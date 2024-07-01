//----------------------------------------------------------------------
// <copyright file="TLMVEW00042.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Ye Mann Aung</CreatedUser>
// <CreatedDate>2013-07-02</CreatedDate>
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
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
namespace Ace.Cbs.Tel.Vew
{
    public partial class TLMVEW00042 : BaseForm, ITLMVEW00042
    {

        #region Constructions

        public TLMVEW00042()
        {
            InitializeComponent();
        }

        public TLMVEW00042(string parentFromId, string accountNo)
        {
            InitializeComponent();
            this.ParentFormId = parentFromId;
            this.AccountNo = accountNo;
        }

        #endregion
        
        #region Properties
        
        public PFMDTO00067 AccountInformation { get; set; }

        public string ParentFormId { get; set; }
             
        public string AccountNo
        {
            get { return txtEnquiryAccountNo.Text; }
            set { txtEnquiryAccountNo.Text = value; }
        }
        public bool IsWithSignature
        {
            get { return chkShowSignature.Checked; }
            set { chkShowSignature.Checked = value; }
        }

        public bool IsWithPhoto
        {
            get { return chkPhoto.Checked; }
            set { chkPhoto.Checked = value; }
        }

        private ITLMCTL00042 controller;
        public ITLMCTL00042 Controller
        {
            get { return this.controller; }
            set
            {
                this.controller = value;
                controller.View = this;
            }
        }
        
        #endregion

        #region Method

        private void BindDataToUI()
        {
            this.txtAccountNo.Text = AccountInformation.AccountNo;
            this.txtBalance.Text = AccountInformation.Amount.ToString("N2");
            this.lbLinkAccountNo.Items.Clear();
            this.lbLinkAccountNo.Items.Add(AccountInformation.LinkAccountNo);
            this.pbPhoto.Image = (IsWithPhoto) ? CXClientGlobal.GetImage(AccountInformation.Photo) : null;
            this.pbSignature.Image = (IsWithSignature) ? CXClientGlobal.GetImage(AccountInformation.Signature) : null;
            this.BindCustomerGrid(AccountInformation.CustomerInfo);
            this.txtLoansAmount.Text = AccountInformation.LoansAmount.ToString("N2");
            this.txtLoansExpireAmount.Text = AccountInformation.ExpireAmount.ToString("N2");
            this.txtNoofLoans.Text = AccountInformation.NoOfLoan.ToString();
            this.txtMinimumBalance.Text = AccountInformation.MiniumBalance.ToString("N2");
            this.txtAvailableAmount.Text = (AccountInformation.Amount-AccountInformation.MiniumBalance).ToString("N2");
            this.txtLinkBalance.Text = AccountInformation.LinkAmount.ToString("N2");
            this.txtNoofPersonSign.Text = AccountInformation.NoOfPersonToSign.ToString();
            this.txtJointType.Text = AccountInformation.JointType;
            if (AccountInformation.ChequeInfo != null)
            {
                this.lbCheque.Items.Clear();
                foreach (PFMDTO00006 item in AccountInformation.ChequeInfo)
                {
                    this.lbCheque.Items.Add(item.StartNo + " - " + item.EndNo);
                }
            }
            
        }

        private void BindCustomerGrid(IList<PFMDTO00001> customerInformation)
        {
            gvCustomer.DataSource = null;
            gvCustomer.AutoGenerateColumns = false;
            gvCustomer.DataSource = customerInformation;
            
            for (int i = 0; i < gvCustomer.Rows.Count; i++)
            {
                if(customerInformation[i].IsVIP)
                gvCustomer.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LimeGreen;
            }
        }

        private void CleaningUIControls()
        {
            this.txtEnquiryAccountNo.Clear();
            this.txtAccountNo.Clear();
            this.txtBalance.Clear();
            this.lbLinkAccountNo.Items.Clear();
            this.pbPhoto.Image = null;
            this.pbSignature.Image = null;
            this.gvCustomer.DataSource = null;
            this.txtColour.Visible = false;
            this.txtLoansAmount.Clear();
            this.txtLoansExpireAmount.Clear();
            this.txtNoofLoans.Clear();
            this.txtMinimumBalance.Clear();
            this.txtAvailableAmount.Clear();
            this.txtLinkBalance.Clear();
            this.txtNoofPersonSign.Clear();
            this.txtJointType.Clear();
            this.lbCheque.Items.Clear();
            this.chkPhoto.Checked = false;
            this.chkShowSignature.Checked = false;
        }

        #endregion

        #region Events
        
        private void InitializeControls()
        {
            this.txtEnquiryAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
        }

        private void TLMVEW00042_Load(object sender, EventArgs e)
        {
            //this.tsbCRUD.ButtonEnableDisabled(firstButtonEnabled, previousButtonEnabled, nextButtonEnabled, lastButtonEnabled, newButtonEnabled, editButtonEnabled, saveButtonEnabled, deleteButtonEnabled, cancelButtonEnabled, printButtonEnabled, exitButtonEnabled);
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, false, true);
            this.InitializeControls();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butEnquiry_Click(object sender, EventArgs e)
        {
            if (AccountNo.Trim() != string.Empty)
            {
                this.AccountInformation = new PFMDTO00067();
                this.AccountInformation = this.Controller.GetAccountInformation();
                if (this.AccountInformation == null)
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00046);
                    txtEnquiryAccountNo.Focus();
                }
                else
                    this.BindDataToUI();
            }
            else
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME90009);
                txtEnquiryAccountNo.Focus();
            }
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.CleaningUIControls();
            this.Controller.ClearErrors();
        }

        private void gvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                pbPhoto.Image = (IsWithPhoto) ? (AccountInformation.CustomerInfo[e.RowIndex].CustPhotos != null) ? (CXClientGlobal.GetImage(AccountInformation.CustomerInfo[e.RowIndex].CustPhotos)) : null : null;
                pbSignature.Image = (IsWithSignature) ? (AccountInformation.CustomerInfo[e.RowIndex].Signature != null) ? (CXClientGlobal.GetImage(AccountInformation.CustomerInfo[e.RowIndex].Signature)) : null : null;
            }
        }

        #endregion

    }

}


