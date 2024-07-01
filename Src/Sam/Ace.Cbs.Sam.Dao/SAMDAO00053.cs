using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Sam.Ctr.Dao;
using Ace.Cbs.Sam.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;


namespace Ace.Cbs.Sam.Dao
{
    public class SAMDAO00053 : DataRepository<SAMORM00053>, ISAMDAO00053
    {
        public bool CheckExist(string nationalityCode, string desp, bool isEdit)
        {
            IQuery query = this.Session.GetNamedQuery("NationalityCodeDAO.CheckExist");
            query.SetString("nationalityCode", nationalityCode);
            query.SetString("desp", desp);
            IList<SAMDTO00053> NationalityCodeList = query.List<SAMDTO00053>();
            return NationalityCodeList == null ? false : this.CheckDTOList(NationalityCodeList, nationalityCode, isEdit);
        }

        public IList<SAMDTO00053> CheckExist2(string nationalityCode, string desp)
        {
            IQuery query = this.Session.GetNamedQuery("NationalityCodeDAO.CheckExist2");
            query.SetString("nationalityCode", nationalityCode);
            query.SetString("desp", desp);
            IList<SAMDTO00053> NationalityCodeList = query.List<SAMDTO00053>();
            return NationalityCodeList;
        }

        public IList<SAMDTO00053> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("NationalityCodeDAO.SelectAll");
            return query.List<SAMDTO00053>();
        }

        public SAMDTO00053 SelectByNationalityCode(string nationalityCode)
        {
            IQuery query = this.Session.GetNamedQuery("NationalityCodeDAO.SelectByNationalityCode");
            query.SetString("nationalityCode", nationalityCode);
            return query.UniqueResult<SAMDTO00053>();
        }

        private bool CheckDTOList(IList<SAMDTO00053> nationalityCodeList, string nationalityCode, bool isEdit)
        {
            foreach (SAMDTO00053 info in nationalityCodeList)
            {
                if (info.Nationality_Code != nationalityCode && isEdit)
                    return true;
                else if (!isEdit)
                    return true;
            }
            return false;
        }
    }
}
