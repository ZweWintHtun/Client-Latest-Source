using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using System;
using System.Collections.Generic;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00200 : IPresenter
    {
        ILOMVEW00200 View { get; set; }
        LOMDTO00200 HPManualRepayment(string hpNo, int startTerm, int endTerm, decimal totalRepayAmt, string eno, string sourceBr, int createdUserId, string userName);
        string HPManualRepayment_CheckPaidOrUnpaid(string hpNo, int startTerm, int endTerm, string sourceBr, int createdUserId, string userName);
        //string GetRepayAmountPerTerm(string hpno, string sourceBr);
        //string GetRepayAmountSTermToETerm(string hpno, int startTerm, int endTerm, string sourceBr);
        string Get_HP_PrepaymentInfo(string hpNo, string sourceBr);
        string HP_Manual_Pre_Payment_Process(string hpNo, int startTerm, int endTerm, decimal totalPaidPrepayAmt, decimal totalPaidRentalChgAmt,
                                                    decimal rentalDiscountRate, string eno, string sourceBr, int createdUserId, string userName);

        // Added-22-Sep-2017
        string HP_Manual_Pre_Payment_Process_NewLogic(string hpNo, int startTerm, int endTerm, decimal totalPaidInstallmentAmt, decimal totalPaidPrincipleAmt, decimal totalPaidRentalChgAmt,
                                            decimal rentalDiscountRate, string sourceBr, int createdUserId, string userName);
        string Get_HP_PrepaymentInfo_NewLogic(string hpNo, int startTerm, int endTerm, string sourceBr);
        string CheckHPAccountandStartTerm(string hpNo, string sourceBr);
        // Personal Loan Manual Prepayment Process,added by AAM (05-Apr-2018)
        string PL_Manual_Pre_Payment_Process(string plNo, int startTerm, int endTerm, decimal totalPaidInstallAmt
                                                    , decimal totalPaidPrinAmt, decimal totalPaidIntAmt, decimal intDisRate, string sourceBr
                                                    , int createdUserId, string userName,string formatCode
                                                    ,int valueCount,string valueStr);
        string Get_PL_PrepaymentInfo(string plNo, int startTerm, int endTerm, string sourceBr);
        string CheckPLAccountandStartTerm(string plNo, string sourceBr);
        DateTime GetSystemDate(string sourceBr);
        DateTime GetLastSettlementDate(string sourceBr);
    }
    public interface ILOMVEW00200
    {
        ILOMCTL00200 Controller { get; set; }
    }
}