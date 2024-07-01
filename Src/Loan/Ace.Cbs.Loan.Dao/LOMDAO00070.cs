using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Dao;
using NHibernate;

namespace Ace.Cbs.Loan.Dao
{
    public class LOMDAO00070 : DataRepository<LOMORM00070>, ILOMDAO00070
    {
        public IList<LOMDTO00070> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("VillageGroupDAO.SelectAll");
            return query.List<LOMDTO00070>();
        }

        public IList<LOMDTO00070> CheckExist2(string villageCode, string desp)
        {
            IQuery query = this.Session.GetNamedQuery("VillageGroupDAO.CheckExist2");
            query.SetString("villageCode", villageCode);
            query.SetString("desp", desp);
            IList<LOMDTO00070> villageGroupList = query.List<LOMDTO00070>();
            return villageGroupList;
        }

        public bool CheckExist(string villageCode, string desp, bool isEdit)
        {
            IQuery query = this.Session.GetNamedQuery("VillageGroupDAO.CheckExist");
            query.SetString("villageCode", villageCode);
            query.SetString("desp", desp);
            IList<LOMDTO00070> villageGroupList = query.List<LOMDTO00070>();

            return villageGroupList.Count == null ? false : this.CheckDTOList(villageGroupList, villageCode, isEdit);
        }

        public bool CheckDTOList(IList<LOMDTO00070> villageGroupList, string villageCode, bool isEdit)
        {
            foreach (LOMDTO00070 villageGroupDto in villageGroupList)
            {
                if (villageGroupDto.VillageCode != villageCode && isEdit)
                    return true;

                else if (!isEdit)
                    return true;
            }
            return false;
        }
    }
}
