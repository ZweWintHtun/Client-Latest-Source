using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00091 : BaseDockingForm, ILOMVEW00091
    {
        #region Constructor
        public LOMVEW00091()
        {
            InitializeComponent();
        }
        #endregion

        #region Controllers

        private ILOMCTL00091 controller;
        public ILOMCTL00091 Controller
        {
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
            get { return this.controller; }
        }

        #endregion

        #region Variables

        Array FromMonths = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        Array ToMonths = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        
        int BudMonth;
        string MonthName;

        public enum DateInterval
        {
            Day,
            DayOfYear,
            Hour,
            Minute,
            Month,
            Quarter,
            Second,
            Weekday,
            WeekOfYear,
            Year
        }

        #endregion

        #region Helper Methods
        
        public string returnMonthNumber(string MonthName)
        {
            switch (MonthName.ToLower())
            {
                case "january":
                    MonthName = "01";
                    break;

                case "february":
                    MonthName = "02";
                    break;

                case "march":
                    MonthName = "03";
                    break;

                case "april":
                    MonthName = "04";
                    break;

                case "may":
                    MonthName = "05";
                    break;

                case "june":
                    MonthName = "06";
                    break;

                case "july":
                    MonthName = "07";
                    break;

                case "august":
                    MonthName = "08";
                    break;

                case "september":
                    MonthName = "09";
                    break;

                case "october":
                    MonthName = "10";
                    break;

                case "november":
                    MonthName = "11";
                    break;

                case "december":
                    MonthName = "12";
                    break;

                default:
                    MonthName = "ERROR";
                    break;
            }
            return MonthName;
        }

        /// <summary>
        ///Failure Message
        /// </summary>
        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.cboFromMonth.SelectedIndex = 0;
            txtFromDate.Text = DateTime.Now.Year.ToString();
            txtToDate.Text = DateTime.Now.AddYears(1).Year.ToString();
            txtToDate.Focus();
        }


        #endregion

        #region Events

        private void LOMVEW00091_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            cboFromMonth.DataSource = FromMonths;
            cboFromMonth.SelectedIndex = DateTime.Now.Month - 1;
            cboToMonth.DataSource = ToMonths;
            cboToMonth.SelectedIndex = DateTime.Now.Month - 1;
            BudMonth = DateTime.Now.Month;
            if (BudMonth >= 4)
            {
                txtFromDate.Text = DateTime.Now.Year.ToString();
                txtToDate.Text = DateTime.Now.AddYears(1).Year.ToString();
            }
            else
            {
                txtFromDate.Text = DateTime.Now.AddYears(-1).ToString("yyyy");
                txtToDate.Text = DateTime.Now.Year.ToString();
            }
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            cboFromMonth.DataSource = FromMonths;
            cboFromMonth.SelectedIndex = DateTime.Now.Month - 1;
            cboToMonth.DataSource = ToMonths;
            cboToMonth.SelectedIndex = DateTime.Now.Month - 1;
            BudMonth = DateTime.Now.Month;
            if (BudMonth >= 4)
            {
                txtFromDate.Text = DateTime.Now.Year.ToString();
                txtToDate.Text = DateTime.Now.AddYears(1).Year.ToString();
            }
            else
            {
                txtFromDate.Text = DateTime.Now.AddYears(-1).ToString("yyyy");
                txtToDate.Text = DateTime.Now.Year.ToString();
            }
        }
        
        private void txtToDate_Leave(object sender, EventArgs e)
        {
            if (txtToDate.Text == "" || txtToDate.Text == "0")
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00144);
                txtToDate.Text = DateTime.Now.AddYears(1).Year.ToString();
                txtToDate.Focus();
            }
            else if (Convert.ToInt32(txtFromDate.Text) >= Convert.ToInt32(txtToDate.Text))
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90084);
                txtToDate.Text = DateTime.Now.AddYears(1).Year.ToString();
                txtToDate.Focus();
            }
        }

        private void txtToDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            if (txtToDate.Text.Trim() != "")
            {
                DateTime today = DateTime.Today;
                DateTime sdt;
                DateTime edt;
                if (Int32.Parse(returnMonthNumber(cboFromMonth.Text)) > 0 && Int32.Parse(returnMonthNumber(cboFromMonth.Text)) < 4)
                {
                    sdt = Convert.ToDateTime(returnMonthNumber(cboFromMonth.Text) + "/01/" + txtToDate.Text.ToString());//StartDate of From Month to calculate interest
                }
                else
                {
                    sdt = Convert.ToDateTime(returnMonthNumber(cboFromMonth.Text) + "/01/" + txtFromDate.Text.ToString());//StartDate of From Month to calculate interest
                }
                if (Int32.Parse(returnMonthNumber(cboToMonth.Text)) > 0 && Int32.Parse(returnMonthNumber(cboToMonth.Text)) < 4)
                {
                    edt = Convert.ToDateTime(returnMonthNumber(cboToMonth.Text) + "/01/" + txtToDate.Text.ToString());//StartDate of To Month to calculate interest
                }
                else
                {
                    edt = Convert.ToDateTime(returnMonthNumber(cboToMonth.Text) + "/01/" + txtFromDate.Text.ToString());//StartDate of To Month to calculate interest
                }

                int edtDate = DateTime.DaysInMonth(edt.Year, edt.Month);
                DateTime dtEDate = Convert.ToDateTime(edt.Month.ToString() + "/" + edtDate + "/" + edt.Year.ToString());//EndDate of To Month to calculate interest

                //this.controller.CalculateInterestFromMonthToMonth(txtFromDate.Text.ToString() + "/" + txtToDate.Text.ToString(), sdt, dtEDate);

                string budgetYear = txtFromDate.Text.ToString() + "/" + txtToDate.Text.ToString();
                IList<LOMDTO00085> farmLiList = this.controller.SelectFarmLiCloseDateIsNull(CurrentUserEntity.BranchCode, budgetYear);
                if (farmLiList != null && farmLiList.Count > 0)
                {
                    if (this.controller.CalculateFarmLoanInterestByMonth(farmLiList, sdt, dtEDate))
                    {
                        Successful(CXMessage.MI90024);
                    }
                    else
                    {
                        Failure(CXMessage.MI90025);
                    }
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90078);
                    txtToDate.Focus();
                }
            }
            else
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00144);
                txtToDate.Focus();
            }
        }

        #endregion
    }
}
