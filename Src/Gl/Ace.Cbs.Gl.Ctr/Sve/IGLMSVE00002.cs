using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Gl.Ctr.Sve
{
    public interface IGLMSVE00002:IBaseService
    {
        IList<MNMDTO00010> GetCCOADataList();
        bool UpdateCCOAListForOpeningBalanceEntry(IList<MNMDTO00010> editedCCOADataList,bool IsDelete);  //IsDelete == true , update OBAL=0 and HOBAL=0       
    }
}
