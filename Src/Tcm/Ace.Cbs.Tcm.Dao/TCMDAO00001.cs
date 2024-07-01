//----------------------------------------------------------------------
// <copyright file="TCMDAO00001.cs" Name="Start" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San </CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Tcm.Ctr.Dao;
using NHibernate;

namespace Ace.Cbs.Tcm.Dao
{
    /// <summary>
    /// Start DAO
    /// </summary>
  public  class TCMDAO00001 : DataRepository<TCMORM00001>,ITCMDAO00001
    {
      public TCMDTO00001 SelectStartBySourceBr(string sourceBr)
      {
          IQuery query = this.Session.GetNamedQuery("TCMDAO00001.SelectStartBySourceBr");
          query.SetString("sourceBr", sourceBr);
          return query.UniqueResult<TCMDTO00001>();
      }

      public bool UpdateBySourceBr(string sourceBr,int updatedUserId,string status)
      {
          IQuery query = this.Session.GetNamedQuery("TCMDAO00001.UpdateStatusAndDateBySourceBr");
          query.SetString("status", status);
          query.SetDateTime("date", DateTime.Now);
          query.SetDateTime("updatedDate", DateTime.Now);
          query.SetInt32("updatedUserId", updatedUserId);
          query.SetString("sourceBr", sourceBr);
          return query.ExecuteUpdate() > 0;
      }

      public bool UpdateStatusBySourceBr(string sourceBr, int updatedUserId, string status)
      {
          IQuery query = this.Session.GetNamedQuery("TCMDAO00001.UpdateStatusBySourceBr");
          query.SetString("status", status);        
          query.SetDateTime("updatedDate", DateTime.Now);
          query.SetInt32("updatedUserId", updatedUserId);
          query.SetString("sourceBr", sourceBr);
          return query.ExecuteUpdate() > 0;
      }

    
     

    }
}
