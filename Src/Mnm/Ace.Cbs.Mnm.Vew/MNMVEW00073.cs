using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Mnm.Ctr.Ptr;


namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00073 : BaseForm , IMNMVEW00073
    {
        #region Constructor
        public MNMVEW00073()
        {
            InitializeComponent();
        }
        #endregion 

        #region Properties

        private string _formName = string.Empty;
        public string FormName
        {
            get { return this._formName; }
            set { this._formName = value; }
        }

        private string _parameter = string.Empty;
        public string Parameter
        {
            get { return this._parameter; }
            set { this._parameter = value; }
        }

        public DateTime StartDate
        {
            get { return dtpStartDate.Value; }
            set { dtpStartDate.Text = value.ToString(); }
        }
        public DateTime EndDate 
        {
            get { return dtpEndDate.Value; }
            set { dtpEndDate.Text = value.ToString(); }
        }

        public bool IsTransactionDate 
        {
            get 
            {
                if (rdoTransactionDate.Checked == true)
                    return true;
                else
                    return false;
            }
            set
            {
                rdoTransactionDate.Checked = value;
            }
        }

        #endregion

        #region Controller

        private IMNMCTL00073 _controller;
        public IMNMCTL00073 Controller
        {
            get
            {
                return this._controller;
            }
            set
            {
                this._controller = value;
                this._controller.View = this;
            }
        }
        #endregion

        #region Method

        private bool CheckDate()
        {    // Check dtpStartDate Date Time
            if (this.dtpStartDate.Value.Date > DateTime.Now.Date)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00129, this.dtpStartDate.Value.ToString("dd/MM/yyyy"));//Datetime cannot be greater than today date.
                this.dtpStartDate.Focus();
                return false;
            }
            // Check dtpEndDate Date Time
            else if (this.dtpEndDate.Value.Date > DateTime.Now.Date)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00130, this.dtpEndDate.Value.ToString("dd/MM/yyyy"));//Datetime cannot be greater than today date.
                this.dtpEndDate.Focus();
                return false;
            }
            else if (dtpStartDate.Value.Date > this.dtpEndDate.Value.Date)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00131);//Start Date must not be greater than End Date.
                this.dtpEndDate.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        public void IntializeControls()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.rdoTransactionDate.Checked = true;
            this.dtpStartDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            this.dtpEndDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
        }

        public string GetFormName()
        {
            string name = string.Empty;
            if (this.FormName == "Payment Order Register Listing All")
            { name = "PO Register All"; }
            else if (this.FormName == "Payment Order Register Listing By Cash")
            { name = "PO Register By Cash"; }
            else if (this.FormName == "Payment Order Register Listing By Transfer")
            { name = "PO Register By Transfer"; }
            else if (this.FormName == "Payment Order Withdrawal All")
            { name = "PO Withdrawal All"; }
            else if (this.FormName == "Payment Order Withdrawal By Cash")
            { name = "PO Withdrawal By Cash"; }
            else if (this.FormName == "Payment Order Withdrawal By Transfer")
            { name = "PO Withdrawal By Transfer"; }
            else if (this.FormName == "Internal Remittance Register")
            { name = "IR Register"; }
            else if (this.FormName == "Internal Remittance Withdrawal All")
            { name = "IR Withdrwal All"; }
            else if (this.FormName == "Internal Remittance Withdrawal By Cash")
            { name = "IR Withdrawal By Cash"; }
            else if (this.FormName == "Internal Remittance Withdrawal By Transfer")
            { name = "IR Withdrawal By Transfer"; }
            return name;
        }

        #endregion

        #region Events
        private void MNMVEW00073_Load(object sender, EventArgs e)
        {
            this.IntializeControls();
            this.Text = this.GetFormName();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            if (CheckDate())
                this.Controller.Print();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.IntializeControls();
        }

        #endregion
    }
}
