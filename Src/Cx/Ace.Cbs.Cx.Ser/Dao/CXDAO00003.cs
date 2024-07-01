using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using System;

namespace Ace.Cbs.Cx.Ser.Dao
{
    /// <summary>
    /// Printing Dao Class
    /// </summary>
    public class CXDAO00003 : DataRepository<PFMORM00014>,ICXDAO00003
    {
        public IList<PFMDTO00014> PrintCheque_SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("PrintChequeDAO.SelectAll");
            return query.List<PFMDTO00014>();
        }

        public PFMDTO00014 PrintCheque_SelectByPrintChequeId(int id)
        {
            IQuery query = this.Session.GetNamedQuery("PrintChequeDAO.SelectByPrintChequeId");
            query.SetInt32("id", id);
            return query.UniqueResult<PFMDTO00014>();
        }

        public IList<PFMDTO00043> PRNFile_SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("PRNFileDAO.SelectAll");
            return query.List<PFMDTO00043>();
        }

        public PFMDTO00043 PRNFile_SelectByPRNFileId(int id)
        {
            IQuery query = this.Session.GetNamedQuery("PRNFileDAO.SelectByPRNFileId");
            query.SetInt32("id", id);
            return query.UniqueResult<PFMDTO00043>();
        }

        public PFMORM00043 PRNFile_Save(PFMORM00043 entity)
        {
            this.Session.Save(entity);
            return entity;
        }

        public void PRNFile_Update(PFMORM00043 entity)
        {
            this.Session.Update(entity);
        }

        public void PRNFile_Delete(PFMORM00043 entity)
        {
            this.Session.Update(entity);
        }

        public void FPRNFile_Delete(PFMORM00058 entity)
        {
            this.Session.Update(entity);
        }

        public IList<PFMDTO00043> PRNFile_SelectByAccountNo(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("PrnFile.SelectByAccountNo");
            query.SetString("accountNo", accountNo);
           return query.List<PFMDTO00043>();
           
        }

        public IList<PFMDTO00058> FPRNFile_SelectByAccountNo(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00058.SelectByAccountNo");
            query.SetString("accountNo", accountNo);
            return query.List<PFMDTO00058>();
        }

        [Transaction(TransactionPropagation.Required)]
        public bool DeletePrnFileByAccountNo(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00043.DeleteByAccountNo");
            query.SetString("accountNo", accountNo);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool DeleteFPrnFileByAccountNo(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00058.DeleteByAccountNo");
            query.SetString("accountNo", accountNo);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdatePrintLineForCS(string accountNo,decimal lineNo,int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00028.UpdatePrintLineNo");
            query.SetString("accountNo", accountNo);
            query.SetDecimal("lineNo", lineNo);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdatePrintLineForFixed(string accountNo, decimal lineNo,int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00023.UpdatePrintLineNo");
            query.SetString("accountNo", accountNo);
            query.SetDecimal("lineNo", lineNo);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }

        public decimal GetPrintLineforAccountNo(string accountNo)
        {
            if (string.IsNullOrEmpty(accountNo))
            {
                throw new Exception("ME90018");//Invalid Parameter Value.
            }
            else
            {
                IQuery query = this.Session.GetNamedQuery("PFMDAO00028.SelectPrintLineNo");
                query.SetString("accountNo", accountNo);

                return query.UniqueResult<PFMDTO00028>().PrintLineNo;
            }
        }

        public decimal GetPrintLineforFixedAccountNo(string accountNo)
        {
            if (string.IsNullOrEmpty(accountNo))
            {
                throw new Exception("ME90018");//Invalid Parameter Value.
            }
            else
            {
                IQuery query = this.Session.GetNamedQuery("PFMDAO00023.SelectPrintLineNo");
                query.SetString("accountNo", accountNo);

                return Convert.ToDecimal(query.UniqueResult<PFMDTO00023>().PrintLineNo);
            }
        }

    }
}
