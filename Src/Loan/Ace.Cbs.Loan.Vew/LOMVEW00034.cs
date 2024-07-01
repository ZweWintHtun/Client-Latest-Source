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
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00034 : BaseForm, ILOMVEW00034
    {
        #region variables
        string loans;
        string formname;
        #endregion

        private ILOMCTL00034 controller;
        public ILOMCTL00034 Controller
        {
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
            get
            {
                return this.controller;
            }
        }
        #region Constructor
        public LOMVEW00034()
        {
            InitializeComponent();
        }
        public LOMVEW00034(string formName,string bLType)
        {
            InitializeComponent();
            this.formname = formName;
            this.LoanType = bLType;
        }
        public LOMVEW00034(string bLType)
        {
            InitializeComponent();
            this.LoanType = bLType;
        }
        //public string FormName
        //{
        //    get { return this.formname; }
        //}
        public string TransactionStatus
        {
            get { return this.LoanType; }
        }
        public string LoanType;
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
            set { this.cboBranch.SelectedValue = value.ToString(); }
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
        //private string parentFormName = string.Empty;
        //public string ParentFormName
        //{
        //    get { return this.parentFormName; }
        //    set { this.parentFormName = value; }
        //}
        #endregion  

        #region Controller     
       
      
        #endregion

        #region Methods
        #region Initialize
        private void InitailizeControl()
        {
            this.dtpStartDate.Value = DateTime.Now;
            this.dtpEndDate.Value = DateTime.Now;
            this.BindCurrency();
            this.BindSourceBranch();            
            this.dtpStartDate.Focus();
            this.SourceBranch = CurrentUserEntity.BranchCode;
            if (!CurrentUserEntity.IsHOUser)
            {
                this.cboBranch.Enabled = false;
            }
            else
            {
                this.cboBranch.Enabled = true;
            }
        }       
        private void BindSourceBranch()
        {
            IList<BranchDTO> BranchList = CXCLE00002.Instance.GetListObject<BranchDTO>("Branch.Client.SelectNotOtherBank", new object[] { false });

            cboBranch.ValueMember = "BranchCode";
            cboBranch.DisplayMember = "BranchCode";
            cboBranch.DataSource = BranchList;
            cboBranch.SelectedIndex = 0;
        }
        private void BindCurrency()
        {
            IList<CurrencyDTO> CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = CurrencyList;
            cboCurrency.SelectedIndex = 0;
        }
        #endregion
        #endregion

        #region Events
        private void LOMVEW00034_Load(object sender, EventArgs e)
        {
            //if (this.formname == "All")
            //{
            //    this.FormName = "Loan Registration Listing(All)";
            //    loans = "All";
            //}
            //else if (this.formname == "Land and Building")
            //{
            //    this.FormName = "Loan Registration Listing(Land and Building)";
            //    loans = "LB";
            //}
            //else if (this.formname == "Personal Guarantee")
            //{
            //    this.FormName = "Loan Listing(Personal Guarantee)";
            //    loans = "PG";
            //}
            //else if (this.formname == "Pledge")
            //{
            //    this.FormName = "Loan Registration Listing(Pledge)";
            //    loans = "PL";
            //}
            //else if (this.formname == "Hypothecation")
            //{
            //    this.FormName = "Loan Registration Listing(Hypothecation)";
            //    loans = "HP";
            //}
            //else if (this.formname == "Gold And Jwelly")
            //{
            //    this.FormName = "Loan Registration Listing(Gold & Jewellery)";
            //    loans = "GJ";
            //}
            //else if (this.formname == "Personal Guarantee")
            //{
            //    this.FormName = "Loan Registration Listing(Personal Guarantee)";
            //    loans = "PG";
            //}
            //else 
            //{
            //    this.FormName = "Loan Registration Listing(CNG)";
            //    loans = "CG";
            //}

            this.FormName = "Business Loans Information Listing For " + this.LoanType;
            this.Text = this.FormName;
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            //this.cboCurrency.SelectedIndex = 0;
            //this.cboBranch.SelectedIndex = 0;
            this.InitailizeControl();
        }
        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            if (this.CheckDate())
            {
                try
                {
                    this.controller.Print(LoanType, this.FormName);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00123");
            }
        }
        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitailizeControl();
        }
        private bool CheckDate()
        {
            bool date = CXCOM00006.Instance.IsValidStartDateEndDate(this.dtpStartDate.Value, this.dtpEndDate.Value);
            if (date == false)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00131");//Start Date must not be greater than End Date.
            }
            return date;
        }
        #endregion 
    }
}
