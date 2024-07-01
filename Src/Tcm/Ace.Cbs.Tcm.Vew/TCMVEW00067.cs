using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Tcm.Dmd;
using System.IO;
using Microsoft.Reporting.WinForms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Tcm.Vew
{
    public partial class TCMVEW00067 : BaseDockingForm
    {
        IList<TCMDTO00013> ReportDTOList { get; set; }
        string transaction { get; set; }
        string cur { get; set; }
        int count { get; set; }

        public TCMVEW00067()
        {
            InitializeComponent();
        }

        public TCMVEW00067(IList<TCMDTO00013> dtolist, string transactionType, string currency)
        {
            ReportDTOList = dtolist;
            count = dtolist.Count;
            transaction = transactionType;
            cur = currency.Replace("KYT", "MMK");//Updated by HWKO (25-Sep-2017)
            InitializeComponent();
        }

        private void TCMVEW00067_Load(object sender, EventArgs e)
        {
            switch (transaction)
            {
                case "All": this.Text = "Ledger Balance Listing (All)";
                    break;
                case "Current": this.Text = "Ledger Balance Listing (Current)";
                    break;
                case "Saving": this.Text = "Ledger Balance Listing (Saving)";
                    break;
                case "Fix": this.Text = "Ledger Balance Listing (Fix)";
                    break;
                case "OverDrawn": this.Text = "Ledger Balance Listing (OverDrawn)";
                    break;
            }
            Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });

            rpvLedgerBalanceByTransaction.LocalReport.DataSources.Clear();
            ReportParameter[] para = new ReportParameter[10];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[8] = new ReportParameter("BrCode", Branch.BranchCode);
            para[9] = new ReportParameter("Br_Alias", Branch.BranchAlias);

            //Commented by HWKO (31-Oct-2017)
            //Image img = null;
            //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            //{
            //    img = System.Drawing.Image.FromStream(stream);

            //    img.Save(tempFilePath);
            //}

            string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

            para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[5] = new ReportParameter("Transaction", transaction);
            para[6] = new ReportParameter("Cur", cur);
            para[7] = new ReportParameter("Count", Convert.ToString(count));

            this.rpvLedgerBalanceByTransaction.LocalReport.EnableExternalImages = true;
            this.rpvLedgerBalanceByTransaction.LocalReport.SetParameters(para);
            ReportDataSource dataset = new ReportDataSource("TCMDS00013", ReportDTOList);
            this.rpvLedgerBalanceByTransaction.LocalReport.DataSources.Add(dataset);
            dataset.Value = ReportDTOList;

            this.rpvLedgerBalanceByTransaction.RefreshReport();
        }

      

    }
}
