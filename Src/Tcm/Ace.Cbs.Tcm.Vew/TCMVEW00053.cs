using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Pfm.Dmd;
using Microsoft.Reporting.WinForms;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Utt;
using System.IO;

namespace Ace.Cbs.Tcm.Vew
{
    public partial class TCMVEW00053 : BaseDockingForm
    {

        #region Properties
        public IList<PFMDTO00020> DataLists { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        #endregion

        #region Constructor
        public TCMVEW00053()
        {
            InitializeComponent();
        }

        public TCMVEW00053(IList<PFMDTO00020> PrintDataLists,string startDate,string endDate)
        {
            this.DataLists = PrintDataLists;
            this.StartDate = startDate;
            this.EndDate = endDate;
            InitializeComponent();
        }
        #endregion

        private void TCMVEW00053_Load(object sender, EventArgs e)
        {
            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            this.rpvWithdrawalChequeReportViewer.LocalReport.DataSources.Clear();

            ReportParameter[] para = new ReportParameter[10];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);

            para[8] = new ReportParameter("BrCode", Branch.BranchCode);
            para[9] = new ReportParameter("Br_Alias", Branch.BranchAlias);
   


            Image img = null;
            string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            {
                img = System.Drawing.Image.FromStream(stream);

                img.Save(tempFilePath);
            }

            para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[5] = new ReportParameter("StartDate", this.StartDate);
            para[6] = new ReportParameter("EndDate", this.EndDate);
            para[7] = new ReportParameter("TotalRecords", this.DataLists.Count.ToString());
            this.rpvWithdrawalChequeReportViewer.LocalReport.EnableExternalImages = true;
            this.rpvWithdrawalChequeReportViewer.LocalReport.SetParameters(para);
            this.rpvWithdrawalChequeReportViewer.RefreshReport();
            ReportDataSource dataset = new ReportDataSource("WithdrawalChequeDataSets", this.DataLists);
            this.rpvWithdrawalChequeReportViewer.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.DataLists;
            rpvWithdrawalChequeReportViewer.LocalReport.Refresh();

            this.rpvWithdrawalChequeReportViewer.RefreshReport();
        }
    }
}
