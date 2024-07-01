using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Com.Dmd;
namespace Ace.Cbs.Cx.Com.Dto
{
     [Serializable]
  public class CXDTO00004
    {
      public CXDMD00002 DebitCreditTransaction { get; set; }
      public decimal Amount { get; set; }
      public string AccountNo { get; set; }
      public string ACSign { get; set; }
      public int Force { get; set; }
      public int MinBalCheck { get; set; }
      public bool IsVIP { get; set; }
      public int CreatedUserId { get; set; }
    }
}
