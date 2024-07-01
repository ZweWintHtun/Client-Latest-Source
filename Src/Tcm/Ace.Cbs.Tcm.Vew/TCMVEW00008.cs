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
    public partial class TCMVEW00008 : BaseForm , ITCMVEW00008
    {
        #region Constractor
        public TCMVEW00008()
        {
            InitializeComponent();
        }
        #endregion 

        #region Properties

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

        public string ChequeBookNo
        {
            get { return this.txtChequeBookNo.Text; }
            set { this.txtChequeBookNo.Text = value; }
        }

        public string IssueDate
        {
            get { return this.txtIssueDate.Text; }
            set { this.txtIssueDate.Text = value; }
        }

        public string SourceBranch { get; set; }
       
        public string AccountNo
        {
            get { return this.mtxtAccountNo.Text.Trim(); }
            set { this.mtxtAccountNo.Text = value; }
        }

        public string StartNo
        {
            get
            {
                return this.txtStartNo.Text.Trim();

            }
            set { this.txtStartNo.Text = value; }
        }

        public string EndNo
        {
            get
            {
                return this.txtEndNo.Text.Trim();


            }
            set { this.txtEndNo.Text = value; }
        }


        #endregion

        #region "Controller"
        private ITCMCTL00008 chequeBookEditingcontroller;
        public ITCMCTL00008 Controller
        {
            set
            {
                this.chequeBookEditingcontroller = value;
                chequeBookEditingcontroller.View = this;
            }
            get
            {
                return this.chequeBookEditingcontroller;
            }

        }
        #endregion

        #region Method
        private void InitialEnableDisabledControls()
        {
            txtChequeBookNo.ReadOnly = false;
            txtChequeBookNo.Enabled = true;            
            txtIssueDate.ReadOnly  = true;
            mtxtAccountNo.ReadOnly = true;
            txtStartNo.ReadOnly = true;
            txtEndNo.ReadOnly = true;
            txtChequeBookNo.Focus();
            
           
        }

        public void InitialEnableControls()
        {
            txtChequeBookNo.ReadOnly = true;
            txtStartNo.ReadOnly = false;

        }

        public void Successful(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
            // Clear all controls
            this.Controller.ClearControls();
            this.InitialEnableDisabledControls();
          
        }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }

        #endregion

        #region Event
        private void TCMVEW00008_Load(object sender, EventArgs e)
        {
            tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);    
            InitialEnableDisabledControls();
            
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.Controller.Save();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.txtChequeBookNo.Enabled = true;
            this.Controller.ClearControls();
            InitialEnableDisabledControls();
            
        }
        
        private void txtChequeBookNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtStartNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        
        private void txtEndNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        #endregion

        private void TCMVEW00008_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

        private void TCMVEW00008_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {     
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
                e.Handled = true;
            }
        }
    }
}
