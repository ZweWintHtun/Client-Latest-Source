//----------------------------------------------------------------------
// <copyright file="TLMVEW00073.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-10-15</CreatedDate>
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
using Ace.Cbs.Cx.Com.Ctr;

namespace Ace.Cbs.Tel.Vew
{
    /// <summary>
    /// Report -> Bank Statement Listing By Date -> 1. Bank Statement Listing By Date For Fixed Deposit A/C
    /// </summary>
    public partial class TLMVEW00073 : BaseDockingForm, ITLMVEW00073
    {
        #region "Properties"
        public string TransactionStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string AccountNo { get; set; }
        public bool IsAllCustomers { get; set; }
        public bool WithReversal { get; set; }
        public IList<PFMDTO00021> FledgerInfoLists { get; set; }
        #endregion

        #region "Constructor
        public TLMVEW00073()
        {
            InitializeComponent();
        }

        public TLMVEW00073(IList<PFMDTO00021> fledgerInfoLists, string accountNo, bool isAllCustomers, DateTime startDate, DateTime endDate, string screenName,bool withReversal)
        {
            this.TransactionStatus = screenName;
            this.Text = this.TransactionStatus;
            this.FledgerInfoLists = fledgerInfoLists;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.AccountNo = accountNo;
            this.IsAllCustomers = isAllCustomers;
            this.WithReversal = withReversal;
            InitializeComponent();
        }
        #endregion

        #region "Methods"
        
        #endregion

        #region "Controllers"
        private ITLMCTL00073 controller;
        public ITLMCTL00073 BankStatementListingByDateForFixedDepositACController //WithdrawalListingByAllController
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                this.controller.BankStatementListingByDateForFixedDepositACView = this;
            }
        }

        #endregion

        #region "Event"
        private void TLMVEW00073_Load(object sender, EventArgs e)
        {           

            IList<PFMDTO00042> BankStatementListingDTOList = new List<PFMDTO00042>();
            BankStatementListingDTOList = this.controller.GetBankStatementReportList(this.StartDate, this.EndDate, this.AccountNo, this.IsAllCustomers,this.WithReversal);
            
            if (BankStatementListingDTOList.Count > 0)
            {
                PFMDTO00042 bankstatementDTO = new PFMDTO00042();
                bankstatementDTO.BankName = CurrentUserEntity.BranchDescription;

                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                bankstatementDTO.BranchName = Branch.Address;
                bankstatementDTO.Phone = Branch.Phone;
                bankstatementDTO.Fax = Branch.Fax;

                rpvFixedBankStatementListing.LocalReport.DataSources.Clear();
                ReportParameter[] para = new ReportParameter[17];
                para[0] = new ReportParameter("BankName", bankstatementDTO.BankName);
                para[1] = new ReportParameter("BranchName", bankstatementDTO.BranchName);
                para[2] = new ReportParameter("Phone", bankstatementDTO.Phone);
                para[3] = new ReportParameter("Fax", bankstatementDTO.Fax);
                para[15] = new ReportParameter("BrCode", Branch.BranchCode);
                para[16] = new ReportParameter("Br_Alias", Branch.Bank_Alias);
                Image img = null;
                string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                {
                    img = System.Drawing.Image.FromStream(stream);

                    img.Save(tempFilePath);
                }

                para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                para[5] = new ReportParameter("AccountNo", BankStatementListingDTOList[BankStatementListingDTOList.Count - 1].AcctNo);
                //para[6] = new ReportParameter("Name", narration.Substring(0, narration.Length - 1));
                para[6] = new ReportParameter("Name", BankStatementListingDTOList[BankStatementListingDTOList.Count-1].Narration);
                //para[7] = new ReportParameter("NRC", nrc.Substring(0, nrc.Length - 1));
                para[7] = new ReportParameter("NRC", String.IsNullOrEmpty(BankStatementListingDTOList[BankStatementListingDTOList.Count - 1].LGNo) ? "-" : BankStatementListingDTOList[BankStatementListingDTOList.Count - 1].LGNo);

                //para[8] = new ReportParameter("Address", FledgerInfoLists[0].Address = FledgerInfoLists[0].Address == null ? " " : FledgerInfoLists[0].Address);
                para[8] = new ReportParameter("Address", String.IsNullOrEmpty(BankStatementListingDTOList[BankStatementListingDTOList.Count - 1].DomBankPost) ? "-" : BankStatementListingDTOList[BankStatementListingDTOList.Count - 1].DomBankPost);
                //para[9] = new ReportParameter("Phones", FledgerInfoLists[0].Phone = FledgerInfoLists[0].Phone == null ? " " : FledgerInfoLists[0].Phone);
                para[9] = new ReportParameter("Phones", String.IsNullOrEmpty(BankStatementListingDTOList[BankStatementListingDTOList.Count - 1].RefVNo) ? "-" : BankStatementListingDTOList[BankStatementListingDTOList.Count - 1].RefVNo);
                para[10] = new ReportParameter("StartDate", this.StartDate.ToShortDateString());
                para[11] = new ReportParameter("EndDate", this.EndDate.ToShortDateString());
                para[12] = new ReportParameter("WithdrawalCounts", BankStatementListingDTOList[BankStatementListingDTOList.Count - 1].WithdrawalCount.ToString());
                para[13] = new ReportParameter("DepositCounts", BankStatementListingDTOList[BankStatementListingDTOList.Count - 1].DepositCount.ToString());
                //para[14] = new ReportParameter("TownshipCode", FledgerInfoLists[0].Township_Code = FledgerInfoLists[0].Township_Code == null ? " " : FledgerInfoLists[0].Township_Code);
                para[14] = new ReportParameter("TownshipCode", String.IsNullOrEmpty(BankStatementListingDTOList[BankStatementListingDTOList.Count - 1].RefType) ? "-" : BankStatementListingDTOList[BankStatementListingDTOList.Count - 1].RefType);
                
                //if (IsAllCustomers == false)
                //{
                //    para[15] = new ReportParameter("Member", " ");
                //    para[16] = new ReportParameter("member1", " ");
                //    para[17] = new ReportParameter("member2", " ");
                //    para[18] = new ReportParameter("member3", " ");
                //    para[19] = new ReportParameter("member4", " ");
                //    para[20] = new ReportParameter("member5", " ");
                //    para[21] = new ReportParameter("member6", " ");
                //}
                //else
                //{
                //    para[15] = new ReportParameter("Member", "Member :");
                //    para[16] = new ReportParameter("member1", member1);
                //    para[17] = new ReportParameter("member2", member2);
                //    para[18] = new ReportParameter("member3", member3);
                //    para[19] = new ReportParameter("member4", member4);
                //    para[20] = new ReportParameter("member5", member5);
                //    para[21] = new ReportParameter("member6", member6);
                //}

                this.rpvFixedBankStatementListing.LocalReport.EnableExternalImages = true;
                rpvFixedBankStatementListing.LocalReport.SetParameters(para);
                ReportDataSource dataset = new ReportDataSource("BankStatementListingByDateForFixedDepositDataSet", BankStatementListingDTOList);
                rpvFixedBankStatementListing.LocalReport.DataSources.Add(dataset);

                dataset.Value = BankStatementListingDTOList;
                rpvFixedBankStatementListing.LocalReport.Refresh();
                this.rpvFixedBankStatementListing.RefreshReport();
            }


        }
        #endregion
    }
}

