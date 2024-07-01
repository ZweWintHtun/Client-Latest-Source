using System;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.PTR;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Pfm.Vew
{
    //Cheque -> Cheque Issue (Book)
    public partial class frmPFMVEW00013 : BaseForm, IPFMVEW00013
    {
        #region Constractor

        public frmPFMVEW00013()
        {
            InitializeComponent();
        }

        public frmPFMVEW00013(bool isMainMenu, string parentFormId)
        {
            InitializeComponent();
            this.IsMainMenu = isMainMenu;
            this.ParentFormId = parentFormId;
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

        public string ChequeBookNo
        {
            get { return this.txtChequeBookNo.Text; }
            set { this.txtChequeBookNo.Text = value; }
        }
        #endregion

        #region Presentor Controller
        private IPFMCTL00013 chequeController;
        public IPFMCTL00013 ChequeController
        {
            set
            {
                this.chequeController = value;
                this.chequeController.ChequeView = this;
            }
            get
            {
                return this.chequeController;
            }
        }
        #endregion

        #region Entity

        private PFMDTO00006 chequeEntity;
        public PFMDTO00006 ChequeEntity
        {
            get
            {
                if (this.chequeEntity == null) this.chequeEntity = new PFMDTO00006();
                this.chequeEntity.AccountNo = this.AccountNo.Replace("-", "");
                this.chequeEntity.StartNo = this.StartNo;
                this.chequeEntity.EndNo = this.EndNo;
                this.chequeEntity.ChequeBookNo = this.ChequeBookNo;
                return this.chequeEntity;
            }

            set { this.chequeEntity = value; }
        }

        #endregion

        #region Method

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.mtxtAccountNo.Focus();
            this.InitializedControl();
        }

        public void Failure(string message)
        {
            //edit by hmw (To check different branch validation)            
           
            if (message == "MV00091" || message == "MV00058" || message == "MV00044")
            {
                this.mtxtAccountNo.Focus();
            }
            else if (message == "MV00025" || message == "MV00084") 
            {
                this.txtChequeBookNo.Focus();
            }
            else if (message == "MV00065") //Invalid Start Cheque No.
            {
                this.txtStartNo.Focus();
            }

             if(message=="MV00091")
             {
                 CXUIMessageUtilities.ShowMessageByCode(message, new object[] { CurrentUserEntity.BranchCode });
             }
             else
             {CXUIMessageUtilities.ShowMessageByCode(message);}
        }

        #endregion

        #region Private Methods

        private void InitializedControl()
        {
            this.chequeController.ClearControls();
        }

        #endregion

        #region Event
        private void txtChequeBookNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtStartNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void tlspCommon_SaveButtonClick(object sender, EventArgs e)
        {
            if (this.IsMainMenu)
            {
                //if(!string.IsNullOrEmpty(this.ChequeBookNo))
                this.chequeController.Save(this.ChequeEntity);
            }
            else
            {
                if (chequeController.ValidateForm(this.ChequeEntity))
                {
                    CXUIScreenTransit.SetData(this.ParentFormId, this.ChequeEntity);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void frmPFMVEW00013_Load(object sender, EventArgs e)
        {
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);

            this.tlspCommon.ButtonEnableDisabled(false, false, true, false, true, false, true);

            if (this.IsMainMenu == false)
            {
                this.HideControls("ChequeEntry.VisibleAccountNo");
            }
        }

        private void tlspCommon_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializedControl();
            this.mtxtAccountNo.Focus();
            this.ChequeController.ClearErrors();
        }

        private void tlspCommon_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPFMVEW00013_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

        private void frmPFMVEW00013_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
                e.Handled = true;
            }
        }                

        //private void txtChequeBookNo_Validated(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(this.ChequeBookNo.Trim()))
        //        this.ChequeBookNo = CXCLE00007.GetFormatString(Convert.ToInt32(this.ChequeBookNo), CXCOM00009.ChequeBookNoDisplayFormat);

        //}

        #endregion

        

    }
}
