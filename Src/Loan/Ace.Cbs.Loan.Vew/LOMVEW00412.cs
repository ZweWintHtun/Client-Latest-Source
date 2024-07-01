using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.CXClient;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00412 : BaseForm, ILOMVEW00412
    {
        #region Constructor
        public LOMVEW00412()
        {
            InitializeComponent();
        }
        #endregion

        #region Controller
        private ILOMCTL00412 controller;
        public ILOMCTL00412 Controller
        {
            get { return this.controller; }
            set { this.controller = value; this.controller.View = this; }
        }
        #endregion

        #region Properties
        public string SourceBranch
        {
            get
            {
                if (this.cboBranch.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cboBranch.SelectedValue.ToString();
                }

            }
            set { this.cboBranch.SelectedValue = value.ToString(); }
        }

        public string Currency
        {
            get
            {
                if (this.cboCurrency.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cboCurrency.SelectedValue.ToString();
                }
            }
            set { this.cboCurrency.SelectedValue = value; }
        }

        //Commented by HWKO (22-Nov-2017)
        //public string BLNo
        //{
        //    get
        //    {
        //        if (this.cboBLNo.SelectedValue == null)
        //        {
        //            return null;
        //        }
        //        else
        //        {
        //            return this.cboBLNo.SelectedValue.ToString();
        //        }
        //    }
        //    set { this.cboBLNo.SelectedValue = value; }
        //}

        //Added by HWKO (22-Nov-2017)
        public string AcctNo
        {
            get { return this.mtxtAccountNo.Text.Trim(); }
            set { this.mtxtAccountNo.Text = value.Trim(); }
        }

        public string BudgetYear
        {
            get { return this.lblBudgetYear.Text; }
            set { this.lblBudgetYear.Text = value.ToString(); }
        }

        #endregion

        #region Method

        #region Initialize
        private void InitailizeControls()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);

            this.BudgetYear = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode);
            this.BindCurrency();
            this.BindSourceBranch();

            //Added by HWKO (22-Nov-2017)
            this.mtxtAccountNo.Text = string.Empty;
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            
            //this.cboBLNo.Enabled = false;
            //this.BindBusinessLoansNo();
            this.cboCurrency.Focus();
            // this.controller.ClearErrors();
            //cboBranch.SelectedIndex = -1;
            cboCurrency.SelectedIndex = 0;
            //cboBLNo.SelectedIndex = -1;
            this.SourceBranch = CurrentUserEntity.BranchCode;
            if (!CurrentUserEntity.IsHOUser)
            {
                this.cboBranch.Enabled = false;
            }
            else
            {
                this.cboBranch.Enabled = true;
            }
        }
        #endregion

        #region BindComboBox

        private void BindCurrency()
        {
            IList<CurrencyDTO> CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = CurrencyList;
            cboCurrency.SelectedIndex = 0;
        }

        private void BindSourceBranch()
        {
            IList<BranchDTO> BranchList = CXCLE00002.Instance.GetListObject<BranchDTO>("Branch.Client.SelectNotOtherBank", new object[] { false });
            cboBranch.ValueMember = "BranchCode";
            cboBranch.DisplayMember = "BranchCode";
            cboBranch.DataSource = BranchList;
            cboBranch.SelectedIndex = 0;
        }
        //private void BindBusinessLoansNo()
        //{
        //    IList<TLMDTO00018> lnoList = this.Controller.GetBusinessLNo(this.SourceBranch);

        //    cboBLNo.ValueMember = "Lno";
        //    cboBLNo.DisplayMember = "Lno";
        //    cboBLNo.DataSource = lnoList;
        //    cboBLNo.Refresh();
        //    cboBLNo.SelectedIndex =-1;
           
        //}
        #endregion        

        #endregion

        #region Event
        private void LOMVEW00412_Load(object sender, EventArgs e)
        {
            this.InitailizeControls();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitailizeControls();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            if (this.cboCurrency.SelectedValue == string.Empty)
            {
                CXUIMessageUtilities.ShowMessageByCode("MV00020");
                this.cboCurrency.Focus();
                return;
            }
            if (this.cboBranch.SelectedValue == string.Empty)
            {
                CXUIMessageUtilities.ShowMessageByCode("MV00070");
                this.cboBranch.Focus();
                return;
            }
            if (String.IsNullOrEmpty(this.AcctNo))
            {
                CXUIMessageUtilities.ShowMessageByCode("MV00046");
                this.mtxtAccountNo.Focus();
                return;
            }
            //if (this.cboBLNo.SelectedValue == string.Empty)
            //{
            //    CXUIMessageUtilities.ShowMessageByCode("MV90181");///Invalid Business Loans No!
            //    this.cboBranch.Focus();
            //    return;
            //}
            this.Controller.Print();
        }

        private void mtxtAccountNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void mtxtAccountNo_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.AcctNo))
            {
                if (!this.controller.CheckBusinessLoansAccountNo(this.AcctNo))
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00046);
                    this.mtxtAccountNo.Focus();
                }
            }
        }
        //private void cboBranch_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (this.cboBranch.SelectedIndex != -1)
        //    {
        //        //this.cboBLNo.Enabled = true;
        //        //BindBusinessLoansNo();
        //    }
        //}
        #endregion  
    }
}
