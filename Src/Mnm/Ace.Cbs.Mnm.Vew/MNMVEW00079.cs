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
    public partial class MNMVEW00079 : BaseForm, IMNMVEW00079
    {
        #region Constructor
        public MNMVEW00079()
        {
            InitializeComponent();
        }
        #endregion


        #region Properties

        private string formName = string.Empty;
        public string FormName
        {
            get { return this.formName; }
            set { this.formName = value; }
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

        #endregion
        private IMNMCTL00079 controller;
        public IMNMCTL00079 Controller
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
        #region Controller

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
           
            this.dtpStartDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            this.dtpEndDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
        }

        public string GetFormName()
        {
            string name = string.Empty;
            if (this.FormName == "PO Withdrawl(Encash) By Cash Listing")
            { name = "PO Withdrawl(Encash) By Cash Listing"; }

            else if (this.FormName == "PO Withdrawl(Encash) By Transfer Listing")
            { name = "PO Withdrawl(Encash) By Transfer Listing"; }

            else if (this.FormName == "PO Withdrawl(Encash) All Listing")
            { name = "PO Withdrawl(Encash) All Listing"; }

          
            return name;
        }

        #endregion

        private void MNMVEW00079_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.IntializeControls();
            this.Text = this.GetFormName();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.IntializeControls();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            if (CheckDate())
              this.Controller.Print();
        }


    }
}
