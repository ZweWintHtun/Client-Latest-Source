using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
using Ace.Cbs.Loan.Dmd.DTO;
using NHibernate.Transform;

namespace Ace.Cbs.Loan.Dao
{
    public class LOMDAO00404 : DataRepository<LOMORM00404>, ILOMDAO00404
    {
        public bool CheckExist(string businessCode, string description,string acode, bool isEdit)
        {
            IQuery query = this.Session.GetNamedQuery("LoanBTypeDAO.CheckExist");
            query.SetString("code", businessCode);
            query.SetString("description", description);
            query.SetString("acode", acode);
            IList<LOMDTO00001> BusinessCodeList = query.List<LOMDTO00001>();
            return BusinessCodeList == null ? false : this.CheckDTOList(BusinessCodeList, businessCode, isEdit);
        }

        public IList<LOMDTO00001> CheckExist2(string businessCode, string description, string acode)
        {
            IQuery query = this.Session.GetNamedQuery("LoanBTypeDAO.CheckExist2");
            query.SetString("code", businessCode);
            query.SetString("description", description);
            query.SetString("acode", acode);
            IList<LOMDTO00001> BusinessCodeList = query.List<LOMDTO00001>();
            return BusinessCodeList;
        }

        public IList<LOMDTO00001> SelectAll()
        
        {
            IQuery query = this.Session.GetNamedQuery("LoanBTypeDAO.SelectAll");
            return query.List<LOMDTO00001>();
        }

        public LOMDTO00001 SelectByBusinessCode(string businessCode)
        {
            IQuery query = this.Session.GetNamedQuery("LoanBTypeDAO.SelectByCode");
            query.SetString("code", businessCode);
            return query.UniqueResult<LOMDTO00001>();
        }

        private bool CheckDTOList(IList<LOMDTO00001> businessCodeList, string businessCode, bool isEdit)
        {
            foreach (LOMDTO00001 info in businessCodeList)
            {
                if (info.Code != businessCode && isEdit)
                    return true;
                else if (!isEdit)
                    return true;
            }
            return false;
        }
        public string SelectCompanyName(string acctno)
        {
            IQuery query = this.Session.GetNamedQuery("SP_GetCompanyName");
            query.SetString("acctno", acctno);

            return query.UniqueResult().ToString();
        }
    }
}
