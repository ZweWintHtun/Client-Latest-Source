using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Tcm.Dmd;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00015 : BaseDockingForm , ILOMVEW00015
    {
        #region Constructor
        public LOMVEW00015()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        private ILOMCTL00015 controller;
        public ILOMCTL00015 Controller
        {
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
            get
            {
                return this.controller;
            }
        }

        public string LoanNo
        {
            get { return txtLoanNo.Text.ToString(); }
            set { txtLoanNo.Text = value; }
        }
        public string AccountNo
        {
            get { return this.mtxtAccountNo.Text.ToString(); }
            set { this.mtxtAccountNo.Text = value; }
        }
        public string AccountType
        {
            get { return this.txtAccountType.Text.ToString(); }
            set { this.txtAccountType.Text = value; }
        }
        public string MakingDate
        {
            get { return this.txtMakingDate.Text.ToString(); }
            set { this.txtMakingDate.Text = value; }
        }
       
        #endregion

        #region Method
        public void InitializeControls()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            this.txtLoanNo.Text = string.Empty;
            this.mtxtAccountNo.Text = string.Empty;
            this.txtAccountType.Text = string.Empty;
            this.txtMakingDate.Text = string.Empty;
            this.lblTodayDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.lblUserName.Text = CurrentUserEntity.CurrentUserName;
            this.txtLoanNo.Focus();
            this.lblNPLReleaseVoucher.Visible = false;
            this.gvNPLReleaseVoucher.Visible = false;
            //this.Size = new System.Drawing.Size(608, 182);
        }
        public void BindGridView(IList<TCMDTO00003> GridDataList)
        {
            this.gvNPLReleaseVoucher.AutoGenerateColumns = false;
            this.gvNPLReleaseVoucher.DataSource = null;
            if (GridDataList != null)
            {
                if (GridDataList.Count > 0)
                {
                    this.gvNPLReleaseVoucher.DataSource = GridDataList;
                    this.lblNPLReleaseVoucher.Visible = true;
                    this.gvNPLReleaseVoucher.Visible = true;
                    //this.Size = new System.Drawing.Size(608, 396);
                }
            }
        }

        #endregion

        #region Events
        private void LOMVEW00015_Load(object sender, EventArgs e)
        {
            this.InitializeControls();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.controller.ClearErrors();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.controller.Save();
            this.InitializeControls();
        }

        private void txtLoanNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }
        #endregion

        private void LOMVEW00015_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
                //this.tsbCRUD.butSave.TabIndex = 0;    
                e.Handled = true;
            }
        }
    }
}
