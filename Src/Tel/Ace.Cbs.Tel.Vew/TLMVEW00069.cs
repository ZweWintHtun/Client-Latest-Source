//----------------------------------------------------------------------
// <copyright file="TLMVEW00069.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-11-16</CreatedDate>
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
    public partial class TLMVEW00069 : BaseDockingForm
    {
        #region Constructor
        public TLMVEW00069()
        {
            InitializeComponent();
        }

        public TLMVEW00069(IList<TLMDTO00017> rdList,string transactionType,DateTime date)
        {
            this.RDList = rdList;
            this.TransactionType = transactionType;
            this.Date = date;
            InitializeComponent();
        }

        public TLMVEW00069(IList<TLMDTO00001> reList, string transactionType, DateTime date)
        {
            this.REList = reList;
            this.TransactionType = transactionType;
            this.Date = date;
            InitializeComponent();
        }
        #endregion

        #region Properties
        IList<TLMDTO00017> RDList { get; set; }
        IList<TLMDTO00001> REList { get; set; }
        string TransactionType { get; set; }
        DateTime Date { get; set; }
        #endregion

        #region Methods
        private void rvIBLReconsileReport_Load(object sender, EventArgs e)
        {
            string datetime=this.Date.ToShortDateString();
            if (TransactionType == "RD")
            {
                TransactionType = "Drawing";
                this.Text = "Drawing Remittance Reconcilation Report";
            }
            else
            {
                TransactionType = "Encash";
                this.Text = "Encash Remittance Reconcilation Report";
            }

            string Title= "Daily Reconcilation for Remittance " + TransactionType + " " + "in Branch " + CurrentUserEntity.BranchDescription + " " + "for the Date: " + datetime;
 

            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            this.rpvRemittanceReconsileReport.LocalReport.DataSources.Clear();


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
            this.rpvRemittanceReconsileReport.LocalReport.EnableExternalImages = true;
            this.rpvRemittanceReconsileReport.LocalReport.SetParameters(para);
            this.rpvRemittanceReconsileReport.RefreshReport();
            IList<TLMDTO00017> rdList = new List<TLMDTO00017>();
            if (this.TransactionType=="Drawing")
            {
              
                foreach (TLMDTO00017 data in this.RDList)
                {
                    TLMDTO00017 list = new TLMDTO00017();
                    if (data.status == "Agree")
                    {
                        list.status = "Agree Transaction(s)";
                    }
                    else if (data.status == "DAgree")
                    {
                        list.status = "Disagree Transaction(s)";
                    }
                    else
                    {
                        list.status = "Duplicate Transaction(s)";
                    }

                    list.BankName = data.Dbank;
                    list.RegisterNo = data.RegisterNo;
                    list.Currency = data.Currency;
                    list.Amount = data.Amount;
                    list.Name = data.Name;
                    list.ToAccountNo = data.ToAccountNo;
                    list.ToName = data.ToName;
                    rdList.Add(list);
                }

            }
            else
            {
                foreach (TLMDTO00001 data in this.REList)
                {
                    TLMDTO00017 list = new TLMDTO00017();
                    if (data.status == "Agree")
                    {
                        list.status = "Agree Transaction(s)";
                    }
                    else if (data.status == "DAgree")
                    {
                        list.status = "Disagree Transaction(s)";
                    }
                    else
                    {
                        list.status = "Duplicate Transaction(s)";
                    }

                    list.BankName = data.Ebank;
                    list.RegisterNo = data.RegisterNo;
                    list.Currency = data.Currency;
                    list.Amount = data.Amount;
                    list.Name = data.Name;
                    list.ToAccountNo = data.ToAccountNo;
                    list.ToName = data.ToName;
                    rdList.Add(list);
                }

            }
            ReportDataSource dataset = new ReportDataSource("RDREReconsileDataSet", rdList);
            this.rpvRemittanceReconsileReport.LocalReport.DataSources.Add(dataset);
            dataset.Value = rdList;
            rpvRemittanceReconsileReport.LocalReport.Refresh();
            this.rpvRemittanceReconsileReport.RefreshReport();
        }
        #endregion
    }
}
