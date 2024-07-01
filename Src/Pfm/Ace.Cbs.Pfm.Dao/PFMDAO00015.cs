using System.Collections.Generic;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
namespace Ace.Cbs.Pfm.Dao
{
    public class PFMDAO00015 : DataRepository<PFMORM00015>, IPFMDAO00015
    {
        public bool CheckExist(int id, string code, string description, string symbol)
        {
            IQuery query = this.Session.GetNamedQuery("AccountTypeDAO.CheckExist");
            query.SetString("code", code);
            query.SetString("description", description);
            query.SetString("symbol", symbol);
            IList<PFMDTO00015> accountTypes = query.List<PFMDTO00015>();
            return accountTypes.Count == 0 ? false : this.CheckList(accountTypes, id, code, description, symbol);
        }

        public bool CheckList(IList<PFMDTO00015> accountTypes, int id, string code, string description, string symbol)
        {
            foreach (PFMDTO00015 accountType in accountTypes)
            {
                if (accountType.Id == id)
                {

                    for (int i = 0; i < accountTypes.Count; i++)
                    {
                        if ((accountType.Id != accountTypes[i].Id) && (accountTypes[i].Code == code || accountTypes[i].Description == description || accountTypes[i].Symbol == symbol))
                        {
                            return true;
                        }
                    }
                    return false;
                }

            }
            return true;
        }

        public IList<PFMDTO00015> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("AccountTypeDAO.SelectAll");
            return query.List<PFMDTO00015>();
        }

        public PFMDTO00015 SelectById(int id)
        {
            IQuery query = this.Session.GetNamedQuery("AccountTypeDAO.SelectById");
            query.SetInt32("id", id);
            return query.UniqueResult<PFMDTO00015>();
        }

        public PFMDTO00015 SelectByCode(string code)
        {
            IQuery query = this.Session.GetNamedQuery("AccountTypeDAO.SelectByCode");
            query.SetString("code", code);
            return query.UniqueResult<PFMDTO00015>();
        }
    }
}