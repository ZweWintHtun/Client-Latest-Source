using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    /// <summary>
    /// Print Location Item DTO Entity
    /// </summary>
    [Serializable]
    public class PFMDTO00034 : EntityBase<PFMDTO00034>
    {
        public PFMDTO00034() 
        { }

        public PFMDTO00034(int id, int printLocationHeaderId, string fontSize, int xLocation, int yLocation, int lineNo)
        {
            this.Id = id;
            this.PrintLocationHeaderId = printLocationHeaderId;
            this.FontSize = fontSize;
            this.XLocation = xLocation;
            this.YLocation = yLocation;
            this.LineNumber = lineNo;
        }

        public PFMDTO00034(int id, string fontSize, int xLocation, int yLocation, int alignment, int printLocationHeaderId, int length, int lineNo)
        {
            this.Id = id;
            this.FontSize = fontSize;
            this.XLocation = xLocation;
            this.YLocation = yLocation;
            this.Alignment = alignment;
            this.PrintLocationHeaderId = printLocationHeaderId;
            this.Length = length;
            this.LineNumber = lineNo;
        }

        //Id,PrintLocationHeaderId,FontSize,XLocation,YLocation,LineNumber,Alignment,Length,Active,CreatedDate,CreatedUserId,
        //UpdatedDate,UpdatedUserId,TS
        public PFMDTO00034(int id, int printLocationHeaderId, string fontSize, int xLocation, int yLocation, int lineNo,int alignment,
           int length, bool active, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate,System.Nullable<int> updatedUserId, byte[] tS)
        {
            this.Id = id;
            this.PrintLocationHeaderId = printLocationHeaderId;
            this.FontSize = fontSize;
            this.XLocation = xLocation;
            this.YLocation = yLocation;
            this.LineNumber = lineNo;
            this.Alignment = alignment;
            this.Length = length;
            this.Active = active;
            this.CreatedUserId = createdUserId;
            this.CreatedDate = createdDate;
            this.TS = tS;
            this.UpdatedUserId = updatedUserId;
            this.UpdatedDate = updatedDate;
        }
        
        public PFMDTO00034(int id, int printLocationHeaderId, string fontSize, int xLocation, int yLocation, int lineNo, bool active, int createdUserId, DateTime createdDate, byte[] tS, System.Nullable<int> updatedUserId, System.Nullable<DateTime> updatedDate)
        {
            this.Id = id;
            this.PrintLocationHeaderId = printLocationHeaderId;
            this.FontSize = fontSize;
            this.XLocation = xLocation;
            this.YLocation = yLocation;
            this.LineNumber = lineNo;
            this.Active = active;
            this.CreatedUserId = createdUserId;
            this.CreatedDate = createdDate;
            this.TS = tS;
            this.UpdatedUserId = updatedUserId;
            this.UpdatedDate = updatedDate;
        }
        public virtual int PrintLocationHeaderId { get; set; }
        public virtual PFMDTO00038 PrintLocationHeader { get; set; }
        public virtual string FontSize { get; set; }
        public virtual int XLocation { get; set; }
        public virtual int YLocation { get; set; }
        public virtual int Alignment { get; set; }
        public virtual int Length { get; set; }
        public virtual int LineNumber { get; set; }
    }
}