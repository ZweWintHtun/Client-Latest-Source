//----------------------------------------------------------------------
// <copyright file="MNMVEW00002.cs" company="ACE Data Systems">
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
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Admin.DataModel;
using System.Globalization;
using Ace.Cbs.Mnm.Ctr.Ptr;


namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00002 : BaseForm,IMNMVEW00002
    {
        public MNMVEW00002()
        {
            InitializeComponent();
        }


        #region controller
        IMNMCTL00002 controller;
        public IMNMCTL00002 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                controller.MonthAfterViewData = this;
            }
        }
        #endregion

        #region Properties
        public bool butProcess_Enable
        {
            get { return this.lblProcess.Enabled; }
            set { this.lblProcess.Enabled = value; }
        }

  
        //private DateTime currentDate = DateTime.Now;
        private DateTime currentDate;
        
        public DateTime Date_time
        {   
            get
            {
                //return this.currentDate;
                this.currentDate = this.controller.GetSystemDate(CurrentUserEntity.BranchCode);
                return this.currentDate;
            }
            set
            {
                this.currentDate = value;
            }
        }
        public int ProgressBar
        {
            get { return pgbAfterDayClose.Value; }
            set { this.pgbAfterDayClose.Value = value; }
        }
        public bool Progressstatus
        {
            get { return pgbAfterDayClose.Visible; }
            set { this.pgbAfterDayClose.Visible = value; }
        }
        public ProgressBarStyle ProgressBarStyle
        {
            set { this.pgbAfterDayClose.Style = value; }
        }

        #endregion

        #region method

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);

        }

        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        #endregion

        #region Event 

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void lblProcessingYear_Click(object sender, EventArgs e)
        {

        }

        private void MNMVEW00002_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
            /*
            lblProcessYear.Text = DateTime.Now.ToString("yyyy");
            lblProcessMonth.Text = DateTime.Now.ToString("MMMM");
             */

            #region Seperating_EOD_Logic (Added by HMW at 16-10-2019)
            DateTime systemDate = this.controller.GetSystemDate(CurrentUserEntity.BranchCode);
            this.lblProcessMonth.Text = systemDate.ToString("MMMM");
            this.lblProcessYear.Text = systemDate.Year.ToString();
            #endregion

            this.Controller.CheckClosing();
        }

        private void lblProcess_Click(object sender, EventArgs e)
        {

            string budget = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.UIDateFormat);
        }

        private void lblProcess_Click_1(object sender, EventArgs e)
        {
            this.pgbAfterDayClose.Style = ProgressBarStyle.Marquee;
            this.controller.MonthAfter();            
        }


        #endregion

        private void cxC00071_Click(object sender, EventArgs e)
        {

        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MNMVEW00002_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }
    }
}
