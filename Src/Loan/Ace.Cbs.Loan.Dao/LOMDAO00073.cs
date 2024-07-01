using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;
using NHibernate;
using Ace.Cbs.Loan.Ctr.Dao;

namespace Ace.Cbs.Loan.Dao
{
    public class LOMDAO00073 : DataRepository<LOMORM00073>, ILOMDAO00073
    {
        public IList<LOMDTO00073> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("UMDAO.SelectAll");
            return query.List<LOMDTO00073>();
        }

        public IList<LOMDTO00073> CheckExist2(string umCode, string umDesp)
        {
            IQuery query = this.Session.GetNamedQuery("UMDAO.CheckExist2");
            query.SetString("umCode", umCode);
            query.SetString("umDesp", umDesp);
            IList<LOMDTO00073> umTypeList = query.List<LOMDTO00073>();
            return umTypeList;
        }

        public IList<LOMDTO00073> SelectByUMCode(string umCode)
        {
            IQuery query = this.Session.GetNamedQuery("UMDAO.SelectByUMCode");
            query.SetString("umCode", umCode);
            return query.List<LOMDTO00073>();
        }

        public bool CheckExist(string umCode, string umDesp, bool isEdit)
        {
            IQuery query = this.Session.GetNamedQuery("UMDAO.CheckExist");
            query.SetString("umCode", umCode);
            query.SetString("umDesp", umDesp);
            IList<LOMDTO00073> umTypeList = query.List<LOMDTO00073>();

            return umTypeList.Count == null ? false : this.CheckDTOList(umTypeList, umCode, isEdit);
        }

        public bool CheckDTOList(IList<LOMDTO00073> umTypeList, string umCode, bool isEdit)
        {
            foreach (LOMDTO00073 umTypeDto in umTypeList)
            {
                if (umTypeDto.UMCode != umCode && isEdit)
                    return true;

                else if (!isEdit)
                    return true;
            }
            return false;
        }

    }
}
