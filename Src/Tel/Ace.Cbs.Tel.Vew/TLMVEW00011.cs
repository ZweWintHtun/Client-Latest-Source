using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Tel.Vew
{
    public partial class TLMVEW00011 : BaseDockingForm, ITLMVEW00011
    {
        #region Constructor

        public TLMVEW00011()
        {
            InitializeComponent();
        }

        public TLMVEW00011(decimal totalAmount, string currencyCode, CXDMD00008 transactionStatus, string parentFormId)
        {            
            this.DefaultAmount = totalAmount;
            this.CurrencyCode = currencyCode;
            this.ParentFormId = parentFormId;
            this.TransactionStatus = transactionStatus;
            InitializeComponent();
        }

        #endregion

        #region Properties

        private ITLMCTL00011 controller;
        public ITLMCTL00011 Controller
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

        public CXDMD00008 TransactionStatus { get; set; }

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

        public decimal DefaultAmount { get; set; }

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

        public decimal RefundAmount
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtRefundAmount.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtRefundAmount.Text = value.ToString(); }
        }
        
        public string CurrencyCode { get; set; }        

        public decimal counttotal { get; set; }

        public IList<TLMDTO00012> Deno { get; set; }

        private string parentFormId = string.Empty;
        public string ParentFormId
        {
            get { return this.parentFormId; }
            set { this.parentFormId = value; }
        }

        #endregion

        #region Events

        private void TLMVEW00011_Load(object sender, EventArgs e)
        {
            if (this.ParentFormId == "frmTLMVEW00004")
            {
                this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
                this.InitializeControls();
            }
            else
            {
                if (this.CounterChecking())
                {
                    // Button Enable Disabled
                    this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
                    this.InitializeControls();
                }
            }
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            //if (this.ParentFormId == "TLMVEW00075")
            ////{
                if (txtTotalAmount.Text.ToString() != "0.00")
                {
                    // if (txtRefundAmount.Text.ToString() != "0.00" && txtTotalAmount.Text != txtAmount.Text)
                    if (this.ParentFormId == "TLMVEW00078")
                    {
                        if (txtTotalAmount.Text != txtAmount.Text)
                        {
                            CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00037);    //Invalid Amount
                            //gvDenomination.Rows[e.RowIndex].Cells["Count"].Selected = true;
                            gvDenomination.Focus();
                        }                   
                        else
                        {
                            if (Controller.Save())
                            {
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                        }
                    }
                    else
                    {
                        if (Controller.Save())
                        {
                             this.DialogResult = DialogResult.OK;
                             this.Close();
                    }
                }
            }      
        }

        private void gvDenomination_CellEnter(object sender, DataGridViewCellEventArgs e)
          {
            try
            {
                if (e.ColumnIndex < 0 || e.RowIndex < 0 || gvDenomination.Columns[e.ColumnIndex].ReadOnly == true)
                    return;
                else
                {
                    if (gvDenomination.Rows[e.RowIndex].Cells["colDescription"].Value.ToString().IndexOf("D1") != 0)
                        counttotal -= Convert.ToDecimal(gvDenomination.Rows[e.RowIndex].Cells["D1"].Value) * Convert.ToDecimal(gvDenomination.Rows[e.RowIndex].Cells["Count"].Value);
                    if (gvDenomination.Rows[e.RowIndex].Cells["colDescription"].Value.ToString().IndexOf("D2") != 0)
                        counttotal -= (Convert.ToDecimal(gvDenomination.Rows[e.RowIndex].Cells["D2"].Value) / 100) * Convert.ToDecimal(gvDenomination.Rows[e.RowIndex].Cells["Count"].Value);
                    //this.TotalAmount = counttotal;
                }
                this.DenoData[e.RowIndex].DenoCount = Convert.ToInt32(gvDenomination.Rows[e.RowIndex].Cells["Count"].Value);
            }
            catch
            { }
        }

        private void gvDenomination_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex < 0 || e.RowIndex < 0 || gvDenomination.Columns[e.ColumnIndex].ReadOnly == true)
                    return;
                else
                {
                    if (gvDenomination.Rows[e.RowIndex].Cells["colDescription"].Value.ToString().IndexOf("D1") != 0)
                        counttotal += Convert.ToDecimal(gvDenomination.Rows[e.RowIndex].Cells["D1"].Value) * Convert.ToDecimal(gvDenomination.Rows[e.RowIndex].Cells["Count"].Value);
                    if (gvDenomination.Rows[e.RowIndex].Cells["colDescription"].Value.ToString().IndexOf("D2") != 0)
                        counttotal += (Convert.ToDecimal(gvDenomination.Rows[e.RowIndex].Cells["D2"].Value) / 100) * Convert.ToDecimal(gvDenomination.Rows[e.RowIndex].Cells["Count"].Value);
                    this.TotalAmount = counttotal;
                    if (counttotal != 0 && counttotal>Amount)
                        RefundAmount = Math.Abs(counttotal - Amount);
                    else
                        RefundAmount = 0;
                    this.DenoData[e.RowIndex].DenoCount = Convert.ToInt32(gvDenomination.Rows[e.RowIndex].Cells["Count"].Value);
                   
                    ////Added by ASDA**
                    //if (this.ParentFormId == "TLMVEW00075")
                    //{
                    //    if (txtTotalAmount.Text.ToString() != "0.00")
                    //    {
                    //        // if (txtRefundAmount.Text.ToString() != "0.00" && txtTotalAmount.Text != txtAmount.Text)
                    //        if (txtTotalAmount.Text != txtAmount.Text)
                    //        {
                    //            CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00037);    //Invalid Amount
                    //            gvDenomination.Rows[e.RowIndex].Cells["Count"].Selected = true;                                
                    //        }
                    //    }
                    //}

                }
            }
            catch
            { }
        }

        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void gvDenomination_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            if (gvDenomination.CurrentCell.OwningColumn.Name.Equals("Count"))
            {
                TextBox combo = e.Control as TextBox;
                if (combo != null)
                {
                    combo.KeyPress -= new KeyPressEventHandler(NumericTextBox_KeyPress);
                    combo.KeyPress += new KeyPressEventHandler(NumericTextBox_KeyPress);
                }
            }
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.Controller.ClearControls();
        }
        
        #endregion

        #region Methods

        private void InitializeControls()
        {
            this.BindDenoInformation();
            this.BindCounterNo();
            this.DisableControls("Deno.DisableControls");
            this.Amount = this.DefaultAmount;       
        }

        public void BindDenoInformation()
        {
            // Get Deno data by Currency.
            gvDenomination.DataSource = null;
            Deno = CXCLE00002.Instance.GetListObject<TLMDTO00012>("Deno.SelectByCurrencyCode", new object[] { this.CurrencyCode,true });
            gvDenomination.AutoGenerateColumns = false;
            gvDenomination.DataSource = Deno; 
        }

        private void BindCounterNo()
        {
            // Get Counter No data. Wrong
            this.BranchCode = CurrentUserEntity.BranchCode;

            foreach (TLMDTO00012 denoInfo in DenoData)
                denoInfo.CounterNo = this.CounterNo;
        }

        private bool CounterChecking()
        {
            switch (this.TransactionStatus)
            {
                case CXDMD00008.Payment:
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
                case CXDMD00008.Received:
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
                case CXDMD00008.Non:
                        CounterType = string.Empty;
                        this.CounterNo = CurrentUserEntity.CounterList[0].CounterNo;
                        return true;
                    break;
            }
            return false;
        }

        #endregion

        private void gvDenomination_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        { 
            DataGridViewRow dataRow = (DataGridViewRow)gvDenomination.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            if (e.RowIndex > -1 && (!dataRow.IsNewRow || cell.OwningColumn.Name.Equals("Count")))
            {
                if (cell.OwningColumn.Name.Equals("Count"))
                {
                    if (cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
                    {    
                        gvDenomination.EndEdit();
                        gvDenomination.CurrentCell.GetEditedFormattedValue(e.RowIndex, 0);
                        //gvDenomination.CurrentCell = dataRow.Cells["Count"];
                        //dataRow.Cells["Count"].Value = gvDenomination.CurrentCell;
                        gvDenomination.Rows[e.RowIndex].Cells["Count"].Value = 0;
                        gvDenomination.BeginEdit(true);
                        e.Cancel = true;
                    }
                    if (cell.EditedFormattedValue.ToString().StartsWith(Decimal.Zero.ToString()) && cell.EditedFormattedValue.ToString().Length > 1)
                    {
                        gvDenomination.EndEdit();
                        gvDenomination.CurrentCell.GetEditedFormattedValue(e.RowIndex, 0);
                        //gvDenomination.CurrentCell = dataRow.Cells["Count"];
                        //dataRow.Cells["Count"].Value = gvDenomination.CurrentCell;
                        gvDenomination.Rows[e.RowIndex].Cells["Count"].Value = 0;
                        gvDenomination.BeginEdit(true);
                        e.Cancel = true;
                    }
                }
            }            
        }                 
    }
}
