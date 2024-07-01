//----------------------------------------------------------------------
// <copyright file="frmCXCLE00016.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Su Su Wai</CreatedUser>
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
using System.Windows.Forms;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Dmd;
namespace Ace.Cbs.Cx.Cle
{
    /// <summary>
    /// Manager Approve Form Commom Module
    /// </summary>
    public partial class frmCXCLE00016 : BaseForm, ICXCLE00016
    {
        #region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
        public frmCXCLE00016()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Manager Approve Form For Drawing Remittance
        /// </summary>
        /// <param name="testKey"></param>
        /// <param name="remittanceType"></param>
        /// this.View.ParentFormId, rdData.TestKey, CXDMD00006.Drawing, this.view.CurrentFormPermissionEntity
        public frmCXCLE00016(string parentFormId, decimal validTestKey, CXDMD00006 remittanceType, CXDMD00010 currentFormPermissionEntity)
        {
            if (remittanceType.Equals(CXDMD00006.Drawing))
            {
                InitializeComponent();
                this.ValidTestKey = validTestKey;
                this.RemittanceType = remittanceType;
                this.ParentFormId = parentFormId;
                this.CurrentFormPermissionEntity = currentFormPermissionEntity;
                this.IsVisible = true;
                this.EnableTestKey = true;
            }
            else
                throw new Exception("Invalid parameter for Drawing Remittance");
        }
        /// <summary>
        /// Manager Approve Form For Other
        /// </summary>
        /// <param name="parentFormId"></param>
        /// <param name="validTestKey"></param>
        /// <param name="remittanceType"></param>
        /// <param name="currentFormPermissionEntity"></param>     

        public frmCXCLE00016(string parentFormId, CXDMD00006 remittanceType, CXDMD00010 currentFormPermissionEntity)
        {
            if (remittanceType.Equals(CXDMD00006.Other))
            {
                InitializeComponent();
                this.RemittanceType = remittanceType;
                this.ParentFormId = parentFormId;
                this.CurrentFormPermissionEntity = currentFormPermissionEntity;
            }
            else
                throw new Exception("Invalid parameter for Drawing Remittance");
        }

        public frmCXCLE00016(string parentFormId, CXDMD00006 remittanceType, CXDMD00010 currentFormPermissionEntity, bool isVisible)
        {
            if (remittanceType.Equals(CXDMD00006.Other))
            {
                InitializeComponent();
                this.RemittanceType = remittanceType;
                this.ParentFormId = parentFormId;
                this.CurrentFormPermissionEntity = currentFormPermissionEntity;
                this.IsVisible = IsVisible;
            }
            else
                throw new Exception("Invalid parameter");
        }
        /// <summary>
        /// Manager Approve Form For Encash Remittance
        /// </summary>
        /// <param name="testKey"></param>
        /// <param name="remittanceType"></param>
        /// <param name="encashDate"></param>
        /// <param name="encashAmount"></param>
        public frmCXCLE00016(string parentFormId, string testKey, CXDMD00006 remittanceType, string branchkey, DateTime encashDate, decimal encashAmount, CXDMD00010 currentFormPermissionEntity)
        {
            if (remittanceType.Equals(CXDMD00006.Encash))
            {
                InitializeComponent();
                this.TestKey = testKey;
                this.RemittanceType = remittanceType;
                this.EncashDate = encashDate;
                this.EncashAmount = encashAmount;
                this.BranchKey = branchkey;
                this.ParentFormId = parentFormId;
                this.CurrentFormPermissionEntity = currentFormPermissionEntity;
            }
            else
                throw new Exception("Invalid parameter for Encash Remittance");
        }

        public frmCXCLE00016(string parentFormId, string testKey, CXDMD00006 remittanceType, string branchkey, DateTime encashDate, decimal encashAmount, CXDMD00010 currentFormPermissionEntity, bool enableTestkey)
        {
            if (remittanceType.Equals(CXDMD00006.Encash))
            {
                InitializeComponent();
                this.TestKey = testKey;
                this.RemittanceType = remittanceType;
                this.EncashDate = encashDate;
                this.EncashAmount = encashAmount;
                this.BranchKey = branchkey;
                this.ParentFormId = parentFormId;
                this.CurrentFormPermissionEntity = currentFormPermissionEntity;
                this.EnableTestKey = enableTestkey;
                this.IsVisible = true;  //bug no(182 _ KSWin)
            }
            else
                throw new Exception("Invalid parameter for Encash Remittance");
        }
        #endregion

        #region View Data Properties
        public bool IsVisible { get; set; }
        public CXDMD00006 RemittanceType { get; set; }
        public decimal ValidTestKey { get; set; }
        public string BranchKey { get; set; }
        public decimal EncashAmount { get; set; }
        public DateTime EncashDate { get; set; }
        private string ParentFormId { get; set; }
        public CXDMD00010 CurrentFormPermissionEntity { get; set; }
        public bool EnableTestKey { get; set; }

