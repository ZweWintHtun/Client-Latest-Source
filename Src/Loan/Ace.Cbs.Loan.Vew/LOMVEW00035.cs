using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00035 : BaseForm, ILOMVEW00035
    {
        #region Constructor
        public LOMVEW00035()
        {
            InitializeComponent();
        }

        public LOMVEW00035(string typeName)
        {
            if(!String.IsNullOrEmpty(typeName))
            {
                switch (typeName)
                {
                    case "Land and Building":
                        this.ParentFormName = "LB";
                        break;
                    case "Personal Guarantee":
                        this.ParentFormName = "PG";
                        break;
                    case "Pledge":
                        this.ParentFormName = "PL";
                        break;
                    case "Hypothecation":
                        this.ParentFormName = "HP";
                        break;
                    case "Gold and Jewellery":
                        this.ParentFormName = "GJ";
                        break;
                    case "All":
                        this.ParentFormName = "All";
                        break;
                }
            }            
            InitializeComponent();
        }
        #endregion

        #region Properties
        public DateTime StartDate
        {
            get { return this.dtpStartDate.Value; }
            set { this.dtpStartDate.Text = value.ToString(); }
        }

        public DateTime EndDate
        {
            get { return this.dtpEndDate.Value; }
            set { this.dtpEndDate.Text = value.ToString(); }
        }

        public string SourceBranch
        {
            get
            {
                if (this.cboBranch.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cboBranch.SelectedValue.ToString();
                }

            }
            set { this.cboBranch.SelectedValue = value; }
        }

        public string Currency
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

        private string parentFormName = string.Empty;
        public string ParentFormName
        {
            get { return this.parentFormName; }
            set { this.parentFormName = value; }
        }
        #endregion

        #region Controller
        private ILOMCTL00035 controller;
        public ILOMCTL00035 Controller
        {
            get { return controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }
        #endregion

        #region Method
        #region Initialize
        private void InitailizeControl()
        {
            this.dtpStartDate.Value = DateTime.Now;
            this.dtpEndDate.Value = DateTime.Now;
            this.BindCurrency();
            this.BindSourceBranch();
            this.dtpStartDate.Focus();
            // this.controller.ClearErrors();
        }
        #endregion

        #region BindComboBox

        private void BindCurrency()
        {
            IList<CurrencyDTO> CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = CurrencyList;
            cboCurrency.SelectedIndex = 0;
        }
        
        private void BindSourceBranch()
        {
            IList<BranchDTO> BranchList = CXCLE00002.Instance.GetListObject<BranchDTO>("Branch.Client.SelectNotOtherBank", new object[] { false });

            cboBranch.ValueMember = "BranchCode";
            cboBranch.DisplayMember = "BranchCode";
            cboBranch.DataSource = BranchList;
            cboBranch.SelectedIndex = -1;
        }
        #endregion        
        #endregion

        #region Events
        private void LOMVEW00035_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            switch (this.ParentFormName)
            {
                case "LB":
                    this.Text = "Overdraft Registration Listing (Lands and Building)";
                    break;
                case "PG":
                    this.Text = "Overdraft Registration Listing (Personal Guarantee)";
                    break;
                case "PL":
                    this.Text = "Overdraft Registration Listing (Pledge)";
                    break;
                case "HP":
                    this.Text = "Overdraft Registration Listing (Hypothecation)";
                    break;
                case "GJ":
                    this.Text = "Overdraft Registration Listing (Gold and Jewellery)";
                    break;
                case "All":
                    this.Text = "Overdraft Registration Listing (All)";
                    break;
            }
            this.InitailizeControl();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            this.controller.Print();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitailizeControl();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion        
        
    }
}
