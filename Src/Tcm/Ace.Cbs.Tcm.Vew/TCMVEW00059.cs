using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Pfm.Dmd;
using Microsoft.Reporting.WinForms;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Utt;
using System.IO;

namespace Ace.Cbs.Tcm.Vew
{
    public partial class TCMVEW00059 : BaseDockingForm
    {


        #region Properties
        public IList<PFMDTO00006> IssueLists { get; set; }
        public IList<PFMDTO00011> StopLists { get; set; }
        public IList<PFMDTO00014> PrintLists { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string AccountNo { get; set; }
        public string Head { get; set; }
        public string Title{get;set;}
        public string Column1 { get; set; }
        public string Column2 { get; set; }
        public string Column3 { get; set; }
        public string Column4 { get; set; }
        public string Column5 { get; set; }
        public string Column6 { get; set; }
        public string Remark { get; set; }  //Added by ASDA
        public string Status { get; set; }
        public string Type { get; set; }
        #endregion

        #region Constructor
        public TCMVEW00059()
        {
            InitializeComponent();
        }

        //For Issued cheque Listing By Date
        public TCMVEW00059(IList<PFMDTO00006> PrintDataLists, string startDate, string endDate, string srNo, string accountNo, string chequebookNo, string date, string startNo, string endNo, string head, string remark)
        {
            this.IssueLists = PrintDataLists;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Column1 = srNo;
            this.Column2 = accountNo;
            this.Column3 = chequebookNo;
            this.Column4 = date;
            this.Column5 = startNo;
            this.Column6 = endNo;
            this.Head = head;
            this.Remark = remark;
            this.Status = "Date";
            this.Type = "Issue";
            InitializeComponent();
        }
       
        //For Issued cheque Listing By AccountNo.       
        public TCMVEW00059(IList<PFMDTO00006> PrintDataLists, string currentAccountNo, string srNo, string accountNo, string chequebookNo, string date, string startNo, string endNo, string head)
        {
            this.IssueLists = PrintDataLists;
            this.AccountNo = currentAccountNo;
            this.Column1 = srNo;
            this.Column2 = accountNo;
            this.Column3 = chequebookNo;
            this.Column4 = date;
            this.Column5 = startNo;
            this.Column6 = endNo;
            this.Head = head;
            //this.Remark = remark;
            this.Status = "Account";
            this.Type = "Issue";
            InitializeComponent();
        }

        //For Stoped cheque Listing By Date
        public TCMVEW00059(IList<PFMDTO00011> PrintDataLists, string startDate, string endDate, string srNo, string accountNo, string chequebookNo, string date, string startNo, string endNo, string remark, string head)
        {
            //this.StopLists = PrintDataLists;
            //this.StartDate = startDate;
            //this.EndDate = endDate;
            //this.Column1 = accountNo;
            //this.Column2 = chequebookNo;
            //this.Column3 = date;
            //this.Column4 = startNo;
            //this.Column5 = endNo;
            //this.Column6 = remark;            
            //this.Head = head;
            //this.Status = "Date";
            //this.Type = "Stop";            

            this.StopLists = PrintDataLists;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Column1 = srNo;
            this.Column2 = accountNo;
            this.Column3 = chequebookNo;
            this.Column4 = date;
            this.Column5 = startNo;
            this.Column6 = endNo;
            this.Remark = remark;
            this.Head = head;
            this.Status = "Date";
            this.Type = "Stop";     
            InitializeComponent();
        }

        //For Stoped cheque Listing By AccountNo.
        public TCMVEW00059(IList<PFMDTO00011> PrintDataLists, string currentAccountNo, string srNo, string accountNo, string chequebookNo, string date, string startNo, string endNo, string remark, string head)
        {
            //this.StopLists = PrintDataLists;
            //this.AccountNo = currentAccountNo;
            //this.Column1 = accountNo;
            //this.Column2 = chequebookNo;
            //this.Column3 = date;
            //this.Column4 = startNo;
            //this.Column5 = endNo;
            //this.Column6 = remark;
            //this.Head = head;
            //this.Status = "Account";
            //this.Type = "Stop";

            this.StopLists = PrintDataLists;
            this.AccountNo = currentAccountNo;
            this.Column1 = srNo;
            this.Column2 = accountNo;
            this.Column3 = chequebookNo;
            this.Column4 = date;
            this.Column5 = startNo;
            this.Column6 = endNo;
            this.Remark = remark;
            this.Head = head;
            this.Status = "Account";
            this.Type = "Stop";
            InitializeComponent();
        }

        //For Printed cheque Listing By Date       
        public TCMVEW00059(IList<PFMDTO00014> PrintDataLists, string startDate, string endDate, string srNo, string accountNo, string chequebookNo, string date, string chequeNo, string branch,string head, string remark)
        {
            this.PrintLists = PrintDataLists;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Column1 = srNo;
            this.Column2 = accountNo;
            this.Column3 = chequebookNo;
            this.Column4 = date;
            this.Column5 = chequeNo;
            this.Column6 = branch;
            this.Head = head;
            this.Remark = remark;
            this.Status = "Date";
            this.Type = "Print";
            InitializeComponent();
        }

        //For Printed cheque Listing By AccountNo.
        public TCMVEW00059(IList<PFMDTO00014> PrintDataLists, string currentAccountNo, string srNo, string accountNo, string chequebookNo, string date, string chequeNo, string branch, string head)
        {
            this.PrintLists = PrintDataLists;
            this.AccountNo = currentAccountNo;
            this.Column1 = srNo;
            this.Column2 = accountNo;
            this.Column3 = chequebookNo;
            this.Column4 = date;
            this.Column5 = chequeNo;
            this.Column6 = branch;
            this.Head = head;
            //this.Remark = remark;
            this.Status = "Account";
            this.Type = "Print";
            InitializeComponent();
        }
        #endregion

        private void TCMVEW00059_Load(object sender, EventArgs e)
        {
            this.Text = this.Head;
            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            this.rpvChequeListReportViewer.LocalReport.DataSources.Clear();
          
        
            ReportParameter[] para = new ReportParameter[15];

            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);

            para[13] = new ReportParameter("BrCode", Branch.BranchCode);
            para[14] = new ReportParameter("Br_Alias", Branch.Bank_Alias);


            Image img = null;
            string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            {
              img = System.Drawing.Image.FromStream(stream);

              img.Save(tempFilePath);
            }

            para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);

