//----------------------------------------------------------------------
// <copyright file="MNMVEW00166.cs" company="ACE Data Systems">
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
using Ace.Windows.Core.Utt;//Added by AAM(19-Jan-2018)
using Ace.Windows.Admin.DataModel;//Added by AAM(19-Jan-2018)

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00166 : BaseForm,IMNMVEW00166
    {
        #region Contructor
        public MNMVEW00166()
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
        public string AccountNo
        {
            get { return txtAcctno.Text; }
            set { txtAcctno.Text = value; }
        }
        public decimal Amount
        {
            get { return Convert.ToDecimal(txtAmount.Text); }
            set { txtAmount.Text = value.ToString(); }
        }
        public string Cheque
        {
            get { return txtCheque.Text; }
            set { txtCheque.Text = value; }
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

        private IMNMCTL00166 controller;
        public IMNMCTL00166 Controller
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
        private void MNMVEW00166_Load(object sender, EventArgs e)
        {
            #region Old_Logic

            //gvReversal.AutoGenerateColumns = false;
            //this.EnableDisableControls();
            //this.ParentFormId = this.Name;

            #endregion

            #region Seperating_EOD_Logic (Added By YMP at 30-07-2019, Modified by HMW at 26-08-2019)
            DateTime systemDate = this.Controller.GetSystemDate(CurrentUserEntity.BranchCode);
            DateTime lastSettlementDate = this.controller.GetLastSettlementDate(CurrentUserEntity.BranchCode);

            this.lblTransactionDate.Text = systemDate.ToString("dd-MM-yyyy");

            if (systemDate.ToString("dd-MM-yyyy") != lastSettlementDate.ToString("dd-MM-yyyy")) //Show Form
            {
                gvReversal.AutoGenerateColumns = false;
                this.EnableDisableControls();
                this.ParentFormId = this.Name;
            }
            else //Don't show form after cut off
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI50013);//You have no permission.\n"Back Date EOD Process" needs to be completed!
                this.tsbCRUDD.ButtonEnableDisabled(false, false, false, false, false, false, true);
                //this.InitializeControls();
                this.DisableControls("MutliDepostiWithdrawReverse.AllDisable");
            }
            #endregion
        }
        private void tsbCRUDD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUDD_CancelButtonClick(object sender, EventArgs e)
        {
            this.ClearControls();
            this.controller.ClearErrors();
            this.controller.ClearCustomErrorMessage();
            // this.EnableDisableControls();
            this.txtGroupNo.Focus();
            if(this.gvReversal.RowCount > 0)
                gvReversal.Rows.Clear();
            gvReversal.DataSource=null;
        }
        
        private void tsbCRUDD_SaveButtonClick(object sender, EventArgs e)
        {
            if (this.gvReversal.RowCount <= 0)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00171); //Grid Record must has at least one.
                this.txtGroupNo.Focus();
                return;
            }
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
                this.txtGroupNo.Focus();
                gvReversal.Rows.Clear();
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
                    this.txtGroupNo.Focus();
                    gvReversal.Rows.Clear();
                }
            }
        }
        
        private void MNMVEW00166_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }
        
        #endregion

        #region Methods

        private void ClearControls()
        {
            this.txtEntryNo.Text =string.Empty;
            this.txtGroupNo.Text = string.Empty;
            this.txtNarration.Text = string.Empty;
            txtAcctno.Text = string.Empty;
            txtAmount.Text = string.Empty;
            txtCheque.Text = string.Empty;
            this.gvReversal.DataSource = null;
            gvReversal.Rows.Clear();
        }
        
        public void ClearTextBox()
        {
            this.txtEntryNo.Text = string.Empty;
            this.txtGroupNo.Text = string.Empty;
            this.txtNarration.Text = string.Empty;
            txtAcctno.Text = string.Empty;
            txtAmount.Text = string.Empty;
            txtCheque.Text = string.Empty;
            if (gvReversal.RowCount > 0)
            {
                gvReversal.Rows.Clear();
                gvReversal.Refresh();
            }
        }
        
        public void EnableDisableControls()
        {
            tsbCRUDD.ButtonEnableDisabled(false, false, true, false, true, false, true);
        }

        public void FillData(IList<PFMDTO00054> BindData, IList<PFMDTO00001> CustData)
        {
            IList<PFMDTO00054> gridData = BindData;
            #region old
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

                // 
                if ((gridData[i].Narration.Contains("Income") || gridData[i].Narration.Contains("INCOME VOUCHER")) && gridData[i].AccountNo.Length == 6)
                    gridData[i].TransactionCode = "INCOME";
                else if ((gridData[i].Narration.Contains("Fax") || gridData[i].Narration.Contains("COMMUNICATION CHARGES")) && gridData[i].AccountNo.Length == 6)
                    gridData[i].TransactionCode = "COM CHARGES";
                else
                    this.status = gridData[i].TransactionCode;

            }
        #endregion
            gvReversal.Rows.Clear();
            for (int i = 0; i < CustData.Count; i++)
            {
                object[] str = { CustData[i].Name, CustData[i].NRC };

                this.gvReversal.CausesValidation = false;
                this.gvReversal.AutoGenerateColumns = false;
                gvReversal.Rows.Add(str);
                this.gvReversal.ReadOnly = true;
            }
            this.Narration = gridData[0].Description;
            this.AccountNo = gridData[0].AccountNo;
            this.Cheque = gridData[0].Cheque;
            //this.GroupNo = gridData[0].GroupNo;

            if (gridData[0].Status == "CCD")
                this.lblTransactionType.Text = "Multiple Deposit Transaction";
            else if (gridData[0].Status == "CDW")
                this.lblTransactionType.Text = "Multiple Withdraw Transaction";
        }
        
        public void Successful(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
            this.txtGroupNo.Focus();
        }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }

        #endregion  

        #region Old Code 
        //private void txtEntryNo_KeyDown(object sender, KeyEventArgs e)
        //{
        //    string entryNo = txtEntryNo.Text.ToString();
        //    if (entryNo != "")
        //    {
        //        if (entryNo.Substring(0, 2).ToString() == "00")
        //        {
        //            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00213); //Invalid Entry No.
        //            txtEntryNo.Text = "";
        //            txtEntryNo.Focus();
        //            return;
        //        }
        //        else
        //        {
        //            this.Controller.GetEntryData();
        //        }
        //    }
        //}
        #endregion

        //private void txtGroupNo_Leave(object sender, EventArgs e) //OK for Tab Key and Entry Key. Not ok for Cancel button and Exit button
        //{
        //    #region Old Code
        //    //string groupNo = txtGroupNo.Text.ToString();
        //    //if (groupNo != "")
        //    //{
        //    //    if (groupNo.Substring(0, 1).ToString() != "G")
        //    //    {
        //    //        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90119); //Invalid Group No.
        //    //        txtGroupNo.Text = "";
        //    //        txtGroupNo.Focus();
        //    //        return;
        //    //    }
        //    //}
        //    #endregion

        //    // Added by AAM (19-Jan-2018)
        //    if (txtGroupNo.Text != "")
        //    {
        //        if (txtGroupNo.Text.Length == 0)
        //        {
        //            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90151); //Group No is required.
        //            txtGroupNo.Focus();
        //            return;
        //        }

        //        string str = this.controller.Check_GroupNo_ValidOrNot_MultipleDepReversal(GroupNo, CurrentUserEntity.BranchCode);
        //        if (str == "-1")
        //        {
        //            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90119); //Invalid Group No.
        //            txtGroupNo.Text = "";
        //            txtGroupNo.Focus();
        //            return;
        //        }
        //    }
        //}

        private void txtGroupNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            if (e.KeyChar == '\t' || e.KeyChar == '\r')
            {
                if (txtGroupNo.Text != "")
                {
                    if (txtGroupNo.Text.Length == 0)
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90151); //Group No is required.
                        txtGroupNo.Focus();
                        return;
                    }
                    string str = this.controller.Check_GroupNo_ValidOrNot_MultipleDepReversal(GroupNo, CurrentUserEntity.BranchCode);
                    if (str == "-1")
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90119); //Invalid Group No.
                        txtGroupNo.Text = "";
                        txtGroupNo.Focus();
                        return;
                    }
                }
            }
        
        }

        private void txtEntryNo_Leave(object sender, EventArgs e)
        {
            #region Old Code
            //string entryNo = txtEntryNo.Text.ToString();
            //if (entryNo != "")
            //{
            //    if (entryNo.Substring(0, 2).ToString() == "00")
            //    {
            //        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00213); //Invalid Entry No.
            //        txtEntryNo.Text = "";
            //        txtEntryNo.Focus();
            //        return;
            //    }
            //    else
            //    {
                    //this.Controller.GetEntryData();
                //}
            //}
            #endregion

            // Added by AAM (22-Jan-2018)
            string entryNo = txtEntryNo.Text.ToString(); // Added by ZMS(16.11.18)
            if (entryNo != "")// Added by ZMS(16.11.18)
            {
                //string str = this.controller.Check_EntryNo_ValidOrNot_MultipleDepReversal(EntryNo, CurrentUserEntity.BranchCode);
                string str = this.controller.Check_EntryNo_ValidOrNot_MultipleDepWdwReversal(EntryNo, CurrentUserEntity.BranchCode);
                if (str == "-1")
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90119); //Invalid Group No.
                    txtEntryNo.Text = "";
                    txtEntryNo.Focus();                  
                    txtAcctno.Text = "";
                    txtAmount.Text = "";
                    txtNarration.Text = "";
                    txtCheque.Text = "";
                    gvReversal.Rows.Clear();                   

                    return;
                }
                if (str == "-2")
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00213); //Invalid Entry No.
                    txtEntryNo.Text = "";
                    txtEntryNo.Focus(); // modified by ZMS (13.11.18)
                    #region Add by AAM (25_Sep_2018)
                    txtAcctno.Text = "";
                    txtAmount.Text = "";
                    txtNarration.Text = "";
                    txtCheque.Text = "";
                    gvReversal.Rows.Clear();
                    #endregion

                    return;
                }
                else if (str == "-3")
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME30003); //Not allowed already reversal.
                    txtEntryNo.Text = "";
                    txtEntryNo.Focus();
                    #region Add by ZMS  (13.11.18)
                    txtAcctno.Text = "";
                    txtAmount.Text = "";
                    txtNarration.Text = "";
                    txtCheque.Text = "";
                    gvReversal.Rows.Clear();
                    #endregion
                    return;
                }

                else if (str == "-4")
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI50012); //Already Cut Off! \nNot Allowed Reversal for "Before Cut Off Transactions".
                    txtEntryNo.Text = "";
                    txtEntryNo.Focus();
                    #region Add by ZMS  (13.11.18)
                    txtAcctno.Text = "";
                    txtAmount.Text = "";
                    txtNarration.Text = "";
                    txtCheque.Text = "";
                    gvReversal.Rows.Clear();
                    #endregion
                    return;
                }

                else if (str == "-5")//Checking Previous Day TXN at "Tomorrow Morning after EOD"
                {  
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME30002); //Not Allowed Back Date Transaction!
                    txtEntryNo.Text = "";
                    txtEntryNo.Focus(); // modified by ZMS (13.11.18)
                    #region Add by ZMS  (13.11.18)
                    txtAcctno.Text = "";
                    txtAmount.Text = "";
                    txtNarration.Text = "";
                    txtCheque.Text = "";
                    gvReversal.Rows.Clear();
                    #endregion
                    return;
                }
                else if (str == "-6")//Checking normal backdate TXN at "Normal EOD Day (Before Cut Off Time)"
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME30002); //Not Allowed Back Date Transaction!
                    txtEntryNo.Text = "";
                    txtEntryNo.Focus();                   
                    txtAcctno.Text = "";
                    txtAmount.Text = "";
                    txtNarration.Text = "";
                    txtCheque.Text = "";
                    gvReversal.Rows.Clear();
                  
                    return;
                }
                else if (str == "-7")//Checking normal backdate TXN at "After Cut Off" time
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME30002); //Not Allowed Back Date Transaction!
                    txtEntryNo.Text = "";
                    txtEntryNo.Focus();
                    txtAcctno.Text = "";
                    txtAmount.Text = "";
                    txtNarration.Text = "";
                    txtCheque.Text = "";
                    gvReversal.Rows.Clear();

                    return;
                }
                else if (str == "-8")
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90202); //Not Allow Individuals Deposit/Withdraw Transaction!
                    txtEntryNo.Text = "";
                    txtEntryNo.Focus();
                    txtAcctno.Text = "";
                    txtAmount.Text = "";
                    txtNarration.Text = "";
                    txtCheque.Text = "";
                    gvReversal.Rows.Clear();

                    return;
                }

                else if (str == "0")//Successful
                {
                    this.controller.GetEntryData();
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {                        
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }
            }
        }

        

    }
}
