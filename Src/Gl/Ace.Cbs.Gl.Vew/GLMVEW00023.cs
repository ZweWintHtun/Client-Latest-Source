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
using Ace.Cbs.Gl.Ctr.Ptr;
using Ace.Cbs.Gl.Dmd;

namespace Ace.Cbs.Gl.Vew
{
    public partial class GLMVEW00023 : BaseForm , IGLMVEW00023
    {
        public GLMVEW00023()
        {
            InitializeComponent();
        }       
        #region Controller
        private IGLMCTL00023 controller;
        public IGLMCTL00023 Controller
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
        public GLMDTO00023 ViewData { get; set; }
        //public Nullable<DateTime> Date_time
        //{
        //    get
        //    {
        //        return this.dtpMonthlyPosting.Value;
        //    }
        //    set
        //    {
        //        if (value == null)
        //        {
        //            this.dtpMonthlyPosting.CustomFormat = " ";
        //        }
        //        {
        //            this.dtpMonthlyPosting.CustomFormat = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.UIDateFormat);
        //        }
        //    }
        //}
        // start day of selected month
        public DateTime StartDate
        {
            get
            {
                string dtmonth = dtpMonthlyPosting.Value.Month.ToString();
                string dtyear = dtpMonthlyPosting.Value.Year.ToString();
                string date = dtmonth + "/01/" + dtyear;
                DateTime stdate = Convert.ToDateTime(date);
                return stdate;
            }
            set
            {
            }
        }
        // end day of selected month
        public DateTime EndDate
        {
            get
            {
                string date=string.Empty;
                string dtmonth = dtpMonthlyPosting.Value.Month.ToString();
                string dtyear = dtpMonthlyPosting.Value.Year.ToString();
                int month = Convert.ToInt16(dtmonth);
                int year = Convert.ToInt16(dtyear);

                /*
                if (year == DateTime.Now.Year && month < DateTime.Now.Month)
                {
                    string daysInMonth = System.DateTime.DaysInMonth(year, month).ToString();
                    date = dtmonth + "/" + daysInMonth + "/" + dtyear;
                }
                if (year == DateTime.Now.Year && month == DateTime.Now.Month)
                {
                    string daysInMonth = System.DateTime.DaysInMonth(year, month).ToString();
                    string days = DateTime.Now.Day.ToString();
                    date = dtmonth + "/" + days + "/" + dtyear;
                }
                if (year < DateTime.Now.Year && month < DateTime.Now.Month)
                {
                    string daysInMonth = System.DateTime.DaysInMonth(year, month).ToString();
                    string days = DateTime.Now.Day.ToString();
                    date = month + "/" + dtpMonthlyPosting.Value.Day.ToString() + "/" + year;
                }
                if (year < DateTime.Now.Year && month > DateTime.Now.Month)
                {
                    string daysInMonth = System.DateTime.DaysInMonth(year, month).ToString();
                    string days = DateTime.Now.Day.ToString();
                    date = month + "/" + dtpMonthlyPosting.Value.Day.ToString() + "/" + year;
                }
                if (year < DateTime.Now.Year && month == DateTime.Now.Month)
                {
                    string daysInMonth = System.DateTime.DaysInMonth(year, month).ToString();
                    string days = DateTime.Now.Day.ToString();
                    date = month + "/" + dtpMonthlyPosting.Value.Day.ToString() + "/" + year;
                }
                */
                // Modified By SSZ (2022-01-11)

                string daysInMonth = System.DateTime.DaysInMonth(year, month).ToString();
                date = dtmonth + "/" + daysInMonth + "/" + dtyear;

                DateTime enddate = Convert.ToDateTime(date);
                return enddate;
            }
            set
            {
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
        public bool IsAllBranch
        {
            get { return chkBranch.Checked; }
            set { this.chkBranch.Checked = value; }
        }
        public string BranchCode
        {
            get
            {
                if (this.cboBranchNo.Text == null)
                {
                    return null;
                }
                else
                {
                    return this.cboBranchNo.Text;
                }
            }
            set
            {
                this.cboBranchNo.Text = value;
            }
        }
        #endregion 

        #region Methods
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
        private void GLMVEW00023_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
            InitializedControls();
        }
        private void btnPosting_Click(object sender, EventArgs e)
        {
            string serverName = System.Windows.Forms.SystemInformation.ComputerName;

            if (CXUIMessageUtilities.ShowMessageByCode("MC30002") == DialogResult.Yes)
            {
                progressBarPosting.Visible = true;
                int getMonth = DateTime.Now.Month;
                int getYear = DateTime.Now.Year;
                int dateMonth = Convert.ToInt16(dtpMonthlyPosting.Value.Month);
                int dateYear = Convert.ToInt16(dtpMonthlyPosting.Value.Year);

                if (dateMonth > getMonth && dateYear > getYear)
                {
                    progressBarPosting.Visible = false;
                    CXUIMessageUtilities.ShowMessageByCode("MV90204"); //Lock request time-out period exceeded!
                }
                else
                {
                    Controller.MonthlyPosting();
                }
            }
            else
            {
                this.Focus();
                progressBarPosting.Visible = false;
            }
        }
        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }
        private void GLMVEW00023_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

        private void chkBranch_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBranch.Checked)
            {
                this.cboBranchNo.Enabled = false;
                this.cboBranchNo.SelectedValue = "";
            }
            else
            {
                this.cboBranchNo.Enabled = true;
            }
        }
        #endregion
        #region Helper Methods
        private void BindBranchCode()
        {
            IList<BranchDTO> branches = CXCLE00001.Instance.SelectAllBranch();
            cboBranchNo.ValueMember = "BranchCode";
            cboBranchNo.DisplayMember = "BranchCode";
            cboBranchNo.DataSource = branches;
            //cboBranchNo.SelectedIndex = -1;
        }
        private void InitializedControls()
        {
            if(CurrentUserEntity.IsHOUser)
            {
                this.cboBranchNo.Visible = true;
                this.chkBranch.Visible= true;
                this.BindBranchCode();
            }
            else
            {
                this.lblBranchNo.Visible = true;
                this.lblBranchNo.Text = CurrentUserEntity.BranchCode +" ("+CurrentUserEntity.BranchDescription+")";
            }
        }
        #endregion
    }
}
