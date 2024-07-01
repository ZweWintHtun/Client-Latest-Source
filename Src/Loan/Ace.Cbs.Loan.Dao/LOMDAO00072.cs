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
    public class LOMDAO00072 : DataRepository<LOMORM00072>, ILOMDAO00072
    {
        public IList<LOMDTO00072> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("CropTypeDAO.SelectAll");
            return query.List<LOMDTO00072>();
        }

        public IList<LOMDTO00072> CheckExist2(string cropCode, string desp)
        {
            IQuery query = this.Session.GetNamedQuery("CropTypeDAO.CheckExist2");
            query.SetString("cropCode", cropCode);
            query.SetString("desp", desp);
            IList<LOMDTO00072> cropTypeList = query.List<LOMDTO00072>();
            return cropTypeList;
        }

        public bool CheckExist(string cropCode, string desp, bool isEdit)
        {
            IQuery query = this.Session.GetNamedQuery("CropTypeDAO.CheckExist");
            query.SetString("cropCode", cropCode);
            query.SetString("desp", desp);
            IList<LOMDTO00072> cropTypeList = query.List<LOMDTO00072>();

            return cropTypeList.Count == null ? false : this.CheckDTOList(cropTypeList, cropCode, isEdit);
        }

        public bool CheckDTOList(IList<LOMDTO00072> cropTypeList, string cropCode, bool isEdit)
        {
            foreach (LOMDTO00072 cropTypeDto in cropTypeList)
            {
                if (cropTypeDto.CropCode != cropCode && isEdit)
                    return true;

                else if (!isEdit)
                    return true;
            }
            return false;
        }

    }
}
