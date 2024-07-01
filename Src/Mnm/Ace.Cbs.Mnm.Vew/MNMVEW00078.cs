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
    public partial class MNMVEW00078 : BaseForm, IMNMVEW00078
    
    {  
        #region Constructor

        public MNMVEW00078()
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

        //public string CurrencyCode
        //{
        //    get { return this.CurrencyCode; }
        //    set { this.CurrencyCode = value; }
        //}


        public DateTime EndDate
        {
            get { return this.dtpEndDate.Value; }
            set { this.dtpEndDate.Text = value.ToString(); }
        }
      

        #endregion


        #region Controller

        private IMNMCTL00078 controller;
        public IMNMCTL00078 Controller
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

     
        private void MNMVEW00078_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.InitialControls();
            this.Text = this.GetFormName();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        public string GetFormName()
        {
            string name = string.Empty;
            if (this.FormName == "PO Register(Encash) Listing")
            name = "PO Register(Encash) Listing";
            return name;
        }
          private void InitialControls()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);  
            this.dtpStartDate.Text = DateTime.Now.ToShortDateString();
            this.dtpEndDate.Text = DateTime.Now.ToShortDateString();
        }
      

         private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
         {
             this.InitialControls();
             this.controller.ClearCustomErrorMessage();
         }


         private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
         {
             this.Controller.Print();
         }

        #region CheckDate


         public bool CheckDate()
         {
             // Check dtpStartDate Date Time
             if (this.dtpStartDate.Value.Date > DateTime.Now.Date)
             {
                 Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00160, this.dtpStartDate.Value.ToString("dd/MM/yyyy"));//Datetime cannot be greater than today date.
                 this.dtpStartDate.Focus();
                 return false;
             }

             // Check dtpEndDate Date Time
             else if (this.dtpEndDate.Value.Date > DateTime.Now.Date)
             {
                 Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00160, this.dtpEndDate.Value.ToString("dd/MM/yyyy"));//Datetime cannot be greater than today date.
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
