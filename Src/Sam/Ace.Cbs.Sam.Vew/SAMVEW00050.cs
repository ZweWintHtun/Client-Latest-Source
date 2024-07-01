//----------------------------------------------------------------------
// <copyright file="SAMVEW00050.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>08/08/2013</CreatedDate>
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
    public partial class SAMVEW00050 : BaseDockingForm, ISAMVEW00050
    {
        #region Constrator

        public SAMVEW00050()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        private PFMDTO00048 _previousMessageDto;
        public PFMDTO00048 PreviousMessageDto
        {
            get
            {
                if(_previousMessageDto == null)
                    return new PFMDTO00048();
                return _previousMessageDto;
            }
            set
            { _previousMessageDto = value; }
        }

        public int Id
        {
            get { throw new NotImplementedException(); }
        }

        public string Code
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

        private PFMDTO00048 viewData;
        public PFMDTO00048 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new PFMDTO00048();

                this.viewData.Code = this.Code;
                this.viewData.Description = this.Description;

                return this.viewData;
            }
            set { this.viewData = value; }
        }

        public IList<PFMDTO00048> Messages { get; set; }

        private ISAMCTL00050 controller;
        public ISAMCTL00050 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                controller.MessageView = this;
            }
        }

        #endregion

        #region Method

        private void dgVMessage_DataBind()
        {
            gvMessageList.AutoGenerateColumns = false;
            this.Messages = this.controller.GetAll();
            this.gvMessageList.DataSource = this.Messages;
            this.txtRecordCount.Text = gvMessageList.RowCount.ToString();

        }

        private void ChangeControlStatusByUserType(bool isUpdateOnlyUser)
        {
            this.txtCode.Enabled = isUpdateOnlyUser;
            this.txtDescription.Enabled = isUpdateOnlyUser;

        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            //this.dgVMessage_DataBind();
            this.InitializeControls();
            this.txtCode.Focus();
        }

        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        private void InitializeControls()
        {
            this.txtCode.Text = string.Empty;
            this.txtDescription.Text = string.Empty;

            this.ControlSetting("Message.Enable", true);
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
            this.dgVMessage_DataBind();
            //this.txtCode.Focus();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.Controller.ClearErrors();
            this.gvMessageList.EndEdit();
            IList<PFMDTO00048> List = this.Messages.Where<PFMDTO00048>(x => x.IsCheck == true).ToList();
            foreach (PFMDTO00048 dto in List)
            {
                dto.IsCheck = false;
            }
            this.txtCode.Focus();
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.gvMessageList.EndEdit();
            IList<PFMDTO00048> deleteList = this.Messages.Where<PFMDTO00048>(x => x.IsCheck == true).ToList();
            if (deleteList.Count > 0)
            {
                if (CXUIMessageUtilities.ShowMessageByCode("MC90001") == DialogResult.Yes)
                {
                    this.Controller.Delete(deleteList);
                    this.dgVMessage_DataBind();
                    this.txtCode.Focus();
                }
            }
            else
            {
                this.Failure("MV90012");
            }
        }

        private void SAMVEW00050_Load(object sender, EventArgs e)
        {
            //Enatble Disable Controls
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.dgVMessage_DataBind();
            this.InitializeControls();
        }

        private void dgVMessage_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1))
            {
                return;
            }
            DataGridViewRow dataRow = (DataGridViewRow)gvMessageList.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colEdit"))
            {
                this.ChangeControlStatusByUserType(true);

                PFMDTO00048 message = (PFMDTO00048)gvMessageList.Rows[e.RowIndex].DataBoundItem;

                this.PreviousMessageDto = new PFMDTO00048();
                this.Code = this.PreviousMessageDto.Code = message.Code;
                this.Description = this.PreviousMessageDto.Description = message.Description;

                this.ViewData = message;
                this.ControlSetting("Message.Disable", false);
                this.Status = "Update";
            }
        }

        private void dgVMessageEntry_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value.ToString().Equals("Undefined"))
            {
                e.CellStyle.ForeColor = Color.Blue;
            }
        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
            e.Handled = e.KeyChar == ' ';
        } 

        #endregion
    }
}

