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
    public partial class MNMVEW00135 : BaseDockingForm
    {
        #region Properties
        public string FormName { get; set; }
        //public string AccountNo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Header { get; set; }
        public IList<PFMDTO00017> PrintDataList { get; set; }
        #endregion

        #region Constructor
        public MNMVEW00135()
        {
            InitializeComponent();
        }
        public MNMVEW00135(IList<PFMDTO00017> List, DateTime startDate, DateTime endDate, string formName)
        {
            this.FormName = formName;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.PrintDataList = List;
            if (formName == "Saving Account Joint")
            {
               // this.Text = "Current Account Opening (Joint)";
                this.Header = "Listing For Saving A/C Opening (Joint) From " + this.StartDate.ToString("dd/MM/yyyy") + " To " + this.EndDate.ToString("dd/MM/yyyy");
            }
            else if (formName == "Current Account Joint")
            {
                this.Header = "Listing For Current A/C Opening (Joint) From " + this.StartDate.ToString("dd/MM/yyyy") + " To " + this.EndDate.ToString("dd/MM/yyyy");
            }
            else if (formName == "Saving Account Individual")
            {
                this.Header = "Listing For Saving A/C Opening (Individual) From " + this.StartDate.ToString("dd/MM/yyyy") + " To " + this.EndDate.ToString("dd/MM/yyyy");
            }
            #region Added By HWKO (23-Jun-2017) For PRISTINE
            else if (formName == "Business Loan Account Individual") // Added By HWKO (23-Jun-2017)
            {
                this.Header = "Listing For Business Loan A/C Opening (Individual) From " + this.StartDate.ToString("dd/MM/yyyy") + " To " + this.EndDate.ToString("dd/MM/yyyy");
            }
            else if (formName == "Hire Purchase Loan Account Individual") // Added By HWKO (23-Jun-2017)
            {
                this.Header = "Listing For Hire Purchase Loan A/C Opening (Individual) From " + this.StartDate.ToString("dd/MM/yyyy") + " To " + this.EndDate.ToString("dd/MM/yyyy");
            }
            else if (formName == "Personal Loan Account Individual") // Added By HWKO (23-Jun-2017)
            {
                this.Header = "Listing For Personal Loan A/C Opening (Individual) From " + this.StartDate.ToString("dd/MM/yyyy") + " To " + this.EndDate.ToString("dd/MM/yyyy");
            }
            else if (formName == "Dealer Account Individual") // Added By HWKO (04-Aug-2017)
            {
                this.Header = "Listing For Dealer A/C Opening (Individual) From " + this.StartDate.ToString("dd/MM/yyyy") + " To " + this.EndDate.ToString("dd/MM/yyyy");
            }
            else if (formName == "Business Loan Account Joint") // Added By HWKO (23-Jun-2017)
            {
                this.Header = "Listing For Business Loan A/C Opening (Joint) From " + this.StartDate.ToString("dd/MM/yyyy") + " To " + this.EndDate.ToString("dd/MM/yyyy");
            }
            else if (formName == "Hire Purchase Loan Account Joint") // Added By HWKO (23-Jun-2017)
            {
                this.Header = "Listing For Hire Purchase Loan A/C Opening (Joint) From " + this.StartDate.ToString("dd/MM/yyyy") + " To " + this.EndDate.ToString("dd/MM/yyyy");
            }
            else if (formName == "Personal Loan Account Joint") // Added By HWKO (23-Jun-2017)
            {
                this.Header = "Listing For Personal Loan A/C Opening (Joint) From " + this.StartDate.ToString("dd/MM/yyyy") + " To " + this.EndDate.ToString("dd/MM/yyyy");
            }
            else if (formName == "Dealer Account Joint") // Added By HWKO (04-Aug-2017)
            {
                this.Header = "Listing For Dealer A/C Opening (Joint) From " + this.StartDate.ToString("dd/MM/yyyy") + " To " + this.EndDate.ToString("dd/MM/yyyy");
            }
            #endregion
            InitializeComponent();
        }

        #endregion

        #region Event
        private void MNMVEW00135_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("Loading Viewer Form");
            this.Text = this.FormName + " Listing";
            Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            
            if(Branch != null)MessageBox.Show("Loading Branch Info is success!!!");

            this.rpvCurrentAccountJoint.LocalReport.DataSources.Clear();
            //MessageBox.Show("Clear DataSources!!!");

            ReportParameter[] para = new ReportParameter[9];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[7] = new ReportParameter("BrCode", Branch.BranchCode);
            para[8] = new ReportParameter("Br_Alias", Branch.Bank_Alias);

            //MessageBox.Show("Before call bank logo!!!");
            Image img = null;
            string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            {
                img = System.Drawing.Image.FromStream(stream);

                img.Save(tempFilePath);
            }

            //MessageBox.Show("After call bank logo!!!");

            para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[5] = new ReportParameter("Header", Header);
            para[6] = new ReportParameter("Count", this.PrintDataList.Count.ToString());
            //para[5] = new ReportParameter("StartDate", StartDate.ToString("dd/MM/yyyy"));
            //para[6] = new ReportParameter("EndDate", EndDate.ToString("dd/MM/yyyy"));
            //MessageBox.Show("Loading Viewer Form(Setting parameters)");
            this.rpvCurrentAccountJoint.LocalReport.EnableExternalImages = true;
            this.rpvCurrentAccountJoint.LocalReport.SetParameters(para);
            ReportDataSource dataset = new ReportDataSource("CurrentAccountJoint", PrintDataList);
            this.rpvCurrentAccountJoint.LocalReport.DataSources.Add(dataset);
            dataset.Value = PrintDataList;
            //MessageBox.Show("Loading Viewer Form(Before RefreshReport)");
            this.rpvCurrentAccountJoint.RefreshReport();
            //MessageBox.Show("Loading Viewer Form(After RefreshReport)");
        }
        #endregion
    }
}
