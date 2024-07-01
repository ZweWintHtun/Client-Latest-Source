using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Core.Utt;
using Microsoft.Reporting.WinForms;
using System.IO;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient.Controls;

namespace Ace.Cbs.Tel.Vew
{
    public partial class TLMVEW00077 : BaseDockingForm
    {
        public TLMVEW00077()
        {
            InitializeComponent();
        }

        private string Title { get; set; }
        private IList<TLMDTO00009> CashDenoListForMulti = new List<TLMDTO00009>();
       
        public TLMVEW00077(string title , IList<TLMDTO00009> cashDenoListForMulti)
        {
            this.Title = title;
            this.CashDenoListForMulti = cashDenoListForMulti;
            InitializeComponent();
        }      

        private void TLMVEW00077_Load(object sender, EventArgs e)
        {
            this.Text = this.Title;
            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            this.rptCashDenominationMultiTransaction.LocalReport.DataSources.Clear();
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
            para[5] = new ReportParameter("Title", this.Title);
            para[6] = new ReportParameter("Count", this.CashDenoListForMulti.Count.ToString());
           
            this.rptCashDenominationMultiTransaction.LocalReport.EnableExternalImages = true;
            this.rptCashDenominationMultiTransaction.LocalReport.SetParameters(para);
            //this.rptCashDenominationMultiTransaction.RefreshReport();
            ReportDataSource dataset = new ReportDataSource("DSCashDenoForMulti", this.CashDenoListForMulti);
            //ReportDataSource dataset = new ReportDataSource("DataSet1",this.CashDenoListForMulti);
            this.rptCashDenominationMultiTransaction.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.CashDenoListForMulti;
           
            this.rptCashDenominationMultiTransaction.LocalReport.Refresh();
            this.rptCashDenominationMultiTransaction.RefreshReport();
            //this.rptCashDenominationMultiTransaction.RefreshReport();
        
        }
    }
    
}
