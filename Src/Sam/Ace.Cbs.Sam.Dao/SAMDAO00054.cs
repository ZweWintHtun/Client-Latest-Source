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
    public class SAMDAO00054 : DataRepository<SAMORM00054>, ISAMDAO00054
    {
        public bool CheckExist(int Id, string StateCode, string TownshipCode, string TownshipDesp, bool isEdit)
        {
            IQuery query = this.Session.GetNamedQuery("NRCDAO.CheckExist");
            query.SetString("StateCode", StateCode);
            query.SetString("TownshipCode", TownshipCode);
            IList<SAMDTO00054> NRCCodeList = query.List<SAMDTO00054>();
            return NRCCodeList == null ? false : this.CheckDTOList(NRCCodeList, Id, StateCode,TownshipCode, TownshipDesp, isEdit);
        }

        public IList<SAMDTO00054> CheckExist2(string StateCode, string TownshipCode)
        {
            IQuery query = this.Session.GetNamedQuery("NRCDAO.CheckExist2");
            query.SetString("StateCode", StateCode);
            query.SetString("TownshipCode", TownshipCode);
            IList<SAMDTO00054> NRCCodeList = query.List<SAMDTO00054>();
            return NRCCodeList;
        }

        public IList<SAMDTO00054> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("NRCDAO.SelectAll");
            return query.List<SAMDTO00054>();
        }

        public IList<SAMDTO00054> SelectByStateCode(string StateCode)
        {
            IQuery query = this.Session.GetNamedQuery("NRCDAO.SelectByStateCode");
            query.SetString("StateCode", StateCode);
            return query.List<SAMDTO00054>();
        }

        private bool CheckDTOList(IList<SAMDTO00054> NRCCodeList, int Id, string StateCode, string TownshipCode, string TownshipDesp, bool isEdit)
        {
            foreach (SAMDTO00054 info in NRCCodeList)
            {
                if (isEdit)
                {
                    if (info.Id == Id)
                    {
                        if ((info.TownshipCode == TownshipCode && info.StateCode == StateCode) && info.TownshipDesp == TownshipDesp && isEdit)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if ((info.TownshipCode == TownshipCode && info.StateCode == StateCode) && isEdit)
                        {
                            return true;
                        }
                    }
                }
                else if (!isEdit)
                    return true;
            }
            return false;
        }
    }
}
