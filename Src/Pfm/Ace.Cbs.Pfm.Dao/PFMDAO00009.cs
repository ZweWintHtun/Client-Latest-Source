using System.Collections.Generic;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;

namespace Ace.Cbs.Pfm.Dao
{
    public class PFMDAO00009 : DataRepository<PFMORM00009>, IPFMDAO00009
    {
        public bool CheckExist(string code, string desp, System.DateTime dATE_TIME, bool lASTMODIFY, decimal rate, bool isEdit)
        {
            IQuery query = this.Session.GetNamedQuery("RateFileDAO.CheckExist");
            query.SetString("code", code);
            //query.SetString("desp", desp);
            //query.SetDateTime("dATE_TIME", dATE_TIME);
            //query.SetBoolean("lASTMODIFY", lASTMODIFY);
            //query.SetDecimal("rate", rate);
            IList<PFMDTO00009> RateFileList = query.List<PFMDTO00009>();
            return RateFileList.Count == 0 ? false : this.CheckDTOList(RateFileList, code, isEdit);
        }

        public IList<PFMDTO00009> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("RateFileDAO.SelectAll");
            return query.List<PFMDTO00009>();
        }

        public PFMDTO00009 SelectByCode(string code)
        {
            IQuery query = this.Session.GetNamedQuery("RateFileDAO.SelectByCode");
            query.SetString("code", code);
            return query.UniqueResult<PFMDTO00009>();
        }

        public PFMDTO00009 SelectByRateCode(string code)
        {
            IQuery query = this.Session.GetNamedQuery("RateFileDAO.SelectByRateCode");
            query.SetString("code", code);
            return query.UniqueResult<PFMDTO00009>();
        }

        private bool CheckDTOList(IList<PFMDTO00009> rateFileList, string code, bool isEdit)
        {
            foreach (PFMDTO00009 info in rateFileList)
            {
                if (info.Code != code && isEdit)
                    return true;
                else if (!isEdit)
                    return true;
            }
            return false;
        }

        public bool UpdateRate(PFMDTO00009 entity)
        {
            IQuery query = this.Session.GetNamedQuery("RateFileDAO.UpdateRate");
            query.SetString("code", entity.Code);
            query.SetDateTime("updateddate", (System.DateTime)entity.UpdatedDate);
            query.SetInt32("updateduserid", (System.Int32)entity.UpdatedUserId);
            return query.ExecuteUpdate() > 0;
        }

        public bool DeleteRate(PFMDTO00009 entity)
        {
            IQuery query = this.Session.GetNamedQuery("RateFileDAO.DeleteRate");
            query.SetString("code", entity.Code);
            query.SetDateTime("updateddate", (System.DateTime)entity.UpdatedDate);
            query.SetInt32("updateduserid", (System.Int32)entity.UpdatedUserId);
            return query.ExecuteUpdate() > 0;
        }
    }
}