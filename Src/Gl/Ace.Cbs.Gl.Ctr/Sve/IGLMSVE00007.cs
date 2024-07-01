using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Gl.Dmd;

namespace Ace.Cbs.Gl.Ctr.Sve
{
    public interface IGLMSVE00007 : IBaseService
    {
        IList<GLMDTO00001> GetFormatFileDataList(string formatStatus);
        void Save(GLMDTO00001 viewData);
        void Update(GLMDTO00001 viewData);
        void Delete(IList<GLMDTO00001> deleteList);
    }
}
