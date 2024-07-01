//----------------------------------------------------------------------
// <copyright file="CXSVE00010.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>AK</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.Core.Utt;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using NHibernate;
using Spring.Data.NHibernate.Support;

namespace Ace.Cbs.Cx.Com.Utt
{
    public class CXCOM00011 : HibernateDaoSupport
    {
        #region Private Variables
        private static CXCOM00011 instance = null;
        private IQuery query = null;
        #endregion

        #region Properties
        /// <summary>
        /// CXCOM00011 Instance Object
        /// </summary>
        public static CXCOM00011 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = SpringApplicationContext.Instance.Resolve<CXCOM00011>("CXCOM00011");
                }

                return instance;
            }
        }
        #endregion

        #region Public Methods

        public string GetSQLString(string hqlString)
        {
            var session = (NHibernate.Engine.ISessionImplementor)this.Session;
            var sf = (NHibernate.Engine.ISessionFactoryImplementor)this.Session.SessionFactory;

            NHibernate.Engine.Query.HQLStringQueryPlan sql = new NHibernate.Engine.Query.HQLStringQueryPlan(hqlString, true, session.EnabledFilters, sf);

            return string.Join(";", sql.SqlStrings);
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

                Dictionary<string, object> parameters = null;

                string hqlString = this.GetSQLString(clientDataEntity.ORMObjectName, clientDataEntity.ORMProperties, clientDataEntity.DTOObjectName, clientDataEntity.WhereProperties, clientDataEntity.OrderByProperties, CXDMD00001.Select, whereValues, ref parameters);
                hqlString += hqlString.ToUpper().Contains("ACTIVE") || hqlString.ToUpper().Contains("ORDER") ? string.Empty : " and Active=true ";

                this.query = this.Session.CreateQuery(hqlString);
                if (parameters != null)
                {
                    this.BuildParameterValue(parameters);
                }
                string sqlQuery = this.GetSQLString(query.QueryString);
                
                object temp = this.query.UniqueResult<TResult>();

                if (temp == null)
                    throw new Exception(CXMessage.ME00021);
                else
                    return (TResult)temp;
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

        #endregion

        #region private Methods

        private void BuildParameterValue(Dictionary<string, object> parameters)
        {
            foreach (KeyValuePair<string, object> item in parameters)
            {
                if (item.Value is bool)
                {
                    this.query.SetBoolean(item.Key, Convert.ToBoolean(item.Value));
                }
                else if (item.Value is DateTime)
                {
                    this.query.SetDateTime(item.Key, Convert.ToDateTime(item.Value));
                }
                else if (item.Value is int)
                {
                    this.query.SetInt32(item.Key, Convert.ToInt32(item.Value));
                }
                //else if (item.Value is string)
                //{
                //    this.query.SetString(item.Key, Convert.ToString(item.Value));
                //}
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
            string[] valueItems = new string[] { };
            string[] whereItems = new string[] { };

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

        private object GetParameterValue(object value, string propertyName)
        {
            Type propertyType = value.GetType().GetProperty(propertyName).PropertyType;
            object propertyValue = value.GetType().GetProperty(propertyName).GetValue(value, null);
            object parameterValue = this.GetNull(propertyValue, propertyType);
            return parameterValue;
        }

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

    }
}
