using System;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;

namespace Ace.Cbs.Pfm.Dao
{
    public class PFMDAO00045 : DataRepository<PFMORM00045>, IPFMDAO00045
    {       
        //Passbook->Transaction Printing( PrintRecord )      
        #region IPFMDAO00045 Members

        public DateTime SelectCloseDateByAccountNo(string AccountNo)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00045.SelectCloseDate");
            query.SetString("AccountNo", AccountNo);
            DateTime resultDate = query.UniqueResult<DateTime>();
            System.Diagnostics.Debug.WriteLine("----------- Testing AccountNo  in Dao ----------");
            System.Diagnostics.Debug.WriteLine(resultDate);
            return resultDate;
            
        }

        #endregion
    }


}