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
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Microsoft.Reporting.WinForms;
using Ace.Windows.Core.Utt;
using System.IO;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00056 : BaseForm
    {
        IList<LOMDTO00054> DataList { get; set; }
        string Currency { get; set; }
        string SourceBranch { get; set; }
        string Header { get; set; }
        string QuaterNo { get; set; }

        public LOMVEW00056()
        {
            InitializeComponent();
        }

        public LOMVEW00056(IList<LOMDTO00054> dataList, string cur, string sourceBr,
            string head,string qno)
        {
            this.Text = head;
            this.Header = head;
            this.DataList = dataList;
            this.Currency = cur;
            this.SourceBranch = sourceBr;
            this.QuaterNo = qno;
            InitializeComponent();
        }

        public string GetQuaterName(string qno)
        {
            if (!String.IsNullOrEmpty(qno))
            {
                switch (qno)
                {
                    case "Q1":
                        return "April to June";
                    case "Q2":
                        return "July to September";
                    case "Q3":
                        return "October to December";
                    case "Q4":
                        return "January to March";
                    default:
                        return null;
                }
            }
            return null;
        }

        private void LOMVEW00056_Load(object sender, EventArgs e)
        {
            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            this.rpvODInterestListing.LocalReport.DataSources.Clear();

            ReportParameter[] para = new ReportParameter[13];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            

            Image img = null;
            string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            {
                img = System.Drawing.Image.FromStream(stream);
                img.Save(tempFilePath);
            }

            para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[5] = new ReportParameter("Title", this.Header);            
            para[6] = new ReportParameter("BrCode", this.SourceBranch);
            para[7] = new ReportParameter("Br_Alias", Branch.Bank_Alias);
            para[8] = new ReportParameter("TotalRecords", Convert.ToString(DataList.Count));
            para[9] = new ReportParameter("Currency", this.Currency);
            para[10] = new ReportParameter("QNo", this.QuaterNo);
            para[11] = new ReportParameter("QuaterName", this.GetQuaterName(this.QuaterNo));
            para[12] = new ReportParameter("CurrentDate", DateTime.Now.ToString("dd/MM/yyyy"));

            this.rpvODInterestListing.LocalReport.EnableExternalImages = true;
            this.rpvODInterestListing.LocalReport.SetParameters(para);
            this.rpvODInterestListing.RefreshReport();

            ReportDataSource dataset = new ReportDataSource("DSLOMRDLC00009", this.DataList);
            this.rpvODInterestListing.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.DataList;
            this.rpvODInterestListing.LocalReport.Refresh();

            this.rpvODInterestListing.RefreshReport();
        }
    }
}
