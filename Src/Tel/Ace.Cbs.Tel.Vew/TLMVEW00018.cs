//----------------------------------------------------------------------
// <copyright file="ITLMCTL00018.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hnin Thazin Shwe</CreatedUser>
// <CreatedDate>07/11/2013</CreatedDate>
// <UpdatedUser>Ye Mann Aung</UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
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
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Tel.Vew
{
    public partial class TLMVEW00018 : BaseDockingForm, ITLMVEW00018
    {
        #region"Constructor"
        public TLMVEW00018()
        {
            InitializeComponent();
        }
        #endregion

        #region "Controller"
        private IList<TLMDTO00054> remitDataSource;
        public IList<TLMDTO00054> RemitDataSource
        {
            get
            {
                if (this.remitDataSource == null)
                    this.remitDataSource = new List<TLMDTO00054>();

                return this.remitDataSource;
            }
            set
            {
                this.remitDataSource = value;
            }
        }

        private ITLMCTL00018 controller;
        public ITLMCTL00018 Controller
        {
            set
            {
                this.controller = value;
                controller.View = this;
            }
            get
            {
                return this.controller;
            }

        }
        #endregion

        #region"Variable"
        private string drawerbank { get; set; }
        private string cbodrawerbank { get; set; }
        public decimal totalamount { get; set; }
        public decimal totalcomission { get; set; }
        public decimal endAmount { get; set; }
        private decimal amount;
        public decimal totaltelexcharges { get; set; }
        public bool IsCancelExit { get; set; }
        IList<BranchDTO> BranchList { get; set; }
        public bool Flag { get; set; }
        public string IncomeType { get; set; }
        public bool status { get; set; }
        public string tran { get; set; }
        #endregion

        # region"View Data Properties"

        public string TransactionStatus
        {
            get { return this.FormName; }
        }

        public string GroupNo
        {
            get { return this.txtGroupNo.Text; }
            set { this.txtGroupNo.Text = value; }
        }

        public string CurrencyCode
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
                //this.cboCurrency.SelectedValue = value;
            }
        }

        public string AccountNo
        {
            get { return this.mtxtAccountNo.Text; }
            set { this.mtxtAccountNo.Text = value; }
        }

        public string SenderName
        {
            get { return this.txtName.Text; }
            set { this.txtName.Text = value; }
        }

        public string NRC
        {
            get { return this.txtNRC.Text; }
            set { this.txtNRC.Text = value; }
        }

        public string Address
        {
            get { return this.txtAddress.Text; }
            set { this.txtAddress.Text = value; }
        }

        public string PhoneNo
        {
            get { return this.txtPhone.Text; }
            set { this.txtPhone.Text = value; }
        }

        public string Narration
        {
            get { return this.txtNarration.Text; }
            set { this.txtNarration.Text = value; }
        }

        public decimal TotalAmount
        {
            get { return Convert.ToDecimal(this.txtTotalAmount.Text); }
            set { this.txtTotalAmount.Text = Convert.ToString(value); }
        }

        public string ChequeNo
        {
            get { return this.txtChequeNo.Text; }
            set { this.txtChequeNo.Text = value; }
        }

        public bool IsVIP
        {
            get { return this.chkVIPCustomer.Checked; }
            set { this.chkVIPCustomer.Checked = value; }
        }

        public bool IsCash
        {
            get { return this.rdoIncomeByCash.Checked; }
            set { this.rdoIncomeByCash.Checked = value; }
        }

        public bool IsIncome
        {
            get { return this.rdoIncome.Checked; }
            set { this.rdoIncome.Checked = value; }
        }

        public bool IsTakeIncome
        {
            get { return this.chkTakeIncome.Checked; }
            set { this.chkTakeIncome.Checked = value; }
        }

        public bool IsChequeNoEnable
        {
            get { return this.txtChequeNo.Enabled; }
            set { this.txtChequeNo.Enabled = value; }
        }

        public bool IsDrawingGroupBox
        {
            get { return this.grpDrawing.Enabled; }
            set { this.grpDrawing.Enabled = value; }
        }

        public IList<TLMDTO00054> DrawList { get; set; }

        public bool IsEnableIncomeBox
        {
            get { return this.grpIncome.Enabled; }
            set { this.grpIncome.Enabled = value; }
        }

        #endregion

        #region"Event"
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTLMVEW00018_Load(object sender, EventArgs e)
        {
            this.EnableDisableButtonControl();
            this.BindComboBoxes();
            this.FormLoadDisableControls();
            this.InitializeControls();
            this.totalamount = 0;
            this.totalcomission = 0;
            this.totaltelexcharges = 0;
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            this.lblSourceBr.Text = this.Controller.GetSourceBranch();
            this.rdoIncome.Focus();
            //this.gvCustomer = new gvCustomer..DataGridViewMaskedTextColumn();
            // dataGridViewTextBoxColumn9
            //
            //this.dataGridViewTextBoxColumn9.DataPropertyName = "DOB";
            //this.dataGridViewTextBoxColumn9.HeaderText = "DOB";
            //this.dataGridViewTextBoxColumn9.Mask = "00/00/0000";
            //this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";

        }
        /// <summary>
        /// chkTakeIncome is Disable if CheckChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void gvCustomer_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (!this.IsCancelExit.Equals(true))
            {
                DataGridViewRow dataRow = (DataGridViewRow)gvCustomer.Rows[e.RowIndex];
                DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

                if (e.RowIndex > -1 && (!dataRow.IsNewRow || cell.OwningColumn.Name.Equals("colDrawerBank")))
                {
                    if (cell.OwningColumn.Name.Equals("colDrawerBank"))
                    {
                        if (cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty) || cbodrawerbank == null || cbodrawerbank == string.Empty)
                        {
                            this.Failure("MV00089"); //If DrawerBank is not selected , need to show message;
                            gvCustomer.CurrentCell = dataRow.Cells["colDrawerBank"];
                            gvCustomer.BeginEdit(true);
                            e.Cancel = true;
                        }
                        if (!String.IsNullOrEmpty((gvCustomer.Rows[e.RowIndex].Cells["colAmount"].EditedFormattedValue).ToString()) && dataRow.Cells["colDrawerBank"].Value != null && cbodrawerbank != null && cbodrawerbank != string.Empty)
                        {
                            this.amount = 0;
                            this.amount = Convert.ToDecimal(gvCustomer.Rows[e.RowIndex].Cells["colAmount"].EditedFormattedValue);
                            bool isAmountValid = true;
                            decimal[] charges = new decimal[3];

                            if (this.CalculateCharges(amount, ref charges, ref isAmountValid))
                            {
                                dataRow.Cells["colIBLChanges"].Value = charges[0];
                                dataRow.Cells["colCommission"].Value = charges[1];
                                dataRow.Cells["colRemitAmount"].Value = charges[2];
                            }
                            else
                            {
                                //dataRow.Cells["colAmount"].Value = null;
                                dataRow.Cells["colIBLChanges"].Value = null;
                                dataRow.Cells["colCommission"].Value = null;
                                dataRow.Cells["colRemitAmount"].Value = null;
                                gvCustomer.CurrentCell = dataRow.Cells["colDrawerBank"];
                                gvCustomer.BeginEdit(true);
                                e.Cancel = true;                                
                            }
                        }                    
                    }

                    else if (cell.OwningColumn.Name.Equals("colName"))
                    {
                        if (cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
                        {
                            this.Failure("MV00002"); // Invalid Name
                            gvCustomer.CurrentCell = dataRow.Cells["colName"];
                            gvCustomer.BeginEdit(true);
                            e.Cancel = true;
                        }
                        else
                        {
                            dataRow.Cells["colName"].Value = cell.EditedFormattedValue.ToString();
                        }
                    }
                    else if (cell.OwningColumn.Name.Equals("colAccountNo"))
                    {                       
                        //if (!cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty)
                        //    || !cell.EditedFormattedValue.ToString().Trim().Equals("-")
                        //    || !(CXCLE00012.Instance.CheckAccountNoType(Convert.ToString(cell.EditedFormattedValue), CXDMD00011.AccountNoType2)))                        
                        if (!cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
                        {
                            if (!cell.EditedFormattedValue.ToString().Trim().Equals("-"))
                            {
                                if (CXCLE00012.Instance.CheckAccountNoType(Convert.ToString(cell.EditedFormattedValue), CXDMD00011.AccountNoType2))
                                {
                                    if (cell.EditedFormattedValue.ToString().Trim().Equals(this.AccountNo))
                                    {
                                        this.Failure("MI30048");   //Drawing Account No and Drawee Account No cannot be same.
                                        gvCustomer.CurrentCell = dataRow.Cells["colAccountNo"];
                                        gvCustomer.BeginEdit(true);
                                        e.Cancel = true;
                                    }
                                    else
                                    {
                                        if (!this.controller.ValidAccountNo(cell.EditedFormattedValue.ToString().Trim(), gvCustomer.Rows[e.RowIndex].Cells["colDrawerBank"].EditedFormattedValue.ToString()))
                                        {
                                            gvCustomer.CurrentCell = dataRow.Cells["colAccountNo"];
                                            gvCustomer.BeginEdit(true);
                                            e.Cancel = true;
                                        }
                                    }
                                }
                                else
                                {
                                    this.Failure("MV00046");   //Invalid Account No.
                                    gvCustomer.CurrentCell = dataRow.Cells["colAccountNo"];
                                    gvCustomer.BeginEdit(true);
                                    e.Cancel = true;
                                }
                            }
                        }
                        else
                        {
                            dataRow.Cells["colAccountNo"].Value = cell.EditedFormattedValue.ToString().Trim();
                        }
                    }
                    else if (cell.OwningColumn.Name.Equals("colAmount"))
                        {
                        if (cell.EditedFormattedValue.ToString().StartsWith(Decimal.Zero.ToString()))
                        {
                            //gvCustomer.CurrentCell = dataRow.Cells["colAmount"];
                            gvCustomer.EndEdit();
                            gvCustomer.Rows[e.RowIndex].Cells["colAmount"].Value = 0;
                            gvCustomer.BeginEdit(true);
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00037); // Message Code for if Amount is Blank;
                            e.Cancel = true;
                        }
                        if (cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
                        {
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00037); // Message Code for if Amount is Blank;
                            //gvCustomer.CurrentCell = dataRow.Cells["colAmount"];
                            gvCustomer.EndEdit();
                            gvCustomer.Rows[e.RowIndex].Cells["colAmount"].Value = null;
                            gvCustomer.BeginEdit(true);
                            e.Cancel = true;
                        }
                        if (!cell.EditedFormattedValue.ToString().StartsWith(Decimal.Zero.ToString()) && !String.IsNullOrEmpty(cell.EditedFormattedValue.ToString()))
                        {
                            this.amount = 0;
                            this.amount = Convert.ToDecimal(gvCustomer.Rows[e.RowIndex].Cells["colAmount"].EditedFormattedValue);

                            //if (amount > TotalAmount)
                            //{
                            //    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00196);
                            //    gvCustomer.CurrentCell = dataRow.Cells["colAmount"];
                            //    gvCustomer.BeginEdit(true);
                            //    e.Cancel = true;
                            //}

                        }
                        //if (this.Flag)    ////comment by ASDA
                        //{
                        //    e.Cancel = true;
                        //    this.Flag = false;
                        //    this.status = false;
                        //}
                    }

                    else if (cell.OwningColumn.Name.Equals("colNrc"))
                    {
                        if (cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
                        {
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00004); // Invalid NRC
                            gvCustomer.CurrentCell = dataRow.Cells["colNrc"];
                            gvCustomer.BeginEdit(true);
                            e.Cancel = true;
                        }

                    }
                    else if (cell.OwningColumn.Name.Equals("colAddress"))
                    {
                        if (cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
                        {
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00010); // Invalid Address
                            gvCustomer.CurrentCell = dataRow.Cells["colAddress"];
                            gvCustomer.BeginEdit(true);
                            e.Cancel = true;
                        }
                    }
                    else if (cell.OwningColumn.Name.Equals("colPhoneNo"))
                    {
                        if (cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
                        {
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00011); // Invalid Phone No.
                            gvCustomer.CurrentCell = dataRow.Cells["colPhoneNo"];
                            gvCustomer.BeginEdit(true);
                            e.Cancel = true;
                        }
                    }
                }              
            }
        }
        private void gvCustomer_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!this.IsCancelExit.Equals(true))
            {
                if (e.RowIndex.Equals(-1) || e.ColumnIndex.Equals(-1))
                {
                    return;
                }
                DataGridViewRow dataRow = (DataGridViewRow)gvCustomer.Rows[e.RowIndex];
                DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];
                if (e.RowIndex >= 0 && !dataRow.IsNewRow)
                {
                    if (dataRow.Cells["colDrawerBank"].Value == null || dataRow.Cells["colName"].Value == null || dataRow.Cells["colNrc"].Value == null ||
                        dataRow.Cells["colAddress"].Value == null || dataRow.Cells["colPhoneNo"].Value == null || dataRow.Cells["colRemitAmount"].Value == null)
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90015);
                        gvCustomer.CurrentCell = gvCustomer.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        gvCustomer.BeginEdit(true);
                        e.Cancel = true;
                        //return;
                    }
                }
            }
        }


        #region EditedCode
        //private void gvCustomer_CellLeave(object sender, DataGridViewCellEventArgs e)
        //{
        //    //if (!this.IsCancelExit.Equals(true))
        //    //{
        //        DataGridViewRow dataRow = (DataGridViewRow)gvCustomer.Rows[e.RowIndex];
        //        DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

        //        if (e.RowIndex > -1 && (!dataRow.IsNewRow || cell.OwningColumn.Name.Equals("colDrawerBank")))
        //        {
        //            if (cell.OwningColumn.Name.Equals("colDrawerBank"))
        //            {
        //                dataRow.Cells["colDrawerBank"].Value = cell.EditedFormattedValue.ToString();
        //                drawerbank = dataRow.Cells["colDrawerBank"].Value.ToString();
        //                if (!String.IsNullOrEmpty((gvCustomer.Rows[e.RowIndex].Cells["colAmount"].EditedFormattedValue).ToString()))
        //                {
        //                    this.amount = 0;
        //                    this.amount = Convert.ToDecimal(gvCustomer.Rows[e.RowIndex].Cells["colAmount"].EditedFormattedValue);
        //                    bool isAmountValid = true;
        //                    decimal[] charges = new decimal[3];

        //                    if (this.CalculateCharges(amount, ref charges, ref isAmountValid))
        //                    {
        //                        dataRow.Cells["colIBLChanges"].Value = charges[0];
        //                        dataRow.Cells["colCommission"].Value = charges[1];
        //                        dataRow.Cells["colRemitAmount"].Value = charges[2];
        //                    }
        //                }
        //            }
        //        }
        //        else if (cell.OwningColumn.Name.Equals("colAccountNo"))
        //        {
        //            if (!cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty) && (this.TransactionStatus == "IBL") && (CXCLE00012.Instance.CheckAccountNoType(Convert.ToString(cell.EditedFormattedValue), CXDMD00011.AccountNoType2)))
        //            {
        //                if (cell.EditedFormattedValue.ToString().Trim().Equals(this.AccountNo))
        //                {
        //                    this.Failure("MI30048");
        //                    gvCustomer.CurrentCell = dataRow.Cells["colAccountNo"];
        //                    gvCustomer.BeginEdit(true);
                           
        //                }
        //                else
        //                {
        //                    if (!this.controller.ValidAccountNo(cell.EditedFormattedValue.ToString()))
        //                    {
        //                        this.Failure("MV00046");
        //                        gvCustomer.CurrentCell = dataRow.Cells["colAccountNo"];
        //                        gvCustomer.BeginEdit(true);
                                
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                dataRow.Cells["colAccountNo"].Value = cell.EditedFormattedValue.ToString().Trim();
        //            }

        //        }

        //        else if (cell.OwningColumn.Name.Equals("colName"))
        //        {
        //            if (cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
        //            {
        //                this.Failure("MV00002"); // Invalid Name
        //                gvCustomer.CurrentCell = dataRow.Cells["colName"];
        //                gvCustomer.BeginEdit(true);
                        
        //            }
        //            else
        //            {
        //                dataRow.Cells["colName"].Value = cell.EditedFormattedValue.ToString();
        //            }
        //        }

        //        else if (cell.OwningColumn.Name.Equals("colNrc"))
        //        {
        //            if (cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
        //            {
        //                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00004); // Invalid NRC
        //                gvCustomer.CurrentCell = dataRow.Cells["colNrc"];
        //                gvCustomer.BeginEdit(true);
                        
        //            }

        //        }
        //        else if (cell.OwningColumn.Name.Equals("colAddress"))
        //        {
        //            if (cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
        //            {
        //                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00010); // Invalid Address
        //                gvCustomer.CurrentCell = dataRow.Cells["colAddress"];
        //                gvCustomer.BeginEdit(true);
                        
        //            }
        //        }
        //        else if (cell.OwningColumn.Name.Equals("colPhoneNo"))
        //        {
        //            if (cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
        //            {
        //                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00011); // Invalid Phone No.
        //                gvCustomer.CurrentCell = dataRow.Cells["colPhoneNo"];
        //                gvCustomer.BeginEdit(true);
                        
        //            }
        //        }

        //        else if (cell.OwningColumn.Name.Equals("colAmount"))
        //        {
        //            if (cell.EditedFormattedValue.ToString().Trim().Equals(Decimal.Zero) || cell.EditedFormattedValue.ToString().Trim().Equals(string.Empty))
        //            {
        //                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00037); // Message Code for if Amount is Blank;
        //                gvCustomer.CurrentCell = dataRow.Cells["colAmount"];
        //                gvCustomer.BeginEdit(true);

        //            }
        //            bool isAmountValid = true;
        //            if (!cell.EditedFormattedValue.ToString().Trim().Equals(Decimal.Zero) && !String.IsNullOrEmpty(cell.EditedFormattedValue.ToString()))
        //            {
        //                this.amount = 0;
        //                this.amount = Convert.ToDecimal(gvCustomer.Rows[e.RowIndex].Cells["colAmount"].EditedFormattedValue);
        //                if (amount > TotalAmount)
        //                {
        //                    gvCustomer.CurrentCell = dataRow.Cells["colAmount"];
        //                    gvCustomer.BeginEdit(true);
        //                    isAmountValid = false;
        //                }
        //                else
        //                {
        //                    decimal[] charges = new decimal[3];
        //                    if (this.CalculateCharges(amount, ref charges, ref isAmountValid))
        //                    {
        //                        dataRow.Cells["colIBLChanges"].Value = charges[0];
        //                        dataRow.Cells["colCommission"].Value = charges[1];
        //                        dataRow.Cells["colRemitAmount"].Value = charges[2];
        //                    }
        //                }
        //            }

        //            if (this.Flag)
        //            {
        //                this.Flag = false;
        //                this.status = false;
        //            }


        //            totalamount = 0; totalcomission = 0; totaltelexcharges = 0;
        //            if (e.RowIndex > -1 && !dataRow.IsNewRow)
        //            {
        //                if (e.RowIndex >= 0)
        //                {
        //                    foreach (DataGridViewRow row in gvCustomer.Rows)
        //                    {
        //                        if ((!row.Cells["colAmount"].EditedFormattedValue.Equals(null)) && (row.Cells["colAmount"].EditedFormattedValue.ToString() != string.Empty))
        //                        {
        //                            totalamount += Convert.ToDecimal(row.Cells["colAmount"].EditedFormattedValue);
        //                        }

        //                        if ((!row.Cells["colIBLChanges"].EditedFormattedValue.Equals(null)) && (row.Cells["colIBLChanges"].EditedFormattedValue.ToString() != string.Empty))
        //                        {
        //                            totaltelexcharges += Convert.ToDecimal(row.Cells["colIBLChanges"].EditedFormattedValue);
        //                        }

        //                        if ((!row.Cells["colCommission"].EditedFormattedValue.Equals(null)) && (row.Cells["colCommission"].EditedFormattedValue.ToString() != string.Empty))
        //                        {
        //                            totalcomission += Convert.ToDecimal(row.Cells["colCommission"].EditedFormattedValue);
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    //}
        //}

        #endregion

        /// <summary>
        /// To prevent cell value loss if user click Save Button before Validating Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        #region OldCode
        private void gvCustomer_CellLeave(object sender, DataGridViewCellEventArgs e)
            {
            gvCustomer.CausesValidation = false;
            cbodrawerbank = string.Empty;
            //if (this.status == false && this.Flag == false)   ////comment by ASDA
            //{
                if (!this.IsCancelExit.Equals(true))
                {
                    DataGridViewRow dataRow = (DataGridViewRow)gvCustomer.Rows[e.RowIndex];
                    DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];
                    
                    if (e.RowIndex > -1 && !dataRow.IsNewRow)
                    {
                       
                        if (cell.OwningColumn.Name.Equals("colDrawerBank"))
                        {
                            dataRow.Cells["colDrawerBank"].Value = cell.EditedFormattedValue.ToString();
                            drawerbank = cbodrawerbank = dataRow.Cells["colDrawerBank"].Value.ToString();

                            //if (!String.IsNullOrEmpty((gvCustomer.Rows[e.RowIndex].Cells["colAmount"].EditedFormattedValue).ToString()))
                            //{
                            //    this.amount = 0;
                            //    this.amount = Convert.ToDecimal(gvCustomer.Rows[e.RowIndex].Cells["colAmount"].EditedFormattedValue);
                            //    bool isAmountValid = true;
                            //    decimal[] charges = new decimal[3];

                            //    if (this.CalculateCharges(amount, ref charges, ref isAmountValid))
                            //    {                                    
                            //        dataRow.Cells["colIBLChanges"].Value = charges[0];
                            //        dataRow.Cells["colCommission"].Value = charges[1];                                 
                            //        dataRow.Cells["colRemitAmount"].Value = charges[2] ;                                   
                            //    }
                            //    else
                            //    {
                            //        dataRow.Cells["colAmount"].Value = null;
                            //        dataRow.Cells["colIBLChanges"].Value = null;
                            //        dataRow.Cells["colCommission"].Value = null;
                            //        dataRow.Cells["colRemitAmount"].Value = null;
                            //    }
                            //}
                        }

                        else if (cell.OwningColumn.Name.Equals("colName"))
                        {
                            dataRow.Cells["colName"].Value = cell.EditedFormattedValue.ToString();
                        }
                        else if (cell.OwningColumn.Name.Equals("colAccountNo"))
                        {
                            dataRow.Cells["colAccountNo"].Value = cell.EditedFormattedValue.ToString().Trim();
                        }
                        else if (cell.OwningColumn.Name.Equals("colAmount"))
                        {
                            //drawerbank = dataRow.Cells["colDrawerBank"].Value.ToString();
                            gvCustomer.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType = Type.GetType("System.Decimal");
                            bool isAmountValid = true;
                            if (!cell.EditedFormattedValue.ToString().StartsWith(decimal.Zero.ToString()) && !String.IsNullOrEmpty(cell.EditedFormattedValue.ToString()) && dataRow.Cells["colDrawerBank"].Value != null && drawerbank != null)
                            {
                                dataRow.Cells["colAmount"].Value = cell.EditedFormattedValue.ToString().Trim();
                                this.amount = 0;
                                this.amount = Convert.ToDecimal(gvCustomer.Rows[e.RowIndex].Cells["colAmount"].EditedFormattedValue);
                                //if (amount > TotalAmount)
                                //{

                                //    isAmountValid = false;
                                //    //e.Cancel = true;
                                //}
                                //else
                                //{
                                    decimal[] charges = new decimal[3];
                                    
                                    if (this.CalculateCharges(amount, ref charges, ref isAmountValid))
                                    {
                                        gvCustomer.CausesValidation = false;
                                        dataRow.Cells["colIBLChanges"].Value = charges[0];
                                        dataRow.Cells["colCommission"].Value = charges[1];
                                        dataRow.Cells["colRemitAmount"].Value = charges[2]; 
                                    }                                   
                                //}
                            }
                        }
                        totalamount = 0; totalcomission = 0; totaltelexcharges = 0;
                        if (e.RowIndex > -1 && !dataRow.IsNewRow)
                        {
                            if (e.RowIndex >= 0)
                            {
                                foreach (DataGridViewRow row in gvCustomer.Rows)
                                {
                                    if ((!row.Cells["colAmount"].EditedFormattedValue.Equals(null)) && (row.Cells["colAmount"].EditedFormattedValue.ToString() != string.Empty))
                                    {
                                        totalamount += Convert.ToDecimal(row.Cells["colAmount"].EditedFormattedValue);
                                    }

                                    if ((!row.Cells["colIBLChanges"].EditedFormattedValue.Equals(null)) && (row.Cells["colIBLChanges"].EditedFormattedValue.ToString() != string.Empty))
                                    {
                                        totaltelexcharges += Convert.ToDecimal(row.Cells["colIBLChanges"].EditedFormattedValue);
                                    }

                                    if ((!row.Cells["colCommission"].EditedFormattedValue.Equals(null)) && (row.Cells["colCommission"].EditedFormattedValue.ToString() != string.Empty))
                                    {
                                        totalcomission += Convert.ToDecimal(row.Cells["colCommission"].EditedFormattedValue);
                                    }
                                    //if (this.IsTakeIncome == true)
                                    //{
                                    //    totalamount = totalamount - (totaltelexcharges + totalcomission);
                                    //    dataRow.Cells["colRemitAmount"].Value = totalamount;
                                    //}
                                    //else
                                    //{
                                    //    totalamount = totalamount + totaltelexcharges + totalcomission;
                                    //    dataRow.Cells["colRemitAmount"].Value = totalamount;
                                    //}                                   
                                }
                            }
                        }
                    }
                }
            //}
        }

        #endregion

        private void gvCustomer_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
            {
            DataGridViewCell dataCurrentCell = gvCustomer.CurrentCell;
            e.Control.KeyPress -= new KeyPressEventHandler(colAccountNo_KeyPress);
            e.Control.KeyPress -= new KeyPressEventHandler(colPhoneNo_KeyPress);
            e.Control.KeyPress -= new KeyPressEventHandler(colAmount_KeyPress);
            

            //if (dataCurrentCell.OwningColumn.Name.Equals("colDrawerBank"))
            //{
            //    ComboBox combo = e.Control as ComboBox;
            //    if (combo != null)
            //    {
            //        combo.SelectedIndexChanged -= new EventHandler(colDrawerBank_SelectedIndexChanged);
            //        combo.SelectedIndexChanged += new EventHandler(colDrawerBank_SelectedIndexChanged);
            //    }
            //}
            if (dataCurrentCell.OwningColumn.Name.Equals("colAccountNo"))
            {
                TextBox txtbox = e.Control as TextBox;
                if (txtbox != null)
                {
                    //txtbox.KeyPress -= new KeyPressEventHandler(colAccountNo_KeyPress);
                    txtbox.KeyPress += new KeyPressEventHandler(colAccountNo_KeyPress);
                }
            }   

            //else 
            if (dataCurrentCell.OwningColumn.Name.Equals("colPhoneNo"))
            {
                TextBox txtbox = e.Control as TextBox;
                if (txtbox != null)
                {
                    //txtbox.KeyPress -= new KeyPressEventHandler(colPhoneNo_KeyPress);
                    txtbox.KeyPress += new KeyPressEventHandler(colPhoneNo_KeyPress);
                }
            }   

            else if (dataCurrentCell.OwningColumn.Name.Equals("colAmount"))
            {
                TextBox txtbox = e.Control as TextBox;
                if (txtbox != null)
                {
                   // txtbox.KeyPress -= new KeyPressEventHandler(colAmount_KeyPress);
                    txtbox.KeyPress += new KeyPressEventHandler(colAmount_KeyPress);
                }
            }            
        }
      

        private void butContinue_Click(object sender, EventArgs e)
        {
            this.controller.Continue();
            this.txtChequeNo.Focus();
        }

        private void gvCustomer_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                foreach (DataGridViewRow row in gvCustomer.Rows)
                {
                    totalamount = 0;
                    if ((!row.Cells["colAmount"].FormattedValue.Equals("")) && (!row.Cells["colAmount"].FormattedValue.Equals(Decimal.Zero)))  //edited by ASDA
                    {
                        totalamount += Convert.ToDecimal(row.Cells["colAmount"].EditedFormattedValue);
                    }
                    if (totalamount > this.TotalAmount)
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00196);

                    }
                }
            }
        }

        private void colDrawerBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            drawerbank = (((ComboBox)sender).SelectedValue != null) ? ((ComboBox)sender).SelectedValue.ToString() : string.Empty;
        }

        private void colAmount_KeyPress(object sender, KeyPressEventArgs e)   //edited by ASDA . to enter decimal point
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
                e.Handled = true;            

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)           
                e.Handled = true;
        }

        private void colPhoneNo_KeyPress(object sender, KeyPressEventArgs e)  // to enter digit and - 
        {
            const char Delete = (char)12;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != Delete)
            {
                e.Handled = true;
            }

         }

        private void colAccountNo_KeyPress(object sender, KeyPressEventArgs e)  // to enter digit and - 
        {
            const char Delete = (char)15;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar == '-' && e.KeyChar != Delete)
            {
                e.Handled = true;
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00046);
            }
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            if (this.totalamount != TotalAmount)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00196);
                //int nRowIndex = gvCustomer.Rows.Count -1;               
                //gvCustomer.CurrentCell = gvCustomer.Rows[nRowIndex -1].Cells[11];
                this.gvCustomer.EndEdit();
                this.gvCustomer.Focus();

                return;
            }
            this.DrawList = this.GetDrawingData();
            if (this.DrawList == null)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90015);
                this.gvCustomer.Focus();
                return;
            }
            else if (this.DrawList.Count < 1 ) 
            {
                //At least one record must be exist to save.
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00107);
                this.rdoIncome.Focus();
                return;
            }
          
            else
            {
                gvCustomer.ClearSelection();
                //gvCustomer.CellValidating -= new DataGridViewCellValidatingEventHandler(gvCustomer_CellValidating);
                this.controller.Save(DrawList);
                //gvCustomer.CellValidating += new DataGridViewCellValidatingEventHandler(gvCustomer_CellValidating);
            }
        }

        private void Income_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoIncome.Checked)
                this.CheckBoxEnable();
            if (this.rdoNoIncome.Checked)
                this.CheckBoxDisable();
        }

        private void butEnquiry_Click(object sender, EventArgs e)
        {
            if (CXUIScreenTransit.Transit("frmTLMVEW00042", true, new object[] { "frmTLMVEW00018", this.AccountNo }) == DialogResult.OK)
            {
                return;
            }
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {            
            //AutoValidate = AutoValidate.Disable;  
            gvCustomer.CausesValidation = false;
            this.ClearAllUIControls();
            this.EnableControls("DrawingRemittanceEntry.DrawingGroupBoxEnable");
            this.txtChequeNo.Enabled = false;
            this.status = false;
            this.drawerbank = null;
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.IsCancelExit = true;
            this.Close();
        }

        private void IncomeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoIncomeByCash.Checked)
            {
                this.chkTakeIncome.Enabled = true;
                this.IncomeType = "cash";
            }
            if (this.rdoIncomeByTransfer.Checked)
            {
                this.chkTakeIncome.Checked = false;
                this.chkTakeIncome.Enabled = false;
                this.IncomeType = "transfer";
            }
        }

        private void cboCurrency_Validated(object sender, EventArgs e)
        {
            this.grpDrawing.Enabled = false;
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)10;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != Delete)
            { e.Handled = true; }
        }

        //private void TLMVEW00018_KeyDown(object sender, KeyEventArgs e)  //added by ASDA--------------
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        //SendKeys.Send("{TAB}"); 
        //       this.SelectNextControl(ActiveControl, true, true, true, true);
        //    }

        //} // end -----------------------------

        private void gvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)    //added by ASDA
        {
            if (e.RowIndex.Equals(-1) || e.ColumnIndex.Equals(-1))
            {
                return;
            }
            DataGridViewRow dataRow = (DataGridViewRow)gvCustomer.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];
            if (dataRow.IsNewRow && dataRow.Cells["colDrawerBank"].Value != null && cell.OwningColumn.Name.Equals("colDelete"))
            {
                gvCustomer.AllowUserToDeleteRows = false;
            }
            else if (dataRow.IsNewRow && dataRow.Cells["colDrawerBank"].Value == null && cell.OwningColumn.Name.Equals("colDelete"))
            {
                gvCustomer.AllowUserToDeleteRows = false;
            }
            else if (e.RowIndex >= 0 && !dataRow.IsNewRow && dataRow.Cells["colDrawerBank"].Value != null && cell.OwningColumn.Name.Equals("colDelete"))
            {
                gvCustomer.Rows.RemoveAt(e.RowIndex);

                if (gvCustomer.CurrentRow.Index < gvCustomer.Rows.Count)
                {
                    gvCustomer.ClearSelection();
                    int nRowIndex = gvCustomer.Rows.Count - 1;
                    gvCustomer.CurrentCell = gvCustomer.Rows[nRowIndex].Cells[11];
                }
            }
        }

        private void chkTakeIncome_CheckedChanged(object sender, EventArgs e)   //Added by ASDA
        {
            if (chkTakeIncome.Checked == true)
            {
                if (!string.IsNullOrEmpty(this.mtxtAccountNo.Text))
                {
                    rdoIncomeByTransfer.Checked = true;
                }
            }
        }            
        #endregion

        #region"Method"

        /// <summary>
        /// Button Enable Disable Control
        /// </summary>
        private void EnableDisableButtonControl()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, true, true);
        }
        /// <summary>
        /// Currency Combo Box DataBind
        /// </summary>
        private void BindComboBoxes()
        {
            IList<CurrencyDTO> CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = CurrencyList;
            cboCurrency.SelectedIndex = 0;
        }

        public void BindBranchCode()
        {
            string sourceBranchCode = CXCOM00007.Instance.BranchCode;
            if (TransactionStatus == "IBL")
            {
                BranchList = CXCLE00002.Instance.GetListByCustomHQL<BranchDTO>("BranchCodeAndBranchDesp.SelectAllOthersBranch", new Dictionary<string, object>() { { "sourcebranchcode", sourceBranchCode } });
            }
            else
            {
                BranchList = CXCLE00002.Instance.GetListByCustomHQL<BranchDTO>("BranchCodeAndBranchDesp.SelectAllBranches", new Dictionary<string, object>() { { "sourcebranchcode", sourceBranchCode } });
                //BranchList = CXCLE00002.Instance.GetListObject<BranchDTO>("BranchCode.Client.SelectOtherBank", new object[] { true });

            }
            colDrawerBank.ValueMember = "BranchCode";
            colDrawerBank.DisplayMember = "BranchCode";
            colDrawerBank.DataSource = BranchList;
            ((DataGridViewComboBoxColumn)gvCustomer.Columns["colDrawerBank"]).DataSource = BranchList;

            //gvCustomer.Rows[0].Cells[1].Value = BranchList[0].ToString();
            gvCustomer.CurrentCell = gvCustomer.Rows[0].Cells[1];
            this.gvCustomer.Focus();

        }

        public void ReadOnlyControl(bool tabstop)
        {
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.TabStop = tabstop;
        }

        /// <summary>
        /// Get FormName
        /// </summary>
        private void InitializeControls()
        {
            gbPaymentDetail.Text = this.GetNameString("Drawing Remittance Register");
            this.Text = this.GetNameString("Drawing Remittance Register");
        }


        private string GetNameString(string parameter)
        {
            switch (this.FormName)
            {
                case "IBL":
                    return parameter + " IBL Entry";

                case "IBS":
                    return parameter + " IBS Entry";

                default:
                    return string.Empty;
            }
        }

        public void gvCustomer_DataBind(IList<TLMDTO00054> RegisterNoList)
        {
            this.gvCustomer.DataSource = null;
            gvCustomer.AutoGenerateColumns = false;
            this.gvCustomer.DataSource = RegisterNoList;
        }

        /// <summary>
        /// chkTakeIncome is Disable if rdoNoIncome is chosen
        /// </summary>
        private void CheckBoxDisable()
        {
            this.DisableControls("DrawingRemittanceEntry.CheckboxDisable");
        }
        /// <summary>
        /// chkTakeIncome is Enable if rdoIncome is chosen
        /// </summary>
        private void CheckBoxEnable()
        {
            this.EnableControls("DrawingRemittanceEntry.CheckboxEnable");
        }
        /// <summary>
        /// Disable Controls for FormLoad
        /// </summary>
        private void FormLoadDisableControls()
        {
            this.DisableControls("DrawingRemittanceEntry.FormLoadDisable");
        }
        /// <summary>
        /// Enable txtcheque if Account No is Current Account
        /// </summary>
        /// <param name="accountSign"></param>
        public void EnableControlByAccountDrawing()
        {
            if (this.Controller._AccountType == CXDMD00004.CurrentAccount)
            {
                this.EnableControls("DrawingRemittanceEntry.ChequeNoEnable");
            }
        }
        /// <summary>
        /// Disable controls If Drawing Remittance by Account
        /// </summary>
        public void DisableControlsByAccountDrawing()
        {
            this.DisableControls("DrawingRemittanceEntry.DrawRemittanceByAccountDisable");
        }

        public void EnableDisableControlsforContinueClick()
        {
            if ((!string.IsNullOrEmpty(this.AccountNo)) && (this.IsIncome) && (!this.Controller.IsDomesticAcType))
            {
                this.EnableControls("DrawingRemittanceEntry.DrawingGroupBoxEnable");
            }

            this.EnableControls("DrawingRemittanceEntry.gvCustomerEnable");
            // this.DisableControls("DrawingRemittanceEntry.GroupBoxsDisable");
        }

        public void DisableEnableControlsForContinueEvent(bool enable)
        {
            if (enable)
                this.EnableControls("DrawingRemittanceEntry.ContinueControlsEnable");
            else
                this.DisableControls("DrawingRemittanceEntry.ContinueControlsDisable");
        }

        private void ClearAllUIControls()
        {
            this.IsCancelExit = true;
            this.DisableEnableControlsForContinueEvent(true);
            this.controller.ClearControls(true);
            this.controller.ClearErrors();
            this.HideControls(true, false, false);
            this.IsCancelExit = false;
            this.rdoIncome.Checked = true;
            this.rdoIncome.Focus();
            this.chkVIPCustomer.Checked = false;
            this.chkTakeIncome.Checked = false;
            this.rdoIncomeByCash.Checked = true;
        }

        private IList<TLMDTO00054> GetDrawingData()
        {
            IList<TLMDTO00054> drawinglist = new List<TLMDTO00054>();
            foreach (DataGridViewRow row in gvCustomer.Rows)
            {
                if ((Convert.ToString(row.Cells["colDrawerBank"].Value) != "") &&
                        (row.Cells["colDrawerBank"].Value != null) &&
                    (Convert.ToString(row.Cells["colName"].Value) != "") &&
                        (row.Cells["colName"].Value != null) &&
                    (Convert.ToString(row.Cells["colNrc"].Value) != "") &&
                        (row.Cells["colNrc"].Value != null) &&
                    (Convert.ToString(row.Cells["colAddress"].Value) != "") &&
                        (row.Cells["colAddress"].Value != null) &&
                    (Convert.ToString(row.Cells["colPhoneNo"].Value) != "") &&
                        (row.Cells["colPhoneNo"].Value != null) &&
                    (Convert.ToString(row.Cells["colAmount"].Value) != "") &&
                        (row.Cells["colAmount"].Value != null))
                {
                    TLMDTO00054 drawing = new TLMDTO00054();
                    drawing.Dbank = Convert.ToString(row.Cells["colDrawerBank"].Value);
                    drawing.BranchAlias = (from value in BranchList
                                           where value.BranchCode.Equals(drawing.Dbank)
                                           select value.BranchAlias).Single();
                    drawing.RegisterNo = string.Empty;
                    drawing.ToAccountNo = Convert.ToString(row.Cells["colAccountNo"].Value).Trim();
                    drawing.ToName = Convert.ToString(row.Cells["colName"].Value);
                    drawing.ToNRC = Convert.ToString(row.Cells["colNrc"].Value);
                    drawing.ToAddress = Convert.ToString(row.Cells["colAddress"].Value);
                    drawing.ToPhoneNo = Convert.ToString(row.Cells["colPhoneNo"].Value);
                    drawing.ToAmount = Convert.ToDecimal(row.Cells["colAmount"].Value);
                    drawing.Commission = Convert.ToDecimal(row.Cells["colCommission"].Value);
                    drawing.TelexCharges = Convert.ToDecimal(row.Cells["colIBLChanges"].Value);
                    drawing.RemitAmount = Convert.ToDecimal(row.Cells["colRemitAmount"].Value);
                    //drawing.TestKey = CXCLE00017.Instance.GetTestKey(drawing.Dbank, DateTime.Now.Day.ToString().PadLeft(2, '0'), DateTime.Now.Month.ToString().PadLeft(2, '0'), drawing.ToAmount, CXCOM00007.Instance.BranchCode);

                    //For Test Key calculate for different branch.
                    if (this.chkTakeIncome.Checked)
                    {
                        drawing.TestKey = CXCLE00017.Instance.GetTestKey(drawing.Dbank, DateTime.Now.Day.ToString().PadLeft(2, '0'), DateTime.Now.Month.ToString().PadLeft(2, '0'), drawing.RemitAmount, CXCOM00007.Instance.BranchCode);
                    }
                    else 
                    {
                        drawing.TestKey = CXCLE00017.Instance.GetTestKey(drawing.Dbank, DateTime.Now.Day.ToString().PadLeft(2, '0'), DateTime.Now.Month.ToString().PadLeft(2, '0'), drawing.ToAmount, CXCOM00007.Instance.BranchCode);
                    }

                    drawing.IsTakeIncome = this.chkTakeIncome.Checked; //For solve drawing, encash different amount.
                    drawinglist.Add(drawing);
                }
                else if ((Convert.ToString(row.Cells["colDrawerBank"].Value) == "") &&
                        (row.Cells["colDrawerBank"].Value == null) &&
                    (Convert.ToString(row.Cells["colName"].Value) == "") &&
                        (row.Cells["colName"].Value == null) &&
                    (Convert.ToString(row.Cells["colNrc"].Value) == "") &&
                        (row.Cells["colNrc"].Value == null) &&
                    (Convert.ToString(row.Cells["colAddress"].Value) == "") &&
                        (row.Cells["colAddress"].Value == null) &&
                    (Convert.ToString(row.Cells["colPhoneNo"].Value) == "") &&
                        (row.Cells["colPhoneNo"].Value == null) &&
                    (Convert.ToString(row.Cells["colAmount"].Value) == "") &&
                        (row.Cells["colAmount"].Value == null))
                {
 
                }

                else if (((Convert.ToString(row.Cells["colDrawerBank"].Value) != "") ||
                        (row.Cells["colDrawerBank"].Value != null)) &&
                    (Convert.ToString(row.Cells["colName"].Value) == "") ||
                        (row.Cells["colName"].Value == null) ||
                    (Convert.ToString(row.Cells["colNrc"].Value) == "") ||
                        (row.Cells["colNrc"].Value == null) ||
                    (Convert.ToString(row.Cells["colAddress"].Value) == "") ||
                        (row.Cells["colAddress"].Value == null) ||
                    (Convert.ToString(row.Cells["colPhoneNo"].Value) == "") ||
                        (row.Cells["colPhoneNo"].Value == null) ||
                    (Convert.ToString(row.Cells["colAmount"].Value) == "") ||
                        (row.Cells["colAmount"].Value == null))
                {
                    // Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI90015");
                    return null;

                }
            }
            return drawinglist;
        }

        /// <summary>
        /// Hide Controls if inputed Account is COA Type
        /// </summary>
        /// <param name="enable"></param>
        public void HideControls(bool enable,bool isDomesticAccType,bool isContinue)
        {
            this.txtName.Enabled = enable;
            this.txtNRC.Enabled = enable;
            this.txtAddress.Enabled = enable;
            this.txtPhone.Enabled = enable;
            if (isDomesticAccType)
            {
                this.cboCurrency.Enabled = !enable;
                this.IsEnableIncomeBox = false;
            }
            else this.cboCurrency.Enabled = enable;
            if (!isContinue)
            {
                this.cboCurrency.SelectedIndex = 0;
                this.gvCustomer.DataSource = null;
                this.gvCustomer.Rows.Clear();
                this.gvCustomer.Enabled = false;
                if (!isDomesticAccType && !this.IsCancelExit)
                    this.txtNarration.Focus();  
            }
        }

        public void Failure(string message, string branchcode)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message, new object[] { branchcode });
        }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }

        public bool Successful(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
            this.ClearAllUIControls();
            this.txtChequeNo.Enabled = false;
            this.status = false;
            if (CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC00002) == DialogResult.Yes)
                return true;
            else
                return false;
        }
        public void InformAboutCharges(string message)
        {
            string drawingtype = (this.rdoIncomeByCash.Checked) ? "By Cash." : "By Transfer.";
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message, new object[] {drawingtype});
        }

        public void InitializedState()
        {
            this.Controller.ClearControls(false);
            this.EnableControls("DrawingRemittanceEntry.InitializedState");
            this.cboCurrency.SelectedIndex = 0;
            if (this.Controller.IsDomesticAcType) this.rdoNoIncome.Checked = true;
            //this.cboCurrency.Focus();
        }

        /// <summary>
        /// charges array Index
        /// [0] for Charges
        /// [1] for Commission
        /// [2] for Remittance Amount 
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="charges"></param>
        /// <param name="isAmountValid"></param>
        /// <returns></returns>
        private bool CalculateCharges(decimal amount, ref decimal[] charges, ref bool isAmountValid)
        {
            this.gvCustomer.CausesValidation = false;
             Nullable<decimal> amt=0;
            if ((IsIncome))
            {
                if ((TransactionStatus == "IBL") && isAmountValid)
                {
                    TLMDTO00029 remitBrIBLDto = this.controller.GetTelexChargesByIBLDrawerBranchCodeAndCurrencyCode(drawerbank, this.CurrencyCode);
                    if (remitBrIBLDto != null)
                    {
                        this.totaltelexcharges = remitBrIBLDto.TelaxCharges;
                        charges[0] = remitBrIBLDto.TelaxCharges;

                    }
                    else
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00195, new object[] { drawerbank });
                        //this.Flag = true;     //comment by ASDA
                        //this.status = true;                        
                        return false;
                    }
#region  old
                    //TLMDTO00030 comissionDto = this.controller.GetCommisionByIBLDrawerBranchCodeCurrencyCodeAndAmount(drawerbank, this.CurrencyCode, amount);
                    //if (comissionDto != null)
                    //{
                    //    this.totalcomission = comissionDto.FixAmount.Value;
                    //    if (amount > 100000)
                    //    {
                    //        charges[1] = (comissionDto.Rate.Value * amount) / 100;

                    //        amt = charges[0] + charges[1];
                    //    }

                    //    else
                    //    {
                    //        charges[1] = totalcomission;

                    //        amt = charges[0] + charges[1];

                    //    }
                    //    if (IsTakeIncome)
                    //        charges[2] = this.amount - amt.Value;
                    //    else
                    //        charges[2] = amount + amt.Value;
                    //}
#endregion
                    TLMDTO00030 EndNofFixedAmtDto = this.controller.GetEndNoByIBLDrawerBranchCodeCurrencyCodeAndAmount(drawerbank, this.CurrencyCode);
                    if (EndNofFixedAmtDto != null)
                    {
                        this.endAmount = EndNofFixedAmtDto.EndNo;
                        this.totalcomission = EndNofFixedAmtDto.FixAmount.Value;
                        if (amount > endAmount)
                        {

                            TLMDTO00030 comissionDto = this.controller.GetCommisionByIBLDrawerBranchCodeCurrencyCodeAndAmount(drawerbank, this.CurrencyCode, amount);
                            charges[1] = (comissionDto.Rate.Value * amount) / 100;
                            amt = charges[0] + charges[1];
                        }

                        else
                        {
                            charges[1] = totalcomission;

                            amt = charges[0] + charges[1];

                        }
                        if (IsTakeIncome)
                            charges[2] = this.amount - amt.Value;
                        else
                            charges[2] = amount + amt.Value;
                    }
                    else
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00195, new object[] { drawerbank });
                        //this.Flag = true;     //comment by ASDA
                        //this.status = true;
                        return false;
                    }
                }
                else
                {
                    TLMDTO00028 remitBrDto = this.controller.GetTelexChargesByIBSDrawerBranchCodeAndCurrencyCode(drawerbank, this.CurrencyCode);
                    if (remitBrDto != null)
                    {
                        charges[0] = remitBrDto.TelaxCharges;
                    }
                    else
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00195, new object[] { drawerbank });
                        //this.Flag = true;     //comment by ASDA
                        //this.status = true;
                        return false;
                    }
