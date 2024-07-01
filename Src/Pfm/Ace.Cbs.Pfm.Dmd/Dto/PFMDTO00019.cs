using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    [Serializable]
    public class PFMDTO00019 : Supportfields<PFMDTO00019>
    {
        public PFMDTO00019() { }
        public PFMDTO00019(string symbol)
        {
            this.Symbol = symbol;
        }

        public virtual string ClassCode { get; set; }
        public virtual string Symbol { get; set; }
        public virtual string Description { get; set; }
        public virtual string Portion { get; set; }
    }
}