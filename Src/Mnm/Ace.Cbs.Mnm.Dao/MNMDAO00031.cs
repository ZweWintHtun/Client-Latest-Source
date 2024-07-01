using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Mnm.Ctr.Dao;

namespace Ace.Cbs.Mnm.Dao
{
    public class MNMDAO00031 : DataRepository<PFMORM00001>,IMNMDAO00031
    {

        public PFMDTO00001 GetCAOFsInfoByAccountNumber(string accountNumber)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.SelectCustomerInformationByCAOF");
            query.SetString("accountNo", accountNumber);

            return query.UniqueResult<PFMDTO00001>();
        }

        public PFMDTO00001 GetSAOFInfoByAccountNumber(string accountNumber)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.SelectCustomerInformationBySAOF");
            query.SetString("accountNo", accountNumber);

            return query.UniqueResult<PFMDTO00001>();
        }

        public PFMDTO00001 GetFAOFInfoByAccountNumber(string accountNumber)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.SelectCustomerInformationByFAOF");
            query.SetString("accountNo", accountNumber);

            return query.UniqueResult<PFMDTO00001>();
        }

       
    }
}
