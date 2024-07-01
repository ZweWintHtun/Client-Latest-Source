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
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Dmd.DTO;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00428 : BaseDockingForm, ILOMVEW00428
    {
#region Properties
        public string Name
        {
            get { return this.txtName.Text.ToString(); }
            set { this.txtName.Text = value; }
        }
        public string NRC
        {
            get { return this.txtNRC.Text.ToString(); }
            set { this.txtNRC.Text = value; }
        }
        public string FName
        {
            get { return this.txtFatherName.Text.ToString(); }
            set { this.txtFatherName.Text = value; }
        }
        public DateTime DOB
        {
            get { return this.dtpDOB.Value; }
            set { this.dtpDOB.Text = value.ToString(); }
        }
        public string CName
        {
            get { return this.txtCName.Text.ToString(); }
            set { this.txtCName.Text = value; }
        }
        public string Address
        {
            get { return this.txtAddress.Text.ToString(); }
            set { this.txtAddress.Text = value; }
        }
#endregion

        #region Constructor
        public LOMVEW00428()
        {
            InitializeComponent();
        }
        private ILOMCTL00428 controller;
        public ILOMCTL00428 Controller
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
        #endregion

        #region Events
        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            if (txtNRC.Text.Trim() != "" && txtNRC.Text.Trim() != string.Empty)
            {
                string result = this.Controller.SaveBlackLists_ExternalCust(CurrentUserEntity.CurrentUserID, CurrentUserEntity.BranchCode);
                if (result == "0000")
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90001);//Saving Successful.
                    InitializeControls();
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90215);//This customer is already in Black List.
                    InitializeControls();
                }
            }
            else
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00004);//Invalid NRC No.
                txtNRC.Text = "";
                txtNRC.Focus();
            }
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LOMVEW00428_Load(object sender, EventArgs e)
        {
            try
            {
                LOMDTO00427 userLists = this.Controller.SelectUserMakerCheckerApproveByUserId();
                if (userLists != null)
                {
                    if (userLists.IsEntry == true)
                    {
                        tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
                        InitializeControls();
                        EnableDisibleControls(true);
                        txtName.Focus();

                        //IsValidUser = "1";
                        //this.Show();
                        //this.Visible = true;
                        //mtxtAcctNo.Enabled = true;
                    }
                    else
                    {
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI40002);//You do not have permission for this function.
                        EnableDisibleControls(false);
                        tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
                        InitializeControls();

                        //IsValidUser = "0";
                        //mtxtAcctNo.Enabled = false;
                        //this.Close();
                        //return;
                    }
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI40002);//You do not have permission for this function.
                    EnableDisibleControls(false);
                    tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
                    InitializeControls();

                    //IsValidUser = "0";
                    //mtxtAcctNo.Enabled = false;
                    //this.Close();
                    //return;
                }
            }
            catch (Exception ex)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI40002);//You do not have permission for this function.
                EnableDisibleControls(false);
                tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);

                //this.Hide();
                //this.Visible = false;
                //mtxtAcctNo.Enabled = false;
                //this.Close();
                //IsValidUser = "0";
                //this.Close();
                //return;
            }
        }
        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtNRC_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }
        private void txtFatherName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtCName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }
        #endregion

        #region Methods
        public void EnableDisibleControls(bool status)
        {
            this.txtName.Enabled = status;
            this.txtNRC.Enabled = status;
            this.txtFatherName.Enabled = status;
            this.dtpDOB.Enabled = status;
            this.txtCName.Enabled = status;
            this.txtAddress.Enabled = status;

            //if(status == tru)

        }
        public void InitializeControls()
        {
            this.txtName.Text = "";
            this.txtNRC.Text = "";
            this.txtFatherName.Text = "";
            this.txtCName.Text = "";
            this.dtpDOB.Text = "";
            this.txtAddress.Text = "";
            this.txtName.Focus();
        }
        #endregion        

    }
}
