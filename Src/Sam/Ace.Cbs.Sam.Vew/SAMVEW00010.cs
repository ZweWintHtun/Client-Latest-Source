//----------------------------------------------------------------------
// <copyright file="SAMVEW00010.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>08/06/2013</CreatedDate>
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
    public partial class SAMVEW00010 : BaseDockingForm, ISAMVEW00010
    {
        #region Constrator

        public SAMVEW00010()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        public int Id
        {
            get { throw new NotImplementedException(); }
        }

        public string KeyName
        {
            get { return this.txtKeyName.Text; }
            set { this.txtKeyName.Text = value; }
        }

        public string KeyValue
        {
            get { return this.txtKeyValue.Text; }
            set { this.txtKeyValue.Text = value; }
        }

        public string Description
        {
            get { return this.txtDescription.Text; }
            set { this.txtDescription.Text = value; }
        }

        public int Location
        {
            get 
            {
                if (txtLocation.Text != "")
                    return Convert.ToInt32(this.txtLocation.Text);
                else
                    return 0;
            }
            set { this.txtLocation.Text = value.ToString(); }
        }

        public int Type
        {
            get 
            {
                if (txtType.Text != "")
                    return Convert.ToInt32(this.txtType.Text);
                else
                    return 0;
            }
            set { this.txtType.Text = value.ToString(); }
        }

        //public byte[] BinaryValue
        //{
        //    get { return (byte[])this.txtPhoto.Text; }
        //    set { this.txtBinaryValue.Text = value.ToString(); }
        //}

        public string photoName
        {
            get { return this.txtPhoto.Text; }
            set { this.txtPhoto.Text = value; }
        }

        public Image Photo
        {
            get { return this.picPhoto.Image; }
            set { this.picPhoto.Image = value; }
        }

        public string Status { get; set; }

        private PFMDTO00053 viewData;
        public PFMDTO00053 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new PFMDTO00053();

                this.viewData.KeyName = this.KeyName;
                this.viewData.KeyValue = this.KeyValue;
                this.viewData.Description = this.Description;
                this.viewData.Location = this.Location;
                this.viewData.Type = this.Type;

                if (this.picPhoto.Image != null)
                    this.viewData.BinaryValue = CXClientGlobal.ImageToByteArray(this.Photo);
                else
                    this.viewData.BinaryValue = null;


                return this.viewData;
            }
            set { this.viewData = value; }
        }

        public IList<PFMDTO00053> AppSettingss { get; set; }

        private ISAMCTL00010 controller;
        public ISAMCTL00010 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                controller.AppSettingsView = this;
            }
        }

        #endregion

        #region Variables

        PFMDTO00053 _previousAppSettingDto;
        public PFMDTO00053 PreviousAppSettingDto
        {
            get
            {
                if (_previousAppSettingDto == null)
                    return new PFMDTO00053();
                return _previousAppSettingDto;
            }
            set { _previousAppSettingDto = value; }
        }

        #endregion

        #region Method

        private void dgVAppSettings_DataBind()
        {
            gvAppSettings.AutoGenerateColumns = false;
            this.AppSettingss = this.controller.GetAll();
            this.gvAppSettings.DataSource = this.AppSettingss;
            this.txtRecordCount.Text = gvAppSettings.RowCount.ToString();

        }

        private void ChangeControlStatusByUserType(bool isUpdateOnlyUser)
        {
            this.txtKeyName.Enabled = isUpdateOnlyUser;
            this.txtKeyValue.Enabled = isUpdateOnlyUser;
            this.txtDescription.Enabled = isUpdateOnlyUser;
            this.txtLocation.Enabled = isUpdateOnlyUser;
            this.txtType.Enabled = isUpdateOnlyUser;
            this.txtPhoto.Enabled = isUpdateOnlyUser;

        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            //this.dgVAppSettings_DataBind();
            this.InitializeControls();
            this.focus();
        }

        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        private void InitializeControls()
        {
            this.txtKeyName.Text = string.Empty;
            this.txtKeyValue.Text = string.Empty;
            this.txtDescription.Text = string.Empty;
            this.txtLocation.Text = string.Empty;
            this.txtType.Text = string.Empty;
            this.txtPhoto.Text = string.Empty;
            this.picPhoto.Image = null;
            this.txtKeyName.Focus();

            this.Status = "Save";
        }

        public void focus()
        {
            this.txtKeyName.Focus();
        }

        #endregion

        #region Event
        private void butBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();

                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.ico)|*.jpg; *.jpeg; *.gif; *.bmp; *.ico";

                if (open.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        picPhoto.Image = new Bitmap(open.FileName);
                    }
                    catch
                    {
                        // Invalid file format.Please re-choose again.
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00018);
                        return;
                    }
                }

                this.photoName = open.FileName.ToString();
            }
            catch (Exception)
            {

                this.Failure("Failed loading image");
            }
        }

        private void butClearPhoto_Click(object sender, EventArgs e)
        {
            this.picPhoto.Image = null;
            this.photoName = "";
        }
        
        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.Controller.Save(this.ViewData);
            this.dgVAppSettings_DataBind();
            //this.focus();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.Controller.ClearErrors();
            this.gvAppSettings.EndEdit();
            IList<PFMDTO00053> List = this.AppSettingss.Where<PFMDTO00053>(x => x.IsCheck == true).ToList();
            foreach (PFMDTO00053 dto in List)
            {
                dto.IsCheck = false;
            }
            this.focus();
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.gvAppSettings.EndEdit();
            IList<PFMDTO00053> deleteList = this.AppSettingss.Where<PFMDTO00053>(x => x.IsCheck == true).ToList();
            if (deleteList.Count > 0)
            {
                if (CXUIMessageUtilities.ShowMessageByCode("MC90001") == DialogResult.Yes)
                {
                    this.Controller.Delete(deleteList);
                    this.dgVAppSettings_DataBind();
                    this.focus();
                }
            }
            else
            {
                this.Failure("MV90012");
            }
            this.focus();
        }

        private void SAMVEW00010_Load(object sender, EventArgs e)
        {
            //Enatble Disable Controls
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.dgVAppSettings_DataBind();
            this.InitializeControls();
        }

        private void dgVAppSettings_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1))
            {
                return;
            }
            DataGridViewRow dataRow = (DataGridViewRow)gvAppSettings.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colEdit"))
            {
                this.ChangeControlStatusByUserType(true);

                PFMDTO00053 appSettings = (PFMDTO00053)gvAppSettings.Rows[e.RowIndex].DataBoundItem;
                this.PreviousAppSettingDto = new PFMDTO00053();

                this.PreviousAppSettingDto.Id = appSettings.Id;
                this.KeyName = this.PreviousAppSettingDto.KeyName = appSettings.KeyName;
                this.KeyValue = this.PreviousAppSettingDto.KeyValue = appSettings.KeyValue;
                this.Description = this.PreviousAppSettingDto.Description = appSettings.Description;
                this.Location = this.PreviousAppSettingDto.Location = appSettings.Location;
                this.Type = this.PreviousAppSettingDto.Type = appSettings.Type;
                this.Photo = CXClientGlobal.GetImage(appSettings.BinaryValue);
                this.PreviousAppSettingDto.BinaryValue = appSettings.BinaryValue;


                this.ViewData = appSettings;

                this.Status = "Update";
            }
        }

        private void dgVAppSettingsEntry_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value.ToString().Equals("Undefined"))
            {
                e.CellStyle.ForeColor = Color.Blue;
            }
        }

        #endregion

        private void gvAppSettings_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

    
    }
}

