using System;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Microsoft.Reporting.WinForms;

namespace Ace.Cbs.Pfm.Vew
{
    //Current Account Company Report 2
    public partial class frmPFMVEW00033 : BaseForm
    {
        public frmPFMVEW00033()
        {
            InitializeComponent();
        }

        public frmPFMVEW00033(PFMDTO00061 printingData, string param)
        {
            InitializeComponent();
            this.printingData = printingData;
            this.Text = param;
        }

        private PFMDTO00061 printingData;

        private void PFMVEW00033_Load(object sender, EventArgs e)
        {
            ReportParameter[] param = new ReportParameter[12];

            param[0] = new ReportParameter("BankName", this.printingData.BankName);
            param[1] = new ReportParameter("BranchName", this.printingData.BranchName);
            param[2] = new ReportParameter("NameOfFirm", this.printingData.NameOfFirm);
            param[3] = new ReportParameter("Address", this.printingData.Address);
            param[4] = new ReportParameter("IntroducedBy", this.printingData.IntroducedBy);
            param[5] = new ReportParameter("Date", DateTime.Now.ToString(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.UIDateFormat)));
            param[6] = new ReportParameter("Customer1", this.printingData.Customers[0].Name);
            param[7] = new ReportParameter("Customer2", this.printingData.Customers[1].Name);
            param[8] = new ReportParameter("Customer3", this.printingData.Customers.Count >= 3 ? this.printingData.Customers[2].Name : string.Empty);
            param[9] = new ReportParameter("Customer4", this.printingData.Customers.Count >= 4 ? this.printingData.Customers[3].Name : string.Empty);
            param[10] = new ReportParameter("Customer5", this.printingData.Customers.Count >= 5 ? this.printingData.Customers[4].Name : string.Empty);
            param[11] = new ReportParameter("Customer6", this.printingData.Customers.Count >= 6 ? this.printingData.Customers[5].Name : string.Empty);

            this.rpvCurrentAccountCompanyReport2.LocalReport.SetParameters(param);
            this.rpvCurrentAccountCompanyReport2.SetDisplayMode(DisplayMode.PrintLayout);
            this.rpvCurrentAccountCompanyReport2.ZoomMode = ZoomMode.FullPage;
            this.rpvCurrentAccountCompanyReport2.ZoomPercent = 75;
            this.rpvCurrentAccountCompanyReport2.RefreshReport();
        }
    }
}