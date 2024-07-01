using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    //Sys001 dto
    [Serializable]
    public class PFMDTO00069 : Supportfields<PFMDTO00069>
    {
        public PFMDTO00069() { }
        
        public virtual string Name { get; set; }
        public virtual string SysMonYear { get; set; }
        public virtual string Status { get; set; }
        public virtual DateTime SysDate { get; set; }
        public virtual string SysQty { get; set; }
        public virtual string SourceBranchCode { get; set; }


    }
}