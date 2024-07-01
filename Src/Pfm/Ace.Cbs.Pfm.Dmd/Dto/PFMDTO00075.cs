using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{    
    [Serializable]
    public class PFMDTO00075 : EntityBase<PFMDTO00075>
    {
        /// <summary>
        /// RateInfo DTO Entity
        /// </summary>
        public PFMDTO00075() { }

        public PFMDTO00075(decimal rate, string denoRate)
        {
            this.Rate = rate;
            this.DenoRate = denoRate;
        }

        public PFMDTO00075(int id, decimal rate, string denoRate)
        {
            this.Id = id;
            this.Rate = rate;
            this.DenoRate = denoRate;
        }

        //Id,CurrencyCode,RateType,Rate,DenoRate,RegisterDate,LastModify,ToCurrencyCode,Active,CreatedDate,CreatedUserId,UpdatedDate,UpdatedUserId,TS
        public PFMDTO00075(int id, string cur, string rateType, decimal rate, string denoRate, DateTime rDate, bool lastModify,
            string toCur, bool active, int createdUserId, DateTime createdDate, System.Nullable<int> updatedUserId, System.Nullable<DateTime> updatedDate, byte[] tS)
        {
            this.Id = id;
            this.CurrencyCode = cur;
            this.RateType = rateType;
            this.Rate = rate;
            this.DenoRate = denoRate;
            this.RegisterDate = rDate;
            this.LastModify = lastModify;
            this.ToCurrencyCode = toCur;
            this.Active = active;
            this.TS = tS;
            this.CreatedUserId = createdUserId;
            this.CreatedDate = createdDate;
            this.UpdatedUserId = updatedUserId;
            this.UpdatedDate = updatedDate;
        }
        /// <summary>
        /// Constructor for DataVersion
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cur"></param>
        /// <param name="rateType"></param>
        /// <param name="rate"></param>
        /// <param name="denoRate"></param>
        /// <param name="rDate"></param>
        /// <param name="lastModify"></param>
        /// <param name="toCur"></param>
        /// <param name="active"></param>
        /// <param name="createdUserId"></param>
        /// <param name="createdDate"></param>
        /// <param name="updatedUserId"></param>
        /// <param name="updatedDate"></param>
        /// <param name="tS"></param>
        /// //Id,CurrencyCode,RateType,Rate,DenoRate,RegisterDate,LastModify,ToCurrencyCode,Active,CreatedDate,CreatedUserId,UpdatedDate,UpdatedUserId,TS
        public PFMDTO00075(int id, string cur, string rateType, decimal rate, string denoRate, DateTime rDate, bool lastModify,
           string toCur, bool active, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId, byte[] tS)
        {
            this.Id = id;
            this.CurrencyCode = cur;
            this.RateType = rateType;
            this.Rate = rate;
            this.DenoRate = denoRate;
            this.RegisterDate = rDate;
            this.LastModify = lastModify;
            this.ToCurrencyCode = toCur;
            this.Active = active;
            this.TS = tS;
            this.CreatedUserId = createdUserId;
            this.CreatedDate = createdDate;
            this.UpdatedUserId = updatedUserId;
            this.UpdatedDate = updatedDate;
        }
        public PFMDTO00075(int id, string cur, string rateType, decimal rate, string denoRate, DateTime rDate, bool lastModify, string toCur, bool active, byte[] tS, int createdUserId, DateTime createdDate, System.Nullable<int> updatedUserId, System.Nullable<DateTime> updatedDate)
        {
            this.Id = id;
            this.CurrencyCode = cur;
            this.RateType = rateType;
            this.Rate = rate;
            this.DenoRate = denoRate;
            this.RegisterDate = rDate;
            this.LastModify = lastModify;
            this.ToCurrencyCode = toCur;
            this.Active = active;
            this.TS = tS;
            this.CreatedUserId = createdUserId;
            this.CreatedDate = createdDate;
            this.UpdatedUserId = updatedUserId;
            this.UpdatedDate = updatedDate;
        }

        public PFMDTO00075(decimal rate)
        {
            this.Rate = rate;
        }

        public PFMDTO00075(int id)
        {
            this.Id = id;
        }

        public virtual string CurrencyCode { get; set; }
        public virtual string RateType { get; set; }
        public virtual decimal Rate { get; set; }
        public virtual string DenoRate { get; set; }
        public virtual DateTime RegisterDate { get; set; }
        public virtual bool LastModify { get; set; }
        public virtual string ToCurrencyCode { get; set; }
        public virtual bool IsCheck { get; set; }
        public virtual string Status { get; set; }
    }
}