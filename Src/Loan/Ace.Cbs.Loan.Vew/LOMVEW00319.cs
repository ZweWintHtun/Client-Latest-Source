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
using System.IO;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00319 : BaseForm
    {
        IList<LOMDTO00316> DataList { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string Currency { get; set; }
        string SourceBranch { get; set; }
        string head { get; set; }
        string CompanyName { get; set; }
        string InterestPaidStatus { get; set; }

        public LOMVEW00319()
        {
            InitializeComponent();
        }

        public LOMVEW00319(IList<LOMDTO00316> dataList, string startDate, string endDate, string currency,
            string sourceBranch, string header,string companyName,string interestPaidStatus)
        {
            this.Text = header.Replace("KYT", "MMK");//Updated by HWKO (21-Sep-2017)
            this.head = header.Replace("KYT", "MMK");//Updated by HWKO (21-Sep-2017)
            this.DataList = this.CheckStatusAndChangeStatus(dataList);
            this.StartDate = Convert.ToDateTime(startDate);
            this.EndDate = Convert.ToDateTime(endDate);
            this.Currency = currency.Replace("KYT", "MMK");//Updated by HWKO (21-Sep-2017)
            this.SourceBranch = sourceBranch;
            // Added By AAM (08-Dec-2017)
            this.CompanyName = companyName;
            this.InterestPaidStatus = interestPaidStatus;
            InitializeComponent();
        }

        public IList<LOMDTO00316> CheckStatusAndChangeStatus(IList<LOMDTO00316> dataList)
        {
            this.Text = head;

            IList<LOMDTO00316> resultDataList = new List<LOMDTO00316>();
            for (int i = 0; i < dataList.Count; i++)
            {
                if (dataList[i].Status == "A")
                {
                    dataList[i].Status = "Paid";
                }
                //else if (dataList[i].Status == "")
                //{
                //    dataList[i].Status = "Absent";
                //}
                //else
                //{
                //    dataList[i].Status = "Need To Pay";
                //}
                else
                {
                    if (dataList[i].Status == null)
                    {
                        //if (dataList[i].DueDate.ToString("dd/MM/yyyy") == DateTime.Now.ToString("dd/MM/yyyy") 
                        //    || dataList[i].DueDate > DateTime.Now)//Updated by HWKO (06-Dec-2017)
                        //{  // Modified By AAM (11-Dec-2017)
                            dataList[i].Status = "Need To Pay";
                        //}
                        //else
                        //{
                        //    dataList[i].Status = "Absent";
                        //} // Modified By AAM (11-Dec-2017)
                    }
                    else if (dataList[i].Status == "")
                    {
                        dataList[i].Status = "Absent";
                    }
                }
                resultDataList.Add(dataList[i]);
            }
            return resultDataList;
        }

        private void LOMVEW00319_Load(object sender, EventArgs e)
        {
            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            this.rpvPLIntDuePreList.LocalReport.DataSources.Clear();

            ReportParameter[] para = new ReportParameter[14];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[4] = new ReportParameter("Br_Alias", Branch.BranchAlias);
            para[5] = new ReportParameter("StartDate", this.StartDate.ToString("dd/MM/yyyy"));
            para[6] = new ReportParameter("EndDate", this.EndDate.ToString("dd/MM/yyyy"));
            para[7] = new ReportParameter("BrCode", this.SourceBranch);
            para[8] = new ReportParameter("Title", this.head);
            para[9] = new ReportParameter("Currency", this.Currency);
            para[10] = new ReportParameter("TotalRecords", Convert.ToString(DataList.Count));

            //Commented by HWKO (31-Oct-2017)
            //Image img = null;
            //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            //{
            //    img = System.Drawing.Image.FromStream(stream);
            //    img.Save(tempFilePath);
            //}

            string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

            para[11] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            // Added by AAM (08-Dec-2017)
            para[12] = new ReportParameter("CompanyName", this.CompanyName);
            para[13] = new ReportParameter("InterestPaidStatus", this.InterestPaidStatus);

            this.Text = this.head;//Added by HMW (20-03-2023)
            this.rpvPLIntDuePreList.LocalReport.EnableExternalImages = true;
            this.rpvPLIntDuePreList.LocalReport.SetParameters(para);
            this.rpvPLIntDuePreList.RefreshReport();

            ReportDataSource dataset = new ReportDataSource("DSLOMRDLC00032", this.DataList);
            this.rpvPLIntDuePreList.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.DataList;
            this.rpvPLIntDuePreList.LocalReport.Refresh();

            this.rpvPLIntDuePreList.RefreshReport();
        }
    }
}
