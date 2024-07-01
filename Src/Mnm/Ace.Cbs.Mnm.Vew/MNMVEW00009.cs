//----------------------------------------------------------------------
// <copyright file="MNMVEW00009.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>11/04/2013</CreatedDate>
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
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00009 : BaseForm, IMNMVEW00009
    {
        public MNMVEW00009()
        {
            InitializeComponent();
        }

        public IList<PFMDTO00054> tlfData;
        public IList<PFMDTO00054> gridData { get; set; }
        private string eno;
        public string Eno
        {
            get { return this.txtEntryNo.Text; }
            set { this.txtEntryNo.Text = value; }
        }

        private string narration;
        public string Narration
        {
            get { return this.txtNarration.Text; }
            set { this.txtNarration.Text = value; }
        }

        public string Status { get; set; }


        private IMNMCTL00009 clrVoucherReversalcontroller;
        public IMNMCTL00009 Controller
        {
            get { return this.clrVoucherReversalcontroller; }
            set
            {
                this.clrVoucherReversalcontroller = value;
                this.clrVoucherReversalcontroller.View = this;
            }
        }

        public void FillData(IList<PFMDTO00054> tlfEntity)
        {
             gridData = tlfEntity;
            for (int i = 0; i < gridData.Count; i++)
            {
                if (gridData[i].TransactionCode == "CLRDR")
                    gridData[i].TransactionCode = "Debit";
                else if (gridData[i].TransactionCode == "CLRCR")
                    gridData[i].TransactionCode = "Credit";
            }
            this.gvClearingVoucher.DataSource = null;
            this.gvClearingVoucher.AutoGenerateColumns = false;
            this.gvClearingVoucher.DataSource = gridData;
            this.Narration = gridData[0].Narration;
        }

        private void FormName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void MNMVEW00009_Load(object sender, EventArgs e)
        {
            #region Old_Logic
            /*
            this.gvClearingVoucher.AutoGenerateColumns = false;
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            this.txtEntryNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.VoucherNoFormat);
            this.lblNarration.Visible = false;
            this.txtNarration.Visible = false;
            */
            #endregion


            DateTime systemDate = this.Controller.GetSystemDate(CurrentUserEntity.BranchCode);
            DateTime lastSettlementDate = this.Controller.GetLastSettlementDate(CurrentUserEntity.BranchCode);
            this.lblTransactionDate.Text = systemDate.ToString("dd-MM-yyyy");

            if (systemDate.ToString("dd-MM-yyyy") != lastSettlementDate.ToString("dd-MM-yyyy")) //Show Form
            {
                this.gvClearingVoucher.AutoGenerateColumns = false;
                this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
                this.txtEntryNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.VoucherNoFormat);
                this.lblNarration.Visible = false;
                this.txtNarration.Visible = false;
            }
            else //Don't show form after cut off
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI50013);//You have no permission.\n"Back Date EOD Process" needs to be completed!
                this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
                //this.InitializeControls();
                this.DisableControls("ClearingVoucher.AllDisable");
            }

        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.Controller.ClearControls();
            this.gvClearingVoucher.DataSource = null;
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            // Reverse Process to controller
            this.Status = "Save";
            this.Controller.Reverse();
        }

        public void Successful(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
            this.gvClearingVoucher.DataSource = null;
        }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }

        private void MNMVEW00009_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }
    }
}
