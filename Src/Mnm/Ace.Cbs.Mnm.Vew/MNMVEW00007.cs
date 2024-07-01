//----------------------------------------------------------------------
// <copyright file="MNMVEW00007.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NEEA</CreatedUser>
// <CreatedDate>11/18/2013</CreatedDate>
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


namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00007 : BaseDockingForm,IMNMVEW00007
    {
        public MNMVEW00007()
        {
            InitializeComponent();
        }

        #region Properties

        public bool SavingAccrued
        {
            get 
            {
                if (this.rdoSavingAccrued.Checked)
                    return true;
                else
                    return false;
            }
            set { this.rdoSavingAccrued.Checked = value; }
        }

        public bool SavingNotAccrued
        {
            get
            {
                if (this.rdoSavingNotAccrued.Checked)
                    return true;
                else
                    return false;
            }
            set { this.rdoSavingNotAccrued.Checked = value; }
        }

        public bool FixedAccrued
        {
            get
            {
                if (this.rdoFixedAccrued.Checked)
                    return true;
                else
                    return false;
            }
            set { this.rdoFixedAccrued.Checked = value; }
        }

        public bool FixedNotAccrued
        {
            get
            {
                if (this.rdoFixedNotAccrued.Checked)
                    return true;
                else
                    return false;
            }
            set { this.rdoFixedNotAccrued.Checked = value; }
        }

        #endregion

        #region Controller

        private IMNMCTL00007 controller;
        public IMNMCTL00007 Controller
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

        #region Events

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
             string Saving_Checkitem=null;
            string Fixed_Checkitem=null;

            if (rdoSavingAccrued.Checked)
                Saving_Checkitem = rdoSavingAccrued.Text;

            else 
                Saving_Checkitem = rdoSavingNotAccrued.Text;

            if (rdoFixedAccrued.Checked)
                Fixed_Checkitem = rdoFixedAccrued.Text;

            else 
                Fixed_Checkitem = rdoFixedNotAccrued.Text;

            this.controller.Save(Saving_Checkitem,Fixed_Checkitem);

            this.controller.ClearErrors();
        }

        private void MNMVEW00007_Load(object sender, EventArgs e)
        {
            this.EnableDisableControls();   
            this.controller.SelectByKeyName();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.controller.ClearControls();
            this.controller.ClearErrors();
            this.InitializeControls();
        }

        #endregion

        #region Methods

        private void InitializeControls()
        {
            this.SavingAccrued = true;
            this.FixedAccrued = true;
        }
     
        private void EnableDisableControls()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
        }

        public void Successful(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);           
        }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }

        #endregion

       
            
    }
}
