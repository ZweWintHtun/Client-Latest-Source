//----------------------------------------------------------------------
// <copyright file="TCMVEW00054.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate></CreatedDate>
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
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Cle;
using Microsoft.Reporting.WinForms;
using System.IO;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Tcm.Vew
{
    public partial class TCMVEW00054 : BaseForm,ITCMVEW00054
    {
        #region Constructor
        public TCMVEW00054()
        {
            InitializeComponent();
        }

        public TCMVEW00054(string parentformName,DateTime startdate,DateTime enddate, IList<PFMDTO00042> reporttlfs)
        {
            InitializeComponent();
            this.ParentFormName = parentformName;
            this.StartDate = startdate;
            this.EndDate = enddate;
            this.ReporTLFs = reporttlfs;
        }

        private string ParentFormName { get; set; }
        private DateTime StartDate{get;set;}
        private DateTime EndDate{get;set;}
        private IList<PFMDTO00042> ReporTLFs { get; set; } 

        #endregion

        #region Controller
        private ITCMCTL00054 controller;
        public ITCMCTL00054 Controller
        {
            get
            {
                { return this.controller; }
            }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }
        #endregion

        #region Event
        private void TCMVEW00054_Load(object sender, EventArgs e)
        {
            try
            {
                Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                rpvDeliveredCheque.LocalReport.DataSources.Clear();
                ReportParameter[] para = new ReportParameter[9];
                para[0] = new ReportParameter("BankName", Branch.BranchDescription);
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
                para[5] = new ReportParameter("TotalRecords", this.ReporTLFs.Count.ToString());

                if (this.ParentFormName == "NotYetPosted")
                {
                    para[6] = new ReportParameter("ReportTitle", "Delivered Cheque Listing (Not Yet Posted) from " + this.StartDate.ToString("dd/MM/yyyy") + " to " + this.EndDate.ToString("dd/MM/yyyy"));

                }
                else
                {
                    para[6] = new ReportParameter("ReportTitle","Delivered Cheque Listing (Posted) from " + this.StartDate.ToString("dd/MM/yyyy") + " to " + this.EndDate.ToString("dd/MM/yyyy"));
 
                }
                this.rpvDeliveredCheque.LocalReport.EnableExternalImages = true;
                rpvDeliveredCheque.LocalReport.SetParameters(para);
                ReportDataSource dataset = new ReportDataSource("PFMDTO00042_DataSet", this.ReporTLFs);
                rpvDeliveredCheque.LocalReport.DataSources.Add(dataset);
                dataset.Value = this.ReporTLFs;
                this.rpvDeliveredCheque.RefreshReport();
                this.Text = "Delivered Cheque Listing";
            }
            catch
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00039);
            }
        }
        #endregion


    }
}
