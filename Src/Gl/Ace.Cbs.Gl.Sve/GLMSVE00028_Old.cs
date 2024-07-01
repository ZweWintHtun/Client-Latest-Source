using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Gl.Ctr.Sve;
using Ace.Cbs.Gl.Ctr.Dao;
using Spring.Transaction.Interceptor;
using Spring.Transaction;

namespace Ace.Cbs.Gl.Sve
{
    public class GLMSVE00028 : BaseService,IGLMSVE00028
    {
        #region Constructor

        public GLMSVE00028() { }

        #endregion

        #region Properties

        private IGLMDAO00028 statementOfFinancialPositionDAO;
        public IGLMDAO00028 StatementOfFinancialPositionDAO
        {
            get { return this.statementOfFinancialPositionDAO; }
            set { this.statementOfFinancialPositionDAO = value; }
        }

        #endregion

        public object GetPropertyPlanAndEquipment(string requireMonth, string currency, string sourceBr)
        {
            return this.StatementOfFinancialPositionDAO.GetPropertyPlanAndEquipment(requireMonth, currency, sourceBr);            
        }
        
        public object GetSoftwareAndNetworkEquipment(string requireMonth, string currency, string sourceBr)
        {
            return this.StatementOfFinancialPositionDAO.GetSoftwareAndNetworkEquipment(requireMonth, currency, sourceBr);
        }

        //Updated by HWKO (22-Dec-2017) According to separate Loans and Hire Purchase
        public object GetLoansAmount(string requireMonth, string currency, string sourceBr)
        {
            return this.StatementOfFinancialPositionDAO.GetLoansAmount(requireMonth, currency, sourceBr);
        }

        //Hire Purchase //Added by HWKO (22-Dec-2017) According to separate Loans and Hire Purchase
        public object GetHPAmount(string requireMonth, string currency, string sourceBr)
        {
            return this.StatementOfFinancialPositionDAO.GetHPAmount(requireMonth, currency, sourceBr);
        }

        public object GetOtherAssets(string requireMonth, string currency, string sourceBr)
        {
            return this.StatementOfFinancialPositionDAO.GetOtherAssets(requireMonth, currency, sourceBr);
        }

        public object GetCashAndCashEquivalent(string requireMonth, string currency, string sourceBr)
        {
            return this.StatementOfFinancialPositionDAO.GetCashAndCashEquivalent(requireMonth, currency, sourceBr);
        }

        public object GetInterCompanyReceivable(string requireMonth, string currency, string sourceBr)
        {
            return this.StatementOfFinancialPositionDAO.GetInterCompanyReceivable(requireMonth, currency, sourceBr);
        }

        public object GetPaidUpCapital(string requireMonth, string currency, string sourceBr)
        {
            return this.StatementOfFinancialPositionDAO.GetPaidUpCapital(requireMonth, currency, sourceBr);
        }

        public object GetOtherReserves(string requireMonth, string currency, string sourceBr)
        {
            return this.StatementOfFinancialPositionDAO.GetOtherReserves(requireMonth, currency, sourceBr);
        }

        public object GetRetainedEarnings(string requireMonth, string currency, string sourceBr)
        {
            return this.StatementOfFinancialPositionDAO.GetRetainedEarnings(requireMonth, currency, sourceBr);
        }

        public object GetProfit(string requireMonth, string currency, string sourceBr)
        {
            return this.StatementOfFinancialPositionDAO.GetProfit(requireMonth, currency, sourceBr);
        }

        public object GetLoss(string requireMonth, string currency, string sourceBr)
        {
            return this.StatementOfFinancialPositionDAO.GetLoss(requireMonth, currency, sourceBr);
        }

        public object GetSundryDepositAndOtherPayables(string requireMonth, string currency, string sourceBr)
        {
            return this.StatementOfFinancialPositionDAO.GetSundryDepositAndOtherPayables(requireMonth, currency, sourceBr);
        }

        //Overdraft //Added by HWKO (01-Dec-2017)
        public object GetOverdraft(string requireMonth, string currency, string sourceBr)
        {
            return this.StatementOfFinancialPositionDAO.GetOverdraft(requireMonth, currency, sourceBr);
        }
    }
}
