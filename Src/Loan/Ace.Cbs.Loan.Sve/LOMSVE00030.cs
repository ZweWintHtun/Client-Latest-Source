using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using Ace.Windows.Core.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Ix.Core.Ctr;
using Ace.Windows.Core.DataModel;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Tcm.Ctr.Dao;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Sve
{
    public class LOMSVE00030 : BaseService, ILOMSVE00030
    {
        public ICXSVE00002 CodeGenerator { get; set; }
        public ICXSVE00006 ReversalSVE { get; set; }
        private IPFMDAO00054 TlfDAO { get; set; }
        private IPFMDAO00056 SysDAO { get; set; }
        public ITLMDAO00018 LoansDAO { get; set; }
        public IList<PFMDTO00054> tlfEntity { get; set; }
        public TLMDTO00018 LoanDataByLoanNo { get; set; }

        public TLMDTO00018 RepayLoanEdit(TLMDTO00018 loanDto, bool fullSettlement, string lno, string accountNo, string repayNo, decimal repaymentAmount, string userNo, int userId, decimal newRepaymenAmount, string sourceBr)
        {
            string voucherNo, reversalVouno;
            DateTime sys001 = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("NextSettlementDate"), loanDto.SourceBranchCode, true });
            decimal rate = CXCOM00010.Instance.GetExchangeRate(loanDto.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType));

            string day = sys001.Day.ToString().PadLeft(2, '0');
            string month = sys001.Month.ToString().PadLeft(2, '0');
            string year = sys001.Year.ToString().Substring(2);
            int updatedUserId = loanDto.CreatedUserId;

            voucherNo = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, updatedUserId, loanDto.SourceBranchCode, new object[] { day, month, year });
            reversalVouno = this.CodeGenerator.GetGenerateCode("Reversal Code", string.Empty, updatedUserId, loanDto.SourceBranchCode, new object[] { day, month, year });

            TLMDTO00018 LoanDTO = LoansDAO.RepayLoanEdit(fullSettlement, lno, accountNo, repayNo, repaymentAmount, userNo, userId, newRepaymenAmount, reversalVouno, sourceBr,voucherNo);

            if (LoanDTO == null || LoanDTO.ResultCode == "0001")
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV90055.ToString(); //Invalid Loan No.
                return LoanDTO;
            }

            //tlfEntity = GetTlfDataForLoanRepaymentEditing(repayNo, sourceBr);
            //this.ReversalSVE.ReversalProcess(this.tlfEntity[0].Eno, reversalVouno, null, loanDto.SourceBranchCode, loanDto.CreatedDate, loanDto.SourceBranchCode, updatedUserId, new TLMDTO00015(), "TRCREDIT", false);  // Call Commodule to save Tlf table 

            //PFMORM00054 creditTransactionLog = this.GetTransactionLogFile(loanDto, loanDto.CreditAccountCode, voucherNo, accountNo, loanDto.CreditAccountDesp,
            //     "TCV", rate, sys001, "TRCREDIT", loanDto.Assessor);
            ////Insert Tlf
            //this.TlfDAO.Save(creditTransactionLog);
            //loanDto.LastRepaymentNo = repayNo;
            //loanDto.Lno = lno;
            //PFMORM00054 debitTransactionLog = this.GetTransactionLogFile(loanDto, loanDto.AType, voucherNo, loanDto.AType, loanDto.BType,
            //    "TDV", rate, sys001, "TRDEBIT", loanDto.Assessor);
            ////Insert Tlf
            //this.TlfDAO.Save(debitTransactionLog);

            return LoanDTO;
        }

        public TLMDTO00018 GetLoanInformationForRepaymentEdit(string lno, string sourceBr)
        {
            TLMDTO00018 LoanDTO = LoansDAO.GetLoanInformationForRepaymentEdit(lno, sourceBr);
            LoanDataByLoanNo = LoanDTO;

            if (LoanDTO == null)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV90055; //Invalid Loan No.
                return null;
            }
            else
            {
                this.GetTlfDataForLoanRepaymentEditing(LoanDTO.LastRepaymentNo, sourceBr);
                if (tlfEntity.Count == 0 || tlfEntity == null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV90055; //Invalid Loan No.
                    return LoanDTO;
                }
                else
                    LoanDTO.Currency = tlfEntity[0].OtherBankChq;  //sourcecur
            }
            return LoanDTO;
        }

        private IList<PFMDTO00054> GetTlfDataForLoanRepaymentEditing(string lgno, string sourcebr)
        {
            tlfEntity = this.TlfDAO.SelectTlfInfoByLGNo(lgno, sourcebr);

            return tlfEntity;
        }

        //[Transaction(TransactionPropagation.Required)]
        //public void SaveODLimitChangeData(TLMDTO00018 odLimitChangeEntity)
        //{
        //    try
        //    {
        //        Rate = CXCOM00010.Instance.GetExchangeRate(odLimitChangeEntity.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType));
        //        if (Rate == 0)
        //        {
        //            this.ServiceResult.ErrorOccurred = true;
        //            this.ServiceResult.MessageCode = CXMessage.ME00021; //Client Data Not Found.
        //            return;
        //        }
        //        SettlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), odLimitChangeEntity.SourceBranchCode, true });
        //        if (SettlementDate == null)
        //        {
        //            this.ServiceResult.ErrorOccurred = true;
        //            this.ServiceResult.MessageCode = CXMessage.ME00021; // Client Data Not Found.
        //            return;
        //        }
        //        if (odLimitChangeEntity.NewTotalODLimit > odLimitChangeEntity.TotalODLimit)  //IF New Limit >Old Limit then
        //        {
        //            if (!this.ODOnly(odLimitChangeEntity))
        //            {
        //                this.ServiceResult.ErrorOccurred = true;
        //                return;
        //            }
        //        }
        //            //else
        //            //{
        //                NewSetupDAO.UpdateValueOfRunTrigger("Enable", odLimitChangeEntity.UpdatedUserId.Value);

        //                //*** Update on Cledger ***
        //                decimal oVDLimit = odLimitChangeEntity.TotalODLimit + (odLimitChangeEntity.NewODLimit - odLimitChangeEntity.PresentODLimit);
        //                CledgerDAO.UpdateOVDLimitInCledger(oVDLimit, odLimitChangeEntity.SourceBranchCode, odLimitChangeEntity.AccountNo, odLimitChangeEntity.UpdatedUserId.Value);

        //                //'*** Update on Loans ***
        //                LoansDAO.UpdateSamtAndFirstSamt(odLimitChangeEntity.NewODLimit, odLimitChangeEntity.Lno, odLimitChangeEntity.SourceBranchCode, odLimitChangeEntity.AccountNo, odLimitChangeEntity.UpdatedUserId.Value);

        //                //'*** Insert into LMT99#00 ***
        //                LMT99DAO.Save(this.ConvertToLimitFileORM(odLimitChangeEntity));
        //            //}
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //[Transaction(TransactionPropagation.Required)]
        //public bool ODOnly(TLMDTO00018 odLimitChangeEntity)
        //{
        //    int restofdays = 0;
        //    bool autolink = true;
        //    string commissionCode;
        //    int Dayinyear=0;

        //    if (odLimitChangeEntity != null)
        //    {
        //        restofdays = (Convert.ToDateTime(odLimitChangeEntity.ExpireDate)-DateTime.Now).Days + 2;
        //    }

        //    PFMDTO00009 SCharges = RateFileDAO.SelectByRateCode("SchargeNew");            
        //   // int Dayinyear = 337 + (Convert.ToInt32(Convert.ToDateTime("03/01/" + (DateTime.Now.Year)).Day-1));    //number of days in 1 year           

        //    if(DateTime.IsLeapYear(DateTime.Now.Year))
        //        Dayinyear=366;
        //    else
        //        Dayinyear=365;

        //    douAmt = (((odLimitChangeEntity.NewODLimit - odLimitChangeEntity.PresentODLimit) * (SCharges.Rate / 100)) / Dayinyear) * Convert.ToDecimal(restofdays);  //' 1% amount

        //    this.ServiceResult.MessageCode = CXMessage.MV90063 + "."+douAmt.ToString();  //Service Charges {0} will be deducted from Account no.: {1}            

        //    commissionCode = CXCOM00011.Instance.GetScalarObject<string>("COASetup.Server.Select", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NewServiceCharge), odLimitChangeEntity.Currency, odLimitChangeEntity.SourceBranchCode, true });   // a/c code for Commssion

        //    //update Chargesstatus of Loan file when this a/c is OD
        //    LoansDAO.UpdateChargesstatus("Y", odLimitChangeEntity.Lno, Convert.ToInt32(odLimitChangeEntity.UpdatedUserId));

        //    string voucherNumber = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, odLimitChangeEntity.UpdatedUserId.Value, odLimitChangeEntity.SourceBranchCode, new object[] { SettlementDate.Day.ToString().PadLeft(2, '0'), SettlementDate.Month.ToString().PadLeft(2, '0'), SettlementDate.Year.ToString().Substring(2) });  //Transaction Voucher

        //    if (douAmt < odLimitChangeEntity.OverdraftAmount) //ouAmt Begin
        //    {
        //        autolink = false ;   // 1 - Autolink(true) , 0 - Normal(false)
        //    }

        //    string[] vouType = new string[] {"D","C"};    
        //    string[] accountNo = new string[] {odLimitChangeEntity.AccountNo,commissionCode};
        //    string channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);

        //    for(int i=0; i < vouType.Count() ; i++)
        //    {
        //        string account =accountNo[i].ToString();
        //        string voucherType = vouType[i].ToString();                
        //        ///*** Insert into tlf ***   (2 transaction will save. one with customerAcc and one with acode)
        //        if (!CXServiceWrapper.Instance.Invoke<ICXSVE00010, bool>(x => x.Sp_SERVICECHARGES_VOU(voucherNumber, account, odLimitChangeEntity.Lno, "Service Charges for Limit Change", douAmt, 0, odLimitChangeEntity.UserNo, voucherType,
        //        false,odLimitChangeEntity.Currency,Convert.ToInt32(Rate),odLimitChangeEntity.SourceBranchCode, SettlementDate,channel,true, string.Empty)))
        //        {
        //            this.ServiceResult.ErrorOccurred = true;
        //            this.ServiceResult.MessageCode = CXMessage.ME00018;   //Transaction is not Success!
        //            //throw new Exception(this.ServiceResult.MessageCode);                   
        //        }
        //    }
        //    ///*** Insert into Services_Charges ***
        //    this.ServiceChargesDAO.Save(this.ConvertToService_ChargesORM(odLimitChangeEntity));
        //    return true;
        //}

        //public TCMORM00002 ConvertToService_ChargesORM(TLMDTO00018 odLimitChangeEntity)
        //{
        //    TCMORM00002 ServiceChargesORM = new TCMORM00002();
        //    ServiceChargesORM.LNo = odLimitChangeEntity.Lno;
        //    ServiceChargesORM.AcctNo = odLimitChangeEntity.AccountNo;
        //    ServiceChargesORM.Desp = "OD Limit Change";
        //    ServiceChargesORM.GetColo = string.Empty;
        //    ServiceChargesORM.VouDate = DateTime.Now;
        //    ServiceChargesORM.Amount = douAmt;
        //    ServiceChargesORM.SourceBr = odLimitChangeEntity.SourceBranchCode;
        //    ServiceChargesORM.Cur = odLimitChangeEntity.Currency;
        //    ServiceChargesORM.Active = true;
        //    ServiceChargesORM.CreatedDate = DateTime.Now;
        //    ServiceChargesORM.CreatedUserId = odLimitChangeEntity.CreatedUserId;
        //    return ServiceChargesORM;
        //}

        //public LOMORM00011 ConvertToLimitFileORM(TLMDTO00018 odLimitChangeEntity)
        //{
        //    LOMORM00011 LimitFileORM = new LOMORM00011();
        //    LimitFileORM.AcctNo = odLimitChangeEntity.AccountNo;
        //    LimitFileORM.CloseDate = odLimitChangeEntity.CloseDate ;
        //    LimitFileORM.Cur = odLimitChangeEntity.Currency ;
        //    LimitFileORM.Date_Time = DateTime.Now ;
        //    LimitFileORM.LoanNo = odLimitChangeEntity.Lno ;
        //    LimitFileORM.OLDLimit = odLimitChangeEntity.TotalODLimit ;
        //    LimitFileORM.OVDLimit = odLimitChangeEntity.NewODLimit ;
        //    LimitFileORM.SourceBr = odLimitChangeEntity.SourceBranchCode ;
        //    LimitFileORM.UserNo = odLimitChangeEntity.UserNo ;
        //    LimitFileORM.Active = true ;
        //    LimitFileORM.CreatedDate = DateTime.Now;
        //    LimitFileORM.CreatedUserId = odLimitChangeEntity.CreatedUserId;
        //    return LimitFileORM;
        //}

        //    private PFMORM00054 GetTransactionLogFile(TLMDTO00018 LoansDto, string acode, string voucherno, string acctno, string desp, string status, decimal rate, DateTime settlementdate, string trancode, string channel)
        //    {
        //        PFMORM00054 tlfORM = new PFMORM00054();
        //        tlfORM.Id = this.TlfDAO.SelectMaxId() + 1;
        //        tlfORM.Eno = voucherno;
        //        tlfORM.AccountNo = acctno;
        //        tlfORM.Acode = acode;
        //        tlfORM.Lno = LoansDto.Lno;
        //        tlfORM.Amount = Convert.ToDecimal(LoansDto.SAmount);
        //        tlfORM.HomeAmount = LoansDto.SAmount;
        //        tlfORM.HomeAmt = 0;
        //        tlfORM.HomeOAmt = 0;
        //        tlfORM.LocalAmt = LoansDto.SAmount;
        //        tlfORM.LocalAmount = LoansDto.SAmount;
        //        tlfORM.LocalOAmt = 0;
        //        tlfORM.Description = desp;
        //        tlfORM.Narration = "LoansRepayEntEdit:" + LoansDto.Lno;
        //        tlfORM.DateTime = LoansDto.CreatedDate;
        //        tlfORM.Status = status;
        //        tlfORM.TransactionCode = trancode;
        //        tlfORM.AccountSign = LoansDto.ACSign;
        //        tlfORM.UserNo = LoansDto.CreatedUserId.ToString();
        //        tlfORM.SourceCurrency = LoansDto.Currency;
        //        tlfORM.Rate = rate;
        //        tlfORM.SourceBranchCode = LoansDto.SourceBranchCode;
        //        tlfORM.SettlementDate = settlementdate;
        //        tlfORM.Channel = channel;
        //        tlfORM.ReferenceType = "LOANS";
        //        tlfORM.ReferenceVoucherNo = LoansDto.Lno;
        //        tlfORM.GChequeNo = "1";
        //        tlfORM.LgNo = LoansDto.LastRepaymentNo;
        //        tlfORM.CreatedDate = LoansDto.CreatedDate;
        //        tlfORM.CreatedUserId = LoansDto.CreatedUserId;
        //        return tlfORM;
        //    }
        //}
    }
}
