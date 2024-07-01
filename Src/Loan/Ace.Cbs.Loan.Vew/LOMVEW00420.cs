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
    public partial class LOMVEW00420 : BaseForm
    {
        IList<LOMDTO00406> blAbsentHistoryList { get; set; }
        IList<LOMDTO00406> blRepaymentHistory_Enquiry { get; set; }

        string Currency { get; set; }
        string SourceBr { get; set; }
        string startDate { get; set; }
        string endDate { get; set; }
        string head { get; set; }
        string LNo { get; set; }
        string AcctNo { get; set; }
        string CustName { get; set; }
        string Phone { get; set; }
        string Address { get; set; }
        string rptName { get; set; }

        public LOMVEW00420()
        {
            InitializeComponent();
        }

        public LOMVEW00420(IList<LOMDTO00406> blAbsentHistoryList, string header, string sourceBr, string startDate, string endDate, string rptName)
        {
            this.blAbsentHistoryList = blAbsentHistoryList;
            this.SourceBr = sourceBr;
            this.startDate = startDate;
            this.endDate = endDate;
            this.head = header;
            this.rptName = rptName;
            InitializeComponent();
        }
        public LOMVEW00420(IList<LOMDTO00406> blRepaymentHistory_Enquiry, string header, string sourceBr, string rptName)
        {
            this.blRepaymentHistory_Enquiry = blRepaymentHistory_Enquiry;
            this.SourceBr = sourceBr;
            this.head = header;
            this.rptName = rptName;
            InitializeComponent();
        }
        public void BL_AbsentHistoryList_Report()
        {
            try
            {
                this.rptBusinessLaons.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00058.rdlc";
                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                this.rptBusinessLaons.LocalReport.DataSources.Clear();

                ReportParameter[] para = new ReportParameter[11];
                para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
                para[1] = new ReportParameter("BranchName", Branch.Address);
                para[2] = new ReportParameter("Phone", Branch.Phone);
                para[3] = new ReportParameter("Fax", Branch.Fax);

                Image img = null;
                string tempFilePath = Application.StartupPath + "\\pristinelogo.png";
                //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                //{
                //    img = System.Drawing.Image.FromStream(stream);
                //    img.Save(tempFilePath);
                //}
                para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                para[5] = new ReportParameter("Title", this.head);
                para[6] = new ReportParameter("BrCode", this.SourceBr);
                para[7] = new ReportParameter("Br_Alias", Branch.BranchAlias);
                para[8] = new ReportParameter("TotalRecords", Convert.ToString(blAbsentHistoryList.Count));
                para[9] = new ReportParameter("StartDate", this.startDate);
                para[10] = new ReportParameter("EndDate", this.endDate);

                this.rptBusinessLaons.LocalReport.EnableExternalImages = true;
                this.rptBusinessLaons.LocalReport.SetParameters(para);

                ReportDataSource dataset = new ReportDataSource("BLAbsentHistoryList", this.blAbsentHistoryList);
                this.rptBusinessLaons.LocalReport.DataSources.Add(dataset);
                dataset.Value = this.blAbsentHistoryList;
                this.rptBusinessLaons.RefreshReport();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void BL_RepaymentHistory_Enquiry_Report()
        {
            try
            {
                this.rptBusinessLaons.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00059.rdlc";
                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                this.rptBusinessLaons.LocalReport.DataSources.Clear();

                ReportParameter[] para = new ReportParameter[9];
                para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
                para[1] = new ReportParameter("BranchName", Branch.Address);
                para[2] = new ReportParameter("Phone", Branch.Phone);
                para[3] = new ReportParameter("Fax", Branch.Fax);

                Image img = null;
                //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                //{
                //    img = System.Drawing.Image.FromStream(stream);
                //    img.Save(tempFilePath);
                //}

                string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

                para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                para[5] = new ReportParameter("Title", this.head);
                para[6] = new ReportParameter("BrCode", this.SourceBr);
                para[7] = new ReportParameter("Br_Alias", Branch.BranchAlias);
                para[8] = new ReportParameter("TotalRecords", Convert.ToString(blRepaymentHistory_Enquiry.Count));

                this.rptBusinessLaons.LocalReport.EnableExternalImages = true;
                this.rptBusinessLaons.LocalReport.SetParameters(para);

                ReportDataSource dataset = new ReportDataSource("BLRepaymentHistory_Enquiry", this.blRepaymentHistory_Enquiry);
                this.rptBusinessLaons.LocalReport.DataSources.Add(dataset);
                dataset.Value = this.blRepaymentHistory_Enquiry;
                this.rptBusinessLaons.RefreshReport();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void LOMVEW00420_Load(object sender, EventArgs e)
        {
            if (rptName == "BLAbsentHistoryList") this.BL_AbsentHistoryList_Report();
            else if (rptName == "BLRepaymentHistory_Enquiry") this.BL_RepaymentHistory_Enquiry_Report();
            this.rptBusinessLaons.RefreshReport();
        }
    }
}
