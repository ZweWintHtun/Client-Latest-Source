using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    /// <summary>
    /// Print Location Item ORM Entity
    /// </summary>
    [Serializable]
    public class PFMORM00034 : EntityBase<PFMORM00034>
    {
        public PFMORM00034()
        { }

        public virtual int PrintLocationHeaderId { get; set; }
        public virtual PFMORM00038 PrintLocationHeader { get; set; }
        public virtual string FontSize { get; set; }
        public virtual int XLocation { get; set; }
        public virtual int YLocation { get; set; }
        public virtual int LineNumber { get; set; }
        public virtual int Alignment { get; set; }
        public virtual int Length { get; set; }
    }
}