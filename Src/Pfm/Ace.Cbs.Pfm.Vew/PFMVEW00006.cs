using System;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient.Controls;
using Microsoft.Reporting.WinForms;

namespace Ace.Cbs.Pfm.Vew
{
    public partial class PFMVEW00006 : BaseForm
    {
        //CurrentAccountIndividual Report1 
        public PFMDTO00061 entityDTO { get; set; }
        public PFMVEW00006()
        {
            InitializeComponent();
        }

        public PFMVEW00006(PFMDTO00061 entity)
        {
            InitializeComponent();
            this.entityDTO = entity;
        }

        public PFMVEW00006(PFMDTO00061 entity, string param)
        {
            InitializeComponent();
            this.entityDTO = entity;
            this.Text = param;
        }

        private void PFMVEW00006_Load(object sender, EventArgs e)
        {
            ReportParameter[] param = new ReportParameter[2];           
            param[0] = new ReportParameter("BankName", this.entityDTO.BankName);
            param[1] = new ReportParameter("BranchName", "(" + this.entityDTO.BranchName + ")");

            this.rpvCurrentAccountJoint.LocalReport.SetParameters(param);

            this.rpvCurrentAccountJoint.SetDisplayMode(DisplayMode.PrintLayout);
            this.rpvCurrentAccountJoint.ZoomMode = ZoomMode.FullPage;
            this.rpvCurrentAccountJoint.ZoomPercent = 75;
            this.rpvCurrentAccountJoint.RefreshReport();
        }
    }
}
