using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Admin.DataModel;
using Microsoft.Reporting.WinForms;
using System.IO;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.CXClient.Controls;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00409 : BaseForm
    {
        #region Properties
        IList<LOMDTO00405> DataList { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string Currency { get; set; }
        string SourceBranch { get; set; }
        decimal MaximumAmount { get; set; }
        decimal MinimumAmount { get; set; }
        string head { get; set; }
        string BLType { get; set; }
        string RptName { get; set; }
        #endregion

        #region Constructor
        public LOMVEW00409()
        {
            InitializeComponent();
        }
         public LOMVEW00409(IList<LOMDTO00405> dataList, string startDate, string endDate, string currency,
            string sourceBranch, decimal minAmt, decimal maxAmt, string header, string bLType,string rptName)
        {
            this.Text = header.Replace("KYT", "MMK");//Updated by HWKO (20-Sep-2017)
            this.head = header.Replace("KYT", "MMK");//Updated by HWKO (20-Sep-2017)
            this.DataList = dataList;
            this.StartDate = Convert.ToDateTime(startDate);
            this.EndDate = Convert.ToDateTime(endDate);
            this.Currency = currency.Replace("KYT", "MMK");//Updated by HWKO (20-Sep-2017)
            this.SourceBranch = sourceBranch;
            this.MinimumAmount = minAmt;
            this.MaximumAmount = maxAmt;
            if (bLType == "")
            {
                this.BLType = "All";
            }
            else
            {
                this.BLType = bLType;
            }
            this.RptName = rptName;
            InitializeComponent();
        }
         //public LOMVEW00409(IList<LOMDTO00405> dataList, string startDate, string endDate, string currency,
         //   string sourceBranch, decimal minAmt, decimal maxAmt, string header, string bLType, string rptName)
         //{
         //    this.Text = header.Replace("KYT", "MMK");//Updated by HWKO (20-Sep-2017)
         //    this.head = header.Replace("KYT", "MMK");//Updated by HWKO (20-Sep-2017)
         //    this.DataList = dataList;
         //    this.StartDate = Convert.ToDateTime(startDate);
         //    this.EndDate = Convert.ToDateTime(endDate);
         //    this.Currency = currency.Replace("KYT", "MMK");
         //    this.SourceBranch = sourceBranch;
         //    this.MinimumAmount = minAmt;
         //    this.MaximumAmount = maxAmt;
         //    this.BLType = bLType;
         //    this.RptName = rptName;
         //    InitializeComponent();
         //}
        #endregion

        #region Event
         private void LOMVEW00409_Load(object sender, EventArgs e)
         {
             if (RptName == "All" || RptName == "") this.BL_ListingByGradeAll();
             else this.BL_ListingByGradeByBLNo();
             this.rpvBL.RefreshReport();
        }
        #endregion

        #region Methods 

        public void BL_ListingByGradeAll() ///New
        {
            this.rpvBL.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00060.rdlc";
            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            this.rpvBL.LocalReport.DataSources.Clear();

            ReportParameter[] para = new ReportParameter[13];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);

            Image img = null;
            string tempFilePath = Application.StartupPath + "\\pristinelogo.png";
            para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);

            para[5] = new ReportParameter("Title", this.head);
            para[6] = new ReportParameter("BrCode", this.SourceBranch);
            para[7] = new ReportParameter("Br_Alias", Branch.BranchAlias);
            para[8] = new ReportParameter("TotalRecords", Convert.ToString(DataList.Count));
            para[9] = new ReportParameter("StartDate", this.StartDate.ToString("dd/MM/yyyy"));
            para[10] = new ReportParameter("EndDate", this.EndDate.ToString("dd/MM/yyyy"));
            para[11] = new ReportParameter("Currency", this.Currency);
            para[12] = new ReportParameter("BLType", this.BLType);
           
            this.rpvBL.LocalReport.EnableExternalImages = true;            
            this.rpvBL.LocalReport.SetParameters(para);
            this.rpvBL.RefreshReport();

            ReportDataSource dataset = new ReportDataSource("DSLOMRDLC00040", this.DataList);
            this.rpvBL.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.DataList;
            this.rpvBL.LocalReport.Refresh();
            this.rpvBL.RefreshReport();
            this.rpvBL.RefreshReport();
        }

        public void BL_ListingByGradeByBLNo()
        {
            this.rpvBL.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00040.rdlc";

             BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
             this.rpvBL.LocalReport.DataSources.Clear();

             ReportParameter[] para = new ReportParameter[13];
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

             para[5] = new ReportParameter("Title", this.head);
             para[6] = new ReportParameter("BrCode", this.SourceBranch);
             para[7] = new ReportParameter("Br_Alias", Branch.BranchAlias);
             para[8] = new ReportParameter("TotalRecords", Convert.ToString(DataList.Count));
             para[9] = new ReportParameter("StartDate", this.StartDate.ToString("dd/MM/yyyy"));
             para[10] = new ReportParameter("EndDate", this.EndDate.ToString("dd/MM/yyyy"));             
             para[11] = new ReportParameter("Currency", this.Currency);

            
             para[12] = new ReportParameter("BLType", this.BLType);

             this.rpvBL.LocalReport.EnableExternalImages = true;
             this.rpvBL.LocalReport.SetParameters(para);
             this.rpvBL.RefreshReport();

             ReportDataSource dataset = new ReportDataSource("DSLOMRDLC00040", this.DataList);
             this.rpvBL.LocalReport.DataSources.Add(dataset);
             dataset.Value = this.DataList;
             this.rpvBL.LocalReport.Refresh();
             this.rpvBL.RefreshReport();
             this.rpvBL.RefreshReport();
         }

        #endregion
    }
}
