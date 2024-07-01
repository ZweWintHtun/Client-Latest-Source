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
    public partial class LOMVEW00048 : BaseForm
    {
        IList<LOMDTO00047> DataList { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string Currency { get; set; }
        string SourceBranch { get; set; }
        string head { get; set; }

        public LOMVEW00048()
        {
            InitializeComponent();
        }

        public LOMVEW00048(IList<LOMDTO00047> dataList,string startDate,string endDate,string currency,
            string sourceBranch, string header)
        {
            this.Text = header.Replace("KYT", "MMK");//Updated by HWKO (22-Sep-2017)
            this.head = header.Replace("KYT", "MMK");//Updated by HWKO (22-Sep-2017)
            this.DataList = dataList;
            this.StartDate = Convert.ToDateTime(startDate);
            this.EndDate = Convert.ToDateTime(endDate);
            this.Currency = currency.Replace("KYT", "MMK");//Updated by HWKO (22-Sep-2017)
            this.SourceBranch = sourceBranch;
            InitializeComponent();
        }

        private void LOMVEW00048_Load(object sender, EventArgs e)
        {
            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            this.rpvODListing.LocalReport.DataSources.Clear();

            ReportParameter[] para = new ReportParameter[12];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[7] = new ReportParameter("Br_Alias", Branch.BranchAlias);

            Image img = null;
            string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

            //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            //{
            //    img = System.Drawing.Image.FromStream(stream);

            //    img.Save(tempFilePath);
            //}

            para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[9] = new ReportParameter("StartDate", this.StartDate.ToString("dd/MM/yyyy"));
            para[10] = new ReportParameter("EndDate", this.EndDate.ToString("dd/MM/yyyy"));
            para[5] = new ReportParameter("Title", this.head);
            para[8] = new ReportParameter("TotalRecords", Convert.ToString(DataList.Count));
            para[6] = new ReportParameter("BrCode", this.SourceBranch);
            para[11] = new ReportParameter("Currency", this.Currency);

            this.rpvODListing.LocalReport.EnableExternalImages = true;
            this.rpvODListing.LocalReport.SetParameters(para);
            this.rpvODListing.RefreshReport();

            ReportDataSource dataset = new ReportDataSource("DSLOMRDLC00005", this.DataList);
            this.rpvODListing.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.DataList;
            this.rpvODListing.LocalReport.Refresh();

            this.rpvODListing.RefreshReport();
        }
    }
}
