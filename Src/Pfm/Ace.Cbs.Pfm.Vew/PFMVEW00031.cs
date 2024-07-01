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
    public partial class frmPFMVEW00031 : BaseForm
    {
        public frmPFMVEW00031(PFMDTO00060 entity, string param)
        {
            InitializeComponent();
            this.EntityDTO = entity;
            this.Text = param;
        }

        private PFMDTO00060 EntityDTO { get; set; }

        private void PFMVEW00031_Load(object sender, System.EventArgs e)
        {
            ReportParameter[] param = new ReportParameter[9];

            param[0] = new ReportParameter("BankName", this.EntityDTO.BankName);
            param[1] = new ReportParameter("BranchName", this.EntityDTO.BranchName);
            param[2] = new ReportParameter("Name", this.EntityDTO.Name);
            param[3] = new ReportParameter("Address", this.EntityDTO.Address);
            param[4] = new ReportParameter("FatherName", this.EntityDTO.FatherName);
            param[5] = new ReportParameter("NRC", this.EntityDTO.NRC);
            //param[6] = new ReportParameter("DateOfBirth", this.EntityDTO.DateOfBirth.ToString("dd/MM/yyyy"));
            //param[7] = new ReportParameter("MatureDate", this.EntityDTO.MatureDate.ToString("dd/MM/yyyy"));

            param[6] = new ReportParameter("DateOfBirth", this.EntityDTO.DateOfBirth.ToString("dd MMMM, yyyy"));
            param[7] = new ReportParameter("MatureDate", this.EntityDTO.MatureDate.ToString("dd MMMM, yyyy"));

            Image img = null;
            string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            {
                img = System.Drawing.Image.FromStream(stream);

                img.Save(tempFilePath);
            }

            param[8] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            this.rpvSavingMinorReport2.LocalReport.EnableExternalImages = true;

            this.rpvSavingMinorReport2.LocalReport.SetParameters(param);
            this.rpvSavingMinorReport2.SetDisplayMode(DisplayMode.PrintLayout);
            this.rpvSavingMinorReport2.ZoomMode = ZoomMode.FullPage;
            this.rpvSavingMinorReport2.ZoomPercent = 75;
            this.rpvSavingMinorReport2.RefreshReport();
        }
    }
}