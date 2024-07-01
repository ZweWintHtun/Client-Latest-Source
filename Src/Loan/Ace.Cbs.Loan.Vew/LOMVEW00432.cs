using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Utt;
using Microsoft.Reporting.WinForms;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00432 : BaseForm
    {
        #region Properties
        private IList<LOMDTO00427> BLList;
        private string HeaderName;
        private string StartDate;
        private string EndDate;
        public string RptName;
        public string SourceBr;
        IList<LOMDTO00427> BlackListResultData;
        #endregion

        #region Constructor
        public LOMVEW00432()
        {
            InitializeComponent();
        }
        public LOMVEW00432(IList<LOMDTO00427> bLList, string headerName, string startDate, string endDate, string rptName,string sourceBr)
        {
            InitializeComponent();
            //if (rptName == "rptExternalCustomer")
            //{
            //    BlackListResultData = new List<LOMDTO00427>();
            //    foreach (LOMDTO00427 item in bLList)
            //    {
            //        LOMDTO00427 bLdata = new LOMDTO00427();

            //        if (item.Name == "" || item.Name == string.Empty)
            //            bLdata.Name = "-";
            //        else
            //            bLdata.Name = item.Name;

            //        bLdata.NRC = item.NRC;

            //        if (item.FatherName == "" || item.FatherName == string.Empty)
            //            bLdata.FatherName = "-";
            //        else
            //            bLdata.FatherName = item.FatherName;

            //        if (Convert.ToString(bLdata.DOB) == "")
            //            bLdata.DOB = Convert.ToDateTime(DBNull.Value);
            //        else
            //            bLdata.DOB = item.DOB;

            //        if (item.Address == "" || item.Address == string.Empty)
            //            bLdata.Address = "-";
            //        else
            //            bLdata.Address = item.Address;

            //        if (item.CompanyName == "" || item.CompanyName == string.Empty)
            //            bLdata.CompanyName = "-";
            //        else
            //            bLdata.CompanyName = item.CompanyName;

            //        bLdata.CreatedDate = item.CreatedDate;
            //        bLdata.UserName = item.UserName;
            //        bLdata.ApprovedUserName = item.ApprovedUserName;

            //        BLList.Add(bLdata);
            //    }
            //}
            //else
            this.BLList = bLList;
            this.HeaderName = headerName; 
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.RptName = rptName;
            this.SourceBr = sourceBr;
        }
        #endregion

        #region Event
        private void LOMVEW00432_Load(object sender, EventArgs e)
        {
            if (this.RptName == "rptInternalCustomer") this.InternalCustomerListing();
            else if (this.RptName == "rptExternalCustomer") this.ExternalCustomerListing();
            else if (this.RptName == "rptInternalHistoryCustomer") this.InternalHistoryCustomerListing();
            else if (this.RptName == "rptExternalHistoryCustomer") this.ExternalHistoryCustomerListing();
        }
        #endregion

        #region Helper Methods

        private void InternalCustomerListing()
        {
            this.rpvBlackList.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00092.rdlc";

            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            this.rpvBlackList.LocalReport.DataSources.Clear();

            ReportParameter[] para = new ReportParameter[11];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[4] = new ReportParameter("Br_Alias", Branch.BranchAlias);
            para[5] = new ReportParameter("StartDate", this.StartDate);
            para[6] = new ReportParameter("EndDate", this.EndDate);
            para[7] = new ReportParameter("BrCode", this.SourceBr);
            para[8] = new ReportParameter("Title", this.HeaderName);
            para[9] = new ReportParameter("TotalRecords", Convert.ToString(BLList.Count));

            Image img = null;
            string tempFilePath = Application.StartupPath + "\\pristinelogo.png";


            //Image img = null;
            //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            //{
            //    img = System.Drawing.Image.FromStream(stream);
            //    img.Save(tempFilePath);
            //}

            para[10] = new ReportParameter("BankLogo", "file:////" + tempFilePath);

            this.rpvBlackList.LocalReport.EnableExternalImages = true;
            //rpvBlackList.LocalReport.ReportEmbeddedResource = "CommonLayer.Reports.SalesByPrice.rdlc";
            this.rpvBlackList.LocalReport.SetParameters(para);
            this.rpvBlackList.RefreshReport();

            ReportDataSource dataset = new ReportDataSource("DSLOMVEW00431_DataSet", this.BLList);
            this.rpvBlackList.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.BLList;
            this.rpvBlackList.LocalReport.Refresh();
            this.rpvBlackList.RefreshReport();
        }

        private void ExternalCustomerListing()
        {
            this.rpvBlackList.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00093.rdlc";

            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            this.rpvBlackList.LocalReport.DataSources.Clear();

            ReportParameter[] para = new ReportParameter[11];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[4] = new ReportParameter("Br_Alias", Branch.BranchAlias);
            para[5] = new ReportParameter("StartDate", this.StartDate);
            para[6] = new ReportParameter("EndDate", this.EndDate);
            para[7] = new ReportParameter("BrCode", this.SourceBr);
            para[8] = new ReportParameter("Title", this.HeaderName);
            para[9] = new ReportParameter("TotalRecords", Convert.ToString(BLList.Count));

            Image img = null;
            string tempFilePath = Application.StartupPath + "\\pristinelogo.png";


            //Image img = null;
            //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            //{
            //    img = System.Drawing.Image.FromStream(stream);
            //    img.Save(tempFilePath);
            //}

            para[10] = new ReportParameter("BankLogo", "file:////" + tempFilePath);

            this.rpvBlackList.LocalReport.EnableExternalImages = true;
            //rpvBlackList.LocalReport.ReportEmbeddedResource = "CommonLayer.Reports.SalesByPrice.rdlc";
            this.rpvBlackList.LocalReport.SetParameters(para);
            this.rpvBlackList.RefreshReport();

            ReportDataSource dataset = new ReportDataSource("DSLOMVEW00431_DataSet", this.BLList);
            this.rpvBlackList.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.BLList;
            this.rpvBlackList.LocalReport.Refresh();
            this.rpvBlackList.RefreshReport();
        }

        private void InternalHistoryCustomerListing()
        {
            this.rpvBlackList.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00094.rdlc";

            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            this.rpvBlackList.LocalReport.DataSources.Clear();

            ReportParameter[] para = new ReportParameter[11];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[4] = new ReportParameter("Br_Alias", Branch.BranchAlias);
            para[5] = new ReportParameter("StartDate", this.StartDate);
            para[6] = new ReportParameter("EndDate", this.EndDate);
            para[7] = new ReportParameter("BrCode", this.SourceBr);
            para[8] = new ReportParameter("Title", this.HeaderName);
            para[9] = new ReportParameter("TotalRecords", Convert.ToString(BLList.Count));

            Image img = null;
            string tempFilePath = Application.StartupPath + "\\pristinelogo.png";


            //Image img = null;
            //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            //{
            //    img = System.Drawing.Image.FromStream(stream);
            //    img.Save(tempFilePath);
            //}

            para[10] = new ReportParameter("BankLogo", "file:////" + tempFilePath);

            this.rpvBlackList.LocalReport.EnableExternalImages = true;
            //rpvBlackList.LocalReport.ReportEmbeddedResource = "CommonLayer.Reports.SalesByPrice.rdlc";
            this.rpvBlackList.LocalReport.SetParameters(para);
            this.rpvBlackList.RefreshReport();

            ReportDataSource dataset = new ReportDataSource("DSLOMVEW00431_DataSet", this.BLList);
            this.rpvBlackList.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.BLList;
            this.rpvBlackList.LocalReport.Refresh();
            this.rpvBlackList.RefreshReport();
        }

        private void ExternalHistoryCustomerListing()
        {
            this.rpvBlackList.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00095.rdlc";

            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            this.rpvBlackList.LocalReport.DataSources.Clear();

            ReportParameter[] para = new ReportParameter[11];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[4] = new ReportParameter("Br_Alias", Branch.BranchAlias);
            para[5] = new ReportParameter("StartDate", this.StartDate);
            para[6] = new ReportParameter("EndDate", this.EndDate);
            para[7] = new ReportParameter("BrCode", this.SourceBr);
            para[8] = new ReportParameter("Title", this.HeaderName);
            para[9] = new ReportParameter("TotalRecords", Convert.ToString(BLList.Count));

            Image img = null;
            string tempFilePath = Application.StartupPath + "\\pristinelogo.png";


            //Image img = null;
            //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            //{
            //    img = System.Drawing.Image.FromStream(stream);
            //    img.Save(tempFilePath);
            //}

            para[10] = new ReportParameter("BankLogo", "file:////" + tempFilePath);

            this.rpvBlackList.LocalReport.EnableExternalImages = true;
            //rpvBlackList.LocalReport.ReportEmbeddedResource = "CommonLayer.Reports.SalesByPrice.rdlc";
            this.rpvBlackList.LocalReport.SetParameters(para);
            this.rpvBlackList.RefreshReport();

            ReportDataSource dataset = new ReportDataSource("DSLOMVEW00431_DataSet", this.BLList);
            this.rpvBlackList.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.BLList;
            this.rpvBlackList.LocalReport.Refresh();
            this.rpvBlackList.RefreshReport();
        }

        #endregion
    }
}
