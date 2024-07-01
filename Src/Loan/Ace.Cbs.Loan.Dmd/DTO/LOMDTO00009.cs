using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{

    /// <summary>
    /// Stock DTO Entity
    /// </summary>
    /// 
    [Serializable]
    public class LOMDTO00009 : Supportfields<LOMDTO00009>
    {
         public LOMDTO00009() { }

                                // Stockno,Name,Active,CreatedDate,CreatedUserId,UpdatedDate,UpdatedUserId,TS
        public LOMDTO00009(string stockno, string name, bool active, DateTime createdDate, int createdUserId, Nullable<DateTime> updatedDate, Nullable<int> updatedUserId, byte[] ts)
        {
            this.StockNo = stockno;
            this.Name = name;
            this.Active = active;
            this.TS = ts;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public LOMDTO00009(string stockno, string name, bool active, byte[] ts, DateTime createdDate, int createdUserId, DateTime updatedDate, int updatedUserId)
        {
            this.StockNo = stockno;
            this.Name = name;
            this.Active = active;
            this.TS = ts;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public LOMDTO00009(string stockno, string name)
        {
            this.StockNo = stockno;
            this.Name = name;
        }

        //public virtual int Id { get; set; } 
        public virtual string StockNo { get; set; }
        public virtual string Name { get; set; }
        public virtual bool IsCheck { get; set; }





    }
}
