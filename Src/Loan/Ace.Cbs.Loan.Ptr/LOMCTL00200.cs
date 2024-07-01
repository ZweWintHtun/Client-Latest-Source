using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Loan.Ptr
{
    class LOMCTL00200 : AbstractPresenter, ILOMCTL00200
    {
        public LOMDTO00200 dto;
        private ILOMVEW00200 view;
        public ILOMVEW00200 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00200 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }
        public LOMDTO00200 HPManualRepayment(string hpNo, int startTerm, int endTerm, decimal totalRepayAmt, string eno, string sourceBr, int createdUserId, string userName)
        {
            dto=CXClientWrapper.Instance.Invoke<ILOMSVE00096, LOMDTO00200>(x => x.HPManualRepayment(hpNo, startTerm, endTerm, totalRepayAmt,eno, sourceBr,createdUserId, userName));
            return dto;
        }

        public string HPManualRepayment_CheckPaidOrUnpaid(string hpNo, int startTerm, int endTerm, string sourceBr, int createdUserId, string userName)
        {
            string str = CXClientWrapper.Instance.Invoke<ILOMSVE00096, string>(x => x.HPManualRepayment_CheckPaidOrUnpaid(hpNo, startTerm, endTerm,sourceBr, createdUserId, userName));
            return str;
        }

        //public string GetRepayAmountPerTerm(string hpno,string sourceBr)
        //{
        //    string repayAmount=CXClientWrapper.Instance.Invoke<ILOMSVE00096, string>(x =>x.GetRepayAmountPerTerm(hpno,sourceBr));
        //    return repayAmount;
        //}

        //public string GetRepayAmountSTermToETerm(string hpno, int startTerm, int endTerm, string sourceBr)
        //{
        //    string repayTotalAmount = CXClientWrapper.Instance.Invoke<ILOMSVE00096, string>(x =>x.GetRepayAmountSTermToETerm(hpno, startTerm, endTerm, sourceBr));
        //    return repayTotalAmount;
        //}

        public string Get_HP_PrepaymentInfo(string hpNo,string sourceBr)
        {
            string str = CXClientWrapper.Instance.Invoke<ILOMSVE00096, string>(x => x.Get_HP_PrepaymentInfo(hpNo,sourceBr));
            return str;
        }

        public string HP_Manual_Pre_Payment_Process(string hpNo, int startTerm, int endTerm, decimal totalPaidPrepayAmt, decimal totalPaidRentalChgAmt,
                                                    decimal rentalDiscountRate, string eno, string sourceBr, int createdUserId, string userName)
        {
            string str = CXClientWrapper.Instance.Invoke<ILOMSVE00096, string>(x => x.HP_Manual_Pre_Payment_Process(hpNo,startTerm,endTerm,totalPaidPrepayAmt,totalPaidRentalChgAmt,
                                                                                                                    rentalDiscountRate,eno,sourceBr,createdUserId,userName));
            return str;
        }

        public string HP_Manual_Pre_Payment_Process_NewLogic(string hpNo, int startTerm, int endTerm, decimal totalPaidInstallmentAmt, decimal totalPaidPrincipleAmt, decimal totalPaidRentalChgAmt,
                                            decimal rentalDiscountRate, string sourceBr, int createdUserId, string userName)
        {
            string str = CXClientWrapper.Instance.Invoke<ILOMSVE00096, string>(x => x.HP_Manual_Pre_Payment_Process_NewLogic(hpNo, startTerm, endTerm,totalPaidInstallmentAmt, totalPaidPrincipleAmt, totalPaidRentalChgAmt,
                                                                                                                    rentalDiscountRate,sourceBr, createdUserId, userName));
            return str;
        }

        public string Get_HP_PrepaymentInfo_NewLogic(string hpNo, int startTerm, int endTerm, string sourceBr)
        {
            string str = CXClientWrapper.Instance.Invoke<ILOMSVE00096, string>(x => x.Get_HP_PrepaymentInfo_NewLogic(hpNo,startTerm,endTerm,sourceBr));
            return str;
        }

        public string CheckHPAccountandStartTerm(string hpNo, string sourceBr)
        {
            string str = CXClientWrapper.Instance.Invoke<ILOMSVE00096, string>(x => x.CheckHPAccountandStartTerm(hpNo,sourceBr));
            return str;
        }        

        // Personal Loan Manual Prepayment Process,added by AAM (05-Apr-2018)
        public string PL_Manual_Pre_Payment_Process(string plNo, int startTerm, int endTerm, decimal totalPaidInstallAmt
                                                    , decimal totalPaidPrinAmt, decimal totalPaidIntAmt, decimal intDisRate, string sourceBr
                                                    , int createdUserId, string userName,string formatCode
                                                    ,int valueCount,string valueStr)
        {
            string str = CXClientWrapper.Instance.Invoke<ILOMSVE00096, string>(x => x.PL_Manual_Pre_Payment_Process(plNo,startTerm,endTerm,totalPaidInstallAmt
                                                                                    , totalPaidPrinAmt, totalPaidIntAmt, intDisRate, sourceBr
                                                                                    ,createdUserId,userName,formatCode
                                                                                    ,valueCount,valueStr));
            return str;
        }

        public string Get_PL_PrepaymentInfo(string plNo, int startTerm, int endTerm, string sourceBr)
        {
            string str = CXClientWrapper.Instance.Invoke<ILOMSVE00096, string>(x => x.Get_PL_PrepaymentInfo(plNo, startTerm, endTerm, sourceBr));
            return str;
        }

        public string CheckPLAccountandStartTerm(string plNo, string sourceBr)
        {
            string str = CXClientWrapper.Instance.Invoke<ILOMSVE00096, string>(x => x.CheckPLAccountandStartTerm(plNo, sourceBr));
            return str;
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
    }
}
