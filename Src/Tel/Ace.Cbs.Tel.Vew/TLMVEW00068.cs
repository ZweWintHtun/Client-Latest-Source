//----------------------------------------------------------------------
// <copyright file="TLMVEW00068.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-09-10</CreatedDate>
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

namespace Ace.Cbs.Tel.Vew
{
    /// <summary>
    /// Listing -> Transaction Listing -> Withdrawal By Acctno. -> Withdrawal By Account No Report
    /// </summary>
    public partial class TLMVEW00068 : BaseDockingForm
    {
        #region "Properties"
        public string TransactionStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string AccountNo { get; set; }
        private string Names { get; set; }

        public IList<PFMDTO00042> WithdrawalListingCounterNoDTOList { get; set; }
        #endregion

        #region "Constructor"
        public TLMVEW00068()
        {
            InitializeComponent();
        }
         public TLMVEW00068(IList<PFMDTO00042> withdrawalListingCounterNoDTOList,DateTime startDate,DateTime endDate,string accountNo,string screenName)
        {
            this.TransactionStatus = screenName;
            this.Text = this.TransactionStatus;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.AccountNo=accountNo;
            this.WithdrawalListingCounterNoDTOList = withdrawalListingCounterNoDTOList;
            InitializeComponent();
        }

        #endregion

         #region "Events"
         private void TLMVEW00068_Load(object sender, EventArgs e)
         {
             this.Text = "Withdrawal Listing By Account No.";
                
              if (this.WithdrawalListingCounterNoDTOList.Count > 0)
            {
                PFMDTO00042 WithdrawlListingDTO = new PFMDTO00042();
                WithdrawlListingDTO.BankName = CurrentUserEntity.BranchDescription;
              
                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                WithdrawlListingDTO.BranchName = Branch.Address;
                WithdrawlListingDTO.Phone = Branch.Phone;
                WithdrawlListingDTO.Fax = Branch.Fax;
                WithdrawlListingDTO.StartDate = StartDate;
                WithdrawlListingDTO.EndDate = EndDate;
             // WithdrawlListingDTO.SourceBranch = Branch.BranchCode;


                rpvWithdrawByAccountNo.LocalReport.DataSources.Clear();
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
                para[5] = new ReportParameter("StartDate", WithdrawlListingDTO.StartDate.ToShortDateString());
                para[6] = new ReportParameter("EndDate", WithdrawlListingDTO.EndDate.ToShortDateString());
                para[7] = new ReportParameter("AccountNo",this.AccountNo);

                foreach (PFMDTO00042 withdrawalAccountnodto in WithdrawalListingCounterNoDTOList)
                {
                    Names = withdrawalAccountnodto.Description;
                }

                para[8] = new ReportParameter("Name", this.Names = (this.Names == string.Empty || this.Names == null) ? this.Names = "-" : this.Names);

                this.rpvWithdrawByAccountNo.LocalReport.EnableExternalImages = true;
                rpvWithdrawByAccountNo.LocalReport.SetParameters(para);
                ReportDataSource dataset = new ReportDataSource("WithdrawalListingByAccountNoDataSet", WithdrawalListingCounterNoDTOList);
                rpvWithdrawByAccountNo.LocalReport.DataSources.Add(dataset);
                rpvWithdrawByAccountNo.LocalReport.Refresh();
                this.rpvWithdrawByAccountNo.RefreshReport();
            }
              this.rpvWithdrawByAccountNo.RefreshReport();
         }
#endregion

        
    }
}
