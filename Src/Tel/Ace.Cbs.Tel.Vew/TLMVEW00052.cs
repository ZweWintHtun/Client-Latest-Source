//----------------------------------------------------------------------
// <copyright file="TLMVEW00052.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-09-10</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Admin.DataModel;
using Microsoft.Reporting.WinForms;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Cx.Cle;
using System.IO;
using System.Drawing;


namespace Ace.Cbs.Tel.Vew
{
    //Bankcash Scroll Reports
    public partial class TLMVEW00052 : BaseDockingForm
    {
        #region "Properties"
        private string currencyType { get; set; }
        private string dateType { get; set; }
        private bool isAllBranches { get; set; }
        private bool isWithReversal { get; set; }
        private bool isHomeCurrency { get; set; }
        private DateTime datetime { get; set; }
        private string screenName { get; set; }

        private IList<PFMDTO00042> ReportTLFDTOList { get; set; }
        private PFMDTO00042 ReportTLFDTO { get; set; }
        #endregion

        #region "Constructors"
        public TLMVEW00052()
        {
            InitializeComponent();
        }

        public TLMVEW00052(IList<PFMDTO00042> DTOList, PFMDTO00042 DTO, string transactionstatus)
        {
            this.ReportTLFDTO = DTO;
            this.ReportTLFDTOList = DTOList;
            this.Text = DTO.OrgnPoNo;
            // this.FormName = transactionstatus;            
            InitializeComponent();
        }
        #endregion

        private string stringToDecimal(decimal str)
        {
            try
            {
                return string.Format("{0:#,##0.00}", str);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        #region "Load_Event"
        private void TLMVEW00052_Load(object sender, EventArgs e)
        {
            string amountStatus = " By Home Amount";
            try
            {
                if (ReportTLFDTOList.Count > 0)
                {
                    PFMDTO00042 bankstatementDTO = new PFMDTO00042();
                    bankstatementDTO.BankName = CurrentUserEntity.BranchDescription;

                    BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                    bankstatementDTO.BranchName = Branch.Address;
                    bankstatementDTO.Phone = Branch.Phone;
                    bankstatementDTO.Fax = Branch.Fax;

                    rvBankCashScroll.LocalReport.DataSources.Clear();
                    ReportParameter[] para = new ReportParameter[15];
                    para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
                    para[1] = new ReportParameter("BranchName", bankstatementDTO.BranchName);
                    para[2] = new ReportParameter("Phone", bankstatementDTO.Phone);
                    para[3] = new ReportParameter("Fax", bankstatementDTO.Fax);
                    para[12] = new ReportParameter("BrCode", Branch.BranchCode);

                    para[13] = new ReportParameter("Br_Alias", Branch.BranchAlias);


                    //Image img = null;
                    string tempFilePath = Application.StartupPath + "\\pristinelogo.png";// "\\banklogo.jpg"
                    //Commented by HWKO (30-Oct-2017)
                    //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                    //{
                    //    img = System.Drawing.Image.FromStream(stream);

                    //    img.Save(tempFilePath);
                    //}
                    para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                    //switch (ReportTLFDTO.DateType)
                    //{
                    //    case "Transaction Date": para[5] = new ReportParameter("ReportTitle", ReportTLFDTO.OrgnPoNo + " By Date");
                    //    break;
                    //    case "Settlement Date": para[5] = new ReportParameter("ReportTitle", ReportTLFDTO.OrgnPoNo + " By Settlement Date");
                    //    break;
                    //}
                    para[5] = new ReportParameter("ReportTitle", ReportTLFDTO.OrgnPoNo + " By Date");
                    para[6] = new ReportParameter("DateTime", ReportTLFDTO.StartDate.ToString("dd/MM/yyyy"));
                    //para[7] = new ReportParameter("BranchType",(ReportTLFDTO.IsAllBranches == true)? "All Branches":"Branch Code : "+ReportTLFDTO.OtherBank);                    
                    para[7] = new ReportParameter("BranchType", (ReportTLFDTO.IsAllBranches == true) ? "All Branches" : "Branch Code : " + ReportTLFDTO.SourceBranch);   

                    if (ReportTLFDTO.CurrencyType == "Home Currency")
                    {
                        para[8] = new ReportParameter("Currencies", "All Currencies" + amountStatus);
                    }
                    else
                    {
                        para[8] = new ReportParameter("Currencies", "Currency : " + ReportTLFDTO.CurCode.Replace("KYT", "MMK") + amountStatus);
                    }
                    decimal ReturnObalance = ReportTLFDTOList[ReportTLFDTOList.Count - 1].ReturnObalance;
                    decimal TransferAndClearing = ReportTLFDTOList[ReportTLFDTOList.Count - 1].TrCL;

                    decimal sumOfReturnObalanceAndTransferAndClearing = ReturnObalance + TransferAndClearing;
                    
                    para[9] = new ReportParameter("OpeningBalance", ReturnObalance.ToString());
                    para[10] = new ReportParameter("TransferAndClearing", TransferAndClearing.ToString());
                    para[11] = new ReportParameter("Count", ReportTLFDTOList.Count.ToString());

                    para[14] = new ReportParameter("SumOfOBalAndTCL", stringToDecimal(sumOfReturnObalanceAndTransferAndClearing));

                    this.rvBankCashScroll.LocalReport.EnableExternalImages = true;
                    rvBankCashScroll.LocalReport.SetParameters(para);
                    ReportDataSource dataset = new ReportDataSource("BankcashScrollDataSet", ReportTLFDTOList);
                    rvBankCashScroll.LocalReport.DataSources.Add(dataset);

                    dataset.Value = ReportTLFDTOList;
                    rvBankCashScroll.LocalReport.Refresh();
                    this.rvBankCashScroll.RefreshReport();
                }
            }
            catch (Exception ex)
            {
            }
        }
        #endregion
    }
}
