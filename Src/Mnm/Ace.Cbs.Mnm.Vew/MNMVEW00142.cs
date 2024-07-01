//----------------------------------------------------------------------
// <copyright file="Fixed year end interest calculation" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KSW</CreatedUser>
// <CreatedDate>2014/07/15</CreatedDate>
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

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00142 : BaseForm, IMNMVEW00142
    {
        #region Properties

        public  Nullable<DateTime> date
        {
            get { return DateTime.Now; }
            
        }

        public int Progress
        {
            get { return this.pgbInterestCalculation.Value; }
            set { this.pgbInterestCalculation.Value = value; }
        }

        bool isSuccessful = false;
        public bool IsSuccessful
        {
            get { return this.isSuccessful; }
            set { this.isSuccessful = value; }
        }

        public Timer TimerProgress
        {
            get { return this.tmrProgress; }
        }

        public ProgressBarStyle ProgressBarStyle
        {
            set { this.pgbInterestCalculation.Style = value; }
        }

        private string formName = string.Empty;
        public string FormName
        {
            get { return this.formName; }
            set { this.formName = value; }
        }

        #endregion

        #region Controller

        private IMNMCTL00142 controller;
        public IMNMCTL00142 Controller
        {
            get { return this.controller; }
            set
            {
                this.controller = value;
                this.controller.ViewData = this;
            }
        }

        #endregion

        #region Event 

        public MNMVEW00142()
        {
            InitializeComponent();
        }

        private void MNMVEW00142_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
            this.lblProcessDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.Text = this.FormName + " Entry";
            if (DateTime.Now.Month.ToString()=="3")
            {            
                this.lblProcessYear.Text = "03/" + DateTime.Now.Year.ToString();
            }
            //else if (DateTime.Now.Month.ToString() == "9")
            //{
            //    this.lblProcessYear.Text = "09/" + DateTime.Now.Year.ToString();
            //}
            //else
            //{
            //    this.lblProcessYear.Text ="Not Fixed Year End";
            //}
            this.lblProcessYear.Text = "";
        }
        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tmrProgress_Tick(object sender, EventArgs e)
        {
            this.pgbInterestCalculation.Visible = true;

            if (this.pgbInterestCalculation.Value < 100)
            {
                this.pgbInterestCalculation.Value = this.pgbInterestCalculation.Value + 2;
            }
            if (this.pgbInterestCalculation.Value == 50)
            {
                this.Timer_Control();
            }
            if (this.pgbInterestCalculation.Value == 100)
            {
                this.tmrProgress.Stop();
                this.pgbInterestCalculation.Enabled = true;
                this.pgbInterestCalculation.Visible = false;
                this.pgbInterestCalculation.Value = 0;
            }
        }

        public void Timer_Control()
        {
            if (!IsSuccessful)
            {
                this.tmrProgress.Stop();
                this.pgbInterestCalculation.Value = 0;
                this.pgbInterestCalculation.Visible = false;
            }
        }
        

        private void btnProcess_Click(object sender, EventArgs e)
        {
            Controller.ProcessInterest(this.FormName);
        }

        #endregion

        private void MNMVEW00142_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }
    }
}
