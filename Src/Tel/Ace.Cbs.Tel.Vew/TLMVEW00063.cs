//----------------------------------------------------------------------
// <copyright file="TLMVEW00063" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate>18.6.2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
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
    public partial class TLMVEW00063 : BaseForm, ITLMVEW00063
    {
        #region Controls Input Output
        public TLMVEW00063()
        {
            InitializeComponent();
        }
        public TLMVEW00063(string parentFormId, DateTime startDate, DateTime endDate, string counterNo, string depositName)
        {
            InitializeComponent();
            this.ParentFormId = parentFormId;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.CounterNo = counterNo;
            this.DepositName = depositName;
        }
        public TLMVEW00063(string parentFormId, DateTime startDate, DateTime endDate, decimal minimumAmount, decimal maximumAmount,string accountSign,string bygradename)
        {
            InitializeComponent();
            this.ParentFormId = parentFormId;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.MinimumAmount = minimumAmount;
            this.MaximumAmount = maximumAmount;
            this.AccountSign = accountSign;
            this.ByGradeName = bygradename;
        }

        public TLMVEW00063(string parentFormId, DateTime startDate, DateTime endDate, string counterNo, string depositName,IList<PFMDTO00042> lists)
        {
            InitializeComponent();
            this.ParentFormId = parentFormId;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.CounterNo = counterNo;
            this.DepositName = depositName;
            this.List = lists;

        }

        IList<PFMDTO00042> List { get; set; }
        public string ByGradeName { get; set; }
        public bool isCounter { get; set; }
        private bool isMainMenu = true;
        public bool IsMainMenu
        {
            get { return this.isMainMenu; }
            set { this.isMainMenu = value; }
        }
        private string parentFormId = string.Empty;
        public string ParentFormId
        {
            get { return this.parentFormId; }
            set { this.parentFormId = value; }
        }
        public string CounterNo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string DepositName { get; set; }        
        public  IList<PFMDTO00042> list {get;set;}
        public decimal MinimumAmount { get; set; }
       public decimal MaximumAmount { get; set; }
      public  string AccountSign { get; set; }
      

        #endregion

        #region Controller
        private ITLMCTL00063 controller;
        public ITLMCTL00063 Controller
        {
            get { return this.controller; }
            set
            {
              this.controller = value;
                this.controller.View = this;
            }
        }
     
        #endregion

        private void TLMVEW00063_Load(object sender, EventArgs e)
        {
            PFMDTO00042 reporttlfDTO = new PFMDTO00042();
            reporttlfDTO.StartDate = this.StartDate;
            reporttlfDTO.EndDate = this.EndDate;
            this.Text = ByGradeName;

            if (this.DepositName == "DepositListingByAll")
            {
                this.Text = "Deposit Listing (By All)";
                reporttlfDTO.ReportTitle = "Deposit Listing (By All) From "+this.StartDate.ToString("dd/MM/yyyy")+ " To "+this.EndDate.ToString("dd/MM/yyyy");
                this.list = this.List;
            }
            else if (this.DepositName == "DepositListingByCounterNo")
            {
                this.Text = "Deposit Listing (By User - " + this.CounterNo + ")";             
               // this.list = this.controller.ShowDepositByCounterReport();
               
                this.list = this.List;
                foreach (PFMDTO00042 item in this.list)
                {
                    item.UserNo = this.CounterNo;
 
                }
                reporttlfDTO.ReportTitle = "Deposit Listing (By User - " + this.CounterNo + ") from " + this.StartDate.ToString("dd/MM/yyyy") + " to " + this.EndDate.ToString("dd/MM/yyyy");
            }
            else if(this.ByGradeName == "DepositListingByGrade")
            {
                this.Text = "Deposit Listing (By Grade) ";
                reporttlfDTO.ReportTitle = "Deposit Listing (By Grade) between "+ this.MinimumAmount.ToString() + " and " + this.MaximumAmount.ToString();
                this.list = this.controller.ShowDepositByGrade(); 
            }

            else if (this.ByGradeName == "WithdrawListingByGrade")
            {
               
                reporttlfDTO.ReportTitle = "Withdraw Listing (By Grade) between " + this.MinimumAmount.ToString() + " and " + this.MaximumAmount.ToString();
                this.list = this.controller.ShowWithdrawByGrade();
                this.Text = "Withdraw Listing (By Grade) ";
            }

            if (list == null)
                list = new List<PFMDTO00042>();

            if (list.Count > 0)
            {

                reporttlfDTO.BankName = CurrentUserEntity.BranchDescription;

                Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });

                reporttlfDTO.BranchName = Branch.Address;
             // reporttlfDTO.SourceBranch = Branch.BranchCode;


                rpvDepositListingByAll.LocalReport.DataSources.Clear();
                ReportParameter[] para = new ReportParameter[9];
                para[0] = new ReportParameter("BankName", reporttlfDTO.BankName);
                para[1] = new ReportParameter("BranchName", reporttlfDTO.BranchName);
                para[2] = new ReportParameter("Phone", Branch.Phone);
                para[3] = new ReportParameter("Fax", Branch.Fax);
                para[7] = new ReportParameter("BrCode", Branch.BranchCode);
                para[8] = new ReportParameter("Br_Alias", Branch.Bank_Alias); 

                Image img = null;
                string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

                //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                //{
                //    img = System.Drawing.Image.FromStream(stream);

                //    img.Save(tempFilePath);
                //}

                para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);


                para[5] = new ReportParameter("ReportTitle", reporttlfDTO.ReportTitle);
                para[6] = new ReportParameter("TotalRecords", list.Count.ToString());


                this.rpvDepositListingByAll.LocalReport.EnableExternalImages = true;
                rpvDepositListingByAll.LocalReport.SetParameters(para);
                ReportDataSource dataset = new ReportDataSource("DepositListingByAllandByCounterDTO_DataSet", list);
                rpvDepositListingByAll.LocalReport.DataSources.Add(dataset);

                dataset.Value = list;
                this.rpvDepositListingByAll.RefreshReport();
            }

            else
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                this.Close();
            }
        }



      
    }
}

   


