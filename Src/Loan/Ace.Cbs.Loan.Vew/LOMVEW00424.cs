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
using Ace.Cbs.Loan.Dmd.DTO;


namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00424 : BaseForm
    {
        #region Properties
        IList<LOMDTO00423> blDailyPositionListing { get; set; }

        string branchcode { get; set; }
        string header { get; set; }
        string reportName { get; set; }
        string currency { get; set; }
        string bLoanGroup { get; set; }

        #endregion

        #region Constructor
        public LOMVEW00424()
        {
            InitializeComponent();
        }
        public LOMVEW00424(IList<LOMDTO00423> dtoList, string cur,string head , string bcode,string rptName,string loanGroup)
        {
            InitializeComponent();
            this.blDailyPositionListing = dtoList;
            this.branchcode = bcode;
            this.header = head.Replace("KYT", "MMK");
            this.reportName = rptName;
            this.currency = cur.Replace("KYT", "MMK");
            this.bLoanGroup = loanGroup;
        }
        #endregion

        #region RDLC Methods
        public void BL_DailyPositionListing()
        {
            this.rptReport.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00091.rdlc";
            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            this.rptReport.LocalReport.DataSources.Clear();

            ReportParameter[] para = new ReportParameter[11];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);

            Image img = null;
            string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

            para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[5] = new ReportParameter("Currency", this.currency);
            para[6] = new ReportParameter("BrCode", this.branchcode);
            para[7] = new ReportParameter("Br_Alias", Branch.BranchAlias);
            para[8] = new ReportParameter("TotalRecords", Convert.ToString(blDailyPositionListing.Count));

            para[9] = new ReportParameter("Title", this.header);
            para[10] = new ReportParameter("LoansGroup", this.bLoanGroup);

            this.rptReport.LocalReport.EnableExternalImages = true;
            this.rptReport.LocalReport.SetParameters(para);

            ReportDataSource dataset = new ReportDataSource("BLDailyPositionDataSet", this.blDailyPositionListing);
            this.rptReport.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.blDailyPositionListing;
            this.rptReport.RefreshReport();

        }
        #endregion

        #region Event
        private void LOMVEW00424_Load(object sender, EventArgs e)
        {
            #region Methods Call

            if (reportName == "BLDailyPositionListing") this.BL_DailyPositionListing();
            
            #endregion
        }
        #endregion
    }
}
