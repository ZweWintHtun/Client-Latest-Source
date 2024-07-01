//----------------------------------------------------------------------
// <copyright file="PFMDAO00042" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate>2.9.2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using Ace.Windows.Core.Dao;
using Ace.Cbs.Pfm.Dmd;
using System;
using System.Collections.Generic;
namespace Ace.Cbs.Pfm.Ctr.Dao
{
    public interface IPFMDAO00042
    {
        IList<PFMDTO00042> SelectDepositByAllAccount(string workStation);
        IList<PFMDTO00042> SelectDepositByCounterNo(string userNo, string workStation);
        IList<PFMDTO00042> SelectDepositByAccountType(string userNo, string accountSign, string workStation);
        IList<PFMDTO00042> SelectDepositByAccountNo(string accountNo, string workStation, DateTime startDate, DateTime endDate);
        IList<PFMDTO00042> SelectScheduleData(bool isTransaction, string workstation, DateTime selectedDate,string sourceCur);
        IList<PFMDTO00042> SelectAbstractData(bool isTransaction, string workstation, DateTime selectedDate,string sourceCur);
        IList<PFMDTO00042> SelectReport_TLF(string workstation, int month, int year, string acSign, string status, string sourceBr);
        IList<PFMDTO00042> SelectOverDraftReportData(DateTime selectedDateTime, string currency, string workstation, bool isReserval, bool isTransaction);
        IList<PFMDTO00042> GetBankCashDataWithoutReversal1(string workStationId, string sourceCurrency,string branchCode,DateTime dateTime,string cashCreditStatus, string cashDebitStatus);
        IList<PFMDTO00042> GetBankCashDataWithoutReversal2(string workStationId, string sourceCurrency,DateTime dateTime,string branchCode,string cashCreditStatus, string cashDebitStatus, string currentControlStatus, string overDraftStatus);
        IList<PFMDTO00042> GetBankCashDataWithReversal1(string workStationId, string sourceCurrency,string branchCode,DateTime dateTime,string cashCreditStatus, string cashDebitStatus);
        IList<PFMDTO00042> GetBankCashDataWithReversal2(string workStationId, string sourceCurrency, DateTime dateTime, string branchCode,string cashCreditStatus, string cashDebitStatus, string currentControlStatus, string overDraftStatus);

        //IList<PFMDTO00042> CheckDayBookSummaryReport(DateTime date, string status, string workstation); // for TCMSVE00028
        //IList<PFMDTO00042> GetDayBookSummaryReport(DateTime date, string status, string workstation); // for TCMSVE00028

        IList<PFMDTO00042> GetClearingPaidChequeReport(DateTime startdate, DateTime enddate , string workstation);
        IList<PFMDTO00042> ChequePOReceipt(DateTime startdate, DateTime enddate, string workstation);
        IList<PFMDTO00042> SelectDeliveredChequeBySourceBrAndWorkstation(DateTime startdate, DateTime enddate, string sourcebr, string workstation);

        IList<PFMDTO00042> SelectDebitListing(string workStation, string acSign, string sourceBr, string transactionCode, DateTime datetime, string sourceCur);
    }
}