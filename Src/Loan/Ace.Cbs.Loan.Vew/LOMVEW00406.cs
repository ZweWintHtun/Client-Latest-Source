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
using System.IO;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Loan.Dmd.DTO;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00406 : BaseForm
    {
        IList<LOMDTO00406> DataList { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string Currency { get; set; }
        string SourceBranch { get; set; }
        string head { get; set; }
        string BLType { get; set; }
        string RptName { get; set; }

        // Added By AAM (11-Dec-2017)
        string businessTypes { get; set; }
        string interestPaidStatus { get; set; }

        public LOMVEW00406()
        {
            InitializeComponent();
        }
        public LOMVEW00406(IList<LOMDTO00406> dataList, string startDate, string endDate, string currency,
                                              string sourceBranch, string header, string bLType, string rptName,
                                              string businessTypes,string interestPaidStatus) // Added two parametes by AAM(11-Dec-2017).
        {
            this.Text = header.Replace("KYT","MMK");//Updated by HWKO (20-Sep-2017)
            this.head = header.Replace("KYT","MMK");//Updated by HWKO (20-Sep-2017)
            this.StartDate = Convert.ToDateTime(startDate);
            this.EndDate = Convert.ToDateTime(endDate);
            this.DataList = dataList;// this.CheckStatusAndChangeStatus(dataList); // Modified By AAM (12-Dec-2017)
            this.Currency = currency.Replace("KYT", "MMK");//Updated by HWKO (20-Sep-2017)
            this.SourceBranch = sourceBranch; 
            if (bLType == "")
            {
                this.BLType = "ALL";
            }
            else
            {
                this.BLType = bLType;
            }
            this.RptName = rptName;

            this.businessTypes = businessTypes;
            this.interestPaidStatus = interestPaidStatus;

            InitializeComponent();
        }

         public IList<LOMDTO00406> CheckStatusAndChangeStatus(IList<LOMDTO00406> dataList)
        {
            IList<LOMDTO00406> resultDataList = new List<LOMDTO00406>();
            for (int i = 0; i < dataList.Count; i++)
            {
                if (dataList[i].InterestStatus==true)//(dataList[i].InterestStatus.ToString() == "1")   // Modified By AAM (11-Dec-2017)
                {
                    dataList[i].InterestPaidStatus = "Paid";
                }
                else
                {
                    if (dataList[i].InterestStatus == null)
                    {
                        //if (Convert.ToDateTime(dataList[i].GracePeriodDueDate).ToString("dd/MM/yyyy") == DateTime.Now.ToString("dd/MM/yyyy") || dataList[i].GracePeriodDueDate > DateTime.Now)
                        //{
                        //    dataList[i].InterestPaidStatus = "Need To Pay";
                        //}
                        //else
                        //{
                        //    dataList[i].InterestPaidStatus = "Absent";
                        //} // Commented By AAM ( 11-Dec-2017)

                        dataList[i].InterestPaidStatus = "Need To Pay"; // Added By AAM (11-Dec-2017)

                    }
                   //else if (dataList[i].ODAmount == dataList[i].RepayInterestAmount) // All OD
                   // {
                   //     dataList[i].InterestPaidStatus = "Absent";
                   // } // Commented By AAM ( 11-Dec-2017)

                    dataList[i].InterestPaidStatus = "Absent";
                }
                resultDataList.Add(dataList[i]);
                }
            return resultDataList;
        }

        private void LOMVEW00406_Load(object sender, EventArgs e)
        {
            if (RptName == "ALL" || RptName == "") this.BL_InterestDueListingByAll();
            else this.BL_InterestDueListingByBLNo();
            this.rpvLoans.RefreshReport();
        }
        public void BL_InterestDueListingByAll()
        {
            this.rpvLoans.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00039.rdlc";

            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            this.rpvLoans.LocalReport.DataSources.Clear();

            ReportParameter[] para = new ReportParameter[14]; // Modified By AAM (11-Dec-2017) 13 to 14.
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
           

            //Image img = null;
            //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            //{
            //    img = System.Drawing.Image.FromStream(stream);
            //    img.Save(tempFilePath);
            //}

            para[11] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[12] = new ReportParameter("BLoansType", this.BLType);
            para[13] = new ReportParameter("InterestPaidStatus", this.interestPaidStatus); // Added By AAM (11-Dec-2017)

            this.rpvLoans.LocalReport.EnableExternalImages = true;
            //rpvLoans.LocalReport.ReportEmbeddedResource = "CommonLayer.Reports.SalesByPrice.rdlc";
            this.rpvLoans.LocalReport.SetParameters(para);
            this.rpvLoans.RefreshReport();

            ReportDataSource dataset = new ReportDataSource("DSLOMRDLC00039", this.DataList);
            this.rpvLoans.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.DataList;
            this.rpvLoans.LocalReport.Refresh();
            this.rpvLoans.RefreshReport();
        }

        public void BL_InterestDueListingByBLNo()
        {
            //this.rpvLoans.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00061.rdlc";

            this.rpvLoans.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00039.rdlc";

            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            this.rpvLoans.LocalReport.DataSources.Clear();

            ReportParameter[] para = new ReportParameter[14]; // Modified By AAM (11-Dec-2017) 13 to 14.
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
            
            //Image img = null;
            //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            //{
            //    img = System.Drawing.Image.FromStream(stream);
            //    img.Save(tempFilePath);
            //}

            para[11] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[12] = new ReportParameter("BLoansType", this.BLType);
            para[13] = new ReportParameter("InterestPaidStatus", this.interestPaidStatus); // Added By AAM (11-Dec-2017)

            this.rpvLoans.LocalReport.EnableExternalImages = true;
            //rpvLoans.LocalReport.ReportEmbeddedResource = "CommonLayer.Reports.SalesByPrice.rdlc";
            this.rpvLoans.LocalReport.SetParameters(para);
            this.rpvLoans.RefreshReport();

            ReportDataSource dataset = new ReportDataSource("DSLOMRDLC00039", this.DataList);
            this.rpvLoans.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.DataList;
            this.rpvLoans.LocalReport.Refresh();
            this.rpvLoans.RefreshReport();
        }
    }
}
