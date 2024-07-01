using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Sam.Ctr.Ptr;
using Ace.Cbs.Sam.Dmd;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Sam.Vew
{
    public partial class SAMVEW00064 : BaseDockingForm, ISAMVEW00056
    {
        /// <summary>
        /// NRC Code Entry View
        /// </summary>
        ///
        #region Constrator
        public SAMVEW00064()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties

        SAMDTO00054 previousNRCCodeDto;
        public SAMDTO00054 PreviousNRCCodeDto
        {
            get
            {
                if (previousNRCCodeDto == null)
                    return new SAMDTO00054();
                return previousNRCCodeDto;
            }
            set { previousNRCCodeDto = value; }
        }


        public int Id
        {
            get { throw new NotImplementedException(); }
        }

        public string StateCode
        {
            get
            {
                if (this.cboStateCode.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cboStateCode.SelectedValue.ToString();
                }
            }
            set { this.cboStateCode.SelectedValue = value; }
        }
        public string StateDesp
        {
            get { return this.lblStateDesp.Text; }
            set { this.lblStateDesp.Text = value; }
        }

        public string TownshipCode
        {
            get { return this.txtTownshipCode.Text; }
            set { this.txtTownshipCode.Text = value; }
        }

        public string TownshipDesp
        {
            get { return this.txtTownshipDesp.Text; }
            set { this.txtTownshipDesp.Text = value; }
        }

        public string Status { get; set; }

        private SAMDTO00054 viewData;
        public SAMDTO00054 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new SAMDTO00054();                
                this.viewData.TownshipCode = this.TownshipCode;
                this.viewData.TownshipDesp = this.TownshipDesp;
                this.viewData.StateCode = this.StateCode;

                return this.viewData;
            }
            set { this.viewData = value; }
        }

        public IList<SAMDTO00054> NRCCodeList { get; set; }
        public IList<StateDTO> StateCodeList { get; set; }

        private ISAMCTL00056 controller;
        public ISAMCTL00056 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                this.controller.NRCCodeView = this;
            }
        }
        #endregion

        #region Method

        private void gvNRCCode_DataBind()
        {
            gvNRCCode.AutoGenerateColumns = false;
            this.NRCCodeList = this.controller.GetAll();
            this.gvNRCCode.DataSource = this.NRCCodeList;
            this.txtRecordCount.Text = gvNRCCode.RowCount.ToString();
        }

        private void BindStateComboBox()
        {
            StateCodeList = CXCLE00002.Instance.GetListObject<StateDTO>("StateCode.Client.Select", new object[] { true });
            cboStateCode.ValueMember = "StateCode";
            cboStateCode.DisplayMember = "StateCode";
            cboStateCode.DataSource = StateCodeList;
        }

        private void ChangeControlStatusByUserType(bool isUpdateOnlyUser)
        {
            this.cboStateCode.Enabled = isUpdateOnlyUser;
            this.txtTownshipCode.Enabled = isUpdateOnlyUser;
            this.txtTownshipDesp.Enabled = isUpdateOnlyUser;
        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.gvNRCCode_DataBind();
            this.InitializeControls();
            this.focus();
        }

        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        private void InitializeControls()
        {
            this.cboStateCode.SelectedIndex = -1;
            this.lblStateDesp.Text = string.Empty;
            this.txtTownshipCode.Text = string.Empty;
            this.txtTownshipDesp.Text = string.Empty;
            this.tsbCRUD.CausesValidation = false;
            this.Status = "Save";
        }

        public void ControlSetting(string name, bool isEnable)
        {
            if (isEnable)
                this.EnableControls(name);
            else
                this.DisableControls(name);
        }

        public void focus()
        {
            this.cboStateCode.Focus();
        }

        #endregion

        #region Event
        private void SAMVEW00064_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.gvNRCCode_DataBind();            
            this.BindStateComboBox();
            this.InitializeControls();
            this.focus();

        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.Controller.Save(this.ViewData);
            this.gvNRCCode_DataBind();
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.gvNRCCode.EndEdit();
            IList<SAMDTO00054> deleteList = this.NRCCodeList.Where<SAMDTO00054>(x => x.IsCheck == true).ToList();
            if (deleteList.Count > 0)
            {
                if (CXUIMessageUtilities.ShowMessageByCode("MC90001") == DialogResult.Yes)
                {
                    this.Controller.Delete(deleteList);
                    this.gvNRCCode_DataBind();
                    this.Focus();
                }
            }
            else
            {
                this.Failure("MV90012");
            }
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.Controller.ClearErrors();
            this.gvNRCCode.EndEdit();
            IList<SAMDTO00054> List = this.NRCCodeList.Where<SAMDTO00054>(x => x.IsCheck == true).ToList();
            foreach (SAMDTO00054 dto in List)
            {
                dto.IsCheck = false;
            }
            this.focus();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvNRCCode_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1))
            {
                return;
            }
            DataGridViewRow dataRow = (DataGridViewRow)gvNRCCode.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colEdit"))
            {
                this.ChangeControlStatusByUserType(true);

                SAMDTO00054 NRCCode = (SAMDTO00054)gvNRCCode.Rows[e.RowIndex].DataBoundItem;

                this.PreviousNRCCodeDto = new SAMDTO00054();

                this.previousNRCCodeDto.Id = NRCCode.Id;
                this.TownshipCode = this.PreviousNRCCodeDto.TownshipCode = NRCCode.TownshipCode;
                this.TownshipDesp = this.PreviousNRCCodeDto.TownshipDesp = NRCCode.TownshipDesp;
                this.StateCode = this.PreviousNRCCodeDto.StateCode = NRCCode.StateCode;

                this.ViewData = NRCCode;
                this.Status = "Update";
            }
        }

        private void gvNRCCodeEntry_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value.ToString().Equals("Undefined"))
            {
                e.CellStyle.ForeColor = Color.Blue;
            }
        }

        private void cboStateCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboStateCode.SelectedIndex != -1)
            {
                if (this.cboStateCode.SelectedValue != null)
                {
                    var data = (from x in this.StateCodeList where x.StateCode.ToString().Equals(cboStateCode.SelectedValue.ToString()) select x.Description).Single().ToString();
                    lblStateDesp.Text = data;
                }
            }
        }

        private void txtTownshipCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar)) || e.KeyChar == '-' || e.KeyChar == ' ' || e.KeyChar == '.')
            { 
                e.Handled = true; 
            }
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void txtTownshipDesp_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void txtTownshipCode_Leave(object sender, EventArgs e)
        {

        }
        private void cboStateCode_Leave(object sender, EventArgs e)
        {
            
        }
        private void txtTownshipDesp_Leave(object sender, EventArgs e)
        {
            if (this.ActiveControl.Name.Contains("tsbCRUD"))
            {
                this.tsbCRUD.CausesValidation = true;
            }
        }
        #endregion       
     
    }
}
