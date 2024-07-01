//----------------------------------------------------------------------
// <copyright file="SAMVEW00026.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Lenovo</CreatedUser>
// <CreatedDate>08/04/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Sam.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Admin.DataModel;
using System.Data;

namespace Ace.Cbs.Sam.Vew
{
    public partial class SAMVEW00026 : BaseDockingForm, ISAMVEW00026
    {
        #region Constrator

        public SAMVEW00026()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        public int Id { get; set; }

        public string BranchCode
        {
            get
            {
                if (this.cboBranchCode.SelectedValue == null)
                {
                    return string.Empty;
                }
                else
                {
                    return this.cboBranchCode.SelectedValue.ToString();
                }
            }
            set { this.cboBranchCode.SelectedValue = value.ToString(); }
        }

        public string Currency
        {
            get
            {
                if (this.cboCurrency.SelectedValue == null)
                {
                    return string.Empty;
                }
                else
                {
                    return this.cboCurrency.SelectedValue.ToString();
                }
            }
            set { this.cboCurrency.SelectedValue = value.ToString(); }
        }

        public decimal TlxCharges
        {
            get { return Convert.ToDecimal(this.txtTelexCharge.Text); }
            set { this.txtTelexCharge.Text = value.ToString(); }
        }

        public string DrawAc
        {
            get { return this.txtDrawingAccount.Text; }
            set { this.txtDrawingAccount.Text = value; }
        }

        public string EncashAc
        {
            get { return this.txtEashaccount.Text; }
            set { this.txtEashaccount.Text = value; }
        }

        public string IBSComAc
        {
            get { return this.txComssAccount.Text; }
            set { this.txComssAccount.Text = value; }
        }

        public string TelexAc
        {
            get { return this.txttelexAccount.Text; }
            set { this.txttelexAccount.Text = value; }
        }

        public string IRPOAC
        {
            get { return this.txtIRpoaccount.Text; }
            set { this.txtIRpoaccount.Text = value; }
        }

        public string Status { get; set; }
        
        public string SourceBranch { get; set; }

        private TLMDTO00028 _previousRemittanceDTO;
        public TLMDTO00028 PreviousRemittanceDto
        {
            get
            {
                if (this._previousRemittanceDTO == null)
                    return new TLMDTO00028();
                return _previousRemittanceDTO;
            }
            set { this._previousRemittanceDTO = value; }

        }
        private TLMDTO00028 viewData;
        public TLMDTO00028 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new TLMDTO00028();
                
                this.viewData.Id = this.Id;
                this.viewData.BranchCode =  this.BranchCode;
                this.viewData.TelaxCharges =  this.TlxCharges;
                this.viewData.DrawingAccount =  this.DrawAc;
                this.viewData.EncashAccount = this.EncashAc;
                this.viewData.IBSComAccount = this.IBSComAc;
                this.viewData.TelaxAccount = this.TelexAc;
                this.viewData.IRPOAccount = this.IRPOAC;
                this.viewData.SourceBranchCode = this.SourceBranch;
                this.viewData.Currency = this.Currency;
                this.viewData.CreatedUserId = CurrentUserEntity.CurrentUserID;
                //this.viewData.Status = this.Status;

