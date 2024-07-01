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
using System.Drawing.Printing;

namespace Ace.Cbs.Tel.Vew
{
    public partial class TLMVEW00053 : BaseForm, ITLMVEW00053
    {
         public TLMVEW00053()
        {
            InitializeComponent();
        }

        #region Controls Input Output

         public TLMVEW00053(DateTime requireDate, bool isTransactionDate, string branchCode,string currencyCode,bool isreversal,bool isSourceCurrency,bool sortByTime,string acsign,bool issettlemendate)
         {
             InitializeComponent();
          //   this.ParentFormId = parentFormId;
             this.RequireDate = requireDate;
             this.IsTransactionDate = isTransactionDate;
             this.BranchCode = branchCode;
             //this.IsAllBranch = isAllBranch;
             //this.CurrencyCode = currencyCode.Replace("KYT","MMK");//Updated by HWKO (25-Sep-2017)
             this.CurrencyCode = currencyCode;
             this.IsReversal = isreversal;
             this.IsSourceCurrency = isSourceCurrency;
             this.SortByTime = sortByTime;
             this.AccountSign = acsign;
             this.IsSettlementDate = issettlemendate;
          
         }

        public DateTime RequireDate { get; set; }
        public bool IsSettlementDate { get; set;}
      
        public string CurrencyCode { get; set; }
        private string parentFormId = string.Empty;
        public string ParentFormId
        {
            get { return this.parentFormId; }
            set { this.parentFormId = value; }
        }

        public bool IsTransactionDate { get; set; }
        public string BranchCode { get; set; }
        public bool IsAllBranch { get; set; }
        public bool IsReversal { get; set; }
        public bool IsSourceCurrency { get; set; }
        public bool SortByTime { get; set; }
        IList<TLMDTO00058> dayBooks { get; set; }
        public string AccountSign { get; set; }
        

        #endregion
      
        #region Controller
        private ITLMCTL00053 controller;
        public ITLMCTL00053 Controller
        {
            get { return this.controller; }
            set
            {
              this.controller = value;
                this.controller.View = this;
            }
        }
     
        #endregion

        //Added by HWKO (14-Aug-2017)
        private string GetReportTitleByAcSign(string acsign)
        {
            if (acsign.Contains("B"))
            { return "Business Loan"; }
            else if (acsign.Contains("H"))
            { return "Hire Purchase"; }
            else if (acsign.Contains("P"))
            { return "Personal Loan"; }
            else if (acsign.Contains("D"))
            { return "Dealer Account"; }
            else
                return String.Empty;
        }

        private void TLMVEW00053_Load(object sender, EventArgs e)
        {
            try
            { 
                this.Text = this.GetReportTitleByAcSign(this.AccountSign) + " Day Book Report";   
                
                TLMDTO00058 dayBookDTO = new TLMDTO00058();
                if (this.IsReversal == false && this.IsSourceCurrency == true)
                {
                    this.dayBooks = this.controller.SelectCurrentDayBook();
                    dayBookDTO.ReportTitle = "(Without Reversal)";
                }

                else if (this.IsReversal == true && this.IsSourceCurrency == true)
                {
                    this.dayBooks = this.controller.SelectCurrentReversalDayBook();
                    dayBookDTO.ReportTitle = "(With Reversal)";
                }

                else if (this.IsReversal == false && this.IsSourceCurrency == false)
                {
                    this.dayBooks = this.controller.SelectCurrentHomeDayBook();
                    dayBookDTO.ReportTitle = "(Without Reversal)";
                }
                else if (this.IsReversal == true && this.IsSourceCurrency == false)
                {
                    this.dayBooks = this.controller.SelectCurrentHomeReversalDayBook();
                    dayBookDTO.ReportTitle = "(With Reversal)";
                }
           


                if (this.dayBooks.Count > 0)
                {
                    //if (this.SortByTime == true)
                    //{
                    //    //this.dayBooks.OrderByDescending(a => a.Sort_Date_Time.Value);
                    //    this.dayBooks.OrderBy(a => a.Sort_Date_Time.Value); 
                    //}
                    //else
                    //{
                    //    //this.dayBooks.OrderByDescending(a => a.Account_No);
                    //    this.dayBooks.OrderBy(a => a.Account_No); 
                    //}
                    Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });

                    rpvCurrentDayBook.LocalReport.DataSources.Clear();
                    ReportParameter[] para = new ReportParameter[13];
                    para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
                    para[1] = new ReportParameter("BranchName", Branch.Address);
                    para[2] = new ReportParameter("Phone", Branch.Phone);
                    para[3] = new ReportParameter("Fax", Branch.Fax);
                    para[9] = new ReportParameter("BrCode", Branch.BranchCode);
                    para[10] = new ReportParameter("Br_Alias", Branch.BranchAlias);
                    para[11] = new ReportParameter("ReportTitle2", this.GetReportTitleByAcSign(this.AccountSign));

                    //Added by HMW at (13.5.2019)
                    if (this.IsSettlementDate == true)
                    {
                        dayBookDTO.Date_Time = this.dayBooks[0].SettlementDate;
                        para[12] = new ReportParameter("ByDateType","By Settlement Date");
                    }
                    else
                    {
                        dayBookDTO.Date_Time = this.dayBooks[0].Date_Time;
                        para[12] = new ReportParameter("ByDateType","By Transaction Date");
                    }
                    
                    
                    //Commented by HWKO (30-Oct-2017)
                    //Image img = null;
                    //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                    //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                    //{
                    //    img = System.Drawing.Image.FromStream(stream);

                    //    img.Save(tempFilePath);
                    //}

                    string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

                    para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);


                    para[5] = new ReportParameter("ReportTitle", dayBookDTO.ReportTitle);
                    para[6] = new ReportParameter("TotalRecords", dayBooks.Count.ToString());
                    para[7] = new ReportParameter("Currency", CurrencyCode.Replace("KYT", "MMK"));
                    if (BranchCode == string.Empty)
                    {
                        para[8] = new ReportParameter("Branch", "By All Branches");
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(BranchCode))
                        {
                            Ace.Windows.Admin.DataModel.BranchDTO br = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { this.BranchCode });


                            para[8] = new ReportParameter("Branch", "By " + br.BranchDescription);
                        }
                    }


                    this.rpvCurrentDayBook.LocalReport.EnableExternalImages = true;
                    rpvCurrentDayBook.LocalReport.SetParameters(para);
                    ReportDataSource dataset = new ReportDataSource("CurrentDayBook_DataSet", dayBooks);
                    rpvCurrentDayBook.LocalReport.DataSources.Add(dataset);

                    dataset.Value = dayBooks;
                    this.rpvCurrentDayBook.RefreshReport();

                    //var setup = this.rpvCurrentDayBook.GetPageSettings();
                    //setup.Margins = new System.Drawing.Printing.Margins(2, 1, 1, 1);
                    //this.rpvCurrentDayBook.SetPageSettings(setup);                   
                }

                else
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                    this.Close();
                }
                
            }
            catch (Exception ex)
            { }
        }


       
      
    }
}
