//----------------------------------------------------------------------
// <copyright file="MNMDAO00022.cs"  company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San </CreatedUser>
// <CreatedDate>11/27/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using Ace.Windows.Core.Dao;
using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using NHibernate;
using System;
using Ace.Cbs.Mnm.Ctr.Dao;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Mnm.Dmd;
namespace Ace.Cbs.Mnm.Dao
{
    public class MNMDAO00022 : DataRepository<MNMORM00022>, IMNMDAO00022
    {
       #region Unused
        public IList<PFMDTO00042> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("ReportTLF.SelectAll");
            return query.List<PFMDTO00042>();
        }
    #endregion

        public bool DeleteAdjRemitOi(string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("DeleteAdjRemitOi");
            query.SetString("sourceBr", sourceBr);
            return query.ExecuteUpdate() > 0;
        }

    }



}
