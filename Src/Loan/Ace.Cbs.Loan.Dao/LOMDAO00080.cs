using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Loan.Dmd.DTO;
using System.Data.SqlClient;
using System.Data;

namespace Ace.Cbs.Loan.Dao
{
    public class LOMDAO00080 : DataRepository<LOMORM00026>, ILOMDAO00080
    {
        public string eno = "";
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00080> GetAllDealerInformation(string sourceBr)
        {
            IList<LOMDTO00080> result;
            IQuery query = this.Session.GetNamedQuery("SP_GetAllDealer");
            query.SetString("sourceBr", sourceBr); 
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00080)));
            result = query.List<LOMDTO00080>();
            return result;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00081> GetAllStockItem()
        {
            IList<LOMDTO00081> result;
            IQuery query = this.Session.GetNamedQuery("SP_GetAllStockItem");
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00081)));
            result = query.List<LOMDTO00081>();
            return result;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00082> GetAllStockGroup()
        {
            IList<LOMDTO00082> result;
            IQuery query = this.Session.GetNamedQuery("SP_GetAllStockGroup");
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00082)));
            result = query.List<LOMDTO00082>();
            return result;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00083> GetAllInstallmentTypes()
        {
            IList<LOMDTO00083> result;
            IQuery query = this.Session.GetNamedQuery("SP_GetAllInstallmentTypes");
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00083)));
            result = query.List<LOMDTO00083>();
            return result;
        }

        [Transaction(TransactionPropagation.Required)]
        public LOMDTO00084 AddHirePurchaseRegistration(string hpno, string caccount,string dealerAC,string dealerStatus, string guanteeAcctNo, decimal downPayPercent, decimal rChgsPercent,// decimal sChgsPercent,
                                                       decimal nextYrRChgsPercent, decimal disAmt, decimal docFees, int gapPeriod, decimal commPercent, string stockGCode, string stockISubCode, string relatedGLACode, decimal productValue, int payDuration, int payOptionId,
                                                       DateTime repaySDate, DateTime repayExpDate, string sourceBr, string remarks, int createdUserId, string eno, string userName)
        {
            IQuery query = this.Session.GetNamedQuery("SP_HirePurchaseRegistration");
            query.SetString("hpno", hpno);
            query.SetString("caccount", caccount);
            query.SetString("dealerAC", dealerAC);
            query.SetString("dealerStatus", dealerStatus);
            query.SetString("guanteeAcctNo", guanteeAcctNo);
            query.SetDecimal("downPayPercent", downPayPercent);
            query.SetDecimal("rChgsPercent", rChgsPercent);
            //query.SetDecimal("sChgsPercent", sChgsPercent);
            query.SetDecimal("nextYrRChgsPercent", nextYrRChgsPercent);
            query.SetDecimal("disAmt", disAmt);
            query.SetDecimal("docFees", docFees);
            query.SetInt32("gapPeriod", gapPeriod);
            query.SetDecimal("commPercent", commPercent);
            query.SetString("stockGCode", stockGCode);
            query.SetString("stockISubCode", stockISubCode);
            query.SetString("relatedGLACode", relatedGLACode);
            query.SetDecimal("productValue", productValue);
            query.SetInt32("payDuration", payDuration);
            query.SetInt32("payOptionId", payOptionId);
            query.SetDateTime("repaySDate", repaySDate);
            query.SetDateTime("repayExpDate", repayExpDate);
            query.SetString("sourceBr", sourceBr);
            query.SetString("remarks", remarks);
            query.SetInt32("createdUserId", createdUserId);
            query.SetString("eno", eno);
            query.SetString("userName", userName);

            string strResult=query.UniqueResult().ToString();
            string[] strval = strResult.Split(',');

            LOMDTO00084 dto = new LOMDTO00084();
	        dto.RetMsg = Convert.ToString(strval[7]);
            if (dto.RetMsg == "0")
            {
                dto.DownPayAmt = decimal.Parse(strval[0]);
                dto.RentalCharges = decimal.Parse(strval[1]);
                dto.ServiceCharges = decimal.Parse(strval[2]);
                dto.Commission = decimal.Parse(strval[3]);
                dto.Installment = decimal.Parse(strval[4]);
                dto.Eno = Convert.ToString(strval[5]);
                dto.ExpiredDate = DateTime.Parse(strval[6]);
            }
            return dto;
        }

        [Transaction(TransactionPropagation.Required)]
        public string CheckBalance(string caccount,string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_CheckBalance");
            query.SetString("caccount", caccount);
            query.SetString("sourceBr", sourceBr);
            return query.UniqueResult().ToString();
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00092> GetHPVoucherDetails(LOMDTO00092 d)
        {
            IList<LOMDTO00092> result;
            IQuery query = this.Session.GetNamedQuery("SP_GetHPVoucherDetails");
            query.SetString("eno", d.eno);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00092)));
            result = query.List<LOMDTO00092>();
            return result;
        }

        [Transaction(TransactionPropagation.Required)]
        public string CheckAccountExistsOrValid(string caccount, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_CheckAccountExistsOrValid");
            query.SetString("caccount", caccount);
            query.SetString("sourceBr", sourceBr);
            return query.UniqueResult().ToString();
        }

        [Transaction(TransactionPropagation.Required)]
        public string GetInstallmentAmt(decimal netAmt, int noOfTerms)
        {
            IQuery query = this.Session.GetNamedQuery("SP_GetInstallmentAmtToShow");
            query.SetDecimal("netAmt", netAmt);
            query.SetInt32("noOfTerms", noOfTerms);
            return query.UniqueResult().ToString();
        }
        
        [Transaction(TransactionPropagation.Required)]
        public string CheckDealerAccountExists(string dealerNo,string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_DealerAccountExists");
            query.SetString("dealerNo", dealerNo);
            query.SetString("sourcebr", sourceBr);
            return query.UniqueResult().ToString();
        }

        //public IList<decimal> GetRateForHPReg()
        //{
        //    IQuery query = this.Session.GetNamedQuery("SP_GetRateForHPReg");
        //    return query.List<decimal>();
        //}

        [Transaction(TransactionPropagation.Required)]
        public IList<string> GetAllCompanyNameFromPersonalLoans(string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_GetAllCompanyNameFromPersonalLoans");
            query.SetString("sourceBr", sourceBr);
            return query.List<string>();
        }

        [Transaction(TransactionPropagation.Required)]
        public string GetDealerCommission_ByDealerNo(string dealerNo, string sourceBr)//Added By AAM (28/07/2017)
        {
            IQuery query = this.Session.GetNamedQuery("SP_GetDealerCommission_ByDealerNo");
            query.SetString("dealerNo", dealerNo);
            query.SetString("sourceBr", sourceBr);
            return query.UniqueResult().ToString();
        }
    }
}

