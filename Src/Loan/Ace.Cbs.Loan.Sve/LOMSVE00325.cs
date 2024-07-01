using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Windows.CXServer.Utt;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Cle;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Loan.Sve
{
    //Added by HWKO (28-Jul-2017)
    public class LOMSVE00325 : BaseService, ILOMSVE00325
    {
        #region Properties

        public ICXSVE00002 CodeGenerator { get; set; }

        private ILOMDAO00311 personalLoanDAO;
        public ILOMDAO00311 PersonalLoanDAO
        {
            get { return this.personalLoanDAO; }
            set { this.personalLoanDAO = value; }
        }

        #endregion

        #region Methods

        public string GetACodeByACNoName(string acnoName, string currency)
        {
            return CXCLE00002.Instance.GetScalarObject<string>("COASetup.Client.Select", new object[] { acnoName, currency, CurrentUserEntity.BranchCode, true });
        }

        public string GetACNameByAcode(string acode)
        {
            return CXCLE00002.Instance.GetScalarObject<string>("COA.Client.SelectACName", new object[] { acode, CurrentUserEntity.BranchCode, true });
        }

        public IList<PFMDTO00072> SelectPersonalLoanInfoByloanNoandSourcebr(string plno, string sourcebr)
        {
            PFMDTO00072 acctNoInfoList = new PFMDTO00072();
            IList<PFMDTO00072> returnDtoList = new List<PFMDTO00072>();
            try
            {
                LOMDTO00311 PlDto = this.PersonalLoanDAO.GetPersonalLoansByLnoAndSourceBr(plno, sourcebr);
                if (PlDto == null)
                {
                    throw new Exception("MV90055"); //Invalid Loan No.
                }
                else if (PlDto.CloseDate != null && !PlDto.CloseDate.Equals(System.DateTime.MinValue))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MV90057";     //Loans No. Already Closed! 
                }
                else if (Convert.ToBoolean(PlDto.Vouchered) || (Convert.ToDateTime(PlDto.VoucherDate) != null && !Convert.ToDateTime(PlDto.VoucherDate).Equals(System.DateTime.MinValue)))
                {
                    this.ServiceResult.MessageCode = "MV90080";      //This LoanNo. Is already vouchered…
                    this.ServiceResult.ErrorOccurred = true;
                }
                else if (Convert.ToBoolean(PlDto.NPLCase) || (Convert.ToDateTime(PlDto.NPLDate) != null && !Convert.ToDateTime(PlDto.NPLDate).Equals(System.DateTime.MinValue)))
                {
                    this.ServiceResult.MessageCode = "MV90064";      //NPL Case Is Already Exist.
                    this.ServiceResult.ErrorOccurred = true;
                }
                #region old
                //else
                //{
                //    #region SanctionAmount
                //    LOMDTO00325 dtoForSAmtDr = new LOMDTO00325();
                //    dtoForSAmtDr.Eno = string.Empty;
                //    dtoForSAmtDr.LoanNo = PlDto.PLNo;
                //    dtoForSAmtDr.Currency = PlDto.Cur;
                //    dtoForSAmtDr.SAmt = Convert.ToDecimal(PlDto.SAmt);
                //    dtoForSAmtDr.AcctNo = this.GetACodeByACNoName("PLLOANS", PlDto.Cur);
                //    dtoForSAmtDr.Desp = this.GetACNameByAcode(dtoForSAmtDr.AcctNo);
                //    dtoForSAmtDr.DCAmt = Convert.ToDecimal(PlDto.SAmt);
                //    dtoForSAmtDr.DCDesp = "Debit";
                //    returnDtoList.Add(dtoForSAmtDr);

                //    LOMDTO00325 dtoForSAmtCr = new LOMDTO00325();
                //    dtoForSAmtCr.Eno = string.Empty;
                //    dtoForSAmtCr.LoanNo = PlDto.PLNo;
                //    dtoForSAmtCr.Currency = PlDto.Cur;
                //    dtoForSAmtCr.SAmt = Convert.ToDecimal(PlDto.SAmt);
                //    dtoForSAmtCr.AcctNo = PlDto.ACNo;
                //    dtoForSAmtCr.Desp = this.GetACNameByAcode(this.GetACodeByACNoName("PLCONTROL", PlDto.Cur));
                //    dtoForSAmtCr.DCAmt = Convert.ToDecimal(PlDto.SAmt);
                //    dtoForSAmtCr.DCDesp = "Credit";
                //    returnDtoList.Add(dtoForSAmtCr);
                //    #endregion

                //    #region Documentation Fee
                //    if (PlDto.DocFee > 0)
                //    {
                //        LOMDTO00325 dtoForDocFeeDr = new LOMDTO00325();
                //        dtoForDocFeeDr.Eno = string.Empty;
                //        dtoForDocFeeDr.LoanNo = PlDto.PLNo;
                //        dtoForDocFeeDr.Currency = PlDto.Cur;
                //        dtoForDocFeeDr.SAmt = Convert.ToDecimal(PlDto.SAmt);
                //        dtoForDocFeeDr.AcctNo = PlDto.ACNo;
                //        dtoForDocFeeDr.Desp = this.GetACNameByAcode(this.GetACodeByACNoName("PLCONTROL", PlDto.Cur));
                //        dtoForDocFeeDr.DCAmt = Convert.ToDecimal(PlDto.DocFee);
                //        dtoForDocFeeDr.DCDesp = "Debit";
                //        returnDtoList.Add(dtoForDocFeeDr);

                //        LOMDTO00325 dtoForDocFeeCr = new LOMDTO00325();
                //        dtoForDocFeeCr.Eno = string.Empty;
                //        dtoForDocFeeCr.LoanNo = PlDto.PLNo;
                //        dtoForDocFeeCr.Currency = PlDto.Cur;
                //        dtoForDocFeeCr.SAmt = Convert.ToDecimal(PlDto.SAmt);
                //        dtoForDocFeeCr.AcctNo = this.GetACodeByACNoName("DOCINCOME", PlDto.Cur);
                //        dtoForDocFeeCr.Desp = this.GetACNameByAcode(dtoForDocFeeCr.AcctNo);
                //        dtoForDocFeeCr.DCAmt = Convert.ToDecimal(PlDto.DocFee);
                //        dtoForDocFeeCr.DCDesp = "Credit";
                //        returnDtoList.Add(dtoForDocFeeCr);
                //    }
                //    #endregion

                //    #region Service Charges
                //    if (PlDto.isSCharge == true && PlDto.SCharges > 0)
                //    {
                //        LOMDTO00325 dtoForSChargeDr = new LOMDTO00325();
                //        dtoForSChargeDr.Eno = string.Empty;
                //        dtoForSChargeDr.LoanNo = PlDto.PLNo;
                //        dtoForSChargeDr.Currency = PlDto.Cur;
                //        dtoForSChargeDr.SAmt = Convert.ToDecimal(PlDto.SAmt);
                //        dtoForSChargeDr.AcctNo = PlDto.ACNo;
                //        dtoForSChargeDr.Desp = this.GetACNameByAcode(this.GetACodeByACNoName("PLCONTROL", PlDto.Cur));
                //        dtoForSChargeDr.DCAmt = Convert.ToDecimal(PlDto.SCharges);
                //        dtoForSChargeDr.DCDesp = "Debit";
                //        returnDtoList.Add(dtoForSChargeDr);

                //        LOMDTO00325 dtoForSChargeCr = new LOMDTO00325();
                //        dtoForSChargeCr.Eno = string.Empty;
                //        dtoForSChargeCr.LoanNo = PlDto.PLNo;
                //        dtoForSChargeCr.Currency = PlDto.Cur;
                //        dtoForSChargeCr.SAmt = Convert.ToDecimal(PlDto.SAmt);
                //        dtoForSChargeCr.AcctNo = this.GetACodeByACNoName("PLSCHARGE", PlDto.Cur);
                //        dtoForSChargeCr.Desp = this.GetACNameByAcode(dtoForSChargeCr.AcctNo);
                //        dtoForSChargeCr.DCAmt = Convert.ToDecimal(PlDto.SCharges);
                //        dtoForSChargeCr.DCDesp = "Credit";
                //        returnDtoList.Add(dtoForSChargeCr);
                //    }
                //    #endregion
                //}
                #endregion
                else
                {
                    acctNoInfoList.AccountNo = PlDto.ACNo;
                    acctNoInfoList.LoanNo = PlDto.PLNo;
                    acctNoInfoList.SAmt = Convert.ToDecimal(PlDto.SAmt);
                    acctNoInfoList.CurrencyCode = PlDto.Cur;
                    acctNoInfoList.sCharge = Convert.ToDecimal(PlDto.SCharges);
                    acctNoInfoList.docFee = Convert.ToDecimal(PlDto.DocFee);

                    returnDtoList.Add(acctNoInfoList);
                }
            }
            catch (Exception ex)
            {
                this.ServiceResult.MessageCode = CXServiceWrapper.Instance.ServiceResult.MessageCode;     //Invalid Loan No.
                this.ServiceResult.ErrorOccurred = true;
            }
            return returnDtoList;
        }

        [Transaction(TransactionPropagation.Required)]
        public string Save_PersonalLoansVoucher(string plno, string sourcebr)
        {
            string voucherno = string.Empty;
            try
            {
                LOMDTO00311 PlDto = this.PersonalLoanDAO.GetPersonalLoansByLnoAndSourceBr(plno, sourcebr);
                if (PlDto == null)
                {
                    throw new Exception("MV90055"); //Invalid Loan No.
                }
                else
                {
                    DateTime nextSettlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("NextSettlementDate"), sourcebr, true });
                    voucherno = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, 1, sourcebr, new object[] { nextSettlementDate.ToString("dd"), nextSettlementDate.ToString("MM"), nextSettlementDate.ToString("yy") });

                    LOMDTO00311 result = this.PersonalLoanDAO.PersonalLoanVoucherEntry(voucherno, plno, sourcebr);

                    if (result.RetMsg != "0")
                    {
                        this.ServiceResult.ErrorOccurred = true;
                    }
                }
            }
            catch (Exception ex)
            {
                this.ServiceResult.MessageCode = CXServiceWrapper.Instance.ServiceResult.MessageCode;     //Invalid Loan No.
                this.ServiceResult.ErrorOccurred = true;
            }
            return voucherno;
        }

        public string Get_CustomerName_PLVoucher(string plNo)
        {
            return this.personalLoanDAO.Get_CustomerName_PLVoucher(plNo);
        }

        #endregion
    }
}
