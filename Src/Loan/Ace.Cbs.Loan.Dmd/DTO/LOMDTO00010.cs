using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{

    /// <summary>
    /// KStock DTO Entity
    /// </summary>
    /// 
    [Serializable]
    public class LOMDTO00010 : Supportfields<LOMDTO00010>
    {
        
         public LOMDTO00010() { }

                                // KStockno,Desp,Active,CreatedDate,CreatedUserId,UpdatedDate,UpdatedUserId,TS
        public LOMDTO00010(string kstockno, string desp, bool active, DateTime createdDate, int createdUserId, Nullable<DateTime> updatedDate, Nullable<int> updatedUserId, byte[] ts)
        {
            this.KStockNo = kstockno;
            this.Desp = desp;
            this.Active = active;
            this.TS = ts;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public LOMDTO00010(string kstockno, string desp, bool active, byte[] ts, DateTime createdDate, int createdUserId, DateTime updatedDate, int updatedUserId)
        {
            this.KStockNo = kstockno;
            this.Desp = desp;
            this.Active = active;
            this.TS = ts;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public LOMDTO00010(string kstockno, string desp)
        {
            this.KStockNo = kstockno;
            this.Desp = desp;
        }

        //public virtual int Id { get; set; } 
        public virtual string KStockNo { get; set; }
        public virtual string Desp { get; set; }
        public virtual bool IsCheck { get; set; }




    }
}
