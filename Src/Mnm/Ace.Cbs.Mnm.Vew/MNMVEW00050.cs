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
    public partial class MNMVEW00050 : BaseForm ,IMNMVEW00050
    {
        #region Constructor

        public MNMVEW00050()
        {
            InitializeComponent();
        }

        #endregion 

        #region Controller
        private IMNMCTL00050 controller;
        public IMNMCTL00050 Controller
        {
            get { return this.controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }
        #endregion

        #region Properties

        private string formName = string.Empty;
        public string FormName
        {
            get { return this.formName; }
            set { this.formName = value; }
        }

        public string RequiredYear
        {
            get { return this.mtxtRequiredYear.Text; }
            set { this.mtxtRequiredYear.Text = value; }

        }

        public string Currency
        {
            get { return this.cboCurrency.SelectedValue == null ? string.Empty : this.cboCurrency.SelectedValue.ToString(); }
            set { this.cboCurrency.SelectedValue = value; }
        }
        public string BranchCode
        {
            get { return null; }
            set { }
        }
    
        #endregion

        #region Events

        private void MNMVEW00050_Load(object sender, EventArgs e)
        {
            //ButtonEnableDisabled(newButtonEnabled, editButtonEnabled, saveButtonEnabled, deleteButtonEnabled,cancelButtonEnabled, printButtonEnabled, exitButtonEnabled);
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.Text = this.FormName;

            IList<CurrencyDTO> CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = CurrencyList;
            cboCurrency.SelectedIndex = 0;

            

            this.mtxtRequiredYear.Text = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode);
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            if (this.controller.Validate())
            {
                this.Controller.ShowReport(formName);
            }
        }

        #endregion 

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.controller.ClearCustomErrorMessage();
            this.cboCurrency.SelectedIndex = 0;
            this.mtxtRequiredYear.Text = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode);
        }
    }
}
