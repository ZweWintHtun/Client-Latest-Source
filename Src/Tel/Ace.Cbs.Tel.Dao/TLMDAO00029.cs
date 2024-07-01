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

namespace Ace.Cbs.Tel.Dao
{
    public class TLMDAO00029 : DataRepository<TLMORM00029>, ITLMDAO00029
    {
        public decimal SelectIblSerialByDrawerBankAndCurrencyCode(string drawerbank, string SourceBr, string currencycode)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00029.SelectIblSerialByDrawerBankAndCurrencyCode");
            query.SetString("drawerbank", drawerbank);
            query.SetString("SourceBr", SourceBr);
            query.SetString("currencycode", currencycode);
            return Convert.ToDecimal(query.UniqueResult<TLMDTO00029>().IblSerial);
    
         }
        
        
        public void UpdateIBLSerial(string currencycode,int serial, string drawerbank,int updateduserid)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00029.UpdateSerial");
            query.SetString("drawerbank", drawerbank);
            query.SetString("currencycode", currencycode);
            query.SetInt32("serial", serial);
            query.SetDateTime("updateddate",DateTime.Now);
            query.SetInt32("updateduserId", updateduserid);             
            query.ExecuteUpdate();
        
        }

        public bool UpdateIBL(string currencycode, int serial, string drawerbank, string SourceBr, int updateduserid)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00029.IblSerialUpdate");
            query.SetString("drawerbank", drawerbank);
            query.SetString("SourceBr", SourceBr);
            query.SetString("currencycode", currencycode);
            query.SetInt32("serial", serial);
            query.SetDateTime("updateddate", DateTime.Now);
            query.SetInt32("updateduserId", updateduserid);
            return query.ExecuteUpdate() > 0;
        }

        public void IBLSerialUpdate(string currencycode, int serial, string drawerbank, string SourceBr, int updateduserid)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00029.IblSerialUpdate");
            query.SetString("drawerbank", drawerbank);
            query.SetString("SourceBr", SourceBr);
            query.SetString("currencycode", currencycode);
            query.SetInt32("serial", serial);
            query.SetDateTime("updateddate", DateTime.Now);
            query.SetInt32("updateduserId", updateduserid);
            query.ExecuteUpdate();

        }

        public bool CheckExist(int id, string branchCode, string sourceBr, string cur)
        {
            IQuery query = this.Session.GetNamedQuery("RemitBrIblDAO.CheckExist");
            query.SetString("branchCode", branchCode);
            query.SetString("sourceBr", sourceBr);
            query.SetString("cur", cur);
            TLMDTO00029 RemitBr = query.UniqueResult<TLMDTO00029>();
            return RemitBr == null ? false : true;
        }

        public TLMDTO00029 SelectByCode(string cur, string branchCode, string SourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("RemitBrIblDAO.SelectByCode");
            query.SetString("branchCode", branchCode);
            query.SetString("SourceBr", SourceBr);
            query.SetString("cur", cur);
            return query.UniqueResult<TLMDTO00029>();
        }
        public bool DeleteById(int id, int userId)
        {
            IQuery query = this.Session.GetNamedQuery("RemitBrIblDAO.DeleteById");
            query.SetDateTime("updatedDate", System.DateTime.Now);
            query.SetInt32("updatedUserId", userId);
            query.SetInt32("id", id);
            return query.ExecuteUpdate() > 0 ? true : false;
        }
        public TLMDTO00029 SelectById(int id, string SourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("RemitBrIblDAO.SelectById");
            query.SetInt32("id", id);
            query.SetString("SourceBr", SourceBr);
            return query.UniqueResult<TLMDTO00029>();
        }

    }
}
