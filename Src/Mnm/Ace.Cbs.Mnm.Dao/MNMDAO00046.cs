using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Mnm.Ctr.Dao;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Mnm.Dao
{
    public class MNMDAO00046 : DataRepository<TLMVIW000A9>, IMNMDAO00046
    {
        //public IList<PFMDTO00042> BankSatatementByWithdrawAmount(string workstation, string accountNo, DateTime year, DateTime month)
        //{
        //    IQuery query = this.Session.GetNamedQuery("TLMVIW000A9.BankSatatementByWithdrawAmount");
        //    query.SetString("workstation", workstation);
        //    query.SetString("accountNo", accountNo);
        //    query.SetDateTime("year", year);
        //    query.SetDateTime("month", month);
        //    string sql = this.GetSQLString(query.QueryString);

        //    return query.List<PFMDTO00042>();
        //}
        
        //public IList<PFMDTO00042> BankSatatementByDepositAmount(int workstation, string accountNo, DateTime year, DateTime month)
        //{
        //    IQuery query = this.Session.GetNamedQuery("TLMVIW000A9.BankSatatementByDepositAmount");
        //    query.SetInt32("workstation", workstation);
        //    query.SetString("accountNo", accountNo);
        //    query.SetDateTime("year", year);
        //    query.SetDateTime("month", month);

        //    return query.List<PFMDTO00042>();
        //}

        public IList<PFMDTO00017> SelectCustID(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("PFMORM00017.SelectCustID");
            query.SetString("acctNo", accountNo);

            return query.List<PFMDTO00017>();
        }

        public IList<PFMDTO00017> SelectSCustID(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("PFMORM00016.SelectCustID");
            query.SetString("acctNo", accountNo);

            return query.List<PFMDTO00017>();
        }

        public PFMDTO00001 SelectCustInfoByCustID(string custID)
        {
            IQuery query = this.Session.GetNamedQuery("PFMORM00001.SelectCustInfoByCustID");
            query.SetString("custID", custID);

            return query.UniqueResult<PFMDTO00001>();
        }

        public TownshipDTO SelectTownship(string townshipCode)
        {
            IQuery query = this.Session.GetNamedQuery("Township.SelectTownshipDesp");
            query.SetString("townshipCode", townshipCode);

            return query.UniqueResult<TownshipDTO>();
        }

        public PFMDTO00028 SelectAccountSign(string accountNo, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00028.SelectAccountSign");
            query.SetString("accountNo", accountNo);
            query.SetString("sourcebr", sourceBr);

            return query.UniqueResult<PFMDTO00028>();
        }
    }
}
