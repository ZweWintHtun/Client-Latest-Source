using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Cle;

namespace Ace.Cbs.Tcm.Vew
{
    public partial class TCMVEW00009 : BaseForm,ITCMVEW00009
    {
        #region Constructor
        public TCMVEW00009()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        public string AccountNo
        {
            get { return this.mtxtAccountNo.Text; }
            set { this.mtxtAccountNo.Text = value; }
        }

        public string LoansNo
        {
            get { return this.txtLoansNo.Text; }
            set { this.txtLoansNo.Text = value; }
        }
        
        public decimal OverdraftLimit
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtOverdraftLimit.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtOverdraftLimit.Text = value.ToString(); }
        }

        public string LastCalculateDate
        {
            get { return this.txtLastCalculateDate.Text; }
            set { this.txtLastCalculateDate.Text = value; }
        }

        public decimal Rate
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtRate.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtRate.Text = value.ToString(); }
        }

        public decimal InterestOfLastDate
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtInterestOfLastDate.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtInterestOfLastDate.Text = value.ToString(); }
        }

        public decimal InterestMonth1
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtInterestMonth1.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtInterestMonth1.Text = value.ToString(); }
        }

        public decimal InterestMonth2
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtInterestMonth2.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtInterestMonth2.Text = value.ToString(); }
        }

        public decimal InterestMonth3
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtInterestMonth3.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtInterestMonth3.Text = value.ToString(); }
        }


        public decimal InterestTotal
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtInterestTotal.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtInterestTotal.Text = value.ToString(); }
        }

        private string parentFormId = string.Empty;
        public string ParentFormId
        {
            get { return this.parentFormId; }
            set { this.parentFormId = value; }
        }

        private string formName = string.Empty;
        public string FormName
        {
            get { return this.formName; }
            set { this.formName = value; }
        }
      public  bool isValidate { get; set; }

        public string Month1 { get; set; }
        public string Month2 { get; set; }
        public string Month3 { get; set; }

        public string LabelTotalInterest
        {
            get { return this.lblTotal.Text; }
            set { this.lblTotal.Text = value; }
        }

        #endregion

        #region Controller
        private ITCMCTL00009 controller;
        public ITCMCTL00009 Controller
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
        #endregion       

        #region Methods
        public string GetFormName()
        {
            string name = string.Empty;
            if (this.FormName == "OverdraftInterest")
            {
                name = "Overdraft Interest Editing";
            }
            else if (this.FormName == "CommitmentFees")
            {
                name = "Commitment Fees Editing";
            }
            else if (this.FormName == "TODExtraCharges")
            {
                name = "TOD Extra Charges Editing";
            }
            else if (this.FormName == "TODServiceCharges")
            {
                name = "TOD Service Charges Editing";
            }
            return name;
        }

       

        private void EnableDisableControls()
        {
            tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
        }

        private void InitializeControls()
        {
            this.isValidate = true;
            //this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            this.EnableControls();
           // this.mtxtAccountNo.Focus();
            this.txtLoansNo.Focus();
            this.mtxtAccountNo.Enabled = false;
        }

        public void GetMonth(string formName)
        {
            DateTime todayDate = DateTime.Now;
            int month = todayDate.Month;
            string year = todayDate.Year.ToString();

            if (month == 4 || month == 5 || month == 6)
            {
                this.lblMonth1.Text = "April / " + year ;
                this.lblMonth2.Text = "May / " + year;
                this.lblMonth3.Text = "June / " + year;
                this.Month1 = (formName == "TODExtraCharges") ? "S1" : "M1";
                this.Month2 = (formName == "TODExtraCharges") ? "S2" : "M2";
                this.Month3 = (formName == "TODExtraCharges") ? "S3" : "M3";
            }
            else if (month == 7 || month == 8 || month == 9)
            {
                this.lblMonth1.Text = "July / " + year;
                this.lblMonth2.Text = "August / " + year;
                this.lblMonth3.Text = "September / " + year;
                this.Month1 = (formName == "TODExtraCharges") ? "S4" : "M4";
                this.Month2 = (formName == "TODExtraCharges") ? "S5" : "M5";
                this.Month3 = (formName == "TODExtraCharges") ? "S6" : "M6";
            }
            else if (month == 10 || month == 11 || month == 12)
            {
                this.lblMonth1.Text = "October / " + year;
                this.lblMonth2.Text = "November / " + year;
                this.lblMonth3.Text = "December / " + year;
                this.Month1 = (formName == "TODExtraCharges") ? "S7" : "M7";
                this.Month2 = (formName == "TODExtraCharges") ? "S8" : "M8";
                this.Month3 = (formName == "TODExtraCharges") ? "S9" : "M9";
            }
            else if (month == 1 || month == 2 || month == 3)
            {
                this.lblMonth1.Text = "January / " + year;
                this.lblMonth2.Text = "Febuary / " + year;
                this.lblMonth3.Text = "March / " + year;
                this.Month1 = (formName == "TODExtraCharges") ? "S10" : "M10";
                this.Month2 = (formName == "TODExtraCharges") ? "S11" : "M11";
                this.Month3 = (formName == "TODExtraCharges") ? "S12" : "M12";
            }
            this.ShowLabel();
            //this.LabelTotalInterest = "Total Interest Up to    /  /   ";
        }

        public void Successful(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
         //   this.Controller.ClearControls();
            this.EnableControls();
            this.ShowLabel();
            this.isValidate = true;
            
        }

        public void ShowLabel()
        { this.LabelTotalInterest = "Total Interest Up to    /  /   "; }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }

        public void EnableControls()
        {
            this.EnableControls("InterestEdit.Enable");
        }

        public void DisableControls()
        {
            this.DisableControls("InterestEdit.Disable");
        }

        public void SetFocus()
        {
            this.txtInterestOfLastDate.Focus();
        }

        #endregion

        private void TCMVEW00009_Load(object sender, EventArgs e)
        {
            this.EnableDisableControls();
            this.InitializeControls();
            this.Text = GetFormName();
            this.GetMonth(this.formName);
            this.txtDateTime.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        }

        public void ClearControls()
        {
            this.mtxtAccountNo.Text = string.Empty;
           // this.txtLoansNo.Text = string.Empty;
            
            this.txtLastCalculateDate.Text = string.Empty;
            this.txtOverdraftLimit.Text = "0.00";
            this.txtRate.Text = "0.00";
            this.txtInterestOfLastDate.Text = "0.00";
            this.txtInterestMonth1.Text = "0.00";
            this.txtInterestMonth2.Text = "0.00";
            this.txtInterestMonth3.Text = "0.00";
            this.txtInterestTotal.Text = "0.00";
            this.ShowLabel();
            this.txtLoansNo.Focus();
            }

        public void ClearFormControls()
        {
            this.mtxtAccountNo.Text = string.Empty;
            this.txtLoansNo.Text = string.Empty;

            this.txtLastCalculateDate.Text = string.Empty;
            this.txtOverdraftLimit.Text = "0.00";
            this.txtRate.Text = "0.00";
            this.txtInterestOfLastDate.Text = "0.00";
            this.txtInterestMonth1.Text = "0.00";
            this.txtInterestMonth2.Text = "0.00";
            this.txtInterestMonth3.Text = "0.00";
            this.txtInterestTotal.Text = "0.00";
            this.lblTotal.Text = string.Empty;
            this.txtLoansNo.Focus();
            this.ShowLabel();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.controller.ClearCustomErrorMessage();
             this.ClearControls();
             this.txtLoansNo.Text = string.Empty;
          
            this.ShowLabel();
           
            isValidate = true;
            
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.isValidate = false;
            this.controller.Save();
        }

        private void TCMVEW00009_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

        private void txtInterestMonth1_Leave(object sender, EventArgs e)
        {
            txtInterestTotal.Text = (InterestMonth1 + InterestMonth2 + InterestMonth3).ToString();
        }

        private void txtInterestMonth2_Leave(object sender, EventArgs e)
        {
            txtInterestTotal.Text = (InterestMonth1 + InterestMonth2 + InterestMonth3).ToString();
        }

        private void txtInterestMonth3_Leave(object sender, EventArgs e)
        {
            txtInterestTotal.Text = (InterestMonth1 + InterestMonth2 + InterestMonth3).ToString();
        }

        private void TCMVEW00009_KeyDown(object sender, KeyEventArgs e)
       {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return) || (e.KeyCode == Keys.Tab))
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
                e.Handled = true;
            }
        }

        private void txtLoansNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            
        }

      

    }
}
