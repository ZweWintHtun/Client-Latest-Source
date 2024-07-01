//----------------------------------------------------------------------
// <copyright file="TLMVEW00046.cs" company="ACE Data Systems">
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
    public partial class TLMVEW00046 : BaseForm, ITLMVEW00046
    {
        #region Constructor
        public TLMVEW00046()
        {
            InitializeComponent();
        }
        public TLMVEW00046(string parentFormId, DateTime startDate, DateTime endDate, string branchCode, bool isActive, bool isReversal, string tranType)
        {
            InitializeComponent();
            this.ParentFormId = parentFormId;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.BranchCode = branchCode;
            this.IsActive = isActive;
            this.IsReversal = isReversal;
            this.TranType = tranType;

        }
        #endregion

        #region Controller
        private ITLMCTL00046 controller;
        public ITLMCTL00046 Controller
        {
            get { return this.controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }
        #endregion

        #region Controls Input Output
        private string parentFormId = string.Empty;
        public string ParentFormId
        {
            get { return this.parentFormId; }
            set { this.parentFormId = value; }
        }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool AllBranch { get; set; }
        public string BranchCode { get; set; }
        public string TranType { get; set; }
        public bool IsActive { get; set; }
        public bool IsReversal { get; set; }
        #endregion

        #region Event
        private void TLMVEW00046_Load(object sender, EventArgs e)
        {
            TLMDTO00004 ibltlfDTO = new TLMDTO00004();
            string StartDate = this.StartDate.ToString("dd/MM/yyyy");
            string EndDate = this.EndDate.ToString("dd/MM/yyyy");
            //ibltlfDTO.StartDate = this.StartDate;
            //ibltlfDTO.EndDate = this.EndDate;

            string Transaction=string.Empty;
            if(this.TranType=="CCD")
            {
                Transaction="Deposit";
            }
            else if (this.TranType == "CDW")
            {
                Transaction = "Withdraw";
            }
            else if (this.TranType == "-")
            {
                Transaction = "All Transactions";
            }
            else if (this.TranType == "WENQ")
            {
                Transaction = "Without Enquiry";
            }
            else if (this.TranType == "TDV")
            {
                Transaction = "Transfer Debit";
            }
            else if (this.TranType == "TCV")
            {
                Transaction = "Transfer Credit";
            }
     
     
            IList<TLMDTO00004> list = new List<TLMDTO00004>();
            if (this.IsActive == true)
            {
                list = this.controller.ActiveTransactionListingByBranch();

                if (Transaction == "All Transactions")
                {
                    foreach (TLMDTO00004 item in list)
                    {
                      string trancode = item.TranType;

                      if (trancode == "CCD")
                      {
                          Transaction = "Deposit"; 
                      }
                        else if (trancode == "CDW")
                          Transaction = "Withdraw"; 

                    }
                }

                if (this.IsReversal == true)
                {
                    ibltlfDTO.ReportTitle = "Listing of (Active Branch) for " + Transaction + " "+"Transactions By With Reversal" +" " + "(" + StartDate +" " + "to" +" " + EndDate + ")";
                    ibltlfDTO.Status = "To Branch";
                }
                else
                {
                    ibltlfDTO.ReportTitle = "Listing of (Active Branch) for " + Transaction + " " + "Transactions By Without Reversal" + " " +"(" + StartDate +" " + "to" +" "+ EndDate + ")";
                    ibltlfDTO.Status = "To Branch";
                }
                //ibltlfDTO.ReportTitle = "IBL Income Receipt Initiated by" + CurrentUserEntity.BranchDescription;
            }
            else
            {
                list = this.controller.HomeTransactionListingByBranch();
                if (Transaction == "All Transactions")
                {
                    foreach (TLMDTO00004 item in list)
                    {
                        string trancode = item.TranType;

                        if (trancode == "CCD")
                        {
                            Transaction = "Deposit";
                        }
                        else if (trancode == "CDW")
                            Transaction = "Withdraw"; 

                    }
                }
                if (this.IsReversal == true)
                {
                    ibltlfDTO.ReportTitle = "Listing of (Home Branch) for " + Transaction + " " + "Transactions By With Reversal" + " " +"(" + StartDate +" "+ "to" +" " + EndDate + ")";
                    ibltlfDTO.Status = "From Branch";
                }
                else
                {
                    ibltlfDTO.ReportTitle = "Listing of (Home Branch) for " + Transaction + " " + "Transactions By Without Reversal" + " " + "(" + StartDate +" "+ "to" + " " + EndDate + ")";
                    ibltlfDTO.Status = "From Branch";
                }
                //ibltlfDTO.ReportTitle = "IBL Income Receipt Initiated by Other Branches";
            }

            if (list.Count > 0)
            {
                ibltlfDTO.BankName = CurrentUserEntity.BranchDescription;
                Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                ibltlfDTO.BranchName = Branch.Address;
          //     ibltlfDTO.SourceBranchCode = Branch.BranchCode;

                rpvTransactionByBranch.LocalReport.DataSources.Clear();
                ReportParameter[] para = new ReportParameter[10];
                para[0] = new ReportParameter("BankName", ibltlfDTO.BankName);
                para[1] = new ReportParameter("BranchName", ibltlfDTO.BranchName);
                para[2] = new ReportParameter("Phone", Branch.Phone);
                para[3] = new ReportParameter("Fax", Branch.Fax);
                para[8] = new ReportParameter("BrCode", Branch.BranchCode);
                para[9] = new ReportParameter("Br_Alias", Branch.BranchAlias);
                
                Image img = null;
                string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                {
                    img = System.Drawing.Image.FromStream(stream);

                    img.Save(tempFilePath);
                }

                para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                para[5] = new ReportParameter("ReportTitle", ibltlfDTO.ReportTitle);
                para[6] = new ReportParameter("BranchStatus", ibltlfDTO.Status);
                para[7] = new ReportParameter("TotalRecords", list.Count.ToString());
                this.rpvTransactionByBranch.LocalReport.EnableExternalImages = true;
                rpvTransactionByBranch.LocalReport.SetParameters(para);
                
                IList<TLMDTO00004> dataLists = new List<TLMDTO00004>();
               
                    foreach (TLMDTO00004 data in list)
                    {
                        TLMDTO00004 reportData = new TLMDTO00004();
                        reportData.Eno = data.Eno;

                        if (ibltlfDTO.Status == "From Branch")
                        { reportData.BranchCode = data.FromBranch; }
                        else
                        { reportData.BranchCode = data.ToBranch; }

                        reportData.AccountNo = data.AccountNo;
                        reportData.Amount = data.Amount;
                        reportData.Income = data.Income;
                        reportData.Communicationcharge = data.Communicationcharge;
                        reportData.TranType = Transaction;
                        if (data.IncomeType == 1)
                        { reportData.BranchAlias = "By Cash"; }
                        else if (data.IncomeType == 2)
                        { reportData.BranchAlias = "By Transfer"; }
                        else
                        { reportData.BranchAlias = string.Empty; }
                        dataLists.Add(reportData);

                    }
                
                ReportDataSource dataset = new ReportDataSource("IBLHomeIncomeReportDataSet", dataLists);
                rpvTransactionByBranch.LocalReport.DataSources.Add(dataset);
                dataset.Value = dataLists;
                this.rpvTransactionByBranch.RefreshReport();
            }

            else
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                this.Close();
            }
        }
        #endregion
    }
}
