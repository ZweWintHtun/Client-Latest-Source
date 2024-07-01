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
namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00049 : BaseForm, IMNMVEW00049
    {
        public MNMVEW00049()
        {
            InitializeComponent();
        }

        private string formName = string.Empty;


        #region Properties
        #region controller
        private IMNMCTL00049 currentCompanyController;
        public IMNMCTL00049 Controller
        {
            get
            {
                return this.currentCompanyController;
            }
            set
            {
                this.currentCompanyController = value;
                this.currentCompanyController.View = this;
            }
        }
        #endregion
        public string FormName
        {
            get { return this.formName; }
            set { this.formName = value; }
        }
        public string AccountNumber
        {
            get { return this.mtxtAccountNo.Text.Replace("-", "").Trim(); }
            set { this.mtxtAccountNo.Text = value; }
        }
        public string AccountType
        {
            get;
            set;
        }
        #endregion

        #region Events

        private void MNMVEW00049_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
        }
        #region rsb Events
        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            CXUIScreenTransit.Transit("frmMNMVEW00098BalanceCertificateReprot", true, new object[] { false, "BalanceConfirmation" });
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #endregion
    }
}
