using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Mnm.Dmd
{
    [Serializable]
    public class MNMORM00001 : EntityBase<MNMORM00001>
    {
        public MNMORM00001()
        { }

        public virtual int Id { get; set; }
        public virtual string PostingName { get; set; }
        public virtual System.Nullable<DateTime> Date_time { get; set; }
        public virtual string Status { get; set; }
        public virtual string UID { get; set; }
        public virtual string SourceBr { get; set; }
    }
}
