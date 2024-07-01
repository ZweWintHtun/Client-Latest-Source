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
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Utt;
using Microsoft.Reporting.WinForms;
using System.IO;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00050 : BaseForm
    {
        IList<LOMDTO00035> DataList { get; set; }
        string Currency { get; set; }
        string SourceBranch { get; set; }
        string head { get; set; }

        public LOMVEW00050()
        {
            InitializeComponent();
        }

        public LOMVEW00050(IList<LOMDTO00035> dataList, string currency, string sourceBranch, string header)
        {
            this.Text = header.Replace("KYT", "MMK");//Updated by HWKO (22-Sep-2017)
            this.head = header.Replace("KYT", "MMK");//Updated by HWKO (22-Sep-2017)
            this.DataList = dataList;
            this.Currency = currency.Replace("KYT", "MMK");//Updated by HWKO (22-Sep-2017)
            this.SourceBranch = sourceBranch;
            InitializeComponent();
        }

        private void LOMVEW00050_Load(object sender, EventArgs e)
        {
            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            this.rpvLDPListing.LocalReport.DataSources.Clear();

            ReportParameter[] para = new ReportParameter[11];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[7] = new ReportParameter("Br_Alias", Branch.Bank_Alias);

            Image img = null;
            string tempFilePath = Application.StartupPath + "\\pristinelogo.png";
            //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            //{
            //    img = System.Drawing.Image.FromStream(stream);
            //    img.Save(tempFilePath);
            //}

            para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[5] = new ReportParameter("Title", this.head);
            para[8] = new ReportParameter("TotalRecords", Convert.ToString(DataList.Count));
            para[6] = new ReportParameter("BrCode", this.SourceBranch);
            para[9] = new ReportParameter("Currency", this.Currency);
            para[10] = new ReportParameter("RequireDate",DateTime.Now.ToString("dd/MM/yyyy"));

            this.rpvLDPListing.LocalReport.EnableExternalImages = true;
            this.rpvLDPListing.LocalReport.SetParameters(para);
            this.rpvLDPListing.RefreshReport();

            ReportDataSource dataset = new ReportDataSource("DSLOMRDLC00006", this.DataList);
            this.rpvLDPListing.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.DataList;
            this.rpvLDPListing.LocalReport.Refresh();

            this.rpvLDPListing.RefreshReport();
        }


    }
}
