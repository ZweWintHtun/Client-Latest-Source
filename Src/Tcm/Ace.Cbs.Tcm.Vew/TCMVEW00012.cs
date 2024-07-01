using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Cle;
using System.Windows.Forms;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Cx.Com.Utt;


namespace Ace.Cbs.Tcm.Vew
{
    public partial class TCMVEW00012 : BaseForm,ITCMVEW00012
    {
        #region Constructor
        public TCMVEW00012()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        public string AccountNo
        {
            get { return this.mtxtAccountNo.Text.Replace("-", " "); }
            set { this.mtxtAccountNo.Text = value; }
        }

        public string CheckBookNo
        {
            get { return this.txtCheckBookNo.Text; }
            set { this.txtCheckBookNo.Text = value; }
        }

        public string StartSerialNo
        {
            get { return this.txtStartSerialNo.Text; }
            set { this.txtStartSerialNo.Text = value; }
        }

        public string EndSerialNo
        {
            get { return this.txtEndSerialNo.Text; }
            set { this.txtEndSerialNo.Text = value; }
        }

        public string Name
        {
            get { return this.lblName.Text; }
            set { this.lblName.Text = value; }
        }
        public string NRC
        {
            get { return this.lblNRC.Text; }
            set { this.lblNRC.Text = value; }
        }
        #endregion

        #region Controller
        private ITCMCTL00012 controller;
        public ITCMCTL00012 Controller
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
            this.Name = string.Empty;
            this.NRC = string.Empty;
            this.mtxtAccountNo.Select();
        }

        public void Successful(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }
        #endregion

        #region Events
        private void TCMVEW00012_Load(object sender, EventArgs e)
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
            string data = this.controller.CheckCheque();

            if (data == "OK")
            {
                if (CXUIMessageUtilities.ShowMessageByCode("MC00020") == DialogResult.Yes)//Are you sure to Release?
                {
                    controller.Save();
                }
            }
            else if (data == "NOT OK")
            {
                CXUIMessageUtilities.ShowMessageByCode("MV00059");//Invalid Cheque No.
            }
            else
                return;
          
        }

        private void txtCheckBookNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtStartSerialNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtEndSerialNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        #endregion

        private void TCMVEW00012_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }
    }
}
