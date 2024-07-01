//----------------------------------------------------------------------
// <copyright file="PFMVEW00012.cs" company="Ace Data Systems">
// Copyright (c) Ace Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Su Su Wai</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.PTR;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Pfm.Vew
{
    /// <summary>
    /// Link Account Entry
    /// </summary>
    public partial class frmPFMVEW00012 : BaseForm, IPFMVEW00012
    {

        #region Constractor

        /// <summary>
        /// Constructor.
        /// </summary>
        public frmPFMVEW00012()
        {
            InitializeComponent();
        }

        #endregion

        #region View Data Properties

        /// <summary>
        /// Current Account No 
        /// </summary>
        public string CurrentAccountNo
        {
            get { return this.mtxtCurrentAccountNo.Text.Trim(); }
            set { this.mtxtCurrentAccountNo.Text = value; }
        }

        /// <summary>
        /// Minumun Balance for Current Account No
        /// </summary>
        public decimal CurrentAccountMinimumBalance
        {
            get
            {
                if (this.ntxtCurrentMinimunBalance.Text.Trim().Equals(string.Empty))
                    return 0;
                else
                    return Convert.ToDecimal(this.ntxtCurrentMinimunBalance.Text.Trim());
            }
            set { this.ntxtCurrentMinimunBalance.Text = value.ToString(); }
        }

        /// <summary>
        /// Saving Account No
        /// </summary>
        public string SavingAccountNo
        {
            get { return this.mtxtSavingAccountNo.Text; }
            set { this.mtxtSavingAccountNo.Text = value; }
        }

        /// <summary>
        /// Minimun Balnace for Saving Account 
        /// </summary>
        public decimal SavingAccountMinimumBalance
        {
            get
            {
                if (this.ntxtSavingMinimunBalance.Text.Trim().Equals(string.Empty))
                    return 0;
                else
                    return Convert.ToDecimal(this.ntxtSavingMinimunBalance.Text.Trim());

            }
            set { this.ntxtSavingMinimunBalance.Text = value.ToString(); }
        }
        
        #endregion

        #region Presenter Controller

        /// <summary>
        /// Link Account Controller
        /// </summary>
        private IPFMCTL00012 linkAccountController;
        public IPFMCTL00012 LinkAccountController
        {
            set
            {
                this.linkAccountController = value;
                this.linkAccountController.LinkAccountView = this;
            }
            get
            {
                return this.linkAccountController;
            }
        }
        #endregion

        #region Entity

        /// <summary>
        /// Link Account Entity
        /// </summary>
        private PFMDTO00029 linkAccountEntity;
        public PFMDTO00029 LinkAccountEntity
        {
            get
            {
                if (this.linkAccountEntity == null) this.linkAccountEntity = new PFMDTO00029();
                this.linkAccountEntity.CurrentAccountNo = this.CurrentAccountNo;
                this.linkAccountEntity.MinimumCurrentAccountBalance = this.CurrentAccountMinimumBalance;
                this.linkAccountEntity.MinimumSavingAccountBalance = this.SavingAccountMinimumBalance;
                this.linkAccountEntity.SavingAccountNo = this.SavingAccountNo;
                return this.linkAccountEntity;
            }

            set { this.linkAccountEntity = value; }
        }

        #endregion

        #region Public Method

        /// <summary>
        /// Show successful message and clear control data
        /// </summary>
        /// <param name="message">Message Code</param>
        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.InitializedControl();
        }

        /// <summary>
        /// Show failuer message.
        /// </summary>
        /// <param name="message">Message Code</param>
        public void Failure(string message,string accountno)
        {
            CXUIMessageUtilities.ShowMessageByCode(message, new object[] { message == "MV00062" ? accountno : null }); 
            
            if (this.lvCurrentNames.Items.Count <= 0)
            {
                this.mtxtCurrentAccountNo.Focus();
            }
            else if (this.lvSavingNames.Items.Count <= 0)
            {
                mtxtSavingAccountNo.Focus();
            }            
        }

        /// <summary>
        /// Bind Customer Names by Current Account No.
        /// </summary>
        /// <param name="customerNames">customer names list collection</param>
        public void lvCurrentNames_DataBind(IList<string> customerNames)
        {
            // Clear all data in lvCurrentNames listView before binding data.
            this.lvCurrentNames.Items.Clear(); 
 
            // if customerNames is not equal to blank.
            if (customerNames != null)
            {
                // Bind CustomerNames into listView.
                int i = 0;
                while (i < customerNames.Count)
                {
                    if (!string.IsNullOrEmpty(customerNames[i]))  
                        this.lvCurrentNames.Items.Add(customerNames[i]);
                    i++;
                }
            }
        }

        /// <summary>
        /// Bind Customer Names by Current Account No.
        /// </summary>
        /// <param name="customerNames">customer names list collection</param>
        public void lvSavingNames_DataBind(IList<string> customerNames)
        {
            // Clear all data in lvSavingNames listView before binding data.
            this.lvSavingNames.Items.Clear();

            // if customerNames is not equal to blank.
            if (customerNames != null)
            {
                // Bind CustomerNames into listView.
                int i = 0;
                while (i < customerNames.Count)
                {
                    if (!string.IsNullOrEmpty(customerNames[i]))                    
                        this.lvSavingNames.Items.Add(customerNames[i]);
                    i++;
                }
            }
        }

        /// <summary>
        /// Clear data in controls
        /// </summary>
        private void InitializedControl()
        {
            this.linkAccountController.ClearControls();
            // Clear CurrentMinimumBalance Textbox.
            this.ntxtCurrentMinimunBalance.ResetText();

            // Clear SavingMinimunBalance TextBox.
            this.ntxtSavingMinimunBalance.ResetText();

            // Clear lvCurrentNames ListView Items.
            this.lvCurrentNames.Items.Clear();

            // Clear lvSavingNames ListView Items.
            this.lvSavingNames.Items.Clear();           
        }
        #endregion

        #region Event
        
        /// <summary>
        /// For Load Events
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void frmPFMVEW00012_Load(object sender, EventArgs e)
        {
            // Clear data in controls.
            this.InitializedControl();

            // Set format for CurrentAccountNo to Mask properties  
            this.mtxtCurrentAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);

            // Set format for SavingAccountNo to Mask properties  
            this.mtxtSavingAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);

            //Enable Disable for tool strip bar for Update/Delete/Insert/Select Operation
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
        }

        /// <summary>
        /// Save Button Click
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            // Call Save method to insert data into linkAC table.
            this.LinkAccountController.Save(this.LinkAccountEntity);
        }

        /// <summary>
        /// Cancel Button Click
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            // Clear data in input controls.
            this.InitializedControl();
            this.LinkAccountController.ClearErrors();
        }

        /// <summary>
        /// Close Button Click.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            // Close current form.
            this.Close();
        }
        /// <summary>
        /// CurrentMinimunBalance Textbox Click.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void ntxtCurrentMinimunBalance_Click(object sender, EventArgs e)
        {
            //select all text in textbox
            ntxtCurrentMinimunBalance.SelectAll();
        }
        /// <summary>
        /// SavingMinimunBalance Textbox Click.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void ntxtSavingMinimunBalance_Click(object sender, EventArgs e)
        {
            //select all text in textbox
            ntxtSavingMinimunBalance.SelectAll();
        }
        #endregion

        private void frmPFMVEW00012_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }
    }
}
