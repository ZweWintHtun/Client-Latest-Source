using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Dao;
using NHibernate;

namespace Ace.Cbs.Loan.Dao
{
    public class LOMDAO00079 : DataRepository<LOMORM00079>, ILOMDAO00079
    {
        public LOMDTO00079 SelectPersonalGuaranteeInfoByLoanNoandSourcebr(string lno, string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("PGDAO.SelectPersonalGuaranteeInfoByLoanNoandSourcebr");
            query.SetString("lno", lno);
            query.SetString("sourcebr", sourcebr);
            LOMDTO00079 per_guaDto = query.UniqueResult<LOMDTO00079>();
            return per_guaDto;
        }

        public bool UpdatePGOfFarmLoanByLnoAndSourceBr(LOMDTO00079 pgDto)
        {
            IQuery query = this.Session.GetNamedQuery("PGDAO.UpdatePGOfFarmLoanByLnoAndSourceBr");

            query.SetString("acctNo1", pgDto.AcctNo1);
            query.SetString("name1", pgDto.Name1);
            query.SetString("nrc1", pgDto.NRC1);
            query.SetString("phone1", pgDto.Phone1);
            query.SetString("acctNo2", pgDto.AcctNo2);
            query.SetString("name2", pgDto.Name2);
            query.SetString("nrc2", pgDto.NRC2);
            query.SetString("phone2", pgDto.Phone2);
            query.SetString("userNo", pgDto.USERNO);
            query.SetString("lno", pgDto.Lno);
            query.SetString("sourcebr", pgDto.SourceBr);
            query.SetDateTime("updatedDate", (DateTime)pgDto.UpdatedDate);
            query.SetInt32("updatedUserId", (int)pgDto.UpdatedUserId);

            return query.ExecuteUpdate() > 0;
        }
    }
}
