using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Gl.Dmd;

namespace Ace.Cbs.Gl.Ctr.Sve
{
    public interface IGLMSVE00011 : IBaseService
    {
        IList<GLMDTO00001> SelectAllFormatFile(string formatStatus);
        IList<GLMDTO00001> GetPreViewData(int month, string formatType, string formatStatus, string cur);
    }
}
