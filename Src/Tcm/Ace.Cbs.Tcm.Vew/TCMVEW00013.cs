//----------------------------------------------------------------------
// <copyright file="TCMVEW00013.cs" company="Ace Data Systems">
// Copyright (c) Ace Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>AK</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Com.Utt;
using System.Windows.Forms;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Cle;

namespace Ace.Cbs.Tcm.Vew
{
    public partial class TCMVEW00013 : BaseForm, ITCMVEW00013
    {
        private bool isFirstBind = true;
        private IList<PFMDTO00007> FixRateList;

        #region Constractor

        public TCMVEW00013()
        {
            InitializeComponent();
        }

        #endregion

        #region View Data Properties

        public string OldReceiptNo { get; set; }
        public bool IsFReceiptValidate { get; set; }
        public bool IsReverse { get; set; }
        

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
            get { return this.mtxtInterestTakenAccount.Text.Replace("-", "").Trim(); }
            set { this.mtxtInterestTakenAccount.Text = value; }
        }

        public decimal Duration
        {

            get
            {
                if (cboDurationDesp.SelectedValue == null || string.IsNullOrEmpty(this.cboDurationDesp.SelectedValue.ToString()))
                {
                    return -1;
                }
                else
                {
                    return Convert.ToDecimal(this.cboDurationDesp.SelectedValue.ToString());
                }
            }
            set
            {
                this.cboDurationDesp.SelectedValue = value;
            }
        }

        public bool AutoRenewal
        {
            get { return chkAutoRenewal.Checked; }
            set { chkAutoRenewal.Checked = value; rdoBothPrincipleandInterest.Checked = value; }
        }

        public bool OnlyPrinciple 
        {
            get
            {
                return this.rdoOnlyPrinciple.Checked;
            }
            set
            {
                this.rdoOnlyPrinciple.Checked = value;
                this.rdoBothPrincipleandInterest.Checked = !this.rdoOnlyPrinciple.Checked;
            }
        }

        public string SourceBranchCode { get; set; }

        public string Status { get; set; }

        public string AccountSign { get; set; }

        public string CurrencyCode { get; set; }

        #endregion

        #region Entity

        private PFMDTO00032 freceiptEntity;
        public PFMDTO00032 FReceiptEntity
        {
            get
            {
                if (this.freceiptEntity == null) this.freceiptEntity = new PFMDTO00032();

                this.freceiptEntity.Amount = this.Amount;
                this.freceiptEntity.IsReversalTransaction = this.freceiptEntity.IsReversalTransaction ? true : false;

                if (cboDurationDesp.SelectedIndex > -1)
                {
                    this.freceiptEntity.Duration = this.Duration;
                }

                this.freceiptEntity.AccountNo = this.AccountNo;
                this.freceiptEntity.ToAccountNo = string.Empty;
                this.freceiptEntity.InterestRate = this.Rate;
                this.freceiptEntity.Status = this.Status;
                this.freceiptEntity.SourceBranchCode = this.SourceBranchCode;
                this.freceiptEntity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                this.freceiptEntity.CurrencyCode = this.CurrencyCode;
                this.freceiptEntity.AccountSign = this.AccountSign;
                this.freceiptEntity.ReceiptNo = this.ReceiptNo;
                this.freceiptEntity.Duration = this.Duration;
                this.freceiptEntity.OldReceiptNo = this.OldReceiptNo;

                if (this.AutoRenewal == false)
                    this.freceiptEntity.AccuredStatus = "00"; // autoRenewal checked Value
                else
                {
                    if (!this.OnlyPrinciple)
                        this.freceiptEntity.AccuredStatus = "11";
                    else if (rdoOnlyPrinciple.Checked)
                    {
                        this.freceiptEntity.AccuredStatus = "12";
                        this.freceiptEntity.ToAccountNo = this.TakenAccount;
                    }
                }
                this.freceiptEntity.AutoRenewal = this.AutoRenewal;

                return this.freceiptEntity;
            }

            set { this.freceiptEntity = value; }
        }

        private IList<PFMDTO00032> fReceiptList;
        public IList<PFMDTO00032> FReceiptList 
        { 
            get
            {
                if (fReceiptList == null)
                    return new List<PFMDTO00032>();
                else
                    return fReceiptList;
            }
            set
            {
                fReceiptList = value;
            }
        }

        #endregion

        #region Presenter
        private ITCMCTL00013 freceiptController;
        public ITCMCTL00013 FReceiptController
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

        #region Methods

