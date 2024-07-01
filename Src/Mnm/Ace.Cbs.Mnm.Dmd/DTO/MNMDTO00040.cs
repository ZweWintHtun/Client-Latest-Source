using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Mnm.Dmd
{
      [Serializable]
    public class MNMDTO00040 : Supportfields<MNMDTO00040>
    {
        public MNMDTO00040() { }

        public MNMDTO00040(decimal startAmount, decimal endAmount, string sourcebr)
        {
            this.StartAmount = startAmount;
            this.EndAmount = endAmount;
            this.SourceBr = sourcebr;
        }

        public MNMDTO00040(decimal startAmount, decimal endAmount, string currency, string sourcebr)
        {
            this.StartAmount = startAmount;
            this.EndAmount = endAmount;
            this.Cur = currency;
            this.SourceBr = sourcebr;
        }

        public MNMDTO00040(string acctNo, string name, decimal balance, decimal overDrawn_Amount, decimal ovdLimit, string currency)
        {
            this.AcctNo = acctNo;
            this.Name = name;
            this.CBal = balance;
            this.OverDrawn_Amount = overDrawn_Amount;
            this.OvdLimit = ovdLimit;
            this.Cur = currency;
        }

        public MNMDTO00040(string name)
        {
            this.Name = name;
        }

        public virtual int Id { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual decimal CBal { get; set; }
        public virtual decimal OverDrawn_Amount { get; set; }
        public virtual decimal OvdLimit { get; set; }
        public virtual string Cur { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string ACSign { get; set; }
        public virtual decimal StartAmount { get; set; }
        public virtual decimal EndAmount { get; set; }
        public virtual string Name { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Fax { get; set; }
        public virtual string Address { get; set; }
        public virtual string Nrc { get; set; }
        public virtual DateTime OpenDate { get; set; }
        public virtual string TransactionStatus { get; set; }
        public virtual string IsrdoCurrent { get; set; }
        public virtual bool IscheckAllCurrency { get; set; }

    }
}
