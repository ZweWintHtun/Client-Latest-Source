using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Dao;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using NHibernate;
using NHibernate.Transform;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Loan.Dmd.DTO;
using System.Data.SqlClient;

namespace Ace.Cbs.Loan.Dao
{
    public class LOMDAO00311 : DataRepository<LOMORM00311>, ILOMDAO00311
    {
        //string PLNo,string AcctNo,int NoOfTerms,decimal SanAmt,decimal IntRate,decimal DocumentFee,
        //int PaymentDuration,string PaymentOptionId,string UserNo,string SourceBr,string Cur,int CreatedUserId,
        //string ENo,DateTime SDate
        [Transaction(TransactionPropagation.Required)]
        public LOMDTO00311 AddPLRegTermAndVouUpdate(string PLNo,string AcctNo,int NoOfTerms,decimal SanAmt,decimal IntRate,decimal DocumentFee,
            int PaymentDuration,string PaymentOptionId, string UserNo, string SourceBr, string Cur,int CreatedUserId, string ENo,DateTime SDate
            ,string BType,DateTime ExpireDate,string Assessor,string Lawer,decimal MonthlyIncome, string MonthlyRepaymentDate, string ProductType, string CompanyName,
             bool isSCharge, decimal SCharges, bool isLateFee, string GuaCompanyName, string GuaName, string GuaNrc, string GuaPhone,
            decimal NYIntRate,int gracePeriod)//Updated by HWKO (02-Oct-2017)
        {
            LOMDTO00311 dto = new LOMDTO00311();
            //if (PaymentDuration >= 12)
            //{
            if (ProductType == "Myanmar Net Customer")
            {
                //IQuery query = this.Session.GetNamedQuery("SP_PLReg_Detail_Vou");
                IQuery query = this.Session.GetNamedQuery("SP_PLReg_Detail_Vou_MyannmarNetCustomer");
                query.SetString("plno", PLNo);
                query.SetString("acctNo", AcctNo);
                query.SetInt32("noofterms", NoOfTerms);
                query.SetDecimal("sanAmt", SanAmt);
                query.SetDecimal("intRate", IntRate);
                query.SetDecimal("documentFee", DocumentFee);
                query.SetInt32("paymentDuration", PaymentDuration);
                query.SetString("paymentOptionId", PaymentOptionId);
                query.SetString("userNo", UserNo);
                query.SetString("sourceBr", SourceBr);
                query.SetString("cur", Cur);
                query.SetInt32("createdUserId", CreatedUserId);
                query.SetString("eno", ENo);
                query.SetDateTime("sdate", SDate);
                query.SetString("btype", BType);
                query.SetDateTime("expireDate", ExpireDate);
                query.SetString("assessor", Assessor);
                query.SetString("lawer", Lawer);
                query.SetDecimal("monthlyIncome", MonthlyIncome);
                query.SetString("companyName", CompanyName);
                query.SetBoolean("isscharge", isSCharge);
                query.SetDecimal("scharges", SCharges);
                query.SetBoolean("islatefee", isLateFee);
                query.SetString("guacompanyName", GuaCompanyName);
                query.SetString("guaname", GuaName);
                query.SetString("guanrc", GuaNrc);
                query.SetString("guaphone", GuaPhone);
                query.SetDecimal("nyintrate", NYIntRate);
                query.SetInt32("graceperiod", gracePeriod);
                query.SetString("monthlyRepayDD", MonthlyRepaymentDate);

                string strResult = query.UniqueResult().ToString();
                string[] strval = strResult.Split(',');

                dto.RetMsg = Convert.ToString(strval[4]);
                if (dto.RetMsg == "0")
                {
                    dto.InterestAmount = decimal.Parse(strval[0]);
                    dto.InstallmentAmount = decimal.Parse(strval[1]);
                    dto.Eno = Convert.ToString(strval[2]);
                    dto.DueDate = DateTime.Parse(strval[3]);
                }
            }
            else 
            {
                IQuery query = this.Session.GetNamedQuery("SP_PLReg_Detail_Vou");
                query.SetString("plno", PLNo);
                query.SetString("acctNo", AcctNo);
                query.SetInt32("noofterms", NoOfTerms);
                query.SetDecimal("sanAmt", SanAmt);
                query.SetDecimal("intRate", IntRate);
                query.SetDecimal("documentFee", DocumentFee);
                query.SetInt32("paymentDuration", PaymentDuration);
                query.SetString("paymentOptionId", PaymentOptionId);
                query.SetString("userNo", UserNo);
                query.SetString("sourceBr", SourceBr);
                query.SetString("cur", Cur);
                query.SetInt32("createdUserId", CreatedUserId);
                query.SetString("eno", ENo);
                query.SetDateTime("sdate", SDate);
                query.SetString("btype", BType);
                query.SetDateTime("expireDate", ExpireDate);
                query.SetString("assessor", Assessor);
                query.SetString("lawer", Lawer);
                query.SetDecimal("monthlyIncome", MonthlyIncome);
                query.SetString("companyName", CompanyName);
                query.SetBoolean("isscharge", isSCharge);
                query.SetDecimal("scharges", SCharges);
                query.SetBoolean("islatefee", isLateFee);
                query.SetString("guacompanyName", GuaCompanyName);
                query.SetString("guaname", GuaName);
                query.SetString("guanrc", GuaNrc);
                query.SetString("guaphone", GuaPhone);
                query.SetDecimal("nyintrate", NYIntRate);
                query.SetInt32("graceperiod", gracePeriod);

                string strResult = query.UniqueResult().ToString();
                string[] strval = strResult.Split(',');

                dto.RetMsg = Convert.ToString(strval[4]);
                if (dto.RetMsg == "0")
                {
                    dto.InterestAmount = decimal.Parse(strval[0]);
                    dto.InstallmentAmount = decimal.Parse(strval[1]);
                    dto.Eno = Convert.ToString(strval[2]);
                    dto.DueDate = DateTime.Parse(strval[3]);
                }
            }
            //}
            //else if (@PaymentDuration < 12)
            //{
            //    IQuery query = this.Session.GetNamedQuery("SP_PLReg_Detail_Vou_ByPaymentDurationLessThanOneYr");
            //    query.SetString("plno", PLNo);
            //    query.SetString("acctNo", AcctNo);
            //    query.SetInt32("noofterms", NoOfTerms);
            //    query.SetDecimal("sanAmt", SanAmt);
            //    query.SetDecimal("intRate", IntRate);
            //    query.SetDecimal("documentFee", DocumentFee);
            //    query.SetInt32("paymentDuration", PaymentDuration);
            //    query.SetString("paymentOptionId", PaymentOptionId);
            //    query.SetString("userNo", UserNo);
            //    query.SetString("sourceBr", SourceBr);
            //    query.SetString("cur", Cur);
            //    query.SetInt32("createdUserId", CreatedUserId);
            //    query.SetString("eno", ENo);
            //    query.SetDateTime("sdate", SDate);
            //    query.SetString("btype", BType);
            //    query.SetDateTime("expireDate", ExpireDate);
            //    query.SetString("assessor", Assessor);
            //    query.SetString("lawer", Lawer);
            //    query.SetDecimal("monthlyIncome", MonthlyIncome);
            //    query.SetString("companyName", CompanyName);
            //    query.SetBoolean("isscharge", isSCharge);
            //    query.SetDecimal("scharges", SCharges);
            //    query.SetBoolean("islatefee", isLateFee);
            //    query.SetString("guacompanyName", GuaCompanyName);
            //    query.SetString("guaname", GuaName);
            //    query.SetString("guanrc", GuaNrc);
            //    query.SetString("guaphone", GuaPhone);
            //    query.SetDecimal("nyintrate", NYIntRate);
            //    query.SetInt32("graceperiod", gracePeriod);

            //    string strResult = query.UniqueResult().ToString();
            //    string[] strval = strResult.Split(',');

                
            //    dto.RetMsg = Convert.ToString(strval[4]);
            //    if (dto.RetMsg == "0")
            //    {
            //        dto.InterestAmount = decimal.Parse(strval[0]);
            //        dto.InstallmentAmount = decimal.Parse(strval[1]);
            //        dto.Eno = Convert.ToString(strval[2]);
            //        dto.DueDate = DateTime.Parse(strval[3]);
            //    }
            //}
            return dto;
        }

