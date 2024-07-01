using System;
using System.Drawing;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.PTR;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;

namespace Ace.Cbs.Pfm.Vew
{
    public partial class frmPFMVEW00007 : BaseForm, IPFMVEW00007
    {
        #region Constructor

        public frmPFMVEW00007()
        {
            InitializeComponent();
        } 

        #endregion

        #region Private Variables

        private bool isNew;

        private Point OldConfirmPasswordLabelLocation;

        private Point OldConfirmPasswordTextBoxLocation;

        #endregion

        #region View Data Properties

        public string UserName
        {
            get { return this.txtAuthorizeName.Text.Trim(); }
            set { this.txtAuthorizeName.Text = value; }  
        }

        public string OldPassword
        {
            get { return this.txtOldPassword.Text.Trim(); }
            set { this.txtOldPassword.Text = value; }
        }

        public string NewPassword
        {
            get { return this.txtNewPassword.Text.Trim(); }
            set { this.txtNewPassword.Text = value; }
        }

        public string ConfirmPassword
        {
            get { return this.txtConfirmPassword.Text.Trim(); }
            set { this.txtConfirmPassword.Text = value; }
        }

        private string branchCode;
        public string BranchCode
        {
            get { return branchCode; }
        }

        public bool IsCheckOrEdit
        {
            get
            {
                return this.txtAuthorizeName.Enabled;
            } 
        }

        #endregion

        #region Entity

        private PFMDTO00044 printUserEntity;
        public PFMDTO00044 PrintUserEntity
        {
            get 
            {
                if (this.printUserEntity == null)
                    this.printUserEntity = new PFMDTO00044();

                this.printUserEntity.SourceBranchCode = branchCode;
                if (isNew)
                {
                    this.printUserEntity.CheckStatus = "None";
                }
                else
                {
                    this.printUserEntity.CheckStatus = "Check";
                }
                this.printUserEntity.UserName = this.UserName;
                this.printUserEntity.OldPassword = this.OldPassword;
                this.printUserEntity.Password = this.NewPassword;             
                this.printUserEntity.ConfirmPassword = this.ConfirmPassword;
                
                return this.printUserEntity;
            }
            set 
            {
                this.printUserEntity = value;
            }
        }

        #endregion

        #region Controller

        private IPFMCTL00007 printUserController;
        public IPFMCTL00007 PrintUserController
        {
            get
            {
                return this.printUserController;
            }
            set
            {
                this.printUserController = value;
                this.printUserController.PrintUserView = this;
            }
        }

        #endregion

        #region Public Methods

        public void DisableControlsForNewUser()
        {
            this.DisableControls("PrintUserEntry.DisableForNew");
        }
         
        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);

            CurrentUserEntity.IsIgnoreDataValidating = true;

            this.txtAuthorizeName.Enabled = false;

            if (isNew == true)
            {
                RefreshControl(this.lblConfirmPassword.Location, this.txtConfirmPassword.Location, OldConfirmPasswordLabelLocation, OldConfirmPasswordTextBoxLocation);

                isNew = false;
            }

            this.printUserEntity.CheckStatus = "Check";

            RefreshVisible(true, false, false);

            tlspCommon.ButtonEnableDisabled(false, true, false, false, true, false, true);

            this.butOk.Visible = true;

            this.lblOldPassword.Text = "Password: ";

            this.InitializeControls();

            this.txtOldPassword.Focus();

