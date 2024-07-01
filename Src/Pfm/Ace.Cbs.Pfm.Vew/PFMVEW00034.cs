using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Microsoft.Reporting.WinForms;

namespace Ace.Cbs.Pfm.Vew
{
    public partial class frmPFMVEW00034 : BaseForm
    {
        #region Private Variables
        private PFMDTO00061 printingData;
        #endregion

        #region Constructor
        public frmPFMVEW00034()
        {
            InitializeComponent();
        }        

        public frmPFMVEW00034(PFMDTO00061 printingData, string param)
        {
            InitializeComponent();
            this.printingData = printingData;
            this.Text = param;
        }
        #endregion

        #region Events
        private void PFMVEW00034_Load(object sender, System.EventArgs e)
        {           
            ReportParameter[] param = new ReportParameter[53];

            param[0] = new ReportParameter("Name1", this.printingData.Customers[0].Name);
            param[1] = new ReportParameter("FatherName1", this.printingData.Customers[0].FatherName);


            param[2] = new ReportParameter("OccupationCode1", this.GetDescriptionByCode("OccupationCode.SelectByCode", this.printingData.Customers[0].OccupationCode));
            param[3] = new ReportParameter("NRC1", this.printingData.Customers[0].NRC);
            param[4] = new ReportParameter("Address1", this.printingData.Customers[0].Address);
            param[5] = new ReportParameter("TownshipCode1", this.GetDescriptionByCode("TownshipCode.SelectByCode", this.printingData.Customers[0].TownshipCode));
            param[6] = new ReportParameter("CityCode1", this.GetDescriptionByCode("CityCode.SelectByCode", this.printingData.Customers[0].CityCode));
         //   param[6] = new ReportParameter("TownshipCode1", this.GetDescriptionByCode("TownshipCode.SelectByCode", this.printingData.Customers[0].TownshipCode));
            param[7] = new ReportParameter("StateCode1", this.GetDescriptionByCode("StateCode.SelectByCode", this.printingData.Customers[0].StateCode));
           // param[7] = new ReportParameter("TownshipCode1", this.GetDescriptionByCode("TownshipCode.SelectByCode", this.printingData.Customers[0].TownshipCode));

            param[8] = new ReportParameter("Name2", this.printingData.Customers[1].Name);
            param[9] = new ReportParameter("FatherName2", this.printingData.Customers[1].FatherName);
            param[10] = new ReportParameter("OccupationCode2", this.GetDescriptionByCode("OccupationCode.SelectByCode", this.printingData.Customers[1].OccupationCode));
            param[11] = new ReportParameter("NRC2", this.printingData.Customers[1].NRC);
            param[12] = new ReportParameter("Address2", this.printingData.Customers[1].Address);
            param[13] = new ReportParameter("TownshipCode2", this.GetDescriptionByCode("TownshipCode.SelectByCode", this.printingData.Customers[1].TownshipCode));
            param[14] = new ReportParameter("CityCode2", this.GetDescriptionByCode("CityCode.SelectByCode", this.printingData.Customers[1].CityCode));
          //  param[14] = new ReportParameter("TownshipCode2", this.GetDescriptionByCode("TownshipCode.SelectByCode", this.printingData.Customers[1].TownshipCode));
            
            param[15] = new ReportParameter("StateCode2", this.GetDescriptionByCode("StateCode.SelectByCode", this.printingData.Customers[1].StateCode));
            
            

            if (this.printingData.Customers.Count > 2)
            {
                param[16] = new ReportParameter("Name3", this.printingData.Customers[2].Name);
                param[17] = new ReportParameter("FatherName3", this.printingData.Customers[2].FatherName);
                param[18] = new ReportParameter("OccupationCode3", this.GetDescriptionByCode("OccupationCode.SelectByCode", this.printingData.Customers[2].OccupationCode));
                param[19] = new ReportParameter("NRC3", this.printingData.Customers[2].NRC);
                param[20] = new ReportParameter("Address3", this.printingData.Customers[2].Address);
                param[21] = new ReportParameter("TownshipCode3", this.GetDescriptionByCode("TownshipCode.SelectByCode", this.printingData.Customers[2].TownshipCode));
                param[22] = new ReportParameter("CityCode3", this.GetDescriptionByCode("CityCode.SelectByCode", this.printingData.Customers[2].CityCode));
              //  param[22] = new ReportParameter("TownshipCode3", this.GetDescriptionByCode("TownshipCode.SelectByCode", this.printingData.Customers[2].TownshipCode));
                param[23] = new ReportParameter("StateCode3", this.GetDescriptionByCode("StateCode.SelectByCode", this.printingData.Customers[2].StateCode));
               // param[23] = new ReportParameter("TownshipCode3", this.GetDescriptionByCode("TownshipCode.SelectByCode", this.printingData.Customers[2].TownshipCode));
            }
            else
            {
                param[16] = new ReportParameter("Name3", string.Empty);
                param[17] = new ReportParameter("FatherName3", string.Empty);
                param[18] = new ReportParameter("OccupationCode3", string.Empty);
                param[19] = new ReportParameter("NRC3", string.Empty);
                param[20] = new ReportParameter("Address3", string.Empty);
                param[21] = new ReportParameter("TownshipCode3", string.Empty);
                param[22] = new ReportParameter("CityCode3", string.Empty);
             //   param[22] = new ReportParameter("TownshipCode3", string.Empty);
                param[23] = new ReportParameter("StateCode3", string.Empty);
               // param[23] = new ReportParameter("TownshipCode3", string.Empty);
            }

            if (this.printingData.Customers.Count > 3)
            {
                param[24] = new ReportParameter("Name4", this.printingData.Customers[3].Name);
                param[25] = new ReportParameter("FatherName4", this.printingData.Customers[3].FatherName);
                param[26] = new ReportParameter("OccupationCode4", this.GetDescriptionByCode("OccupationCode.SelectByCode", this.printingData.Customers[3].OccupationCode));
                param[27] = new ReportParameter("NRC4", this.printingData.Customers[3].NRC);
                param[28] = new ReportParameter("Address4", this.printingData.Customers[3].Address);
                param[29] = new ReportParameter("TownshipCode4", this.GetDescriptionByCode("TownshipCode.SelectByCode", this.printingData.Customers[3].TownshipCode));
                param[30] = new ReportParameter("CityCode4", this.GetDescriptionByCode("CityCode.SelectByCode", this.printingData.Customers[3].CityCode));
             //   param[30] = new ReportParameter("TownshipCode4", this.GetDescriptionByCode("TownshipCode.SelectByCode", this.printingData.Customers[3].TownshipCode));
                param[31] = new ReportParameter("StateCode4", this.GetDescriptionByCode("StateCode.SelectByCode", this.printingData.Customers[3].StateCode));
              //  param[31] = new ReportParameter("TownshipCode4", this.GetDescriptionByCode("TownshipCode.SelectByCode", this.printingData.Customers[3].TownshipCode));
            }
            else
            {
                param[24] = new ReportParameter("Name4", string.Empty);
                param[25] = new ReportParameter("FatherName4", string.Empty);
                param[26] = new ReportParameter("OccupationCode4", string.Empty);
                param[27] = new ReportParameter("NRC4", string.Empty);
                param[28] = new ReportParameter("Address4", string.Empty);
                param[29] = new ReportParameter("TownshipCode4", string.Empty);
                param[30] = new ReportParameter("CityCode4", string.Empty);
            //    param[30] = new ReportParameter("TownshipCode4", string.Empty);
                param[31] = new ReportParameter("StateCode4", string.Empty);
            //    param[31] = new ReportParameter("TownshipCode4", string.Empty);
            }

            if (this.printingData.Customers.Count > 4)
            {
                param[32] = new ReportParameter("Name5", this.printingData.Customers[4].Name);
                param[33] = new ReportParameter("FatherName5", this.printingData.Customers[4].FatherName);
                param[34] = new ReportParameter("OccupationCode5", this.GetDescriptionByCode("OccupationCode.SelectByCode", this.printingData.Customers[4].OccupationCode));
                param[35] = new ReportParameter("NRC5", this.printingData.Customers[4].NRC);
                param[36] = new ReportParameter("Address5", this.printingData.Customers[4].Address);
                param[37] = new ReportParameter("TownshipCode5", this.GetDescriptionByCode("TownshipCode.SelectByCode", this.printingData.Customers[4].TownshipCode));
                param[38] = new ReportParameter("CityCode5", this.GetDescriptionByCode("CityCode.SelectByCode", this.printingData.Customers[4].CityCode));
            //    param[38] = new ReportParameter("TownshipCode5", this.GetDescriptionByCode("TownshipCode.SelectByCode", this.printingData.Customers[4].TownshipCode));
                param[39] = new ReportParameter("StateCode5", this.GetDescriptionByCode("StateCode.SelectByCode", this.printingData.Customers[4].StateCode));
              //  param[39] = new ReportParameter("TownshipCode5", this.GetDescriptionByCode("TownshipCode.SelectByCode", this.printingData.Customers[4].TownshipCode));
            }
            else
            {
                param[32] = new ReportParameter("Name5", string.Empty);
                param[33] = new ReportParameter("FatherName5", string.Empty);
                param[34] = new ReportParameter("OccupationCode5", string.Empty);
                param[35] = new ReportParameter("NRC5", string.Empty);
                param[36] = new ReportParameter("Address5", string.Empty);
                param[37] = new ReportParameter("TownshipCode5", string.Empty);
                param[38] = new ReportParameter("CityCode5", string.Empty);
            //    param[39] = new ReportParameter("TownshipCode5", string.Empty);
                param[39] = new ReportParameter("StateCode5", string.Empty);
             //   param[39] = new ReportParameter("TownshipCode5", string.Empty);
            }

            if (this.printingData.Customers.Count > 5)
            {
                param[40] = new ReportParameter("Name6", this.printingData.Customers[5].Name);
                param[41] = new ReportParameter("FatherName6", this.printingData.Customers[5].FatherName);
                param[42] = new ReportParameter("OccupationCode6", this.GetDescriptionByCode("OccupationCode.SelectByCode", this.printingData.Customers[5].OccupationCode));
                param[43] = new ReportParameter("NRC6", this.printingData.Customers[5].NRC);
                param[44] = new ReportParameter("Address6", this.printingData.Customers[5].Address);
                param[45] = new ReportParameter("TownshipCode6", this.GetDescriptionByCode("TownshipCode.SelectByCode", this.printingData.Customers[5].TownshipCode));
                param[46] = new ReportParameter("CityCode6", this.GetDescriptionByCode("CityCode.SelectByCode", this.printingData.Customers[5].CityCode));
            //    param[46] = new ReportParameter("TownshipCode6", this.GetDescriptionByCode("TownshipCode.SelectByCode", this.printingData.Customers[5].TownshipCode));
                param[47] = new ReportParameter("StateCode6", this.GetDescriptionByCode("StateCode.SelectByCode", this.printingData.Customers[5].StateCode));
               // param[47] = new ReportParameter("TownshipCode6", this.GetDescriptionByCode("TownshipCode.SelectByCode", this.printingData.Customers[5].TownshipCode));
            }
            else
            {
                param[40] = new ReportParameter("Name6", string.Empty);
                param[41] = new ReportParameter("FatherName6", string.Empty);
                param[42] = new ReportParameter("OccupationCode6", string.Empty);
                param[43] = new ReportParameter("NRC6", string.Empty);
                param[44] = new ReportParameter("Address6", string.Empty);
                param[45] = new ReportParameter("TownshipCode6", string.Empty);
                param[46] = new ReportParameter("CityCode6", string.Empty);
              //  param[46] = new ReportParameter("TownshipCode6", string.Empty);
                param[47] = new ReportParameter("StateCode6", string.Empty);
             //   param[47] = new ReportParameter("TownshipCode6", string.Empty);
            }

            param[48] = new ReportParameter("BankName", this.printingData.BankName);
            param[49] = new ReportParameter("BranchName", this.printingData.BranchName);
            param[50] = new ReportParameter("Date", DateTime.Now.ToString(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.UIDateFormat)));
            param[51] = new ReportParameter("NameOfFirm", this.printingData.NameOfFirm);

            Image img = null;
            string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            {
                img = System.Drawing.Image.FromStream(stream);

                img.Save(tempFilePath);
            }

            param[52] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            this.rpvSavingCorganizationr2.LocalReport.EnableExternalImages = true;

            this.rpvSavingCorganizationr2.LocalReport.SetParameters(param);
            this.rpvSavingCorganizationr2.SetDisplayMode(DisplayMode.PrintLayout);
            this.rpvSavingCorganizationr2.ZoomMode = ZoomMode.FullPage;
            this.rpvSavingCorganizationr2.ZoomPercent = 75;
            this.rpvSavingCorganizationr2.RefreshReport();
        }
        #endregion

        private string GetDescriptionByCode(string key, string code)
        {
            string description = CXCLE00002.Instance.GetScalarObject<string>(key, new object[] {  code ,true});

            if(description == null)
            {
                return string.Empty;
            }

            return description;
        }
    }
}
