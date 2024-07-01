using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    /// <summary>
    /// Counter Version DTO Entity
    /// </summary>
    [Serializable]
    public class PFMDTO00030 : EntityBase<PFMDTO00030>
    { 
        public PFMDTO00030() { }

        public string CounterId { get; set; }
        public int ServerVersionId { get; set; }
        public int Status { get; set; }
    }
}