            CurrentUserEntity.IsIgnoreDataValidating = false;
        }

        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        public void VisibleControlsForNewUser()
        {
            RefreshVisible(true, false, false);
            this.lblOldPassword.Text = "Password :";
            this.tlspCommon.ButtonEnableDisabled(true, false, false, false, false, false, true);
        }

        public void VisibleControlsForCurrentUser(string userName)
        {
            RefreshVisible(true, false, false);
            this.txtAuthorizeName.Text = userName;
            this.txtAuthorizeName.Enabled = false;
            this.lblOldPassword.Text = "Password :";
            this.butOk.Location = this.txtNewPassword.Location;            
            this.tlspCommon.ButtonEnableDisabled(false, true, false, false, true, false, true);
        }

        public void RebindAuthorizeUserTextBox(string userName)
        {
            this.txtAuthorizeName.Text = userName;
        }

        #endregion

        #region Private Methods

        private void InitializeControls()
        {
            if (this.txtAuthorizeName.Enabled == true)
            {
                this.txtAuthorizeName.Clear();
            }

            this.txtOldPassword.Clear();

            this.txtNewPassword.Clear();

            this.txtConfirmPassword.Clear();

            this.txtAuthorizeName.Focus();

            this.printUserController.ClearErrors();
        }

        private void RefreshControl(Point NewPasswordLabelLocation, Point NewPasswordTextBoxLocation, Point ConfirmPasswordLabelLocation, Point ConfirmPasswordTextBoxLocation)
        {
            this.lblNewPassword.Location = NewPasswordLabelLocation;
            this.txtNewPassword.Location = NewPasswordTextBoxLocation;

            this.lblConfirmPassword.Location = ConfirmPasswordLabelLocation;
            this.txtConfirmPassword.Location = ConfirmPasswordTextBoxLocation;
        }

        private void RefreshVisible(bool isPasswordVisible, bool isNewPasswordVisible, bool isConfirmPasswordVisible)
        {
            if (isPasswordVisible)
            {
                this.ShowControls(VisibleHideSettings.visibleOne.ToString());                                            
            }
            else
            {
                this.HideControls(VisibleHideSettings.hideOne.ToString());
            }

            if (isNewPasswordVisible)
            {
                this.ShowControls(VisibleHideSettings.visibleTwo.ToString());
            }
            else
            {
                this.HideControls(VisibleHideSettings.hideTwo.ToString());
            }

            if (isConfirmPasswordVisible)
            {
                this.ShowControls(VisibleHideSettings.visibleThree.ToString());
            }
            else
            {
                this.HideControls(VisibleHideSettings.hideThree.ToString());
            }
        }

        #endregion

        #region Event

        private void PFMVEW00007_Load(object sender, EventArgs e)
        {
            //Get branch code
            this.tlspCommon.ButtonEnableDisabled(true, true, true, false, true, false, true);
            this.tlspCommon.butNew.Enabled = true;
            this.tlspCommon.butNew.Visible = true;

            branchCode = CXCOM00007.Instance.BranchCode;

            this.PrintUserController.CheckUserExist(branchCode);

            this.OldConfirmPasswordLabelLocation = this.lblConfirmPassword.Location;

            this.OldConfirmPasswordTextBoxLocation = this.txtConfirmPassword.Location;

            this.Size = new System.Drawing.Size(484, 163); 
        }

        private void tlspCommon_NewButtonClick(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(484, 212);
            RefreshVisible(false, true, true);

            RefreshControl(lblOldPassword.Location, txtOldPassword.Location, lblNewPassword.Location, txtNewPassword.Location);

            this.tlspCommon.ButtonEnableDisabled(false, false, true, false, true, false, true);

            this.EnableControls("PrintUserEntry.EnableAfterNew");

            isNew = true;

            this.printUserEntity.CheckStatus = "None";

            this.txtAuthorizeName.Focus();

            this.butOk.Visible = false;
        }

        private void tlspCommon_EditButtonClick(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(484, 212);
            this.txtAuthorizeName.Enabled = true;

            RefreshVisible(true, true, true);

            this.tlspCommon.ButtonEnableDisabled(false, false, true, false, true, false, true);

            isNew = false;

            this.PrintUserEntity.CheckStatus = "EditCheck";

            this.butOk.Visible = false;

            this.lblOldPassword.Text = "Old Password :";

            this.txtAuthorizeName.Focus();      
        }

        private void tlspCommon_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();   
        }

        private void tlspCommon_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlspCommon_SaveButtonClick(object sender, EventArgs e)
        {
            if (isNew)
            {
                this.PrintUserController.SavePrintUserEntity(PrintUserEntity);   
            }
            else
            {
                this.PrintUserController.UpdatePrintUserEntity(PrintUserEntity);
            }
            this.Size = new System.Drawing.Size(484, 163); 
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            if (this.PrintUserController.IsValidPassword(branchCode,OldPassword))
            {
                CXUIScreenTransit.Transit("frmPFMVEW00008",true,new object[] { this.MenuIdForPermission, branchCode });
            }
            else
            {
                // Invalid Password.
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00043);
            }
        }
        
        #endregion

        private void frmPFMVEW00007_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

        //private void frmPFMVEW00007_Move(object sender, EventArgs e)
        //{
        //    this.CenterToParent();
        //}
    }

    class VisibleHideSettings
    {
        public const string visibleOne = "PrintUserEntry.VisibleControlsOne";
        public const string visibleTwo = "PrintUserEntry.VisibleControlsTwo";
        public const string visibleThree = "PrintUserEntry.VisibleControlsThree";
        public const string hideOne = "PrintUserEntry.HiddenControlsOne";
        public const string hideTwo = "PrintUserEntry.HiddenControlsTwo";
        public const string hideThree = "PrintUserEntry.HiddenControlsThree";
    }

}
