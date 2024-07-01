//----------------------------------------------------------------------
// <copyright file="TLMDAO00015.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hnin Thazin Shwe</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
using System;
using Spring.Transaction;
using Spring.Transaction.Interceptor;


namespace Ace.Cbs.Tel.Dao
{
   public class TLMDAO00028 : DataRepository<TLMORM00028>, ITLMDAO00028
    {

       public int SelectMaxId()
       {
           IQuery query = this.Session.GetNamedQuery("TLMDAO00028.SelectMaxId");
           TLMDTO00028 remitBrdto = query.UniqueResult<TLMDTO00028>();
           return remitBrdto.Id;
       }

      public void UpdateTTSerial(string currencycode, int serial, string drawerbank, int updateduserid)
       {
           IQuery query = this.Session.GetNamedQuery("TLMDAO00028.UpdateSerial");
           query.SetString("drawerbank", drawerbank);
           query.SetString("currencycode", currencycode);
           query.SetInt32("serial", serial);
           query.SetDateTime("updateddate", DateTime.Now);
           query.SetInt32("updateduserId", updateduserid);
           query.ExecuteUpdate();
       }

      public void UpdateSerialRemit()
      {
          IQuery query = this.Session.GetNamedQuery("TLMDAO00028.UpdateSerialRemit");
          query.ExecuteUpdate();
      }

      public decimal SelectTTSerialByDrawerBankAndCurrencyCode(string drawerbank, string currencycode)
      {
          IQuery query = this.Session.GetNamedQuery("TLMDAO00028.SelectTTSerialByDrawerBankAndCurrencyCode");
          query.SetString("drawerbank", drawerbank);
          query.SetString("currencycode", currencycode);
          return Convert.ToDecimal(query.UniqueResult<TLMDTO00028>().TTSerial);

      }

      public bool CheckExist(int id, string branchCode, string sourceBr, string cur)
      {
          IQuery query = this.Session.GetNamedQuery("RemitBrDAO.CheckExist");
          query.SetString("branchCode", branchCode);
          query.SetString("sourceBr", sourceBr);
          query.SetString("cur", cur);
          TLMDTO00028 RemitBr = query.UniqueResult<TLMDTO00028>();
          return RemitBr == null ? false : true;
      }

      public TLMDTO00028 SelectByCode(string currency, string branchCode, string sourceBranch)
      {
          IQuery query = this.Session.GetNamedQuery("RemitBrDAO.SelectByCode");
          query.SetString("branchCode", branchCode);
          query.SetString("sourceBranch", sourceBranch);
          query.SetString("currency", currency);
          return query.UniqueResult<TLMDTO00028>();
      }

      public bool DeleteById(int id, int userId)
      {
          IQuery query = this.Session.GetNamedQuery("RemitBrDAO.DeleteById");
          query.SetDateTime("updatedDate", System.DateTime.Now);
          query.SetInt32("updatedUserId", userId);
          query.SetInt32("id", id);
          return query.ExecuteUpdate() > 0 ? true : false;
      }


       [Transaction(TransactionPropagation.Required)]
      public void UpdateSerialRemit(decimal serial, string sourcebr, int updateduserid)
      {
          IQuery query = this.Session.GetNamedQuery("TLMDAO00028.UpdateSerialRemit");
          query.SetDecimal("serial", serial);
          query.SetString("sourceBranch", sourcebr);
          query.SetDateTime("UpdatedDate", DateTime.Now);
          query.SetInt32("updatedUserId", updateduserid);
          query.ExecuteUpdate();
      }
       public TLMDTO00028 SelectById(int id, string sourceBranch)
       {
           IQuery query = this.Session.GetNamedQuery("RemitBrDAO.SelectById");
           query.SetInt32("id", id);
           query.SetString("sourceBranch", sourceBranch);         
           return query.UniqueResult<TLMDTO00028>();
       }

       public void TTSerialUpdate(string currencycode, int serial, string drawerbank, string SourceBr, int updateduserid)
       {
           IQuery query = this.Session.GetNamedQuery("RemitBrDAO.UpdateSerialRemit");
           query.SetString("drawerbank", drawerbank);
           query.SetString("sourceBranch", SourceBr);
           query.SetString("currencycode", currencycode);
           query.SetInt32("serial", serial);
           query.SetDateTime("UpdatedDate", DateTime.Now);
           query.SetInt32("updatedUserId", updateduserid);
           query.ExecuteUpdate();

       }
       public decimal SelectTTSerialByDrawerBankAndSourceBrachCode(string drawerbank, string SourceBr, string currencycode)
       {
           IQuery query = this.Session.GetNamedQuery("TLMDAO00028.SelectTTSerialByDrawerBankAndSourceBrachCode");
           query.SetString("drawerbank", drawerbank);
           query.SetString("SourceBr", SourceBr);
           query.SetString("currencycode", currencycode);
           //return Convert.ToDecimal(query.UniqueResult<TLMDTO00028>().TTSerial);
           return Convert.ToDecimal(query.UniqueResult<TLMDTO00028>().TelaxCharges);

       }
    }
}
