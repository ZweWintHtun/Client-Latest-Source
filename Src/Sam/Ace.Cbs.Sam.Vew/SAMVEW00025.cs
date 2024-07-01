// <CreatedUser>KSW</CreatedUser>
// <CreatedDate>08/06/2013</CreatedDate>
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
    public partial class SAMVEW00025 : BaseDockingForm, ISAMVEW00025
    {
        public SAMVEW00025()
        {
            InitializeComponent();
        }

        #region Properties
        private int rowindex = 0;
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

        private TLMDTO00029 viewData;
        public TLMDTO00029 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new TLMDTO00029();
               
                this.viewData.Id = this.Id;
                this.viewData.BranchCode = this.BranchCode;
                this.viewData.TelaxCharges = this.TlxCharges;
                this.viewData.DrawingAccount = this.DrawAc;
                this.viewData.EncashAccount = this.EncashAc;
                this.viewData.IBSComAccount = this.IBSComAc;
                this.viewData.TelaxAccount = this.TelexAc;
                this.viewData.IRPOAccount = this.IRPOAC;
                this.viewData.SourceBranchCode = this.SourceBranch;
                this.viewData.Currency = this.Currency;
                this.viewData.CreatedUserId = CurrentUserEntity.CurrentUserID;

                return this.viewData;
            }
            set { this.viewData = value; }
        }

        private ISAMCTL00025 controller;
        public ISAMCTL00025 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                controller.RemitBrIblView =this;
            }
        }

        public IList<TLMDTO00030> RmitIblRates { get; set; }

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
            //*********Edited By SYM*************************************
            //cboBranchCode.DisplayMember = "BranchCode";
            //cboBranchCode.ValueMember = "BranchCode";
            //cboBranchCode.DataSource = this.Controller.SelectBranchCode();
            //cboBranchCode.SelectedIndex = -1;
            IList<BranchDTO> branches = this.controller.SelectBranchCode();
            cboBranchCode.ValueMember = "BranchAlias";
            cboBranchCode.DisplayMember = "BranchAlias";
            cboBranchCode.DataSource = branches;
            cboBranchCode.SelectedIndex = -1;
        }

        public void dgVRemitIblBr_DataBind()
        {
            //TLMDTO00030 info = new TLMDTO00030(); //Comment by ASDA
            //if (this.RmitIblRates != null) //Comment by ASDA
            //    this.RmitIblRates.Add(info);  //Comment by ASDA

            gvRemittanceBranchAndRate.AutoGenerateColumns = false;
            gvRemittanceBranchAndRate.DataSource = this.RmitIblRates != null ? (this.RmitIblRates.Count == 0 ? null : this.RmitIblRates) : null;          
            //gvRemittanceBranchAndRate.Refresh();


            if (gvRemittanceBranchAndRate.DataSource != null)
            {
                gvRemittanceBranchAndRate.AllowUserToAddRows = true;
                //gvIBLRate.Rows.Add();
                DataTable dt = new DataTable();
                dt.Columns.Add("StartNo", typeof(decimal));
                dt.Columns.Add("EndNo", typeof(decimal));
                dt.Columns.Add("Rate", typeof(decimal));
                dt.Columns.Add("FixAmount", typeof(decimal));
                dt.Columns.Add("TrDiscount", typeof(decimal));
                dt.Columns.Add("CSDiscount", typeof(decimal));

                if (this.RmitIblRates.Count > 0)
                {
                    foreach (TLMDTO00030 data in this.RmitIblRates)
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
                    gvRemittanceBranchAndRate.AutoGenerateColumns = false;
                    gvRemittanceBranchAndRate.DataSource = dt;
                }
            }
            else
            {
                //gvIBLRate.DataSource = dt;
                gvRemittanceBranchAndRate.Rows.Clear();
                gvRemittanceBranchAndRate.Refresh();
            }
        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.dgVRemitIblBr_DataBind();
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
            this.RmitIblRates = null;
            this.dgVRemitIblBr_DataBind();

            if (gvRemittanceBranchAndRate.Rows.Count == 0)
                this.gvRemittanceBranchAndRate.Rows.Add();

            this.SourceBranch = CurrentUserEntity.BranchCode;
            this.Status = "Save";
        }

        public IList<TLMDTO00030> GetItemCollection()
        {
            IList<TLMDTO00030> RmitIblRates = new List<TLMDTO00030>();
            gvRemittanceBranchAndRate.AllowUserToAddRows = false;
            foreach (DataGridViewRow dgvr in gvRemittanceBranchAndRate.Rows)
            {
                if (dgvr.Cells["colStartAmount"].Value != null && dgvr.Cells["colStartAmount"].Value.Equals(DBNull.Value) == false)
                {
                    TLMDTO00030 rmitRateInfo = new TLMDTO00030();
                    rmitRateInfo.BranchCode = this.BranchCode;
                    rmitRateInfo.Currency = this.Currency;
                    rmitRateInfo.SourceBranchCode = this.SourceBranch;

                    //for Start Amount
                    //if (dgvr.Cells["colStartAmount"].Value == null || dgvr.Cells["colStartAmount"].Value.Equals(DBNull.Value) == true)
                    //{
                    //    dgvr.Cells["colStartAmount"].Value = decimal.Zero;
                    //}
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
                    if (gvRemittanceBranchAndRate.RowCount != RmitIblRates.Count)
                    {
                        RmitIblRates.Add(rmitRateInfo);
                    }
                }
            }

            return RmitIblRates;
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
            this.Controller.Save(this.ViewData, this.GetItemCollection());
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.Controller.ClearErrors();
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            if (this.Status == "Update")
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

        private void SAMVEW00025_Load(object sender, EventArgs e)
        {
            //Enatble Disable Controls
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);         
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

            if(!temp.Contains(".") && intKeyCode == 46 )
                e.Handled=false;
            else if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' )
                e.Handled = true;

        }

        private void gvRemittanceBranchAndRate_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox textbox = e.Control as TextBox;
            if (textbox != null)
            {
                textbox.KeyPress -= new KeyPressEventHandler(NumericTextBox_KeyPress);
                textbox.KeyPress += new KeyPressEventHandler(NumericTextBox_KeyPress);
            }    
        }


        private void gvRemittanceBranchAndRate_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridViewRow dataRow = (DataGridViewRow)gvRemittanceBranchAndRate.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            if (e.RowIndex > -1 && (!dataRow.IsNewRow))
            {
              
                if (cell.OwningColumn.Name.Equals("colStartAmount"))
                {
                    gvRemittanceBranchAndRate.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType = Type.GetType("System.Decimal");
                    if (cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
                    {
                        this.Failure("MV00037"); // Invalid amount
                        gvRemittanceBranchAndRate.CurrentCell = dataRow.Cells["colStartAmount"];
                        gvRemittanceBranchAndRate.BeginEdit(true);
                        e.Cancel = true;
                        gvRemittanceBranchAndRate.CurrentCell.Value = decimal.Zero;
                    }

                    if (gvRemittanceBranchAndRate.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString() == "0.000" ||
                        gvRemittanceBranchAndRate.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.Equals(decimal.Zero.ToString()))
                    {
                        dataRow.Cells["colStartAmount"].Value = decimal.Zero;
                        return;
                    }                 

                }
                if (cell.OwningColumn.Name.Equals("colEndAmount"))
                {
                    gvRemittanceBranchAndRate.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType = Type.GetType("System.Decimal");
                    if (cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
                    {
                        this.Failure("MV00037"); // Invalid Amount
                        gvRemittanceBranchAndRate.CurrentCell = dataRow.Cells["colEndAmount"];
                        gvRemittanceBranchAndRate.BeginEdit(true);
                        e.Cancel = true;
                        gvRemittanceBranchAndRate.CurrentCell.Value = decimal.Zero;
                    }

                    if (gvRemittanceBranchAndRate.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString() == "0.000" ||
                        gvRemittanceBranchAndRate.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.Equals(decimal.Zero.ToString()))
                    {
                        dataRow.Cells["colEndAmount"].Value = decimal.Zero;
                        return;
                    }
                  

                }
                if (cell.OwningColumn.Name.Equals("colRate"))
                {
                    gvRemittanceBranchAndRate.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType = Type.GetType("System.Decimal");
                    if (cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
                    {
                        this.Failure("MV20032"); // Invalid Rate
                        gvRemittanceBranchAndRate.CurrentCell = dataRow.Cells["colRate"];
                        gvRemittanceBranchAndRate.BeginEdit(true);
                        e.Cancel = true;
                        gvRemittanceBranchAndRate.CurrentCell.Value = decimal.Zero;
                    }
                   
                    if (gvRemittanceBranchAndRate.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString() == "0.000" ||
                        gvRemittanceBranchAndRate.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.Equals(decimal.Zero.ToString()))
                    {
                        dataRow.Cells["colRate"].Value = decimal.Zero;
                        return;
                    }
               
                }

                if (cell.OwningColumn.Name.Equals("colFixAmount"))
                {
                    gvRemittanceBranchAndRate.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType = Type.GetType("System.Decimal");
                    if (cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
                    {
                        this.Failure("MV20033"); // Invalid Fixed Amount
                        gvRemittanceBranchAndRate.CurrentCell = dataRow.Cells["colFixAmount"];
                        gvRemittanceBranchAndRate.BeginEdit(true);
                        e.Cancel = true;
                        gvRemittanceBranchAndRate.CurrentCell.Value = decimal.Zero;
                    }
                    if (gvRemittanceBranchAndRate.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString() == "0.000" ||
                        gvRemittanceBranchAndRate.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.Equals(decimal.Zero.ToString()))
                    {
                        dataRow.Cells["colFixAmount"].Value = decimal.Zero;
                        return;
                    }

                 
                }

                if (cell.OwningColumn.Name.Equals("colTrdiscount"))
                {

                    gvRemittanceBranchAndRate.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType = Type.GetType("System.Decimal");
                    if (cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
                    {
                        this.Failure("ME90018"); // Invalid Parameter Value
                        gvRemittanceBranchAndRate.CurrentCell = dataRow.Cells["colTrdiscount"];
                        gvRemittanceBranchAndRate.BeginEdit(true);
                        e.Cancel = true;
                        gvRemittanceBranchAndRate.CurrentCell.Value = decimal.Zero;
                    }
                    if (gvRemittanceBranchAndRate.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString() == "0.000" ||
                        gvRemittanceBranchAndRate.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.Equals(decimal.Zero.ToString()))
                    {
                        dataRow.Cells["colTrdiscount"].Value = decimal.Zero;
                        return;
                    }
                    
                }

                if (cell.OwningColumn.Name.Equals("colCSdiscount"))
                {

                    gvRemittanceBranchAndRate.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType = Type.GetType("System.Decimal");
                    if (cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
                    {
                        this.Failure("ME90018"); // Invalid Parameter Value
                        gvRemittanceBranchAndRate.CurrentCell = dataRow.Cells["colCSdiscount"];
                        gvRemittanceBranchAndRate.BeginEdit(true);
                        e.Cancel = true;
                        gvRemittanceBranchAndRate.CurrentCell.Value = decimal.Zero;
                    }

                    if (gvRemittanceBranchAndRate.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString() == "0.000" ||
                        gvRemittanceBranchAndRate.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.Equals(decimal.Zero.ToString()))
                    {
                        dataRow.Cells["colCSdiscount"].Value = decimal.Zero;
                        return;
                    }
                    
                }

              
            }
           
        }

        private void txtTelexCharge_KeyPress(object sender, KeyPressEventArgs e)
        {
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

        private void txttelexAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
            e.Handled = e.KeyChar == ' ';
        }

        private void txtIRpoaccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
            e.Handled = e.KeyChar == ' ';
        }

        private void txtDrawingAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
            e.Handled = e.KeyChar == ' ';
        }


        
        //private void gvRemittanceBranchAndRate_CellClick(object sender, DataGridViewCellEventArgs e)  //comment by ASDA
        //{
        //    //if (gvRemittanceBranchAndRate.Rows.Count == 3) //old comment 
        //    //    gvRemittanceBranchAndRate.AllowUserToAddRows = false; //old comment
        //}

        #endregion

    }
}
