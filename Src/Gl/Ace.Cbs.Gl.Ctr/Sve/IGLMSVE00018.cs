using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Gl.Dmd;

namespace Ace.Cbs.Gl.Ctr.Sve
{
    public interface IGLMSVE00018 : IBaseService
    {
        IList<GLMDTO00001> GetAllFormatFile(string formatType, string formatStatus);
        void Save(IList<GLMDTO00001> FormatFileDataList);
        void Delete(IList<GLMDTO00001> FormatFileDeleteList);
        //string GetDescription(string aCode);
    }
}
