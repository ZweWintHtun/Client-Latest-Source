using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;
using NHibernate;
using Spring.Data.NHibernate.Support;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Tel.Dmd;
using System.Linq;

namespace Ace.Cbs.Cx.Cle
{
    /// <summary>
    /// Insert, Update, Delete and Search client data from SQLite database
    /// by xml configuration file (appclientdata.xml).
    /// </summary>
    public class CXCLE00002 : HibernateDaoSupport
    {
        #region Private Variables
        private static CXCLE00002 instance = null;
        private IQuery query = null;
        #endregion

        #region Properties
        /// <summary>
        /// CXClientData Singleton Object
        /// </summary>
        public static CXCLE00002 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = SpringApplicationContext.Instance.Resolve<CXCLE00002>("CXClientDataHandler");
                }

                return instance;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Insert Client Data by Configuration Key Name
        /// </summary>
        /// <param name="clientConfigKeyName">Client Data Configuration Key Name</param>
        /// <param name="value">Your Updated Client Data</param>
        public void Save(string ormName, object value, PFMDTO00030 counter)
        {
            try
            {
                // Get ORM Object without data
                object ormObject = Activator.CreateInstance(Type.GetType(ormName));

                // Transform dto object to orm object with data
                object saveObject = null; // Mapper.Map(value, ormObject, value.GetType(), ormObject.GetType());

                // Save ORM object
                this.Session.Save(saveObject);

                bool returnValue = CXClientWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.CounterVersion_Insert(counter));

                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    throw new Exception(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }

                if (returnValue == false)
                {
                    throw new Exception(CXMessage.ME90000);
                }
            }
            catch (Exception exp)
            {
                throw new Exception(CXMessage.ME90000, exp);
            }
            finally
            {
                if (this.Session.IsOpen)
                {
                    this.Session.Close();
                }
            }               
        }

        /// <summary>
        /// Update Client Data by Configuration Key Name
        /// </summary>
        /// <param name="clientConfigKeyName">Client Data Configuration Key Name</param>
        /// <param name="value">Your Updated Client Data</param>
        public void Update(string clientConfigKeyName, object value)
        {
            try
            {
                // Get Spring Object
                CXDMD00003 clientDataEntity = SpringApplicationContext.Instance.Resolve<CXDMD00003>(clientConfigKeyName);

                Dictionary<string, object> parameters = null;
                string hqlString = this.GetSQLString(clientDataEntity.ORMObjectName, clientDataEntity.ORMProperties, string.Empty, string.Empty, clientDataEntity.WhereProperties, CXDMD00001.Update, value, ref parameters);
                this.query = this.Session.CreateQuery(hqlString);
                if (parameters != null)
                {
                    this.BuildParameterValue(parameters);
                }

                this.query.ExecuteUpdate();
            }
            catch (Exception exp)
            {
                throw new Exception(CXMessage.ME90001, exp);
            }
            finally
            {
                if (this.Session.IsOpen)
                {
                    this.Session.Close();
                }
            }
        }

        /// <summary>
        /// Delete Client Data by Configuration Key Name
        /// </summary>
        /// <param name="clientConfigKeyName">Client Data Configuration Key Name</param>
        /// <param name="value">Your Updated Client Data</param>
        public void Delete(string clientConfigKeyName, object value)
        {
            try
            {
                // Get Spring Object
                CXDMD00003 clientDataEntity = SpringApplicationContext.Instance.Resolve<CXDMD00003>(clientConfigKeyName);

                Dictionary<string, object> parameters = null;
                string hqlString = this.GetSQLString(clientDataEntity.ORMObjectName, clientDataEntity.ORMProperties, string.Empty, string.Empty, clientDataEntity.WhereProperties, CXDMD00001.Delete, value, ref parameters);
                this.query = this.Session.CreateQuery(hqlString);
                if (parameters != null)
                {
                    this.BuildParameterValue(parameters);
                }

                this.query.ExecuteUpdate();
            }
            catch (Exception exp)
            {
                throw new Exception(CXMessage.ME90002, exp);
            }
            finally
            {
                if (this.Session.IsOpen)
                {
                    this.Session.Close();
                }
            }
        }

        /// <summary>
        /// Get Client Scalar Data by Configuration Key Name
        /// </summary>
        /// <typeparam name="TResult">Your Client Data DTO Object</typeparam>
        /// <param name="clientKeyName">Client Data Configuration Key Name</param>
        /// <returns>Your Client Scalar Data Object</returns>
        public TResult GetScalarObject<TResult>(string clientKeyName, params object[] whereValues)
        {
            try
            {
                // Get Spring Object
                CXDMD00003 clientDataEntity = SpringApplicationContext.Instance.Resolve<CXDMD00003>(clientKeyName);
                //CXDMD00003 clientDataEntity = SpringApplicationContext.Instance.Resolve<CXDMD00003>("RemitBr.SelectDrawingAccountCode");

                Dictionary<string, object> parameters = null;

                string hqlString = this.GetSQLString(clientDataEntity.ORMObjectName, clientDataEntity.ORMProperties, clientDataEntity.DTOObjectName, clientDataEntity.WhereProperties, clientDataEntity.OrderByProperties, CXDMD00001.Select, whereValues, ref parameters);
                hqlString += hqlString.ToUpper().Contains("ACTIVE") || hqlString.ToUpper().Contains("ORDER") ? string.Empty : (hqlString.ToUpper().Contains("WHERE") ? " and Active=true " : " where Active=true ");
                
                this.query = this.Session.CreateQuery(hqlString);
                if (parameters != null)
                {
                    this.BuildParameterValue(parameters);
                }

                object temp = this.query.UniqueResult<TResult>();

                if (temp == null)
                    throw new Exception(CXMessage.ME00021);
                else
                    return (TResult)temp;

            }
            catch (Exception exp)
            {
               throw new Exception(exp.Message);
            }
            finally
            {
                if (this.Session.IsOpen)
                {
                    this.Session.Close();
                }
            }
        }

        /// <summary>
        /// Get Client List Data by Configuration Key Name
        /// </summary>
        /// <typeparam name="TResult">Your Client Data DTO Object</typeparam>
        /// <param name="clientKeyName">Client Data Configuration Key Name</param>
        /// <returns>Your Client List Data Object</returns>
        public IList<TResult> GetListObject<TResult>(string clientKeyName, params object[] whereValues)
        {
            try
            {
                // Get Spring Object
                CXDMD00003 clientDataEntity = SpringApplicationContext.Instance.Resolve<CXDMD00003>(clientKeyName);

                Dictionary<string, object> parameters = null;

                string hqlString = this.GetSQLString(clientDataEntity.ORMObjectName, clientDataEntity.ORMProperties, clientDataEntity.DTOObjectName, clientDataEntity.WhereProperties, clientDataEntity.OrderByProperties, CXDMD00001.Select, whereValues, ref parameters);
                hqlString += hqlString.ToUpper().Contains("ACTIVE") || hqlString.ToUpper().Contains("ORDER") ? string.Empty : (hqlString.ToUpper().Contains("WHERE") ? " and Active=true " : " where Active=true ");
                
                this.query = this.Session.CreateQuery(hqlString);

                if (parameters != null)
                {
                    this.BuildParameterValue(parameters);
                }

                object temp= this.query.List<TResult>();

                if (temp == null)
                    throw new Exception(CXMessage.ME00021);
                else
                    return (IList<TResult>)temp;

            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }
            finally
            {
                if (this.Session.IsOpen)
                {
                    this.Session.Close();
                }
            } 
        }

        public bool UpdateData(string counterId, IList<PFMDTO00031> updateList)
        {
            // Loop
            for (int i = 0; i < updateList.Count; i++)
            {
                switch (updateList[i].Status)
                {
                    case 1: // Insert
                        object insertValue = CXClientWrapper.Instance.Invoke<ICXSVE00001, object>(x => x.GetScalarObject(updateList[i].Id));

                        PFMDTO00030 cccDataVersion = new PFMDTO00030();
                        cccDataVersion.CounterId = counterId;
                        cccDataVersion.ServerVersionId = updateList[i].Id;
                        cccDataVersion.Active = true;
                        cccDataVersion.CreatedDate = DateTime.Now;
                        cccDataVersion.CreatedUserId = CurrentUserEntity.CurrentUserID;

                        this.Save(updateList[i].ORMName, insertValue, cccDataVersion);
                        break;

                    case 2: // Update
                        object updateValue = CXClientWrapper.Instance.Invoke<ICXSVE00001, object>(x => x.GetScalarObject(updateList[i].Id));
                        this.Update("", updateValue);
                        break;

                    case 3: // Delete
                        this.Delete("", updateList[i].DataIdName);
                        break;
                }
            }

            // Update the version after one version is finished


            return true;
        }
        #endregion

        #region Private Methods
        private void BuildParameterValue(Dictionary<string, object> parameters)
        {
            foreach (KeyValuePair<string, object> item in parameters)
            {
                if (item.Value is bool)
                {
                    this.query.SetBoolean(item.Key, Convert.ToBoolean(item.Value));
                }
                else
                {
                    this.query.SetParameter(item.Key, item.Value);
                }
            }
        }

        private string GetSQLString(string ormObjectName, string ormValueClause, string dtoObjectName, string whereClause, string orderbyClause, CXDMD00001 dataAction, object value, ref Dictionary<string, object> parameters)
        {
            string returnValue = string.Empty;
            string whereValue = string.Empty;
            string sqlFormat = string.Empty;    
            string[] valueItems = new string[]{};
            string[] whereItems = new string[]{};

            if (dataAction != CXDMD00001.Delete)
            {
                if (string.IsNullOrEmpty(ormValueClause))
                {
                    throw new Exception(CXMessage.ME90005);
                }
                else
                {
                    valueItems = ormValueClause.Split(',');

                    if (valueItems.Length <= 0)
                    {
                        throw new Exception(CXMessage.ME90006);
                    }
                }
            }

            if (!string.IsNullOrEmpty(whereClause))
            {
                whereItems = whereClause.Split(',');
            }

            switch (dataAction)
            {
                #region Update
                case CXDMD00001.Update:
                    sqlFormat = "Update {0} Set {1} {2}";

                    // Update Statement
                    returnValue = valueItems[0].Trim() + "=:" + valueItems[0].Trim();
                    parameters = new Dictionary<string, object>();
                    parameters.Add(valueItems[0].Trim(), this.GetParameterValue(value, valueItems[0].Trim()));

                    for (int i = 1; i < valueItems.Length; i++)
                    {
                        returnValue = ", " + valueItems[i].Trim() + "=:" + valueItems[i].Trim();
                        parameters.Add(valueItems[i].Trim(), this.GetParameterValue(value, valueItems[i].Trim()));
                    }

                    // Where Statemenet
                    if (whereItems.Length > 0)
                    {
                        object[] whereValues = (object[])value;
                        whereValue = "Where " + whereItems[0].Trim() + "=:" + whereItems[0].Trim();
                        parameters.Add(whereItems[0].Trim(), whereValues[0]);

                        for (int i = 1; i < whereItems.Length; i++)
                        {
                            whereValue += " And " + whereItems[i] + "=:" + whereItems[i].Trim();
                            parameters.Add(whereItems[i].Trim(), whereValues[i]);
                        }
                    }

                    returnValue = string.Format(sqlFormat, new object[] { ormObjectName, returnValue, whereValue });
                    break;
                #endregion

                #region Delete
                case CXDMD00001.Delete:
                    sqlFormat = "Delete From {0} {1}";

                    // Where Statemenet
                    if (whereItems.Length > 0)
                    {
                        parameters = new Dictionary<string, object>();

                        object[] whereValues = (object[])value;
                        whereValue = "Where " + whereItems[0].Trim() + "=:" + whereItems[0].Trim();
                        parameters.Add(whereItems[0].Trim(), whereValues[0]);

                        for (int i = 1; i < whereItems.Length; i++)
                        {
                            whereValue += " And " + whereItems[i] + "=:" + whereItems[i].Trim();
                            parameters.Add(whereItems[i].Trim(), whereValues[i]);
                        }
                    }

                    returnValue = string.Format(sqlFormat, new object[] { ormObjectName, whereValue });
                    break;
                #endregion

                #region Select
                case CXDMD00001.Select:
                    sqlFormat = "Select {0} From {1} {2} {3}";
                    string dtoString = "new {0}({1})";

                    if (value != null && whereItems.Length > 0)
                    {
                        parameters = new Dictionary<string, object>();

                        // Where Statemenet
                        object[] whereValues = (object[])value;
                        whereValue = "Where " + whereItems[0].Trim() + "=:" + whereItems[0].Trim();
                        parameters.Add(whereItems[0].Trim(), whereValues[0]);

                        for (int i = 1; i < whereItems.Length; i++)
                        {
                            whereValue += " And " + whereItems[i].Trim() + "=:" + whereItems[i].Trim();
                            parameters.Add(whereItems[i].Trim(), whereValues[i]);
                        }
                    }

                    if (string.IsNullOrEmpty(orderbyClause) == false)
                    {
                        orderbyClause = "order by " + orderbyClause;
                    }

                    if (string.IsNullOrEmpty(dtoObjectName))
                    {
                        returnValue = string.Format(sqlFormat, new object[] { ormValueClause, ormObjectName, whereValue, orderbyClause });
                    }
                    else
                    {
                        returnValue = string.Format(sqlFormat, new object[] { string.Format(dtoString, new object[] { dtoObjectName, ormValueClause }), ormObjectName, whereValue, orderbyClause });
                    }

                    break;
                #endregion
            }

            return returnValue;
        }

        private List<TResult> GetSelectObject<TResult>(string valueClause, string propertyClause, SQLiteDataReader reader)
        {
            string[] valueItems = valueClause.Split(',');
            string[] propertyItems = propertyClause.Split(',');

            if (propertyItems.Length == 0)
            {
                propertyItems = valueItems;
            }

            if (valueItems.Length != propertyItems.Length)
            {
                throw new Exception(CXMessage.ME90008);
            }

            List<TResult> valueList = Activator.CreateInstance<List<TResult>>();

            while (reader.Read())
            {
                TResult value = Activator.CreateInstance<TResult>();
                for (int i = 0; i < valueItems.Length; i++)
                {
                    string propertyName = propertyItems[i].Trim();

                    if (reader.IsDBNull(i) == false)
                    {
                        object propertyValue = reader[i];
                        value.GetType().GetProperty(propertyName).SetValue(value, propertyValue, System.Reflection.BindingFlags.SetProperty, null, null, null);
                    }
                }

                valueList.Add(value);
            }

            return valueList;
        }

        private object GetParameterValue(object value, string propertyName)
        {
            Type propertyType = value.GetType().GetProperty(propertyName).PropertyType;
            object propertyValue = value.GetType().GetProperty(propertyName).GetValue(value, null);
            object parameterValue = this.GetNull(propertyValue, propertyType);
            return parameterValue;
        }
                
        private DbType ToDbType(Type type)
        {
            if (type == typeof(string)) return DbType.String;
            if (type == typeof(UInt64)) return DbType.UInt64;
            if (type == typeof(Int64)) return DbType.Int64;
            if (type == typeof(Int32) || type == typeof(System.Nullable<int>)) return DbType.Int32;
            if (type == typeof(UInt32)) return DbType.UInt32;
            if (type == typeof(DateTime) || type == typeof(System.Nullable<DateTime>)) return DbType.DateTime;
            if (type == typeof(UInt16)) return DbType.UInt16;
            if (type == typeof(Int16)) return DbType.Int16;
            if (type == typeof(SByte)) return DbType.SByte;
            if (type == typeof(Object)) return DbType.Object;
            if (type == typeof(double)) return DbType.Double;
            if (type == typeof(byte[])) return DbType.Binary;
            if (type == typeof(decimal)) return DbType.Decimal;
            if (type == typeof(Guid)) return DbType.Guid;
            if (type == typeof(Boolean) || type == typeof(bool)) return DbType.Boolean;

            throw new Exception(CXMessage.ME90007);
        }

        /// <summary>
        /// Get an object's value or DBNull value
        /// </summary>
        /// <param name="obj">The Object</param>
        /// <returns>Object's value or DBNull value</returns>
        private object GetNull(object obj, Type propertyType)
        {
            // Check that object is "string" and object's value is empty string
            if ((obj is string) && (obj.ToString() == string.Empty))
            {
                // Specify DBNull value
                obj = DBNull.Value;
                return obj;
            }

            // Check that object is "DateTime" and object's value is minimum datetime value
            if ((obj is DateTime) && (((DateTime)obj) == DateTime.MinValue))
            {
                // Specify DBNull value
                obj = DBNull.Value;
                return obj;
            }

            // Check that object is "int" and object's value is minimum integer value
            if (((obj is int) && (((int)obj) == int.MinValue)) || (propertyType == typeof(Nullable<int>) && obj.Equals(0)))
            {
                // Specify DBNull value
                obj = DBNull.Value;
                return obj;
            }

            // Check that object is "float" and object's value is minimum float value
            if ((obj is float) && (((float)obj) == float.MinValue))
            {
                // Specify DBNull value
                obj = DBNull.Value;
                return obj;
            }

            // Check that object is "decimal" and object's value is minimum decimal value
            if ((obj is decimal) && (((decimal)obj) == decimal.MinValue))
            {
                // Specify DBNull value
                obj = DBNull.Value;
                return obj;
            }

            // Check that object is "double" and object's value is minimum double value
            if ((obj is double) && (((double)obj) == double.MinValue))
            {
                // Specify DBNull value
                obj = DBNull.Value;
            }

            return obj;
        }
        #endregion

        #region SSW

        public TResult GetClientData<TResult>(string clientKeyName, params object[] whereValues)
        {
            try
            {
                // Get Spring Object
                CXDMD00003 clientDataEntity = SpringApplicationContext.Instance.Resolve<CXDMD00003>(clientKeyName);

                Dictionary<string, object> parameters = null;

                string hqlString = this.BuildHQLQuery(clientDataEntity, CXDMD00001.Select, whereValues, ref parameters);
                this.query = this.Session.CreateQuery(hqlString);
                if (parameters != null)
                {
                    this.BuildParameterValue(parameters);
                }

                return this.query.UniqueResult<TResult>();
            }
            catch (Exception exp)
            {
                throw new Exception(CXMessage.ME90003, exp);
            }
            finally
            {
                if (this.Session.IsOpen)
                {
                    this.Session.Close();
                }
            }
        }
        public IList<TResult> GetClientDataList<TResult>(string clientKeyName, params object[] whereValues)
        {
            try
            {
                // Get Spring Object
                CXDMD00003 clientDataEntity = SpringApplicationContext.Instance.Resolve<CXDMD00003>(clientKeyName);

                Dictionary<string, object> parameters = null;

                string hqlString = this.BuildHQLQuery(clientDataEntity, CXDMD00001.Select, whereValues, ref parameters);                
                this.query = this.Session.CreateQuery(hqlString);
                if (parameters != null)
                {
                    this.BuildParameterValue(parameters);
                }

                return this.query.List<TResult>();
            }
            catch (Exception exp)
            {
                throw new Exception(CXMessage.ME90004, exp);
            }
            finally
            {
                if (this.Session.IsOpen)
                {
                    this.Session.Close();
                    
                }
                this.Session.Clear();
            }
        }
        //clientDataEntity.ORMObjectName, clientDataEntity.ORMProperties, clientDataEntity.DTOObjectName, clientDataEntity.WhereProperties, clientDataEntity.OrderByProperties
        //string ormObjectName,           string ormValueClause,          string dtoObjectName,           string whereClause,               string orderbyClause
        private string BuildHQLQuery(CXDMD00003 clientDataEntity, CXDMD00001 dataAction, object whereValues, ref Dictionary<string, object> parameters)
        {
            string returnValue = string.Empty;
            string whereCondiction = string.Empty;
            string sqlFormat = string.Empty;
            string[] valueItems = new string[] { };
            string[] whereItems = new string[] { };
            string[] logicalOperators = new string[] { };
            string[] comparisonOperator = new string[] { };
            if (dataAction != CXDMD00001.Delete)
            {
                if (string.IsNullOrEmpty(clientDataEntity.ORMProperties))
                {
                    throw new Exception(CXMessage.ME90005);
                }
                else
                {
                    valueItems = clientDataEntity.ORMProperties.Split(',');

                    if (valueItems.Length <= 0)
                    {
                        throw new Exception(CXMessage.ME90006);
                    }
                }
            }

            if (!string.IsNullOrEmpty(clientDataEntity.WhereProperties))
            {
                whereItems = clientDataEntity.WhereProperties.Split(',');
            }
            if (!string.IsNullOrEmpty(clientDataEntity.LogicalOperator))
            {
                logicalOperators = clientDataEntity.LogicalOperator.Split(',');
            }
            if (!string.IsNullOrEmpty(clientDataEntity.ComparisonOperator))
            {
                comparisonOperator = clientDataEntity.ComparisonOperator.Split(',');
            }
            switch (dataAction)
            {
                #region Update
                case CXDMD00001.Update:
                    sqlFormat = "Update {0} Set {1} {2}";

                    // Update Statement
                    returnValue = valueItems[0].Trim() + "=:" + valueItems[0].Trim();
                    parameters = new Dictionary<string, object>();
                    parameters.Add(valueItems[0].Trim(), this.GetParameterValue(whereValues, valueItems[0].Trim()));

                    for (int i = 1; i < valueItems.Length; i++)
                    {
                        returnValue = ", " + valueItems[i].Trim() + "=:" + valueItems[i].Trim();
                        parameters.Add(valueItems[i].Trim(), this.GetParameterValue(whereValues, valueItems[i].Trim()));
                    }

                    // Where Statemenet
                    if (whereItems.Length > 0)
                    {
                        object[] where_Values = (object[])whereValues;
                        whereCondiction = string.IsNullOrEmpty(clientDataEntity.ComparisonOperator) ? ("Where " + whereItems[0].Trim() + "=:" + whereItems[0].Trim()) :
                             ("Where " + whereItems[0].Trim() + comparisonOperator[0] + ":" + whereItems[0].Trim());
                        parameters.Add(whereItems[0].Trim(), where_Values[0]);

                        for (int i = 1; i < whereItems.Length; i++)
                        {
                            whereCondiction += string.IsNullOrEmpty(clientDataEntity.LogicalOperator) ? (" And " + whereItems[i].Trim()) :
                                (" " + logicalOperators[i - 1] + " " + whereItems[i].Trim());
                            whereCondiction += string.IsNullOrEmpty(clientDataEntity.ComparisonOperator) ? "=" : comparisonOperator[i];
                            whereCondiction += ":" + whereItems[i].Trim();
                            parameters.Add(whereItems[i].Trim(), where_Values[i]);
                        }
                    }

                    returnValue = string.Format(sqlFormat, new object[] { clientDataEntity.ORMObjectName, returnValue, whereCondiction });
                    break;
                #endregion

                #region Delete
                case CXDMD00001.Delete:
                    sqlFormat = "Delete From {0} {1}";

                    // Where Statemenet
                    if (whereItems.Length > 0)
                    {
                        parameters = new Dictionary<string, object>();

                        object[] where_Values = (object[])whereValues;
                        whereCondiction = string.IsNullOrEmpty(clientDataEntity.ComparisonOperator) ? ("Where " + whereItems[0].Trim() + "=:" + whereItems[0].Trim()) :
                            ("Where " + whereItems[0].Trim() + comparisonOperator[0] + ":" + whereItems[0].Trim());
                        parameters.Add(whereItems[0].Trim(), where_Values[0]);

                        for (int i = 1; i < whereItems.Length; i++)
                        {
                            whereCondiction += string.IsNullOrEmpty(clientDataEntity.LogicalOperator) ? (" And " + whereItems[i].Trim()) :
                                (" " + logicalOperators[i - 1] + " " + whereItems[i].Trim());
                            whereCondiction += string.IsNullOrEmpty(clientDataEntity.ComparisonOperator) ? "=" : comparisonOperator[i];
                            whereCondiction += ":" + whereItems[i].Trim();
                            parameters.Add(whereItems[i].Trim(), where_Values[i]);
                        }
                    }

                    returnValue = string.Format(sqlFormat, new object[] { clientDataEntity.ORMObjectName, whereCondiction });
                    break;
                #endregion

                #region Select
                case CXDMD00001.Select:
                    sqlFormat = "Select {0} From {1} {2} {3}";
                    string dtoString = "new {0}({1})";

                    if (whereValues != null && whereItems.Length > 0)
                    {
                        parameters = new Dictionary<string, object>();

                        // Where Statemenet
                        object[] where_Values = (object[])whereValues;
                        whereCondiction = string.IsNullOrEmpty(clientDataEntity.ComparisonOperator) ? ("Where " + whereItems[0].Trim() + "=:" + whereItems[0].Trim()) :
                            ("Where " + whereItems[0].Trim() + comparisonOperator[0] + ":" + whereItems[0].Trim());
                        parameters.Add(whereItems[0].Trim(), where_Values[0]);

                        for (int i = 1; i < whereItems.Length; i++)
                        {
                            whereCondiction += string.IsNullOrEmpty(clientDataEntity.LogicalOperator) ? (" And " + whereItems[i].Trim()) :
                                (" " + logicalOperators[i - 1] + " " + whereItems[i].Trim());
                            whereCondiction += string.IsNullOrEmpty(clientDataEntity.ComparisonOperator) ? "=" : comparisonOperator[i];
                            whereCondiction += ":" + whereItems[i].Trim();
                            parameters.Add(whereItems[i].Trim(), where_Values[i]);
                        }
                    }

                    if (string.IsNullOrEmpty(clientDataEntity.OrderByProperties) == false)
                    {
                        clientDataEntity.OrderByProperties = "order by " + clientDataEntity.OrderByProperties;
                    }

                    if (string.IsNullOrEmpty(clientDataEntity.DTOObjectName))
                    {
                        returnValue = string.Format(sqlFormat, new object[] { clientDataEntity.ORMProperties, clientDataEntity.ORMObjectName, whereCondiction, clientDataEntity.OrderByProperties });
                    }
                    else
                    {
                        returnValue = string.Format(sqlFormat, new object[] { string.Format(dtoString, new object[] { clientDataEntity.DTOObjectName, clientDataEntity.ORMProperties }), clientDataEntity.ORMObjectName, whereCondiction, clientDataEntity.OrderByProperties });
                    }

                    break;
                #endregion
            }

            return returnValue;
        }

        public TResult GetObjectByCustomHQL<TResult>(string customHQL, Dictionary<string, object> whereValues)
        {
            try
            {
                this.query = this.Session.GetNamedQuery(customHQL);
                if (whereValues != null)
                {
                    this.BuildParameterValue(whereValues);
                }

                return this.query.UniqueResult<TResult>();
            }
            catch (Exception exp)
            {
                throw new Exception(CXMessage.ME90003, exp);
            }
            finally
            {
                if (this.Session.IsOpen)
                {
                    this.Session.Close();
                }
            }
        }

        public IList<TResult> GetListByCustomHQL<TResult>(string customHQL, Dictionary<string, object> whereValues)
        {
            try
            {
                this.query = this.Session.GetNamedQuery(customHQL);

                if (whereValues != null)
                {
                    this.BuildParameterValue(whereValues);
                }

                return this.query.List<TResult>();
            }
            catch (Exception exp)
            {
                throw new Exception(CXMessage.ME90004, exp);
            }
            finally
            {
                if (this.Session.IsOpen)
                {
                    this.Session.Close();
                }
            }
        }

        public decimal GetDenoAmount(string denoDetail, string cur)
        {
            if (denoDetail == null || denoDetail == "" || denoDetail == "0")
                return 0;

            decimal denoAmount = 0;
            
            IList<TLMDTO00012> denoList = new List<TLMDTO00012>();
            string[] denoDetailArr = denoDetail.Split("*".ToCharArray());

            Dictionary<string, int> denoDict = new Dictionary<string, int>();
            for (int i = 0; i < denoDetailArr.Length; i++)
            {
                string[] eachDeno = denoDetailArr[i].Split(":".ToCharArray());
                denoDict.Add(eachDeno[0], Convert.ToInt32(eachDeno[1]));
            }
            IList<string> symbols = denoDict.Keys.ToList();

            IQuery query = this.Session.GetNamedQuery("TLMDAO00012.SelectBySymbol");
            query.SetParameterList("symbols", symbols);
            query.SetString("currency", cur);
            denoList = query.List<TLMDTO00012>();

            foreach (TLMDTO00012 deno in denoList)
            {
                decimal d1 = Convert.ToInt32(deno.D1);
                decimal multiplier = Convert.ToDecimal(denoDict[deno.Symbol]);
                denoAmount += d1 * multiplier;
            }
            

            return denoAmount;
        }

        #endregion
    }
}
