//----------------------------------------------------------------------
// <copyright file="TLMVEW00076.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2014-07-21</CreatedDate>
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
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Tel.Vew
{
    /*Drawing Cash Deposit Denomination Entry*/
    public partial class TLMVEW00076 : BaseDockingForm,ITLMVEW00076
    {
        #region "Constructor"
        public TLMVEW00076()
        {
            InitializeComponent();
        }
        #endregion

        #region "Control Input Outputs"
        public string RegisterNo
        {
            get { return this.txtGroupNo.Text.Trim(); }
            set { this.txtGroupNo.Text = value; }
        }
        public string Currency 
        {
            get { return this.txtCurrency.Text.Trim(); }
            set { this.txtCurrency.Text = value; }
        }
        public decimal Amount
        {
            get { return Convert.ToDecimal(this.txtTotalAmount.Value); }
            set { this.txtTotalAmount.Text = value.ToString(); }
        }
        private IList<TLMDTO00017> drawingCashDepositDenominationDataSource;
        public IList<TLMDTO00017> DrawingCashDepositDenominationDataSource
        {
            get
            {
                if (this.drawingCashDepositDenominationDataSource == null)
                    this.drawingCashDepositDenominationDataSource = new List<TLMDTO00017>();

                return this.drawingCashDepositDenominationDataSource;
            }
            set
            {
                this.drawingCashDepositDenominationDataSource = value;
            }
        }
        #endregion

        #region "Controller"
        private ITLMCTL00076 controller;
        public ITLMCTL00076 Controller
        {
            get { return this.controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }
        public IList<TLMDTO00017> RD { get; set; }
        #endregion

        #region "Methods"
        public void InitializeControls()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            this.txtGroupNo.Clear();
            this.txtGroupNo.Focus();
            this.txtCurrency.Clear();
            this.txtTotalAmount.Clear();
            this.gvDrawingCashDepositDenomination.DataSource = null;
            this.gvDrawingCashDepositDenomination.AutoGenerateColumns = false;
        }
        public void BindGridView()
        {
            IList<TLMDTO00017> RDList = this.DrawingCashDepositDenominationDataSource;
            this.gvDrawingCashDepositDenomination.DataSource = RDList;
        
        
           // return RDList;
        }
        public void Successful(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message, new object[] { string.Empty });
            this.InitializeControls();
        }
        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
            this.InitializeControls();
        }
        public void RegisterNoSetFocus()
        {
            this.txtGroupNo.Focus();
        }
        #endregion

        #region "Events"
        private void TLMVEW00076_Load(object sender, EventArgs e)
        {
            this.InitializeControls();
        }
        #endregion

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.controller.Save();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.controller.ClearErrors();

            //this.txtGroupNo_Leave() -= new System.EventHandler(this.txtGroupNo_Leave);
          // txtGroupNo_Leave -= new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.InitializeControls();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.controller.ClearErrors();
            this.Close();
        }

        private void txtGroupNo_Leave(object sender, EventArgs e)
        {
            //if (this.txtGroupNo.Text != string.Empty && this.txtGroupNo.Text != null)
            //{
            //    IList<TLMDTO00017> RDList = new List<TLMDTO00017>();
            //    RDList = this.controller.GetDrawingCashDepoDenoList(this.txtGroupNo.Text);
            //    if (RDList.Count == 0 || CXClientWrapper.Instance.ServiceResult.ErrorOccurred == true)
            //    {
            //        //this.SetCustomErrorMessage(this.GetControl("txtGroupNo"), CXClientWrapper.Instance.ServiceResult.MessageCode); //MV00168 Invalid Drawing Registerno.
            //        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00168", new object[] { string.Empty });
            //        return;
            //    }
            //    else
            //    {
            //        this.txtCurrency.Text = RDList[0].Currency;
            //        this.txtTotalAmount.Text = RDList[0].Amount.Value.ToString();
            //        this.DrawingCashDepositDenominationDataSource = RDList;
            //        this.gvDrawingCashDepositDenomination.DataSource = this.DrawingCashDepositDenominationDataSource;
            //    }
            //}
            //else
            //{
            //    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00168", new object[] { string.Empty });
            //    return;
            //}
        }

        public void ClearControls()
        {
                        
            this.txtCurrency.Clear();
            this.txtTotalAmount.Clear();
            this.gvDrawingCashDepositDenomination.DataSource = null;
            this.gvDrawingCashDepositDenomination.AutoGenerateColumns = false;
        }

        private void txtGroupNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }
    }
}
