using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Utt;
using System.IO;
using Microsoft.Reporting.WinForms;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient.Controls;


namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00136 : BaseDockingForm
    {
        #region Properties
        public string FormName { get; set; }               
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Header { get; set; }
        public IList<PFMDTO00017> PrintDataList { get; set; }
        #endregion

        #region Constructor
        public MNMVEW00136()
        {
            InitializeComponent();
        }
        public MNMVEW00136(IList<PFMDTO00017> List, DateTime startDate, DateTime endDate, string formName)
        {
            this.FormName = formName;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.PrintDataList = List;
            if (formName.Contains("Minor"))
                this.Header = "Listing For Saving A/C Opening (Minor) From " + this.StartDate.ToString("dd/MM/yyyy") + " To " + this.EndDate.ToString("dd/MM/yyyy");            
            InitializeComponent();
        }
        #endregion

        #region Event
        private void MNMVEW00136_Load(object sender, EventArgs e)
        {
            this.Text = this.FormName + " Listing";
            Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });

            this.rpvSavingAccountMinor.LocalReport.DataSources.Clear();
            ReportParameter[] para = new ReportParameter[9];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[7] = new ReportParameter("BrCode", Branch.BranchCode);
            para[8] = new ReportParameter("Br_Alias", Branch.Bank_Alias);


            Image img = null;
            string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            {
                img = System.Drawing.Image.FromStream(stream);

                img.Save(tempFilePath);
            }

            para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[5] = new ReportParameter("Header", Header);
            para[6] = new ReportParameter("Count", this.PrintDataList.Count.ToString());
            this.rpvSavingAccountMinor.LocalReport.EnableExternalImages = true;
            this.rpvSavingAccountMinor.LocalReport.SetParameters(para);
            ReportDataSource dataset = new ReportDataSource("SavingAccountMinor", PrintDataList);
            this.rpvSavingAccountMinor.LocalReport.DataSources.Add(dataset);
            dataset.Value = PrintDataList; 

            this.rpvSavingAccountMinor.RefreshReport();
        }
        #endregion
    }
}
