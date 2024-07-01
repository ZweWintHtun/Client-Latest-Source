//----------------------------------------------------------------------
// <copyright file="TLMVEW00016.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Su Su Wai</CreatedUser>
// <CreatedDate>09/06/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
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
using System.Linq;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Tel.Vew
{
    /// <summary>
    /// PO Refund By Cash Entry
    /// </summary>\
    public partial class TLMVEW00016 : BaseDockingForm, ITLMVEW00016
    {
        #region "Constractor"
        public TLMVEW00016()
        {
            InitializeComponent();
        }
        #endregion
        
        #region "Variables"

        private int editRowIndex = -1;
        public int EditRowIndex
        {
            get { return editRowIndex; }
            set { this.editRowIndex = value; }
        }
        public string SourceBranchCode { get; set; }
        
        #endregion

        #region "Controls Input Output"
        public string VoucherNoLabel
        {
            get { return this.lblVoucherNo.Text; } 
            set { this.lblVoucherNo.Text = value; }
        }

        public bool HasNotToAdd { get; set; }
        public string BudgetYear
        {
            get { return this.txtBudgetYear.Text.Trim(); }
            set { this.txtBudgetYear.Text = value; }
        }
        public string PaymentOrderNo
        {
            get { return this.txtPaymentOrderNo.Text.Trim(); }
            set { this.txtPaymentOrderNo.Text = value; }
        }
        public string GroupNo
        {
            set { this.txtGroupNo.Text = value; }
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
            set
            {
                this.cboCurrency.SelectedValue = value;
            }
        }
        public string RegisterNo
        {
            get { return this.txtRegisterNo.Text.Trim(); }
            set { this.txtRegisterNo.Text = value; }
        }
        public double Amount
        {
            get { return Convert.ToDouble(this.txtAmount.Value); }
            set { this.txtAmount.Text = Convert.ToDouble(value).ToString("N2"); }//Modified by HMW at 03-Oct-2019            
        }
        public double TotalAmount
        {
            get { return Convert.ToDouble(this.txtTotalAmount.Value); }
            set { this.txtTotalAmount.Text = Convert.ToDouble(value).ToString("N2"); }//Modified by HMW at 03-Oct-2019
        }
        private IList<TLMDTO00041> paymentOrderDataSource;
        public IList<TLMDTO00041> PaymentOrderDataSource
        {
            get
            {
                if (this.paymentOrderDataSource == null)
                    this.paymentOrderDataSource = new List<TLMDTO00041>();

                return this.paymentOrderDataSource;
            }
            set
            {
                this.paymentOrderDataSource = value;
            }
        }

        public bool isAdd { get; set; }

        #endregion

        #region "Controller"

        private ITLMCTL00016 poRefundByCashController;
        public ITLMCTL00016 Controller
        {
            get
            {
                return this.poRefundByCashController;
            }
            set
            {
                this.poRefundByCashController = value;
                this.poRefundByCashController.View = this;
            }
        }

        #endregion

        #region "Method"

        public void FocusOnPOTextBox()
        {
            /*Modified By HWH*/
            this.txtPaymentOrderNo.Focus();
            this.txtPaymentOrderNo.SelectionStart = this.txtPaymentOrderNo.TextLength;
          
        }
        private void InitializeControls()
        {
            this.SourceBranchCode = CXCOM00007.Instance.BranchCode;
            this.gvPaymentOrder.AutoGenerateColumns = false;
            this.BindComboBoxes();
            this.Controller.ClearControls();
            this.cboCurrency.Focus();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
            //this.BudgetYear = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode);            
            //string Return = String.Empty;
            //this.BudgetYear = BLFDAO.GetBudget_Month_Year_Quarter(2, DateTime.Now, this.SourceBranchCode, Return);

            //Get Budget Year (New Logic by HMW at 5.4.2019)
            this.BudgetYear = this.Controller.GetBudYear();
            txtBudgetYear.Text = this.BudgetYear;

            //this.txtPaymentOrderNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.POTextBoxFormat);
            this.txtAmount.Text = "0.00";
            this.txtTotalAmount.Text = "0.00";
        }

        private void EnableDisableControls()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            this.txtRegisterNo.ReadOnly = true;
            this.txtTotalAmount.ReadOnly = true;
            this.txtAmount.ReadOnly = true;
            this.txtGroupNo.ReadOnly = true;            
        }
        private void BindComboBoxes()
        {
            IList<CurrencyDTO> CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = CurrencyList;
        }
        public void BindPaymentOrder()
        {
            this.gvPaymentOrder.AutoGenerateColumns = false;
            this.gvPaymentOrder.DataSource = null;            
            if(PaymentOrderDataSource.Count>0)
                this.gvPaymentOrder.DataSource = this.PaymentOrderDataSource;          

        }
        public void Successful(string message, string groupCode)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message, new object[] { groupCode });
            // Clear all controls
            this.Controller.ClearControls();
            this.txtAmount.Clear();
            this.cboCurrency.Enabled = true;
            this.cboCurrency.Focus();
            this.BudgetYear = this.Controller.GetBudYear();//HMW
        }
        public void Failure(string message,string poNo)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message, new object[] { poNo });
        }
        public void Failure(string message, string string1,string string2)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message, new object[] { string1, string2 });
        }
        #endregion

        #region "Event"

        private void TLMVEW00016_Load(object sender, EventArgs e)
        {
            #region Old_Logic
            /*
            // Enable / Disable Controls
            this.EnableDisableControls();

            // Set Initialize Controls
            this.InitializeControls();
            this.txtPaymentOrderNo.Focus();
            */
            #endregion

            #region Seperating_EOD_Logic (Added By YMP at 30-07-2019, Modified by HMW at 26-08-2019)
            DateTime systemDate = this.Controller.GetSystemDate(CurrentUserEntity.BranchCode);
            DateTime lastSettlementDate = this.Controller.GetLastSettlementDate(CurrentUserEntity.BranchCode);

            this.lblTransactionDate.Text = systemDate.ToString("dd-MM-yyyy");

            if (systemDate.ToString("dd-MM-yyyy") != lastSettlementDate.ToString("dd-MM-yyyy")) //Show Form
            {
                // Enable / Disable Controls
                this.EnableDisableControls();

                // Set Initialize Controls
                this.InitializeControls();
                this.txtPaymentOrderNo.Focus();
            }
            else //Don't show form after cut off
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI50013);//You have no permission.\n"Back Date EOD Process" needs to be completed!
                this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
                //this.InitializeControls();
                this.DisableControls("PaymentToDealerByCash.AllDisable");
            }
            #endregion
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.Controller.Save();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.Controller.ClearControls();
            this.BindPaymentOrder();
            this.txtAmount.Clear();
            this.cboCurrency.Enabled = true;
            this.cboCurrency.Focus();
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            if (this.EditRowIndex.Equals(-1))
            {
                this.HasNotToAdd = false;
                if (this.Controller.AddPaymentOrder())
                {
                    this.Amount = 0;
                    this.BindPaymentOrder();
                    this.Controller.ClearTextBox();
                    if (this.cboCurrency.Enabled)
                        this.cboCurrency.Enabled = false;
                }                
            }
            else
            {
                if (this.Controller.EditPaymentOrder(this.EditRowIndex))
                {
                    this.BindPaymentOrder();
                    this.Controller.ClearTextBox();
                    this.EditRowIndex = -1;
                }
            }
            this.HasNotToAdd = false;            
            this.tsbCRUD.butSave.Focus();      
            
            //this.txtPaymentOrderNo.Focus();
        }

        private void gvPaymentOrder_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void gvPaymentOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                DataGridViewRow dataRow = (DataGridViewRow)gvPaymentOrder.Rows[e.RowIndex];
                DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

                if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colEdit"))
                {
                    TLMDTO00041 paymentOrderEntity = (TLMDTO00041)gvPaymentOrder.Rows[e.RowIndex].DataBoundItem;
                    this.EditRowIndex = this.PaymentOrderDataSource.ToList().FindIndex(x => x.PaymentOrderNo.Equals(paymentOrderEntity.PaymentOrderNo));
                    this.CurrencyCode = paymentOrderEntity.CurrencyCode;
                    this.PaymentOrderNo = paymentOrderEntity.PaymentOrderNo;
                    this.RegisterNo = paymentOrderEntity.RegisterNo;
                    this.Amount = Convert.ToDouble(paymentOrderEntity.Amount);
                    this.BudgetYear = paymentOrderEntity.BudgetYear;
                }

                else if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colDelete"))
                {
                    if (CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC90001) == DialogResult.Yes)
                    {
                        double amount = Convert.ToDouble(this.PaymentOrderDataSource[e.RowIndex].Amount);
                        this.PaymentOrderDataSource.RemoveAt(e.RowIndex);
                        this.TotalAmount -= amount;
                        this.BindPaymentOrder();
                        this.Controller.ClearTextBox();
                        this.EditRowIndex = -1;
                        if (this.PaymentOrderDataSource.Count < 2) //if gridView row is less than 2, change Label GroupNo to VoucherNo
                            this.VoucherNoLabel = "Voucher No :";
                    }
                }
            }
        }

        private void txtPaymentOrderNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }


        //private void TLMVEW00016_KeyDown(object sender, KeyEventArgs e)  //added by KSWin
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        this.SelectNextControl(this.ActiveControl, true, true, true, true);
        //    }
        //}

        #endregion

      
    }
}
