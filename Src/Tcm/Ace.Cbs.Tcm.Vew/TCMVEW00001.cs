//----------------------------------------------------------------------
// <copyright file="TCMVEW00001.cs" company="Ace Data Systems">
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
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Tcm.Vew
{
    public partial class TCMVEW00001 : BaseDockingForm, ITCMVEW00001
    {
        #region Constractor

        public TCMVEW00001()
        {
            InitializeComponent();
        }

        #endregion
      

        #region View Data Properties

        public string CreditAccountNo
        {
            get { return this.mtxtAccountNo.Text.Replace("-", "").Trim(); }
            set { this.mtxtAccountNo.Text = value; }
        }

        public string DebitAccountNo
        {
            get { return this.mtxtDebitAccountNo.Text.Replace("-", "").Trim(); }
            set { this.mtxtDebitAccountNo.Text = value; }
        }

        public string ChequeNo
        {
            get { return this.txtChequeNo.Text.Trim(); }
            set { this.txtChequeNo.Text = value; }
        }

        public decimal Amount
        {
            get
            {
                if (this.txtAmount.Text.Trim().Equals(string.Empty))
                    return 0;
                else
                    return Convert.ToDecimal(this.txtAmount.Text.Trim());
            }

            set { this.txtAmount.Text = Convert.ToString(value); }
        }

        public string Description
        {
            get
            {
                if (this.cboDuration.SelectedIndex < 0)
                    return string.Empty;
                else
                    return this.cboDuration.SelectedText.ToString();
            }

            set { this.cboDuration.SelectedText = value; }
        }

        public string ReceiptNo
        {
            get { return txtReceiptNo.Text.Trim(); }
            set { this.txtReceiptNo.Text = value; }
        }

        public decimal Rate
        {
            get
            {
                if (this.txtInterestRate.Text.Trim().Equals(string.Empty))
                    return 0;
                else
                    return Convert.ToDecimal(this.txtInterestRate.Text.Trim());
            }

            set { this.txtInterestRate.Text = Convert.ToString(value); }
        }

        public string TakenAccount
        {
            get { return this.mtxtInterestTakenAccount.Text.Replace("-", "").Trim(); }
            set { this.mtxtInterestTakenAccount.Text = value; }
        }

        public decimal Duration
        {
            get
            {
                if (this.cboDuration.SelectedValue == null)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToDecimal(this.cboDuration.SelectedValue.ToString());
                }
            }
            set { this.cboDuration.SelectedValue = value; }
        }

        public bool AutoRenewal
        {
            get { return chkAutoRenewal.Checked; }
            set { chkAutoRenewal.Checked = value; rdoBothPrincipleAndInterest.Checked = value; }
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
                this.rdoBothPrincipleAndInterest.Checked = !this.rdoOnlyPrinciple.Checked;
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

                
                if (cboDuration.SelectedIndex > -1)
                {
                    this.freceiptEntity.Duration = this.Duration;
                }
                this.freceiptEntity.Amount = this.Amount;
                this.freceiptEntity.DebitAccountNo = this.DebitAccountNo;
                this.freceiptEntity.CreditAccountNo = this.CreditAccountNo;
                this.freceiptEntity.ChequeNo = this.ChequeNo;
                this.freceiptEntity.ToAccountNo = this.TakenAccount;
                this.freceiptEntity.InterestRate = this.Rate;
                this.freceiptEntity.CurrencyCode = this.CurrencyCode;
                this.freceiptEntity.AccountSign = this.AccountSign;
                this.freceiptEntity.SourceBranchCode = this.SourceBranchCode;
                this.freceiptEntity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                this.freceiptEntity.RDate = DateTime.Now;
                this.freceiptEntity.LastInterestDate = DateTime.Now;

                if (chkAutoRenewal.Checked == false)
                    this.freceiptEntity.AccuredStatus = "00"; // autoRenewal checked Value
                else
                {
                    if (rdoBothPrincipleAndInterest.Checked)
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

        public IList<PFMDTO00007> FixRateList { get; set; }

        #endregion

        #region Presenter
        
        private ITCMCTL00001 fixedDepositTransferController;
        public ITCMCTL00001 FixedDepositTransferController
        {
            set
            {
                this.fixedDepositTransferController = value;
                this.fixedDepositTransferController.FixedDepositTransferView = this;
            }
            get
            {
                return this.fixedDepositTransferController;
            }
        }
        
        #endregion

        #region Methods

        public void GetCheckNofocus()
        {
            txtChequeNo.Focus();
        }

        private void InitializeControls()
        {
            this.DisableControls("FixedDepositTransfer.Load.Disable");
            this.mtxtDebitAccountNo.Focus();
            this.Status = string.Empty;
            this.SourceBranchCode = CXCOM00007.Instance.BranchCode;
            this.CreditAccountNo = string.Empty;
            this.DebitAccountNo = string.Empty;
            this.ChequeNo = string.Empty;
            this.Amount = 0;
            this.ReceiptNo = string.Empty;
            this.TakenAccount = string.Empty;
            this.Rate = 0;
            this.cboDuration.SelectedIndex = -1;
            this.AutoRenewal = false;
            this.gbInterestTakenAccount.Visible = false;
            this.gbRenewalType.Visible = false;            
            this.FixedDepositTransferController.ClearErrors();
        }

        private void BindDurationComboBox()
        {
            // Get client fixRate data.
            FixRateList = CXCLE00002.Instance.GetListObject<PFMDTO00007>("FixRate.Client.Select", new object[] { true });            
            cboDuration.DisplayMember = "Description";
            cboDuration.ValueMember = "Duration";
            cboDuration.DataSource = FixRateList;

            cboDuration.SelectedIndex = -1;
        }

        public void EnableControlsForReceiptEditing(string name)
        {
            this.EnableControls(name);
        }

        public void VisibleControlsForReceiptEditing(bool renewalType, bool takenAccount)
        {
            this.gbRenewalType.Visible = renewalType;
            this.gbInterestTakenAccount.Visible = takenAccount;
        }

        public void ShowInformationMessage(string message, object[] arguments)
        {
            CXUIMessageUtilities.ShowMessageByCode(message, arguments);
        }

        #endregion

        #region Events

        private void TCMVEW00001_Load(object sender, EventArgs e)
        {
            //Enable Disable for tool strip bar for Update/Delete/Insert/Select Operation
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);

            this.InitializeControls();

            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            this.mtxtDebitAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            this.txtReceiptNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiptFormat);

            this.EnableControls("FixedDepositTransfer.ChequeNo.Enable");
            this.DisableControls("FixedDepositTransfer.Load.Disable");
            this.gbInterestTakenAccount.Visible = false;
            this.gbRenewalType.Visible = false;

            this.BindDurationComboBox();
            
            //ReceiptFormat
            this.mtxtInterestTakenAccount.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
                        
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
                this.Status = "Save";
                if (this.FixedDepositTransferController.Save(this.FReceiptEntity))
                {
                    string debitAccountNo, creditAccountNo;
                    debitAccountNo = this.DebitAccountNo;
                    creditAccountNo = this.CreditAccountNo;
                    this.InitializeControls();

                    if (CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC00002) == DialogResult.Yes)
                    {
                        this.FixedDepositTransferController.FPRN_FilePrinting(creditAccountNo);

                        if (this.AccountSign.Substring(0, 1).Equals(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SavingAccountSign)))
                            this.FixedDepositTransferController.PRN_FilePrinting(debitAccountNo);
                    }
                }
                this.Status = string.Empty;
        }

        private void chkAutoRenewal_CheckedChanged(object sender, EventArgs e)
        {
            this.AutoRenewal = chkAutoRenewal.Checked;
            this.gbRenewalType.Visible = chkAutoRenewal.Checked;
            this.gbInterestTakenAccount.Visible = rdoOnlyPrinciple.Checked && chkAutoRenewal.Checked;
        }

        private void rdoOnlyPrinciple_CheckedChanged(object sender, EventArgs e)
        {
            this.gbInterestTakenAccount.Visible = rdoOnlyPrinciple.Checked;
            this.OnlyPrinciple = rdoOnlyPrinciple.Checked;
        }

        #endregion

    }
}
