//----------------------------------------------------------------------
// <copyright file="MNMVEW00156.cs" company="Ace Data Systems">
// Copyright (c) Ace Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo</CreatedUser>
// <CreatedDate>2015-02-04</CreatedDate>
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
using System.Globalization;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.CXClient;

namespace Ace.Cbs.Mnm.Vew
{
    //Closing -->Monthly Closing-->Drawing Remittance
    //Closing -->Monthly Closing-->Encash Remittance

    public partial class MNMVEW00156 : BaseForm, IMNMVEW00156
    {
        #region "Constructor"
        public MNMVEW00156()
        {
            InitializeComponent();
        }
        #endregion

        #region "Properties"
        public string TransactionStatus
        {
            get { return this.FormName; }
        }

        public string RequiredYear
        {
            get { return this.txtRequiredYear.Text; }
            set { this.txtRequiredYear.Text = value.ToString(); }
        }
        public string RequiredMonth
        {
            get
            {
                if (this.cboRequiredMonth.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cboRequiredMonth.SelectedValue.ToString();
                }
            }

            set { this.cboRequiredMonth.SelectedValue = value; }
        }
        #endregion

        #region "Controller"
        private IMNMCTL00156 drawingRemittanceMonthlyClosingController;
        public IMNMCTL00156 DrawingRemittanceMonthlyClosingController   //Controller
        {
            get
            {
                return this.drawingRemittanceMonthlyClosingController;
            }
            set
            {
                this.drawingRemittanceMonthlyClosingController = value;
                this.drawingRemittanceMonthlyClosingController.DrawingRemittanceMonthlyClosingView = this;
            }
        }

        #endregion

        #region "Public Method"
        public void InitailizedControlsFormLoad()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.rdoTransactionDate.Checked = true;
            this.txtRequiredYear.Text = DateTime.Now.Year.ToString();

            for (int i = 0; i < 12; i++)
            {
                this.cboRequiredMonth.Items.Add(CultureInfo.CurrentCulture.DateTimeFormat.MonthNames[i]);
            }
            string currentmonth = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames[DateTime.Now.Month - 1];
            this.cboRequiredMonth.SelectedItem = currentmonth;
        }
        #endregion

        #region "Events"

        private void MNMVEW00156_Load(object sender, EventArgs e)
        {
            this.InitailizedControlsFormLoad();
            this.Text = TransactionStatus;

        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            IList<TLMDTO00017> DrawingLists = new List<TLMDTO00017>();
            IList<TLMDTO00001> EncashLists = new List<TLMDTO00001>();
            string typename = string.Empty;
            if (this.rdoTransactionDate.Checked) //Transaction Date
            {
                if (TransactionStatus == "Monthly Drawing Remittance Listing")
                {
                    //Drawing Transaction
                    DrawingLists = this.drawingRemittanceMonthlyClosingController.MainDrawingPrint("Monthly Drawing Remittance Transaction");
                    if (DrawingLists.Count > 0)
                    {
                        CXUIScreenTransit.Transit("frmMNMVEW00157DrawingTransaction", true, new object[] { DrawingLists, "Monthly Drawing Remittance Listing By Transaction Date For" + this.GetName() });
                    }
                    else
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                    }
                }
                else
                {
                    //Encash Transaction
                    EncashLists = this.drawingRemittanceMonthlyClosingController.MAinEncashPrint("Monthly Encash Remittance Transaction");
                    if (EncashLists.Count > 0)
                    {
                       CXUIScreenTransit.Transit("frmMNMVEW00160EncashTransaction", true, new object[] { EncashLists, "Monthly Drawing Remittance Listing By Transaction Date For" +this.GetName()});
                    }
                   else
                    {
                       Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                    }
                }
            }
            else //Settlement Date
            {
                if (TransactionStatus == "Monthly Encash Remittance Listing")
                {
                    //Encash Settle
                    EncashLists = this.drawingRemittanceMonthlyClosingController.MAinEncashPrint("Monthly Encash Remittance Settlement");
                    if (EncashLists.Count > 0)
                    {
                        CXUIScreenTransit.Transit("frmMNMVEW00160EncashSettlement", true, new object[] { DrawingLists, "Monthly Drawing Remittance Listing By Transaction Date For" + this.GetName() });
                    }
                    else
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                    }
                }
                else
                {
                    //Drawing Settle
                    DrawingLists = this.drawingRemittanceMonthlyClosingController.MainDrawingPrint("Monthly Drawing Remittance Settlement");
                    if (DrawingLists.Count > 0)
                    {
                        CXUIScreenTransit.Transit("frmMNMVEW00157DrawingSettlement", true, new object[] { DrawingLists, "Monthly Drawing Remittance Listing By Transaction Date For" + this.GetName() });
                    }
                    else
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                    }
                }

            }
        }

        private string GetName()
        {
            string name = " " + this.cboRequiredMonth.Text + " " + this.txtRequiredYear.Text;
            return name;
        }
        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitailizedControlsFormLoad();
        }
        #endregion
    }
}
