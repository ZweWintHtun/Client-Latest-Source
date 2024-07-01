using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Tel.Vew
{
    public partial class TLMVEW00079 : BaseForm, ITLMVEW00079
    {
        #region "Properties"

        public string AccountNo
        {
            get { return this.mtxtAccountNo.Text.Replace("-", "").Trim(); }
            set { this.mtxtAccountNo.Text = value; }
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

        public bool isFixedAcc { get; set; }

        public bool WithReversal
        {
            get { return chkWithReversal.Checked; }
            set { chkWithReversal.Checked = value; }
        }
        #endregion

        #region "Constructor"
        public TLMVEW00079()
        {
            InitializeComponent();
        }
        #endregion

        #region "Controllers"
        private ITLMCTL00079 controller;
        public ITLMCTL00079 Controller 
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

        #region "Private Method"

        private void EnableDisableControls()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);

        }

        private void InitializeControls()
        {
            this.EnableDisableControls();
            this.dtpStartDate.Value = DateTime.Now;
            this.dtpEndDate.Value = DateTime.Now;
            this.mtxtAccountNo.Clear();
            this.mtxtAccountNo.Focus();
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);            
        }

        #endregion

        #region "Events"

        private void TLMVEW00079_Load(object sender, EventArgs e)
        {
            this.InitializeControls();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            if (this.controller.CheckDate())
            {
                this.controller.FAOFMainPrint();
            }
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.controller.ClearErrors();
        }

        #endregion

    }
}
