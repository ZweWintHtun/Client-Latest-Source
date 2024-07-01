using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;
using Microsoft.Reporting.WinForms;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Utt;
using System.IO;

namespace Ace.Cbs.Tcm.Vew
{
    public partial class TCMVEW00050 : BaseDockingForm
    {
        #region Properties

        public IList<PFMDTO00042> DataLists { get; set; }
        public string Header { get; set; }
        public string DateTime { get; set; }
        public string TranType { get; set; }
        public decimal Balance { get; set; }
        public string BlText { get; set; }
        public string CurrencyCode { get; set; }
        #endregion

        #region Constructor

        public TCMVEW00050()
        {
            InitializeComponent();
        }

        public TCMVEW00050(IList<PFMDTO00042> PrintDataList, DateTime datetime, string currencyCode, string trantype, decimal balance, string bltext)
        {
            this.DataLists = PrintDataList;
            this.DateTime = datetime.ToString("dd/MM/yyyy");
            this.CurrencyCode = currencyCode;
            this.TranType = trantype;
            this.Balance = balance;
            this.BlText = bltext;
            InitializeComponent();
        }

        #endregion

        private void TCMDayBookSummaryReport_Load(object sender, EventArgs e)
        {
            this.Text = "Day Book Summary Listing";
            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            this.rpvDayBookSummaryReport.LocalReport.DataSources.Clear();

            ReportParameter[] para = new ReportParameter[13];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchCode", CurrentUserEntity.BranchCode);
            para[2] = new ReportParameter("BranchName", Branch.Address);
            para[3] = new ReportParameter("Phone", Branch.Phone);
            para[4] = new ReportParameter("Fax", Branch.Fax);
            para[5] = new ReportParameter("DateTime", this.DateTime);
            para[6] = new ReportParameter("TranType", this.TranType);
            para[7] = new ReportParameter("Balance", this.Balance.ToString());
            para[8] = new ReportParameter("BlText", this.BlText);
            para[10] = new ReportParameter("BrCode", Branch.BranchCode);
            para[11] = new ReportParameter("Br_Alias", Branch.BranchAlias);

            Image img = null;
            string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            {
                img = System.Drawing.Image.FromStream(stream);

                img.Save(tempFilePath);
            }

            this.rpvDayBookSummaryReport.LocalReport.EnableExternalImages = true;
            para[9] = new ReportParameter("BankLogo", "file:////" + tempFilePath, true);
            para[12] = new ReportParameter("Currency", this.CurrencyCode);

            this.rpvDayBookSummaryReport.LocalReport.SetParameters(para);
            this.rpvDayBookSummaryReport.RefreshReport();
            ReportDataSource dataset = new ReportDataSource("DayBookSummaryDataSet", this.DataLists);
            this.rpvDayBookSummaryReport.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.DataLists;
            this.rpvDayBookSummaryReport.LocalReport.Refresh();
            this.rpvDayBookSummaryReport.RefreshReport();
        }
    }
}