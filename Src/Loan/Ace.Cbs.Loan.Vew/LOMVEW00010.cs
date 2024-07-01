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
    public partial class LOMVEW00010 : BaseDockingForm, ILOMVEW00010
    {
        #region Constructor
        public LOMVEW00010()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties

        private LOMDTO00008 _previousGJKDto;
        public LOMDTO00008 PreviousGJKDto
        {
            get
            {
                if (this._previousGJKDto == null)
                    this._previousGJKDto = new LOMDTO00008();
                return this._previousGJKDto;
            }
            set { this._previousGJKDto = value; }
        }

        public string Kind
        {
            get { return this.txtKind.Text; }
            set { this.txtKind.Text = value; }
        }
     
        public string Description
        {
            get { return this.txtDescription.Text; }
            set { this.txtDescription.Text = value; }
        }

        public string Status { get; set; }

        private LOMDTO00008 viewData;
        public LOMDTO00008 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new LOMDTO00008();

                this.viewData.Kind = this.Kind;
                this.viewData.Description = this.Description;

                return this.viewData;
            }
            set { this.viewData = value; }
        }


        public IList<LOMDTO00008> GJKCodes { get; set; }

        

        private ILOMCTL00010 _controller;
        public ILOMCTL00010 Controller
        {
            get
            {
                return this._controller;
            }
            set
            {
                this._controller = value;
                this._controller.GJKCodeView = this;
            }
        }
        #endregion

        #region Implementation
        public void ControlSetting(string name, bool isEnable)
        {
            if (isEnable)
                this.EnableControls(name);
            else
                this.DisableControls(name);
        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.InitializedControls();
        }

        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.InitializedControls();
        }
        #endregion

        #region Helper Methods
        private void InitializedControls()
        {
            this.txtKind.ResetText();
            this.txtDescription.ResetText();
            this.ControlSetting("GJK.Enable", true);
            this.Status = "Save";
        }

        private void gvGjKind_DataBind()
        {
            this.gvGjKind.AutoGenerateColumns = false;
            this.GJKCodes = this.Controller.SelectAll();
            this.gvGjKind.DataSource = GJKCodes;
            this.txtRowCount.Text = this.gvGjKind.RowCount.ToString();
        }

        private void changeControlByUserType(bool p)
        {
            this.txtKind.Enabled = p;
            this.txtDescription.Enabled = p;
        }
        #endregion

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializedControls();
            this.Controller.ClearErrors();
            txtKind.Focus();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();            
        }

       
        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            txtKind.CausesValidation = true;
            txtDescription.CausesValidation = true;

            //this.ViewData = new LOMDTO00008();
            //this.ViewData.Kind = txtKind.Text;
            //this.ViewData.Description = txtDescription.Text;
            this.Controller.Save(this.ViewData);
            this.gvGjKind_DataBind();
          //  this.txtKind.Focus();

            this.txtKind.CausesValidation = false;
            this.txtDescription.CausesValidation = false;
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.gvGjKind.EndEdit();
            IList<LOMDTO00008> itemlist = this.GJKCodes.Where<LOMDTO00008>(x => x.IsCheck == true).ToList<LOMDTO00008>();
            if (itemlist.Count > 0)
            {
                if (CXUIMessageUtilities.ShowMessageByCode("MC90001") == DialogResult.Yes)
                {
                    this.Controller.Delete(itemlist);
                    this.gvGjKind_DataBind();
                    txtKind.Focus();
                }
            }
        }

        private void gvGjKind_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1))
                return;
            DataGridViewRow gvRows = (DataGridViewRow)gvGjKind.Rows[e.RowIndex];
            DataGridViewCell cell = (DataGridViewCell)gvRows.Cells[e.ColumnIndex];

            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colEdit"))
            {
                this.changeControlByUserType(true);
                LOMDTO00008 GjtDto = (LOMDTO00008)gvGjKind.Rows[e.RowIndex].DataBoundItem;
                this.PreviousGJKDto = new LOMDTO00008();
                this.Kind = this.PreviousGJKDto.Kind = GjtDto.Kind;
                this.Description = this.PreviousGJKDto.Description = GjtDto.Description;
                this.ViewData = GjtDto;
                this.Status = "Update";
            }
        }

        private void LOMVEW00010_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.gvGjKind_DataBind();
            this.InitializedControls();
        }

        //private void LOMVEW00010_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        this.SelectNextControl(this.ActiveControl, true, true, true, true);
        //    }            
        //}

        private void txtKind_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            e.Handled = e.KeyChar == ' ';
        }

        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }
    }
}
