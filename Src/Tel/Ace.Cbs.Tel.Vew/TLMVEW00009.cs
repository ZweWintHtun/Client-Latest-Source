//----------------------------------------------------------------------
// <copyright file="TLMVEW00009.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Yu Thandar Aung</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;

namespace Ace.Cbs.Tel.Vew
{
    /// <summary>
    /// FixedDeposit DepositEntry
    /// </summary>
    public partial class frmTLMVEW00009 : BaseDockingForm, ITLMVEW00009
    {
        #region Constructor
        public frmTLMVEW00009()
        {
            InitializeComponent();
        }
        #endregion

        #region Controller
        private ITLMCTL00009 controller;
        public ITLMCTL00009 Controller
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
        #endregion

        #region Properties
        
        public string AccountNo
        {
            get
            {
                return this.mtxtAccountNo.Text;
            }
            set
            {
                mtxtAccountNo.Text = value;
            }
        }

        public string ReceiptNo
        {
            get
            {
                if (this.cboReceiptNo.Text == null)
                {
                    return null;
                }
                else
                {
                    return this.cboReceiptNo.Text.ToString();
                }
            }
            set
            {
                this.cboReceiptNo.SelectedValue = value;
            }
        }

        public string Duration
        {
            get
            {
                return this.txtDuration.Text;
            }
            set
            {
                txtDuration.Text = value;
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

        public Image Photo
        {
            get { return this.pbPhoto.Image; }
            set { this.pbPhoto.Image = value; }
        }

        public Image Signature
        {
            get { return this.pbSignature.Image; }
            set { this.pbSignature.Image = value; }
        }

        public IList<PFMDTO00032> FReceiptList { get; set; }

        //For Currency require for Receipt
        public string CurrencyCode { get; set; }

        private string parentFormId = string.Empty;
        public string ParentFormId
        {
            get { return this.parentFormId; }
            set { this.parentFormId = value; }
        }
        
        #endregion

        #region Events
        
        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TLMVEW00009_Load(object sender, EventArgs e)
        {
            this.EnableDisableControls();
            this.InitializeControls();
            ParentFormId = this.Name;
            this.lblTransactionDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            if (this.cboReceiptNo.SelectedIndex == -1 && (!string.IsNullOrEmpty(this.mtxtAccountNo.Text)))
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00022);//Invalid Receipt No.
                this.cboReceiptNo.Focus();
            }
            else
            {
                if (this.controller.Save())
                {
                    if (CXUIMessageUtilities.ShowMessageByCode("MC00002") == DialogResult.Yes)//Are you sure to print?
                    {
                        this.controller.Printing();
                    }
                    this.controller.ClearControls();
                    this.InitializeControls();
                    this.gvCustomer.DataSource = null;
                    this.mtxtAccountNo.Focus();
                }
            }
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.controller.ClearControls();
            this.InitializeControls();
            this.gvCustomer.DataSource = null;
            this.controller.ClearErrors();
        }

        private void cboReceiptNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            PFMDTO00032 receipt = this.controller.BindReceiptInfo();
            if (receipt != null)
            {
                this.Amount = receipt.Amount;
                this.Duration = DurationFormat(receipt.Duration);
                this.CurrencyCode = receipt.CurrencyCode;
            }
            this.tsbCRUD.butSave.Focus();
        }
             
        private void gvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                PFMDTO00001 customer = this.gvCustomer.Rows[e.RowIndex].DataBoundItem as PFMDTO00001;
                PFMDTO00001 customerResult = CXClientWrapper.Instance.Invoke<ICXSVE00006, PFMDTO00001>(x => x.GetCustomerByCustomerId(customer.CustomerId));
                if (customerResult != null)
                {
                    if (customerResult.CustPhoto.CustPhotos != null)
                    {
                        this.Photo = CXClientGlobal.GetImage(customerResult.CustPhoto.CustPhotos);
                    }
                    else
                    {
                        this.Photo = null;
                    }

                    if (customerResult.Signature != null)
                    {
                        this.Signature = CXClientGlobal.GetImage(customerResult.Signature);
                    }
                    else
                    {
                        this.Signature = null;
                    }
                }
            }
        }
        #endregion
                
        #region Methods
        
        public void gvCustomer_DataBind(IList<PFMDTO00001> customerList)
        {
            this.gvCustomer.DataSource = null;
            gvCustomer.AutoGenerateColumns = false;
            this.gvCustomer.DataSource = customerList;
            if (customerList == null || customerList.Count < 0)
            {
                this.Photo = null;
                this.Signature = null;
            }
            else
            {
                foreach(PFMDTO00001 customerInfo in customerList)
                {
                    if(customerInfo.CustPhotos != null)
                    {
                        this.Photo = CXClientGlobal.GetImage(customerInfo.CustPhotos);
                        if(customerInfo.Signature != null)
                        {
                            this.Signature = CXClientGlobal.GetImage(customerInfo.Signature);
                            break;
                        }
                    }                    
                }
            }
        }

        public void BindReceiptNo()
        {
            if (FReceiptList != null)
            {
                cboReceiptNo.ValueMember = "ReceiptNo";
                cboReceiptNo.DisplayMember = "ReceiptNo";
                cboReceiptNo.DataSource = FReceiptList;
                this.cboReceiptNo.SelectedIndex = -1;

                if (this.cboReceiptNo.SelectedIndex == -1)
                {
                    this.Duration = string.Empty;
                    this.Amount = 0;
                }
                this.EnableControls();
                this.cboReceiptNo.Focus();
            }
        }

        private void EnableDisableControls()
        {
            tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
        }

        private void InitializeControls()
        {
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            this.FReceiptList = null;
            this.DisableControls();
            this.Controller.Status = string.Empty;
            this.mtxtAccountNo.Focus();
        }

        public string DurationFormat(decimal duration)
        {
            string Duration = string.Empty;
            if (duration < 1)
            {
                if ((duration * 4) > 1)
                {
                    Duration = ((duration * 4).ToString().Replace(".00", " Weeks"));
                }
                else
                {
                    Duration = ((duration * 4).ToString().Replace(".00", " Week"));
                }

            }
            else if (duration < 12)
            {
                if (((duration % 12) > 1))
                {
                    Duration = ((duration % 12).ToString().Replace(".00", " Months"));
                }
                else
                {
                    Duration = ((duration % 12).ToString().Replace(".00", " Month"));
                }
            }
           
            else if ((duration / 12) > 1)
            {
                Duration = ((duration / 12).ToString().Replace(".00", " Years"));
            }
            else
            {
                Duration = ((duration / 12).ToString().Replace(".00", " Year"));
            }

            return Duration;
            //return (duration < 12) ? duration.ToString().Replace(".00", " Months") : (duration / 12) > 1 ? ((duration / 12).ToString().Replace(".00", " Years")) : ((duration / 12).ToString().Replace(".00", " Year"));
        }

        public void EnableControls()
        {
            this.EnableControls("FixedDepositWithdraw.Enable");
        }

        public void DisableControls()
        {
            this.DisableControls("FixedDepositDeposit.Disable");
        }
        
        public void Successful(string message, string VoucherNo)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message, new object[] {"Voucher No", VoucherNo });
        }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }
        #endregion

    }
}
