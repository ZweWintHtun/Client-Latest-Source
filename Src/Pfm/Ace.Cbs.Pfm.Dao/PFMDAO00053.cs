//----------------------------------------------------------------------
// <copyright file="PFMDAO00053.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>08/05/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
using Ace.Windows.Core.Utt;
using System;

namespace Ace.Cbs.Pfm.Dao
{
    public class PFMDAO00053 : DataRepository<PFMORM00053>, IPFMDAO00053
    {
        public bool CheckExist(int id, string keyName, string keyValue, int location, int type)
        {
            IQuery query = this.Session.GetNamedQuery("AppSettingsDAO.CheckExist");
            query.SetString("keyName", keyName);
            PFMDTO00053 AppSettings = query.UniqueResult<PFMDTO00053>();
            return AppSettings == null ? false : (AppSettings.Id == id ? false : true);
        }
        public IList<PFMDTO00053> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("AppSettingsDAO.SelectAll");
            return query.List<PFMDTO00053>();
        }

        public PFMDTO00053 SelectById(int id)
        {
            IQuery query = this.Session.GetNamedQuery("AppSettingsDAO.SelectById");
            query.SetInt32("id", id);
            return query.UniqueResult<PFMDTO00053>();
        }

        public bool UpdateKeyValue(string keyname, string keyValue)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00053.UpdateKeyValueByKeyName");
            query.SetString("keyName", keyname);
            query.SetString("KeyValue", keyValue);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", CurrentUserEntity.CurrentUserID);
            return query.ExecuteUpdate() > 0;

        }
        public IList<PFMDTO00053> SelectByKeyName(string keyName1, string keyname2)
        {
            IQuery query = this.Session.GetNamedQuery("AppSettingsDAO.SelectByKeyName");
            query.SetString("keyName1", keyName1);
            query.SetString("keyName2", keyname2);

            IList<PFMDTO00053> ListAppSettDTO = query.List<PFMDTO00053>();
            return ListAppSettDTO;
        }



    }
}