                return this.viewData;
            }
            set { this.viewData = value; }
        }

        private ISAMCTL00026 controller;
        public ISAMCTL00026 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                controller.RemitBrView = this;
            }
        }

        public IList<TLMDTO00032> RmitRates { get; set; }
        public IList<TLMDTO00032> RemitRates { get; set; }
        
        #endregion

        #region Method

        private void cboCurrency_DataBind()
        {
            //IList<CurrencyDTO> CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            IList<CurrencyDTO> CurrencyList = controller.GetCurrency();
            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = CurrencyList;
            cboCurrency.SelectedIndex = 0;
        }

        private void cboBranchCode_DataBind()
        {
            IList<BranchDTO> branches = controller.SelectBranchCode();
            //IList<BranchDTO> branches = CXCLE00001.Instance.SelectAllBranch();
            cboBranchCode.ValueMember = "BranchAlias";
            cboBranchCode.DisplayMember = "BranchAlias";
            cboBranchCode.DataSource = branches;
            cboBranchCode.SelectedIndex = -1;
        }

        public void dgVRemitBr_DataBind()
        {
            gvIBLRate.AutoGenerateColumns = false;
            gvIBLRate.DataSource = this.RmitRates != null ? (this.RmitRates.Count == 0 ? null : this.RmitRates) : null;
            if (gvIBLRate.DataSource != null)
            {
                gvIBLRate.AllowUserToAddRows = true;
                //gvIBLRate.Rows.Add();
                DataTable dt = new DataTable();
                dt.Columns.Add("StartNo", typeof(decimal));
                dt.Columns.Add("EndNo", typeof(decimal));
                dt.Columns.Add("Rate", typeof(decimal));
                dt.Columns.Add("FixAmount", typeof(decimal));
                dt.Columns.Add("TrDiscount", typeof(decimal));
                dt.Columns.Add("CSDiscount", typeof(decimal));

                if (this.RmitRates.Count > 0)
                {
                    foreach (TLMDTO00032 data in this.RmitRates)
                    {
                        DataRow dr = dt.NewRow();
                        dr["StartNo"] = Convert.ToString(data.StartNo);
                        dr["EndNo"] = Convert.ToString(data.EndNo);
                        dr["Rate"] = Convert.ToString(data.Rate);
                        dr["FixAmount"] = Convert.ToString(data.FixAmount);
                        dr["TrDiscount"] = Convert.ToString(data.TrDiscount);
                        dr["CSDiscount"] = Convert.ToString(data.CsDiscount);
                        dt.Rows.Add(dr);
                    }
                    gvIBLRate.AutoGenerateColumns = false;
                    gvIBLRate.DataSource = dt;
                }
               
            }
            else
            {
                //gvIBLRate.DataSource = dt;
                gvIBLRate.Rows.Clear();
                gvIBLRate.Refresh();
            }
        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.dgVRemitBr_DataBind();
            this.InitializeControls();
        }

        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        private void InitializeControls()
        {
            this.cboBranchCode.SelectedIndex = -1;
            this.Id = 0;
            this.TlxCharges = 0;
            this.DrawAc = string.Empty;
            this.EncashAc = string.Empty;
            this.IBSComAc = string.Empty;
            this.TelexAc = string.Empty;
            this.IRPOAC = string.Empty;
            this.cboCurrency.SelectedIndex = 0;         
            this.RmitRates=null;
            this.dgVRemitBr_DataBind();
           // this.dgVRemitBr_DataBind();

            if(gvIBLRate.Rows.Count==0)
                this.gvIBLRate.Rows.Add();

            this.SourceBranch = CurrentUserEntity.BranchCode;
            
            this.Status = "Save";
        }

        public IList<TLMDTO00032> GetItemCollection()
        {
            IList<TLMDTO00032>  RmitRates = new List<TLMDTO00032>();
            gvIBLRate.AllowUserToAddRows = false;
            foreach (DataGridViewRow dgvr in gvIBLRate.Rows)
                {
                    if (dgvr.Cells["colStartAmount"].Value != null && dgvr.Cells["colStartAmount"].Value.Equals(DBNull.Value) == false)
                    {
                        TLMDTO00032 rmitRateInfo = new TLMDTO00032();
                        rmitRateInfo.BranchCode = this.BranchCode;
                        rmitRateInfo.Currency = this.Currency;
                        rmitRateInfo.SourceBranchCode = this.SourceBranch;
                        rmitRateInfo.StartNo = Convert.ToDecimal(dgvr.Cells["colStartAmount"].Value);

                        //for End Amount
                        if (dgvr.Cells["colEndAmount"].Value == null || dgvr.Cells["colEndAmount"].Value.Equals(DBNull.Value) == true)
                        {
                            dgvr.Cells["colEndAmount"].Value = decimal.Zero;
                        }
                        rmitRateInfo.EndNo = Convert.ToDecimal(dgvr.Cells["colEndAmount"].Value);

                        //for Rate
                        if (dgvr.Cells["colRate"].Value == null || dgvr.Cells["colRate"].Value.Equals(DBNull.Value) == true)
                        {
                            dgvr.Cells["colRate"].Value = decimal.Zero;
                        }
                        rmitRateInfo.Rate = Convert.ToDecimal(dgvr.Cells["colRate"].Value);

                        //For Fix Amount
                        if (dgvr.Cells["colFixAmount"].Value == null || DBNull.Value.Equals(dgvr.Cells["colFixAmount"].Value))
                        {
                            dgvr.Cells["colFixAmount"].Value = decimal.Zero;
                        }
                        rmitRateInfo.FixAmount = Convert.ToDecimal(dgvr.Cells["colFixAmount"].Value);

                        //For Tr Discount 
                        if (dgvr.Cells["colTrdiscount"].Value == null || dgvr.Cells["colTrdiscount"].Value == DBNull.Value)
                        {
                            dgvr.Cells["colTrdiscount"].Value = decimal.Zero;
                        }
                        rmitRateInfo.TrDiscount = Convert.ToDecimal(dgvr.Cells["colTrdiscount"].Value);

                        //For Cs Discount
                        if (dgvr.Cells["colCSdiscount"].Value == null || Convert.IsDBNull(dgvr.Cells["colCSdiscount"].Value))
                        {
                            dgvr.Cells["colCSdiscount"].Value = decimal.Zero;
                        }
                        rmitRateInfo.CsDiscount = Convert.ToDecimal(dgvr.Cells["colCSdiscount"].Value);

                        rmitRateInfo.CreatedUserId = CurrentUserEntity.CurrentUserID;
                        if (gvIBLRate.RowCount != RmitRates.Count)
                        {
                            RmitRates.Add(rmitRateInfo);
                        }
                    }
                }

            return RmitRates;
        }

        #endregion

        #region Event

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.Currency) && !string.IsNullOrEmpty(this.BranchCode))
            {
                this.controller.BindContorls();
            }
        }
        
        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.Controller.Save(this.ViewData,this.GetItemCollection());
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            //this.gvIBLRate.DataSource = null;
            //this.dgVRemitBr_DataBind();
            this.Controller.ClearErrors();
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            if (this.Status=="Update")
            {
                if (CXUIMessageUtilities.ShowMessageByCode("MC90001") == DialogResult.Yes)
                {
                    this.Controller.Delete(this.ViewData);
                }
            }
            else
            {
                this.Failure("MV90012");
            }
        }

        private void SAMVEW00026_Load(object sender, EventArgs e)
        {
            //Enatble Disable Controls
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            //this.dgVRemitBr_DataBind();
            this.InitializeControls();
            this.cboCurrency_DataBind();
            this.cboBranchCode_DataBind();

        }

        private void dgVRemitBrEntry_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value.ToString().Equals("Undefined"))
            {
                e.CellStyle.ForeColor = Color.Blue;
            }
        }

        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Int32 intKeyCode = Convert.ToInt32(e.KeyChar);
            TextBox txt = (TextBox)sender;
            string temp = txt.Text;

            if (!temp.Contains(".") && intKeyCode == 46)
                e.Handled = false;
            else if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void gvIBLRate_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
                TextBox textbox = e.Control as TextBox;
                if (textbox != null)
                {
                    textbox.KeyPress -= new KeyPressEventHandler(NumericTextBox_KeyPress);
                    textbox.KeyPress += new KeyPressEventHandler(NumericTextBox_KeyPress);
                }
                //if (gvIBLRate.Rows.Count == 3)
                //    gvIBLRate.AllowUserToAddRows = false;
        }

        //private void gvIBLRate_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    //if (gvIBLRate.Rows.Count == 3)
        //    //    gvIBLRate.AllowUserToAddRows = false;
        //}

        //Added by ASDA**
        private void gvIBLRate_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridViewRow dataRow = (DataGridViewRow)gvIBLRate.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            if (e.RowIndex > -1 && (!dataRow.IsNewRow))
            {
                if (cell.OwningColumn.Name.Equals("colStartAmount"))
                {
                    gvIBLRate.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType = Type.GetType("System.Decimal");
                    if (cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
                    {
                        this.Failure("MV00037"); // Invalid amount
                        gvIBLRate.CurrentCell = dataRow.Cells["colStartAmount"];
                        gvIBLRate.BeginEdit(true);
                        e.Cancel = true;
                        gvIBLRate.CurrentCell.Value = decimal.Zero;
                    }
                    if (gvIBLRate.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString() == "0.000" ||
                        gvIBLRate.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.Equals(decimal.Zero.ToString()))
                    {
                        dataRow.Cells["colStartAmount"].Value = decimal.Zero;
                        return;
                    }
                    //else
                    //{
                    //    dataRow.Cells["colStartAmount"].Value = cell.EditedFormattedValue.ToString();
                    //}
                }
                if (cell.OwningColumn.Name.Equals("colEndAmount"))
                {
                    gvIBLRate.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType = Type.GetType("System.Decimal");
                    if (cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
                    {
                        this.Failure("MV00037"); // Invalid Amount
                        gvIBLRate.CurrentCell = dataRow.Cells["colEndAmount"];
                        gvIBLRate.BeginEdit(true);
                        e.Cancel = true;
                        gvIBLRate.CurrentCell.Value = decimal.Zero;
                    }
                    if (gvIBLRate.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString() == "0.000" ||
                       gvIBLRate.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.Equals(decimal.Zero.ToString()))
                    {
                        dataRow.Cells["colEndAmount"].Value = decimal.Zero;
                        return;
                    }
                   
                }
                if (cell.OwningColumn.Name.Equals("colRate"))
                {
                    gvIBLRate.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType = Type.GetType("System.Decimal");
                    if (cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
                    {
                        this.Failure("MV20032"); // Invalid Rate
                        gvIBLRate.CurrentCell = dataRow.Cells["colRate"];
                        gvIBLRate.BeginEdit(true);
                        e.Cancel = true;
                        gvIBLRate.CurrentCell.Value = decimal.Zero;
                    }
                    if (gvIBLRate.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString() == "0.000" ||
                       gvIBLRate.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.Equals(decimal.Zero.ToString()))
                    {
                        dataRow.Cells["colRate"].Value = decimal.Zero;
                        return;
                    }
                   
                }

                if (cell.OwningColumn.Name.Equals("colFixAmount"))
                {
                    gvIBLRate.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType = Type.GetType("System.Decimal");
                    if (cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
                    {
                        this.Failure("MV20033"); // Invalid Fixed Amount
                        gvIBLRate.CurrentCell = dataRow.Cells["colFixAmount"];
                        gvIBLRate.BeginEdit(true);
                        e.Cancel = true;
                        gvIBLRate.CurrentCell.Value = decimal.Zero;
                    }
                    if (gvIBLRate.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString() == "0.000" ||
                       gvIBLRate.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.Equals(decimal.Zero.ToString()))
                    {
                        dataRow.Cells["colFixAmount"].Value = decimal.Zero;
                        return;
                    }
                   
                }
                if (cell.OwningColumn.Name.Equals("colTrdiscount"))
                {
                    gvIBLRate.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType = Type.GetType("System.Decimal");
                    if (cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
                    {
                        this.Failure("ME90018"); // Invalid Parameter Value
                        gvIBLRate.CurrentCell = dataRow.Cells["colTrdiscount"];
                        gvIBLRate.BeginEdit(true);
                        e.Cancel = true;
                        gvIBLRate.CurrentCell.Value = decimal.Zero;
                    }
                    if (gvIBLRate.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString() == "0.000" ||
                       gvIBLRate.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.Equals(decimal.Zero.ToString()))
                    {
                        dataRow.Cells["colTrdiscount"].Value = decimal.Zero;
                        return;
                    }
                   
                }
                if (cell.OwningColumn.Name.Equals("colCSdiscount"))
                {
                    gvIBLRate.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType = Type.GetType("System.Decimal");
                    if (cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
                    {
                        this.Failure("ME90018"); // Invalid Parameter Value
                        gvIBLRate.CurrentCell = dataRow.Cells["colCSdiscount"];
                        gvIBLRate.BeginEdit(true);
                        gvIBLRate.CurrentCell.Value = decimal.Zero;
                    }

                    if (gvIBLRate.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString() == "0.000" ||
                        gvIBLRate.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.Equals(decimal.Zero.ToString()))
                    {
                        dataRow.Cells["colCSdiscount"].Value = decimal.Zero;
                        return;
                    }
                   
                }
            }
           
        }
        //End**

        #endregion

        private void txtTelexCharge_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == ' ';
        }

        private void txtDrawingAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
            e.Handled = e.KeyChar == ' ';
        }

        private void txtEashaccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
            e.Handled = e.KeyChar == ' ';
        }

        private void txComssAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
            e.Handled = e.KeyChar == ' ';
        }

        private void txtIRpoaccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
            e.Handled = e.KeyChar == ' ';
        }

        private void txttelexAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
            e.Handled = e.KeyChar == ' ';
        }

    }
}