using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00023 : BaseDockingForm, ILOMVEW00023
    {
        public LOMVEW00023()
        {
            InitializeComponent();
        }        

        #region "Constructors"

        #endregion

        #region "Properties"
        private IList<LOMDTO00021> liList;
        public IList<LOMDTO00021> LiList
        {
            get
            {
                if (this.liList == null)
                    this.liList = new List<LOMDTO00021>();

                return this.liList;
            }
            set { this.liList = value; }
        }
        public bool isMonthly
        {
            get { return this.rdoMonthly.Checked; }
            set {this.rdoMonthly.Checked = value;}
        }
        public bool isQuaterly
        {
            get { return this.rdoQuaterly.Checked; }
            set { this.rdoQuaterly.Checked = value; }
        }
        public bool isPeriod1
        {
            get { return this.rdoPeriod1.Checked; }
            set { this.rdoPeriod1.Checked = value; }
        }
        public bool isPeriod2
        {
            get { return this.rdoPeriod2.Checked; }
            set { this.rdoPeriod2.Checked = value; }
        }
        public bool isPeriod3
        {
            get { return this.rdoPeriod3.Checked; }
            set { this.rdoPeriod3.Checked = value; }
        }
        public bool isPeriod4
        {
            get { return this.rdoPeriod4.Checked; }
            set { this.rdoPeriod4.Checked = value; }
        }
        #endregion

        #region "Variables"
                
        Array Months = new string[] {"January","February","March","April","May","June","July","August","September","October","November","December"};
        int BudMonth;
        string MonthName;
        string output = string.Empty;

        #endregion

        #region "Controllers"
        private ILOMCTL00023 controller;
        public ILOMCTL00023 Controller
        {
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
            get { return this.controller; }
        }
        #endregion        

        #region "Events"

        private void LOMVEW00023_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            //cboMonth.DataSource = Months;
            //cboMonth.SelectedIndex = DateTime.Now.Month - 1;
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
            this.grpMonthly.Visible = false;
            this.isMonthly = false;
            //this.grpQuaterly.Visible = false;
            //this.isQuaterly = false;
            this.Size = new System.Drawing.Size(506, 83);
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            if (this.isMonthly)
            {
                cboMonth.SelectedIndex = DateTime.Now.Month - 1;
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
                txtToDate.Focus();
            }
            else if (this.isQuaterly)
            {
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
                //txtToDate.Focus();
                PeriodChecked();
            }
        }

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

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (txtToDate.Text.Trim() != "")
                {
                    string eDate = string.Empty;
                    string sDate = string.Empty;
                    DateTime dtSDate = DateTime.Now, dtEDate = DateTime.Now;
                    Int16 period = 0;

                    if (isMonthly)
                    {
                        if ((cboMonth.SelectedIndex + 1).ToString() == DateTime.Now.Month.ToString())
                        {
                            DateTime today = DateTime.Today;
                            period = Convert.ToInt16(this.returnMonthNumber(cboMonth.Text));
                            dtSDate = Convert.ToDateTime(period + "/01/" + txtFromDate.Text.ToString()); //start date
                            string mon = (cboMonth.SelectedIndex + 1).ToString();
                            int dtDate = DateTime.DaysInMonth(today.Year, today.Month);

                            dtEDate = Convert.ToDateTime(dtSDate.Month.ToString() + "/" + dtDate + "/" + txtFromDate.Text.ToString());

                            string month = (cboMonth.SelectedIndex + 1).ToString();
                            period = SearchBudgetMonth(period);
                            output = this.controller.CalculateLoansInterestForMonthly(dtSDate, dtEDate, period, CurrentUserEntity.BranchCode.ToString(),CurrentUserEntity.CurrentUserID);
                            if (this.output == "000")
                            {
                                Successful(CXMessage.MI90024);
                            }
                            else
                            {
                                Failure(CXMessage.MI90025); /// not voucher OR not have in during datetime period OR not SAMT or not QBAl
                            }

                        }
                        else
                        {
                            CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90158);
                            cboMonth.Focus();
                        }
                    }
                    else if (isQuaterly)
                    {                       
                        DateTime today = DateTime.Today;
                        if (isPeriod1) //April to June
                        {
                            dtSDate = Convert.ToDateTime("04" + "/01/" + txtFromDate.Text.ToString()); //start date (04/01/2018)
                            int year = Convert.ToInt16(txtToDate.Text);
                            int dtDate = DateTime.DaysInMonth(year, 06);
                            dtEDate = Convert.ToDateTime("06" + "/30/" + txtFromDate.Text.ToString()); //end date
                            if (dtSDate>=DateTime.Now || dtEDate<=DateTime.Now)
                            {
                                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90158);
                            }
                            else
                            {
                                period = 1;
                                output = this.controller.CalculateLoansInterestForQuarter(dtSDate, dtEDate, period, CurrentUserEntity.BranchCode.ToString());                                
                                if (this.output == "000")
                                {
                                    Successful(CXMessage.MI90024);
                                }
                                else
                                {
                                    Failure(CXMessage.MI90025); /// not voucher OR not have in during datetime period OR not SAMT or not QBAl(Loans Interest Calculation fail.)
                                }
                            }
                        }
                        else if (isPeriod2)//July to September
                        {
                            dtSDate = Convert.ToDateTime("07" + "/01/" + txtFromDate.Text.ToString()); //start date (07/01/2018)
                            int year = Convert.ToInt16(txtToDate.Text);
                            int dtDate = DateTime.DaysInMonth(year, 09);
                            dtEDate = Convert.ToDateTime("09" + "/30/" + txtFromDate.Text.ToString()); //end date
                            if (dtSDate >= DateTime.Now || dtEDate <= DateTime.Now)
                            {
                                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90158);
                            }
                            else
                            {
                                period = 2;
                                output = this.controller.CalculateLoansInterestForQuarter(dtSDate, dtEDate, period, CurrentUserEntity.BranchCode.ToString());                                
                                if (this.output == "000")
                                {
                                    Successful(CXMessage.MI90024);
                                }
                                else
                                {
                                    Failure(CXMessage.MI90025); /// not voucher OR not have in during datetime period OR not SAMT or not QBAl(Loans Interest Calculation fail.)
                                }
                            }
                        }
                        else if (isPeriod3)//October to December
                        {
                            dtSDate = Convert.ToDateTime("10" + "/01/" + txtFromDate.Text.ToString()); //start date (10/01/2018)
                            int year = Convert.ToInt16(txtToDate.Text);
                            dtEDate = Convert.ToDateTime("12" + "/31/" + txtFromDate.Text.ToString()); //end date
                            if (dtSDate >= DateTime.Now || dtEDate <= DateTime.Now)
                            {
                                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90158);
                            }
                            else
                            {
                                period = 3;
                                output = this.controller.CalculateLoansInterestForQuarter(dtSDate, dtEDate, period, CurrentUserEntity.BranchCode.ToString());                               
                                if (this.output == "000")
                                {
                                    Successful(CXMessage.MI90024);
                                }
                                else
                                {
                                    Failure(CXMessage.MI90025); /// not voucher OR not have in during datetime period OR not SAMT or not QBAl(Loans Interest Calculation fail.)
                                }
                            }
                        }
                        else if (isPeriod4)//January to March
                        {
                            dtSDate = Convert.ToDateTime("01" + "/01/" + txtFromDate.Text.ToString()); //start date (01/01/2017)
                            int year = Convert.ToInt16(txtToDate.Text);
                            //int dtDate = DateTime.DaysInMonth(year, 03);
                            dtEDate = Convert.ToDateTime("03" + "/31/" + txtFromDate.Text.ToString()); //end date
                            if (dtSDate >= DateTime.Now || dtEDate <= DateTime.Now)
                            {
                                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90158);
                            }
                            else
                            {
                                period = 4;
                                output = this.controller.CalculateLoansInterestForQuarter(dtSDate, dtEDate, period, CurrentUserEntity.BranchCode.ToString());                                
                                if (this.output == "000")
                                {
                                    Successful(CXMessage.MI90024);
                                }
                                else
                                {
                                    Failure(CXMessage.MI90025); /// not voucher OR not have in during datetime period OR not SAMT or not QBAl(Loans Interest Calculation fail.)
                                }
                            }
                            
                        }                        
                    }
                }
                else
                { 
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00144);
                    txtToDate.Focus();
                }
            }
            catch (Exception ex)
            {
                throw ex;
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

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtToDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        //private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //if (cboMonth.SelectedIndex == 0 || cboMonth.SelectedIndex == 1 || cboMonth.SelectedIndex == 2)//for Jan,Feb,March(2016/2017)
        //    //{
        //    //    txtFromDate.Text = DateTime.Now.Year.ToString(); //2016
        //    //    txtFromDate.Text = DateTime.Now.AddYears(1).Year.ToString(); //2017
        //    //}
        //    //else  //for April\.....\Dec(2017/2018)
        //    //{
        //    //    txtFromDate.Text = DateTime.Now.AddYears(1).Year.ToString(); //2017
        //    //    txtFromDate.Text = DateTime.Now.AddYears(2).Year.ToString(); //2018
        //    //}
        //}

        //private void PreviousRadioButton_CheckedChanged(object sender, EventArgs e)
        //{
        //    //if (isPeriod4 == true) // Q4 (January to March)
        //    //{
        //    //    txtFromDate.Text = DateTime.Now.Year.ToString(); //2016
        //    //    txtFromDate.Text = DateTime.Now.AddYears(1).Year.ToString(); //2017
        //    //}
        //    //else if (isPeriod1 == true || isPeriod2 == true || isPeriod3 == true)
        //    //{
        //    //    txtFromDate.Text = DateTime.Now.AddYears(1).Year.ToString(); //2017
        //    //    txtFromDate.Text = DateTime.Now.AddYears(2).Year.ToString(); //2018
        //    //}
        //}

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.isMonthly)
            {
                cboMonth.DataSource = Months;
                cboMonth.SelectedIndex= DateTime.Now.Month-1;
                this.grpMonthly.Visible = true;
                this.isMonthly = true;
                this.grpQuaterly.Visible = false;
                this.isQuaterly = false;
                this.Size = new System.Drawing.Size(506, 221);
            }
            //if (this.isQuaterly)
            //{
            //    this.grpMonthly.Visible = false;
            //    this.isMonthly = false;
            //    this.grpQuaterly.Visible = true;
            //    this.isQuaterly = true;
            //    PeriodChecked();
            //    this.Size = new System.Drawing.Size(506, 276);
            //}
        }

        #endregion

        #region "Methods"

        private void PeriodChecked()
        {
            if (this.BudMonth == 1 || this.BudMonth == 2 || this.BudMonth == 3)
            {
                this.isPeriod4 = true;
            }
            if (this.BudMonth == 4 || this.BudMonth == 5 || this.BudMonth == 6)
            {
                this.isPeriod1 = true;
            }
            if (this.BudMonth == 7 || this.BudMonth == 8 || this.BudMonth == 9)
            {
                this.isPeriod2 = true;
            }
            if (this.BudMonth == 10 || this.BudMonth == 11 || this.BudMonth == 12)
            {
                this.isPeriod3 = true;
            }
        }

        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            if (rdoMonthly.Checked == true)
            {
                cboMonth.SelectedIndex = DateTime.Now.Month - 1;
            }
            txtToDate.Focus();           
        }
        public Int16 SearchBudgetMonth(int month)
        {
            Int16 budmonth = 0;
            if (month == 1)
            {
                budmonth = 10;
            }
            else if (month == 2)
            {
                budmonth = 11;
            }
            else if (month == 3)
            {
                budmonth = 12;
            }
            else if (month == 4)
            {
                budmonth = 1;
            }
            else if (month == 5)
            {
                budmonth = 2;
            }
            else if (month ==6)
            {
                budmonth =3;
            }
            else if (month == 7)
            {
                budmonth = 4;
            }
            else if (month == 8)
            {
                budmonth =5;
            }
            else if (month == 9)
            {
                budmonth = 6;
            }
            else if (month == 10)
            {
                budmonth = 7;
            }
            else if (month == 11)
            {
                budmonth =8;
            }
            else if (month == 12)
            {
                budmonth = 9;
            }
            return budmonth;
        }
        #endregion
    }
}
