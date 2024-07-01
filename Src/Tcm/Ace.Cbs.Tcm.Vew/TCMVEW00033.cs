//----------------------------------------------------------------------
// <copyright file="TCMVEW00033.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
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
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Tcm.Ctr.Ptr;

namespace Ace.Cbs.Tcm.Vew
{
    public partial class TCMVEW00033 : BaseForm,ITCMVEW00033
    {
        #region Constructor
        public TCMVEW00033()
        {
            InitializeComponent();
        }
        #endregion

        #region Controller
        private ITCMCTL00033 controller;
        public ITCMCTL00033 Controller
        {
            get
            {
                { return this.controller; }
            }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }
        #endregion

        #region Controls Input Output

        public string FormName { get; set; }
        public DateTime StartDate
        {
            get
            {
                return Convert.ToDateTime(dtpStartDate.Text);
            }
            set
            {
                this.dtpStartDate.Value = value;
            }
        }
        public DateTime EndDate
        {
            get
            {
                return Convert.ToDateTime(this.dtpEndDate.Text);
            }
            set
            {
                this.dtpEndDate.Value = value;
            }
        }
      
        #endregion

        #region Method
        private void InitializeControls()
        {
            this.dtpStartDate.Text = DateTime.Now.ToShortDateString();
            this.dtpEndDate.Text = DateTime.Now.ToShortDateString();
            this.dtpStartDate.Focus();
        }       
        #endregion
       
        #region Event
        private void TCMVEW00033_Load(object sender, EventArgs e)
        {
            if (this.FormName == "NotYetPosted")
            {
                this.Text = "Delivered Cheque Listing(Not Yet Posted)";

            }
            else
            {
                this.Text = "Delivered Cheque Listing(Posted)";
            }

            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);     
            this.InitializeControls();
        }
       
        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            if (this.controller.CheckDate())
            {
                if (this.FormName == "NotYetPosted")
                {
                    this.controller.DeliveredChequeNotYetPosted();

                }
                else
                {
                    this.controller.DeliveredChequePosted();
                }
            }
        }
        #endregion

       
    }
}
