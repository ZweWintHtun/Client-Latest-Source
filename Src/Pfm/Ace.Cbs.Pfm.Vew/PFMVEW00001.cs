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
    public partial class PFMVEW00001 : BaseDockingForm, IPFMVEW00001
    {
        public PFMVEW00001()
        {
            InitializeComponent();
        }
        
        #region Controls Input Output
        public PFMDTO00032 FReceipt { get; set; }

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

        public string CustomerId
        {
            get { return this.mtxtCustomerID.Text; }
            set { this.mtxtCustomerID.Text = value; }
        }

        public string CustomerName
        {
            get { return this.txtName.Text; }
            set { this.txtName.Text = value; }
        }

        public Nullable<DateTime> DateOfBirth
        {
            get { return this.dtpDateofBirth.Value; }
            set 
            {
                if (value == null)
                {
                    this.dtpDateofBirth.CustomFormat = " ";
                }
                else
                {
                    this.dtpDateofBirth.CustomFormat = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.UIDateFormat);
                    this.dtpDateofBirth.Value = value.Value;
                }
            }
        }

        public Nullable<DateTime> MatureDate
        {
            get { return this.dtpMatureDate.Value; }
            set
            {
                if (value == null)
                {
                    this.dtpMatureDate.CustomFormat = " ";
                }
                else
                {
                    this.dtpMatureDate.CustomFormat = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.UIDateFormat);
                    this.dtpMatureDate.Value = value.Value;
                }
            }
        }

        public string OccupationCode
        {
            get { return this.txtOccupation.Text; }
            set { this.txtOccupation.Text = value; }
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

        public string GuardianshipName
        {
            get { return this.txtGuardianshipName.Text; }
            set { this.txtGuardianshipName.Text = value; }
        }

        public string GuardianshipNRC
        {
            get { return this.mtxtFatherGuardianshipNRC.Text; }
            set { this.mtxtFatherGuardianshipNRC.Text = value; }
        }

        public string NameOfFirm 
        {
            get { return this.txtNameofFirm.Text; }
            set { this.txtNameofFirm.Text = value; } 
        }

        public string FatherName
        {
            get { return this.txtFatherName.Text; }
            set { this.txtFatherName.Text = value; }
        }

        public string NRC
        {
            get { return this.mtxtNRC.Text; }
            set { this.mtxtNRC.Text = value; }
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
            get { return txtTownship.Text; }
            set { this.txtTownship.Text = value; }    
        }

        public string StateCode
        {
            get { return txtState.Text; }
            set { this.txtState.Text = value; }    
        }

        public string CityCode
        {
            get { return txtCity.Text; }
            set { this.txtCity.Text = value; }    
        }       

        public string Business
        {
            get { return this.txtBusiness.Text; }
            set { this.txtBusiness.Text = value; }
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
            get { return this.txtLinkAccountName.Text; }
            set { this.txtLinkAccountName.Text = value; }
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
        #endregion

        #region "Controller"

        private IPFMCTL00001 controller;
        public IPFMCTL00001 Controller
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

        public PFMDTO00001 Customer { get; set; }

        #endregion

        #region "Events"

        private void PFMVEW00001_Load(object sender, EventArgs e)
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

            this.cboCurrency.Focus();

            //
            tabControl1.TabPages.Remove(tabPage2);
            ((Control)this.tabPage2).Enabled = false;
            ((Control)this.tabPage2).Visible = false;
        }

        private void cxcliC0011_SaveButtonClick(object sender, EventArgs e)
        {
            this.controller.Save();            
        }

        private void cxcliC0011_CancelButtonClick(object sender, EventArgs e)
        {
            this.controller.ClearControls(false);
            this.controller.ClearErrors();
            this.cboCurrency.Focus();
            this.cxcliC0011.ButtonEnableDisabled(false, false, true, false, true, false, true);
        }

        private void cxcliC0011_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butReceipt_Click(object sender, EventArgs e)
        {
            this.controller.AddReceipt();
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
            if (this.controller.AddCustomer())
            {
                this.BindCustomer();
            }
        }

        private void mtxtDebitLinkAccount_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.controller.GetDebitLinkAccount();
        }
        #endregion

        #region "Methods"

        private void InitializeControls()
        {
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            this.gbAccountInformation.Text = this.GetFormNameString("Information");
            this.Text = this.GetFormNameString("Entry");
            this.cboCurrency.Focus();
            this.BindComboBoxes();
            this.controller.ClearControls(false);
            
        }

        private void EnableDisableControls()
        {
            cxcliC0011.ButtonEnableDisabled(false, false, true, false, true, false, true);
        }

        private void BindCheque(PFMDTO00006 cheque)
        {
            this.txtChequeBookNo.Text = cheque.ChequeBookNo;
            this.txtFromChequeNo.Text = cheque.StartNo;
            this.txtToChequeNo.Text = cheque.EndNo;
        }

        private void BindComboBoxes()
        {
            IList<CurrencyDTO> CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });

            cboCurrency.ValueMember = "Symbol";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = CurrencyList;
        }
        
        public void BindCustomer()
        {
            this.CustomerId = this.Customer.CustomerId;
            this.CustomerName = this.Customer.Name;
            this.DateOfBirth = this.Customer.DateOfBirth;
            this.MatureDate = this.Customer.DateOfBirth.AddYears(18);
            this.Email = this.Customer.Email;
            this.Address = this.Customer.Address;
            this.GuardianshipName = this.Customer.GuardianName;
            this.GuardianshipNRC = this.Customer.GuardianNRCNo;
            this.FatherName = this.Customer.FatherName;
            this.NRC = this.Customer.NRC;
            this.Phone = this.Customer.PhoneNo;
            this.Fax = this.Customer.FaxNo;

            if (String.IsNullOrEmpty(this.Customer.OccupationDesp))
            {
                this.OccupationCode = CXCLE00002.Instance.GetScalarObject<string>("OccupationCode.SelectByCode", this.Customer.OccupationCode,true);
            }
            else
            {
                this.OccupationCode = this.Customer.OccupationDesp;
            }

            if (String.IsNullOrEmpty(this.Customer.TownshipDesp))
            {
                this.TownshipCode = CXCLE00002.Instance.GetScalarObject<string>("TownshipCode.SelectByCode", this.Customer.TownshipCode,true);
            }
            else
            {
                this.TownshipCode = this.Customer.TownshipDesp;
            }

            if (String.IsNullOrEmpty(this.Customer.StateDesp))
            {
                this.StateCode = CXCLE00002.Instance.GetScalarObject<string>("StateCode.SelectByCode", this.Customer.StateCode,true);
            }
            else
            {
                this.StateCode = this.Customer.StateDesp;
            }

            if (String.IsNullOrEmpty(this.Customer.CityDesp))
            {
                this.CityCode = CXCLE00002.Instance.GetScalarObject<string>("CityCode.SelectByCode", this.Customer.CityCode,true);
            }
            else
            {
                this.CityCode = this.Customer.CityDesp;
            }

            this.GuardianshipNRC = this.Customer.GuardianNRCNo;

            PFMDTO00001 customerResult = CXClientWrapper.Instance.Invoke<ICXSVE00006, PFMDTO00001>(x => x.GetCustomerByCustomerId(this.Customer.CustomerId));
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
            //added by ZMS for Pristine to known the customer is black list customer or not 
            if (this.Customer.BlackList == "Black List Customer")
            {
                //lblBlackListInfo.Text = Customer.BlackList;
                this.cxcliC0011.ButtonEnableDisabled(false, false, false, false, true, false, true);
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90229);//This customer is a Black List Customer!Please select the other customer.
            }
            else
                this.cxcliC0011.ButtonEnableDisabled(false, false, true, false, true, false, true);
        }

        private string GetFormNameString(string parameter)
        {
            switch(this.FormName)
            {
                case "Current.Individual":
                    return "Current Account (Individual) " + parameter;

                case "Current.PrivateFirm":
                    return "Current Account (Private Firm) " + parameter;

                case "Saving.Individual":
                    return "Saving Account (Individual) " + parameter;

                case "Saving.Minor":
                    return "Saving Account (Minor) " + parameter;

                case "Fixed.Individual":
                    return "Fixed Account (Individual) " + parameter;

                case "Fixed.Minor":
                    return "Fixed Account (Minor) " + parameter;

                case "BusinessLoan.Individual":
                    return "Business Loan Account (Individual) " + parameter; // Added By HWKO (22-Jun-2017)               

                case "HirePurchaseLoan.Individual":
                    return "Hire Purchase Loan Account (Individual) " + parameter; // Added By HWKO (22-Jun-2017) 

                case "PersonalLoan.Individual":
                    return "Persoanl Loan Account (Individual) " + parameter; // Added By HWKO (22-Jun-2017) 

                case "Dealer.Individual":
                    return "Dealer Account (Individual) " + parameter; // Added By HWKO (04-Aug-2017) 

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

        private void mtxtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            { e.Handled = true; }
        }

        private void mtxtFax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            { e.Handled = true; }
        }

        private void PFMVEW00001_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode.Equals(Keys.F2))
            //{
            //    ((Control)this.tabPage2).Enabled = true;
            //    // ((Control)this.tbpPersonalGuarantee).Visible = true;
            //    this.tabControl1.SelectedTab = this.tabPage2;
            //    this.chkVIPAccount.Focus();
            //}
        }

        private void gbAccountInformation_Enter(object sender, EventArgs e)
        {

        }
    }
}
