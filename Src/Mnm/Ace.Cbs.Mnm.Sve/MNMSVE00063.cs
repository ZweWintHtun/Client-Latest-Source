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
    public class MNMSVE00063 : BaseService, IMNMSVE00063
    {
        #region Constructor
        public MNMSVE00063() { }
        #endregion

        #region Properties
        public ICXDAO00009 ViewDAO { get; set; }
        #endregion

        #region Method
        [Transaction(TransactionPropagation.Required)]
        public IList<MNMDTO00040> GetReportData(MNMDTO00040 dto, bool isCheckCurrency, string isrdoCurrentAccount)
        {
            IList<MNMDTO00040> DataList = new List<MNMDTO00040>();
            if (isrdoCurrentAccount == "Current Account")
            {
                if (isCheckCurrency == true)
                {
                    DataList = ViewDAO.SelectLedgerBalanceByGradeCurrentAllCurrency(dto.StartAmount, dto.EndAmount, dto.SourceBr);
                }
                else
                {
                    DataList = ViewDAO.SelectLedgerBalanceByGradeCurrent(dto.StartAmount, dto.EndAmount, dto.Cur, dto.SourceBr);
                }
            }
            else
            {
                if (isCheckCurrency == true)
                {
                    DataList = ViewDAO.SelectLedgerBalanceByGradeSavingAllCurrency(dto.StartAmount, dto.EndAmount, dto.SourceBr);
                }
                else
                {
                    DataList = ViewDAO.SelectLedgerBalanceByGradeSaving(dto.StartAmount, dto.EndAmount, dto.Cur, dto.SourceBr);
                }
            }            
            
            return DataList;
        }
        #endregion
    }
}
