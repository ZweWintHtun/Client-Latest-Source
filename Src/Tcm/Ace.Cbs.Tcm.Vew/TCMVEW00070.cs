//----------------------------------------------------------------------
// <copyright file="TCMVEW00070.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2014-08-01</CreatedDate>
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
using System.Windows.Forms;
using Ace.Windows.CXClient;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient.Controls;

namespace Ace.Cbs.Tcm.Vew
{
    /*Gift Cheque Issued By Transfer ( Income ) Entry*/
    /*Gift Cheque Issued By Transfer ( No Income ) Entry*/
    public partial class TCMVEW00070 : BaseDockingForm, ITCMVEW00070
    {
        #region Constructor
        public TCMVEW00070()
        {
            InitializeComponent();
        }
        #endregion

        #region Controller
        private ITCMCTL00070 controller;
        public ITCMCTL00070 Controller //Gift Cheque Issued By Transfer Controller
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

        #region Controls' Inputs and Outputs
        public string AccountNo
        {
            get { return this.mtxtAccountNo.Text.Trim(); }
            set { this.mtxtAccountNo.Text = value; }
        }
        public string FromName
        {
            get { return this.txtFromName.Text.Trim(); }
            set { this.txtFromName.Text = value; }
        }
        public string ToName
        {
            get { return this.txtToName.Text.Trim(); }
            set { this.txtToName.Text = value; }
        }
        public string GiftChequeNo
        {
            get { return this.txtGiftChequeNo.Text.Trim(); }
            set { this.txtGiftChequeNo.Text = value; }
        }
        public string ChequeNo
        {
            get { return this.txtGiftChequeNo.Text.Trim(); }
            set { this.txtGiftChequeNo.Text = value; }
        }
        public decimal Amount
        {
            get
            {
                if (this.txtAmount.Text == string.Empty || this.txtAmount.Text == null)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToDecimal(this.txtAmount.Text.Trim());
                }
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
        public TLMDTO00059 GiftChequeDTO { get; set; }
        public bool isWithIncome { get; set; }
        #endregion

        #region Methods
        public void InitalizeControls()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            this.chkVIP.Focus();
            this.chkVIP.Checked = false;
            this.mtxtAccountNo.Clear();
            this.txtFromName.Clear();
            this.txtToName.Clear();
            this.txtAmount.Text = "0.00";
            this.txtCharges.Text = "0.00";
            this.txtGiftChequeNo.Clear();
            this.txtToal.Text = "0.00";
            this.txtChequeNo.Clear();
            this.gvGiftChequeIssueTransfer.DataSource = null;
            this.txtChequeNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ChequeNoMaximumValue);
        }
        public void DisableChequeNo()
        {
            this.txtChequeNo.Enabled = false;
        }
        #endregion

        private void TCMVEW00070_Load(object sender, EventArgs e)
        {
            this.InitalizeControls();
            if (this.FormName.Equals("GCIssueByTransferIncome"))
            {
                this.Text = "Gift Cheque Issue By Transfer With Income";
                this.Texts = this.Text;
                this.isWithIncome = true;
            }
            else
            {
                this.Text = "Gift Cheque Issue By Transfer With No Income";
                this.Texts = this.Text;
                this.txtCharges.Enabled = false;
                this.isWithIncome = false;
            }
        }

    }
}
