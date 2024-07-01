using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Mnm.Dmd.DTO;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Core.Utt;
using System.IO;
using Microsoft.Reporting.WinForms;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00159 : BaseForm
    {
        public MNMVEW00159()
        {
            InitializeComponent();
        }

        public MNMVEW00159(IList<MNMDTO00071> savingAccuredOutstanding)
        {
            this.SavingAccuredOutstanding = savingAccuredOutstanding;
            InitializeComponent();
        }


        private IList<MNMDTO00071> SavingAccuredOutstanding { get; set; }

        private void MNMVEW00159_Load(object sender, EventArgs e)
        {
            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            this.rptSavingAccruedOutstanding.LocalReport.DataSources.Clear();
            ReportParameter[] para = new ReportParameter[9];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[4] = new ReportParameter("BrCode", Branch.BranchCode);
            para[5] = new ReportParameter("Br_Alias", Branch.Bank_Alias);
            Image img = null;
            string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            {
                img = System.Drawing.Image.FromStream(stream);
                img.Save(tempFilePath);
            }
            para[6] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[7] = new ReportParameter("ReportTitle", "Saving Interest Outstanding Listing");
            para[8] = new ReportParameter("TotalRecords", this.SavingAccuredOutstanding.Count.ToString());
            this.rptSavingAccruedOutstanding.LocalReport.EnableExternalImages = true;
            this.rptSavingAccruedOutstanding.LocalReport.SetParameters(para);

            ReportDataSource dataset = new ReportDataSource("SavingAccruedOutstanding_DataSet", this.SavingAccuredOutstanding);
            this.rptSavingAccruedOutstanding.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.SavingAccuredOutstanding;

            this.rptSavingAccruedOutstanding.LocalReport.Refresh();
            this.rptSavingAccruedOutstanding.RefreshReport();
            this.rptSavingAccruedOutstanding.RefreshReport();
        }

        private void MNMVEW00159_FormClosing(object sender, FormClosingEventArgs e)
        {
            rptSavingAccruedOutstanding.LocalReport.ReleaseSandboxAppDomain();
        }
    }
}
