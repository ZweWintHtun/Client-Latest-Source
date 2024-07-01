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
    public class MNMSVE00070 : BaseService, IMNMSVE00070
    {
        #region Properties
        public ICXDAO00009 ViewDAO { get; set; }
        #endregion

        #region GetReportData Method
        [Transaction(TransactionPropagation.Required)]
        public IList<MNMDTO00039> GetReportData(MNMDTO00039 dto, bool IsByDate)
        {
            IList<MNMDTO00039> DataList = new List<MNMDTO00039>();
            if (IsByDate == true)
            {
                DataList = ViewDAO.SelectCustIDByDate(dto.StartDate, dto.EndDate, dto.SourceBr);//, dto.Cur //Commented by HWKO (25-Aug-2016)
            }
            else
            {
                DataList = ViewDAO.SelectCustIDByTownship(dto.StartDate, dto.EndDate, dto.SourceBr, dto.TownShipDesp);//, dto.Cur //Commented by HWKO (25-Aug-2016)
            }
            return DataList;
        }
        #endregion
    }
}
