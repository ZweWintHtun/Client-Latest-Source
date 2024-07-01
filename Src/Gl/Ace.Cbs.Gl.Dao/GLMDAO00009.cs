using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Gl.Dao;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Gl.Dmd;
using Ace.Cbs.Gl.Ctr.Dao;
using NHibernate;
using Ace.Cbs.Mnm.Dmd;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Gl.Dao
{
    public class GLMDAO00009 : DataRepository<MNMVIW00011>, IGLMDAO00009
    {
        public IList<MNMDTO00054> VW_LedgerListingByHomeCurrency(string aCode, DateTime startDate, DateTime endDate,bool isTransactionDate, string sourcebr, int workStation)
        {
            IQuery query = null;
            if (isTransactionDate)
            {
                query = this.Session.GetNamedQuery("GetLedgerListingRptByTDate2");
            }
            else
            {
                query = this.Session.GetNamedQuery("GetLedgerListingRptBySDate2");
            }
            query.SetString("acode", aCode);
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("sourcebr", sourcebr);
            query.SetInt32("workstation", workStation);

            IList<MNMDTO00054> DTOlist = query.List<MNMDTO00054>();
            return DTOlist;
        }

        public IList<MNMDTO00054> VW_LedgerListingBySourceCurrency(string aCode, DateTime startDate, DateTime endDate,string currency, bool isTransactionDate, string sourcebr, int workStation)
        {
            IQuery query = null;
            if (isTransactionDate)
            {
                query = this.Session.GetNamedQuery("GetLedgerListingRptBySourceCurAndTdate2");
            }
            else
            {
                query = this.Session.GetNamedQuery("GetLedgerListingRptBySourceCurAndSdate2");
            }
            query.SetString("acode", aCode);
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("sourcecur", currency);
            query.SetString("sourcebr", sourcebr);
            query.SetInt32("workstation", workStation);

            IList<MNMDTO00054> DTOlist = query.List<MNMDTO00054>();
            return DTOlist;
        }

        #region OldCode
        //public IList<MNMDTO00054> VW_LedgerListingByHomeCurrency(string aCode, DateTime startDate, DateTime endDate, string sourcebr, int workStation)
        //{
        //    IQuery query = this.Session.GetNamedQuery("VW_LedgerListing_ByHomeCurrency");
        //    query.SetString("aCode", aCode);
        //    query.SetDateTime("startDate", startDate);
        //    query.SetDateTime("endDate", endDate);
        //    query.SetString("sourcebr", sourcebr);
        //    query.SetInt32("workstation", workStation);

        //    IList<MNMDTO00054> DTOlist = query.List<MNMDTO00054>();
        //    return DTOlist;
        //}

        //public IList<MNMDTO00054> VW_LedgerListingBySourceCurrency(string aCode, DateTime startDate, DateTime endDate, string sourcebr, int workStation)
        //{
        //    IQuery query = this.Session.GetNamedQuery("VW_LedgerListing_BySourceCurrency");
        //    query.SetString("aCode", aCode);
        //    query.SetDateTime("startDate", startDate);
        //    query.SetDateTime("endDate", endDate);
        //    query.SetString("sourcebr", sourcebr);
        //    query.SetInt32("workstation", workStation);

        //    IList<MNMDTO00054> DTOlist = query.List<MNMDTO00054>();
        //    return DTOlist;
        //}
        #endregion

        public IList<ChargeOfAccountDTO> ChargeOfAccountSelectByPCEAccount(string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("ChargeOfAccount.SelectByOLSAccount");
            query.SetString("sourceBranchCode", sourcebr);

            IList<ChargeOfAccountDTO> coaDTO = query.List<ChargeOfAccountDTO>();
            return coaDTO;
        }
    }
}
