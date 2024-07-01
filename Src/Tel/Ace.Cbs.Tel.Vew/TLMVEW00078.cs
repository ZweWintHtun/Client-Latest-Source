using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Utt;


namespace Ace.Cbs.Tel.Vew
{
    /*Cash Payment Denomination Entry*/
    public partial class TLMVEW00078 : BaseForm , ITLMVEW00078
    {
        public TLMVEW00078()
        {
            InitializeComponent();
        }

        #region "Controller"
        private ITLMCTL00078 controller;
        public ITLMCTL00078 Controller //Cash Payment Denomination Entry
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

        #region "Control Inputs Outputs"

        public string status { get; set; }
        public PFMDTO00054 tlDTO { get; set; }
        public string Eno
        {
            get { return this.txtEntryNo.Text.Trim(); }
            set { this.txtEntryNo.Text = value; }
        }
        public string AccountNo
        {
            get { return this.mtxtAccountNo.Text.Trim(); }
            set { this.mtxtAccountNo.Text = value; }
        }
        public string Description
        {
            get { return this.txtDescription.Text.Trim(); }
            set { this.txtDescription.Text = value; }
        }
        public string PoNo
        {
            get { return this.txtPONo.Text.Trim(); }
            set { this.txtPONo.Text = value; }
        }
        public string Currency
        {
            get { return this.txtCurrency.Text.Trim(); }
            set { this.txtCurrency.Text = value; }
        }
        public decimal Amount
        {
            get { return Convert.ToDecimal(this.txtAmount.Value); }
            //set { this.txtAmount.Text = Convert.ToString(value); } 
            set { this.txtAmount.Text = Convert.ToDouble(value).ToString("N2"); } 
        }
        //public DateTime _Date
        //{
        //    //get { return Convert.ToDateTime(this.txtDateTime.Value); }
        //    set { this.txtDateTime.Text = Convert.ToString(System.DateTime.Today.Date); }
        //}

        #endregion

        #region "Methods"

        public void InitailizeControls()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            this.txtEntryNo.Focus();
        }
        public void Successful(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message, new object[] { string.Empty });
            this.InitailizeControls();
            this.txtEntryNo.Clear();
            // this.txtEntryNo.Focus();
            this.mtxtAccountNo.Clear();
            this.txtDescription.Clear();
            this.txtPONo.Clear();
            this.txtCurrency.Clear();
            this.txtAmount.Text = "0.00";
            this.txtEntryNo.Focus();
        }
        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
            this.InitailizeControls();
        }

        public void EnableDisableControls(bool status)
        {
            this.txtEntryNo.Enabled = status;
            this.mtxtAccountNo.Enabled = status;
            this.txtDescription.Enabled = status;
            this.txtPONo.Enabled = status;
            this.txtCurrency.Enabled = status;
            this.txtAmount.Enabled = status;
            this.txtEntryNo.Focus();
        }
        #endregion

        #region "Events"
        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.controller.Save();
        }
        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.controller.ClearErrors();
            this.Close();
        }
        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.txtEntryNo.CausesValidation = false;
            this.EnableDisableControls(true);
            this.controller.ClearErrors();
            this.InitailizeControls();
            this.txtEntryNo.Clear();
            this.txtEntryNo.Focus();
            this.mtxtAccountNo.Clear();
            this.txtDescription.Clear();
            this.txtPONo.Clear();
            this.txtCurrency.Clear();
            this.txtAmount.Text = "0.00";
        }

        private void TLMVEW00078_Load(object sender, EventArgs e)
        {
            #region Old_Logic
            //this.InitailizeControls();
            //this.lblDateTime.Text = System.DateTime.Today.ToShortDateString();
            //this.txtEntryNo.Focus();
            #endregion

            #region Seperating_EOD_Logic (Added By YMP at 30-07-2019, Modified by HMW at 26-08-2019)
            DateTime systemDate = this.controller.GetSystemDate(CurrentUserEntity.BranchCode);
            DateTime lastSettlementDate = this.controller.GetLastSettlementDate(CurrentUserEntity.BranchCode);
            this.lblDateTime.Text = systemDate.ToString("dd-MM-yyyy");

            if (systemDate.ToString("dd-MM-yyyy") != lastSettlementDate.ToString("dd-MM-yyyy")) //Show Form
            {
                this.InitailizeControls();                
                this.txtEntryNo.Focus();           
            }
            else //Don't show form after cut off
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI50013);//You have no permission.\n"Back Date EOD Process" needs to be completed!
                this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);               
                this.DisableControls("CashPaymentDenomination.AllDisable");
            }
            #endregion
        }

        //private void TLMVEW00078_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        this.SelectNextControl(this.ActiveControl, true, true, true, true);
        //    }
        //}


        private void TLMVEW00078_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

        #endregion

        private void txtEntryNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

    }
}
