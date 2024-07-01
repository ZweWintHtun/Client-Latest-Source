using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00211: EntityBase<LOMDTO00211>
    {
        public LOMDTO00211() { }
        public LOMDTO00211(DateTime startDate,DateTime endDate,string sourceBranch, string currency)
        {
            StartDate = startDate;
            EndDate = endDate;
            SourceBr = sourceBranch;
            Cur = currency;
        }
        //t.HPNo,t.AcctNo,v.NAME,a.PaidTerm,b.PaidDate,SUM(Amount)AS TotalPaidInstallAmt,SUM(RentalChgAmt)AS TotalPaidRentalChgAmt
        public LOMDTO00211(string hpNo, string acctNo, string name, string paidTerm, DateTime paidDate, decimal totalPaidInstallAmt, decimal totalPaidRentalChgAmt, string stockGroupCode)
        {
            HPNo = hpNo;
            AcctNo = acctNo;
            NAME = name;
            PaidTerm = paidTerm;
            PaidDate = paidDate;
            TotalPaidInstallAmt = totalPaidInstallAmt;
            TotalPaidRentalChgAmt = totalPaidRentalChgAmt;
            StockGroup = stockGroupCode;
        }
        
        public virtual string HPNo { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual string NAME { get; set; }
        public virtual string PaidTerm { get; set; }
        public virtual DateTime PaidDate { get; set; }
        public virtual decimal TotalPaidInstallAmt { get; set; }
        public virtual decimal TotalPaidRentalChgAmt { get; set; }
        public virtual string StockGroup { get; set; }

        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }
    }
}
