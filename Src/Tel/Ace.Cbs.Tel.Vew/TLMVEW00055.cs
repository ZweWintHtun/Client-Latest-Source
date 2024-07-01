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
    public partial class TLMVEW00055 : BaseForm, ITLMVEW00055
    {
        public TLMVEW00055()
        {
            InitializeComponent();
        }
          
        #region Controls Input Output

        public TLMVEW00055(DateTime requireDate, bool isTransactionDate, string branchCode, string currencyCode, bool isreversal,bool isSourceCurrency,bool sortByTime,string acsign,bool issettlementdate)
         {
             InitializeComponent();
            // this.ParentFormId = parentFormId;
             this.RequireDate = requireDate;
             this.IsTransactionDate = isTransactionDate;
             this.BranchCode = branchCode;
             //this.IsAllBranch = isAllBranch;
             ////this.CurrencyCode = currencyCode.Replace("KYT", "MMK");//Updated by HWKO (25-Sep-2017)
             this.CurrencyCode = currencyCode;
             this.IsReversal = isreversal;
             this.IsSourceCurrency = isSourceCurrency;
             this.SortByTime = sortByTime;
             this.AccountSign = acsign;
             this.IsSettlementDate = issettlementdate;
         }

        public bool IsSettlementDate { get; set; }
        //public string AccountSign { get; set; }
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
        //public bool IsAllBranch { get; set; }
        public bool IsReversal { get; set; }
        public bool IsSourceCurrency { get; set; }
        public bool SortByTime { get; set; }
        IList<TLMDTO00058> dayBooks { get; set; }
        public string AccountSign { get; set; }
        public int subTotalCount = 0;

        #endregion
     
        #region Controller
        private ITLMCTL00055 controller;
        public ITLMCTL00055 Controller
        {
            get { return this.controller; }
            set
            {
              this.controller = value;
                this.controller.View = this;
            }
        }
     
        #endregion

        private void TLMVEW00055_Load(object sender, EventArgs e)
        {
            decimal Debit_cash = 0,Debit_Transfer = 0 , Debit_Clearing= 0 ,Debit_Total = 0,Credit_cash = 0,Credit_Transfer = 0 , Credit_Clearing= 0 ,Credit_Total = 0;
            TLMDTO00058 dayBookDTO = new TLMDTO00058();
            if (this.IsReversal == false && this.IsSourceCurrency == true)
            { this.dayBooks = this.controller.SelectDomesticDayBook();
            dayBookDTO.ReportTitle = "(Without Reversal)";
            }
            else if (this.IsReversal == true && this.IsSourceCurrency == true)
            { this.dayBooks = this.controller.SelectDomesticReversalDayBook();
             dayBookDTO.ReportTitle = "(Without Reversal)";
            }
            else if (this.IsReversal == false && this.IsSourceCurrency == false)
            { this.dayBooks = this.controller.SelectDomesticHomeDayBook();
            dayBookDTO.ReportTitle = "(Without Reversal)";
            }
            else  if (this.IsReversal == true && this.IsSourceCurrency == false)
            { this.dayBooks = this.controller.SelectDomesticHomeReversalDayBook();
             dayBookDTO.ReportTitle = "(With Reversal)";
            }

            if (this.dayBooks.Count > 0)
            {
                //if (this.SortByTime == true)
                //{
                //    this.dayBooks.OrderByDescending(a => a.Sort_Date_Time.Value);
                //}
                //else
                //{
                //    this.dayBooks.OrderByDescending(a => a.Account_No);
                //}
                #region old by ZMS (27-JUN-2018)
                //foreach (TLMDTO00058 dto in dayBooks)
                //{
                //    if (!dto.ACNoDesp.Contains("(SUB TOTAL)"))
                //    {
                //        Debit_cash += Convert.ToDecimal(dto.Debit_Cash);
                //        Debit_Transfer += Convert.ToDecimal(dto.Debit_Transfer);
                //        Debit_Clearing += Convert.ToDecimal(dto.Debit_Clearing);
                //        Debit_Total += Convert.ToDecimal(dto.Debit_Total);
                //        Credit_cash += Convert.ToDecimal(dto.Credit_Cash);
                //        Credit_Transfer += Convert.ToDecimal(dto.Credit_Transfer);
                //        Credit_Clearing += Convert.ToDecimal(dto.Credit_Clearing);
                //        Credit_Total += Convert.ToDecimal(dto.Credit_Total);
                //    }
                //    else subTotalCount = subTotalCount + 1;
                //}
                #endregion

                Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });

                rpvDomesticDayBook.LocalReport.DataSources.Clear();
                ReportParameter[] para = new ReportParameter[11];
                para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
                para[1] = new ReportParameter("BranchName", Branch.Address);
                para[2] = new ReportParameter("Phone", Branch.Phone);
                para[3] = new ReportParameter("Fax", Branch.Fax);
                para[9] = new ReportParameter("BrCode", Branch.BranchCode);
                para[10] = new ReportParameter("Br_Alias", Branch.BranchAlias);

                #region old by ZMS (27-JUN-2018)
                //para[11] = new ReportParameter("Debit_cash", String.Format("{0:0,0.00}", Debit_cash));
                //para[12] = new ReportParameter("Debit_Transfer",String.Format("{0:0,0.00}",  Debit_Transfer));
                //para[13] = new ReportParameter("Debit_Clearing", String.Format("{0:0,0.00}", Debit_Clearing));
                //para[14] = new ReportParameter("Debit_Total", String.Format("{0:0,0.00}", Debit_Total));
                //para[15] = new ReportParameter("Credit_cash", String.Format("{0:0,0.00}", Credit_cash));
                //para[16] = new ReportParameter("Credit_Transfer", String.Format("{0:0,0.00}", Credit_Transfer));
                //para[17] = new ReportParameter("Credit_Clearing", String.Format("{0:0,0.00}", Credit_Clearing));
                //para[18] = new ReportParameter("Credit_Total", String.Format("{0:0,0.00}", Credit_Total));
                //para[19] = new ReportParameter("subTotalCount", subTotalCount.ToString());

#endregion              

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


                this.rpvDomesticDayBook.LocalReport.EnableExternalImages = true;
                rpvDomesticDayBook.LocalReport.SetParameters(para);
                ReportDataSource dataset = new ReportDataSource("DomesticDayBook_DataSet", dayBooks);
                rpvDomesticDayBook.LocalReport.DataSources.Add(dataset);

                dataset.Value = dayBooks;
                this.rpvDomesticDayBook.RefreshReport();
            }

            else
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                this.Close();
            }
            

        }
    }
}
