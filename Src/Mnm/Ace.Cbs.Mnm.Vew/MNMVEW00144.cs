using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Utt;
using System.IO;
using Microsoft.Reporting.WinForms;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient.Controls;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00144 : BaseDockingForm
    {
        #region Properties

        public string Header { get; set; }
        public IList<PFMDTO00042> PrintDataList { get; set; }

        #endregion
        public MNMVEW00144()
        {
            InitializeComponent();
        }
       
    
        public MNMVEW00144(IList<PFMDTO00042> List,string formName,DateTime dateTime, bool IsReversal)
        {          
            this.PrintDataList = List;
            if (formName.Contains("Debit"))
            {
                if (IsReversal)
                    this.Header = " Auto Link Call Debit Voucher Listing as at " + dateTime.ToString("dd/MM/yyyy") + "( Reversal )";
                else
                    this.Header = " Auto Link Call Debit Voucher Listing as at " + dateTime.ToString("dd/MM/yyyy") + "( Without Reversal )";
            }
            else
            {
                if (IsReversal)
                    this.Header = " Auto Link Call Credit Voucher Listing as at " + dateTime.ToString("dd/MM/yyyy") + "( Reversal )";
                else
                    this.Header = " Auto Link Call Credit Voucher Listing as at " + dateTime.ToString("dd/MM/yyyy") + "( Without Reversal )";
            }
            InitializeComponent();
        }

        private void MNMVEW00144_Load(object sender, EventArgs e)
        {
            Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });

            rpvAutoLinkDebitListing.LocalReport.DataSources.Clear();
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

            this.rpvAutoLinkDebitListing.LocalReport.EnableExternalImages = true;
            this.rpvAutoLinkDebitListing.LocalReport.SetParameters(para);
            ReportDataSource dataset = new ReportDataSource("AutoLinkDebitCreditListingDataSet", PrintDataList);
            this.rpvAutoLinkDebitListing.LocalReport.DataSources.Add(dataset);
            dataset.Value = PrintDataList;

            this.rpvAutoLinkDebitListing.RefreshReport();
        }
    }
}
