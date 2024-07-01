//----------------------------------------------------------------------
// <copyright file="TLMVEW00038.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-07-12</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//---------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.CXClient;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Utt;


namespace Ace.Cbs.Tel.Vew
{
    /// <summary>
    /// (Listing -> Drawing Remittance Listing) -> Drawing Remittance Listing All/By Branch
    ///(Listing -> Encashment Remittance Listing) -> Encashment Remittance Listing All/By Branch
    /// </summary>
    /// 
    public partial class TLMVEW00038 : BaseDockingForm,ITLMVEW00038
    {
        #region "Properties"
        public string TransactionStatus
        {
            get { return this.FormName; }
        }

        public DateTime StartDate
        {
            get { return this.dtpStartDate.Value; }
            set { this.dtpStartDate.Text = value.ToString(); }
        }


        public DateTime EndDate
        {
            get { return this.dtpEndDate.Value; }
            set { this.dtpEndDate.Text = value.ToString(); }
        }



        public string BranchNo
        {
            get
            {
                if (this.cboBranchNo.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cboBranchNo.SelectedValue.ToString();
                }
            }

            set { this.cboBranchNo.SelectedValue = value; }
        }


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
        #endregion

        #region "Constructors"
        public TLMVEW00038()
        {
            InitializeComponent();
        }

         public TLMVEW00038(bool isMainMenu, string formName)
        {
            InitializeComponent();
            this.IsMainMenu = isMainMenu;
            this.FormName = formName;
         
        }
         #endregion

        #region "Controllers"
         private ITLMCTL00038 controller;
         public ITLMCTL00038 DrawingEncashController //WithdrawalListingByAllController
         {
             get
             {
                 return this.controller;
             }
             set
             {
                 this.controller = value;
                 this.controller.DrawingRemittanceEncashAllByBranchView = this;
             }
         }

         #endregion

        #region "Events"

         private void TLMVEW00038_Load(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.Text = this.GetFormNameString("(All/ By Branch)");
             
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }


        private void rdoByBranch_CheckedChanged(object sender, EventArgs e)
        {
            this.cboBranchNo.Enabled = true;
        }


