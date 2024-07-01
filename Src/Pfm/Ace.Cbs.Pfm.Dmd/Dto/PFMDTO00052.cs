using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    /// <summary>
    /// Format Definition DTO Entity
    /// </summary>
    [Serializable]
    public class PFMDTO00052 : EntityBase<PFMDTO00052>
    {
        public PFMDTO00052() { }

        public PFMDTO00052(int id)
        {
            this.Id = id + 1;
        }

        public PFMDTO00052(int formatId, string code, string description, string portionCode, int position, int length, string prefix, string suffix, bool isValue, bool isCheckDigit, bool isIncrement, bool isZeroLeading, bool active, byte[] ts, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId)
        {
            this.FormatId = formatId;
            this.Code = code;
            this.Description = description;
            this.PortionCode = portionCode;
            this.Position = position;
            this.Length = length;
            this.Prefix = prefix;
            this.Suffix = suffix;
            this.IsValue = isValue;
            this.IsCheckDigit = isCheckDigit;
            this.IsIncrement = isIncrement;
            this.IsZeroLeading = isZeroLeading;
            this.Active = active;
            this.TS = ts;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public PFMDTO00052(int id, string maximumValue, bool isZeroLeading, byte[] ts)
        {
            this.Id = id;
            this.MaximumValue = maximumValue;
            this.IsZeroLeading = isZeroLeading;
            this.TS = ts;
        }

        public PFMDTO00052(int formatId, string portionCode)
        {
            this.FormatId = formatId;
            this.PortionCode = portionCode;
        }

        public virtual int FormatId { get; set; }
        public virtual string FormatCode { get; set; }
        public virtual string PortionCode { get; set; }
        public virtual int Position { get; set; }
        public virtual string Code { get; set; }
        public virtual string Description { get; set; }
        public virtual int Length { get; set; }
        public virtual string MaximumValue { get; set; }
        public virtual string Prefix { get; set; }
        public virtual string Suffix { get; set; }
        public virtual bool IsValue { get; set; }
        public virtual bool IsCheckDigit { get; set; }
        public virtual bool IsIncrement { get; set; }
        public virtual bool IsZeroLeading { get; set; }
        public virtual bool IsCheck { get; set; }
    }
}
