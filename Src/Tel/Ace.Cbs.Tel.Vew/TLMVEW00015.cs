//----------------------------------------------------------------------
// <copyright file="TLMVEW00015.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Ye Mann Aung</CreatedUser>
// <CreatedDate></CreatedDate>
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
using Ace.Windows.Core.Utt;
using System.Linq;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Tel.Vew
{
    public partial class TLMVEW00015 : BaseForm, ITLMVEW00015
    {
        #region constructor

        public TLMVEW00015()
        {
            InitializeComponent();
        }

        #endregion

        public static bool isBegun = true;
        public static bool isEdited = false;
        #region Properties

        private ITLMCTL00015 _controller;
        public ITLMCTL00015 Controller
        {
            get
            {
                return this._controller;
            }
            set
            {
                this._controller = value;
                _controller.View = this;
            }
        }

        public int Count { get; set; }
        public string _Name
        {
            get { return this.Name; }
            set { this.Name = value; }
        }
        public string GroupNo //Property For GroupNo
        {
            get { return this.txtGroupNo.Text; }
            set { this.txtGroupNo.Text = value; }
        }

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

        public decimal Amount // Property for inputed amount from txtAmount
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtAmount.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtAmount.Text = value.ToString(); }
        }

        public decimal Charges // Property for charges from txtCharges
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtCharges.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtCharges.Text = value.ToString(); }
        }

        public bool isWithIncome { get; set; }
        public decimal TotalAmount // Property for totalAmount from txtTotal (Amount + Charges)
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtTotalAmount.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtTotalAmount.Text = value.ToString(); }
        }

        public string SourceBranchCode
        {
            get
            {
                return CXCOM00007.Instance.BranchCode;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IList<TLMDTO00012> DenoInfo { get; set; }

        public string PONo { get; set; }

        public decimal POCharges { get; set; }

        public string RegisterNo { get; set; }

        public int SrNo { get; set; }


        public IList<TLMDTO00042> viewDataList;
        public IList<TLMDTO00042> ViewDataList
        {
            get 
            {
                if (this.viewDataList == null)
                    this.viewDataList = new List<TLMDTO00042>();

                return this.viewDataList;
            }
            set 
            {
                this.viewDataList = value;
            }
        }

        private int editRowIndex = -1;
        public int EditRowIndex
        {
            get { return editRowIndex; }
            set { this.editRowIndex = value; }
        }

        public TLMDTO00042 TempData{get;set;}

        #endregion

        #region method
        
        private void BindCurrencyComboBoxes()
        {
            IList<CurrencyDTO> CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = CurrencyList;
            cboCurrency.SelectedIndex = 0;
        }

        public void BindTempDataListToGridview() // To Bind TempDataList to GridView
        {
            this.gvMultiPaymentOrderIssueInformation.AutoGenerateColumns = false;
            this.gvMultiPaymentOrderIssueInformation.DataSource = null;
            if(ViewDataList.Count > 0)
                gvMultiPaymentOrderIssueInformation.DataSource = this.ViewDataList;
        }

        public void InitializeControls()
        {
            this.Count = Convert.ToInt32(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.MultiTransactionCount));
            this.Controller.FormCleaning();
            this.BindCurrencyComboBoxes();
            this.txtAmount.Text = "0.00";
            this.txtCharges.Text = "0.00";
            this.txtTotalAmount.Text = "0.00";
        }
        #endregion

        #region Events
        private void butAdd_Click(object sender, EventArgs e)
        {
            if (this.Count.Equals(this.ViewDataList.Count))
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00210);
                return;
            }
            else if (this.Amount > 0 )
            {
                if (this.isWithIncome==true && this.Charges == 0)
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME00036);//PO Rate Not Found in Table
                }
                else
                {
                    if (this.EditRowIndex.Equals(-1))
                    {
                        if (this.cboCurrency.Enabled)
                            this.cboCurrency.Enabled = false;
                        if (this.Controller.AddPOIssue())
                        {
                            this.BindTempDataListToGridview();
                            this.Controller.ClearTextBoxControls();
                        }
                    }
                    else
                    {
                        if (this.Controller.EditPOIssue(this.EditRowIndex))
                        {
                            this.BindTempDataListToGridview();
                            this.Controller.ClearTextBoxControls();
                            this.EditRowIndex = -1;
                        }
                    }
                }
                this.txtAmount.Focus();
            }
            else
            {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00037);
                    txtAmount.Focus();                
            }
        }

        private void TLMVEW00015_Load(object sender, EventArgs e)
        {
            // Button Enable Disabled
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            this.InitializeControls();
            if (this.FormName.Equals("POIssue.Income"))
            {
                this.Text = "Payment Order Issue Entry (Income)";
                this.isWithIncome = true;
            }
            else
            {
                this.Text = "Payment Order Issue Entry (No Income)";
                this.isWithIncome = false;
            }
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.Controller.FormCleaning();
            this.cboCurrency.Enabled = true;
            this.cboCurrency.Focus();
        }

        private void gvMultiPaymentOrderIssueInformation_CellClick(object sender, DataGridViewCellEventArgs e) // For Edit
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                DataGridViewRow dataRow = (DataGridViewRow)gvMultiPaymentOrderIssueInformation.Rows[e.RowIndex];
                DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

                if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colEdit"))
                {
                    TLMDTO00042 poIssueEntity = (TLMDTO00042)gvMultiPaymentOrderIssueInformation.Rows[e.RowIndex].DataBoundItem;
                    this.EditRowIndex = e.RowIndex;
                    this.Amount = poIssueEntity.Amount;
                    this.Charges = poIssueEntity.Charges;
                    this.TotalAmount = this.Amount + this.Charges;
                }
                else if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colDelete"))
                {
                    if (CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC90001) == DialogResult.Yes)
                    {
                        decimal amount = this.ViewDataList[e.RowIndex].Amount;
                        this.ViewDataList.RemoveAt(e.RowIndex);
                        this.BindTempDataListToGridview();
                        this.Controller.ClearTextBoxControls();
                        this.EditRowIndex = -1;
                    }

                }
            }
            
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
          
            if (gvMultiPaymentOrderIssueInformation.RowCount <1)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00107);//At least one record must be exist to save.
                txtAmount.Focus();
                return;
            }
            else
                this.Controller.Save(ViewDataList);
        }

        public void Successful(string message)
        {
            if (GroupNo == string.Empty)
            {
                GroupNo = this.ViewDataList[0].PONo;
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message, new object[] { "PONo", this.ViewDataList[0].PONo });
            }
            else
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message, new object[] { "GroupNo", this.GroupNo });
            }
            this.Controller.FormCleaning();
            this.cboCurrency.Enabled = true;
            this.cboCurrency.Focus();
        }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }
       
        private void txtAmount_Validated(object sender, EventArgs e)
        {
            if (Amount > 0)
            {
                cboCurrency.Enabled = false;
                if(isWithIncome)
                    if(Currency != null)
                        Charges = CXCLE00010.Instance.CalculatePOrate(this.Amount, this.Currency);
                if (isWithIncome==true && Charges == 0)
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME00036);
                }
                else
                {
                    TotalAmount = Amount + Charges;
                }
            }
        }

        public void ChangeControlName(bool isChanged)
        {
           lblGroupNo.Text= (isChanged)?("Voucher NO :"):("Group No :");
        }

        private void cboCurrency_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cboCurrency.Text))
                butAdd.Enabled = true;
        }

        #endregion


        private void TLMVEW00015_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

    }
}
