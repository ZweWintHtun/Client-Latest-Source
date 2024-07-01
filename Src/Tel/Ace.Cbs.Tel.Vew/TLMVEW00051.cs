//----------------------------------------------------------------------
// <copyright file="TLMVEW00051.cs" company="ACE Data Systems">
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
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using System.IO;

namespace Ace.Cbs.Tel.Vew
{  
    /// <summary>
    /// Report -> Bank Statement Listing By Date -> 1. Bankstatement Report
    /// </summary>
    
    public partial class TLMVEW00051 : BaseDockingForm,ITLMVEW00051
    {
        #region "Properties"
        public string TransactionStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate{get;set;}
        public string AccountNo { get; set; }
        public bool WithReversal { get; set; }
        #endregion

        #region "Constructor"
        public TLMVEW00051()
        {
            InitializeComponent();
        }

        public TLMVEW00051(string accountno,DateTime startDate,DateTime endDate,string screenName,bool withReversal)
        {
            this.AccountNo = accountno;
            this.TransactionStatus = screenName;
            this.Text = this.TransactionStatus;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.WithReversal = withReversal;
            InitializeComponent();
        }
        #endregion

        #region "Controllers"
        private ITLMCTL00051 controller;
        public ITLMCTL00051 BankStatementListingReportController //WithdrawalListingByAllController
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                this.controller.BankStatementListingReportView = this;
            }
        }

        #endregion

        #region "Event"
        private void TLMVEW00051_Load(object sender, EventArgs e)
        {
            IList<PFMDTO00042> BankStatementListingDTOList = new List<PFMDTO00042>();
            BankStatementListingDTOList = this.BankStatementListingReportController.GetBankStatementReportList();
            PFMDTO00001 CustomerDataInfos = new PFMDTO00001();
           
            if (BankStatementListingDTOList.Count > 0)
            {
                PFMDTO00042 bankstatementDTO = new PFMDTO00042();
                bankstatementDTO.BankName = CurrentUserEntity.BranchDescription;
               
                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] {CurrentUserEntity.BranchCode });
                bankstatementDTO.BranchName = Branch.Address;
                bankstatementDTO.Phone = Branch.Phone;
                bankstatementDTO.Fax = Branch.Fax;
            //    bankstatementDTO.SourceBranch = Branch.BranchCode;
                

                rpvBankStatement.LocalReport.DataSources.Clear();
                ReportParameter[] para = new ReportParameter[17];
                para[0] = new ReportParameter("BankName", bankstatementDTO.BankName);
                para[1] = new ReportParameter("BranchName", bankstatementDTO.BranchName.ToUpper());
                para[2] = new ReportParameter("Phone", bankstatementDTO.Phone);
                para[3] = new ReportParameter("Fax", bankstatementDTO.Fax);
                para[15] = new ReportParameter("BrCode", Branch.BranchCode);
                para[16] = new ReportParameter("Br_Alias", Branch.BranchAlias);

                //Commented by HWKO (30-Oct-2017)
                //Image img = null;
                //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                //{
                //    img = System.Drawing.Image.FromStream(stream);

                //    img.Save(tempFilePath);
                //}

                string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

                para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                para[5] = new ReportParameter("AccountNo", BankStatementListingDTOList[BankStatementListingDTOList.Count-1].AcctNo);
                para[6] = new ReportParameter("Name", String.IsNullOrEmpty(BankStatementListingDTOList[BankStatementListingDTOList.Count - 1].Narration) ? "-" : BankStatementListingDTOList[BankStatementListingDTOList.Count - 1].Narration);
                para[7] = new ReportParameter("NRC", String.IsNullOrEmpty(BankStatementListingDTOList[BankStatementListingDTOList.Count-1].LGNo)?"-":BankStatementListingDTOList[BankStatementListingDTOList.Count-1].LGNo);
                para[8] = new ReportParameter("Address", String.IsNullOrEmpty(BankStatementListingDTOList[BankStatementListingDTOList.Count - 1].DomBankPost) ? "-" : BankStatementListingDTOList[BankStatementListingDTOList.Count - 1].DomBankPost);
                para[9] = new ReportParameter("Phones", String.IsNullOrEmpty(BankStatementListingDTOList[BankStatementListingDTOList.Count-1].RefVNo)?"-": BankStatementListingDTOList[BankStatementListingDTOList.Count-1].RefVNo);
                para[10] = new ReportParameter("StartDate", this.StartDate.ToString("dd/MM/yyyy"));
                para[11] = new ReportParameter("EndDate", this.EndDate.ToString("dd/MM/yyyy"));
                para[12] = new ReportParameter("WithdrawalCounts",BankStatementListingDTOList[BankStatementListingDTOList.Count-1].WithdrawalCount.ToString());
                para[13] = new ReportParameter("DepositCounts", BankStatementListingDTOList[BankStatementListingDTOList.Count - 1].DepositCount.ToString());
                para[14] = new ReportParameter("TownshipCode", String.IsNullOrEmpty(BankStatementListingDTOList[BankStatementListingDTOList.Count - 1].RefType) ? "-" : BankStatementListingDTOList[BankStatementListingDTOList.Count - 1].RefType);
              
                this.rpvBankStatement.LocalReport.EnableExternalImages = true;
                rpvBankStatement.LocalReport.SetParameters(para);
                ReportDataSource dataset = new ReportDataSource("BankStatementListingByDateDataSet", BankStatementListingDTOList);
                rpvBankStatement.LocalReport.DataSources.Add(dataset);             

                dataset.Value = BankStatementListingDTOList;
                rpvBankStatement.LocalReport.Refresh();
                this.rpvBankStatement.RefreshReport();
            }
        }
        #endregion
    }
}
