using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Loan.Dmd;
using Microsoft.Reporting.WinForms;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Utt;
using System.IO;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient.Controls;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00413 : BaseForm
    {
        IList<LOMDTO00406> DataList { get; set; }
        string Currency { get; set; }
        string SourceBranch { get; set; }
        string head { get; set; }
        #region Constructor
        public LOMVEW00413()
        {
            InitializeComponent();
        }
        public LOMVEW00413(IList<LOMDTO00406> dataList, string currency, string sourceBranch, string header)
        {
            this.Text = header.Replace("KYT", "MMK");//Updated by HWKO (20-Sep-2017)
            this.head = header.Replace("KYT", "MMK");//Updated by HWKO (20-Sep-2017)
            //this.DataList = this.CheckStatusAndChangeStatus(dataList);
            this.DataList = dataList;
            this.Currency = currency;
            this.SourceBranch = sourceBranch;
            InitializeComponent();
        }
        #endregion

        //public IList<LOMDTO00406> CheckStatusAndChangeStatus(LOMDTO00406 dataList)
        //{
        //    IList<LOMDTO00406> resultDataList = new List<LOMDTO00406>();
        //    for (int i = 0; i < 1; i++)
        //    {
        //        resultDataList.Add(dataList);
        //    }
        //    return resultDataList;
        //}

        private void LOMVEW00413_Load(object sender, EventArgs e)
        {
            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            this.rpvLoans.LocalReport.DataSources.Clear();


            string recordCount = "1";
            ReportParameter[] para = new ReportParameter[10];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[4] = new ReportParameter("Br_Alias", Branch.BranchAlias);
            para[5] = new ReportParameter("BrCode", this.SourceBranch);
            para[6] = new ReportParameter("Title", this.head);
            para[7] = new ReportParameter("Currency", this.Currency.Replace("KYT","MMK"));//Updated by HWKO (20-Sep-2017)
            para[9] = new ReportParameter("TotalRecords", recordCount);

            Image img = null;
            //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            //{
            //    img = System.Drawing.Image.FromStream(stream);
            //    img.Save(tempFilePath);
            //}

            string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

            para[8] = new ReportParameter("BankLogo", "file:////" + tempFilePath);

            this.rpvLoans.LocalReport.EnableExternalImages = true;
            this.rpvLoans.LocalReport.SetParameters(para);
            this.rpvLoans.RefreshReport();

            ReportDataSource dataset = new ReportDataSource("DSLOMRDLC00042", this.DataList);
            this.rpvLoans.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.DataList;
            this.rpvLoans.LocalReport.Refresh();
            this.rpvLoans.RefreshReport();
        }
    }
}
