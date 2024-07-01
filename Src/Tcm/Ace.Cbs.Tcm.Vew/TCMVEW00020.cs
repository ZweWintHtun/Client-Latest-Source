using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tcm.Ctr.Ptr;

namespace Ace.Cbs.Tcm.Vew
{
    public partial class TCMVEW00020 : BaseDockingForm,ITCMVEW00020
    {
        #region Constructor
        public TCMVEW00020()
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

        public decimal OldMinimumLimit
        {
            get{ return Convert.ToDecimal(this.txtOldMinimumLimit.Text);}
            set { this.txtOldMinimumLimit.Text = value.ToString(); }
        }

        public decimal NewMinimumLimit
        {
            get { return Convert.ToDecimal(this.txtNewMinimumLimit.Text); }
            set { this.txtNewMinimumLimit.Text = value.ToString(); }
        }

        public string Remark
        {
            get { return this.txtRemark.Text; }
            set { this.txtRemark.Text= value; }
        }

        public string Information
        {
            get { return this.gbPersonalInfo.Text; }
            set { this.gbPersonalInfo.Text = value; }
        }

       
        #endregion

        #region Controller
        private ITCMCTL00020 controller;
        public ITCMCTL00020 Controller
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
        private void EnableDisableControls()
        {
            tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
        }

        private void InitializeControls()
        {
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            this.gvCustomer.DataSource = null;
        }

        public void Successful(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }

        public void gvCustomer_DataBind(IList<PFMDTO00001> customerList)
        {
            this.gvCustomer.DataSource = null;
            gvCustomer.AutoGenerateColumns = false;
            this.gvCustomer.DataSource = customerList;
        }

        public void SetFocus()
        {
            this.mtxtAccountNo.Focus();
        }
        #endregion

        private void TCMVEW00020_Load(object sender, EventArgs e)
        {
            this.EnableDisableControls();
            this.InitializeControls();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.controller.ClearControls();
            this.controller.ClearErrors();
            this.InitializeControls();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            if (this.controller.Save())
            {
                this.InitializeControls();
            }
            else
            {
                this.txtNewMinimumLimit.Select();
            }
        }

    }
}
