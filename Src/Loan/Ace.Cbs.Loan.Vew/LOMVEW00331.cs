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
using Ace.Cbs.Tel.Dmd;


namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00331 : BaseForm
    {
        IList<TLMDTO00018> DataList { get; set; }
        string Currency { get; set; }
        string SourceBranch { get; set; }
        string head { get; set; }

        public LOMVEW00331()
        {
            InitializeComponent();
        }

        public LOMVEW00331(IList<TLMDTO00018> dataList, string currency,
            string sourceBranch, string header)
        {
            this.Text = header.Replace("KYT", "MMK");
            this.head = header.Replace("KYT", "MMK");
            this.DataList = dataList;
            this.Currency = currency.Replace("KYT", "MMK");
            this.SourceBranch = sourceBranch;
            InitializeComponent();
        }

        private void LOMVEW00331_Load(object sender, EventArgs e)
        {
            this.Text = head;

            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            this.rpvBLVrOstdListing.LocalReport.DataSources.Clear();

            ReportParameter[] para = new ReportParameter[10];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[4] = new ReportParameter("Br_Alias", Branch.BranchAlias);
            para[5] = new ReportParameter("BrCode", this.SourceBranch);
            para[6] = new ReportParameter("Title", this.head);
            para[7] = new ReportParameter("Currency", this.Currency);
            para[8] = new ReportParameter("TotalRecords", Convert.ToString(DataList.Count));

            //Commented by HWKO (31-Oct-2017)
            //Image img = null;
            //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            //{
            //    img = System.Drawing.Image.FromStream(stream);
            //    img.Save(tempFilePath);
            //}

            string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

            para[9] = new ReportParameter("BankLogo", "file:////" + tempFilePath);

            this.rpvBLVrOstdListing.LocalReport.EnableExternalImages = true;
            this.rpvBLVrOstdListing.LocalReport.SetParameters(para);
            this.rpvBLVrOstdListing.RefreshReport();

            ReportDataSource dataset = new ReportDataSource("DSLOMRDLC00056", this.DataList);
            this.rpvBLVrOstdListing.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.DataList;
            this.rpvBLVrOstdListing.LocalReport.Refresh();

            this.rpvBLVrOstdListing.RefreshReport();
        }
    }
}
