//----------------------------------------------------------------------
// <copyright file="LOMSVE00015" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>ASDA</CreatedUser>
// <CreatedDate>14.01.2015</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Tel.Dmd;
using System.Windows.Forms;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Loan.Dmd.DTO; // Added by AAM (15-Jan-2018)
using Ace.Cbs.Cx.Com.Ctr;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00024 : AbstractPresenter, ILOMCTL00024
    {
        #region "Wire To"

        public bool isScharge { get; set; }
        private ILOMVEW00024 loanVoucherView;
        public ILOMVEW00024 LoanVoucherView
        {
            get { return this.loanVoucherView; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00024 view)
        {
            if (this.loanVoucherView == null)
            {
                this.loanVoucherView = view;
                this.Initialize(this.loanVoucherView, this.GetEntity());
            }
        }

        private TLMDTO00018 GetEntity()
        {
            TLMDTO00018 LoanEntity = new TLMDTO00018();
            LoanEntity.Lno = this.loanVoucherView.LoanNo;
            return LoanEntity;
        }

        #endregion

        #region Properties
        private CXDMD00010 permissionEntity;
        public CXDMD00010 PermissionEntity
        {
            get 
            {
                if (permissionEntity == null)
                    permissionEntity = new CXDMD00010();
                return permissionEntity;
            }
            set
            {
                permissionEntity = value;
            }
        }

        #region Properties Added By AAM (15-Jan-2018)
        public List<LOMDTO00236> lstBLLimitVou1;
        public List<LOMDTO00236> lstBLLimitVou2;
        public List<LOMDTO00236> lstBLLimitVou3;

        public List<LOMDTO00236> lst_Debit_BLLimitVou;
        public List<LOMDTO00236> lst_Credit_BLLimitVou;

        public List<LOMDTO00236> lst_BL_LimitVouPrint;
        public List<LOMDTO00236> lsts_businessLoans_Limit_Vou_Print;

        public static string eno;
        public string debitAcctNo;
        public string creditAcctNo;
        public string brCode;
        public string acType;
        public string serialNo;
        public string debitAcctDespDomestic;
        public string creditAcctDespDomestic;
        public int index;
        public string desp;
        //public string plVoucher1_Narration;
        //public string plVoucher2_Narration;
        //public string plVoucher3_Narration;

        #endregion

        #endregion

        #region validation

        public void txtLoanNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if xml base error does not exist.
            if (e.HasXmlBaseError == false)
            {
                try
                {
                    string lno = this.LoanVoucherView.LoanNo;
                    if (String.IsNullOrEmpty(lno))
                    {
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90055);   //Invalid Loan No. !
                        this.SetFocus("txtLoanNo");
                        return;
                    }
                    if (lno.Substring(0, 1).ToUpper() != "L")
                    {
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90199);   //Invalid Entry No for Business Loans!
                        this.SetFocus("txtLoanNo");
                        return;
                    }

                    IList<PFMDTO00072> LoanDTO = CXClientWrapper.Instance.Invoke<ILOMSVE00024, IList<PFMDTO00072>>(x => x.SelectLoanInfoByloanNoandSourcebr(lno, CurrentUserEntity.BranchCode));

                    if (LoanDTO.Count == 0 || CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        this.SetFocus("txtLoanNo");
                        return;
                    }
                    else
                    {
                        this.loanVoucherView.Currency = LoanDTO[0].CurrencyCode;
                        this.loanVoucherView.SanctionAmount = LoanDTO[0].CreditAmount1;
                        this.isScharge = LoanDTO[0].Active; //For Service Charges For loan Type
                        this.loanVoucherView.BindAccountInfo(LoanDTO);
                    }
                }
                catch (Exception ex)
                {
                    this.SetCustomErrorMessage(this.GetControl("txtLoanNo"), "MV90055"); //Invalid Entry No.
                }
            }
            else
            { return; }
        }


        #endregion

        #region Method
        
        public void Save(TLMDTO00018 loanDto, IList<PFMDTO00072> acctnoInfoList, string sourceBr)
        {
            try
            {
                if (this.ValidateForm(this.GetEntity()))
                {
                    PFMDTO00009 ratedto = new PFMDTO00009();
                    string channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
                    acctnoInfoList[0].CreditDescription2 = channel;
                    loanDto.isScharge = this.isScharge;
                    ratedto = CXCLE00002.Instance.GetScalarObject<PFMDTO00009>("PFMORM00009.Client.SelectByCodeAndLastModify", new object[] { "LOANSCHARGERATE", true, true }); //hm
                    loanDto.serviceChargesRate = ratedto.Rate;
                    TLMDTO00018 LoanDTO = CXClientWrapper.Instance.Invoke<ILOMSVE00024, TLMDTO00018>(x => x.SelectLoanByloanNoandSourcebr(loanDto.Lno, CurrentUserEntity.BranchCode));
                    string AccountNo = null;
                   // if (LoanDTO.BType == "001")
                    //{
                        // AccountNo = CXCLE00002.Instance.GetScalarObject<string>("COASetup.Client.Select", new object[] { "BL_SME_SCHARGENEW", loanDto.Currency, sourceBr, true });
                    //}
                    //if (LoanDTO.BType == "002")
                    //{
                      //  AccountNo = CXCLE00002.Instance.GetScalarObject<string>("COASetup.Client.Select", new object[] { "BL_PLBUSINESS_SCHARGENEW", loanDto.Currency, sourceBr, true });
                    //}
                    AccountNo = CXCLE00002.Instance.GetScalarObject<string>("COASetup.Client.Select", new object[] { "SCHARGENEW", loanDto.Currency, sourceBr, true });
                    string description = CXCLE00002.Instance.GetScalarObject<string>("COA.Client.SelectACName", new object[] { AccountNo, sourceBr, true });

                    if (CXUIScreenTransit.Transit("frmCXCLE00016", true, new object[] { "frmLOMVEW00024", CXDMD00006.Other, PermissionEntity, false }) == DialogResult.OK)
                    {
                        string voucherNo = string.Empty;
                        this.PermissionEntity = CXUIScreenTransit.GetData<CXDMD00010>("frmLOMVEW00024");
                        voucherNo = CXClientWrapper.Instance.Invoke<ILOMSVE00024, string>(x => x.LoanVoucher(loanDto, acctnoInfoList, sourceBr, AccountNo, description, this.loanVoucherView.isSCharge));

                        if (string.IsNullOrEmpty(voucherNo) || CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                        {
                            throw new Exception();
                        }
                        else
                        {
                            this.loanVoucherView.Successful("MI00051", voucherNo);      //Saving Successful.\n Generated {0} is {1}.

                            #region Added By AAM (15-Jan-2018)
                            // Added By AAM (15-Jan-2018)
                            string rptName = "BL_Reg_Vou_Print_Lists";
                            IList<LOMDTO00236> lst_BL_LimitVouPrint = CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00236>>(x => x.Get_BL_LimitVou_Lists(voucherNo));
                            this.BL_Reg_Vou_Printing(rptName, lst_BL_LimitVouPrint, voucherNo);
                            
                            #endregion 

                            this.loanVoucherView.ClearControls();
                        }
                    }
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode("MV90055"); //Invalid Loan No.
                    this.SetFocus("txtLoanNo");
                }
            }
            catch (Exception ex)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }


        #region Two Method For Limit Voucher Printing Added By AAM (15-Jan-2018)
        
        public void Call_BL_Limits_Voucher_Printing(string rptName, IList<LOMDTO00236> lst_BL_LimitVouPrint)
        {
            CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { "frmLOMVEW00024", lst_BL_LimitVouPrint, rptName });
        }

        public void BL_Reg_Vou_Printing(string rptName, IList<LOMDTO00236> lst_BL_LimitVouPrint, string voucherNo)
        {
            if (CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC00016) == DialogResult.Yes)
            {
                lstBLLimitVou1 = lst_BL_LimitVouPrint.Where(a => a.Narration.Contains("LoansVou")).ToList();
                lstBLLimitVou2 = lst_BL_LimitVouPrint.Where(a => a.Narration.Contains("Documentation Fee")).ToList();
                lstBLLimitVou3 = lst_BL_LimitVouPrint.Where(a => a.Narration.Contains("Service Cha")).ToList();

                lsts_businessLoans_Limit_Vou_Print = new List<LOMDTO00236>();// For RDLC Display

                #region LoansVou
                for (int i = 0; i < lstBLLimitVou1.Count - 1; i++)
                {
                    lst_Debit_BLLimitVou = lstBLLimitVou1.Where(a => a.Status == "TDV").ToList();
                    lst_Credit_BLLimitVou = lstBLLimitVou1.Where(a => a.Status == "TCV").ToList();

                    LOMDTO00236 transferVouPrint = new LOMDTO00236(); // For RDLC Display

                    if (lst_Debit_BLLimitVou[i].AcctNo.Length == 6)
                    {
                        debitAcctNo = lstBLLimitVou1[i].AcctNo;
                        index = debitAcctNo.IndexOf("0");
                        acType = debitAcctNo.Substring(0, index);
                        serialNo = debitAcctNo.Substring(index, debitAcctNo.Length - index);
                        desp = lst_Debit_BLLimitVou[i].HeadACName + "-" + lst_Debit_BLLimitVou[i].Desp + "(" + acType + "-" + serialNo + ")";
                    }

                    else //if (lst_Debit_BLLimitVou[i].AcctNo.Length == 15 && lst_Debit_BLLimitVou[i].AcctNo.Substring(4, 1) == "1")
                    {
                        debitAcctNo = lst_Debit_BLLimitVou[i].AcctNo;
                        brCode = debitAcctNo.Substring(0, 3);
                        acType = debitAcctNo.Substring(3, 3);
                        serialNo = debitAcctNo.Substring(6, 9);
                        debitAcctNo = brCode + " - " + acType + "-" + serialNo;
                        desp = "Customer A/C - ( " + debitAcctNo + " ) " + " " + lst_Debit_BLLimitVou[i].Desp;
                    }

                    transferVouPrint.Eno = lst_Debit_BLLimitVou[i].Eno;
                    transferVouPrint.DebitAcctDesp = desp;
                    transferVouPrint.DebitAcctAmount = lst_Debit_BLLimitVou[i].Amount;
                    transferVouPrint.DebitAcctNo = lst_Debit_BLLimitVou[i].AcctNo;
                    transferVouPrint.DrNarration = lst_Debit_BLLimitVou[i].Desp;

                    /////////////For Credit Transactions////////////////

                    if (lst_Credit_BLLimitVou[i].AcctNo.Length == 6)
                    {
                        creditAcctNo = lst_Credit_BLLimitVou[i].AcctNo;
                        index = creditAcctNo.IndexOf("0");
                        acType = creditAcctNo.Substring(0, index);
                        serialNo = creditAcctNo.Substring(index, creditAcctNo.Length - index);
                        desp = lst_Credit_BLLimitVou[i].HeadACName + "-" + lst_Credit_BLLimitVou[i].Desp + "(" + acType + "-" + serialNo + ")";
                    }

                    else 
                    {
                        creditAcctNo = lst_Credit_BLLimitVou[i].AcctNo;
                        brCode = creditAcctNo.Substring(0, 3);
                        acType = creditAcctNo.Substring(3, 3);
                        serialNo = creditAcctNo.Substring(6, 9);
                        creditAcctNo = brCode + " - " + acType + "-" + serialNo;
                        desp = "Customer A/C - ( " + creditAcctNo + " ) " + " " + lst_Credit_BLLimitVou[i].Desp;
                    }

                    transferVouPrint.Eno = lst_Credit_BLLimitVou[i].Eno;
                    transferVouPrint.CreditAcctDesp = desp;
                    transferVouPrint.CreditAcctAmount = lst_Credit_BLLimitVou[i].Amount;
                    transferVouPrint.CreditAcctNo = lst_Credit_BLLimitVou[i].AcctNo;
                    transferVouPrint.CrNarration = lst_Debit_BLLimitVou[i].Desp;

                    transferVouPrint.AmountInWords = this.AmountToWords(lst_Credit_BLLimitVou[i].Amount.ToString());
                    lsts_businessLoans_Limit_Vou_Print.Add(transferVouPrint);

                } // End of For Looping
                #endregion

                #region Documentation Charges
                for (int i = 0; i < lstBLLimitVou2.Count - 1; i++)
                {
                    lst_Debit_BLLimitVou = lstBLLimitVou2.Where(a => a.Status == "TDV").ToList();
                    lst_Credit_BLLimitVou = lstBLLimitVou2.Where(a => a.Status == "TCV").ToList();

                    LOMDTO00236 transferVouPrint = new LOMDTO00236(); // For RDLC Display

                    if (lst_Debit_BLLimitVou[i].AcctNo.Length == 6)
                    {
                        debitAcctNo = lstBLLimitVou2[i].AcctNo;
                        index = debitAcctNo.IndexOf("0");
                        acType = debitAcctNo.Substring(0, index);
                        serialNo = debitAcctNo.Substring(index, debitAcctNo.Length - index);
                        desp = lst_Debit_BLLimitVou[i].HeadACName + "-" + lst_Debit_BLLimitVou[i].Desp + "(" + acType + "-" + serialNo + ")";
                    }

                    else 
                    {
                        debitAcctNo = lst_Debit_BLLimitVou[i].AcctNo;
                        brCode = debitAcctNo.Substring(0, 3);
                        acType = debitAcctNo.Substring(3, 3);
                        serialNo = debitAcctNo.Substring(6, 9);
                        debitAcctNo = brCode + " - " + acType + "-" + serialNo;
                        desp = "Customer A/C - ( " + debitAcctNo + " ) " + " " + lst_Debit_BLLimitVou[i].Desp;
                    }

                    transferVouPrint.Eno = lst_Debit_BLLimitVou[i].Eno;
                    transferVouPrint.DebitAcctDesp = desp;
                    transferVouPrint.DebitAcctAmount = lst_Debit_BLLimitVou[i].Amount;
                    transferVouPrint.DebitAcctNo = lst_Debit_BLLimitVou[i].AcctNo;
                    transferVouPrint.DrNarration = lst_Credit_BLLimitVou[i].Desp; //"Documentation Fees";

                    ////////////For Credit Transaction/////////////////

                    if (lst_Credit_BLLimitVou[i].AcctNo.Length == 6)
                    {
                        creditAcctNo = lst_Credit_BLLimitVou[i].AcctNo;
                        index = creditAcctNo.IndexOf("0");
                        acType = creditAcctNo.Substring(0, index);
                        serialNo = creditAcctNo.Substring(index, creditAcctNo.Length - index);
                        desp = lst_Credit_BLLimitVou[i].HeadACName + "-" + lst_Credit_BLLimitVou[i].Desp + "(" + acType + "-" + serialNo + ")";
                    }

                    else 
                    {
                        creditAcctNo = lst_Credit_BLLimitVou[i].AcctNo;
                        brCode = creditAcctNo.Substring(0, 3);
                        acType = creditAcctNo.Substring(3, 3);
                        serialNo = creditAcctNo.Substring(6, 9);
                        creditAcctNo = brCode + " - " + acType + "-" + serialNo;
                        desp = "Customer A/C - ( " + creditAcctNo + " ) " + " " + lst_Credit_BLLimitVou[i].Desp;
                    }

                    transferVouPrint.Eno = lst_Credit_BLLimitVou[i].Eno;
                    transferVouPrint.CreditAcctDesp = desp;
                    transferVouPrint.CreditAcctAmount = lst_Credit_BLLimitVou[i].Amount;
                    transferVouPrint.CreditAcctNo = lst_Credit_BLLimitVou[i].AcctNo;
                    transferVouPrint.CrNarration = lst_Credit_BLLimitVou[i].Desp; //"Documentation Fees";

                    transferVouPrint.AmountInWords = this.AmountToWords(lst_Credit_BLLimitVou[i].Amount.ToString());
                    lsts_businessLoans_Limit_Vou_Print.Add(transferVouPrint);

                } // End of For Looping
                #endregion

                #region Service Charges
                for (int i = 0; i < lstBLLimitVou3.Count - 1; i++)
                {
                    lst_Debit_BLLimitVou = lstBLLimitVou3.Where(a => a.Status == "TDV").ToList();
                    lst_Credit_BLLimitVou = lstBLLimitVou3.Where(a => a.Status == "TCV").ToList();

                    LOMDTO00236 transferVouPrint = new LOMDTO00236(); // For RDLC Display

                    if (lst_Debit_BLLimitVou[i].AcctNo.Length == 6)
                    {
                        debitAcctNo = lstBLLimitVou3[i].AcctNo;
                        index = debitAcctNo.IndexOf("0");
                        acType = debitAcctNo.Substring(0, index);
                        serialNo = debitAcctNo.Substring(index, debitAcctNo.Length - index);
                        desp = lst_Debit_BLLimitVou[i].HeadACName + "-" + lst_Debit_BLLimitVou[i].Desp + "(" + acType + "-" + serialNo + ")";
                    }

                    else 
                    {
                        debitAcctNo = lst_Debit_BLLimitVou[i].AcctNo;
                        brCode = debitAcctNo.Substring(0, 3);
                        acType = debitAcctNo.Substring(3, 3);
                        serialNo = debitAcctNo.Substring(6, 9);
                        debitAcctNo = brCode + " - " + acType + "-" + serialNo;
                        desp = "Customer A/C - ( " + debitAcctNo + " ) " + " " + lst_Debit_BLLimitVou[i].Desp;
                    }

                    transferVouPrint.Eno = lst_Debit_BLLimitVou[i].Eno;
                    transferVouPrint.DebitAcctDesp = desp;
                    transferVouPrint.DebitAcctAmount = lst_Debit_BLLimitVou[i].Amount;
                    transferVouPrint.DebitAcctNo = lst_Debit_BLLimitVou[i].AcctNo;
                    transferVouPrint.DrNarration = lst_Credit_BLLimitVou[i].Desp; //"Service Charges";

                    /////////////For Credit Transaction///////////////

                    if (lst_Credit_BLLimitVou[i].AcctNo.Length == 6)
                    {
                        creditAcctNo = lst_Credit_BLLimitVou[i].AcctNo;
                        index = creditAcctNo.IndexOf("0");
                        acType = creditAcctNo.Substring(0, index);
                        serialNo = creditAcctNo.Substring(index, creditAcctNo.Length - index);
                        desp = lst_Credit_BLLimitVou[i].HeadACName + "-" + lst_Credit_BLLimitVou[i].Desp + "(" + acType + "-" + serialNo + ")";
                    }

                    else 
                    {
                        creditAcctNo = lst_Credit_BLLimitVou[i].AcctNo;
                        brCode = creditAcctNo.Substring(0, 3);
                        acType = creditAcctNo.Substring(3, 3);
                        serialNo = creditAcctNo.Substring(6, 9);
                        creditAcctNo = brCode + " - " + acType + "-" + serialNo;
                        desp = "Customer A/C - ( " + creditAcctNo + " ) " + " " + lst_Credit_BLLimitVou[i].Desp;
                    }

                    transferVouPrint.Eno = lst_Credit_BLLimitVou[i].Eno;
                    transferVouPrint.CreditAcctDesp = desp;
                    transferVouPrint.CreditAcctAmount = lst_Credit_BLLimitVou[i].Amount;
                    transferVouPrint.CreditAcctNo = lst_Credit_BLLimitVou[i].AcctNo;
                    transferVouPrint.CrNarration = lst_Credit_BLLimitVou[i].Desp; //"Service Charges";
                    //}

                    transferVouPrint.AmountInWords = this.AmountToWords(lst_Credit_BLLimitVou[i].Amount.ToString());
                    lsts_businessLoans_Limit_Vou_Print.Add(transferVouPrint);

                } // End of For Looping
                #endregion

                this.Call_BL_Limits_Voucher_Printing(rptName, lsts_businessLoans_Limit_Vou_Print);
            }
        }
        
        #endregion

        #region AmountInWords Added By AAM (15-Jan-2018)
        
        public string ReportAmountInword;

        //To Convert Number From Amount Textbox to Words
        private string AmountToWords(string inputStr)
        {
            string point = string.Empty;
            string firstamount = string.Empty;
            string[] answers = inputStr.Split(new string[] { ".", " " }, StringSplitOptions.RemoveEmptyEntries);

            if (answers.Length > 1)
            {
                firstamount = this.NumberToWords(Convert.ToInt64(answers[0]));
                if ((Convert.ToInt32(answers[1])) > 0)
                {
                    point = this.NumberToWords(Convert.ToInt64(answers[1]));
                }
            }
            else
            {
                firstamount = this.NumberToWords(Convert.ToInt64(answers[0]));
            }


            this.ReportAmountInword = "Kyats " + firstamount + " ";
            if (string.IsNullOrEmpty(point))
            {
                this.ReportAmountInword += " Only.";
            }
            else
            {
                this.ReportAmountInword += " " + point + " " + "Pyar Only.";
            }

            return ReportAmountInword;
        }

        //To Conver Number to Letter
        private string NumberToWords(Int64 number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";
            if ((number / 100000000) > 0)
            {
                if ((number / 10000000) > 0)
                {
                    if ((number / 1000000) > 0)
                    {
                        words += " " + NumberToWords(number / 1000000) + " Million";
                        number %= 1000000;
                    }
                    else
                    {
                        words += " " + NumberToWords(number / 10000000) + " Billion";
                        number %= 10000000;
                    }
                }
                else
                {
                    words += " " + NumberToWords(number / 100000000) + " Trillion";
                    number %= 100000000;
                }
            }
            if ((number / 10000000) > 0)
            {
                if ((number / 1000000) > 0)
                {
                    words += " " + NumberToWords(number / 1000000) + " Million";
                    number %= 1000000;
                }
                else
                {
                    words += " " + NumberToWords(number / 10000000) + " Billion";
                    number %= 10000000;
                }
            }

            if ((number / 1000000) > 0)
            {
                words += " " + NumberToWords(number / 1000000) + " Million";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += " " + NumberToWords(number / 1000) + " Thousand";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += " " + NumberToWords(number / 100) + " Hundred";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += " " + " and ";

                var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                var tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

                if (number < 20)
                    words += " " + unitsMap[number];
                else
                {
                    words += " " + tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += " " + "-" + unitsMap[number % 10];
                }
            }

            return words;
        }

        private string CashInZawGyiFont(decimal amount)
        {
            //int stringCount = (amount.ToString().Length);
            string keyword = string.Empty;
            //for (int i = 0; i < stringCount; i++)
            //{
            //    keyword += (amount.ToString()).;
            //}
            //return keyword;

            char[] keys = (amount.ToString()).ToCharArray();
            foreach (char item in keys)
            {
                keyword += GetZawGyiFont(item);
            }
            return keyword;
        }

        private string GetZawGyiFont(char key)
        {
            switch (key)
            {
                case '1':
                    return "၁";
                case '2':
                    return "၂";
                case '3':
                    return "၃";
                case '4':
                    return "၄";
                case '5':
                    return "၅";
                case '6':
                    return "၆";
                case '7':
                    return "၇";
                case '8':
                    return "၈";
                case '9':
                    return "၉";
                default:
                    return "၀";
            }
        }
        #endregion


        //Added by YMP at 30-07-2019 : [Seperating EOD Process] To show system date (not PC date) at report
        public DateTime GetSystemDate(string sourceBr)
        {
            TCMDTO00001 systemStartInfo = CXClientWrapper.Instance.Invoke<ICXSVE00006, TCMDTO00001>(x => x.SelectStartBySourceBr(sourceBr));
            DateTime systemDate = systemStartInfo.Date;
            return systemDate;
        }

        //Added by HMW at 26-08-2019 : [Seperating EOD Process] Check Settlement Date to show form
        public DateTime GetLastSettlementDate(string sourceBr)
        {
            DateTime lastSettlementDate = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.LastSettlementDate), sourceBr);
            return lastSettlementDate;
        }

        #endregion

    }
}
