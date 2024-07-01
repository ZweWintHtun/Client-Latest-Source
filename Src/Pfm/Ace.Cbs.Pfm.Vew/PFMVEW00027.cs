//----------------------------------------------------------------------
// <copyright file="PFMVEW00012.cs" company="Ace Data Systems">
// Copyright (c) Ace Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.PTR;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Pfm.Vew
{
    public partial class PFMVEW00027 : BaseForm, IPFMVEW00027
    {
        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>

        private IPFMVEW00027 view;

        public IPFMVEW00027 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(IPFMVEW00027 view)
        {
            if (this.view == null)
            {
                this.view = view;                
            }
        }

        public PFMVEW00027()
        {
            InitializeComponent();
            this.Text = "Next Receipt Entry";
        }

        public PFMVEW00027(bool isMainMenu, string parentFormId)
        {
            InitializeComponent();
            this.IsMainMenu = isMainMenu;
            this.ParentFormId = parentFormId;
        }

        #endregion

        #region View Data Properties

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

        /// <summary>
        /// Account Number
        /// </summary>
        public string AccountNo
        {
            get { return this.mtxtAccountNo.Text.Trim(); }
            set { this.mtxtAccountNo.Text = value; }
        }

        /// <summary>
        /// Amount
        /// </summary>
        public decimal Amount
        {
            get
            {
                if (this.ntxtAmount.Text.Trim().Equals(string.Empty))
                    return 0;
                else
                    return Convert.ToDecimal(this.ntxtAmount.Text.Trim());
            }

            set { this.ntxtAmount.Text = Convert.ToString(value); }
        }

        /// <summary>
        /// Duration
        /// </summary>
        public string Description
        {
            get
            {
                if (this.cboDurationDesp.SelectedIndex < 0)
                    return string.Empty;
                else
                    return this.cboDurationDesp.SelectedText.ToString();
            }

            set { this.cboDurationDesp.SelectedText = value; }
        }

        /// <summary>
        /// ReceiptNo
        /// </summary>
        public string ReceiptNo
        {
            get { return mtxtReceiptNo.Text.Trim(); }                
            set { this.mtxtReceiptNo.Text = value; }
        }

        /// <summary>
        /// Rate
        /// </summary>
        public decimal Rate
        {
            get
            {
                if (this.ntxtInterestRate.Text.Trim().Equals(string.Empty))
                    return 0;
                else
                    return Convert.ToDecimal(this.ntxtInterestRate.Text.Trim());
            }

            set { this.ntxtInterestRate.Text = Convert.ToString(value); }
        }

        /// <summary>
        /// Interest Taken Account
        /// </summary>
        public string TakenAccount
        {
            get { return this.mtxtInterestTakenAccount.Text.Replace("-","").Trim(); }
            set { this.mtxtInterestTakenAccount.Text = value; }
        }

        public decimal Duration
        {
            get
            {
                if (this.cboDurationDesp.SelectedValue == null)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToDecimal(this.cboDurationDesp.SelectedValue.ToString());
                }
            }
            set { this.cboDurationDesp.SelectedValue = value; }
        }

        public bool AutoRenewal
        {
            get { return chkAutoRenewal.Checked && rdoOnlyPrinciple.Checked; }
            set { chkAutoRenewal.Checked = value; rdoOnlyPrinciple.Checked = value; }
        }
        public string LocalBranchCode { get; set; }
        #endregion

        #region Private Variable

        private IList<PFMDTO00007> FixRateList;

        private bool isFirstBind = true;

        #endregion

        #region Presenter
        private IPFMCTL00027 freceiptController;
        public IPFMCTL00027 FReceiptController
        {
            set
            {
                this.freceiptController = value;
                this.freceiptController.FReceiptView = this;
            }
            get
            {
                return this.freceiptController;
            }
        }
        #endregion

        #region Entity

        private PFMDTO00032 freceiptEntity;
        public PFMDTO00032 FReceiptEntity
        {
            get
            {
                if (this.freceiptEntity == null) this.freceiptEntity = new PFMDTO00032();

                this.freceiptEntity.Amount = this.Amount;

                if (cboDurationDesp.SelectedIndex > -1)
                {
                    this.freceiptEntity.Duration = this.Duration;
                }

                this.freceiptEntity.AccountNo = this.AccountNo;
                this.freceiptEntity.ToAccountNo = string.Empty;
                this.freceiptEntity.InterestRate = this.Rate;

                if (chkAutoRenewal.Checked == false)
                    this.freceiptEntity.AccuredStatus = "00"; // autoRenewal checked Value
                else
                {
                    if (rdoBothPrincipleandInterest.Checked)
                        this.freceiptEntity.AccuredStatus = "11";
                    else if (rdoOnlyPrinciple.Checked)
                    {
                        this.freceiptEntity.AccuredStatus = "12";
                        this.freceiptEntity.ToAccountNo = this.TakenAccount;
                    }
                }

                this.freceiptEntity.IsMainMenu = this.isMainMenu;
                this.freceiptEntity.AutoRenewal = this.AutoRenewal;

                return this.freceiptEntity;
            }

            set { this.freceiptEntity = value; }
        }

        #endregion

        #region Public Method

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        public void SuccessfulReceiptNo(string message,string receiptNo)
        {
            CXUIMessageUtilities.ShowMessageByCode(message,receiptNo);
        }

        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message, new object[] { message == "MV00091" || message=="MV00214" ? CurrentUserEntity.BranchCode : null });            
        }

        public void ShowInformationMessage(string message, object[] arguments)
        {
            CXUIMessageUtilities.ShowMessageByCode(message, arguments);
        }

        public void RebindReceiptNoTextBox(string receiptNo)
        {
            this.mtxtReceiptNo.Text = receiptNo;
        }

        #endregion

        #region Private Method
        /// <summary>
        /// Clear all controls vlaue.
        /// </summary>
        private void InitializeControls()
        {
            this.mtxtAccountNo.Focus();

            // Clear account number
            this.mtxtAccountNo.Clear();

            // Clear receipt nubmer
            this.mtxtReceiptNo.Clear();

            // Set default value
            this.ntxtAmount.Text = ".00";

            // Set default value
            this.ntxtInterestRate.Text = ".00";

            // Clear interest taken account.
            this.mtxtInterestTakenAccount.Clear();

            // CLear Selected Index
            this.cboDurationDesp.SelectedIndex = -1;

            this.mtxtInterestTakenAccount.Clear();
            this.LocalBranchCode = CurrentUserEntity.BranchCode;
        }

        private void InitializeVisibleControl()
        {
            if (this.IsMainMenu)
            {
                this.mtxtAccountNo.Visible = true;

                this.lblAccountNo.Visible = true;
            }
            else
            {
                this.mtxtAccountNo.Visible = false;

                this.lblAccountNo.Visible = false;
            }

            //Set default value
            this.chkAutoRenewal.Checked = false;
            this.rdoBothPrincipleandInterest.Checked = true;
            this.gbRenewalType.Visible = false;

            this.gbInterestTakenAccount.Visible = false;
        }

        /// <summary>
        /// Bind Duration from FixRate Datatable to combo
        /// </summary>
        private void BindDurationComboBox()
        {
            // Get client fixRate data.
            FixRateList = CXCLE00002.Instance.GetListObject<PFMDTO00007>("FixRate.Client.Select",new object[] {true});

            cboDurationDesp.DisplayMember = "Description";

            cboDurationDesp.ValueMember = "Duration";

            cboDurationDesp.DataSource = FixRateList;

            cboDurationDesp.SelectedIndex = -1;
        }

        #endregion

        #region Event

        private void PFMVEW00027_Load(object sender, EventArgs e)
        {
            InitializeControls();

            InitializeVisibleControl();

            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            this.mtxtReceiptNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiptFormat);

            //ReceiptFormat
            this.mtxtInterestTakenAccount.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);

            //Enable Disable for tool strip bar for Update/Delete/Insert/Select Operation
            this.tlspCommon.ButtonEnableDisabled(false, false, true, false, true, false, true);

            BindDurationComboBox();

            isFirstBind = false;
            this.Size = new System.Drawing.Size(490, 243);
        }

        private void chkAutoRenewal_CheckedChanged(object sender, EventArgs e)
        {            
            this.gbRenewalType.Visible = chkAutoRenewal.Checked;
            this.gbInterestTakenAccount.Visible = rdoOnlyPrinciple.Checked && chkAutoRenewal.Checked;            
            if(this.chkAutoRenewal.Checked)this.Size = new System.Drawing.Size(490, 304);
            else this.Size = new System.Drawing.Size(490, 243);
        }

        private void rdoOnlyPrinciple_CheckedChanged(object sender, EventArgs e)
        {            
            this.gbInterestTakenAccount.Visible = rdoOnlyPrinciple.Checked;
            this.Size = new System.Drawing.Size(490, 362);
        }

        private void tlspCommon_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.InitializeVisibleControl();
            this.FReceiptController.ClearErrors();
            this.Size = new System.Drawing.Size(490, 243);
        }

        private void tlspCommon_SaveButtonClick(object sender, EventArgs e)
        {
            if (this.IsMainMenu == false)
            {
                if (this.freceiptController.ValidateFormForAccountOpening(this.FReceiptEntity))
                {                    
                    if (this.freceiptController.Save(this.FReceiptEntity))
                    {
                        CXUIScreenTransit.SetData(this.parentFormId, this.FReceiptEntity);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }                    
                }
            }
            else
            {
                if (this.freceiptController.Save(this.FReceiptEntity))
                {
                    this.InitializeControls();
                    this.InitializeVisibleControl();
                }
                else
                {
                    if (rdoOnlyPrinciple.Checked == true) //add by hmw (to be set focus when Interest taken account no is fail in save event with custom validation.)
                    {
                        mtxtInterestTakenAccount.Focus();

                    }
                    else
                        mtxtAccountNo.Focus();
                }
            }
        }

        private void tlspCommon_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboDurationDesp_Validated(object sender, EventArgs e)
        {
            if (cboDurationDesp.SelectedIndex == -1 || isFirstBind)
            {
                return;
            }

            string desp = cboDurationDesp.Text;

            decimal duration = Convert.ToDecimal(cboDurationDesp.SelectedValue);

            decimal rate = FixRateList.Where(a => a.Description == desp && a.Duration == duration).SingleOrDefault<PFMDTO00007>().Rate;

            this.ntxtInterestRate.Text = rate.ToString();
            this.ntxtInterestRate.ReadOnly = true;
        }


        #endregion       

        private void rdoBothPrincipleandInterest_CheckedChanged(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(490, 304);
        }

        private void PFMVEW00027_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }
    }
}

