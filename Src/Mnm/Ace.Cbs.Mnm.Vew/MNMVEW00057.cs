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
using Ace.Cbs.Mnm.Ctr.Ptr;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00057 : BaseForm, IMNMVEW00057
    {
        #region Constructor
        public MNMVEW00057()
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
            get { return this.dtpStartDate.Value; }
            set { this.dtpStartDate.Text = value.ToString(); }
             
        }

        public DateTime EndDate
        {
            get { return this.dtpEndDate.Value; }
            set { this.dtpEndDate.Text = value.ToString(); } 
        }
        public string AccountSign;

        #endregion

        #region Controller

        private IMNMCTL00057 controller;
        public IMNMCTL00057 Controller
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

        #region Event
        private void MNMVEW00057_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.InitialControls();
            this.Text = this.FormName;
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            try
            {
                //if (this.Controller.Validate_Form())
                //{
                    //this.CheckDate();
                    // Check dtpStartDate Date Time
                    if (this.dtpStartDate.Value.Date > DateTime.Now.Date)
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00129, this.dtpStartDate.Value.ToString("dd/MM/yyyy"));//Datetime cannot be greater than today date.
                        this.dtpStartDate.Focus();
                        return;
                    }

                    // Check dtpEndDate Date Time
                    else if (this.dtpEndDate.Value.Date > DateTime.Now.Date)
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00130, this.dtpEndDate.Value.ToString("dd/MM/yyyy"));//Datetime cannot be greater than today date.
                        this.dtpEndDate.Focus();
                        return;
                    }

                    else if (this.dtpStartDate.Value.Date > this.dtpEndDate.Value.Date)
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00131);//Start Date must not be greater than End Date.
                        this.dtpEndDate.Focus();
                        return;
                    }
                    //return true;
                    this.Controller.Print(); 
               // }
            }
            catch (Exception ex)
            {
                throw new Exception(CXMessage.ME90043, ex);   //Unexpected Error Occurs
            }
            
        }


        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitialControls();
            this.controller.ClearCustomErrorMessage();
        }

        private void InitialControls()
        {
            this.dtpStartDate.Text = DateTime.Now.ToShortDateString();
            this.dtpEndDate.Text = DateTime.Now.ToShortDateString();
        }
        #endregion

        #region CheckDate

        public bool CheckDate()
        {
            // Check dtpStartDate Date Time
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

            else if (this.dtpStartDate.Value.Date > this.dtpEndDate.Value.Date)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00131);//Start Date must not be greater than End Date.
                this.dtpEndDate.Focus();
                return false;
            }            
            return true;
        }
        #endregion    

       
      }
}
