//----------------------------------------------------------------------
// <copyright file="TLMVEW00067.cs" company="ACE Data Systems">
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
    /// Listing -> Transaction Listing -> Withdrawal By Counter -> Withdrawal By Counter Report
    /// </summary>
    public partial class TLMVEW00067 : BaseDockingForm
    {
        #region "Properties"
        public string TransactionStatus { get; set; }

        public DateTime StartDate { get; set; }
        public string CounterNo{get;set;}
        public DateTime EndDate { get; set; }
        public IList<PFMDTO00042> WithdrawalListingCounterNoDTOList { get; set; }

        #endregion

        #region "Constructors"
        public TLMVEW00067()
        {
            InitializeComponent();
        }

        public TLMVEW00067(IList<PFMDTO00042> withdrawalListingCounterNoDTOList,DateTime startDate,DateTime endDate,string counterNo,string screenName)
        {
            this.TransactionStatus = screenName;
            this.Text = this.TransactionStatus;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.CounterNo=counterNo;
            this.WithdrawalListingCounterNoDTOList = withdrawalListingCounterNoDTOList;
            InitializeComponent();
        }
        #endregion

        #region "Event"
        private void TLMVEW00067_Load(object sender, EventArgs e)
        {
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
              //  WithdrawlListingDTO.SourceBranch = Branch.BranchCode;

                rpvWithdrawalCounterNo.LocalReport.DataSources.Clear();
                ReportParameter[] para = new ReportParameter[10];
                para[0] = new ReportParameter("BankName", WithdrawlListingDTO.BankName);
                para[1] = new ReportParameter("BranchName", WithdrawlListingDTO.BranchName);
                para[2] = new ReportParameter("Phone", WithdrawlListingDTO.Phone);
                para[3] = new ReportParameter("Fax", WithdrawlListingDTO.Fax);
                para[8] = new ReportParameter("BrCode", Branch.BranchCode);
                para[9] = new ReportParameter("Br_Alias", Branch.BranchAlias);



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
                para[7] = new ReportParameter("UserNo",this.CounterNo);
                
                this.rpvWithdrawalCounterNo.LocalReport.EnableExternalImages = true;
                rpvWithdrawalCounterNo.LocalReport.SetParameters(para);
                ReportDataSource dataset = new ReportDataSource("WithdrawalListingByCounterNoDataSet", WithdrawalListingCounterNoDTOList);
                rpvWithdrawalCounterNo.LocalReport.DataSources.Add(dataset);


                rpvWithdrawalCounterNo.LocalReport.Refresh();
                this.rpvWithdrawalCounterNo.RefreshReport();
            }
            this.rpvWithdrawalCounterNo.RefreshReport();
        }
        #endregion
    }
}
