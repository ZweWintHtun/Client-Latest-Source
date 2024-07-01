using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    /// <summary>
    /// CS99#00 DTO
    /// </summary>
    [Serializable]
    public class PFMDTO00036: EntityBase<PFMDTO00036>
    {
        public PFMDTO00036()
        {
        }

        public PFMDTO00036(decimal balance, string currencycode, DateTime datetime, decimal homeamount, string sourcebranchcode)
        {
            this.Balance = balance;
            this.CurrencyCode = currencycode;
            this.Date_Time = datetime;
            this.HomeAmount = homeamount;
            this.SourceBranchCode = sourcebranchcode;
        }


        public PFMDTO00036(decimal balance)//, string currencycode, DateTime datetime, decimal homeamount, string sourcebranchcode)
        {
            this.Balance = balance;
           
        }
        public PFMDTO00036(int maxId)
        {
            this.Id = maxId;
        }

      //  public int Id { get; set; }
        public string CurrencyCode { get; set; }
        public System.Nullable<decimal> Balance { get; set; }
        public System.Nullable<DateTime> Date_Time { get; set; }
        public System.Nullable<decimal> HomeAmount { get; set; }
        public string SourceBranchCode { get; set; }
       // public string UniqueID { get; set; }
        
    }
}
