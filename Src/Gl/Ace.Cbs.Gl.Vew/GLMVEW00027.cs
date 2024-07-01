using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Gl.Ctr.Ptr;
using Ace.Cbs.Mnm._Excel;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Gl.Dmd;

namespace Ace.Cbs.Gl.Vew
{
    public partial class GLMVEW00027 : BaseForm, IGLMVEW00027
    {
        #region Constructor
        public GLMVEW00027()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        public DateTime RequiredDate
        {
            get { return dtpRequiredDate.Value; }
            set { dtpRequiredDate.Text = value.ToString(); }
        }
        private string Income;
        public string isIncome
        {
            get { return this.Income; ; }
            set { this.Income = value; }
        }
        private string allBranch;
        public string isAllBranch
        {
            get { return this.allBranch; }
            set { this.allBranch = value; }
        }
        public bool IsIncomeAndExpenditure
        {
            get
            {
                if (rdoIncomeAndExpenditure.Checked == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                rdoIncomeAndExpenditure.Checked = value;
            }
        }
        public string SourceBranch
        {
            get
            {
                if (this.cboBranchNo.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cboBranchNo.SelectedValue.ToString();
                }

            }
            set { this.cboBranchNo.SelectedValue = value.ToString(); }
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

        #region Controller
        private IGLMCTL00027 _controller;
        public IGLMCTL00027 Controller
        {
            get
            {
                return this._controller;
            }
            set
            {
                this._controller = value;
                this._controller.View = this;
            }
        }
        #endregion

        #region Methods
        private bool CheckDate()
        {    // Check dtpRequiredDate Date Time
            if (this.dtpRequiredDate.Value.Date > DateTime.Now.Date)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00129, this.dtpRequiredDate.Value.ToString("dd/MM/yyyy"));//Datetime cannot be greater than today date.
                this.dtpRequiredDate.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        //public void IntializeControls()
        //{
        //    this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
        //    this.rdoIncomeAndExpenditure.Checked = true;
        //    this.dtpRequiredDate.Text = DateTime.Now.ToString("MMM/yyyy");
        //    Income = "1";
        //    allBranch = "1";            
        //}

        #endregion

        #region Events
        private void GLMVEW00027_Load(object sender, EventArgs e)
        {
            InitializedControls();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializedControls();
        }


        private void New_Method()
        {
            if (CheckDate())
            //this.Controller.Print();
            {
                try
                {
                    //DataSet ds = this.Controller.Print();
                    IList<GLMDTO00023> ds1 = this.Controller.Print1();
                    IList<GLMDTO00023> ds2 = this.Controller.Print2();

                    if (ds1.Count > 0 && ds2.Count > 0)
                    {
                        //if (Income == "0")
                        //{
                            //DataTable dt1 = ds.Tables[0];
                            //DataTable dt2 = ds.Tables[1];


                            //DataTable sort_dt1 = Check_Data(dt2, dt1);
                            //sort_dt1.Columns["ITEM"].DataType = Type.GetType("System.Int32");

                            //DataView view = sort_dt1.DefaultView;
                            //view.Sort = "ITEM ASC";
                            //sort_dt1 = view.ToTable();

                            //dgvData1.DataSource = sort_dt1;
                            //dgvData1.DataSource = Check_Data(dt2, dt1);
                            //dgvData1.Columns["ITEM"].ValueType = typeof(int);
                            //dgvData1.Sort(this.dgvData1.Columns["ITEM"],
                            //        ListSortDirection.Ascending);

                            //DataTable sort_dt2 = Check_Data(dt1, dt2);
                            //sort_dt2.Columns["ITEM"].DataType = Type.GetType("System.Int32");

                            //DataView view2 = sort_dt2.DefaultView;
                            //view2.Sort = "ITEM ASC";
                            //sort_dt2 = view2.ToTable();

                            //dgvData2.DataSource = sort_dt2;
                            //dgvData2.DataSource = Check_Data(dt1, dt2);
                            //dgvData2.Columns["ITEM"].ValueType = typeof(int);
                            //dgvData2.Sort(this.dgvData2.Columns["ITEM"],
                            //        ListSortDirection.Ascending);

                            //}
                            //else
                            //{
                            //    DataTable dt1 = new DataTable();
                            //    for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                            //    {
                            //        dt1.Columns.Add(ds.Tables[0].Columns[i].ColumnName);
                            //    }
                            //    dt1.Columns["ITEM"].DataType = Type.GetType("System.Int32");

                            //    dt1 = ds.Tables[0];

                            //    DataView view = dt1.DefaultView;
                            //    view.Sort = "ITEM ASC";
                            //    dt1 = view.ToTable();

                            //    DataTable dt2 = new DataTable();

                            //    for (int i = 0; i < ds.Tables[1].Columns.Count; i++)
                            //    {
                            //        dt2.Columns.Add(ds.Tables[1].Columns[i].ColumnName);
                            //    }

                            //    dt2.Columns["ITEM"].DataType = Type.GetType("System.Int32");

                            //    dt2 = ds.Tables[1];

                            //    DataView view2 = dt2.DefaultView;
                            //    view2.Sort = "ITEM ASC";
                            //    dt2 = view2.ToTable();

                            //    //dgvData1.DataSource = dt1;
                            //    //dgvData2.DataSource = dt2;

                            //    dgvData1.DataSource = ds.Tables[0];
                            //    dgvData1.Columns["ITEM"].ValueType = typeof(int);
                            //    dgvData1.Sort(this.dgvData1.Columns["ITEM"],
                            //           ListSortDirection.Ascending);
                            //    dgvData2.DataSource = ds.Tables[1];
                            //    dgvData2.Columns["ITEM"].ValueType = typeof(int);
                            //    dgvData2.Sort(this.dgvData2.Columns["ITEM"],
                            //           ListSortDirection.Ascending);
                            //}


                            //string _counterType = this.Controller._counterType;
                            //string reportTitle = this.Controller.SendReportTitle();
                            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                            //CashControlReport_Excel frm = new CashControlReport_Excel();
                            GeneralLedger_Lia_Excel frm2 = new GeneralLedger_Lia_Excel();
                            //GeneralLedger_Lia_Excel_CombineBankName frm2 = new GeneralLedger_Lia_Excel_CombineBankName();
                            Income_Expense_Excel frm3 = new Income_Expense_Excel();
                            string bankDesp = Branch.BranchDescription;
                            string address = Branch.Address;


                            string result_Income_sheet1_3Line_Title = "GENERAL LEDGER";
                            string result_Income_sheet1_4Line_Title = "RETURN OF GENERAL LEDGER BALANCE STATEMENT FOR THE MONTH OF " + DateTime.Now.ToString("MMMM").ToUpper() + " " + DateTime.Now.ToString("yyyy");
                            string result_Income_sheet2_3Line_Title = "GENERAL LEDGER";
                            string result_Income_sheet2_4Line_Title = "RETURN OF GENERAL LEDGER BALANCE STATEMENT FOR THE MONTH OF " + DateTime.Now.ToString("MMMM").ToUpper() + " " + DateTime.Now.ToString("yyyy");

                            if (Income == "1")
                            {
                                result_Income_sheet1_3Line_Title = bankDesp + " (" + address + ")";
                                result_Income_sheet1_4Line_Title = "INCOME ACCOUNT FOR THE MONTH OF " + DateTime.Now.ToString("MMMM").ToUpper() + " " + DateTime.Now.ToString("yyyy");
                                result_Income_sheet2_3Line_Title = bankDesp + " (" + address + ")";
                                result_Income_sheet2_4Line_Title = "EXPENDITURE ACCOUNT FOR THE MONTH OF " + DateTime.Now.ToString("MMMM").ToUpper() + " " + DateTime.Now.ToString("yyyy");
                            }
                            if (Income == "1")
                            {
                                //frm.ExportToExcel_Expenditure(dgvData1, dgvData2, "Income And Expenditure", bankDesp, address, result_Income_sheet1_3Line_Title, result_Income_sheet1_4Line_Title, result_Income_sheet2_3Line_Title, result_Income_sheet2_4Line_Title);
                                //frm.ExportToExcel_Expenditure_New(ds1, ds2, "Income And Expenditure", bankDesp, address, result_Income_sheet1_3Line_Title, result_Income_sheet1_4Line_Title, result_Income_sheet2_3Line_Title, result_Income_sheet2_4Line_Title);
                                frm3.ExportToExcel_Income_Expense(ds1, ds2, "Income And Expenditure", bankDesp, address, result_Income_sheet1_3Line_Title, result_Income_sheet1_4Line_Title, result_Income_sheet2_3Line_Title, result_Income_sheet2_4Line_Title,this.RequiredDate);
                            }
                            else
                            {
                                //frm.ExportToExcel_Expenditure(dgvData1, dgvData2, "General Ledger  Statement", bankDesp, address, result_Income_sheet1_3Line_Title, result_Income_sheet1_4Line_Title, result_Income_sheet2_3Line_Title, result_Income_sheet2_4Line_Title);
                                frm2.ExportToExcel_General_Ledger(ds1, ds2, "General Ledger Statement", bankDesp, address, result_Income_sheet1_3Line_Title, result_Income_sheet1_4Line_Title, result_Income_sheet2_3Line_Title, result_Income_sheet2_4Line_Title, this.RequiredDate);
                            }

                            //}
                            //else
                            //{
                            //    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME90033);//No Data for Report.
                            //}
                        }
                    }
                //}
                    
                catch (Exception ex)
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME90033);//No Data for Report.
                }
            }
            
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            New_Method();
            //if (CheckDate())
            ////this.Controller.Print();
            //{
            //    try
            //    {
            //        DataSet ds = this.Controller.Print();

            //        if (ds.Tables.Count > 0)
            //        {
            //            if (Income == "0")
            //            {
            //                DataTable dt1 = ds.Tables[0];
            //                DataTable dt2 = ds.Tables[1];


            //                //DataTable sort_dt1 = Check_Data(dt2, dt1);
            //                //sort_dt1.Columns["ITEM"].DataType = Type.GetType("System.Int32");

            //                //DataView view = sort_dt1.DefaultView;
            //                //view.Sort = "ITEM ASC";
            //                //sort_dt1 = view.ToTable();

            //                //dgvData1.DataSource = sort_dt1;
            //                dgvData1.DataSource = Check_Data(dt2, dt1);
            //                dgvData1.Columns["ITEM"].ValueType = typeof(int);
            //                dgvData1.Sort(this.dgvData1.Columns["ITEM"],
            //                        ListSortDirection.Ascending);

            //                //DataTable sort_dt2 = Check_Data(dt1, dt2);
            //                //sort_dt2.Columns["ITEM"].DataType = Type.GetType("System.Int32");

            //                //DataView view2 = sort_dt2.DefaultView;
            //                //view2.Sort = "ITEM ASC";
            //                //sort_dt2 = view2.ToTable();

            //                //dgvData2.DataSource = sort_dt2;
            //                dgvData2.DataSource = Check_Data(dt1, dt2);
            //                dgvData2.Columns["ITEM"].ValueType = typeof(int);
            //                dgvData2.Sort(this.dgvData2.Columns["ITEM"],
            //                        ListSortDirection.Ascending);
            //            }
            //            else
            //            {
            //                DataTable dt1 = new DataTable();
            //                for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
            //                {
            //                    dt1.Columns.Add(ds.Tables[0].Columns[i].ColumnName);
            //                }
            //                dt1.Columns["ITEM"].DataType = Type.GetType("System.Int32");

            //                dt1 = ds.Tables[0];

            //                DataView view = dt1.DefaultView;
            //                view.Sort = "ITEM ASC";
            //                dt1 = view.ToTable();

            //                DataTable dt2 = new DataTable();

            //                for (int i = 0; i < ds.Tables[1].Columns.Count; i++)
            //                {
            //                    dt2.Columns.Add(ds.Tables[1].Columns[i].ColumnName);
            //                }

            //                dt2.Columns["ITEM"].DataType = Type.GetType("System.Int32");

            //                dt2 = ds.Tables[1];

            //                DataView view2 = dt2.DefaultView;
            //                view2.Sort = "ITEM ASC";
            //                dt2 = view2.ToTable();

            //                //dgvData1.DataSource = dt1;
            //                //dgvData2.DataSource = dt2;

            //                dgvData1.DataSource = ds.Tables[0];
            //                dgvData1.Columns["ITEM"].ValueType = typeof(int);
            //                dgvData1.Sort(this.dgvData1.Columns["ITEM"],
            //                       ListSortDirection.Ascending);
            //                dgvData2.DataSource = ds.Tables[1];
            //                dgvData2.Columns["ITEM"].ValueType = typeof(int);
            //                dgvData2.Sort(this.dgvData2.Columns["ITEM"],
            //                       ListSortDirection.Ascending);
            //            }

            //            if (dgvData1.DataSource != null || dgvData1.Rows.Count > 0)
            //            {
            //                //string _counterType = this.Controller._counterType;
            //                //string reportTitle = this.Controller.SendReportTitle();
            //                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            //                CashControlReport_Excel frm = new CashControlReport_Excel();
            //                string bankDesp = Branch.BranchDescription;
            //                string address = Branch.Address;


            //                string result_Income_sheet1_3Line_Title = "GENERAL LEDGER";
            //                string result_Income_sheet1_4Line_Title = "RETURN OF GENERAL LEDGER BALANCE STATEMENT FOR THE MONTH OF ";
            //                string result_Income_sheet2_3Line_Title = "GENERAL LEDGER";
            //                string result_Income_sheet2_4Line_Title = "RETURN OF GENERAL LEDGER BALANCE STATEMENT FOR THE MONTH OF ";

            //                if (Income == "1")
            //                {
            //                    result_Income_sheet1_3Line_Title = bankDesp + " (" + address + ")";
            //                    result_Income_sheet1_4Line_Title = "INCOME ACCOUNT FOR THE MONTH OF " + DateTime.Now.ToString("MMMM").ToUpper() + " " + DateTime.Now.ToString("yyyy");
            //                    result_Income_sheet2_3Line_Title = bankDesp + " (" + address + ")";
            //                    result_Income_sheet2_4Line_Title = "EXPENDITURE ACCOUNT FOR THE MONTH OF " + DateTime.Now.ToString("MMMM").ToUpper() + " " + DateTime.Now.ToString("yyyy");
            //                }                            
            //                if (Income == "1")
            //                {
            //                    frm.ExportToExcel_Expenditure(dgvData1, dgvData2, "Income And Expenditure", bankDesp, address, result_Income_sheet1_3Line_Title, result_Income_sheet1_4Line_Title, result_Income_sheet2_3Line_Title, result_Income_sheet2_4Line_Title);
            //                }
            //                else
            //                {
            //                    frm.ExportToExcel_Expenditure(dgvData1, dgvData2, "General Ledger  Statement", bankDesp, address, result_Income_sheet1_3Line_Title, result_Income_sheet1_4Line_Title, result_Income_sheet2_3Line_Title, result_Income_sheet2_4Line_Title);
            //                }
            //            }
            //        }
            //        else
            //        {
            //            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME90033);//No Data for Report.
            //        }
            //    }
            //    catch (Exception ex)
            //    {

            //    }
            //}
        }

