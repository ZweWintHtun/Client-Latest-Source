using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    [Serializable]
    public class PFMDTO00073 : EntityBase<PFMDTO00073>
    {
        /// <summary>
        /// Freeze DTO Entity
        /// </summary>
        public PFMDTO00073() { }
        public PFMDTO00073(string AccountNO) 
        {
            this.AccountNo = AccountNO;
        }

        public virtual string AccountNo { get; set; }
        public virtual string Reason { get; set; }
        public virtual DateTime FreezeDate { get; set; }
        public virtual string FreezeType { get; set; }
        public virtual string BranchCode { get; set; }
    }
}