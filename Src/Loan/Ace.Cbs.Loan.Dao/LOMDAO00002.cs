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
    public class LOMDAO00002 : DataRepository<LOMORM00002>, ILOMDAO00002
    {
        public bool CheckExist(string advanceCode, string description, bool isEdit)
        {
            IQuery query = this.Session.GetNamedQuery("AdvanceDAO.CheckExist");
            query.SetString("code", advanceCode);
            query.SetString("description", description);           
            IList<LOMDTO00002> advanceList = query.List<LOMDTO00002>();

            return advanceList.Count == null ? false : this.CheckDTOList(advanceList, advanceCode, isEdit);           
        }

        public IList<LOMDTO00002> CheckExist2(string advanceCode, string description)
        {
            IQuery query = this.Session.GetNamedQuery("AdvanceDAO.CheckExist2");
            query.SetString("code", advanceCode);
            query.SetString("description", description);
            IList<LOMDTO00002> advanceList = query.List<LOMDTO00002>();
            return advanceList;
        }

        public IList<LOMDTO00002> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("AdvanceDAO.SelectAll");
            return query.List<LOMDTO00002>();
        }

        public LOMDTO00002 SelectByAdvanceCode(string advanceCode)
        {
            IQuery query = this.Session.GetNamedQuery("AdvanceDAO.SelectByAdvanceCode");
            query.SetString("code", advanceCode);
            return query.UniqueResult<LOMDTO00002>();
        }

        public bool CheckDTOList(IList<LOMDTO00002> advanceList, string advanceCode, bool isEdit)
        {
            foreach (LOMDTO00002 advanceDto in advanceList)
            {
                if (advanceDto.Code != advanceCode && isEdit)         
                    return true;
               
                else if (!isEdit)
                    return true;
            }
            return false;
        }

    }
}
