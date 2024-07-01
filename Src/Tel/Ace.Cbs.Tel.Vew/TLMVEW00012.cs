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

namespace Ace.Cbs.Tel.Vew
{
    public partial class TLMVEW00012 : BaseDockingForm, ITLMVEW00012
    {
        #region Constrator

        public TLMVEW00012()
        {
            InitializeComponent();
        }

        public TLMVEW00012(decimal refundAmount, IList<TLMDTO00012> denoData,string parentFormId )
        {
            InitializeComponent();
            this.DefaultRefundAmount = refundAmount;
            this.Deno = denoData;
            this.ParentFormId = parentFormId;
        }

        #endregion

        #region Properties

        private ITLMCTL00012 controller;
        public ITLMCTL00012 Controller
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

        public decimal DefaultRefundAmount { get; set; }

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

        public decimal SurPlus
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtSurPlus.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtSurPlus.Text = value.ToString(); }
        }

        public decimal Shortage
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtShortage.Text.Replace("-",string.Empty), out result);
                return Math.Round(result, 2);
            }
            set { this.txtShortage.Text = "-"+value.ToString(); }
        }

        private string parentFormId = string.Empty;
        public string ParentFormId
        {
            get { return this.parentFormId; }
            set { this.parentFormId = value; }
        }

        public string CurrencyCode { get; set; }

        public string RefundString { get; set; }

        public decimal counttotal { get; set; }

        public decimal DenoAdjustAmount { get; set; }

        public IList<TLMDTO00012> Deno { get; set; }

        #endregion

        #region Events

        private void TLMVEW00012_Load(object sender, EventArgs e)
        {
            // Button Enable Disabled
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            this.InitializeControls();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            if (Controller.Save())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
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
                    TotalAmount = Math.Round(counttotal, 2);
                }
                this.DenoData[e.RowIndex].RefundCount = Convert.ToInt32(gvDenomination.Rows[e.RowIndex].Cells["Count"].Value);
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
                    TotalAmount = Math.Round(counttotal, 2); 
                    
                    if (this.TotalAmount > this.RefundAmount)
                    {
                        this.Shortage = Math.Abs(this.TotalAmount - this.RefundAmount);
                        this.SurPlus = 0;
                    }
                    else if (this.TotalAmount < this.RefundAmount)
                    {
                        this.SurPlus = Math.Abs(this.RefundAmount - this.TotalAmount);
                        this.Shortage = 0;
                    }
                    else
                    {
                        this.SurPlus = 0;
                        this.Shortage = 0;
                    }
                    this.DenoData[e.RowIndex].RefundCount = Convert.ToInt32(gvDenomination.Rows[e.RowIndex].Cells["Count"].Value);
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
            this.RefundAmount = this.DefaultRefundAmount;
            this.BindDenoInformation();
            this.DisableControls("DenoRefund.DisableControls");
            this.DenoAdjustAmount = Convert.ToDecimal(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.DenoAdjustAmount));
        }

        public void BindDenoInformation()
        {
            gvDenomination.DataSource = null;
            gvDenomination.AutoGenerateColumns = false;
            gvDenomination.DataSource = Deno;
        }

        #endregion
        
    }
}
