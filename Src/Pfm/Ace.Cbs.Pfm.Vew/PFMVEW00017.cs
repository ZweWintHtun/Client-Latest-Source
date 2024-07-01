using System;
using System.Collections.Generic;
using System.Drawing;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.PTR;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Pfm.Vew
{
    public partial class frmPFMVEW00017 : BaseDockingForm, IPFMVEW00017
    {
        public string TransactionStatus {get;set;}
        private bool isValid;

        public frmPFMVEW00017(string screenName)
        {
            InitializeComponent();
            this.TransactionStatus = screenName;
            this.Text = this.TransactionStatus + " Printing Enquiry";
            this.IndividualDTO = new PFMDTO00060();
            this.CustomerIdDTO = new PFMDTO00001();
        }

        #region"Properties"
        public string CustomerId
        {
            get { return this.mtxtCustomerID.Text; }
            set { this.mtxtCustomerID.Text = value; }
        }
        public string NameofFirm
        {
            get { return this.txtNameoffirm.Text; }
            set { this.txtNameoffirm.Text = value; }
        }
        public string FatherName
        {
            get { return this.txtFathersName.Text; }
            set { this.txtFathersName.Text = value; }
        }
        public string Address
        {
            get { return this.txtAddress.Text; }
            set { this.txtAddress.Text = value; }
        }
        public string Occupation
        {
            get { return this.txtOccupation.Text; }
            set { this.txtOccupation.Text = value; }
        }
        public string Nationality
        {
            get { return this.txtNationality.Text; }
            set { this.txtNationality.Text = value; }
        }
        public string NRC
        {
            get { return this.txtNRC.Text; }
            set { this.txtNRC.Text = value; }
        }
        public string IntroducedBy
        {
            get { return this.txtIntroducedBy.Text; }
            set { this.txtIntroducedBy.Text = value; }
        }
        public string Phone
        {
            get { return this.txtPhone.Text; }
            set { this.txtPhone.Text = value; }
        }
        
        public string city
        {
            get { return this.txtCity.Text; }
            set { this.txtCity.Text = value; }
        }
        public string state
        {
            get { return this.txtState.Text; }
            set { this.txtState.Text = value; }
        }

        public string EMail
        {
            get { return this.txtEmail.Text; }
            set { this.txtEmail.Text = value; }
        }

        public string townshipcode
        {
            get { return this.txtTownship.Text; }
            set { this.txtTownship.Text = value; }
        }

        public string BankName {get;set;}
        //{
        //    get { return this.BankName; }
        //    set { CXClientGlobal.GetConfigurationValue("BankName"); }
        //} commented by YMA

        public string BranchName{get;set;}
        //{
        //    get { return this.BranchName; }
        //    set { CXClientGlobal.GetConfigurationValue("BranchName"); }
        //} commented by YMA

        public string Fax
        {
            get { return this.txtFax.Text; }
            set { this.txtFax.Text = value; }
        }

        public string Currency
        {
            get
            {
                if (!this.cboCurrency.SelectedIndex.Equals(-1))
                    return this.cboCurrency.SelectedValue.ToString();
                return null;
            }
            set
            {
                if (value != null)
                    this.cboCurrency.SelectedValue = value;
                else this.cboCurrency.SelectedIndex = 0;
            }
        }
        
        public string CurrencyCode
        {
            get
            {
                if (!this.cboCurrency.SelectedIndex.Equals(-1))
                    return this.cboCurrency.Text;
                return null;
            }
            set
            {
                if (value != null)
                    this.cboCurrency.Text = value;
                else this.cboCurrency.SelectedIndex = 0;
            }
        }


        public DateTime DateOfBirth
        {
            get { return this.dtpDateOfBirth.Value; }
            set { this.dtpDateOfBirth.Value = value; }
        }

        public string GuardianName
        {
            get { return this.txtGuardianshipName.Text; }
            set { this.txtGuardianshipName.Text = value; }
        }

        public string GuardianNRC
        {
            get { return this.mtxtFatherGuardianshipNRC.Text; }
            set { this.mtxtFatherGuardianshipNRC.Text = value; }
        }

        public Image Photo
        {
            get { return this.picPhoto.Image; }
            set { this.picPhoto.Image = value; }
        }

        public string FullAddress
        {
            get;
            set;
        }

        public Image Signature
        {
            get { return this.picSignature.Image; }
            set { this.picSignature.Image = value; }
        }

        #endregion

        #region "DTOs"

        private PFMDTO00060 individualDTO;
        public PFMDTO00060 IndividualDTO
        {
            get { return this.individualDTO; }
            set { this.individualDTO = value; }
        }

        private PFMDTO00001 customerIdDTO;
        public PFMDTO00001 CustomerIdDTO
        {
            get { return this.customerIdDTO; }
            set { this.customerIdDTO = value; }
        }

        #endregion

        #region"Controller"

        private IPFMCTL00017 individualController;
        public IPFMCTL00017 IndividualPrintingController
        {
            get
            {
                return this.individualController;
            }
            set
            {
                this.individualController = value;
                this.individualController.View = this;
            }
        }

        #endregion

        #region "Events"

        private void PFMVEW00017_Load(object sender, EventArgs e)
        {
            this.mtxtCustomerID.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CustomerNoDisplayFormat);
            this.EnableDisableControls("FormLoad");
            this.gpAccountInformation.Text = this.TransactionStatus + " Information";
            this.mtxtCustomerID.Clear();
            this.InitializeControls();
            this.mtxtCustomerID.Focus();
        }

        private void cxcliC0011_CancelButtonClick(object sender, EventArgs e)
        {
            IndividualPrintingController.ClearControls();
            this.EnableDisableControls("AfterCancel");
            this.mtxtCustomerID.ReadOnly = false;
            cboCurrency.SelectedIndex = 0;
            this.mtxtCustomerID.Focus();
            this.IndividualPrintingController.ClearErrors();
        }

        private void cxcliC0011_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cxcliC0011_PrintButtonClick(object sender, EventArgs e)
        {
            IndividualPrintingController.PrintData(TransactionStatus);
            this.mtxtCustomerID.ReadOnly = false;
            cboCurrency.SelectedIndex = 0;
        }

        private void butAddCustomer_Click(object sender, EventArgs e)
        {
            //this.CustomerIdDTO = individualController.GetCustomerData();
            //if (this.CustomerIdDTO != null)
            //{
            //    this.EnableDisableControls();
            //    this.mtxtCustomerID.ReadOnly = true;
            //    //if (this.TransactionStatus != "Saving Account (Minor)")
            //    //{
            //    //    this.txtIntroducedBy.Focus();
            //    //}
            //    //else
            //    //    this.cboCurrency.Focus();
            //}
        }

        #endregion

        #region "Methods"

        public void InitializeControls()
        {
            this.BindComboBox();
           
        }

        private void EnableDisableControls(string param = "")
        {
            this.mtxtCustomerID.Enabled = true;
            this.txtNameoffirm.Enabled = false;
            this.dtpDateOfBirth.Enabled = false;
            this.txtOccupation.Enabled = false;
            this.txtEmail.Enabled = false;
            this.txtAddress.Enabled = false;
            this.txtCity.Enabled = false;
            this.txtNationality.Enabled = false;
            this.txtIntroducedBy.Enabled = true;
            this.picPhoto.Enabled = false;
            this.butAddCustomer.Enabled = true;
            this.cboCurrency.Enabled = true;
            this.txtFathersName.Enabled = false;
            this.txtNRC.Enabled = false;
            this.txtPhone.Enabled = false;
            this.txtFax.Enabled = false;
            this.txtTownship.Enabled = false;
            this.txtState.Enabled = false;
            this.picSignature.Enabled = false;
            this.mtxtFatherGuardianshipNRC.Enabled = false;
            this.txtGuardianshipName.Enabled = false;            
            
            if (param == "FormLoad" || param == "AfterCancel")
            {
                this.cxcliC0011.ButtonEnableDisabled(false, false, false, false, false, false, true);
            }
            if (param == "")
            {
                this.cxcliC0011.ButtonEnableDisabled(false, false, false, false, true, true, true);
            }

            if (this.TransactionStatus != "Saving Account (Minor)")
            {
                this.lblFatherGuardianshipNRC.Visible = false;
                this.lblGuardianshipName.Visible = false;
                this.mtxtFatherGuardianshipNRC.Visible = false;
                this.txtGuardianshipName.Visible = false;                
            }
            else 
            {
                this.lblNRC.Visible = false;
                this.txtNRC.Visible = false;
                this.lblIntroducedBy.Visible = false;
                this.txtIntroducedBy.Visible = false;
            }
        }

        private void BindComboBox()
        {
            IList<CurrencyDTO> CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Symbol";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = CurrencyList;
            cboCurrency.SelectedIndex = 0;
        }

        public void CheckValidCustomer(bool isValid)
        {
            this.isValid = isValid;
            this.EnableDisableControls();
        }
        #endregion        

        private void butAddCustomer_Click_1(object sender, EventArgs e)
        {
            this.CustomerIdDTO = individualController.GetCustomerData();
            if (this.CustomerIdDTO != null)
            {
                this.EnableDisableControls();
                this.mtxtCustomerID.ReadOnly = true;
                //if (this.TransactionStatus != "Saving Account (Minor)")
                //{
                //    this.txtIntroducedBy.Focus();
                //}
                //else
                //    this.cboCurrency.Focus();
            }
        }
    }
}