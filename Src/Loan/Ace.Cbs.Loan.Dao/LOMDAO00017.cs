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
    /// Hypothecation DAO
    /// </summary>
    public class LOMDAO00017 : DataRepository<LOMORM00017>, ILOMDAO00017
    {
        public LOMDTO00017 SelectHypothecationInfoByLoanNoandSourcebr(string lno, string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("SelectHypothecationInfoByLoanNoandSourcebr");
            query.SetString("lno", lno);
            query.SetString("sourcebr", sourcebr);
            LOMDTO00017 HypothecationDto = query.UniqueResult<LOMDTO00017>();
            return HypothecationDto;
        }

        public bool UpdateHypothecationInfoByLoanNoAndSourceBr(LOMDTO00017 hypothecationDto)
        {
            IQuery query = this.Session.GetNamedQuery("LOMDAO00017.UpdateHypothecationInfoByLoanNoAndSourceBr");
            query.SetString("kstockNo", hypothecationDto.KStock);
            query.SetDecimal("value", Convert.ToDecimal(hypothecationDto.Value));
            query.SetString("isType", hypothecationDto.IsType);
            query.SetDateTime("isDate", Convert.ToDateTime(hypothecationDto.IsDate));
            query.SetDateTime("isEdate", Convert.ToDateTime(hypothecationDto.IsExpiredDate));
            query.SetDecimal("isAmt", Convert.ToDecimal(hypothecationDto.IsAMT));
            query.SetString("lno", hypothecationDto.LNo);
            query.SetString("sourcebr", hypothecationDto.SourceBr);
            query.SetDateTime("updatedDate", Convert.ToDateTime(hypothecationDto.UpdatedDate));
            query.SetInt32("updatedUserId", Convert.ToInt32(hypothecationDto.UpdatedUserId));
            return query.ExecuteUpdate() > 0;
        }
    }
}
