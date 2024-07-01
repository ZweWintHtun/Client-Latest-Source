using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Microsoft.Reporting.WinForms;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Utt;
using System.IO;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient.Controls;

namespace Ace.Cbs.CBM.Vew
{
    public partial class CBMVEW00005 : BaseForm
    {
        public CBMVEW00005()
        {
            InitializeComponent();
        }

        public CBMVEW00005(IList<PFMDTO00042> list, DateTime date)
        {
            this.DTOList = list;
            this.Date = date;
            InitializeComponent();
        }

         IList<PFMDTO00042> DTOList { get; set; }
         DateTime Date { get; set; }

         private void CBMVEW00005_Load(object sender, EventArgs e)
        {
            this.Text = "Financial Statement";

            Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });

            rptFinancialStatement.LocalReport.DataSources.Clear();
            ReportParameter[] para = new ReportParameter[6];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);

            Image img = null;
            string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            {
                img = System.Drawing.Image.FromStream(stream);

                img.Save(tempFilePath);
            }

            para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[5] = new ReportParameter("Date", this.Date.ToString("dd/MM/yyyy"));
            this.rptFinancialStatement.LocalReport.EnableExternalImages = true;

            rptFinancialStatement.LocalReport.SetParameters(para);

            ReportDataSource dataset = new ReportDataSource("FinancialDS", DTOList);
            rptFinancialStatement.LocalReport.DataSources.Add(dataset);
            dataset.Value = DTOList;

            this.rptFinancialStatement.RefreshReport();
            this.rptFinancialStatement.RefreshReport();
        }
    }
}
