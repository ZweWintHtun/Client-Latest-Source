using System;
using System.Collections.Generic;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    /// <summary>
    /// Print Location Header DTO Entity
    /// </summary>
    [Serializable]
    public class PFMDTO00038 : EntityBase<PFMDTO00038>
    {
        public PFMDTO00038() 
        {
            PrintLocationItems = new List<PFMDTO00034>();
        }

        public PFMDTO00038(int id, string code, string position, string printerName, int maximumSize)
        {
            this.Id = id;
            this.Code = code;
            this.Position = position;
            this.PrinterName = printerName;
            this.MaximumLine = maximumSize;
        }

        //Id,Code,Position,PrinterName,MaximumLine,Active,CreatedDate,CreatedUserId,UpdatedDate,UpdatedUserId,TS
        public PFMDTO00038(int id, string code, string position, string printerName, int maximumSize, bool active,
             DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId,byte[] tS)
        {
            this.Id = id;
            this.Code = code;
            this.Position = position;
            this.PrinterName = printerName;
            this.MaximumLine = maximumSize;
            this.Active = active;
            this.CreatedUserId = createdUserId;
            this.CreatedDate = createdDate;
            this.TS = tS;
            this.UpdatedUserId = updatedUserId;
            this.UpdatedDate = updatedDate;
        }

        
        public PFMDTO00038(int id, string code, string position, string printerName, int maximumSize, bool active, int createdUserId, DateTime createdDate, byte[] tS, System.Nullable<int> updatedUserId, System.Nullable<DateTime> updatedDate)
        {
            this.Id = id;
            this.Code = code;
            this.Position = position;
            this.PrinterName = printerName;
            this.MaximumLine = maximumSize;
            this.Active = active;
            this.CreatedUserId = createdUserId;
            this.CreatedDate = createdDate;
            this.TS = tS;
            this.UpdatedUserId = updatedUserId;
            this.UpdatedDate = updatedDate;
        }

        public virtual string Code { get; set; }
        public virtual string Position { get; set; }
        public virtual string PrinterName { get; set; }
        public virtual int MaximumLine { get; set; }
        public virtual IList<PFMDTO00034> PrintLocationItems { get; set; }
    }
}