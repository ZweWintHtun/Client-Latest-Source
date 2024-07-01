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
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Tcm.Vew
{
    public partial class TCMVEW00018 : BaseDockingForm,ITCMVEW00018
    {
        #region Constructor
        public TCMVEW00018()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
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

        public decimal Amount
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtAmount.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtAmount.Text = value.ToString(); }
        }

        public string TransactionStatus
        {
            get { return this.FormName; }
        }

        public string CounterNo
        {
            get
            {
                return this.txtCounterNo.Text.ToString();
            }
            set
            {
                this.txtCounterNo.Text = value;
            }
        }

        public string CounterType { get; set; }
        public string BranchCode { get; set; }

        public decimal DenoAmount
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtAmount1.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtAmount1.Text = value.ToString(); }
        }

        public decimal TotalAmount
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtTotalAmount.Text, out result);
                return Math.Round(result, 2);
            }
            set
            {
                this.txtTotalAmount.Text = value.ToString();
            }
        }

        public IList<TLMDTO00012> Deno { get; set; }

        private IList<TLMDTO00012> denoData;
        public IList<TLMDTO00012> DenoData
        {
            get
            {
                if (this.denoData == null)
                    this.denoData = Deno;
                return this.denoData;
            }
            set
            {
                this.denoData = value;
            }
        }

        private ITCMCTL00018 notechangedepositcontroller;
        public ITCMCTL00018 Controller
        {
            get { return this.notechangedepositcontroller; }
            set
            {
                this.notechangedepositcontroller = value;
                this.notechangedepositcontroller.View = this;
            }
        }        
   
        public decimal counttotal { get; set; }

        private string parentFormId = string.Empty;
        public string ParentFormId
        {
            get { return this.parentFormId; }
            set { this.parentFormId = value; }
        }
      
        #endregion

        #region Events
        private void TCMVEW00018_Load(object sender, EventArgs e)
        {
            #region Old_Logic
            //this.BindCurrencyComboBoxes();
            //this.InitializeControls();
            //this.ParentFormId = this.Name;
            //this.CounterChecking();

            #endregion

            #region Seperating_EOD_Logic (Added By YMP at 30-07-2019, Modified by HMW at 26-08-2019)
            DateTime systemDate = this.Controller.GetSystemDate(CurrentUserEntity.BranchCode);
            DateTime lastSettlementDate = this.Controller.GetLastSettlementDate(CurrentUserEntity.BranchCode);
            this.lblTransactionDate.Text = systemDate.ToString("dd-MM-yyyy");

            if (systemDate.ToString("dd-MM-yyyy") != lastSettlementDate.ToString("dd-MM-yyyy")) //Show Form
            {
                this.BindCurrencyComboBoxes();
                this.InitializeControls();
                this.ParentFormId = this.Name;
                this.CounterChecking();
            }
            else //Don't show form after cut off
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI50013);//You have no permission.\n"Back Date EOD Process" needs to be completed!
                this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
                //this.InitializeControls();
                this.DisableControls("NoteChangeDeposit.AllDisable");
            }
            #endregion
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.Controller.ClearingForm();
        }

        private void cboCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindDenoInformation();
        }

        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            //this.DenoAmount = this.Amount;
        }

        private void gvDenomination_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            #region OldCode
            //try
            //{
            //    if (e.ColumnIndex < 0 || e.RowIndex < 0 || gvDenomination.Columns[e.ColumnIndex].ReadOnly == true)
            //        return;
            //    else
            //    {
            //        if (gvDenomination.Rows[e.RowIndex].Cells["colDescription"].Value.ToString().IndexOf("D1") != 0)
            //            counttotal -= Convert.ToDecimal(gvDenomination.Rows[e.RowIndex].Cells["D1"].Value) * Convert.ToDecimal(gvDenomination.Rows[e.RowIndex].Cells["Count"].Value);
            //        if (gvDenomination.Rows[e.RowIndex].Cells["colDescription"].Value.ToString().IndexOf("D2") != 0)
            //            counttotal -= (Convert.ToDecimal(gvDenomination.Rows[e.RowIndex].Cells["D2"].Value) / 100) * Convert.ToDecimal(gvDenomination.Rows[e.RowIndex].Cells["Count"].Value);
            //        this.TotalAmount = counttotal;
            //    }
            //    this.DenoData[e.RowIndex].DenoCount = Convert.ToInt32(gvDenomination.Rows[e.RowIndex].Cells["Count"].Value);
            //}
            //catch
            //{ }

            #endregion OldCode
        }

        private void gvDenomination_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            #region OldCode
            //try
            //{
            //    if (e.ColumnIndex < 0 || e.RowIndex < 0 || gvDenomination.Columns[e.ColumnIndex].ReadOnly == true)
            //        return;
            //    else
            //    {
            //        if (gvDenomination.Rows[e.RowIndex].Cells["colDescription"].Value.ToString().IndexOf("D1") != 0)
            //            counttotal += Convert.ToDecimal(gvDenomination.Rows[e.RowIndex].Cells["D1"].Value) * Convert.ToDecimal(gvDenomination.Rows[e.RowIndex].Cells["Count"].Value);
            //        if (gvDenomination.Rows[e.RowIndex].Cells["colDescription"].Value.ToString().IndexOf("D2") != 0)
            //            counttotal += (Convert.ToDecimal(gvDenomination.Rows[e.RowIndex].Cells["D2"].Value) / 100) * Convert.ToDecimal(gvDenomination.Rows[e.RowIndex].Cells["Count"].Value);
            //        this.TotalAmount = counttotal;
            //        //if (counttotal != 0 && counttotal > Amount)
            //        //    RefundAmount = Math.Abs(counttotal - Amount);
            //        //else
            //        //    RefundAmount = 0;
            //        //this.DenoData[e.RowIndex].DenoCount = Convert.ToInt32(gvDenomination.Rows[e.RowIndex].Cells["Count"].Value);
            //    }
            //}
            //catch
            //{ }
            #endregion OldCode

            try
            {                
                if (e.ColumnIndex < 0 || e.RowIndex < 0 || gvDenomination.Columns[e.ColumnIndex].ReadOnly == true)
                    return;
                else
                {
                    decimal tosubtract=0;
                    if (this.DenoData[e.RowIndex].D1 != 0 && this.DenoData[e.RowIndex].DenoCount != Convert.ToInt32(gvDenomination.Rows[e.RowIndex].Cells["Count"].Value))
                    {
                        tosubtract +=Convert.ToDecimal(this.DenoData[e.RowIndex].D1) * (this.DenoData[e.RowIndex].DenoCount);                        
                    }
                    if (this.DenoData[e.RowIndex].D2 != 0 && this.DenoData[e.RowIndex].DenoCount != Convert.ToInt32(gvDenomination.Rows[e.RowIndex].Cells["Count"].Value))
                    {
                        tosubtract += (Convert.ToDecimal(this.DenoData[e.RowIndex].D2)/100) * (this.DenoData[e.RowIndex].DenoCount);                        
                    }
                    this.TotalAmount = TotalAmount - tosubtract;
                    counttotal = 0;
                    if (gvDenomination.Rows[e.RowIndex].Cells["colDescription"].Value.ToString().IndexOf("D1") != 0 && this.DenoData[e.RowIndex].DenoCount != Convert.ToInt32(gvDenomination.Rows[e.RowIndex].Cells["Count"].Value))
                        counttotal  += Convert.ToDecimal(gvDenomination.Rows[e.RowIndex].Cells["D1"].Value) * Convert.ToDecimal(gvDenomination.Rows[e.RowIndex].Cells["Count"].Value);
                    if (gvDenomination.Rows[e.RowIndex].Cells["colDescription"].Value.ToString().IndexOf("D2") != 0 && this.DenoData[e.RowIndex].DenoCount != Convert.ToInt32(gvDenomination.Rows[e.RowIndex].Cells["Count"].Value))
                        counttotal  += (Convert.ToDecimal(gvDenomination.Rows[e.RowIndex].Cells["D2"].Value) / 100) * Convert.ToDecimal(gvDenomination.Rows[e.RowIndex].Cells["Count"].Value);
                    this.TotalAmount =this.TotalAmount+counttotal;
                }
                this.DenoData[e.RowIndex].DenoCount = Convert.ToInt32(gvDenomination.Rows[e.RowIndex].Cells["Count"].Value);
            }
            catch
            { }
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            if (this.Controller.ValidateAmount() && cboCurrency.SelectedIndex!=-1)
            {
                CXUIScreenTransit.Transit("frmTCMVEW00019", true, new object[] { this.DenoAmount, this.DenoData, this.TransactionStatus, this.parentFormId });

                this.Controller.ClearingForm();
                this.gvDenomination.DataSource = null;
            }
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            this.DenoAmount = this.Amount;
        }
        #endregion

        #region Methods

        public void BindDenoInformation()
        {
            // Get Deno data by Currency.
            gvDenomination.DataSource = null;
            Deno = CXCLE00002.Instance.GetListObject<TLMDTO00012>("Deno.SelectByCurrencyCode", new object[] { this.Currency ,true});
            gvDenomination.AutoGenerateColumns = false;
            gvDenomination.DataSource = Deno;
        }

        private void BindCurrencyComboBoxes()
        {
            IList<CurrencyDTO> CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = CurrencyList;
            cboCurrency.SelectedIndex = 0;
        }

        private void InitializeControls()
        {
            //ButtonEnableDisabled(newButtonEnabled, editButtonEnabled, saveButtonEnabled, deleteButtonEnabled,cancelButtonEnabled, printButtonEnabled, exitButtonEnabled);
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            this.cboCurrency.Focus();
        }
        #endregion

        //private void BindCounterNo()
        //{
        //    // Get Counter No data. Wrong
        //    this.BranchCode = CurrentUserEntity.BranchCode;

        //    foreach (TLMDTO00012 denoInfo in DenoData)
        //        denoInfo.CounterNo = this.CounterNo;
        //}

        private bool CounterChecking()
        {
            switch (this.TransactionStatus)
            {
                case "Payment":
                    CounterType = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.PaymentCounterType);
                    foreach (CurrentCounterInfo Info in CurrentUserEntity.CounterList)
                    {
                        if (Info.CounterType == CounterType)
                        {
                            this.CounterNo = Info.CounterNo;
                            return true;
                        }
                    }
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV20047);
                    this.Close();
                    break;
                case "Receiving":
                    CounterType = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiveCounterType);
                    foreach (CurrentCounterInfo Info in CurrentUserEntity.CounterList)
                    {
                        if (Info.CounterType == CounterType)
                        {
                            this.CounterNo = Info.CounterNo;
                            return true;
                        }
                    }
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV20047);
                    this.Close();
                    break;
                case "ChiefCashierEntry":
                    CounterType = string.Empty;
                    this.CounterNo = string.Empty;
                    this.txtCounterNo.Visible = false;
                    this.lblCounterNo.Visible = false;
                    return true;
                    break;
            }
            return false;
        }
        //private void gvDenomination_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        //{

        //    if (gvDenomination.CurrentCell.OwningColumn.Name.Equals("Count"))
        //    {
        //        TextBox combo = e.Control as TextBox;
        //        if (combo != null)
        //        {
        //            combo.KeyPress -= new KeyPressEventHandler(NumericTextBox_KeyPress);
        //            combo.KeyPress += new KeyPressEventHandler(NumericTextBox_KeyPress);
        //        }
        //    }
        //}

    }
}
