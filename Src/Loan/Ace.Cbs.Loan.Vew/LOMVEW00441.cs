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
    public partial class LOMVEW00441 : BaseDockingForm, ILOMVEW00441
    {
        public string LNO = String.Empty;        
        public string termArray { get; set; }
        private ILOMCTL00441 controllerLateFeeInfo;
        List<LOMDTO00219> ListForBind;
        int ReadOnlyCount;
        bool IsAllRecordsReadOnly;

        public ILOMCTL00441 ControllerLateFeeInfo
        {
            set
            {
                this.controllerLateFeeInfo = value;
                this.controllerLateFeeInfo.View = this;
            }
            get
            {
                return this.controllerLateFeeInfo;
            }
        }

        public string AccountNo
        {
            get { return this.mtxtAcctNo.Text.Replace("-", "").Trim(); }
            set { this.mtxtAcctNo.Text = value; }
        }

        public string Name
        {
            get { return this.txtName.Text.ToString(); }
            set { this.txtName.Text = value; }
        }
        public string WorkingCompanyName
        {
            get { return this.txtWorkingCompanyName.Text.ToString(); }
            set { this.txtWorkingCompanyName.Text = value; }
        }

        private IList<LOMDTO00219> LateFeeInfoList { get; set; }
        private IList<LOMDTO00219> LateFeeInfoListToSave { get; set; }

        public LOMVEW00441()
        {
            InitializeComponent();
        }

        private void LOMVEW00441_Load(object sender, EventArgs e)
        {
            try
            {
                LOMDTO00427 userLists = this.ControllerLateFeeInfo.SelectUserMakerCheckerApproveByUserId();
                if (userLists != null)
                {
                    if (userLists.IsEntry == true)
                    {
                        InitializeControls();
                        this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
                        mtxtAcctNo.Select();
                    }
                    else
                    {
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI40002);//You do not have permission for this function.
                        EnableDisibleControls(false);
                        tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
                        txtName.Text = "";
                        mtxtAcctNo.Select();
                    }
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI40002);//You do not have permission for this function.
                    EnableDisibleControls(false);
                    tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
                    txtName.Text = "";
                    mtxtAcctNo.Select();
                }
            }
            catch (Exception ex)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI40002);//You do not have permission for this function.
                EnableDisibleControls(false);
                tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
                txtName.Text = "";
                mtxtAcctNo.Select();
            }
        }

        public void EnableDisibleControls(bool status)
        {
            this.mtxtAcctNo.Enabled = status;
        }

        //private void mtxtAcctNo_Leave(object sender, EventArgs e)
        //{
        //    if (this.mtxtAcctNo.Text.Replace("-", "").Trim() != "" || this.mtxtAcctNo.Text.Replace("-", "").Trim() != string.Empty || this.mtxtAcctNo.Text.Replace("-", "").Trim().Length > 6)
        //    {
        //        GetLateFeeInfo();
        //        if (CheckSelectedData() == false) btnSelectAll.Text = "Select All";
        //        this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
        //    }
        //}

        private void mtxtAcctNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                GetLateFeeInfo();
                if (CheckSelectedData() == false) btnSelectAll.Text = "Select All";
                this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            }
        }

        private void mtxtAcctNo_Enter(object sender, EventArgs e)
        {
            if (this.mtxtAcctNo.Text.Replace("-", "").Trim() != "" || this.mtxtAcctNo.Text.Replace("-", "").Trim() != string.Empty || this.mtxtAcctNo.Text.Replace("-", "").Trim().Length > 6)
            {
                GetLateFeeInfo();
                if (CheckSelectedData() == false) btnSelectAll.Text = "Select All";
                this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            }
        }

        public void GetLateFeeInfo()
        {
            string SourceBr = CurrentUserEntity.BranchCode, Currency = "";
            this.AccountNo = mtxtAcctNo.Text.Replace("-", "").Trim();
            
            //this.txtName.Text = "";
            LateFeeInfoList = null;
            dgvLateFeeInfo.DataSource = LateFeeInfoList;
            dgvLateFeeInfo.Refresh();
            LateFeeInfoList = ControllerLateFeeInfo.GetLateFeeInfoByACNo(this.AccountNo,SourceBr);
            ListForBind = new List<LOMDTO00219>();
            if (LateFeeInfoList.Count > 0)
            {
                foreach (LOMDTO00219 latefeeInfo in LateFeeInfoList)
                {
                    txtName.Text = latefeeInfo.NAME.ToString();
                    txtWorkingCompanyName.Text = latefeeInfo.CompanyName.ToString();
                    LNO = latefeeInfo.Lno.ToString();
                    Currency = latefeeInfo.Cur.ToString();
                }

                foreach (DataGridViewColumn col in dgvLateFeeInfo.Columns)
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                BindDataGrid(LateFeeInfoList);
                dgvLateFeeInfo.Refresh();
                
            }
            else
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90232); //No OD and Late Fee Information!
                //ShowMessageByCode(CXMessage.MV90231);//No late fee for this account!                
            }

        }

        private DataTable CreateDataForGrid()
        {
            DataTable table = new DataTable("dtLateFeeInfo");
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
            table.Columns.Add("Status", typeof(bool));
            return table;
        }

        private void BindDataGrid(IList<LOMDTO00219> LateFeeInfoData)
        {
            DataTable table = CreateDataForGrid();
            
            foreach (LOMDTO00219 item in LateFeeInfoData)
            {
                //table.Rows.Add(item.TermNo, item.ODAmount.ToString("#,0.00"), item.LateDays, item.TotalLateFeesAmt.ToString("#,0.00"), false);
                table.Rows.Add(item.TermNo, item.Principal_TOD.ToString("#,0.00"), item.Interest_TOD.ToString("#,0.00"), item.ODAmount.ToString("#,0.00"),
                    item.LateDays,
                    item.TotalLateFee_PTOD_OnIntRate.ToString("#,0.00"), Convert.ToBoolean(item.ReadOnlyFlag_P_Int),
                    item.TotalLateFee_PTOD_OnLateFeeRate.ToString("#,0.00"), Convert.ToBoolean(item.ReadOnlyFlag_P_Late),
                    item.TotalLateFee_ITOD_OnLateFeeRate.ToString("#,0.00"), Convert.ToBoolean(item.ReadOnlyFlag_I_Late),
                    item.TotalLateFeesAmt.ToString("#,0.00"), Convert.ToBoolean(item.ReadOnlyFlag_Total), Convert.ToBoolean(item.ReadOnlyFlag));
            }

            this.dgvLateFeeInfo.AutoGenerateColumns = false;
            this.dgvLateFeeInfo.DataSource = table;

            //InitializeDatGridView(false);

            //setting read only property
            ReadOnlyCount = 0;
            for (int index = 0; index < dgvLateFeeInfo.Rows.Count; index++)
            {
               // dgvLateFeeInfo.Rows[index].Cells["Status"].Value = Convert.ToBoolean(dgvLateFeeInfo.Rows[index].Cells["Status"].Value) == true ? false : true;      //Cells["colSelect"]

                if (Convert.ToBoolean(this.dgvLateFeeInfo.Rows[index].Cells["Status"].Value))
                {
                    this.dgvLateFeeInfo.Rows[index].ReadOnly = true;
                    this.dgvLateFeeInfo.Rows[index].DefaultCellStyle.BackColor = Color.LightGray;
                    ReadOnlyCount = ReadOnlyCount + 1;
                }
            }
            #region Added by HMW at 06-Sept-20111 : Not to Change "Select All" button description when all grid records are readonly
            IsAllRecordsReadOnly = false;
            if (dgvLateFeeInfo.Rows.Count == ReadOnlyCount)
                IsAllRecordsReadOnly = true;
            #endregion

            ReDesignDataGrid();

            this.dgvLateFeeInfo.Refresh();
        }

        private void ReDesignDataGrid()
        {
            //Programmatically redesign DataGrid
            if (dgvLateFeeInfo.Rows.Count > 0)
            {
                this.dgvLateFeeInfo.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; 
                this.dgvLateFeeInfo.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvLateFeeInfo.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvLateFeeInfo.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; 
                this.dgvLateFeeInfo.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvLateFeeInfo.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; 
            }
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            InitializeControls();
            this.dgvLateFeeInfo.DataSource = CreateDataForGrid();
            this.dgvLateFeeInfo.Refresh();
            mtxtAcctNo.Select();
        }

        public void InitializeControls()
        {
            this.mtxtAcctNo.Text = "";
            this.mtxtAcctNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            this.txtName.Text = "";
            this.txtWorkingCompanyName.Text = "";
            this.LateFeeInfoList = null;
            this.LateFeeInfoListToSave = null;
            this.dgvLateFeeInfo.DataSource = null;
            this.dgvLateFeeInfo.Refresh();
            this.btnSelectAll.Text = "Select All";
            mtxtAcctNo.Select();
        }

        private bool CheckSelectedData()
        {
            bool checkdata = false;
            if (this.dgvLateFeeInfo.Rows.Count > 0)
            {
                for (int i = 0; i < dgvLateFeeInfo.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dgvLateFeeInfo.Rows[i].Cells[7].Value) || Convert.ToBoolean(dgvLateFeeInfo.Rows[i].Cells[9].Value) || Convert.ToBoolean(dgvLateFeeInfo.Rows[i].Cells[11].Value) || Convert.ToBoolean(dgvLateFeeInfo.Rows[i].Cells[13].Value))
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
            termArray = "";

            GetDataGridViewSelectedID();
            if (mtxtAcctNo.Text.Replace("-", "").Trim() != string.Empty && mtxtAcctNo.Text.Replace("-", "").Trim() != "")
            {
                if (CheckSelectedData() == false)
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00025);  //No Data to Save.
                    mtxtAcctNo.Select();
                    return;
                }

                string result = this.ControllerLateFeeInfo.SaveLateFeeExceptionInfo(LateFeeInfoListToSave);
                if (result == "0000")
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90001);//Saving Successful.
                    InitializeControls();
                    this.dgvLateFeeInfo.DataSource = CreateDataForGrid();
                    ReDesignDataGrid();
                    this.dgvLateFeeInfo.Refresh();
                    mtxtAcctNo.Select();

                    if(mtxtAcctNo.Text=="")
                        this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME00072);//Process Fail!
                    InitializeControls();
                    this.dgvLateFeeInfo.DataSource = CreateDataForGrid();
                    this.dgvLateFeeInfo.Refresh();
                    mtxtAcctNo.Select();
                }
            }
            else
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00046);//Invalid Account No.
                InitializeControls();
                mtxtAcctNo.Text = "";
                mtxtAcctNo.Select();
            }

        }

        public void InitializeDatGridView(bool select)
        {
            if(dgvLateFeeInfo.Rows.Count > 0)
            {
                for (int i = 0; i < dgvLateFeeInfo.Rows.Count; i++)
                {
                    if (dgvLateFeeInfo.Rows[i].ReadOnly != true)
                        dgvLateFeeInfo.Rows[i].Cells["colSelect"].Value = select; //Cells["colSelect"]

                    if (Convert.ToBoolean(dgvLateFeeInfo.Rows[i].Cells["colSelect"].Value))
                    {
                        if (Convert.ToDecimal(dgvLateFeeInfo.Rows[i].Cells["colTotalLateFeesAmount"].Value) > 0 && Convert.ToDecimal(dgvLateFeeInfo.Rows[i].Cells["colTotalLateFee_PTOD_OnIntRate"].Value) == 0 && Convert.ToDecimal(dgvLateFeeInfo.Rows[i].Cells["colTotalLateFee_PTOD_OnLateFeeRate"].Value) == 0 && Convert.ToDecimal(dgvLateFeeInfo.Rows[i].Cells["colTotalLateFee_ITOD_OnLateFeeRate"].Value) == 0)
                        {
                            dgvLateFeeInfo.Rows[i].Cells["colSelect_P_Int"].Value = false;
                            dgvLateFeeInfo.Rows[i].Cells["colSelect_P_Late"].Value = false;
                            dgvLateFeeInfo.Rows[i].Cells["colSelect_I_Late"].Value = false;                         
                        }
                        else 
                        {
                            dgvLateFeeInfo.Rows[i].Cells["colSelect_P_Int"].Value = true;
                            dgvLateFeeInfo.Rows[i].Cells["colSelect_P_Late"].Value = true;
                            dgvLateFeeInfo.Rows[i].Cells["colSelect_I_Late"].Value = true;
                        }


                    }
                    else
                    {
                        dgvLateFeeInfo.Rows[i].Cells["colSelect_P_Int"].Value = false;
                        dgvLateFeeInfo.Rows[i].Cells["colSelect_P_Late"].Value = false;
                        dgvLateFeeInfo.Rows[i].Cells["colSelect_I_Late"].Value = false;

                    }
                }
            }
        }

        public void GetDataGridViewSelectedID()
        {
            LateFeeInfoListToSave = new List<LOMDTO00219>();
            for (int i = 0; i < dgvLateFeeInfo.Rows.Count; i++)
            {

                if (!Convert.ToBoolean(this.dgvLateFeeInfo.Rows[i].Cells["Status"].Value))
                {
                    bool isCellChecked = false;

                    if (Convert.ToBoolean(dgvLateFeeInfo.Rows[i].Cells[7].Value) || Convert.ToBoolean(dgvLateFeeInfo.Rows[i].Cells[9].Value) || Convert.ToBoolean(dgvLateFeeInfo.Rows[i].Cells[11].Value) || Convert.ToBoolean(dgvLateFeeInfo.Rows[i].Cells[13].Value))
                        isCellChecked = true;
                    else
                        isCellChecked = false;

                    if (isCellChecked)
                    {
                        //save data here
                        LOMDTO00219 arr0 = new LOMDTO00219();
                        arr0.TermNo = Convert.ToInt16(dgvLateFeeInfo.Rows[i].Cells[1].Value.ToString()); //Cells["colPaymentTermNo"]
                        arr0.ODAmount = Convert.ToDecimal(dgvLateFeeInfo.Rows[i].Cells[2].Value); //Cells["colODAmount"]
                        arr0.LateDays = Convert.ToInt32(dgvLateFeeInfo.Rows[i].Cells[5].Value); //Cells["colTotalLateDays"]
                        //arr0.TotalLateFeesAmt = Convert.ToDecimal(dgvLateFeeInfo.Rows[i].Cells[12].Value); //Cells["colTotalLateFeesAmount"]
                        arr0.Acctno = this.mtxtAcctNo.Text.Replace("-", "").Trim();
                        arr0.Lno = LNO;
                        arr0.Cur = "KYT";

                        arr0.Interest_PTOD_Status = Convert.ToBoolean(dgvLateFeeInfo.Rows[i].Cells[7].Value);
                        arr0.LateFee_PTOD_Status = Convert.ToBoolean(dgvLateFeeInfo.Rows[i].Cells[9].Value);
                        arr0.LateFee_ITOD_Status = Convert.ToBoolean(dgvLateFeeInfo.Rows[i].Cells[11].Value);
                        arr0.TotalLateFee_Status = Convert.ToBoolean(dgvLateFeeInfo.Rows[i].Cells[13].Value);

                        arr0.SourceBr = CurrentUserEntity.BranchCode;
                        arr0.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                        LateFeeInfoListToSave.Add(arr0);
                    }
                }
            }
            
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (btnSelectAll.Text == "Select All" && IsAllRecordsReadOnly == false)
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

        private void dgvLateFeeInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1))
                return;

            dgvLateFeeInfo.Refresh();

            DataGridViewRow dataRow = (DataGridViewRow)dgvLateFeeInfo.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];


            if (cell.OwningColumn != null)
            {
                if (Convert.ToBoolean( dataRow.Cells["colSelect"].Value))
                {
                   if( Convert.ToDecimal( dataRow.Cells["colTotalLateFeesAmount"].Value)>0 && Convert.ToDecimal( dataRow.Cells["colTotalLateFee_PTOD_OnIntRate"].Value)==0 &&  Convert.ToDecimal( dataRow.Cells["colTotalLateFee_PTOD_OnLateFeeRate"].Value) == 0   &&  Convert.ToDecimal( dataRow.Cells["colTotalLateFee_ITOD_OnLateFeeRate"].Value)== 0 )
                   {
                        dataRow.Cells["colSelect_P_Int"].Value=false;
                        dataRow.Cells["colSelect_P_Late"].Value =false;
                        dataRow.Cells["colSelect_I_Late"].Value=false;
                        dataRow.Cells["colSelect"].Selected=true;
                   }
                   else if (Convert.ToBoolean(dataRow.Cells["colSelect_P_Int"].Value)==false && Convert.ToBoolean(dataRow.Cells["colSelect_P_Late"].Value)==false  && Convert.ToBoolean(dataRow.Cells["colSelect_I_Late"].Value)==false)
                   {
                       dataRow.Cells["colSelect_P_Int"].Value = true;
                       dataRow.Cells["colSelect_P_Late"].Value = true;
                       dataRow.Cells["colSelect_I_Late"].Value = true;
                   }
                   else if (Convert.ToBoolean(dataRow.Cells["colSelect_P_Int"].Value) == false || Convert.ToBoolean(dataRow.Cells["colSelect_P_Late"].Value) == false || Convert.ToBoolean(dataRow.Cells["colSelect_I_Late"].Value) == false)
                       dataRow.Cells["colSelect"].Value = false;
                    
                }
                else
                {
                    if (e.ColumnIndex == 7 || e.ColumnIndex == 9 || e.ColumnIndex==11)
                    {
                        if (Convert.ToBoolean(dataRow.Cells["colSelect_P_Int"].Value) && Convert.ToBoolean(dataRow.Cells["colSelect_P_Late"].Value) && Convert.ToBoolean(dataRow.Cells["colSelect_I_Late"].Value))
                            dataRow.Cells["colSelect"].Value = true;
                    }
                    else if (e.ColumnIndex == 13)
                    {
                        if (Convert.ToBoolean(dataRow.Cells["colSelect_P_Int"].Value) && Convert.ToBoolean(dataRow.Cells["colSelect_P_Late"].Value) && Convert.ToBoolean(dataRow.Cells["colSelect_I_Late"].Value))
                        {
                            dataRow.Cells["colSelect_P_Int"].Value = false;
                            dataRow.Cells["colSelect_P_Late"].Value = false;
                            dataRow.Cells["colSelect_I_Late"].Value = false;
                        }
                    }

                }

            }

            dgvLateFeeInfo.RefreshEdit();
            dgvLateFeeInfo.Refresh();
            
        }

        private void dgvLateFeeInfo_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvLateFeeInfo.IsCurrentCellDirty)
                dgvLateFeeInfo.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

       
    }
}
