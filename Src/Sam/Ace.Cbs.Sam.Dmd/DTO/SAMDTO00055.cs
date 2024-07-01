using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Sam.Dmd.DTO
{
    /// <summary>
    /// Code Listing DTO
    /// </summary>
    [Serializable]
   public class SAMDTO00055
    {
        public string CodeType { get; set; }
        public int SerialNo { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string UserNo { get; set; }
    }
}
