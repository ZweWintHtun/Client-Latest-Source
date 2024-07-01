using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;

namespace Ace.Cbs.Loan.Dao
{
    public class LOMDAO00071 : DataRepository<LOMORM00071>,ILOMDAO00071
    {
        public bool CheckExist(string seasonCode, string description, bool isEdit)
        {
            IQuery query = this.Session.GetNamedQuery("SeasonCodeDAO.CheckExist");
            query.SetString("code", seasonCode);
            query.SetString("description", description);
            IList<LOMDTO00071> seasonCodeList = query.List<LOMDTO00071>();

            return seasonCodeList.Count == null ? false : this.CheckDTOList(seasonCodeList, seasonCode, isEdit);
        }

        public IList<LOMDTO00071> CheckExist2(string seasonCode, string description)
        {
            IQuery query = this.Session.GetNamedQuery("SeasonCodeDAO.CheckExist2");
            query.SetString("code", seasonCode);
            query.SetString("description", description);
            IList<LOMDTO00071> advanceList = query.List<LOMDTO00071>();
            return advanceList;
        }

        public IList<LOMDTO00071> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("SeasonCodeDAO.SelectAll");
            return query.List<LOMDTO00071>();
        }

        public LOMDTO00071 SelectBySeasonCode(string seasonCode)
        {
            IQuery query = this.Session.GetNamedQuery("SeasonCodeDAO.SelectBySeasonCode");
            query.SetString("code", seasonCode);
            return query.UniqueResult<LOMDTO00071>();
        }

        public bool CheckDTOList(IList<LOMDTO00071> advanceList, string seasonCode, bool isEdit)
        {
            foreach (LOMDTO00071 seasonCodeDto in advanceList)
            {
                if (seasonCodeDto.Code != seasonCode && isEdit)
                    return true;

                else if (!isEdit)
                    return true;
            }
            return false;
        }

    }
}

