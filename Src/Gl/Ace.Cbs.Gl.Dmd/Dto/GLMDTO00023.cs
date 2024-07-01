using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Gl.Dmd
{
    [Serializable]
    public class GLMDTO00023 : EntityBase<GLMDTO00023>
    {
        public GLMDTO00023() { }

        private string delimiter = "<*>";


        public GLMDTO00023(string acode, Nullable<decimal> amt)
        {
            this.ACODE = acode;
            this.Closing_bal = amt;
        }

        public GLMDTO00023(int id, string type, string item, string subItem, string aCode, string title, string subTitle, decimal openingBalance, decimal closingBalance, decimal creditAmount, decimal debitAmount, string dCode,string workStation, bool active, byte[] ts, int cuserid, DateTime cuserDate, int updateduserid, DateTime updateduserDate)
        {
            this.Id = id; 
            this.TYPE = type;
            this.ITEM = item;
            this.SUBITEM = subItem;
            this.ACODE = aCode;
            this.TITLE = title;
            this.SUBTITLE = subTitle;
            this.Opening_bal = openingBalance;
            this.Closing_bal = closingBalance;
            this.Credit_Amount = creditAmount;
            this.Debit_Amount = debitAmount;
            this.DCode = dCode;
            this.Workstation = workStation;
            this.Active = active;
            this.TS = ts;
            this.CreatedUserId = cuserid;
            this.CreatedDate = cuserDate;
            this.UpdatedUserId = updateduserid;
            this.UpdatedDate = updateduserDate;
        }

        public GLMDTO00023(int id, string type, string item, string subItem, string aCode, string title, string subTitle, decimal openingBalance, decimal closingBalance, decimal creditAmount, decimal debitAmount, string dCode, string workStation, bool active, byte[] ts, int cuserid, DateTime cuserDate, int updateduserid, DateTime updateduserDate, string groupAcode)
        {
            this.Id = id;
            this.TYPE = type;
            this.ITEM = item;
            this.SUBITEM = subItem;
            this.ACODE = aCode;
            this.TITLE = title;
            this.SUBTITLE = subTitle;
            this.Opening_bal = openingBalance;
            this.Closing_bal = closingBalance;
            this.Credit_Amount = creditAmount;
            this.Debit_Amount = debitAmount;
            this.DCode = dCode;
            this.Workstation = workStation;
            this.Active = active;
            this.TS = ts;
            this.CreatedUserId = cuserid;
            this.CreatedDate = cuserDate;
            this.UpdatedUserId = updateduserid;
            this.UpdatedDate = updateduserDate;
            this.GroupAcode = groupAcode;
        }

        public GLMDTO00023(string aCode, decimal balance)
        {
            this.ACODE = aCode;
            this.Balance = balance;
        }

        public GLMDTO00023(string aCode)
        {
            this.ACODE = aCode;
        }

        public GLMDTO00023(int id, string item, string subItem, string aCode, decimal openingBalance, decimal closingBalance, decimal creditAmount, decimal debitAmount, string dCode, int updateduserid, DateTime updateduserDate)
        {
            this.Id = id;
            this.ITEM = item;
            this.SUBITEM = subItem;
            this.ACODE = aCode;
            this.Opening_bal = openingBalance;
            this.Closing_bal = closingBalance;
            this.Credit_Amount = creditAmount;
            this.Debit_Amount = debitAmount;
            this.DCode = dCode;
            this.UpdatedUserId = updateduserid;
            this.UpdatedDate = updateduserDate;
        }
        public virtual int Id { get; set; }
        public virtual string TYPE { get; set; }
        public virtual string ITEM { get; set; }
        public virtual string SUBITEM { get; set; }
        public virtual int SUBITEM_No { get; set; }
        
        public virtual string ACODE { get; set; }
        public virtual string ACode { get; set; }
        public virtual string ACName { get; set; }
        public virtual string TITLE { get; set; }     
        public virtual string SUBTITLE { get; set; }
        public virtual Nullable<decimal> Opening_bal { get; set; }
        public virtual Nullable<decimal> Closing_bal { get; set; }
        public virtual Nullable<decimal> Credit_Amount { get; set; }
        public virtual Nullable<decimal> Debit_Amount { get; set; }
        public virtual string DCode { get; set; }
        public virtual string Workstation { get; set; }
        public virtual string BranchCode { get; set; }
        public virtual string HACode { get; set; }
        public virtual string AccountType { get; set; }
        public virtual int SrNo { get; set; }
        public virtual int MaxSrNo { get; set; }
        public virtual int NewSubSrNo { get; set; }
        public virtual int NewSrNo { get; set; }
        public virtual int MaxSubSrNo { get; set; }   
        
        public virtual string OtherBankGroupTitle { get; set; }
        

        public virtual System.Nullable<decimal> Balance { get; set; }
        public virtual System.Nullable<decimal> M1 { get; set; }
        public virtual System.Nullable<decimal> M2 { get; set; }
        public virtual System.Nullable<decimal> M3 { get; set; }
        public virtual System.Nullable<decimal> M4 { get; set; }
        public virtual System.Nullable<decimal> M5 { get; set; }
        public virtual System.Nullable<decimal> M6 { get; set; }
        public virtual System.Nullable<decimal> M7 { get; set; }
        public virtual System.Nullable<decimal> M8 { get; set; }
        public virtual System.Nullable<decimal> M9 { get; set; }
        public virtual System.Nullable<decimal> M10 { get; set; }
        public virtual System.Nullable<decimal> M11 { get; set; }
        public virtual System.Nullable<decimal> M12 { get; set; }
        public virtual System.Nullable<decimal> M13 { get; set; }

        public virtual string GroupAcode { get; set; }

        //public string ToDbString()
        //{
        //    return Id + delimiter + TYPE + delimiter + ITEM + delimiter + SUBITEM + delimiter + ACODE + delimiter + TITLE + delimiter +
        //           SUBTITLE + delimiter + Opening_bal + delimiter + Closing_bal + delimiter + Credit_Amount + delimiter + Debit_Amount + delimiter + DCode + delimiter +
        //           Balance + delimiter + M1 + delimiter + M2 + delimiter + M3 + delimiter + M4 + delimiter + M5 + delimiter +
        //           M6 + delimiter + M7 + delimiter + M8 + delimiter + M9 + delimiter + M10 + delimiter + M11 + delimiter +
        //           M12 + delimiter + M13 + delimiter 
        //          + delimiter + CreatedUserId + delimiter + CreatedDate + delimiter + UpdatedUserId + delimiter + UpdatedDate;
        //}
        public string ToDbString(GLMDTO00023 monthlyCoalist)
        {
            return monthlyCoalist.Id + delimiter + monthlyCoalist.TYPE + delimiter + monthlyCoalist.ITEM + delimiter + monthlyCoalist.SUBITEM_No + delimiter + monthlyCoalist.SUBITEM + delimiter + monthlyCoalist.ACODE + delimiter + monthlyCoalist.TITLE + delimiter +
                   monthlyCoalist.SUBTITLE + delimiter + monthlyCoalist.Opening_bal + delimiter + monthlyCoalist.Closing_bal + delimiter + monthlyCoalist.Credit_Amount + delimiter + monthlyCoalist.Debit_Amount + delimiter + monthlyCoalist.DCode + delimiter +
                   monthlyCoalist.Balance + delimiter + monthlyCoalist.M1 + delimiter + monthlyCoalist.M2 + delimiter + monthlyCoalist.M3 + delimiter + monthlyCoalist.M4 + delimiter + monthlyCoalist.M5 + delimiter +
                   monthlyCoalist.M6 + delimiter + monthlyCoalist.M7 + delimiter + monthlyCoalist.M8 + delimiter + monthlyCoalist.M9 + delimiter + monthlyCoalist.M10 + delimiter + monthlyCoalist.M11 + delimiter +
                   monthlyCoalist.M12 + delimiter + monthlyCoalist.M13 + delimiter
                  + delimiter + monthlyCoalist.CreatedUserId + delimiter + monthlyCoalist.CreatedDate + delimiter + monthlyCoalist.UpdatedUserId + delimiter + monthlyCoalist.UpdatedDate;
        }
    }
}
