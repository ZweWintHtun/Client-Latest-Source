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

namespace Ace.Cbs.Pfm.Vew
{
    /// <summary>
    /// Opening Form Printing >> Joint Printing Form
    /// </summary>
    public partial class PFMVEW00018 : BaseDockingForm,IPFMVEW00018
    {
        #region Constructor
        public PFMVEW00018()
        {
            InitializeComponent();
        }

        public PFMVEW00018(string transactionStatus)
        {
            InitializeComponent();
            this.transactionStatus = transactionStatus;
            this.Text = this.transactionStatus + " Printing Enquiry";            
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
                    return this.cboCurrency.Text.ToString();
                }
            }
            set
            {
                this.cboCurrency.Text = value;
                this.cboCurrency.SelectedValue = value;
            }
        }

        public string IntroducedBy
        {
             get { return this.txtIntroducedBy.Text; }
            set { this.txtIntroducedBy.Text = value; }
        }

        public int NoOfPersonSign
        {
            get
            {
                return Convert.ToInt32(this.txtNoPersonSign.Value);
            }
            set { this.txtNoPersonSign.Text = value.ToString(); }
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
                    this.rdoTypeA.Checked = true;
                else
                    this.rdoTypeB.Checked = true;
            }
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

        #region Controller

        private IPFMCTL00018 controller;
        public IPFMCTL00018 Controller
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

        #region Events

        private void PFMVEW00018_Load(object sender, EventArgs e)
        {
            this.EnableDisableControls();
            this.BindComboBoxes();
            this.InitializeControls();
        }       

        private void cxcliC0011_CancelButtonClick(object sender, EventArgs e)
        {
            this.controller.ClearControls();
            this.BindCustomer();
            this.Controller.ClearErrors();
        }

        private void cxcliC0011_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cxcliC0011_PrintButtonClick(object sender, EventArgs e)
        {
            this.controller.Print();
        }

        private void butAddCustomers_Click(object sender, EventArgs e)
        {
            if (this.controller.AddCustomer())
            {
                this.BindCustomer();
            }
            if (this.CustomerDataSource.Count >= 4) this.butAddCustomers.Enabled = false;
        }

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
                if (e.ColumnIndex == 4)
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
                else if (customerResult != null)
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
        }
        
        #endregion

        #region Helper Methods
        private void EnableDisableControls()
        {
            this.cxcliC0011.ButtonEnableDisabled(false, false, false, false, true, true, true);
        }

        private void InitializeControls()
        {
            this.cboCurrency.SelectedIndex = 0;
            this.controller.ClearControls();
            this.gbAccountJointInformation.Text = this.transactionStatus + " Information";
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
            int GridRowsCount = Convert.ToInt32(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.MaxCustInGridComp));
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
        #endregion
    }
}