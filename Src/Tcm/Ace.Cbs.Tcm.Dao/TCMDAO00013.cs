using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tcm.Ctr.Dao;
using Ace.Windows.Core.Dao;
using Spring.Transaction;
using Spring.Transaction.Interceptor;

namespace Ace.Cbs.Tcm.Dao
{
    public class TCMDAO00013 :DataRepository<TCMVIW00013>, ITCMDAO00013
    {
        public IList<PFMDTO00042> SelectAcctNoAbyWorkstation(int workstation, string currency)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00042.SelectAAcctno");
            query.SetString("workStationId", Convert.ToString(workstation));
            query.SetString("currency", currency);

            return query.List<PFMDTO00042>();
        }

        public IList<PFMDTO00042> SelectAcctNoCbyWorkstation(int workstation, string currency)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00042.SelectCAcctno");
            query.SetString("workStationId", Convert.ToString(workstation));
            query.SetString("currency", currency);

            return query.List<PFMDTO00042>();
        }

        //Added by HWKO (17-Aug-2017)
        public IList<PFMDTO00042> SelectAcctNoBbyWorkstation(int workstation, string currency)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00042.SelectBAcctno");
            query.SetString("workStationId", Convert.ToString(workstation));
            query.SetString("currency", currency);

            return query.List<PFMDTO00042>();
        }

        //Added by HWKO (17-Aug-2017)
        public IList<PFMDTO00042> SelectAcctNoHbyWorkstation(int workstation, string currency)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00042.SelectHAcctno");
            query.SetString("workStationId", Convert.ToString(workstation));
            query.SetString("currency", currency);

            return query.List<PFMDTO00042>();
        }

        //Added by HWKO (17-Aug-2017)
        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00042> SelectAcctNoPbyWorkstation(int workstation, string currency)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00042.SelectPAcctno");
            query.SetString("workStationId", Convert.ToString(workstation));
            query.SetString("currency", currency);            
            return query.List<PFMDTO00042>();
        }

        //Added by HWKO (17-Aug-2017)
        public IList<PFMDTO00042> SelectAcctNoDbyWorkstation(int workstation, string currency)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00042.SelectDAcctno");
            query.SetString("workStationId", Convert.ToString(workstation));
            query.SetString("currency", currency);

            return query.List<PFMDTO00042>();
        }

        public IList<PFMDTO00042> SelectAcctNoSbyWorkstation(int workstation, string currency)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00042.SelectSAcctno");
            query.SetString("workStationId", Convert.ToString(workstation));
            query.SetString("currency", currency);

            return query.List<PFMDTO00042>();
        }

        public IList<PFMDTO00042> SelectAcctNoFbyWorkstation(int workstation, string currency)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00042.SelectFAcctno");
            query.SetString("workStationId", Convert.ToString(workstation));
            query.SetString("currency", currency);

            return query.List<PFMDTO00042>();
        }
    }
}
