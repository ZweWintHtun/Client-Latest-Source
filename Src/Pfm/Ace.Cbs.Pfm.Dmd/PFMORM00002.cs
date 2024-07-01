using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    [Serializable]
    public class PFMORM00002 : EntityBase<PFMORM00002>
    {
        /// <summary>
        /// CloseBal Entity
        /// </summary>
        public PFMORM00002() { }

        public virtual string AccountNo { get; set; }
        public virtual string Name { get; set; }
        public virtual decimal CloseBalance { get; set; }
        public virtual DateTime CloseDate { get; set; }
        public virtual string CheckNo { get; set; }
        public virtual string AccountSign { get; set; }
        public virtual string UserNo { get; set; }
        public virtual string Cur { get; set; }
        public virtual string SourceBranch { get; set; }
    }
}