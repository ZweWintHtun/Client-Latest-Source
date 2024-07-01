//----------------------------------------------------------------------
// <copyright file="TLMVEW00040.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-09-24</CreatedDate>
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
using Microsoft.Reporting.WinForms;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using System.IO;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Tel.Vew
{
    /// <summary>
    /// (Listing -> Drawing Remittance Listing) -> Drawing Remittance Listing By NRC
      //(Listing -> Encashment Remittance Listing) -> Encashment Remittance Listing By NRC
      //(Listing -> Drawing Remittance Listing) -> Drawing Remittance Listing By Name
      //(Listing -> Encashment Remittance Listing) -> Encashment Remittance Listing By Name
    /// </summary>
    public partial class TLMVEW00040 : BaseDockingForm, ITLMVEW00040
    {
        #region "Constructors"
        public TLMVEW00040()
        {
            InitializeComponent();
        }

        public TLMVEW00040(bool isMainMenu, string parentFormId, string transactionBy)
        {
            InitializeComponent();
            this.IsMainMenu = isMainMenu;
            this.ParentFormId = parentFormId;
            this.TransactionBy = transactionBy;
        }

        #endregion

        #region "Input Output Controls"

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

        private string transactionBy = string.Empty;
        public string TransactionBy
        {
            get { return this.transactionBy; }
            set { this.transactionBy = value; }
        }

        public DateTime StartDate
        {
            get { return this.dtpStartDate.Value; }
            set { this.dtpStartDate.Text = value.ToString(); }
        }


        public DateTime EndDate
        {
            get { return this.dtpEndDate.Value; }
            set { this.dtpEndDate.Text = value.ToString(); }
        }

        public string NameAndNRC
        {
            get { return this.txtTemp.Text.Trim(); }
            set { this.txtTemp.Text = value; }
        }

        #endregion

        #region "Controllers"
        private ITLMCTL00040 controller;
        public ITLMCTL00040 DrawingRemittanceEncashNRCandNameController
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                this.controller.DrawingRemittanceEncashNRCandNameView = this;
            }
        }

        #endregion

        #region "Events"
        private void TLMVEW00040_Load(object sender, EventArgs e)
        {
            tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.InitializeControls();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.txtTemp.Text = string.Empty;
            this.chkExactly.Checked = false;
            this.dtpStartDate.Value = DateTime.Today;
            this.dtpEndDate.Value = DateTime.Today;
            this.controller.ClearErrors();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            if (this.CheckDate())
            {
                IList<TLMDTO00017> DrawingEncashLists = new List<TLMDTO00017>();

                if (this.Text == "Drawing Remittance Listing (By NRC)")
                {
                    //NRC by Transaction Date
                    if (this.rdoTransactionDate.Checked == true)
                    {
                        // With Exactly
                        if (this.chkExactly.Checked == true)
                        {
                            DrawingEncashLists = this.DrawingRemittanceEncashNRCandNameController.MainPrint("Drawing Remittance NRC Exactly By Transaction Date");
                            if (DrawingEncashLists.Count > 0)
                            {
                                CXUIScreenTransit.Transit("frmTLMVEW00058DrawingRemitNRCExactlyByTransactionDate", true, new object[] { DrawingEncashLists, "Drawing Remittance Listing By Transaction Date", this.StartDate, this.EndDate, "Drawing Remittance Listing (By NRC) Report" });
                            }
                            else
                            {
                                // Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                            }
                        }

                        // Without Exactly
                        else
                        {
                            DrawingEncashLists = this.DrawingRemittanceEncashNRCandNameController.MainPrint("Drawing Remittance NRC By Transaction Date");
                            if (DrawingEncashLists.Count > 0)
                            {
                                CXUIScreenTransit.Transit("frmTLMVEW00058DrawingRemitNRCByTransactionDate", true, new object[] { DrawingEncashLists, "Drawing Remittance Listing By Transaction Date", this.StartDate, this.EndDate, "Drawing Remittance Listing (By NRC) Report" });
                            }
                            else
                            {
                                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                            }
                        }

                    }

                    //NRC by Settlement Date
                    else
                    {
                        if (this.chkExactly.Checked == true)
                        {
                            DrawingEncashLists = this.DrawingRemittanceEncashNRCandNameController.MainPrint("Drawing Remittance NRC Exactly By Settlement Date");
                            if (DrawingEncashLists.Count > 0)
                            {
                                CXUIScreenTransit.Transit("frmTLMVEW00058DrawingRemitNRCExactlyBySettlementDate", true, new object[] { DrawingEncashLists, "Drawing Remittance Listing By Settlement Date", this.StartDate, this.EndDate, "Drawing Remittance Listing (By NRC) Report" });
                            }
                            else
                            {
                                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                            }
                        }

                        else
                        {
                            DrawingEncashLists = this.DrawingRemittanceEncashNRCandNameController.MainPrint("Drawing Remittance NRC By Settlement Date");
                            if (DrawingEncashLists.Count > 0)
                            {
                                CXUIScreenTransit.Transit("frmTLMVEW00058DrawingRemitNRCBySettlementDate", true, new object[] { DrawingEncashLists, "Drawing Remittance Listing By Settlement Date", this.StartDate, this.EndDate, "Drawing Remittance Listing (By NRC) Report" });
                            }
                            else
                            {
                                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                            }
                        }

                    }
                }
                else if (this.Text == "Encash Remittance Listing (By NRC)")
                {
                    if (this.rdoTransactionDate.Checked == true)
                    {
                        // With Exactly
                        if (this.chkExactly.Checked == true)
                        {
                            DrawingEncashLists = this.DrawingRemittanceEncashNRCandNameController.MainPrint("Encash Remittance NRC Exactly By Transaction Date");
                            if (DrawingEncashLists.Count > 0)
                            {
                                CXUIScreenTransit.Transit("frmTLMVEW00062EncashRemitNRCExactlyByTransactionDate", true, new object[] { DrawingEncashLists, "Encash Remittance Listing By Transaction Date", this.StartDate, this.EndDate, "Encash Remittance Listing (By NRC) Report" });
                            }
                            else
                            {
                                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                            }
                        }

                        // Without Exactly
                        else
                        {
                            DrawingEncashLists = this.DrawingRemittanceEncashNRCandNameController.MainPrint("Encash Remittance NRC By Transaction Date");
                            if (DrawingEncashLists.Count > 0)
                            {
                                CXUIScreenTransit.Transit("frmTLMVEW00062EncashRemitNRCByTransactionDate", true, new object[] { DrawingEncashLists, "Encash Remittance Listing By Transaction Date", this.StartDate, this.EndDate, "Encash Remittance Listing (By NRC) Report" });
                            }
                            else
                            {
                                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                            }

                        }

                    }

                   //NRC by Settlement Date
                    else
                    {
                        if (this.chkExactly.Checked == true)
                        {
                            DrawingEncashLists = this.DrawingRemittanceEncashNRCandNameController.MainPrint("Encash Remittance NRC Exactly By Settlement Date");
                            if (DrawingEncashLists.Count > 0)
                            {
                                CXUIScreenTransit.Transit("frmTLMVEW00062EncashRemitNRCExactlyBySettlementDate", true, new object[] { DrawingEncashLists, "Encash Remittance Listing By Settlement Date", this.StartDate, this.EndDate, "Encash Remittance Listing (By NRC) Report" });
                            }
                            else
                            {
                                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                            }
                        }

                        else
                        {
                            DrawingEncashLists = this.DrawingRemittanceEncashNRCandNameController.MainPrint("Encash Remittance NRC By Settlement Date");
                            if (DrawingEncashLists.Count > 0)
                            {
                                CXUIScreenTransit.Transit("frmTLMVEW00062EncashRemitNRCBySettlementDate", true, new object[] { DrawingEncashLists, "Encash Remittance Listing By Settlement Date", this.StartDate, this.EndDate, "Encash Remittance Listing (By NRC) Report" });
                            }
                            else
                            {
                                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                            }
                        }

                    }
                }

                else if (this.Text == "Drawing Remittance Listing (By Name)")
                {
                    if (this.rdoTransactionDate.Checked == true)
                    {
                        // With Exactly
                        if (this.chkExactly.Checked == true)
                        {
                            DrawingEncashLists = this.DrawingRemittanceEncashNRCandNameController.MainPrint("Drawing Remittance Name Exactly By Transaction Date");
                            if (DrawingEncashLists.Count > 0)
                            {
                                CXUIScreenTransit.Transit("frmTLMVEW00058DrawingRemitNameExactlyByTransactionDate", true, new object[] { DrawingEncashLists, "Drawing Remittance Listing By Transaction Date", this.StartDate, this.EndDate, "Drawing Remittance Listing (By Name) Report" });
                            }
                            else
                            {
                                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                            }
                        }

                        // Without Exactly
                        else
                        {
                            DrawingEncashLists = this.DrawingRemittanceEncashNRCandNameController.MainPrint("Drawing Remittance Name By Transaction Date");
                            if (DrawingEncashLists.Count > 0)
                            {
                                CXUIScreenTransit.Transit("frmTLMVEW00058DrawingRemitNameByTransactionDate", true, new object[] { DrawingEncashLists, "Drawing Remittance Listing By Transaction Date", this.StartDate, this.EndDate, "Drawing Remittance Listing (By Name) Report" });
                            }
                            else
                            {
                                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                            }
                        }

                    }

                   //NRC by Settlement Date
                    else
                    {
                        if (this.chkExactly.Checked == true)
                        {
                            DrawingEncashLists = this.DrawingRemittanceEncashNRCandNameController.MainPrint("Drawing Remittance Name Exactly By Settlement Date");
                            if (DrawingEncashLists.Count > 0)
                            {
                                CXUIScreenTransit.Transit("frmTLMVEW00058DrawingRemitNameExactlyBySettlementDate", true, new object[] { DrawingEncashLists, "Drawing Remittance Listing By Settlement Date", this.StartDate, this.EndDate, "Drawing Remittance Listing (By Name) Report" });
                            }
                            else
                            {
                                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                            }
                        }

                        else
                        {
                            DrawingEncashLists = this.DrawingRemittanceEncashNRCandNameController.MainPrint("Drawing Remittance Name By Settlement Date");
                            if (DrawingEncashLists.Count > 0)
                            {
                                CXUIScreenTransit.Transit("frmTLMVEW00058DrawingRemitNameBySettlementDate", true, new object[] { DrawingEncashLists, "Drawing Remittance Listing By Settlement Date", this.StartDate, this.EndDate, "Drawing Remittance Listing (By Name) Report" });
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
                    if (this.rdoTransactionDate.Checked == true)
                    {
                        // With Exactly
                        if (this.chkExactly.Checked == true)
                        {
                            DrawingEncashLists = this.DrawingRemittanceEncashNRCandNameController.MainPrint("Encash Remittance Name Exactly By Transaction Date");
                            if (DrawingEncashLists.Count > 0)
                            {
                                CXUIScreenTransit.Transit("frmTLMVEW00062EncashRemitNameExactlyByTransactionDate", true, new object[] { DrawingEncashLists, "Encash Remittance Listing By Transaction Date", this.StartDate, this.EndDate, "Encash Remittance Listing (By Name) Report" });
                            }
                            else
                            {
                                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                            }
                        }

                        // Without Exactly
                        else
                        {
                            DrawingEncashLists = this.DrawingRemittanceEncashNRCandNameController.MainPrint("Encash Remittance Name By Transaction Date");
                            if (DrawingEncashLists.Count > 0)
                            {
                                CXUIScreenTransit.Transit("frmTLMVEW00062EncashRemitNameByTransactionDate", true, new object[] { DrawingEncashLists, "Encash Remittance Listing By Transaction Date", this.StartDate, this.EndDate, "Encash Remittance Listing (By Name) Report" });
                            }
                            else
                            {
                                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                            }
                        }

                    }

                   //NRC by Settlement Date
                    else
                    {
                        if (this.chkExactly.Checked == true)
                        {
                            DrawingEncashLists = this.DrawingRemittanceEncashNRCandNameController.MainPrint("Encash Remittance Name Exactly By Settlement Date");
                            if (DrawingEncashLists.Count > 0)
                            {
                                CXUIScreenTransit.Transit("frmTLMVEW00062EncashRemitNameExactlyBySettlementDate", true, new object[] { DrawingEncashLists, "Encash Remittance Listing By Settlement Date", this.StartDate, this.EndDate, "Encash Remittance Listing (By Name) Report" });
                            }
                            else
                            {
                                // Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00039);
                            }
                        }

                        else
                        {
                            DrawingEncashLists = this.DrawingRemittanceEncashNRCandNameController.MainPrint("Encash Remittance Name By Settlement Date");
                            if (DrawingEncashLists.Count > 0)
                            {
                                CXUIScreenTransit.Transit("frmTLMVEW00062EncashRemitNameBySettlementDate", true, new object[] { DrawingEncashLists, "Encash Remittance Listing By Settlement Date", this.StartDate, this.EndDate, "Encash Remittance Listing (By Name) Report" });
                            }
                            else
                            {
                                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                            }
                        }

                    }
                }

            }
        }

        #endregion

        #region "Methods"
        private bool CheckDate()
        {
            bool date = CXCOM00006.Instance.IsValidStartDateEndDate(this.dtpStartDate.Value, this.dtpEndDate.Value);
            if (date == false)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00123");
            }

            return date;

        }

        private void InitializeControls()
        {
            if (this.parentFormId == "Drawing Remittance Listing" && this.transactionBy == "ByNRC")
            {
                this.Text = "Drawing Remittance Listing (By NRC)";
                this.lblNameorNRC.Text = "NRC";
            }

            else if (this.parentFormId == "Encash Remittance Listing" && this.transactionBy == "ByNRC")
            {
                this.Text = "Encash Remittance Listing (By NRC)";
                this.lblNameorNRC.Text = "NRC";
            }

            else if (this.parentFormId == "Drawing Remittance Listing" && this.transactionBy == "ByName")
            {
                this.Text = "Drawing Remittance Listing (By Name)";
                this.lblNameorNRC.Text = "Name";
            }

            else
            {
                this.Text = "Encash Remittance Listing (By Name)";
                this.lblNameorNRC.Text = "Name";

            }

        }

        #endregion

        private void txtTemp_Leave(object sender, EventArgs e)
        {
            if (this.Text.Contains("NRC") && (txtTemp.Text == ""))
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00004");
                txtTemp.Focus();
            }
            else if (this.Text.Contains("Name") && txtTemp.Text == "")
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00002");
                txtTemp.Focus();
            }
        }

        
    }
}
