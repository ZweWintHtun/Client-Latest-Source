using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Mnm.Ctr.PTR;
using Ace.Windows.Core.Utt;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00165 : BaseForm,IMNMVEW00165
    {
        #region Constructor

        public MNMVEW00165()
        {
            InitializeComponent();
        }

        #endregion

        #region Controller

        private IMNMCTL00165 controller;
        public IMNMCTL00165 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }
        #endregion

        #region Properties

        public string BranchCode
        {
            get
            {
                if (this.cboBranch.Text == null)
                {
                    return null;
                }
                else
                {
                    return this.cboBranch.Text.ToString();
                }
            }
            set
            {
                this.cboBranch.Text = value;
                this.cboBranch.SelectedValue = value;
            }
        }

        public string CurrencyNo
        {
            get
            {
                if (this.cboCurrency.Text == string.Empty)
                    return string.Empty;
                else
                    return this.cboCurrency.Text;
            }
            set
            {
                this.cboCurrency.Text = value;
            }
        }

        public DateTime SelectedDate
        {
            get { return this.dtpEnterDate.Value; }
            set { this.dtpEnterDate.Text = value.ToString(); }
        }

        public string Title
        {
            get { return this.Text; }
            set { this.Text = value; }
        }

        #endregion

        #region Methods

        private void BindCurrency()
        {
            IList<CurrencyDTO> currencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = currencyList;
            cboCurrency.SelectedIndex = 0;
        }

        private void BindBranchCode()
        {
            IList<BranchDTO> branches = CXCLE00001.Instance.SelectAllBranch();
            cboBranch.ValueMember = "BranchCode";
            cboBranch.DisplayMember = "BranchCode";
            cboBranch.DataSource = branches;
            cboBranch.SelectedIndex = 0;
        }  

        public void InitializeControls()
        {
            //Enable Disable Menu Controls
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.BindCurrency();
            if (CurrentUserEntity.IsHOUser)
            {                
                this.BindBranchCode();
                this.BranchCode = CurrentUserEntity.BranchCode;
            }
            this.SelectedDate = DateTime.Now;
            this.dtpEnterDate.Focus();
        }

        #endregion

        private void MNMVEW00165_Load(object sender, EventArgs e)
        {
            if (this.FormName.Contains("Group"))
            {
                this.Title = "Trial Balance Group Listing By Date";
                this.Text = "Trial Balance Group Listing By Date";
            }
            else
            {
                this.Title = "Trial Balance Detail Listing By Date";
                this.Text = "Trial Balance Detail Listing By Date";
            }
            InitializeControls();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.Controller.ClearCustomErrorMessage();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            if (this.Controller.Validate_Form())
            {
                this.Controller.Print();
            }

        }
    }
}
