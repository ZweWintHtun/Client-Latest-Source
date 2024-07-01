using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Windows.CXClient;
using Ace.Windows.Core.Utt;


namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00442 : BaseDockingForm, ILOMVEW00442
    {
        private IList<LOMDTO00219> LateFeeInfoList { get; set; }
        private IList<LOMDTO00219> LateFeeInfoListSelected { get; set; }
        public string termArray { get; set; }
        private ILOMCTL00442 controller;
        public ILOMCTL00442 Controller
        {
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
            get
            {
                return this.controller;
            }
        }

        public LOMVEW00442()
        {
            InitializeComponent();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        public void GetDataGridViewSelectedID()
        {
            LateFeeInfoListSelected = new List<LOMDTO00219>();
            if (dgvLateFeeInfo.Rows.Count > 0)
            {
                for (int i = 0; i < dgvLateFeeInfo.Rows.Count; i++)
                {
                    //Cells[8] = "colSelect"
                    bool isCellChecked = dgvLateFeeInfo.Rows[i].Cells[17].Value.ToString().ToLower() == "false" || dgvLateFeeInfo.Rows[i].Cells[17].Value.ToString() == "null" ? false : true;
                    if (isCellChecked == true)
                    {
                        //save data here
                        LOMDTO00219 arr0 = new LOMDTO00219();
                        arr0.Acctno = dgvLateFeeInfo.Rows[i].Cells[1].Value.ToString(); //Acctno
                        arr0.TermNo = Convert.ToInt16(dgvLateFeeInfo.Rows[i].Cells[4].Value.ToString()); //Term
                        arr0.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                        LateFeeInfoListSelected.Add(arr0);
                    }
                }
            }
        }

        private bool CheckSelectedData()
        {
            bool checkdata = false;
            if (this.dgvLateFeeInfo.Rows.Count > 0)
            {
                for (int i = 0; i < dgvLateFeeInfo.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dgvLateFeeInfo.Rows[i].Cells[17].Value) == true)
                    {
                        checkdata = true;
                        break;
                    }
                }
            }
            return checkdata;
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            //string result = this.ControllerLateFeeInfo.SaveLateFeeExceptionInfo(LateFeeInfoListToSave);
            if (CheckSelectedData() == false)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00025);  //No Data to Save.
                InitializeControls();
                BindLateFeeInfoForChecker();
                this.dgvLateFeeInfo.Refresh();
                return;
            }

            if (CXUIMessageUtilities.ShowMessageByCode("MC00023") == DialogResult.Yes)//Are you sure to approve?
            {
                GetDataGridViewSelectedID();

                string result = this.Controller.UpdateLateFeeExceptionInfo(LateFeeInfoListSelected, "A"); //A - Approve
                if (result == "0000")
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90145);  //Approve Successfully!
                    InitializeControls();
                    //this.dgvLateFeeInfo.DataSource = CreateDataForGrid();
                    BindLateFeeInfoForChecker();
                    this.dgvLateFeeInfo.Refresh();

                    if (dgvLateFeeInfo.RowCount == 0)//Added by HMW (06-Sept-2019)
                        this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90163);//Process Fail!
                    InitializeControls();
                    //this.dgvLateFeeInfo.DataSource = CreateDataForGrid();
                    BindLateFeeInfoForChecker();
                    this.dgvLateFeeInfo.Refresh();
                }
            }
        }

        public void InitializeControls()
        {
            this.dgvLateFeeInfo.DataSource = null;
            this.dgvLateFeeInfo.Refresh();
            this.btnSelectAll.Text = "Select All";
        }

        public void InitializeDatGridView(bool select)
        {
            if (dgvLateFeeInfo.Rows.Count > 0)
            {
                for (int i = 0; i < dgvLateFeeInfo.Rows.Count; i++)
                {
                    dgvLateFeeInfo.Rows[i].Cells[17].Value = select; //Cells["colSelect"]
                }
            }
        }

        private DataTable CreateDataForGrid()
        {
            DataTable table = new DataTable("dtLateFeeInfo");
            table.Columns.Add("Account No", typeof(string));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Working Company Name", typeof(string));
            table.Columns.Add("Payment Term No", typeof(string));
            table.Columns.Add("Principal_TOD", typeof(string));
            table.Columns.Add("Interest_TOD", typeof(string));
            table.Columns.Add("OD Amount", typeof(string));
            table.Columns.Add("Total Late Days", typeof(int));
            table.Columns.Add("TotalLateFee_PTOD_OnIntRate", typeof(string));
            table.Columns.Add("Select_P_Int", typeof(bool));
            table.Columns.Add("TotalLateFee_PTOD_OnLateFeeRate", typeof(string));
            table.Columns.Add("Select_P_Late", typeof(bool));
            table.Columns.Add("TotalLateFee_ITOD_OnLateFeeRate", typeof(string));
            table.Columns.Add("Select_I_Late", typeof(bool));
            table.Columns.Add("Total Late Fees Amount", typeof(string));
            table.Columns.Add("Select", typeof(bool));
            table.Columns.Add("Approve", typeof(bool));
            ////table.Columns.Add("Status", typeof(bool));
            return table;
        }


        private void BindDataGrid(IList<LOMDTO00219> LateFeeInfoData)
        {
            DataTable table = CreateDataForGrid();

            foreach (LOMDTO00219 item in LateFeeInfoData)
            {
                table.Rows.Add(item.Acctno, item.NAME, item.CompanyName, item.TermNo,
                    item.Principal_TOD.ToString("#,0.00"), item.Interest_TOD.ToString("#,0.00"), item.ODAmount.ToString("#,0.00"),
                    item.LateDays,
                    item.TotalLateFee_PTOD_OnIntRate.ToString("#,0.00"), Convert.ToBoolean(item.Interest_PTOD_Status),
                    item.TotalLateFee_PTOD_OnLateFeeRate.ToString("#,0.00"), Convert.ToBoolean(item.LateFee_PTOD_Status),
                    item.TotalLateFee_ITOD_OnLateFeeRate.ToString("#,0.00"), Convert.ToBoolean(item.LateFee_ITOD_Status),
                    item.TotalLateFeesAmt.ToString("#,0.00"), Convert.ToBoolean(item.TotalLateFee_Status), false);
                    //item.TotalLateFeesAmt.ToString("#,0.00"), false);            

            }
            this.dgvLateFeeInfo.AutoGenerateColumns = false;
            this.dgvLateFeeInfo.DataSource = table;

            //Programmatically redesign DataGrid
            if (dgvLateFeeInfo.Rows.Count > 0)
            {
                this.dgvLateFeeInfo.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvLateFeeInfo.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvLateFeeInfo.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvLateFeeInfo.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvLateFeeInfo.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvLateFeeInfo.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvLateFeeInfo.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; 
            }

            InitializeDatGridView(false);
            this.dgvLateFeeInfo.Refresh();
        }

        private void BindLateFeeInfoForChecker()
        {
            LateFeeInfoList = Controller.GetLateFeeInfoAllForChecker();
            //dgvLateFeeInfo.DataSource = LateFeeInfoList;
            BindDataGrid(LateFeeInfoList);
        }

        private void LOMVEW00442_Load(object sender, EventArgs e)
        {
            try
            {
                LOMDTO00427 userLists = this.Controller.SelectUserMakerCheckerApproveByUserId();
                if (userLists != null)
                {
                    if (userLists.IsApprove == true)
                    {
                        InitializeControls();
                        BindLateFeeInfoForChecker();
                        if(dgvLateFeeInfo.RowCount==0)//Added by HMW (06-Sept-2019)
                            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
                        else
                            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
                    }
                    else
                    {
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI40002);//You do not have permission for this function.
                        tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
                    }
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI40002);//You do not have permission for this function.
                    tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
                }
            }
            catch (Exception ex)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI40002);//You do not have permission for this function.
                tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (btnSelectAll.Text == "Select All" && dgvLateFeeInfo.RowCount>0)
            {
                btnSelectAll.Text = "Unselect All";
                InitializeDatGridView(true);
            }
            else
            {
                btnSelectAll.Text = "Select All";
                InitializeDatGridView(false);
            }
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            //if (btnSelectAll.Text == "Select All")
            //{
            //    btnSelectAll.Text = "Unselect All";
            //    InitializeDatGridView(true);
            //}
            //else
            //{
                btnSelectAll.Text = "Select All";
                InitializeDatGridView(false);
            //}
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            if (CheckSelectedData() == false)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00025);  //No Data to Save.
                return;
            }

            if (CXUIMessageUtilities.ShowMessageByCode("MC00024") == DialogResult.Yes)//Are you sure to reject?
            {
                GetDataGridViewSelectedID();

                string result = this.Controller.UpdateLateFeeExceptionInfo(LateFeeInfoListSelected, "R"); //R - Reject
                if (result == "0000")
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90146);  //Reject Successfully!
                    InitializeControls();
                    //this.dgvLateFeeInfo.DataSource = CreateDataForGrid();
                    BindLateFeeInfoForChecker();
                    this.dgvLateFeeInfo.Refresh();

                    if (dgvLateFeeInfo.RowCount == 0)//Added by HMW (06-Sept-2019)
                        this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90163);//Process Fail!
                    InitializeControls();
                    this.dgvLateFeeInfo.DataSource = CreateDataForGrid();
                    this.dgvLateFeeInfo.Refresh();
                }
            }
        }

        private void dgvLateFeeInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
