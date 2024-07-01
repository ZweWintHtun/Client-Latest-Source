using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;
using System.Windows.Forms;

namespace Ace.Cbs.Gl.Dmd
{
    [Serializable]
    public class GLMDTO00024 : Supportfields<GLMDTO00024>
    {
        public GLMDTO00024()
        {

        }
        public GLMDTO00024(System.Nullable<decimal> creditAmt, System.Nullable<decimal> debitAmt, string dateTime, string acType, string desp, System.Nullable<decimal> homeoAmt)
        {           
            this.CreditAmt = CreditAmt;
            this.DebitAmt = DebitAmt;
            this.Date_Time = dateTime;
            this.ACType = acType;
            this.Desp = desp;
            this.HomeoAmt = homeoAmt;
        }

        public GLMDTO00024(string credit_debit, decimal debit, decimal credit)
        {
            this.Credit_Debit = credit_debit;
            this.DEBIT = debit;
            this.CREDIT = credit;
        }

        public GLMDTO00024(string credit_debit, decimal debit, decimal credit, string cur)
        {
            this.Credit_Debit = credit_debit;
            this.DEBIT = debit;
            this.CREDIT = credit;
            this.curcode = cur;
        }
        public virtual int Id { get; set; }
        public virtual System.Nullable<decimal> HomeoAmt { get; set; }
        public virtual string ACode { get; set; }
        public virtual System.Nullable<DateTime> DateTime { get; set; }
        public virtual string Date_Time { get; set; }
        public virtual string ACType { get; set; }
        public virtual string Desp { get; set; }
        public virtual string Workstation { get; set; }
        public virtual string Currency { get; set; }
        public virtual string Sourcebr { get; set; }
        public virtual System.Nullable<decimal> CreditAmt { get; set; }
        public virtual System.Nullable<decimal> DebitAmt { get; set; }
        public virtual int Cash { get; set; }

        public virtual string Credit_Debit { get; set; }
        public virtual System.Nullable<decimal> DEBIT { get; set; }
        public virtual System.Nullable<decimal> CREDIT { get; set; }
        public virtual string curcode { get; set; }

        public virtual int cash { get; set; }
    }
}
