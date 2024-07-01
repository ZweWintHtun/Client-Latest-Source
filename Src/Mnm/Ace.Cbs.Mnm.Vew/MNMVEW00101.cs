//----------------------------------------------------------------------
// <copyright file="TLMVEW00063" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>HM</CreatedUser>
// <CreatedDate>30.12.2013</CreatedDate>
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
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00101 :BaseDockingForm, IMNMVEW00101
    {
        #region Properties

        public string FormName { get; set; }
        //public string AccountNo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IList<PFMDTO00001> PrintDataList { get; set; }
        public IList<MNMDTO00032> list { get; set; }

        #endregion
               
        #region Constructor

        public MNMVEW00101()
        {
            InitializeComponent();
        }
        public MNMVEW00101(IList<PFMDTO00001> List,string formName, DateTime startDate, DateTime endDate)
        {
            this.FormName = formName;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.PrintDataList = List;
            InitializeComponent();
        }

      #endregion    

        #region Controller

        private IMNMCTL00101 controller;
        public IMNMCTL00101 Controller
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

        private void MNMVEW00101_Load(object sender, EventArgs e)
        {            
            Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });

            rpvCustomerLedger.LocalReport.DataSources.Clear();
            ReportParameter[] para = new ReportParameter[10];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
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
            para[5] = new ReportParameter("StartDate", StartDate.ToString("MM/yyyy"));
            para[6] = new ReportParameter("EndDate", EndDate.ToString("MM/yyyy"));
            para[7] = new ReportParameter("Count", this.PrintDataList.Count.ToString());
           
          
            this.rpvCustomerLedger.LocalReport.EnableExternalImages = true;
            rpvCustomerLedger.LocalReport.SetParameters(para);
            ReportDataSource dataset = new ReportDataSource("SubLedgerCustomerDataSet",PrintDataList);
            rpvCustomerLedger.LocalReport.DataSources.Add(dataset);
            dataset.Value = PrintDataList;

            this.rpvCustomerLedger.RefreshReport();
            this.rpvCustomerLedger.RefreshReport();
        }

        #endregion 


    }
}
