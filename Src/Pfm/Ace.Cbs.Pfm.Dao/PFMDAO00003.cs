using System.Collections.Generic;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;

namespace Ace.Cbs.Pfm.Dao
{
    public class PFMDAO00003 : DataRepository<PFMORM00003>, IPFMDAO00003
    {
        public bool CheckExist(string initial, string description, bool isEdit)
        {
            IQuery query = this.Session.GetNamedQuery("InitialDAO.CheckExist");
            query.SetString("initial", initial);
            query.SetString("description", description);
            IList<PFMDTO00003> InitialList = query.List<PFMDTO00003>();
            return InitialList == null ? false : this.CheckDTOList(InitialList, initial, isEdit);
        }

  public IList<PFMDTO00003> CheckExist2(string initial, string description)
        {
            IQuery query = this.Session.GetNamedQuery("InitialDAO.CheckExist2");
            query.SetString("initial", initial);
            query.SetString("description", description);
            IList<PFMDTO00003> InitialList = query.List<PFMDTO00003>();
            return InitialList;
        }
        public IList<PFMDTO00003> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("InitialDAO.SelectAll");
            IList<PFMDTO00003> res = query.List<PFMDTO00003>();
            return res;
            //return query.List<PFMDTO00003>();
        }

        public PFMDTO00003 SelectByInitial(string initial)
        {
            IQuery query = this.Session.GetNamedQuery("InitialDAO.SelectByInitial");
            query.SetString("initial", initial);
            return query.UniqueResult<PFMDTO00003>();
        }

        private bool CheckDTOList(IList<PFMDTO00003> initialList, string initial, bool isEdit)
        {
            foreach (PFMDTO00003 info in initialList)
            {
                if (info.Initial != initial && isEdit)
                    return true;
                else if (!isEdit)
                    return true;
            }
            return false;
        }
    }
}