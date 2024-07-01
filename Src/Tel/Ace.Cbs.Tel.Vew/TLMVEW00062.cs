﻿//----------------------------------------------------------------------
// <copyright file="TLMVEW00062.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-09-26</CreatedDate>
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
using Microsoft.Reporting.WinForms;
using Ace.Cbs.Cx.Cle;
using System.IO;

namespace Ace.Cbs.Tel.Vew
{
    /// <summary>
    /// (Listing -> Encashment Remittance) -> (Encashment Remittance Listing By NRC) -> 1.Encashment Remittance Listing By  NRC Report
      //(Listing -> Encashment Remittance) -> (Encashment Remittance Listing By Name) -> 1. Encashment Remittance Listing By Name Report
    /// </summary>
    public partial class TLMVEW00062 : BaseDockingForm
    {
        #region "Properties"
        public string TransactionStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string DateType { get; set; }    
        public IList<TLMDTO00017> DrawingEncashRemittanceDTOLists { get; set; }
        #endregion

        #region "Constructor"
        public TLMVEW00062()
        {
            InitializeComponent();
        }

         public TLMVEW00062(IList<TLMDTO00017> DEDTOLists, string dateType, DateTime startDate, DateTime endDate, string screenName)
        {
            this.TransactionStatus = screenName;
            this.Text = this.TransactionStatus;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.DateType = dateType;
            this.DrawingEncashRemittanceDTOLists = DEDTOLists;
            InitializeComponent();
        }
        #endregion

         #region "Event"
         private void TLMVEW00062_Load(object sender, EventArgs e)
        {
            if (this.DrawingEncashRemittanceDTOLists.Count > 0)
            {
                TLMDTO00017 WithdrawlListingDTO = new TLMDTO00017();
                WithdrawlListingDTO.BankName = CurrentUserEntity.BranchDescription;

                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                WithdrawlListingDTO.BranchName = Branch.Address;
                WithdrawlListingDTO.Phone = Branch.Phone;
                WithdrawlListingDTO.Fax = Branch.Fax;
                WithdrawlListingDTO.StartDate = this.StartDate;
                WithdrawlListingDTO.EndDate = this.EndDate;
                WithdrawlListingDTO.Address = this.DateType;
                WithdrawlListingDTO.CashAmount = 0;
            //    WithdrawlListingDTO.SourceBranchCode = Branch.BranchCode;


                rpvEncashment.LocalReport.DataSources.Clear();
                ReportParameter[] para = new ReportParameter[10];
                para[0] = new ReportParameter("BankName", WithdrawlListingDTO.BankName);
                para[1] = new ReportParameter("Address", WithdrawlListingDTO.BranchName);
                para[2] = new ReportParameter("Phone", WithdrawlListingDTO.Phone);
                para[3] = new ReportParameter("Fax", WithdrawlListingDTO.Fax);
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
                para[5] = new ReportParameter("StartDate", WithdrawlListingDTO.StartDate.Value.ToShortDateString());
                para[6] = new ReportParameter("EndDate", WithdrawlListingDTO.EndDate.Value.ToShortDateString());
                para[7] = new ReportParameter("DateType", WithdrawlListingDTO.Address);

                this.rpvEncashment.LocalReport.EnableExternalImages = true;
                rpvEncashment.LocalReport.SetParameters(para);
                ReportDataSource dataset = new ReportDataSource("EncashRemittanceNameandNRCDataSet", DrawingEncashRemittanceDTOLists);
                rpvEncashment.LocalReport.DataSources.Add(dataset);


                dataset.Value = DrawingEncashRemittanceDTOLists;
                rpvEncashment.LocalReport.Refresh();
                this.rpvEncashment.RefreshReport();
            }
        }
#endregion
    }
}

