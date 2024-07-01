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
using System.IO;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Sam.Vew
{
    public partial class SAMVEW00057 : BaseForm
    {
        public SAMVEW00057()
        {
            InitializeComponent();
        }

        public SAMVEW00057(IList<PFMDTO00003> initialList)
        {
            this.InitialList = initialList;
            InitializeComponent();
        }

        private IList<PFMDTO00003> InitialList { get; set; }
        private void SAMVEW00057_Load(object sender, EventArgs e)
        {
            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            this.rptInitial.LocalReport.DataSources.Clear();
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
            para[5] = new ReportParameter("ReportTitle", this.Text);
            para[6] = new ReportParameter("TotalRecords", this.InitialList.Count.ToString());
            this.rptInitial.LocalReport.EnableExternalImages = true;
            this.rptInitial.LocalReport.SetParameters(para);

            ReportDataSource dataset = new ReportDataSource("Initial_DataSet", this.InitialList);
            this.rptInitial.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.InitialList;

            this.rptInitial.LocalReport.Refresh();
            this.rptInitial.RefreshReport();
        }

        private void SAMVEW00057_FormClosing(object sender, FormClosingEventArgs e)
        {
            rptInitial.LocalReport.ReleaseSandboxAppDomain();
        }
    }
}
