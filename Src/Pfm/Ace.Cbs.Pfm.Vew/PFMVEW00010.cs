using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.PTR;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;

namespace Ace.Cbs.Pfm.Vew
{
    public partial class frmPFMVEW00010 : BaseForm, IPFMVEW00010

    {
        public frmPFMVEW00010()
        {
            InitializeComponent();
        }

        #region Controller
        private IPFMCTL00010 controller;
        public IPFMCTL00010 Controller
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

        #region "View Data Properties"

        public string AccountNo
        {
            get { return this.mtxtAccountNo.Text; }
            set { this.mtxtAccountNo.Text = value; }
        }

        public string AccountSignature { get; set; }
        public string BranchCode { get; set; }
        public string CurrencyCode { get; set; }
        public string DebitCreditStatus 
        {
            get { return this.gpInterestAmount.Text; }
            set { this.gpInterestAmount.Text = value; }
        }

        public DateTime OpenDate { get; set; }

        public DateTime CloseDate
        {
            get { return Convert.ToDateTime(txtCloseDate.Text); }
            set 
            {
                if (value == DateTime.MinValue)
                {
                    this.txtCloseDate.Text = string.Empty;
                }
                else
                {
                    this.txtCloseDate.Text = value.ToString(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.UIDateFormat)); 
                }
            }
        }

        public decimal Balance
        {
            get
            {
                return Convert.ToDecimal(this.txtBalance.Text);
            }
            set
            {
                this.txtBalance.Text = value.ToString(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.DecimalDisplayFormat));
            }
        }

        public decimal Charges
        {
            get
            {
                return Convert.ToDecimal(this.txtCharges.Text);
            }
            set
            {
                this.txtCharges.Text = value.ToString(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.DecimalDisplayFormat));
            }
        }

        public Dictionary<string, string> Customers { get; set; }  

        public decimal BeforeTax
        {
            get
            {
                return Convert.ToDecimal(this.txtBeforeTax.Text);
            }
            set
            {
                this.txtBeforeTax.Text = value.ToString(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.DecimalDisplayFormat));
            }
        }

        public decimal Tax
        {
            get
            {
                return Convert.ToDecimal(this.txtTax.Text);
            }
            set
            {
                this.txtTax.Text = value.ToString(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.DecimalDisplayFormat));
            }
        }

        public decimal AfterTax
        {
            get
            {
                return Convert.ToDecimal(this.txtAfterTax.Text);
            }
            set
            {
                this.txtAfterTax.Text = value.ToString(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.DecimalDisplayFormat));
            }
        }

        public decimal TotalInterest
        {
            get
            {
                return Convert.ToDecimal(this.txtTotalInterestAmount.Text);
            }
            set
            {
                this.txtTotalInterestAmount.Text = value.ToString(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.DecimalDisplayFormat));
            }
        }

        public decimal NewBalance
        {
            get
            {
                return Convert.ToDecimal(this.txtNewBalance.Text);
            }
            set
            {
                this.txtNewBalance.Text = value.ToString(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.DecimalDisplayFormat));
            }
        }
        #endregion

        #region Public Methods
        public void BindCustomer()
        {
            this.lstCustomer.ValueMember = "Key";
            this.lstCustomer.DisplayMember = "Value";
            this.lstCustomer.Items.Clear();

            foreach (KeyValuePair<string, string> item in this.Customers)
            {
                this.lstCustomer.Items.Add(item);
            }
        }       
        #endregion

        #region Events
        private void cxcliC0012_SaveButtonClick(object sender, EventArgs e)
        {
            this.controller.SaveSavingAccountClose();
        }

        private void frmPFMVEW00010_Load(object sender, EventArgs e)
        {
            this.controller.ClearControls();
            this.EnableDisableControls();
            this.BranchCode = this.controller.GetBranchCode();
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
        }

        private void cxcliC0012_CancelButtonClick(object sender, EventArgs e)
        {
            this.controller.ClearControls();
            this.mtxtAccountNo.Focus();
            this.Controller.ClearErrors();
        }

        private void cxcliC0012_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Helper Methods
        private void EnableDisableControls()
        {
            cxcliC0012.ButtonEnableDisabled(false, false, true, false, true, false, true);
        }
        #endregion

        private void frmPFMVEW00010_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }
    }
}
