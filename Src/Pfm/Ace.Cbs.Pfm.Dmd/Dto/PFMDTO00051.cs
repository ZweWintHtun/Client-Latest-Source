using System;
using System.Collections.Generic;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    /// <summary>
    /// FormatDefinition DTO Entity
    /// </summary>
    [Serializable]
    public class PFMDTO00051 : EntityBase<PFMDTO00051>
    {
        public PFMDTO00051()
        {
            FormatDefinitions = new List<PFMDTO00052>();
        }

        public PFMDTO00051(int id, string code, string description, int codeFormat)
        {
            this.Id = id;
            this.Code = code;
            this.Description = description;
            this.CodeFormat = codeFormat;
        }

        public PFMDTO00051(int id, string code, string description, int codeFormat, bool active, byte[] tS, DateTime createdDate, int createdUserId, DateTime updatedDate, int updatedUserId)
        {
            this.Id = id;
            this.Code = code;
            this.Description = description;
            this.CodeFormat = codeFormat;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public virtual string Code { get; set; }
        public virtual string Description { get; set; }
        public virtual int CodeFormat { get; set; }
        public bool IsCheck { get; set; }
        public virtual IList<PFMDTO00052> FormatDefinitions { get; set; }
    }
}
