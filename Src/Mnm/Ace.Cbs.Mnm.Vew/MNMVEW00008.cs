//----------------------------------------------------------------------
// <copyright file="MNMVEW00008.cs" company="ACE Data Systems">
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
using Ace.Cbs.Cx.Com.Utt;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00008 : BaseForm, IMNMVEW00008
    {
        #region "Constructor"

        public MNMVEW00008()
        {
            InitializeComponent();
        }

        #endregion "Constructor"

        #region "Controller"

        private IMNMCTL00008 controller;
        public IMNMCTL00008 Controller
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

        #region "Controls Input Output"

        private string narration = string.Empty;
        private string entryNo = string.Empty;

        public string EntryNo
        {
            get { return this.mtxtEntryNo.Text; }
            set { this.mtxtEntryNo.Text = value; }
        }

        public string Narration
        {
            get { return this.txtNarration.Text; }
            set { this.txtNarration.Text = value; }
        }

        IList<string> cashInfo = new List<string>();
        public IList<string> CashInfo
        {
            get { return this.cashInfo; }
            set { this.cashInfo = value; }
        }
        public string Status { get; set; }


        #endregion "Controls Input Output"

        #region "Entity"

        private PFMDTO00054 viewEntity;
        public PFMDTO00054 ViewEntity
        {
            get 
            {
                if (viewEntity == null)
                    return new PFMDTO00054();
                else
                    return viewEntity;
            }
            set 
            {
                viewEntity = value;
                viewEntity.Eno = this.EntryNo;
                viewEntity.Narration = this.Narration;
            }
        }

        #endregion

        #region "Events"

        private void MNMVEW00008_Load(object sender, System.EventArgs e)
        {
            #region Old_Logic
            /*
            //ButtonEnableDisabled(newButtonEnabled, editButtonEnabled, saveButtonEnabled, deleteButtonEnabled,cancelButtonEnabled, printButtonEnabled, exitButtonEnabled);
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, false, true);
            this.mtxtEntryNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.VoucherNoFormat);
            this.txtNarration.Enabled = false;
            this.gvCashVoucher.Enabled = false;
            */
            #endregion

            DateTime systemDate = this.Controller.GetSystemDate(CurrentUserEntity.BranchCode);
            DateTime lastSettlementDate = this.controller.GetLastSettlementDate(CurrentUserEntity.BranchCode);

            this.lblTransactionDate.Text = systemDate.ToString("dd-MM-yyyy");

            if (systemDate.ToString("dd-MM-yyyy") != lastSettlementDate.ToString("dd-MM-yyyy")) //Show Form
            {
                this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, false, true);
                this.mtxtEntryNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.VoucherNoFormat);
                this.txtNarration.Enabled = false;
                this.gvCashVoucher.Enabled = false;
            }
            else //Don't show the form after cut off
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI50013);//You have no permission.\n"Back Date EOD Process" needs to be completed!
                this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
                //this.InitializeControls();
                this.DisableControls("CashVoucherReverse.AllDisable");
            }
        }  
           
        private void tsbCRUD_CancelButtonClick(object sender, System.EventArgs e)
        {
            this.Controller.ClearControls();
            this.gvCashVoucher.DataSource = null;
            this.mtxtEntryNo.Enabled = true;
            this.mtxtEntryNo.Focus();
        }

        private void tsbCRUD_ExitButtonClick(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_SaveButtonClick(object sender, System.EventArgs e)
        {
            this.Status = "Save";
            this.Controller.Save();
        }

        private void MNMVEW00008_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

        #endregion " Events "

        #region "Method"

        private void FormName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        public void BindCashVoucherGrid(IList<PFMDTO00054> cashVoucherlist)
        {
            gvCashVoucher.DataSource = null;
            gvCashVoucher.AutoGenerateColumns = false;
            gvCashVoucher.DataSource = cashVoucherlist;
        }

        public void EnableDisable(bool flag,bool isSave)
        {
            //ButtonEnableDisabled(newButtonEnabled, editButtonEnabled, saveButtonEnabled, deleteButtonEnabled,cancelButtonEnabled, printButtonEnabled, exitButtonEnabled);
            if(isSave)this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            else this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, false, true);
            this.txtNarration.Enabled = flag;
            this.mtxtEntryNo.Enabled = flag;
            this.mtxtEntryNo.Focus();
        }

        public void Successful(string message, string accountCode)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message, new object[] { accountCode });
            this.gvCashVoucher.DataSource = null;
        }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }

        #endregion

        
    }
}
