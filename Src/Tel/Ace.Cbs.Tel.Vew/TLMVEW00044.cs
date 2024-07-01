//----------------------------------------------------------------------
// <copyright file="TLMVEW00044.cs" company="ACE Data Systems">
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
    /// Listing For Denomination Outstanding (Multiple Transaction Report) 
    /// </summary>
    public partial class TLMVEW00044 : BaseDockingForm,ITLMVEW00044
    {

        #region " Properties"
        public string TransactionStatus { get; set; }
        #endregion 

        #region "Constructor"
        public TLMVEW00044(string screenName)
        {
            InitializeComponent();
            this.TransactionStatus = screenName;
            this.Text = this.TransactionStatus;
           
        }

        public TLMVEW00044()
        {
            InitializeComponent();
        }
          #endregion

        #region "Controller"

        private ITLMCTL00044 denominationOutstandingMultipleTransactionController;

        public ITLMCTL00044 DenominationOutstandingMultipleTransactionController
        {
            get
            {
                return this.denominationOutstandingMultipleTransactionController;
            }
            set
            {
                this.denominationOutstandingMultipleTransactionController = value;
                this.denominationOutstandingMultipleTransactionController.DenominationOutstandingMultipleTransactionView = this;
            }
        }

        #endregion

        #region "Events"
        private void TLMVEW00044_Load(object sender, EventArgs e)
        {
            IList<TLMDTO00009> list = denominationOutstandingMultipleTransactionController.GetPrintData();
            if (list.Count > 0)
            {
                TLMDTO00009 DenoOutstandingMultipleTransactionDTO = new TLMDTO00009();
                DenoOutstandingMultipleTransactionDTO.BankName =CurrentUserEntity.BranchDescription ;


                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                DenoOutstandingMultipleTransactionDTO.BranchName = Branch.Address;
                DenoOutstandingMultipleTransactionDTO.Phone = Branch.Phone;
                DenoOutstandingMultipleTransactionDTO.Fax = Branch.Fax;
             // DenoOutstandingMultipleTransactionDTO.SourceBranchCode = Branch.BranchCode;

                rpvMultiDeno.LocalReport.DataSources.Clear();
                ReportParameter[] para = new ReportParameter[7];
                para[0] = new ReportParameter("BankName", DenoOutstandingMultipleTransactionDTO.BankName);
                para[1] = new ReportParameter("BranchName", DenoOutstandingMultipleTransactionDTO.BranchName);
                para[2] = new ReportParameter("Phone", DenoOutstandingMultipleTransactionDTO.Phone);
                para[3] = new ReportParameter("Fax", DenoOutstandingMultipleTransactionDTO.Fax);
                para[5] = new ReportParameter("BrCode", Branch.BranchCode);
                para[6] = new ReportParameter("Br_Alias", Branch.Bank_Alias);
                
                Image img = null;
                string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                {
                    img = System.Drawing.Image.FromStream(stream);

                    img.Save(tempFilePath);
                }

                para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                this.rpvMultiDeno.LocalReport.EnableExternalImages = true;
                rpvMultiDeno.LocalReport.SetParameters(para);
                ReportDataSource dataset = new ReportDataSource("MultiTransactionDenoOutstandingDataSet", list);
                rpvMultiDeno.LocalReport.DataSources.Add(dataset);
                dataset.Value = list;
                rpvMultiDeno.LocalReport.Refresh();
                this.rpvMultiDeno.RefreshReport();
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
