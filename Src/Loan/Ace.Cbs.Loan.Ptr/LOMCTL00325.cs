using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Dmd.DTO; // Uncommented by AAM (15-Jan-2018)
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Dmd;
using System.Windows.Forms;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Cx.Com.Ctr;

namespace Ace.Cbs.Loan.Ptr
{
    //Added by HWKO (28-Jul-2017)
    public class LOMCTL00325 : AbstractPresenter, ILOMCTL00325
    {
        #region Constructor
        public LOMCTL00325()
        { }
        #endregion

        #region Properties
        private ILOMVEW00325 view;
        public ILOMVEW00325 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00325 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetEntity());
            }
        }

        private LOMDTO00311 GetEntity()
        {
            LOMDTO00311 entity = new LOMDTO00311();
            entity.PLNo = this.view.LoanNo;
            return entity;
        }

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
        public List<LOMDTO00235> lstPLLimitVou1;
        public List<LOMDTO00235> lstPLLimitVou2;
        public List<LOMDTO00235> lstPLLimitVou3;

        public List<LOMDTO00235> lst_Debit_PLLimitVou;
        public List<LOMDTO00235> lst_Credit_PLLimitVou;

        public List<LOMDTO00235> lst_PL_LimitVouPrint;
        public List<LOMDTO00235> lsts_personalLoans_Limit_Vou_Print;

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
        public string plVoucher1_Narration;
        public string plVoucher2_Narration;
        public string plVoucher3_Narration;
        #endregion

        #endregion

        #region Control Validations
        public void txtLoanNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if xml base error does not exist.
            if (e.HasXmlBaseError == false)
            {
                try
                {
                    string plno = this.View.LoanNo;
                    if (String.IsNullOrEmpty(plno))
                    {
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90055);   //Invalid Loan No. !
                        this.SetFocus("txtLoanNo");
                        return;
                    }

                    if (plno.Substring(0, 2).ToUpper() != "PL")
                    {
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90200);   //Invalid Entry No for Personal Loans!
                        this.SetFocus("txtLoanNo");
                        return;
                    }

                    IList<PFMDTO00072> PLVoucherDTO = CXClientWrapper.Instance.Invoke<ILOMSVE00325, IList<PFMDTO00072>>(x => x.SelectPersonalLoanInfoByloanNoandSourcebr(plno, CurrentUserEntity.BranchCode));

                    if (PLVoucherDTO.Count == 0 || CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        this.SetFocus("txtLoanNo");
                        return;
                    }
                    else
                    {
                        this.View.BindPLVoucherInfo(PLVoucherDTO);
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

        #region Methods

        public void BindPersonalLoanVoucherInfor(string plno)
        {
            try
            {
                //string plno = this.view.LoanNo;
                if (String.IsNullOrEmpty(plno))
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90055);   //Invalid Loan No. !
                    this.SetFocus("txtLoanNo");
                }

                IList<PFMDTO00072> PLVoucherDTO = CXClientWrapper.Instance.Invoke<ILOMSVE00325, IList<PFMDTO00072>>(x => x.SelectPersonalLoanInfoByloanNoandSourcebr(plno, CurrentUserEntity.BranchCode));

                if (PLVoucherDTO.Count == 0 || CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    this.SetFocus("txtLoanNo");
                    return;
                }
                else
                {
                    this.View.BindPLVoucherInfo(PLVoucherDTO);
                }
            }
            catch (Exception ex)
            {
                this.SetCustomErrorMessage(this.GetControl("txtLoanNo"), "MV90055"); //Invalid Entry No.
            }
        }

        public void Save(string plno, string sourcebr)
        {
            try
            {
                if (this.GetEntity() != null)
                {
                    if (CXUIScreenTransit.Transit("frmCXCLE00016", true, new object[] { "frmLOMVEW00325", CXDMD00006.Other, PermissionEntity, false }) == DialogResult.OK)
                    {
                        string voucherNo = string.Empty;
                        this.PermissionEntity = CXUIScreenTransit.GetData<CXDMD00010>("frmLOMVEW00325");
                        voucherNo = CXClientWrapper.Instance.Invoke<ILOMSVE00325, string>(x => x.Save_PersonalLoansVoucher(plno, sourcebr));

                        if (string.IsNullOrEmpty(voucherNo) || CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                        {
                            throw new Exception();
                        }
                        else
                        {
                            this.view.Successful("MI00051", voucherNo);      //Saving Successful.\n Generated {0} is {1}.

                            #region Added By AAM (15-Jan-2018)
                            // Added By AAM (15-Jan-2018)
                            string rptName = "PL_Reg_Vou_Print_Lists";
                            IList<LOMDTO00235> lst_PL_LimitVouPrint = CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00235>>(x => x.Get_PL_LimitVou_Lists(voucherNo));
                            this.PL_Reg_Vou_Printing(rptName, lst_PL_LimitVouPrint, voucherNo);
                            #endregion

                            this.view.ClearControls();
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
        public void Call_PL_Limits_Voucher_Printing(string rptName, IList<LOMDTO00235> lst_PL_LimitVouPrint)
        {
            CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { "frmLOMVEW00325", lst_PL_LimitVouPrint, rptName });
        }

        // Added By AAM (15-Jan-2018)
        public void PL_Reg_Vou_Printing(string rptName, IList<LOMDTO00235> lst_PL_LimitVouPrint, string voucherNo)
        {
            if (CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC00016) == DialogResult.Yes)
            {
                lstPLLimitVou1 = lst_PL_LimitVouPrint.Where(a => a.Narration.Contains("PL Reg Voucher")).ToList();
                lstPLLimitVou2 = lst_PL_LimitVouPrint.Where(a => a.Narration.Contains("Documentation Charges")).ToList();
                lstPLLimitVou3 = lst_PL_LimitVouPrint.Where(a => a.Narration.Contains("Service Charges")).ToList();

                lsts_personalLoans_Limit_Vou_Print = new List<LOMDTO00235>();// For RDLC Display

                #region PL Reg Voucher
                for (int i = 0; i < lstPLLimitVou1.Count - 1; i++)
                {
                    lst_Debit_PLLimitVou = lstPLLimitVou1.Where(a => a.Status == "TDV").ToList();
                    lst_Credit_PLLimitVou = lstPLLimitVou1.Where(a => a.Status == "TCV").ToList();

                    LOMDTO00235 transferVouPrint = new LOMDTO00235(); // For RDLC Display

                    if (lst_Debit_PLLimitVou[i].AcctNo.Length == 6)
                    {
                        debitAcctNo = lstPLLimitVou1[i].AcctNo;
                        index = debitAcctNo.IndexOf("0");
                        acType = debitAcctNo.Substring(0, index);
                        serialNo = debitAcctNo.Substring(index, debitAcctNo.Length - index);
                        desp = lst_Debit_PLLimitVou[i].HeadACName + "-" + lst_Debit_PLLimitVou[i].Desp + "(" + acType + "-" + serialNo + ")";
                    }

                    else
                    {
                        debitAcctNo = lst_Debit_PLLimitVou[i].AcctNo;
                        brCode = debitAcctNo.Substring(0, 3);
                        acType = debitAcctNo.Substring(3, 3);
                        serialNo = debitAcctNo.Substring(6, 9);
                        debitAcctNo = brCode + " - " + acType + "-" + serialNo;
                        desp = "Customer A/C - ( " + debitAcctNo + " ) " + " " + lst_Debit_PLLimitVou[i].Desp;
                    }

                    transferVouPrint.Eno = lst_Debit_PLLimitVou[i].Eno;
                    transferVouPrint.DebitAcctDesp = desp;
                    transferVouPrint.DebitAcctAmount = lst_Debit_PLLimitVou[i].Amount;
                    transferVouPrint.DebitAcctNo = lst_Debit_PLLimitVou[i].AcctNo;
                    transferVouPrint.DrNarration = lst_Debit_PLLimitVou[i].Desp;

                    //////////////For Credit Transactions////////////////

                    if (lst_Credit_PLLimitVou[i].AcctNo.Length == 6)
                    {
                        creditAcctNo = lst_Credit_PLLimitVou[i].AcctNo;
                        index = creditAcctNo.IndexOf("0");
                        acType = creditAcctNo.Substring(0, index);
                        serialNo = creditAcctNo.Substring(index, creditAcctNo.Length - index);
                        desp = lst_Credit_PLLimitVou[i].HeadACName + "-" + lst_Credit_PLLimitVou[i].Desp + "(" + acType + "-" + serialNo + ")";
                    }

                    else
                    {
                        creditAcctNo = lst_Credit_PLLimitVou[i].AcctNo;
                        brCode = creditAcctNo.Substring(0, 3);
                        acType = creditAcctNo.Substring(3, 3);
                        serialNo = creditAcctNo.Substring(6, 9);
                        creditAcctNo = brCode + " - " + acType + "-" + serialNo;
                        desp = "Customer A/C - ( " + creditAcctNo + " ) " + " " + lst_Credit_PLLimitVou[i].Desp;
                    }

                    transferVouPrint.Eno = lst_Credit_PLLimitVou[i].Eno;
                    transferVouPrint.CreditAcctDesp = desp;
                    transferVouPrint.CreditAcctAmount = lst_Credit_PLLimitVou[i].Amount;
                    transferVouPrint.CreditAcctNo = lst_Credit_PLLimitVou[i].AcctNo;
                    transferVouPrint.CrNarration = lst_Debit_PLLimitVou[i].Desp;

                    transferVouPrint.AmountInWords = this.AmountToWords(lst_Credit_PLLimitVou[i].Amount.ToString());
                    lsts_personalLoans_Limit_Vou_Print.Add(transferVouPrint);

                } // End of For Looping
                #endregion

                #region Documentation Charges
                for (int i = 0; i < lstPLLimitVou2.Count - 1; i++)
                {
                    lst_Debit_PLLimitVou = lstPLLimitVou2.Where(a => a.Status == "TDV").ToList();
                    lst_Credit_PLLimitVou = lstPLLimitVou2.Where(a => a.Status == "TCV").ToList();

                    LOMDTO00235 transferVouPrint = new LOMDTO00235(); // For RDLC Display

                    if (lst_Debit_PLLimitVou[i].AcctNo.Length == 6)
                    {
                        debitAcctNo = lstPLLimitVou2[i].AcctNo;
                        index = debitAcctNo.IndexOf("0");
                        acType = debitAcctNo.Substring(0, index);
                        serialNo = debitAcctNo.Substring(index, debitAcctNo.Length - index);
                        desp = lst_Debit_PLLimitVou[i].HeadACName + "-" + lst_Debit_PLLimitVou[i].Desp + "(" + acType + "-" + serialNo + ")";
                    }

                    else
                    {
                        debitAcctNo = lst_Debit_PLLimitVou[i].AcctNo;
                        brCode = debitAcctNo.Substring(0, 3);
                        acType = debitAcctNo.Substring(3, 3);
                        serialNo = debitAcctNo.Substring(6, 9);
                        debitAcctNo = brCode + " - " + acType + "-" + serialNo;
                        desp = "Customer A/C - ( " + debitAcctNo + " ) " + " " + lst_Debit_PLLimitVou[i].Desp;
                    }

                    transferVouPrint.Eno = lst_Debit_PLLimitVou[i].Eno;
                    transferVouPrint.DebitAcctDesp = desp;
                    transferVouPrint.DebitAcctAmount = lst_Debit_PLLimitVou[i].Amount;
                    transferVouPrint.DebitAcctNo = lst_Debit_PLLimitVou[i].AcctNo;
                    transferVouPrint.DrNarration = lst_Credit_PLLimitVou[i].Desp; //"Documentation Fees";

                    //////////////For Credit Transactions///////////////

                    if (lst_Credit_PLLimitVou[i].AcctNo.Length == 6)
                    {
                        creditAcctNo = lst_Credit_PLLimitVou[i].AcctNo;
                        index = creditAcctNo.IndexOf("0");
                        acType = creditAcctNo.Substring(0, index);
                        serialNo = creditAcctNo.Substring(index, creditAcctNo.Length - index);
                        desp = lst_Credit_PLLimitVou[i].HeadACName + "-" + lst_Credit_PLLimitVou[i].Desp + "(" + acType + "-" + serialNo + ")";
                    }

                    else
                    {
                        creditAcctNo = lst_Credit_PLLimitVou[i].AcctNo;
                        brCode = creditAcctNo.Substring(0, 3);
                        acType = creditAcctNo.Substring(3, 3);
                        serialNo = creditAcctNo.Substring(6, 9);
                        creditAcctNo = brCode + " - " + acType + "-" + serialNo;
                        desp = "Customer A/C - ( " + creditAcctNo + " ) " + " " + lst_Credit_PLLimitVou[i].Desp;
                    }

                    transferVouPrint.Eno = lst_Credit_PLLimitVou[i].Eno;
                    transferVouPrint.CreditAcctDesp = desp;
                    transferVouPrint.CreditAcctAmount = lst_Credit_PLLimitVou[i].Amount;
                    transferVouPrint.CreditAcctNo = lst_Credit_PLLimitVou[i].AcctNo;
                    transferVouPrint.CrNarration = lst_Credit_PLLimitVou[i].Desp; //"Documentation Fees";

                    transferVouPrint.AmountInWords = this.AmountToWords(lst_Credit_PLLimitVou[i].Amount.ToString());
                    lsts_personalLoans_Limit_Vou_Print.Add(transferVouPrint);

                } // End of For Looping
                #endregion

                #region Service Charges
                for (int i = 0; i < lstPLLimitVou3.Count - 1; i++)
                {
                    lst_Debit_PLLimitVou = lstPLLimitVou3.Where(a => a.Status == "TDV").ToList();
                    lst_Credit_PLLimitVou = lstPLLimitVou3.Where(a => a.Status == "TCV").ToList();

                    LOMDTO00235 transferVouPrint = new LOMDTO00235(); // For RDLC Display

                    if (lst_Debit_PLLimitVou[i].AcctNo.Length == 6)
                    {
                        debitAcctNo = lstPLLimitVou3[i].AcctNo;
                        index = debitAcctNo.IndexOf("0");
                        acType = debitAcctNo.Substring(0, index);
                        serialNo = debitAcctNo.Substring(index, debitAcctNo.Length - index);
                        desp = lst_Debit_PLLimitVou[i].HeadACName + "-" + lst_Debit_PLLimitVou[i].Desp + "(" + acType + "-" + serialNo + ")";
                    }

                    else
                    {
                        debitAcctNo = lst_Debit_PLLimitVou[i].AcctNo;
                        brCode = debitAcctNo.Substring(0, 3);
                        acType = debitAcctNo.Substring(3, 3);
                        serialNo = debitAcctNo.Substring(6, 9);
                        debitAcctNo = brCode + " - " + acType + "-" + serialNo;
                        desp = "Customer A/C - ( " + debitAcctNo + " ) " + " " + lst_Debit_PLLimitVou[i].Desp;
                    }

                    transferVouPrint.Eno = lst_Debit_PLLimitVou[i].Eno;
                    transferVouPrint.DebitAcctDesp = desp;
                    transferVouPrint.DebitAcctAmount = lst_Debit_PLLimitVou[i].Amount;
                    transferVouPrint.DebitAcctNo = lst_Debit_PLLimitVou[i].AcctNo;
                    transferVouPrint.DrNarration = lst_Credit_PLLimitVou[i].Desp;  //"Service Charges";

                    /////////////For Credit Transactions///////////////

                    if (lst_Credit_PLLimitVou[i].AcctNo.Length == 6)
                    {
                        creditAcctNo = lst_Credit_PLLimitVou[i].AcctNo;
                        index = creditAcctNo.IndexOf("0");
                        acType = creditAcctNo.Substring(0, index);
                        serialNo = creditAcctNo.Substring(index, creditAcctNo.Length - index);
                        desp = lst_Credit_PLLimitVou[i].HeadACName + "-" + lst_Credit_PLLimitVou[i].Desp + "(" + acType + "-" + serialNo + ")";
                    }

                    else
                    {
                        creditAcctNo = lst_Credit_PLLimitVou[i].AcctNo;
                        brCode = creditAcctNo.Substring(0, 3);
                        acType = creditAcctNo.Substring(3, 3);
                        serialNo = creditAcctNo.Substring(6, 9);
                        creditAcctNo = brCode + " - " + acType + "-" + serialNo;
                        desp = "Customer A/C - ( " + creditAcctNo + " ) " + " " + lst_Credit_PLLimitVou[i].Desp;
                    }

                    transferVouPrint.Eno = lst_Credit_PLLimitVou[i].Eno;
                    transferVouPrint.CreditAcctDesp = desp;
                    transferVouPrint.CreditAcctAmount = lst_Credit_PLLimitVou[i].Amount;
                    transferVouPrint.CreditAcctNo = lst_Credit_PLLimitVou[i].AcctNo;
                    transferVouPrint.CrNarration = lst_Credit_PLLimitVou[i].Desp;  //"Service Charges";

                    transferVouPrint.AmountInWords = this.AmountToWords(lst_Credit_PLLimitVou[i].Amount.ToString());
                    lsts_personalLoans_Limit_Vou_Print.Add(transferVouPrint);

                } // End of For Looping
                #endregion

                this.Call_PL_Limits_Voucher_Printing(rptName, lsts_personalLoans_Limit_Vou_Print);
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

        //Added By AAM (27-Feb-2018)
        public string Get_CustomerName_PLVoucher(string plNo)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00325, string>(x => x.Get_CustomerName_PLVoucher(plNo));
        }
        
        //Added by YMP at 30-07-2019 : [Seperating EOD Process] To show system date (not PC date) at report
        public DateTime GetSystemDate(string sourceBr)
        {
            TCMDTO00001 systemStartInfo = CXClientWrapper.Instance.Invoke<ICXSVE00006, TCMDTO00001>(x => x.SelectStartBySourceBr(sourceBr));
            DateTime systemDate = systemStartInfo.Date;
            return systemDate;
        }

        //Added by HMW at 28-08-2019 : [Seperating EOD Process] Check Settlement Date to show form
        public DateTime GetLastSettlementDate(string sourceBr)
        {
            DateTime lastSettlementDate = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.LastSettlementDate), sourceBr);
            return lastSettlementDate;
        }
        #endregion
    }
}
