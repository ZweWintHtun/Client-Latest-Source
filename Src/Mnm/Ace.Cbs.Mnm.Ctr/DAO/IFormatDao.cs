using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Mnm.Ctr.Dao
{
    public interface IFormatDao
    {
        IList<FormatDefinitionDTO> SelectFormatDefinitionByCodeAndPortionCode(string code, string branchCode);
    }
}
