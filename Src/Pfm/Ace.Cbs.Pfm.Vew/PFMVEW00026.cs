using System;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient.Controls;
using Microsoft.Reporting.WinForms;

namespace Ace.Cbs.Pfm.Vew
{
    public partial class frmPFMVEW00026 : BaseForm
    {
        //Current Account Individual Report 2
        public frmPFMVEW00026()
        {
            InitializeComponent();
        }

        public PFMDTO00060 EntityDTO { get; set; }

        public frmPFMVEW00026(PFMDTO00060 entity, string param)
        {
            InitializeComponent();
            this.EntityDTO = entity;
            this.Text = param;
        }

        private void frmPFMVEW00026_Load(object sender, EventArgs e)
        {
            if (this.EntityDTO != null)
            {
                ReportParameter[] param = new ReportParameter[7];

                param[0] = new ReportParameter("Name", EntityDTO.Name);
                param[1] = new ReportParameter("Address", EntityDTO.Address);
                param[2] = new ReportParameter("Occupation", EntityDTO.Occupation);
                param[3] = new ReportParameter("NRC", EntityDTO.NRC);
                param[4] = new ReportParameter("BankName", EntityDTO.BankName);
                param[5] = new ReportParameter("BranchName", EntityDTO.BranchName);
                //param[6] = new ReportParameter("Date", DateTime.Now.ToString("dd/MM/yyyy"));

                param[6] = new ReportParameter("Date", DateTime.Now.ToString("dd MMMM, yyyy"));
                this.rpvCurrentAccountIndividual.LocalReport.SetParameters(param);
                this.rpvCurrentAccountIndividual.SetDisplayMode(DisplayMode.PrintLayout);
                this.rpvCurrentAccountIndividual.ZoomMode = ZoomMode.FullPage;
                this.rpvCurrentAccountIndividual.ZoomPercent = 75;
                this.rpvCurrentAccountIndividual.RefreshReport();
            }
        }

    }
}