using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Microsoft.Reporting.WinForms;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Utt;
using System.IO;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Dmd.DTO;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00038 : BaseForm
    {
        #region variables
        //IList<LOMDTO00034> DataList { get; set; }
        IList<LOMDTO00204> DataList { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string Currency { get; set; }
        string SourceBranch { get; set; }
        string head { get; set; }
        string RptName { get; set; }
        #endregion

        #region Constructor
        public LOMVEW00038()
        {
            InitializeComponent();
        }
        public LOMVEW00038(IList<LOMDTO00204> dataList, string startDate, string endDate, string currency, string sourceBranch, string header,string rptName)
        {
            InitializeComponent();

            this.Text = header.Replace("KYT", "MMK");//Updated by HWKO (20-Sep-2017)
            //this.head = header;
            this.DataList = dataList;
            this.StartDate = Convert.ToDateTime(startDate);
            this.EndDate = Convert.ToDateTime(endDate);
            this.SourceBranch = sourceBranch;
            this.Currency = currency;
            this.RptName = rptName;
        }
        #endregion

        #region Event
        private void LOMVEW00038_Load(object sender, EventArgs e)
        {
            if (RptName == "All" || RptName == "") this.BL_RegInformationAll();
            else this.BL_RegInformationByLoansType();
            this.rpvLoanRegistrationListing.RefreshReport();
        }
        public void BL_RegInformationAll() 
         {
            this.rpvLoanRegistrationListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00002.rdlc";
            this.rpvLoanRegistrationListing.LocalReport.DataSources.Clear();
            head = this.Text;
            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            this.rpvLoanRegistrationListing.LocalReport.DataSources.Clear();

            ReportParameter[] para = new ReportParameter[9];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);         

            Image img = null;
            string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

            //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            //{
            //    img = System.Drawing.Image.FromStream(stream);

            //    img.Save(tempFilePath);
            //}

            para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[5] = new ReportParameter("Title", head);
            para[6] = new ReportParameter("BrCode", Branch.BranchCode);
            para[7] = new ReportParameter("Br_Alias", Branch.BranchAlias);
            para[8] = new ReportParameter("TotalRecords", Convert.ToString(DataList.Count));
            this.rpvLoanRegistrationListing.LocalReport.EnableExternalImages = true;
            this.rpvLoanRegistrationListing.LocalReport.SetParameters(para);
            //ReportDataSource dataset = new ReportDataSource("MNMDS00039", this.DataList);
            ReportDataSource dataset = new ReportDataSource("DSLoanRegistrationListing", this.DataList);
            this.rpvLoanRegistrationListing.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.DataList;
            this.rpvLoanRegistrationListing.LocalReport.Refresh();
            this.rpvLoanRegistrationListing.RefreshReport();
        }

        public void BL_RegInformationByLoansType()
        {
            this.rpvLoanRegistrationListing.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00070.rdlc";
            this.rpvLoanRegistrationListing.LocalReport.DataSources.Clear();
            head = this.Text;
            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            this.rpvLoanRegistrationListing.LocalReport.DataSources.Clear();

            ReportParameter[] para = new ReportParameter[9];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);

            Image img = null;
            string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

            //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            //{
            //    img = System.Drawing.Image.FromStream(stream);

            //    img.Save(tempFilePath);
            //}

            para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[5] = new ReportParameter("Title", head);
            para[6] = new ReportParameter("BrCode", Branch.BranchCode);
            para[7] = new ReportParameter("Br_Alias", Branch.BranchAlias);
            para[8] = new ReportParameter("TotalRecords", Convert.ToString(DataList.Count));
            this.rpvLoanRegistrationListing.LocalReport.EnableExternalImages = true;
            this.rpvLoanRegistrationListing.LocalReport.SetParameters(para);
            //ReportDataSource dataset = new ReportDataSource("MNMDS00039", this.DataList);
            ReportDataSource dataset = new ReportDataSource("DSLoanRegistrationListing", this.DataList);
            this.rpvLoanRegistrationListing.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.DataList;
            this.rpvLoanRegistrationListing.LocalReport.Refresh();
            this.rpvLoanRegistrationListing.RefreshReport();
        }
        #endregion
    }
}
