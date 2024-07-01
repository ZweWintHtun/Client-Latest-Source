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
    public partial class MNMVEW00106 : BaseDockingForm
    {
        #region Properties
        private string fname;
        public string FormName
        {
            get { return this.fname; }
            set { this.fname = value; }
        }
        //public string AccountNo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Header { get; set; }
        public string _fname { get; set; }
        public IList<PFMDTO00017> PrintDataList { get; set; }

        #endregion

        #region Constructor
        public MNMVEW00106()
        {
            InitializeComponent();
        }

        public MNMVEW00106(IList<PFMDTO00017> List, DateTime startDate, DateTime endDate,string formName)
        {
            this.FormName = formName;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.PrintDataList = List;
            this.FormName = formName;
            if (formName == "Current Account All")
            {
                this.Header = "Listing For Current A/C Opening (All) From " + this.StartDate.ToString("dd/MM/yyyy") + " To " + this.EndDate.ToString("dd/MM/yyyy");
            }
            else if(formName == "Current Account Association")
            {
                this.Header = "Listing For Current A/C Opening (Association) From" + this.StartDate.ToString("dd/MM/yyyy") + " To " + this.EndDate.ToString("dd/MM/yyyy");
            }
            else if(formName == "Saving Account All")
            {
                this.Header = "Listing For Saving A/C Opening (All) From " + this.StartDate.ToString("dd/MM/yyyy") + " To " + this.EndDate.ToString("dd/MM/yyyy");
            }
            else if (formName == "Saving Account Organization")
            {
                this.Header = "Listing For Saving A/C Opening (Organization) From" + this.StartDate.ToString("dd/MM/yyyy") + " To " + this.EndDate.ToString("dd/MM/yyyy");
            }
            #region Added By HWKO (23-Jun-2017) For PRISTINE
            else if (formName == "Business Loan Account All") //Added By HWKO (23-Jun-2017)
            {
                this.Header = "Listing For Business Loan A/C Opening (All) From " + this.StartDate.ToString("dd/MM/yyyy") + " To " + this.EndDate.ToString("dd/MM/yyyy");
            }
            else if (formName == "Hire Purchase Loan Account All") //Added By HWKO (23-Jun-2017)
            {
                this.Header = "Listing For Hire Purchase Loan A/C Opening (All) From " + this.StartDate.ToString("dd/MM/yyyy") + " To " + this.EndDate.ToString("dd/MM/yyyy");
            }
            else if (formName == "Personal Loan Account All") //Added By HWKO (23-Jun-2017)
            {
                this.Header = "Listing For Personal Loan A/C Opening (All) From " + this.StartDate.ToString("dd/MM/yyyy") + " To " + this.EndDate.ToString("dd/MM/yyyy");
            }
            else if (formName == "Dealer Account All") //Added By HWKO (04-Aug-2017)
            {
                this.Header = "Listing For Dealer A/C Opening (All) From " + this.StartDate.ToString("dd/MM/yyyy") + " To " + this.EndDate.ToString("dd/MM/yyyy");
            }
            #endregion
            InitializeComponent();
        }
        #endregion

        #region Event
        private void MNMVEW00106_Load(object sender, EventArgs e)
        {
            this.Text = this.FormName + " Listing";
            Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });

            rpvCurrentAccountAll.LocalReport.DataSources.Clear();
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
            //string hh = "i"; //test for column disable / enable
            //para[6] = new ReportParameter("IsVisible", (hh=="i")? "True":"False");
           

            this.rpvCurrentAccountAll.LocalReport.EnableExternalImages = true;
            this.rpvCurrentAccountAll.LocalReport.SetParameters(para);
            ReportDataSource dataset = new ReportDataSource("CurrentAccountDataSet", PrintDataList);
            this.rpvCurrentAccountAll.LocalReport.DataSources.Add(dataset);
            dataset.Value = PrintDataList;

            this.rpvCurrentAccountAll.RefreshReport();

        }
        #endregion
    }
}
