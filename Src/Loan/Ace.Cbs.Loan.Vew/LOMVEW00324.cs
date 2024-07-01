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
    public partial class LOMVEW00324 : BaseForm
    {
        IList<LOMDTO00316> DataList { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string Currency { get; set; }
        string SourceBranch { get; set; }
        string head { get; set; }

        public LOMVEW00324()
        {
            InitializeComponent();
        }

        public LOMVEW00324(IList<LOMDTO00316> dataList, string startDate, string endDate, string currency,
            string sourceBranch, string header)
        {
            this.Text = header.Replace("KYT", "MMK");//Updated by HWKO (21-Sep-2017)
            this.head = header.Replace("KYT", "MMK");//Updated by HWKO (21-Sep-2017)
            this.DataList = dataList;
            this.StartDate = Convert.ToDateTime(startDate);
            this.EndDate = Convert.ToDateTime(endDate);
            this.Currency = currency.Replace("KYT", "MMK");//Updated by HWKO (21-Sep-2017)
            this.SourceBranch = sourceBranch;
            InitializeComponent();
        }

        private void LOMVEW00324_Load(object sender, EventArgs e)
        {
            this.Text = head;

            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            this.rpvPLRepaymentListing.LocalReport.DataSources.Clear();

            ReportParameter[] para = new ReportParameter[12];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[4] = new ReportParameter("Br_Alias", Branch.BranchAlias);
            para[5] = new ReportParameter("StartDate", this.StartDate.ToString("dd/MM/yyyy"));
            para[6] = new ReportParameter("EndDate", this.EndDate.ToString("dd/MM/yyyy"));
            para[7] = new ReportParameter("BrCode", this.SourceBranch);
            para[8] = new ReportParameter("Title", this.head);
            para[9] = new ReportParameter("Currency", this.Currency);
            para[10] = new ReportParameter("TotalRecords", Convert.ToString(DataList.Count));

            //Commented by HWKO (31-Oct-2017)
            //Image img = null;
            //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            //{
            //    img = System.Drawing.Image.FromStream(stream);
            //    img.Save(tempFilePath);
            //}

            string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

            para[11] = new ReportParameter("BankLogo", "file:////" + tempFilePath);

            this.rpvPLRepaymentListing.LocalReport.EnableExternalImages = true;
            this.rpvPLRepaymentListing.LocalReport.SetParameters(para);
            this.rpvPLRepaymentListing.RefreshReport();

            ReportDataSource dataset = new ReportDataSource("DSLOMRDLC00045", this.DataList);
            this.rpvPLRepaymentListing.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.DataList;
            this.rpvPLRepaymentListing.LocalReport.Refresh();

            this.rpvPLRepaymentListing.RefreshReport();
        }
    }
}
