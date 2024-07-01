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
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.CXClient;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00070 : BaseDockingForm, ILOMVEW00070
    {
        #region Constructor
        public LOMVEW00070()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        private LOMDTO00070 _previousVillageGroupDto;
        public LOMDTO00070 PreviousVillageGroupDto
        {
            get
            {
                if (_previousVillageGroupDto == null)
                    return new LOMDTO00070();
                return _previousVillageGroupDto;
            }
            set
            {
                _previousVillageGroupDto = value;
            }
        }

        public int Id
        {
            get { throw new NotImplementedException(); }
        }

        public string VillageCode
        {
            get { return this.txtCode.Text; }
            set { this.txtCode.Text = value; }
        }

        public string Description
        {
            get { return this.txtDescription.Text; }

            set { this.txtDescription.Text = value; }
        }


        public string Status { get; set; }

        private LOMDTO00070 viewData;
        public LOMDTO00070 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new LOMDTO00070();

                this.viewData.VillageCode = this.VillageCode;
                this.viewData.Desp = this.Description;

                return this.viewData;
            }
            set { this.viewData = value; }
        }

        public IList<LOMDTO00070> VillageGroupList { get; set; }

        private ILOMCTL00070 controller;
        public ILOMCTL00070 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                controller.VillageGroupEntryView = this;
            }
        }

        public void focus()
        {
            this.txtCode.Focus();
        }
        #endregion

        #region Method
        private void gvVillageGroupList_DataBind()
        {
            this.gvVillageGroupList.AutoGenerateColumns = false;
            this.VillageGroupList = this.controller.GetAll();
            this.gvVillageGroupList.DataSource = this.VillageGroupList;
            this.txtRecordCount.Text = gvVillageGroupList.RowCount.ToString();
        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.gvVillageGroupList_DataBind();
            this.InitializeControls();
        }

        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        private void InitializeControls()
        {
            this.txtCode.Text = string.Empty;
            this.txtDescription.Text = string.Empty;

            this.Status = "Save";
        }

        #endregion

        private void LOMVEW00070_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.gvVillageGroupList_DataBind();
            this.InitializeControls();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.Controller.ClearErrors();
            this.txtCode.Focus();
            this.focus();
            this.gvVillageGroupList.EndEdit();
            IList<LOMDTO00070> List = this.VillageGroupList.Where<LOMDTO00070>(x => x.IsCheck == true).ToList();
            foreach (LOMDTO00070 dto in List)
            {
                dto.IsCheck = false;
            }
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.Controller.Save(this.ViewData);
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.gvVillageGroupList.EndEdit();
            IList<LOMDTO00070> deleteList = this.VillageGroupList.Where<LOMDTO00070>(x => x.IsCheck == true).ToList();
            if (deleteList.Count > 0)
            {
                if (CXUIMessageUtilities.ShowMessageByCode("MC90001") == DialogResult.Yes)    //Are you sure you want to delete?
                {
                    this.Controller.Delete(deleteList);
                    this.txtCode.Focus();
                }
            }
            else
            {
                this.Failure("MV90012");  //Please select at least one record.
            }
            this.focus();
        }

        private void gvVillageGroupList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1))
            {
                return;
            }
            DataGridViewRow dataRow = (DataGridViewRow)gvVillageGroupList.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colEdit"))
            {
                this.ChangeControlStatusByUserType(true);

                LOMDTO00070 villageGroupCode = (LOMDTO00070)gvVillageGroupList.Rows[e.RowIndex].DataBoundItem;

                this.PreviousVillageGroupDto = new LOMDTO00070();
                this.VillageCode = this.PreviousVillageGroupDto.VillageCode = villageGroupCode.VillageCode;
                this.Description = this.PreviousVillageGroupDto.Desp = villageGroupCode.Desp;

                this.ViewData = villageGroupCode;
                this.Status = "Update";

                //txtCode.Enabled = false;

            }
        }

        private void ChangeControlStatusByUserType(bool isUpdateOnlyUser)
        {
            this.txtCode.Enabled = isUpdateOnlyUser;
            this.txtDescription.Enabled = isUpdateOnlyUser;
        }

        private void gvVillageGroupList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value.ToString().Equals("Undefined"))
            {
                e.CellStyle.ForeColor = Color.Blue;
            }
        }

        private void textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
            catch { }
        }
    }
}
