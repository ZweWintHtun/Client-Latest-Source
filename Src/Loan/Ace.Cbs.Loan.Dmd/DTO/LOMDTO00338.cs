using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Loan.Dmd
{
    //Created by HWKO (13-Dec-2017)
    [Serializable]
    public class LOMDTO00338
    {
        public LOMDTO00338() { }

        //User for LOMDAO00311.GetBLPGInfoForContractPrinting
        public LOMDTO00338(decimal loanAmt, string acctNo, string custName, string custnrc, string custaddress,
            string guaname, string guanrc, string guaaddress, decimal rchgrate, string termno)
        {
            this.LoanAmount = loanAmt;
            this.AcctNo = acctNo;
            this.CustName = custName;
            this.CustNRC = custnrc;
            this.CustAddress = custaddress;
            this.GuaName = guaname;
            this.GuaNRC = guanrc;
            this.GuaAddress = guaaddress;
            this.RChgRate = rchgrate;
            this.TermNo = termno;
        }

        public LOMDTO00338(decimal loanamt, string acctno,string lno, string custname, string custnrc, string custaddress,
            decimal rchgrate, string termno, string stockgroup, string stockitem)
        {
            this.LoanAmount = loanamt;
            this.AcctNo = acctno;
            this.Lno = lno;
            this.CustName = custname;
            this.CustNRC = custnrc;
            this.CustAddress = custaddress;
            this.RChgRate = rchgrate;
            this.TermNo = termno;
            this.StockGroupDesp = stockgroup;
            this.StockItemDesp = stockitem;
        }

        public LOMDTO00338(decimal loanamt, string acctno, string lno, string custname, string custnrc, string custaddress,
            decimal rchgrate, string termno)
        {
            this.LoanAmount = loanamt;
            this.AcctNo = acctno;
            this.Lno = lno;
            this.CustName = custname;
            this.CustNRC = custnrc;
            this.CustAddress = custaddress;
            this.RChgRate = rchgrate;
            this.TermNo = termno;
        }

        public LOMDTO00338(decimal loanamt, string acctno, string lno, string custname, string custnrc, string custaddress,
            decimal rchgrate, string termno, decimal downPayment, string custNameCustNRC, string custFatherName)
        {
            this.LoanAmount = loanamt;
            this.AcctNo = acctno;
            this.Lno = lno;
            this.CustName = custname;
            this.CustNRC = custnrc;
            this.CustAddress = custaddress;
            this.RChgRate = rchgrate;
            this.TermNo = termno;
            this.DownPayment = downPayment;
            this.CustNameCustNRC = custNameCustNRC;
            this.CustFatherName = custFatherName;
        }

        public LOMDTO00338(decimal loanamt, string acctno, string lno, string custname, string custnrc, string custaddress,
            decimal rchgrate, string termno, decimal downPayment, string custNameCustNRC, string custFatherName,
            string custNameCustNRCConcatFromView, string custNameConcatFromView, string custNRCConcatFromView, string custFatherNameConcatFromView, string custAddressForOneConcatFromView, string custNameConcatWithEnterFromView, string custNameCustNRCConcatWithEnterFromView)
        {
            this.LoanAmount = loanamt;
            this.AcctNo = acctno;
            this.Lno = lno;
            this.CustName = custname;
            this.CustNRC = custnrc;
            this.CustAddress = custaddress;
            this.RChgRate = rchgrate;
            this.TermNo = termno;
            this.DownPayment = downPayment;
            this.CustNameCustNRC = custNameCustNRC;
            this.CustFatherName = custFatherName;
            this.CustNameCustNRCConcatFromView = custNameCustNRCConcatFromView;
            this.CustNameConcatFromView = custNameConcatFromView;
            this.CustNRCConcatFromView = custNRCConcatFromView; 
            this.CustFatherNameConcatFromView = custFatherNameConcatFromView;
            this.CustAddressForOneConcatFromView = custAddressForOneConcatFromView;
            this.CustNameConcatWithEnterFromView = custNameConcatWithEnterFromView;
            this.CustNameCustNRCConcatWithEnterFromView = custNameCustNRCConcatWithEnterFromView;
        }

        public virtual string Lno { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual DateTime DateFromView { get; set; }

        public virtual string CustNameCustNRCConcatFromView { get; set; }
        public virtual string CustNameCustNRCConcatWithEnterFromView { get; set; }
        public virtual string CustNameConcatFromView { get; set; }
        public virtual string CustNRCConcatFromView { get; set; }
        public virtual string CustFatherNameConcatFromView { get; set; }
        public virtual string CustAddressForOneConcatFromView { get; set; }
        public virtual string CustNameConcatWithEnterFromView { get; set; }

        public virtual decimal LoanAmount { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual string CustName { get; set; }
        public virtual string CustNRC { get; set; }
        
        public virtual string CustFatherName { get; set; }

        public virtual string CustNameCustNRC { get; set; }
        
        public virtual string CustAddress { get; set; }
        public virtual string GuaName { get; set; }
        public virtual string GuaNRC { get; set; }
        public virtual string GuaAddress { get; set; }

        public virtual decimal DownPayment { get; set; }

        public virtual decimal RChgRate { get; set; }
        public virtual string TermNo { get; set; }
        public virtual DateTime DueDate { get; set; }
        public virtual decimal InstallAmtPerTerm { get; set; }
        public virtual decimal RChgAmtPerTerm { get; set; }
        public virtual DateTime FTDueDate { get; set; }//First Term Due Date
        public virtual DateTime LTDueDate { get; set; }//Last Term Due Date
        public virtual decimal TotalInstallmentAmt { get; set; }//Total Installment Amt without Down Payment for all terms

        public virtual string StockGroupDesp { get; set; }
        public virtual string StockItemDesp { get; set; }
        public virtual string CustCompanyName { get; set; }
    }
}
