using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Tel.Ctr.Ptr
{
   public interface ITLMCTL00072
    {
       ITLMVEW00072 View { get; set; }
       void PrintRemainTransaction();
       void clear();

    }

   public interface ITLMVEW00072
   {
       ITLMCTL00072 Controller { get; set; }

       string AccountNo { get; set; }
       void ClearControls();
       void BindTransactionGridView(IList<PFMDTO00043> prnFileList);
   }
}
