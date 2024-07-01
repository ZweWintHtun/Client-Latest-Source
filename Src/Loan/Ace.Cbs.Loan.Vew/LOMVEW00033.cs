//----------------------------------------------------------------------
// <copyright file="LOMVEW00033.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> ASDA </CreatedUser>
// <CreatedDate>20-01-2015</CreatedDate>
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
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Loan.Dmd;
using System.IO;
using Microsoft.Reporting.WinForms;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00033 : BaseForm
    {
        #region Properties
        IList<LOMDTO00013> PrintDataList { get; set; }
        string msg = string.Empty;
        #endregion
        #region Constructor
        public LOMVEW00033()
        {
            InitializeComponent();
        }

        public LOMVEW00033(IList<LOMDTO00013> ReportDataList)
        {
            PrintDataList = ReportDataList;
            InitializeComponent();
        }
        #endregion

        private void LOMVEW00033_Load(object sender, EventArgs e)
        {
            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.SelectActiveBranch", new object[] { CurrentUserEntity.BranchCode,true });
            this.rpvLegalAccountReport.LocalReport.DataSources.Clear();

            ReportParameter[] para = new ReportParameter[9];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[6] = new ReportParameter("BrCode", Branch.BranchCode);
            para[7] = new ReportParameter("Br_Alias", Branch.Bank_Alias);

            if (PrintDataList.Count > 1)
                msg = " records";
            else if (PrintDataList.Count == 1)
                msg = " record";

            para[8] = new ReportParameter("TotalRecords", "( "+this.PrintDataList.Count.ToString()+" )"+msg);

            Image img = null;
            string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            {
                img = System.Drawing.Image.FromStream(stream);

                img.Save(tempFilePath);
            }

            para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[5] = new ReportParameter("Title", "Enquiry By Legal Loans Account No");
            this.rpvLegalAccountReport.LocalReport.EnableExternalImages = true;
            this.rpvLegalAccountReport.LocalReport.SetParameters(para);
            this.rpvLegalAccountReport.RefreshReport();
            
            ReportDataSource dataset = new ReportDataSource("LegalSueCaseByAccountNoDataSet", PrintDataList);
            this.rpvLegalAccountReport.LocalReport.DataSources.Add(dataset);
           
            rpvLegalAccountReport.LocalReport.Refresh();
            this.rpvLegalAccountReport.RefreshReport();
        }
    }
}
