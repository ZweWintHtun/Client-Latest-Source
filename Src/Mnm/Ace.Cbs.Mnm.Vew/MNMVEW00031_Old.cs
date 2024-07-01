//----------------------------------------------------------------------
// <copyright file="MNMVEW00031.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NEEA</CreatedUser>
// <CreatedDate>10/29/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.Admin.DataModel;


namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00031 : BaseDockingForm, IMNMVEW00031
    {
        public MNMVEW00031()
        {
            InitializeComponent();
        }

        
        #region Controls Input Output
       

        private string acSign;
        public string AcSign { get; set; }

        string oldCustomer_ID;
        public string oldCustomerID
        {
            get { return this.oldCustomer_ID; }
            set { this.oldCustomer_ID = value; }
        }

        public decimal MinimumBalance
        {
            get { return string.IsNullOrEmpty(this.txtMinBal.Text) ? 0 : Convert.ToDecimal(this.txtMinBal.Text); }
            set { txtMinBal.Text =value.ToString(); }
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
                this.cboCurrency.SelectedValue = value;
                this.cboCurrency.Text = value;
                
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

        public bool saveStatus = false;
        public bool SaveStatus
        {
            get { return this.saveStatus; }
            set { this.saveStatus = value; }
        }
   

        #endregion

        #region "Controller"

        private IMNMCTL00031 controller;
        public IMNMCTL00031 Controller
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

        private void MNMVEW00031_Load(object sender, EventArgs e)
        {
            // Show / Hide Controls //Modified by HWKO (26-Dec-2017)
            if (this.TransactionStatus == "BUSINESSLOAN.Individual" ||
                this.TransactionStatus == "PERSONALLOAN.Individual" ||
                this.TransactionStatus == "HIREPURCHASELOAN.Individual" ||
                this.TransactionStatus == "DEALER.Individual")
            {
                this.HideControls("Current.Individual");
            }
            else
            {
                this.HideControls(this.TransactionStatus);
            }
            this.lblTo.Hide();
            // Enable / Disable Controls
            this.EnableDisableControls();

            //this.EnableDisableControls(false);

            // Set Initialize Controls
            this.InitializeControls();

        }     
      
        private void cxcliC0011_SaveButtonClick(object sender, EventArgs e)
        {          
            //if (CXUIMessageUtilities.ShowMessageByCode("MC00004") == DialogResult.Yes)
            //{
                this.SaveStatus = true;
                this.controller.Save();

            //}

            if(this.Controller.SaveStaus == true)
                  this.EnableDisableControls();    
        }

        private void cxcliC0011_CancelButtonClick(object sender, EventArgs e)
        {
            this.controller.ClearControls(false);
            this.controller.ClearErrors();
            this.cboCurrency.Focus();
            this.cboCurrency.SelectedIndex = 0;
            this.cboCurrency.Enabled = true;
            //this.mtxtAccountNo.Enabled = false;
            this.butAddCustomer.Enabled = false;
            this.EnableDisableControls();
            
            this.InitializeControls();// Added By AAM(31-Jan-2018)
        }

        private void cxcliC0011_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }      

        private void butAddCustomer_Click(object sender, EventArgs e)
        {
            if (this.controller.AddCustomer())
            {
                this.BindCustomer();
            }
        }

        private void cboCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.mtxtAccountNo.Enabled = true;
            //this.mtxtAccountNo.Focus();
        }

        //private void cboCurrency_KeyDown(object sender, KeyEventArgs e) 
        //{
        //    //if (e.KeyCode.Equals(Keys.Enter) || e.KeyCode.Equals(Keys.Tab))
        //    //{
        //    //    //SendKeys.Send("{Tab}");
        //    //    //this.mtxtAccountNo.Enabled = true;
        //    //    //this.mtxtAccountNo.Focus();
        //    //}
        //}

                
        #endregion

        #region "Methods"

        private void InitializeControls()
        {
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            this.gbAccountInformation.Text = this.GetFormNameString("Information");   
            this.Text = this.GetFormNameString("Edit");            
            this.controller.ClearControls(false);
            this.BindCurrency();
            this.cboCurrency.SelectedIndex = 0;
            this.cboCurrency.Enabled = true;
            this.mtxtCustomerID.Enabled = false;
            //this.mtxtAccountNo.Enabled = false; 
            this.butAddCustomer.Enabled = false;
            this.mtxtAccountNo.Focus();
        }

        private void EnableDisableControls()
        {
            cxcliC0011.ButtonEnableDisabled(false, false, true, false, true, false, true);
            if (this.FormName.Substring(0,5)=="Fixed")
            {
                this.txtMinBal.Visible = false;
                this.lblMinimumBalance.Visible = false;
            }
        }

        public void BindCustomer()
        {
            this.CustomerId = this.Customer.CustomerId;
            this.CustomerName = this.Customer.Name;
            this.DateOfBirth = this.Customer.DateOfBirth;
            this.Email = this.Customer.Email;
            this.Address = this.Customer.Address;
            this.GuardianshipName = this.Customer.GuardianName;
            this.GuardianshipNRC = this.Customer.GuardianNRCNo;
            this.FatherName = this.Customer.FatherName;
            this.NRC = this.Customer.NRC;
            this.Phone = this.Customer.PhoneNo;
            this.Fax = this.Customer.FaxNo;
            //this.Business = this.Customer.Business;   //added by ASDA

            if (this.Customer.OccupationDesp == null)
            {
                this.OccupationCode = CXCLE00002.Instance.GetScalarObject<string>("OccupationCode.SelectByCode", this.Customer.OccupationCode,true);
            }
            else
            {
                this.OccupationCode = this.Customer.OccupationDesp;
            }

            if (this.Customer.TownshipDesp == null)
            {
                this.TownshipCode = CXCLE00002.Instance.GetScalarObject<string>("TownshipCode.SelectByCode", this.Customer.TownshipCode,true);
            }
            else
            {
                this.TownshipCode = this.Customer.TownshipDesp;
            }

            if (this.Customer.StateDesp == null)
            {
                this.StateCode = CXCLE00002.Instance.GetScalarObject<string>("StateCode.SelectByCode", this.Customer.StateCode,true);
            }
            else
            {
                this.StateCode = this.Customer.StateDesp;
            }

            if (this.Customer.CityDesp == null)
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

        }

        private string GetFormNameString(string parameter)
        {
            switch (this.FormName)
            {
                case "Current.Individual":
                    return "Current Account (Individual) " + parameter;

                    //Added by HWKO (26-Dec-2017)
                case "BUSINESSLOAN.Individual":
                    return "Business Loan Account (Individual) " + parameter;

                case "PERSONALLOAN.Individual":
                    return "Personal Loan Account (Individual) " + parameter;

                case "HIREPURCHASELOAN.Individual":
                    return "Hire Purchase Loan Account (Individual) " + parameter;

                case "DEALER.Individual":
                    return "Dealer Account (Individual) " + parameter;
                    //Endregion

                case "Current.PrivateFirm":
                    return "Current Account (PrivateFirm) " + parameter;

                case "Saving.Individual":
                    return "Saving Account (Individual) " + parameter;

                case "Saving.Minor":
                    return "Saving Account (Minor) " + parameter;

                case "Fixed.Individual":
                    return "Fixed Account (Individual) " + parameter;

                case "Fixed.Minor":
                    return "Fixed Account (Minor) " + parameter;

                default:
                    return string.Empty;
            }
        }

        public void Successful(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);

            this.controller.ClearControls(false);
            this.controller.ClearErrors();
            this.cboCurrency.SelectedIndex = 0;
            this.cboCurrency.Enabled = true;
            this.mtxtAccountNo.Enabled = false;
            this.butAddCustomer.Enabled = false;
            this.EnableDisableControls();
            this.cboCurrency.Focus();
        }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }

        private void BindCurrency()
        {
            IList<CurrencyDTO> CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });

            cboCurrency.ValueMember = "Symbol";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = CurrencyList;
        }

        public void EnableDisableInputControls(bool status)
        {
            this.txtAddress.Enabled = status;
            this.txtEmail.Enabled = status;
            this.txtCity.Enabled = status;
            this.txtBusiness.Enabled = status;
            this.mtxtPhone.Enabled = status;
            this.mtxtFax.Enabled = status;
            this.txtFatherName.Enabled = status;
            this.txtState.Enabled = status;
            this.txtTownship.Enabled = status;
            this.txtOccupation.Enabled = status;
            this.txtGuardianshipName.Enabled = status;
            this.txtName.Enabled = status;
            this.txtNameofFirm.Enabled = status;
            this.txtMinBal.Enabled = status;
            this.mtxtNRC.Enabled = status;

        }

        public void FillData(PFMDTO00001 CustomerInfo)
        {
            cxcliC0011.ButtonEnableDisabled(false, false, true, false, true, false, true);
            this.CurrencSymbol = CustomerInfo.CurrencyCode;
            this.CustomerId = CustomerInfo.CustomerId;
            this.CustomerName = CustomerInfo.Name;
            this.Email = CustomerInfo.Email;
            this.Address = CustomerInfo.Address;
            this.NRC = CustomerInfo.NRC;
            this.Phone = CustomerInfo.PhoneNo;
            this.Fax = CustomerInfo.FaxNo;
            this.Address = CustomerInfo.Address;
            this.DateOfBirth = CustomerInfo.DateOfBirth;
            this.OccupationCode = CustomerInfo.OccupationDesp;
            this.TownshipCode = CustomerInfo.TownshipDesp;
            this.StateCode = CustomerInfo.StateDesp;
            this.CityCode = CustomerInfo.CityDesp;
            this.FatherName = CustomerInfo.FatherName;
            this.CurrencyCode = CustomerInfo.CurrencyCode;
            this.NameOfFirm = CustomerInfo.NameofFirm;
            this.GuardianshipName = CustomerInfo.GuardianName;
            this.GuardianshipNRC = CustomerInfo.GuardianNRCNo;
            this.ChequeBookNo = CustomerInfo.chequeBookNo;
            this.ChequeStartNo = CustomerInfo.StartNo;
            this.ChequeEndNo = CustomerInfo.EndNo;
            this.Photo = CXClientGlobal.GetImage(CustomerInfo.CustPhotos);
            this.Signature = CXClientGlobal.GetImage(CustomerInfo.Signature);
            this.oldCustomerID = CustomerInfo.CustomerId;
            this.MinimumBalance = CustomerInfo.MinimumBalance;
            this.Business = CustomerInfo.Business;  //Added by ASDA

            this.butAddCustomer.Enabled = true;
            this.mtxtCustomerID.Enabled = true;
            this.cboCurrency.Enabled = false;
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

    

    }
}
