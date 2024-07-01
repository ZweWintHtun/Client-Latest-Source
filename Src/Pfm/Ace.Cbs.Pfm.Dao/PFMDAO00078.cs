using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Pfm.Ctr;
using Ace.Windows.Core.Dao;
using NHibernate;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Pfm.Ctr.DAO;

namespace Ace.Cbs.Pfm.Dao
{
    public class PFMDAO00078 : DataRepository<PFMORM00078>, IPFMDAO00078
    {        
        public string SelectSolidarityCountNo()
        {
            try
            {
                object maxIdObject;
                int maxId;
                IQuery query = this.Session.GetNamedQuery("SolidarityLendingDAO.SelectNo");
                maxIdObject = query.SetFirstResult(0).SetMaxResults(1).UniqueResult();
                if (maxIdObject != null)
                {
                    maxId = Convert.ToInt32(maxIdObject);
                    maxId += 1;
                    return "G" + CurrentUserEntity.BranchCode.ToString() + String.Format("{0:00000}", maxId);
                }
                else
                {
                    return "G" + CurrentUserEntity.BranchCode.ToString() + String.Format("{0:00000}", 1);
                }
            }
            catch { return string.Empty; }            
        }

        public IList<PFMDTO00078> SelectByGroupNo(string groupNo)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("SolidarityLendingDAO.SelectByGroupNo");
                query.SetString("groupNo", groupNo);
                return query.List<PFMDTO00078>();
            }
            catch { throw; }
        }

        public bool UpdateSolidarity(PFMDTO00078 sol)
        {
            try
            {
                int i = 0;
                IQuery query = this.Session.GetNamedQuery("SolidarityLendingDAO.UpdateSolidarity");
                query.SetString("NameOnly", sol.NameOnly);
                query.SetBoolean("IsNRC", sol.IsNRC);
                query.SetBoolean("IsLeader", sol.IsLeader);
                query.SetString("NRCNo", sol.NRCNo);                
                query.SetString("FatherName", sol.FatherName);
                query.SetString("VillageCode", sol.VillageCode);
                query.SetString("Address", sol.Address);
                query.SetDateTime("UpdatedDate", DateTime.Now);
                query.SetInt32("UpdatedUserId", CurrentUserEntity.CurrentUserID);
                query.SetInt32("Id", sol.Id);
                i = query.ExecuteUpdate();     
                return i > 0 ? true : false;                
            }
            catch { throw; }
        }
    }
}
