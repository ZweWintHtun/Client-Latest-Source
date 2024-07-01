using System;
using System.Collections;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.Core.Utt;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using Ace.Windows.Ix.Contracts.Dao;

namespace Ace.Cbs.Cx.Ser.Sve
{
    /// <summary>
    /// Client Version Data Service Class (Server) by ServerVersion and CounterVersion
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
    public class CXSVE00001 : BaseService, ICXSVE00001
    {
        #region Private Variables
        private ICXDAO00001 serverDataDAO = null;
        #endregion

        #region Properties
        public ICXDAO00001 ServerDataDAO
        {
            get { return this.serverDataDAO; }
            set { this.serverDataDAO = value; }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Get database list data by configuration in appserverdata.xml
        /// </summary>
        /// <typeparam name="TResult">Your target object</typeparam>
        /// <param name="clientKeyName">Your configuration in appserverdata.xml</param>
        /// <param name="parameters">Your parameters</param>
        /// <returns>Target List Object</returns>
        public IList GetListObject(int serverDataVersionId)
        {
            try
            {
                Dictionary<string, object> parameters = null;

                string queryString = this.GetSQLString(serverDataVersionId, ref parameters);

                IList list = this.serverDataDAO.GetListObject(queryString, parameters);

                return list;
            }
            catch (Exception exp)
            {
                throw new Exception(CXMessage.ME90015, exp);
            }
        }

        /// <summary>
        /// Get database single data by configuration in appserverdata.xml
        /// </summary>
        /// <typeparam name="TResult">Your target object</typeparam>
        /// <param name="clientKeyName">Your configuration in appserverdata.xml</param>
        /// <param name="parameters">Your parameters</param>
        /// <returns>Target Single Object</returns>
        public object GetScalarObject(int serverDataVersionId)
        {
            try
            {
                Dictionary<string, object> parameters = null;

                string queryString = this.GetSQLString(serverDataVersionId, ref parameters);

                IList list = this.serverDataDAO.GetListObject(queryString, parameters);

                return list[0];
            }
            catch (Exception exp)
            {
                throw new Exception(CXMessage.ME90016, exp);
            }
        }

        public void ServerVersion_Save(PFMDTO00031 serverVersion)
        {
            int count = this.serverDataDAO.ServerVersion_Count(serverVersion.ORMDescription, serverVersion.DataIdName);

            if (count > 0)
            {
                this.serverDataDAO.ServerVersion_Update(serverVersion.ORMDescription, serverVersion.DataIdName, serverVersion.Status, serverVersion.UpdatedDate.Value, serverVersion.UpdatedUserId.Value);
            }
            else
            {
                PFMORM00031 result = new PFMORM00031();
                result.Version = serverVersion.Version;
                result.DataVersionId = serverVersion.DataIdValue;
                result.DataIdValue = serverVersion.DataIdValue;
                result.Status = serverVersion.Status;
                result.Version = serverVersion.Version;
                result.CreatedDate = DateTime.Now;
                result.CreatedUserId = serverVersion.CreatedUserId;

                this.serverDataDAO.Save(result);
            }
        }

        public PFMDTO00031 ServerVersionById(int serverVersionId)
        {
            return this.serverDataDAO.ServerVersionById(serverVersionId);
        }

        public IList<PFMDTO00031> GetUpdateList(string counterId, decimal currentVersion)
        {
            return this.serverDataDAO.ServerVersion_SelectListByCounterIdVersionNumber(counterId, currentVersion);
        }

        public void ServerVersion_UpdateVersion(IList<PFMDTO00031> list, decimal definedServerNumber)
        {
            for (int i = 0; i < list.Count; i++)
            {
                this.serverDataDAO.ServerVersion_UpdateVersion(list[i].Id, list[i].TS, definedServerNumber);
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public bool CounterVersion_Insert(PFMDTO00030 entity)
        {
            PFMORM00030 ormEntity = new PFMORM00030();
            ormEntity.CounterId = entity.CounterId;
            ormEntity.ServerVersionId = entity.ServerVersionId;
            ormEntity.Active = true;
            ormEntity.CreatedDate = DateTime.Now;
            ormEntity.CreatedUserId = entity.CreatedUserId;

            object returnValue = this.serverDataDAO.CounterVersion_Insert(ormEntity);

            return returnValue != null;
        }

        private string GetSQLString(int serverDataVersionId, ref Dictionary<string, object> parameters)
        {
            // Select new messagedto(Id, Code, Description) From Message Where m.Id = 1)
            string sqlFormat = "Select new {0}({1}) From {2} {3}";

            PFMDTO00031 serverDataVersion = this.serverDataDAO.ServerVersionById(serverDataVersionId);

            string whereStatement = string.Empty;
            string[] whereItems = null;
            string[] valueItems = null;

            whereItems = serverDataVersion.DataIdName.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            valueItems = serverDataVersion.DataIdValue.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            parameters = new Dictionary<string, object>();

            for (int i = 0; i < whereItems.Length; i++)
            {
                if (string.IsNullOrEmpty(whereItems[i].Trim()) == false)
                {
                    if (string.IsNullOrEmpty(whereStatement))
                    {
                        whereStatement = " Where " + whereItems[i] + "=:" + whereItems[i];
                        parameters.Add(whereItems[i], valueItems[i]);
                    }
                    else
                    {
                        whereStatement += " and " + whereItems[i] + "=:" + whereItems[i];
                        parameters.Add(whereItems[i], valueItems[i]);
                    }
                }
            }

            sqlFormat = string.Format(sqlFormat, new object[] { serverDataVersion.DTOName, serverDataVersion.ORMProperties, serverDataVersion.ORMName, whereStatement });

            return sqlFormat;
        }
        #endregion


        #region Server Sqlite
        public IServerClientDataUpdateDAO ServerClientDataUpdateDAO { get; set; }

        [Transaction(TransactionPropagation.Required)]
        public bool Delete(string ormName, string primaryKey, object primaryKeyValue, int deletedUserId,byte[] ts)
        {
            return this.ServerClientDataUpdateDAO.Delete(ormName, primaryKey, primaryKeyValue, deletedUserId,ts);
        }

        public bool Update(string ormName, Dictionary<string, object> updateColumnsandValues, Dictionary<string, object> whereColumnsandValues)
        {
            return this.ServerClientDataUpdateDAO.Update(ormName, updateColumnsandValues, whereColumnsandValues);
        }

        public void Save(object entity)
        {
            //this.ServerClientDataUpdateDAO.Save(entity);
        }

        public void InsertServer(string tableName, Dictionary<string, object> savecolumnsandValues, byte[] ts, int createdUserId, DateTime createdDate)
        {
            this.ServerClientDataUpdateDAO.InsertServer(tableName, savecolumnsandValues, ts, createdUserId, createdDate);
        }


        public void Insert(object entity)
        {
            throw new NotImplementedException();
        }

        public bool UpdateServer(string ormName, Dictionary<string, object> updateColumnsandValues, Dictionary<string, object> whereColumnsandValues)
        {
            return this.ServerClientDataUpdateDAO.Update(ormName, updateColumnsandValues, whereColumnsandValues);
        }

        #endregion
    }
}
