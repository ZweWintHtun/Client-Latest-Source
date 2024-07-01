using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.CXClient;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Tel.Vew
{
    public partial class TLMVEW00036 : BaseForm, ITLMVEW00036
    {
        #region Constructor
        public TLMVEW00036()
        {
            InitializeComponent();

        }
        #endregion

        #region Controller
        private ITLMCTL00036 controller;
        public ITLMCTL00036 Controller
        {
            get { return this.controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }
        #endregion

        #region CONTROLS INPUT OUTPUT

        public bool IsSettlementDate
        {
            get { return rdoSettlementDate.Checked ? true : false; }
        }
        public bool IsByAccountNo
        {
            get { return rdoAccountNO.Checked ? true : false; }
        }

        public string AccountSign { get; set; }
        public DateTime RequireDate
        {
            get { return this.dtpRequiredDate.Value; }
        }

        public bool IsTransactionDate
        {
            get
            {
                if (rdoTransactionDate.Checked == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public string BranchCode { get; set; }
        //{
        //    get
        //    {
        //        if (this.cboBranchNo.SelectedValue == null)
        //        {
        //            return string.Empty;
        //        }
        //        else
        //        {
        //            return this.cboBranchNo.SelectedValue.ToString();
        //        }
        //    }
        //    set { this.cboBranchNo.SelectedValue = value; }
        //}
        public string CurrencyCode
        {
            get
            {
                if (this.cboCurrency.SelectedValue == null)
                {
                    return string.Empty;
                }
                else
                {
                    return this.cboCurrency.SelectedValue.ToString();
                }
            }
            set { this.cboCurrency.SelectedValue = value; }
        }
        public bool IsReversal
        {
            get { return chkReversal.Checked; }
        }
        public bool IsSaving { get; set; }


        public bool IsSourceCurrency { get { return rdoSourceCurrency.Checked; } }
        public bool SortByTime { get; set; }

        #endregion

        #region   METHODS
        public void InitializeControls()
        {
            //Enable Disable Menu Controls
            tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);

            //if (chkBranch.Checked)
            //{
            //    this.DisableControls("DayBook.Disable");
            //}
            if (rdoHomeCurrency.Checked)
            { this.DisableControls("DayBook.Currency.Disable"); }
            this.BindCurrency();
            this.BindBranchCode();
            this.BranchCode = CurrentUserEntity.BranchCode;
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BindCurrency()
        {
            IList<CurrencyDTO> currencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            //if (rdoSourceCurrency.Checked)
            //{
            //    var cur = (from value in currencyList
            //               where value.Cur != "KYT"
            //               select value).ToList();
            //    cboCurrency.DataSource = cur;
            //}
            //else
            //{
            cboCurrency.DataSource = currencyList;

            //}

            cboCurrency.SelectedIndex = 0;
        }

        private void BindBranchCode()
        {
            //this.controller.GetCurrentBranch();
            IList<BranchDTO> branches = CXCLE00002.Instance.GetListObject<BranchDTO>("BranchCode.Client.SelectOtherBank", new object[] { false });
            cboBranchNo.ColumnNames = "BranchCode,BranchDescription";
            cboBranchNo.ValueMember = "BranchCode";
            cboBranchNo.DisplayMember = "BranchCode";
            cboBranchNo.DataSource = branches;
            cboBranchNo.SelectedIndex = 0;

        }

        public void GetHomeCurrency()
        {
            if (rdoHomeCurrency.Checked)
            {
                this.CurrencyCode = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.HomeCurrencyCode);
            }
            else
            {
                //if (this.cboCurrency.SelectedText.ToString() == null || this.cboCurrency.SelectedText.ToString() == string.Empty)
                //{
                //    CXUIMessageUtilities.ShowMessageByCode("MV00020"); //Invalid Currency Code.
                //    this.cboCurrency.Focus();
                //    return;
                //}
                //else 
                this.CurrencyCode = cboCurrency.SelectedValue.ToString();
            }
        }
        #endregion

        #region EVENTS
        private void TLMVEW00036_Load(object sender, EventArgs e)
        {
            this.gbBranch.Visible = false;
            this.InitializeControls();
            this.SortByTime = true;

        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.rdoBusinessLoan.Checked = true;
            this.dtpRequiredDate.Value = DateTime.Now;
            this.rdoTransactionDate.Checked = true;
            //  this.cboBranchNo.SelectedIndex = -1;
            this.cboCurrency.SelectedIndex = 0;
            this.rdoTime.Checked = true;
            //this.chkBranch.Checked = false;
            this.InitializeControls();
            this.controller.ClearCustomErrorMessage();
        }

        //private void chkBranch_CheckedChanged(object sender, EventArgs e)
        //{
        //    this.DisableControls("IBLTransaction.DisableControls");
        //    this.BranchCode = string.Empty;


        //    if (chkBranch.Checked == false)
        //    {
        //        this.EnableControls("IBLTransaction.EnableControls");
        //    }

        //    this.controller.ClearErrors();
        //}

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            if (!this.controller.CheckDate())
            {
                dtpRequiredDate.Focus();
                return;
            }

            if (rdoSourceCurrency.Checked == true && cboCurrency.SelectedIndex == -1)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00020");
                this.cboCurrency.Focus();
                return;
            }

            this.GetHomeCurrency();
            this.GetACSign();
            //Editted by HWKO (14-Aug-2017)
            if (rdoBusinessLoan.Checked)
            {
                this.controller.CurrentDayBook();
            }
            if (this.rdoHirePurchase.Checked)
            {
                this.controller.CurrentDayBook();

            }
            if (this.rdoPersonalLoan.Checked)
            {
                this.controller.CurrentDayBook();

            }
            if (this.rdoDealer.Checked)
            {
                this.controller.CurrentDayBook();

            }
            //End Region

            #region Old Code
            //if (rdoCurrent.Checked)
            //{
            //    this.controller.CurrentDayBook();
            //}

            //if (rdoSaving.Checked)
            //{
            //    this.controller.SavingDayBook();
            //}

            //if (rdoFixed.Checked)
            //{
            //    this.controller.FixedDayBook();
            //}
            #endregion

            if (rdoDomestic.Checked)
            {
                this.controller.DomesticDayBook();
            }
        }

        private void rdoSourceCurrency_CheckedChanged(object sender, EventArgs e)
        {
            this.EnableControls("DayBook.EnableControls");
            IList<CurrencyDTO> currencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = currencyList;
            //if (rdoSourceCurrency.Checked)
            //{
            //    var cur = (from value in currencyList
            //               where value.Cur != "KYT"
            //               select value).ToList();
            //    cboCurrency.DataSource = cur;
            //}
            //else
            //{
            //    cboCurrency.DataSource = currencyList;

            //}
            cboCurrency.SelectedIndex = 0;

            if (rdoSourceCurrency.Checked == false)
            {
                this.DisableControls("DayBook.DisableControls");
            }

        }
        #endregion

        #region Old Code
        //private void rdoSaving_CheckedChanged(object sender, EventArgs e)
        //{
        //    //this.HideControls("DayBook.SavingandFixed.HideControls");
        //    this.IsSaving = true;
        //    if (rdoSaving.Checked == false)
        //    {
        //        this.IsSaving = false;
        //        this.ShowControls("DayBook.SavingandFixed.ShowControls"); 
        //    }
        //}

        //private void rdoFixed_CheckedChanged(object sender, EventArgs e)
        //{
        //    //this.rdoSettlementDate.Visible = false;
        //    //this.HideControls("DayBook.SavingandFixed.HideControls");
        //    if (rdoFixed.Checked == false)
        //    {
        //        this.ShowControls("DayBook.SavingandFixed.ShowControls");
        //        //this.rdoSettlementDate.Visible = true;               
        //    }
        //}
        #endregion

        public void GetACSign()
        {
            #region Old Code
            //if (rdoCurrent.Checked)
            //{
            //    this.AccountSign = "C";
            //}
            //else if (rdoSaving.Checked)
            //{
            //    this.AccountSign = "S";
            //}
            //else if (rdoFixed.Checked)
            //{
            //    this.AccountSign = "F";
            //}
            #endregion

            //Editted by HWKO (14-Aug-2017)
            if (rdoBusinessLoan.Checked)
            {
                this.AccountSign = "B";
            }
            else if (rdoHirePurchase.Checked)
            {
                this.AccountSign = "H";
            }
            else if (rdoPersonalLoan.Checked)
            {
                this.AccountSign = "P";
            }
            else if (rdoDealer.Checked)
            {
                this.AccountSign = "D";
            }
            else
            {
                this.AccountSign = null;
            }
        }

        public bool CheckSettlemetDate()
        {
            if (rdoSettlementDate.Checked)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        private void dtpRequiredDate_Validating(object sender, CancelEventArgs e)
        {
            if (!this.controller.CheckDate())
            {
                dtpRequiredDate.Focus();
            }
        }

        private void rdoHomeCurrency_CheckedChanged(object sender, EventArgs e)
        {
            this.CurrencyCode = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.HomeCurrencyCode);
        }

        private void rdoTime_CheckedChanged(object sender, EventArgs e)
        {
            this.SortByTime = true;
        }

        private void rdoAccountNO_CheckedChanged(object sender, EventArgs e)
        {
            this.SortByTime = false;
        }
    }
}
