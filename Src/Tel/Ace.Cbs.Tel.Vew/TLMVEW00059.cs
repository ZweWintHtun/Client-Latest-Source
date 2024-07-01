//----------------------------------------------------------------------
// <copyright file="TLMVEW00063" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate>18.6.2013</CreatedDate>
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
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;
using System.Linq;
using Microsoft.Reporting.WinForms;
using System.IO;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;


namespace Ace.Cbs.Tel.Vew
{
    public partial class TLMVEW00059 : BaseForm, ITLMVEW00059
    {
        #region "Constructor"
        public TLMVEW00059()
        {
            InitializeComponent();
        }
        public TLMVEW00059(bool isMainMenu, string parentFormId)
        {
            InitializeComponent();
            this.IsMainMenu = isMainMenu;
            this.ParentFormId = parentFormId;
        }
        public TLMVEW00059(bool isMainMenu, string parentFormId, IList<TLMDTO00001> redto)
        {
            InitializeComponent();
            this.IsMainMenu = isMainMenu;
            this.ParentFormId = parentFormId;
            this.list = redto;
        }
        #endregion

        #region Controller
        private ITLMCTL00059 controller;
        public ITLMCTL00059 Controller
        {
            get { return this.controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }

        #endregion     

        #region "Properties"
        private bool isMainMenu = true;
        public bool IsMainMenu
        {
            get { return this.isMainMenu; }
            set { this.isMainMenu = value; }
        }

        private string parentFormId = string.Empty;
        public string ParentFormId
        {
            get { return this.parentFormId; }
            set { this.parentFormId = value; }
        }

        public IList<TLMDTO00001> list { get; set; }
        #endregion

        #region "Event"
        private void TLMVEW00059_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.ParentFormId != "TLMVEW00030")
                {
                    this.Text = "Encash Remittance Outstanding Listing";
                    string sourceBr = CurrentUserEntity.BranchCode;
                    list = this.controller.ShowEncashOutstandingReport(sourceBr);

                }
                if (list.Count > 0)
                {
                    TLMDTO00001 reDTO = new TLMDTO00001();
                    reDTO.BankName = CurrentUserEntity.BranchDescription;
                    Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });

                    foreach (TLMDTO00001 item in list)
                    {
                        
                        if (!string.IsNullOrEmpty(item.RegisterNo))
                        {
                            item.HomeExchangeRate = item.Amount;//temp assign data value
                            item.Amount = 0;
                           
                        }
                       
                    }
                    
                    reDTO.BranchName = Branch.Address;
                //   reDTO.SourceBranchCode = Branch.BranchCode;

                    rpnEncashOutstanding.LocalReport.DataSources.Clear();
                    ReportParameter[] para = new ReportParameter[9];
                    para[0] = new ReportParameter("BankName", reDTO.BankName);
                    para[1] = new ReportParameter("BranchName", Branch.Address);
                    para[2] = new ReportParameter("Phone", Branch.Phone);
                    para[3] = new ReportParameter("Fax", Branch.Fax);
                    para[7] = new ReportParameter("BrCode", Branch.BranchCode);
                    para[8] = new ReportParameter("Br_Alias", Branch.Bank_Alias);

                    Image img = null;
                    string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                    using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                    {
                        img = System.Drawing.Image.FromStream(stream);

                        img.Save(tempFilePath);
                    }

                    para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                    para[5] = new ReportParameter("ReportTitle", "Encashment Remittance Outstanding Listing as at "+ DateTime.Now.ToString("dd/MM/yyyy"));
                    para[6] = new ReportParameter("TotalRecords", list.Count.ToString());
                   
                    this.rpnEncashOutstanding.LocalReport.EnableExternalImages = true;
                    rpnEncashOutstanding.LocalReport.SetParameters(para);
                    ReportDataSource dataset = new ReportDataSource("EncashRegisterOutstandingDataSet", list);
                    rpnEncashOutstanding.LocalReport.DataSources.Add(dataset);

                    dataset.Value = list;
                    this.rpnEncashOutstanding.RefreshReport();
                }
                else
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                }
            }
            catch (Exception ex)
            { }
        }
        #endregion
    }
}
