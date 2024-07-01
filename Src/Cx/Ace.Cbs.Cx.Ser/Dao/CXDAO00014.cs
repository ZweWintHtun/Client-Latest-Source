//----------------------------------------------------------------------
// <copyright file='For Framework Commodule (CCOA) ' company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Khin Swe Win</CreatedUser>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Admin.DataModel;
using NHibernate;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using System;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Windows.Core.Dao;


namespace Ace.Cbs.Cx.Ser.Dao
{
   public class CXDAO00014:DataRepository<CurrencyChargeOfAccount>, ICXDAO00014
   {
       #region daily posting 

       public IList<CurrencyChargeOfAccountDTO> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("CCOADAO.SelectAll");
            return query.List<CurrencyChargeOfAccountDTO>();
        }

        public CurrencyChargeOfAccountDTO SelectByACODE(string aCODE)
        {
            IQuery query = this.Session.GetNamedQuery("CCOADAO.SelectByACODE");
            query.SetString("aCODE", aCODE);
            return query.UniqueResult<CurrencyChargeOfAccountDTO>();
        }

        public IList<CurrencyChargeOfAccountDTO> SelectAllyearly(string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("CCOADAO.SelectAllForyearly");
            query.SetString("dcode", sourcebr);
            return query.List<CurrencyChargeOfAccountDTO>();
        }

        public bool UpdateBalance(int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("CCOADAO.UpdateBalance");
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", updatedUserId);
            return query.ExecuteUpdate() > 0;
        }

