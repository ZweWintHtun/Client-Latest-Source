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
    public partial class LOMVEW00433 : BaseDockingForm,ILOMVEW00433
    {
        #region Constructor
        public LOMVEW00433()
        {
            InitializeComponent();
        }
        private ILOMCTL00433 controller;
        public ILOMCTL00433 Controller
        {
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
            get { return this.controller; }
        }
        #endregion

        #region Properties 
        public string UserName
        {
            get
            {
                if (this.cboUser.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cboUser.SelectedValue.ToString();
                }
            }
            set { this.cboUser.SelectedValue = value; }
        }
        public string ApproveType { get; set; } //1 => Entry , 2 => Approve , 3=> Both
        private IList<LOMDTO00433> UserList { get; set; }
        public string idArray { get; set; }
        public string userIdArray { get; set; }

        #endregion

        #region Events
        private void LOMVEW00433_Load(object sender, EventArgs e)
        {
            tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            InitializeControls();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            InitializeControls();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            GetDatGridViewSelectedID();
            if (idArray != string.Empty && idArray != "null")
            {
                string result = this.Controller.DeleteBlackListUser();
                if (result == "000")
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90222);//Black List Maker Checker User Delete Successful!
                    InitializeControls();
                }
                else if (result == "111")
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90021);//Invalid User!
                    InitializeControls();
                }
            }
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            if (cboUser.Text == "null" || cboUser.Text == string.Empty)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90011);//User Name is required.
                cboUser.Focus();
            }
            else
            {
                string result = this.Controller.SaveBlackListUser();
                if (result == "000")
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90221);//Black List Maker Checker User Entry Successful!
                    InitializeControls();
                }
                else if (result == "111")
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90021);//Invalid User!
                    InitializeControls();
                }
                else if (result == "222")
                {
                    //Data Already Exist.
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90001);//Data Already Exist.
                    InitializeControls();
                }
            }
        }
        private void OptEntryUser_CheckedChanged(object sender, EventArgs e)
        {
            if (OptEntryUser.Checked == true)
            {
                rdoCheckChange();
            }
        }

        private void OptApproveUser_CheckedChanged(object sender, EventArgs e)
        {
            if (OptApproveUser.Checked == true)
            {
                rdoCheckChange();
            }
        }

        private void optBoth_CheckedChanged(object sender, EventArgs e)
        {
            if (optBoth.Checked == true)
            {
                rdoCheckChange();
            }
        }
        #endregion

        #region Helper Methods
        public void GetDatGridViewSelectedID()
        {
            for (int i = 0; i < dgvUser.Rows.Count; i++)
            {
                bool isCellChecked = (bool)dgvUser.Rows[i].Cells[0].Value;
                if (isCellChecked == true)
                {
                    if (idArray != "")
                    {
                        idArray += "<;>";
                    }
                    idArray += dgvUser.Rows[i].Cells[1].Value;///("colId");
                }
            }
            if (idArray == "" || idArray == string.Empty || idArray == null)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90012);//Please select at least one record!
                dgvUser.Focus();
                return;

            }
        }
        private void InitializeControls()
        {
            idArray = "";
            this.cboUser.SelectedValue = "";
            BindUser();
            optBoth.Checked = false;
            OptEntryUser.Checked = true;
            ApproveType = "1";
            OptApproveUser.Checked = false;
            BindBlackListApproverDataGrid();
        }
        private void BindUser()
        {
            IList<LOMDTO00427> UserLists= this.Controller.BindUser();

            this.cboUser.ValueMember = "Id";
            this.cboUser.DisplayMember = "UserName";
            this.cboUser.DataSource = UserLists;
            this.cboUser.SelectedIndex = -1;
        }
        private void BindBlackListApproverDataGrid()
        {
            IList<LOMDTO00427> BindBlackListApproverLists = this.Controller.BindBlackListApprover();
            UserList = new List<LOMDTO00433>();

            foreach (LOMDTO00427 item in BindBlackListApproverLists)
            {
                LOMDTO00433 arr = new LOMDTO00433();

                arr.No = item.No;
                arr.UserName = item.UserName;
                arr.UserType = item.UserType;
                arr.Id = item.Id;

                UserList.Add(arr);
            }
            this.dgvUser.DataSource = UserList;
            this.dgvUser.Refresh();
        }
        public void rdoCheckChange()
        {
            if (OptEntryUser.Checked == true)
            {
                OptApproveUser.Checked = false;
                optBoth.Checked = false;
                this.ApproveType = "1";
            }

            if (OptApproveUser.Checked == true)
            {
                OptEntryUser.Checked = false;
                optBoth.Checked = false;
                this.ApproveType = "2";
            }

            if (optBoth.Checked == true)
            {
                OptEntryUser.Checked = false;
                OptApproveUser.Checked = false;
                this.ApproveType = "3";
            }
        }
        #endregion

      
    }
}
