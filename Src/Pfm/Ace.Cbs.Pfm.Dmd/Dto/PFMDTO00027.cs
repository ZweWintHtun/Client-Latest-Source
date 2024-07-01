using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    //Currency DTO
    [Serializable]
    public class PFMDTO00027 : Supportfields<PFMDTO00027>
    {
        public PFMDTO00027() { }

        public PFMDTO00027(string currencyCode, string symbol) 
        {
            this.Cur = currencyCode;
            this.Symbol = symbol;
        }

        public PFMDTO00027(string currency)
        {
            this.Cur = currency;
        }

        public PFMDTO00027(string cur, string desp, string symbol, string inwordDesp1, string inwordDesp2, bool isHomeCur, string aCode)
        {
            this.Cur = cur;
            this.Description = desp;
            this.Symbol = symbol;
            this.FirstInWord = inwordDesp1;
            this.SecondInWord = inwordDesp2;
            this.IsHomeCur = isHomeCur;
            this.CodeForCOA = aCode;
        }

        public PFMDTO00027(string cur, string desp, string symbol, string inwordDesp1, string inwordDesp2, bool isHomeCur, string aCode, bool active, byte[] tS, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId)
        {
            this.Cur = cur;
            this.Description = desp;
            this.Symbol = symbol;
            this.FirstInWord = inwordDesp1;
            this.SecondInWord = inwordDesp2;
            this.IsHomeCur = isHomeCur;
            this.CodeForCOA = aCode;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        // Primary Key
        public virtual string Cur { get; set; }

        public virtual string Description { get; set; }
        public virtual string Symbol { get; set; }
        public virtual string FirstInWord { get; set; }
        public virtual string SecondInWord { get; set; }
        public virtual bool IsHomeCur { get; set; }
        public virtual decimal Month1Ammount { get; set; }
        public virtual decimal Month2Ammount { get; set; }
        public virtual decimal Month3Ammount { get; set; }
        public virtual decimal Month4Ammount { get; set; }
        public virtual decimal Month5Ammount { get; set; }
        public virtual decimal Month6Ammount { get; set; }
        public virtual decimal Month7Ammount { get; set; }
        public virtual decimal Month8Ammount { get; set; }
        public virtual decimal Month9Ammount { get; set; }
        public virtual decimal Month10Ammount { get; set; }
        public virtual decimal Month11Ammount { get; set; }
        public virtual decimal Month12Ammount { get; set; }
        public virtual decimal Month13Ammount { get; set; }

        // Current Account Opening
        public virtual string CodeForCOA { get; set; }
        public virtual bool IsCheck { get; set; }
    }
}