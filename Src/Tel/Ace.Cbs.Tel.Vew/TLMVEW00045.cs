//----------------------------------------------------------------------
// <copyright file="TLMVEW00045.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo</CreatedUser>
// <CreatedDate>2013-06-24</CreatedDate>
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
using Microsoft.Reporting.WinForms;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Tel.Vew
{
    /// <summary>
    /// Listing For Payment Order Outstanding Normal Report
    /// </summary>
    public partial class frmTLMVEW00045 : BaseDockingForm,ITLMVEW00045
    {
        #region " Properties"
        public string TransactionStatus { get; set; }
        #endregion

        #region "Constructor"
        public frmTLMVEW00045(string screenName)
        {
            InitializeComponent();
            this.TransactionStatus = screenName;
            this.Text = this.TransactionStatus;
           
        }
        #endregion

        #region "Controller"

        private ITLMCTL00045 pOOutstandingNormalReportController;

        public ITLMCTL00045 POOutstandingNormalReportController
        {
            get
            {
                return this.pOOutstandingNormalReportController;
            }
            set
            {
                this.pOOutstandingNormalReportController = value;
                this.pOOutstandingNormalReportController.View = this;
            }
        }

        #endregion

        #region "DTO"

        private TLMDTO00016 denooutstandingReportDTO;
        public TLMDTO00016 DenoOutstandingReportDTO
        {
            get { return this.denooutstandingReportDTO; }
            set { this.denooutstandingReportDTO = value; }
        }

        #endregion

        #region "Event"
        private void TLMVEW00045_Load(object sender, EventArgs e)
        {
            IList<TLMDTO00016> list = POOutstandingNormalReportController.GetPrintData(CurrentUserEntity.BranchCode);
            if (list.Count > 0)
            {
                try
                {
                    TLMDTO00016 POEntity = new TLMDTO00016();
                    POEntity.BankName = CurrentUserEntity.BranchDescription;

                    BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                    POEntity.BranchName = Branch.Address;
                    POEntity.Phone = Branch.Phone;
                    POEntity.Fax = Branch.Fax;
                    POEntity.SourceBranchCode = Branch.BranchCode;

                    rpvListingForPaymentOrderOutstandingNormal.LocalReport.DataSources.Clear();
                    ReportParameter[] para = new ReportParameter[7];
                    para[0] = new ReportParameter("BankName", POEntity.BankName);
                    para[1] = new ReportParameter("BranchName", POEntity.BranchName);
                    para[2] = new ReportParameter("Phone", POEntity.Phone);
                    para[3] = new ReportParameter("Fax", POEntity.Fax);
                    para[5] = new ReportParameter("BrCode", POEntity.SourceBranchCode);
                    para[6] = new ReportParameter("Br_Alias", Branch.Bank_Alias);
                

                    Image img = null;
                    string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                    using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                    {
                        img = System.Drawing.Image.FromStream(stream);

                        img.Save(tempFilePath);
                    }

                    para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                    this.rpvListingForPaymentOrderOutstandingNormal.LocalReport.EnableExternalImages = true;
                    rpvListingForPaymentOrderOutstandingNormal.LocalReport.SetParameters(para);
                    ReportDataSource dataset = new ReportDataSource("POOutstandingReportDataSet", list);
                    rpvListingForPaymentOrderOutstandingNormal.LocalReport.DataSources.Add(dataset);
                    dataset.Value = list;

                    rpvListingForPaymentOrderOutstandingNormal.LocalReport.Refresh();
                    this.rpvListingForPaymentOrderOutstandingNormal.RefreshReport();
                }
                catch
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("ME00021");
                }
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
