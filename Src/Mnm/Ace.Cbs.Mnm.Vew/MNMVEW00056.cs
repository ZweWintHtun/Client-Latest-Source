using System;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Admin.DataModel;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;
using Ace.Cbs.Mnm._Excel;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00056 : BaseForm, IMNMVEW00056
    {
        #region DataProperties 
       
        public IList<BranchDTO> BranchList { get; set; }
        private IList<CounterInfoDTO> tocounterInfolist;
        public IList<CounterInfoDTO> TocounterInfolist
        {
            get
            {
                if (this.tocounterInfolist == null)
                    this.tocounterInfolist = new List<CounterInfoDTO>();

                return this.tocounterInfolist;
            }
            set
            {
                this.tocounterInfolist = value;
            }
        }
        private IList<TLMDTO00013> VaultList { get; set; }
        private IList<CurrencyDTO> CurrencyList { get; set; }

        #endregion

        #region Controller
        private IMNMCTL00056 controller;
        public IMNMCTL00056 Controller
        {
            get { return this.controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }
        #endregion

        #region UI Properties 

        private DataGridView _dgvCashControl;

        public DataGridView DgvCashControl
        {
            get { return _dgvCashControl; }
            set { _dgvCashControl = value; }
        }

        public bool IsBranch
        {
            get { return this.rdoBranch.Checked; }
            set { this.rdoBranch.Checked = value; }
        }

        public bool IsVault
        {
            get { return this.rdoVault.Checked; }
            set { this.rdoVault.Checked = value; }
        }

        public bool IsCounter
        {
            get { return this.rdoCounter.Checked; }
            set { this.rdoCounter.Checked = value; }
        }

        public string DataComboBoxString
        {
            get {
                if (this.cboCounterNo.SelectedValue != null)
                    return this.cboCounterNo.SelectedValue.ToString();
                else
                    return string.Empty;
            }
            set { this.cboCounterNo.SelectedValue = value; }
        }

        public string Currency
        {
            get
            {
                if (this.cboCurrency.Text == null)
                {
                    return null;
                }
                else
                {
                    return this.cboCurrency.Text.ToString();
                }
            }
            set
            {
                this.cboCurrency.Text = value;
                this.cboCurrency.SelectedValue = value;
            }
        }

        public DateTime EndDateTime
        {
            get { return this.dtpEnterDate.Value; }
            set { this.dtpEnterDate.Text = value.ToString(); }
        }

        public bool IsReversal
        {
            get { return this.chkBeforeEditing.Checked; }
            set { this.chkBeforeEditing.Checked = value; }
        }

        public bool IsItem
        {
            get { return this.chkItem.Checked; }
            set { this.chkItem.Checked = value; }
        }
        public bool IsPayment
        {
            get { return this.rdoPayment.Checked; }
            set { this.rdoPayment.Checked = value; }
        }

        public bool IsReceipt
        {
            get { return this.rdoReceipt.Checked; }
            set { this.rdoReceipt.Checked = value; }
        }

        public bool IsAll
        {
            get { return this.rdoAll.Checked; }
            set { this.rdoAll.Checked = value; }
        }

        public bool IsNonIssue
        {
            get { return this.chkNonIssueableNote.Checked; }
            set { this.chkNonIssueableNote.Checked = value; }
        }
        public string TotalVault;
        #endregion

        #region Methods

        private void BindCurrency()
        {
            this.CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = this.CurrencyList;
            cboCurrency.SelectedIndex = 0;
        }

        private void BindCounterComboBox()
        {
            //this.TocounterInfolist = CXCLE00002.Instance.GetListObject<TLMDTO00002>("CounterInfo.Client.SelectAllCounterNo", new object[] { CurrentUserEntity.BranchCode });
            this.TocounterInfolist = this.Controller.GetAllCounterListBySourceBranchCode();
            cboCounterNo.DataSource = this.TocounterInfolist;
            cboCounterNo.ValueMember = "CounterNo";
            cboCounterNo.DisplayMember = "CounterNo";
            cboCounterNo.SelectedIndex = -1;
           
        }

        private void BindVaultComboBox()
        {
            if (this.VaultList == null)
                this.VaultList = CXCLE00002.Instance.GetListObject<TLMDTO00013>("CashSetup.Client.SelectCashCode");
            cboCounterNo.DataSource = this.VaultList;
            cboCounterNo.ValueMember = "CashCode";
            cboCounterNo.DisplayMember = "Description";
            cboCounterNo.SelectedIndex = -1;
        }

        private void BindBranchComboBox()
        {
            if (this.BranchList == null)
                this.BranchList = CXCLE00002.Instance.GetListObject<BranchDTO>("Branch.Client.SelectNotOtherBank", new object[] { false });
            cboCounterNo.DataSource = this.BranchList;
            cboCounterNo.ValueMember = "BranchCode";
            cboCounterNo.DisplayMember = "BranchCode";
            cboCounterNo.SelectedIndex = 0;
        }

        #endregion

        #region Events
        public MNMVEW00056()
        {
            InitializeComponent();
        }

        private void MNMVEW00056_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.BindBranchComboBox();
            this.BindCurrency();
            this.grpCounterItem.Visible = false;
            this.IsItem = false;
            this.Size = new System.Drawing.Size(500, 216);
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.IsBranch)
            {
                this.lblNo.Text = "Branch No :";
                this.IsItem = false;
                this.BindBranchComboBox();
                this.DataComboBoxString = CurrentUserEntity.BranchCode;
                if (!CurrentUserEntity.IsHOUser)
                {
                    this.cboCounterNo.Enabled = false;
                }
                else
                {
                    this.cboCounterNo.Enabled = true;
                }
                this.grpCounterItem.Visible = false;
                this.Size = new System.Drawing.Size(500, 216);
            }
            else if (this.IsVault)
            {
                this.cboCounterNo.CausesValidation = false;
                this.lblNo.Text = "Vault Type :";
                this.IsItem = false;
                this.BindVaultComboBox();
                this.grpCounterItem.Visible = false;
                this.Size = new System.Drawing.Size(500, 216);
                this.cboCounterNo.Enabled = true;
            }
            else
            {
                this.cboCounterNo.CausesValidation = false;
                this.lblNo.Text = "Counter No :";
                this.IsItem = false;
                this.BindCounterComboBox();
                this.grpCounterItem.Visible = true;
                this.rdoPayment.Checked = true;
                this.rdoPayment.Enabled = false;
                this.rdoReceipt.Enabled = false;
                this.rdoAll.Enabled = false;
                this.Size = new System.Drawing.Size(500, 295);
                this.cboCounterNo.Enabled = true;
            }
        }

        private void chkItem_CheckedChanged(object sender, EventArgs e)
        {
            if (IsItem)
            {
                this.cboCounterNo.Text = string.Empty;
                this.cboCounterNo.Enabled = false;
                this.rdoPayment.Checked = true;
                this.rdoPayment.Enabled = true;
                this.rdoReceipt.Enabled = true;
                this.rdoAll.Enabled = true;
            }
            else
            {
                this.cboCounterNo.Enabled = true;
                this.rdoPayment.Enabled = false;
                this.rdoReceipt.Enabled = false;
                this.rdoAll.Enabled = false;
            }
        }


        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            //if (rdoVault.Checked == true && cboCounterNo.Text == "T")
                this.Close();
        }
        private void cboCounterNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cboCounterNo.CausesValidation = true;
            if (this.IsVault && this.DataComboBoxString.Equals("V00000"))
            {
                this.chkNonIssueableNote.Visible = true;
                }
            else
                this.chkNonIssueableNote.Visible = false;
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            try
            {
                this.TotalVault = "False";
                if (rdoVault.Checked == true && cboCounterNo.Text == "Total Vault Book")
                {
                    this.TotalVault = "True";
                }
                else
                {
                    this.TotalVault = "False";
                }
                dgvCashControl.DataSource = this.Controller.PrintExel_New(TotalVault);
                if (dgvCashControl.DataSource != null)
                {
                    bool isReceive = Controller.isReceive == 1 ? true : false;
                    if (IsVault)
                    {
                        isReceive = false;
                    }
                    //bool isVault = Controller.isv == 1 ? true : false;
                    string reportTitle = this.Controller.SendReportTitle();
                    BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                    CashControlReport_Excel frm = new CashControlReport_Excel(dgvCashControl);
                    frm.CashControlReport_ExcelGrid(IsVault, isReceive, IsCounter, Branch.BranchDescription, Branch.Address, Branch.Phone, Branch.Fax, reportTitle, DateTime.Now, dgvCashControl);
                }
            }
            catch(Exception ex)
            {

            }
        }

        #endregion

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.Controller.ClearUIControl();
            this.dtpEnterDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            this.rdoBranch.Checked = true;
            this.cboCounterNo.Enabled = true;
            this.grpCounterItem.Visible = false;
            this.chkBeforeEditing.Checked = false;
            
        }
    }
}
