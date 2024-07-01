//----------------------------------------------------------------------
// <copyright file="MNMVEW00003.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>11/14/2013</CreatedDate>
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
    public partial class MNMVEW00003 : BaseForm, IMNMVEW00003
    {
        struct month
        {
            public string text { get; set; }
            public int value { get; set; }
        }

        public MNMVEW00003()
        {
            InitializeComponent();
        }

        #region Controller

        private IMNMCTL00003 controller;
        public IMNMCTL00003 Controller
        {
            get { return this.controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }

        #endregion

        #region Properties

        public string MonthText
        {
            get { return this.cboRequiredMonth.SelectedText; }
            set { this.cboRequiredMonth.SelectedText = value; }
        }

        public int MonthValue
        {
            get { return this.cboRequiredMonth.SelectedValue == null ? 0 : Convert.ToInt32(this.cboRequiredMonth.SelectedValue.ToString()); }
            set { this.cboRequiredMonth.SelectedValue = value; }
        }

        public int Year
        {
            get { return this.txtRequiredYear.Text == string.Empty ? 0 : Convert.ToInt32(this.txtRequiredYear.Text); }
            set { this.txtRequiredYear.Text = value.ToString(); }
        }

        public int Progress
        {
            get { return this.pgbSavingInterest.Value; }
            set { this.pgbSavingInterest.Value = value; }
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
            set { this.pgbSavingInterest.Style = value; }
        }

        public Ace.Windows.CXClient.Controls.CXC0007 ButCalculate
        {
            get { return this.btnCalculate; }
            set { this.btnCalculate = value; }
        }

        #endregion

        #region Events

        private void MNMVEW00003_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, false, true);
            this.BindMonth();
            this.InitializeControls();
            this.pgbSavingInterest.Visible = false;
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            this.Controller.CalculateInterest(this.MonthValue, this.Year);
        }

        private void tmrProgress_Tick(object sender, EventArgs e)
        {
            this.pgbSavingInterest.Visible = true;

            if (this.pgbSavingInterest.Value < 100)
            {
                this.pgbSavingInterest.Value = this.pgbSavingInterest.Value + 2;
            }
            if (this.pgbSavingInterest.Value == 50)
            {
                this.Timer_Control();
            }
            if (this.pgbSavingInterest.Value == 100)
            {
                this.tmrProgress.Stop();
                this.Controller.Show_Message("MI30005");    //Saving Interest Successful
                this.btnCalculate.Enabled = true;
                this.pgbSavingInterest.Visible = false;
                this.pgbSavingInterest.Value = 0;
            }
        }

        #endregion

        #region Methods

        private void BindMonth()
        {
            string[] monthText = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            IList<month> monthList = new List<month>();

            for (int i = 0; i < 12; i++)
            {
                month Month = new month();
                Month.text = monthText[i];
                Month.value = i + 1;

                monthList.Add(Month);
            }

            this.cboRequiredMonth.DisplayMember = "text";
            this.cboRequiredMonth.ValueMember = "value";
            this.cboRequiredMonth.DataSource = monthList;
        }

        private void InitializeControls()
        {
            this.MonthValue = DateTime.Now.Month;
            this.Year = DateTime.Now.Year;
        }

        public void Timer_Control()
        {
            if (!IsSuccessful)
            {
                this.tmrProgress.Stop();
                this.Controller.Show_Message("MI30006");    //Saving Interest Fail.
                this.pgbSavingInterest.Value = 0;
                this.pgbSavingInterest.Visible = false;
            }
        }

        #endregion

        private void MNMVEW00003_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

    }
}
