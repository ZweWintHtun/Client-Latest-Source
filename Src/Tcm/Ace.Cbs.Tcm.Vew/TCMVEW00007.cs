using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Dto;

namespace Ace.Cbs.Tcm.Vew
{
    public partial class TCMVEW00007 : BaseForm ,ITCMVEW00007
    {
        #region Constructor

        public TCMVEW00007()
        {
            InitializeComponent();           
        }

        #endregion

        #region Properties

        public string EntryNo
        {
            get { return this.txtEntryNo.Text; }
            set { this.txtEntryNo.Text = value; }
        }

        public string AccountNo
        {
            get { return this.mtxtAccountNo.Text; }
            set { this.mtxtAccountNo.Text = value; }
        }

        public string Description
        {
            get { return this.txtDescription.Text; }
            set { this.txtDescription.Text = value; }
        }

        public string Currency
        {
            get { return this.txtCurrency.Text; }
            set { this.txtCurrency.Text = value; }
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

        #endregion

        #region Controller

        private ITCMCTL00007 controller;
        public ITCMCTL00007 Controller
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

        #region Methods

        private void EnableDisableControls()
        {
            tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            this.txtEntryNo.Enabled = true;
            this.mtxtAccountNo.Enabled = false;
            this.txtDescription.Enabled = false;
            this.txtCurrency.Enabled = false;
            this.txtAmount.Enabled = false;            
        }

        private void InitializeControls()
        {
            this.txtEntryNo.Text = string.Empty;
            this.mtxtAccountNo.Text = string.Empty;
            this.txtDescription.Text = string.Empty;
            this.txtCurrency.Text = string.Empty;
            this.txtAmount.Text = "0.00";
        }       

        public void Successful(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }

        public void FillData(PFMDTO00054 tlfInfo)  // to bind data in UIcontrols
        {
            this.EntryNo = tlfInfo.Eno;
            this.AccountNo = tlfInfo.AccountNo;
            this.Description = tlfInfo.Narration;
            this.Currency = tlfInfo.SourceCurrency;
            this.Amount = tlfInfo.Amount;
        }

        #endregion

        #region Events     

        private void TCMVEW00007_Load(object sender, EventArgs e)
        {   
            this.EnableDisableControls();
            this.InitializeControls();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.controller.ClearErrors();
            this.InitializeControls();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.Controller.Save();
        }

        private void txtEntryNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
       
       #endregion                  
    }
}
