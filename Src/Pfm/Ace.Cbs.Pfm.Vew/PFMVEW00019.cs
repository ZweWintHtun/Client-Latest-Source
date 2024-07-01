using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.PTR;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;

namespace Ace.Cbs.Pfm.Vew
{
    public partial class frmPFMVEW00019 : BaseDockingForm, IPFMVEW00019
    {
        #region Constructor
        public frmPFMVEW00019()
        {
            InitializeComponent();
        }

        public frmPFMVEW00019(string transactionStatus)
        {
            InitializeComponent();
            this.transactionStatus = transactionStatus;
            this.Text = this.transactionStatus + " Printing Enquiry";
            this.gbCompany.Text = this.transactionStatus + " Information";
        }
        #endregion

        #region Properties
        private string transactionStatus;
        public string TransactionStatus
        {
            get { return this.transactionStatus; }
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
                    return this.cboCurrency.Text;
                }
            }
            set
            {
                this.cboCurrency.Text = value;
                this.cboCurrency.SelectedValue = value.ToString();
            }
        }

        public string NameOfFirm
        {
            get { return this.txtNameOfFirm.Text.ToString(); }
            set { this.txtNameOfFirm.Text = value; }
        }

        public string Email
        {
            get { return this.txtEmail.Text.ToString(); }
            set { this.txtEmail.Text = value; }
        }

        public string Address
        {
            get { return this.txtAddress.Text.ToString(); }
            set { this.txtAddress.Text = value; }
        }

        public string CityCode
        {
            get
            {
                if (this.cboCity.Text == null)
                {
                    return null;
                }
                else
                {
                    return this.cboCity.Text;
                }
            }
            set
            {
                this.cboCity.Text = value;
                this.cboCity.SelectedValue = value.ToString();
            }
        }

        public string IntroducedBy
        {
            get { return this.txtIntroducedBy.Text; }
            set { this.txtIntroducedBy.Text = value; }
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
                if (this.cboTownship.Text == null)
                {
                    return null;
                }
                else
                {
                    return this.cboTownship.Text;
                }
            }
            set 
            {
                this.cboTownship.Text = value;
                this.cboTownship.SelectedValue = value.ToString() ; 
            }
        }

        public string StateCode
        {
            get
            {
                if (this.cboState.Text == null)
                {
                    return null;
                }
                else
                {
                    return this.cboState.Text;
                }
            }
            set 
            {
                this.cboState.Text = value;
                this.cboState.SelectedValue = value.ToString(); 
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

        private IPFMCTL00019 controller;
        public IPFMCTL00019 Controller
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

        private IList<PFMDTO00001> customerDataSource;
        public IList<PFMDTO00001> CustomerDataSource
        {
            get { return this.customerDataSource; }
            set
            {
                this.customerDataSource = value;
            }
        }
        #endregion

        #region Events
        private void butAddCustomer_Click(object sender, EventArgs e)
        {
            if (this.controller.AddCustomer())
            {
                BindCustomer();
            }
        }

        private void cxcliC0011_CancelButtonClick(object sender, EventArgs e)
        {
            this.controller.ClearControls();
            this.cboCurrency.Focus();
            this.Controller.ClearErrors();
        }

        private void cxcliC0011_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPFMVEW00019_Load(object sender, EventArgs e)
        {
            this.EnableDisableControls();
            this.BindComboBoxes();            
            this.controller.ClearControls();
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
                    // Are you sure want to delete?
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

        private void cxcliC0011_PrintButtonClick(object sender, EventArgs e)
        {
            this.controller.PrintData();
        }


        private void txtNameOfFirm_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        //private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    e.KeyChar = char.ToUpper(e.KeyChar);
        //}

        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtIntroducedBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        #endregion

        #region Helper Methods
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

        private void EnableDisableControls()
        {
            cxcliC0011.ButtonEnableDisabled(false,false,false,false,true,true,true);
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
            cboCity.SelectedIndex = -1;

            cboState.ValueMember = "StateCode";
            cboState.DisplayMember = "Description";
            cboState.DataSource = StateCodeList;
            cboState.SelectedIndex = -1;

            cboTownship.ValueMember = "TownshipCode";
            cboTownship.DisplayMember = "Description";
            cboTownship.DataSource = TownshipCodeList;
            cboTownship.SelectedIndex = -1;

            cboCurrency.ValueMember = "Symbol";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = CurrencyList;
            cboCurrency.SelectedIndex = 0;
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
    }
}
