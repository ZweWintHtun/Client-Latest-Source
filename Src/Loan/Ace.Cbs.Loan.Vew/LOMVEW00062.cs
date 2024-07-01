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
    public partial class LOMVEW00062 : BaseForm
    {

        IList<LOMDTO00059> DataList { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string Currency { get; set; }
        string SourceBranch { get; set; }
        string Header { get; set; }

        public LOMVEW00062()
        {
            InitializeComponent();
        }

        public LOMVEW00062(IList<LOMDTO00059> dataList, string startDate, string endDate, string currency,
            string sourceBranch, string header)
        {
            this.Text = header;
            this.Header = header;
            this.DataList = dataList;
            this.StartDate = Convert.ToDateTime(startDate);
            this.EndDate = Convert.ToDateTime(endDate);
            this.Currency = currency;
            this.SourceBranch = sourceBranch;
            InitializeComponent();
        }

        private void LOMVEW00062_Load(object sender, EventArgs e)
        {
            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            this.rpvODLimitChangeByAcctNo.LocalReport.DataSources.Clear();

            ReportParameter[] para = new ReportParameter[12];
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
            para[9] = new ReportParameter("StartDate", this.StartDate.ToString("dd/MM/yyyy"));
            para[10] = new ReportParameter("EndDate", this.EndDate.ToString("dd/MM/yyyy"));
            para[11] = new ReportParameter("Currency", this.Currency);

            this.rpvODLimitChangeByAcctNo.LocalReport.EnableExternalImages = true;
            this.rpvODLimitChangeByAcctNo.LocalReport.SetParameters(para);
            this.rpvODLimitChangeByAcctNo.RefreshReport();

            ReportDataSource dataset = new ReportDataSource("DSLOMRDLC00012", this.DataList);
            this.rpvODLimitChangeByAcctNo.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.DataList;
            this.rpvODLimitChangeByAcctNo.LocalReport.Refresh();

            this.rpvODLimitChangeByAcctNo.RefreshReport();
        }
    }
}
