//----------------------------------------------------------------------
// <copyright file="TLMCVEW00071" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate>2.9.2013</CreatedDate>
// <UpdatedUser>NLKK</UpdatedUser>
// <UpdatedDate>27.12.2013</UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.CXClient;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Mnm._Excel;

namespace Ace.Cbs.Tel.Vew
{
    public partial class TLMVEW00071 : BaseForm, ITLMVEW00071
    {
        IList<CounterInfoDTO> counterList;
        bool isFormLoad = false;

        #region Constructor
        public TLMVEW00071()
        {
            InitializeComponent();
        }
        #endregion

        #region Controller
        private ITLMCTL00071 controller;
        public ITLMCTL00071 Controller
        {
            get { return this.controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }
        #endregion

        #region Controls Input Output

        public bool isReversal
        {
            get { return chkBeforeEditing.Checked ? true : false; }
        }

        public DateTime RequireDate
        {
            get { return this.dtpRequireDate.Value; }
        }

        public string CurrencyCode
        {
            get
            {
                if (this.cboCurrency.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                   return this.cboCurrency.SelectedValue.ToString();
                }
            }

            set { this.cboCurrency.SelectedValue = value; }
        }

        public string CounterNo
        {
            get { return this.cboCounterNo.Text; }
        }

        public bool isNoteChange
        {
            get { return this.rdoNotesChange.Checked; }
        }

        public bool isReceipt
        {
            get { return this.rdoReceipt.Checked; }
        }

        public bool isPayment
        {
            get { return this.rdoPayment.Checked; }
        }

        public bool isReceiptRefund
        {
            get { return this.rdoReceiptRefund.Checked; }
        }

        public bool isReceiptWithdraw
        {
            get { return this.rdoReceiptByCounter.Checked; }
        }


        public bool isMultiTransaction
        {
            get { return this.rdoMultiTransactions.Checked; }
        }

        #endregion

        #region Methods
        private void BindCurrency()
        {
            IList<CurrencyDTO> currencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = currencyList;
            cboCurrency.SelectedIndex = 0;
        }

        private void BindCounterNo(string counterType)
        {
            IList<CounterInfoDTO> Counters = new List<CounterInfoDTO>();
            if (counterType != "Both")
            {
                Counters = this.counterList.Where<CounterInfoDTO>(x => x.CounterType == counterType).ToList();                               
            }
            else
            {
                Counters = this.counterList.Where<CounterInfoDTO>(x => x.CounterType != "").ToList();
            }
            CounterInfoDTO counter = new CounterInfoDTO();
            counter.CounterNo = "All";
            Counters.Add(counter);
            var counterLists = Counters.OrderBy(x => x.CounterNo);
            this.cboCounterNo.DataSource = null;
            this.cboCounterNo.ValueMember = "CounterNo";
            this.cboCounterNo.DisplayMember = "CounterNo";
            this.cboCounterNo.DataSource = counterLists.ToList();
            this.cboCounterNo.SelectedIndex = -1;
        }

        private void InitializeControls()
        {
            tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.rdoReceipt.Focus();
            this.BindCurrency();
            if(this.isFormLoad)
                this.BindCounterNo("R");        
        }

        #endregion

        #region Events
        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TLMVEW00071_Load(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.counterList = this.Controller.GetCounterInfo();
            this.isFormLoad = true;
            this.BindCounterNo("R");
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
           // this.controller.ClearAllCustomErrorMessage();
            this.rdoReceipt.Checked = true;
            this.cboCurrency.SelectedIndex = 0;
            this.cboCounterNo.SelectedIndex = -1;
            this.dtpRequireDate.Value = DateTime.Now;
            this.chkBeforeEditing.Checked = false;
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            //if (backgroundWorker1.IsBusy != true)
            //{
            //    // Start the asynchronous operation.
            //    backgroundWorker1.RunWorkerAsync();
            //}          

            #region Process
            if (this.rdoReceipt.Checked)
            {
                //this.controller.Receipt(this.isReversal);
                dgvCashDenomination.DataSource = this.controller.Receipt_New(this.isReversal);

            }

            else if (this.rdoReceiptRefund.Checked)
            {
                dgvCashDenomination.DataSource = this.controller.ReceiptRefund(this.isReversal);
            }

            else if (this.rdoReceiptByCounter.Checked)
            {
                dgvCashDenomination.DataSource = this.controller.ReceiptWithdrawByCounter(this.isReversal);
            }

            else if (this.rdoPayment.Checked)
            {
                dgvCashDenomination.DataSource = this.controller.Payment(this.isReversal);
            }

            else if (this.rdoNotesChange.Checked)
            {
                dgvCashDenomination.DataSource = this.controller.NotesChange(this.isReversal);
            }

            else if (this.rdoMultiTransactions.Checked)
            {
                this.controller.MultiTransactions(this.isReversal);
            }

            #endregion
            try
            {
                if (dgvCashDenomination.DataSource != null)
                {
                    string reportTitle = this.Controller.GetReportTitle();
                    BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                    CashControlReport_Excel frm = new CashControlReport_Excel(dgvCashDenomination);
                    frm.CashDenominationListing_ExcelGrid(Branch.BranchDescription, Branch.Address, Branch.Phone, Branch.Fax, reportTitle, DateTime.Now, dgvCashDenomination);

                }
            }
            catch (Exception ex)
            {

            }

        }

        #endregion

        private void rdoReceipt_CheckedChanged(object sender, EventArgs e)
        {
            if(this.rdoReceipt.Checked)
                this.BindCounterNo("R");
        }

        private void rdoReceiptRefund_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoReceiptRefund.Checked)
                this.BindCounterNo("R");
        }

        private void rdoReceiptByCounter_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoReceiptByCounter.Checked)
                this.BindCounterNo("R");
        }

        private void rdoPayment_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoPayment.Checked)
                this.BindCounterNo("P");
        }

        private void rdoNotesChange_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoNotesChange.Checked)
                this.BindCounterNo("Both");
        }

        private void rdoMultiTransactions_CheckedChanged(object sender, EventArgs e)
        {
            if(this.rdoMultiTransactions.Checked)
                this.BindCounterNo("Both");
        }

        //private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    //  Thread.Sleep(1000); // One second. //using System.Threading;         
        //}
    }
}
