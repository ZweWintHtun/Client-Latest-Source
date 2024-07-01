//----------------------------------------------------------------------
// <copyright file="TLMVEW00050.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-08-22</CreatedDate>
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
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Tel.Dmd;
using System.IO;



namespace Ace.Cbs.Tel.Vew
{
    /// <summary>
    /// Report -> IBL Remittance Listing -> IBL Test Key Listing -> 1. Test Key Listing By All Report
    /// Report -> IBL Remittance Listing -> IBL Test Key Listing -> 2. Test Key Listing By Date Report
    /// </summary>

    public partial class TLMVEW00050 : BaseForm, ITLMVEW00050
    {
        #region "Properties"
        public DateTime Date { get; set; }
        public string ScreenName { get; set; }
        public IList<TLMDTO00037> list { get; set; }
        public string TransactionStatus
        {
            get { return this.FormName; }
        }
        #endregion       

        #region "Constructors"
        public TLMVEW00050()
        {
            InitializeComponent();
        }

        public TLMVEW00050(IList<TLMDTO00037> iblList, DateTime date, string screenName)
        {
            InitializeComponent();
            this.list = iblList;
            this.Text = screenName;
            this.Date = date;

        }

        #endregion

        #region "Controller"

        private ITLMCTL00050 iblTestKeyListingController;

        public ITLMCTL00050 IBLTestKeyListingController
        {
            get
            {
                return this.iblTestKeyListingController;
            }
            set
            {
                this.iblTestKeyListingController = value;
                this.iblTestKeyListingController.IBLTestKeyListingView = this;
            }
        }

        #endregion

        #region "Events"
        private void TLMVEW00050_Load(object sender, EventArgs e)
        {
            if (this.TransactionStatus.Equals("TestKey.All"))
            {
                this.Text = "IBL Test Key Listing By All Report";
                list = iblTestKeyListingController.GetALLPrintData();
            }            
            if (list.Count > 0)
            {
                    TLMDTO00037 iblTestKeyListingDTO = new TLMDTO00037();
                    iblTestKeyListingDTO.BankName = CurrentUserEntity.BranchDescription;
                  //  iblTestKeyListingDTO.BranchName = CXAppSettings.Instance.GetValueByKeyName(CXCOM00009.BranchName);

                    BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                    iblTestKeyListingDTO.BranchName = Branch.Address;
                    iblTestKeyListingDTO.Phone = Branch.Phone;
                    iblTestKeyListingDTO.Fax = Branch.Fax;

                    rpvIBLRemittanceTestKeyListing.LocalReport.DataSources.Clear();
                    ReportParameter[] para = new ReportParameter[9];
                    para[0] = new ReportParameter("BankName", iblTestKeyListingDTO.BankName);
                    para[1] = new ReportParameter("BranchName", iblTestKeyListingDTO.BranchName);
                    para[2] = new ReportParameter("Phone", iblTestKeyListingDTO.Phone);
                    para[3] = new ReportParameter("Fax", iblTestKeyListingDTO.Fax);
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
                    if (!this.TransactionStatus.Equals("TestKey.All"))
                    {
                        para[5] = new ReportParameter("DateTime", Date.ToString("dd MMM,yyyy"));
                        para[6] = new ReportParameter("StartsDate"," ");

                    }
                    else
                    {
                        para[5] = new ReportParameter("DateTime", "All");
                        para[6] = new ReportParameter("StartsDate", "Start Date:");

                    }
                    this.rpvIBLRemittanceTestKeyListing.LocalReport.EnableExternalImages = true;
                    rpvIBLRemittanceTestKeyListing.LocalReport.SetParameters(para);
                    ReportDataSource dataset = new ReportDataSource("IBLTestKeyListingDataSet", list);
                    rpvIBLRemittanceTestKeyListing.LocalReport.DataSources.Add(dataset);
                    dataset.Value = list;
                    rpvIBLRemittanceTestKeyListing.LocalReport.Refresh();
                    this.rpvIBLRemittanceTestKeyListing.RefreshReport();
                }        
            }
        #endregion

        #region "Methods"
        public void CloseForm()
        {
            this.rpvIBLRemittanceTestKeyListing.Hide();
            this.Visible = false;
            this.Close();
        }
        #endregion
    }
}
     

