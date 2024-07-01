using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Mnm.Dmd;
using Microsoft.Reporting.WinForms;
using System.IO;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00163 : BaseDockingForm
    {
        bool isFixedBal;
        string currency;
        #region Properties

        public string Header { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public IList<MNMDTO00035> list { get; set; }

        #endregion 

        public MNMVEW00163()
        {
            InitializeComponent();
        }

        public MNMVEW00163(IList<MNMDTO00035> list, string formName, bool isFixedBal, string currency)
        {
            this.list = list;
            this.Header = formName;
            this.isFixedBal = isFixedBal;
            this.currency = currency;
            InitializeComponent();
        }

        private void MNMVEW00163_Load(object sender, EventArgs e)
        {
            Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });

            rpvSubByTransaction.LocalReport.DataSources.Clear();
            ReportParameter[] para = new ReportParameter[11];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[9] = new ReportParameter("BrCode", Branch.BranchCode);
            para[10] = new ReportParameter("Br_Alias", Branch.Bank_Alias);


            Image img = null;
            string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            {
                img = System.Drawing.Image.FromStream(stream);

                img.Save(tempFilePath);
            }

            para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[5] = new ReportParameter("Head", this.Header);
            para[6] = new ReportParameter("Count", list.Count.ToString());
            if (this.isFixedBal)
                para[7] = new ReportParameter("ColumnVisible", "false");
            else
                para[7] = new ReportParameter("ColumnVisible", "true");
            para[8] = new ReportParameter("Currency", string.IsNullOrEmpty(this.currency) ? "All" : this.currency);

            this.rpvSubByTransaction.LocalReport.EnableExternalImages = true;
            rpvSubByTransaction.LocalReport.SetParameters(para);
            ReportDataSource dataset = new ReportDataSource("MNMDS00091", list);
            rpvSubByTransaction.LocalReport.DataSources.Add(dataset);
            dataset.Value = list;

            this.rpvSubByTransaction.RefreshReport();
        }
    }
}
