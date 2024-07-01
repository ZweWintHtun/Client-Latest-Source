using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Tcm.Ctr.Dao;
using NHibernate;
using Spring.Transaction;
using Spring.Transaction.Interceptor;

namespace Ace.Cbs.Tcm.Dao
{
    public class TCMDAO00052 : DataRepository<TCMORM00052>, ITCMDAO00052
    {
        public void DeleteData(string currency)
        {
            IQuery query = this.Session.GetNamedQuery("DeleteDailyReportByCurDate");
            query.SetString("CUR", currency);
            query.ExecuteUpdate();
        }

        [Transaction(TransactionPropagation.Required)]
        public int SelectMaxId()
        {
            IQuery query = this.Session.GetNamedQuery("TCMDAO00052.SelectMaxId");
            int id = query.UniqueResult<TCMDTO00052>().Id;
            return id;
        }

        public TCMDTO00052 SelectViewDate(string currency, DateTime datetime)
        {
            IQuery query = this.Session.GetNamedQuery("TCMVIW00052.MODIFY_DAILYREPORT_VW");
            query.SetString("Cur", currency);
            query.SetDateTime("datetime",datetime);           
            TCMDTO00052 dto = query.UniqueResult<TCMDTO00052>();
            return dto;
        }

        public TCMDTO00052 SelectDailyReportData(string currency)
        {
            IQuery query = this.Session.GetNamedQuery("SelectDailyReportData");
            query.SetString("Cur", currency);
            TCMDTO00052 dto = query.UniqueResult<TCMDTO00052>();
            return dto;
        }

        public TCMDTO00052 SelectAllDailyReport(DateTime postDate, string currency)
        {
            IQuery query = this.Session.GetNamedQuery("TCMDAO0011.SelectAllFromDailyReport");
            query.SetString("cur", currency);
            query.SetString("datetime", postDate.ToString("yyyy/MM/dd"));
            return query.UniqueResult<TCMDTO00052>();
        }

        [Transaction(TransactionPropagation.Required)]
        public int UpdateDailyReport(TCMDTO00052 dailyreportdto)
        {
            IQuery query = this.Session.GetNamedQuery("TCMDAO00011.UpdateDailyReport");
            query.SetDecimal("receiptcash", dailyreportdto.RECEIPTCASH);
            query.SetDecimal("receiptcashvou", dailyreportdto.RECEIPTCASHVOU);

            query.SetDecimal("receiptTran", dailyreportdto.RECEIPTTRANSFER);
            query.SetDecimal("receiptTranVou", dailyreportdto.RECEIPTTRANSFERVOU);
            query.SetDecimal("receiptClearing", dailyreportdto.RECEIPTCLEARING);
            query.SetDecimal("receiptClearingVou", dailyreportdto.RECEIPTCLEARINGVOU);
            query.SetDecimal("paymentCash", dailyreportdto.PAYMENTCASH);
            query.SetDecimal("paymentCashVou", dailyreportdto.PAYMENTCASHVOU);
            query.SetDecimal("paymentTran", dailyreportdto.PAYMENTTRANSFER);
            query.SetDecimal("paymentTranVou", dailyreportdto.PAYMENTTRANSFERVOU);
            query.SetDecimal("paymentClearing", dailyreportdto.PAYMENTCLEARING);
            query.SetDecimal("paymentClearingVou", dailyreportdto.PAYMENTCLEARINGVOU);
            query.SetDecimal("drawingCash", dailyreportdto.DRAWINGCASH);
            query.SetDecimal("drawingCashVou", dailyreportdto.DRAWINGCASHVOU);
            query.SetDecimal("drawingTran", dailyreportdto.DRAWINGTRANSFER);
            query.SetDecimal("drawingTanVou", dailyreportdto.DRAWINGTRANSFERVOU);
            query.SetDecimal("encashCash", dailyreportdto.ENCASHCASH);
            query.SetDecimal("encashCashVou", dailyreportdto.ENCASHCASHVOU);
            query.SetDecimal("encashTran", dailyreportdto.ENCASHTRANSFER);
            query.SetDecimal("encashTranVou", dailyreportdto.ENCASHTRANSFERVOU);
            query.SetDecimal("cashinHand", dailyreportdto.CASHINHAND);
            query.SetDecimal("cashwithcbm", dailyreportdto.CASHWITHCBM);
            query.SetDecimal("acwithothbank", dailyreportdto.ACWITHOTHBANK);
            query.SetDecimal("curopened", dailyreportdto.CUROPENED);
            query.SetDecimal("curclosed", dailyreportdto.CURCLOSED);
            query.SetDecimal("curtotal", dailyreportdto.CURTOTAL);
            query.SetDecimal("curobal", dailyreportdto.CUROBAL);
            query.SetDecimal("curdep", dailyreportdto.CURDEP);
            query.SetDecimal("curwith", dailyreportdto.CURWITH);
            query.SetDecimal("savopend", dailyreportdto.SAVOPENED);
            query.SetDecimal("saveclosed", dailyreportdto.SAVCLOSED);
            query.SetDecimal("savetotal", dailyreportdto.SAVTOTAL);
            query.SetDecimal("saveobal", dailyreportdto.SAVOBAL);
            query.SetDecimal("savedep", dailyreportdto.SAVDEP);
            query.SetDecimal("savwith", dailyreportdto.SAVWITH);
            query.SetDecimal("calopend", dailyreportdto.CALOPENED);
            query.SetDecimal("calclosed", dailyreportdto.CALCLOSED);
            query.SetDecimal("caltotal", dailyreportdto.CALTOTAL);
            query.SetDecimal("calobal", dailyreportdto.CALOBAL);
            query.SetDecimal("caldep", dailyreportdto.CALDEP);
            query.SetDecimal("calwith", dailyreportdto.CALWITH);
            query.SetDecimal("fixopened", dailyreportdto.FIXOPENED);

            query.SetDecimal("fixclosed", dailyreportdto.FIXCLOSED);
            query.SetDecimal("fixtotal", dailyreportdto.FIXTOTAL);
            query.SetDecimal("fixobal", dailyreportdto.FIXOBAL);
            query.SetDecimal("fixdep", dailyreportdto.FIXDEP);
            query.SetDecimal("fixwith", dailyreportdto.FIXWITH);
            query.SetDateTime("updateddate", dailyreportdto.UpdatedDate.Value);
            query.SetDecimal("updateduserId", dailyreportdto.UpdatedUserId.Value);
            query.SetString("currencycode", dailyreportdto.CUR);
            return query.ExecuteUpdate();
        }
    }
}
