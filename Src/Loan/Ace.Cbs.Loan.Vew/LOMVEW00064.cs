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
using System.IO;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00064 : BaseForm
    {
        IList<LOMDTO00013> DataList { get; set; }
        string Currency { get; set; }
        string SourceBranch { get; set; }
        string Header { get; set; }

        public LOMVEW00064()
        {
            InitializeComponent();
        }

        public LOMVEW00064(IList<LOMDTO00013> dataList, string currency,
            string sourceBranch, string header)
        {
            this.Text = header;
            this.Header = header;
            this.DataList = dataList;
            this.Currency = currency;
            this.SourceBranch = sourceBranch;
            InitializeComponent();
        }

        private void LOMVEW00064_Load(object sender, EventArgs e)
        {
            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            this.rpvNonPerformanceLoansCase.LocalReport.DataSources.Clear();

            ReportParameter[] para = new ReportParameter[10];
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

            this.rpvNonPerformanceLoansCase.LocalReport.EnableExternalImages = true;
            this.rpvNonPerformanceLoansCase.LocalReport.SetParameters(para);
            this.rpvNonPerformanceLoansCase.RefreshReport();

            ReportDataSource dataset = new ReportDataSource("DSLOMRDLC00013", this.DataList);
            this.rpvNonPerformanceLoansCase.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.DataList;
            this.rpvNonPerformanceLoansCase.LocalReport.Refresh();

            this.rpvNonPerformanceLoansCase.RefreshReport();
        }

    }
}
