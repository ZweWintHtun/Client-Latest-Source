//----------------------------------------------------------------------
// <copyright file="MNMVEW00032.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KTRHMS</CreatedUser>
// <CreatedDate>11/04/2013</CreatedDate>
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
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Mnm.Vew
{
    /// <summary>
    /// Joint Form
    /// </summary>
    public partial class MNMVEW00032 : BaseDockingForm, IMNMVEW00032
    {
        #region "Constructure"

        public MNMVEW00032()
        {
            InitializeComponent();
        }

        #endregion

        #region "Controls Input Output"

        private string formName = string.Empty;
        public string FormName
        {
            get { return this.formName; }
            set { this.formName = value; }
        }

        public PFMDTO00032 FReceipt { get; set; }
        public PFMDTO00067 AccountInformation { get; set; }

        private IList<PFMDTO00001> customerDataSource;
        public IList<PFMDTO00001> CustomerDataSource
        {
            get 
            {
                if(this.customerDataSource == null)
                    this.customerDataSource = new List<PFMDTO00001>();

               return this.customerDataSource; 
            }
            set
            {
                this.customerDataSource = value;
            }
        }

        IList<string> oldCustomers = new List<string>();
        public IList<string> OldCustomers
        {
            get { return this.oldCustomers; }
            set { this.oldCustomers = value; }
        }

        public string TransactionStatus
        {
            get { return this.FormName; }
        }

        public string AccountNo
        {
            get { return this.mtxtAccountNo.Text.Replace("-", "").Trim(); }
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

        public decimal MinBalance
        {
            get { return string.IsNullOrEmpty(this.txtMinBal.Text)? 0 : Convert.ToDecimal(this.txtMinBal.Text); }
            set { this.txtMinBal.Text = value.ToString(); }
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

                this.rdoTypeB.Checked = true;
            }
        }

        public string Status { get; set; }

        #endregion

        #region "Controller"

        private IMNMCTL00032 controller;
        public IMNMCTL00032 Controller
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

        private void MNMVEW00032_Load(object sender, EventArgs e)
        {
            //ButtonEnableDisabled(newButtonEnabled, editButtonEnabled, saveButtonEnabled, deleteButtonEnabled,cancelButtonEnabled, printButtonEnabled, exitButtonEnabled);
            this.tsbCRUD.ButtonEnableDisabled(false, true, false, false, true, false, true);
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            //Show Form Text
            this.Text = this.GetFormNameString("Editting");

            // Enable / Disable Controls
            this.EnableDisableControls();

            // Set Initialize Controls
            this.InitializeControls();

            //Set Focus
            this.cboCurrency.SelectedIndex = 0;
            this.DisableControl(false);

            if (this.FormName.Substring(0, 5) == "Fixed")
            {
                this.txtMinBal.Visible = false;
                this.lblMinBal.Visible = false;
            }
            this.mtxtAccountNo.Focus();

        }

        private void DisableControl(bool flag)
        {
            this.butAddCustomers.Enabled = flag;
            this.txtNoPersonSign.Enabled = flag;
            this.txtMinBal.Enabled = flag;
            this.gbJoinType.Enabled = flag;
            this.rdoTypeA.Enabled = flag;
            this.rdoTypeB.Enabled = flag;
            //this.mtxtAccountNo.Enabled = flag;//Commented by HWKO (27-Dec-2017)
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
                // Save to controller
                this.Status = "save";
                this.Controller.Save();
                //this.InitializeControls();
                //this.DisableControl(false);            
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.controller.ClearControls();
            this.cboCurrency.SelectedIndex = 0;
            this.DisableControl(false);           
            this.cboCurrency.Enabled = true;
            this.mtxtAccountNo.Enabled = false;
            //this.cboCurrency.Focus();//Commented by HWKO (27-Dec-2017)
            this.mtxtAccountNo.Enabled = true;// Added By AAM (31-Jan-2018)
            this.mtxtAccountNo.Focus();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        //Commented by HWKO (27-Dec-2017)
        //private void cboCurrency_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    this.mtxtAccountNo.Enabled = true;
        //    //this.mtxtAccountNo.Focus();
        //}

        private void gvCustomer_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
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

        private void butAddCustomers_Click(object sender, EventArgs e)
        {
            if (this.controller.AddCustomer())
            {
                this.BindCustomer();
            }
        }
        
        #endregion

        #region "Methods"

        public void BindJointData()
        {
            if (AccountNo.Trim() != string.Empty)
            {
                this.AccountInformation = new PFMDTO00067();
                this.AccountInformation = this.Controller.GetAccountInformation(this.AccountNo,this.TransactionStatus);
                //if (this.AccountInformation == null || this.AccountInformation.CustomerInfo==null)
                //{
                //    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00046);
                //    mtxtAccountNo.Focus();

                //}
                if(this.AccountInformation!=null && this.AccountInformation.CustomerInfo!=null)
                {                   
                    PFMDTO00001 CustInfo = this.AccountInformation.CustomerInfo.First();
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
                    this.BindDataToUI();                    
                    this.DisableControl(true);
                    //this.mtxtAccountNo.Enabled = false;  comment by ASDA
                }
            }
            else
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME90009);
                mtxtAccountNo.Focus();
            }

        }

        private void BindCurrency()
        {
            IList<CurrencyDTO> CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });

            cboCurrency.ValueMember = "Symbol";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = CurrencyList;
        }

        private void BindDataToUI()
        {
//this.pbPhoto.Image = CXClientGlobal.GetImage(AccountInformation.Photo);
            //this.pbSignature.Image = CXClientGlobal.GetImage(AccountInformation.Signature);

            this.txtMinBal.Text = AccountInformation.MiniumBalance.ToString();
            this.txtNoPersonSign.Text = AccountInformation.NoOfPersonToSign.ToString();
            if (AccountInformation.JointType == "A")
            { this.rdoTypeA.Checked = true; this.rdoTypeB.Checked = false; }
            else if(AccountInformation.JointType =="B"){ this.rdoTypeB.Checked = true; this.rdoTypeA.Checked = false; }
            //this.JoinType = AccountInformation.JointType;
            foreach (PFMDTO00001 customerDTO in AccountInformation.CustomerInfo)
            {
                oldCustomers.Add(customerDTO.CustomerId);
            }
            this.cboCurrency.Text = AccountInformation.Currency;
            this.cboCurrency.Enabled = false;
            this.BindCustomerGrid(AccountInformation.CustomerInfo);
        }

        private void BindCustomerGrid(IList<PFMDTO00001> customerInformation)
        {
            gvCustomer.DataSource = null;
            gvCustomer.AutoGenerateColumns = false;
            this.CustomerDataSource = customerInformation;
            gvCustomer.DataSource = CustomerDataSource; 
        }

        private void InitializeControls()
        {
            this.BindCurrency();
            this.gbJoint.Text = this.GetFormNameString("Information");
            this.gvCustomer.AutoGenerateColumns = false;
            this.mtxtAccountNo.Enabled = true;
            this.mtxtAccountNo.Focus();
            this.Status = string.Empty;
        }

        private void EnableDisableControls()
        {
            //ButtonEnableDisabled(newButtonEnabled,editButtonEnabled,saveButtonEnabled,deleteButtonEnabled,cancelButtonEnabled, printButtonEnabled,exitButtonEnabled);
            tsbCRUD.ButtonEnableDisabled(false, true, true, false, true, false, true);
        }     

        public void BindCustomer()
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

        private string GetFormNameString(string parameter)
        {
            switch (this.FormName)
            {
                case "Current.Joint":
                    return "Current Account Opening (Joint) " + parameter;
                //Added by HWKO (27-Dec-2017)
                case "BUSINESSLOAN.Joint":
                    return "Business Loan Account Opening (Joint) " + parameter;

                case "HIREPURCHASELOAN.Joint":
                    return "Hire Purchase Loan Account Opening (Joint) " + parameter;

                case "PERSONALLOAN.Joint":
                    return "Personal Loan Account Opening (Joint) " + parameter;

                case "DEALER.Joint":
                    return "Dealer Account Opening (Joint) " + parameter;
                //End Region

                case "Saving.Joint":
                    return "Saving Account Opening (Joint) " + parameter;

                case "Fixed.Joint":
                    return "Fixed Account Opening (Joint) " + parameter;

                default:
                    return string.Empty;
            }
        }

        public void Successful(string message, string accountCode)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message, new object[] { accountCode });
            this.cboCurrency.SelectedIndex = 0;
            this.cboCurrency.Focus();
            this.DisableControl(false);
            this.cboCurrency.Enabled = true;
        }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
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

