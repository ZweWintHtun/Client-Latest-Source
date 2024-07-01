using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;

namespace Ace.Cbs.Pfm.Vew
{
    public partial class frmPFMVEW00016 : BaseForm
    {
        #region Constructor

        public frmPFMVEW00016()
        {
            InitializeComponent();
        }

        #endregion

        #region private variables

        private Dictionary<int, string> CurrentAccountFormType;

        private Dictionary<int, string> SavingAccountFormType;

        #endregion

        #region Event

        private void frmPFMVEW00016_Load(object sender, EventArgs e)
        {
            CurrentAccountFormType = SpringApplicationContext.Instance.Resolve<Dictionary<int, string>>(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurrentAccountFormType));

            SavingAccountFormType = SpringApplicationContext.Instance.Resolve<Dictionary<int, string>>(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SavingAccountFormType));

            tlspCommon.ButtonEnableDisabled(false, false, false, false, true, false, true);

            this.InitializedControls();
        }

        private void rdoCurrentAccount_CheckedChanged(object sender, EventArgs e)
        {
            BindCurrentAccountFormType();
        }

        private void rdoSavingAccount_CheckedChanged(object sender, EventArgs e)
        {
            BindSavingAccountFormType();
        }

        private void butContinue_Click(object sender, EventArgs e)
        {
            if (cboFormType.SelectedIndex < 0)
            {
               CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00073);
                cboFormType.Focus();
                return ;

            }
            if (rdoCurrentAccount.Checked)
            {
                if (cboFormType.Text == "Individual")
                    CXUIScreenTransit.Transit("frmPFMVEW00017", "Current Account (Individual)");
                else if (cboFormType.Text == "Joint")
                    CXUIScreenTransit.Transit("frmPFMVEW00018", "Current Account (Joint)");                   
                else
                    CXUIScreenTransit.Transit("frmPFMVEW00019", "Current Account (Company)");
            }
            else
            {
                if (cboFormType.Text == "Individual")
                    CXUIScreenTransit.Transit("frmPFMVEW00017", "Saving Account (Individual)");
                else if (cboFormType.Text == "Joint")
                    CXUIScreenTransit.Transit("frmPFMVEW00018", "Saving Account (Joint)");
                else if (cboFormType.Text == "Minor")
                    CXUIScreenTransit.Transit("frmPFMVEW00017", "Saving Account (Minor)");
                else
                    CXUIScreenTransit.Transit("frmPFMVEW00019", "Saving Account (Co./Organization)");
            }
        }

        private void tlspCommon_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializedControls();
           
        }

        private void tlspCommon_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Private methods

        private void InitializedControls()
        {
            rdoCurrentAccount.Checked = true;
            cboFormType.SelectedIndex = -1;
        }

        private void BindCurrentAccountFormType()
        {
            cboFormType.Enabled = true;
            cboFormType.DataSource = new BindingSource(CurrentAccountFormType, null);
            cboFormType.DisplayMember = "Value";
          cboFormType.ValueMember = "Key";
            //cboFormType.ValueMember = "aa";
            cboFormType.SelectedIndex = -1;
        }

        private void BindSavingAccountFormType()
        {
            cboFormType.Enabled = true;
            cboFormType.DataSource = new BindingSource(SavingAccountFormType, null);
            cboFormType.DisplayMember = "Value";
            cboFormType.ValueMember = "Key";
            cboFormType.SelectedIndex = -1;
        }

        #endregion

    }
}