//----------------------------------------------------------------------
// <copyright file="TLMVEW00066.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-09-06</CreatedDate>
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
    /// Listing -> Transaction Listing -> Withdrawal By All -> Withdrawal By All Report
        //Listing -> Transaction Listing -> Withdrawal By Type -> Withdrawal By Type Report
    /// </summary>
    public partial class TLMVEW00066 : BaseDockingForm
    {
        #region "Properties"
        public string TransactionStatus { get; set; }
        public DateTime Startdate{get;set;}
        public DateTime Enddate{get;set;}

        public IList<PFMDTO00042> WithdrawalListingAllDTOList { get; set; }
        #endregion

        #region "Constructor"
        public TLMVEW00066()
        {
            InitializeComponent();
        }
        public TLMVEW00066(IList<PFMDTO00042> withdrawalListingALLDTOList,DateTime startDate,DateTime endDate,string screenName)
        {
            this.TransactionStatus = screenName;
            this.Text = this.TransactionStatus;
            this.WithdrawalListingAllDTOList = withdrawalListingALLDTOList;
            this.Startdate = startDate;
            this.Enddate = endDate;
            InitializeComponent();
        }
        #endregion

        #region "Event"
        private void TLMVEW00066_Load(object sender, EventArgs e)
        {
            string accountType = "AccountType";
           if (this.WithdrawalListingAllDTOList.Count > 0)
           {
               PFMDTO00042 WithdrawlListingDTO = new PFMDTO00042();
               WithdrawlListingDTO.BankName = CurrentUserEntity.BranchDescription;
               BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode});
               WithdrawlListingDTO.BranchName = Branch.Address;
               WithdrawlListingDTO.Phone = Branch.Phone;
               WithdrawlListingDTO.Fax = Branch.Fax;
               WithdrawlListingDTO.StartDate = this.Startdate;
               WithdrawlListingDTO.EndDate = this.Enddate;
             //  WithdrawlListingDTO.SourceBranch = Branch.BranchCode;

               rpvWithdrawal.LocalReport.DataSources.Clear();
               ReportParameter[] para = new ReportParameter[11];
               para[0] = new ReportParameter("BankName", WithdrawlListingDTO.BankName);
               para[1] = new ReportParameter("BranchName", WithdrawlListingDTO.BranchName);
               para[2] = new ReportParameter("Phone", WithdrawlListingDTO.Phone);
               para[3] = new ReportParameter("Fax", WithdrawlListingDTO.Fax);
               para[9] = new ReportParameter("BrCode", Branch.BranchCode);
               para[10] = new ReportParameter("Br_Alias", Branch.Bank_Alias);

               Image img = null;
               string tempFilePath = Application.StartupPath + "\\pristinelogo.png";
               //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
               //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
               //{
               //    img = System.Drawing.Image.FromStream(stream);

               //    img.Save(tempFilePath);
               //}

               para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
               para[5] = new ReportParameter("StartDate", WithdrawlListingDTO.StartDate.ToString("dd/MM/yyyy"));
               para[6] = new ReportParameter("EndDate", WithdrawlListingDTO.EndDate.ToString("dd/MM/yyyy"));
               if (this.TransactionStatus == "Withdrawal Listing By All Report")
               {
                   para[7] = new ReportParameter(accountType, "Withdrawal Listing By All Type");
               }

               else if (this.TransactionStatus == "Withdrawal Listing By Account Type (Current) Report")
               {
                   para[7] = new ReportParameter(accountType, "Withdrawal Listing By Current Account");
               }
               else if (this.TransactionStatus == "Withdrawal Listing By Account Type (Business Loans) Report")
               {
                   para[7] = new ReportParameter(accountType, "Withdrawal Listing By Business Loans Account");
               }
               else if (this.TransactionStatus == "Withdrawal Listing By Account Type (HirePurchase) Report")
               {
                   para[7] = new ReportParameter(accountType, "Withdrawal Listing By HirePurchase Account");
               }
               else if (this.TransactionStatus == "Withdrawal Listing By Account Type (Personal Loans) Report")
               {
                   para[7] = new ReportParameter(accountType, "Withdrawal Listing By Personal Loans Account");
               }
               else if (this.TransactionStatus == "Withdrawal Listing By Account Type (Dealer) Report")
               {
                   para[7] = new ReportParameter(accountType, "Withdrawal Listing By Dealer Account");
               }
               else if (this.TransactionStatus == "Withdrawal Listing By Account Type (Saving) Report")
               {
                   para[7] = new ReportParameter(accountType, "Withdrawal Listing By Saving Account");
               }


               else if (this.TransactionStatus == "Withdrawal Listing By Account Type (Fixed) Report")
               {
                   para[7] = new ReportParameter(accountType, "Withdrawal Listing By Fixed Account");
               }

               para[8] = new ReportParameter("TotalRecords", this.WithdrawalListingAllDTOList.Count.ToString());
               this.rpvWithdrawal.LocalReport.EnableExternalImages = true;
               rpvWithdrawal.LocalReport.SetParameters(para);
               ReportDataSource dataset = new ReportDataSource("WithdrawalListingAllDataSet", WithdrawalListingAllDTOList);
               rpvWithdrawal.LocalReport.DataSources.Add(dataset);
               rpvWithdrawal.LocalReport.Refresh();
               this.rpvWithdrawal.RefreshReport();
           }
        }
        #endregion            
    }
}
