//----------------------------------------------------------------------
// <copyright file="SAMVEW00004.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>11/01/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
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
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00033 : BaseDockingForm,IMNMVEW00033
    {
        public MNMVEW00033()
        {
            InitializeComponent();
        }

        private string formName = string.Empty;
        public string FormName
        {
            get;
            set;
        }

        private string acSign = string.Empty;
        public string AcSign
        {
            get;
            set;
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
                if (this.cboCity.SelectedValue == null)
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
                this.cboCurrency.SelectedValue = value;
                this.cboCurrency.Text = value;                
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

        public decimal MinBal
        {
            get { return string.IsNullOrEmpty(this.txtMinBal.Text) ? 0 : Convert.ToDecimal(this.txtMinBal.Text); }
            set {this.txtMinBal.Text=value.ToString(); }
        }

        private bool saveStatus = false;
        public bool SaveStatus
        {
            get { return this.saveStatus; }
            set { this.saveStatus = value; }
        }

        // Add JoinType by AAM (05-Feb-2018)
        public string JointType
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

        private IMNMCTL00033 currentCompanyController;
        public IMNMCTL00033 Controller
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

        IList<string> oldCustomers = new List<string>();
        public IList<string> OldCustomers
        {
            get { return this.oldCustomers; }
            set { this.oldCustomers = value; }
        }

        #endregion

        #region "Events"

        private void MNMVEW00033_Load(object sender, EventArgs e)
        {
            // Show / Hide Controls //Modified by HWKO (28-Dec-2017)
            if (this.TransactionStatus == "BUSINESSLOAN.Company" ||
                this.TransactionStatus == "PERSONALLOAN.Company" ||
                this.TransactionStatus == "HIREPURCHASELOAN.Company" ||
                this.TransactionStatus == "DEALER.Company")
            {
                this.HideControls("Current.Company");
            }
            else
            {
                this.HideControls(this.TransactionStatus);
            }

            // Set Initialize Controls
            this.InitializeControls();

            this.butCheque.Visible = false;
            this.butReceipt.Visible = false;
            this.lblReceiptNo.Visible = false;
            this.lblChequeBookNo.Visible = false;
            this.lblChequeSerialNo.Visible = false;
            this.txtReceiptNo.Visible = false;
            this.txtChequeBookNo.Visible = false;
            this.txtFromChequeNo.Visible = false;
            this.txtToChequeNo.Visible = false;
            this.gbLink.Visible = false;

            // Enable / Disable Controls
            this.EnableDisableControls();
            
            if (this.TransactionStatus == "Fixed.Company")
            {
                this.txtMinBal.Visible = false;
                this.lblMinBal.Visible = false;
            }
            this.Text = this.GetFormNameString("Editting");
            this.cboCurrency.SelectedIndex = 0;
            this.mtxtAccountNo.Enabled = true;
            this.mtxtAccountNo.Focus();
        }

        private void cxcliC0011_SaveButtonClick(object sender, EventArgs e)
        {
            this.SaveStatus = true;
            //if (CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC90001) == DialogResult.Yes)
            //{
                this.currentCompanyController.Save();   
            //}
                    
        }

        private void cxcliC0011_CancelButtonClick(object sender, EventArgs e)
        {
            this.currentCompanyController.ClearControls();
            this.EnableDisableControls();
            this.BindCustomer();
            this.cboCurrency.SelectedIndex = 0;
            this.cboCurrency.Focus();

            this.mtxtAccountNo.Enabled = true;// Added By AAM (31-Jan-2018)
            this.mtxtAccountNo.Focus(); // Added By AAM (31-Jan-2018)
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
                    BindCheque(cheque);
                }
            }
        }

        private void butAddCustomer_Click(object sender, EventArgs e)
        {
            if (this.currentCompanyController.AddCustomer())
            {
                this.BindCustomer();
            }
        }

        private void gvCustomer_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void mtxtDebitLinkAccount_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //this.currentCompanyController.GetDebitLinkAccount();
        }

        //private void FormName_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        this.SelectNextControl(this.ActiveControl, true, true, true, true);
        //    }
        //}


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

        public void FillData(PFMDTO00050 bindData)
        {
  if (bindData != null && bindData.CustomerDTOs != null)
            {
                PFMDTO00001 CustInfo = bindData.CustomerDTOs.First();
                PFMDTO00001 customerResult = CXClientWrapper.Instance.Invoke<ICXSVE00006, PFMDTO00001>(x => x.GetCustomerByCustomerId(CustInfo.CustomerId));
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
            }
            this.NameOfFirm = bindData.Name;
            this.Email = bindData.Email;
            this.Address = bindData.Address;
            this.CityCode = bindData.CityCode;
            this.CurrencyCode = bindData.CurrencyCode;
            this.Phone = bindData.Phone;
            this.Fax = bindData.Fax;
            this.TownshipCode = bindData.TownshipCode;
            this.StateCode = bindData.StateCode;
            this.Business = bindData.Business;
            this.NoOfPersonSign = bindData.NoOfPersonSign;
            this.gvCustomer.DataSource = bindData.CustomerDTOs.Where(c=>c.CustomerId != null).ToList();//Updated by HWKO (28-Dec-2017)
            this.customerDataSource = bindData.CustomerDTOs.Where(c => c.CustomerId != null).ToList();//Updated by HWKO (28-Dec-2017)
            this.MinBal = bindData.MinBal;
            foreach (PFMDTO00001 customerDTO in bindData.CustomerDTOs)
            {
                oldCustomers.Add(customerDTO.CustomerId);
            }

            this.cboCurrency.Enabled = false;
        }

        private void InitializeControls()
        {
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            this.gbAccountInformation.Text = this.GetFormNameString("Information");
            this.Text = this.GetFormNameString("Entry");
            this.gvCustomer.AutoGenerateColumns = false;
            this.BindComboBoxes();
            this.currentCompanyController.ClearControls();
            //this.cboCurrency.Focus();
            this.mtxtAccountNo.Enabled = true;
            this.mtxtAccountNo.Focus();
        }

        public void EnableDisableControls()
        {
            cxcliC0011.ButtonEnableDisabled(false, false, true, false, true, false, true);
            //Disable All Controls
            //this.mtxtAccountNo.Enabled = false;
            this.EnableDisableInputControls(false);
            this.cboCurrency.Enabled = true;

        }

        public void EnableDisableInputControls(bool status)
        {
            this.txtNameOfFirm.Enabled = status;
            this.txtEmail.Enabled = status;
            this.txtAddress.Enabled = status;
            this.cboCity.Enabled = status;
            this.mtxtPhone.Enabled = status;
            this.mtxtFax.Enabled = status;
            this.cboTownship.Enabled = status;
            this.cboState.Enabled = status;
            this.txtBusiness.Enabled = status;
            this.txtNoPersonSign.Enabled = status;
            this.txtReceiptNo.Enabled = status;
            this.txtChequeBookNo.Enabled = status;
            this.txtMinBal.Enabled = status;
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
            int GridRowsCount = Convert.ToInt32(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.MaxCustInGridComp));
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

        private string GetFormNameString(string parameter)
        {
            switch (this.FormName)
            {
                case "Current.Company":
                    return "Current Account (Company) " + parameter;
                //Added by HWKO (28-Dec-2017)
                case "BUSINESSLOAN.Company":
                    return "Business Loan Account (Company) " + parameter;

                case "HIREPURCHASELOAN.Company":
                    return "Hire Purchase Loan Account (Company) " + parameter;

                case "PERSONALLOAN.Company":
                    return "Personal Loan Account (Company) " + parameter;

                case "DEALER.Company":
                    return "Dealer Account (Company) " + parameter;
                //End Region

                case "Current.Partnership":
                    return "Current Account (Partnership) " + parameter;

                case "Current.Association":
                    return "Current Account (Association) " + parameter;

                case "Saving.Company":
                    return "Saving Account (Organization) " + parameter;

                case "Fixed.Company":
                    return "Fixed Account (Company) " + parameter;

                default:
                    return string.Empty;
            }
        }

        public void Successful(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
            this.EnableDisableControls();
            this.cboCurrency.SelectedIndex = 0;
            //this.cboCurrency.Focus();
            this.mtxtAccountNo.Focus();
        }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }

        public void SetFocus()
        {
            this.txtNameOfFirm.Focus();
        }
        public void SetDisable()
        {
            this.mtxtAccountNo.Enabled = false;
        }
        public void SetEnable()
        {
            this.mtxtAccountNo.Enabled = true;
        }
        #endregion

        #region phone and fax validation
        private void mtxtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 60 && e.KeyChar <= 90)

                e.Handled = true;

            if (e.KeyChar >= 97 && e.KeyChar <= 122)
                e.Handled = true;


        }

        private void mtxtFax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 60 && e.KeyChar <= 90)

                e.Handled = true;

            if (e.KeyChar >= 97 && e.KeyChar <= 122)
                e.Handled = true;
        }



        #endregion



    }
}
