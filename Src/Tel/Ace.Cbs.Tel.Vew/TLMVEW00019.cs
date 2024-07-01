//----------------------------------------------------------------------
// <copyright file="TLMVEW00019.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Yu Thandar Aung</CreatedUser>
// <CreatedDate></CreatedDate>
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
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Dmd;


namespace Ace.Cbs.Tel.Vew
{
    public partial class TLMVEW00019 : BaseForm, ITLMVEW00019
    {
        #region Constructor
        public TLMVEW00019()
        {
            InitializeComponent();

        }
        #endregion

        #region Controller
        private ITLMCTL00019 controller;
        public ITLMCTL00019 Controller
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
        #endregion

        #region Properties
        public string RegisterNo
        {
            get
            {
                if (this.cboRegisterNo.Text == null)
                {
                    return null;
                }
                else
                {
                    return this.cboRegisterNo.Text.ToString();
                }
            }
            set
            {
                this.cboRegisterNo.Text = value;
                // this.cboRegisterNo.SelectedValue = value;
            }
        }

        public bool VIP
        {
            get { return chkVIP.Checked; }
            set { chkVIP.Checked = value; }
        }

        public string ParentFormId
        {
            get { return this.Name; }
        }

     

        private CXDMD00010 currentFormPermissionEntity;
        public CXDMD00010 CurrentFormPermissionEntity
        {
            get
            { return this.currentFormPermissionEntity; }
            set
            { this.currentFormPermissionEntity = value; }
        }

        public IList<TLMDTO00017> RegisterNoDataSource { get; set; }
        public IList<TLMDTO00050> RegisterNoInformation { get; set; }
        public string CurrencyCode { get; set; }
        public string type { get; set; }
        public bool IsInitial;
        #endregion

        #region Events
        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TLMVEW00019_Load(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.EnableDisableControls();
            this.CurrentFormPermissionEntity = new CXDMD00010();
          
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            if (this.cboRegisterNo.SelectedIndex == -1)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00167);//Blank Registerno not allowed.
                cboRegisterNo.Focus();
                return;
            }
            else
            {
                this.controller.Save();
                 cboRegisterNo.Focus();
                //this.InitializeControls();
            }

        //    cboRegisterNo.Focus();        
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.controller.ClearErrors();
        }

        //private void cboRegisterNo_Validated(object sender, EventArgs e)
        //{
          
        //}

        private void gvDrawingRemitt_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        #endregion

        #region Methods
        private void InitializeControls()
        {
         //   this.cboRegisterNo.Focus();
            this.cboRegisterNo.Select();
            this.cboRegisterNo.Enabled = true;
            this.cboRegisterNo.SelectedIndex = -1;
            this.gvDrawingRemitt.DataSource = null;
            this.chkVIP.Checked = false;
            this.IsInitial = true;
            if (this.FormName.Equals("DrawingRemittanceVoucher.IBL"))
            {
                this.Text = "Drawing Remittance Voucher Entry(IBL)";
                type = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.InterBranchLinking); //IBL
                this.RegisterNoDataSource = this.controller.GetRegisterNo(type);
            }
            else
            {
                this.Text = "Drawing Remittance Voucher Entry(FX)";
                type = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.OtherBankLinking); //IBS
                this.RegisterNoDataSource = this.controller.GetRegisterNo(type);
            }


            if (this.RegisterNoDataSource.Count > 0)
            {
                this.BindRegisterNo();
            }
            else
            {
                cboRegisterNo.Enabled = false;
                //CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00055);//There is no Register No.
                //this.cboRegisterNo.Focus();
            }
          //  this.lblsourcebr.Text = this.Controller.GetSaveData().BankName;                
           this.lblsourcebr.Text = this.Controller.SourceBr;  //edited by ASDA
        }

        private void EnableDisableControls()
        {
            tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
        }

        public void BindRegisterNo()
        {
            cboRegisterNo.ValueMember = "RegisterNo";
            cboRegisterNo.DisplayMember = "RegisterNo";
            cboRegisterNo.DataSource = RegisterNoDataSource;
            this.cboRegisterNo.SelectedIndex = -1;
        }

        public void gvDrawingRemitt_DataBind()
        {
            this.gvDrawingRemitt.DataSource = null;
            gvDrawingRemitt.AutoGenerateColumns = false;
            if (this.FormName.Equals("DrawingRemittanceVoucher.IBL"))
            {
                string Drawing_Type = "IBL";
                this.gvDrawingRemitt.DataSource = controller.BindRegisterNoInformation(Drawing_Type);   
            }
            else
            {
                string Drawing_Type = "IBS";
                this.gvDrawingRemitt.DataSource = controller.BindRegisterNoInformation(Drawing_Type);   
            }
            //this.gvDrawingRemitt.DataSource = controller.BindRegisterNoInformation();            
        }

        public void Successful(string message, string VoucherNo)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message, new object[] { "Voucher No", VoucherNo });
            this.InitializeControls();
            this.BindRegisterNo();
        }

        public void Failure(string message,string accountNo)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message,new object[]{accountNo});
            //this.InitializeControls();
        }

        private void cboRegisterNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.IsInitial == false)
            {
                this.gvDrawingRemitt_DataBind();
                this.gvDrawingRemitt.ReadOnly = true;
                this.gvDrawingRemitt.Enabled = false;
                
            }
            this.IsInitial = false;
        }

        private void cboRegisterNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                if (this.IsInitial == false)
                {
                    this.gvDrawingRemitt_DataBind();
                    this.gvDrawingRemitt.ReadOnly = true;
                    this.gvDrawingRemitt.Enabled = false;

                }
                this.IsInitial = false;
            }
        }

        private void TLMVEW00019_Move(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        //private void gvDrawingRemitt_Leave(object sender, EventArgs e)
        //{
        //    this.tsbCRUD.Focus();
        //}

        //public void SetFocus()
        //{
        //    this.SelectNextControl(this.ActiveControl, true, true, true, true);
        //}
        #endregion

        //private void cboRegisterNo_Leave(object sender, EventArgs e)
        //{
        //    this.gvDrawingRemitt_DataBind();
        //    this.SelectNextControl(this.ActiveControl, true, true, true, true);
        //    //this.tsbCRUD.Focus();
        //    //this.SetEnableDisable("cboRegisterNo", false); }
        //}

        //private void cboRegisterNo_Validated(object sender, EventArgs e)
        //{
        //    this.gvDrawingRemitt_DataBind();
        //    if (this.gvDrawingRemitt.RowCount != 0)
        //    { this.cboRegisterNo.Enabled = false; }
        //}

        //private void cboRegisterNo_Validating(object sender, CancelEventArgs e)
        //{
        //    this.gvDrawingRemitt_DataBind();
        //    if (this.gvDrawingRemitt.RowCount != 0)
        //    { this.cboRegisterNo.Enabled = false; }
        //}
    }
}


        

       
       




   