using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00212 : EntityBase<LOMDTO00212>
    {
        public LOMDTO00212() { }
        public LOMDTO00212(DateTime startDate, DateTime endDate, string sourceBranch, string currency)
        {
            StartDate = startDate;
            EndDate = endDate;
            SourceBr = sourceBranch;
            Cur = currency;
        }

        public LOMDTO00212(string hpNo, string acctNo, string name, string termNo, string rentalStatus, DateTime rentalPaidDate, DateTime dueDate,
                            decimal rentalChgAmt,decimal totalLateFees,decimal totalODAmt,decimal total,string ph,string address)
        {
            HPNo = hpNo;
            AcctNo = acctNo;
            NAME = name;
            TermNo = termNo;
            RentalChgPaidStatus = rentalStatus;
            RentalChgPaidDate = rentalPaidDate;
            DueDate = dueDate;
            RentalChgAmt = rentalChgAmt;
            TotalLateFees = totalLateFees;
            TotalODAmount = totalODAmt;
            Total = total;
            PHONE = ph;
            ADDRESS = address;
        }

        //Added by HWKO (15-Aug-2017)
        public LOMDTO00212(string hpNo, string acctNo, string name, string termNo, string rentalStatus, DateTime rentalPaidDate, DateTime dueDate,
                            decimal rentalChgAmt, decimal totalLateFees, decimal totalODAmt, decimal total, string ph, string address,decimal ledgerBalance,decimal installmentAmt,string stockGroup)
        {
            HPNo = hpNo;
            AcctNo = acctNo;
            NAME = name;
            TermNo = termNo;
            RentalChgPaidStatus = rentalStatus;
            RentalChgPaidDate = rentalPaidDate;
            DueDate = dueDate;
            RentalChgAmt = rentalChgAmt;
            TotalLateFees = totalLateFees;
            TotalODAmount = totalODAmt;
            Total = total;
            PHONE = ph;
            ADDRESS = address;
            LedgerBalance = ledgerBalance;
            InstallmentAmount = installmentAmt;
            StockGroup = stockGroup;
        }
        
        public virtual string HPNo { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual string NAME { get; set; }
        public virtual string TermNo { get; set; }
        public virtual string RentalChgPaidStatus { get; set; }
        public virtual DateTime RentalChgPaidDate { get; set; }
        public virtual DateTime DueDate { get; set; }
        public virtual decimal RentalChgAmt { get; set; }
        public virtual decimal TotalLateFees { get; set; }
        public virtual decimal TotalODAmount { get; set; }
        public virtual decimal Total { get; set; }
        public virtual string PHONE { get; set; }
        public virtual string ADDRESS { get; set; }
        public virtual decimal LedgerBalance { get; set; }//Added by HWKO (15-Aug-2017)
        public virtual decimal InstallmentAmount { get; set; } // Added by HWKO (15-Sep-2017)
        public virtual string StockGroup { get; set; }//Added By AAM(08-Nov-2017)

        public string DateDisplay
        {
            get { return (RentalChgPaidDate.ToString("dd-MM-yyyy") == "01-01-0001") ? "-" : RentalChgPaidDate.ToString("dd/MM/yyyy"); }
        }

        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }
    }
}
