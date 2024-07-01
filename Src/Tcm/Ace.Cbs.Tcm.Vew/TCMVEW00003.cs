//----------------------------------------------------------------------
// <copyright file="TCMVEW00004.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo</CreatedUser>
// <CreatedDate>12/09/2013</CreatedDate>
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
using Ace.Cbs.Cx.Cle;
using System.Windows.Forms;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Tcm.Vew
{
    /// <summary>
    /// PO Issue By Transfer With Income
    /// PO Issue By Transfer With No Income
    /// </summary>
    public partial class TCMVEW00003 : BaseForm, ITCMVEW00003
    {
        #region "Constructor"
        public TCMVEW00003()
        {
            InitializeComponent();
        }
        #endregion

        #region "Controls Input Output"
        public string AccountNo
        {
            get { return this.mtxtAccountNo.Text.Trim(); }
            set { this.mtxtAccountNo.Text = value; }
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

        public decimal POAmount
        {
            get
            {
                if (this.txtPoAmount.Text == string.Empty || this.txtPoAmount.Text == null)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToDecimal(this.txtPoAmount.Text.Trim());
                }
            }
            set { this.txtPoAmount.Text = value.ToString(); }
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
                    return Convert.ToDecimal(this.txtCharges.Text.Trim());
                }
            }
            set { this.txtCharges.Text = value.ToString(); }
        }

        public decimal TotalAmount // Property for totalAmount from txtTotal (Amount + Charges)
        {
            get
            {
                if (this.txtTotal.Text == string.Empty)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToDecimal(this.txtTotal.Text.Trim());
                }
            }
            set { this.txtTotal.Text = value.ToString(); }
        }

        public bool IsVIP
        {
            get
            {
                if (this.chkVIP.Checked)
                    return true;
                else
                    return false;
            }
            set { this.chkVIP.Checked = value; }
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

        public bool isEdit = false;
        public TLMDTO00016 PODTO { get; set; }
        #endregion

        #region "Controller"
        private ITCMCTL00003 poIssueForEncashmentController;
        public ITCMCTL00003 POIssueByTransferController
        {
            get
            {
                return this.poIssueForEncashmentController;
            }
            set
            {
                this.poIssueForEncashmentController = value;
                this.poIssueForEncashmentController.View = this;
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
        private int editRowIndex = -1;
        public int EditRowIndex
        {
            get { return editRowIndex; }
            set { this.editRowIndex = value; }
        }



        #endregion

        #region "Events"
        private void TCMVEW00003_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            this.InitializeControls();            
            if (this.FormName.Equals("POIssueByTransferIncome"))
            {
                this.Texts = "P.O Issue By Transfer (Income)";
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
            if (!string.IsNullOrEmpty(this.mtxtAccountNo.Text))
            {
                decimal totalamount = 0;
                decimal total = 0;
                //<----------------------------->//
                //Used Cheque or Stop Cheque
                //CheckAmout Auto LInk or Saving One time Account No
                if (isEdit)
                {
                    if (this.viewDataList.Count > 1)
                    {
                        for (int i = 0; i < viewDataList.Count; i++)
                            if (this.EditRowIndex != i)
                                total += this.ViewDataList[i].AdjustmentAmount;
                        totalamount = total + this.TotalAmount;
                    }
                    else
                        totalamount = this.TotalAmount;
                }
                else
                {
                    if (this.viewDataList.Count > 0)
                    {
                        for (int i = 0; i < viewDataList.Count; i++)
                            total += this.ViewDataList[i].AdjustmentAmount;
                        totalamount = this.TotalAmount + total;
                    }
                    else
                        totalamount = this.TotalAmount;
                }


                //if (!this.poIssueForEncashmentController.CheckChequeNoAndAmount(AccountNo, ChequeNo, POAmount, true, this.IsVIP, true))
                bool[] check = this.poIssueForEncashmentController.CheckChequeNoAndAmount(AccountNo, ChequeNo, totalamount, true, this.IsVIP, true);
                if (check[0] == false)
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

                            if (this.poIssueForEncashmentController.AddPOIssue())
                            {
                                this.BindTempDataListToGridview();
                                //decimal total = this.ViewDataList[EditRowIndex].AdjustmentAmount;
                                this.mtxtAccountNo.Enabled = false;
                                //this.poIssueForEncashmentController.ClearTextBoxControls();
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

                        this.txtPoAmount.Text = "0";
                        this.txtCharges.Text = "0";
                        this.txtTotal.Text = "0";
                        this.txtPoAmount.Focus();
                    }
                    else
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00037);
                        txtPoAmount.Focus();
                        txtPoAmount.Text = "0";
                    }

                    this.txtCurrency.Enabled = false;
                }
                else
                {
                    if (check[1] == true)
                    {
                        this.txtChequeNo.Focus();
                        return;
                    }
                    else
                    {
                        this.txtPoAmount.Focus();
                        return;
                    }
                }
                isEdit = false;
            }
            else
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME90009); //Account No must not be blank
                mtxtAccountNo.Focus();
                return;
            }
            
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
                if (gvPoIssueForTransfer.RowCount < 1)
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00107);//At least one record must be exist to save.
                    txtPoAmount.Focus();
                    return;
                }
                else
                {
                    this.POIssueByTransferController.SavePOIssueTransfer(this.ViewDataList);
                }
                //Select Top 1 * from RateInfo WITH(NOLOCK) where Cur = ''USD'' and RateType = ''TT'' and Convert(Char(10),RDate,111) = ''2014/01/03'' and LastModify = 1'
                //'Select Top 1 SysDate from Sys001 WITH(NOLOCK) where [Name] = ''NEXT_SETTLEMENT_DATE'''
                //Voucher No Tat mal PONO nat tat mal
                //'Select Top 1 CBAL From Cledger WITH(NOLOCK) where Acctno = ''203211000000016'''
                //@RetValue Varchar(70) EXEC sp_ALUpdate_PO '0512130000026','203211000000016',850,0,'',100,'ADMIN',0,'PO203/0512130003','2013/2014','USD',0,'203','2013/12/05','CBS', @RetValue OUTPUT SELECT @RetValue

            this.poIssueForEncashmentController.ClearErrors();
            this.mtxtAccountNo.Enabled = true;
            this.chkVIP.Checked = false;
            this.mtxtAccountNo.Focus();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
          
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
                    this.POAmount = poIssueEntity.Amount;
                    this.Charges = poIssueEntity.Charges;
                    this.TotalAmount = this.POAmount + this.Charges;
                    this.isEdit = true;                     
                }
                else if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colDelete"))
                {
                    if (CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC90001) == DialogResult.Yes)
                    {
                        decimal amount = this.ViewDataList[e.RowIndex].AdjustmentAmount;
                        this.ViewDataList.RemoveAt(e.RowIndex);
                        this.BindTempDataListToGridview();
                        //this.poIssueForEncashmentController.FormCleaning();
                        this.EditRowIndex = -1;
                        this.txtPoAmount.Text = "0";
                        this.txtCharges.Text = "0";
                        this.txtTotal.Text = "0";
                    }

                }
            }
        }

        private void TCMVEW00003_Load_1(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            this.InitializeControls();
            if (this.FormName.Equals("POIssueByTransferIncome"))
            {
                this.Text = "P.O Issue By Transfer (Income)";
                this.Texts = this.Text;
                this.isWithIncome = true;
            }
            else
            {
                this.Text = "P.O Issue By Transfer (No Income)";
                this.Texts = this.Text;
                this.txtCharges.Enabled = false;
                this.isWithIncome = false;
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

            this.poIssueForEncashmentController.FormCleaning();
            this.txtCurrency.Enabled = true;
            this.txtCurrency.Focus();
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
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            this.Count = Convert.ToInt32(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.MultiTransactionCount));
            this.chkVIP.Focus();
            this.chkVIP.Checked = false;
            this.mtxtAccountNo.Enabled = true;
            this.txtCurrency.Enabled = true;
            this.txtChequeNo.Enabled = true;
            this.POIssueByTransferController.FormCleaning();
            this.txtChequeNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ChequeNoMaximumValue);
        }

        public int Count { get; set; }

        public void DisableChequeNo()
        {
            this.txtChequeNo.Enabled = false;
        }

        public void ClearErrors()
        {
        }
        #endregion

        private void TCMVEW00003_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

    }
}
