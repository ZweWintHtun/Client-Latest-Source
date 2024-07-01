using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using System.Windows.Forms;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Dmd;


namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00075 : BaseDockingForm, ILOMVEW00075
    {
        /// <summary>
        /// AGLoanProductTypeItem Code Setup View
        /// </summary>
        /// 

        #region Constructor
        public LOMVEW00075()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties

        private LOMDTO00075 _previousAGLoanProductTypeItemSetupDto;
        public LOMDTO00075 PreviousAGLoanProductTypeItemSetupDto
        {
            get
            {
                if (_previousAGLoanProductTypeItemSetupDto == null)
                    return new LOMDTO00075();
                return _previousAGLoanProductTypeItemSetupDto;
            }
            set
            { _previousAGLoanProductTypeItemSetupDto = value; }
        }

        //public int Id
        //{
        //    get { throw new NotImplementedException(); }
        //}

        public string ProductCode
        {
            get
            {
                if (this.cboProductType.SelectedValue == null)
                {
                    return null;
                }
                else return this.cboProductType.SelectedValue.ToString();
            }

            set
            {
                //this.cboProductType.SelectedValue = value;
            }
        }
        public string ProductDesp
        {
            get { return null; }
            set
            {
                this.cboProductType.Text = value;
                //this.cboProductType.SelectedValue = value;
            }
        }
        public string SeasonCode
        {
            get
            {
                if (this.cboSeasonType.SelectedValue == null)
                {
                    return null;
                }
                else return this.cboSeasonType.SelectedValue.ToString();
            }

            set
            {
                // this.cboSeasonType.SelectedValue = value;

            }
        }
        public string SeasonDesp
        {
            get { return null; }
            set
            {
                this.cboSeasonType.Text = value;
            }
        }
        public string UMCode
        {
            get
            {
                if (this.cboUM.SelectedValue == null)
                {
                    return null;
                }
                else return this.cboUM.SelectedValue.ToString();
            }

            set
            {
                //this.cboUM.SelectedValue = value;
            }
        }
        public string UMDesp
        {
            get { return null; }
            set
            {
                this.cboUM.Text = value;
            }
        }
        public string SDay
        {
            get
            {
                if (this.cboSDay.Text == null)
                {
                    return null;
                }
                else return this.cboSDay.Text.ToString();
            }

            set
            {
                this.cboSDay.Text = value;
            }
        }

        public string SMonth
        {
            get
            {
                if (this.cboSMonth.SelectedValue == null)
                {
                    return null;
                }
                else return this.cboSMonth.SelectedValue.ToString();
            }

            set
            {
                this.cboSMonth.Text = value;
            }
        }

        public string EDay
        {
            get
            {
                if (this.cboEDay.Text == null)
                {
                    return null;
                }
                else return this.cboEDay.Text.ToString();
            }

            set
            {
                this.cboEDay.Text = value;
            }
        }

        public string EMonth
        {

            get
            {
                if (this.cboEMonth.SelectedValue == null)
                {
                    return null;
                }
                else return this.cboEMonth.SelectedValue.ToString();
            }

            set
            {
                this.cboEMonth.Text = value;
            }
        }

        public string DeadLineDay
        {
            get
            {
                if (this.cboDDay.Text == null)
                {
                    return null;
                }
                else return this.cboDDay.Text.ToString();
            }

            set
            {
                this.cboDDay.Text = value;
            }
        }

        public string DeadLineMonth
        {
            get
            {
                if (this.cboDMonth.SelectedValue == null)
                {
                    return null;
                }
                else return this.cboDMonth.SelectedValue.ToString();
            }

            set
            {
                this.cboDMonth.Text = value;
            }
        }

        public string Status { get; set; }
        public bool isupdate = false;

        private LOMDTO00075 viewData;
        public LOMDTO00075 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new LOMDTO00075();

                this.viewData.ProductCode = this.ProductCode;
                this.viewData.SeasonCode = this.SeasonCode;
                this.viewData.UMCode = this.UMCode;
                this.viewData.SDay = this.SDay;
                this.viewData.SMonth = this.SMonth;
                this.viewData.EDay = this.EDay;
                this.viewData.EMonth = this.EMonth;
                this.viewData.DeadLineDay = this.DeadLineDay;
                this.viewData.DeadLineMonth = this.DeadLineMonth;

                return this.viewData;
            }
            set { this.viewData = value; }
        }

        public IList<LOMDTO00075> AGLoanProductTypeItemSetupList { get; set; }

        List<string> Dayitems = new List<string>();
        Dictionary<string, string> Monthitems = new Dictionary<string, string>();

        List<string> Dayitems2 = new List<string>();
        Dictionary<string, string> Monthitems2 = new Dictionary<string, string>();

        List<string> Dayitems3 = new List<string>();
        Dictionary<string, string> Monthitems3 = new Dictionary<string, string>();

        private ILOMCTL00075 controller;
        public ILOMCTL00075 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                controller.AGLoanProductTypeItemSetupView = this;
            }
        }
        public void focus()
        {
            this.cboProductType.Focus();
        }
        #endregion

        #region Method

        private void gvAGLoanProductTypeItemSetupList_DataBind()
        {
            gvAGLoansList.AutoGenerateColumns = false;
            this.AGLoanProductTypeItemSetupList = this.controller.GetAll();
            this.gvAGLoansList.DataSource = this.AGLoanProductTypeItemSetupList;
            this.txtRecordCount.Text = gvAGLoansList.RowCount.ToString();
        }

        private void ChangeControlStatusByUserType(bool isUpdateOnlyUser)
        {
            this.cboProductType.Enabled = isUpdateOnlyUser;
            this.cboSeasonType.Enabled = isUpdateOnlyUser;
            this.cboUM.Enabled = isUpdateOnlyUser;
            this.cboSMonth.Enabled = isUpdateOnlyUser;
            this.cboSDay.Enabled = isUpdateOnlyUser;
            this.cboEMonth.Enabled = isUpdateOnlyUser;
            this.cboEDay.Enabled = isUpdateOnlyUser;
            this.cboDDay.Enabled = isUpdateOnlyUser;
            this.cboDMonth.Enabled = isUpdateOnlyUser;
        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.gvAGLoanProductTypeItemSetupList_DataBind();
            this.InitializeControls();
        }

        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        private void InitializeControls()
        {

            this.BindProductType();
            this.BindSeasonType();
            this.BindUM();
            this.BindSMonth();
            this.BindEMonth();
            this.BindDMonth();
            this.cboProductType.SelectedIndex = -1;
            this.cboSeasonType.SelectedIndex = -1;
            this.cboUM.SelectedIndex = -1;
            this.cboSMonth.SelectedIndex = 0;
            this.cboSDay.SelectedIndex = -1;
            this.cboEMonth.SelectedIndex = 0;
            this.cboEDay.SelectedIndex = -1;
            this.cboDMonth.SelectedIndex = 0;
            this.cboDDay.SelectedIndex = -1;
            this.Status = "Save";
            this.isupdate = false;
        }

        public void BindProductType()
        {
            IList<LOMDTO00074> ProductTypeList = CXCLE00002.Instance.GetListObject<LOMDTO00074>("LOMORM00074.SelectAllProductCode", new object[] { true });
            this.cboProductType.ValueMember = "Code";
            this.cboProductType.DisplayMember = "Description";
            this.cboProductType.DataSource = ProductTypeList;
            this.cboProductType.SelectedIndex = -1;
        }

        public void BindUM()
        {
            IList<LOMDTO00073> UMList = CXCLE00002.Instance.GetListObject<LOMDTO00073>("LOMORM00073.SelectAllUMCode", new object[] { true });
            this.cboUM.ValueMember = "UMCode";
            this.cboUM.DisplayMember = "UMDesp";
            this.cboUM.DataSource = UMList;
            this.cboUM.SelectedIndex = -1;
        }

        public void BindSeasonType()
        {
            IList<LOMDTO00071> SeasonTypeList = CXCLE00002.Instance.GetListObject<LOMDTO00071>("LOMORM00071.SelectAllSeasonCode", new object[] { true });
            this.cboSeasonType.ValueMember = "Code";
            this.cboSeasonType.DisplayMember = "Description";
            this.cboSeasonType.DataSource = SeasonTypeList;
            this.cboSeasonType.SelectedIndex = -1;
        }

        public void BindSMonth()
        {
            cboSMonth.DataSource = new BindingSource(Monthitems, null);
            cboSMonth.DisplayMember = "Value";
            cboSMonth.ValueMember = "Key";
            cboSMonth.SelectedIndex = 0;

        }
        public void BindEMonth()
        {
            cboEMonth.DataSource = new BindingSource(Monthitems, null);
            cboEMonth.DisplayMember = "Value";
            cboEMonth.ValueMember = "Key";
            cboEMonth.SelectedIndex = 0;

        }
        public void BindDMonth()
        {
            cboDMonth.DataSource = new BindingSource(Monthitems, null);
            cboDMonth.DisplayMember = "Value";
            cboDMonth.ValueMember = "Key";
            cboDMonth.SelectedIndex = 0;

        }
        public void InitializeDays(string para)
        {
            if (para == "1")
            {
                Dayitems.Add("-- Select Day --");
                for (int i = 1; i <= 27; i++)
                {
                    Dayitems.Add(i.ToString());
                }
            }
            else if (para == "2")
            {
                Dayitems2.Add("-- Select Day --");
                for (int i = 1; i <= 27; i++)
                {
                    Dayitems2.Add(i.ToString());
                }
            }
            else if (para == "3")
            {
                Dayitems3.Add("-- Select Day --");
                for (int i = 1; i <= 27; i++)
                {
                    Dayitems3.Add(i.ToString());
                }
            }
        }
        // For getting month 
        public Dictionary<string, string> InitializeMonths(string para)
        {
            Dictionary<string, string> MonthitemsFor = new Dictionary<string, string>();
            if (para == "1")
            {
                Monthitems.Add("0", "-- Select Day --");
                Monthitems.Add("1", "January");
                Monthitems.Add("2", "February");
                Monthitems.Add("3", "March");
                Monthitems.Add("4", "April");
                Monthitems.Add("5", "May");
                Monthitems.Add("6", "June");
                Monthitems.Add("7", "July");
                Monthitems.Add("8", "August");
                Monthitems.Add("9", "September");
                Monthitems.Add("10", "October");
                Monthitems.Add("11", "November");
                Monthitems.Add("12", "December");
                MonthitemsFor = Monthitems;
                //return Monthitems;
            }
            else if (para == "2")
            {
                Monthitems2.Add("0", "-- Select Day --");
                Monthitems2.Add("1", "January");
                Monthitems2.Add("2", "February");
                Monthitems2.Add("3", "March");
                Monthitems2.Add("4", "April");
                Monthitems2.Add("5", "May");
                Monthitems2.Add("6", "June");
                Monthitems2.Add("7", "July");
                Monthitems2.Add("8", "August");
                Monthitems2.Add("9", "September");
                Monthitems2.Add("10", "October");
                Monthitems2.Add("11", "November");
                Monthitems2.Add("12", "December");
                MonthitemsFor = Monthitems2;
                //return Monthitems2;
            }
            else if (para == "3")
            {
                Monthitems3.Add("0", "-- Select Day --");
                Monthitems3.Add("1", "January");
                Monthitems3.Add("2", "February");
                Monthitems3.Add("3", "March");
                Monthitems3.Add("4", "April");
                Monthitems3.Add("5", "May");
                Monthitems3.Add("6", "June");
                Monthitems3.Add("7", "July");
                Monthitems3.Add("8", "August");
                Monthitems3.Add("9", "September");
                Monthitems3.Add("10", "October");
                Monthitems3.Add("11", "November");
                Monthitems3.Add("12", "December");
                MonthitemsFor = Monthitems3;
                //return Monthitems2;
            }

            return MonthitemsFor;
        }

        public int SearchDayInMonth(string month)
        {
            int year = DateTime.Now.Year;
            //int monthInNumber = ChangeMonthNameWithNumber(month);
            int monthInNumber = Convert.ToInt16(month);
            int daysInMonth = System.DateTime.DaysInMonth(year, monthInNumber);

            return daysInMonth;
        }

        //public int ChangeMonthNameWithNumber(string month)
        //{
        //    int monthInNumber = 0;
        //    if (month == "January")
        //    {
        //        monthInNumber = 1;
        //    }
        //    else if (month == "February")
        //    {
        //        monthInNumber = 2;
        //    }
        //    else if (month == "March")
        //    {
        //        monthInNumber = 3;
        //    }
        //    else if (month == "April")
        //    {
        //        monthInNumber = 4;
        //    }
        //    else if (month == "May")
        //    {
        //        monthInNumber = 5;
        //    }
        //    else if (month == "June")
        //    {
        //        monthInNumber = 6;
        //    }
        //    else if (month == "July")
        //    {
        //        monthInNumber = 7;
        //    }
        //    else if (month == "August")
        //    {
        //        monthInNumber = 8;
        //    }
        //    else if (month == "September")
        //    {
        //        monthInNumber = 9;
        //    }
        //    else if (month == "October")
        //    {
        //        monthInNumber = 10;
        //    }
        //    else if (month == "November")
        //    {
        //        monthInNumber = 11;
        //    }
        //    else if (month == "December")
        //    {
        //        monthInNumber = 12;
        //    }
        //    return monthInNumber;
        //}

        public List<string> FindingDays(int day)
        {
            List<string> dayList = new List<string>();
            Dayitems.Clear();
            InitializeDays("1");
            dayList = Dayitems; /// 1,2,......,27
            for (int i = 28; i <= day; i++)
                dayList.Add(i.ToString());
            return dayList;
        }

        public List<string> FindingDays2(int day)
        {
            List<string> dayList2 = new List<string>();
            Dayitems2.Clear();
            InitializeDays("2");
            dayList2 = Dayitems2; /// 1,2,......,27
            for (int i = 28; i <= day; i++)
                dayList2.Add(i.ToString());
            return dayList2;
        }
        public List<string> FindingDays3(int day)
        {
            List<string> dayList3 = new List<string>();
            Dayitems3.Clear();
            InitializeDays("3");
            dayList3 = Dayitems3; /// 1,2,......,27
            for (int i = 28; i <= day; i++)
                dayList3.Add(i.ToString());
            return dayList3;
        }
        #endregion

        #region Event

        private void LOMVEW00075_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.gvAGLoanProductTypeItemSetupList_DataBind();
            InitializeMonths("1");
            InitializeMonths("2");
            InitializeMonths("3");
            this.InitializeControls();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.Controller.ClearErrors();
            this.cboProductType.Focus();
            this.focus();
            this.gvAGLoansList.EndEdit();
            IList<LOMDTO00075> List = this.AGLoanProductTypeItemSetupList.Where<LOMDTO00075>(x => x.IsCheck == true).ToList();
            foreach (LOMDTO00075 dto in List)
            {
                dto.IsCheck = false;
            }
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.gvAGLoansList.EndEdit();
            IList<LOMDTO00075> deleteList = this.AGLoanProductTypeItemSetupList.Where<LOMDTO00075>(x => x.IsCheck == true).ToList();
            if (deleteList.Count > 0)
            {
                if (CXUIMessageUtilities.ShowMessageByCode("MC90001") == DialogResult.Yes)    //Are you sure you want to delete?
                {
                    this.Controller.Delete(deleteList);
                    this.cboProductType.Focus();
                }
            }
            else
            {
                this.Failure("MV90012");  //Please select at least one record.
            }
            this.focus();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            if (cboSMonth.SelectedIndex == -1 || cboSMonth.SelectedIndex == 0)
            {
                //this.Failure("MV90113");
                CXUIMessageUtilities.ShowMessageByCode("MV90113");
                cboSMonth.Focus();
                return;
            }
            if (cboSDay.SelectedIndex == -1 || cboSMonth.SelectedIndex == 0)
            {
                this.Failure("MV90114");
                cboSDay.Focus();
                return;
            }
            if (cboEMonth.SelectedIndex == -1 || cboSMonth.SelectedIndex == 0)
            {
                this.Failure("MV90115");
                cboEMonth.Focus();
                return;
            }
            if (cboEDay.SelectedIndex == -1 || cboSMonth.SelectedIndex == 0)
            {
                this.Failure("MV90116");
                cboEDay.Focus();
                return;
            }
            if (cboDMonth.SelectedIndex == -1 || cboSMonth.SelectedIndex == 0)
            {
                this.Failure("MV90117");
                cboDMonth.Focus();
                return;
            }
            if (cboDDay.SelectedIndex == -1 || cboSMonth.SelectedIndex == 0)
            {
                this.Failure("MV90118");
                cboDDay.Focus();
                return;
            }
            this.Controller.Save(this.ViewData);
        }

        private void gvAGLoansList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1))
            {
                return;
            }
            DataGridViewRow dataRow = (DataGridViewRow)gvAGLoansList.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colEdit"))
            {
                this.ChangeControlStatusByUserType(true);

                LOMDTO00075 AGLoansCode = (LOMDTO00075)gvAGLoansList.Rows[e.RowIndex].DataBoundItem;

                this.PreviousAGLoanProductTypeItemSetupDto = new LOMDTO00075();
                isupdate = true;
                this.ProductDesp = this.PreviousAGLoanProductTypeItemSetupDto.ProductDesp = AGLoansCode.ProductDesp = gvAGLoansList.Rows[e.RowIndex].Cells[2].Value.ToString();
                this.ProductCode = this.PreviousAGLoanProductTypeItemSetupDto.ProductCode = AGLoansCode.ProductCode = gvAGLoansList.Rows[e.RowIndex].Cells[3].Value.ToString();
                this.SeasonDesp = this.PreviousAGLoanProductTypeItemSetupDto.SeasonDesp = AGLoansCode.SeasonDesp = gvAGLoansList.Rows[e.RowIndex].Cells[4].Value.ToString();
                this.SeasonCode = this.PreviousAGLoanProductTypeItemSetupDto.SeasonCode = AGLoansCode.SeasonCode = gvAGLoansList.Rows[e.RowIndex].Cells[5].Value.ToString();
                this.UMDesp = this.PreviousAGLoanProductTypeItemSetupDto.UMDesp = AGLoansCode.UMDesp = gvAGLoansList.Rows[e.RowIndex].Cells[6].Value.ToString();
                this.UMCode = this.PreviousAGLoanProductTypeItemSetupDto.UMCode = AGLoansCode.UMCode = gvAGLoansList.Rows[e.RowIndex].Cells[7].Value.ToString();
                this.SDay = this.PreviousAGLoanProductTypeItemSetupDto.SDay = AGLoansCode.SDay = gvAGLoansList.Rows[e.RowIndex].Cells[8].Value.ToString();
                this.SMonth = this.PreviousAGLoanProductTypeItemSetupDto.SMonth = AGLoansCode.SMonth = gvAGLoansList.Rows[e.RowIndex].Cells[9].Value.ToString();
                this.EDay = this.PreviousAGLoanProductTypeItemSetupDto.EDay = AGLoansCode.EDay = gvAGLoansList.Rows[e.RowIndex].Cells[10].Value.ToString();
                this.EMonth = this.PreviousAGLoanProductTypeItemSetupDto.EMonth = AGLoansCode.EMonth = gvAGLoansList.Rows[e.RowIndex].Cells[11].Value.ToString();
                this.DeadLineDay = this.PreviousAGLoanProductTypeItemSetupDto.DeadLineDay = AGLoansCode.DeadLineDay = gvAGLoansList.Rows[e.RowIndex].Cells[12].Value.ToString();
                this.DeadLineMonth = this.PreviousAGLoanProductTypeItemSetupDto.DeadLineMonth = AGLoansCode.DeadLineMonth;
                this.ViewData = AGLoansCode;
                this.Status = "Update";
            }
        }

        private void gvAGLoansList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value.ToString().Equals("Undefined"))
            {
                e.CellStyle.ForeColor = Color.Blue;
            }
        }
        private void cboSMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSMonth.SelectedIndex != 0 && cboSMonth.SelectedIndex != -1)
            {
                if (cboSMonth.Text != null)
                {
                    cboSDay.DataSource = null;
                    string month = cboSMonth.SelectedValue.ToString(); // 1
                    int day = SearchDayInMonth(month); // 31
                    List<string> dayLists;
                    dayLists = FindingDays(day);
                    // set data source
                    cboSDay.Enabled = true;
                    cboSDay.DisplayMember = "SName";
                    cboSDay.DataSource = dayLists;
                    if (isupdate == false)
                    {
                        cboSDay.SelectedIndex = 0;
                    }
                }
            }
        }

        private void cboEMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEMonth.SelectedIndex != 0 && cboEMonth.SelectedIndex != -1)
            {
                if (cboEMonth.Text != null)
                {
                    cboEDay.DataSource = null;
                    string month = cboEMonth.SelectedValue.ToString();// January
                    int day = SearchDayInMonth(month); // 31
                    List<string> dayLists2 = FindingDays2(day);

                    cboEDay.Enabled = true;
                    // set data source
                    cboEDay.DisplayMember = "EName";
                    cboEDay.DataSource = dayLists2;
                    if (isupdate == false)
                    {
                        cboEDay.SelectedIndex = 0;
                    }
                }
            }
        }

        private void cboDMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDMonth.SelectedIndex != 0 && cboDMonth.SelectedIndex != -1)
            {
                if (cboDMonth.Text != null)
                {
                    cboDDay.DataSource = null;
                    string month = cboDMonth.SelectedValue.ToString(); // January
                    int day = SearchDayInMonth(month); // 31
                    List<string> dayLists3 = FindingDays3(day);

                    cboDDay.Enabled = true;
                    // set data source
                    cboDDay.DisplayMember = "DName";
                    cboDDay.DataSource = dayLists3;
                    if (isupdate == false)
                    {
                        cboDDay.SelectedIndex = 0;
                    }
                }
            }
        }
        #endregion
        //private void txtDescription_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        //SendKeys.Send("{Tab}");
        //       this.tsbCRUD.Focus();
        //    }
        //}


    }
}
