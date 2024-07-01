using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Microsoft.Reporting.WinForms;
 
namespace Ace.Cbs.Pfm.Vew
{
    public partial class frmPFMVEW00023 : BaseForm
    {
        public PFMDTO00059 entityDTO { get; set; }
        public frmPFMVEW00023()
        {
            InitializeComponent();
        }
        public frmPFMVEW00023(PFMDTO00059 entityDTO)
        {
            InitializeComponent();
            this.entityDTO = entityDTO;
        }
        private void frmPFMVEW00023_Load(object sender, EventArgs e)
        {
          
            if (this.entityDTO != null)
            {  
                ReportParameter[] param = new ReportParameter[10];               
                param[0] = new ReportParameter("BranchDesp", entityDTO.BranchName);
                param[1] = new ReportParameter("NameofAccount", entityDTO.Name);
                param[2] = new ReportParameter("AccountNo", entityDTO.AccountNo);
                param[3] = new ReportParameter("Amount", (entityDTO.Amount).ToString());
                param[4] = new ReportParameter("Inwords", entityDTO.AmountinWords);
                param[5] = new ReportParameter("NRCNo", entityDTO.NRC);
                //param[6] = new ReportParameter("Date", DateTime.Now.ToString("dd/MM/yyyy")); //(eg.05/10/2014)
                param[6] = new ReportParameter("Date", DateTime.Now.ToString("dd MMMM, yyyy"));
                param[7] = new ReportParameter("BankName", entityDTO.BankName);
                param[8] = new ReportParameter("AmountWithZawGyi", this.ThousandSeparator(entityDTO.AmountWithZawGyi).ToString() + ".၀၀");
                
                Image img = null;
                string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                {
                    img = System.Drawing.Image.FromStream(stream);

                    img.Save(tempFilePath);
                }

                param[9] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                this.rpvSavingWithdrawReport.LocalReport.EnableExternalImages = true;

                this.rpvSavingWithdrawReport.LocalReport.SetParameters(param);

                this.rpvSavingWithdrawReport.SetDisplayMode(DisplayMode.PrintLayout);
                this.rpvSavingWithdrawReport.ZoomMode = ZoomMode.FullPage;
                this.rpvSavingWithdrawReport.ZoomPercent = 75;
                this.rpvSavingWithdrawReport.RefreshReport();
            }
        }

        public string ThousandSeparator(string myNumber)
        {
            var myResult = "";
            for (var i = myNumber.Length - 1; i >= 0; i--)
            {
                myResult = myNumber[i] + myResult;
                if ((myNumber.Length - i) % 3 == 0 & i > 0)
                    myResult = "," + myResult;
            }

            return myResult;
        }
    }
}
