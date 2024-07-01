using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Mnm.Dmd
{
    [Serializable]
    public class MNMVIW00027
    {
        public MNMVIW00027() { }

        public virtual int Id { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual string Name { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Fax { get; set; }
        public virtual string Address { get; set; }
        public virtual string Nrc { get; set; }
        public virtual string ACSign { get; set; }
        public virtual DateTime OpenDate { get; set; }
    }
}
