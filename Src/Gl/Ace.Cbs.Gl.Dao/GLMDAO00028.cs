using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Gl.Ctr.Dao;
using NHibernate;
using Ace.Cbs.Gl.Dmd;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using NHibernate.Transform;
using Ace.Cbs.Gl.Dmd.Dto;

namespace Ace.Cbs.Gl.Dao
{
    public class GLMDAO00028 : DataRepository<CurrencyChargeOfAccount>,IGLMDAO00028
    {
        public string GetMonthQuery(string requireMonth)
        {
            string monthQuery = string.Empty;
            int currentMonth = Convert.ToInt32(requireMonth) < 4 ? (Convert.ToInt32(requireMonth) + 9) : (Convert.ToInt32(requireMonth) - 3);
            //6 //SUM(OBal) + SUM(M1) + SUM(M2) + SUM(M3) + SUM(M4)...
            //monthQuery = "SUM(OBAL)";
            //for (int i = 1; i <= currentMonth; i++)
            //{
                monthQuery = "SUM(M" + currentMonth.ToString() + ")";
            //}
            return monthQuery;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<GLMDTO00028> GetACodeBySFPType(string sfpType, string sourceBr, string cur)
        {
            IQuery query = this.Session.GetNamedQuery("SP_GetACodeBySFPType");
            query.SetString("sfpType", sfpType);
            query.SetString("sourceBr", sourceBr);
            query.SetString("cur", cur);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(GLMDTO00028)));
            IList<GLMDTO00028> multilist = query.List<GLMDTO00028>();
            return multilist;
        }

        public string GetAcodeCondition(string sfpType, string sourceBr, string cur)
        {
            string returnString = string.Empty;
            IList<GLMDTO00028> DTOList = new List<GLMDTO00028>();
            DTOList = this.GetACodeBySFPType(sfpType, sourceBr, cur);
            if(DTOList.Count > 0)
            {
                if (DTOList.Count > 1)
                {
                    //ccoa.ACODE like 'ABG%' or ccoa.ACODE like 'ABH%' or ccoa.ACODE like 'ABJ%'
                    returnString = "ccoa.ACODE like '" + DTOList[0].ACode +"'";
                    for (int i = 1; i < DTOList.Count; i++)
                    {
                        returnString = returnString + " or ccoa.ACODE like '" + DTOList[i].ACode + "'";
                    }
                }
                else
                {
                    returnString = "ccoa.ACODE like '" + DTOList[0].ACode + "'";
                }
            }
            return returnString;
        }

        //Property, plant & equipment
        public object GetPropertyPlanAndEquipment(string requireMonth, string currency, string sourceBr)
        {
            string monthQuery = this.GetMonthQuery(requireMonth);
            string acodeCondition = this.GetAcodeCondition("PROPERTY_PLANT_EQUIPMENT", sourceBr, currency);//ccoa.ACODE like 'ABG%' or ccoa.ACODE like 'ABH%' or ccoa.ACODE like 'ABJ%'
            //SUM(requiremonth)
            string query = "select ({0}) from CurrencyChargeOfAccount ccoa where ccoa.DCODE = :sourceBr and ccoa.CUR = :cur and SUBSTRING(ccoa.ACODE,4,3)<>'000' and ( {1} ) Group by ccoa.DCODE ";

            IQuery hqlQuery = this.Session.CreateQuery(string.Format(query, new object[] { monthQuery,acodeCondition }));
            hqlQuery.SetString("cur", currency);
            hqlQuery.SetString("sourceBr", sourceBr);

            return hqlQuery.UniqueResult();
        }
        
        //Software & Network Equipment
        public object GetSoftwareAndNetworkEquipment(string requireMonth, string currency, string sourceBr)
        {
            string monthQuery = this.GetMonthQuery(requireMonth);
            string acodeCondition = this.GetAcodeCondition("SOFTWARE_NETWORK_EQUIPMENT", sourceBr, currency);//ccoa.ACODE like 'ABI%'
            //SUM(requiremonth)
            string query = "select ({0}) from CurrencyChargeOfAccount ccoa where ccoa.DCODE = :sourceBr and ccoa.CUR = :cur and SUBSTRING(ccoa.ACODE,4,3)<>'000' and  ( {1} ) Group by ccoa.DCODE ";

            IQuery hqlQuery = this.Session.CreateQuery(string.Format(query, new object[] { monthQuery,acodeCondition }));
            hqlQuery.SetString("cur", currency);
            hqlQuery.SetString("sourceBr", sourceBr);

