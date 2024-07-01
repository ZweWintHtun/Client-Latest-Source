//----------------------------------------------------------------------
// <copyright file="TLMVEW00020.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Ye Man Aung</CreatedUser>
// <CreatedDate>2013-06-07</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//---------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;

namespace Ace.Cbs.Tel.Vew
{
    /// <summary>
    /// Entry ->Remittance Voucher -> Encash Remittance
    /// </summary>
    public partial class TLMVEW00020 : BaseForm , ITLMVEW00020
    {
        #region "Constructor"
        public TLMVEW00020()
        {
            InitializeComponent();
        }
        #endregion

        #region "Controls Input Output"

        private ITLMCTL00020 controller;
        public ITLMCTL00020 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                controller.View = this;
            }
        }

        public string TransactionStatus
        {
            get { return this.Name; }
        }

        public string AccountNo { get; set; }

        public string RegisterNo
        {
            get
            {
                if (this.cboRegisterNo.SelectedValue == null)
                {
                    return string.Empty;
                }
                else
                {
                    return this.cboRegisterNo.SelectedValue.ToString();
                }
            }
            set
            {
                this.cboRegisterNo.SelectedValue = value;
            }
        }

        public string EBank { get; set; }

        public string EncashAccount { get; set; }

        public string Description { get; set; }

        public string Currency { get; set; }

        public decimal Amount { get; set; }

        public string ToAccountNo { get; set; }

        public string ToName { get; set; }

        public string AccountSign { get; set; }

        public string Parameter { get; set; } 

        public IList<TLMDTO00050> tempEncashList { get; set; }

        public IList<TLMDTO00001> TempEncashList { get; set; }

        public string _Name
        {
            get { return this.Name; }
            set { this.Name = value; }
        }

        #endregion
        
        #region Method 

        public void BindRegisterNoBoxes() //To Bind RegisterNo to cboRegisterNo
        {
            cboRegisterNo.DisplayMember = "RegisterNo";
            cboRegisterNo.ValueMember = "RegisterNo";
            cboRegisterNo.DataSource = this.TempEncashList;
            cboRegisterNo.SelectedIndex = -1;
            if (cboRegisterNo.Items.Count.Equals(0))
            {

               // CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00167);

                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00055);

                cboRegisterNo.Enabled = false;
            }
        }

        private void GetGridData() //Bind Data to Grid
        {
                if (this.TempEncashList != null)
                {
                    
                    tempEncashList = new List<TLMDTO00050>();
                    tempEncashList = Controller.GetGridData(TempEncashList);

                    this.BindGridView(tempEncashList);
                }
        }

        public void BindGridView(IList<TLMDTO00050> list)
        {
            gvEncashment.DataSource = null;
            gvEncashment.AutoGenerateColumns = false;
            gvEncashment.DataSource = list;
        }

        //private void CleanForm()
        //{
        //    this.TempEncashList = this.Controller.GetEncashData();
        //    this.BindRegisterNoBoxes();
        //    cboRegisterNo.Focus();
        //    tempEncashList = new List<TLMDTO00050>();
        //    this.BindGridView(tempEncashList);
        //}

        #endregion

        #region Events
        private void TLMVEW00020_Load(object sender, EventArgs e)
        {
            //this.tsbCRUD.ButtonEnableDisabled(firstButtonEnabled, previousButtonEnabled, nextButtonEnabled, lastButtonEnabled, newButtonEnabled, editButtonEnabled, saveButtonEnabled, deleteButtonEnabled, cancelButtonEnabled, printButtonEnabled, exitButtonEnabled);
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            //  txtDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");

            if (this.FormName.Equals("IsCashType"))
                this.Parameter = "C";
            else
                this.Parameter = "T";

            this.TempEncashList = this.Controller.GetEncashData();
            this.BindRegisterNoBoxes();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboRegisterNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (RegisterNo.Trim() == string.Empty)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00168);
                cboRegisterNo.Focus();
                return;
            }
            else
            {
                this.GetGridData();
            }
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            if (gvEncashment.RowCount <= 0)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00171);
                cboRegisterNo.Focus();
                return;
            }
            else
            {
                this.Controller.Save();
                Controller.ClearForm();
                cboRegisterNo.Focus();
            }
        }

        public void Successful(string message , string voucherNo)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message, new object[] { "VoucherNo", voucherNo });
        }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            Controller.ClearForm();
            cboRegisterNo.Focus();
        }

        #endregion

        private void TLMVEW00020_Move(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

    }
}
