using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Mnm.Dmd
{
    [Serializable]
    public class MNMDTO00071 : Supportfields<MNMDTO00071>
    {
        public MNMDTO00071()
        { }
        public MNMDTO00071(string accountNo, Nullable<DateTime> closeDate, string currencyCode, Nullable<decimal> amount, string acName)
        {
            this.AccountNo = accountNo;
            this.CloseDate = closeDate;
            this.CurrencyCode = currencyCode;
            this.Amount = amount;
            this.ACName = acName;          
 
        }

        public MNMDTO00071(string accountNo, string type, Nullable<DateTime> datetime, string currency, Nullable<decimal> amount,string acName)
        {
            this.AccountNo = accountNo;
            this.Type = type;
            this.Date_Time = datetime;
            this.CurrencyCode = currency;
            this.Amount = amount;
            this.ACName = acName;
        }

        public string AccountNo { get; set; }
        public string Type { get; set; }
        public Nullable<DateTime> CloseDate { get; set; }
        public String CurrencyCode { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string ACName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Nullable<DateTime> Date_Time { get; set; }
    }
}