            return hqlQuery.UniqueResult();
        }

        //Loans //Updated by HWKO (22-Dec-2017) According to separate Loans and Hire Purchase
        public object GetLoansAmount(string requireMonth, string currency, string sourceBr)
        {
            string monthQuery = this.GetMonthQuery(requireMonth);
            string acodeCondition = this.GetAcodeCondition("LOANS", sourceBr, currency);//ccoa.ACODE like 'AAG%' or ccoa.ACODE like 'AAI%'
            //SUM(requiremonth)
            string query = "select ({0}) from CurrencyChargeOfAccount ccoa where ccoa.DCODE = :sourceBr and ccoa.CUR = :cur and SUBSTRING(ccoa.ACODE,4,3)<>'000' and  ( {1} ) Group by ccoa.DCODE ";

            IQuery hqlQuery = this.Session.CreateQuery(string.Format(query, new object[] { monthQuery,acodeCondition }));
            hqlQuery.SetString("cur", currency);
            hqlQuery.SetString("sourceBr", sourceBr);

            return hqlQuery.UniqueResult();
        }

        //Hire Purchase //Added by HWKO (22-Dec-2017) According to separate Loans and Hire Purchase
        public object GetHPAmount(string requireMonth, string currency, string sourceBr)
        {
            string monthQuery = this.GetMonthQuery(requireMonth);
            string acodeCondition = this.GetAcodeCondition("HIREPURCHASE", sourceBr, currency);//ccoa.ACODE like 'AAG%' or ccoa.ACODE like 'AAI%'
            //SUM(requiremonth)
            string query = "select ({0}) from CurrencyChargeOfAccount ccoa where ccoa.DCODE = :sourceBr and ccoa.CUR = :cur and SUBSTRING(ccoa.ACODE,4,3)<>'000' and  ( {1} ) Group by ccoa.DCODE ";

            IQuery hqlQuery = this.Session.CreateQuery(string.Format(query, new object[] { monthQuery, acodeCondition }));
            hqlQuery.SetString("cur", currency);
            hqlQuery.SetString("sourceBr", sourceBr);

            return hqlQuery.UniqueResult();
        }



        //Other Assets
        public object GetOtherAssets(string requireMonth, string currency, string sourceBr)
        {
            string monthQuery = this.GetMonthQuery(requireMonth);
            string acodeCondition = this.GetAcodeCondition("OTHER_ASSETS", sourceBr, currency);//ccoa.ACODE like 'ABD%'
            //SUM(requiremonth)
            string query = "select ({0}) from CurrencyChargeOfAccount ccoa where ccoa.DCODE = :sourceBr and ccoa.CUR = :cur and SUBSTRING(ccoa.ACODE,4,3)<>'000' and ({1})  Group by ccoa.DCODE ";

            IQuery hqlQuery = this.Session.CreateQuery(string.Format(query, new object[] { monthQuery,acodeCondition }));
            hqlQuery.SetString("cur", currency);
            hqlQuery.SetString("sourceBr", sourceBr);

            return hqlQuery.UniqueResult();
        }

        //Cash & Cash Equivalent
        public object GetCashAndCashEquivalent(string requireMonth, string currency, string sourceBr)
        {
            string monthQuery = this.GetMonthQuery(requireMonth);
            string acodeCondition = this.GetAcodeCondition("CASH_CASH_EQUIVALENT", sourceBr, currency);//ccoa.ACODE like 'AAA%' or ccoa.ACODE like 'AAB%' or ccoa.ACODE like 'AAC%'
            //SUM(requiremonth)
            string query = "select ({0}) from CurrencyChargeOfAccount ccoa where ccoa.DCODE = :sourceBr and ccoa.CUR = :cur and SUBSTRING(ccoa.ACODE,4,3)<>'000' and  ( {1} ) Group by ccoa.DCODE ";

            IQuery hqlQuery = this.Session.CreateQuery(string.Format(query, new object[] { monthQuery, acodeCondition }));
            hqlQuery.SetString("cur", currency);
            hqlQuery.SetString("sourceBr", sourceBr);

            return hqlQuery.UniqueResult();
        }

        //Inter Company Receivable
        public object GetInterCompanyReceivable(string requireMonth, string currency, string sourceBr)
        {
            string monthQuery = this.GetMonthQuery(requireMonth);
            string acodeCondition = this.GetAcodeCondition("INTER_COMPANY_RECEIVABLE", sourceBr, currency);//ccoa.ACODE like 'ABB%'
            //SUM(requiremonth)
            string query = "select ({0}) from CurrencyChargeOfAccount ccoa where ccoa.DCODE = :sourceBr and ccoa.CUR = :cur and SUBSTRING(ccoa.ACODE,4,3)<>'000' and  ({1}) Group by ccoa.DCODE ";

