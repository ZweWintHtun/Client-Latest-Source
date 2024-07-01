using System;
using System.Collections.Generic;
using Ace.Windows.Core.Utt;
using NHibernate;
using Spring.Data.NHibernate.Support;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Cx.Com.Utt
{
    /// <summary>
    /// Get Account Signature, Account Symbol by Account Type and Sub Account Type
    /// </summary>
    public class CXCOM00010 :  HibernateDaoSupport
    {
        #region Private Variables
        private static CXCOM00010 instance = null;
        #endregion

        #region Properties
        /// <summary>
        /// CXCOM00007 Instance Object
        /// </summary>
        public static CXCOM00010 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = SpringApplicationContext.Instance.Resolve<CXCOM00010>("CXCOM00010");
                }

                return instance;
            }
        }
        #endregion

        public string GetAccountSignature(string accountType, string subAccountType)
        {
            IQuery quey = this.Session.GetNamedQuery("CXCOM00010.GetAccountSignatureByAccountTypeAndSubAccountType");
            quey.SetString("accountTypeCode", accountType);
            quey.SetString("subAccountTypeCode", subAccountType);

            object accountSignature = quey.UniqueResult();
            if (accountSignature == null)
            {
                return null;
            }

            return accountSignature.ToString();
        }

        public string GetSymbolByAccountType(string accountType)
        {
            IQuery quey = this.Session.GetNamedQuery("CXCOM00010.GetSymbolByAccountType");
            quey.SetString("code", accountType);

            object symbol = quey.UniqueResult();
            if (symbol == null)
            {
                return null;
            }

            return symbol.ToString();
        }

        public string GetSymbolByAccountTypeAndSubAccountType(string accountType, string subAccountType)
        {
            IQuery quey = this.Session.GetNamedQuery("CXCOM00010.GetSymbolByAccountTypeAndSubAccountType");
            quey.SetString("accountTypeCode", accountType);
            quey.SetString("subAccountTypeCode", subAccountType);

            object symbol = quey.UniqueResult();
            if (symbol == null)
            {
                return null;
            }

            return symbol.ToString();
        }

        /// <summary>
        /// When account opening, use this budget year calculation
        /// </summary>
        /// <param name="variable">Your Variable Value ('BUDSMTH')</param>
        /// <returns>return budget year</returns>
        public string GetBudgetYearForLoan(string variable,DateTime datetime)
        {
            string value = CXCOM00007.Instance.GetValueByVariable(CXCOM00009.BudgetYearCode);

            int currentYear = datetime.Year;
            int currentMonth = datetime.Month;

            if (value == "1")
            {
                return currentYear.ToString() + "/" + currentYear.ToString();
            }

            int month = Convert.ToInt32(value.ToString());
            if (currentMonth < month)
            {
                return (currentYear - 1).ToString() + "/" + currentYear;
            }

            return currentYear.ToString() + "/" + (currentYear + 1).ToString();
        }

        /// <summary>
        /// When account opening, use this budget year calculation
        /// </summary>
        /// <param name="variable">Your Variable Value ('BUDSMTH')</param>
        /// <returns>return budget year</returns>
        public string GetBudgetYear1(string variable)
        {
            string value = CXCOM00007.Instance.GetValueByVariable(CXCOM00009.BudgetYearCode);

            int currentYear = DateTime.Now.Year;
            int currentMonth = DateTime.Now.Month;

            if (value == "1")
            {
                return currentYear.ToString() + "/" + currentYear.ToString();
            }

            int month = Convert.ToInt32(value.ToString());
            if (currentMonth < month)
            {
                return (currentYear - 1).ToString() + "/" + currentYear;
            }

            return currentYear.ToString() + "/" + (currentYear + 1).ToString();
        }

        /// <summary>
        /// When interest calculating, use this budget year calculation
        /// </summary>
        /// <param name="variable">Your Variable Value ('BUDSMTH')</param>
        /// <returns>return budget year</returns>
        public string GetBudgetYear2(string variable, DateTime currentDate)
        {
            int currentMonth = currentDate.Month;

            string value = CXCOM00007.Instance.GetValueByVariable(CXCOM00009.BudgetYearCode);

            if (currentMonth < Convert.ToInt32(value.ToString()))
            {
                currentMonth = currentMonth + 12;
            }

            return ((currentMonth + 1) - Convert.ToInt32(value.ToString())).ToString();
        }

        /// <summary>
        /// When PO Printing, use this budget ("13-14") year calculation.Added by HWH.Requested By PO Prinitng in Transfer & Clearing Function.
        /// </summary>
        /// <param name="variable">Your Variable Value ('BUDSMTH')</param>
        /// <param name="variable">Your Variable Value (DateTime)</param>
        /// <returns>return budget year</returns>
        public string GetBudgetYear3(string variable, DateTime requiredate)
        {
            string value = CXCOM00007.Instance.GetValueByVariable(CXCOM00009.BudgetYearCode);
            string requireYear=requiredate.Year.ToString().Substring(2);//"2013"
            int requiredYear=requiredate.Year;//2013  

            int nextyear = requiredYear + 1;//2014
            string nyear = nextyear.ToString().Substring(2);//"2014"
            string budgetyear = requireYear + "-" + nyear;
            return budgetyear;       
        }

        public string GetBudgetYear4(string variable, DateTime requiredate)  //added by ASDA
        {
            string value = CXCOM00007.Instance.GetValueByVariable(CXCOM00009.BudgetYearCode);            
            int requiredYear = requiredate.Year;//2013  

            int nextyear = requiredYear + 1;//2014            
            string budgetyear = Convert.ToString(requiredYear) + "/" + Convert.ToString(nextyear);
            return budgetyear;
        }

        // Added By AAM (29-Jan-2018)
        public string GetBudgetYear_For_PreviousBudget(string variable, DateTime startDate)
        {
            string value = CXCOM00007.Instance.GetValueByVariable(CXCOM00009.BudgetYearCode);

            int currentYear = startDate.Year;
            int currentMonth = startDate.Month;

            if (value == "1")
            {
                return currentYear.ToString() + "/" + currentYear.ToString();
            }

            int month = Convert.ToInt32(value.ToString());
            if (currentMonth < month)
            {
                return (currentYear - 1).ToString() + "/" + currentYear;
            }

            return currentYear.ToString() + "/" + (currentYear + 1).ToString();
        }

        public decimal GetExchangeRate(string currencyCode, string rateType)
        {
            string homeCur = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.HomeCurrencyCode);
            if (currencyCode == homeCur)
            {
                return 1;
            }
            else
            {
                IQuery query = this.Session.GetNamedQuery("CXCOM00010.SelectRate");
                query.SetString("currencyCode", currencyCode);
                query.SetString("rateType", rateType);
                query.SetString("homeCur", homeCur);
                object rate = query.UniqueResult();
                
                if (rate == null)
                {
                    return 0;
                }

                return Convert.ToDecimal(rate);
            }
        }

        public string GetCOAAccountNo(string accountName, string branchCode, string currencyCode)
        {
            IQuery query = this.Session.GetNamedQuery("CXCOM00010.SelectAccountNo");
            query.SetString("accountName", accountName);
            query.SetString("currencyCode", currencyCode);
            query.SetString("branchCode", branchCode);

            object rate = query.UniqueResult();

            if (rate == null)
            {
                return null;
            }

            return rate.ToString();
        }

        public DateTime GetNextSettlementDate(string name, string branchCode)
        {
            IQuery query = this.Session.GetNamedQuery("CXCOM00010.SelectNextSettlementDate");
            query.SetString("name", name);
            query.SetString("branchCode", branchCode);

            return query.UniqueResult<DateTime>();
        }

        public DateTime GetDateOnly(DateTime date)
        {
            return Convert.ToDateTime(date.ToString(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SQLiteDateSavingFormat)));
        }

        public PFMDTO00075 SelectRateAndDenoRate(string currencyCode, string rateType)
        {
            if (string.IsNullOrEmpty(currencyCode) || string.IsNullOrEmpty(rateType))
            {
                throw new Exception(CXMessage.ME90018);
            }
            else
            {
                PFMDTO00075 rateInfoDTO = new PFMDTO00075();
                string homeCur = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.HomeCurrencyCode);
                if (currencyCode == homeCur)
                {
                    rateInfoDTO.Rate = 1;
                }
                else
                {
                    IQuery query = this.Session.GetNamedQuery("CXCLE00011.SelectRateAndDenoRate");
                    query.SetString("currencyCode", currencyCode);
                    query.SetString("rateType", rateType);
                    query.SetString("homeCur", homeCur);
                    rateInfoDTO = query.UniqueResult<PFMDTO00075>();
                    if (rateInfoDTO == null)
                        throw new Exception(CXMessage.ME00037);//Exchange Rate not found in table.
                }
                return rateInfoDTO;
            }

        }

        public string GetCoaSetupAccountNo(string accountName, string branchCode, string currencyCode)
        {
            IQuery query = this.Session.GetNamedQuery("CXCOM00010.SelectCoaSetupAccountNo");
            query.SetString("accountName", accountName);
            query.SetString("currencyCode", currencyCode);
            query.SetString("branchCode", branchCode);


            object rate =query.UniqueResult() ;

            if (rate == null)
            {
                return null;
            }

            return rate.ToString();
        }

        public string GetCoaSetupAccountNo(string accountName, string branchCode)
        {
            IQuery query = this.Session.GetNamedQuery("CXCOM00010.SelectCoaSetupAccountNoByAccountName");
            query.SetString("accountname", accountName);
            query.SetString("branchCode", branchCode);
            string rate = query.SetFirstResult(0).SetMaxResults(1).UniqueResult<ChargeOfAccountSetupDTO>().AccountNo;

            if (rate == null)
            {
                return null;
            }

            return rate;
        }

        public string GetAllDenoRate(string currencyCode, string rateType, string toCurrency)
        {
            if (currencyCode == CXCOM00009.HomeCurrencyCode)
            {
                return string.Empty;
            }
            else
            {
                IQuery query = this.Session.GetNamedQuery("CXCOM00010.SelectAllDenoRate");
                query.SetString("currencyCode", currencyCode);
                query.SetString("rateType", rateType);
                query.SetString("ToCur", toCurrency);
                object rate = query.UniqueResult();
                
                if (rate == null)
                {
                    return string.Empty;
                }

                return rate.ToString();
            }
        }

        public string GetBudgetMonth()  //Added by ASDA    (Show Budget Month Eg. M1, M2)Budinfo No-3
        {
            string value = CXCOM00007.Instance.GetValueByVariable(CXCOM00009.BudgetYearCode);  
            string currentMonth = DateTime.Now.Month.ToString();
            int result;
            if (Convert.ToInt16(currentMonth) < Convert.ToInt16(value))
            {
                result = Convert.ToInt16(currentMonth) + 12;
            }
            else
            {
                result = Convert.ToInt16(currentMonth);
            }

            string returnValue = Convert.ToString(result + 1 - Convert.ToInt16(value));

            return returnValue;
        }

        public string GetBudgetMonth4()  //Show Quarter Eg. Q1,Q2,Q3,Q4    Added by ASDA (LOMCTL00016)     
        {
            string value = CXCOM00007.Instance.GetValueByVariable(CXCOM00009.BudgetYearCode);

            string returnValue = string.Empty;
            int MStart = Convert.ToInt32(value);
            int MEnd = Convert.ToInt32(MStart + 2);  //6
            int counter = 0;
            int period = 1;
            for (int i = Convert.ToInt32(value); i < Convert.ToInt32(value) + 12; i++)            
            {
                counter += 1;
                int currentMonth = i > 12 ? i-12 : i;
                if (counter % 3 == 0)
                {
                    MStart = MEnd + 1 > 12 ? MEnd + 1 - 12 : MEnd + 1;   //4
                    MEnd = MStart + 2 > 12 ? MStart + 2 - 12 : MStart + 2;  //6
                    period += 1;
                }
                if(MStart <= DateTime.Now.Month && MEnd >= DateTime.Now.Month)
                {
                    returnValue = period.ToString();
                }
            }
            return returnValue;
        }

        public PFMDTO00009 GetRateFromRateFile(string code)  // call from (LOMCTL00016)
        {
            if (string.IsNullOrEmpty(code))
            {
                throw new Exception(CXMessage.ME90018);
            }
            else
            {
                IQuery query = this.Session.GetNamedQuery("RateFileDAO.SelectByRateCode");
                query.SetString("code", code);
                return query.UniqueResult<PFMDTO00009>();
            }
        }  
    }
}
