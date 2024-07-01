using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMDTO00044 : Supportfields<LOMDTO00044>
    {
        public LOMDTO00044() { }

        public virtual DateTime InterestCalculationDate { get; set; }
    }
}
