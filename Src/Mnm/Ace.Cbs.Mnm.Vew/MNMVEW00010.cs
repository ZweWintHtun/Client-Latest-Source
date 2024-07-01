//----------------------------------------------------------------------
// <copyright file="MNMVEW00010.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NEEA</CreatedUser>
// <CreatedDate>11/6/2013</CreatedDate>
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
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Mnm.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;




namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00010 : BaseForm, IMNMVEW00010
    {
        #region Contructor
        public MNMVEW00010()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties

        private string parentFormId = string.Empty;
        public string ParentFormId
        {
            get { return this.parentFormId; }
            set { this.parentFormId = value; }
        }

        public string GroupNo
        {
            get { return txtGroupNo.Text; }
            set { txtGroupNo.Text = value; }
        }

        public string EntryNo
        {
            get { return txtEntryNo.Text; }
            set { txtEntryNo.Text = value; }
        }

        public string Narration
        {
            get { return txtNarration.Text; }
            set { txtNarration.Text = value; }
        }

        private string status;
        public string Status
        {
            get { return this.status; }
            set { this.status = value; }
        }

        public bool PrintStatus { get; set; }
        #endregion

        #region Controller

        private IMNMCTL00010 controller;
        public IMNMCTL00010 Controller
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

        private IList<PFMDTO00054> reversalDataSource;
        public IList<PFMDTO00054> ReversalDataSource
        {
            get
            {
                if (this.reversalDataSource == null)
                    this.reversalDataSource = new List<PFMDTO00054>();

                return this.reversalDataSource;
            }
            set
            {
                this.reversalDataSource = value;
            }
        }
        #endregion

        #region Events

        private void MNMVEW00010_Load(object sender, EventArgs e)
        {
            #region Old_Logic
            /*
            gvReversal.AutoGenerateColumns = false;
            this.EnableDisableControls();
            this.ParentFormId = this.Name.ToString();
            */
            #endregion

            DateTime systemDate = this.Controller.GetSystemDate(CurrentUserEntity.BranchCode);
            this.lblTransactionDate.Text = systemDate.ToString("dd-MM-yyyy");

            gvReversal.AutoGenerateColumns = false;
            this.EnableDisableControls();
            this.ParentFormId = this.Name.ToString();
        }           

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            if (this.gvReversal.RowCount <= 0)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00171); //Grid Record must has at least one.
                this.txtEntryNo.Focus();
                return;
            }
            //Added by ASDA***
            //if (!this.EntryNo.StartsWith("I") && !String.IsNullOrEmpty(this.GroupNo) && this.status == "WITHDRAW")
            if (!String.IsNullOrEmpty(this.GroupNo))
            {
                CXUIScreenTransit.Transit("frmMNMVEW00146", true, new object[] { this.GroupNo, this.EntryNo });
                string status = CXUIScreenTransit.GetData<string>("MNMVEW00146");
                if (status == "1")  //YES
                {                    
                    this.Controller.Save();                    
                }
                this.ClearControls();
                this.controller.ClearErrors();
                this.txtEntryNo.Focus();
            }
                //End***
            else
            {
                if (CXUIMessageUtilities.ShowMessageByCode("MC00004") == DialogResult.Yes)    //confirm to save
                {
                    this.Controller.Save();
                    this.ClearControls();
                    this.controller.ClearErrors();
                    // this.EnableDisableControls();
                    this.txtEntryNo.Focus();
                }
            } 
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.ClearControls();
            this.controller.ClearErrors();
            this.controller.ClearCustomErrorMessage();
           // this.EnableDisableControls();
            this.txtEntryNo.Focus();
        }

        #endregion

        #region Methods

        private void ClearControls()
        {
            this.txtEntryNo.Text =string.Empty;
            this.txtGroupNo.Text = string.Empty;
            this.txtNarration.Text = string.Empty;
            this.gvReversal.DataSource = null;           
        }

        public void EnableDisableControls()
        {
            tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
        }

        public void FillData(IList<PFMDTO00054> BindData)
        {
            IList<PFMDTO00054> gridData = BindData;
            for (int i = 0; i < gridData.Count; i++)
            {
                #region Message one
                /*
                if (gridData[i].TransactionCode == "CSDEBIT" || gridData[i].TransactionCode == "TRDEBIT" || gridData[i].TransactionCode == "WITHDRAW")
                {
                    // Checking that this transaction is income or other transaction  // Update By NLH
                    if (!gridData[i].Narration.Contains("Income") || gridData[i].AccountNo.Length != 6)
                    {
                        this.status = gridData[i].TransactionCode;
                    }
                    //this.status = gridData[0].TransactionCode;
                    gridData[i].TransactionCode = "Debit";
                }

                else if (gridData[i].TransactionCode == "CSCREDIT" || gridData[i].TransactionCode == "TRCREDIT" || gridData[i].TransactionCode == "DEPOSIT")
                {
                    // Checking that this transaction is income or other transaction  // Update By NLH
                    if (!gridData[i].Narration.Contains("Income") || gridData[i].AccountNo.Length != 6)
                    {
                        this.status = gridData[i].TransactionCode;
                    }
                    //this.status = gridData[0].TransactionCode;
                    gridData[i].TransactionCode = "Credit";

                }\*/

                #endregion

                switch (gridData[i].TransactionCode) 
                {
                    case "CSDEBIT": gridData[i].TransactionCode = "Withdraw";
                        break;
                    case "TRDEBIT": gridData[i].TransactionCode = "Tr Debit";
                        break;
                    case "TRCREDIT": gridData[i].TransactionCode = "Tr Credit";
                        break;
                    case "CSCREDIT": gridData[i].TransactionCode = "Deposit";
                        break;
                }

                /* Not requried for Pristine (Comment by HMW at 18-06-2020)
                if ((gridData[i].Narration.Contains("Income") || gridData[i].Narration.Contains("INCOME VOUCHER")) && gridData[i].AccountNo.Length == 6)
                    gridData[i].TransactionCode = "INCOME";
                else if ((gridData[i].Narration.Contains("Fax") || gridData[i].Narration.Contains("COMMUNICATION CHARGES")) && gridData[i].AccountNo.Length == 6)
                    gridData[i].TransactionCode = "COM CHARGES";
                else
                    this.status = gridData[i].TransactionCode;              
                 * */

            }
            this.gvReversal.DataSource = gridData;
            this.Narration = gridData[0].Narration; //Modify by HMW at 20.5.2019 (Set the right Narration)
            this.GroupNo = gridData[0].GroupNo;
        }

        public void Successful(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
            this.txtEntryNo.Focus();
        }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
            this.txtEntryNo.Focus();
        }

        #endregion

        private void MNMVEW00010_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

        //Added and Modify by HMW at 20-5-2019        
        //private void txtEntryNo_KeyDown(object sender, KeyEventArgs e)//OK for Enter Key Only. Not ok for Cancel button and Exit button
        //{           
        //    if (this.txtEntryNo.Text.ToString() != "" || this.txtEntryNo.Text.ToString() != string.Empty)
        //    {
        //        if (this.txtEntryNo.Text.Length == 13)
        //        {
        //            this.Controller.GetInfoByEntryNo();
        //            string messageCode;
        //            messageCode = CXClientWrapper.Instance.ServiceResult.MessageCode;
        //            if (messageCode != "")
        //            {
        //                this.Failure(messageCode);
        //            }
        //        }
        //    }            
        //}

        //Added and Modify by HMW at 20-5-2019 
        //private void txtEntryNo_Leave(object sender, EventArgs e)//OK for Tab Key and Entry Key. Not ok for Cancel button and Exit button
        //{            
        //    if (this.txtEntryNo.Text.ToString() != "" || this.txtEntryNo.Text.ToString() != string.Empty)
        //    {
        //        if (this.txtEntryNo.Text.Length == 13)
        //        {
        //            this.Controller.GetInfoByEntryNo();
        //            string messageCode;
        //            messageCode = CXClientWrapper.Instance.ServiceResult.MessageCode;
        //            if (messageCode != "")
        //            {
        //                this.Failure(messageCode);
        //            }
        //        }
        //    }
        //    else return;
        //}

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtEntryNo_KeyPress(object sender, KeyPressEventArgs e)//OK for Entry Key only. Ok for Cancel button and Exit button
        {
            if (e.KeyChar == '\t' || e.KeyChar == '\r')            
            {
                if (this.txtEntryNo.Text.ToString() != "" || this.txtEntryNo.Text.ToString() != string.Empty)
                {
                    this.Controller.GetInfoByEntryNo();
                    this.gvReversal.Columns[2].DefaultCellStyle.Format = "N2"; //Added by HMW at 08-Oct-2019 : Adding "Thousand Seperators"
                    string messageCode;
                    messageCode = CXClientWrapper.Instance.ServiceResult.MessageCode;
                    if (messageCode != "")
                    {
                        this.Failure(messageCode);
                    }
                }
                else return;
            }
        }     
    }
}
