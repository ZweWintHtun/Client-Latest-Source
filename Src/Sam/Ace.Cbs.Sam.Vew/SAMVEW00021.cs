//----------------------------------------------------------------------
// <copyright file="SAMVEW00021.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NL</CreatedUser>
// <CreatedDate>07/24/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Sam.Ctr.Ptr;
using Ace.Cbs.Sam.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Sam.Vew
{
    /// <summary>
    /// Initial Setup
    /// </summary>
    public partial class SAMVEW00021 : BaseDockingForm, ISAMVEW00021
    {
        #region Constrator

        public SAMVEW00021()
        {
            InitializeComponent();
        }

        #endregion

        #region Variables

        PFMDTO00003 _previousInitialDto;
        public PFMDTO00003 PreviousInitialDto
        {
            get
            {
                if (_previousInitialDto == null)
                    return new PFMDTO00003();
                return _previousInitialDto;
            }
            set { _previousInitialDto = value; }
        }

        #endregion

        #region Properties

        public int Id
        {
            get { throw new NotImplementedException(); }
        }

        public string Initial
        {
            get { return this.txtInitialCode.Text; }
            set { this.txtInitialCode.Text = value; }
        }

        public string Description
        {
            get { return this.txtDescription.Text; }
            set { this.txtDescription.Text = value; }
        }

        public string Status { get; set; }

        private PFMDTO00003 viewData;
        public PFMDTO00003 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new PFMDTO00003();

                this.viewData.Initial = this.Initial;
                this.viewData.Description = this.Description;

                return this.viewData;
            }
            set { this.viewData = value; }
        }

        public IList<PFMDTO00003> Initials { get; set; }

        private ISAMCTL00021 controller;
        public ISAMCTL00021 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                controller.InitialView = this;
            }
        }

        #endregion

        #region Method

        private void dgVInitial_DataBind()
        {
            gvInitialCode.AutoGenerateColumns = false;
            this.Initials = this.controller.GetAll();
            this.gvInitialCode.DataSource = this.Initials;
            this.txtRecordCount.Text = gvInitialCode.RowCount.ToString();

        }

        private void ChangeControlStatusByUserType(bool isUpdateOnlyUser)
        {
            this.txtInitialCode.Enabled = isUpdateOnlyUser;
            this.txtDescription.Enabled = isUpdateOnlyUser;

        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.dgVInitial_DataBind();
            this.InitializeControls();
        }

        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        private void InitializeControls()
        {
            this.txtInitialCode.Text = string.Empty;
            this.txtDescription.Text = string.Empty;
            this.ControlSetting("Initial.Enable", true);
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
            this.txtInitialCode.Focus();
        }

        #endregion

        #region Event

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.Controller.Save(this.ViewData);
          
            this.dgVInitial_DataBind();
          //  this.focus();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.Controller.ClearErrors();
            this.txtInitialCode.Focus();
            this.gvInitialCode.EndEdit();
            IList<PFMDTO00003> List = this.Initials.Where<PFMDTO00003>(x => x.IsCheck == true).ToList();
            foreach (PFMDTO00003 dto in List)
            {
                dto.IsCheck = false;
            }
            this.focus();
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.gvInitialCode.EndEdit();
            IList<PFMDTO00003> deleteList = this.Initials.Where<PFMDTO00003>(x => x.IsCheck == true).ToList();
            if (deleteList.Count > 0)
            {
                if (CXUIMessageUtilities.ShowMessageByCode("MC90001") == DialogResult.Yes)
                {
                    this.Controller.Delete(deleteList);
                }
            }
            else
            {
                this.Failure("MV90012");
            }
            this.focus();
        }

        private void SAMVEW00021_Load(object sender, EventArgs e)
        {
            //Enatble Disable Controls
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.dgVInitial_DataBind();
            this.InitializeControls();
        }

        private void dgVInitial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1))
            {
                return;
            }
            DataGridViewRow dataRow = (DataGridViewRow)gvInitialCode.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colEdit"))
            {
                this.ChangeControlStatusByUserType(true);

                PFMDTO00003 initial = (PFMDTO00003)gvInitialCode.Rows[e.RowIndex].DataBoundItem;
                
                this.PreviousInitialDto = new PFMDTO00003();
               
                this.Initial = this.PreviousInitialDto.Initial = initial.Initial;
                this.Description = this.PreviousInitialDto.Description = initial.Description;

                this.ViewData = initial;
                this.ControlSetting("Initial.Disable", false);
                this.Status = "Update";
            }
        }
        
        private void dgVInitialEntry_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value.ToString().Equals("Undefined"))
            {
                e.CellStyle.ForeColor = Color.Blue;
            }
        }

        private void txtInitialCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
            e.Handled = e.KeyChar == ' ';
        }


        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }
        #endregion

    }
}

