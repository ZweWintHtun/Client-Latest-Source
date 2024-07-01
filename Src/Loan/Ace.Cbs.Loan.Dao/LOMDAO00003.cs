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
    public class LOMDAO00003 : DataRepository<LOMORM00003>, ILOMDAO00003
    {
        public bool CheckExist(string characterCode, string description, bool isEdit)
        {
            IQuery query = this.Session.GetNamedQuery("CustomerCharacterDAO.CheckExist");
            query.SetString("code", characterCode);
            query.SetString("description", description);
            IList<LOMDTO00001> CharacterCodeList = query.List<LOMDTO00001>();
            return CharacterCodeList == null ? false : this.CheckDTOList(CharacterCodeList, characterCode, isEdit);
        }

        public IList<LOMDTO00001> CheckExist2(string characterCode, string description)
        {
            IQuery query = this.Session.GetNamedQuery("CustomerCharacterDAO.CheckExist2");
            query.SetString("code", characterCode);
            query.SetString("description", description);
            IList<LOMDTO00001> CharacterCodeList = query.List<LOMDTO00001>();
            return CharacterCodeList;
        }

        public IList<LOMDTO00001> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("CustomerCharacterDAO.SelectAll");
            return query.List<LOMDTO00001>();
        }

        public LOMDTO00001 SelectByCode(string characterCode)
        {
            IQuery query = this.Session.GetNamedQuery("CustomerCharacterDAO.SelectByCode");
            query.SetString("code", characterCode);
            return query.UniqueResult<LOMDTO00001>();
        }

        private bool CheckDTOList(IList<LOMDTO00001> characterCodeList, string characterCode, bool isEdit)
        {
            foreach (LOMDTO00001 info in characterCodeList)
            {
                if (info.Code != characterCode && isEdit)
                    return true;
                else if (!isEdit)
                    return true;
            }
            return false;
        }

  }

}
