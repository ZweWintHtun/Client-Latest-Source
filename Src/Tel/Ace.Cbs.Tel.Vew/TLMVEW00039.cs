//----------------------------------------------------------------------
// <copyright file="TLMVEW00039.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-09-21</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//---------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.CXClient;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Tel.Vew
{
    /// <summary>
    /// (Listing -> Drawing Remittance Listing) -> Drawing Remittance Listing By Amount
    //  (Listing -> Encashment Remittance Listing) -> Encashment Remittance Listing By Amount
    /// </summary>
    
    public partial class TLMVEW00039 : BaseDockingForm,ITLMVEW00039
    {
        #region "Constructors"
        public TLMVEW00039()
        {
            InitializeComponent();
        }        

        public TLMVEW00039(bool isMainMenu, string parentFormId)
        {
            InitializeComponent();
            this.IsMainMenu = isMainMenu;
            this.ParentFormId = parentFormId;
        }
        #endregion

        #region " Controls Input Output"

        public string TransactionStatus
        {
            get { return this.FormName; }
        }

        private bool isMainMenu = true;
        public bool IsMainMenu
        {
            get { return this.isMainMenu; }
            set { this.isMainMenu = value; }
        }

        private string parentFormId = string.Empty;
        public string ParentFormId
        {
            get { return this.parentFormId; }
            set { this.parentFormId = value; }
        }

        public DateTime StartDate
        {
            get { return this.dtpEncashmentStartDate.Value; }
            set { this.dtpEncashmentStartDate.Text = value.ToString(); }
        }


        public DateTime EndDate
        {
            get { return this.dtpEncashmentEndDate.Value; }
            set { this.dtpEncashmentEndDate.Text = value.ToString(); }
        }

        public decimal StartAmount
        {
            get { return Convert.ToDecimal(this.ntxtStartAmount.Text); }
            set { this.ntxtStartAmount.Text = value.ToString(); }
        }

        public decimal EndAmount
        {
            get { return Convert.ToDecimal(this.ntxtEndAmount.Text); }
            set { this.ntxtEndAmount.Text = value.ToString(); }
        }

        #endregion

        #region "Controllers"
        private ITLMCTL00039 controller;
        public ITLMCTL00039 DrawingRemittanceEncashAmountController //WithdrawalListingByAllController
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                this.controller.DrawingRemittanceEncashAmountView = this;
            }
        }

        #endregion

        #region "Events"
        private void TLMVEW00039_Load(object sender, EventArgs e)
        {
            tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.InitializeControls();
        }
        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.rdoTransactionDate.Checked = true;
            this.dtpEncashmentStartDate.Value = DateTime.Now;
            this.dtpEncashmentEndDate.Value = DateTime.Now;
            this.ntxtStartAmount.Text = "0.00";
            this.ntxtEndAmount.Text = "0.00";
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {          
            if (this.CheckDate())
            {
                if (this.EndAmount > 0)
                {
                    IList<TLMDTO00017> DrawingEncashLists = new List<TLMDTO00017>();
                    if (this.parentFormId == "Drawing Remittance Listing" ) 
                    {
                        if (this.rdoTransactionDate.Checked == true)
                        {
                            DrawingEncashLists= this.DrawingRemittanceEncashAmountController.MainPrint("Drawing Remittance Listing By Transaction Date");
                           if (DrawingEncashLists.Count > 0)
                           {
                               CXUIScreenTransit.Transit("frmTLMVEW00058DrawingRemittanceAmountByTransactionDate", true, new object[] { DrawingEncashLists, "Drawing Remittance Listing By Transaction Date", this.StartDate, this.EndDate,"Drawing Remittance Listing (By Amount) Report" });
                           }
                           else
                           {
                               Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                           }
                        }

                        else
                        {
                           DrawingEncashLists= this.DrawingRemittanceEncashAmountController.MainPrint("Drawing Remittance Listing By Settlement Date");
                           if (DrawingEncashLists.Count > 0)
                           {
                               CXUIScreenTransit.Transit("frmTLMVEW00058DrawingRemittanceAmountBySettlementDate", true, new object[] { DrawingEncashLists, "Daily Drawing Remittance Listing By Settlement Date", this.StartDate, this.EndDate, "Drawing Remittance Listing (By Amount) Report" });
                           }
                           else
                           {
                               Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                           }
                        }
                    }

                    else
                    {
                        if (this.rdoTransactionDate.Checked == true)
                        {
                           DrawingEncashLists= this.DrawingRemittanceEncashAmountController.MainPrint("Encash Remittance Listing By Transaction Date");
                           if (DrawingEncashLists.Count > 0)
                           {
                               CXUIScreenTransit.Transit("frmTLMVEW00061EncashRemittanceAmountByTransactionDate", true, new object[] { DrawingEncashLists, "Encash Remittance Listing By Transaction Date", this.StartDate, this.EndDate, "Encash Remittance Listing (By Amount) Report" });
                           }
                           else
                           {
                               Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                           }
                        }

                        else
                        {
                           DrawingEncashLists= this.DrawingRemittanceEncashAmountController.MainPrint("Encash Remittance Listing By Settlement Date");
                           if (DrawingEncashLists.Count > 0)
                           {
                               CXUIScreenTransit.Transit("frmTLMVEW00061EncashRemittanceAmountBySettlementDate", true, new object[] { DrawingEncashLists, "Encash Remittance Listing By Settlement Date", this.StartDate, this.EndDate, "Encash Remittance Listing (By Amount) Report" });
                           }
                           else
                           {
                               Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                           }
                        }
                    }
                }
                else
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV20031");
                }
            }
        }


        private void ntxtEndAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter & Keys.Tab))
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void ntxtEndAmount_Leave(object sender, EventArgs e)
        {
            if (ntxtEndAmount.Text == "0.00")
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV20031");
                ntxtEndAmount.Focus();
            }
            else if (Convert.ToDecimal(ntxtStartAmount.Text) > Convert.ToDecimal(ntxtEndAmount.Text))
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00202");
                ntxtEndAmount.Focus();
            }
        }
        #endregion

        #region "Methods"
        private void InitializeControls()
        {
            tsbCRUD.butPrint.TabIndex = 9;
            if (ParentFormId == "Drawing Remittance Listing")
            {
                this.Text = "Drawing Remittance Listing (By Amount)";
                this.gbRemittanceListingByAmount.Text = "Drawing Remittance Listing (By Amount)";
            }
            else
            {
                this.Text = "Encash Remittance Listing (By Amount)";
                this.gbRemittanceListingByAmount.Text = "Encash Remittance Listing (By Amount)";
            }
        }

        private bool CheckDate()
        {
            bool date = CXCOM00006.Instance.IsValidStartDateEndDate(this.dtpEncashmentStartDate.Value, this.dtpEncashmentEndDate.Value);
            if (date == false)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00131");//Start Date must not be greater than End Date.
            }
            return date;
        }
        #endregion
    }
}


