using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.PTR;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient.Controls;

namespace Ace.Cbs.Pfm.Vew
{
    /// <summary>
    /// Print Cheque
    /// </summary>
    public partial class frmPFMVEW00015 : BaseForm ,IPFMVEW00015     
    { 
        #region"Constructor"
        public frmPFMVEW00015()
        {
            InitializeComponent();
        }
        #endregion

        #region"Properties"

        public IList<PFMDTO00014> PrintCheques { get; set; }

        public string AccountNo
        {
            get { return this.mtxtAccountNo.Text.Replace("-", "").Trim(); }
            set { this.mtxtAccountNo.Text = value; }
        }

        public string ChequeBookNo
        {
            get { return this.txtChequeBookNo.Text; }
            set { this.txtChequeBookNo.Text = value; }
        }

        public string StartSerialNo
        {
            get
            {
                return this.txtStartChequeNo.Text;
              
            }

            set { this.txtStartChequeNo.Text = value; }
        }

        public string EndSerialNo
        {
            get
            {
                return this.txtEndChequeNo.Text;
            }
   
            set { this.txtEndChequeNo.Text = value; }
        }

        public string SourceBranchCode
        {

            get { return this.txtBranchNo.Text; }
            set { this.txtBranchNo.Text = value; }
        }
        #endregion

        #region"Entity"
        public PFMDTO00006 chequeEntity;
        public PFMDTO00006 ChequeEntity
        {
            get
            {
                if (this.chequeEntity == null) this.chequeEntity = new PFMDTO00006();
                this.chequeEntity.AccountNo = this.AccountNo;
                this.chequeEntity.StartNo = this.StartSerialNo;
                this.chequeEntity.EndNo = this.EndSerialNo;
                this.chequeEntity.ChequeBookNo = this.ChequeBookNo;
                this.chequeEntity.SourceBranchCode = this.SourceBranchCode;
                return this.chequeEntity;
     
            }
            set
            {
                this.chequeEntity=value;
            }
        
        
        }
        #endregion

        #region"Controller"
        private IPFMCTL00015 printChequeController;
        public IPFMCTL00015 PrintChequeController
        {
            set
            {
                this.printChequeController = value;
                printChequeController.PrintChequeView = this;
            }
            get
            {
                return this.printChequeController;
            }

        }
        #endregion

        #region"Public Methods"

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.mtxtAccountNo.Enabled = true;
            this.txtChequeBookNo.Enabled = true;
            this.mtxtAccountNo.Focus();
            this.InitializeControls();
        }   

        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        #endregion

        #region "Private Methods"

        private void InitializeControls()
        {
            this.mtxtAccountNo.Clear();
            this.txtChequeBookNo.Clear();
            this.txtBranchNo.Clear();
            //this.txtBranchNo.Text = this.printChequeController.GetCurrentBranch();
            this.txtStartChequeNo.Clear();
            this.txtEndChequeNo.Clear();
            //this.txtBranchNo.ReadOnly = true;
        }

        #endregion

        #region"Event"

        private void tlspCommon_PrintButtonClick(object sender, EventArgs e)
        {
            //this.printChequeController.Print(); 
            this.printChequeController.PrintWithRDLC();
        }

        private void frmPFMVEW00015_Load(object sender, EventArgs e)
        {
            tlspCommon.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.InitializeControls();
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
        }

        private void tlspCommon_CancelButtonClick(object sender, EventArgs e)
        {
            this.mtxtAccountNo.Enabled = true;
            this.txtChequeBookNo.Enabled = true;
            this.mtxtAccountNo.Focus();
            this.InitializeControls();
            this.PrintChequeController.ClearErrors();
        }

        private void tlspCommon_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtStartChequeNo_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.StartSerialNo))
            {
                this.StartSerialNo = CXCLE00007.GetFormatString(Convert.ToInt32(this.StartSerialNo), CXCOM00009.ChequeNoDisplayFormat);
            }
        }
        private void txtChequeBookNo_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.ChequeBookNo))
            {
                this.ChequeBookNo = CXCLE00007.GetFormatString(Convert.ToInt32(this.ChequeBookNo), CXCOM00009.ChequeBookNoDisplayFormat);
                this.mtxtAccountNo.Enabled = false;
                this.txtChequeBookNo.Enabled = false;
                this.txtStartChequeNo.Text = this.StartSerialNo;
                this.txtEndChequeNo.Text = this.EndSerialNo;
                this.txtBranchNo.Focus();
            }

        }


        private void txtEndChequeNo_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.EndSerialNo))
            {
                this.EndSerialNo = CXCLE00007.GetFormatString(Convert.ToInt32(this.EndSerialNo), CXCOM00009.ChequeNoDisplayFormat);
            }

            if (!string.IsNullOrEmpty(this.StartSerialNo) && !string.IsNullOrEmpty(this.EndSerialNo))

                if (Convert.ToInt32(this.StartSerialNo) > (Convert.ToInt32(this.EndSerialNo)))
                {
                    this.Failure("MV00101");
                    txtStartChequeNo.Focus();

                }
        }

        #endregion     

        private void txtChequeBookNo_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtBranchNo_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtStartChequeNo_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtEndChequeNo_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }   

       
    }
}
