using System.Collections.Generic;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;

namespace Ace.Cbs.Pfm.Dao
{
    public class PFMDAO00004 : DataRepository<PFMORM00004>, IPFMDAO00004
    {
        public bool CheckExist(string occupationCode, string desp, bool isEdit)
        {
            IQuery query = this.Session.GetNamedQuery("OccupationCodeDAO.CheckExist");
            query.SetString("occupationCode", occupationCode);
            query.SetString("desp", desp);
            IList<PFMDTO00004> OccupationCodeList = query.List<PFMDTO00004>();
            return OccupationCodeList == null ? false : this.CheckDTOList(OccupationCodeList, occupationCode, isEdit);
        }

        public IList<PFMDTO00004> CheckExist2(string occupationCode, string desp)
        {
            IQuery query = this.Session.GetNamedQuery("OccupationCodeDAO.CheckExist2");
            query.SetString("occupationCode", occupationCode);
            query.SetString("desp", desp);
            IList<PFMDTO00004> OccupationCodeList = query.List<PFMDTO00004>();
            return OccupationCodeList;
        }

        public IList<PFMDTO00004> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("OccupationCodeDAO.SelectAll");
            return query.List<PFMDTO00004>();
        }

        public PFMDTO00004 SelectByOccupationCode(string occupationCode)
        {
            IQuery query = this.Session.GetNamedQuery("OccupationCodeDAO.SelectByOccupationCode");
            query.SetString("occupationCode", occupationCode);
            return query.UniqueResult<PFMDTO00004>();
        }

        private bool CheckDTOList(IList<PFMDTO00004> occupationCodeList, string occupationCode, bool isEdit)
        {
            foreach (PFMDTO00004 info in occupationCodeList)
            {
                if (info.Occupation_Code != occupationCode && isEdit)
                    return true;
                else if (!isEdit)
                    return true;
            }
            return false;
        }
    }
}