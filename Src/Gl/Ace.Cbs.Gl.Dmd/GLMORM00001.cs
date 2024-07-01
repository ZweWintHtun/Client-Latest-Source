using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Gl.Dmd
{
    [Serializable]
    public class GLMORM00001 : EntityBase<GLMORM00001>
    {
        public GLMORM00001() { }

        public virtual int Id { get; set; }
        public virtual string FormatType { get; set; }
        public virtual string FormatName { get; set; }
        public virtual int LineNo { get; set; }
        public virtual string ACode { get; set; }
        public virtual string DCode { get; set; }
        public virtual string Description { get; set; }
        public virtual string AccountRange1 { get; set; }
        public virtual string AccountRange2 { get; set; }
        public virtual string LineRange1 { get; set; }
        public virtual string LineRange2 { get; set; }
        public virtual string Other { get; set; }
        public virtual string Status { get; set; }
        public virtual string ShowHide { get; set; }
        public virtual string AmountTotal { get; set; }
        public virtual string FormatStatus { get; set; }
        public virtual string Normal { get; set; }
        public virtual string UId { get; set; }
    }
}
