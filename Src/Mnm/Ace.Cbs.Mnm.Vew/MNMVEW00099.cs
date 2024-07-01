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
using System.Drawing;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Mnm.Dmd.DTO;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;
using System.Linq;
using Microsoft.Reporting.WinForms;
using System.IO;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00099 : BaseDockingForm, IMNMVEW00099
    {
        IList<MNMDTO00007> list = new List<MNMDTO00007>();
        string currency = string.Empty;

        #region Constructor

        public MNMVEW00099()
        {
            InitializeComponent();
        }
        public MNMVEW00099(string month,string cur,IList<MNMDTO00007> silist)
        {
            InitializeComponent();
            this.month = month;
            this.list = silist;
            this.currency = cur;
        }
        #endregion

        #region Properties

        public string FormName { get; set; }
        public string month { get; set; }
            
        #endregion

        #region Controller
        private IMNMCTL00099 controller;
        public IMNMCTL00099 Controller
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

        private void MNMVEW00099_Load(object sender, EventArgs e)
        {

            Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });

            rpvInterestSchedule.LocalReport.DataSources.Clear();
            ReportParameter[] para = new ReportParameter[13];
            para[0] = new ReportParameter("BankName", Branch.Bank_Alias + CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[11] = new ReportParameter("BrCode", Branch.BranchCode);
            para[12] = new ReportParameter("Br_Alias", Branch.Bank_Alias);



            switch (month) 
            {
                case "Interest Schedule (Apr-Jun)":
                    para[6] = new ReportParameter("Month1", "April");
                    para[7] = new ReportParameter("Month2", "May");
                    para[8] = new ReportParameter("Month3", "June");
                    break;
                case "Interest Schedule (July-Sep)":
                    para[6] = new ReportParameter("Month1", "July");
                    para[7] = new ReportParameter("Month2", "Augst");
                    para[8] = new ReportParameter("Month3", "September");
                    break;
                case "Interest Schedule (Oct-Dec)":
                    para[6] = new ReportParameter("Month1", "October");
                    para[7] = new ReportParameter("Month2", "November");
                    para[8] = new ReportParameter("Month3", "December");
                    break;
                case "Interest Schedule (Jan-Mar)":
                    para[6] = new ReportParameter("Month1", "January");
                    para[7] = new ReportParameter("Month2", "February");
                    para[8] = new ReportParameter("Month3", "March");
                    break;
            }

            Image img = null;
            string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            
            using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            {
                img = System.Drawing.Image.FromStream(stream);

                img.Save(tempFilePath);
            }

            para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[5] = new ReportParameter("Head", FormName + "Listing");
            para[9] = new ReportParameter("Currency", currency);
            para[10] = new ReportParameter("Count", list.Count.ToString());
       
            this.rpvInterestSchedule.LocalReport.EnableExternalImages = true;
            rpvInterestSchedule.LocalReport.SetParameters(para);
            ReportDataSource dataset = new ReportDataSource("MNMDS00019", list);
            rpvInterestSchedule.LocalReport.DataSources.Add(dataset);

            foreach (MNMDTO00007 si in list)
            {
                switch (month)
                {
                    case "Interest Schedule (Apr-Jun)":
                        si.Total = si.Month1 + si.Month2 + si.Month3;
                        break;
                    case "Interest Schedule (July-Sep)":
                        si.Month1 = si.Month4;
                        si.Month2 = si.Month5;
                        si.Month3 = si.Month6;
                        si.Total = si.Month1 + si.Month2 + si.Month3;
                        break;
                    case "Interest Schedule (Oct-Dec)":
                        si.Month1 = si.Month7;
                        si.Month2 = si.Month8;
                        si.Month3 = si.Month9;
                        si.Total = si.Month1 + si.Month2 + si.Month3;
                        break;
                    case "Interest Schedule (Jan-Mar)":
                        si.Month1 = si.Month10;
                        si.Month2 = si.Month11;
                        si.Month3 = si.Month12;
                        si.Total = si.Month1 + si.Month2 + si.Month3;
                        break;
                }
            }

            dataset.Value = list;


            this.rpvInterestSchedule.RefreshReport();
            this.rpvInterestSchedule.RefreshReport();
        }

        private void MNMVEW00099t_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.rpvInterestSchedule.LocalReport.ReleaseSandboxAppDomain();
        }

        #endregion

      
     

    }
}




