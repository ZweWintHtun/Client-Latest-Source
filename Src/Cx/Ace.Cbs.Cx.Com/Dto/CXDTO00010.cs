using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Cx.Com.Dto
{
     [Serializable]
  public  class CXDTO00010
    {
         public CXDTO00010() { }
         public string ENO { get; set; }
         public string MACCTNO { get; set; }
         public string LNO { get; set; }
         public string NAR { get; set; }
         public decimal AMOUNT { get; set; }
         public decimal OAMOUNT { get; set; }
         public string USERNO { get; set; }
         public string VOUSTATUS { get; set; }
         public bool TSTATUS { get; set; }
         public string CUR { get; set; }
         public decimal HOMEEXRATE { get; set; }
         public string SOURCEBR { get; set; }
         public DateTime SETTLEMENTDATE { get; set; }
         public string CHANNEL { get; set; }
         public bool RETVALUE { get; set; }
         public string MESSAGE { get; set; }
     } 
}
