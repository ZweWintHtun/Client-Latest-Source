using System.Collections.Generic;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;

namespace Ace.Cbs.Pfm.Dao
{
    public class PFMDAO00048 : DataRepository<PFMORM00048>, IPFMDAO00048
    {
        public bool CheckExist(string code, string description, bool isEdit)
        {
            IQuery query = this.Session.GetNamedQuery("MessageDAO.CheckExist");
            query.SetString("code", code);
            query.SetString("description", description);
            IList<PFMDTO00048> MessageList = query.List<PFMDTO00048>();
            return MessageList == null ? false : this.CheckDTOList(MessageList, code, isEdit);
        }

        public IList<PFMDTO00048 > CheckExist2(string MessageCode, string desp)
        {
            IQuery query = this.Session.GetNamedQuery("MessageDAO.CheckExist2");
            query.SetString("code", MessageCode);
            query.SetString("description", desp);
            IList<PFMDTO00048> MessageList = query.List<PFMDTO00048>();
            return MessageList;
        }

        public IList<PFMDTO00048> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("MessageDAO.SelectAll");
            return query.List<PFMDTO00048>();
        }

        public PFMDTO00048 SelectByCode(string code)
        {
            IQuery query = this.Session.GetNamedQuery("MessageDAO.SelectByCode");
            query.SetString("code", code);
            return query.UniqueResult<PFMDTO00048>();
        }

        private bool CheckDTOList(IList<PFMDTO00048> messageList, string code, bool isEdit)
        {
            foreach (PFMDTO00048 info in messageList)
            {
                if (info.Code != code && isEdit)
                    return true;
                else if (!isEdit)
                    return true;
            }
            return false;
        }
    }
}