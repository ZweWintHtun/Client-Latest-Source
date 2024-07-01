using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.CXClient.Controls;
using Microsoft.Reporting.WinForms;
using System.IO;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00103 : BaseForm
    {
        IList<LOMDTO00102> lstLoanRecord { get; set; }
        string StartDate { get; set; }
        string EndDate { get; set; }
        string TownshipCode { get; set; }
        string Header { get; set; }
        string loanType { get; set; }

        public LOMVEW00103()
        {
            InitializeComponent();
        }

        public LOMVEW00103(IList<LOMDTO00102> lstAllLoanRecord, string startDate, string endDate, string townshipCode, string header, string loanType)
        {
            this.lstLoanRecord = lstAllLoanRecord;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.TownshipCode = townshipCode;
            this.Header = header;
            this.loanType = loanType;
            InitializeComponent();
        }

        private void LOMVEW00103_Load(object sender, EventArgs e)
        {
            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            this.rpvLSLoanListing.LocalReport.DataSources.Clear();

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
            para[10] = new ReportParameter("Township", lstLoanRecord.Select(x => x.TownshipName).FirstOrDefault().ToString());

            this.rpvLSLoanListing.LocalReport.EnableExternalImages = true;
            this.rpvLSLoanListing.LocalReport.SetParameters(para);
            this.rpvLSLoanListing.RefreshReport();

            dataset = new ReportDataSource("DSLOMRDLC00019", this.lstLoanRecord);
            this.rpvLSLoanListing.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.lstLoanRecord;
            this.rpvLSLoanListing.LocalReport.Refresh();

            this.rpvLSLoanListing.RefreshReport();
            rpvLSLoanListing.SetDisplayMode(DisplayMode.PrintLayout);

        }
    }
}
