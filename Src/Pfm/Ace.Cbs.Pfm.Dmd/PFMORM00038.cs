using System;
using System.Collections.Generic;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    /// <summary>
    /// Print Location Header ORM Entity
    /// </summary>
    [Serializable]
    public class PFMORM00038 : EntityBase<PFMORM00038>
    {
        public PFMORM00038()
        {
            PrintLocationItems = new List<PFMORM00034>();
        }

        public virtual IList<PFMORM00034> PrintLocationItems { get; set; }
        public virtual string Code { get; set; }
        public virtual string Position { get; set; }
        public virtual string PrinterName { get; set; }
        public virtual int MaximumLine { get; set; }
    }
}