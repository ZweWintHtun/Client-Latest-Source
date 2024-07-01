using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Pfm.Dmd;
using Microsoft.Reporting.WinForms;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Utt;
using System.IO;

namespace Ace.Cbs.Tcm.Vew
{
    public partial class TCMVEW00047 : BaseDockingForm
    {
        #region Properties
        public IList<PFMDTO00042> DataLists { get; set; }
        public string Header { get; set; }
        public string DateTime { get; set; }
        public string Branch { get; set; }
        public string Currency { get; set; }
        #endregion

        #region Constructor
        public TCMVEW00047()
        {
            InitializeComponent();
        }

        public TCMVEW00047(IList<PFMDTO00042> PrintDataLists, string header, string datetime,string branch, string currency)
        {
            this.DataLists =PrintDataLists;
            this.Header = header;
            this.DateTime = datetime;
            this.Branch = branch;
            this.Currency = currency.Replace("KYT","MMK");//Updated by HWKO (25-Sep-2017)
            InitializeComponent();
        }
        #endregion

        #region Events
        private void TCMCleanCashReport_Load(object sender, EventArgs e)
        {
            this.Text = this.Header;
            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            this.rpvCleanCashReportViewer.LocalReport.DataSources.Clear();

            ReportParameter[] para = new ReportParameter[12];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[10] = new ReportParameter("BrCode", Branch.BranchCode);
            para[11] = new ReportParameter("Br_Alias", Branch.BranchAlias);

            //Commented by HWKO (31-Oct-2017)
            //Image img = null;
            //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            //{
            //    img = System.Drawing.Image.FromStream(stream);

            //    img.Save(tempFilePath);
            //}

            string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

            para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[5] = new ReportParameter("Header", this.Header);
            para[6] = new ReportParameter("DateTime", this.DateTime);
            para[7] = new ReportParameter("Branch", this.Branch);
            para[8] = new ReportParameter("Currency", this.Currency);
            para[9] = new ReportParameter("TotalRecords", this.DataLists.Count.ToString());

            this.rpvCleanCashReportViewer.LocalReport.EnableExternalImages = true;
            this.rpvCleanCashReportViewer.LocalReport.SetParameters(para);
            this.rpvCleanCashReportViewer.RefreshReport();
            ReportDataSource dataset = new ReportDataSource("CleanCashDataSets", this.DataLists);
            this.rpvCleanCashReportViewer.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.DataLists;
            rpvCleanCashReportViewer.LocalReport.Refresh();
            this.rpvCleanCashReportViewer.RefreshReport();
        }
        #endregion
    }
}

