using System;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using System.Collections.Generic;
using NHibernate;

namespace Ace.Cbs.Pfm.Dao
{
   //Stop Cheque Dao
    public class PFMDAO00011 : DataRepository<PFMORM00011>,IPFMDAO00011
    {
        public IList<PFMDTO00011> SelectSChequeData(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00011.SelectSChequeData");
            query.SetString("accountNo", accountNo);
            IList<PFMDTO00011> list = query.List<PFMDTO00011>();
            return list;
          
        }

        public IList<PFMDTO00011> SelectSChequeDataByAccount(string accountNo,string branch)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00011.SelectSChequeDataByAccount");
            query.SetString("accountNo", accountNo);
            query.SetString("branch", branch);
            IList<PFMDTO00011> list = query.List<PFMDTO00011>();
            return list;

        }

        public IList<PFMDTO00011> SelectSChequeDataByDate(DateTime startDate, DateTime endDate,string branch)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00011.SelectSChequeDataByDate");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("branch", branch);
            IList<PFMDTO00011> list = query.List<PFMDTO00011>();
            return list;

        }


        public bool UpdateSChequeData(string accountNo, string checkBookNo, string startSerialNo, string endSerialNo, int updatedUserId, DateTime updatedDate)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00011.UpdateSChequeData");
            query.SetString("accountNo", accountNo);
            query.SetString("checkBookNo", checkBookNo);
            query.SetString("startSerialNo", startSerialNo);
            query.SetString("endSerialNo", endSerialNo);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", updatedDate);
            return query.ExecuteUpdate() > 0;
        }

        public IList<PFMDTO00011> GetSChequeInfoByChequeBookNo(string accountNo, string checkBookNo, string branch)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00011.SelectSChequeDataByChequeBookNo");
            query.SetString("accountNo", accountNo);
            query.SetString("chequebookNo", checkBookNo);
            query.SetString("sourcebr", branch);

            //return query.UniqueResult<PFMDTO00011>();
            IList<PFMDTO00011> list = query.List<PFMDTO00011>();
            return list;
        }
    }
}