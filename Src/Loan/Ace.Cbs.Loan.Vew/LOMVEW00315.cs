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
    public partial class LOMVEW00315 : BaseForm
    {
        IList<LOMDTO00314> DataList { get; set; }
        DateTime SelectedDate { get; set; }        
        //string Currency { get; set; }
        string SourceBranch { get; set; }
        string head { get; set; }

        public LOMVEW00315()
        {
            InitializeComponent();
        }

        public LOMVEW00315(IList<LOMDTO00314> dataList, string selectedDate, string sourceBranch, string header)
        {
            this.Text = header.Replace("KYT", "MMK");//Updated by HWKO (20-Sep-2017)
            this.head = header.Replace("KYT", "MMK");//Updated by HWKO (20-Sep-2017)
            this.DataList = dataList;
            this.SelectedDate = Convert.ToDateTime(selectedDate);
            //this.Currency = currency;
            this.SourceBranch = sourceBranch;
            InitializeComponent();
        }

        private void LOMVEW00315_Load(object sender, EventArgs e)
        {
            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            this.rpvExpiredLandLeaseListing.LocalReport.DataSources.Clear();

            ReportParameter[] para = new ReportParameter[10];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[4] = new ReportParameter("Br_Alias", Branch.BranchAlias);
            para[5] = new ReportParameter("SelectedDate", this.SelectedDate.ToString("dd/MM/yyyy"));
            para[6] = new ReportParameter("BrCode", this.SourceBranch);
            para[7] = new ReportParameter("Title", this.head);
            //para[9] = new ReportParameter("Currency", this.Currency);
            para[8] = new ReportParameter("TotalRecords", Convert.ToString(DataList.Count));

            Image img = null;
            //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            //{
            //    img = System.Drawing.Image.FromStream(stream);
            //    img.Save(tempFilePath);
            //}

            string tempFilePath = Application.StartupPath + "\\pristinelogo.png";
            para[9] = new ReportParameter("BankLogo", "file:////" + tempFilePath);

            this.rpvExpiredLandLeaseListing.LocalReport.EnableExternalImages = true;
            this.rpvExpiredLandLeaseListing.LocalReport.SetParameters(para);
            this.rpvExpiredLandLeaseListing.RefreshReport();

            ReportDataSource dataset = new ReportDataSource("DSLOMRDLC00030", this.DataList);
            this.rpvExpiredLandLeaseListing.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.DataList;
            this.rpvExpiredLandLeaseListing.LocalReport.Refresh();

            this.rpvExpiredLandLeaseListing.RefreshReport();
        }
    }
}
