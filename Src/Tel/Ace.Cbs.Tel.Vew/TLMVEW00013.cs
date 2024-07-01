// <copyright file="TLMVEW00013.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate>2013-05-21</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version>1.0</Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Com.Ctr;

namespace Ace.Cbs.Tel.Vew
{
    // Fixed Deposit Withdraw Form
    public partial class TLMVEW00013 : BaseDockingForm, ITLMVEW00013
    {
        #region Constructor
        public TLMVEW00013()
        {
            InitializeComponent();
        }
        #endregion

        #region Controller  
        private ITLMCTL00013 controller;
        public ITLMCTL00013 Controller
        {
            get { return this.controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }
        #endregion

        #region Controls Input Output
        public string AccountNo
        {
            get { return this.mtxtAccountNo.Text; }
            set { this.mtxtAccountNo.Text = value; }
        }        

        public string VoucherNo
        {
            get { return this.txtVoucherNo.Text; }
            set { this.txtVoucherNo.Text = value; }
        }       

        public string RegisterDuration
        {
            get { return this.txtDuration.Text; }
            set { this.txtDuration.Text = value; }
        }      

        public decimal Amount
        {
            get { return this.txtAmount.Value; }
            set { this.txtAmount.Text = value.ToString(); }
        }       

        public string RegisterDate
        {
            get { return this.txtDate.Text; }
            set { this.txtDate.Text = value; }
        }

        public bool isSelected = false;


        //public decimal Amount
        //{
        //    get
        //    {
        //        decimal result = 0;
        //        decimal.TryParse(this.txtAmount.Text, out result);
        //        return Math.Round(result, 2);
        //    }
        //    set { this.txtAmount.Text = value.ToString(); }
        //}
        public decimal AvailableInterestAfterTax
        {
            get 
            {
                decimal result = 0;
                decimal.TryParse(this.txtInterestAfterTax.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtInterestAfterTax.Text = value.ToString(); }
        }       

        public decimal TotalAmount
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtTotalAmount.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtTotalAmount.Text = value.ToString(); }
        }       

        public int NoOfPerson
        {
            get
            {
                return Convert.ToInt32(this.txtNoOfPerson.Value);
            }
            set { this.txtNoOfPerson.Text = value.ToString(); }
        }        

        public string JoinType
        {
            get { return this.txtJointType.Text; }
            set { this.txtJointType.Text = value; }
        }

