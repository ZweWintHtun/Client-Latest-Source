//----------------------------------------------------------------------
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>HM</CreatedUser>
// <CreatedDate>12/01/2014</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Mnm.Ctr.Dao;
using Ace.Cbs.Mnm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.Core.Service;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using NHibernate;
using Spring.Data.NHibernate.Support;
using Ace.Windows.Admin.DataModel;
using System.Linq;
namespace Ace.Cbs.Mnm.Sve
{
    class MNMSVE00092 : BaseService, IMNMSVE00092
    {
        #region DAO

        private ICXDAO00010 procedureDAO {get; set;}

        #endregion

        public string branchno { get; set; }
        public string cur { get; set; }
        public string month { get; set; }
        public int isHomeCur { get; set; }
        public IList<MNMDTO00010> trialList { get; set; }

        private ICXDAO00014 bLFDAO;
        public ICXDAO00014 BLFDAO
        {
            get { return this.bLFDAO; }
            set { this.bLFDAO = value; }
        }
        #region Main Method

        [Transaction(TransactionPropagation.Required)]
        public IList<MNMDTO00010> SelectTrialBalanceGroup(string Branchno, string Currency, int Month, int IsByhome)
        {
            this.branchno = Branchno;
            this.cur = Currency;
            this.isHomeCur = IsByhome;

            #region old Code 
            
            //if (Month >= 4 && Month <= 12)
            //    this.month = (Month - 3).ToString();

            //else if (Month <= 3 && Month >= 1)
            //    this.month = (Month + 9).ToString();
            //else
            //    this.month = Month.ToString();
            #endregion

            // Modified by ZMS (2018/09/17) for Budget Month Flexible
            // For Budget Month
            ///this.month = Month < 4 ? (Month + 9).ToString() : (Month - 3).ToString();
            string Return = string.Empty;
            DateTime tempDate = Convert.ToDateTime(Convert.ToString(DateTime.Now.Year) + "/" + Convert.ToString(Month) + "/" + Convert.ToString(DateTime.Now.Day));
            this.month = BLFDAO.GetBudget_Month_Year_Quarter(3, tempDate, Branchno, Return); // For 2018/09/17 => 6

            if (cur == string.Empty)
            {
                string sqlstring = "MSRC" + month;
                isHomeCur = 1;
                if (branchno == string.Empty)
                {
                    trialList = this.procedureDAO.SelectTrialGroupByHomeAllBranch(sqlstring, cur, isHomeCur, branchno);
                }
                else
                {
                    trialList = this.procedureDAO.SelectTrialGroupByHomeBranch(sqlstring, cur, isHomeCur, branchno);
 
                }
            }
            else
            {
                if (this.branchno == string.Empty)
                {
                    //string sqlstring = "M" + month;
                    if (this.isHomeCur == 1)
                        trialList = this.procedureDAO.SelectTrialGroupBySourceAllBranch("MSRC" + month, cur, isHomeCur, branchno);
                    else
                        trialList = this.procedureDAO.SelectTrialGroupBySourceAllBranch("M" + month, cur, 0, branchno);
                }
                else
                {
                    if (this.isHomeCur == 1)
                        trialList = this.procedureDAO.SelectTrialGroupBySourceBranch("MSRC" + month, cur, 0, branchno);
                    else
                        trialList = this.procedureDAO.SelectTrialGroupBySourceBranch("M" + month, cur, 0, branchno);
                }
 
            }         

            return trialList;
        }

        //Added by HWKO (31-Aug-2017)
        //For Trial Balance Grouping By Back Date
        [Transaction(TransactionPropagation.Required)]
        public IList<MNMDTO00010> SelectTriGroupForBackDate(string currency, string branchCode, DateTime selectedDate)
        {            
            // Modified by ZMS (2018/09/17) for Budget Month Flexible
            // For Budget Month
            //string month = selectedDate.Month < 4 ? (selectedDate.Month + 9).ToString() : (selectedDate.Month - 3).ToString();
            string Return = string.Empty;
            string month = BLFDAO.GetBudget_Month_Year_Quarter(3, selectedDate, branchCode, Return); // For 2018/09/17 => 6

            string strOpeningField = "M" + month;
            return this.procedureDAO.SelectTriGroupForBackDate(currency, branchCode, selectedDate, strOpeningField);
        }


        #endregion

    }
}
