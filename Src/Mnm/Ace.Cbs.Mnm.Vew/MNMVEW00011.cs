//----------------------------------------------------------------------
// <copyright file="MNMVEW00011.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>10/23/2013</CreatedDate>
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
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Utt;
using System.Windows.Forms;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00011 : BaseForm, IMNMVEW00011
    {

        #region "constructor"

        public MNMVEW00011()
        {
            InitializeComponent();
        }

        #endregion "Constructor"

        #region "Controller"

        private IMNMCTL00011 controller;
        public IMNMCTL00011 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }

        #endregion

        #region "Controls Input Output"

        public string TransactionStatus
        {
            get { return this.FormName; }
        }

        public string PayInSlipNo
        {
            get { return this.txtPaySlipNo.Text; }
            set { this.txtPaySlipNo.Text = value; }
        }

        public string AccountNo
        {
            get { return this.mtxtAccountNo.Text.Replace("-", "").Trim(); }
            set { this.mtxtAccountNo.Text = value; }
        }

        public string Currency
        {
            get { return this.txtCurrency.Text; }
            set { this.txtCurrency.Text = value; }
        }

        public string Note
        {
            get { return this.txtNote.Text; }
            set { this.txtNote.Text = value; }
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

        public string OtherBankCheque
        {
            get { return this.mtxtCheque.Text; }
            set { this.mtxtCheque.Text = value; }
        }

        public string ChequeNo
        {
            get { return this.mtxtOtherBankCheque.Text; }
            set { this.mtxtOtherBankCheque.Text = value; }
        }

        public string PaidBank
        {
            get { return this.txtPaidBank.Text; }
            set { this.txtPaidBank.Text = value; }
        }

        public string ReceiptNo
        {
            get { return this.txtReceiptNo.Text; }
            set { this.txtReceiptNo.Text = value; }
        }

        public string Status { get; set; }

        public ListBox CustomerList
        {
            get { return this.lsbCustomerNames; }
            set { this.lsbCustomerNames = value; }
        }

        public string OCheque { get; set; }
        public string StatusCheque { get; set; }
        #endregion "Controls Input Output"

        #region "Events"

        public void MNMVEW00011_Load(object sender, EventArgs e)
        {
            #region Old_Logic
            /*
            //ButtonEnableDisabled(newButtonEnabled, editButtonEnabled, saveButtonEnabled, deleteButtonEnabled,cancelButtonEnabled, printButtonEnabled, exitButtonEnabled);
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            //Show Form Text
            this.Text = this.GetFormNameString();

            //Show Controls
            this.ShowControl(false);

            //Set Focus at Pay In Slip No
            this.SetFocus(false);
            */
            #endregion

            DateTime systemDate = this.Controller.GetSystemDate(CurrentUserEntity.BranchCode);
            DateTime lastSettlementDate = this.controller.GetLastSettlementDate(CurrentUserEntity.BranchCode);
            this.lblTransactionDate.Text = systemDate.ToString("dd-MM-yyyy");

            if (systemDate.ToString("dd-MM-yyyy") != lastSettlementDate.ToString("dd-MM-yyyy")) //Show Form
            {
                this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
                this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
                this.Text = this.GetFormNameString();
                this.ShowControl(false);
                this.SetFocus(false);
            }
            else //Don't show form after cut off
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI50013);//You have no permission.\n"Back Date EOD Process" needs to be completed!
                this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
                lblMonths.Text = "";
                this.DisableControls("DeliverEdit.AllDisable");
            }

         }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.ClearControl();
            this.txtPaySlipNo.Enabled = true;
            this.txtPaySlipNo.Focus();
            this.controller.ClearCustomErrorMessage();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            //Saving Logic
            if (this.FormName == "Deliver Edit")
            {
                if (CXUIMessageUtilities.ShowMessageByCode("MC00004") == DialogResult.Yes)  // confirm to save
                    this.Controller.Delete();
            }
            else
                this.Controller.Save();
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)//No Need Delete Event for Deliver Reverse(Confirm by KSW)
        {
            // Are you sure want to delete?
            if (CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC90001) == DialogResult.Yes)
            {
                this.Controller.Delete();
            }
        }

        private void MNMVEW00011_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }
        #endregion "Events"

        #region "Methods"

        //public void BindBCode()
        //{
        //    this.cboPaidBank.ValueMember = "BCode";
        //    this.cboPaidBank.DisplayMember = "BCode";
        //    IList<TLMDTO00040> BCodeDTO = this.Controller.GetBCode();
        //    this.cboPaidBank.DataSource = BCodeDTO;
        //    this.cboPaidBank.SelectedIndex = -1;
        //}

        public void SetFocus()
        {
            this.mtxtOtherBankCheque.Focus();
        }

        /*---When printing Saving Passbook,need Menu Permission Id ---*/
        public int GetMenuIDPermission()
        {
            int menuIdPermission = this.MenuIdForPermission;
            return menuIdPermission;
        }


        private string GetFormNameString()
        {
            switch (this.FormName)
            {
                case "Deliver Edit":
                    this.Status = "Update";
                    this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
                    return "Delivered Cheque Editting ";

                case "Deliver Reverse":
                    this.Status = "Save";
                    this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
                    return "Clearing Posted Delivered Cheque Reversal ";

                case "Receipt Reverse":
                    this.Status = "Save";
                    this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
                    return "Clearing Receipt Reversal ";

                default:
                    return string.Empty;
            }
        }

        private void ShowControl(bool flag)
        {
            if (this.FormName == "Deliver Reverse")
            {
                this.lblReceivedNo.Visible = flag;
                this.txtReceiptNo.Visible = flag;
                this.grpMonths.Visible = flag;
                this.lblMonths.Visible = flag;
                this.lsbCustomerNames.Items.Clear();
                this.lblCheque.Visible = flag;
                this.mtxtOtherBankCheque.Visible = flag;
                this.StatusCheque = "N";
                this.txtNote.Visible = false;
            }
            else if (this.FormName == "Receipt Reverse")
            {
                this.lblReceivedNo.Visible = flag;
                this.txtReceiptNo.Visible = flag;
                this.lblPaidBank.Visible = true;
                this.txtPaidBank.Visible = true;
                this.grpMonths.Visible = flag;
                this.lblMonths.Visible = flag;
                this.lsbCustomerNames.Items.Clear();
                this.lblOtherBankCheque.Visible = flag;
                this.mtxtCheque.Visible = flag;
                this.mtxtOtherBankCheque.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ChequeNoMaximumValue);
                this.txtNote.Visible = false;
                this.Size = new System.Drawing.Size(514, 269); 
            }
            else
            {
                this.lblMonths.Text = " 0 Month.";
                this.lsbCustomerNames.Items.Clear();
                this.lblReceivedNo.Visible = flag;
                this.txtReceiptNo.Visible = flag;
                this.lblCheque.Visible = flag;
                this.mtxtOtherBankCheque.Visible = flag;
                this.StatusCheque = "N";
                this.txtNote.Visible = false;
                this.Size = new System.Drawing.Size(514, 269); 
            }

            this.txtCurrency.Enabled = flag;                          
            this.mtxtCheque.Enabled = flag;
            this.txtPaidBank.Enabled = flag;
            this.txtAmount.Enabled = flag; 
            this.txtReceiptNo.Enabled = flag;
        }

        public void ClearControl()
        {
            this.txtPaySlipNo.Text = string.Empty;
            this.txtCurrency.Text = string.Empty;
            this.txtAmount.Text = "0.00";
            this.txtPaidBank.Text = string.Empty;
            this.mtxtAccountNo.Text = string.Empty;
            this.txtReceiptNo.Text = string.Empty;
            this.mtxtCheque.Text = string.Empty;
            this.mtxtOtherBankCheque.Text = string.Empty;
            this.lblMonths.Text = "0 Month";
            this.lsbCustomerNames.Items.Clear();
            this.txtPaySlipNo.Enabled = true;
            this.txtAmount.Enabled = false;
            this.mtxtAccountNo.Enabled = true;
            this.txtPaidBank.Enabled = false;
            this.txtReceiptNo.Enabled = false;
            this.txtNote.Text = string.Empty;
            this.txtNote.Visible = false;
            this.SetFocus(false);
        }

        public void SetEnable(bool flag)
        {
           this.txtAmount.Enabled = flag;
           this.txtNote.Visible = flag;
        }

        public void SetEnable(bool flag1, bool flag2) 
        {
           this.txtAmount.Enabled = flag1;
           this.txtNote.Visible = flag2;
        }
        public void SetDisable(bool flag, bool flag2)
        {           
                this.txtCurrency.Enabled = flag;
                this.txtPaySlipNo.Enabled = flag;
                this.mtxtCheque.Enabled = flag2;
                this.txtPaidBank.Enabled = flag;             
                if(flag2) this.txtAmount.Enabled = flag;

                if (this.FormName.Contains("Edit"))
                {                    
                    this.txtPaidBank.Enabled = flag2;
                    this.txtAmount.Enabled = flag2;
                }
                else if (this.FormName == "Receipt Reverse")
                {
                    this.mtxtOtherBankCheque.Enabled = flag2;
                }
                //this.View.SetDisable(false, true);
        }
        public void SetFocus(bool isAccountno)
        {
            if (isAccountno)
            {
               this.mtxtAccountNo.Focus();
               this.mtxtAccountNo.Enabled = isAccountno;
            }
            else this.txtPaySlipNo.Focus();
        }

        public void SetFocusAmount()
        {
            this.txtAmount.Focus();
        }

        public void Successful(string message, string accountCode)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message, new object[] { accountCode });
        }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }

        #endregion "Methods"

        

    }
}
