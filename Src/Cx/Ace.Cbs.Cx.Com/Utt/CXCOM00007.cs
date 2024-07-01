using System;
using Ace.Windows.Core.Utt;
using NHibernate;
using Spring.Data.NHibernate.Support;
using Ace.Cbs.Cx.Com.Utt;
using System.Configuration;

namespace Ace.Cbs.Cx.Com.Utt
{
    //AppClient Data Read
    /// <summary>
    /// Insert, Update, Delete and Search Application Settings data from SQLite database
    /// To read server appSettings 
    /// </summary>
    public class CXCOM00007 : ClientDataHandler
    {
        #region Private Variables
        private static CXCOM00007 instance = null;
        #endregion

        #region Properties
        /// <summary>
        /// CXCOM00007 Instance Object
        /// </summary>
        public new static CXCOM00007 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = SpringApplicationContext.Instance.Resolve<CXCOM00007>("CXCOM00007");
                }

                return instance;
            }
        }
        #endregion

        public string BranchCode
        {
            get
            {
                return CurrentUserEntity.BranchCode;
            }
        }

        public string GetSQLString(string hqlString)
        {
            var session = (NHibernate.Engine.ISessionImplementor)this.Session;
            var sf = (NHibernate.Engine.ISessionFactoryImplementor)this.Session.SessionFactory;

            NHibernate.Engine.Query.HQLStringQueryPlan sql = new NHibernate.Engine.Query.HQLStringQueryPlan(hqlString, true, session.EnabledFilters, sf);

            return string.Join(";", sql.SqlStrings);
        }

        #region Public Methods
        /// <summary>
        /// Get Application Settings Value by Key Name
        /// </summary>
        /// <param name="keyName">Your Key Name</param>
        /// <returns>Application Settings Value</returns>
        public string GetValueByKeyName(string keyName)
        {
            try
            {
                IQuery query = this.Session.CreateQuery("select KeyValue from PFMORM00053 where KeyName = :keyName");

                query.SetString("keyName", keyName);
                object result = query.UniqueResult();

                if (result == null)
                {
                    return string.Empty;
                }

                return result.ToString();
            }
            catch (Exception exp)
            {
                throw new Exception(CXMessage.ME90013, exp);
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
        /// Get NewSetup Value by Variable
        /// </summary>
        /// <param name="keyName">Your Variable Name</param>
        /// <returns>NewSetup Value</returns>
        public string GetValueByVariable(string variable)
        {
            try
            {
                IQuery query = this.Session.CreateQuery("select Value from PFMORM00057 where Variable = :variable");
                string sql = this.GetSQLString(query.QueryString);
                query.SetString("variable", variable);
                object result = query.UniqueResult();

                if (result == null)
                {
                    return string.Empty;
                }

                return result.ToString();
            }
            catch (Exception exp)
            {
                throw new Exception(CXMessage.ME90013, exp);
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
    }
}
