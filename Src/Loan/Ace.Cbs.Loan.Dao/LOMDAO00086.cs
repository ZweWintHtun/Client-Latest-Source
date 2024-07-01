using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Dao;
using NHibernate;
using Ace.Windows.Core.Utt;
using NHibernate.Transform;

namespace Ace.Cbs.Loan.Dao
{
    public class LOMDAO00086 : DataRepository<LOMORM00086>, ILOMDAO00086
    {        
        public int CheckLoanAccNo(string vrNo)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("SP_CheckLoanAccNo");
                query.SetString("vrNo", vrNo);
                query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00086)));
                LOMDTO00086 accNo = query.UniqueResult<LOMDTO00086>();
                if (accNo != null)
                    return accNo.Id;
                else
                    return 0;
            }
            catch { return 0; }
        }

        public LOMDTO00086 GetLoanRecordByLoanNo(string eno)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("LRDAO.GetLoanRecordByLoanNo");
                query.SetString("eno", eno);
                return query.UniqueResult<LOMDTO00086>();
            }
            catch { return null; }
        }

        public bool UpdateLoanRecord(LOMDTO00086 entity)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("LRDAO.UpdateLoanRecord");
                query.SetString("eno", entity.Eno);
                query.SetString("townshipCode", entity.TownshipCode);
                query.SetString("villageCode", entity.VillageCode);
                query.SetString("financialYear", entity.FinancialYear);
                query.SetString("businessCode", entity.BusinessCode);
                query.SetDateTime("suspendDate", entity.SuspendDate);
                query.SetDecimal("suspendAmu", entity.SuspendAmu);
                query.SetDateTime("deliverDate", entity.DeliverDate);
                query.SetString("totalGroup", entity.TotalGroup);
                query.SetString("population", entity.Population);
                query.SetString("acre", entity.Acre);
                query.SetDecimal("sanctionAmu", entity.SanctionAmu);
                query.SetDateTime("refundDate", entity.RefundDate);
                query.SetDecimal("refundAmu", entity.RefundAmu);
                query.SetDateTime("updatedDate", DateTime.Now);
                query.SetInt32("updatedUserId", CurrentUserEntity.CurrentUserID);
                query.SetString("businessTypeUM", entity.BusinessTypeUM);
                if (query.ExecuteUpdate() > 0)
                    return true;
                else
                    return false;
            }
            catch { return false; }
        }

        public bool DeleteLoanRecord(string eno)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("LRDAO.DeleteLoanRecord");
                query.SetString("eno", eno);
                query.SetDateTime("updatedDate", DateTime.Now);
                query.SetInt32("updatedUserId", CurrentUserEntity.CurrentUserID);  
                if (query.ExecuteUpdate() > 0)
                    return true;
                else
                    return false;
            }
            catch { return false; }
        }
    }
}