            IQuery hqlQuery = this.Session.CreateQuery(string.Format(query, new object[] { monthQuery, acodeCondition }));
            hqlQuery.SetString("cur", currency);
            hqlQuery.SetString("sourceBr", sourceBr);

            return hqlQuery.UniqueResult();
        }

        //Paid Up Capital
        public object GetPaidUpCapital(string requireMonth, string currency, string sourceBr)
        {
            string monthQuery = this.GetMonthQuery(requireMonth);
            string acodeCondition = this.GetAcodeCondition("PAID_UP_CAPITAL", sourceBr, currency);//ccoa.ACODE like 'LAA001'
            //SUM(requiremonth)
            string query = "select ({0}) from CurrencyChargeOfAccount ccoa where ccoa.DCODE = :sourceBr and ccoa.CUR = :cur and SUBSTRING(ccoa.ACODE,4,3)<>'000' and ({1})  Group by ccoa.DCODE ";

            IQuery hqlQuery = this.Session.CreateQuery(string.Format(query, new object[] { monthQuery, acodeCondition }));
            hqlQuery.SetString("cur", currency);
            hqlQuery.SetString("sourceBr", sourceBr);

            return hqlQuery.UniqueResult();
        }

        //Other reserves
        public object GetOtherReserves(string requireMonth, string currency, string sourceBr)
        {
            string monthQuery = this.GetMonthQuery(requireMonth);
            string acodeCondition = this.GetAcodeCondition("OTHER_RESERVES", sourceBr, currency);//ccoa.ACODE like 'LAB%'
            //SUM(requiremonth)
            string query = "select ({0}) from CurrencyChargeOfAccount ccoa where ccoa.DCODE = :sourceBr and ccoa.CUR = :cur and SUBSTRING(ccoa.ACODE,4,3)<>'000' and  ({1}) Group by ccoa.DCODE ";

            IQuery hqlQuery = this.Session.CreateQuery(string.Format(query, new object[] { monthQuery,acodeCondition }));
            hqlQuery.SetString("cur", currency);
            hqlQuery.SetString("sourceBr", sourceBr);

            return hqlQuery.UniqueResult();
        }
        
        //Retained Earnings
        public object GetRetainedEarnings(string requireMonth, string currency, string sourceBr)
        {
            string monthQuery = this.GetMonthQuery(requireMonth);
            string acodeCondition = this.GetAcodeCondition("RETAINED_EARNINGS", sourceBr, currency);//ccoa.ACODE like 'LAC002'
            //SUM(requiremonth)
            string query = "select ({0}) from CurrencyChargeOfAccount ccoa where ccoa.DCODE = :sourceBr and ccoa.CUR = :cur and SUBSTRING(ccoa.ACODE,4,3)<>'000' and ({1})  Group by ccoa.DCODE ";

            IQuery hqlQuery = this.Session.CreateQuery(string.Format(query, new object[] { monthQuery, acodeCondition }));
            hqlQuery.SetString("cur", currency);
            hqlQuery.SetString("sourceBr", sourceBr);

            return hqlQuery.UniqueResult();
        }

        //Profit/(Loss)
        public object GetProfit(string requireMonth, string currency, string sourceBr)
        {
            string monthQuery = this.GetMonthQuery(requireMonth);
            string acodeCondition = this.GetAcodeCondition("PROFIT", sourceBr, currency);//ccoa.ACODE like 'I00000'
            //SUM(requiremonth)
            string query = "select ({0}) from CurrencyChargeOfAccount ccoa where ccoa.DCODE = :sourceBr and ccoa.CUR = :cur and ({1})  Group by ccoa.DCODE ";

            IQuery hqlQuery = this.Session.CreateQuery(string.Format(query, new object[] { monthQuery, acodeCondition }));
            hqlQuery.SetString("cur", currency);
            hqlQuery.SetString("sourceBr", sourceBr);

            return hqlQuery.UniqueResult();
        }
        public object GetLoss(string requireMonth, string currency, string sourceBr)
        {
            string monthQuery = this.GetMonthQuery(requireMonth);
            string acodeCondition = this.GetAcodeCondition("LOSS", sourceBr, currency);//ccoa.ACODE like 'E00000'
            //SUM(requiremonth)
            string query = "select ({0}) from CurrencyChargeOfAccount ccoa where ccoa.DCODE = :sourceBr and ccoa.CUR = :cur and ({1}) Group by ccoa.DCODE ";

