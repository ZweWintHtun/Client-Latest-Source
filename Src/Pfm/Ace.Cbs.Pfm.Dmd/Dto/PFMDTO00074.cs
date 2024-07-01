using System.Collections.Generic;

namespace Ace.Cbs.Pfm.Dmd
{
    [System.Serializable]
    public class PFMDTO00074
    {
        public int TotalRecordCount { get; set; }
        public IList<PFMDTO00001> SearchResultList { get; set; }
    }
}
