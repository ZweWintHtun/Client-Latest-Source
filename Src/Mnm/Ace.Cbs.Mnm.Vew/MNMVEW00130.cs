using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Cle;
using Microsoft.Reporting.WinForms;
using Ace.Windows.Core.Utt;
using System.IO;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient.Controls;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00130 : BaseForm
    {
        TLMDTO00017 printData;
        public MNMVEW00130()
        {
            InitializeComponent();
        }
       
        public MNMVEW00130(TLMDTO00017 printData)
        {
            InitializeComponent();
            this.printData = printData;
            switch (this.printData.status)
            {
                case "CrossChange":
                    this.Text = "Cross Change Printing";
                    break;

                case "RDImportantData":
                    this.Text = "RD Important Data Printing";
                    break;
                case "RDPersonalInfo":
                    this.Text = "RD Personal Information Printing";
                    break;
            }
            
        }

        private void MNMVEW00130_Load(object sender, EventArgs e)
        {
            Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            Ace.Windows.Admin.DataModel.BranchDTO ToBranch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { printData.Dbank });
            rpvDrawingPrinting.LocalReport.DataSources.Clear();
            ReportParameter[] para = new ReportParameter[25];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("FromBranch", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[4] = new ReportParameter("ToBranch", ToBranch.Address);
        


            Image img = null;
            string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            {
                img = System.Drawing.Image.FromStream(stream);

                img.Save(tempFilePath);
            }
            para[5] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[6] = new ReportParameter("City", ToBranch.CityCode);
            para[7] = new ReportParameter("AmountByLetter", string.IsNullOrEmpty(printData.AmountByLetter) ? " " : printData.AmountByLetter);
            para[8] = new ReportParameter("PayeeName", printData.ToName);
            para[9] = new ReportParameter("PayeeAccountNo", string.IsNullOrEmpty(printData.ToAccountNo) ? " " : printData.ToAccountNo);
            para[10] = new ReportParameter("PayeeNRC", printData.ToNRC);
            para[11] = new ReportParameter("PayeeAddress", printData.ToAddress);
            para[12] = new ReportParameter("PayeePhoneNo", string.IsNullOrEmpty(printData.ToPhoneNo) ? " " : printData.ToPhoneNo);
            para[13] = new ReportParameter("Amount", printData.Amount.ToString());
            para[14] = new ReportParameter("Commission", printData.Commission.ToString());
            para[15] = new ReportParameter("TlxCharges", printData.TlxCharges.ToString());
            para[16] = new ReportParameter("TotalAmount", (printData.Amount + printData.Commission + printData.TlxCharges).ToString());
            para[17] = new ReportParameter("RegisterNo", printData.RegisterNo);
            para[18] = new ReportParameter("PayerName", printData.Name);
            para[19] = new ReportParameter("PayerNRC", printData.NRC);
            para[20] = new ReportParameter("PayerAddress", printData.Address);
            para[21] = new ReportParameter("PayerPhoneNo", string.IsNullOrEmpty(printData.PhoneNo) ? " " : printData.PhoneNo);
            para[22] = new ReportParameter("Narration", string.IsNullOrEmpty(printData.Narration) ? " " : printData.Narration);
            para[23] = new ReportParameter("DateTime", printData.DateTime.Value.ToString("dd/MM/yyyy"));
            para[24] = new ReportParameter("GroupNo", string.IsNullOrEmpty(printData.GroupNo) ? " " : printData.GroupNo);
            this.rpvDrawingPrinting.LocalReport.EnableExternalImages = true;
            rpvDrawingPrinting.LocalReport.SetParameters(para);
            

            this.rpvDrawingPrinting.RefreshReport();
            this.rpvDrawingPrinting.RefreshReport();
        }
    }
}
