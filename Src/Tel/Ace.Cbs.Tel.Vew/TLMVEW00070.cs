//----------------------------------------------------------------------
// <copyright file="TLMVEW00070.cs" company="ACE Data Systems">
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
using Ace.Cbs.Cx.Cle;
using System.IO;

namespace Ace.Cbs.Tel.Vew
{
    public partial class TLMVEW00070 : BaseDockingForm
    {
        #region Constructor
        public TLMVEW00070()
        {
            InitializeComponent();
        }

        public TLMVEW00070(IList<TLMDTO00004> ibltlfList, string transactionType, DateTime date)
        {
            this.IBLTLFList = ibltlfList;
            this.TransactionType = transactionType;
            this.Date = date;
            InitializeComponent();
        }
        #endregion

        #region Properties
        IList<TLMDTO00004> IBLTLFList { get; set; }
        string TransactionType { get; set; }
        DateTime Date { get; set; }
        #endregion

        #region Method
        private void TLMVEW00070_Load(object sender, EventArgs e)
        {
            this.Text = "Online Transaction Reconcilation Report";
            string datetime = this.Date.ToString("dd/MM/yyyy");
            string Title = "Daily Reconcilation for Online Transactions "  + "in Branch " + CurrentUserEntity.BranchDescription + " " + "for the Date: " + datetime;


            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            this.rpvTransactionReconsileReport.LocalReport.DataSources.Clear();

            ReportParameter[] para = new ReportParameter[8];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[6] = new ReportParameter("BrCode", Branch.BranchCode);
            para[7] = new ReportParameter("Br_Alias", Branch.Bank_Alias);


            Image img = null;
            string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            {
                img = System.Drawing.Image.FromStream(stream);

                img.Save(tempFilePath);
            }

            para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[5] = new ReportParameter("Title", Title);
            this.rpvTransactionReconsileReport.LocalReport.EnableExternalImages = true;
            this.rpvTransactionReconsileReport.LocalReport.SetParameters(para);
            this.rpvTransactionReconsileReport.RefreshReport();

               IList<TLMDTO00004> transactionlist = new List<TLMDTO00004>();
               foreach (TLMDTO00004 data in this.IBLTLFList)
                {
                    TLMDTO00004 list = new TLMDTO00004();
                    if (data.Status == "Agree")
                    {
                        list.Status = "Agree Transaction(s)";
                    }
                    else if (data.Status == "DAgree")
                    {
                        list.Status = "Disagree Transaction(s)";
                    }
                    else
                    {
                        list.Status = "Duplicate Transaction(s)";
                    }

                    list.BankName = data.ToBranch;
                    list.Eno = data.Eno;
                    list.Currency = data.Currency;
                    list.Amount = data.Amount;
                    list.RelatedAccount = data.RelatedAccount;
                    list.Cheque = data.Cheque;
                    list.AccountNo = data.AccountNo;
                    if (data.TranType == "CCD")
                    { 
                        list.TranType = "Cash Deposit";
                    }
                    else if (data.TranType=="CDW")
                    {
                        list.TranType = "Cash Withdrawal";
                    }
                    else if (data.TranType == "TCV")
                    {
                        list.TranType = "Transfer Credit";
                    }
                    else
                    {
                        list.TranType = "Transfer Debit";
                    }
                    transactionlist.Add(list);
                }           
            
            ReportDataSource dataset = new ReportDataSource("IBLTLFReconsileDataSet", transactionlist);
            this.rpvTransactionReconsileReport.LocalReport.DataSources.Add(dataset);
            dataset.Value = transactionlist;
            rpvTransactionReconsileReport.LocalReport.Refresh();
            this.rpvTransactionReconsileReport.RefreshReport();
        }
        #endregion
    }
}