        /// <summary>
        /// RememberPassword Checkbox
        /// </summary>
        public bool ChkRememberPassword
        {
            get { return chkRememberPassword.Checked; }
            set { this.chkRememberPassword.Checked = value; }
        }
        /// <summary>
        /// UserName Textbox
        /// </summary>
        public string UserName
        {
            get { return this.txtUserName.Text.Trim(); }
            set { this.txtUserName.Text = value; }
        }
        /// <summary>
        /// Password Textbox
        /// </summary>
        public string Password
        {
            get { return this.txtPassword.Text; }
            set { this.txtPassword.Text = value; }
        }
        /// <summary>
        /// TestKey Textbox
        /// </summary>
        public string TestKey
        {
            get { return this.txtTestKey.Text.Trim(); }
            set { this.txtTestKey.Text = value; }
        }
        /// <summary>
        /// ComfirmPassword Textbox
        /// </summary>
        public string ConfirmPassword
        {
            get { return this.txtConfirmPassword.Text; }
            set { this.txtConfirmPassword.Text = value; }
        }
        public string ProgramId
        {
            get { return this.ProgramPath; }
        }
        private bool hasTestKey = true;
        public bool HasTestKey
        {
            get { return this.hasTestKey; }
            set { this.hasTestKey = value; }

        }
        #endregion

        #region Presentor Controller

        /// <summary>
        /// Controller
        /// </summary>
        private ICXCTR00016 controller;
        public ICXCTR00016 Controller
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

        #region Event
        private void frmCXCLE00016_Load(object sender, EventArgs e)
        {
            if (this.CurrentFormPermissionEntity.IsRememberPassword)
            {
                this.ChkRememberPassword = true;
                this.Password = this.CurrentFormPermissionEntity.ValidPassword;
                this.ConfirmPassword = this.CurrentFormPermissionEntity.ValidPassword;
                this.UserName = this.CurrentFormPermissionEntity.UserName;
            }
            this.CurrentFormPermissionEntity.IsValidFormPermission = false;
            if (this.RemittanceType.Equals(CXDMD00006.Other))
            {
                this.txtTestKey.Enabled = false;
                this.HasTestKey = false;
            }

            if (!this.EnableTestKey)
            {
                this.txtTestKey.Enabled = false;
            }
            else
            {
                this.txtTestKey.Enabled = true;
            }

            if (!this.IsVisible)
            {
                this.txtTestKey.Visible = false;
                this.lblTestkey.Visible = false;
            }
            else
            {
                this.txtTestKey.Visible = true;
                this.lblTestkey.Visible = true;
            }
        }
        /// <summary>
        /// Before Form Closed, check permission is already valid or not.
        /// If not valid, overwirte the earlier valid entity with current invalid entity.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCXCLE00016_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!this.CurrentFormPermissionEntity.IsValidFormPermission)
            {
                //overwirte the earlier valid entity with current invalid entity.
                CXUIScreenTransit.SetData(this.ParentFormId, null);
                this.DialogResult = DialogResult.Abort;
            }
        }
        private void butApprove_Click(object sender, EventArgs e)
        {
            this.Controller.GetManagerApprove();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.txtTestKey.Focus();
            this.Controller.ClearControls();
            this.Controller.ClearErrors();
        }
        /// <summary>
        /// Clear earlier remember password, if user change the password.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.CurrentFormPermissionEntity.IsRememberPassword)
            {
                this.ResetRememberPassword(0, string.Empty, string.Empty, false);
            }
        }
        /// <summary>
        /// Clear earlier remember password, if user change the confrimPassword.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtConfirmPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.CurrentFormPermissionEntity.IsRememberPassword)
            {
                this.ResetRememberPassword(0, string.Empty, string.Empty, false);
            }
        }
        /// <summary>
        /// Clear earlier remember userId, if user change the userId.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.CurrentFormPermissionEntity.IsRememberPassword)
            {
                if (e.KeyChar.Equals(Keys.Space) && this.CurrentFormPermissionEntity.UserName.Equals(this.UserName))
                {
                    return;
                }
                else
                {
                    this.ResetRememberPassword(0, string.Empty, string.Empty, false);
                }
            }
        }
        #region KeyDown Event
        private void txtTestKey_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode.Equals(Keys.Enter))
            //{
            //    SendKeys.Send("{Tab}");
            //}         

        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode.Equals(Keys.Enter))
            //{
            //    SendKeys.Send("{Tab}");
            //}
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode.Equals(Keys.Enter))
            //{
            //    SendKeys.Send("{Tab}");
            //}
        }

        private void txtComfirmPassword_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode.Equals(Keys.Enter))
            //{
            //    this.butApprove_Click(sender, e);
            //}

        }
        #endregion

        #endregion

        #region Method
        public void Successful(int validPassword)
        {
            if (this.ChkRememberPassword)
                this.ResetRememberPassword(validPassword, this.Password, this.UserName, true);
            else
                this.ResetRememberPassword(validPassword, string.Empty, string.Empty, false);

            this.CurrentFormPermissionEntity.IsValidFormPermission = true;
            CXUIScreenTransit.SetData(this.ParentFormId, this.CurrentFormPermissionEntity);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        public void Failure(string message)
        {
            this.CurrentFormPermissionEntity.IsValidFormPermission = false;
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.Controller.ClearControls();
            this.Controller.ClearErrors();
        }
        public void ResetRememberPassword(int userid, string password, string userName, bool isRememberPassword)
        {
            this.CurrentFormPermissionEntity.UserId = userid;
            this.CurrentFormPermissionEntity.ValidPassword = password;
            this.CurrentFormPermissionEntity.IsRememberPassword = isRememberPassword;
            this.CurrentFormPermissionEntity.UserName = userName;
        }
        #endregion

        //Added by ASDA ----------------
        private void frmCXCLE00016_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }
        //end_-------------------------
    }
}
