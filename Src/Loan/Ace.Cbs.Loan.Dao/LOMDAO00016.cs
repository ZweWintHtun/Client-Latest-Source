using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using NHibernate;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using System.Collections.Generic;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Dao;

namespace Ace.Cbs.Loan.Dao
{

    /// <summary>
    /// Pledge DAO
    /// </summary>
    public class LOMDAO00016 : DataRepository<LOMORM00016>, ILOMDAO00016
    {
        [Transaction(TransactionPropagation.Required)]
        public int SelectMaxId()
        {
            IQuery query = this.Session.GetNamedQuery("PledgeDAO.SelectMaxId");
            LOMDTO00016 dto = query.UniqueResult<LOMDTO00016>();
            return dto.Id;
        }

        public IList<LOMDTO00016> SelectPledgeInfoByLoanNoandSourcebr(string lno, string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("SelectPledgeInfoByLoanNoandSourcebr");
            query.SetString("lno", lno);
            query.SetString("sourcebr", sourcebr);
            IList<LOMDTO00016> pledgeDtoList = query.List<LOMDTO00016>();
            return pledgeDtoList;
        }

        public bool UpdatePledgeInfoByLoanNoAndSourceBr(int id, string lno,string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("LOMDAO00016.UpdatePledgeInfoByLoanNoAndSourceBr");
            //query.SetString("stockNo", pledgeDto.StockNo);
            //query.SetDecimal("stockqty", Convert.ToDecimal(pledgeDto.StockQTY));
            //query.SetDecimal("marketvalue", Convert.ToDecimal(pledgeDto.Market_VAL));
            //query.SetString("isType", pledgeDto.IsType);
            //query.SetDateTime("isDate", Convert.ToDateTime(pledgeDto.IsDate));
            //query.SetDateTime("isEdate", Convert.ToDateTime(pledgeDto.IsExpiredDate));
            //query.SetDecimal("isAmt", Convert.ToDecimal(pledgeDto.IsAMT));
            query.SetInt32("id", id);
            query.SetString("lno", lno);
            query.SetString("sourcebr", sourcebr);
            //query.SetDateTime("updatedDate", pledgeDto.CreatedDate);
            //query.SetInt32("updatedUserId", pledgeDto.CreatedUserId);
            return query.ExecuteUpdate() > 0;
         }
    }
}
