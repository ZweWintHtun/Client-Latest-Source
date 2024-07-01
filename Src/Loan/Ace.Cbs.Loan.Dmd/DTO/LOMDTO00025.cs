using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    /// <summary>
    /// Business DTO Entity
    /// </summary>
    /// 
    [Serializable]
    public class LOMDTO00025
    {
        public LOMDTO00025() { }

       
         public string RepaymentNo
         {
             get;set;
             
         }

         public string LoanNo
         {
             get;
             set;
         }
         public string AccountNo
         {
             get;
             set;
         }

         public string TypeOfSecurity
         {
             get;
             set;
         }
         public decimal TotalOutstanding
         {
             get;
             set;
         }

         public decimal RepaymentAmount
         {
             get;
             set;
         }

         public decimal TotalInterest
         {
             get;
             set;
         }



        //                        //Id,Code,Description,Active,CreatedDate,CreatedUserId,UpdatedDate,UpdatedUserId,TS
        //public LOMDTO00001(string code, string description, bool active, DateTime createdDate, int createdUserId, Nullable<DateTime> updatedDate, Nullable<int> updatedUserId, byte[] ts)
        //{            
        //    this.Code = code;
        //    this.Description = description;
        //    this.Active = active;
        //    this.TS = ts;
        //    this.CreatedDate = createdDate;
        //    this.CreatedUserId = createdUserId;
        //    this.UpdatedDate = updatedDate;
        //    this.UpdatedUserId = updatedUserId;
        //}

        //public LOMDTO00001(string code, string description, bool active, byte[] ts, DateTime createdDate, int createdUserId, DateTime updatedDate, int updatedUserId)
        //{            
        //    this.Code = code;
        //    this.Description = description;
        //    this.Active = active;
        //    this.TS = ts;
        //    this.CreatedDate = createdDate;
        //    this.CreatedUserId = createdUserId;
        //    this.UpdatedDate = updatedDate;
        //    this.UpdatedUserId = updatedUserId;
        //}

        //public LOMDTO00001(string code, string description)
        //{
        //    this.Code = code;
        //    this.Description = description;
        //}

        ////public virtual int Id { get; set; } 
        //public virtual string Code { get; set; }
        //public virtual string Description { get; set; }
        //public virtual bool IsCheck { get; set; }
    }
}
