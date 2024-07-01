using System.Collections.Generic;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;

namespace Ace.Cbs.Pfm.Dao
{
    public class PFMDAO00007 : DataRepository<PFMORM00007>, IPFMDAO00007
    {
        public bool CheckExist(int id, decimal duration, string desc, decimal rate)
        {
            IQuery query = this.Session.GetNamedQuery("FixRateDAO.CheckExist");
            query.SetDecimal("duration", duration);
            query.SetString("desc", desc);
            //query.SetDecimal("rate", rate);
            IList<PFMDTO00007> FixRates = query.List<PFMDTO00007>();
            return FixRates.Count == 0 ? false : this.CheckList(FixRates, id, duration, desc);
            //return FixRates.Count == 0 ? false : this.CheckList(FixRates, id, duration, desc, rate);
        }
        //public bool CheckList(IList<PFMDTO00007> fixRates, int id, decimal duration, string desc, decimal rate)
        public bool CheckList(IList<PFMDTO00007> fixRates, int id, decimal duration, string desc)
        {
            foreach (PFMDTO00007 fixRate in fixRates)
            {
                if (fixRate.Id == id)
                {
                    for (int i = 0; i < fixRates.Count; i++)
                    {                        
                        
                        //if ((fixRate.Id != fixRates[i].Id) && (fixRates[i].Duration == duration || fixRates[i].Description == desc || fixRates[i].Rate == rate))
                        if ((fixRate.Id != fixRates[i].Id) && (fixRates[i].Duration == duration || fixRates[i].Description == desc))
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
            return true;
        }

        public IList<PFMDTO00007> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("FixRateDAO.SelectAll");
            return query.List<PFMDTO00007>();
        }

        public PFMDTO00007 SelectById(int id)
        {
            IQuery query = this.Session.GetNamedQuery("FixRateDAO.SelectById");
            query.SetInt32("id", id);
            return query.UniqueResult<PFMDTO00007>();
        }


        public PFMDTO00007 SelectFixRateDescription(decimal duration)
        {
            IQuery query = this.Session.GetNamedQuery("FixRateDAO.SelectDescription");
            query.SetDecimal("duration", duration);
            return query.UniqueResult<PFMDTO00007>();
          
        }
    }
}