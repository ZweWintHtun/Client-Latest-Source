//----------------------------------------------------------------------
// <copyright file="TLMVEW00043.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-08-20</CreatedDate>
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
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Tel.Dmd;
using System.IO;
using Ace.Windows.Core.Utt;
using Microsoft.Reporting.WinForms;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Tel.Vew
{
    /// <summary>
    /// Listing For Deno Outstanding Report
    /// </summary>
    public partial class TLMVEW00043 : BaseDockingForm,ITLMVEW00043
    {
        #region " Properties"
        public string TransactionStatus { get; set; }
        #endregion      
        
        #region "Constructor"
        public TLMVEW00043(string screenName)
        {
            InitializeComponent();
            this.TransactionStatus = screenName;
            this.Text = this.TransactionStatus;
           
        }
        public TLMVEW00043()
        {
            InitializeComponent();
        }

        #endregion

        #region "Controller"

        private ITLMCTL00043 denoOutstandingReportController;

        public ITLMCTL00043 DenoOutstandingReportViewController
        {
            get
            {
                return this.denoOutstandingReportController;
            }
            set
            {
                this.denoOutstandingReportController = value;
                this.denoOutstandingReportController.DenoOutstandingReportView = this;
            }
        }

        #endregion

        #region "Events"
        private void TLMVEW00043_Load(object sender, EventArgs e)
        {
            IList<PFMDTO00054> list = DenoOutstandingReportViewController.GetPrintData();
            if (list.Count >0)
            {
                PFMDTO00054 DenoOutstandingDTO = new PFMDTO00054();
                DenoOutstandingDTO.BankName = CurrentUserEntity.BranchDescription;
          
                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                DenoOutstandingDTO.BranchName =Branch.Address;
                DenoOutstandingDTO.Phone = Branch.Phone;
                DenoOutstandingDTO.Fax = Branch.Fax;
            //   DenoOutstandingDTO.SourceBranchCode = Branch.BranchCode;
                
                

                rpvDenoOutstandingReport.LocalReport.DataSources.Clear();
                ReportParameter[] para = new ReportParameter[7];
                para[0] = new ReportParameter("BankName", DenoOutstandingDTO.BankName);
                para[1] = new ReportParameter("BranchName", DenoOutstandingDTO.BranchName);
                para[2] = new ReportParameter("Phone", DenoOutstandingDTO.Phone);
                para[3] = new ReportParameter("Fax", DenoOutstandingDTO.Fax);
                para[5] = new ReportParameter("BrCode",Branch.BranchCode);
                para[6] = new ReportParameter("Br_Alias",Branch.Bank_Alias);
                
                
                 Image img = null;
                string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                {
                    img = System.Drawing.Image.FromStream(stream);

                    img.Save(tempFilePath);
                }

                para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                this.rpvDenoOutstandingReport.LocalReport.EnableExternalImages = true;
                rpvDenoOutstandingReport.LocalReport.SetParameters(para);
                ReportDataSource dataset = new ReportDataSource("DenoOutstandingReportDataSet", list);
                rpvDenoOutstandingReport.LocalReport.DataSources.Add(dataset);
                dataset.Value = list;
                rpvDenoOutstandingReport.LocalReport.Refresh();
                this.rpvDenoOutstandingReport.RefreshReport();
            }

            else
            {
                this.Close();
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
               
            }

        }
        #endregion
    }
}
