//----------------------------------------------------------------------
// <copyright file="MNMVEW00021.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>HM</CreatedUser>
// <CreatedDate>04/02/2014</CreatedDate>
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
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Utt;


namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00021 : BaseDockingForm,IMNMVEW00021
    {
       
        #region Constructor

        public MNMVEW00021()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties

        public string RegisterNo1
        {
            get { return this.txtRegisterNo1.Text; }
            set { this.txtRegisterNo1.Text = value; }
        }

        public string RegisterNo2
        {
            get { return this.txtRegisterNo2.Text; }
            set { this.txtRegisterNo2.Text = value; }
        }

        public string Amount1
        {
            get { return this.txtAmount1.Text; }
            set { this.txtAmount1.Text = value; }
        }

        public string Amount2
        {
            get { return this.txtAmount2.Text; }
            set { this.txtAmount2.Text = value; }
        }

        public string PayerName1
        {
            get { return this.txtPayerName1.Text; }
            set { this.txtPayerName1.Text = value; }
        }

        public string PayerName2
        {
            get { return this.txtPayerName2.Text; }
            set { this.txtPayerName2.Text = value; }
        }

        public string PayeeName1
        {
            get { return this.txtPayeeName1.Text; }
            set { this.txtPayeeName1.Text = value; }
        }

        public string PayeeName2
        {
            get { return this.txtPayeeName2.Text; }
            set { this.txtPayeeName2.Text = value; }
        }

        public string DraweBankCode1
        {
            get { return this.txtDBank1.Text; }
            set { this.txtDBank1.Text = value; }
        }

        public string DraweBankCode2
        {
            get { return this.txtDBank2.Text; }
            set { this.txtDBank2.Text = value; }
        }

        public string DraweBankName1
        {
            get { return this.txtDraweeBank1.Text; }
            set { this.txtDraweeBank1.Text = value; }
        }

        public string DraweBankName2
        {
            get { return this.txtDraweeBank2.Text; }
            set { this.txtDraweeBank2.Text = value; }
        }

        public string Currency1
        {
            get { return this.lblCur1.Text; }
            set { this.lblCur1.Text = value; }
        }

        public string Currency2
        {
            get { return this.lblCur2.Text; }
            set { this.lblCur2.Text = value; }
        }

        #endregion

        #region Controller

        private IMNMCTL00021 controller;
        public IMNMCTL00021 Controller
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

        #region Methods

        public void Successful(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV20085", new object[] { message });
            this.txtRegisterNo1.Focus();
        }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV20085", new object[] { message });
            
            
        }

        public void ClearControls()
        {
            this.txtRegisterNo1.Focus();
            this.RegisterNo1 = string.Empty;
            this.RegisterNo2 = string.Empty;
            this.Amount1 = string.Empty;
            this.Amount2 = string.Empty;
            this.Currency1 = string.Empty;
            this.Currency2 = string.Empty;
            this.DraweBankCode1 = string.Empty;
            this.DraweBankCode2 = string.Empty;
            this.DraweBankName1 = string.Empty;
            this.DraweBankName2 = string.Empty;
            this.PayerName1 = string.Empty;
            this.PayerName2 = string.Empty;
            this.PayeeName1 = string.Empty;
            this.PayeeName2 = string.Empty;
            this.Controller.isFinish = false; 

        }

        #endregion

        #region Events

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.controller.Save();                                                       
        }       

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.Controller.ClearCustomErrorMessage();
            ClearControls();
            this.tsbCRUD.CausesValidation = false;
            this.txtRegisterNo1.Focus();
        }
      

        private void MNMVEW00021_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, true, true);
            this.txtRegisterNo1.Focus();
            this.ClearControls();
           

        }

        #endregion

        private void txtRegisterNo2_Leave(object sender, EventArgs e)
        {

            if (this.ActiveControl.Name.Contains("tsbCRUD") && this.txtRegisterNo2.ContainsFocus)
            {
                this.tsbCRUD.CausesValidation = true;
            }
            //if (this.ActiveControl.Name.Contains("tsbCRUD") && !this.txtRegisterNo2.ContainsFocus)
            //{
            //    this.tsbCRUD.CausesValidation = false;
            //}
        }



    }
}
