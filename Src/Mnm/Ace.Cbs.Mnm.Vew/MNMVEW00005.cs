//----------------------------------------------------------------------
// <copyright file="MNMVEW00005.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KSW</CreatedUser>
// <CreatedDate>13/11/2013</CreatedDate>
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
using System.Globalization;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Mnm.Ctr.Ptr;


namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00005 : BaseForm ,IMNMVEW00005
    {
        public MNMVEW00005()
        {
            InitializeComponent();
        }

        #region controller
        private IMNMCTL00005 controller;
        public IMNMCTL00005 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                controller.ViewData = this;
            }
        }
        #endregion

        #region Properties

        public Nullable<DateTime> Date_time
        {
            get
            {
                return this.dtpDailyPosting.Value;

            }
            set
            {
                if (value == null)
                {
                    this.dtpDailyPosting.CustomFormat = " ";
                }
                else
                {
                    this.dtpDailyPosting.CustomFormat = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.UIDateFormat);
                    this.dtpDailyPosting.Value = value.Value;
                }
            }
             
        }
        public DateTime StartDate
        {
            get
            {
                //string dtmonth = dtpDailyPosting.Value.ToShortDateString().Substring(0, 2);
                string dtmonth = dtpDailyPosting.Value.Month.ToString();
                //string dtyear = dtpDailyPosting.Value.ToShortDateString().Substring(6, 4);
                string dtyear = dtpDailyPosting.Value.Year.ToString();
                string date = dtmonth + "/01/" + dtyear;
                DateTime stdate = Convert.ToDateTime(date);
                return stdate;

            }            
        }

        public int ProgressBar
        {
            get { return progressBarPosting.Value; }
            set { this.progressBarPosting.Value = value; }
        }
        public bool Progressstatus
        {
            get { return progressBarPosting.Visible; }
            set { this.progressBarPosting.Visible = value; }
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

        private void btnPosting_Click(object sender, EventArgs e)
        {
            string serverName = System.Windows.Forms.SystemInformation.ComputerName;

            if (CXUIMessageUtilities.ShowMessageByCode("MC30002") == DialogResult.Yes)
            {
                progressBarPosting.Visible = true;
                string getdate = DateTime.Now.ToShortDateString();
                DateTime datestr = dtpDailyPosting.Value;
                string datetxt = datestr.ToShortDateString();

                //if (datetxt != getdate)
                //{
                //    progressBarPosting.Visible = false;
                //    CXUIMessageUtilities.ShowMessageByCode("MV00117"); //invaild date
                //}
                //else
                //{
                    Controller.DailyPosting();
                //}

            }
            else
            {
                this.Focus();
                progressBarPosting.Visible = false;

            }

            }

        private void MNMVEW00005_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MNMVEW00005_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }
        

       
    }
}
