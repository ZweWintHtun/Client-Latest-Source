//----------------------------------------------------------------------
// <copyright file="PFMDAO00042" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate>2.9.2013</CreatedDate>
// <UpdatedUser>Ye Mann Aung</UpdatedUser>
// <UpdatedDate>2013-11-28</UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using NHibernate;
using System;
namespace Ace.Cbs.Pfm.Dao
{
    public class PFMDAO00042 : DataRepository<PFMORM00054>, IPFMDAO00042
    {
        public IList<PFMDTO00042> SelectDepositByAllAccount(string workStation)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00063.SelecDepositListingByAll");
            query.SetString("sourceBr", workStation);
            IList<PFMDTO00042> list = query.List<PFMDTO00042>();
            return list;
        }

        public IList<PFMDTO00042> SelectDepositByCounterNo(string userNo, string workStation)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00063.SelecDepositListingByAll");
            query.SetString("userNo", userNo);
            query.SetString("sourceBr", workStation);
            IList<PFMDTO00042> list = query.List<PFMDTO00042>();
            return list;
        }

        public IList<PFMDTO00042> SelectDepositByAccountType(string userNo, string accountSign, string workStation)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00042.SelectDepositByAccountType");
            query.SetString("userNo", userNo);
            query.SetString("accountSign", accountSign);
            query.SetString("sourceBr", workStation);
            IList<PFMDTO00042> list = query.List<PFMDTO00042>();
            return list;
        }

        public IList<PFMDTO00042> SelectDepositByAccountNo(string accountNo, string workStation, DateTime startDate, DateTime endDate)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00063.SelecDepositListingByAll");
            query.SetString("accountNo", accountNo);
            query.SetString("sourceBr", workStation);
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            IList<PFMDTO00042> list = query.List<PFMDTO00042>();
            return list;
        }

        public IList<PFMDTO00042> SelectScheduleData(bool isTransaction,string workstation,DateTime selectedDate,string sourceCur)
        {
            IQuery query = this.Session.GetNamedQuery((isTransaction) ? "TCMVEW00029.Schedule.TransactionDate.Report" : "TCMVEW00029.Schedule.Settlement.Report");
            query.SetString("workstation", workstation);
            query.SetString("selectedDateTime", selectedDate.ToString("yyyy/MM/dd"));
            query.SetString("lcd", "LCD");
            query.SetString("sourceCur", sourceCur);
            return query.List<PFMDTO00042>();
        }

        public IList<PFMDTO00042> SelectAbstractData(bool isTransaction, string workstation, DateTime selectedDate, string sourceCur)
        {
            IQuery query = this.Session.GetNamedQuery((isTransaction) ? "TCMVEW00029.Abstract.TransactionDate.Report" : "TCMVEW00029.Abstract.SettlementDate.Report");
            query.SetString("workstation", workstation);
            query.SetString("selectDate", selectedDate.ToString("yyyy/MM/dd"));
            query.SetString("status", "L");
            query.SetString("r", "R");
            query.SetString("sourceCur", sourceCur);
            return query.List<PFMDTO00042>();
        }

        public IList<PFMDTO00042> SelectReport_TLF(string workstation, int month, int year, string acSign, string status, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00042.SelectReportTLF");
            query.SetString("workstation", workstation);
            query.SetInt32("month", month);
            query.SetInt32("year", year);
            query.SetString("acSign", acSign);
            query.SetString("status", status);
            query.SetString("sourceBr", sourceBr);
            IList<PFMDTO00042> list = query.List<PFMDTO00042>();

            return list;
        }

        public IList<PFMDTO00042> SelectDebitListing(string workStation, string acSign, string sourceBr, string transactionCode, DateTime datetime, string sourceCur)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00042.SelectByDebitListing");
            query.SetString("workstation", workStation);
            query.SetString("acsign", acSign + "%");
            query.SetString("sourceBr", sourceBr);
            query.SetString("transactioncode", transactionCode);
            query.SetDateTime("datetime", datetime);
            query.SetString("sourceCur", sourceCur);
         
            IList<PFMDTO00042> list = query.List<PFMDTO00042>();
            return list;
        }



      
        public IList<PFMDTO00042> SelectOverDraftReportData(DateTime selectedDateTime, string currency, string workstation, bool isReserval, bool isTransaction)
        {
            IQuery query;
            if (!isReserval)
            {
                if (isTransaction)
                    query = this.Session.GetNamedQuery("PFMDAO00042.SelectOverDraftDayBook.TransactionDate.WithoutReversal");
                else
                    query = this.Session.GetNamedQuery("PFMDAO00042.SelectOverDraftDayBook.SettlementDate.WithoutReversal");
            }
            else
            {
                if (isTransaction)
                    query = this.Session.GetNamedQuery("PFMDAO00042.SelectOverDraftDayBook.TransactionDate.WithReversal");
                else
                    query = this.Session.GetNamedQuery("PFMDAO00042.SelectOverDraftDayBook.SettlementDate.WithReversal");
            }
            query.SetString("c", "C");
            query.SetString("od", "OD");
            query.SetString("selectedCurrency", currency);
            query.SetString("selectedDateTime", selectedDateTime.ToString("yyyy/MM/dd"));
            query.SetString("workstation", "5");
            IList<PFMDTO00042> list = query.List<PFMDTO00042>();
            return list;
        }

        public IList<PFMDTO00042> GetBankCashDataWithoutReversal1(string workStationId, string sourceCurrency,string branchCode,DateTime dateTime,string cashCreditStatus, string cashDebitStatus)
        {
            IQuery query = this.Session.GetNamedQuery("TCMVEW00025.SelectBankCashWithoutReversal1");
            query.SetString("workStationId", workStationId);
            query.SetString("sourceCurrency", sourceCurrency);
            query.SetString("branchCode", branchCode);
            query.SetDateTime("dateTime", dateTime);
            query.SetString("cashCreditStatus", cashCreditStatus);
            query.SetString("cashDebitStatus", cashDebitStatus);
            return query.List<PFMDTO00042>();
        }

        public IList<PFMDTO00042> GetBankCashDataWithoutReversal2(string workStationId, string sourceCurrency, DateTime dateTime,string branchCode,string cashCreditStatus, string cashDebitStatus, string currentControlStatus, string overDraftStatus)
        {
            IQuery query = this.Session.GetNamedQuery("TCMVEW00025.SelectBankCashWithoutReversal2");
            query.SetString("workStationId", workStationId);
            query.SetString("sourceCurrency", sourceCurrency);
            query.SetDateTime("dateTime", dateTime);
            query.SetString("branchCode", branchCode);
            query.SetString("cashCreditStatus", cashCreditStatus);
            query.SetString("cashDebitStatus", cashDebitStatus);
            query.SetString("currentControlStatus", currentControlStatus);
            query.SetString("overDraftStatus", overDraftStatus);
            IList<PFMDTO00042> list = query.List<PFMDTO00042>();
            return list;
        }

        public IList<PFMDTO00042> GetBankCashDataWithReversal1(string workStationId, string sourceCurrency,string branchCode, DateTime dateTime, string cashCreditStatus, string cashDebitStatus)
        {
            IQuery query = this.Session.GetNamedQuery("TCMVEW00025.SelectBankCashWithReversal1");
            query.SetString("workStationId", workStationId);
            query.SetString("sourceCurrency", sourceCurrency);
            query.SetString("branchCode", branchCode);
            query.SetDateTime("dateTime", dateTime);
            query.SetString("cashCreditStatus", cashCreditStatus);
            query.SetString("cashDebitStatus", cashDebitStatus);
            IList<PFMDTO00042> list = query.List<PFMDTO00042>();
            return list;
        }

        public IList<PFMDTO00042> GetBankCashDataWithReversal2(string workStationId, string sourceCurrency, DateTime dateTime, string branchCode, string cashCreditStatus, string cashDebitStatus, string currentControlStatus, string overDraftStatus)
        {
            IQuery query = this.Session.GetNamedQuery("TCMVEW00025.SelectBankCashWithReversal2");
            query.SetString("workStationId", workStationId);
            query.SetString("sourceCurrency", sourceCurrency);
            query.SetDateTime("dateTime", dateTime);
            query.SetString("branchCode", branchCode);
            query.SetString("cashCreditStatus", cashCreditStatus);
            query.SetString("cashDebitStatus", cashDebitStatus);
            query.SetString("currentControlStatus", currentControlStatus);
            query.SetString("overDraftStatus", overDraftStatus);
            IList<PFMDTO00042> list = query.List<PFMDTO00042>();
            return list;
        }

        public IList<PFMDTO00042> GetClearingPaidChequeReport(DateTime startdate , DateTime enddate , string workstation)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00042.ClearingPaidChequeListing");
            query.SetString("startdate", startdate.ToString("yyyy/MM/dd"));
            query.SetString("enddate", enddate.ToString("yyyy/MM/dd"));
            query.SetString("workstation", workstation);
            return query.List<PFMDTO00042>();
        }

        public IList<PFMDTO00042> ChequePOReceipt(DateTime startdate, DateTime enddate, string workstation)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00042.Cheque.POReceipt");
            query.SetString("startdate", startdate.ToString("yyyy/MM/dd"));
            query.SetString("enddate", enddate.ToString("yyyy/MM/dd"));
            query.SetString("workstation", workstation);
            return query.List<PFMDTO00042>();
        }

        public IList<PFMDTO00042> SelectDeliveredChequeBySourceBrAndWorkstation(DateTime startdate, DateTime enddate, string sourcebr, string workstation)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00042.SelectDeliveredChequeBySourebrAndWorkstation");
            query.SetDateTime("startdate", startdate);
            query.SetDateTime("enddate", enddate);
            query.SetString("sourcebr", sourcebr);
            query.SetString("workstation", workstation);
            IList<PFMDTO00042> reporttlfs = query.List<PFMDTO00042>();
            return reporttlfs;
        }     

    }
}