        private void InitializeControls()
        {
            this.Status = string.Empty;
            this.SourceBranchCode = CXCOM00007.Instance.BranchCode;
            this.AccountNo = string.Empty;
            this.Amount = 0;
            this.ReceiptNo = string.Empty;
            this.TakenAccount = string.Empty;
            this.Rate = 0;
            this.cboDurationDesp.Text = string.Empty;
            this.cboDurationDesp.SelectedIndex = -1;
            this.AutoRenewal = false;
            this.DisableControls("FormLoad.Disable");
            this.EnableControls("FReceiptNo.Enable");
            this.gbInterestTakenAccount.Visible = false;
            this.gbRenewalType.Visible = false;
            this.Size = new System.Drawing.Size(482, 232);
            this.mtxtAccountNo.Focus();

        }

        public void EnableControlsForReceiptEditing(string name)
        {
            this.EnableControls(name);
        }

        public void VisibleControlsForReceiptEditing(bool renewalType,bool takenAccount)
        {
            this.gbRenewalType.Visible = renewalType;
            this.gbInterestTakenAccount.Visible = takenAccount;
        }

        public void ShowInformationMessage(string message, object[] arguments)
        {
            CXUIMessageUtilities.ShowMessageByCode(message, arguments);
        }

        private void BindDurationComboBox()
        {
            // Get client fixRate data.
            FixRateList = CXCLE00002.Instance.GetListObject<PFMDTO00007>("FixRate.Client.Select", new object[] { true });

            cboDurationDesp.DisplayMember = "Description";

            cboDurationDesp.ValueMember = "Duration";

            cboDurationDesp.DataSource = FixRateList;

            cboDurationDesp.SelectedIndex = -1;
        }

        private string GenerateReceiptNoByAccountNo(decimal duration)
        {
            //string prefixCode = GetPrefixCode(Convert.ToInt32(Convert.ToInt32(duration)));
            string prefixCode = GetPrefixCode(duration);
            return prefixCode + (0 + 1).ToString().PadLeft(4, '0');
        }


        private string GetPrefixCode(decimal duration)
        {
            string prefixCode = string.Empty;

            if (duration < 1)
            {
                duration *= 4;
                prefixCode = Convert.ToInt32(duration).ToString() + 'W';
            }
            else if (duration >= 1 && duration < 12)
            {
                prefixCode = Convert.ToInt32(duration).ToString() + 'M';
            }
            else if (duration >= 12)
            {
                duration = duration / 12;
                prefixCode = Convert.ToInt32(duration).ToString() + 'Y';
            }

            return prefixCode;
        }

       

        public void ReceiptNoDisable()
        {
            //this.DisableControls("FReceiptNo.Disable");
            this.mtxtReceiptNo.Enabled = false;
        }

        #endregion        

        #region Events

        private void TCMVEW00013_Load(object sender, EventArgs e)
        {
            this.InitializeControls();

            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            this.mtxtReceiptNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiptFormat);

            //ReceiptFormat
            this.mtxtInterestTakenAccount.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);

            //Enable Disable for tool strip bar for Update/Delete/Insert/Select Operation
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            isFirstBind = false;
            BindDurationComboBox();
            this.mtxtReceiptNo.Text = string.Empty;
            this.Size = new System.Drawing.Size(482, 232);
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.FReceiptController.ClearErrors();
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.Status = "Delete";
            if (this.FReceiptController.Delete(this.FReceiptEntity))
                this.InitializeControls();
            this.Status = string.Empty;
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.Status = "Save";
            this.FReceiptEntity.IsReversalTransaction = this.IsReverse;
            if (this.FReceiptController.Save(this.FReceiptEntity))
            {
                this.InitializeControls();
            }
            this.Status = string.Empty;
        }

        private void chkAutoRenewal_CheckedChanged(object sender, EventArgs e)
        {
            this.AutoRenewal = chkAutoRenewal.Checked;
            this.gbRenewalType.Visible = chkAutoRenewal.Checked;
            this.gbInterestTakenAccount.Visible = rdoOnlyPrinciple.Checked && chkAutoRenewal.Checked;
            this.Size = new System.Drawing.Size(482, 350);
        }

        private void rdoOnlyPrinciple_CheckedChanged(object sender, EventArgs e)
        {
            this.gbInterestTakenAccount.Visible = rdoOnlyPrinciple.Checked;
            this.OnlyPrinciple = rdoOnlyPrinciple.Checked;
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
        }

        private void cboDurationDesp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.IsFReceiptValidate)
                return;
            if (!(cboDurationDesp.SelectedValue == null || string.IsNullOrEmpty(cboDurationDesp.SelectedValue.ToString()) || cboDurationDesp.SelectedIndex == -1))
                this.mtxtReceiptNo.Text = this.GenerateReceiptNoByAccountNo(Convert.ToDecimal(cboDurationDesp.SelectedValue.ToString()));
        }

        private void mtxtReceiptNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }
        #endregion

        private void TCMVEW00013_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }
    }
}
