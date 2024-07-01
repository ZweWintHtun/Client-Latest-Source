// <copyright file="TLMVEW00026.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate>2013-06-26</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version>1.0</Version>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Tel.Vew
{
    public partial class TLMVEW00026 : BaseDockingForm,ITLMVEW00026
    {
        #region Constructor
        public TLMVEW00026()
        {
            InitializeComponent();
        }
        public TLMVEW00026(bool isMainMenu, string parentFormId,string bygradename)
        {
            InitializeComponent();
            this.IsMainMenu = isMainMenu;
            this.ParentFormId = parentFormId;
            this.ByGradeName = bygradename;
        }
        #endregion       

        #region Controller
        private ITLMCTL00026 controller;
        public ITLMCTL00026 Controller
        {
            get { return this.controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }
        #endregion

        #region Controls Input Output

        public string ByGradeName { get; set; }
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
        public DateTime StartDate
        {
            get { return this.dtpStartDate.Value; }
            set { this.dtpStartDate.Value = value; }
        }
        public DateTime EndDate
        {
            get { return this.dtpEndDate.Value; }
            set { this.dtpEndDate.Value = value; }
 
        }
        public decimal MinimumAmount
        {
            get { return this.txtMinimumAmount.Value; }
            set { this.txtMinimumAmount.Text = value.ToString(); }
        }
        public decimal MaximumAmount
        {
            get { return this.txtMaximumAmount.Value; }
            set { this.txtMaximumAmount.Text = value.ToString(); }
        }

        public string Status { get; set; }

        public string AccountSign { get; set; }       
 
        #endregion

        #region Method
        public void EnableDisableMenuControls()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
        }

        public void InitializeControls()
        {
            this.EnableDisableMenuControls();

            //Get Date format of Start Date
           string startDate = this.dtpStartDate.ToString();
           startDate =  CXCOM00006.Instance.GetDateFormat(this.StartDate);            

            //Get Date format of End Date
           string endDate = this.dtpEndDate.ToString();
           endDate = CXCOM00006.Instance.GetDateFormat(this.EndDate);
           //this.dtpStartDate.MaxDate = DateTime.Now;
           //this.dtpEndDate.MaxDate = DateTime.Now;

           if (this.ByGradeName == "DepositListingByGrade")
           {
               this.Text = "Deposit Listing By Grade";

           }
           else
           {
               this.Text = "Withdraw Listing By Grade";
 
           }


           
        }

        public bool CheckDate()
        {

            bool date = CXCOM00006.Instance.IsValidStartDateEndDate(this.StartDate, this.EndDate);
            if (date == false)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00123");
            }

            return date;

        }
      
        #endregion

        #region Events
        private void TLMVEW00026_Load(object sender, EventArgs e)
        {
            this.InitializeControls();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (this.controller.Validate())
                {
                    //if (this.CheckDate())
                    if (!CXCOM00006.Instance.IsExceedTodayDate(this.StartDate))
                    {
                        if (!CXCOM00006.Instance.IsExceedTodayDate(this.EndDate))
                        {
                            if (this.StartDate > this.EndDate)
                            {
                                CXUIMessageUtilities.ShowMessageByCode("MV00131");//Start Date must not be greater than End Date.
                            }
                            else
                            {
                                string userNo = Convert.ToString(CurrentUserEntity.CurrentUserID);
                                int workStationId = CurrentUserEntity.WorkStationId;
                                string workstation = workStationId.ToString();
                                this.GetAccountSign();

                                if (this.ByGradeName == "DepositListingByGrade")
                                {
                                    if (CXClientWrapper.Instance.Invoke<ITLMSVE00063, IList<PFMDTO00042>>(x => x.SelectDepositListingByGrade(this.StartDate, this.EndDate, CurrentUserEntity.CurrentUserID, workstation, this.MinimumAmount, this.MaximumAmount, this.AccountSign, CurrentUserEntity.BranchCode)).Count > 0)
                                    {
                                        CXUIScreenTransit.Transit("frmTLMVEW00063", true, new object[] { this.Name, this.StartDate, this.EndDate, this.MinimumAmount, this.MaximumAmount, this.AccountSign, this.ByGradeName });

                                    }
                                    else
                                    {
                                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                                    }
                                }

                                else
                                {
                                    if (CXClientWrapper.Instance.Invoke<ITLMSVE00063, IList<PFMDTO00042>>(x => x.SelectWithdrawListingByGrade(this.StartDate, this.EndDate, CurrentUserEntity.CurrentUserID, workStationId, this.MinimumAmount, this.MaximumAmount, this.AccountSign, CurrentUserEntity.BranchCode)).Count > 0)
                                    {
                                        CXUIScreenTransit.Transit("frmTLMVEW00063", true, new object[] { this.Name, this.StartDate, this.EndDate, this.MinimumAmount, this.MaximumAmount, this.AccountSign, this.ByGradeName });

                                        this.Text = "Withdraw Listing By Grade";
                                    }
                                    else
                                    {
                                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                                    }

                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }  

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
       {
           this.Close();
       }

        #endregion

        private void rdoCurrentAccout_CheckedChanged(object sender, EventArgs e)
        {
            this.AccountSign = "C";
        }

        private void rdoSavingAccount_CheckedChanged(object sender, EventArgs e)
        {
            this.AccountSign = "S";
        }

        private void rdoFixedAccount_CheckedChanged(object sender, EventArgs e)
        {
            this.AccountSign = "F";
        }

        // updated by ZMS (For Pristine)
        private void rdoBLAccount_CheckedChanged(object sender, EventArgs e)
        {
            this.AccountSign = "B";
        }
        private void rdoHPAcount_CheckedChanged(object sender, EventArgs e)
        {
            this.AccountSign = "H";
        }
        private void rdoPLAccount_CheckedChanged(object sender, EventArgs e)
        {
            this.AccountSign = "P";
        }
        private void rdoDLAccount_CheckedChanged(object sender, EventArgs e)
        {
            this.AccountSign = "D";
        }
        // updated by ZMS (For Pristine)

        public void GetAccountSign()
        {
            // updated by ZMS (For Pristine)
            if (this.rdoBLAccount.Checked)
            {
                this.AccountSign = "B";
            }
            else if (this.rdoHPAcount.Checked)
            {
                this.AccountSign = "H";
            }
            else if (this.rdoPLAccount.Checked)
            {
                this.AccountSign = "P";
            }
            else if (this.rdoDLAccount.Checked)
            {
                this.AccountSign = "D";
            }
            // updated by ZMS (For Pristine)
            else if (this.rdoCurrentAccout.Checked)
            {
                this.AccountSign = "C"; 
            }
            else if (this.rdoSavingAccount.Checked)
            {
                this.AccountSign = "S";
            }
            else
            {
                this.AccountSign = "F"; 
            }
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.MinimumAmount = 0;
            this.MaximumAmount = 0;
            this.dtpStartDate.Value = DateTime.Today;
            this.dtpEndDate.Value = DateTime.Today;
            this.rdoCurrentAccout.Checked = true;
            this.controller.ClearCustomErrorMessage();
            //this.MaximumAmount =Convert.ToDecimal(10000);
            
        }
    }
}