            IQuery hqlQuery = this.Session.CreateQuery(string.Format(query, new object[] { monthQuery, acodeCondition }));
            hqlQuery.SetString("cur", currency);
            hqlQuery.SetString("sourceBr", sourceBr);

            return hqlQuery.UniqueResult();
        }

        //Sundry Deposit and other payables
        public object GetSundryDepositAndOtherPayables(string requireMonth, string currency, string sourceBr)
        {
            string monthQuery = this.GetMonthQuery(requireMonth);
            //SUM(OBAL)+SUM(M1)+SUM(M2)+SUM(M3)+SUM(M4)...
            //string query = "select ({0}) from CurrencyChargeOfAccount ccoa where ccoa.DCODE = :sourceBr and ccoa.CUR = :cur and SUBSTRING(ccoa.ACODE,4,3)<>'000' and  ( ccoa.ACODE like 'LAN%' or ccoa.ACODE like 'LAE%' or ccoa.ACODE like 'LAS%') Group by ccoa.DCODE ";
            string acodeCondition = this.GetAcodeCondition("SUNDRY_DEPOSIT_OTHER_PAYABLES", sourceBr, currency);//ccoa.ACODE like 'LAN%' or ccoa.ACODE like 'LAE%'
            //SUM(requiremonth)
            string query = "select ({0}) from CurrencyChargeOfAccount ccoa where ccoa.DCODE = :sourceBr and ccoa.CUR = :cur and SUBSTRING(ccoa.ACODE,4,3)<>'000' and  ( {1} ) Group by ccoa.DCODE ";

            IQuery hqlQuery = this.Session.CreateQuery(string.Format(query, new object[] { monthQuery, acodeCondition }));
            hqlQuery.SetString("cur", currency);
            hqlQuery.SetString("sourceBr", sourceBr);

            return hqlQuery.UniqueResult();
        }

        //Overdraft //Added by HWKO (01-Dec-2017)
        public object GetOverdraft(string requireMonth, string currency, string sourceBr)
        {
            string monthQuery = this.GetMonthQuery(requireMonth);
            //SUM(OBAL)+SUM(M1)+SUM(M2)+SUM(M3)+SUM(M4)...
            //string query = "select ({0}) from CurrencyChargeOfAccount ccoa where ccoa.DCODE = :sourceBr and ccoa.CUR = :cur and SUBSTRING(ccoa.ACODE,4,3)<>'000' and  ( ccoa.ACODE like 'LAN%' or ccoa.ACODE like 'LAE%' or ccoa.ACODE like 'LAS%') Group by ccoa.DCODE ";
            string acodeCondition = this.GetAcodeCondition("OVERDRAFT", sourceBr, currency);//ccoa.ACODE like 'LAN%' or ccoa.ACODE like 'LAE%'
            //SUM(requiremonth)
            string query = "select ({0}) from CurrencyChargeOfAccount ccoa where ccoa.DCODE = :sourceBr and ccoa.CUR = :cur and SUBSTRING(ccoa.ACODE,4,3)<>'000' and  ( {1} ) Group by ccoa.DCODE ";

            IQuery hqlQuery = this.Session.CreateQuery(string.Format(query, new object[] { monthQuery, acodeCondition }));
            hqlQuery.SetString("cur", currency);
            hqlQuery.SetString("sourceBr", sourceBr);

            return hqlQuery.UniqueResult();
        }

        //Added By AAM(06-Mar-2018)
        public IList<GLMDTO00028> Get_SFP_ReportData(string requireMonth,string sourceBr)
        {
            IList<GLMDTO00028> result;
            IQuery query = this.Session.GetNamedQuery("SP_Get_SOFP_Report");
            query.SetString("requiredMonth", requireMonth);
            query.SetString("sourceBr", sourceBr);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(GLMDTO00028)));
            result = query.List<GLMDTO00028>();
            return result;
        }

        public string GetLastDayofMonth(string requireYear, string requireMonth)
        {
            string requireDay = string.Empty;

            IQuery query = this.Session.GetNamedQuery("SP_GetLastDayofMonth");
            string date = requireYear + "/" + requireMonth + "/" + "01";
            query.SetString("requiredate", date);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(GLMDTO00028)));
            requireDay = query.UniqueResult<GLMDTO00028>().LastDayofRequirementMonth;
            return requireDay;
        }
    }
}
