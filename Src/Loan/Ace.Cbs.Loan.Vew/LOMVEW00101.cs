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
using Microsoft.Reporting.WinForms;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Core.Utt;
using System.IO;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00101 : BaseForm
    {
        IList<LOMDTO00102> lstLoanRecord { get; set; }
        string StartDate { get; set; }
        string EndDate { get; set; }
        string TownshipCode { get; set; }
        string Header { get; set; }
        string loanType { get; set; }

        public LOMVEW00101()
        {
            InitializeComponent();
        }

        public LOMVEW00101(IList<LOMDTO00102> lstAllLoanRecord, string startDate, string endDate, string townshipCode, string header, string loanType)
        { 
            this.lstLoanRecord = lstAllLoanRecord;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.TownshipCode = townshipCode;
            this.Header = header;
            this.loanType = loanType;
            InitializeComponent();
        }

        private void LOMVEW00101_Load(object sender, EventArgs e)
        {
            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            this.rpvAGLoanListing.LocalReport.DataSources.Clear();

            ReportParameter[] para = new ReportParameter[11];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[6] = new ReportParameter("Br_Alias", Branch.Bank_Alias);

            ReportDataSource dataset;
            Image img = null;
            string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            {
                img = System.Drawing.Image.FromStream(stream);
                img.Save(tempFilePath);
            }

            para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[8] = new ReportParameter("StartDate", this.StartDate);
            para[9] = new ReportParameter("EndDate", this.EndDate);
            para[5] = new ReportParameter("Title", this.Header);
            para[7] = new ReportParameter("TotalRecords", Convert.ToString(lstLoanRecord.Count));
            para[10] = new ReportParameter("Township", lstLoanRecord.Select(x=>x.TownshipName).FirstOrDefault().ToString());

            //string path_ = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + @"\FDPB\";

            //MessageBox.Show(Directory.GetCurrentDirectory());
            //return;
            //if (Directory.Exists(path_))
            //{
            //    if(this.loanType == "AGLoan")
            //        path_ = path_ + @"\Loan\Ace.Cbs.Loan.Vew\RDLC\LOMRDLC00018.rdlc";
            //    else
            //        path_ = path_ + @"\Loan\Ace.Cbs.Loan.Vew\RDLC\LOMRDLC00019.rdlc";
            //}
            //else
            //{
            //    path_ = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + ((this.loanType == "AGLoan") ? @"\Src\Loan\Ace.Cbs.Loan.Vew\RDLC\LOMRDLC00018.rdlc" : @"\Src\Loan\Ace.Cbs.Loan.Vew\RDLC\LOMRDLC00019.rdlc");
            //}
            //this.rpvAGLoanListing.LocalReport.ReportPath = path_;

            this.rpvAGLoanListing.LocalReport.EnableExternalImages = true;
            this.rpvAGLoanListing.LocalReport.SetParameters(para);
            this.rpvAGLoanListing.RefreshReport();

            //if (this.loanType == "AGLoan")
            //{                
                dataset = new ReportDataSource("DSLOMRDLC00018", this.lstLoanRecord);
                this.rpvAGLoanListing.LocalReport.DataSources.Add(dataset);
                dataset.Value = this.lstLoanRecord;
                this.rpvAGLoanListing.LocalReport.Refresh();

                this.rpvAGLoanListing.RefreshReport();
                //rpvAGLoanListing.SetDisplayMode(DisplayMode.PrintLayout);
            //}
            //else
            //{
            //    dataset = new ReportDataSource("DSLOMRDLC00019", this.lstLoanRecord);
            //    this.rpvAGLoanListing.LocalReport.DataSources.Add(dataset);
            //    dataset.Value = this.lstLoanRecord;
            //    this.rpvAGLoanListing.LocalReport.Refresh();

            //    this.rpvAGLoanListing.RefreshReport();
            //    rpvAGLoanListing.SetDisplayMode(DisplayMode.PrintLayout);
            //}
            
            
        }
    }
}
