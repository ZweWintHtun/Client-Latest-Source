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
using Ace.Windows.Core.Utt;
using Microsoft.Reporting.WinForms;
using System.IO;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00306 : BaseForm
    {
        IList<LOMDTO00305> DataList { get; set; }
        DateTime WithdrawDate { get; set; }
        string Currency { get; set; }
        string SourceBranch { get; set; }
        string head { get; set; }
        string Village { get; set; }
        string Township { get; set; }

        public LOMVEW00306()
        {
            InitializeComponent();
        }

        public LOMVEW00306(IList<LOMDTO00305> dataList, string village, string township, string withdrawDate, string currency,
            string sourceBranch, string header)
        {
            this.Text = header;
            this.head = header;
            this.DataList = dataList;
            this.WithdrawDate = Convert.ToDateTime(withdrawDate);
            this.Village = village;
            this.Township = township;
            this.Currency = currency;
            this.SourceBranch = sourceBranch;
            InitializeComponent();
        }

        private void LOMVEW00306_Load(object sender, EventArgs e)
        {
            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            this.rpvFLOSTReportBYWD.LocalReport.DataSources.Clear();

            ReportParameter[] para = new ReportParameter[13];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[4] = new ReportParameter("Br_Alias", Branch.Bank_Alias);
            para[5] = new ReportParameter("Township", this.Township);
            para[6] = new ReportParameter("Village", this.Village);
            para[7] = new ReportParameter("WithdrawDate", this.WithdrawDate.ToString("dd/MM/yyyy"));
            para[8] = new ReportParameter("BrCode", this.SourceBranch);
            para[9] = new ReportParameter("Title", this.head);
            para[10] = new ReportParameter("Currency", this.Currency);
            para[11] = new ReportParameter("TotalRecords", Convert.ToString(DataList.Count));

            Image img = null;
            string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            {
                img = System.Drawing.Image.FromStream(stream);
                img.Save(tempFilePath);
            }

            para[12] = new ReportParameter("BankLogo", "file:////" + tempFilePath);

            this.rpvFLOSTReportBYWD.LocalReport.EnableExternalImages = true;
            this.rpvFLOSTReportBYWD.LocalReport.SetParameters(para);
            this.rpvFLOSTReportBYWD.RefreshReport();

            ReportDataSource dataset = new ReportDataSource("DSLOMRDLC00023", this.DataList);
            this.rpvFLOSTReportBYWD.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.DataList;
            this.rpvFLOSTReportBYWD.LocalReport.Refresh();

            this.rpvFLOSTReportBYWD.RefreshReport();
        }
    }
}
