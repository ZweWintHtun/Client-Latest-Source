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
    public partial class PFMVEW00002 : BaseDockingForm, IPFMVEW00002
    {
        public PFMVEW00002()
        {
            InitializeComponent();
        }
        
        #region Controls Input Output
        public PFMDTO00032 FReceipt { get; set; }
        private IList<PFMDTO00001> customerDataSource;
        public IList<PFMDTO00001> CustomerDataSource 
        {
            get
            {
                if (this.customerDataSource == null)
                    this.customerDataSource = new List<PFMDTO00001>();

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

        public string NameOfFirm 
        {
            get { return this.txtNameOfFirm.Text; }
            set { this.txtNameOfFirm.Text = value; } 
        }

        public string Email 
        {
            get { return this.txtEmail.Text; }
            set { this.txtEmail.Text = value; }
        }

        public string Address 
        {
            get { return this.txtAddress.Text; }
            set { this.txtAddress.Text = value; }
        }

        public string CityCode 
        {
            get
            {
                if(this.cboCity.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cboCity.SelectedValue.ToString();
                }
            }
            set { this.cboCity.SelectedValue = value; }
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

        public string Phone
        {
            get { return this.mtxtPhone.Text; }
            set { this.mtxtPhone.Text = value; }
        }

        public string Fax
        {
            get { return this.mtxtFax.Text; }
            set { this.mtxtFax.Text = value; }
        }

        public string TownshipCode
        {
            get
            {
                if (this.cboTownship.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cboTownship.SelectedValue.ToString();
                }
            }
            set { this.cboTownship.SelectedValue = value; }    
        }

        public string StateCode
        {
            get
            {
                if (this.cboState.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cboState.SelectedValue.ToString();
                }
            }
            set { this.cboState.SelectedValue = value; }    
        }
        public string Business
        {
            get { return this.txtBusiness.Text; }
            set { this.txtBusiness.Text = value; }
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
            set { this.txtName.Text = value;}
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

        //Added by HWKO (15-Aug-2017)
        public string CompanyRegNo
        {
            get { return this.txtCpnyRegNo.Text.ToString(); }
            set { this.txtCpnyRegNo.Text = value; }
        }
        public DateTime CompanyRegDate
        {
            get { return this.dtpCpnyRegDate.Value; }
            set { this.dtpCpnyRegDate.Value = value; }
        }
        public DateTime CompanyRegExpDate
        {
            get { return this.dtpCpnyRegExpDate.Value; }
            set { this.dtpCpnyRegExpDate.Value = value; }
        }
        //End Region

        #endregion

        #region "Controller"

        private IPFMCTL00002 currentCompanyController;
        public IPFMCTL00002 Controller
        {
            get
            {
                return this.currentCompanyController;
            }
            set
            {
                this.currentCompanyController = value;
                this.currentCompanyController.View = this;
            }
        }

        #endregion

        #region "Events"

        private void PFMVEW00002_Load(object sender, EventArgs e)
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
                
            // Enable / Disable Controls
            this.EnableDisableControls();
            
            // Set Initialize Controls
            this.InitializeControls();
        }

        private void cxcliC0011_SaveButtonClick(object sender, EventArgs e)
        {
            this.currentCompanyController.Save();
        }

        private void cxcliC0011_CancelButtonClick(object sender, EventArgs e)
        {
            this.currentCompanyController.ClearControls();
            this.BindCustomer();
            this.txtNoPersonSign.Enabled = false;
            this.cboCurrency.Focus();
        }

        private void cxcliC0011_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butReceipt_Click(object sender, EventArgs e)
        {
            this.txtReceiptNo.CausesValidation = false;
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
                    BindCheque(cheque);
                }
            }
        }

        private void butAddCustomer_Click(object sender, EventArgs e)
        {
            if (this.currentCompanyController.AddCustomer())
            {
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
            this.currentCompanyController.GetDebitLinkAccount();
        }

        private void gvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                PFMDTO00001 customer = this.gvCustomer.Rows[e.RowIndex].DataBoundItem as PFMDTO00001;
                PFMDTO00001 customerResult = CXClientWrapper.Instance.Invoke<ICXSVE00006, PFMDTO00001>(x => x.GetCustomerByCustomerId(customer.CustomerId));
                if (customerResult != null)
                {
                    if (customerResult.CustPhoto.CustPhotos != null)
                    {
                        this.pbPhoto.Image = CXClientGlobal.GetImage(customerResult.CustPhoto.CustPhotos);
                    }
                    else
                    {
                        this.pbPhoto.Image = null;
                    }

                    if (customerResult.Signature != null)
                    {
                        this.pbSignature.Image = CXClientGlobal.GetImage(customerResult.Signature);
                    }
                    else
                    {
                        this.pbSignature.Image = null;
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
            this.gbAccountInformation.Text = this.GetFormNameString("Information");
            this.Text = this.GetFormNameString("Entry");
            this.gvCustomer.AutoGenerateColumns = false;
            this.BindComboBoxes();           
            this.currentCompanyController.ClearControls();
            this.txtNameOfFirm.Focus();
        }

        private void EnableDisableControls()
        {
            cxcliC0011.ButtonEnableDisabled(false, false, true, false, true, false, true);
        }

        private void BindComboBoxes()
        {
            IList<CityDTO> CityCodeList = CXCLE00002.Instance.GetListObject<CityDTO>("CityCode.Client.Select", new object[] { true });
            IList<StateDTO> StateCodeList = CXCLE00002.Instance.GetListObject<StateDTO>("StateCode.Client.Select", new object[] { true });
            IList<TownshipDTO> TownshipCodeList = CXCLE00002.Instance.GetListObject<TownshipDTO>("TownshipCode.Client.Select", new object[] { true });
            IList<CurrencyDTO> CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });

            cboCity.ValueMember = "CityCode";
            cboCity.DisplayMember = "Description";
            cboCity.DataSource = CityCodeList;

            cboState.ValueMember = "StateCode";
            cboState.DisplayMember = "Description";
            cboState.DataSource = StateCodeList;

            cboTownship.ValueMember = "TownshipCode";
            cboTownship.DisplayMember = "Description";
            cboTownship.DataSource = TownshipCodeList;

            cboCurrency.ValueMember = "Symbol";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = CurrencyList;
        }

        private void BindCheque(PFMDTO00006 cheque)
        {
            this.txtChequeBookNo.Text = cheque.ChequeBookNo;
            this.txtFromChequeNo.Text = cheque.StartNo;
            this.txtToChequeNo.Text = cheque.EndNo;
        }

        public void BindCustomer()
        {
            int GridRowsCount =Convert.ToInt32(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.MaxCustInGridComp));  
            this.gvCustomer.AutoGenerateColumns = false;
            this.gvCustomer.DataSource = null;

            if (this.CustomerDataSource.Count > 0)
            {
                this.gvCustomer.DataSource = this.CustomerDataSource;
                this.butAddCustomer.Enabled = this.customerDataSource.Count < GridRowsCount;
            }
            else
            {
                this.butAddCustomer.Enabled = true;
            }
        }

        public string GetFormNameString(string parameter)
        {
            switch(this.FormName)
            {
                case "Current.Company":
                    return "Current Account (Company) " + parameter;

                case "Current.Partnership":
                    return "Current Account (Partnership) " + parameter;

                case "Current.Association":
                    return "Current Account (Association) " + parameter;

                case "Saving.Company":
                    return "Saving Account (Organization) " + parameter;

                case "Fixed.Company":
                    return "Fixed Account (Organization) " + parameter;

                //Added By HWKO (22-Jun-2017)
                case "BusinessLoan.Company":      
                    return "Business Loan Account (Company) " + parameter;

                case "HirePurchaseLoan.Company":
                    return "Hire Purchase Loan Account (Company) " + parameter;

                case "PersonalLoan.Company":
                    return "Personal Loan Account (Company) " + parameter;
                //End
                //Added by HWKO (04-Aug-2017)
                case "Dealer.Company":
                    return "Dealer Account (Company) " + parameter;


                default:
                    return string.Empty;
            }
        }

        public void Successful(string message, string accountCode)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message, new object[]{accountCode});
            this.cboCurrency.Focus();
        }

        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message, new object[] { message == "MV00214" ? CurrentUserEntity.BranchCode : null });  
        }

        #endregion

        #region phone and fax validation


        private void mtxtFax_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

       

        #endregion

        private void txtNameOfFirm_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtBusiness_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void gbAccountInformation_Enter(object sender, EventArgs e)
        {

        }

        private void mtxtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            { e.Handled = true; }
        }

        private void mtxtFax_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            { e.Handled = true; }
        }

        private void mtxtPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void mtxtFax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{Tab}");
            }
        }

        //Added by HWKO (15-Aug-2017)
        private void txtCpnyRegNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        //private void PFMVEW00002_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
        //    {
        //        this.SelectNextControl(this.ActiveControl, false, true, true, true);
        //    }
        //}

        //private void cboCity_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
        //    {
        //        this.SelectNextControl(this.ActiveControl, false, true, false, true);
        //    }

        //}     
    }
}
