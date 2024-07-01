//----------------------------------------------------------------------
// <copyright file="TLMVEW00063" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>HM</CreatedUser>
// <CreatedDate>31.12.2013</CreatedDate>
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
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;
using System.Windows.Forms;
using System.IO;
using Microsoft.Reporting.WinForms;
using Ace.Cbs.Mnm.Dmd.DTO;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Mnm.Dmd;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00103 : BaseDockingForm
    {
        #region Properties

        public string FormName { get; set; }
        public string Header { get; set; }
        public string AccountCode { get; set; }
        public string Currency { get; set; }         
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IList<MNMDTO00054> DataList { get; set; }
        public string AccountDescription { get; set; }

        #endregion 

        #region constructure

        public MNMVEW00103()
        {
            InitializeComponent();
        }

        public MNMVEW00103(IList<MNMDTO00054> List,string acctcode, DateTime startDate,DateTime endDate, string curType,string ACName)
        {
            this.DataList = List;
            this.AccountCode = acctcode;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Currency = curType;
            this.Header = "Account Ledger Listing From " + this.StartDate.ToString("dd MMM,yyyy") + " To " + this.EndDate.ToString("dd MMM,yyyy");   //for head
            this.AccountDescription = ACName;
            InitializeComponent();
        }

        #endregion 

        #region Events

        private void MNMVEW00103_Load(object sender, EventArgs e)
        {         
            //this.Header = this.FormName + "Listing " + this.StartDate.ToString("dd MMM,yyyy") + " To " + this.EndDate.ToString("dd MMM,yyyy");   //for head
            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            //DataList[0].acount
            rpvSubLedgerDomestic.LocalReport.DataSources.Clear();
            ReportParameter[] para = new ReportParameter[12];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[9] = new ReportParameter("BrCode", Branch.BranchCode);
            para[10] = new ReportParameter("Br_Alias", Branch.BranchAlias);
            para[11] = new ReportParameter("AccountDescription", AccountDescription);

            //Commented by HWKO (31-Oct-2017)
            //Image img = null;
            //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            //{
            //    img = System.Drawing.Image.FromStream(stream);

            //    img.Save(tempFilePath);
            //}

            string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

            para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[5] = new ReportParameter("Header", Header);
            para[6] = new ReportParameter("AccountCode", this.AccountCode);         
            para[7] = new ReportParameter("Currency", this.Currency.Replace("KYT","MMK"));//Updated by HWKO (25-Sep-2017)
            para[8] = new ReportParameter("Count", this.DataList.Count.ToString());

            this.rpvSubLedgerDomestic.LocalReport.EnableExternalImages = true;
            rpvSubLedgerDomestic.LocalReport.SetParameters(para);
            if (DataList != null)
            {
                ReportDataSource dataset = new ReportDataSource("SubLedgerDomestic", this.DataList);
                rpvSubLedgerDomestic.LocalReport.DataSources.Add(dataset);
                dataset.Value = DataList;
            }

            this.rpvSubLedgerDomestic.RefreshReport();
            this.rpvSubLedgerDomestic.RefreshReport();
        }

        #endregion
    }
}
