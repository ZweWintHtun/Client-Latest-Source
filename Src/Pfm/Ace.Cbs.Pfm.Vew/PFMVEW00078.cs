using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Pfm.Ctr.PTR;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.DataModel;
using Ace.Cbs.Sam.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Pfm.Vew
{
    public partial class frmPFMVEW00078 : BaseDockingForm, IPFMVEW00078
    {
        public frmPFMVEW00078()
        {
            InitializeComponent();
        }
        /* For Combo Data Bind */
        public IList<StateDTO> StateCodeList { get; set; }//For State Code Combo
        public IList<SAMDTO00054> NRCCodes { get; set; }//For NRC Code Combo
        public IList<LOMDTO00070> VillageCodeList { get; set; }// For Village Code Combo
        public IList<SAMDTO00054> NRCCodeList { get; set; }//For FormLoad
        private int editId = 0;
        private IList<int> deleteList = new List<int>();
        public bool IsInitialStateForNRC { get; set; }
        public static bool flag = false;

        private int _id;
        public int Id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        public string GroupNo
        {
            get { return this.txtGroupNo.Text; }
            set { this.txtGroupNo.Text = value; }
        }

        public string NameOnly
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }
        }

        public bool IsNRC
        {
            get { return this.rdoNRC.Checked; }
            set { this.rdoNRC.Checked = value; }
        }

        public string NRCNo
        {
            get { return this.txtNRCNo.Text; }
            set { this.txtNRCNo.Text = value; }
        }

        public string NationalityCodeForNRC
        {
            get
            {
                if (this.cboNationalityCode.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return cboNationalityCode.SelectedValue.ToString();
                }
            }
            set
            {
                cboNationalityCode.SelectedValue = value;
            }
        }

        public string TownshipCodeForNRC
        {
            get
            {
                if (this.cboTownshipCode.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return cboTownshipCode.SelectedValue.ToString();
                }
            }
            set
            {
                cboTownshipCode.SelectedValue = value;
            }
        }

        public string StateCodeForNRC
        {
            get
            {
                if (this.cboStateCode.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return cboStateCode.SelectedValue.ToString();
                }
            }
            set
            {
                cboStateCode.SelectedValue = value;
            }
        }

        public string other
        {
            get { return this.txtNRC.Text; }
            set { this.txtNRC.Text = value; }
        }

        public string FatherName
        {
            get { return this.txtFatherName.Text; }
            set { this.txtFatherName.Text = value; }
        }

        public string VillageCode
        {
            get
            {
                if (this.cboVillage.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return cboVillage.SelectedValue.ToString();
                }
            }
            set
            {
                cboVillage.SelectedValue = value;
            }
        }

        public string Address
        {
            get { return this.txtAddress.Text; }
            set { this.txtAddress.Text = value; }
        }

        private string _status;
        public string Status
        {
            get { return this._status; }
            set { this._status = value; }
        }

        private PFMDTO00078 _viewData;
        public PFMDTO00078 ViewData
        {
            set { this._viewData = value; }
            get
            {
                if (this._viewData == null) this._viewData = new PFMDTO00078();
                this._viewData.Id = this.Id;
                this._viewData.GroupNo = this.GroupNo;
                this._viewData.NameOnly = this.NameOnly;
                this._viewData.IsNRC = this.IsNRC;
                this._viewData.StateCodeForNRC = this.StateCodeForNRC;
                this._viewData.TownshipCodeForNRC = this.TownshipCodeForNRC;
                this._viewData.NationalityCodeForNRC = this.NationalityCodeForNRC;
                this._viewData.FatherName = this.FatherName;
                this._viewData.VillageCode = this.VillageCode;
                this._viewData.Address = this.Address;
                this._viewData.OpenDate = DateTime.Now;
                this._viewData.UserNo = CurrentUserEntity.CurrentUserID.ToString();
                this._viewData.SourceBr = CurrentUserEntity.BranchCode;

                //For NRC
                if (this.rdoNRC.Checked)
                {
                    this._viewData.NRCNo = this.StateCodeForNRC + this.TownshipCodeForNRC + this.NationalityCodeForNRC + this.NRCNo;
                    this._viewData.IsNRC = true;
                }
                else if (this.rdoOther.Checked)
                {
                    this._viewData.NRCNo = this.other;
                    this._viewData.IsNRC = false;
                }
                return this._viewData;
            }
        }

        private FormState formState;
        public FormState FormState
        {
            get { return this.formState; }
            set { this.formState = value; }
        }

        public IList<PFMDTO00078> lstSolidarity { get; set; }
        private IList<PFMDTO00078> lsSolid = new List<PFMDTO00078>();
        DataTable dtTemporaryMember;
        IList<PFMDTO00078> lstSolid;
        private IList<PFMDTO00078> oldSolidarity = new List<PFMDTO00078>();

        private IPFMCTL00078 _controller;
        public IPFMCTL00078 SolidarityLendingController
        {
            get { return this._controller; }
            set { this._controller = value; _controller.solidarityView = this; }
        }

        #region Methods
        /// <summary>
        ///Successful Message
        /// </summary>
        public void Successful(string message, string groupNo)
        {
            if (groupNo != "")
            {
                this.txtGroupNo.Text = groupNo;
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message, new object[] { "Group No.", groupNo });
            }
            else
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }

        /// <summary>
        ///Failure Message
        /// </summary>
        public void Failure(string message)
        {
            try
            {
                CXUIMessageUtilities.ShowMessageByCode(message);
            }
            catch { }
        }

        /// <summary>
        /// Bind State CodeCombobox For NRC
        /// </summary>
        private void BindStateCombobox()
        {
            StateCodeList = CXCLE00002.Instance.GetListObject<StateDTO>("StateCode.Client.Select", new object[] { true });
            for (int i = 0; i < StateCodeList.Count; i++)
            {
                StateCodeList[i].StateCode = StateCodeList[i].StateCode + "/";
            }

            cboStateCode.ValueMember = "StateCode";
            cboStateCode.DisplayMember = "StateCode";
            cboStateCode.DataSource = StateCodeList;
            cboStateCode.SelectedIndex = -1;

        }

        /// <summary>
        /// Bind Township CodeCombobox For NRC
        /// </summary>
        private void BindTownshipCombobox()
        {
            try
            {
                StateCodeList = CXCLE00002.Instance.GetListObject<StateDTO>("StateCode.Client.Select", new object[] { true });
                cboTownshipCode.ValueMember = "TownshipCode";
                cboTownshipCode.DisplayMember = "TownshipCode";
                cboTownshipCode.DataSource = NRCCodes;
                cboTownshipCode.SelectedIndex = -1;
            }
            catch { }
        }

        /// <summary>
        /// Bind Nationality CodeCombobox For NRC
        /// </summary>
        private void BindNationalityCombobox()
        {
            IList<SAMDTO00053> NationalityList = new List<SAMDTO00053>();
            NationalityList.Add(new SAMDTO00053("(N)", null));
            NationalityList.Add(new SAMDTO00053("(E)", null));
            NationalityList.Add(new SAMDTO00053("(T)", null));
            NationalityList.Add(new SAMDTO00053("(P)", null));
            cboNationalityCode.ValueMember = "Nationality_Code";
            cboNationalityCode.DisplayMember = "Nationality_Code";
            cboNationalityCode.DataSource = NationalityList;
            cboNationalityCode.SelectedIndex = -1;
        }

        /// <summary>
        /// Bind Village CodeCombobox
        /// </summary>
        private void BindVillageCodeCombobox()
        {
            try
            {
                IList<LOMDTO00070> VillageGroupList = CXCLE00002.Instance.GetListObject<LOMDTO00070>("LOMORM00070.SelectAllVillageGroupCode", new object[] { true });//LOMORM00070.SelectAllVillageGroupCode
                this.cboVillage.ValueMember = "VillageCode";
                this.cboVillage.DisplayMember = "Desp";
                this.cboVillage.DataSource = VillageGroupList;
                this.cboVillage.SelectedIndex = -1;
            }
            catch { }
        }

        private DataTable DtforGrid()
        {
            DataTable dtTemp = new DataTable();
            dtTemp.Columns.Add("Id", typeof(int));
            dtTemp.Columns.Add("MemberType", typeof(string));
            dtTemp.Columns.Add("NameOnly", typeof(string));
            dtTemp.Columns.Add("IsNRC", typeof(bool));
            dtTemp.Columns.Add("NRCNo", typeof(string));
            dtTemp.Columns.Add("FatherName", typeof(string));
            dtTemp.Columns.Add("VillageCode", typeof(string));
            dtTemp.Columns.Add("Desp", typeof(string));
            dtTemp.Columns.Add("Address", typeof(string));
           
            return dtTemp;
        }

        private void ClearControls()
        {
            try
            {
                if (this.FormState == FormState.New)
                {
                    this.txtGroupNo.Enabled = false;
                }
                else if (this.FormState == FormState.Edit)
                {
                    this.txtGroupNo.Enabled = true;
                }
                txtName.Text = string.Empty;
                rdoNRC.Checked = true;
                rdoOther.Checked = false;
                cboStateCode.SelectedIndex = -1;
                cboTownshipCode.SelectedIndex = -1;
                cboNationalityCode.SelectedIndex = -1;
                txtNRCNo.Text = string.Empty;
                txtNRC.Text = string.Empty;
                txtFatherName.Text = string.Empty;
                cboVillage.SelectedIndex = -1;
                txtAddress.Text = string.Empty;
                chkLeader.Checked = false;
                if (gvSolidarityLending.Rows.Count > 0)
                {
                    dtTemporaryMember = (DataTable)gvSolidarityLending.DataSource;
                    if (dtTemporaryMember.AsEnumerable().Where(x => x.Field<string>("MemberType").ToUpper() == "LEADER").Count() > 0)
                    {
                        chkLeader.Enabled = false;
                        chkLeader.Checked = false;
                    }
                    else
                    {
                        chkLeader.Enabled = true;
                    }
                }
                else
                {
                    chkLeader.Enabled = true;                
                }
                
            }
            catch { }
        }

        private void ClearGridView()
        {
            try
            {
                dtTemporaryMember.Clear();
                gvSolidarityLending.DataSource = dtTemporaryMember;
                gvSolidarityLending.Refresh();
            }
            catch { }
        }

        #endregion

        private void PFMVEW00078_Load(object sender, EventArgs e)
        {
            try
            {
                this.BindStateCombobox();
                this.BindTownshipCombobox();
                this.BindVillageCodeCombobox();
                this.BindNationalityCombobox();
                this.ClearControls();
                NRCCodeList = CXCLE00002.Instance.GetListObject<SAMDTO00054>("NRCCode.Client.Select", new object[] { true });//Bind NRC Code
                if (this.FormState == FormState.New)
                {
                    this.FormName = "Solidarity Entry";
                    tlspCommon.ButtonEnableDisabled(false, false, true, false, true, false, true);
                    EnableDisableCtrl(true);
                    this.rdoNRC.Enabled = true;
                    this.rdoOther.Enabled = true;
                    this.txtGroupNo.Enabled = false;
                }
                else if (this.FormState == FormState.Edit)
                {
                    this.FormName = "Solidarity Edit";
                    tlspCommon.ButtonEnableDisabled(false, true, false, true, true, false, true);
                    EnableDisableCtrl(false);
                    this.rdoNRC.Enabled = false;
                    this.rdoOther.Enabled = false;
                    this.txtGroupNo.Enabled = true;
                }
                if (rdoNRC.Checked)
                {
                    txtNRC.Enabled = false;
                }
                this.Status = "Save";
            }
            catch { }
        }

        private void EnableDisableCtrl(bool flag)
        {
            this.txtName.Enabled = flag;
            if (this.rdoNRC.Checked)
            {
                this.cboNationalityCode.Enabled = flag;
                this.cboStateCode.Enabled = flag;
                this.cboTownshipCode.Enabled = flag;
                this.txtNRCNo.Enabled = flag;
                this.txtNRC.Enabled = !flag;
            }

            if (this.rdoOther.Checked)
            {
                this.cboNationalityCode.Enabled = !flag;
                this.cboStateCode.Enabled = !flag;
                this.cboTownshipCode.Enabled = !flag;
                this.txtNRCNo.Enabled = !flag;
                this.txtNRC.Enabled = flag;
            }
            this.txtFatherName.Enabled = flag;
            this.cboVillage.Enabled = flag;
            this.txtAddress.Enabled = flag;
            this.butAddMember.Enabled = flag;
        }

        private void cboStateCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboStateCode.SelectedIndex != -1)
            {
                if (this.cboStateCode.SelectedValue != null && this.NRCCodeList != null)
                {
                    string StateCode = string.Empty;
                    StateCode = this.cboStateCode.SelectedValue.ToString().Substring(0, this.cboStateCode.SelectedValue.ToString().Length - 1);
                    NRCCodes = (from x in this.NRCCodeList where x.StateCode == StateCode select x).ToList();
                    this.BindTownshipCombobox();
                }
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
                if (char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch { }
        }

        private void cboTownshipCode_TabIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(this.cboStateCode.Text))
                {

                }
            }
            catch { }
        }

        private void rdoNRC_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.SolidarityLendingController.ClearErrors();
                if (this.FormState == FormState.New)
                {
                    if (this.txtNRC.Text != null || this.txtNRC.Text.ToString() != string.Empty)
                    {
                        this.txtNRC.Text = "";
                    }
                    this.txtNRC.Enabled = false;

                    this.cboStateCode.Enabled = true;
                    this.cboTownshipCode.Enabled = true;
                    this.cboNationalityCode.Enabled = true;
                    this.txtNRCNo.Enabled = true;
                }
                else if (this.FormState == FormState.Edit)
                {
                    if (this.txtNRC.Text != null || this.txtNRC.Text.ToString() != string.Empty)
                    {
                        this.txtNRC.Text = "";
                    }
                    this.txtNRC.Enabled = false;

                    this.cboStateCode.Enabled = true;
                    this.cboTownshipCode.Enabled = true;
                    this.cboNationalityCode.Enabled = true;
                    this.txtNRCNo.Enabled = true;
                }
            }
            catch { }
        }

        private void rdoOther_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.SolidarityLendingController.ClearErrors();
                if (this.FormState == FormState.New)
                {
                    if (this.cboStateCode.SelectedIndex > -1 || this.cboStateCode.SelectedValue != null)
                    {
                        this.cboStateCode.SelectedIndex = -1;
                    }
                    if (this.cboTownshipCode.SelectedIndex > -1 || this.cboTownshipCode.SelectedValue != null)
                    {
                        this.cboTownshipCode.SelectedIndex = -1;
                    }
                    if (this.cboNationalityCode.SelectedIndex > -1 || this.cboNationalityCode.SelectedValue != null)
                    {
                        this.cboNationalityCode.SelectedIndex = -1;
                    }
                    if (this.txtNRCNo.Text != null || this.txtNRCNo.Text.ToString() != string.Empty)
                    {
                        this.txtNRCNo.Text = "";
                    }
                    this.txtNRC.Enabled = true;

                    this.cboStateCode.Enabled = false;
                    this.cboTownshipCode.Enabled = false;
                    this.cboNationalityCode.Enabled = false;
                    this.txtNRCNo.Enabled = false;
                }
                else if (this.FormState == FormState.Edit)
                {
                    if (this.cboStateCode.SelectedIndex > -1 || this.cboStateCode.SelectedValue != null)
                    {
                        this.cboStateCode.SelectedIndex = -1;
                    }
                    if (this.cboTownshipCode.SelectedIndex > -1 || this.cboTownshipCode.SelectedValue != null)
                    {
                        this.cboTownshipCode.SelectedIndex = -1;
                    }
                    if (this.cboNationalityCode.SelectedIndex > -1 || this.cboNationalityCode.SelectedValue != null)
                    {
                        this.cboNationalityCode.SelectedIndex = -1;
                    }
                    if (this.txtNRCNo.Text != null || this.txtNRCNo.Text.ToString() != string.Empty)
                    {
                        this.txtNRCNo.Text = "";
                    }
                    this.txtNRC.Enabled = true;

                    this.cboStateCode.Enabled = false;
                    this.cboTownshipCode.Enabled = false;
                    this.cboNationalityCode.Enabled = false;
                    this.txtNRCNo.Enabled = false;
                }
            }
            catch { }
        }

        private void txtNRCNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                if (e.KeyChar == '-')
                {
                    e.Handled = true;
                }
            }
            catch { }
        }

        private void txtFatherName_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
                if (char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch { }
        }

        private void butAddMember_Click(object sender, EventArgs e)
        {
            try
            {
                PFMDTO00078 solidarity = new PFMDTO00078();
                if (gvSolidarityLending.Rows.Count <= 0)
                {
                    dtTemporaryMember = DtforGrid();
                }
                else
                {
                    dtTemporaryMember = (DataTable)gvSolidarityLending.DataSource;                    
                    if (dtTemporaryMember.Rows.Count >= 3 && editId == 0)
                    {
                        this.Failure("MP00078");
                        return;
                    }
                    if (rdoNRC.Checked)
                    {
                        if (editId > 0)
                        {
                            if (dtTemporaryMember.AsEnumerable().Where(x => x.Field<string>("NRCNo") == this.StateCodeForNRC + this.TownshipCodeForNRC + this.NationalityCodeForNRC + this.NRCNo && x.Field<int>("Id") != editId).Count() > 0)
                            {
                                this.Failure("MP00079");
                                txtNRCNo.Focus();
                                return;
                            }
                        }
                        else
                        {
                            if (dtTemporaryMember.AsEnumerable().Where(x => x.Field<string>("NRCNo") == this.StateCodeForNRC + this.TownshipCodeForNRC + this.NationalityCodeForNRC + this.NRCNo).Count() > 0)
                            {
                                this.Failure("MP00079");
                                txtNRCNo.Focus();
                                return;
                            }
                        }
                    }

                    /* For GridView Data Editing */
                    if (editId > 0)
                    {
                        if (dtTemporaryMember.AsEnumerable().Where(x => x.Field<int>("Id") == editId).Count() == 1 && dtTemporaryMember.Rows.Count == 1)
                        {
                            dtTemporaryMember = DtforGrid();

                        }
                        else
                        {
                            dtTemporaryMember = dtTemporaryMember.AsEnumerable().Where(x => x.Field<int>("Id") != editId).CopyToDataTable();
                        }
                    }
                }
                /* To generate girdview row id*/
                int grdId = (dtTemporaryMember.Rows.Count > 0) ? deleteList.Count > 0 ? Convert.ToInt32(deleteList.AsEnumerable().Select(x => x).First().ToString()) : (dtTemporaryMember.Rows.Count + 1) : 1;
                if (deleteList.Count > 0)
                {
                    deleteList.Remove(grdId);
                }
                DataRow dr = dtTemporaryMember.NewRow();
                dr["Id"] = editId > 0 ? editId.ToString() : grdId.ToString();
                if (this.GroupNo != string.Empty || this.GroupNo != "")
                    solidarity.Id = Convert.ToInt32(dr["Id"].ToString());
                else
                    solidarity.Id = 0;
                editId = 0;
                dr["MemberType"] = (chkLeader.Checked && chkLeader.Enabled == true) ? "Leader" : "Member";
                dr["NameOnly"] = solidarity.NameOnly = this.NameOnly.ToString();
                dr["IsNRC"] = solidarity.IsNRC = rdoNRC.Checked == true ? true : false;
                dr["NRCNo"] = solidarity.NRCNo = rdoNRC.Checked == true ? this.StateCodeForNRC + this.TownshipCodeForNRC + this.NationalityCodeForNRC + this.NRCNo : this.other;
                dr["FatherName"] = solidarity.FatherName = this.FatherName;
                dr["VillageCode"] = solidarity.VillageCode = this.VillageCode;
                dr["Desp"] = cboVillage.GetItemText(cboVillage.SelectedItem);
                dr["Address"] = solidarity.Address = this.Address;                                
                dtTemporaryMember.Rows.Add(dr);
                lsSolid =
                 (from item in dtTemporaryMember.AsEnumerable()
                  select new PFMDTO00078
                  {
                      Id = item.Field<int>("Id"),
                      IsLeader = (item.Field<string>("MemberType").ToString().ToUpper() == "LEADER") ? true: false,
                      NameOnly = item.Field<string>("NameOnly"),
                      IsNRC = item.Field<bool>("IsNRC"),
                      NRCNo = item.Field<string>("NRCNo"),
                      FatherName = item.Field<string>("FatherName"),
                      VillageCode = item.Field<string>("VillageCode"),
                      Address = item.Field<string>("Address")                      
                  }).ToList();
                gvSolidarityLending.DataSource = dtTemporaryMember;
                this.ClearControls();
                this.txtName.Focus();
            }
            catch { }
        }

        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
            catch { }
        }

        private void txtNRC_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
            catch { }
        }

        private void tlspCommon_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlspCommon_CancelButtonClick(object sender, EventArgs e)
        {
            try
            {
                this.txtGroupNo.Text = string.Empty;
                this.ClearControls();
                this.ClearGridView();
                this.lsSolid.Clear();
            }
            catch { }
        }

        private void gvSolidarityLending_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex.Equals(-1))
                {
                    return;
                }
                DataGridViewRow dataRow = (DataGridViewRow)gvSolidarityLending.Rows[e.RowIndex];
                DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];
                /* For Editing Row, Binding Row Data to controls*/
                if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colEdit"))
                {
                    /* Control properties for Edit */
                    EnableDisableCtrl(true);
                    this.rdoNRC.Enabled = true;
                    this.rdoOther.Enabled = true;

                    PFMDTO00078 preSolidarity = new PFMDTO00078();
                    preSolidarity.Id = editId = Convert.ToInt32(gvSolidarityLending.Rows[e.RowIndex].Cells["colNo"].Value.ToString());
                    preSolidarity.NameOnly = txtName.Text = gvSolidarityLending.Rows[e.RowIndex].Cells["colName"].Value.ToString();
                    if (gvSolidarityLending.Rows[e.RowIndex].Cells["colIsNRC"].Value.ToString().ToUpper() == "TRUE")
                    {
                        preSolidarity.IsNRC = rdoNRC.Checked = true;
                        string[] nrcCode = gvSolidarityLending.Rows[e.RowIndex].Cells["colNRCNo"].Value.ToString().Split('/');
                        cboStateCode.SelectedValue = nrcCode[0].ToString() + "/";
                        string[] townshipCode = nrcCode[1].Split('(');
                        cboTownshipCode.SelectedValue = townshipCode[0].ToString();
                        cboNationalityCode.SelectedValue = "(" + townshipCode[1].Substring(0, 2);
                        preSolidarity.NRCNo = txtNRCNo.Text = townshipCode[1].Substring(2);
                    }
                    else
                    {
                        preSolidarity.IsNRC = rdoOther.Checked = true;
                        preSolidarity.NRCNo = txtNRC.Text = gvSolidarityLending.Rows[e.RowIndex].Cells["colNRCNo"].Value.ToString();
                    }
                    preSolidarity.FatherName = txtFatherName.Text = gvSolidarityLending.Rows[e.RowIndex].Cells["colFatherName"].Value.ToString();
                    cboVillage.SelectedValue = preSolidarity.VillageCode = gvSolidarityLending.Rows[e.RowIndex].Cells["colVillageCode"].Value.ToString();
                    preSolidarity.Address = txtAddress.Text = gvSolidarityLending.Rows[e.RowIndex].Cells["colAddress"].Value.ToString();
                    chkLeader.Checked = (gvSolidarityLending.Rows[e.RowIndex].Cells["colType"].Value.ToString().ToUpper() == "LEADER") ? true : false;
                    chkLeader.Enabled = true;
                    this.Status = "Update";
                    oldSolidarity.Add(preSolidarity);
                }

                if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colDelete"))
                {
                    if (CXUIMessageUtilities.ShowMessageByCode("MC90001") == DialogResult.Yes)    //Are you sure you want to delete?
                    {
                        int id = Convert.ToInt32(gvSolidarityLending.Rows[e.RowIndex].Cells["colNo"].Value.ToString());
                        if (this.GroupNo != string.Empty || this.GroupNo != "")
                        {
                            IList<PFMDTO00078> delList = this.lstSolid.Where(x => x.Id == id).ToList();
                            deleteList.Add(id);//To get Delete Item Id
                            oldSolidarity = delList;
                            this.SolidarityLendingController.Delete(delList);
                            BindGridView();

                        }
                        else
                        {
                            int count = gvSolidarityLending.Rows.Count;
                            gvSolidarityLending.DataSource = (gvSolidarityLending.DataSource as DataTable).AsEnumerable().Where(x => x.Field<int>("Id") != id).CopyToDataTable();
                            if ((gvSolidarityLending.DataSource as DataTable).AsEnumerable().Where(x => x.Field<string>("MemberType").ToUpper() == "LEADER").Count() > 0)
                            {
                                chkLeader.Enabled = false;
                                chkLeader.Checked = false;
                            }
                            else
                            {
                                chkLeader.Enabled = true;
                            }
                        }
                            
                    }
                }
            }
            catch { }
        }

        private void tlspCommon_SaveButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (gvSolidarityLending.Rows.Count == 3 && lsSolid.Count == 3)
                {
                    lsSolid.ToList().ForEach(x => { x.GroupNo = this.GroupNo == string.Empty ? null : this.GroupNo; x.OpenDate = DateTime.Now; x.UserNo = CurrentUserEntity.CurrentUserID.ToString(); x.SourceBr = CurrentUserEntity.BranchCode; });                   
                    this.SolidarityLendingController.Save(lsSolid);
                    oldSolidarity = null;
                    this.ClearControls();
                    this.ClearGridView();
                    this.lsSolid.Clear();
                    this.txtGroupNo.Text = string.Empty;
                }
                else
                {
                    this.Failure("MP00080");
                    txtName.Focus();
                    return;
                }
            }
            catch { }
        }

        private void txtGroupNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (this.GroupNo != "" || this.GroupNo != string.Empty)
                {
                    BindGridView();
                    this.FormState = FormState.Edit;
                }
            }
            catch { }
        }

        private void BindGridView()
        {
            try
            {
                dtTemporaryMember = DtforGrid();
                lstSolid = this.SolidarityLendingController.SelectByGroupNo(this.GroupNo);
                lstSolid.ToList().ForEach(x => dtTemporaryMember.Rows.Add(x.Id, (x.IsLeader) ? "Leader": "Member",x.NameOnly, x.IsNRC, x.NRCNo, x.FatherName, x.VillageCode, x.Desp, x.Address));
                gvSolidarityLending.DataSource = dtTemporaryMember;
                gvSolidarityLending.Refresh();                
            }
            catch { }

        }

        private void tlspCommon_DeleteButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (this.GroupNo != string.Empty || this.GroupNo != "")
                {
                    IList<PFMDTO00078> deleteList = this.lstSolid.ToList();

                    if (deleteList.Count > 0)
                    {
                        if (CXUIMessageUtilities.ShowMessageByCode("MC90001") == DialogResult.Yes)    //Are you sure you want to delete?
                        {
                            this.SolidarityLendingController.Delete(deleteList);
                            this.txtGroupNo.Text = string.Empty;
                            this.ClearGridView();
                            this.txtGroupNo.Focus();
                        }
                    }
                    else
                    {
                        this.Failure("MV90012");  //Please select at least one record.
                    }
                }
            }
            catch { }
        }

        private void tlspCommon_EditButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (gvSolidarityLending.Rows.Count == 3 && lsSolid.Count == 3)
                {
                    lsSolid.ToList().ForEach(x => { x.GroupNo = this.GroupNo == string.Empty ? null : this.GroupNo; x.OpenDate = DateTime.Now; x.UserNo = CurrentUserEntity.CurrentUserID.ToString(); x.SourceBr = CurrentUserEntity.BranchCode; });
                    if (this.GroupNo != "" || this.GroupNo != string.Empty)
                    {
                        this.Status = "Update";
                        this.SolidarityLendingController.Save(lsSolid, oldSolidarity);
                    }
                    oldSolidarity = null;
                    this.ClearControls();
                    this.ClearGridView();
                    this.lsSolid.Clear();
                    this.txtGroupNo.Text = string.Empty;
                }
                else
                {
                    this.Failure("MP00080");
                    txtName.Focus();
                    return;
                }
            }
            catch { }
        }

        private void chkLeader_CheckedChanged(object sender, EventArgs e)
        {
            flag = (chkLeader.Checked) ? true : false;
        }
    }
}
