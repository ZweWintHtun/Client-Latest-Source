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
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Mnm._Excel;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00055 : BaseForm, IMNMVEW00055
    {
        public MNMVEW00055()
        {
            InitializeComponent();
        }

        #region DataProperties
        private IList<CounterInfoDTO> tocounterInfolist;
        public IList<CounterInfoDTO> TocounterInfolist
        {
            get
            {
                if (this.tocounterInfolist == null)
                    this.tocounterInfolist = new List<CounterInfoDTO>();

                return this.tocounterInfolist;
            }
            set
            {
                this.tocounterInfolist = value;
            }
        }
        private IList<CurrencyDTO> CurrencyList { get; set; }

        #endregion

        #region Controller
        private IMNMCTL00055 controller;
        public IMNMCTL00055 Controller
        {
            get { return this.controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }
        #endregion

        #region UI properties

        public string CounterNo
        {
            get {
                if (this.cboCounterNo.SelectedValue != null)
                    return this.cboCounterNo.SelectedValue.ToString();
                else
                    return string.Empty;
            }
            set { this.cboCounterNo.SelectedValue = value; }
        }

        public string Currency
        {
            get
            {
                if (this.cboCurrency.Text == null)
                {
                    return null;
                }
                else
                {
                    return this.cboCurrency.Text.ToString();
                }
            }
            set
            {
                this.cboCurrency.Text = value;
                this.cboCurrency.SelectedValue = value;
            }
        }

        public DateTime EndDateTime
        {
            get { return this.dtpEnterDate.Value; }
            set { this.dtpEnterDate.Text = value.ToString(); }
        }

        public bool IsReversal
        {
            get { return this.chkBeforeEditing.Checked; }
            set { this.chkBeforeEditing.Checked = value; }
        }

        public string _counterType
        {
            get { return this._counterType; }
            set { this._counterType = value; }
        }

      #endregion




        #region event 
        private void MNMVEW00055_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.BindCounterComboBox();
            this.BindCurrency();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            //this.Controller.PrintExel_New();
            try
            {
                dgvCashControl.DataSource = this.Controller.PrintExel_New();
                if (dgvCashControl.DataSource != null)
                {
                    string _counterType = this.Controller._counterType;
                    string reportTitle = this.Controller.SendReportTitle();
                    BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                    CashControlReport_Excel frm = new CashControlReport_Excel(dgvCashControl);
                    frm.CashControlReportByCounter_ExcelGrid(Branch.BranchDescription, Branch.Address, Branch.Phone, Branch.Fax, reportTitle, DateTime.Now, dgvCashControl, _counterType);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.controller.ClearCustomErrorMessage();
            cboCurrency.SelectedIndex = 0;
            cboCounterNo.SelectedIndex = -1;
            chkBeforeEditing.Checked = false;
            this.dtpEnterDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
        }

        #endregion 

        #region Methods

        private void BindCurrency()
        {
            this.CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = this.CurrencyList;
            cboCurrency.SelectedIndex = 0;
        }

        private void BindCounterComboBox()
        {
            this.TocounterInfolist = this.controller.GetAllCounterListBySourceBranchCode();
            cboCounterNo.DataSource = this.TocounterInfolist;
            cboCounterNo.ValueMember = "CounterNo";
            cboCounterNo.DisplayMember = "CounterNo";
            cboCounterNo.SelectedIndex = -1;
        }
        #endregion
    }
}
