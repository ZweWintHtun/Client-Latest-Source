using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Microsoft.Reporting.WinForms;
using System.IO;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Sam.Vew
{
    public partial class SAMVEW00061 : BaseForm
    {
        public SAMVEW00061()
        {
            InitializeComponent();
        }

        public SAMVEW00061(IList<BranchDTO> branchList)
        {
            this.BranchList = branchList;
            InitializeComponent();
        }

        IList<BranchDTO> BranchList { get; set; }

        private void SAMVEW00061_Load(object sender, EventArgs e)
        {
            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            this.rptBranch.LocalReport.DataSources.Clear();
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
            para[6] = new ReportParameter("TotalRecords", this.BranchList.Count.ToString());
            this.rptBranch.LocalReport.EnableExternalImages = true;
            this.rptBranch.LocalReport.SetParameters(para);

            ReportDataSource dataset = new ReportDataSource("Branch_DataSet", this.BranchList);
            this.rptBranch.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.BranchList;

            this.rptBranch.LocalReport.Refresh();
            this.rptBranch.RefreshReport();
        }

        private void SAMVEW00061_FormClosing(object sender, FormClosingEventArgs e)
        {
            rptBranch.LocalReport.ReleaseSandboxAppDomain();
        }
    }
}
