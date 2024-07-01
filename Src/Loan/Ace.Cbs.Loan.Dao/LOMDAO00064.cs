using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Loan.Dmd.DTO;
using System.Data.SqlClient;
using System.Data;

namespace Ace.Cbs.Loan.Dao
{
    public class LOMDAO00064 : DataRepository<LOMORM00026>, ILOMDAO00064
    {
        public string AddDealerRegistration(string dealerNo, string dealerAC, string dName, string dPhone, string dAddress, string email, string nrc, string fax, string businessName, string city, string businessEmail, string address, decimal commission, string eventMode, string sourceBr, int createdUserId, DateTime createdDate, int updatedUserId, DateTime updatedDate)
        {
            IQuery query = this.Session.GetNamedQuery("SP_InsertDealerRegistration");
            query.SetString("dealerNo", dealerNo);
            query.SetString("dealerAC", dealerAC);
            query.SetString("dName", dName);
            query.SetString("dPhone", dPhone);
            query.SetString("dAddress", dAddress);
            query.SetString("email", email);
            query.SetString("nrc", nrc);
            query.SetString("fax", fax);
            query.SetString("businessName", businessName);
            query.SetString("city", city);
            query.SetString("businessEmail", businessEmail);
            query.SetString("address", address);
            query.SetDecimal("commission", commission);
            query.SetString("eventMode", eventMode);
            query.SetString("sourceBr", sourceBr);
            query.SetInt32("createdUserId", createdUserId);
            query.SetDateTime("createdDate", createdDate);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", updatedDate);
            return query.UniqueResult().ToString();
        }
        public string DeleteDealerRegistration(string dealerNo,int createdUserId,string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_DeleteDealerRegistration");
            query.SetString("dealerNo", dealerNo);
            query.SetInt32("createdUserId", createdUserId);
            query.SetString("sourceBr", sourceBr);
            return query.UniqueResult().ToString();
        }
        public IList<LOMDTO00095> GetDealerAccountInfo(string acctNo, string sourceBr)
        {
            IList<LOMDTO00095> result;
            IQuery query = this.Session.GetNamedQuery("SP_GetDealerAccountInfo");
            query.SetString("acctNo", acctNo);
            query.SetString("sourceBr", sourceBr);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00095)));
            result = query.List<LOMDTO00095>();
            return result;
        }

    }
}
