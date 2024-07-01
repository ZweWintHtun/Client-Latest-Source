using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.PTR;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Pfm.Vew
{
    /// <summary>
    /// Joint Form
    /// </summary>
    public partial class PFMVEW00003 : BaseDockingForm, IPFMVEW00003
    {
        public PFMVEW00003()
        {
            InitializeComponent();
        }

        #region Controls Input Output
        public PFMDTO00032 FReceipt { get; set; }
        public int BalFlag { get; set; }
        private IList<PFMDTO00001> customerDataSource;
        public IList<PFMDTO00001> CustomerDataSource
        {
            get 
            {
                if(this.customerDataSource == null)
                    this.customerDataSource = new List<PFMDTO00001>();
               //this.customerDataSource[0].Photo = CXClientGlobal.ImageToByteArray(this.Photo);
               //this.customerDataSource[0].Signature = CXClientGlobal.ImageToByteArray(this.Signature);
               return this.customerDataSource; 
            }
            set
            {
                this.customerDataSource = value;
            }
        }

        public string TransactionStatus
        {
            get { return this.FormName; }
        }

        public string AccountNo
        {
            get { return this.mtxtAccountNo.Text; }
            set { this.mtxtAccountNo.Text = value; }
        }

        public string CurrencSymbol
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

        public string CurrencyCode
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

        public int NoOfPersonSign
        {
            get
            {
                return Convert.ToInt32(this.txtNoPersonSign.Value);
            }
            set { this.txtNoPersonSign.Text = value.ToString(); }
        }

        public string ReceiptNo
        {
            get { return this.txtReceiptNo.Text; }
            set { this.txtReceiptNo.Text = value; }
        }

        public string ChequeBookNo
        {
            get { return this.txtChequeBookNo.Text; }
            set { this.txtChequeBookNo.Text = value; }
        }

        public string ChequeStartNo
        {
            get { return this.txtFromChequeNo.Text; }
            set { this.txtFromChequeNo.Text = value; }
        }

        public string ChequeEndNo
        {
            get { return this.txtToChequeNo.Text; }
            set { this.txtToChequeNo.Text = value; }
        }

        public string DebitLinkAccount
        {
            get { return this.mtxtDebitLinkAccount.Text; }
            set { this.mtxtDebitLinkAccount.Text = value; }
        }

        public decimal DebitLimit
        {
            get { return this.txtLinkLimit.Value; }
            set { this.txtLinkLimit.Text = value.ToString(); }
        }

        public string LinkAccountName
        {
            get { return this.txtName.Text; }
            set { this.txtName.Text = value; }
        }
        
        public Image Photo
        {
            get { return this.pbPhoto.Image; }
            set { this.pbPhoto.Image = value; }
        }

        public Image Signature
        {
            get { return this.pbSignature.Image; }
            set { this.pbSignature.Image = value; }
        }

        public string JoinType
        {
            get
            {
                if (this.rdoTypeA.Checked)
                {
                    return "A";
                }
                else
                {
                    return "B";
                }
            }
            set
            {
                if (value == "A")
                {
                    this.rdoTypeA.Checked = true;
                }
                else
                {
                    this.rdoTypeB.Checked = true;
                }
            }
        }
        #endregion

        #region "Controller"

        private IPFMCTL00003 controller;
        public IPFMCTL00003 Controller
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

        #region "Events"

        private void PFMVEW00003_Load(object sender, EventArgs e)
        {
            // Show / Hide Controls // Modify by HWKO (22-Jun-2017) // this.HideControls(this.TransactionStatus); <-- Old Code
            if (this.TransactionStatus.Contains("Current") || this.TransactionStatus.Contains("Saving") || this.TransactionStatus.Contains("Fixed"))
            {
                this.HideControls(this.TransactionStatus);
            }
            else if (this.TransactionStatus.Contains("Individual"))
            {
                this.HideControls("Current.Individual");
            }
            else if (this.TransactionStatus.Contains("Joint"))
            {
                this.HideControls("Current.Joint");
            }
            else if (this.TransactionStatus.Contains("Company"))
            {
                this.HideControls("Current.Company");
            }

            //Added By HWKO (22-Jun-2017) // According to sis ZMS told set the controls visible false.
            this.lblChequeBookNo.Visible = false;
            this.lblChequeSerialNo.Visible = false;
            this.txtChequeBookNo.Visible = false;
            this.txtFromChequeNo.Visible = false;
            this.txtToChequeNo.Visible = false;
            this.butCheque.Visible = false;
          
            // Show Form Text
            this.Text = this.GetFormNameString("Entry");

            // Enable / Disable Controls
            this.EnableDisableControls();
            
            // Set Initialize Controls
            this.InitializeControls();

            //Set Focus
            this.cboCurrency.Focus();
            this.rdoTypeB.Checked = true;
        }

        private void cxcliC0011_SaveButtonClick(object sender, EventArgs e)
        {
            // Save 
            this.controller.Save();
        }

        private void cxcliC0011_CancelButtonClick(object sender, EventArgs e)
        {
            this.controller.ClearControls();
            this.BindCustomer();
            this.txtNoPersonSign.Enabled = false;
            this.cboCurrency.Focus();
            this.Controller.ClearErrors();
        }

        private void cxcliC0011_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butReceipt_Click(object sender, EventArgs e)
        {
            if (CXUIScreenTransit.Transit("frmPFMVEW00027", true, new object[] { false, this.Name }) == DialogResult.OK)
            {
                PFMDTO00032 receipt = CXUIScreenTransit.GetData<PFMDTO00032>(this.Name);
                if (receipt != null)
                {
                    this.FReceipt = receipt;
                    this.ReceiptNo = receipt.ReceiptNo;
                }
            }
        }

        private void butCheque_Click(object sender, EventArgs e)
        {
            if (CXUIScreenTransit.Transit("frmPFMVEW00013", true, new object[] { false, this.Name }) == DialogResult.OK)
            {
                PFMDTO00006 cheque = CXUIScreenTransit.GetData<PFMDTO00006>(this.Name);
                if (cheque != null)
                {
                    this.BindCheque(cheque);
                }
            }
        }

        private void butAddCustomer_Click(object sender, EventArgs e)
        {
            BalFlag = 0;
            string bLCustId = "";
            if (this.controller.AddCustomer())
            {
                if (CustomerDataSource.Count > 0)
                {
                    foreach (PFMDTO00001 item in CustomerDataSource)
                    {
                        if (item.BlackList == "Black List Customer")
                        {
                            CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90229);//This customer is a Black List Customer!Please select the other customer.
                            BalFlag = 1;

                            //Remove Black List Customer from CustomerList
                            PFMDTO00001 toRemove = null;
                            toRemove = item;
                            if (toRemove != null)
                            {
                                CustomerDataSource.Remove(toRemove);
                            }

                            break;
                        }
                    }
                }
                this.BindCustomer();
                if (this.CustomerDataSource.Count >= 2)
                    this.txtNoPersonSign.Enabled = true;
            }
        }

        private void gvCustomer_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void mtxtDebitLinkAccount_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.controller.GetDebitLinkAccount();
        }

        private void gvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                PFMDTO00001 customer = this.gvCustomer.Rows[e.RowIndex].DataBoundItem as PFMDTO00001;
                this.controller.customerResult = CXClientWrapper.Instance.Invoke<ICXSVE00006, PFMDTO00001>(x => x.GetCustomerByCustomerId(customer.CustomerId));
                if (this.controller.customerResult != null)
                {
                    if (this.controller.customerResult.CustPhoto.CustPhotos != null)
                    {
                        this.Photo = CXClientGlobal.GetImage(this.controller.customerResult.CustPhoto.CustPhotos);
                    }
                    else
                    {
                        this.Photo = null;
                    }

                    if (this.controller.customerResult.Signature != null)
                    {
                        this.Signature = CXClientGlobal.GetImage(this.controller.customerResult.Signature);
                    }
                    else
                    {
                        this.Signature = null;
                    }
                }

                if (e.ColumnIndex == 3)
                {
                    if (CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC90001) == DialogResult.Yes)
                    {
                        this.CustomerDataSource.RemoveAt(e.RowIndex);
                        this.BindCustomer();
                        this.pbPhoto.Image = null;
                        this.pbSignature.Image = null;
                    }
                }
            }
        }
        #endregion

        #region "Methods"

        private void InitializeControls()
        {
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);   
            this.gbJoint.Text = this.GetFormNameString("Information");            
            this.gvCustomer.AutoGenerateColumns = false;
            this.BindComboBoxes();
            this.controller.ClearControls();
            this.cboCurrency.Focus();
        }

        private void EnableDisableControls()
        {
            cxcliC0011.ButtonEnableDisabled(false, false, true, false, true, false, true);
        }

        private void BindComboBoxes()
        {
            IList<CurrencyDTO> CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });

            cboCurrency.ValueMember = "Symbol";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = CurrencyList;
            cboCurrency.SelectedIndex = 0;
        }

        private void BindCheque(PFMDTO00006 cheque)
        {
            this.txtChequeBookNo.Text = cheque.ChequeBookNo;
            this.txtFromChequeNo.Text = cheque.StartNo;
            this.txtToChequeNo.Text = cheque.EndNo;
        }

        public void BindCustomer()
        {
            if (BalFlag != 1)
            {
                int GridRowsCount = Convert.ToInt32(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.MaxCustInGridJoin));

                this.gvCustomer.AutoGenerateColumns = false;
                this.gvCustomer.DataSource = null;

                if (this.CustomerDataSource.Count > 0)
                {
                    this.gvCustomer.DataSource = this.CustomerDataSource;
                    this.butAddCustomers.Enabled = this.customerDataSource.Count < GridRowsCount;
                }
                else
                {
                    this.butAddCustomers.Enabled = true;
                }
            }
        }

        private string GetFormNameString(string parameter)
        {
            switch (this.FormName)
            {
                case "Current.Joint":
                    return "Current Account (Joint) " + parameter;

                case "Saving.Joint":
                    return "Saving Account (Joint) " + parameter;

                case "Fixed.Joint":
                    return "Fixed Account (Joint) " + parameter;

                case "BusinessLoan.Joint": // Added By HWKO (22-Jun-2017)
                    return "Business Loan Account (Joint) " + parameter;

                case "HirePurchaseLoan.Joint": // Added By HWKO (22-Jun-2017)
                    return "Hire Purchase Loan Account (Joint) " + parameter;

                case "PersonalLoan.Joint": // Added By HWKO (22-Jun-2017)
                    return "Personal Loan Account (Joint) " + parameter;

                case "Dealer.Joint": // Added By HWKO (04-Aug-2017)
                    return "Dealer Account (Joint) " + parameter;

                default:
                    return string.Empty;
            }
        }

        public void Successful(string message, string accountCode)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message, new object[] { accountCode });
            this.cboCurrency.Focus();
        }

        public void Failure(string message)
        {

            CXUIMessageUtilities.ShowMessageByCode(message, new object[] { message == "MV00214" ? CurrentUserEntity.BranchCode : null });  //by hmw (for different branch interest taken account checking)               
        }

        #endregion
    }    
}