        //Added by HWKO (27-Jun-2017)
        public int GetLegalCaseFromPersonalLoansByAccountNo(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("LOMORM00311.SelectLegalCaseAccountByAcctNoForPersonalLoan");
            query.SetString("acctNo", accountNo);

            int count = query.List().Count;
            return count;
        }

        [Transaction(TransactionPropagation.Required)]
        public string PLMonthlyAutoPaymentProc(string sourceBr, int createdUserId, string userName)
        {
            IQuery query = this.Session.GetNamedQuery("SP_PL_Monthly_AutoPayment_ForAllPLAccount");            
            query.SetString("sourcebr", sourceBr);
            query.SetInt32("createduserid", createdUserId);
            query.SetString("username", userName);
            query.SetTimeout(10000); // Added By AAM(15_Aug_2018)
            return query.UniqueResult().ToString();
        }

        [Transaction(TransactionPropagation.Required)]
        public string PLLateFeesCalculationProcess(string sourceBr, int createdUserId, string userName)
        {
            IQuery query = this.Session.GetNamedQuery("SP_PL_GetLateFeesForAllPLAccount");
            query.SetString("sourcebr", sourceBr);
            query.SetInt32("createduserid", createdUserId);
            query.SetString("username", userName);
            return query.UniqueResult().ToString();
        }

