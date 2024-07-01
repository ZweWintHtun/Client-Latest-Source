//----------------------------------------------------------------------
// <copyright file="MNMVEW00027.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>10/23/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Windows.CXClient;


namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00027 : BaseForm,IMNMVEW00027
    {
        #region Constructor
        public MNMVEW00027()
        {
            InitializeComponent();
        }
        #endregion Constructor

        #region Properties
        private IMNMCTL00027 controller;
        public IMNMCTL00027 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }

        private TLMDTO00017 drawingremittancedto;
        public TLMDTO00017 Drawingremittancedto
        {
            get
            {
                if (this.drawingremittancedto == null)
                    this.drawingremittancedto = new TLMDTO00017();
                this.drawingremittancedto.RegisterNo = this.txtDrawingRegisterNo.Text;
                this.drawingremittancedto.GroupNo = this.lblGroupNo.Text.Replace("Group No   : ", "").Trim();
                this.drawingremittancedto.SourceBranchCode = this.SourceBranchCode;
                if (Listdrawingremittancedto != null && Listdrawingremittancedto.Count > 0)
                {
                    TLMDTO00017 databounddrawingRemittance = new TLMDTO00017();
                    databounddrawingRemittance = (TLMDTO00017)gvDrawingAdjustment.Rows[0].DataBoundItem;
                    this.drawingremittancedto.Dbank = databounddrawingRemittance.Dbank;
                    this.drawingremittancedto.AccountNo = databounddrawingRemittance.AccountNo;
                    this.drawingremittancedto.Amount = databounddrawingRemittance.Amount;
                    this.drawingremittancedto.Name = databounddrawingRemittance.Name;
                    this.drawingremittancedto.Currency = databounddrawingRemittance.Currency;
                    this.drawingremittancedto.UpdatedUserId = this.updatedUserId;
                }
                return drawingremittancedto;
                ;
            }
            set { this.drawingremittancedto = value; }
        }

        IList<TLMDTO00017> listdrawingremittancedto = new List<TLMDTO00017>();
        public IList<TLMDTO00017> Listdrawingremittancedto { get { return listdrawingremittancedto; } set { listdrawingremittancedto = value; } }

        public string DrawingRegisterNo
        {
            get { return this.txtDrawingRegisterNo.Text; }
            set { this.txtDrawingRegisterNo.Text = value; }
        }

        public string GroupNo 
        {
            get { return this.lblGroupNo.Text; }
            set { this.lblGroupNo.Text = value; }
        }

        public object GridDataSource 
        {
            get { return this.gvDrawingAdjustment.DataSource; }
            set { this.gvDrawingAdjustment.DataSource = value; }
        }

        public string SourceBranchCode { get; set; }
        public string CurrencyCode { get; set; }
        public int updatedUserId { get; set; }
        public bool IsVoucher { get; set; }
        private bool saveStatus = false;
        public bool SaveStatus
        {
            get { return this.saveStatus; }
            set { this.saveStatus = value; }
        }
        #endregion Properties

        #region Event
        private void MNMVEW00027_Load(object sender, EventArgs e)
        {
            try
            {
                //Enable Disable for tool strip bar for Update/Delete/Insert/Select Operation
                this.tsbCRUD.ButtonEnableDisabled(false, false, false, true, true, false, true);
                this.InitializeControls();
                this.gvDrawingAdjustment.AutoGenerateColumns = false;
            }
            catch (Exception ex)
            {
                //Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME900043, new object[] { name, VoucherNo });
            }
        }
        #endregion Event

        #region Method
        private void InitializeControls()
        {
            this.txtDrawingRegisterNo.Select();
        }

        public void GridDataBind()
        {
            gvDrawingAdjustment.DataSource = null;
            gvDrawingAdjustment.DataSource = this.Listdrawingremittancedto;
        }
        #endregion

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.Controller.ClearControls();
            this.Controller.ClearErrors();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            //if (CXUIMessageUtilities.ShowMessageByCode("MC90001") == DialogResult.Yes)    //confirm to Delete or Reverse
            //{
            //    this.saveStatus = true;
            //    this.Controller.Save();
            //    gvDrawingAdjustment.DataError += new DataGridViewDataErrorEventHandler(gvDrawingAdjustment_DataError); //Added by ASDA
            //    gvDrawingAdjustment.DataError -= new DataGridViewDataErrorEventHandler(gvDrawingAdjustment_DataError);
            //}
        }

        private void gvDrawingAdjustment_DataError(object sender, DataGridViewDataErrorEventArgs e) //Added By ASDA
        {
            e.ThrowException = false;
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            if (CXUIMessageUtilities.ShowMessageByCode("MC90001") == DialogResult.Yes)    //confirm to Delete or Reverse
            {
                this.saveStatus = true;
                this.Controller.Save();
                gvDrawingAdjustment.DataError += new DataGridViewDataErrorEventHandler(gvDrawingAdjustment_DataError); //Added by ASDA
                gvDrawingAdjustment.DataError -= new DataGridViewDataErrorEventHandler(gvDrawingAdjustment_DataError);
            }
        }

        private void txtDrawingRegisterNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void MNMVEW00027_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

    }
}