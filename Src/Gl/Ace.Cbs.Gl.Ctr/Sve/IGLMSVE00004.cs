using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Ctr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Gl.Ctr.Sve
{
    public interface IGLMSVE00004
    {
        IList<MNMDTO00010> GetCCOADataList(bool isHomeCur);
        bool UpdateCCOAList(IList<MNMDTO00010> editedlist, bool isHomeCur, bool isDelete);
        bool DeleteAllCCOAList(IList<MNMDTO00010> deleteList, bool isHomeCur);
    }
}
