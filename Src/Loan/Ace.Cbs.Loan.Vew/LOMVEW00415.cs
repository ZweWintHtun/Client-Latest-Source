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
using Microsoft.Reporting.WinForms;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Cle;
using System.IO;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00415 : BaseForm
    {
        IList<LOMDTO00405> DataList { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string Currency { get; set; }
        string SourceBranch { get; set; }
        string head { get; set; }
        string BLType { get; set; }
        string RptName { get; set; }

        public LOMVEW00415()
        {
            InitializeComponent();
        }
         public LOMVEW00415(IList<LOMDTO00405> dataList, string startDate, string endDate, string currency,
            string sourceBranch, string header, string bLType, string rptName)
        {
            this.Text = header.Replace("KYT", "MMK");//Updated by HWKO (20-Sep-2017)
            this.head = header.Replace("KYT", "MMK");//Updated by HWKO (20-Sep-2017)
            this.StartDate = Convert.ToDateTime(startDate);
            this.EndDate = Convert.ToDateTime(endDate);
            this.DataList = dataList;
            this.Currency = currency.Replace("KYT", "MMK");//Updated by HWKO (20-Sep-2017)
            this.SourceBranch = sourceBranch;
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
        private void LOMVEW00415_Load(object sender, EventArgs e)
        {
            if (RptName == "All" || RptName == "") this.BL_RepayAll();
            else this.BL_RepayByBLNo();
            this.rpvLoans.RefreshReport();     
        }
        public void BL_RepayAll() ///New
        {
            this.rpvLoans.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00043.rdlc";

            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            this.rpvLoans.LocalReport.DataSources.Clear();

            ReportParameter[] para = new ReportParameter[13];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[4] = new ReportParameter("Br_Alias", Branch.BranchAlias);
            para[5] = new ReportParameter("StartDate", this.StartDate.ToString("dd/MM/yyyy"));
            para[6] = new ReportParameter("EndDate", this.EndDate.ToString("dd/MM/yyyy"));
            para[7] = new ReportParameter("BrCode", this.SourceBranch);
            para[8] = new ReportParameter("Title", this.head);
            para[9] = new ReportParameter("Currency", this.Currency.Replace("KYT", "MMK"));//Updated by HWKO (20-Sep-2017)
            para[10] = new ReportParameter("TotalRecords", Convert.ToString(DataList.Count));

            Image img = null;
            string tempFilePath = Application.StartupPath + "\\pristinelogo.png";
            //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            //{
            //    img = System.Drawing.Image.FromStream(stream);
            //    img.Save(tempFilePath);
            //}

            para[11] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[12] = new ReportParameter("BLoanType", this.BLType);

            this.rpvLoans.LocalReport.EnableExternalImages = true;
            this.rpvLoans.LocalReport.SetParameters(para);
            this.rpvLoans.RefreshReport();

            ReportDataSource dataset = new ReportDataSource("DSLOMRDLC00043", this.DataList);
            this.rpvLoans.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.DataList;
            this.rpvLoans.LocalReport.Refresh();
            this.rpvLoans.RefreshReport();
        }

        public void BL_RepayByBLNo() 
        {
            this.rpvLoans.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00064.rdlc";

            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            this.rpvLoans.LocalReport.DataSources.Clear();

            ReportParameter[] para = new ReportParameter[13];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[4] = new ReportParameter("Br_Alias", Branch.BranchAlias);
            para[5] = new ReportParameter("StartDate", this.StartDate.ToString("dd/MM/yyyy"));
            para[6] = new ReportParameter("EndDate", this.EndDate.ToString("dd/MM/yyyy"));
            para[7] = new ReportParameter("BrCode", this.SourceBranch);
            para[8] = new ReportParameter("Title", this.head);
            para[9] = new ReportParameter("Currency", this.Currency.Replace("KYT", "MMK"));//Updated by HWKO (20-Sep-2017)
            para[10] = new ReportParameter("TotalRecords", Convert.ToString(DataList.Count));

            Image img = null;
            string tempFilePath = Application.StartupPath + "\\pristinelogo.png";
            //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            //{
            //    img = System.Drawing.Image.FromStream(stream);
            //    img.Save(tempFilePath);
            //}

            para[11] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[12] = new ReportParameter("BLoanType", this.BLType);

            this.rpvLoans.LocalReport.EnableExternalImages = true;
            this.rpvLoans.LocalReport.SetParameters(para);
            this.rpvLoans.RefreshReport();

            ReportDataSource dataset = new ReportDataSource("DSLOMRDLC00043", this.DataList);
            this.rpvLoans.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.DataList;
            this.rpvLoans.LocalReport.Refresh();
            this.rpvLoans.RefreshReport();
        }
    }
}
