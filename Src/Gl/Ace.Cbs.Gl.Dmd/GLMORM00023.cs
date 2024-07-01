using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Gl.Dmd
{
     [Serializable]
    public class GLMORM00023 : EntityBase<GLMORM00023>
    {
         // Monthly_coa
         public GLMORM00023() { }

         public virtual int Id { get; set; }
         public virtual char TYPE { get; set; }
         public virtual string ITEM { get; set; }
         public virtual string SUBITEM { get; set; }
         public virtual string ACODE { get; set; }
         public virtual string TITLE { get; set; }
         public virtual string SUBTITLE { get; set; }
         public virtual System.Nullable<decimal> Opening_bal { get; set; }
         public virtual System.Nullable<decimal> Closing_bal { get; set; }
         public virtual System.Nullable<decimal> Credit_Amount { get; set; }
         public virtual System.Nullable<decimal> Debit_Amount { get; set; }
         public virtual string DCode { get; set; }
         public virtual string OtherBankGroupTitle { get; set; }
         public virtual int SUBITEM_No { get; set; }//Added by HMW
    }
}
