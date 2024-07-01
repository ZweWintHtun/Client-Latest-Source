using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Windows.CXServer.Utt;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Dto;

namespace Ace.Cbs.Loan.Sve
{
    public class LOMSVE00028 : BaseService, ILOMSVE00028
    {
        public ILOMDAO00013 LegalDAO { get; set; }
        public ICXSVE00006 CodeChecker { get; set; }
        public ICXSVE00002 CodeGenerator { get; set; }
        public ILOMDAO00022 LrpLegalDAO { get; set; }
        public IPFMDAO00054 TLFDAO { get; set; }       

        public IList<LOMDTO00013> CheckLegalLoanNo(string loanNo, string sourceBr)
        {
            IList<LOMDTO00013> legalList = LegalDAO.SelectLegalInfoByCloseDateNull(loanNo, sourceBr);
            if (legalList == null || legalList.Count < 1)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV90055; //Invalid Loan No.
                return null;
            }
            else
            {
                if (legalList[0].CloseDate != null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV90057; //Loans No. Already Closed!
                    return null;
                }
                else if (legalList[0].AcceptDate == null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV90077; //Loans No. Already Accepted!
                    return null;
                }
                else if (legalList[0].ReleaseDate != null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV90074; //This legal case loan is already released.
                    return null;
                }
                else if (legalList[0].AcType == "LOANS")
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV90082; //Legal Overdraft type only...
                    return null;
                }
                else
                {
                    IList<PFMDTO00072> CustomerInfo = this.CodeChecker.GetCurrentAccountInfoByAccountNumber(legalList[0].AcctNo);
                    if (CustomerInfo.Count > 0)
                    {
                        for (int i = 0; i < CustomerInfo.Count; i++)
                        {
                            legalList[i].Name = CustomerInfo[i].CustomerName;
                            legalList[i].Amount = CustomerInfo[i].CurrentBalance;
                            legalList[i].AccountSign = CustomerInfo[i].AccountSignature;
                        }
                    }
                }
                return legalList;
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public void SaveLegalODRepayment(IList<LOMDTO00013> repaymentInfo, decimal currentBalance, string channel, string sourceBr, int workStationId, string currentUserName, int currentUserId)
        {
            try
            {                
                DateTime NextSettlementDate = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), sourceBr);
                decimal HomeExchangeRate = CXCOM00010.Instance.GetExchangeRate(repaymentInfo[0].Cur, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType));
                string voucherNumber = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, currentUserId, sourceBr, new object[] { NextSettlementDate.Day.ToString().PadLeft(2, '0'), NextSettlementDate.Month.ToString().PadLeft(2, '0'), NextSettlementDate.Year.ToString().Substring(2) });
                
                string returnNo = string.Empty;
                bool IsAutoLink = false;
                string userId = currentUserId.ToString();

                //Insert Into LrpLegal Table
                this.ConvertToLrpLegalORM(repaymentInfo, repaymentInfo[0].Cur, sourceBr, voucherNumber, workStationId, currentUserId);

                //Insert Into Tlf Table  , //Update Cbal in Cledger                
                foreach (LOMDTO00013 repaydata in repaymentInfo)
                {
                    if (repaydata.LoansDesp == "Dr")
                    {
                        IsAutoLink = this.DebitInformationCheckingAndLink(repaydata);
                        if (IsAutoLink == true) return;
                        returnNo = CXServiceWrapper.Instance.Invoke<ICXSVE00010, string>(x => x.UpdateForTransfer(voucherNumber, repaydata.AcctNo, repaydata.SAmt.Value, 0, string.Empty, "D", IsAutoLink, repaydata.LoansDesp, userId, repaydata.Cur, HomeExchangeRate, sourceBr, NextSettlementDate, channel));
                    }
                    else
                        returnNo = CXServiceWrapper.Instance.Invoke<ICXSVE00010, string>(x => x.UpdateForTransfer(voucherNumber, repaydata.AcctNo, repaydata.SAmt.Value, 0, string.Empty, "C", IsAutoLink, repaydata.LoansDesp, userId, repaydata.Cur, HomeExchangeRate, sourceBr, NextSettlementDate, channel));
                    
                    if (this.ServiceResult.ErrorOccurred)
                    {
                        this.ServiceResult.MessageCode = returnNo; // Not Allow Saving Debit Transaction for more than one time in a week
                        //return string.Empty;
                        throw new Exception(this.ServiceResult.MessageCode);
                    }
                }
                //Update lno in Tlf Table 
                this.TLFDAO.UpdateTlfByLnoAndRepayNo(repaymentInfo[0].Lno, voucherNumber, sourceBr, currentUserId);

                //Update Legal Table
                this.LegalDAO.UpateLegalForLoanRepay(currentBalance, voucherNumber, repaymentInfo[0].AcctNo, repaymentInfo[0].Lno, sourceBr, currentUserId);

                this.ServiceResult.ErrorOccurred = false;
                return;
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                throw new Exception(ex.Message);
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public bool DebitInformationCheckingAndLink(LOMDTO00013 repaydata)
        {
            string messageNo = string.Empty;           
            bool isLink = false;
           
            //Check Amount
            if (!this.CodeChecker.CheckAmount(repaydata.AcctNo, repaydata.SAmt.Value, true, false, true, ref isLink, ref messageNo))
            {
                string _m = messageNo;
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = messageNo;
                return false;
            }
            return isLink;
        }       

        public TLMDTO00005 GetTranType(string tranCode)
        {
            TLMDTO00005 trantypeDTO = CXCOM00011.Instance.GetScalarObject<TLMDTO00005>("TranType.Server.SelectByTranCode", new object[] { tranCode });// WITHDRAW(status)

            if (trantypeDTO == null)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME00021; // Client Data Not Found.
                return null;
            }
            else
            {
                return trantypeDTO;
            }
        }

        public void ConvertToLrpLegalORM(IList<LOMDTO00013> legalList, string currency, string sourceBr, string voucherNumber, int workstationId, int currentUserId)
        {
            LOMORM00022 LrpLegalORM = new LOMORM00022();
            // LrpLegalORM.Id = LrpLegalDAO.SelectMaxId() + 1;
            //LrpLegalORM.RepayNo = legalList[0].RepayNo;
            LrpLegalORM.RepayNo = voucherNumber;
            LrpLegalORM.Lno = legalList[0].Lno;
            LrpLegalORM.AcctNo = legalList[1].AcctNo;
            LrpLegalORM.Date_Time = DateTime.Now;
            LrpLegalORM.Amount = legalList[0].SAmt.Value;
            LrpLegalORM.UserNo = workstationId.ToString();
            LrpLegalORM.DrAccountNo = legalList[0].DrAccountNo;
            LrpLegalORM.AType = legalList[0].AType;
            LrpLegalORM.SourceBr = sourceBr;
            LrpLegalORM.Cur = currency;
            LrpLegalORM.Active = true;
            LrpLegalORM.CreatedDate = DateTime.Now;
            LrpLegalORM.CreatedUserId = currentUserId;
            LrpLegalDAO.Save(LrpLegalORM);
        }
    }
}
