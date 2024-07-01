using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Cx.Com.Ctr;
using Spring.Transaction.Interceptor;
using Ace.Windows.Admin.DataModel;
using Spring.Transaction;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Ser.Sve;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;


namespace Ace.Cbs.Loan.Sve
{
    public class LOMSVE00444 : BaseService, ILOMSVE00444
    {
        
        #region Properties
        
        private ILOMDAO00444 limitExtendDAO;
        public ILOMDAO00444 LimitExtendDAO
        {
            get { return this.limitExtendDAO; }
            set { this.limitExtendDAO = value; }
        }

        private IPFMDAO00009 rateFileDAO;
        public IPFMDAO00009 RateFileDAO
        {
            get { return this.rateFileDAO; }
            set { this.rateFileDAO = value; }
        }
        #endregion


        public IList<LOMDTO00444> GetLimitExtendList(DateTime date, string sortby)
        {
            return this.LimitExtendDAO.GetLimitExtendList(date, sortby);
        }


        public IList<LOMDTO00423> GetNeedToExtendAccountInfo(string acctno)
        {
            return this.LimitExtendDAO.GetNeedToExtendAccountInfo(acctno);
        }

        public string SaveLimitExtendInfo(string totalExtendDuration, string accountNo, string docFeeNew, string IntRateNew, string UserID, string SourceBr, string preExtend, string sChargeNew)
        {
            return this.LimitExtendDAO.SaveLimitExtendInfo(totalExtendDuration, accountNo, docFeeNew, IntRateNew, UserID, SourceBr, preExtend, sChargeNew);
        }

        public LOMDTO00423 Get_BL_SanctionAmountInfo(string accountNo, string sourceBr)
        {
            return this.LimitExtendDAO.Get_BL_SanctionAmountInfo(accountNo, sourceBr);
        }

        public PFMDTO00009 SelectByCode(string code)
        {
            return this.RateFileDAO.SelectByCode(code);
        }
    }
}
