﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Loan.Dmd;
using Microsoft.Reporting.WinForms;
using System.IO;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00060 : BaseForm
    {
        IList<LOMDTO00059> DataList { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string Currency { get; set; }
        string SourceBranch { get; set; }
        string Header { get; set; }

        public LOMVEW00060()
        {
            InitializeComponent();
        }

        public LOMVEW00060(IList<LOMDTO00059> dataList, string startDate, string endDate, string currency,
            string sourceBranch, string header)
        {
            this.Text = header;
            this.Header = header;
            this.DataList = dataList;
            this.StartDate = Convert.ToDateTime(startDate);
            this.EndDate = Convert.ToDateTime(endDate);
            this.Currency = currency;
            this.SourceBranch = sourceBranch;
            InitializeComponent();
        }

        private void LOMVEW00060_Load(object sender, EventArgs e)
        {
            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            this.rpvODLimitChange.LocalReport.DataSources.Clear();

            ReportParameter[] para = new ReportParameter[12];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);

            Image img = null;
            string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            {
                img = System.Drawing.Image.FromStream(stream);
                img.Save(tempFilePath);
            }

            para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[5] = new ReportParameter("Title", this.Header);
            para[6] = new ReportParameter("BrCode", this.SourceBranch);
            para[7] = new ReportParameter("Br_Alias", Branch.Bank_Alias);
            para[8] = new ReportParameter("TotalRecords", Convert.ToString(DataList.Count));
            para[9] = new ReportParameter("StartDate", this.StartDate.ToString("dd/MM/yyyy"));
            para[10] = new ReportParameter("EndDate", this.EndDate.ToString("dd/MM/yyyy"));
            para[11] = new ReportParameter("Currency", this.Currency);

            this.rpvODLimitChange.LocalReport.EnableExternalImages = true;
            this.rpvODLimitChange.LocalReport.SetParameters(para);
            this.rpvODLimitChange.RefreshReport();

            ReportDataSource dataset = new ReportDataSource("DSLOMRDLC00011", this.DataList);
            this.rpvODLimitChange.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.DataList;
            this.rpvODLimitChange.LocalReport.Refresh();

            this.rpvODLimitChange.RefreshReport();
        }
    }
}
