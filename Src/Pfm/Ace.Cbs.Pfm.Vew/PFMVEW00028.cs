using System;
using System.Collections.Generic;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient.Controls;
using Microsoft.Reporting.WinForms;

namespace Ace.Cbs.Pfm.Vew
{
    public partial class frmPFMVEW00028 : BaseForm
    {
        #region Private Variables
        private IList<PFMDTO00001> Customers { get; set; }
        #endregion

        #region Constructor
        public frmPFMVEW00028()
        {
            InitializeComponent();
        }

        public frmPFMVEW00028(IList<PFMDTO00001> customers)
        {
            InitializeComponent();
            this.Customers = customers;
        }

        public frmPFMVEW00028(IList<PFMDTO00001> customers, string param)
        {
            InitializeComponent();
            this.Customers = customers;
            this.Text = param;
        }
        #endregion

        #region Events
        private void frmPFMVEW00028_Load(object sender, EventArgs e)
        {
            ReportParameter[] param = new ReportParameter[16];

            if (this.Customers.Count > 0)
            {
                param[0] = new ReportParameter("Name1", Customers[0].Name);
                param[1] = new ReportParameter("NRC1", Customers[0].NRC);
                param[2] = new ReportParameter("Occupation1", Customers[0].OccupationDesp);
                param[3] = new ReportParameter("Address1", Customers[0].Address + "," + Customers[0].TownshipDesp + "," + Customers[0].CityDesp + "," + Customers[0].StateDesp);
            }
            else
            {
                param[0] = new ReportParameter("Name1", string.Empty);
                param[1] = new ReportParameter("NRC1", string.Empty);
                param[2] = new ReportParameter("Occupation1", string.Empty);
                param[3] = new ReportParameter("Address1", string.Empty);
            }

            if (this.Customers.Count > 1)
            {
                param[4] = new ReportParameter("Name2", Customers[1].Name);
                param[5] = new ReportParameter("NRC2", Customers[1].NRC);
                param[6] = new ReportParameter("Occupation2", Customers[1].OccupationDesp);
                param[7] = new ReportParameter("Address2", Customers[1].Address + "," + Customers[1].TownshipDesp + "," + Customers[1].CityDesp + "," + Customers[1].StateDesp);
            }            
            else
            {
                param[4] = new ReportParameter("Name2", string.Empty);
                param[5] = new ReportParameter("NRC2", string.Empty);
                param[6] = new ReportParameter("Occupation2", string.Empty);
                param[7] = new ReportParameter("Address2", string.Empty);
            }

            if (this.Customers.Count > 2)
            {
                param[8] = new ReportParameter("Name3", Customers[2].Name);
                param[9] = new ReportParameter("NRC3", Customers[2].NRC);
                param[10] = new ReportParameter("Occupation3", Customers[2].OccupationDesp);
                param[11] = new ReportParameter("Address3", Customers[2].Address + "," + Customers[2].TownshipDesp + "," + Customers[2].CityDesp + "," + Customers[2].StateDesp);
            }            
            else
            {
                param[8] = new ReportParameter("Name3", string.Empty);
                param[9] = new ReportParameter("NRC3", string.Empty);
                param[10] = new ReportParameter("Occupation3", string.Empty);
                param[11] = new ReportParameter("Address3", string.Empty);
            }

            if (this.Customers.Count > 3)
            {
                param[12] = new ReportParameter("Name4", Customers[3].Name);
                param[13] = new ReportParameter("NRC4", Customers[3].NRC);
                param[14] = new ReportParameter("Occupation4", Customers[3].OccupationDesp);
                param[15] = new ReportParameter("Address4", Customers[3].Address + "," + Customers[3].TownshipDesp + "," + Customers[3].CityDesp + "," + Customers[3].StateDesp);
            }            
            else
            {
                param[12] = new ReportParameter("Name4", string.Empty);
                param[13] = new ReportParameter("NRC4", string.Empty);
                param[14] = new ReportParameter("Occupation4", string.Empty);
                param[15] = new ReportParameter("Address4", string.Empty);
            }

            this.rpvPFMVEW0028.LocalReport.SetParameters(param);
            this.rpvPFMVEW0028.SetDisplayMode(DisplayMode.PrintLayout);
            this.rpvPFMVEW0028.ZoomMode = ZoomMode.FullPage;
            this.rpvPFMVEW0028.ZoomPercent = 75;

            this.rpvPFMVEW0028.RefreshReport();
        }
        #endregion
    }
}