        public string ReceiptNo
        {
            get
            {
                if (this.cboReceiptNo.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cboReceiptNo.SelectedValue.ToString();
                }
            }
            set { this.cboReceiptNo.SelectedValue = value; }
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

        public string AccountSign { get; set; }       
        public string CurrencyCode { get; set; }
        public DateTime LastIntDate { get; set; } 
        public decimal Duration { get; set;}
        public string AccuredStatus { get; set; }
        public string Receipt { get; set; }
        public decimal InterestRate { get; set; }
        public decimal Accrued { get; set; }
        public IList<PFMDTO00032> receiptNoList { get; set; }
        public string Status { get; set; }
        public bool MatureStatus { get; set; }
        #endregion      
       
        #region Methods
        public void EnableControls()
        {
            this.EnableControls("FixedDepositWithdraw.Enable");
        }

        private void InitializeControls()
        {
            //Enable or Disable the Toolstrip Menu
            tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            //Set Mask Property to Account No Mask textbox
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            this.DisableControls("FixedDepositWithdraw.Disable");
            //Set Focus
            this.mtxtAccountNo.Focus();
            this.Status = string.Empty;
        }
            
        public void gvClearing_DataSourceNull()
        {
            this.gvCustomer.DataSource = null;
        }

        public void gvCustomer_DataBind(IList<PFMDTO00001> customerDTOList)
        {
            this.gvCustomer.DataSource = null;
            gvCustomer.AutoGenerateColumns = false;
            this.gvCustomer.DataSource = customerDTOList;
        }

        public IList<PFMDTO00032> BindReceiptNo(IList<PFMDTO00032> receiptNoList)
        {
            try
            {  
                 
                cboReceiptNo.ValueMember = "ReceiptNo";
                cboReceiptNo.DisplayMember = "ReceiptNo";
                cboReceiptNo.DataSource = receiptNoList;
                this.cboReceiptNo.SelectedIndexChanged -= new EventHandler(cboReceiptNo_SelectedIndexChanged);
                cboReceiptNo.SelectedIndex = -1;
                this.cboReceiptNo.SelectedIndexChanged += new EventHandler(cboReceiptNo_SelectedIndexChanged); 
                return this.receiptNoList;
             
            }
            catch (Exception ex)
            { return null; }
        }

        public void ReceiptBind()
        {
            this.cboReceiptNo.SelectedIndex = -1;
        }

        public void Successful(string message, string VoucherNo)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message, new object[] { "Voucher No", VoucherNo });
            this.DisableControls("FixedDepositWithdraw.Disable");
        }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }
        #endregion

        #region Event
        private void TLMVEW00013_Load(object sender, EventArgs e)
        {
             this.InitializeControls();         
        }      

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {

          this.Status = "Save";
       //   this.cboReceiptNo.SelectedIndexChanged -= new EventHandler(cboReceiptNo_SelectedIndexChanged);
          
          if (this.controller.Validate())
          {
              //if (!string.IsNullOrEmpty(this.mtxtAccountNo.Text) && this.cboReceiptNo.SelectedIndex == -1)
              //  {
               
              //      Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00022); //Invalid Receipt No.
              //      this.cboReceiptNo.Focus();
              //  //    this.cboReceiptNo.SelectedIndexChanged -= new EventHandler(cboReceiptNo_SelectedIndexChanged);

              //      return;
              //  }
                //else
                //{

                    if (this.AccuredStatus != "00" && this.MatureStatus == false && !string.IsNullOrEmpty(this.mtxtAccountNo.Text))
                    {
                        if (CXUIMessageUtilities.ShowMessageByCode("MC00109") == DialogResult.Yes)//No mature Pay interest.
                        {
                            this.Amount = this.Amount;
                            if (this.CurrencyCode == "KYT")
                            { this.AvailableInterestAfterTax = this.AvailableInterestAfterTax; }
                            else 
                            {
                                int availableInterest = Convert.ToInt32(this.AvailableInterestAfterTax);
                                this.AvailableInterestAfterTax = Convert.ToDecimal(availableInterest);
                            }
                            this.TotalAmount = this.Amount + this.AvailableInterestAfterTax;
                        }
                        else
                        {
                            this.Amount = this.Amount;
                            this.AvailableInterestAfterTax = 0;
                            this.TotalAmount = this.Amount + this.AvailableInterestAfterTax;
                        }
                    }
                    this.controller.SaveFixedDepositWithdraw();

          }
          this.Status = string.Empty;
            
            
             //this.cboReceiptNo.SelectedIndexChanged += new EventHandler(cboReceiptNo_SelectedIndexChanged);
        }

        private void cboReceiptNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            isSelected = true;
            //this.cboReceiptNo.SelectedIndexChanged -= new EventHandler(cboReceiptNo_SelectedIndexChanged);
            if (this.isSelected)
            {
                var receiptInfo = from value in this.receiptNoList
                                  where value.ReceiptNo == this.ReceiptNo
                                  select value;
                foreach (var item in receiptInfo)
                {

                    this.Amount = item.Amount;
                    this.Duration = item.Duration;
                    this.AccuredStatus = item.AccuredStatus;
                    this.LastIntDate = item.LastInterestDate.Value;
                    this.InterestRate = item.InterestRate;
                    this.CurrencyCode = item.CurrencyCode;

                }


                //this.Amount = receiptInfo.Amount;
                //this.Duration = receiptInfo.Duration;
                //this.AccuredStatus = receiptInfo.AccuredStatus;
                //this.LastIntDate = receiptInfo.LastInterestDate.Value;
                //this.InterestRate = receiptInfo.InterestRate;

                this.RegisterDate = CXCOM00006.Instance.GetDateFormat(this.LastIntDate).ToString();
                //return (duration < 12) ? duration.ToString().Replace(".00", " Months") : (duration / 12) > 1 ? ((duration / 12).ToString().Replace(".00", " Years")) : ((duration / 12).ToString().Replace(".00", " Year"));
                if (this.Duration < 1)
                {
                    if ((this.Duration * 4) > 1)
                    {
                        this.RegisterDuration = ((this.Duration * 4).ToString().Replace(".00", " Weeks"));
                    }
                    else
                    {
                        this.RegisterDuration = ((this.Duration * 4).ToString().Replace(".00", " Week"));
                    }

                }
                else if (this.Duration < 12)
                {
                    if (((this.Duration % 12) > 1))
                    {
                        this.RegisterDuration = ((this.Duration % 12).ToString().Replace(".00", " Months"));
                    }
                    else
                    {
                        this.RegisterDuration = ((this.Duration % 12).ToString().Replace(".00", " Month"));
                    }
                }

                else if ((this.Duration / 12) > 1)
                {
                    this.RegisterDuration = ((this.Duration / 12).ToString().Replace(".00", " Years"));
                }
                else
                {
                    this.RegisterDuration = ((this.Duration / 12).ToString().Replace(".00", " Year"));
                }

                this.controller.FixInterestCalculation();//call common module
                //this.AvailableInterestAfterTax = this.AvailableInterestAfterTax;
                if (this.CurrencyCode == "KYT")
                { this.AvailableInterestAfterTax = this.AvailableInterestAfterTax; }
                else
                {
                    int availableInterest = Convert.ToInt32(this.AvailableInterestAfterTax);
                    this.AvailableInterestAfterTax = Convert.ToDecimal(availableInterest);
                }
                this.TotalAmount = this.Amount + this.AvailableInterestAfterTax;
                this.CurrencyCode = this.CurrencyCode;
            }
            isSelected = true;
         
        }        

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
          //  this.cboReceiptNo.SelectedIndexChanged -= new EventHandler(cboReceiptNo_SelectedIndexChanged);
            this.controller.ClearErrors();
            this.controller.ClearControls();           
            this.gvCustomer.DataSource = null;
            this.pbPhoto.Image = null;
            this.pbSignature.Image = null;
            this.mtxtAccountNo.Focus();          
          //  this.cboReceiptNo.SelectedIndexChanged += new EventHandler(cboReceiptNo_SelectedIndexChanged);         
            this.DisableControls("FixedDepositWithdraw.Disable");
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
                        this.pbPhoto.Image = CXClientGlobal.GetImage(customerResult.CustPhoto.CustPhotos);
                    }
                    else
                    {
                        this.pbPhoto.Image = null;
                    }

                    if (customerResult.Signature != null)
                    {
                        this.pbSignature.Image = CXClientGlobal.GetImage(customerResult.Signature);
                    }
                    else
                    {
                        this.pbSignature.Image = null;
                    }
                }
            }
        }

     
       #endregion

    

     

        //private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        //{
        //    //  this.cboReceiptNo.SelectedIndexChanged -= new EventHandler(cboReceiptNo_SelectedIndexChanged);
        //    this.controller.ClearErrors();
        //    this.controller.ClearControls();
        //    this.gvCustomer.DataSource = null;
        //    this.pbPhoto.Image = null;
        //    this.pbSignature.Image = null;
        //    this.mtxtAccountNo.Focus();
        //    //  this.cboReceiptNo.SelectedIndexChanged += new EventHandler(cboReceiptNo_SelectedIndexChanged);         
        //    this.DisableControls("FixedDepositWithdraw.Disable");

        //}

        public void Select()
        {
            this.cboReceiptNo.SelectedIndex = -1;
        }

        
    }
}