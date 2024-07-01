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
    class MNMSVE00091 : BaseService,IMNMSVE00091
    {
        #region DAO
        public ICXDAO00009 ViewDAO { get; set; }
        #endregion  

        public string branchno { get; set; }
        public string cur { get; set; }
        public string month { get; set; }
        public bool isHomeCur { get; set; }
        public IList<MNMDTO00010> trialList { get; set; }

        private ICXDAO00014 bLFDAO;
        public ICXDAO00014 BLFDAO
        {
            get { return this.bLFDAO; }
            set { this.bLFDAO = value; }
        }

        #region Main Method

        [Transaction(TransactionPropagation.Required)]
        public IList<MNMDTO00010> SelectTrialBalanceDetail(string Branchno, string BranchnoforBudgetYear, string Currency, int Month, bool IsByhome)
        {
            /*
             It has 2 branch no parameters. 
             "Branchno" parameter can be bank when you select all branch (i.e. dcode="")  <==== Selected Branch
             "BranchnoforBudgetYear" parameter is cannot be blank to calculate "budget year". <===== CurrentUserEntity.BarnchCode
             */

            this.branchno = Branchno;
            this.cur = Currency;
            this.isHomeCur = IsByhome;

            #region Checking Month
           
            //if (Month > 4 && Month <= 12)
            //    this.month = (Month - 3).ToString();

            //else if (Month <= 3 && Month >= 1)
            //    this.month = (Month + 9).ToString();
           
            //else
            //    this.month = Month.ToString();

            // Modified by ZMS (2018/09/17) for Budget Month Flexible
            // For Budget Month
            //this.month = Month < 4 ? (Month + 9).ToString() : (Month - 3).ToString();
            string Return = string.Empty;
            DateTime tempDate = Convert.ToDateTime(Convert.ToString(DateTime.Now.Year) + "/" + Convert.ToString(Month) + "/" + Convert.ToString(DateTime.Now.Day));

            if (string.IsNullOrEmpty(Branchno))
                this.month = BLFDAO.GetBudget_Month_Year_Quarter(3, tempDate, BranchnoforBudgetYear, Return); // For 2018/09/17 => 6
            else                
                this.month = BLFDAO.GetBudget_Month_Year_Quarter(3, tempDate, Branchno, Return); // For 2018/09/17 => 6

            #endregion
            
            if (this.cur == string.Empty)
            {
                if(this.branchno == string.Empty)
                trialList = this.ViewDAO.SelectTrialBalanceDetailByHomeAllBranch(month);
                else
                    trialList = this.ViewDAO.SelectTrialBalanceDetailByHome(month,branchno);
            }
            else 
            {
                if (this.branchno == string.Empty)
                {
                    if (this.isHomeCur)
                        trialList = this.ViewDAO.SelectTrialBalanceDetailBySourceAllBranchHome(month, cur);
                    else
                        trialList = this.ViewDAO.SelectTrialBalanceDetailBySourceAllBranch(month, cur);
                }
                else
                {
                    if (this.isHomeCur)
                        trialList = this.ViewDAO.SelectTrialBalanceDetailBySourceHome(month, cur, branchno);
                    else
                        trialList = this.ViewDAO.SelectTrialBalanceDetailBySource(month, branchno, cur);
                }
            }

            return trialList;
        }

        //Added by HWKO (03-Sep-2017)
        //For Trial Balance Grouping By Back Date
        [Transaction(TransactionPropagation.Required)]
        public IList<MNMDTO00010> SelectTriDetailForBackDate(string currency, string branchCode, DateTime selectedDate)
        {
            // Modified by ZMS (2018/09/17) for Budget Month Flexible
            // For Budget Month
            //string month = selectedDate.Month < 4 ? (selectedDate.Month + 9).ToString() : (selectedDate.Month - 3).ToString();
            string Return = string.Empty;
            string month = BLFDAO.GetBudget_Month_Year_Quarter(3, selectedDate, branchCode, Return); // For 2018/09/17 => 6

            string strOpeningField = "M" + month;
            return this.ViewDAO.SelectTriDetailForBackDate(currency, branchCode, selectedDate, strOpeningField);
        }
       #endregion

    }
}
