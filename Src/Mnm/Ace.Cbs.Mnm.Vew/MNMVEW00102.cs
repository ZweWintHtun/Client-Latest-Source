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

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00102 : BaseDockingForm, IMNMVEW00102
    {
        bool isFixedBal;
        string currency;
        #region Properties

        public string Header { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public IList<MNMDTO00035> list { get; set; }

        #endregion 

        #region Constructor

        public MNMVEW00102()
        {
            InitializeComponent();
        }

        public MNMVEW00102(IList<MNMDTO00035> list , string formName, bool isFixedBal, string currency)
        {
            this.list = list;
            this.Header = formName;
            this.isFixedBal = isFixedBal;
            this.currency = currency;
            InitializeComponent();
        }

        #endregion

        #region Controller

        private IMNMCTL00102 controller;
        public IMNMCTL00102 Controller
        {
            get { return this.controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }

        #endregion

        #region Events

        private void MNMVEW00102_Load(object sender, EventArgs e)
        {
            Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });

            rpvSubByTransaction.LocalReport.DataSources.Clear();
            ReportParameter[] para = new ReportParameter[11];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[9] = new ReportParameter("BrCode", Branch.BranchCode);
            para[10] = new ReportParameter("Br_Alias", Branch.Bank_Alias);


            Image img = null;
            string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            {
                img = System.Drawing.Image.FromStream(stream);

                img.Save(tempFilePath);
            }

            para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[5] = new ReportParameter("Head", this.Header);
            para[6] = new ReportParameter("Count", list.Count.ToString());
            if (this.isFixedBal)
                para[7] = new ReportParameter("ColumnVisible", "false");
            else
                para[7] = new ReportParameter("ColumnVisible", "true");
            para[8] = new ReportParameter("Currency", string.IsNullOrEmpty(this.currency) ? "All" : this.currency);

            this.rpvSubByTransaction.LocalReport.EnableExternalImages = true;
            rpvSubByTransaction.LocalReport.SetParameters(para);
            ReportDataSource dataset = new ReportDataSource("MNMDS00022", list);
            rpvSubByTransaction.LocalReport.DataSources.Add(dataset);
            dataset.Value = list;

            this.rpvSubByTransaction.RefreshReport();
        }

        #endregion
    }
}
