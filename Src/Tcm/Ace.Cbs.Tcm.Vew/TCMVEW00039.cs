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
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tcm.Ctr.Ptr;

namespace Ace.Cbs.Tcm.Vew
{
    public partial class TCMVEW00039 : BaseForm,ITCMVEW00039
    {
        #region Constructor
        public TCMVEW00039()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        public string ChequeType
        {
            get
            {
                if (this.rdoIssuedCheque.Checked == true)
                {
                    return "Issued Cheque";
                }

                else if (this.rdoStoppedCheque.Checked == true)
                {
                    return "Stopped Cheque";
                }
                else
                {
                    return "Printed Cheque";
                }

            }

            set
            {
                if (value == "Issued Cheque")
                {
                    this.rdoIssuedCheque.Checked = true;
                }
                else if (value == "Stopped Cheque")
                {
                    this.rdoStoppedCheque.Checked = true;
                }
                else
                {
                    this.rdoPrintedCheque.Checked = true;
                }

            }

        }

        public string RequiredType
        {
            get
            {
                if (this.cboRequiredType.Text == null)
                {
                    return null;
                }
                else
                {
                    return this.cboRequiredType.Text.ToString();
                }
            }
            set
            {
                this.cboRequiredType.Text = value;
                this.cboRequiredType.SelectedValue = value;
            }
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

        public string CurrentAccountNo
        {
            get { return this.mtxtAccountNo.Text.Replace("-", "").Trim(); }
            set { this.mtxtAccountNo.Text = value; }
        }
        #endregion

        #region Controller
        private ITCMCTL00039 controller;
        public ITCMCTL00039 Controller
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
        private void InitializeControls()
        {
            //Enable Disable Menu Controls
            tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            this.rdoIssuedCheque.Checked = true;
            this.CurrentAccountNo = string.Empty;
            this.cboRequiredType.SelectedIndex = -1;
            this.HideControls("Cheque.FormStart.HiddenControls");
        }

        #endregion

        private void cboRequiredType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.RequiredType == "By Date")
            {
                this.CurrentAccountNo = string.Empty;
                this.HideControls("Cheque.FormStart.HiddenControls");
                this.ShowControls("Cheque.ByDate.VisibleControls");
            }
            else
            {
                this.dtpStartDate.Value = DateTime.Now;
                this.dtpEndDate.Value = DateTime.Now;
                this.HideControls("Cheque.FormStart.HiddenControls");
                this.ShowControls("Cheque.ByAccount.VisibleControls");
            }
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.dtpStartDate.Value = DateTime.Now;
            this.dtpEndDate.Value = DateTime.Now;
            this.InitializeControls();
            this.Controller.ClearErrorMessage();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            this.controller.Print();
        }

        private void TCMVEW00039_Load(object sender, EventArgs e)
        {
            this.InitializeControls();
        }

        private void rdoChequeType_CheckedChanged(object sender, EventArgs e)
        {
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            this.CurrentAccountNo = string.Empty;
            this.cboRequiredType.SelectedIndex = -1;
            this.dtpStartDate.Value = DateTime.Now;
            this.dtpEndDate.Value = DateTime.Now;
            this.HideControls("Cheque.FormStart.HiddenControls");
        }
     
    }
}
