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
    public class MNMSVE00068: BaseService, IMNMSVE00068
    {
        #region DAO
        public ICXDAO00009 ViewDAO { get; set; }
        #endregion

        #region Method
        [Transaction(TransactionPropagation.Required)]
        public IList<MNMDTO00037> GetReportData(MNMDTO00037 dto, bool IsCurrent)
        {
            IList<MNMDTO00037> dataList = new List<MNMDTO00037>();
            if (IsCurrent == true)
            {
                dataList = ViewDAO.SelectCurrentClosedAccountByDate(dto.StartDate, dto.EndDate, dto.SourceBr);
            }
            else
            {
                dataList = ViewDAO.SelectSavingClosedAccountByDate(dto.StartDate, dto.EndDate, dto.SourceBr);
            }
            return dataList;
        }
        #endregion
    }
}