        public bool UpdateZeroBalance(string budget, int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("CCOADAO.UpdateZeroBalance");
            query.SetString("budget", budget);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", updatedUserId);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateBlanceNotM1ForDailyPost(string currentMonth, string currentMSRC, string prevMonth, string prevMSRC, string branchcode, int updatedUserId)
        {
            string dmlString = "update CurrencyChargeOfAccount set " + currentMonth + "=" + prevMonth + "," + currentMSRC + "=" + prevMSRC + ",UpdatedUserId=" + updatedUserId + ",UpdatedDate=:updatedDate where DCODE='" + branchcode + "' and Active=true";
            IQuery query = this.Session.CreateQuery(dmlString);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateBalanceEqualM1ForDailyPost(string currentMonth, string currentMSRC, string branchCode, int updatedUserId)
        {
            string dmlString = "update CurrencyChargeOfAccount  set " + currentMonth + "=CBAL," + currentMSRC + "=HOBAL " + ",UpdatedUserId=" + updatedUserId + ",UpdatedDate=:updatedDate  where DCODE=" + branchCode + " and Active=true";
            IQuery query = this.Session.CreateQuery(dmlString);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateDailyPostingForAcode(string Acode, string Dcode, string Cur, string currentMonth, string currentMSRC, decimal LocalAmt, decimal homeAmt, int updatedUserId)
        {
            string dmlString = "update CurrencyChargeOfAccount set " + currentMonth + "=" + currentMonth + "+" + LocalAmt + "," + currentMSRC + "=" + currentMSRC + "+" + homeAmt + ",UpdatedUserId=" + updatedUserId + ",UpdatedDate=:updatedDate  where ACODE=" + "'" + Acode + "'" + " and DCODE=" + "'" + Dcode + "'" + " and CUR=" + "'" + Cur + "'" + " and Active=true";
            IQuery query = this.Session.CreateQuery(dmlString);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateDailyPostingForHeadAcode(string HeadAcode, string Dcode, string Cur, string currentMonth, string currentMSRC, decimal LocalAmt, decimal homeAmt, int updatedUserId)
        {
            string dmlString = "update CurrencyChargeOfAccount set " + currentMonth + "=" + currentMonth + "+" + LocalAmt + "," + currentMSRC + "=" + currentMSRC + "+" + homeAmt + ",UpdatedUserId=" + updatedUserId + ",UpdatedDate=:updatedDate  where ACODE=" + "'" + HeadAcode + "'" + " and DCODE=" + "'" + Dcode + "'" + " and CUR=" + "'" + Cur + "'" + " and Active=true";
            IQuery query = this.Session.CreateQuery(dmlString);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateDailyPostingForGroupAcode(string GroupAcode, string Dcode, string Cur, string currentMonth, string currentMSRC, decimal LocalAmt, decimal homeAmt, int updatedUserId)
        {
            string dmlString = "update CurrencyChargeOfAccount set " + currentMonth + "=" + currentMonth + "+" + LocalAmt + "," + currentMSRC + "=" + currentMSRC + "+" + homeAmt + ",UpdatedUserId=" + updatedUserId + ",UpdatedDate=:updatedDate  where ACODE=" + "'" + GroupAcode + "'" + " and DCODE=" + "'" + Dcode + "'" + " and CUR=" + "'" + Cur + "'" + " and Active=true";
            IQuery query = this.Session.CreateQuery(dmlString);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateZeroForNullDcode(string currentMonth, string currentMSRC, int updatedUserId)
        {
            string dmlString = "update CurrencyChargeOfAccount set " + currentMonth + "=0," + currentMSRC + "=0" + ",UpdatedUserId=" + updatedUserId + ",UpdatedDate=:updatedDate  where DCODE='' and Active=true";
            IQuery query = this.Session.CreateQuery(dmlString);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }

        public IList<CurrencyChargeOfAccountDTO> SelectSumAllDcode(string currentMonth, string currentMSRC, string dcode)
        {
            string dmlString = "select new ccoadto (CUR,ACODE,Sum(" + currentMonth + ") as TotalM," + "Sum(" + currentMSRC + ") as TotalMSRC ) from CurrencyChargeOfAccount Where " + currentMonth + " <>0 and DCODE=" + "'" + dcode + "'" + " Group By ACODE,CUR";
            IQuery query = this.Session.CreateQuery(dmlString);

            return query.List<CurrencyChargeOfAccountDTO>();

        }

        public IList<CurrencyChargeOfAccountDTO> SelectAllByDcodeandCurrentmth(string currentMonth, string currentMSRC, string dcode)
        {
            string dmlString = "select new ccoadto(CUR,ACODE," + currentMonth + " as TotalM," + currentMSRC + " as TotalMSRC ) from CurrencyChargeOfAccount Where " + currentMonth + " <>0 and DCODE=" + "'" + dcode + "'";
            IQuery query = this.Session.CreateQuery(dmlString);

            return query.List<CurrencyChargeOfAccountDTO>();

        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateGroupAcode(string currentMonth, string currentMSRC, decimal totalM, decimal totalMSRC, string acode, string cur, int updatedUserId)
        {
            string dmlString = "update CurrencyChargeOfAccount set " + currentMonth + "=" + currentMonth + "+" + totalM + ", " + currentMSRC + "=" + currentMSRC + "+" + totalMSRC + ",UpdatedUserId=" + updatedUserId + ",UpdatedDate=:updatedDate  where ACODE=" + "'" + acode + "'" + "  and CUR=" + "'" + cur + "'" + " and DCODE='' and Active=true";
            IQuery query = this.Session.CreateQuery(dmlString);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateDcodeNullForCheckStatus(string currentMonth, string currentMSRC, decimal currentAmt, decimal msrcAmt, string acode, string cur, int updatedUserId)
        {
            string dmlString = "update CurrencyChargeOfAccount set " + currentMonth + "=" + currentMonth + "-" + currentAmt + ", " + currentMSRC + "=" + currentMSRC + "-" + msrcAmt + ",UpdatedUserId=" + updatedUserId + ",UpdatedDate=:updatedDate  where ACODE=" + "'" + acode + "'" + "  and CUR=" + "'" + cur + "'" + " and DCODE='' and Active=true";
            IQuery query = this.Session.CreateQuery(dmlString);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }

       //Added by HWKO (25-Oct-2017) For Cash Closing
        public decimal SelectCurMAmtByAcodeAndDcode(string currentMonth, string acode, string dcode)
        {
            string dmlString = "select " + currentMonth + " as CurMAmt from CurrencyChargeOfAccount Where ACODE = " + "'" + acode + "'" + "and DCODE=" + "'" + dcode + "'";
            IQuery query = this.Session.CreateQuery(dmlString);

            return query.UniqueResult<decimal>();
        }

       #endregion

        #region For Budget End Flexible By ZMS 2018/09/17
        /// <summary>
        ///budget Year,Month,Quarter calculation
        /// </summary>
        /// <param name="variable">Service 1 is table name checking TLF1516M1,TLF1718M2,etc return will 18#19,18#18,etc </param>
        /// <returns>return 18#19,18#18,etc</returns>
        /// <param name="variable">Service 2 is Budget Year parameter 2018/2019,2019/2020,etc </param>
        /// <returns> return 2018/2019,2019/2020,etc</returns>
        /// <param name="variable">Service 3 is Budget Month calculation Budget Month 1 is start from budget year start, return 1 to 12</param>
        /// <returns> return 1,2,3,4,...,12 for Month </returns>
        /// <param name="variable">Service 4 is quarter calculation budget quarter of every 3 months return 1,2,3,4 </param>
        /// <returns>return 1,2,3,4 For Quarter</returns>
        /// <param name="variable">Service 5 is to return Quarter Start Date and End Date With 'YYYY/MM/DD'#'YYYY/MM/DD' format </param>
        /// <returns>return '2018/01/01'#'2018/03/01' </returns>       
        public string GetBudget_Month_Year_Quarter(Int32 service, DateTime pDate, string branchCode, string Return)
        {
            IQuery query = this.Session.GetNamedQuery("sp_BudInfo");
            query.SetInt32("service", service);
            query.SetDateTime("pDate", pDate);
            query.SetString("branchCode", branchCode);
            query.SetString("Return", Return);
            //query.SetTimeout(10000);
            return query.UniqueResult().ToString();
        }
        #endregion
   }
}