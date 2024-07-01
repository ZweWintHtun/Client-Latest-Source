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
//using Ace.Cbs.Pfm.Dao;


namespace Ace.Cbs.Mnm.Sve
{
    class MNMSVE00069 : BaseService, IMNMSVE00069
    {
        #region Properties

        /// <summary>
        /// Link Account Dao 
        /// </summary>
        private IPFMDAO00029 linkAccountDAO;
        public IPFMDAO00029 LinkAccountDAO
        {
            get { return this.linkAccountDAO; }
            set { this.linkAccountDAO = value; }
        }
        public ICXDAO00009 ViewDAO { get; set; }
        public IList<PFMDTO00029> LinkACList { get; set; }
      

        public IList<PFMDTO00029> SelectLinkACInfo(string linkType,string branchNo)
        {
            if (linkType.Contains("All"))
            {
                LinkACList = this.ViewDAO.SelectLinkACAll(branchNo);
            }

            else if(linkType.Contains("Excess")) 
            {
                LinkACList = this.ViewDAO.SelectLinkACExcess(branchNo);
            } 
       
            if (LinkACList == null || LinkACList.Count <= 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MI00039;    //No data to Report
                return null;
            }

            return LinkACList;

        }

        #endregion
    }
}
