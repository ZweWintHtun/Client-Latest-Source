using System;
using Ace.Windows.Core.DataModel;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    // Balance dto
    [Serializable]
    public class PFMDTO00033 : Supportfields<PFMDTO00033>
    {
        public PFMDTO00033(){}

        public PFMDTO00033(decimal m1)
        {
            this.Month1 = m1;
        }
        public PFMDTO00033(string currency)
        {
            this.CurrencyCode = currency;
        }
        public PFMDTO00033(decimal m2, decimal m1)
        {
            this.Month2 = m2;
            this.Month1 = m1;
        }

        public PFMDTO00033(decimal m3, decimal m2, decimal m1)
        {
            this.Month3 = m3;
            this.Month2 = m2;
            this.Month1 = m1;
        }


        public PFMDTO00033(decimal m4, decimal m3, decimal m2, decimal m1)
        {
            this.Month4 = m4;
            this.Month3 = m3;
            this.Month2 = m2;
            this.Month1 = m1;
        }

        public PFMDTO00033(decimal m5, decimal m4, decimal m3, decimal m2, decimal m1)
        {
            this.Month5 = m5;
            this.Month4 = m4;
            this.Month3 = m3;
            this.Month2 = m2;
            this.Month1 = m1;
        }

        public PFMDTO00033(decimal m6, decimal m5, decimal m4, decimal m3, decimal m2, decimal m1)
        {
            this.Month6 = m6;
            this.Month5 = m5;
            this.Month4 = m4;
            this.Month3 = m3;
            this.Month2 = m2;
            this.Month1 = m1;
        }

        public PFMDTO00033(decimal m7, decimal m6, decimal m5, decimal m4, decimal m3, decimal m2, decimal m1)
        {
            this.Month7 = m7;
            this.Month6 = m6;
            this.Month5 = m5;
            this.Month4 = m4;
            this.Month3 = m3;
            this.Month2 = m2;
            this.Month1 = m1;
        }

        public PFMDTO00033(decimal m8, decimal m7, decimal m6, decimal m5, decimal m4, decimal m3, decimal m2, decimal m1)
        {
            this.Month8 = m8;
            this.Month7 = m7;
            this.Month6 = m6;
            this.Month5 = m5;
            this.Month4 = m4;
            this.Month3 = m3;
            this.Month2 = m2;
            this.Month1 = m1;
        }

        public PFMDTO00033(decimal m9, decimal m8, decimal m7, decimal m6, decimal m5, decimal m4, decimal m3, decimal m2, decimal m1)
        {
            this.Month9 = m9;
            this.Month8 = m8;
            this.Month7 = m7;
            this.Month6 = m6;
            this.Month5 = m5;
            this.Month4 = m4;
            this.Month3 = m3;
            this.Month2 = m2;
            this.Month1 = m1;
        }


        public PFMDTO00033(decimal m10, decimal m9, decimal m8, decimal m7, decimal m6, decimal m5, decimal m4, decimal m3, decimal m2, decimal m1)
        {
            this.Month10 = m10;
            this.Month9 = m9;
            this.Month8 = m8;
            this.Month7 = m7;
            this.Month6 = m6;
            this.Month5 = m5;
            this.Month4 = m4;
            this.Month3 = m3;
            this.Month2 = m2;
            this.Month1 = m1;
        }

        public PFMDTO00033(decimal m11, decimal m10, decimal m9, decimal m8, decimal m7, decimal m6, decimal m5, decimal m4, decimal m3, decimal m2, decimal m1)
        {
            this.Month11 = m11;
            this.Month10 = m10;
            this.Month9 = m9;
            this.Month8 = m8;
            this.Month7 = m7;
            this.Month6 = m6;
            this.Month5 = m5;
            this.Month4 = m4;
            this.Month3 = m3;
            this.Month2 = m2;
            this.Month1 = m1;
        }

        public PFMDTO00033(decimal m12, decimal m11, decimal m10, decimal m9, decimal m8, decimal m7, decimal m6, decimal m5, decimal m4, decimal m3, decimal m2, decimal m1)
        {
            this.Month12 = m12;
            this.Month11 = m11;
            this.Month10 = m10;
            this.Month9 = m9;
            this.Month8 = m8;
            this.Month7 = m7;
            this.Month6 = m6;
            this.Month5 = m5;
            this.Month4 = m4;
            this.Month3 = m3;
            this.Month2 = m2;
            this.Month1 = m1;
        }     

        public PFMDTO00033(string acctNo,DateTime date_time,decimal Amount,string acSign)
        {
            this.AccountNo = acctNo;
            this.DATE_TIME = date_time;
            this.Amt = Amount;
            this.AccountSign = acSign;
        }

        public PFMDTO00033(int id, string acctNo, string cur, System.Nullable<DateTime> dATE_TIME, string uSERNO, System.Nullable<DateTime> closeDate, string budget, string aCSign, decimal m1, System.Nullable<decimal> tCount1, decimal m2, System.Nullable<decimal> tCount2, decimal m3, System.Nullable<decimal> tCount3, decimal m4, System.Nullable<decimal> tCount4, decimal m5, System.Nullable<decimal> tCount5, decimal m6, System.Nullable<decimal> tCount6, decimal m7, System.Nullable<decimal> tCount7, decimal m8, System.Nullable<decimal> tCount8, decimal m9, System.Nullable<decimal> tCount9, decimal m10, System.Nullable<decimal> tCount10, decimal m11, System.Nullable<decimal> tCount11, decimal m12, System.Nullable<decimal> tCount12, string sourceBr, bool active, byte[] tS, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId)
        {
            this.Id = id;
            this.AccountNo = acctNo;
            this.CurrencyCode = cur;
            this.DATE_TIME = dATE_TIME;
            this.USERNO = uSERNO;
            this.CloseDate = closeDate;
            this.Budget = budget;
            this.AccountSign = aCSign;
            this.Month1 = m1;
            this.TransactionCountOfMonth1 = tCount1;
            this.Month2 = m2;
            this.TransactionCountOfMonth2 = tCount2;
            this.Month3 = m3;
            this.TransactionCountOfMonth3 = tCount3;
            this.Month4= m4;
            this.TransactionCountOfMonth4 = tCount4;
            this.Month5 = m5;
            this.TransactionCountOfMonth5 = tCount5;
            this.Month6 = m6;
            this.TransactionCountOfMonth6 = tCount6;
            this.Month7 = m7;
            this.TransactionCountOfMonth7 = tCount7;
            this.Month8 = m8;
            this.TransactionCountOfMonth8 = tCount8;
            this.Month9 = m9;
            this.TransactionCountOfMonth9 = tCount9;
            this.Month10 = m10;
            this.TransactionCountOfMonth10 = tCount10;
            this.Month11 = m11;
            this.TransactionCountOfMonth11 = tCount11;
            this.Month12 = m12;
            this.TransactionCountOfMonth12 = tCount12;
            this.SourceBranchCode = sourceBr;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }
        //public PFMDTO00033(string sourceBr)
        //{
        //    this.SourceBranchCode = sourceBr;

        //}

        public PFMDTO00033(string acctNo, decimal currentBal,decimal ovdLimit,string aCSign,decimal usedRate, decimal unUsedRate,DateTime date_time, string cur,string sourceBr, decimal m1, decimal m2, decimal m3, decimal m4,decimal m5, decimal m6,decimal m7, decimal m8,decimal m9, decimal m10,decimal m11,decimal m12)
        {           
            this.AccountNo = acctNo;
            this.CurrentBal = currentBal;
            this.OverdraftLimit = ovdLimit;
            this.AccountSign = aCSign;
            this.UsedRate = usedRate;
            this.UnUsedRate = unUsedRate;
            this.Date_Time = date_time;
            this.CurrencyCode = cur;     
            this.SourceBranchCode = sourceBr;
            this.Month1 = m1;            
            this.Month2 = m2;     
            this.Month3 = m3;
            this.Month4 = m4;
            this.Month5 = m5;
            this.Month6 = m6;
            this.Month7 = m7;
            this.Month8 = m8;
            this.Month9 = m9;
            this.Month10 = m10;
            this.Month11 = m11;
            this.Month12 = m12;                     
        }

        public virtual int Id { get; set; }
        public virtual string AccountNo { get; set; }
        public virtual System.Nullable<DateTime> DATE_TIME { get; set; }
        public virtual string USERNO { get; set; }
        public virtual System.Nullable<DateTime> CloseDate { get; set; }
        public virtual string Budget { get; set; }
        public virtual string AccountSign { get; set; }
        public virtual decimal Month1 { get; set; }
        public virtual System.Nullable<decimal> TransactionCountOfMonth1 { get; set; }
        public virtual decimal Month2 { get; set; }
        public virtual System.Nullable<decimal> TransactionCountOfMonth2 { get; set; }
        public virtual decimal Month3 { get; set; }
        public virtual System.Nullable<decimal> TransactionCountOfMonth3 { get; set; }
        public virtual decimal Month4 { get; set; }
        public virtual System.Nullable<decimal> TransactionCountOfMonth4 { get; set; }
        public virtual decimal Month5 { get; set; }
        public virtual System.Nullable<decimal> TransactionCountOfMonth5 { get; set; }
        public virtual decimal Month6 { get; set; }
        public virtual System.Nullable<decimal> TransactionCountOfMonth6 { get; set; }
        public virtual decimal Month7 { get; set; }
        public virtual System.Nullable<decimal> TransactionCountOfMonth7 { get; set; }
        public virtual decimal Month8 { get; set; }
        public virtual System.Nullable<decimal> TransactionCountOfMonth8 { get; set; }
        public virtual decimal Month9 { get; set; }
        public virtual System.Nullable<decimal> TransactionCountOfMonth9 { get; set; }
        public virtual decimal Month10 { get; set; }
        public virtual System.Nullable<decimal> TransactionCountOfMonth10 { get; set; }
        public virtual decimal Month11 { get; set; }
        public virtual System.Nullable<decimal> TransactionCountOfMonth11 { get; set; }
        public virtual decimal Month12 { get; set; }
        public virtual System.Nullable<decimal> TransactionCountOfMonth12 { get; set; }
        public virtual string SourceBranchCode { get; set; }
        public virtual string CurrencyCode { get; set; }
        //Branch Relation
        public virtual PFMDTO00033 Branch { get; set; }

        //currency Relation
        public virtual CurrencyDTO Currency { get; set; }

        public virtual decimal Amt { get; set; }
        
        public virtual decimal CurrentBal { get; set; }
        public virtual decimal OverdraftLimit { get; set; }        
        public virtual decimal UsedRate { get; set; }
        public virtual decimal UnUsedRate { get; set; }
        public virtual DateTime Date_Time { get; set; }

  
    }
}