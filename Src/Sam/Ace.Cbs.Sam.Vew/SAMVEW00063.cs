using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Sam.Dmd;
using Ace.Cbs.Cx.Cle;
using Microsoft.Reporting.WinForms;
using Ace.Windows.Core.Utt;
using System.IO;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient.Controls;

namespace Ace.Cbs.Sam.Vew
{
    /// <summary>
    /// Interest Rate Listing Report Viewer
    /// </summary>
    public partial class SAMVEW00063 :BaseDockingForm
    {
        #region " Properties"
        public string TransactionStatus { get; set; }
        #endregion
      
        #region "Constructors"
        public SAMVEW00063()
        {
            InitializeComponent();
        }
        public SAMVEW00063(string screenName, IList<SAMDTO00056> intRateList)
        {
            InitializeComponent();
            this.TransactionStatus = screenName;
            this.Text = "Interest Rate Listing";
            this.InterestRateFileDTOList = intRateList;
        }
        #endregion

        #region "DTO List"
        private IList<SAMDTO00056> interestRateFileDTOList;
        public IList<SAMDTO00056> InterestRateFileDTOList
        {
            get { return this.interestRateFileDTOList; }
            set { this.interestRateFileDTOList = value; }
        }
        #endregion

        #region Event
        private void SAMVEW00063_Load(object sender, EventArgs e)
        {
            Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            rpvInterestRateList.LocalReport.DataSources.Clear();
            ReportParameter[] para = new ReportParameter[7];
            para[0] = new ReportParameter("BankName", Branch.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[4] = new ReportParameter("Header", this.TransactionStatus);
           
            Image img = null;
            string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            {
                img = System.Drawing.Image.FromStream(stream);

                img.Save(tempFilePath);
            }

            para[5] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[6] = new ReportParameter("TotalRecords", InterestRateFileDTOList.Count.ToString());
            this.rpvInterestRateList.LocalReport.EnableExternalImages = true;
            rpvInterestRateList.LocalReport.SetParameters(para);
            ReportDataSource dataset = new ReportDataSource("IntRateFileDataSet", InterestRateFileDTOList);
            rpvInterestRateList.LocalReport.DataSources.Add(dataset);

            dataset.Value = InterestRateFileDTOList;
            this.rpvInterestRateList.RefreshReport();
        }

        private void SAMVEW00063_FormClosing(object sender, FormClosingEventArgs e)
        {
            rpvInterestRateList.LocalReport.ReleaseSandboxAppDomain();
        }

        #endregion

    }
}
