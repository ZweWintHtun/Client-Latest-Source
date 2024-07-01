using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMDTO00415 : Supportfields<LOMDTO00415>
    {
        public LOMDTO00415() { }

        public LOMDTO00415(int id,string productCode, string description, string gLCode, bool active, byte[] ts, DateTime createdDate, int createdUserId, DateTime updatedDate, int updatedUserId)
        {
            this.Id = id;
            this.ProductCode = productCode;
            this.Description = description;
            this.RelatedGLACode = gLCode;
            this.Active = active;
            this.TS = ts;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public LOMDTO00415(int id,string productCode, string description, string gLCode)
        {
            this.Id = id;
            this.ProductCode = productCode;
            this.Description = description;
            this.RelatedGLACode = gLCode;
        }


        public virtual int Id{ get; set; }
        public virtual string ProductCode { get; set; }
        public virtual string Description { get; set; }
        public virtual string RelatedGLACode { get; set; }
        public virtual bool IsCheck { get; set; }
        public virtual string ACode { get; set; }
        public virtual string ACName { get; set; }

    }
}
