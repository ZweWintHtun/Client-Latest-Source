using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Pfm.Ctr.Dao
{
    public interface IPFMDAO00039 : IDataRepository<PFMORM00039>
    {
        PFMDTO00039 SelectPersonalGuaranteeInfoByLoanNoandSourcebr(string lno, string sourcebr);
        bool UpdatePer_GuaranteeInfoByLoanNoAndSourceBr(PFMDTO00039 per_guaDto);
    }
}