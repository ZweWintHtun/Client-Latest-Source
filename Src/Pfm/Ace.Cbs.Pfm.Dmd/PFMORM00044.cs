using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    //Pass Book->Transaction Printion->Printing User
    [Serializable]
    public class PFMORM00044 : EntityBase<PFMORM00044>
    {
        public PFMORM00044() { }

        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public virtual DateTime UsedDate { get; set; }
        public virtual string ConfirmPassword { get; set; }
        public virtual string SourceBranchCode { get; set; }

    }
}