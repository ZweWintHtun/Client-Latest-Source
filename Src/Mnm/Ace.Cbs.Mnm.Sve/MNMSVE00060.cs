using System;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Mnm.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.Core.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Mnm.Ctr.Sve;
using System.Collections.Generic;
using Ace.Cbs.Mnm.Ctr.Dao;
//using Ace.Cbs.Pfm.Dao;


namespace Ace.Cbs.Mnm.Sve
{
    class MNMSVE00060 : BaseService, IMNMSVE00060
    {
        #region Properties

        /// <summary>
        /// Link Account Dao 
        /// </summary>
        private IPFMDAO00007 fixRateDAO;
        public IPFMDAO00007 FixRateDAO
        {
            get { return this.fixRateDAO; }
            set { this.fixRateDAO = value; }
        }
        public ICXDAO00009 ViewDAO { get; set; }
        public IList<MNMDTO00035> frateList { get; set; }


        public IList<MNMDTO00035> SelectDurationForFixedDeposit(decimal duration,string branchno)
        {

            frateList = this.ViewDAO.SelectDurationForFixedDeposit(duration, branchno);

            if (frateList == null || frateList.Count <= 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MI00039;    //No data to Report
                return null;
            }

            return frateList;

        }

        public IList<PFMDTO00007> SelectRequiredDuration()
        {
            return this.fixRateDAO.SelectAll();
 
        }

        #endregion
    }
}
