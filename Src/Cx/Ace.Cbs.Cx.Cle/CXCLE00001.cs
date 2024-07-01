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

namespace Ace.Cbs.Cx.Cle
{
    /// <summary>
    /// Insert, Update, Delete and Search client data from SQLite database
    /// by xml configuration file (appclientdata.xml).
    /// </summary>
    public class CXCLE00001 : HibernateDaoSupport
    {
        #region Private Variables
        private static CXCLE00001 instance = null;
        private IQuery query = null;
        #endregion

        #region Properties
        /// <summary>
        /// CXClientData Singleton Object
        /// </summary>
        public static CXCLE00001 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = SpringApplicationContext.Instance.Resolve<CXCLE00001>("CXClientDataCustomQueryHandler");
                }

                return instance;
            }
        }
        #endregion

        #region DAO
        
        public decimal SelectBranchKey(string branchKey)
        {
            try
            {
                this.query = this.Session.GetNamedQuery("CXCLE00001.SelectBranchKey");
                this.query.SetString("Code", branchKey);
                this.query.SetString("todaydate",(DateTime.Now.ToString("yyyy/MM/dd")));
               
                TLMDTO00037 entity = this.query.SetFirstResult(0).SetMaxResults(1).UniqueResult<TLMDTO00037>();
                //return entity.Value.HasValue ? entity.Value.Value : 0;
                return entity.Value;
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

        public decimal SelectDayKey(string dayKey)
        {
            try
            {
                this.query = this.Session.GetNamedQuery("CXCLE00001.SelectDayKey");
                this.query.SetString("Code", dayKey);
                this.query.SetString("todaydate", DateTime.Now.ToString("yyyy/MM/dd"));
               
                TLMDTO00034 entity = this.query.SetFirstResult(0).SetMaxResults(1).UniqueResult<TLMDTO00034>();
                return entity.Value.HasValue ? entity.Value.Value : 0;
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

        public decimal SelectMonthKey(string monthKey)
        {
            try
            {
                this.query = this.Session.GetNamedQuery("CXCLE00001.SelectMonthKey");
                this.query.SetString("Code", monthKey);
                this.query.SetString("todaydate", DateTime.Now.ToString("yyyy/MM/dd"));

                TLMDTO00035 entity = this.query.SetFirstResult(0).SetMaxResults(1).UniqueResult<TLMDTO00035>();
                //return entity.Value.HasValue ? entity.Value.Value : 0;
                
                return entity.Value;
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
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              
        public decimal SelectAmountKey(decimal amountKey)
        {
            try
            {
                this.query = this.Session.GetNamedQuery("CXCLE00001.SelectAmountKey");
                this.query.SetInt32("Code", Convert.ToInt32(amountKey));
                this.query.SetString("todaydate", DateTime.Now.ToString("yyyy/MM/dd"));
                IList<TLMDTO00036> hhlist = query.List<TLMDTO00036>();
                TLMDTO00036 entity = this.query.SetFirstResult(0).SetMaxResults(1).UniqueResult<TLMDTO00036>();
                //return entity.Value.HasValue ? entity.Value.Value : 0;
                return entity.Value;
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
                
        public string GetCOAAccountNameByCoaSetupAccountNo(string aCode, string sourceBranchCode)//Add by hmw
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("CXCLE00001.SelectCOAAccountNameByCoaSetupAccountNo");
                query.SetString("aCode", aCode);
                query.SetString("sourceBranchCode", sourceBranchCode);

                object description = query.UniqueResult();

                if (description == null)
                {
                    return null;
                }

                return description.ToString();
                
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
        public ChargeOfAccountDTO SelectCoaAccountNameCoaSetupAccountNameByAcode(string acode, string sourceBranchCode, string currencyCode)
        {
            IQuery query = this.Session.GetNamedQuery("COA.SelectCoaAccountNameCoaSetupAccountNameByAcode");
            query.SetString("acode", acode);
            this.query.SetString("currencyCode", currencyCode);
            this.query.SetString("sourceBranchCode", sourceBranchCode);
            return query.UniqueResult<ChargeOfAccountDTO>();

        }

        public IList<ChargeOfAccountDTO> COASelectAccountNoAndAccountName(string sourceBankAccountName, string otherBankAccountName,string currency,string sourceBranchCode)
        {
            this.query = this.Session.GetNamedQuery("COA.SelectAccountNoAndAccountName");
            this.query.SetString("sourceBankAccountName", sourceBankAccountName);
            this.query.SetString("otherBankAccountName", otherBankAccountName);
            this.query.SetString("currency", currency);
            this.query.SetString("sourceBranchCode", sourceBranchCode);
            return this.query.List<ChargeOfAccountDTO>();
        }

        public IList<BranchDTO> SelectAllBranch()
        {
            IQuery query = this.Session.GetNamedQuery("BranchCode.SelectAllBranch");

            IList<BranchDTO> branchList = query.List<BranchDTO>();
            return branchList; 
        }

        public IList<BranchDTO> SelectAllOtherBranchBySourceBranch(string sourcebranchCode)
        {
            IQuery query = this.Session.GetNamedQuery("BranchCodeAndBranchDesp.SelectAllOthersBranch");
            query.SetString("sourcebranchcode", sourcebranchCode);
            IList<BranchDTO> branchList = query.List<BranchDTO>();
            return branchList;

        }

        public IList<BranchDTO> SelectAllBranchesBySourceBranch(string sourcebranchCode)
        {
            IQuery query = this.Session.GetNamedQuery("BranchCodeAndBranchDesp.SelectAllBranches");
            query.SetString("sourcebranchcode", sourcebranchCode);
            IList<BranchDTO> branchList = query.List<BranchDTO>();
            return branchList;

        }

        public ChargeOfAccountDTO SelectCOADescription(string aCode, string sourceBranchCode)
        {
            this.query = this.Session.GetNamedQuery("COA.Client.SelectAccountDescription");
                this.query.SetString("aCode", aCode);
                this.query.SetString("sourceBranchCode", sourceBranchCode);

                ChargeOfAccountDTO acName = query.UniqueResult<ChargeOfAccountDTO>();
                return acName;
        }

        public string SelectNewSetUpValueByVariable(string variable)
        {
            this.query = this.Session.GetNamedQuery("SelectNewSetUpValueByVariable");
            this.query.SetString("variable", variable);

            PFMDTO00057 newsetupDTO = query.UniqueResult<PFMDTO00057>();

            string value = newsetupDTO.Value;
            return value;

        }

        public ChargeOfAccountDTO SelectACode(string acname)
        {

            this.query = this.Session.GetNamedQuery("CXCLE00001.SelectACode");
            this.query.SetString("accountName", acname);

            ChargeOfAccountDTO coaDTO = this.query.SetFirstResult(0).SetMaxResults(1).UniqueResult<ChargeOfAccountDTO>();
            return coaDTO;
        }

        public IList<ChargeOfAccountDTO> GetACodeForFormatFileEntry()
        {
            this.query = this.Session.GetNamedQuery("CXCLE00001.SelectACodeForFormatFileEntry");            
            return this.query.List<ChargeOfAccountDTO>();            
        }

        
        public IList<ChargeOfAccountDTO> COA_RangeofAccount()
        {
            this.query = this.Session.GetNamedQuery("COA_RangeofAccount");

            IList<ChargeOfAccountDTO> coaDTO = query.List<ChargeOfAccountDTO>();
            return coaDTO;
        }

        public IList<ChargeOfAccountDTO> COA_RangeofAccountbyACode(string fromACode, string toACode)
        {
            this.query = this.Session.GetNamedQuery("COA_RangeofAccountbyACode");
            query.SetString("fromAcode", fromACode);
            query.SetString("toAcode", toACode);           
            IList<ChargeOfAccountDTO> coaDTO = query.List<ChargeOfAccountDTO>();
            return coaDTO;
        }        

        public IList<BranchDTO> BranchSelectedForOnlineActiveTransactionListing(string sourceBranchCode)
        {
            this.query = this.Session.GetNamedQuery("Branch.BranchSelectedForOnlineActiveTransactionListing");            
            this.query.SetString("sourceBranchCode", sourceBranchCode);
            return query.List<BranchDTO>();
         
        }
        #endregion

        #region Select All & Select By Id Client Data
        public IList<PFMDTO00022> SelectAllSubAccountType()
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("SubAccountTypeDAO.SelectAll");
                IList<PFMDTO00022> list = query.List<PFMDTO00022>();
                return list;
            }
            catch
            { return null; }
        }

        public PFMDTO00022 SelectByIdSubAccountType(int id)
        {
            IQuery query = this.Session.GetNamedQuery("SubAccountTypeDAO.SelectById");
            query.SetInt32("id", id);
            return query.UniqueResult<PFMDTO00022>();
        }

        public IList<TLMDTO00030> SelectListById(int id)
        {
            IQuery query = this.Session.GetNamedQuery("SubAccountTypeDAO.SelectById");
            query.SetInt32("RemitbrIblID", id);
            return query.List<TLMDTO00030>();
        }
        #endregion
    }
}
