using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Gl.Ctr.Sve
{
    public interface IGLMSVE00012 : IBaseService
    {
        IList<ChargeOfAccountDTO> SelectCOAAccountNameByACTypeL();
        IList<ChargeOfAccountDTO> SelectCOAAccountNameByACode(string acode);
    }
}
