using System;
using System.Collections.Generic;
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
    public partial class frmPFMVEW00030 : BaseForm
    {

        #region Private Variables

        private IList<PFMDTO00001> Customers { get; set; }
        private PFMDTO00061 headerEntity { get; set; }

        #endregion

        #region Constructor

        public frmPFMVEW00030()
        {
            InitializeComponent();
        }

        public frmPFMVEW00030(PFMDTO00061 headerEntity, string param) //Saving Joint
        {
            InitializeComponent();
            this.headerEntity = headerEntity;
            this.Customers = headerEntity.Customers;
            this.Text = param;
        }

        #endregion

        #region " Event "

        private void PFMVEW00030_Load(object sender, EventArgs e)
        {
            ReportParameter[] param = new ReportParameter[25];

            param[0] = new ReportParameter("Name1", Customers[0].Name);
            param[1] = new ReportParameter("FatherName1", Customers[0].FatherName);
            param[2] = new ReportParameter("OccupationCode1", Customers[0].OccupationDesp);
            param[3] = new ReportParameter("NRC1", Customers[0].NRC);
            param[4] = new ReportParameter("Address1", Customers[0].Address + " , " + Customers[0].TownshipDesp + " , " + Customers[0].CityDesp + " , " + Customers[0].StateDesp);

            param[5] = new ReportParameter("Name2", Customers[1].Name);
            param[6] = new ReportParameter("FatherName2", Customers[1].FatherName);
            param[7] = new ReportParameter("OccupationCode2", Customers[1].OccupationDesp);
            param[8] = new ReportParameter("NRC2", Customers[1].NRC);
            param[9] = new ReportParameter("Address2", Customers[1].Address + " , " + Customers[1].TownshipDesp + " , " + Customers[1].CityDesp + " , " + Customers[1].StateDesp);

            param[10] = new ReportParameter("Name3", Customers.Count >= 3 ? Customers[2].Name : string.Empty);
            param[11] = new ReportParameter("FatherName3", Customers.Count >= 3 ? Customers[2].FatherName : string.Empty);
            param[12] = new ReportParameter("OccupationCode3", Customers.Count >= 3 ? Customers[2].OccupationDesp : string.Empty);
            param[13] = new ReportParameter("NRC3", Customers.Count >= 3 ? Customers[2].NRC : string.Empty);
            param[14] = new ReportParameter("Address3", Customers.Count >= 3 ? Customers[2].Address + " , " + Customers[2].TownshipDesp + " , " + Customers[2].CityDesp + " , " + Customers[2].StateDesp : string.Empty);

            param[15] = new ReportParameter("Name4", Customers.Count >= 4 ? Customers[3].Name : string.Empty);
            param[16] = new ReportParameter("FatherName4", Customers.Count >= 4 ? Customers[3].FatherName : string.Empty);
            param[17] = new ReportParameter("OccupationCode4", Customers.Count >= 4 ? Customers[3].OccupationDesp : string.Empty);
            param[18] = new ReportParameter("NRC4", Customers.Count >= 4 ? Customers[3].NRC : string.Empty);
            param[19] = new ReportParameter("Address4", Customers.Count >= 4 ? Customers[3].Address + " , " + Customers[3].TownshipDesp + " , " + Customers[3].CityDesp + " , " + Customers[3].StateDesp : string.Empty);

            param[20] = new ReportParameter("BankName", this.headerEntity.BankName);
            param[21] = new ReportParameter("BranchName", this.headerEntity.BranchName);
            param[22] = new ReportParameter("Currency", this.headerEntity.CurrencyCode);
            //param[23] = new ReportParameter("Date", DateTime.Now.ToString("dd/MM/yyyy"));
            param[23] = new ReportParameter("Date", DateTime.Now.ToString("dd MMMM, yyyy"));
            Image img = null;
            string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            {
                img = System.Drawing.Image.FromStream(stream);

                img.Save(tempFilePath);
            }

            param[24] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            this.rpvPFMVEW00030.LocalReport.EnableExternalImages = true;

            this.rpvPFMVEW00030.LocalReport.SetParameters(param);
            this.rpvPFMVEW00030.SetDisplayMode(DisplayMode.PrintLayout);
            this.rpvPFMVEW00030.ZoomMode = ZoomMode.FullPage;
            this.rpvPFMVEW00030.ZoomPercent = 75;

            this.rpvPFMVEW00030.RefreshReport();
        }

        #endregion
    }
}