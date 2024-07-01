using System;
using System.Collections;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;

namespace Ace.Cbs.Cx.Ser.Dao
{
    /// <summary>
    /// Client Version Data Dao Class (Server) by ServerVersion and CounterVersion
    /// 
    /// You must follow the following rules
    /// 1. Create ORM object
    /// 2. Create DTO object (must be equal to ORM object's name except the suffix "dto".
    /// 3. Map ORM object with database
    /// 4. Import DTO object as Nhibernate object in the related ORM Mapping file(.hbm.xml)
    /// 5. Configure in appserverdata.xml file
    /// 
    /// You can call as the following:
    /// IList<GroupDTO> list = CXServer.CXServerData.Instance.GetListObject<GroupDTO>("Group.Select", new object[] {1});
    /// </summary>
    public class CXDAO00001 : DataRepository<PFMORM00031>, ICXDAO00001
    {
        public IList GetListObject(string queryString, Dictionary<string, object> parameters)
        {
           IQuery query = this.Session.CreateQuery(queryString);

            if (parameters != null)
            { 
                this.BuildParameterValue(query, parameters);
            }

            return query.List();
        }

        private void BuildParameterValue(IQuery query, Dictionary<string, object> parameters)
       {
           foreach (KeyValuePair<string, object> item in parameters)
           {
               if (item.Value is bool)
               {
                   query.SetBoolean(item.Key, Convert.ToBoolean(item.Value));
               }
               else
               {
                   query.SetParameter(item.Key, item.Value);
               }
           }
       }

        public int ServerVersion_Count(string tableName, string dataId)
        {
            IQuery query = this.Session.GetNamedQuery("ServerVersionDAO.Count");
            query.SetString("tableName", tableName);
            query.SetString("dataId", dataId);

            return query.UniqueResult<int>();
        }

        public PFMDTO00031 ServerVersionById(int id)
        {
            IQuery query = this.Session.GetNamedQuery("ServerVersionDAO.SelectById");
            query.SetInt32("id", id);

            return query.UniqueResult<PFMDTO00031>();
        }

        public int ServerVersion_Update(string tableName, string dataId, int status, DateTime updatedDate, int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("ServerVersionDAO.Update");
            query.SetString("tableName", tableName);
            query.SetString("dataId", dataId);
            query.SetInt32("status", status);
            query.SetDateTime("updatedDate", updatedDate);
            query.SetInt32("updatedUserId", updatedUserId);
            return query.ExecuteUpdate();
        }

        public int ServerVersion_UpdateVersion(int serverVersionId, byte[] timestamp, decimal definedVersionNumber)
        {
            IQuery query = this.Session.GetNamedQuery("ServerVersionDAO.UpdateVersion");
            return query.ExecuteUpdate();
        }

        public IList<PFMDTO00031> ServerVersion_SelectListByCounterIdVersionNumber(string counterId, decimal currentVersionNumber)
        {
            IQuery query = this.Session.GetNamedQuery("ServerVersionDAO.SelectListByCounterIdVersionNumber");
            query.SetDecimal("versionno", currentVersionNumber);
            query.SetString("counterid", counterId);

            return query.List<PFMDTO00031>();
        }

        public object CounterVersion_Insert(PFMORM00030 entity)
        {
            return this.Session.Save(entity);
        }
    }
}
