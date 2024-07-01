//----------------------------------------------------------------------
// <copyright file="SAMVEW00007.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>07/26/2013</CreatedDate>
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

namespace Ace.Cbs.Sam.Vew
{
    public partial class SAMVEW00007 : BaseDockingForm, ISAMVEW00007
    {
        #region Constrator

        public SAMVEW00007()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        public int Id
        {
            get { throw new NotImplementedException(); }
        }

        public DateTime DATE
        {
            get { return this.dtpDate.Value; }
            set { this.dtpDate.Text = value.ToString(); }
        }

        public string DESCRIPTION
        {
            get { return this.txtDescription.Text; }
            set { this.txtDescription.Text = value; }
        }

       public string Status { get; set; }

        private SAMDTO00003 viewData;
        public SAMDTO00003 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new SAMDTO00003();

                this.viewData.DATE = this.DATE.Date;
                this.viewData.DESCRIPTION = this.DESCRIPTION;
                return this.viewData;
            }
            set { this.viewData = value; }
        }

        public IList<SAMDTO00003> HOLIDAYs { get; set; }

        private ISAMCTL00007 controller;
        public ISAMCTL00007 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                controller.HOLIDAYView = this;
            }
        }

        SAMDTO00003 _previousHolidayDto;
        public SAMDTO00003 PreviousHolidayDto
        {
            get
            {
                if (_previousHolidayDto == null)
                    return new SAMDTO00003();
                return _previousHolidayDto;
            }
            set { _previousHolidayDto = value; }
        }

        #endregion

        #region Method

        private void dgVHOLIDAY_DataBind()
        {
            gvHoliday.AutoGenerateColumns = false;
            this.HOLIDAYs = this.controller.GetAll();
            this.gvHoliday.DataSource = this.HOLIDAYs;
            this.txtRecordCount.Text = gvHoliday.RowCount.ToString();
        }

        private void ChangeControlStatusByUserType(bool isUpdateOnlyUser)
        {
            this.dtpDate.Enabled = isUpdateOnlyUser;
            this.txtDescription.Enabled = isUpdateOnlyUser;          
        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.dgVHOLIDAY_DataBind();
            this.InitializeControls();
        }

        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        private void InitializeControls()
        {
            this.dtpDate.Text = string.Empty;
            this.txtDescription.Text = string.Empty;
          
            this.Status = "Save";
        }

        #endregion

        #region Event

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.Controller.Save(this.ViewData);
           // this.dtpDate.Focus();
            this.dgVHOLIDAY_DataBind(); 
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.Controller.ClearErrors();
            this.gvHoliday.EndEdit();
            IList<SAMDTO00003> List = this.HOLIDAYs.Where<SAMDTO00003>(x => x.IsCheck == true).ToList();
            foreach (SAMDTO00003 dto in List)
            {
                dto.IsCheck = false;
            }
            this.dtpDate.Focus();
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.gvHoliday.EndEdit();
            IList<SAMDTO00003> deleteList = this.HOLIDAYs.Where<SAMDTO00003>(x => x.IsCheck == true).ToList();
            if (deleteList.Count > 0)
            {
                if (CXUIMessageUtilities.ShowMessageByCode("MC90001") == DialogResult.Yes)
                {
                    this.Controller.Delete(deleteList);
                    this.dtpDate.Focus();
                }
            }
            else
            {
                this.Failure("MV90012");
            }
        }

        private void SAMVEW00007_Load(object sender, EventArgs e)
        {
            //Enatble Disable Controls
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.dgVHOLIDAY_DataBind();
            this.InitializeControls();
        }

        private void dgVHOLIDAY_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1))
            {
                return;
            }
            DataGridViewRow dataRow = (DataGridViewRow)gvHoliday.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colEdit"))
            {
                this.ChangeControlStatusByUserType(true);

                SAMDTO00003 hOLIDAY = (SAMDTO00003)gvHoliday.Rows[e.RowIndex].DataBoundItem;
                
                this.PreviousHolidayDto = new SAMDTO00003();
                this.PreviousHolidayDto.Id = hOLIDAY.Id;
                this.DATE =this.PreviousHolidayDto.DATE = hOLIDAY.DATE;
                this.DESCRIPTION = this.PreviousHolidayDto.DESCRIPTION = hOLIDAY.DESCRIPTION;
                this.ViewData = hOLIDAY;
                this.Status = "Update";
            }
        }

        private void dgVHOLIDAYEntry_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value.ToString().Equals("Undefined"))
            {
                e.CellStyle.ForeColor = Color.Blue;
            }
        }

        

        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        #endregion

    }
}

