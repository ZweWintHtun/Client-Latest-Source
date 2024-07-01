using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Utt;
using Microsoft.Reporting.WinForms;
using System.IO;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Cbs.Tcm.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Ctr;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00097 : BaseForm
    {
        #region Properties

        IList<LOMDTO00096> hpRegDataList { get; set; }
        IList<LOMDTO00100> hpPayScheduleDataList { get; set; }
        IList<LOMDTO00202> hpOverDraftList { get; set; }
        IList<LOMDTO00203> hpInsufficientList { get; set; }
        IList<LOMDTO00205> personalLoanInfoList { get; set; }
        IList<LOMDTO00206> businessLoanInterestList { get; set; }
        IList<LOMDTO00207> personalLoansNPLCaseList { get; set; }
        IList<LOMDTO00208> hpDailyPositionList { get; set; }
        IList<LOMDTO00209> hpInformationList { get; set; }
        IList<LOMDTO00210> hpPaymentList { get; set; }
        IList<LOMDTO00211> hpReaymentList { get; set; }
        IList<LOMDTO00212> hpInterestDuePreList { get; set; }
        IList<LOMDTO00213> hpRepaymentScheduleList { get; set; }
        IList<LOMDTO00214> hpAbsentHistoryList { get; set; }
        IList<LOMDTO00215> plAbsentHistoryList { get; set; }
        IList<LOMDTO00216> hpRepaymentHistory_Enquiry { get; set; }
        IList<LOMDTO00217> plRepaymentHistory_Enquiry { get; set; }
        IList<LOMDTO00218> hpLateFeesOutstandingList { get; set; }
        IList<LOMDTO00219> blLateFeesOutstandingList { get; set; }
        IList<LOMDTO00220> hpInstallmentList { get; set; }
        IList<LOMDTO00221> plInstallmentList { get; set; }
        IList<LOMDTO00222> blInstallmentList { get; set; }
        IList<LOMDTO00223> plDailyPositionList { get; set; }
        IList<LOMDTO00224> hpAutoPaySufficientList { get; set; }
        IList<LOMDTO00225> plAutoPaySufficientList { get; set; }
        IList<LOMDTO00226> blAutoPaySufficientList { get; set; }
        IList<LOMDTO00227> blOverDraftList { get; set; }
        IList<LOMDTO00230> hpTODRepaymentList { get; set; }
        IList<LOMDTO00230> plTODRepaymentList { get; set; }
        IList<LOMDTO00230> blTODRepaymentList { get; set; }
        IList<LOMDTO00231> accountClosedList { get; set; }
        IList<LOMDTO00232> transferTransactionList { get; set; }
        //List<LOMDTO00233> transferVouPrintList { get; set; }
        List<LOMDTO00234> hpLimit_VoucherPrintList { get; set; }
        List<LOMDTO00235> plLimit_VoucherPrintList { get; set; }
        List<LOMDTO00236> blLimit_VoucherPrintList { get; set; }

        IList<LOMDTO00245> transtList { get; set; }


        string Currency { get; set; }
        string SourceBr { get; set; }
        string head { get; set; }
        string startDate { get; set; }
        string endDate { get; set; }
        string searchDate { get; set; }
        string month { get; set; }
        string year { get; set; }
        string rptName { get; set; }
        string companyName { get; set; }
        string filterStatus { get; set; }

        string HPNo { get; set; }
        string AcctNo { get; set; }
        string CustName { get; set; }
        string Phone { get; set; }
        string Address { get; set; }
        string stockGroupCode { get; set; }
        string showDate { get; set; }
        string businessType { get; set; }
        string filterRptType { get; set; }
        string interestPaidStatus { get; set; }
        string reversalStatus { get; set; }
        string voucherNo { get; set; }
        public string ParentFormId { get; set; }
        string searchBy { get; set; } 
        #endregion Properties

        #region Constructor

        public LOMVEW00097()
        {
            InitializeComponent();
        }

        public LOMVEW00097(string parentFromId, List<LOMDTO00234> lstsTransferVouPrint,string rptName)
        {
            InitializeComponent();
            this.ParentFormId = parentFromId;
            this.hpLimit_VoucherPrintList = lstsTransferVouPrint;
            this.rptName = rptName;
        }

        public LOMVEW00097(string parentFromId, List<LOMDTO00235> lstsPL_Limits_Voucher, string rptName)
        {
            InitializeComponent();
            this.ParentFormId = parentFromId;
            this.plLimit_VoucherPrintList = lstsPL_Limits_Voucher;
            this.rptName = rptName;
        }

        public LOMVEW00097(string parentFromId, List<LOMDTO00236> lstsBL_Limits_Voucher, string rptName)
        {
            InitializeComponent();
            this.ParentFormId = parentFromId;
            this.blLimit_VoucherPrintList = lstsBL_Limits_Voucher;
            this.rptName = rptName;
        }

        #endregion Constructor

        #region DTO Lists Constructor

        public LOMVEW00097(IList<LOMDTO00096> hpRegdataList, string currency, string header, string sourceBr, string startDate, string endDate, string rptName, string stockGroupCode)
        {
            this.Text = header.Replace("KYT", "MMK");//Updated by HWKO (21-Sep-2017)
            this.head = header.Replace("KYT", "MMK");//Updated by HWKO (21-Sep-2017)
            this.hpRegDataList = hpRegdataList;
            this.Currency = currency.Replace("KYT", "MMK");//Updated by HWKO (21-Sep-2017)
            this.SourceBr = sourceBr;
            this.startDate = startDate;
            this.endDate = endDate;
            this.rptName = rptName;
            this.stockGroupCode = stockGroupCode;
            InitializeComponent();
        }

        public LOMVEW00097(IList<LOMDTO00100> hpPayScheduledataList, string currency, string header, string sourceBr, string month, string rptName)
        {
            this.Text = header.Replace("KYT", "MMK");//Updated by HWKO (21-Sep-2017)
            this.head = header.Replace("KYT", "MMK");//Updated by HWKO (21-Sep-2017)
            this.hpPayScheduleDataList = hpPayScheduledataList;
            this.Currency = currency.Replace("KYT", "MMK");//Updated by HWKO (21-Sep-2017)
            this.SourceBr = sourceBr;
            this.month = month;
            this.rptName = rptName;
            InitializeComponent();
        }

        public LOMVEW00097(IList<LOMDTO00202> hpOverDraftList, string currency, string header, string sourceBr, string rptName, string showDate)
        {
            this.Text = header.Replace("KYT", "MMK");//Updated by HWKO (21-Sep-2017)
            this.head = header.Replace("KYT", "MMK");//Updated by HWKO (21-Sep-2017)
            this.hpOverDraftList = hpOverDraftList;
            this.Currency = currency.Replace("KYT", "MMK");//Updated by HWKO (21-Sep-2017)
            this.SourceBr = sourceBr;
            this.rptName = rptName;
            this.showDate = showDate;
            InitializeComponent();
        }

        public LOMVEW00097(IList<LOMDTO00203> hpInsufficientList, string currency, string header, string sourceBr, string month, string rptName)
        {
            this.Text = header.Replace("KYT", "MMK");//Updated by HWKO (21-Sep-2017)
            this.head = header.Replace("KYT", "MMK");//Updated by HWKO (21-Sep-2017)
            this.hpInsufficientList = hpInsufficientList;
            this.Currency = currency.Replace("KYT", "MMK");//Updated by HWKO (21-Sep-2017)
            this.SourceBr = sourceBr;
            this.month = month;
            this.rptName = rptName;
            InitializeComponent();
        }

        public LOMVEW00097(IList<LOMDTO00205> personalLoanInfoList, string currency, string header, string sourceBr, string startDate, string endDate, string rptName, string filterStatus,string companyName)
        {
            this.Text = header.Replace("KYT","MMK");//Updated by HWKO (21-Sep-2017)
            this.head = header.Replace("KYT", "MMK");//Updated by HWKO (21-Sep-2017)
            this.personalLoanInfoList = personalLoanInfoList;
            this.Currency = currency.Replace("KYT", "MMK");//Updated by HWKO (21-Sep-2017)
            this.SourceBr = sourceBr;
            this.startDate = startDate;
            this.endDate = endDate;
            this.filterStatus = filterStatus;
            this.companyName = companyName;
            this.rptName = rptName;
            InitializeComponent();
        }

        public LOMVEW00097(IList<LOMDTO00205> personalLoanInfoList, string currency, string header, string sourceBr, string companyName, string rptName, string filterStatus)
        {
            this.Text = header.Replace("KYT", "MMK");//Updated by HWKO (21-Sep-2017)
            this.head = header.Replace("KYT", "MMK");//Updated by HWKO (21-Sep-2017)
            this.personalLoanInfoList = personalLoanInfoList;
            this.Currency = currency.Replace("KYT", "MMK");//Updated by HWKO (21-Sep-2017)
            this.SourceBr = sourceBr;
            this.companyName = companyName;
            this.filterStatus = filterStatus;
            this.rptName = rptName;
            InitializeComponent();
        }

        public LOMVEW00097(IList<LOMDTO00206> businessLoanInterestList, string currency, string header, string sourceBr,string month,string year,string rptName)
        {
            this.Text = header.Replace("KYT", "MMK");//Updated by HWKO (21-Sep-2017)
            this.head = header.Replace("KYT", "MMK");//Updated by HWKO (21-Sep-2017)
            this.businessLoanInterestList = businessLoanInterestList;
            this.Currency = currency.Replace("KYT","MMK");//Updated by HWKO (20-Sep-2017)
            this.SourceBr = sourceBr;
            this.month = month;
            this.year = year;
            this.rptName = rptName;
            InitializeComponent();
        }

        public LOMVEW00097(IList<LOMDTO00207> personalLoansNPLCaseList, string currency, string header, string sourceBr, string startDate, string endDate, string rptName)
        {
            this.Text = header.Replace("KYT", "MMK");//Updated by HWKO (21-Sep-2017)
            this.head = header.Replace("KYT", "MMK");//Updated by HWKO (21-Sep-2017)
            this.personalLoansNPLCaseList = personalLoansNPLCaseList;
            this.Currency = currency.Replace("KYT", "MMK");//Updated by HWKO (21-Sep-2017)
            this.SourceBr = sourceBr;
            this.startDate = startDate;
            this.endDate = endDate;
            this.rptName = rptName;
            InitializeComponent();
        }

        //public LOMVEW00097(IList<LOMDTO00208> hpDailyPositionList, string currency, string header, string sourceBr, string rptName,string showDate, string stockGroupCode)
        public LOMVEW00097(IList<LOMDTO00208> hpDailyPositionList, string currency, string header, string sourceBr, string rptName,string stockGroupCode)
        {
            this.Text = header.Replace("KYT", "MMK");//Updated by HWKO (21-Sep-2017)
            this.head = header.Replace("KYT", "MMK");//Updated by HWKO (21-Sep-2017)
            this.hpDailyPositionList = hpDailyPositionList;
            this.Currency = currency.Replace("KYT", "MMK");//Updated by HWKO (21-Sep-2017)
            this.SourceBr = sourceBr;
            this.rptName = rptName;
            this.stockGroupCode = stockGroupCode; // Added By AAM(07-Nov-2017)
            //this.showDate = showDate; // Added By AAM (01-Feb-2018))

            InitializeComponent();
        }

        public LOMVEW00097(IList<LOMDTO00209> hpInformationList, string currency, string header, string sourceBr, string startDate, string endDate, string rptName,string stockGroupCode)
        {
            this.Text = header.Replace("KYT", "MMK");//Updated by HWKO (21-Sep-2017)
            this.head = header.Replace("KYT", "MMK");//Updated by HWKO (21-Sep-2017)
            this.hpInformationList = hpInformationList;
            this.Currency = currency.Replace("KYT", "MMK");//Updated by HWKO (21-Sep-2017)
            this.SourceBr = sourceBr;
            this.startDate = startDate;
            this.endDate = endDate;
            this.rptName = rptName;
            this.stockGroupCode = stockGroupCode; //Added By AAM(07-Nov-2017)
            InitializeComponent();
        }

        public LOMVEW00097(IList<LOMDTO00210> hpPaymentList, string header, string startDate, string endDate, string currency, string sourceBr, string rptName, string stockGroupCode)
        {
            this.Text = header.Replace("KYT", "MMK");//Updated by HWKO (21-Sep-2017)
            this.head = header.Replace("KYT", "MMK");//Updated by HWKO (21-Sep-2017)
            this.hpPaymentList = hpPaymentList;
            this.startDate = startDate;
            this.endDate = endDate;
            this.Currency = currency.Replace("KYT", "MMK");//Updated by HWKO (21-Sep-2017)
            this.SourceBr = sourceBr;
            this.rptName = rptName;
            this.stockGroupCode = stockGroupCode; //Added By AAM(07-Nov-2017)
            InitializeComponent();
        }

        public LOMVEW00097(IList<LOMDTO00211> hpRepaymentList, string currency, string header, string sourceBr, string startDate, string endDate, string rptName,string stockGroupCode)
        {
            this.Text = header.Replace("KYT", "MMK");//Updated by HWKO (21-Sep-2017)
            this.head = header.Replace("KYT", "MMK");//Updated by HWKO (21-Sep-2017)
            this.hpReaymentList = hpRepaymentList;
            this.Currency = currency.Replace("KYT", "MMK");//Updated by HWKO (21-Sep-2017)
            this.SourceBr = sourceBr;
            this.startDate = startDate;
            this.endDate = endDate;
            this.rptName = rptName;
            this.stockGroupCode = stockGroupCode;//Added By AAM(08-Nov-2017)
            InitializeComponent();
        }

        public LOMVEW00097(IList<LOMDTO00212> hpInterestDuePreList, string currency, string header, string sourceBr, string startDate, string endDate, string rptName, string stockGroupCode,string interestPaidStatus)
        {
            this.Text = header.Replace("KYT", "MMK");//Updated by HWKO (21-Sep-2017)
            this.head = header.Replace("KYT", "MMK");//Updated by HWKO (21-Sep-2017)
            this.hpInterestDuePreList = hpInterestDuePreList;
            this.Currency = currency.Replace("KYT", "MMK");//Updated by HWKO (21-Sep-2017)
            this.SourceBr = sourceBr;
            this.startDate = startDate;
            this.endDate = endDate;
            this.rptName = rptName;
            this.stockGroupCode = stockGroupCode;
            this.interestPaidStatus = interestPaidStatus;
            InitializeComponent();
        }

        public LOMVEW00097(IList<LOMDTO00213> hpRepaymentScheduleList, string currency, string header, string sourceBr, string hpNo,string acctNo,string name,string ph,string address,string rptName)
        {
            this.Text = header.Replace("KYT", "MMK");//Updated by HWKO (21-Sep-2017)
            this.head = header.Replace("KYT", "MMK");//Updated by HWKO (21-Sep-2017)
            this.hpRepaymentScheduleList = hpRepaymentScheduleList;
            this.Currency = currency.Replace("KYT", "MMK");//Updated by HWKO (21-Sep-2017)
            this.SourceBr = sourceBr;
            HPNo = hpNo;
            AcctNo = acctNo;
            CustName = name;
            Phone = ph;
            Address = address;
            this.rptName = rptName;
            InitializeComponent();
        }

        public LOMVEW00097(IList<LOMDTO00214> hpAbsentHistoryList, string header, string sourceBr, string startDate, string endDate, string rptName)
        {
            this.hpAbsentHistoryList = hpAbsentHistoryList;
            this.SourceBr = sourceBr;
            this.startDate = startDate;
            this.endDate = endDate;
            this.head = header;
            this.rptName = rptName;
            InitializeComponent();
        }

        public LOMVEW00097(IList<LOMDTO00215> plAbsentHistoryList, string header, string sourceBr, string startDate, string endDate, string rptName)
        {
            this.plAbsentHistoryList = plAbsentHistoryList;
            this.SourceBr = sourceBr;
            this.startDate = startDate;
            this.endDate = endDate;
            this.head = header;
            this.rptName = rptName;
            InitializeComponent();
        }

        public LOMVEW00097(IList<LOMDTO00216> hpRepaymentHistory_Enquiry, string header, string sourceBr,string rptName)
        {
            this.hpRepaymentHistory_Enquiry = hpRepaymentHistory_Enquiry;
            this.SourceBr = sourceBr;
            this.head = header;
            this.rptName = rptName;
            InitializeComponent();
        }

        public LOMVEW00097(IList<LOMDTO00217> plRepaymentHistory_Enquiry, string header, string sourceBr, string rptName)
        {
            this.plRepaymentHistory_Enquiry = plRepaymentHistory_Enquiry;
            this.SourceBr = sourceBr;
            this.head = header;
            this.rptName = rptName;
            InitializeComponent();
        }

        public LOMVEW00097(IList<LOMDTO00218> hpLateFeesOutstandingList, string currency, string header, string sourceBr, string rptName, string showDate,string searchBy)
        {
            this.hpLateFeesOutstandingList = hpLateFeesOutstandingList;
            this.SourceBr = sourceBr;
            this.Currency = currency;
            this.head = header;
            this.rptName = rptName;
            this.showDate = showDate;
            this.searchBy = searchBy;
            InitializeComponent();
        }

        public LOMVEW00097(IList<LOMDTO00219> blLateFeesOutstandingList, string currency, string header, string sourceBr, string rptName)
        {
            this.blLateFeesOutstandingList = blLateFeesOutstandingList;
            this.SourceBr = sourceBr;
            this.Currency = currency;
            this.head = header;
            this.rptName = rptName;
            InitializeComponent();
        }

        public LOMVEW00097(IList<LOMDTO00220> hpInstallmentList, string currency, string header, string sourceBr, string showDate,string rptName,string stockGroup)
        {
            this.Text = header.Replace("KYT", "MMK");
            this.head = header.Replace("KYT", "MMK");
            this.hpInstallmentList = hpInstallmentList;
            this.Currency = currency.Replace("KYT", "MMK");
            this.SourceBr = sourceBr;
            this.rptName = rptName;
            this.stockGroupCode = stockGroup;
            this.showDate = showDate;

            InitializeComponent();
        }

        public LOMVEW00097(IList<LOMDTO00221> plInstallmentList, string currency, string header, string sourceBr, string showDate, string rptName, string companyName)
        {
            this.Text = header.Replace("KYT", "MMK");
            this.head = header.Replace("KYT", "MMK");
            this.plInstallmentList = plInstallmentList;
            this.Currency = currency.Replace("KYT", "MMK");
            this.SourceBr = sourceBr;
            this.rptName = rptName;
            this.companyName = companyName;
            this.showDate = showDate;

            InitializeComponent();
        }

        public LOMVEW00097(IList<LOMDTO00222> blInstallmentList, string currency, string header, string sourceBr, string showDate, string rptName, string businessType)
        {
            this.Text = header.Replace("KYT", "MMK");
            this.head = header.Replace("KYT", "MMK");
            this.blInstallmentList = blInstallmentList;
            this.Currency = currency.Replace("KYT", "MMK");
            this.SourceBr = sourceBr;
            this.rptName = rptName;
            this.businessType = businessType;
            this.showDate = showDate;

            InitializeComponent();
        }

        public LOMVEW00097(IList<LOMDTO00223> plDailyPositionList, string currency, string header, string sourceBr, string rptName, string companyName)
        {
            this.Text = header.Replace("KYT", "MMK");
            this.head = header.Replace("KYT", "MMK");
            this.plDailyPositionList = plDailyPositionList;
            this.Currency = currency.Replace("KYT", "MMK");
            this.SourceBr = sourceBr;
            this.rptName = rptName;
            this.companyName = companyName;

            InitializeComponent();
        }

        public LOMVEW00097(IList<LOMDTO00224> hpAutoPaySufficientList, string startDate, string endDate, string currency, string header, string sourceBr, string rptName, string stockGroup)
        {
            this.Text = header.Replace("KYT", "MMK");
            this.head = header.Replace("KYT", "MMK");
            this.hpAutoPaySufficientList = hpAutoPaySufficientList;
            this.startDate = startDate;
            this.endDate = endDate;
            this.Currency = currency.Replace("KYT", "MMK");
            this.SourceBr = sourceBr;
            this.rptName = rptName;
            this.stockGroupCode = stockGroup;

            InitializeComponent();
        }

        public LOMVEW00097(IList<LOMDTO00225> plAutoPaySufficientList, string startDate, string endDate, string currency, string header, string sourceBr, string rptName, string companyName)
        {
            this.Text = header.Replace("KYT", "MMK");
            this.head = header.Replace("KYT", "MMK");
            this.plAutoPaySufficientList = plAutoPaySufficientList;
            this.startDate = startDate;
            this.endDate = endDate;
            this.Currency = currency.Replace("KYT", "MMK");
            this.SourceBr = sourceBr;
            this.rptName = rptName;
            this.companyName = companyName;

            InitializeComponent();
        }

        public LOMVEW00097(IList<LOMDTO00226> blAutoPaySufficientList, string startDate, string endDate, string currency, string header, string sourceBr, string rptName, string businessType)
        {
            this.Text = header.Replace("KYT", "MMK");
            this.head = header.Replace("KYT", "MMK");
            this.blAutoPaySufficientList = blAutoPaySufficientList;
            this.startDate = startDate;
            this.endDate = endDate;
            this.Currency = currency.Replace("KYT", "MMK");
            this.SourceBr = sourceBr;
            this.rptName = rptName;
            this.businessType = businessType;

            InitializeComponent();
        }

        public LOMVEW00097(IList<LOMDTO00227> blOverDraftList, string startDate, string endDate, string currency, string header, string sourceBr, string rptName)
        {
            this.Text = header.Replace("KYT", "MMK");
            this.head = header.Replace("KYT", "MMK");
            this.blOverDraftList = blOverDraftList;
            this.startDate = startDate;
            this.endDate = endDate;
            this.Currency = currency.Replace("KYT", "MMK");
            this.SourceBr = sourceBr;
            this.rptName = rptName;

            InitializeComponent();
        }

        public LOMVEW00097(IList<LOMDTO00230> hpTODRepaymentList, string currency, string header, string sourceBr, string startDate, string endDate, string rptName)
        {
            this.Text = header.Replace("KYT", "MMK");
            this.head = header.Replace("KYT", "MMK");
            this.hpTODRepaymentList = hpTODRepaymentList;
            this.startDate = startDate;
            this.endDate = endDate;
            this.Currency = currency.Replace("KYT", "MMK");
            this.SourceBr = sourceBr;
            this.rptName = rptName;

            InitializeComponent();
        }

        public LOMVEW00097(string currency, string header, string sourceBr, string rptName, string startDate, string endDate, IList<LOMDTO00230> plTODRepaymentList)
        {
            this.Text = header.Replace("KYT", "MMK");
            this.head = header.Replace("KYT", "MMK");
            this.plTODRepaymentList = plTODRepaymentList;
            this.startDate = startDate;
            this.endDate = endDate;
            this.Currency = currency.Replace("KYT", "MMK");
            this.SourceBr = sourceBr;
            this.rptName = rptName;

            InitializeComponent();
        }

        public LOMVEW00097(string currency, string header, string rptName, string startDate, string endDate, IList<LOMDTO00230> blTODRepaymentList, string sourceBr)
        {
            this.Text = header.Replace("KYT", "MMK");
            this.head = header.Replace("KYT", "MMK");
            this.blTODRepaymentList = blTODRepaymentList;
            this.startDate = startDate;
            this.endDate = endDate;
            this.Currency = currency.Replace("KYT", "MMK");
            this.SourceBr = sourceBr;
            this.rptName = rptName;

            InitializeComponent();
        }

        public LOMVEW00097(IList<LOMDTO00231> accountClosedList, string sourceBr, string currency, string header, string rptName, string startDate, string endDate)
        {
            this.Text = header.Replace("KYT", "MMK");
            this.head = header.Replace("KYT", "MMK");
            this.accountClosedList = accountClosedList;
            this.startDate = startDate;
            this.endDate = endDate;
            this.Currency = currency.Replace("KYT", "MMK");
            this.SourceBr = sourceBr;
            this.rptName = rptName;

            InitializeComponent();
        }

        public LOMVEW00097(IList<LOMDTO00232> transferTransactionList, string header, string rptName,string dateOption,string tranType,
                           int reverseStatus, string currency, string sourceBr, string showDate, string chkreversalStatus)
        {
            this.Text = header.Replace("KYT", "MMK");
            this.head = header.Replace("KYT", "MMK");
            this.transferTransactionList = transferTransactionList;
            this.showDate=showDate;
            this.Currency = currency.Replace("KYT", "MMK");
            this.SourceBr = sourceBr;
            this.rptName = rptName;
            this.reversalStatus = chkreversalStatus;

            InitializeComponent();
        }
        //Updated By ZMS(21_June_2018)
        //Added By AAM (20_June_2018)
        public LOMVEW00097(IList<LOMDTO00245> transactionList,string cur, string reportHeader,
                            string sourceBr, string showDate, string searchFilter, string orderBy, string reportName)
        {
            this.Text = reportHeader.Replace("KYT", "MMK");
            this.head = reportHeader.Replace("KYT", "MMK");
            this.transtList = transactionList;
            this.showDate = showDate;
            this.rptName = reportName;
            InitializeComponent();
        }
        #endregion DTO Lists Constructor

        #region RDLC Method

        public void HPRegListing_Report()
        {
            this.rpvHPRegListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00016.rdlc";
            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            this.rpvHPRegListing.LocalReport.DataSources.Clear();

            ReportParameter[] para = new ReportParameter[13];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);

            Image img = null;
            //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            //{
            //    img = System.Drawing.Image.FromStream(stream);
            //    img.Save(tempFilePath);
            //}

            string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

            para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[5] = new ReportParameter("Currency", this.Currency);
            para[6] = new ReportParameter("BrCode", this.SourceBr);
            para[7] = new ReportParameter("Br_Alias", Branch.BranchAlias);
            para[8] = new ReportParameter("TotalRecords", Convert.ToString(hpRegDataList.Count));

            para[9] = new ReportParameter("Title", this.head);
            para[10] = new ReportParameter("StartDate", this.startDate);
            para[11] = new ReportParameter("EndDate", this.endDate);
            para[12] = new ReportParameter("StockGroup", this.stockGroupCode);

            this.rpvHPRegListing.LocalReport.EnableExternalImages = true;
            this.rpvHPRegListing.LocalReport.SetParameters(para);

            ReportDataSource dataset = new ReportDataSource("HPRegListing", this.hpRegDataList);
            this.rpvHPRegListing.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.hpRegDataList;
            this.rpvHPRegListing.RefreshReport();

        }

        public void HPPaymentSchedule_Report()
        {
            try
            {
                this.rpvHPRegListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00017.rdlc";
                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                this.rpvHPRegListing.LocalReport.DataSources.Clear();

                ReportParameter[] para = new ReportParameter[11];
                para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
                para[1] = new ReportParameter("BranchName", Branch.Address);
                para[2] = new ReportParameter("Phone", Branch.Phone);
                para[3] = new ReportParameter("Fax", Branch.Fax);

                Image img = null;
                //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                //{
                //    img = System.Drawing.Image.FromStream(stream);
                //    img.Save(tempFilePath);
                //}

                string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

                para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                para[5] = new ReportParameter("Currency", this.Currency);
                para[6] = new ReportParameter("BrCode", this.SourceBr);
                para[7] = new ReportParameter("Br_Alias", Branch.BranchAlias);
                para[8] = new ReportParameter("TotalRecords", Convert.ToString(hpPayScheduleDataList.Count));
                para[9] = new ReportParameter("Title", this.head);
                para[10] = new ReportParameter("Month", this.month);

                this.rpvHPRegListing.LocalReport.EnableExternalImages = true;
                this.rpvHPRegListing.LocalReport.SetParameters(para);

                ReportDataSource dataset = new ReportDataSource("HPPaymentSchedule", this.hpPayScheduleDataList);
                this.rpvHPRegListing.LocalReport.DataSources.Add(dataset);
                dataset.Value = this.hpPayScheduleDataList;
                this.rpvHPRegListing.RefreshReport();
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public void HPOverDrawnList_Report()
        {
            try
            {
                this.rpvHPRegListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00021.rdlc";
                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                this.rpvHPRegListing.LocalReport.DataSources.Clear();

                ReportParameter[] para = new ReportParameter[11];
                para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
                para[1] = new ReportParameter("BranchName", Branch.Address);
                para[2] = new ReportParameter("Phone", Branch.Phone);
                para[3] = new ReportParameter("Fax", Branch.Fax);

                Image img = null;
                //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                //{
                //    img = System.Drawing.Image.FromStream(stream);
                //    img.Save(tempFilePath);
                //}

                string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

                para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                para[5] = new ReportParameter("Currency", this.Currency);
                para[6] = new ReportParameter("BrCode", this.SourceBr);
                para[7] = new ReportParameter("Br_Alias", Branch.BranchAlias);
                para[8] = new ReportParameter("TotalRecords", Convert.ToString(hpOverDraftList.Count));
                para[9] = new ReportParameter("Title", this.head);
                para[10] = new ReportParameter("ShowDate", this.showDate);

                this.rpvHPRegListing.LocalReport.EnableExternalImages = true;
                this.rpvHPRegListing.LocalReport.SetParameters(para);

                ReportDataSource dataset = new ReportDataSource("HPOverDrawnList", this.hpOverDraftList);
                this.rpvHPRegListing.LocalReport.DataSources.Add(dataset);
                dataset.Value = this.hpOverDraftList;
                this.rpvHPRegListing.RefreshReport();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void HPInsufficientList_Report()
        {
            try
            {
                this.rpvHPRegListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00022.rdlc";
                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                this.rpvHPRegListing.LocalReport.DataSources.Clear();

                ReportParameter[] para = new ReportParameter[11];
                para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
                para[1] = new ReportParameter("BranchName", Branch.Address);
                para[2] = new ReportParameter("Phone", Branch.Phone);
                para[3] = new ReportParameter("Fax", Branch.Fax);

                Image img = null;
                //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                //{
                //    img = System.Drawing.Image.FromStream(stream);
                //    img.Save(tempFilePath);
                //}

                string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

                para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                para[5] = new ReportParameter("Currency", this.Currency);
                para[6] = new ReportParameter("BrCode", this.SourceBr);
                para[7] = new ReportParameter("Br_Alias", Branch.BranchAlias);
                para[8] = new ReportParameter("TotalRecords", Convert.ToString(hpInsufficientList.Count));
                para[9] = new ReportParameter("Title", this.head);
                para[10] = new ReportParameter("Month", this.month);

                this.rpvHPRegListing.LocalReport.EnableExternalImages = true;
                this.rpvHPRegListing.LocalReport.SetParameters(para);

                ReportDataSource dataset = new ReportDataSource("HPInsufficientList", this.hpInsufficientList);
                this.rpvHPRegListing.LocalReport.DataSources.Add(dataset);
                dataset.Value = this.hpInsufficientList;
                this.rpvHPRegListing.RefreshReport();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void PersonalLoanInfoList_Report()
        {
            try
            {
                this.rpvHPRegListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00026.rdlc";
                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                this.rpvHPRegListing.LocalReport.DataSources.Clear();

                ReportParameter[] para = new ReportParameter[13];
                para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
                para[1] = new ReportParameter("BranchName", Branch.Address);
                para[2] = new ReportParameter("Phone", Branch.Phone);
                para[3] = new ReportParameter("Fax", Branch.Fax);

                Image img = null;
                //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                //{
                //    img = System.Drawing.Image.FromStream(stream);
                //    img.Save(tempFilePath);
                //}

                string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

                para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                para[5] = new ReportParameter("Title", this.head);
                para[6] = new ReportParameter("BrCode", this.SourceBr);
                para[7] = new ReportParameter("Br_Alias", Branch.BranchAlias);
                para[8] = new ReportParameter("TotalRecords", Convert.ToString(personalLoanInfoList.Count));
                para[9] = new ReportParameter("StartDate", this.startDate);
                para[10] = new ReportParameter("EndDate", this.endDate);
                para[11] = new ReportParameter("Currency", this.Currency);
                para[12] = new ReportParameter("companyName", this.companyName);

                this.rpvHPRegListing.LocalReport.EnableExternalImages = true;
                this.rpvHPRegListing.LocalReport.SetParameters(para);

                ReportDataSource dataset = new ReportDataSource("PersonalLoanInfoList", this.personalLoanInfoList);
                this.rpvHPRegListing.LocalReport.DataSources.Add(dataset);
                dataset.Value = this.personalLoanInfoList;
                this.rpvHPRegListing.RefreshReport();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void PersonalLoanInfoList_Report_ByCompanyName()
        {
            try
            {
                this.rpvHPRegListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00027.rdlc";
                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                this.rpvHPRegListing.LocalReport.DataSources.Clear();

                ReportParameter[] para = new ReportParameter[11];
                para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
                para[1] = new ReportParameter("BranchName", Branch.Address);
                para[2] = new ReportParameter("Phone", Branch.Phone);
                para[3] = new ReportParameter("Fax", Branch.Fax);

                Image img = null;
                //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                //{
                //    img = System.Drawing.Image.FromStream(stream);
                //    img.Save(tempFilePath);
                //}

                string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

                para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                para[5] = new ReportParameter("Title", this.head);
                para[6] = new ReportParameter("BrCode", this.SourceBr);
                para[7] = new ReportParameter("Br_Alias", Branch.BranchAlias);
                para[8] = new ReportParameter("TotalRecords", Convert.ToString(personalLoanInfoList.Count));
                para[9] = new ReportParameter("CompanyName", this.companyName);
                para[10] = new ReportParameter("Currency", this.Currency);

                this.rpvHPRegListing.LocalReport.EnableExternalImages = true;
                this.rpvHPRegListing.LocalReport.SetParameters(para);

                ReportDataSource dataset = new ReportDataSource("PersonalLoanInfoList", this.personalLoanInfoList);
                this.rpvHPRegListing.LocalReport.DataSources.Add(dataset);
                dataset.Value = this.personalLoanInfoList;
                this.rpvHPRegListing.RefreshReport();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void BusinessLoanInterestList_Report()
        {
            try
            {
                this.rpvHPRegListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00028.rdlc";
                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                this.rpvHPRegListing.LocalReport.DataSources.Clear();

                ReportParameter[] para = new ReportParameter[12];
                para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
                para[1] = new ReportParameter("BranchName", Branch.Address);
                para[2] = new ReportParameter("Phone", Branch.Phone);
                para[3] = new ReportParameter("Fax", Branch.Fax);

                Image img = null;
                //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                //{
                //    img = System.Drawing.Image.FromStream(stream);
                //    img.Save(tempFilePath);
                //}

                string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

                para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                para[5] = new ReportParameter("Title", this.head);
                para[6] = new ReportParameter("BrCode", this.SourceBr);
                para[7] = new ReportParameter("Br_Alias", Branch.BranchAlias);
                para[8] = new ReportParameter("TotalRecords", Convert.ToString(businessLoanInterestList.Count));
                para[9] = new ReportParameter("Month", this.month);
                para[10] = new ReportParameter("Year", this.year);
                para[11] = new ReportParameter("Currency", this.Currency.Replace("KYT","MMK"));//Updated by HWKO (20-Sep-2017)

                this.rpvHPRegListing.LocalReport.EnableExternalImages = true;
                this.rpvHPRegListing.LocalReport.SetParameters(para);

                ReportDataSource dataset = new ReportDataSource("BusinessLoanInterestList", this.businessLoanInterestList);
                this.rpvHPRegListing.LocalReport.DataSources.Add(dataset);
                dataset.Value = this.businessLoanInterestList;
                this.rpvHPRegListing.RefreshReport();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void PersonalLoans_NPLCase_Listing_Report()
        {
            try
            {
                this.rpvHPRegListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00029.rdlc";
                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                this.rpvHPRegListing.LocalReport.DataSources.Clear();

                ReportParameter[] para = new ReportParameter[12];
                para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
                para[1] = new ReportParameter("BranchName", Branch.Address);
                para[2] = new ReportParameter("Phone", Branch.Phone);
                para[3] = new ReportParameter("Fax", Branch.Fax);

                Image img = null;
                //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                //{
                //    img = System.Drawing.Image.FromStream(stream);
                //    img.Save(tempFilePath);
                //}

                string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

                para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                para[5] = new ReportParameter("Title", this.head);
                para[6] = new ReportParameter("BrCode", this.SourceBr);
                para[7] = new ReportParameter("Br_Alias", Branch.BranchAlias);
                para[8] = new ReportParameter("TotalRecords", Convert.ToString(personalLoansNPLCaseList.Count));
                para[9] = new ReportParameter("StartDate", this.startDate);
                para[10] = new ReportParameter("EndDate", this.endDate);
                para[11] = new ReportParameter("Currency", this.Currency);

                this.rpvHPRegListing.LocalReport.EnableExternalImages = true;
                this.rpvHPRegListing.LocalReport.SetParameters(para);

                ReportDataSource dataset = new ReportDataSource("PersonalLoansNPLCaseList", this.personalLoansNPLCaseList);
                this.rpvHPRegListing.LocalReport.DataSources.Add(dataset);
                dataset.Value = this.personalLoansNPLCaseList;
                this.rpvHPRegListing.RefreshReport();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void HPDailyPositionList_Report()
        {
            try
            {
                this.rpvHPRegListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00033.rdlc";
                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                this.rpvHPRegListing.LocalReport.DataSources.Clear();

                ReportParameter[] para = new ReportParameter[11];
                para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
                para[1] = new ReportParameter("BranchName", Branch.Address);
                para[2] = new ReportParameter("Phone", Branch.Phone);
                para[3] = new ReportParameter("Fax", Branch.Fax);

                Image img = null;
                //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                //{
                //    img = System.Drawing.Image.FromStream(stream);
                //    img.Save(tempFilePath);
                //}

                string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

                para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                para[5] = new ReportParameter("Title", this.head);
                para[6] = new ReportParameter("BrCode", this.SourceBr);
                para[7] = new ReportParameter("Br_Alias", Branch.BranchAlias);
                para[8] = new ReportParameter("TotalRecords", Convert.ToString(hpDailyPositionList.Count));
                //para[9] = new ReportParameter("SearchDate", this.searchDate);
                para[9] = new ReportParameter("Currency", this.Currency);
                para[10] = new ReportParameter("StockGroup", this.stockGroupCode);
                //para[11] = new ReportParameter("ShowDate", this.showDate);

                this.rpvHPRegListing.LocalReport.EnableExternalImages = true;
                this.rpvHPRegListing.LocalReport.SetParameters(para);

                ReportDataSource dataset = new ReportDataSource("HPDailyPositionList", this.hpDailyPositionList);
                this.rpvHPRegListing.LocalReport.DataSources.Add(dataset);
                dataset.Value = this.hpDailyPositionList;
                this.rpvHPRegListing.RefreshReport();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void HPInformationList_Report()
        {
            try
            {
                this.rpvHPRegListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00034.rdlc";
                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                this.rpvHPRegListing.LocalReport.DataSources.Clear();

                ReportParameter[] para = new ReportParameter[13];
                para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
                para[1] = new ReportParameter("BranchName", Branch.Address);
                para[2] = new ReportParameter("Phone", Branch.Phone);
                para[3] = new ReportParameter("Fax", Branch.Fax);

                Image img = null;
                string tempFilePath = Application.StartupPath + "\\pristinelogo.png";
                //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                //{
                //    img = System.Drawing.Image.FromStream(stream);
                //    img.Save(tempFilePath);
                //}
                para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                para[5] = new ReportParameter("Title", this.head);
                para[6] = new ReportParameter("BrCode", this.SourceBr);
                para[7] = new ReportParameter("Br_Alias", Branch.BranchAlias);
                para[8] = new ReportParameter("TotalRecords", Convert.ToString(hpInformationList.Count));
                para[9] = new ReportParameter("StartDate", this.startDate);
                para[10] = new ReportParameter("EndDate", this.endDate);
                para[11] = new ReportParameter("Currency", this.Currency);
                para[12] = new ReportParameter("StockGroup", this.stockGroupCode);

                this.rpvHPRegListing.LocalReport.EnableExternalImages = true;
                this.rpvHPRegListing.LocalReport.SetParameters(para);

                ReportDataSource dataset = new ReportDataSource("HPInformationList", this.hpInformationList);
                this.rpvHPRegListing.LocalReport.DataSources.Add(dataset);
                dataset.Value = this.hpInformationList;
                this.rpvHPRegListing.RefreshReport();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void HPPaymentList_Report()
        {
            try
            {
                this.rpvHPRegListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00037.rdlc";
                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                this.rpvHPRegListing.LocalReport.DataSources.Clear();

                ReportParameter[] para = new ReportParameter[13];
                para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
                para[1] = new ReportParameter("BranchName", Branch.Address);
                para[2] = new ReportParameter("Phone", Branch.Phone);
                para[3] = new ReportParameter("Fax", Branch.Fax);

                Image img = null;
                string tempFilePath = Application.StartupPath + "\\pristinelogo.png";
                //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                //{
                //    img = System.Drawing.Image.FromStream(stream);
                //    img.Save(tempFilePath);
                //}
                para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                para[5] = new ReportParameter("Title", this.head);
                para[6] = new ReportParameter("BrCode", this.SourceBr);
                para[7] = new ReportParameter("Br_Alias", Branch.BranchAlias);
                para[8] = new ReportParameter("TotalRecords", Convert.ToString(hpPaymentList.Count));
                para[9] = new ReportParameter("Currency", this.Currency);
                para[10] = new ReportParameter("StartDate", this.startDate);
                para[11] = new ReportParameter("EndDate", this.endDate);
                para[12] = new ReportParameter("StockGroup", this.stockGroupCode);

                this.rpvHPRegListing.LocalReport.EnableExternalImages = true;
                this.rpvHPRegListing.LocalReport.SetParameters(para);

                ReportDataSource dataset = new ReportDataSource("HPPaymentList", this.hpPaymentList);
                this.rpvHPRegListing.LocalReport.DataSources.Add(dataset);
                dataset.Value = this.hpPaymentList;
                this.rpvHPRegListing.RefreshReport();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void HPRepaymentList_Report()
        {
            try
            {
                this.rpvHPRegListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00038.rdlc";
                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                this.rpvHPRegListing.LocalReport.DataSources.Clear();

                ReportParameter[] para = new ReportParameter[13];
                para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
                para[1] = new ReportParameter("BranchName", Branch.Address);
                para[2] = new ReportParameter("Phone", Branch.Phone);
                para[3] = new ReportParameter("Fax", Branch.Fax);

                Image img = null;
                //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                //{
                //    img = System.Drawing.Image.FromStream(stream);
                //    img.Save(tempFilePath);
                //}

                string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

                para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                para[5] = new ReportParameter("Title", this.head);
                para[6] = new ReportParameter("BrCode", this.SourceBr);
                para[7] = new ReportParameter("Br_Alias", Branch.BranchAlias);
                para[8] = new ReportParameter("TotalRecords", Convert.ToString(hpReaymentList.Count));
                para[9] = new ReportParameter("StartDate", this.startDate);
                para[10] = new ReportParameter("EndDate", this.endDate);
                para[11] = new ReportParameter("Currency", this.Currency);
                para[12] = new ReportParameter("StockGroup", this.stockGroupCode);

                this.rpvHPRegListing.LocalReport.EnableExternalImages = true;
                this.rpvHPRegListing.LocalReport.SetParameters(para);

                ReportDataSource dataset = new ReportDataSource("HPRepaymentList", this.hpReaymentList);
                this.rpvHPRegListing.LocalReport.DataSources.Add(dataset);
                dataset.Value = this.hpReaymentList;
                this.rpvHPRegListing.RefreshReport();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void HPInterest_Due_PreList_Report()
        {
            try
            {
                this.rpvHPRegListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00046.rdlc";
                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                this.rpvHPRegListing.LocalReport.DataSources.Clear();

                ReportParameter[] para = new ReportParameter[14];
                para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
                para[1] = new ReportParameter("BranchName", Branch.Address);
                para[2] = new ReportParameter("Phone", Branch.Phone);
                para[3] = new ReportParameter("Fax", Branch.Fax);

                Image img = null;
                //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                //{
                //    img = System.Drawing.Image.FromStream(stream);
                //    img.Save(tempFilePath);
                //}

                string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

                para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                para[5] = new ReportParameter("Title", this.head);
                para[6] = new ReportParameter("BrCode", this.SourceBr);
                para[7] = new ReportParameter("Br_Alias", Branch.BranchAlias);
                para[8] = new ReportParameter("TotalRecords", Convert.ToString(hpInterestDuePreList.Count));
                para[9] = new ReportParameter("StartDate", this.startDate);
                para[10] = new ReportParameter("EndDate", this.endDate);
                para[11] = new ReportParameter("Currency", this.Currency);
                para[12] = new ReportParameter("StockGroup", this.stockGroupCode);
                para[13] = new ReportParameter("InterestPaidStatus", this.interestPaidStatus);

                this.rpvHPRegListing.LocalReport.EnableExternalImages = true;
                this.rpvHPRegListing.LocalReport.SetParameters(para);

                ReportDataSource dataset = new ReportDataSource("HPInterestDuePreList", this.hpInterestDuePreList);
                this.rpvHPRegListing.LocalReport.DataSources.Add(dataset);
                dataset.Value = this.hpInterestDuePreList;
                this.rpvHPRegListing.RefreshReport();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void HP_Repayment_Schedule_List_Report()
        {
            try
            {
                this.rpvHPRegListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00044.rdlc";
                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                this.rpvHPRegListing.LocalReport.DataSources.Clear();

                ReportParameter[] para = new ReportParameter[15];
                para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
                para[1] = new ReportParameter("BranchName", Branch.Address);
                para[2] = new ReportParameter("Phone", Branch.Phone);
                para[3] = new ReportParameter("Fax", Branch.Fax);

                Image img = null;
                //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                //{
                //    img = System.Drawing.Image.FromStream(stream);
                //    img.Save(tempFilePath);
                //}

                string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

                para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                para[5] = new ReportParameter("Title", this.head);
                para[6] = new ReportParameter("BrCode", this.SourceBr);
                para[7] = new ReportParameter("Br_Alias", Branch.BranchAlias);
                para[8] = new ReportParameter("TotalRecords", Convert.ToString(hpRepaymentScheduleList.Count));
                para[9] = new ReportParameter("HPNo", this.HPNo);
                para[10] = new ReportParameter("AccountNo", this.AcctNo);
                para[11] = new ReportParameter("Name", CustName);
                para[12] = new ReportParameter("PhoneNo", this.Phone);
                para[13] = new ReportParameter("Address", this.Address);
                para[14] = new ReportParameter("Currency", this.Currency);

                this.Text = "Hire Purchase Repayment Schedule Listing";
                this.rpvHPRegListing.LocalReport.EnableExternalImages = true;
                this.rpvHPRegListing.LocalReport.SetParameters(para);

                ReportDataSource dataset = new ReportDataSource("HPRepaymentScheduleList", this.hpRepaymentScheduleList);
                this.rpvHPRegListing.LocalReport.DataSources.Add(dataset);
                dataset.Value = this.hpRepaymentScheduleList;
                this.rpvHPRegListing.RefreshReport();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void HP_AbsentHistoryList_Report()
        {
            try
            {
                this.rpvHPRegListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00050.rdlc";
                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                this.rpvHPRegListing.LocalReport.DataSources.Clear();

                ReportParameter[] para = new ReportParameter[11];
                para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
                para[1] = new ReportParameter("BranchName", Branch.Address);
                para[2] = new ReportParameter("Phone", Branch.Phone);
                para[3] = new ReportParameter("Fax", Branch.Fax);

                Image img = null;
                string tempFilePath = Application.StartupPath + "\\pristinelogo.png";
                //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                //{
                //    img = System.Drawing.Image.FromStream(stream);
                //    img.Save(tempFilePath);
                //}
                para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                para[5] = new ReportParameter("Title", this.head);
                para[6] = new ReportParameter("BrCode", this.SourceBr);
                para[7] = new ReportParameter("Br_Alias", Branch.BranchAlias);
                para[8] = new ReportParameter("TotalRecords", Convert.ToString(hpAbsentHistoryList.Count));
                para[9] = new ReportParameter("StartDate", this.startDate);
                para[10] = new ReportParameter("EndDate", this.endDate);

                this.rpvHPRegListing.LocalReport.EnableExternalImages = true;
                this.rpvHPRegListing.LocalReport.SetParameters(para);

                ReportDataSource dataset = new ReportDataSource("HPAbsentHistoryList", this.hpAbsentHistoryList);
                this.rpvHPRegListing.LocalReport.DataSources.Add(dataset);
                dataset.Value = this.hpAbsentHistoryList;
                this.rpvHPRegListing.RefreshReport();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void PL_AbsentHistoryList_Report()
        {
            try
            {
                this.rpvHPRegListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00051.rdlc";
                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                this.rpvHPRegListing.LocalReport.DataSources.Clear();

                ReportParameter[] para = new ReportParameter[11];
                para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
                para[1] = new ReportParameter("BranchName", Branch.Address);
                para[2] = new ReportParameter("Phone", Branch.Phone);
                para[3] = new ReportParameter("Fax", Branch.Fax);

                Image img = null;
                string tempFilePath = Application.StartupPath + "\\pristinelogo.png";
                //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                //{
                //    img = System.Drawing.Image.FromStream(stream);
                //    img.Save(tempFilePath);
                //}
                para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                para[5] = new ReportParameter("Title", this.head);
                para[6] = new ReportParameter("BrCode", this.SourceBr);
                para[7] = new ReportParameter("Br_Alias", Branch.BranchAlias);
                para[8] = new ReportParameter("TotalRecords", Convert.ToString(plAbsentHistoryList.Count));
                para[9] = new ReportParameter("StartDate", this.startDate);
                para[10] = new ReportParameter("EndDate", this.endDate);

                this.rpvHPRegListing.LocalReport.EnableExternalImages = true;
                this.rpvHPRegListing.LocalReport.SetParameters(para);

                ReportDataSource dataset = new ReportDataSource("PLAbsentHistoryList", this.plAbsentHistoryList);
                this.rpvHPRegListing.LocalReport.DataSources.Add(dataset);
                dataset.Value = this.plAbsentHistoryList;
                this.rpvHPRegListing.RefreshReport();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void HP_RepaymentHistory_Enquiry_Report()
        {
            try
            {
                this.rpvHPRegListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00052.rdlc";
                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                this.rpvHPRegListing.LocalReport.DataSources.Clear();

                ReportParameter[] para = new ReportParameter[9];
                para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
                para[1] = new ReportParameter("BranchName", Branch.Address);
                para[2] = new ReportParameter("Phone", Branch.Phone);
                para[3] = new ReportParameter("Fax", Branch.Fax);

                Image img = null;
                //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                //{
                //    img = System.Drawing.Image.FromStream(stream);
                //    img.Save(tempFilePath);
                //}

                string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

                para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                para[5] = new ReportParameter("Title", this.head);
                para[6] = new ReportParameter("BrCode", this.SourceBr);
                para[7] = new ReportParameter("Br_Alias", Branch.BranchAlias);
                para[8] = new ReportParameter("TotalRecords", Convert.ToString(hpRepaymentHistory_Enquiry.Count));

                this.rpvHPRegListing.LocalReport.EnableExternalImages = true;
                this.rpvHPRegListing.LocalReport.SetParameters(para);

                ReportDataSource dataset = new ReportDataSource("HPRepaymentHistory_Enquiry", this.hpRepaymentHistory_Enquiry);
                this.rpvHPRegListing.LocalReport.DataSources.Add(dataset);
                dataset.Value = this.hpRepaymentHistory_Enquiry;
                this.rpvHPRegListing.RefreshReport();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void PL_RepaymentHistory_Enquiry_Report()
        {
            try
            {
                this.rpvHPRegListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00053.rdlc";
                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                this.rpvHPRegListing.LocalReport.DataSources.Clear();

                ReportParameter[] para = new ReportParameter[9];
                para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
                para[1] = new ReportParameter("BranchName", Branch.Address);
                para[2] = new ReportParameter("Phone", Branch.Phone);
                para[3] = new ReportParameter("Fax", Branch.Fax);

                Image img = null;
                //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                //{
                //    img = System.Drawing.Image.FromStream(stream);
                //    img.Save(tempFilePath);
                //}

                string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

                para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                para[5] = new ReportParameter("Title", this.head);
                para[6] = new ReportParameter("BrCode", this.SourceBr);
                para[7] = new ReportParameter("Br_Alias", Branch.BranchAlias);
                para[8] = new ReportParameter("TotalRecords", Convert.ToString(plRepaymentHistory_Enquiry.Count));

                this.rpvHPRegListing.LocalReport.EnableExternalImages = true;
                this.rpvHPRegListing.LocalReport.SetParameters(para);

                ReportDataSource dataset = new ReportDataSource("PLRepaymentHistory_Enquiry", this.plRepaymentHistory_Enquiry);
                this.rpvHPRegListing.LocalReport.DataSources.Add(dataset);
                dataset.Value = this.plRepaymentHistory_Enquiry;
                this.rpvHPRegListing.RefreshReport();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void HPLateFeesOutstandingList_Report()
        {
            try
            {
                this.rpvHPRegListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00055.rdlc";
                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                this.rpvHPRegListing.LocalReport.DataSources.Clear();

                ReportParameter[] para = new ReportParameter[12];
                para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
                para[1] = new ReportParameter("BranchName", Branch.Address);
                para[2] = new ReportParameter("Phone", Branch.Phone);
                para[3] = new ReportParameter("Fax", Branch.Fax);

                Image img = null;
                //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                //{
                //    img = System.Drawing.Image.FromStream(stream);
                //    img.Save(tempFilePath);
                //}

                string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

                para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                para[5] = new ReportParameter("Title", this.head);
                para[6] = new ReportParameter("BrCode", this.SourceBr);
                para[7] = new ReportParameter("Br_Alias", Branch.BranchAlias);
                para[8] = new ReportParameter("TotalRecords", Convert.ToString(hpLateFeesOutstandingList.Count));
                para[9] = new ReportParameter("ShowDate", this.showDate);
                para[10] = new ReportParameter("SearchBy", this.searchBy);

                //Added by HMW at 05-Aug-2019 : To show the actual system date, not PC Date for "Seperating EOD Process"
                TCMDTO00001 StartDTO = CXClientWrapper.Instance.Invoke<ICXSVE00006, TCMDTO00001>(x => x.SelectStartBySourceBr(CurrentUserEntity.BranchCode));
                string SystemDate = StartDTO.Date.ToString("dd MMMM, yyyy");
                para[11] = new ReportParameter("System_Date", SystemDate);

                this.rpvHPRegListing.LocalReport.EnableExternalImages = true;
                this.rpvHPRegListing.LocalReport.SetParameters(para);

                ReportDataSource dataset = new ReportDataSource("HPLateFeesOutstandingList", this.hpLateFeesOutstandingList);
                this.rpvHPRegListing.LocalReport.DataSources.Add(dataset);
                dataset.Value = this.hpLateFeesOutstandingList;
                this.rpvHPRegListing.RefreshReport();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void BLLateFeesOutstandingList_Report()
        {
            try
            {
                this.rpvHPRegListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00065.rdlc";
                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                this.rpvHPRegListing.LocalReport.DataSources.Clear();

                ReportParameter[] para = new ReportParameter[10];
                para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
                para[1] = new ReportParameter("BranchName", Branch.Address);
                para[2] = new ReportParameter("Phone", Branch.Phone);
                para[3] = new ReportParameter("Fax", Branch.Fax);

                Image img = null;
                //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                //{
                //    img = System.Drawing.Image.FromStream(stream);
                //    img.Save(tempFilePath);
                //}

                string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

                para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                para[5] = new ReportParameter("Title", this.head);
                para[6] = new ReportParameter("BrCode", this.SourceBr);
                para[7] = new ReportParameter("Br_Alias", Branch.BranchAlias);
                para[8] = new ReportParameter("TotalRecords", Convert.ToString(blLateFeesOutstandingList.Count));

                //Added by HMW at 05-Aug-2019 : To show the actual system date, not PC Date for "Seperating EOD Process"
                TCMDTO00001 StartDTO = CXClientWrapper.Instance.Invoke<ICXSVE00006, TCMDTO00001>(x => x.SelectStartBySourceBr(CurrentUserEntity.BranchCode));
                string SystemDate = StartDTO.Date.ToString("dd MMMM, yyyy");
                para[9] = new ReportParameter("System_Date", SystemDate);

                this.rpvHPRegListing.LocalReport.EnableExternalImages = true;
                this.rpvHPRegListing.LocalReport.SetParameters(para);

                ReportDataSource dataset = new ReportDataSource("BLLateFeesOutstandingList", this.blLateFeesOutstandingList);
                this.rpvHPRegListing.LocalReport.DataSources.Add(dataset);
                dataset.Value = this.blLateFeesOutstandingList;
                this.rpvHPRegListing.RefreshReport();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void HPInstallmentList_Report()
        {
            try
            {
                this.rpvHPRegListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00066.rdlc";                
                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                this.rpvHPRegListing.LocalReport.DataSources.Clear();

                ReportParameter[] para = new ReportParameter[11];
                para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
                para[1] = new ReportParameter("BranchName", Branch.Address);
                para[2] = new ReportParameter("Phone", Branch.Phone);
                para[3] = new ReportParameter("Fax", Branch.Fax);

                Image img = null;
                //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                //{
                //    img = System.Drawing.Image.FromStream(stream);
                //    img.Save(tempFilePath);
                //}

                string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

                para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                para[5] = new ReportParameter("Title", this.head);
                para[6] = new ReportParameter("BrCode", this.SourceBr);
                para[7] = new ReportParameter("Br_Alias", Branch.BranchAlias);
                para[8] = new ReportParameter("TotalRecords", Convert.ToString(hpInstallmentList.Count));
                para[9] = new ReportParameter("StockGroup", this.stockGroupCode);
                para[10] = new ReportParameter("ShowDate", this.showDate);

                this.rpvHPRegListing.LocalReport.EnableExternalImages = true;
                this.rpvHPRegListing.LocalReport.SetParameters(para);

                ReportDataSource dataset = new ReportDataSource("HPInstallmentList", this.hpInstallmentList);
                this.rpvHPRegListing.LocalReport.DataSources.Add(dataset);
                dataset.Value = this.hpInstallmentList;
                this.rpvHPRegListing.RefreshReport();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void PLInstallmentList_Report()
        {
            try
            {
                this.rpvHPRegListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00067.rdlc";
                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                this.rpvHPRegListing.LocalReport.DataSources.Clear();

                ReportParameter[] para = new ReportParameter[11];
                para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
                para[1] = new ReportParameter("BranchName", Branch.Address);
                para[2] = new ReportParameter("Phone", Branch.Phone);
                para[3] = new ReportParameter("Fax", Branch.Fax);

                Image img = null;
                //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                //{
                //    img = System.Drawing.Image.FromStream(stream);
                //    img.Save(tempFilePath);
                //}

                string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

                para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                para[5] = new ReportParameter("Title", this.head);
                para[6] = new ReportParameter("BrCode", this.SourceBr);
                para[7] = new ReportParameter("Br_Alias", Branch.BranchAlias);
                para[8] = new ReportParameter("TotalRecords", Convert.ToString(plInstallmentList.Count));
                para[9] = new ReportParameter("CompanyName", this.companyName);
                para[10] = new ReportParameter("ShowDate", this.showDate);

                this.rpvHPRegListing.LocalReport.EnableExternalImages = true;
                this.rpvHPRegListing.LocalReport.SetParameters(para);

                ReportDataSource dataset = new ReportDataSource("PLInstallmentList", this.plInstallmentList);
                this.rpvHPRegListing.LocalReport.DataSources.Add(dataset);
                dataset.Value = this.plInstallmentList;
                this.rpvHPRegListing.RefreshReport();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void BLInstallmentList_Report()
        {
            try
            {
                this.rpvHPRegListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00068.rdlc";
                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                this.rpvHPRegListing.LocalReport.DataSources.Clear();

                ReportParameter[] para = new ReportParameter[11];
                para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
                para[1] = new ReportParameter("BranchName", Branch.Address);
                para[2] = new ReportParameter("Phone", Branch.Phone);
                para[3] = new ReportParameter("Fax", Branch.Fax);

                Image img = null;
                //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                //{
                //    img = System.Drawing.Image.FromStream(stream);
                //    img.Save(tempFilePath);
                //}

                string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

                para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                para[5] = new ReportParameter("Title", this.head);
                para[6] = new ReportParameter("BrCode", this.SourceBr);
                para[7] = new ReportParameter("Br_Alias", Branch.BranchAlias);
                para[8] = new ReportParameter("TotalRecords", Convert.ToString(blInstallmentList.Count));
                para[9] = new ReportParameter("BusinessType", this.businessType);
                para[10] = new ReportParameter("ShowDate", this.showDate);

                this.rpvHPRegListing.LocalReport.EnableExternalImages = true;
                this.rpvHPRegListing.LocalReport.SetParameters(para);

                ReportDataSource dataset = new ReportDataSource("BLInstallmentList", this.blInstallmentList);
                this.rpvHPRegListing.LocalReport.DataSources.Add(dataset);
                dataset.Value = this.blInstallmentList;
                this.rpvHPRegListing.RefreshReport();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void PLDailyPositionList_Report()
        {
            try
            {
                this.rpvHPRegListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00069.rdlc";
                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                this.rpvHPRegListing.LocalReport.DataSources.Clear();

                ReportParameter[] para = new ReportParameter[11];
                para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
                para[1] = new ReportParameter("BranchName", Branch.Address);
                para[2] = new ReportParameter("Phone", Branch.Phone);
                para[3] = new ReportParameter("Fax", Branch.Fax);

                Image img = null;
                //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                //{
                //    img = System.Drawing.Image.FromStream(stream);
                //    img.Save(tempFilePath);
                //}

                string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

                para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                para[5] = new ReportParameter("Title", this.head);
                para[6] = new ReportParameter("BrCode", this.SourceBr);
                para[7] = new ReportParameter("Br_Alias", Branch.BranchAlias);
                para[8] = new ReportParameter("TotalRecords", Convert.ToString(plDailyPositionList.Count));
                para[9] = new ReportParameter("Currency", this.Currency);
                para[10] = new ReportParameter("CompanyName", this.companyName);

                this.rpvHPRegListing.LocalReport.EnableExternalImages = true;
                this.rpvHPRegListing.LocalReport.SetParameters(para);

                ReportDataSource dataset = new ReportDataSource("PLDailyPositionList", this.plDailyPositionList);
                this.rpvHPRegListing.LocalReport.DataSources.Add(dataset);
                dataset.Value = this.plDailyPositionList;
                this.rpvHPRegListing.RefreshReport();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void HPAutoPaySufficientList_Report()
        {
            try
            {
                this.rpvHPRegListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00071.rdlc";
                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                this.rpvHPRegListing.LocalReport.DataSources.Clear();

                ReportParameter[] para = new ReportParameter[13];
                para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
                para[1] = new ReportParameter("BranchName", Branch.Address);
                para[2] = new ReportParameter("Phone", Branch.Phone);
                para[3] = new ReportParameter("Fax", Branch.Fax);

                Image img = null;
                //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                //{
                //    img = System.Drawing.Image.FromStream(stream);
                //    img.Save(tempFilePath);
                //}

                string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

                para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                para[5] = new ReportParameter("Title", this.head);
                para[6] = new ReportParameter("BrCode", this.SourceBr);
                para[7] = new ReportParameter("Br_Alias", Branch.BranchAlias);
                para[8] = new ReportParameter("TotalRecords", Convert.ToString(hpAutoPaySufficientList.Count));
                para[9] = new ReportParameter("Currency", this.Currency);
                para[10] = new ReportParameter("StockGroup", this.stockGroupCode);
                para[11] = new ReportParameter("StartDate", this.startDate);
                para[12] = new ReportParameter("EndDate", this.endDate);


                this.rpvHPRegListing.LocalReport.EnableExternalImages = true;
                this.rpvHPRegListing.LocalReport.SetParameters(para);

                ReportDataSource dataset = new ReportDataSource("HPAutoPaySufficientLists", this.hpAutoPaySufficientList);
                this.rpvHPRegListing.LocalReport.DataSources.Add(dataset);
                dataset.Value = this.hpAutoPaySufficientList;
                this.rpvHPRegListing.RefreshReport();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void PLAutoPaySufficientList_Report()
        {
            try
            {
                this.rpvHPRegListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00072.rdlc";
                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                this.rpvHPRegListing.LocalReport.DataSources.Clear();

                ReportParameter[] para = new ReportParameter[13];
                para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
                para[1] = new ReportParameter("BranchName", Branch.Address);
                para[2] = new ReportParameter("Phone", Branch.Phone);
                para[3] = new ReportParameter("Fax", Branch.Fax);

                Image img = null;
                //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                //{
                //    img = System.Drawing.Image.FromStream(stream);
                //    img.Save(tempFilePath);
                //}

                string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

                para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                para[5] = new ReportParameter("Title", this.head);
                para[6] = new ReportParameter("BrCode", this.SourceBr);
                para[7] = new ReportParameter("Br_Alias", Branch.BranchAlias);
                para[8] = new ReportParameter("TotalRecords", Convert.ToString(plAutoPaySufficientList.Count));
                para[9] = new ReportParameter("Currency", this.Currency);
                para[10] = new ReportParameter("CompanyName", this.companyName);
                para[11] = new ReportParameter("StartDate", this.startDate);
                para[12] = new ReportParameter("EndDate", this.endDate);


                this.rpvHPRegListing.LocalReport.EnableExternalImages = true;
                this.rpvHPRegListing.LocalReport.SetParameters(para);

                ReportDataSource dataset = new ReportDataSource("PLAutoPaySufficientLists", this.plAutoPaySufficientList);
                this.rpvHPRegListing.LocalReport.DataSources.Add(dataset);
                dataset.Value = this.plAutoPaySufficientList;
                this.rpvHPRegListing.RefreshReport();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
        public void BLAutoPaySufficientList_Report()
        {
            try
            {
                this.rpvHPRegListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00073.rdlc";
                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                this.rpvHPRegListing.LocalReport.DataSources.Clear();

                ReportParameter[] para = new ReportParameter[13];
                para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
                para[1] = new ReportParameter("BranchName", Branch.Address);
                para[2] = new ReportParameter("Phone", Branch.Phone);
                para[3] = new ReportParameter("Fax", Branch.Fax);

                Image img = null;
                //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                //{
                //    img = System.Drawing.Image.FromStream(stream);
                //    img.Save(tempFilePath);
                //}

                string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

                para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                para[5] = new ReportParameter("Title", this.head);
                para[6] = new ReportParameter("BrCode", this.SourceBr);
                para[7] = new ReportParameter("Br_Alias", Branch.BranchAlias);
                para[8] = new ReportParameter("TotalRecords", Convert.ToString(blAutoPaySufficientList.Count));
                para[9] = new ReportParameter("Currency", this.Currency);
                para[10] = new ReportParameter("BusinessType", this.businessType);
                para[11] = new ReportParameter("StartDate", this.startDate);
                para[12] = new ReportParameter("EndDate", this.endDate);


                this.rpvHPRegListing.LocalReport.EnableExternalImages = true;
                this.rpvHPRegListing.LocalReport.SetParameters(para);

                ReportDataSource dataset = new ReportDataSource("BLAutoPaySufficientLists", this.blAutoPaySufficientList);
                this.rpvHPRegListing.LocalReport.DataSources.Add(dataset);
                dataset.Value = this.blAutoPaySufficientList;
                this.rpvHPRegListing.RefreshReport();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void BLOverDraftList_Report()
        {
            try
            {
                this.rpvHPRegListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00074.rdlc";
                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                this.rpvHPRegListing.LocalReport.DataSources.Clear();

                ReportParameter[] para = new ReportParameter[12];
                para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
                para[1] = new ReportParameter("BranchName", Branch.Address);
                para[2] = new ReportParameter("Phone", Branch.Phone);
                para[3] = new ReportParameter("Fax", Branch.Fax);

                Image img = null;
                //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                //{
                //    img = System.Drawing.Image.FromStream(stream);
                //    img.Save(tempFilePath);
                //}

                string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

                para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                para[5] = new ReportParameter("Title", this.head);
                para[6] = new ReportParameter("BrCode", this.SourceBr);
                para[7] = new ReportParameter("Br_Alias", Branch.BranchAlias);
                para[8] = new ReportParameter("TotalRecords", Convert.ToString(blOverDraftList.Count));
                para[9] = new ReportParameter("Currency", this.Currency);
                para[10] = new ReportParameter("StartDate", this.startDate);
                para[11] = new ReportParameter("EndDate", this.endDate);


                this.rpvHPRegListing.LocalReport.EnableExternalImages = true;
                this.rpvHPRegListing.LocalReport.SetParameters(para);

                ReportDataSource dataset = new ReportDataSource("BLOverdrawnLists", this.blOverDraftList);
                this.rpvHPRegListing.LocalReport.DataSources.Add(dataset);
                dataset.Value = this.blOverDraftList;
                this.rpvHPRegListing.RefreshReport();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void HPTODRepaymentList_Report()
        {
            try
            {
                this.rpvHPRegListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00080.rdlc";
                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                this.rpvHPRegListing.LocalReport.DataSources.Clear();

                ReportParameter[] para = new ReportParameter[12];
                para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
                para[1] = new ReportParameter("BranchName", Branch.Address);
                para[2] = new ReportParameter("Phone", Branch.Phone);
                para[3] = new ReportParameter("Fax", Branch.Fax);

                Image img = null;
                string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

                para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                para[5] = new ReportParameter("Title", this.head);
                para[6] = new ReportParameter("BrCode", this.SourceBr);
                para[7] = new ReportParameter("Br_Alias", Branch.BranchAlias);
                para[8] = new ReportParameter("TotalRecords", Convert.ToString(hpTODRepaymentList.Count));
                para[9] = new ReportParameter("Currency", this.Currency);
                para[10] = new ReportParameter("StartDate", this.startDate);
                para[11] = new ReportParameter("EndDate", this.endDate);


                this.rpvHPRegListing.LocalReport.EnableExternalImages = true;
                this.rpvHPRegListing.LocalReport.SetParameters(para);

                ReportDataSource dataset = new ReportDataSource("HPLateFeesRepaymentLists", this.hpTODRepaymentList);
                this.rpvHPRegListing.LocalReport.DataSources.Add(dataset);
                dataset.Value = this.hpTODRepaymentList;
                this.rpvHPRegListing.RefreshReport();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void PLTODRepaymentList_Report()
        {
            try
            {
                this.rpvHPRegListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00081.rdlc";
                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                this.rpvHPRegListing.LocalReport.DataSources.Clear();

                ReportParameter[] para = new ReportParameter[12];
                para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
                para[1] = new ReportParameter("BranchName", Branch.Address);
                para[2] = new ReportParameter("Phone", Branch.Phone);
                para[3] = new ReportParameter("Fax", Branch.Fax);

                Image img = null;
                string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

                para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                para[5] = new ReportParameter("Title", this.head);
                para[6] = new ReportParameter("BrCode", this.SourceBr);
                para[7] = new ReportParameter("Br_Alias", Branch.BranchAlias);
                para[8] = new ReportParameter("TotalRecords", Convert.ToString(plTODRepaymentList.Count));
                para[9] = new ReportParameter("Currency", this.Currency);
                para[10] = new ReportParameter("StartDate", this.startDate);
                para[11] = new ReportParameter("EndDate", this.endDate);


                this.rpvHPRegListing.LocalReport.EnableExternalImages = true;
                this.rpvHPRegListing.LocalReport.SetParameters(para);

                ReportDataSource dataset = new ReportDataSource("PLLateFeesRepaymentLists", this.plTODRepaymentList);
                this.rpvHPRegListing.LocalReport.DataSources.Add(dataset);
                dataset.Value = this.plTODRepaymentList;
                this.rpvHPRegListing.RefreshReport();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void BLTODRepaymentList_Report()
        {
            try
            {
                this.rpvHPRegListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00082.rdlc";
                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                this.rpvHPRegListing.LocalReport.DataSources.Clear();

                ReportParameter[] para = new ReportParameter[12];
                para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
                para[1] = new ReportParameter("BranchName", Branch.Address);
                para[2] = new ReportParameter("Phone", Branch.Phone);
                para[3] = new ReportParameter("Fax", Branch.Fax);

                Image img = null;
                string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

                para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                para[5] = new ReportParameter("Title", this.head);
                para[6] = new ReportParameter("BrCode", this.SourceBr);
                para[7] = new ReportParameter("Br_Alias", Branch.BranchAlias);
                para[8] = new ReportParameter("TotalRecords", Convert.ToString(blTODRepaymentList.Count));
                para[9] = new ReportParameter("Currency", this.Currency);
                para[10] = new ReportParameter("StartDate", this.startDate);
                para[11] = new ReportParameter("EndDate", this.endDate);


                this.rpvHPRegListing.LocalReport.EnableExternalImages = true;
                this.rpvHPRegListing.LocalReport.SetParameters(para);

                ReportDataSource dataset = new ReportDataSource("BLLateFeesRepaymentLists", this.blTODRepaymentList);
                this.rpvHPRegListing.LocalReport.DataSources.Add(dataset);
                dataset.Value = this.blTODRepaymentList;
                this.rpvHPRegListing.RefreshReport();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void HPAccountClosedList_Report()
        {
            try
            {
                this.rpvHPRegListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00083.rdlc";
                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                this.rpvHPRegListing.LocalReport.DataSources.Clear();

                ReportParameter[] para = new ReportParameter[12];
                para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
                para[1] = new ReportParameter("BranchName", Branch.Address);
                para[2] = new ReportParameter("Phone", Branch.Phone);
                para[3] = new ReportParameter("Fax", Branch.Fax);

                Image img = null;
                string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

                para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                para[5] = new ReportParameter("Title", this.head);
                para[6] = new ReportParameter("BrCode", this.SourceBr);
                para[7] = new ReportParameter("Br_Alias", Branch.BranchAlias);
                para[8] = new ReportParameter("TotalRecords", Convert.ToString(accountClosedList.Count));
                para[9] = new ReportParameter("Currency", this.Currency);
                para[10] = new ReportParameter("StartDate", this.startDate);
                para[11] = new ReportParameter("EndDate", this.endDate);


                this.rpvHPRegListing.LocalReport.EnableExternalImages = true;
                this.rpvHPRegListing.LocalReport.SetParameters(para);

                ReportDataSource dataset = new ReportDataSource("HPAccountClosedLists", this.accountClosedList);
                this.rpvHPRegListing.LocalReport.DataSources.Add(dataset);
                dataset.Value = this.accountClosedList;
                this.rpvHPRegListing.RefreshReport();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void PLAccountClosedList_Report()
        {
            try
            {
                this.rpvHPRegListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00084.rdlc";
                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                this.rpvHPRegListing.LocalReport.DataSources.Clear();

                ReportParameter[] para = new ReportParameter[12];
                para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
                para[1] = new ReportParameter("BranchName", Branch.Address);
                para[2] = new ReportParameter("Phone", Branch.Phone);
                para[3] = new ReportParameter("Fax", Branch.Fax);

                Image img = null;
                string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

                para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                para[5] = new ReportParameter("Title", this.head);
                para[6] = new ReportParameter("BrCode", this.SourceBr);
                para[7] = new ReportParameter("Br_Alias", Branch.BranchAlias);
                para[8] = new ReportParameter("TotalRecords", Convert.ToString(accountClosedList.Count));
                para[9] = new ReportParameter("Currency", this.Currency);
                para[10] = new ReportParameter("StartDate", this.startDate);
                para[11] = new ReportParameter("EndDate", this.endDate);


                this.rpvHPRegListing.LocalReport.EnableExternalImages = true;
                this.rpvHPRegListing.LocalReport.SetParameters(para);

                ReportDataSource dataset = new ReportDataSource("PLAccountClosedLists", this.accountClosedList);
                this.rpvHPRegListing.LocalReport.DataSources.Add(dataset);
                dataset.Value = this.accountClosedList;
                this.rpvHPRegListing.RefreshReport();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void BLAccountClosedList_Report()
        {
            try
            {
                this.rpvHPRegListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00085.rdlc";
                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                this.rpvHPRegListing.LocalReport.DataSources.Clear();

                ReportParameter[] para = new ReportParameter[12];
                para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
                para[1] = new ReportParameter("BranchName", Branch.Address);
                para[2] = new ReportParameter("Phone", Branch.Phone);
                para[3] = new ReportParameter("Fax", Branch.Fax);

                Image img = null;
                string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

                para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                para[5] = new ReportParameter("Title", this.head);
                para[6] = new ReportParameter("BrCode", this.SourceBr);
                para[7] = new ReportParameter("Br_Alias", Branch.BranchAlias);
                para[8] = new ReportParameter("TotalRecords", Convert.ToString(accountClosedList.Count));
                para[9] = new ReportParameter("Currency", this.Currency);
                para[10] = new ReportParameter("StartDate", this.startDate);
                para[11] = new ReportParameter("EndDate", this.endDate);


                this.rpvHPRegListing.LocalReport.EnableExternalImages = true;
                this.rpvHPRegListing.LocalReport.SetParameters(para);

                ReportDataSource dataset = new ReportDataSource("BLAccountClosedLists", this.accountClosedList);
                this.rpvHPRegListing.LocalReport.DataSources.Add(dataset);
                dataset.Value = this.accountClosedList;
                this.rpvHPRegListing.RefreshReport();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Transfer_TransactionList_Report()
        {
            try
            {
                this.rpvHPRegListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00086.rdlc";
                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                this.rpvHPRegListing.LocalReport.DataSources.Clear();

                ReportParameter[] para = new ReportParameter[12];
                para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
                para[1] = new ReportParameter("BranchName", Branch.Address);
                para[2] = new ReportParameter("Phone", Branch.Phone);
                para[3] = new ReportParameter("Fax", Branch.Fax);

                Image img = null;
                string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

                para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                para[5] = new ReportParameter("Title", this.head);
                para[6] = new ReportParameter("BrCode", this.SourceBr);
                para[7] = new ReportParameter("Br_Alias", Branch.BranchAlias);
                para[8] = new ReportParameter("TotalRecords", Convert.ToString(transferTransactionList.Count));
                para[9] = new ReportParameter("Currency", this.Currency);
                para[10] = new ReportParameter("ShowDate", this.showDate);
                para[11] = new ReportParameter("ReversalStatus", this.reversalStatus);

                this.rpvHPRegListing.LocalReport.EnableExternalImages = true;
                this.rpvHPRegListing.LocalReport.SetParameters(para);

                ReportDataSource dataset = new ReportDataSource("TransferTransactionLists", this.transferTransactionList);
                this.rpvHPRegListing.LocalReport.DataSources.Add(dataset);
                dataset.Value = this.transferTransactionList;
                this.rpvHPRegListing.RefreshReport();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void HP_Limit_Voucher_Printing_Report()
        {
            try
            {
                this.rpvHPRegListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00087.rdlc";
                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                this.rpvHPRegListing.LocalReport.DataSources.Clear();

                string drtransferlogoPath = Application.StartupPath + "\\DebitTransfer.png";
                string crtransferlogoPath = Application.StartupPath + "\\CreditTransfer.png";
                string banklogoPath = Application.StartupPath + "\\pristinelogo.png";
                string aclogoPath = Application.StartupPath + "\\Account.jpg";
                string inwordslogoPath = Application.StartupPath + "\\Inwords.jpg";
                string narationlogoPath = Application.StartupPath + "\\Naration.jpg";
                string refreglogoPath = Application.StartupPath + "\\RefReg.jpg";
                string approvedbylogoPath = Application.StartupPath + "\\ApprovedBy.jpg";
                string datelogoPath = Application.StartupPath + "\\Date.png";
                string creditlogoPath = Application.StartupPath + "\\Credit.png";
                string bydebittologoPath = Application.StartupPath + "\\ByDebitTo.png";
                string andcredittologoPath = Application.StartupPath + "\\AndCreditTo.png";

                ReportParameter[] param = new ReportParameter[12];
                param[0] = new ReportParameter("DebitTransferLogo", "file:////" + drtransferlogoPath);
                param[1] = new ReportParameter("CreditTransferLogo", "file:////" + crtransferlogoPath);
                param[2] = new ReportParameter("BankLogo", "file:////" + banklogoPath);
                param[3] = new ReportParameter("ACLogo", "file:////" + aclogoPath);
                param[4] = new ReportParameter("InwordsLogo", "file:////" + inwordslogoPath);
                param[5] = new ReportParameter("NarationLogo", "file:////" + narationlogoPath);
                param[6] = new ReportParameter("RefRegLogo", "file:////" + refreglogoPath);
                param[7] = new ReportParameter("ApprovedByLogo", "file:////" + approvedbylogoPath);
                param[8] = new ReportParameter("DateLogo", "file:////" + datelogoPath);
                param[9] = new ReportParameter("CreditLogo", "file:////" + creditlogoPath);
                param[10] = new ReportParameter("ByDebitToLogo", "file:////" + bydebittologoPath);
                param[11] = new ReportParameter("AndCreditToLogo", "file:////" + andcredittologoPath);

                this.rpvHPRegListing.LocalReport.EnableExternalImages = true;
                this.rpvHPRegListing.LocalReport.SetParameters(param);
                this.rpvHPRegListing.RefreshReport();

                ReportDataSource datasetDR = new ReportDataSource("TransferVouPrintLists", this.hpLimit_VoucherPrintList);
                this.rpvHPRegListing.LocalReport.DataSources.Add(datasetDR);
                datasetDR.Value = this.hpLimit_VoucherPrintList;
                this.rpvHPRegListing.LocalReport.Refresh();

                this.rpvHPRegListing.SetDisplayMode(DisplayMode.PrintLayout);

                this.rpvHPRegListing.RefreshReport();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void PL_Limit_Voucher_Printing_Report()
        {
            try
            {
                this.rpvHPRegListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00088.rdlc";
                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                this.rpvHPRegListing.LocalReport.DataSources.Clear();

                string drtransferlogoPath = Application.StartupPath + "\\DebitTransfer.png";
                string crtransferlogoPath = Application.StartupPath + "\\CreditTransfer.png";
                string banklogoPath = Application.StartupPath + "\\pristinelogo.png";
                string aclogoPath = Application.StartupPath + "\\Account.jpg";
                string inwordslogoPath = Application.StartupPath + "\\Inwords.jpg";
                string narationlogoPath = Application.StartupPath + "\\Naration.jpg";
                string refreglogoPath = Application.StartupPath + "\\RefReg.jpg";
                string approvedbylogoPath = Application.StartupPath + "\\ApprovedBy.jpg";
                string datelogoPath = Application.StartupPath + "\\Date.png";
                string creditlogoPath = Application.StartupPath + "\\Credit.png";
                string bydebittologoPath = Application.StartupPath + "\\ByDebitTo.png";
                string andcredittologoPath = Application.StartupPath + "\\AndCreditTo.png";

                ReportParameter[] param = new ReportParameter[12];
                param[0] = new ReportParameter("DebitTransferLogo", "file:////" + drtransferlogoPath);
                param[1] = new ReportParameter("CreditTransferLogo", "file:////" + crtransferlogoPath);
                param[2] = new ReportParameter("BankLogo", "file:////" + banklogoPath);
                param[3] = new ReportParameter("ACLogo", "file:////" + aclogoPath);
                param[4] = new ReportParameter("InwordsLogo", "file:////" + inwordslogoPath);
                param[5] = new ReportParameter("NarationLogo", "file:////" + narationlogoPath);
                param[6] = new ReportParameter("RefRegLogo", "file:////" + refreglogoPath);
                param[7] = new ReportParameter("ApprovedByLogo", "file:////" + approvedbylogoPath);
                param[8] = new ReportParameter("DateLogo", "file:////" + datelogoPath);
                param[9] = new ReportParameter("CreditLogo", "file:////" + creditlogoPath);
                param[10] = new ReportParameter("ByDebitToLogo", "file:////" + bydebittologoPath);
                param[11] = new ReportParameter("AndCreditToLogo", "file:////" + andcredittologoPath);

                this.rpvHPRegListing.LocalReport.EnableExternalImages = true;
                this.rpvHPRegListing.LocalReport.SetParameters(param);
                this.rpvHPRegListing.RefreshReport();

                ReportDataSource datasetDR = new ReportDataSource("PL_Reg_Vou_Print_Lists", this.plLimit_VoucherPrintList);
                this.rpvHPRegListing.LocalReport.DataSources.Add(datasetDR);
                datasetDR.Value = this.plLimit_VoucherPrintList;
                this.rpvHPRegListing.LocalReport.Refresh();

                this.rpvHPRegListing.SetDisplayMode(DisplayMode.PrintLayout);

                this.rpvHPRegListing.RefreshReport();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void BL_Limit_Voucher_Printing_Report()
        {
            try
            {
                this.rpvHPRegListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00089.rdlc";
                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                this.rpvHPRegListing.LocalReport.DataSources.Clear();

                string drtransferlogoPath = Application.StartupPath + "\\DebitTransfer.png";
                string crtransferlogoPath = Application.StartupPath + "\\CreditTransfer.png";
                string banklogoPath = Application.StartupPath + "\\pristinelogo.png";
                string aclogoPath = Application.StartupPath + "\\Account.jpg";
                string inwordslogoPath = Application.StartupPath + "\\Inwords.jpg";
                string narationlogoPath = Application.StartupPath + "\\Naration.jpg";
                string refreglogoPath = Application.StartupPath + "\\RefReg.jpg";
                string approvedbylogoPath = Application.StartupPath + "\\ApprovedBy.jpg";
                string datelogoPath = Application.StartupPath + "\\Date.png";
                string creditlogoPath = Application.StartupPath + "\\Credit.png";
                string bydebittologoPath = Application.StartupPath + "\\ByDebitTo.png";
                string andcredittologoPath = Application.StartupPath + "\\AndCreditTo.png";

                ReportParameter[] param = new ReportParameter[12];
                param[0] = new ReportParameter("DebitTransferLogo", "file:////" + drtransferlogoPath);
                param[1] = new ReportParameter("CreditTransferLogo", "file:////" + crtransferlogoPath);
                param[2] = new ReportParameter("BankLogo", "file:////" + banklogoPath);
                param[3] = new ReportParameter("ACLogo", "file:////" + aclogoPath);
                param[4] = new ReportParameter("InwordsLogo", "file:////" + inwordslogoPath);
                param[5] = new ReportParameter("NarationLogo", "file:////" + narationlogoPath);
                param[6] = new ReportParameter("RefRegLogo", "file:////" + refreglogoPath);
                param[7] = new ReportParameter("ApprovedByLogo", "file:////" + approvedbylogoPath);
                param[8] = new ReportParameter("DateLogo", "file:////" + datelogoPath);
                param[9] = new ReportParameter("CreditLogo", "file:////" + creditlogoPath);
                param[10] = new ReportParameter("ByDebitToLogo", "file:////" + bydebittologoPath);
                param[11] = new ReportParameter("AndCreditToLogo", "file:////" + andcredittologoPath);

                this.rpvHPRegListing.LocalReport.EnableExternalImages = true;
                this.rpvHPRegListing.LocalReport.SetParameters(param);
                this.rpvHPRegListing.RefreshReport();

                ReportDataSource datasetDR = new ReportDataSource("BL_Reg_Vou_Print_Lists", this.blLimit_VoucherPrintList);
                this.rpvHPRegListing.LocalReport.DataSources.Add(datasetDR);
                datasetDR.Value = this.blLimit_VoucherPrintList;
                this.rpvHPRegListing.LocalReport.Refresh();

                this.rpvHPRegListing.SetDisplayMode(DisplayMode.PrintLayout);

                this.rpvHPRegListing.RefreshReport();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Added By ZMS (20-06-2018)
        public void TransactionsList_Report()
        {
            try
            {
                this.rpvHPRegListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00090.rdlc";
                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                this.rpvHPRegListing.LocalReport.DataSources.Clear();

                ReportParameter[] para = new ReportParameter[9];
                para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
                para[1] = new ReportParameter("BranchName", Branch.Address);
                para[2] = new ReportParameter("Phone", Branch.Phone);
                para[3] = new ReportParameter("Fax", Branch.Fax);

                Image img = null;
                string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

                para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                para[5] = new ReportParameter("ReportTitle", this.head);
                para[6] = new ReportParameter("TotalRecords", Convert.ToString(transtList.Count));
                para[7] = new ReportParameter("BrCode", CurrentUserEntity.BranchCode);
                para[8] = new ReportParameter("Br_Alias", Branch.BranchAlias);

                this.rpvHPRegListing.LocalReport.EnableExternalImages = true;
                this.rpvHPRegListing.LocalReport.SetParameters(para);

                ReportDataSource dataset = new ReportDataSource("TransactionListingDataSet", this.transtList);
                this.rpvHPRegListing.LocalReport.DataSources.Add(dataset);
                dataset.Value = this.transtList;
                this.rpvHPRegListing.RefreshReport();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion RDLC Method

        #region Form_Load
        private void LOMVEW00097_Load(object sender, EventArgs e)
        {
            #region Method Call

            if (rptName == "HPRegListing") this.HPRegListing_Report();
            else if (rptName == "HPPaymentSchedule") this.HPPaymentSchedule_Report();
            else if (rptName == "HPOverDrawnList") this.HPOverDrawnList_Report();
            else if (rptName == "HPInsufficientList") this.HPInsufficientList_Report();
            else if (rptName == "PersonalLoanInfoList" && filterStatus == "0") this.PersonalLoanInfoList_Report();
            else if (rptName == "PersonalLoanInfoList" && filterStatus == "1") this.PersonalLoanInfoList_Report_ByCompanyName();
            else if (rptName == "BusinessLoanInterestList") this.BusinessLoanInterestList_Report();
            else if (rptName == "PersonalLoansNPLCaseList") this.PersonalLoans_NPLCase_Listing_Report();
            else if (rptName == "HPDailyPositionList") this.HPDailyPositionList_Report();
            else if (rptName == "HPInformationList") this.HPInformationList_Report();
            else if (rptName == "HPPaymentList") this.HPPaymentList_Report();
            else if (rptName == "HPRepaymentList") this.HPRepaymentList_Report();
            else if (rptName == "HPInterestDuePreList") this.HPInterest_Due_PreList_Report();
            else if (rptName == "HPRepaymentScheduleList") this.HP_Repayment_Schedule_List_Report();
            else if (rptName == "HPAbsentHistoryList") this.HP_AbsentHistoryList_Report();
            else if (rptName == "PLAbsentHistoryList") this.PL_AbsentHistoryList_Report();
            else if (rptName == "HPRepaymentHistory_Enquiry") this.HP_RepaymentHistory_Enquiry_Report();
            else if (rptName == "PLRepaymentHistory_Enquiry") this.PL_RepaymentHistory_Enquiry_Report();
            else if (rptName == "HPLateFeesOutstandingList") this.HPLateFeesOutstandingList_Report();
            else if (rptName == "BLLateFeesOutstandingList") this.BLLateFeesOutstandingList_Report();
            else if (rptName == "HPInstallmentList") this.HPInstallmentList_Report();
            else if (rptName == "PLInstallmentList") this.PLInstallmentList_Report();
            else if (rptName == "BLInstallmentList") this.BLInstallmentList_Report();
            else if (rptName == "PLDailyPositionList") this.PLDailyPositionList_Report();
            else if (rptName == "HPAutoPaySufficientLists") this.HPAutoPaySufficientList_Report();
            else if (rptName == "PLAutoPaySufficientLists") this.PLAutoPaySufficientList_Report();
            else if (rptName == "BLAutoPaySufficientLists") this.BLAutoPaySufficientList_Report();
            else if (rptName == "BLOverdrawnLists") this.BLOverDraftList_Report();
            else if (rptName == "HPLateFeesRepaymentLists") this.HPTODRepaymentList_Report();
            else if (rptName == "PLLateFeesRepaymentLists") this.PLTODRepaymentList_Report();
            else if (rptName == "BLLateFeesRepaymentLists") this.BLTODRepaymentList_Report();
            else if (rptName == "HPAccountClosedLists") this.HPAccountClosedList_Report();
            else if (rptName == "PLAccountClosedLists") this.PLAccountClosedList_Report();
            else if (rptName == "BLAccountClosedLists") this.BLAccountClosedList_Report();
            else if (rptName == "TransferTransactionLists") this.Transfer_TransactionList_Report();
            else if (rptName == "TransferVouPrintLists") this.HP_Limit_Voucher_Printing_Report();
            else if (rptName == "PL_Reg_Vou_Print_Lists") this.PL_Limit_Voucher_Printing_Report();
            else if (rptName == "BL_Reg_Vou_Print_Lists") this.BL_Limit_Voucher_Printing_Report();
            else if (rptName == "transferTransactionList") this.TransactionsList_Report();// Added By ZMS (20-06-2018)
            //
            #endregion Method Call
        }
        #endregion
    }
}