            if (this.Status == "Date")
            {
                Title = "From  " + this.StartDate + " To  " + this.EndDate ;
            }
            else
            {
                Title = "For  " + this.AccountNo;
            }
            para[5] = new ReportParameter("Head", this.Head);
            para[6] = new ReportParameter("Title", this.Title);
            para[7] = new ReportParameter("Column1", this.Column1);
            para[8] = new ReportParameter("Column2", this.Column2);
            para[9] = new ReportParameter("Column3", this.Column3);
            para[10] = new ReportParameter("Column4", this.Column4);
            para[11] = new ReportParameter("Column5", this.Column5);
            para[12] = new ReportParameter("Column6", this.Column6);
      

            this.rpvChequeListReportViewer.LocalReport.EnableExternalImages = true;
            this.rpvChequeListReportViewer.LocalReport.SetParameters(para);
            this.rpvChequeListReportViewer.RefreshReport();

            IList<PFMDTO00011> chequeLists = new List<PFMDTO00011>();
            int count = 1;
            if (this.Type == "Issue")
            {
                if (IssueLists.Count > 0)
                {
                    foreach (PFMDTO00006 data in IssueLists)
                    {
                        PFMDTO00011 list = new PFMDTO00011();
                        list.SrNo = Convert.ToString(count++);
                        list.AccountNo = data.AccountNo;
                        list.ChequeBookNo = data.ChequeBookNo;
                        DateTime date = Convert.ToDateTime(data.IssueDate);
                        list.Date = CXCOM00006.Instance.GetDateFormat(date);
                        list.StartNo = data.StartNo;
                        list.EndNo = data.EndNo;
            
                        list.Remark = "-";
                        chequeLists.Add(list);

                    }
                }
            }
            else if (this.Type == "Stop")
            {
                if(StopLists.Count > 0)
                {
                    foreach (PFMDTO00011 data in StopLists)
                    {
                        //PFMDTO00011 list = new PFMDTO00011();
                        //list.SrNo = data.AccountNo;
                        //list.AccountNo = data.ChequeBookNo;
                        //DateTime date = Convert.ToDateTime(data.DATE_TIME);
                        //list.ChequeBookNo = CXCOM00006.Instance.GetDateFormat(date);
                        //list.Date = data.StartNo;
                        //list.StartNo = data.EndNo;
                        //list.EndNo = data.Remark;
                        //chequeLists.Add(list);   

                        PFMDTO00011 list = new PFMDTO00011();
                        list.SrNo = Convert.ToString(count++);
                        list.AccountNo = data.AccountNo;
                        list.ChequeBookNo = data.ChequeBookNo;
                        DateTime date = Convert.ToDateTime(data.DATE_TIME);
                        list.Date = CXCOM00006.Instance.GetDateFormat(date);
                        list.StartNo = data.StartNo;
                        list.EndNo = data.EndNo;
                        list.Remark = data.Remark;   //added by ASDA
                        chequeLists.Add(list);
                                          
                    }
                }
            }
            else
            {
                if(PrintLists.Count>0)
                {
                    foreach (PFMDTO00014 data in PrintLists)
                    {
                        PFMDTO00011 list = new PFMDTO00011();
                        list.SrNo = Convert.ToString(count++);
                        list.AccountNo = data.AccountNo;
                        list.ChequeBookNo = data.ChequeBookNo;
                        DateTime date = Convert.ToDateTime(data.DATE_TIME);
                        list.Date = CXCOM00006.Instance.GetDateFormat(date);
                        list.StartNo = data.ChequeNo;
                        list.EndNo = data.SourceBranchCode;
                        list.Remark = "-";  
                        chequeLists.Add(list);


                    }
                }

            }
            ReportDataSource dataset = new ReportDataSource("ChequeListDataSets", chequeLists);
            rpvChequeListReportViewer.LocalReport.DataSources.Add(dataset);
            dataset.Value = chequeLists;
            this.rpvChequeListReportViewer.LocalReport.Refresh();
            this.rpvChequeListReportViewer.RefreshReport();
           
         
        }
    }
}
