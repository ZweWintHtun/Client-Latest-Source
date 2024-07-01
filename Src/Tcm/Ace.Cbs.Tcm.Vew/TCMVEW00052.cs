using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Ace.Windows.Core.Utt;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using System.IO;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Tcm.Vew
{
    public partial class TCMVEW00052 : BaseDockingForm
    {
        public IList<TCMDTO00052> DTOData = new List<TCMDTO00052>();

        public TCMVEW00052()
        {
            InitializeComponent();
        }

        public TCMVEW00052(TCMDTO00052 dto)
        {
            this.DTOData.Add(dto);
            InitializeComponent();
        }

        private void TCMVEW00052_Load(object sender, EventArgs e)
        {
            Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });

            rptDailyReport.LocalReport.DataSources.Clear();
            ReportParameter[] para = new ReportParameter[7];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[5] = new ReportParameter("BrCode", Branch.BranchCode);
            para[6] = new ReportParameter("Br_Alias", Branch.Bank_Alias);
   


            Image img = null;
            string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            {
                img = System.Drawing.Image.FromStream(stream);

                img.Save(tempFilePath);
            }

            para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);

            this.rptDailyReport.LocalReport.EnableExternalImages = true;
            rptDailyReport.LocalReport.SetParameters(para);
            this.rptDailyReport.RefreshReport();

            ReportDataSource dataset = new ReportDataSource("TCMDS00052", DTOData);
            rptDailyReport.LocalReport.DataSources.Add(dataset);
            dataset.Value = DTOData;
            this.rptDailyReport.LocalReport.Refresh();

            this.rptDailyReport.RefreshReport();
        }

        private void TCMVEW00052_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.rptDailyReport.LocalReport.ReleaseSandboxAppDomain();
        }
    }
}