#region old
                    //TLMDTO00032 comissionDto = this.controller.GetCommisionByIBSDrawerBranchCodeCurrencyCodeAndAmount(drawerbank, this.CurrencyCode, amount);
                    //if (comissionDto != null)
                    //{
                    //    this.totalcomission = comissionDto.FixAmount;
                    //    if (amount > 100000)
                    //    {
                    //        charges[1] = (comissionDto.Rate * amount) / 100;

                    //        amt = charges[0] + charges[1];
                    //    }

                    //    else
                    //    {
                    //        charges[1] = totalcomission;

                    //        amt = charges[0] + charges[1];

                    //    }
                    //    if (IsTakeIncome)
                    //    {
                    //        amt = charges[0] + charges[1];
                    //        charges[2] = this.amount - amt.Value;
                    //    }
                    //    else

                    //        charges[2] = amount + amt.Value;
                    //}
#endregion
                    TLMDTO00032 EndNofFixedAmtDto = this.controller.GetEndNoByIBSDrawerBranchCodeCurrencyCodeAndAmount(drawerbank, this.CurrencyCode);
                    if (EndNofFixedAmtDto != null)
                    {
                        this.endAmount = EndNofFixedAmtDto.EndNo;
                        this.totalcomission = EndNofFixedAmtDto.FixAmount;
                        if (amount > endAmount)
                        {
                            TLMDTO00032 comissionDto = this.controller.GetCommisionByIBSDrawerBranchCodeCurrencyCodeAndAmount(drawerbank, this.CurrencyCode, amount);
                            charges[1] = (comissionDto.Rate * amount) / 100;
                            amt = charges[0] + charges[1];

                        }

                        else
                        {
                            charges[1] = totalcomission;

                            amt = charges[0] + charges[1];

                        }
                        if (IsTakeIncome)
                        {
                            // amt = charges[0] + charges[1];
                            charges[2] = this.amount - amt.Value;
                        }
                        else

                            charges[2] = amount + amt.Value;
                    }
                    else
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00195, new object[] { drawerbank });
                        //this.Flag = true;     //comment by ASDA
                        //this.status = true;                        
                        return false;
                    }
                }
            }
            else
            {
                charges[0] = 0;
                charges[1] = 0;
                charges[2] = amount;
            }
            //this.Flag = false;     //comment by ASDA
            //this.status = false;
            return true;
        }

        public void DisableGroupBox()
        {
            this.DisableControls("DrawingRemittanceEntry.DrawingGroupBoxDisable");
        }
        #endregion

        private void rdoIncome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.mtxtAccountNo.Focus();
        }

        private void rdoNoIncome_KeyDown(object sender, KeyEventArgs e)
        {
            if ( e.KeyCode == Keys.Enter)
                this.mtxtAccountNo.Focus();
        }

        private void gbPaymentDetail_Enter(object sender, EventArgs e)
        {

        }

        private void chkVIPCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.mtxtAccountNo.Focus();
        }

        private void chkTakeIncome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.butContinue.Focus();
        }

        private void txtChequeNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.butContinue.Focus();
        }

        //private void cboCurrency_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        txtName.Focus();
        //    }
        //}

        //private void gvCustomer_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    // If the column is the Artist column, check the 
        //    // value. 
        //    //this.gvCustomer.DefaultCellStyle.WrapMode =   DataGridViewTriState.True;
        //    if (this.gvCustomer.Columns[e.ColumnIndex].Name == "colAccountNo")
        //    {
        //        if (e.Value != null)
        //        {
        //               // Check for the string "Account No." in the cell.
        //                e.CellStyle.Format = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);                                         

        //        }
        //    }
            
        //}       
    }
}

