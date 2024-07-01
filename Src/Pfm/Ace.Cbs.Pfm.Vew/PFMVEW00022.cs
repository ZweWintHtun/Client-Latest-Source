using System;
using Ace.Windows.CXClient.Controls;
using Microsoft.Reporting.WinForms;
namespace Ace.Cbs.Pfm.Vew
{
    public partial class frmPFMVEW00022 : BaseForm
    {
        public frmPFMVEW00022()
        {
            InitializeComponent();
        }

        private void frmPFMVEW00022_Load(object sender, EventArgs e)
        {
            this.rpvSavingWithdrawOnlineOfflineReport.SetDisplayMode(DisplayMode.PrintLayout);
            this.rpvSavingWithdrawOnlineOfflineReport.ZoomMode = ZoomMode.FullPage;
            this.rpvSavingWithdrawOnlineOfflineReport.ZoomPercent = 75;
            this.rpvSavingWithdrawOnlineOfflineReport.RefreshReport();
        }
    }
}
