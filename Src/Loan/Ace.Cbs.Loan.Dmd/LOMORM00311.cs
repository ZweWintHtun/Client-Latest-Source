using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMORM00311 : Supportfields<LOMORM00311>
    {
        public LOMORM00311() { }

        public virtual string PLNo { get; set; }
        public virtual string ACNo { get; set; }
        public virtual string BType { get; set; }
        public virtual DateTime SDate { get; set; }
        public virtual decimal SAmt { get; set; }
        public virtual DateTime ExpireDate { get; set; }
        public virtual int Term { get; set; }
        public virtual int RepDuration { get; set; }
        public virtual int RepOption { get; set; }
        public virtual decimal IntRate { get; set; }
        public virtual Nullable<decimal> NYIntRate { get; set; }
        public virtual Nullable<decimal> FirstSAmt { get; set; }
        public virtual Nullable<DateTime> LasIntDate { get; set; }
        public virtual bool Vouchered { get; set; }
        public virtual string ACSign { get; set; }
        public virtual string UserNo { get; set; }
        public virtual string Assessor { get; set; }
        public virtual string Lawer { get; set; }
        public virtual Nullable<decimal> MonthlyIncome { get; set; }
        public virtual string MonthlyRepayDate { get; set; }
        public virtual string ProductType { get; set; }
        public virtual string CompanyName { get; set; }
        public virtual Nullable<decimal> DocFee { get; set; }
        public virtual bool LegalCase { get; set; }
        public virtual Nullable<DateTime> LegalDate { get; set; }
        public virtual string LegaLawer { get; set; }
        public virtual Nullable<DateTime> CloseDate { get; set; }
        public virtual bool NPLCase { get; set; }
        public virtual Nullable<DateTime> NPLDate { get; set; }
        public virtual string LastUserNo { get; set; }
        public virtual Nullable<DateTime> LastDate { get; set; }
        public virtual bool Partial { get; set; }
        public virtual Nullable<DateTime> VoucherDate { get; set; }
        public virtual int PartialNo { get; set; }
        public virtual Nullable<decimal> SCharges { get; set; }
        public virtual string TodSerial { get; set; }
        public virtual Nullable<DateTime> TodCloseDate { get; set; }
        public virtual string Charges_Status { get; set; }
        public virtual string MarkNPLUser { get; set; }
        public virtual string NPLReleaseUser { get; set; }
        public virtual string MarkLegalUser { get; set; }
        public virtual string LegalReleaseUser { get; set; }
        public virtual bool isSCharge { get; set; }
        public virtual bool isLateFee { get; set; }
        public virtual string BalStatus { get; set; }
        public virtual string UId { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }       

    }

}