        public LOMDTO00311 GetPersonalLoansByLnoAndSourceBr(string loanNo, string sourceBr)
        {
            var query = this.Session.GetNamedQuery("LOMORM00311.GetPersonalLoansByLnoAndSourceBr")
            .SetString("lno", loanNo)
            .SetString("sourceBr", sourceBr)
            .SetResultTransformer(Transformers.AliasToBean<LOMDTO00311>()).List<LOMDTO00311>();
            return query.ToList<LOMDTO00311>().FirstOrDefault();

            //IQuery query = this.Session.GetNamedQuery("LOMORM00311.GetPersonalLoansByLnoAndSourceBr");
            //query.SetString("lno", loanNo);
            //query.SetString("sourceBr", sourceBr);
            //return query.UniqueResult<LOMDTO00311>();
        }

        //Added by HWKO (26-Oct-2017)
        [Transaction(TransactionPropagation.Required)]
        public string GetPLNoByACNoAndSourceBr(string acctNo, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_PL_GetPLNoByAcctNoAndSourceBr");
            query.SetString("acctNo", acctNo);
            query.SetString("sourceBr", sourceBr);
            return query.UniqueResult().ToString();
        }

        //Added by HWKO (08-Dec-2017)
        [Transaction(TransactionPropagation.Required)]
        public string GetHPNoByACNoAndSourceBr(string acctNo, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_HP_GetHPNoByAcctNoAndSourceBr");
            query.SetString("acctNo", acctNo);
            query.SetString("sourceBr", sourceBr);
            return query.UniqueResult().ToString();
        }

        //Added by HWKO (14-Dec-2017)
        [Transaction(TransactionPropagation.Required)]
        public string GetBLNoByACNoAndSourceBr(string acctNo, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_BL_GetLNoByAcctNoAndSourceBr");
            query.SetString("acctNo", acctNo);
            query.SetString("sourceBr", sourceBr);
            return query.UniqueResult().ToString();
        }

