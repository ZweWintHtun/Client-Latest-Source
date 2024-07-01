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
using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00437 : BaseDockingForm, ILOMVEW00437
    {
        #region Properties
        private IList<LOMDTO00429> ApproveRejectList { get; set; }
        private IList<LOMDTO00429> WarningListsData { get; set; }
        public string idArray { get; set; }
        public string remove { get; set; }
        #endregion

        #region Constructors
        public LOMVEW00437()
        {
            InitializeComponent();
        }
        private ILOMCTL00437 controller;
        public ILOMCTL00437 Controller
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
        #endregion

        #region Events

        private void btnRemove_Click(object sender, EventArgs e)
        {
            GetDatGridViewSelectedID();
            remove = "1"; // Approve
            string result = this.Controller.SaveWarningListsRemove();
            if (result == "000")
            {
                //CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90218);//Black List Customer Remove Successfully!
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90144);//Warning List Customer Remove Successfully!
                InitializeControls();
            }
            else if (result == "111")
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90021);//Invalid User!
                InitializeControls();
            }

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LOMVEW00437_Load(object sender, EventArgs e)
        {
            try
            {
                LOMDTO00427 userLists = this.Controller.SelectUserMakerCheckerApproveByUserId();
                if (userLists != null)
                {
                    if (userLists.IsApprove == true)
                    {
                        InitializeControls();
                        EnableDisibleControls(true);
                    }
                    else
                    {
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI40002);//You do not have permission for this function.
                        EnableDisibleControls(false);
                        dgvData.DataSource = null;
                    }
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI40002);//You do not have permission for this function.
                    EnableDisibleControls(false);
                    dgvData.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI40002);//You do not have permission for this function.
                EnableDisibleControls(false);
                dgvData.DataSource = null;
            }
        }
        #endregion

        #region  Helper Methods

        public void EnableDisibleControls(bool status)
        {
            dgvData.Enabled = status;
            btnRemove.Enabled = status;
        }
        public void InitializeControls()
        {
            foreach (DataGridViewColumn col in dgvData.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dgvData.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvData.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvData.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvData.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvData.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvData.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            idArray = "";
            WarningListsData = this.Controller.SelectAllWarningListsForRemove();
            BindDataGrid(WarningListsData);
            dgvData.Refresh();
        }
        public void GetDatGridViewSelectedID()
        {
            for (int i = 0; i < dgvData.Rows.Count; i++)
            {
                bool isCellChecked = (bool)dgvData.Rows[i].Cells[11].Value;
                if (isCellChecked == true)
                {
                    if (idArray != "")
                    {
                        idArray += "<;>";
                    }
                    idArray += dgvData.Rows[i].Cells[1].Value;///("colId");
                }
                //else
                //{ // Selection remove 
                //    if (idArray.Equals(dgvData.Rows[i].Cells[1].Value))
                //    {
                //        idArray.Replace(dgvData.Rows[i].Cells[1].Value + "<;>", "");
                //    }
                //}
            }
        }

        private string GenerateMultipleLines(string str)
        {
            string[] field = str.Split(',');
            string result = "";
            if (field.Length == 0)
                return result;
            result = field[0];
            for (int i = 1; i < field.Length; i++)
            {
                result += Environment.NewLine + field[i].Trim();
            }
            return result;


        }
        private string GenerateMultipleLinesForAddress(string str)
        {
            string[] field = str.Split(';');
            string result = "";
            if (field.Length == 0)
                return result;
            result = field[0];
            for (int i = 1; i < field.Length; i++)
            {
                result += Environment.NewLine + field[i].Trim();
            }
            return result;
        }
        private void BindDataGrid(IList<LOMDTO00429> BlackListsData)
        {
            ApproveRejectList = new List<LOMDTO00429>();

            foreach (LOMDTO00429 item in BlackListsData)
            {
                LOMDTO00429 arr0 = new LOMDTO00429();

                arr0.Id = item.Id;
                arr0.No = item.No; //curcontrol acctno
                arr0.AccountNo = item.AccountNo;
                arr0.Name = GenerateMultipleLines(item.Name);
                arr0.NRC = GenerateMultipleLines(item.NRC);
                arr0.FatherName = GenerateMultipleLines(item.FatherName);
                arr0.Address = GenerateMultipleLinesForAddress(item.Address);
                arr0.CompanyName = item.CompanyName;
                arr0.ACSign = item.ACSign;
                arr0.AbsentTerm = item.AbsentTerm;
                arr0.CreatedDate = item.CreatedDate;
                arr0.UserName = item.UserName;

                ApproveRejectList.Add(arr0);
            }

            this.dgvData.DataSource = ApproveRejectList;
            this.dgvData.Refresh();
        }
        #endregion
        
    }
}
