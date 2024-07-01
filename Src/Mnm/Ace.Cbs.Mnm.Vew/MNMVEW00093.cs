using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Microsoft.Reporting.WinForms;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Utt;
using System.IO;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00093 : BaseForm
    {
        #region Property

        public bool IsReversal { get; set; }
        public bool IsSourceCurrency { get; set; }
        public string FormName { get; set; }
        public string BranchNo { get; set; }
        public string Currency { get; set; }
        public bool IsCBMACode { get; set; }
        IList<MNMDTO00038> trialSheetData = new List<MNMDTO00038>();
        IList<PFMDTO00042> rawData;
        string head;
        decimal openingBal;

        #endregion

        #region constructors
        public MNMVEW00093()
        {
            InitializeComponent();
        }

        public MNMVEW00093(string branchno,string cur,bool isReversal, string formName,IList<PFMDTO00042> rawData,bool isCBMACode)
        {
            this.BranchNo = branchno;
            this.Currency = cur.Replace("KYT","MMK");//Updated by HWKO (25-Sep-2017)
            InitializeComponent();
            this.IsReversal = isReversal;
            this.FormName = formName;
            this.rawData = rawData;
            this.IsCBMACode = isCBMACode;
        }
        #endregion

        #region Events

        private void MNMVEW00093_Load(object sender, EventArgs e)
        {
            if (this.IsReversal == false)
            {
                this.head = FormName + " (Without Reversal) Listing";
            }
            else if (this.IsReversal == true)
            {
                this.head = FormName + " (With Reversal) Listing";
            }

            Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });

            rpvTriBalanceDetail.LocalReport.DataSources.Clear();
            ReportParameter[] para = new ReportParameter[14];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[12] = new ReportParameter("BrCode", Branch.BranchCode);
            para[13] = new ReportParameter("Br_Alias", Branch.BranchAlias);

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
            para[5] = new ReportParameter("Head", this.head);
            para[6] = new ReportParameter("branchno", this.BranchNo);
            para[7] = new ReportParameter("cur", this.Currency.Replace("KYT","MMK"));//Updated by HWKO (25-Sep-2017)

            this.openingBal = rawData[rawData.Count - 1].ReturnObalance;
            rawData.RemoveAt(rawData.Count - 1);
            rawData = rawData.OrderBy(x => x.ACode).ToList();

            string aCode = string.Empty;
            string cBMAcode = string.Empty;
            string aHead = string.Empty;
            decimal cr_cash = 0;
            decimal cr_transfer = 0;
            decimal cr_clearing = 0;
            decimal dr_cash = 0;
            decimal dr_transfer = 0;
            decimal dr_clearing = 0;
            decimal cr_GTotal = 0;
            decimal dr_GTotal = 0;

            for (int i = 0; i < rawData.Count; i++)
             {
                if (i == 0)
                {
                    #region Collect Data
                    if (rawData[i].Status[1] == 'C')    //Credit
                    {
                        switch (rawData[i].Status[0])
                        {
                            case 'C': cr_cash += rawData[i].Amount.Value; break;
                            case 'T': cr_transfer += rawData[i].Amount.Value; break;
                            case 'L': cr_clearing += rawData[i].Amount.Value; break;
                        }
                    }
                    else    //Debit
                    {
                        switch (rawData[i].Status[0])
                        {
                            case 'C': dr_cash += rawData[i].Amount.Value; break;
                            case 'T': dr_transfer += rawData[i].Amount.Value; break;
                            case 'L': dr_clearing += rawData[i].Amount.Value; break;
                        }
                    }
                    aCode = rawData[i].ACode;
                    cBMAcode = rawData[i].CBMACode;
                    aHead = rawData[i].ACName;
                    #endregion
                }

                else
                {
                    if (rawData[i].ACode == rawData[i - 1].ACode)
                    {
                        #region Collect Data
                        if (rawData[i].Status[1] == 'C')    //Credit
                        {
                            switch (rawData[i].Status[0])
                            {
                                case 'C': cr_cash += rawData[i].Amount.Value; break;
                                case 'T': cr_transfer += rawData[i].Amount.Value; break;
                                case 'L': cr_clearing += rawData[i].Amount.Value; break;
                            }
                        }
                        else    //Debit
                        {
                            switch (rawData[i].Status[0])
                            {
                                case 'C': dr_cash += rawData[i].Amount.Value; break;
                                case 'T': dr_transfer += rawData[i].Amount.Value; break;
                                case 'L': dr_clearing += rawData[i].Amount.Value; break;
                            }
                        }
                        aCode = rawData[i].ACode;
                        cBMAcode = rawData[i].CBMACode;
                        aHead = rawData[i].ACName;
                        #endregion
                    }
                    else
                    {
                        #region Add TrialSheet Data
                        MNMDTO00038 trialSheet = new MNMDTO00038();
                        trialSheet.CR_Cash = cr_cash;
                        trialSheet.CR_Transfer = cr_transfer;
                        trialSheet.CR_Clearing = cr_clearing;
                        trialSheet.CR_Total = cr_cash + cr_transfer + cr_clearing;
                        trialSheet.DR_Cash = dr_cash;
                        trialSheet.DR_Transfer = dr_transfer;
                        trialSheet.DR_Clearing = dr_clearing;
                        trialSheet.DR_Total = dr_cash + dr_transfer + dr_clearing;
                        if (this.IsCBMACode)
                            trialSheet.AccountCode = cBMAcode;
                        else
                            trialSheet.AccountCode = aCode;

                        trialSheet.AccountHead = aHead;

                        this.trialSheetData.Add(trialSheet);
                        cr_GTotal += cr_cash + cr_transfer + cr_clearing;
                        dr_GTotal += dr_cash + dr_transfer + dr_clearing;
                        #endregion

                        cr_cash = cr_transfer = cr_clearing = dr_cash = dr_transfer = dr_clearing = 0;

                        #region Collect Data
                        if (rawData[i].Status[1] == 'C')    //Credit
                        {
                            switch (rawData[i].Status[0])
                            {
                                case 'C': cr_cash += rawData[i].Amount.Value; break;
                                case 'T': cr_transfer += rawData[i].Amount.Value; break;
                                case 'L': cr_clearing += rawData[i].Amount.Value; break;
                            }
                        }
                        else    //Debit
                        {
                            switch (rawData[i].Status[0])
                            {
                                case 'C': dr_cash += rawData[i].Amount.Value; break;
                                case 'T': dr_transfer += rawData[i].Amount.Value; break;
                                case 'L': dr_clearing += rawData[i].Amount.Value; break;
                            }
                        }
                        aCode = rawData[i].ACode;
                        cBMAcode = rawData[i].CBMACode;
                        aHead = rawData[i].ACName;
                        #endregion
                    }
                }
            }

            #region Add Last TrialSheet Data
            MNMDTO00038 lastTrialSheet = new MNMDTO00038();
            lastTrialSheet.CR_Cash = cr_cash;
            lastTrialSheet.CR_Transfer = cr_transfer;
            lastTrialSheet.CR_Clearing = cr_clearing;
            lastTrialSheet.CR_Total = cr_cash + cr_transfer + cr_clearing;
            lastTrialSheet.DR_Cash = dr_cash;
            lastTrialSheet.DR_Transfer = dr_transfer;
            lastTrialSheet.DR_Clearing = dr_clearing;
            lastTrialSheet.DR_Total = dr_cash + dr_transfer + dr_clearing;
            if (this.IsCBMACode)
                lastTrialSheet.AccountCode = cBMAcode;
            else
                lastTrialSheet.AccountCode = aCode;

            lastTrialSheet.AccountHead = aHead;

            this.trialSheetData.Add(lastTrialSheet);
            cr_GTotal += cr_cash + cr_transfer + cr_clearing;
            dr_GTotal += dr_cash + dr_transfer + dr_clearing;
            #endregion

            para[8] = new ReportParameter("OpeningBalance", openingBal.ToString());
            para[9] = new ReportParameter("Receive", (openingBal + cr_GTotal).ToString());
            para[10] = new ReportParameter("Payment", dr_GTotal.ToString());
            para[11] = new ReportParameter("ClosingBalance", ((openingBal + cr_GTotal) - dr_GTotal).ToString());

            this.rpvTriBalanceDetail.LocalReport.EnableExternalImages = true;
            rpvTriBalanceDetail.LocalReport.SetParameters(para);
            ReportDataSource dataset = new ReportDataSource("MNMDS00013", this.trialSheetData);
            rpvTriBalanceDetail.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.trialSheetData;


            this.rpvTriBalanceDetail.RefreshReport();
            this.rpvTriBalanceDetail.RefreshReport();
        }

        #endregion 
    }
}
