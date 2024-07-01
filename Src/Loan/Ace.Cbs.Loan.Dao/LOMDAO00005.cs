using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Loan.Dmd;
using NHibernate;

namespace Ace.Cbs.Loan.Dao
{
    class LOMDAO00005 : DataRepository<LOMORM00005>, ILOMDAO00005
    {
        public bool CheckExist(string code, string desp, bool isEdit)
        {
            IQuery query = this.Session.GetNamedQuery("LandDAO.CheckExist");
            query.SetString("code", code);
            query.SetString("description", desp);
            IList<LOMDTO00001> codeList = query.List<LOMDTO00001>();
            return codeList == null ? false : this.CheckDTOList(codeList, code, isEdit);
        }

        public IList<LOMDTO00001> CheckExist2(string code, string desp)
        {
            IQuery query = this.Session.GetNamedQuery("LandDAO.CheckExist2");
            query.SetString("code", code);
            query.SetString("description", desp);
            IList<LOMDTO00001> codeList = query.List<LOMDTO00001>();
            return codeList;
        }

        public IList<LOMDTO00001> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("LandDAO.SelectAll");
            return query.List<LOMDTO00001>();
        }

        public LOMDTO00001 SelectByCode(string code)
        {
            IQuery query = this.Session.GetNamedQuery("LandDAO.SelectByCode");
            query.SetString("code", code);
            return query.UniqueResult<LOMDTO00001>();
        }

        public void ManualUpdate(LOMORM00005 entity)
        {
            IQuery query = Session.GetNamedQuery("LandDAO.Update");
            query.SetString("desp", entity.Description);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", entity.UpdatedUserId.Value);
            query.SetString("code", entity.Code);
            query.ExecuteUpdate();
        }

        #region Helper Methods

        private bool CheckDTOList(IList<LOMDTO00001> codeList, string code, bool isEdit)
        {
            foreach (LOMDTO00001 dto in codeList)
            {
                if (dto.Code != code && isEdit)
                    return true;
                else if (!isEdit)
                    return false;
            }
            return false;
        }

        #endregion
    }
}
