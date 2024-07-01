using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Mnm.Ctr.Dao;
using Ace.Cbs.Mnm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.Core.Service;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using NHibernate;
using Spring.Data.NHibernate.Support;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Mnm.Sve
{
    public class MNMSVE00076 : BaseService, IMNMSVE00076
    {
        #region Properties
        public IMNMDAO00076 DAO { get; set; }
        #endregion

        public IList<MNMDTO00076> SelectPoNo(string SourceBr)
        {
            IList<MNMDTO00076> DTOList = DAO.SelectPoNo(SourceBr);

            return DTOList;
        }
    }
}
