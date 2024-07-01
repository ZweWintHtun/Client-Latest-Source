using System.Collections.Generic;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
using System;
using Spring.Transaction;
using Spring.Transaction.Interceptor;

namespace Ace.Cbs.Pfm.Dao
{
    public class PFMDAO00032:DataRepository<PFMORM00032>,IPFMDAO00032
    {
        
        public void Update(int id, string rNo)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00032.UpdateByFReceiptId");
            query.SetInt32("id", id);
            query.ExecuteUpdate();
        }

        public IList<PFMDTO00032> GetFixedReceiptByAccountNo(string accountNo,decimal duration)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00032.GetFixedReceiptByAccountNo");

            query.SetString("AccountNo", accountNo);

            query.SetDecimal("Duration", duration);

            return query.List<PFMDTO00032>();
        }

        public IList<PFMDTO00032> SelectDepositReceiptNoByAccountNo(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00032.SelectDepositReceiptNoByAccountNo");

            query.SetString("accountNo", accountNo);

            return query.List<PFMDTO00032>();
        }

        public IList<PFMDTO00032> SelectWithdrawalReceiptNoByAccountNo(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00032.SelectWithdrawalReceiptNoByAccountNo");
            query.SetString("accountNo", accountNo);
            return query.List<PFMDTO00032>();
        }

        public bool UpdateFreceiptWithdraw(string accountNo, string receiptNo, Nullable<DateTime> withdrawDate, int updatedUserId, DateTime updatedDate)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00032.UpdateFreceiptWithdraw");
            query.SetString("accountNo", accountNo);
            query.SetString("receiptNo", receiptNo);
            query.SetDateTime("withdrawDate", withdrawDate.Value);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", updatedDate);
            return query.ExecuteUpdate() > 0;
        }

        public bool UpdateLastIntDate(string accountNo, string receiptNo, int updatedUserId, System.DateTime updatedDate)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00032.UpdateLastIntDate");
            query.SetString("accountNo", accountNo);
            query.SetString("receiptNo", receiptNo);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", updatedDate);
            return query.ExecuteUpdate() > 0;
        }

        public PFMDTO00032 GetReceiptNoByAccountNo(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00032.GetReceiptNoByAccountNo");
            query.SetString("accountNo", accountNo);

            return query.UniqueResult<PFMDTO00032>();
        }

        public IList<PFMDTO00032> SelectFReceiptListByAccountNo(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00032.SelectFReceiptListByAccountNo");
            query.SetString("accountNo", accountNo);
            return query.List<PFMDTO00032>();
        }

        public PFMDTO00032 GetAccruedInterestByAccountNo(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00032.GetAccruedInterestByAccountNo");
            query.SetString("accountNo", accountNo);
            return query.UniqueResult<PFMDTO00032>();
        }

        [Transaction(TransactionPropagation.Required)]
        public bool DeleteFixedReceipt(string accountNo, string receiptNo,int userId,DateTime updatedDate)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00032.DeleteFixedReceipt");
            query.SetString("accountNo", accountNo);
            query.SetString("receiptNo", receiptNo);
            query.SetInt32("updatedUserId", userId);
            query.SetDateTime("updatedDate", updatedDate);

            return query.ExecuteUpdate()>0;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateFixedReceipt(PFMDTO00032 fReceiptInfo)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00032.UpdateFixedReceipt");
            query.SetString("accountNo", fReceiptInfo.AccountNo);
            query.SetString("receiptNo", fReceiptInfo.ReceiptNo);
            query.SetDecimal("interestRate",fReceiptInfo.InterestRate);
            query.SetString("accuredStatus", fReceiptInfo.AccuredStatus);
            query.SetString("toAccountNo", fReceiptInfo.ToAccountNo);
            query.SetDecimal("amount", fReceiptInfo.Amount);
            query.SetDecimal("duration", fReceiptInfo.Duration);
            query.SetInt32("updatedUserId", fReceiptInfo.CreatedUserId);
            query.SetDateTime("updatedDate", fReceiptInfo.CreatedDate);
            query.SetString("oldReceiptNo", fReceiptInfo.OldReceiptNo);

            return query.ExecuteUpdate()>0;
        }

        //Fixed Deposit Auto Renewal 
        [Transaction(TransactionPropagation.Required)]
        public string FixedDepositAutoRenewalUpdating(DateTime SDate, DateTime EDate, int Start, int UserNo, string SourceBr,string Vouno, int RetValue, string RetMsg)
        {
            IQuery query = this.Session.GetNamedQuery("Sp_FixRenewal");
            query.SetDateTime("SDate", SDate);
            query.SetDateTime("EDate", EDate);
            query.SetInt32("Start",Start);
            query.SetInt32("UserNo", UserNo);
            query.SetString("SourceBr", SourceBr);
            query.SetString("Vouno", Vouno);
            query.SetInt32("RetValue",RetValue);
            query.SetString("RetMsg", RetMsg);
            string code = query.UniqueResult().ToString();
            if (string.IsNullOrEmpty(code))
            {
                code = string.Empty;
            }
            return code;
            //return query.UniqueResult().ToString();

            //if (query.UniqueResult() == null)
            //{
            //    return string.Empty;
            //}
            //else
            //    return query.UniqueResult().ToString();
            
            
        }

        public IList<PFMDTO00032> SelectFReceiptByWdateIsNull(string sourceBr)     //NLKK
        {
            IQuery query = this.Session.GetNamedQuery("FReceiptDAO.SelectFixedReceiptByWDateIsNull");
            query.SetString("sourceBr", sourceBr);
            IList<PFMDTO00032> List = query.List<PFMDTO00032>();
            return List;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateBudgetEndAcAndDrAccrued(decimal budgetEndAc, int updatedUserId, string acctNo,string rNo) //NLKK
        {
            IQuery query = this.Session.GetNamedQuery("FReceiptDAO.UpdateBudgetEndAcAndDrAccrued");
            query.SetDecimal("budgetEndAc", budgetEndAc);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetString("acctNo", acctNo);
            query.SetString("rNo", rNo);

            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateFreceiptInterestWithdraw(PFMDTO00032 fReceiptInfo)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00032.UpdateFreceiptInterestWithdraw");
            query.SetString("accountNo", fReceiptInfo.AccountNo);
            query.SetString("currency", fReceiptInfo.CurrencyCode);
            query.SetInt32("updatedUserId", fReceiptInfo.CreatedUserId);
            query.SetDateTime("updatedDate", fReceiptInfo.CreatedDate);

            return query.ExecuteUpdate() > 0;
        }

        public PFMDTO00032 GetFirstReceiptNoByAccountNo(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00032.GetFirstReceiptNoByAccountNo");
            query.SetString("accountNo", accountNo);
            return query.List<PFMDTO00032>()[0];
        }

        public PFMDTO00032 CheckWithdrawalReceiptNo(string accountNo, string receiptNo, string branch)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00032.CheckFixedReceipt");
            query.SetString("accountNo", accountNo);
            query.SetString("receiptNo", receiptNo);
            query.SetString("branch", branch);
            return query.UniqueResult<PFMDTO00032>();
        }

        public IList<PFMDTO00032> GetFReceipts(DateTime date, string sourceBranch)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00032.GetFReceipts");
            query.SetDateTime("date", date);
            query.SetString("sourceBranch", sourceBranch);
            IList<PFMDTO00032> List = query.List<PFMDTO00032>();
            return List;
        }

       
        //public PFMDTO00032 GetTownshipCode(string customerId)
        //{
        //    IQuery query = this.Session.GetNamedQuery("TownshipCodeDAO.SelectTownshipCodeByCustId");
        //    query.SetString("custId", customerId);
        //    return query.UniqueResult<PFMDTO00032>();
        //}


        //Coming Accrue      //ASDA
        public IList<PFMDTO00032> CheckForComingAccrue(string currency, string sourceBranch)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00032.CheckForComingAccrue");
            query.SetString("currency", currency);
            query.SetString("sourceBranch", sourceBranch);
            IList<PFMDTO00032> List = query.List<PFMDTO00032>();
            return List;
        }
        //Coming Interest      //ASDA
        public IList<PFMDTO00032> CheckForComingInterest(string currency, string sourceBranch)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00032.CheckForComingInterest");
            query.SetString("currency", currency);
            query.SetString("sourceBranch", sourceBranch);
            IList<PFMDTO00032> List = query.List<PFMDTO00032>();
            return List;
        }

        public IList<PFMDTO00032> SelectLastInterestDateByAll(string sourceBr, DateTime date)
        {
             IQuery query = this.Session.GetNamedQuery("SelectFreceiptByLIntDate");
            //query.SetDateTime("date",date);
            query.SetString("date", date.ToString("yyyy/MM/dd"));
            query.SetString("sourceBr", sourceBr);
            IList<PFMDTO00032> List = query.List<PFMDTO00032>();
            return List;
        }
        }
}