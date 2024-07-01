//----------------------------------------------------------------------
// <copyright file="TCMCleanCashReport" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Ye Mann Aung</CreatedUser>
// <CreatedDate>06.12.2013</CreatedDate>
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
    /// Clean Cash OD Report
    /// </summary>
    public partial class TCMVEW00051 : BaseDockingForm
    {
        #region Data Properties

        private IList<PFMDTO00042> AbstractDataList { get; set; }
        private string SelectedDateTime { get; set; }
        private string ReversalStatus { get; set; }

        #endregion

        public TCMVEW00051()
        {
            InitializeComponent();
        }

        public TCMVEW00051(IList<PFMDTO00042> dataset, string selectedDateTime, string reversalStatus)
        {
            this.AbstractDataList = dataset;
            this.ReversalStatus = reversalStatus;
            this.SelectedDateTime = selectedDateTime;
            InitializeComponent();
        }

        private void TCMCleanCashODReport_Load(object sender, EventArgs e)
        {

            this.rpvCleanCashOD.LocalReport.DataSources.Clear();
            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            ReportParameter[] para = new ReportParameter[9];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[7] = new ReportParameter("BrCode", Branch.BranchCode);
            para[8] = new ReportParameter("Br_Alias", Branch.Bank_Alias);

            Image img = null;
            string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            {
                img = System.Drawing.Image.FromStream(stream);

                img.Save(tempFilePath);
            }

            para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[5] = new ReportParameter("SelectedDateTime", this.SelectedDateTime);
            para[6] = new ReportParameter("ReversalStatus", this.ReversalStatus);
            this.rpvCleanCashOD.LocalReport.EnableExternalImages = true;
            this.rpvCleanCashOD.LocalReport.SetParameters(para);
            this.rpvCleanCashOD.RefreshReport();
            ReportDataSource dataset = new ReportDataSource("CleanCashDataset", this.AbstractDataList);
            this.rpvCleanCashOD.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.AbstractDataList;
            this.rpvCleanCashOD.LocalReport.Refresh();
            this.rpvCleanCashOD.RefreshReport();
        }

        private void TCMCleanCashODReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.rpvCleanCashOD.LocalReport.ReleaseSandboxAppDomain();
        }
    }
}
