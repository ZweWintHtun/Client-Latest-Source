using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Ace.Windows.CXClient.Controls;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Utt;
using Microsoft.Reporting.WinForms;
using System.IO;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Tcm.Vew
{
    public partial class TCMVEW00048 : BaseDockingForm
    {
        #region Data Properties

        public IList<PFMDTO00042> ScheduleDataList { get; set; }
        public string SelectedDateTime { get; set; }
        public string SelectedDateType { get; set; }

        #endregion
        public TCMVEW00048()
        {
            InitializeComponent();
        }

        public TCMVEW00048(IList<PFMDTO00042> DataSet , string selectedDateTime , string selectedDateType)
        {
            this.ScheduleDataList = DataSet;
            this.SelectedDateType = selectedDateType;
            this.SelectedDateTime = selectedDateTime;
            InitializeComponent();
        }

        private void TCMScheduleReport_Load(object sender, EventArgs e)
        {
            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            this.rvpClearingScheduleReportViewer.LocalReport.DataSources.Clear();

            ReportParameter[] para = new ReportParameter[9];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[7] = new ReportParameter("BrCode", Branch.BranchCode);
            para[8] = new ReportParameter("Br_Alias", Branch.Bank_Alias);

            Image img = null;
            string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            {
                img = System.Drawing.Image.FromStream(stream);

                img.Save(tempFilePath);
            }

            para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[5] = new ReportParameter("SelectedDateTime", this.SelectedDateTime);
            para[6] = new ReportParameter("SelectedDateType", this.SelectedDateType);
            this.rvpClearingScheduleReportViewer.LocalReport.EnableExternalImages = true;
            this.rvpClearingScheduleReportViewer.LocalReport.SetParameters(para);
            this.rvpClearingScheduleReportViewer.RefreshReport();
            ReportDataSource dataset = new ReportDataSource("ClearingScheduleDataSet", this.ScheduleDataList);
            this.rvpClearingScheduleReportViewer.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.ScheduleDataList;
            rvpClearingScheduleReportViewer.LocalReport.Refresh();
            this.rvpClearingScheduleReportViewer.RefreshReport();
        }

        /// <summary>
        /// Error occured after using Report Viewer. As I know , it's Microsoft Bug.
        /// using method like that can resolve this error. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TCMScheduleReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.rvpClearingScheduleReportViewer.LocalReport.ReleaseSandboxAppDomain();
        }
    }
}
