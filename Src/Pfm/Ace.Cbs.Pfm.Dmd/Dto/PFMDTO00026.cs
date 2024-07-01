using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    // AcStru dto
    [Serializable]
    public class PFMDTO00026 : Supportfields<PFMDTO00026>
    {
        public PFMDTO00026() { }

        public virtual int Id { get; set; }
        public virtual string Portion { get; set; }
        public virtual int StartNo { get; set; }
        public virtual int Length { get; set; }
    }
}