using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    // FixRate dto
    [Serializable]
    public class PFMDTO00007 : EntityBase<PFMDTO00007>
    {
        public PFMDTO00007() { }

        public PFMDTO00007(string description, decimal rate, decimal duration)
        {
            this.Description = description;
            this.Rate = rate;
            this.Duration = duration;
        }

        public PFMDTO00007(int id, string desp, System.Nullable<DateTime> dATE_TIME, bool lASTMODIFY, string uSERNO, decimal rate, decimal duration)
        {
            this.Id = id;
            this.Description = desp;
            this.DATE_TIME = dATE_TIME;
            this.IsLastModify = lASTMODIFY;
            this.UserNumber = uSERNO;
            this.Rate = rate;
            this.Duration = duration;
        }

                              //Id,Description,DATE_TIME,IsLastModify,UserNumber,Rate,Duration,Active,CreatedDate,CreatedUserId,UpdatedDate,UpdatedUserId,TS
        public PFMDTO00007(int id, string desp, System.Nullable<DateTime> dATE_TIME, bool lASTMODIFY, string uSERNO, decimal rate, decimal duration, bool active, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId, byte[] tS)
        {
            this.Id = id;
            this.Description = desp;
            this.DATE_TIME = dATE_TIME;
            this.IsLastModify = lASTMODIFY;
            this.UserNumber = uSERNO;
            this.Rate = rate;
            this.Duration = duration;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public PFMDTO00007(int id, string desp, System.Nullable<DateTime> dATE_TIME, bool lASTMODIFY, string uSERNO, decimal rate, decimal duration, bool active, byte[] tS, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId)
        {
            this.Id = id;
            this.Description = desp;
            this.DATE_TIME = dATE_TIME;
            this.IsLastModify = lASTMODIFY;
            this.UserNumber = uSERNO;
            this.Rate = rate;
            this.Duration = duration;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public PFMDTO00007(string description)
        {
            this.Description = description;
        }

        public virtual string Description { get; set; }
        public virtual System.Nullable<DateTime> DATE_TIME { get; set; }
        public virtual System.Nullable<bool> IsLastModify { get; set; }
        public virtual string UserNumber { get; set; }
        public virtual decimal Rate { get; set; }
        public virtual decimal Duration { get; set; }
        public virtual bool IsCheck { get; set; }	
    }
}