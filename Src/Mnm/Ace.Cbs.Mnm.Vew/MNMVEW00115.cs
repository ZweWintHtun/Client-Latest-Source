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
using System.IO;
using Microsoft.Reporting.WinForms;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00115 : BaseForm
    {
        #region Properties

        IList<PFMDTO00042> PrintDataList { get; set; }
        string Header { get; set; }

        #endregion
        public MNMVEW00115()
        {
            InitializeComponent();
        }

        public MNMVEW00115(IList<PFMDTO00042> List, string formName, DateTime date)
        {
            PrintDataList = List;
            Header = "Fixed Deposit Renewal Voucher Listing As at" + date.ToString("dd/mm/yyyy");
            InitializeComponent();
        }

        private void MNMVEW00115_Load(object sender, EventArgs e)
        {
            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });

            rpvFixedDepositInterest.LocalReport.DataSources.Clear();
            ReportParameter[] para = new ReportParameter[8];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[6] = new ReportParameter("BrCode", Branch.BranchCode);
            para[7] = new ReportParameter("Br_Alias", Branch.Bank_Alias);

            Image img = null;
            string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            {
                img = System.Drawing.Image.FromStream(stream);

                img.Save(tempFilePath);
            }

            para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[5] = new ReportParameter("Header", Header);

            this.rpvFixedDepositInterest.LocalReport.EnableExternalImages = true;
            this.rpvFixedDepositInterest.LocalReport.SetParameters(para);
            ReportDataSource dataset = new ReportDataSource("FixedDepositInterestDataSet", PrintDataList);
            this.rpvFixedDepositInterest.LocalReport.DataSources.Add(dataset);
            dataset.Value = PrintDataList;
            this.rpvFixedDepositInterest.RefreshReport();
        }
    }
}
