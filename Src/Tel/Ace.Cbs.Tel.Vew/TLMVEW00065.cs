using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;
using System.Linq;
using Microsoft.Reporting.WinForms;
using System.IO;

namespace Ace.Cbs.Tel.Vew
{
    public partial class TLMVEW00065 : BaseForm, ITLMVEW00065
    {
        public TLMVEW00065()
        {
            InitializeComponent();
        }

        public TLMVEW00065(string parentFormId, DateTime startDate, DateTime endDate, string accountSign)
        {
            InitializeComponent();            
            this.ParentFormId = parentFormId;
            this.StartDate= startDate;
            this.EndDate = endDate;
            this.AccountSign = accountSign;
        }

        public TLMVEW00065(string parentFormId, DateTime startDate, DateTime endDate, string accountSign,IList<PFMDTO00042> list)
        {
            InitializeComponent();
            this.ParentFormId = parentFormId;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.AccountSign = accountSign;
            this.List = list;
        }

        private string parentFormId = string.Empty;
        public string ParentFormId
        {
            get { return this.parentFormId; }
            set { this.parentFormId = value; }
        }



        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string AccountSign { get; set; }

        private ITLMCTL00065 controller;
        public ITLMCTL00065 Controller
        {
            get { return this.controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }

        IList<PFMDTO00042> List { get; set; }
        private void TLMVEW00065_Load(object sender, EventArgs e)
        {
                PFMDTO00042 reporttlfDTO = new PFMDTO00042();
                if (this.AccountSign == CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurrentAccountSign))
                {
                    this.Text = "Deposit Listing (By Current Account)";
                    reporttlfDTO.ReportTitle = "Deposit Listing (By Current Account) "+" from "+ this.StartDate.ToString("dd/MM/yyyy")+" to "+this.EndDate.ToString("dd/MM/yyyy");
                }
                /*updated by ZMS (for Pristine)*/
                if (this.AccountSign == CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.BusinessLoanAccountSign))
                {
                    this.Text = "Deposit Listing (By Account Type - Business Loan)";
                    reporttlfDTO.ReportTitle = "Deposit Listing (By Account Type - Business Loan) " + " from " + this.StartDate.ToString("dd/MM/yyyy") + " to " + this.EndDate.ToString("dd/MM/yyyy");
                }
                if (this.AccountSign == CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.HirePurchaseLoanAccountSign))
                {
                    this.Text = "Deposit Listing (By Account Type - Hire Purchase)";
                    reporttlfDTO.ReportTitle = "Deposit Listing (By Account Type - Hire Purchase) " + " from " + this.StartDate.ToString("dd/MM/yyyy") + " to " + this.EndDate.ToString("dd/MM/yyyy");
                }
                if (this.AccountSign == CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.PersonalLoanAccountSign))
                {
                    this.Text = "Deposit Listing (By Account Type - Personal Loan)";
                    reporttlfDTO.ReportTitle = "Deposit Listing (By Account Type - Personal Loan) " + " from " + this.StartDate.ToString("dd/MM/yyyy") + " to " + this.EndDate.ToString("dd/MM/yyyy");
                }
                if (this.AccountSign == CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.DealerAccountSign))
                {
                    this.Text = "Deposit Listing (By Account Type - Dealer)";
                    reporttlfDTO.ReportTitle = "Deposit Listing (By Account Type - Dealer) " + " from " + this.StartDate.ToString("dd/MM/yyyy") + " to " + this.EndDate.ToString("dd/MM/yyyy");
                }
                /*updated by ZMS (for Pristine)*/
                else if (this.AccountSign == CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SavingAccountSign))
                {
                    this.Text = "Deposit Listing (By Saving Account)";
                    reporttlfDTO.ReportTitle = "Deposit Listing (By Saving Account) "+" from "+ this.StartDate.ToString("dd/MM/yyyy")+" to "+this.EndDate.ToString("dd/MM/yyyy");
                }
                else if (this.AccountSign == CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.FixedAccountSign))
                {
                    this.Text = "Deposit Listing (By Fixed Deposit Account)";
                    reporttlfDTO.ReportTitle = "Deposit Listing (By Fixed Deposit Account) "+" from "+ this.StartDate.ToString("dd/MM/yyyy")+" to "+this.EndDate.ToString("dd/MM/yyyy");
 
                }
             //   IList<PFMDTO00042> list = this.controller.ShowDepositByAccountTypeReport();
                IList<PFMDTO00042> list = this.List;
                if (list == null)
                    list = new List<PFMDTO00042>();
                if (list.Count > 0)
                {

                    reporttlfDTO.BankName = CurrentUserEntity.BranchDescription;

                    Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });

                    reporttlfDTO.BranchName = Branch.Address;
                //    reporttlfDTO.SourceBranch = Branch.BranchCode;

                    rpvDepositListingByAccountType.LocalReport.DataSources.Clear();
                    ReportParameter[] para = new ReportParameter[9];
                    para[0] = new ReportParameter("BankName", reporttlfDTO.BankName);
                    para[1] = new ReportParameter("BranchName", reporttlfDTO.BranchName);
                    para[2] = new ReportParameter("Phone", Branch.Phone);
                    para[3] = new ReportParameter("Fax", Branch.Fax);
                    para[7] = new ReportParameter("BrCode",Branch.BranchCode);
                    para[8] = new ReportParameter("Br_Alias", Branch.Bank_Alias);

                    Image img = null;
                    //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                    //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                    //{
                    //    img = System.Drawing.Image.FromStream(stream);

                    //    img.Save(tempFilePath);
                    //}

                    string tempFilePath = Application.StartupPath + "\\pristinelogo.png";
                    para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);


                    para[5] = new ReportParameter("ReportTitle", reporttlfDTO.ReportTitle);
                    para[6] = new ReportParameter("TotalRecords", list.Count.ToString());


                    this.rpvDepositListingByAccountType.LocalReport.EnableExternalImages = true;
                    rpvDepositListingByAccountType.LocalReport.SetParameters(para);
                    ReportDataSource dataset = new ReportDataSource("DepositListingByAllandByCounterDTO_DataSet", list);
                    rpvDepositListingByAccountType.LocalReport.DataSources.Add(dataset);

                    dataset.Value = list;
                    this.rpvDepositListingByAccountType.RefreshReport();
                }

                else
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                    this.Close();
                }
           
        }

     
    }
}
