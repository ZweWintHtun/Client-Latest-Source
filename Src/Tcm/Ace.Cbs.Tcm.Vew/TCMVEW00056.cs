﻿
//----------------------------------------------------------------------
// <copyright file="TCMPOReceiptReport" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Ye Mann Aung</CreatedUser>
// <CreatedDate>16.12.2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Ace.Windows.CXClient.Controls;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tcm.Dmd;
using Ace.Windows.Core.Utt;
using Microsoft.Reporting.WinForms;
using System.IO;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Tcm.Vew
{
    /// <summary>
    /// Listing for Clearing with PO Receipt Report
    /// </summary>
    public partial class TCMVEW00056 : BaseDockingForm
    {

        #region Data Properties

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        private IList<PFMDTO00042> POReceiptDataList { get; set; }

        #endregion


        public TCMVEW00056()
        {
            InitializeComponent();
        }

        public TCMVEW00056(IList<PFMDTO00042> dataset, string startDateTime, string endDateTime)
        {
            this.POReceiptDataList = dataset;
            this.StartDate =Convert.ToDateTime(startDateTime);
            this.EndDate =Convert.ToDateTime(endDateTime);
            InitializeComponent();
        }

        private void TCMPOReceipt_Load(object sender, EventArgs e)
        {
            this.rpvClearingPOReceipt.LocalReport.DataSources.Clear();
            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            ReportParameter[] para = new ReportParameter[10];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[8] = new ReportParameter("BrCode", Branch.BranchCode);
            para[9] = new ReportParameter("Br_Alias", Branch.BranchAlias);

            Image img = null;
            string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            {
                img = System.Drawing.Image.FromStream(stream);

                img.Save(tempFilePath);
            }

            para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[5] = new ReportParameter("StartDate", this.StartDate.ToString("dd/MM/yyyy"));
            para[6] = new ReportParameter("EndDate", this.EndDate.ToString("dd/MM/yyyy"));
            para[7] = new ReportParameter("TotalRecords", this.POReceiptDataList.Count.ToString());

            this.rpvClearingPOReceipt.LocalReport.EnableExternalImages = true;
            this.rpvClearingPOReceipt.LocalReport.SetParameters(para);
            this.rpvClearingPOReceipt.RefreshReport();
            ReportDataSource dataset = new ReportDataSource("POReceipt", this.POReceiptDataList);
            this.rpvClearingPOReceipt.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.POReceiptDataList;
            this.rpvClearingPOReceipt.LocalReport.Refresh();
            this.rpvClearingPOReceipt.RefreshReport();
        }

        private void TCMPOReceipt_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.rpvClearingPOReceipt.LocalReport.ReleaseSandboxAppDomain();
        }
    }
}