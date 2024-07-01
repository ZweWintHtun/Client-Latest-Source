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
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Mnm.Dmd.DTO;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00098 : BaseForm
    {
        #region Property
        public bool IsReversal { get; set; }
        public bool IsSourceCurrency { get; set; }
        IList<MNMDTO00032> dayBooks { get; set; }
        public string FormName { get; set; }
        #endregion

        #region constructors
        public MNMVEW00098()
        {
            InitializeComponent();
        }

        public MNMVEW00098(bool isReversal, string formName)
        {
            InitializeComponent();
            this.IsReversal = isReversal;
            this.FormName = formName;
        }
        #endregion


        private void MNMVEW00098_Load(object sender, EventArgs e)
        {
            MNMDTO00032 dayBookDTO = new MNMDTO00032();

            if (this.IsReversal == false)
            {
                dayBookDTO.Status_Letter_One = FormName + " (Without Reversal)";
            }
            else if (this.IsReversal == true)
            {
                dayBookDTO.Status_Letter_One = FormName + " (With Reversal)";
            }
            dayBooks = new List<MNMDTO00032>();
            dayBooks.Add(dayBookDTO);

            Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });

            rpvBalanceCertificate.LocalReport.DataSources.Clear();
            ReportParameter[] para = new ReportParameter[18];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[16] = new ReportParameter("BrCode", Branch.BranchCode);
            para[17] = new ReportParameter("Br_Alias", Branch.Bank_Alias);


            Image img = null;
            string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            {
                img = System.Drawing.Image.FromStream(stream);

                img.Save(tempFilePath);
            }

            para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);


            para[5] = new ReportParameter("Head", dayBookDTO.Status_Letter_One);
            para[6] = new ReportParameter("Currency", dayBooks.Count.ToString());
            para[7] = new ReportParameter("Name", dayBooks.Count.ToString());
            para[8] = new ReportParameter("AccountNo", dayBooks.Count.ToString());
            para[9] = new ReportParameter("Address", dayBooks.Count.ToString());
            para[10] = new ReportParameter("Name", dayBooks.Count.ToString());
            para[11] = new ReportParameter("Date", dayBooks.Count.ToString());
            para[12] = new ReportParameter("Currency", dayBooks.Count.ToString());
            para[13] = new ReportParameter("BankLTD", dayBooks.Count.ToString());
            para[14] = new ReportParameter("Balance", dayBooks.Count.ToString());
            para[15] = new ReportParameter("ByLetter", dayBooks.Count.ToString());


            this.rpvBalanceCertificate.LocalReport.EnableExternalImages = true;
            rpvBalanceCertificate.LocalReport.SetParameters(para);
            ReportDataSource dataset = new ReportDataSource("MNMDS00018", dayBooks);
            rpvBalanceCertificate.LocalReport.DataSources.Add(dataset);
            dataset.Value = dayBooks;


            this.rpvBalanceCertificate.RefreshReport();
            this.rpvBalanceCertificate.RefreshReport();
        }

        private void rpvBalanceCertificate_Load(object sender, EventArgs e)
        {

        }

        //CXUIScreenTransit.Transit("frmTLMVEW00058DrawingRemitNameExactlyByTransactionDate", true, new object[] { DrawingEncashLists, "Drawing Remittance Listing By Transaction Date", this.StartDate, this.EndDate, "Drawing Remittance Listing (By Name) Report" });
    }
}
