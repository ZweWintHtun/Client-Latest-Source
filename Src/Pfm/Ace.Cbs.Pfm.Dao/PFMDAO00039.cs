using System;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using System.Collections.Generic;


namespace Ace.Cbs.Pfm.Dao
{
    public class PFMDAO00039 : DataRepository<PFMORM00039>, IPFMDAO00039
    {
        public PFMDTO00039 SelectPersonalGuaranteeInfoByLoanNoandSourcebr(string lno, string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("SelectPersonalGuaranteeInfoByLoanNoandSourcebr");
            query.SetString("lno", lno);
            query.SetString("sourcebr", sourcebr);
            PFMDTO00039 per_guaDto = query.UniqueResult<PFMDTO00039>();
            return per_guaDto;
        }

        public bool UpdatePer_GuaranteeInfoByLoanNoAndSourceBr(PFMDTO00039 per_guaDto)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00039.UpdatePer_GuaranteeInfoByLoanNoAndSourceBr");
            query.SetString("acctno", per_guaDto.AccountNo);
            query.SetString("name", per_guaDto.Name);
            query.SetString("phone", per_guaDto.Phone);
            query.SetString("nrc", per_guaDto.NRC);
            query.SetString("lno", per_guaDto.LNo);
            query.SetString("sourcebr", per_guaDto.BranchCode);
            query.SetDateTime("updatedDate", per_guaDto.CreatedDate);
            query.SetInt32("updatedUserId", per_guaDto.CreatedUserId);
            return query.ExecuteUpdate() > 0;
        }
    }
}