        private void rdoAllBranches_CheckedChanged(object sender, EventArgs e)
        {
            this.cboBranchNo.Enabled = false;
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            if (this.CheckDate())
            {
                IList<TLMDTO00017> DrawingEncashLists = new List<TLMDTO00017>();
                if (TransactionStatus == "Drawing Remittance Listing")
                {
                    if  (this.cboBranchNo.Enabled == true && this.rdoTransactionDate.Checked == true)
                    {
                        DrawingEncashLists = this.DrawingEncashController.MainPrint("Drawing By Branch By Transaction Date");
                        if (DrawingEncashLists.Count > 0)
                        {
                            CXUIScreenTransit.Transit("frmTLMVEW00058DrawingTransactionByBranch", true, new object[] { DrawingEncashLists, "Daily Drawing Remittance Listing By Transaction Date", this.StartDate, this.EndDate, this.BranchNo, "Drawing Remittance Listing (By Branch)" });
                        }
                        else
                        {
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                        }
                    }

                    else if (this.cboBranchNo.Enabled == false && this.rdoTransactionDate.Checked == true)
                    {
                        DrawingEncashLists = this.controller.MainPrint("Drawing All By Transaction Date");
                        if (DrawingEncashLists.Count > 0)
                        {
                            CXUIScreenTransit.Transit("frmTLMVEW00058DrawingTransactionByALL", true, new object[] { DrawingEncashLists,"Daily Drawing Remittance Listing By Transaction Date",this.StartDate, this.EndDate, "Drawing Remittance Listing (By ALL Branches)" });
                        }

                        else
                        {
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                        }                      
                    }

                    else if (this.cboBranchNo.Enabled == true && this.rdoSettlementDate.Checked == true)
                    {
                        DrawingEncashLists = this.DrawingEncashController.MainPrint("Drawing By Branch By Settlement Date");

                        if (DrawingEncashLists.Count > 0)
                        {
                            CXUIScreenTransit.Transit("frmTLMVEW00058DrawingSettlementByBranch", true, new object[] { DrawingEncashLists, "Daily Drawing Remittance Listing By Settlement Date", this.StartDate, this.EndDate, this.BranchNo, "Drawing Remittance Listing By Branch Report" });
                        }
                        else
                        {
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                        }
                    }

                    else
                    {
                        DrawingEncashLists = this.DrawingEncashController.MainPrint("Drawing All By Settlement Date");

                        if (DrawingEncashLists.Count > 0)
                        {
                            CXUIScreenTransit.Transit("frmTLMVEW00058DrawingSettlementByALL", true, new object[] { DrawingEncashLists, "Daily Drawing Remittance Listing By Settlement Date", this.StartDate, this.EndDate, "Drawing Remittance Listing By ALL Report" });
                        }
                        else
                        {
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                        }
                    }
                }

                else
                {
                    if (this.cboBranchNo.Enabled == true && this.rdoTransactionDate.Checked == true)
                    {
                        DrawingEncashLists = this.DrawingEncashController.MainPrint("Encash By Branch By Transaction Date");
                        if (DrawingEncashLists.Count > 0)
                        {
                            CXUIScreenTransit.Transit("frmTLMVEW00061EncashTransactionByBranch", true, new object[] { DrawingEncashLists, "Daily Encash Remittance Listing By Transaction Date", this.StartDate, this.EndDate, this.BranchNo, "Encash Remittance Listing By Branch Report" });
                        }

                        else
                        {
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                        }

                    }

                    else if (this.cboBranchNo.Enabled == false && this.rdoTransactionDate.Checked == true)
                    {
                        DrawingEncashLists = this.DrawingEncashController.MainPrint("Encash All By Transaction Date");
                        if (DrawingEncashLists.Count > 0)
                        {
                            CXUIScreenTransit.Transit("frmTLMVEW00061EncashTransactionByALL", true, new object[] { DrawingEncashLists, "Daily Encash Remittance Listing By Transaction Date", this.StartDate, this.EndDate, "Encash Remittance Listing By ALL Report" });
                        }

                        else
                        {
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                        }
                    }

                    else if (this.cboBranchNo.Enabled == true && this.rdoSettlementDate.Checked == true)
                    {
                        DrawingEncashLists = this.DrawingEncashController.MainPrint("Encash By Branch By Settlement Date");

                        if (DrawingEncashLists.Count > 0)
                        {
                            CXUIScreenTransit.Transit("frmTLMVEW00061EncashSettlementByBranch", true, new object[] { DrawingEncashLists, "Daily Encash Remittance Listing By Settlement Date", this.StartDate, this.EndDate, this.BranchNo, "Encash Remittance Listing By Branch Report" });
                        }

                        else
                        {
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                        }
                    }

                    else
                    {
                        DrawingEncashLists = this.DrawingEncashController.MainPrint("Encash All By Settlement Date");
                        if (DrawingEncashLists.Count > 0)
                        {
                            CXUIScreenTransit.Transit("frmTLMVEW00061EncashSettlementByALL", true, new object[] { DrawingEncashLists, "Daily Encash Remittance Listing By Settlement Date", this.StartDate, this.EndDate, "Encash Remittance Listing By ALL Report" });
                        }
                        else
                        {
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                        }

                    }
                }
            }
                    
        }
        #endregion

        #region "Methods"

        public void EnableDisableControls()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false,false,true, true, true);
        }

        private string GetFormNameString(string parameter)
        {
            switch (this.FormName)
            {
                case "Drawing Remittance Listing":
                    return "Drawing Remittance Listing " + parameter;

                case "Encash Remittance Listing":
                    return "Encash Remittance Listing" + parameter;

                default:
                    return string.Empty;
            }
        }

        private void BindBranchCode()
        {
            IList<BranchDTO> BranchCodeList = CXCLE00002.Instance.GetListObject<BranchDTO>("Branch.Client.Select");
            //IList<BranchDTO> BranchCodeList = CXCLE00002.Instance.GetListObject<BranchDTO>("Branch.Client.SelectNotOtherBank", new object[] { false, true });
            var list = (from value in BranchCodeList
                              where value.BranchCode != CurrentUserEntity.BranchCode
                              select value).ToList();
            this.cboBranchNo.DisplayMember = "BranchCode";
            this.cboBranchNo.ValueMember = "BranchCode";
            this.cboBranchNo.DataSource = list;
            this.cboBranchNo.SelectedIndex = -1;
        }

        private void InitializeControls()
        {
            this.EnableDisableControls();
            this.BindBranchCode();
            this.rdoByBranch.Checked = false;
            this.cboBranchNo.Enabled = false;            
            this.rdoAllBranches.Checked = true;
            this.rdoTransactionDate.Checked = true;            
        }
        private bool CheckDate()
        {
           bool date= CXCOM00006.Instance.IsValidStartDateEndDate(this.dtpStartDate.Value, this.dtpEndDate.Value);
           if (date == false)
           {
               Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00123");
           }         
           
           return date;           
        }
     
        #endregion      

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.StartDate = DateTime.Now;
            this.EndDate = DateTime.Now;
        }
    }
}
