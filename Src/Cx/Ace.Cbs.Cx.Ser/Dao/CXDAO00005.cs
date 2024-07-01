using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Cx.Com.Ctr;
using NHibernate;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using NHibernate.Transform;
namespace Ace.Cbs.Cx.Ser.Dao
{
    public class CXDAO00005 : DataRepository<TLMORM00015>, ICXDAO00005
    {   //Select Max Id 
        [Transaction(TransactionPropagation.Required)]
        public int SelectMaxId()
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00015.SelectMaxId");
            TLMDTO00015 dto = query.UniqueResult<TLMDTO00015>();
            return dto.Id;
        }

        //For Cash Deno Table Insert For Multiple Withdraw ans Deposit Reversal
        [Transaction(TransactionPropagation.Required)]
        public string InsertCashDeno_MultipleWithdrawAndDepositReversal(TLMORM00015 cashdenoparameter)
        {
            IQuery query = this.Session.GetNamedQuery("SP_InsertCashDeno_MultipleWithdrawAndDepositReversal");
            query.SetString("denoEno", cashdenoparameter.DenoEntryNo);
            query.SetString("tlfEno", cashdenoparameter.TlfEntryNo);
            query.SetString("acType", cashdenoparameter.AccountType);
            query.SetString("branchcode", cashdenoparameter.BranchCode);
            query.SetDecimal("amount",Convert.ToDecimal(cashdenoparameter.Amount));
            if (cashdenoparameter.AdjustAmount.Value == null )
            {
                cashdenoparameter.AdjustAmount=0;
            }
            query.SetDecimal("adjustAmt", Convert.ToDecimal(cashdenoparameter.AdjustAmount.Value));
            query.SetString("denoDetail", cashdenoparameter.DenoDetail);
            query.SetString("denorefundDetail", cashdenoparameter.DenoRefundDetail);
            query.SetString("userNo", cashdenoparameter.UserNo);
            query.SetString("counterNo", cashdenoparameter.CounterNo);
            query.SetString("status", cashdenoparameter.Status);
            query.SetBoolean("reverse", Convert.ToBoolean(cashdenoparameter.Reverse));
            query.SetString("sourceBranch", cashdenoparameter.SourceBranchCode);
            query.SetString("currency", cashdenoparameter.Currency);
            query.SetString("denoRate", cashdenoparameter.DenoRate);
            query.SetString("denorefundRate", cashdenoparameter.DenoRefundRate);
            query.SetDateTime("settlementDate", Convert.ToDateTime(cashdenoparameter.SettlementDate));
            query.SetDecimal("rate", cashdenoparameter.Rate.Value);
            query.SetInt32("createduserId", cashdenoparameter.CreatedUserId);
            query.SetString("ErrorMessage", string.Empty);

            string strResult = query.UniqueResult().ToString();
            return strResult;
        }
    }
}
