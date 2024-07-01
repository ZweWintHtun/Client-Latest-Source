using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Pfm.Dmd
{
    /// <summary>
    /// Solidarity Entity
    /// </summary>
    [Serializable]
    public class PFMORM00078 : EntityBase<PFMORM00078>
    {
        public PFMORM00078() { }

        public virtual int Id { get; set; }
        public virtual string GroupNo { get; set; }
        public virtual string NameOnly { get; set; }
        public virtual bool IsNRC { get; set; }
        public virtual bool IsLeader { get; set; }
        public virtual string NRCNo { get; set; }
        public virtual string FatherName { get; set; }
        public virtual string VillageCode { get; set; }
        public virtual string Address { get; set; }
        public virtual DateTime OpenDate { get; set; }
        public virtual string UserNo { get; set; }
        public virtual string SourceBr { get; set; }

        public virtual LOMORM00070 VillageGroupCode { get; set; }
    }
}
