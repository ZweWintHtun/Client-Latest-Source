﻿//----------------------------------------------------------------------
// <copyright file="TCMScrollReport" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Ye Mann Aung</CreatedUser>
// <CreatedDate>09.12.2013</CreatedDate>
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
    /// Clearing Scroll Report
    /// </summary>
    public partial class TCMVEW00060 : BaseDockingForm
    {

        #region Data Properties

        public IList<TCMDTO00027> ScrollDataList { get; set; }
        public string SelectedDateTime { get; set; }
        public string SelectedDateType { get; set; }
        public string SelectedCurrency { get; set; }
        public string ReversalStatus { get; set; }
        

        #endregion

        #region Constructors
        public TCMVEW00060()
        {
            InitializeComponent();
        }

        public TCMVEW00060(IList<TCMDTO00027> dataset, string selectedDateTime, string selectedDateType, string selectedCurrency, string reversalStatus)
        {
            this.ScrollDataList = dataset;
            this.SelectedDateTime = selectedDateTime;
            this.SelectedDateType = selectedDateType;
            this.SelectedCurrency = selectedCurrency;
            this.ReversalStatus = reversalStatus;
            InitializeComponent();
        }
        #endregion

        private void TCMScrollReport_Load(object sender, EventArgs e)
        {
            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            this.rpvScrollReport.LocalReport.DataSources.Clear();
            ReportParameter[] para = new ReportParameter[12];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[10] = new ReportParameter("BrCode", Branch.BranchCode);
            para[11] = new ReportParameter("Br_Alias", Branch.Bank_Alias);


            Image img = null;
            string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            {
                img = System.Drawing.Image.FromStream(stream);

                img.Save(tempFilePath);
            }

            para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[5] = new ReportParameter("SelectedDateTime", this.SelectedDateTime);
            para[6] = new ReportParameter("SelectedDateType", this.SelectedDateType);
            para[7] = new ReportParameter("ReversalStatus", this.ReversalStatus);
            para[8] = new ReportParameter("Cur", this.SelectedCurrency);
            para[9] = new ReportParameter("Count", this.ScrollDataList.Count.ToString());
            this.rpvScrollReport.LocalReport.EnableExternalImages = true;
            this.rpvScrollReport.LocalReport.SetParameters(para);
            this.rpvScrollReport.RefreshReport();
            ReportDataSource dataset = new ReportDataSource("ClearingScrollDataset", this.ScrollDataList);
            this.rpvScrollReport.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.ScrollDataList;
            rpvScrollReport.LocalReport.Refresh();
            this.rpvScrollReport.RefreshReport();
        }

        private void TCMScrollReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.rpvScrollReport.LocalReport.ReleaseSandboxAppDomain();
        }
    }
}
