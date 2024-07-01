//----------------------------------------------------------------------
// <copyright file="TCMVEW00011.cs" company="Ace Data Systems">
// Copyright (c) Ace Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Khaing Su Wai</CreatedUser>
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
using Ace.Cbs.Cx.Com.Utt;
using System.Windows.Forms;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Pfm.Dmd;


namespace Ace.Cbs.Tcm.Vew
{
    public partial class TCMVEW00011 : BaseDockingForm , ITCMVEW00011
    {
        #region Constructor
        public TCMVEW00011()
        {
            InitializeComponent();
        }
        #endregion
        
        #region Controller
        private ITCMCTL00011 controller;
        public ITCMCTL00011 Controller
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

        #region
        public string EntryNo
        {
            get
            {
                return this.txtEntryNo.Text;

            }
            set
            {
                txtEntryNo.Text = value;
            }
        }
        public string Type
        {
            get
            {
                return this.txtType.Text;
            }
            set
            {
                txtType.Text = value;
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
            set
            {
                this.txtAmount.Text = value.ToString();
            }
        }
        public string UserNo
        {
            get 
            {
                return this.txtUserNo.Text;
            }
            set
            {
                txtUserNo.Text = value;
            }
        }
        public string CounterNo
        {
            get
            {
                return this.txtCounterNo.Text;
            }
            set
            {
                txtCounterNo.Text = value;
            }
        }
        //public string SourceBranchCode
        //{
        //    get
        //    {
        //        CurrentUserEntity.BranchCode = value;
        //    }
        //}
        //string SoucreBranchCode = CurrentUserEntity.BranchCode;

        #endregion
        public void Successful(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
           
            this.ClearControls();
           
        }
        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }
        public void ClearControls()
        {
            this.txtAmount.Text = string.Empty;
            this.txtCounterNo.Text = string.Empty;
            this.txtEntryNo.Text = string.Empty;
            this.txtType.Text = string.Empty;
            this.txtUserNo.Text = string.Empty;
           
        }
      
        private void TCMVEW00011_Load(object sender, EventArgs e)
        {
            tsbCRUD.ButtonEnableDisabled(false, false, false, true, true, false, true);
            this.txtEntryNo.Focus();
            this.InitializeControl();
           
        }
        public void InitializeControl()
        {
            this.txtEntryNo.Focus();
            this.txtEntryNo.Enabled = true;
            this.txtAmount.Enabled = false;
            this.txtCounterNo.Enabled = false;
            this.txtType.Enabled = false;
            this.txtUserNo.Enabled = false;
            
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.txtAmount.Text = "";
            this.txtCounterNo.Text = "";
            this.txtEntryNo.Text = "";
            this.txtType.Text = "";
            this.txtUserNo.Text = "";
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.Controller.Save();
        }
    }
}
