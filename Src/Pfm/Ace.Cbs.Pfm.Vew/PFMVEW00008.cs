using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.PTR;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;

namespace Ace.Cbs.Pfm.Vew
{
    public partial class frmPFMVEW00008 : BaseDockingForm, IPFMVEW00008
    {
        #region Constructor

        public frmPFMVEW00008()
        {
            InitializeComponent();
        }

        public bool flag;

        public frmPFMVEW00008(int menuIdForPermission, string branchName)
        {
            InitializeComponent();

            this.branchCode = branchName;

            CurrentUserEntity.CurrentMenuId = menuIdForPermission;
        } 

        #endregion

        #region Private Variables

        private string branchCode = string.Empty;

        private string currentUserNo = CurrentUserEntity.CurrentUserID.ToString();

        private string channelName = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
        //private string channelName = SpringApplicationContext.Instance.Resolve<string>(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel));        

        public DateTime TPDate
        {
            get { return this.dtpDate.Value; }
            set { this.dtpDate.Value = value; }
        }

        #endregion

        #region Properties

        public string AccountNo
        {
            set { this.mtxtAccountNo.Text = value; }
            get { return this.mtxtAccountNo.Text; }
        }

        public string Reference
        {
            get { return this.txtReference.Text; }
            set { this.txtReference.Text = value; }
        }

        public decimal DAmt
        {
            set
            {
                this.mtxtWithdrawl.Text = Convert.ToString(value);
            }
            get
            {
                decimal result = 0;
                decimal.TryParse(this.mtxtWithdrawl.Text, out result);
                return Math.Round(result,2);           
            }
        }

        public decimal CAmt
        {
            set
            {           
                this.mtxtDeposit.Text = Convert.ToString(value);                         
            }
            get
            {
                decimal result = 0;
                decimal.TryParse(this.mtxtDeposit.Text, out result);
                return Math.Round(result,2);
            }
        }

        public decimal Balance
        {
            set { this.mtxtBalance.Text = Convert.ToString(value); }
            get
            {
                decimal result = 0;
                decimal.TryParse(this.mtxtBalance.Text, out result);
                return Math.Round(result,2);
            }
        }

        public string AccountSign { get; set; }

        #endregion

        #region Controller

        private IPFMCTL00008 printRecordController;
        public IPFMCTL00008 PrintRecordController
        {
            get { return this.printRecordController; }
            set
            {
                this.printRecordController = value;
                this.printRecordController.PrintRecordView = this;

            }
        }

        #endregion

        #region Entities

        private PFMDTO00045 printRecordEntity;
        public PFMDTO00045 PrintRecordEntity
        {
            get
            {
                if(printRecordEntity == null)
                    this.printRecordEntity = new PFMDTO00045();
                this.printRecordEntity.AcctNo = this.AccountNo;
                this.printRecordEntity.DateTime = this.TPDate;
                this.printRecordEntity.DAmt = this.DAmt;
                this.printRecordEntity.CAmt = this.CAmt;
                this.printRecordEntity.Balance = this.Balance;
                this.printRecordEntity.UserNo = currentUserNo;
                this.printRecordEntity.SourceBr = branchCode;
                this.printRecordEntity.Active = true;
                if (this.Balance < this.CAmt)
                {
                    this.printRecordEntity.WithdrawlStatus = false;
                }
                else
                {
                    this.printRecordEntity.WithdrawlStatus = true;
                }
                return this.printRecordEntity;
            }
            set
            {
                this.PrintRecordEntity = value;
            }
        }

        private PFMDTO00043 prnFileDTO;
        public PFMDTO00043 PrnFileDTO// Total fields 11 nos ( not to save , just to carry PFMVEW00009 )
        {
            get
            {
                if(prnFileDTO == null)
                    this.prnFileDTO = new PFMDTO00043();
                this.prnFileDTO.AccountNo = this.AccountNo;
                this.prnFileDTO.DATE_TIME = this.TPDate;
                this.prnFileDTO.UserNo = this.currentUserNo;
                this.prnFileDTO.Credit = this.CAmt;
                this.prnFileDTO.Debit = this.DAmt;
                this.prnFileDTO.Balance = this.Balance;
                this.prnFileDTO.Channel = this.channelName;
                this.prnFileDTO.SourceBranchCode = this.branchCode;
                this.prnFileDTO.Reference = this.Reference;
                return this.prnFileDTO;
            }
            set
            {
                this.PrnFileDTO = value;
            }
        }

        #endregion

        #region Public Methods

        public void ShowErrorMessage(string message, bool isAmountError)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);

            if (isAmountError)
            {
                this.mtxtWithdrawl.Focus();
            }
            else
            {
                this.mtxtAccountNo.Focus();
            }
        } 

        #endregion

        #region Private Methods

        private void EnableDisibleControls()
        {
                        //ButtonEnableDisabled( new, edit, save, delete, cancel, print, exit);
            this.tlspCommon.ButtonEnableDisabled(false, false, false, false, true, true, true);
        }

        private void InitializeControls()
        {
            this.dtpDate.Value = DateTime.Now;
            this.mtxtAccountNo.Clear();
            this.txtReference.Clear();
            this.mtxtWithdrawl.ResetText();
            this.mtxtDeposit.ResetText();
            this.mtxtBalance.ResetText();
        }

        #endregion

        #region Event

        private void frmPFMVEW00008_Load(object sender, EventArgs e)
        {
            this.dtpDate.Value = DateTime.Now;

            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);

            EnableDisibleControls();
            lbltodayDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void tlspCommon_PrintButtonClick(object sender, EventArgs e)
        {
            if (this.printRecordController.Save(this.PrintRecordEntity) == false)
            {
                return;
            }

            this.Visible = false;

            if (CXUIScreenTransit.Transit("frmPFMVEW00009", true, new object[] { this.MenuIdForPermission, PrnFileDTO, AccountSign,true }) == DialogResult.OK)
            {
                this.Visible = true;

                this.mtxtAccountNo.Focus();
            }
        }

        private void tlspCommon_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.PrintRecordController.ClearErrors();
        }

        private void tlspCommon_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mtxtWithdrawl_Validated(object sender, EventArgs e)
        {
            if (this.DAmt > 0)
            {
                this.mtxtDeposit.Enabled = false;

            }
            else
            {
                this.mtxtDeposit.Enabled = true;
            }
        }

        private void mtxtDeposit_Validated(object sender, EventArgs e)
        {
            if (this.CAmt > 0 )
            {
                this.mtxtWithdrawl.Enabled = false;
            }
            else
            {
                this.mtxtWithdrawl.Enabled = true;
            }
        }
        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }
        
        #endregion

        private void txtReference_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

     
    }
}



