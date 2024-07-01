using System;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.Core.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Mnm.Ctr.Sve;
using System.Collections.Generic;
using Ace.Cbs.Mnm.Ctr.Dao;

namespace Ace.Cbs.Mnm.Sve
{
    class MNMSVE00129 : BaseService, IMNMSVE00129
    {
        #region Properties

        /// <summary>
        /// Link Account Dao 
        /// </summary>
        private IMNMDAO00129 linkAutoDAO;
        public IMNMDAO00129 LinkAutoDAO
        {
            get { return this.linkAutoDAO; }
            set { this.linkAutoDAO = value; }
        }

        public IList<PFMDTO00029> LinkAutoList { get; set; }


        public IList<PFMDTO00029> SelectLinkAutoPriorityInfo(string SourceBr)
        {
            LinkAutoList = this.linkAutoDAO.SelectForLinkAutoPriority(SourceBr);

            if (LinkAutoList == null || LinkAutoList.Count <= 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MI00039;    //No data to Report
                return null;
            }

            return LinkAutoList;

        }

        #endregion
    }
}
