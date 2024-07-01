using System.Collections.Generic;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;

namespace Ace.Cbs.Pfm.Dao
{
    public class PFMDAO00022 : DataRepository<PFMORM00022>, IPFMDAO00022
    {
        public bool CheckExist(int id, string code, string description)
        {
            IQuery query = this.Session.GetNamedQuery("SubAccountTypeDAO.CheckExist");
            query.SetString("code", code);
            query.SetString("description", description);
            IList<PFMDTO00022> subaccountType = query.List<PFMDTO00022>();
            return subaccountType.Count == 0 ? false : this.CheckList(subaccountType, id, code, description);
        }

        public bool CheckList(IList<PFMDTO00022> subaccountType, int id, string code, string description)
        {
            foreach (PFMDTO00022 accountType in subaccountType)
            {
                if (accountType.Id == id)
                {

                    for (int i = 0; i < subaccountType.Count; i++)
                    {
                        if ((accountType.Id != subaccountType[i].Id) && (subaccountType[i].Code == code && subaccountType[i].Description == description))
                        {
                            return true;
                        }
                    }
                    return false;
                }

            }
            return true;
        }

        public IList<PFMDTO00022> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("SubAccountTypeDAO.SelectAll");
            return query.List<PFMDTO00022>();
        }

        public PFMDTO00022 SelectById(int id)
        {
            IQuery query = this.Session.GetNamedQuery("SubAccountTypeDAO.SelectById");
            query.SetInt32("id", id);
            return query.UniqueResult<PFMDTO00022>();
        }

        public PFMDTO00022 SelectByCodeAndAcTypeId(string code, int acTypeId)
        {
            IQuery query = this.Session.GetNamedQuery("SubAccountTypeDAO.SelectByCodeAndAccountTypeId");
            query.SetString("code", code);
            query.SetInt32("acTypeId", acTypeId);
            return query.UniqueResult<PFMDTO00022>();
        }
    }
}