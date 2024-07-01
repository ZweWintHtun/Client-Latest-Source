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
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00152 : BaseForm, IMNMVEW00152
    {
        #region Constructor
        public MNMVEW00152()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties


        public DateTime StartDate
        {
            get
            {
                return this.dtpStartDate.Value;
            }
            set
            {
                this.dtpStartDate.Text = value.ToString();
            }

        }

        public DateTime EndDate
        {
            get
            {
                return this.dtpEndDate.Value;
            }
            set
            {
                this.dtpEndDate.Text = value.ToString();
            }

        }

        public string CurrencyCode
        {
            get
            {
                if (this.cboCurrency.Text == string.Empty)
                    return string.Empty;
                else
                    return this.cboCurrency.Text;
            }
            set
            {
                this.cboCurrency.Text = value;
            }
        }


        private string status { get; set; }
        //private string formName = string.Empty;
        public string ReportFormName { get; set; }
      
        private void BindCurrency()
        {
            IList<CurrencyDTO> currencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = currencyList;
            cboCurrency.SelectedIndex = 0;
        }



        #endregion


        #region controller

        private IMNMCTL00152 controller;
        public IMNMCTL00152 Controller
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
        #region Method
     
        private string GetStatus()
        {
            if (rdoOnlyPrinciple.Checked)
            {
                status = "12";
                ReportFormName = "Fixed Auto Renewal Status Only Principle Listing";
                
            }
            else if (rdoNotAuto.Checked)
            {
                ReportFormName = "Fixed Auto Renewal Status Not Auto Renewal Listing";
                if (rdoNotAuto.Checked)
                { status = "00"; }
                else { status = "0"; }

                return status;
            }
            else if (rdoPrincipleAndInterest.Checked)
            {
                status = "11";
                ReportFormName = "Fixed Auto Renewal Status Principle And Interest Listing";
            }

            else
            {
                status = "";
                ReportFormName = "Fixed Auto Renewal All Listing";
            }

           return status;
        } 

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


        #endregion

        #region Events
        private void MNMVEW00152_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
         
            this.dtpStartDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            this.dtpEndDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            this.BindCurrency();
            //this.rdoOnlyPrinciple.Checked = true;
            this.rdoAll.Checked = true;
        }

     

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.dtpEndDate.Text = DateTime.Now.ToShortDateString();
            this.dtpStartDate.Text = DateTime.Now.ToShortDateString();
            //this.cboCurrency.Focus();
             this.rdoAll.Checked = true;
            this.controller.ClearCustomErrorMessage();
            this.cboCurrency.SelectedIndex = 0;
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            if (CheckDate())       
             this.Controller.Print(this.GetStatus());
        
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

    }
}