        private void rdoGeneralReturn_Click(object sender, EventArgs e)
        {
            if (rdoGeneralReturn.Checked == true)
                Income = "0";
            else
                Income = "1";
        }

        private void rdoIncomeAndExpenditure_Click(object sender, EventArgs e)
        {
            if (rdoIncomeAndExpenditure.Checked == true)
                Income = "1";
            else
                Income = "0";
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

        //private void rdoAllBranch_Click(object sender, EventArgs e)
        //{
        //    if (rdoAllBranch.Checked == true)
        //    {
        //        isAllBranch = "1";
        //        lblBranch.Visible = false;
        //        cboBranch.Visible = false;
        //    }
        //    else
        //    {
        //        isAllBranch = "0";
        //        lblBranch.Visible = true;
        //        cboBranch.Visible = true;
        //    }
        //}
        //private void rdoBranch_Click(object sender, EventArgs e)
        //{
        //    if (rdoBranch.Checked == true)
        //    {
        //        isAllBranch = "0";
        //        lblBranch.Visible = true;
        //        cboBranch.Visible = true;
        //    }
        //    else
        //    {
        //        isAllBranch = "1";
        //        lblBranch.Visible = false;
        //        cboBranch.Visible = false;
        //    }
        //}
        #endregion

        private void BindBranchCode()
        {
            IList<BranchDTO> branches = CXCLE00001.Instance.SelectAllBranch();
            cboBranchNo.ValueMember = "BranchCode";
            cboBranchNo.DisplayMember = "BranchCode";
            cboBranchNo.DataSource = branches;
            //cboBranchNo.SelectedIndex = -1;
        }

        private DataTable Check_Data(DataTable dt_Org, DataTable dt_Change)
        {
            for (int i = 0; i < dt_Org.Rows.Count; i++)
            {
                object[] row = new object[dt_Org.Columns.Count];
                //[Opening_bal],[Closing_bal],[Credit_Amount],[Debit_Amount]
                if(Convert.ToDouble(dt_Org.Rows[i]["Opening_bal"].ToString()) < 0)
                {
                    for (int j = 0; j < dt_Org.Columns.Count; j++)
                    {
                        row[i] = dt_Org.Rows[i][j].ToString();
                        dt_Org.Rows[i]["Opening_bal"] = "0";
                        dt_Org.Rows[i]["Closing_bal"] = "0";
                        dt_Org.Rows[i]["Credit_Amount"] = "0";
                        dt_Org.Rows[i]["Debit_Amount"] = "0";

                    }
                    dt_Change.Rows.Add(row);


                    continue;
                }
                else if (Convert.ToDouble(dt_Org.Rows[i]["Closing_bal"].ToString()) < 0)
                {
                    for (int j = 0; j < dt_Org.Columns.Count; j++)
                    {
                        row[i] = dt_Org.Rows[i][j].ToString();
                        dt_Org.Rows[i]["Opening_bal"] = "0";
                        dt_Org.Rows[i]["Closing_bal"] = "0";
                        dt_Org.Rows[i]["Credit_Amount"] = "0";
                        dt_Org.Rows[i]["Debit_Amount"] = "0";

                    }
                    dt_Change.Rows.Add(row);
                    continue;
                }
                else if (Convert.ToDouble(dt_Org.Rows[i]["Credit_Amount"].ToString()) < 0)
                {
                    for (int j = 0; j < dt_Org.Columns.Count; j++)
                    {
                        row[i] = dt_Org.Rows[i][j].ToString();
                        dt_Org.Rows[i]["Opening_bal"] = "0";
                        dt_Org.Rows[i]["Closing_bal"] = "0";
                        dt_Org.Rows[i]["Credit_Amount"] = "0";
                        dt_Org.Rows[i]["Debit_Amount"] = "0";

                    }
                    dt_Change.Rows.Add(row);
                    continue;
                }
                else if (Convert.ToDouble(dt_Org.Rows[i]["Debit_Amount"].ToString()) < 0)
                {
                    for (int j = 0; j < dt_Org.Columns.Count; j++)
                    {
                        row[i] = dt_Org.Rows[i][j].ToString();
                        dt_Org.Rows[i]["Opening_bal"] = "0";
                        dt_Org.Rows[i]["Closing_bal"] = "0";
                        dt_Org.Rows[i]["Credit_Amount"] = "0";
                        dt_Org.Rows[i]["Debit_Amount"] = "0";
                    }
                    dt_Change.Rows.Add(row);
                    continue;
                }
            }




            //DataSet dss = new DataSet();

            //dss.Tables.Add(dt1);
            //dss.Tables.Add(dt2);

            return dt_Change;
        }
        private void InitializedControls()
        {
            if (CurrentUserEntity.IsHOUser)
            {
                this.cboBranchNo.Visible = true;
                this.chkBranch.Visible = true;
                this.BindBranchCode();
            }
            else
            {
                this.lblBranchNo.Visible = true;
                this.lblBranchNo.Text = CurrentUserEntity.BranchCode + " (" + CurrentUserEntity.BranchDescription + ")";
            }
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.rdoIncomeAndExpenditure.Checked = true;
            this.dtpRequiredDate.Text = DateTime.Now.ToString("MMM/yyyy");
            Income = "1";
        }
    }

}
