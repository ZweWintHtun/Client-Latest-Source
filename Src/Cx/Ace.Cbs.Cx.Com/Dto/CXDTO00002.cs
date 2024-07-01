using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Cx.Com.Dto
{
    /// <summary>
    /// Rate Information Return DTO
    /// </summary>
    ///
    [Serializable]
    public class CXDTO00002 
    {
        public string ExchangeRateString { get; set; }
        public string DenoRateString { get; set; }        
    }
}
