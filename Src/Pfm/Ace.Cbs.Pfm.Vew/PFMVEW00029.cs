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
    public partial class frmPFMVEW00029 : BaseForm
    {
        public frmPFMVEW00029()
        {
            InitializeComponent();
        }

        public PFMDTO00060 SavingIndividualEntity { get; set; }

        public frmPFMVEW00029(PFMDTO00060 savingIndividualEntity, string param)
        {
            InitializeComponent();
            this.SavingIndividualEntity = savingIndividualEntity;
            this.Text = param;
        }

        private void frmPFMVEW00029_Load(object sender, EventArgs e)
        {
            if (this.SavingIndividualEntity != null)
            {
                ReportParameter[] param = new ReportParameter[9];

                param[0] = new ReportParameter("Name", SavingIndividualEntity.Name);
                param[1] = new ReportParameter("FatherName", SavingIndividualEntity.FatherName);
                param[2] = new ReportParameter("Address", SavingIndividualEntity.Address);
                param[3] = new ReportParameter("Occupation", SavingIndividualEntity.Occupation);
                param[4] = new ReportParameter("NRC", SavingIndividualEntity.NRC);
                //param[5] = new ReportParameter("Date", DateTime.Now.ToString("dd/MM/yyyy"));
                param[5] = new ReportParameter("Date", DateTime.Now.ToString("dd MMMM, yyyy"));
                param[6] = new ReportParameter("BankName", SavingIndividualEntity.BankName);
                param[7] = new ReportParameter("BranchName", SavingIndividualEntity.BranchName);

                Image img = null;
                string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                {
                    img = System.Drawing.Image.FromStream(stream);

                    img.Save(tempFilePath);
                }

                param[8] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                this.rpvPFMVEW0029.LocalReport.EnableExternalImages = true;

                this.rpvPFMVEW0029.LocalReport.SetParameters(param);
                this.rpvPFMVEW0029.SetDisplayMode(DisplayMode.PrintLayout);
                this.rpvPFMVEW0029.ZoomMode = ZoomMode.FullPage;
                this.rpvPFMVEW0029.ZoomPercent = 75;
            }
        }
    }
}
