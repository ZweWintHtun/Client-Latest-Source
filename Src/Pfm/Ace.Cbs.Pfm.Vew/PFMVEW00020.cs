using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;

namespace Ace.Cbs.Pfm.Vew
{
    public partial class frmPFMVEW00020 : BaseForm
    {

        #region Constructor
        public frmPFMVEW00020()
        {
            InitializeComponent();
        }
        #endregion

        #region Proprety

        private Dictionary<int, string> SavingAccountWithdrawFormPrinting;

        #endregion

        #region Event
        //When Saving  A/C Withdraw Form Printing Menu Clicked
        private void frmPFMVEW00020_Load(object sender, EventArgs e)
        {
            SavingAccountWithdrawFormPrinting = SpringApplicationContext.Instance.Resolve<Dictionary<int, string>>(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SavingAccountWithdrawFormPrinting));

            cxcliC0011.ButtonEnableDisabled(false, false, false, false, true, false, true);          
            this.BindcboTransactionType();
        }

        //When Continue Button Clicked
        private void butContinue_Click(object sender, EventArgs e)
        {
            if (cboTransactionType.SelectedIndex == -1)
            {
                //Please Choose Transaction Type
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00075);
                return;
            }

            if (cboTransactionType.SelectedValue.ToString() == "0")
            {
                CXUIScreenTransit.Transit("frmPFMVEW00021", new object[] { this.MenuIdForPermission, "Saving Withdrawal Form Offline" });
            }

            else if (cboTransactionType.SelectedValue.ToString() == "1")
            { 
                CXUIScreenTransit.Transit("frmPFMVEW00021", new object[]{ this.MenuIdForPermission, "Saving Withdrawal Form Online"});
            }

            //else if(cboTransactionType.SelectedIndex ==-1)
            //{
            //    // Please choose Transaction Type.
            //    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00075); 
            //}
        }

        //When Exit Button Clicked
        private void cxcliC0011_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        //When Cancel Button Clicked
        private void cxcliC0011_CancelButtonClick(object sender, EventArgs e)
        {
            cboTransactionType.SelectedIndex = -1;
        }
        
        #endregion

        #region Method
        //To Bind TransactionType Combobox
        private void BindcboTransactionType()
        {
            cboTransactionType.ValueMember = "Key";
            cboTransactionType.DisplayMember = "Value";
            cboTransactionType.DataSource = new BindingSource(SavingAccountWithdrawFormPrinting, null);
            cboTransactionType.SelectedIndex = -1;
        }
        #endregion

        private void frmPFMVEW00020_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }
    }
}
