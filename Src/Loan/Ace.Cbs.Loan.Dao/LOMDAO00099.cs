using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;
using NHibernate;
using Ace.Windows.Core.Utt;
using NHibernate.Transform;

namespace Ace.Cbs.Loan.Dao
{
    public class LOMDAO00099 : DataRepository<LOMORM00099>, ILOMDAO00099
    {
        public IList<LOMDTO00099> GetAll()
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("LOMORM00099.SelectAll");
                return query.List<LOMDTO00099>();
            }
            catch { return null; }
        }

        public IList<LOMDTO00099> SelectByLoanNo(string lno)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("ProcGetLoanRecord_BusinessType");
                query.SetString("LoanNo", lno);
                query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00099)));
                IList<LOMDTO00099>  LoanRecordList = query.List<LOMDTO00099>();
                return LoanRecordList;
            }
            catch { return null; }
        }

        public bool UpdateLoanRecord_BusinessType(IList<LOMDTO00099> lstBusinessType)
        {
            try
            {
                int count = 0;
                foreach (LOMDTO00099 businessType in lstBusinessType)
                {
                    IQuery query = this.Session.GetNamedQuery("LOMORM00099.UpdateBusinessType");
                    query.SetInt32("id", businessType.Id);
                    query.SetString("businessType", businessType.BusinessType);
                    query.SetDecimal("um", businessType.UM);
                    query.SetDateTime("updatedDate", DateTime.Now);
                    query.SetInt32("updatedUserId", CurrentUserEntity.CurrentUserID);
                    if (query.ExecuteUpdate() > 0)
                        count++;
                }
                return (count == lstBusinessType.Count) ? true : false;
            }
            catch { return false; }
        }

        public void DeleteLoanRecord_BusinessType(IList<LOMDTO00099> lstBusinessType)
        {
            try
            {
                int count = 0;
                foreach (LOMDTO00099 businessType in lstBusinessType)
                {
                    IQuery query = this.Session.GetNamedQuery("LOMORM00099.DeleteBusinessType");
                    query.SetInt32("id", businessType.Id);
                    query.ExecuteUpdate();
                }
            }
            catch {  }
        }
    }
}
