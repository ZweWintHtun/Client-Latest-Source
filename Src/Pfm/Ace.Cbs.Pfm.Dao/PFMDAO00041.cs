//----------------------------------------------------------------------
// <copyright file="PFMDAO00041.cs" Name="Start" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San </CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using Ace.Windows.Core.Dao;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using NHibernate;
using System;
namespace Ace.Cbs.Pfm.Dao
{
    public class PFMDAO00041 : DataRepository<PFMORM00041>, IPFMDAO00041
    {
        public bool UpdateDenoStatusBySourceBr(string sourceBr, int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00041.UpdateDenostatusBySourceBr");
            query.SetString("denoStatus", string.Empty);
            query.SetString("sourceBr", sourceBr);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }
    }
}