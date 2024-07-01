using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Core.Utt;
using Microsoft.Reporting.WinForms;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Mnm.Ctr.Ptr;
using System.IO;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00104 : BaseDockingForm, IMNMVEW00104
    {
        #region Properties

        public string FormName { get; set; }
        //public string AccountNo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IList<PFMDTO00001> PrintDataList { get; set; }

        #endregion

        #region Controller

        private IMNMCTL00104 controller;
        public IMNMCTL00104 Controller
        {
            get { return this.controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }

        #endregion

        #region Constructor

        public MNMVEW00104()
        {
            InitializeComponent();
        }
        public MNMVEW00104(IList<PFMDTO00001> List, string formName, DateTime startPeriod, DateTime endPeriod)
        {
            this.PrintDataList = List;
            this.FormName = formName;
            this.StartDate = startPeriod;
            this.EndDate = endPeriod;
            InitializeComponent();
        }

        #endregion

        #region Event
        private void MNMVEW00104_Load(object sender, EventArgs e)
        {
            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            rpvSubLedgerSpecific.LocalReport.DataSources.Clear();
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
            para[5] = new ReportParameter("StartDate", StartDate.ToString("MM/yyyy"));
            para[6] = new ReportParameter("EndDate", EndDate.ToString("MM/yyyy"));
            para[7] = new ReportParameter("OpeningDate", "01/" + StartDate.Month + "/" + StartDate.Year);

            this.rpvSubLedgerSpecific.LocalReport.EnableExternalImages = true;
            rpvSubLedgerSpecific.LocalReport.SetParameters(para);
            
            ReportDataSource dataset = new ReportDataSource("SubLedgerSpecificDataSet", PrintDataList);
            
            rpvSubLedgerSpecific.LocalReport.DataSources.Add(dataset);
            dataset.Value = PrintDataList;

            this.rpvSubLedgerSpecific.RefreshReport();
            this.rpvSubLedgerSpecific.RefreshReport();
        }
        #endregion
    }
}
