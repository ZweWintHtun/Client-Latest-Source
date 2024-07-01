using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Gl.Dmd;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Gl.Ctr.Sve
{
    public interface IGLMSVE00013 : IBaseService
    {
        IList<GLMDTO00013> SelectDataVW_COA_List(string sourceBr);
    }
}
