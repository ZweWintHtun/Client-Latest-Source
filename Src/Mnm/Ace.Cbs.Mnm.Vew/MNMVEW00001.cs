//----------------------------------------------------------------------
// <copyright file="MNMVEW00001.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>12/02/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00001 : BaseForm,IMNMVEW00001
    {
        #region controller
        IMNMCTL00001 controller;
        public IMNMCTL00001 Controller
        {
            get { return this.controller; }
            set { this.controller = value; this.controller.View = this; }
        }
        #endregion

        #region properties
        public bool butProcess_Enable
        {
            get { return this.btnProcess.Enabled; }
            set { this.btnProcess.Enabled = value; }
        }

        public int ProgressBar
        {
            get { return this.pgbBeforeDayClose.Value; }
            set { this.pgbBeforeDayClose.Value = value; }
        }

        public bool ProgressBar2Visible
        {
            set { this.pgbBeforeDayClose2.Visible = value; }
        }

        public ProgressBarStyle ProgressBar2Style
        {
            set { this.pgbBeforeDayClose2.Style = value; }
        }

        public ProgressBarStyle ProgressBarStyle
        {
            set { this.pgbBeforeDayClose.Style = value; }
        }

        public Timer TimerProgress
        {
            get { return this.tmrProgress; }
        }

        public Timer TimerProgress2
        {
            get { return this.tmrProgress2; }
        }
        #endregion

        public MNMVEW00001()
        {
            InitializeComponent();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            this.Controller.Posting();
        }

        private void MNMVEW00001_Load(object sender, EventArgs e)
        {
            
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
            //this.lblProcessMonth.Text = DateTime.Now.ToString("MMMM");
            //this.lblProcessYear.Text = DateTime.Now.Year.ToString();

            #region Seperating_EOD_Logic (Added by HMW at 16-10-2019)
            DateTime systemDate = this.controller.GetSystemDate(CurrentUserEntity.BranchCode);
            this.lblProcessMonth.Text = systemDate.ToString("MMMM");
            this.lblProcessYear.Text = systemDate.Year.ToString();
            #endregion

            this.Controller.CheckClosing();

            
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tmrProgress_Tick(object sender, EventArgs e)
        {
            if (this.pgbBeforeDayClose.Value < 100)
            {
                this.pgbBeforeDayClose.Value += 2;

                if (this.pgbBeforeDayClose.Value == 22)
                {
                    this.tmrProgress.Stop();
                    this.Controller.Show_Loans_Posting_Message();
                }
            
                else if (this.pgbBeforeDayClose.Value == 42)
                {
                    this.tmrProgress.Stop();
                    this.Controller.Show_OverDraft_Posting_Message();
                }
            
                else if (this.pgbBeforeDayClose.Value == 62)
                {
                    this.tmrProgress.Stop();
                    this.controller.Show_CommitFee_Posting_Message();
                }
            
                else if (this.pgbBeforeDayClose.Value == 82)
                {
                    this.tmrProgress.Stop();
                    this.Controller.Show_Saving_Posting_Message();
                }
            }
            else if (this.pgbBeforeDayClose.Value == 100)
            {
                this.tmrProgress.Stop();
                this.Controller.Show_Fixed_Posting_Message();
                this.tmrProgress2.Stop();
                this.Controller.Successful_Message();
                this.pgbBeforeDayClose.Visible = false;
                this.pgbBeforeDayClose.Value = 0;
            }
            
          
       }

        private void MNMVEW00001_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }
    }
}
