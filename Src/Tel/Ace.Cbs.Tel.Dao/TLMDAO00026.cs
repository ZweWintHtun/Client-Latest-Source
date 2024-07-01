//----------------------------------------------------------------------
// <copyright file="TLMDAO00026.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo</CreatedUser>
// <CreatedDate>2013-07-18</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System.Collections.Generic;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
using System;

namespace Ace.Cbs.Tel.Dao
{
    /* ReconsileDWT DAO*/
    public class TLMDAO00026 : DataRepository<TLMORM00026>, ITLMDAO00026
    {
        public void DeleteTransactionReconcile(string branchcode, DateTime datetime)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00026.Delete");         
            query.SetString("branchcode", branchcode);
            query.SetString("datetime", datetime.ToString("yyyy/MM/dd"));
            query.ExecuteUpdate();
        }
        public IList<TLMDTO00026> SelectReconsileDWTData(IList<string> branchcodelist)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00026.SelectReconsileListForTransaction");  
            query.SetString("type","DWT");
            query.SetDateTime("datetime", DateTime.Now);
            query.SetParameterList("branchcodelist", branchcodelist);
            return query.List<TLMDTO00026>();
        }
        public Nullable<Int32> SelectID()
        {
            object maxdateobject;
            int maxId;
            IQuery query = this.Session.GetNamedQuery("TLMDAO00026.SelectMaxId");
            //query.SetDateTime("datetime", date);
            //string sqlQuery = this.GetSQLString(query.QueryString);
            maxdateobject = query.SetFirstResult(0).SetMaxResults(1).UniqueResult();
            if (maxdateobject != null)
            {
                maxId = Convert.ToInt32(maxdateobject);
                maxId += 1;
                return maxId;
            }
            else
            {
                 return maxId = 1;
            }

        }
    }
}
