using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;
using NHibernate;
using Spring.Data.NHibernate.Support;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Cx.Com.Utt
{
    /// <summary>
    /// Insert, Update, Delete and Search client data from SQLite database
    /// by xml configuration file (appserverdata.xml).
    /// </summary>
    public class CXCOM00012 : HibernateDaoSupport
    {
        #region Private Variables
        private static CXCOM00012 instance = null;
        private IQuery query = null;
        #endregion

        #region Properties        
        public static CXCOM00012 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = SpringApplicationContext.Instance.Resolve<CXCOM00012>("CXCOM00012");
                }

                return instance;
            }
        }
        #endregion

        #region DAO

        public ChargeOfAccountDTO SelectCOAByCoaSetupAccountName(string accountName, string currencyCode, string sourceBranchCode)
        {
            try
            {
                this.query = this.Session.GetNamedQuery("CXCLE00001.SelectCOAByCoaSetupAccountName");
                this.query.SetString("accountName", accountName);
                this.query.SetString("currency", currencyCode);
                this.query.SetString("sourceBranchCode", sourceBranchCode);
                return query.UniqueResult<ChargeOfAccountDTO>();
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

        public IList<ChargeOfAccountDTO> SelectCOAAccountNameByACTypeL()
        {
            IQuery query = this.Session.GetNamedQuery("CXCOM00001.SelectCOAAccountNameByACTypeL");

            IList<ChargeOfAccountDTO> coaDTO = query.List<ChargeOfAccountDTO>();
            return coaDTO;
        }

        public IList<ChargeOfAccountDTO> SelectCOAAccountNameByACode(string acode)
        {

            IQuery query = this.Session.GetNamedQuery("CXCOM00001.SelectCOAAccountNameByACode");
            query.SetString("acode", acode);

            IList<ChargeOfAccountDTO> coaDTO = query.List<ChargeOfAccountDTO>();
            return coaDTO;
        }
       
        #endregion
    }
}
