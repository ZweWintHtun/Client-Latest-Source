//----------------------------------------------------------------------
// <copyright file="TCMVEW00057.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2014-02-06</CreatedDate>
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
using Microsoft.Reporting.WinForms;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using System.IO;

namespace Ace.Cbs.Tcm.Vew
{
    /// <summary>
    /// Clearing Delivered Reversal Report Viewer
    /// </summary>
    public partial class TCMVEW00057 : BaseDockingForm
    {
        #region "Properties"
        private DateTime StartDate { get; set; }
        private DateTime EndDate { get; set; }
        private string ReportTitle { get; set; }
        public IList<PFMDTO00042> ClearingDeliveredReversalDTOList { get; set; }
        #endregion

        #region "Constructors"

        public TCMVEW00057()
        {
            InitializeComponent();
        }
        public TCMVEW00057(IList<PFMDTO00042> reportTLFDTOList,DateTime startDate,DateTime endDate,string reportTitle)
        {
            InitializeComponent();
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.ReportTitle = reportTitle;
            this.Text = this.ReportTitle;
            this.ClearingDeliveredReversalDTOList = reportTLFDTOList;
        }
        #endregion

        #region "Event"
        private void TCMVEW00057_Load(object sender, EventArgs e)
        {
            if (this.ClearingDeliveredReversalDTOList.Count > 0)
            {
                PFMDTO00042 ClearingDeliveredReversalDTO = new PFMDTO00042();
                ClearingDeliveredReversalDTO.BankName = CurrentUserEntity.BranchDescription;
                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                ClearingDeliveredReversalDTO.BranchName = Branch.Address;
                ClearingDeliveredReversalDTO.Phone = Branch.Phone;
                ClearingDeliveredReversalDTO.Fax = Branch.Fax;
                ClearingDeliveredReversalDTO.StartDate = StartDate;
                ClearingDeliveredReversalDTO.EndDate = EndDate;
                ClearingDeliveredReversalDTO.ReportTitle = ReportTitle;

                rpvClearingDeliveredReverse.LocalReport.DataSources.Clear();
                ReportParameter[] para = new ReportParameter[11];
                para[0] = new ReportParameter("BankName", ClearingDeliveredReversalDTO.BankName);
                para[1] = new ReportParameter("BranchName", ClearingDeliveredReversalDTO.BranchName);
                para[2] = new ReportParameter("Phone", ClearingDeliveredReversalDTO.Phone);
                para[3] = new ReportParameter("Fax", ClearingDeliveredReversalDTO.Fax);
                para[9] = new ReportParameter("BrCode", Branch.BranchCode);
                para[10] = new ReportParameter("Br_Alias", Branch.Bank_Alias);

                Image img = null;
                string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                {
                    img = System.Drawing.Image.FromStream(stream);

                    img.Save(tempFilePath);
                }
                para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                para[5] = new ReportParameter("StartDate", ClearingDeliveredReversalDTO.StartDate.ToShortDateString());
                para[6] = new ReportParameter("EndDate", ClearingDeliveredReversalDTO.EndDate.ToShortDateString());
                para[7] = new ReportParameter("ReportTitle", ClearingDeliveredReversalDTO.ReportTitle);
                para[8] = new ReportParameter("TotalRecords", ClearingDeliveredReversalDTOList.Count.ToString());
                this.rpvClearingDeliveredReverse.LocalReport.EnableExternalImages = true;
                rpvClearingDeliveredReverse.LocalReport.SetParameters(para);
                ReportDataSource dataset = new ReportDataSource("PFMDTO000042_DataSet", ClearingDeliveredReversalDTOList);
                rpvClearingDeliveredReverse.LocalReport.DataSources.Add(dataset);
            }

            this.rpvClearingDeliveredReverse.RefreshReport();
            this.rpvClearingDeliveredReverse.RefreshReport();
        }
        #endregion
    }
}
