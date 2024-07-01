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
    class MNMSVE00058 : BaseService, IMNMSVE00058
    {
        #region Properties

        /// <summary>
        /// Link Account Dao 
        /// </summary>
       
        public ICXDAO00009 ViewDAO { get; set; }
        public IList<PFMDTO00021> fixedDepoACList { get; set; }
        private string sign { get; set; }


        public IList<PFMDTO00021> SelectFixedDepoistAll(DateTime sdate, DateTime edate, string cur, string acsign, string branchno, string status)
        {
            if (acsign.Contains("All"))
            {
                if (status == "")
                    fixedDepoACList = this.ViewDAO.SelectFixedDepoInfoForAll(sdate, edate,branchno,cur);
                else
                    fixedDepoACList = this.ViewDAO.SelectFixedDepoInfoForAllByFilter(sdate,edate,branchno,cur,status);
            }
            else if (acsign.Contains("Individual"))
            {
                sign = "FI";
                if (status == "")
                    fixedDepoACList = this.ViewDAO.SelectFixedDepoInfoForOther(sdate, edate, branchno, cur, sign);
                else
                    fixedDepoACList = this.ViewDAO.SelectFixedDepoInfoForOtherByFilter(sdate,edate,branchno,cur,sign,status);
            }
            else if (acsign.Contains("Joint"))
            {
                sign = "FJ";
                if (status == "")
                    fixedDepoACList = this.ViewDAO.SelectFixedDepoInfoForOther(sdate, edate, branchno, cur, sign);
                else
                    fixedDepoACList = this.ViewDAO.SelectFixedDepoInfoForOtherByFilter(sdate, edate, branchno, cur, sign, status);
            }
            else if (acsign.Contains("Co/Organization"))
            {
                sign = "FC";
                if (status == "")
                    fixedDepoACList = this.ViewDAO.SelectFixedDepoInfoForOther(sdate, edate, branchno, cur, sign);
                else
                    fixedDepoACList = this.ViewDAO.SelectFixedDepoInfoForOtherByFilter(sdate, edate, branchno, cur, sign, status);
            }

            else if (acsign.Contains("Minor"))
            {
                sign = "FM";
                if (status == "")
                    fixedDepoACList = this.ViewDAO.SelectFixedDepoInfoForOther(sdate, edate, branchno, cur, sign);
                else
                    fixedDepoACList = this.ViewDAO.SelectFixedDepoInfoForOtherByFilter(sdate, edate, branchno, cur, sign, status);
            }

            if (fixedDepoACList == null || fixedDepoACList.Count <= 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MI00039;    //No data to Report  //Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                return null;
            }

            return fixedDepoACList;

        }

        #endregion
    }
}
