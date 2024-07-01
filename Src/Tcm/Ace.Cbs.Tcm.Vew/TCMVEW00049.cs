//----------------------------------------------------------------------
// <copyright file="TCMAbstractReport" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Ye Mann Aung</CreatedUser>
// <CreatedDate>02.12.2013</CreatedDate>
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
    /// Clearing Abstract Report
    /// </summary>
    public partial class TCMVEW00049 : BaseDockingForm
    {
        #region Data Properties

        public IList<TCMDTO00027> AbstractDataList { get; set; }
        public string SelectedDateTime { get; set; }
        public string SelectedDateType { get; set; }

        #endregion

        public TCMVEW00049()
        {
            InitializeComponent();
        }

        public TCMVEW00049(IList<TCMDTO00027> dataset, string selectedDateTime, string selectedDateType)
        {
            this.AbstractDataList = dataset;
            this.SelectedDateType = selectedDateType;
            this.SelectedDateTime = selectedDateTime;
            InitializeComponent();
        }
        private void TCMAbstractReport_Load(object sender, EventArgs e)
        {
            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            this.rpvAbstractReport.LocalReport.DataSources.Clear();
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
            para[6] = new ReportParameter("SelectedDateType", this.SelectedDateType);
            this.rpvAbstractReport.LocalReport.EnableExternalImages = true;
            this.rpvAbstractReport.LocalReport.SetParameters(para);
            this.rpvAbstractReport.RefreshReport();
            ReportDataSource dataset = new ReportDataSource("ClearingAbstractDataset", this.AbstractDataList);
            this.rpvAbstractReport.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.AbstractDataList;
            rpvAbstractReport.LocalReport.Refresh();
            this.rpvAbstractReport.RefreshReport();
        }

        private void TCMAbstractReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.rpvAbstractReport.LocalReport.ReleaseSandboxAppDomain(); 
        }
    }
}
