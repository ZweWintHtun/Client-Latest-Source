//----------------------------------------------------------------------
// <copyright file="MNMVEW00020.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>10/23/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Cx.Com.Utt;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;


namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00020 : BaseDockingForm,IMNMVEW00020
    {
        #region "Constructor"
        public MNMVEW00020()
        {
            InitializeComponent();
        }
        #endregion

        #region "Controls Input Output"

        public string AccountNo
        {
            get { return this.mtxtAccountNo.Text; }
            set { this.mtxtAccountNo.Text = value; }
        }
       
        public string PaymentOrderNo
        {
            get { return this.mtxtPaymentOrderNo.Text.Trim(); }
            set { this.mtxtPaymentOrderNo.Text = value; }
        }

        public string Currency
        {
            get { return this.txtCurrency.Text.Trim(); }
            set { this.txtCurrency.Text = value; }
        }

        public string ChequeNo
        {
            get { return this.txtChequeNo.Text.Trim(); }
            set { this.txtChequeNo.Text = value; }
        }

        public string BudgetYear
        {
            get { return this.txtYear.Text.Trim(); }
            set { this.txtYear.Text = value; }
        }


        public decimal POAmount
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtAmount.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtAmount.Text = value.ToString(); }
        }

        public decimal Charges
        {
            get
            {
                if (this.txtCharges.Text == string.Empty)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToDecimal(this.txtCharges.Text);
                }
            }
            set { this.txtCharges.Text = value.ToString(); }
        }

        public decimal TotalAmount // Property for totalAmount from txtTotal (Amount + Charges)
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtTotal.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtTotal.Text = value.ToString(); }
        }

        public bool IsVIPCustomer
        {
            get
            {
                if (this.chkVIPCustomer.Checked)
                    return true;
                else
                    return false;
            }
            set { this.chkVIPCustomer.Checked = value; }
        }
        
        public string ACSign
        {
            get;
            set;
        }

        public string Texts
        {
            get;
            set;
        }

        public TLMDTO00016 PODTO { get; set; }
        #endregion

        #region "Controller"

        private IMNMCTL00020 poIssueForTsransferController;
        public IMNMCTL00020 Controller
        {
            get
            {
                return this.poIssueForTsransferController;
            }
            set
            {
                this.poIssueForTsransferController = value;
                this.poIssueForTsransferController.View = this;
            }
        }
        #endregion

        #region "Properties"

        public TLMDTO00043 TempData { get; set; }

        public IList<TLMDTO00043> viewDataList;
        public IList<TLMDTO00043> ViewDataList
        {
            get
            {
                if (this.viewDataList == null)
                    this.viewDataList = new List<TLMDTO00043>();

                return this.viewDataList;
            }
            set
            {
                this.viewDataList = value;
            }
        }
    
        public bool isWithIncome { get; set; }
        public int Count { get; set; }
        private int editRowIndex = -1;
        public int EditRowIndex
        {
            get { return editRowIndex; }
            set { this.editRowIndex = value; }
        }

        #endregion

        #region "Events"

        private void MNMVEW00020_Load(object sender, EventArgs e)
        {
            this.chkVIPCustomer.Focus();
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            this.InitializeControls();
            if (this.FormName.Equals("POIssueByTransferIncome"))
            {
                this.Texts = "P.O Issue By Transfer (Income) ";
                this.Text = this.Texts;
                this.isWithIncome = true;
            }
            else
            {
                this.Texts = "P.O Issue By Transfer (No Income)";
                this.Text = this.Texts;
                this.txtCharges.Enabled = false;
                this.isWithIncome = false;
            }
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            //<----------------------------->//
            //Used Cheque or Stop Cheque
            //CheckAmout Auto LInk or Saving One time Account No            

            if (!this.poIssueForTsransferController.CheckChequeNoAndAmount(AccountNo, ChequeNo, POAmount, true, this.IsVIPCustomer, true))
            {
                if (this.ViewDataList.Count != 0 && this.Count.Equals(this.ViewDataList.Count))
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00210);
                    return;
                }
                else if (this.POAmount > 0)
                {
                    if (this.EditRowIndex.Equals(-1))
                    {
                        if (this.txtCurrency.Enabled)
                            this.txtCurrency.Enabled = false;
                        if (this.ViewDataList.Count > 0)
                        {
                            var duplicateRecord = this.ViewDataList.Where(x => x.PONo == this.PaymentOrderNo).ToList<TLMDTO00043>();
                            if (duplicateRecord.Count() > 0)
                            {
                                //This P.O No. {0} is already exist in this grid.
                                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00150, new object[] { this.PaymentOrderNo });
                                return;
                            }

                        }

                        if (this.poIssueForTsransferController.AddPOIssue())
                        {
                            this.BindTempDataListToGridview();                      

                        }
                    }
                    else
                    {

                        this.ViewDataList[EditRowIndex].Amount = this.POAmount;
                        this.ViewDataList[EditRowIndex].AdjustmentAmount = this.TotalAmount;
                        this.ViewDataList[EditRowIndex].Charges = this.Charges;
                        this.BindTempDataListToGridview();
                        this.EditRowIndex = -1;
                    }
                    this.mtxtPaymentOrderNo.Focus();
                    this.mtxtPaymentOrderNo.Text = string.Empty;
                    this.txtCharges.Text = "0.00";
                    this.txtChequeNo.Text = null;
                    this.txtAmount.Text = "0.00";
                    this.txtTotal.Text = "0.00";
                }
                else
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00037);
                    txtAmount.Focus();
                    txtAmount.Text = "0";
                }

                this.txtCurrency.Enabled = false;
            }
            else
            {
                this.txtChequeNo.Focus();
                return;

            }
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            //TLMDTO00043 POIssueDTO = this.poIssueForTsransferController.GetEntity();
            //if (this.poIssueForTsransferController.ValidateForm(POIssueDTO))
            //{
                if (gvPoIssueForTransfer.RowCount < 1)
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00107);//At least one record must be exist to save.
                    txtAmount.Focus();
                    return;
                }
                else
                {
                   
                    this.Controller.SavePOIssueTransfer(this.ViewDataList);                    
                }

                //Select Top 1 * from RateInfo WITH(NOLOCK) where Cur = ''USD'' and RateType = ''TT'' and Convert(Char(10),RDate,111) = ''2014/01/03'' and LastModify = 1'
                //'Select Top 1 SysDate from Sys001 WITH(NOLOCK) where [Name] = ''NEXT_SETTLEMENT_DATE'''
                //Voucher No Tat mal PONO nat tat mal
                //'Select Top 1 CBAL From Cledger WITH(NOLOCK) where Acctno = ''203211000000016'''
                //@RetValue Varchar(70) EXEC sp_ALUpdate_PO '0512130000026','203211000000016',850,0,'',100,'ADMIN',0,'PO203/0512130003','2013/2014','USD',0,'203','2013/12/05','CBS', @RetValue OUTPUT SELECT @RetValue
            //}
            
            this.chkVIPCustomer.Focus();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
           // this.Controller.ClearCustomErrorMessage();
        }

        private void gvPoIssueForTransfer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                DataGridViewRow dataRow = (DataGridViewRow)gvPoIssueForTransfer.Rows[e.RowIndex];
                DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

                if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colEdit"))
                {
                    TLMDTO00043 poIssueEntity = (TLMDTO00043)gvPoIssueForTransfer.Rows[e.RowIndex].DataBoundItem;
                    this.EditRowIndex = e.RowIndex;
                    this.PaymentOrderNo = poIssueEntity.PONo;
                    this.ChequeNo = poIssueEntity.CheckNo;
                    this.POAmount = poIssueEntity.Amount;
                    this.Charges = poIssueEntity.Charges;
                    this.TotalAmount = this.POAmount + this.Charges;
                }
                else if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colDelete"))
                {
                    if (CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC90001) == DialogResult.Yes)
                    {
                        decimal amount = this.ViewDataList[e.RowIndex].Amount;
                        this.ViewDataList.RemoveAt(e.RowIndex);
                        this.BindTempDataListToGridview();
                        //this.poIssueForEncashmentController.FormCleaning();
                        this.EditRowIndex = -1;
                    }

                }
            }
        }

        #endregion

        #region "Methods"

        public void BindTempDataListToGridview() // To Bind TempDataList to GridView
        {
            this.gvPoIssueForTransfer.AutoGenerateColumns = false;
            this.gvPoIssueForTransfer.DataSource = null;
            if (ViewDataList.Count > 0)
                gvPoIssueForTransfer.DataSource = this.ViewDataList;
        }

        public void Successful(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
  
        }

        /*---When printing Saving Passbook,need Menu Permission Id ---*/
        public int GetMenuIDPermission()
        {
            int menuIdPermission = this.MenuIdForPermission;
            return menuIdPermission;
        }

        public void SetFoucsChequeNo()
        {
            this.txtChequeNo.Focus();
        }

        public void Failure(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME90000);
            }
            else
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
            }
        }

        public void InitializeControls()
        {
            this.Count = Convert.ToInt32(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.MultiTransactionCount));
            this.txtYear.Text = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode); 
            //this.chkVIPCustomer.Focus();
            this.chkVIPCustomer.Checked = false;
            //this.mtxtAccountNo.Focus();
            //this.chkVIPCustomer.Focus();
            this.mtxtPaymentOrderNo.Text = string.Empty;
            this.txtCurrency.Text = string.Empty;
            this.txtCharges.Text = "0.00";
            this.txtAmount.Text = "0.00";
            this.txtTotal.Text = "0.00";
            this.txtYear.Enabled = false;
           // this.txtChequeNo.Enabled = false;
            this.txtCurrency.Enabled = false;
            this.txtCharges.Enabled = false;
            this.Controller.FormCleaning();
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            this.txtChequeNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ChequeNoMaximumValue);
            
        }      

        public void DisableChequeNo()
        {
            this.txtChequeNo.Enabled = false;
            this.chkVIPCustomer.Enabled = false;
        }

       #endregion     

        private void mtxtAccountNo_Validating(object sender, CancelEventArgs e)
        {
            //this.chkVIPCustomer.Focus();
        }

     }
}
