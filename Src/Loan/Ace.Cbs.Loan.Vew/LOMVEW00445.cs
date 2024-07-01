using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Loan.Dmd.DTO;
using Microsoft.Reporting.WinForms;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00445 : BaseForm
    {
        private IList<LOMDTO00444> LimitExtendList;
        private string HeaderName;
        private string Date;
        public string RptName;
        public string SourceBr;

        public LOMVEW00445()
        {
            InitializeComponent();
        }

        //LimitExtendList, this.View.Date.ToString("dd/MM/yyyy"), this.View.rptName, this.View.SourceBr 
        public LOMVEW00445(IList<LOMDTO00444> limitExtendList, string date, string rptName, string sourceBr)
        {
            InitializeComponent();
            this.LimitExtendList = limitExtendList;
            this.Date = date;
            this.RptName = rptName;
            this.SourceBr = sourceBr;
        }

        private void PrintLimitExtendListing()
        {
            this.rpvExtendLimitList.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00098.rdlc";

            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            this.rpvExtendLimitList.LocalReport.DataSources.Clear();

            ReportParameter[] para = new ReportParameter[9];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[4] = new ReportParameter("Br_Alias", Branch.BranchAlias);
            para[5] = new ReportParameter("Date", this.Date);
            para[6] = new ReportParameter("TotalRecords", Convert.ToString(LimitExtendList.Count));

            Image img = null;
            string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

            para[7] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[8] = new ReportParameter("BrCode", this.SourceBr);
            this.rpvExtendLimitList.LocalReport.EnableExternalImages = true;
            this.rpvExtendLimitList.LocalReport.SetParameters(para);
            this.rpvExtendLimitList.RefreshReport();

            ReportDataSource dataset = new ReportDataSource("DSLimitExtendList", this.LimitExtendList);
            this.rpvExtendLimitList.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.LimitExtendList;
            this.rpvExtendLimitList.LocalReport.Refresh();
            this.rpvExtendLimitList.RefreshReport();
        }

        private void LOMVEW00445_Load(object sender, EventArgs e)
        {
            PrintLimitExtendListing();
        }
    }
}
