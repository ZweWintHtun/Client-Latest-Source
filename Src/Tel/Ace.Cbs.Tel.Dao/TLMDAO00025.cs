//----------------------------------------------------------------------
// <copyright file="TLMDAO00025.cs" company="ACE Data Systems">
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
    public class TLMDAO00025 : DataRepository<TLMORM00025>, ITLMDAO00025
    {
        public void UpdateCurselReconcile(string branch, string type, DateTime date,string sourceBranch,int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00025.UpdateReconsileByCursel");
            query.SetString("branch", branch);
            query.SetString("type", type);
            query.SetDateTime("date", date);
            query.SetString("sourceBranch", sourceBranch);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.ExecuteUpdate();
        }


        public void DeleteDrawingBankReconcile(string type,string branchcode,DateTime datetime,string sourceBranch)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00025.Delete");
            query.SetString("type", type);
            query.SetString("branchcode", branchcode);
            query.SetString("datetime", datetime.ToString("yyyy/MM/dd"));
            query.SetString("sourceBranch", sourceBranch);
            query.ExecuteUpdate();
        }

        public Nullable<Int32> SelectID()
        {
            object maxdateobject;
            int maxId;
            IQuery query = this.Session.GetNamedQuery("TLMDAO00025.SelectMaxId");         
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


        public IList<TLMDTO00025> SelectReconsileData(string sourcebranchCode)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00025.GetSelectAllDataByReconcile");
            query.SetString("sourcebranchcode", sourcebranchCode);
            string sqlQuery = this.GetSQLString(query.QueryString);         
            return query.List<TLMDTO00025>();
        }


        public IList<TLMDTO00025> GetReconsileListForRemittance(IList<string> branchcodelist,string type,DateTime datetime)
        {

            IQuery query = this.Session.GetNamedQuery("TLMDAO00025.SelectReconsileListForRemittance");
            query.SetParameterList("branchcodelist", branchcodelist);
            query.SetString("type", type);
            query.SetDateTime("datetime", datetime.Date);
            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<TLMDTO00025> list = query.List<TLMDTO00025>();
            return list;
        }
    }
}
