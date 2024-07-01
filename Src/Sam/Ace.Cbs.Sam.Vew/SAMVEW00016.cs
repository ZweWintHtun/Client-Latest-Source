//----------------------------------------------------------------------
// <copyright file="SAMVEW00016.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>08/07/2013</CreatedDate>
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
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;

namespace Ace.Cbs.Sam.Vew
{
    /// <summary>
    /// NewSetup
    /// </summary>
    public partial class SAMVEW00016 : BaseDockingForm, ISAMVEW00016
    {
        #region Constrator

        public SAMVEW00016()
        {
            InitializeComponent();
        }

        #endregion

        #region Variables

        PFMDTO00057 _previousNewSetupDto;
        public PFMDTO00057 PreviousNewSetupDto
        {
            get
            {
                if (_previousNewSetupDto == null)
                    return new PFMDTO00057();
                return _previousNewSetupDto;
            }
            set { _previousNewSetupDto = value; }
        }

        #endregion

        #region Properties

        public int Id
        {
            get { throw new NotImplementedException(); }
        }

        public string Variable
        {
            get { return this.txtVariable.Text; }
            set { this.txtVariable.Text = value; }
        }

        public string Value
        {
            get { return this.txtValue.Text; }
            set { this.txtValue.Text = value; }
        }

        public string Status { get; set; }

        private PFMDTO00057 viewData;
        public PFMDTO00057 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new PFMDTO00057();

                this.viewData.Variable = this.Variable;
                this.viewData.Value = this.Value;

                return this.viewData;
            }
            set { this.viewData = value; }
        }

        public IList<PFMDTO00057> NewSetups { get; set; }

        private ISAMCTL00016 controller;
        public ISAMCTL00016 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                controller.NewSetupView = this;
            }
        }

        #endregion

        #region Method

        private void dgVNewSetup_DataBind()
        {
            gvNewSetup.AutoGenerateColumns = false;
            this.NewSetups = this.controller.GetAll();
            this.gvNewSetup.DataSource = this.NewSetups;
            this.txtRecordCount.Text = gvNewSetup.RowCount.ToString();

        }

        private void ChangeControlStatusByUserType(bool isUpdateOnlyUser)
        {
            this.txtVariable.Enabled = isUpdateOnlyUser;
            this.txtValue.Enabled = isUpdateOnlyUser;

        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            //this.dgVNewSetup_DataBind();
            this.InitializeControls();
            this.txtVariable.Focus();
        }

        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        private void InitializeControls()
        {
            this.txtVariable.Text = string.Empty;
            this.txtValue.Text = string.Empty;

            this.ControlSetting("NewSetup.Enable", true);
            this.Status = "Save";
        }
        public void ControlSetting(string name, bool isEnable)
        {
            if (isEnable)
                this.EnableControls(name);
            else
                this.DisableControls(name);
        }

        #endregion

        #region Event

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.Controller.Save(this.ViewData);
           // this.txtVariable.Focus();
            this.dgVNewSetup_DataBind();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.Controller.ClearErrors();
            this.gvNewSetup.EndEdit();
            IList<PFMDTO00057> List = this.NewSetups.Where<PFMDTO00057>(x => x.IsCheck == true).ToList();
            foreach (PFMDTO00057 dto in List)
            {
                dto.IsCheck = false;
            }
            this.txtVariable.Focus();
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.gvNewSetup.EndEdit();
            IList<PFMDTO00057> deleteList = this.NewSetups.Where<PFMDTO00057>(x => x.IsCheck == true).ToList();
            if (deleteList.Count > 0)
            {
                if (CXUIMessageUtilities.ShowMessageByCode("MC90001") == DialogResult.Yes)
                {
                    this.Controller.Delete(deleteList);
                    this.dgVNewSetup_DataBind();
                    this.txtVariable.Focus();
                }
            }
            else
            {
                this.Failure("MV90012");
            }
        }

        private void SAMVEW00016_Load(object sender, EventArgs e)
        {
            //Enatble Disable Controls
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.dgVNewSetup_DataBind();
            this.InitializeControls();
        }

        private void dgVNewSetup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1))
            {
                return;
            }
            DataGridViewRow dataRow = (DataGridViewRow)gvNewSetup.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            {
                this.ChangeControlStatusByUserType(true);

                PFMDTO00057 newSetup = (PFMDTO00057)gvNewSetup.Rows[e.RowIndex].DataBoundItem;

                this.PreviousNewSetupDto = new PFMDTO00057();
                this.Variable = this.PreviousNewSetupDto.Variable = newSetup.Variable;
                this.Value = this.PreviousNewSetupDto.Value = newSetup.Value;


                this.ViewData = newSetup;
                this.ControlSetting("NewSetup.Disable", false);
                this.Status = "Update";
            }
        }

        private void dgVNewSetupEntry_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value.ToString().Equals("Undefined"))
            {
                e.CellStyle.ForeColor = Color.Blue;
            }
        }

        private void txtVariable_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        

        private void txtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == ' ';
        }
        #endregion


    }
}

