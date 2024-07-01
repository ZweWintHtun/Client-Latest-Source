using System.Collections.Generic;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    /// <summary>
    /// Account Type ORM Object
    /// </summary>
    public class PFMORM00015 : EntityBase<PFMORM00015>
    {
        public virtual string Code { get; set; }
        public virtual string Description { get; set; }
        public virtual string Symbol { get; set; }
        public virtual IList<PFMORM00022> SubAccountTypes { get; set; }
    }
}