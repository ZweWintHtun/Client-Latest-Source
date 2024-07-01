using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Gl.Dmd
{
    [Serializable]
    public class GLMVIW00013
    {
        public GLMVIW00013() { }

        public virtual int Id { get; set; }
        public virtual string ACODE { get; set; }
        public virtual string DCODE { get; set; }
        public virtual string ACNAME { get; set; }
        public virtual string ACTYPE { get; set; }
        public virtual string CBMACODE { get; set; }
        public virtual DateTime PDATE { get; set; }        

    }
}
