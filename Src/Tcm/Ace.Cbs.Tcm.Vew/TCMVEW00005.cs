//----------------------------------------------------------------------
// <copyright file="TCMVEW00005.cs" company="Ace Data Systems">
// Copyright (c) Ace Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>AK</CreatedUser>
// <CreatedDate></CreatedDate>
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
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Cx.Com.Utt;
using System.Windows.Forms;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Tcm.Vew
{
    public partial class TCMVEW00005 : BaseForm , ITCMVEW00005
    {
        #region Constructor

        public TCMVEW00005()
        {
            InitializeComponent();
        }

        #endregion

        #region View Data Properties

        /// <summary>
        /// Account No
        /// </summary>
        public string AccountNo
        {
            get
            {
                return this.mtxtAccountNo.Text.Replace("-","").Trim();
            }

            set
            {
                this.mtxtAccountNo.Text = value;
            }
        }

        /// <summary>
        /// Amount
        /// </summary>
        public decimal Amount
        {
            get
            {
                return Convert.ToDecimal(this.txtAmount.Text);
            }

            set
            {
                this.txtAmount.Text = value.ToString();
            }
        }

        public string SourceBranchCode { get; set; }

        public string FormCaption
        {
            get 
            {
                return this.FormName;
            }
        }

        #endregion

        #region Presenter

        private ITCMCTL00005 controller;
        public ITCMCTL00005 Controller
        {
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
            get
            {
                return this.controller;
            }
        }

        #endregion

        #region Entity

        private PFMDTO00016 entity;
        public PFMDTO00016 Entity
        {
            get
            {
                if (this.entity == null) this.entity = new PFMDTO00016();
                this.entity.AccountNo = this.AccountNo;
                this.entity.AccruedInterest = this.Amount;
                
                return this.entity;
            }

            set { this.entity = value; }
        }

        #endregion

        #region Methods

        public void InitializedControls()
        {
            this.Text = this.FormName;
            this.SourceBranchCode = CXCOM00007.Instance.BranchCode;
            this.AccountNo = string.Empty;
            this.Amount = 0;
            this.mtxtAccountNo.Focus();
        }

        #endregion

        #region Events

        private void TCMVEW00005_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
                e.Handled = true;
            }            
        }

        private void TCMVEW00005_Load(object sender, EventArgs e)
        {
            this.InitializedControls();
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializedControls();
            this.Controller.ClearErrors();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            if (this.Controller.Save(this.Entity))
            {
                if (CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC00002) == DialogResult.Yes)
                    this.Controller.PRN_FilePrinting(this.AccountNo);
                this.InitializedControls();
            }
        }

        #endregion

      

    }
}
