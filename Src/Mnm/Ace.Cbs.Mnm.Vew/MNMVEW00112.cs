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
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Mnm.Dmd.DTO;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00112 : BaseForm
    {
        IList<MNMDTO00040> DataList { get; set; }
        decimal StartAmount { get; set; }
        decimal EndAmount { get; set; }
        string Currency { get; set; }
        string Head { get; set; }

        public MNMVEW00112()
        {
            InitializeComponent();
        }

        public MNMVEW00112(IList<MNMDTO00040> dataList, decimal startAmount, decimal endAmount, string currency, string header)
        {
            InitializeComponent();

            this.DataList = dataList;
            this.StartAmount = startAmount;
            this.EndAmount = endAmount;
            if (currency == null)
            {
                this.Currency = "All Currency Type";
            }
            else
            {
                this.Currency = currency;
            }
            this.Text = header;
            this.Head = header;
        }

        private void MNMVEW00112_Load(object sender, EventArgs e)
        {
            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            this.rpvLedgerBalance.LocalReport.DataSources.Clear();

            ReportParameter[] para = new ReportParameter[10];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[10] = new ReportParameter("BrCode", Branch.BranchCode);
            para[11] = new ReportParameter("Br_Alias", Branch.Bank_Alias);

            Image img = null;
            string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            {
                img = System.Drawing.Image.FromStream(stream);

                img.Save(tempFilePath);
            }

            para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[5] = new ReportParameter("Head", this.Head);
            para[6] = new ReportParameter("Count", Convert.ToString(DataList.Count));
            para[7] = new ReportParameter("Currency", this.Currency);
            para[8] = new ReportParameter("StartAmount", this.StartAmount.ToString());
            para[9] = new ReportParameter("EndAmount", this.EndAmount.ToString());

            this.rpvLedgerBalance.LocalReport.EnableExternalImages = true;
            this.rpvLedgerBalance.LocalReport.SetParameters(para);
            this.rpvLedgerBalance.RefreshReport();
            ReportDataSource dataset = new ReportDataSource("MNMDS00032", this.DataList);
            this.rpvLedgerBalance.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.DataList;
            this.rpvLedgerBalance.LocalReport.Refresh();

            this.rpvLedgerBalance.RefreshReport();
        }
    }
}
