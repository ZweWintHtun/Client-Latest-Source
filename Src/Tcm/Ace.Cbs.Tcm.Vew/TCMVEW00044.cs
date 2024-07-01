//----------------------------------------------------------------------
// <copyright file="TCMVEW00044.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-12-09</CreatedDate>
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
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;

namespace Ace.Cbs.Tcm.Vew
{
    /// <summary>
    /// Listing -> PO Printing
    /// </summary>
    public partial class TCMVEW00044 : BaseDockingForm,ITCMVEW00044
    {
        #region "Constructor"
        public TCMVEW00044()
        {
            InitializeComponent();
        }
        #endregion
    
        #region "Controls Input Output"

        public IList<TLMDTO00001> REDTOList { get; set; }

        public DateTime RequiredDate
        {
            get
            {
                return this.dtpDate.Value;
            }
            set
            {               
                this.dtpDate.Text=value.ToString();
            }
        }

        #endregion

        #region "Controller"
        private ITCMCTL00044 poprintingController;
        public ITCMCTL00044 POPrintingController
        {
            get
            {
                return this.poprintingController;
            }
            set
            {
                this.poprintingController = value;
                this.poprintingController.POPrintingView = this;
            }
        }
        #endregion

        #region "Methods"

        public void HideShowChequeNo(bool isshowhide)
        {
            if (isshowhide == true)
            {
                this.lblNoCheque.Show();
            }
            else
            {
                this.lblNoCheque.Hide();
            }
        }

        private void EnableDisableControls()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
        }

        /* To select RE DTOList from RE Table.*/
        private IList<TLMDTO00001> SelectPOPrinting()
        {
            this.REDTOList = this.poprintingController.SelectREDTOList(this.RequiredDate);
            /*IF No Data according to UserRequired Date,this message is shown.*/
            if (this.REDTOList.Count.Equals(0))
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                return null;
            }
            return REDTOList;
        }

        /*When Tab or Enter Key is downed,to Bind GridView DataLists from SelectPOPrinting Private Method*/
        public void BindGridView()
        {
            this.gvPOPrinting.DataSource = null;
            this.gvPOPrinting.AutoGenerateColumns = false;           
            this.gvPOPrinting.DataSource = this.SelectPOPrinting();
            this.gvPOPrinting.Enabled = true;
        }

        public void InitializeControls()
        {
            this.EnableDisableControls();
            this.RequiredDate = DateTime.Now;
            /*Get Date Format*/            
           CXCOM00006.Instance.GetDateFormat(this.RequiredDate);
           this.gvPOPrinting.Enabled = false;
        }
        
        #endregion

        #region "Events"
        private void tsbCRUD_Load(object sender, EventArgs e)
        {
           this.InitializeControls();
           this.HideShowChequeNo(false);         
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            if (this.gvPOPrinting.Enabled == true)
            {
                /*Get Budget Year "13-14" Format.*/                
                string budgetYear = "/" + CXCOM00010.Instance.GetBudgetYear3(CurrentUserEntity.BranchCode, DateTime.Now);
                IList<TLMDTO00001> REDTOs = this.REDTOList.Where<TLMDTO00001>(x => x.IsCheck == true).ToList();
                if (REDTOs.Count.Equals(0))
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME30013);/* No PO Records are selected. */
                }
                else
                {
                    CXUIScreenTransit.Transit("frmTCMVEW00061", true, new object[] { REDTOs, "Encashment Printing for (PO / AC)" });
                    this.BindGridView();
                }
            }
            else
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME30013);/* No PO Records are selected. */
            }
        }


        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.poprintingController.ClearErrors();
            this.InitializeControls();           
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        /*To Bind Grid View,when user enters EnterKey or TabKey*/
        private void dtpDate_KeyDown(object sender, KeyEventArgs e)
        {            
            if ((Keys)e.KeyCode == Keys.Enter || (Keys)e.KeyCode == Keys.Tab)
            {
                if (this.poprintingController.CheckDate()==false)
                {
                    this.BindGridView();
                }
            }
        }
        #endregion
       
    }
}

