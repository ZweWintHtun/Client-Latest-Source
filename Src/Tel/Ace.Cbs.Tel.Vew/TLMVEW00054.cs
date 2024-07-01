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

namespace Ace.Cbs.Tel.Vew
{
    public partial class TLMVEW00054 : BaseForm, ITLMVEW00054
    {
        public TLMVEW00054()
        {
            InitializeComponent();
        }

        #region Controls Input Output

       public TLMVEW00054(DateTime requireDate, bool isTransactionDate, string branchCode,string currencyCode,bool isreversal,bool isSaving,bool sortByTime,string acsign,bool issaving,bool issettlementdate)
         {
             InitializeComponent();
            // this.ParentFormId = parentFormId;
             this.RequireDate = requireDate;
             this.IsTransactionDate = isTransactionDate;
             this.BranchCode = branchCode;
             //this.IsAllBranch = isAllBranch;
             //this.CurrencyCode = currencyCode.Replace("KYT", "MMK");//Updated by HWKO (25-Sep-2017)
             this.CurrencyCode = currencyCode;
             this.IsReversal = isreversal;
             this.IsSaving = isSaving;
             this.SortByTime = sortByTime;
             this.AccountSign = acsign;
             this.IsSaving = issaving;
             this.IsSettlementDate = issettlementdate;
         }

       public bool IsSettlementDate { get; set; }
       public string AccountSign { get; set; }
        public DateTime RequireDate { get; set; }
        public string CurrencyCode { get; set; }
       
        private string parentFormId = string.Empty;
        public string ParentFormId
        {
            get { return this.parentFormId; }
            set { this.parentFormId = value; }
        }

        public bool IsTransactionDate { get; set; }
        public string BranchCode { get; set; }
       // public bool IsAllBranch { get; set; }
        public bool IsReversal { get; set; }
        public bool IsSaving { get; set; }
        public bool SortByTime { get; set; }
        IList<TLMDTO00058> dayBooks { get; set; }
   
        #endregion

        #region Controller
        private ITLMCTL00054 controller;
        public ITLMCTL00054 Controller
        {
            get { return this.controller; }
            set
            {
              this.controller = value;
                this.controller.View = this;
            }
        }
     
        #endregion

        private void TLMVEW00054_Load(object sender, EventArgs e)
        {
            try
            {
                TLMDTO00058 dayBookDTO = new TLMDTO00058();
               
                if (this.IsSaving == true && this.IsReversal == false)
                {
                    this.dayBooks = this.controller.SelectSavingDayBook();                  
                    dayBookDTO.ReportTitle1 = "Day Book Saving as at ";
                    dayBookDTO.ReportTitle2 = "(Without Reversal)";
                    this.Text = "Saving Day Book Report";
                }
                else if (this.IsSaving == false && this.IsReversal == false)
                {
                 this.dayBooks = this.controller.SelectFixedDayBook();              
                 dayBookDTO.ReportTitle1 = "Day Book Fixed Deposit as at ";
                 dayBookDTO.ReportTitle2 = "(Without Reversal)";
                 this.Text = "Fixed Day Book Report";
                }

                else if (this.IsSaving == true && this.IsReversal == true)
                {
                    dayBookDTO.ReportTitle1 = "Day Book Saving as at ";
                    this.dayBooks = this.controller.SelectSavingReversalDayBook();
                    dayBookDTO.ReportTitle2 = "(With Reversal)";
                    this.Text = "Saving Day Book with Reversal Report";
                }

                else if (this.IsSaving == false && this.IsReversal == true)
                {
                    dayBookDTO.ReportTitle1 = "Day Book Fixed Deposit as at ";
                    this.dayBooks = this.controller.SelectFixedReversalDayBook();
                    dayBookDTO.ReportTitle2 = "(With Reversal)";
                    this.Text = "Fixed Day Book With Reversal Report";
                }                
             

                if (this.dayBooks.Count > 0)
                {

                    if (this.SortByTime == true)
                    {
                        this.dayBooks.OrderByDescending(a => a.Sort_Date_Time.Value);
                    }
                    else
                    {
                        this.dayBooks.OrderByDescending(a => a.Account_No);
                    }

                    Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                   
                     

                    rpvSavingAndFixedDayBook.LocalReport.DataSources.Clear();
                    ReportParameter[] para = new ReportParameter[12];
                    para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
                    para[1] = new ReportParameter("BranchName", Branch.Address);
                    para[2] = new ReportParameter("Phone", Branch.Phone);
                    para[3] = new ReportParameter("Fax", Branch.Fax);
                    para[10] = new ReportParameter("BrCode", Branch.BranchCode);
                    para[11] = new ReportParameter("Br_Alias", Branch.BranchAlias);


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


                    para[5] = new ReportParameter("ReportTitle1", dayBookDTO.ReportTitle1);
                    para[6] = new ReportParameter("TotalRecords", dayBooks.Count.ToString());
                    para[7] = new ReportParameter("ReportTitle2", dayBookDTO.ReportTitle2);
                    para[8] = new ReportParameter("Currency", CurrencyCode.Replace("KYT", "MMK"));
                  
                    if (BranchCode == string.Empty)
                    {
                        para[9] = new ReportParameter("Branch", "By All Branches");
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(BranchCode))
                        {
                            Ace.Windows.Admin.DataModel.BranchDTO br = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { this.BranchCode });


                            para[9] = new ReportParameter("Branch", "By " + br.BranchDescription);
                        }
                    }

                    this.rpvSavingAndFixedDayBook.LocalReport.EnableExternalImages = true;
                    rpvSavingAndFixedDayBook.LocalReport.SetParameters(para);
                    ReportDataSource dataset = new ReportDataSource("SavingDayBook_DataSet", dayBooks);
                    rpvSavingAndFixedDayBook.LocalReport.DataSources.Add(dataset);

                    dataset.Value = dayBooks;
                    this.rpvSavingAndFixedDayBook.RefreshReport();
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
