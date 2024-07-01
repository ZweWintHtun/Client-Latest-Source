using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    /// <summary>
    /// LRP99#00 Table
    /// </summary>
     [Serializable]
    public class LOMORM00402 : Supportfields<LOMORM00402>
    {
         public LOMORM00402() { }

         public virtual int Id { get; set; }
         public virtual string LNO { get; set; }
         public virtual string RepayNo { get; set; }
         public virtual string AcctNo { get; set; }
         public virtual System.Nullable<DateTime> Date_Time { get; set; }
         public virtual System.Nullable<decimal> Amount { get; set; }
         public virtual System.Nullable<decimal> Interest { get; set; }
         public virtual string UserNo { get; set; }
         public virtual string UID { get; set; }
         public virtual string SourceBr { get; set; }
         public virtual string Cur { get; set; }
         public virtual System.Nullable<DateTime> SettlementDate { get; set; }

         public virtual string LCState { get; set; }  // 0 ==> decrease , 1 ==> increase
         public virtual System.Nullable<decimal> Old_IntRate { get; set; }//Added by HMW at 30-02-2023 (For "interest rate" change LC Increase)
         public virtual System.Nullable<decimal> New_IntRate { get; set; }//Added by HMW at 30-02-2023 (For "interest rate" change LC Increase)

    }
}