        //Added by HWKO (08-Dec-2017)
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00334> GetHPInfoForContractPrinting(string hpNo, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_HP_ContractPrinting");
            query.SetString("hpNo", hpNo);
            query.SetString("sourceBr", sourceBr);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00334)));
            IList<LOMDTO00334> multilist = query.List<LOMDTO00334>();
            return multilist;
        }

        //Added by HWKO (11-Dec-2017)
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00334> GetCustInfoByAcctNo(string acctNo, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_GetCustInfoByAcctNo");
            query.SetString("acctNo", acctNo);
            query.SetString("sourceBr", sourceBr);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00334)));
            IList<LOMDTO00334> multilist = query.List<LOMDTO00334>();
            return multilist;
        }

        //Added by YMP (19-Feb-2019)
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00338> GetCustInfoByAcctNoForBL_LB(string acctNo, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_GetCustInfoByAcctNo");
            query.SetString("acctNo", acctNo);
            query.SetString("sourceBr", sourceBr);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00338)));
            IList<LOMDTO00338> multilist = query.List<LOMDTO00338>();
            return multilist;
        }

        //Added by HWKO (12-Dec-2017)
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00336> GetPLInfoForContractPrinting(string plNo, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_PL_ContractPrinting");
            query.SetString("plNo", plNo);
            query.SetString("sourceBr", sourceBr);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00336)));
            IList<LOMDTO00336> multilist = query.List<LOMDTO00336>();
            return multilist;
        }

        //Added by HWKO (13-Dec-2017)
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00338> GetBLHPInfoForContractPrinting(string lno, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_BL_ContractPrinting_HP");
            query.SetString("lno", lno);
            query.SetString("sourceBr", sourceBr);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00338)));
            IList<LOMDTO00338> multilist = query.List<LOMDTO00338>();
            return multilist;
        }

        //Added by HWKO (13-Dec-2017)
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00338> GetBLLBInfoForContractPrinting(string lno, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_BL_ContractPrinting_LB");
            query.SetString("lno", lno);
            query.SetString("sourceBr", sourceBr);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00338)));
            IList<LOMDTO00338> multilist = query.List<LOMDTO00338>();
            return multilist;
        }

        //Added by HWKO (13-Dec-2017)
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00338> GetBLPGInfoForContractPrinting(string lno, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_BL_ContractPrinting_PG");
            query.SetString("lno", lno);
            query.SetString("sourceBr", sourceBr);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00338)));
            IList<LOMDTO00338> multilist = query.List<LOMDTO00338>();
            return multilist;
        }


        //Added by HWKO (28-Jul-2017)
        [Transaction(TransactionPropagation.Required)]
        public LOMDTO00311 PersonalLoanVoucherEntry(string eno, string plno, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_PL_VoucherUpdate");
            query.SetString("eno", eno);
            query.SetString("plno", plno);
            query.SetString("sourceBr", sourceBr);

            string strResult = query.UniqueResult().ToString();
            string[] strval = strResult.Split(',');

            LOMDTO00311 dto = new LOMDTO00311();
            dto.RetMsg = Convert.ToString(strval[1]);
            if (dto.RetMsg == "0")
            {
                dto.Eno = Convert.ToString(strval[0]);
            }
            return dto;
        }

        //Added by HWKO (13-Oct-2017)
        //For Personal Loans Manual Prepayment

        [Transaction(TransactionPropagation.Required)]
        public string CheckPLAccountandStartTerm(string plNo, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_CheckPLAccountandStartTerm");
            query.SetString("plNo", plNo);
            query.SetString("sourceBr", sourceBr);
            return query.UniqueResult().ToString();
        }

        [Transaction(TransactionPropagation.Required)]
        public string Get_PL_PrepaymentInfo_NewLogic(string plNo, int startTerm, int endTerm, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_Get_PL_PrepaymentInfo_NewLogic");
            query.SetString("plNo", plNo);
            query.SetInt32("startTerm", startTerm);
            query.SetInt32("endTerm", endTerm);
            query.SetString("sourceBr", sourceBr);
            return query.UniqueResult().ToString();
        }

        [Transaction(TransactionPropagation.Required)] 
        public string PL_Manual_Pre_Payment_Process_NewLogic(string plNo, int startTerm, int endTerm, decimal totalPaidInstallmentAmt, decimal totalPaidPrincipleAmt, decimal totalPaidRentalChgAmt,
                                                             decimal rentalDiscountRate, string eno, string sourceBr, int createdUserId, string userName)
        {
            IQuery query = this.Session.GetNamedQuery("SP_PL_Manual_Prepayment_Process_NewLogic");
            query.SetString("plNo", plNo);
            query.SetInt32("startTerm", startTerm);
            query.SetInt32("endTerm", endTerm);
            query.SetDecimal("totalPaidInstallmentAmt", totalPaidInstallmentAmt);
            query.SetDecimal("totalPaidPrincipleAmt", totalPaidPrincipleAmt);
            query.SetDecimal("totalPaidRentalChgAmt", totalPaidRentalChgAmt);
            query.SetDecimal("rentalDiscountRate", rentalDiscountRate);
            query.SetString("eno", eno);
            query.SetString("sourceBr", sourceBr);
            query.SetInt32("createdUserId", createdUserId);
            query.SetString("userName", userName);

            return query.UniqueResult().ToString();
        }

        //Endregion

        //Added by HWKO (16-Oct-2017)
        //Modified by HMW (31-July-2019)
        [Transaction(TransactionPropagation.Required)]
        public string PLLateFeesAutoPayVoucherProcess(string sourceBr, int createdUserId, string userName)
        {
            SqlCommand cmd=new SqlCommand();
            cmd.CommandTimeout = 2400; 
            IQuery query = this.Session.GetNamedQuery("SP_PL_LateFeesAutoPay_Voucher_ALLPLTOD");            
            query.SetString("sourceBr", sourceBr);
            query.SetInt32("createdUserId", createdUserId);
            query.SetString("userName", userName);
            query.SetTimeout(10000); // set transaction timeout values,by AAM(16_July_2018).
            return query.UniqueResult().ToString();
        }

        //Added by HWKO (27-Oct-2017) //For Personal Loans Voucher Outstanding Listing
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00311> GetPLVrOutstandingListing(string sourceBr, string cur)
        {
            IQuery query = this.Session.GetNamedQuery("SP_PL_GetPLVrOutstandingListing");
            query.SetString("sourceBr", sourceBr);
            query.SetString("cur", cur);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00311)));
            IList<LOMDTO00311> multilist = query.List<LOMDTO00311>();
            return multilist;
        }

        //Added by HWKO (07-Nov-2017) //For Business Loans Voucher Outstanding Listing
        [Transaction(TransactionPropagation.Required)]
        public IList<TLMDTO00018> GetBLVrOutstandingListing(string sourceBr, string cur)
        {
            IQuery query = this.Session.GetNamedQuery("SP_BL_GetBLVrOutstandingListing");
            query.SetString("sourceBr", sourceBr);
            query.SetString("cur", cur);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(TLMDTO00018)));
            IList<TLMDTO00018> multilist = query.List<TLMDTO00018>();
            return multilist;
        }

        //Added by HWKO (09-Nov-2017) //For Personal Loans Late Fees Outstanding Listing
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00311> GetPLLFOutstandingListing(string sourceBr, string cur)
        {
            IQuery query = this.Session.GetNamedQuery("SP_PL_LateFeesOutstanding_Listing");
            query.SetString("currency", cur);
            query.SetString("sourceBr", sourceBr);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00311)));
            IList<LOMDTO00311> multilist = query.List<LOMDTO00311>();
            return multilist;
        }

        //Added by AAM (27-Feb-2018) to get Customer Name.
        [Transaction(TransactionPropagation.Required)]
        public string Get_CustomerName_PLVoucher(string plNo)
        {
            IQuery query = this.Session.GetNamedQuery("SP_GetCustomerName_PLVoucher");
            query.SetString("plNo", plNo);

            return query.UniqueResult().ToString();
        }

        //Added by AAM (22-May-2018)
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00243> Get_PLInfoRegisterEdit_ByAcctNo(string acctNo, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_GetPersonalLoanInfo_ByAcctNo");
            query.SetString("acctNo", acctNo);
            query.SetString("sourceBr", sourceBr);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00243)));
            IList<LOMDTO00243> multilist = query.List<LOMDTO00243>();
            return multilist;
        }

        //Added by AAM (22-May-2018)
        [Transaction(TransactionPropagation.Required)]
        public string Save_PLInfoRegisterEdit_ByAcctNo(string acctNo, string sourceBr,string companyName,string guaCompanyName
                                                       , string guaName, string guaNRC, string guaPhone, int createdUserId)
        {
            IQuery query = this.Session.GetNamedQuery("SP_SavePersonalLoanInfoEdit_ByAcctNo");
            query.SetString("acctNo", acctNo);
            query.SetString("sourceBr", sourceBr);
            query.SetString("companyName", companyName);
            query.SetString("guaCompanyName", guaCompanyName);
            query.SetString("guaName", guaName);
            query.SetString("guaNRC", guaNRC);
            query.SetString("guaPhone", guaPhone);
            query.SetInt32("createdUserId", createdUserId); 

            return query.UniqueResult().ToString();
        }
    }
}
