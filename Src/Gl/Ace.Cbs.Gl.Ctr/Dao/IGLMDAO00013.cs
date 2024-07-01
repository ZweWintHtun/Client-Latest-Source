using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Gl.Dmd;
using Ace.Windows.Core.Dao;

namespace Ace.Cbs.Gl.Ctr.Dao
{
    public interface IGLMDAO00013 : IDataRepository<GLMVIW00013>
    {
        IList<GLMDTO00013> SelectDataOrderByACode(string sourceBr);
    }
}
