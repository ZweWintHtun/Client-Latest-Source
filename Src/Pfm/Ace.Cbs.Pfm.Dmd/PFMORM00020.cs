using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    /// <summary>
    /// Used Cheque DTO Entity
    /// </summary>
    [Serializable]
    public class PFMORM00020 : EntityBase<PFMDTO00020>
    {
        public PFMORM00020() { }

        public virtual string ChequeNo { get; set; }
        public virtual string AccountNo { get; set; }
        public virtual string AccountSignature { get; set; }
        public virtual string Channel { get; set; }
        public virtual Nullable<DateTime> DATE_TIME { get; set; }
        public virtual string USERNO { get; set; }
        public virtual string SourceBranchCode { get; set; }
    }
}