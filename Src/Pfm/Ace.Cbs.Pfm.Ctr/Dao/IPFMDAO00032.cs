using System.Collections.Generic;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using System;

namespace Ace.Cbs.Pfm.Ctr.Dao
{
    //freceipt Dao interface
    public interface IPFMDAO00032:IDataRepository<PFMORM00032>
    {
        void Update(int id, string rNo);
        IList<PFMDTO00032> SelectDepositReceiptNoByAccountNo(string accountNo);
        IList<PFMDTO00032> GetFixedReceiptByAccountNo(string accountNo,decimal duration);
        bool UpdateFreceiptWithdraw(string accountNo, string receiptNo, Nullable<DateTime> withdrawDate, int updatedUserId, DateTime updatedDate);
        IList<PFMDTO00032> SelectWithdrawalReceiptNoByAccountNo(string accountNo);
        bool UpdateLastIntDate(string accountNo, string receiptNo, int updatedUserId, System.DateTime updatedDate);
        PFMDTO00032 GetReceiptNoByAccountNo(string accountNo);
        IList<PFMDTO00032> SelectFReceiptListByAccountNo(string accountNo);
        bool DeleteFixedReceipt(string accountNo, string receiptNo, int userId, DateTime updatedDate);
        bool UpdateFixedReceipt(PFMDTO00032 fReceiptInfo);
        string FixedDepositAutoRenewalUpdating(DateTime SDate, DateTime EDate, int Start, int UserNo, string SourceBr,string Vouno, int RetValue, string RetMsg);
        IList<PFMDTO00032> SelectFReceiptByWdateIsNull(string sourceBr);
        PFMDTO00032 GetAccruedInterestByAccountNo(string accountNo);
        bool UpdateBudgetEndAcAndDrAccrued(decimal budgetEndAc, int updatedUserId, string acctNo, string rNo);
        bool UpdateFreceiptInterestWithdraw(PFMDTO00032 fReceiptInfo);
        PFMDTO00032 GetFirstReceiptNoByAccountNo(string accountNo);
        PFMDTO00032 CheckWithdrawalReceiptNo(string accountNo, string receiptNo, string branch);

        IList<PFMDTO00032> GetFReceipts(DateTime date, string sourceBranch);
        //PFMDTO00032 GetTownshipCode(string customerId);

        //Coming Accrue   
        IList<PFMDTO00032> CheckForComingAccrue(string currency, string sourceBranch); //ASDA
        IList<PFMDTO00032> CheckForComingInterest(string currency, string sourceBranch); //ASDA
        IList<PFMDTO00032> SelectLastInterestDateByAll(string sourceBr, DateTime date);
    }
}