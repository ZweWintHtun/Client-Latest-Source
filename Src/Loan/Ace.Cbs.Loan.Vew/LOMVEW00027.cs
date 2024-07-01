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
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00027 :  BaseDockingForm , ILOMVEW00027
    {
        #region Constructor
        public LOMVEW00027()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        private ILOMCTL00027 controller;
        public ILOMCTL00027 Controller
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

        public string LoanNo
        {
            get { return txtLoanNo.Text.ToString(); }
            set { txtLoanNo.Text = value; }
        }
        public string AccountNo
        {
            get { return this.mtxtAccountNo.Text.ToString(); }
            set { this.mtxtAccountNo.Text = value; }
        }       
        public decimal CurrentBalance
        {
            get { return Convert.ToDecimal(this.txtCurrentBalance.Text); }
            set { this.txtCurrentBalance.Text = Convert.ToString(value); }
        }
        public decimal RepaymentAmount
        {
            get { return Convert.ToDecimal(this.txtRepaymentAmount.Text); }
            set { this.txtRepaymentAmount.Text = Convert.ToString(value); }
        }

        public string Status { get; set; }

        public IList<LOMDTO00013> GridViewList { get; set; }
        public IList<LOMDTO00013> legalList { get; set; }
     //  public IList<PFMDTO00072> CustomerList { get; set; }

        public ListBox CustomerList
        {
            get { return this.lstNames; }
            set { this.lstNames = value; }
        }
        #endregion

        #region Method
        public void InitializeControls()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            this.lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.txtLoanNo.Text = string.Empty;
            this.mtxtAccountNo.Text = string.Empty;
            this.txtCurrentBalance.Text = "0.00";
            this.txtRepaymentAmount.Text = "0.00";
            this.lstNames.DataSource = null;
            this.gvLoanRepayment.DataSource = null;            
            this.txtLoanNo.Focus();
            this.lstNames.Items.Clear();
        }

        public void BindNameList(string[] CustomerList)
        {
            //this.lstNames.Items.Clear();
            // if customerNames is not equal to blank.
            if (CustomerList != null)
            {
                // Bind CustomerNames into listView.
                //int i = 0;
                //while (i < CustomerList.Count)
                //{
                if (CustomerList != null)
                    //this.lstNames.Items.Add(CustomerList[i]);
                    this.lstNames.DataSource = CustomerList;
                //    i++;
                //}
            }           
        }  

        public void BindGridView(IList<LOMDTO00013> legalList)
        {            
            this.gvLoanRepayment.AutoGenerateColumns = false;
            this.gvLoanRepayment.DataSource = null;
            if (legalList.Count > 0)
                this.gvLoanRepayment.DataSource = legalList;
        }  
     
        #endregion

        #region Events

        private void txtLoanNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                e.Handled = false;
            }           
        }

        private void gvLoanRepayment_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.Controller.Save();
            if (!string.IsNullOrEmpty(this.Status))
            {
                if (this.Status.Contains("err"))
                {
                    this.txtRepaymentAmount.Focus();
                    this.Status = string.Empty;
                    return;
                }
            }
            this.InitializeControls();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.controller.ClearErrors();
        }

        private void txtLoanNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            
        }

        private void LOMVEW00027_Load(object sender, EventArgs e)
        {
            this.InitializeControls();
        }
        
        #endregion       

        private void LOMVEW00027_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
                e.Handled = true;
            }
        }    
    }
}
