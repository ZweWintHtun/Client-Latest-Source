using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    // Rate File dto
    [Serializable]
    public class PFMDTO00009 : Supportfields<PFMDTO00009>
    {
        public PFMDTO00009() { }

        public PFMDTO00009(string code, string desp, DateTime dATE_TIME, bool lASTMODIFY, string uSERNO, decimal rate, decimal duration)
        {
            this.Code = code;
            this.Description = desp;
            this.DATE_TIME = dATE_TIME;
            this.LASTMODIFY = lASTMODIFY;
            this.USERNO = uSERNO;
            this.Rate = rate;
            this.Duration = duration;
        }

                     //Code,Description,DATE_TIME,LASTMODIFY,USERNO,Rate,Duration,Active,CreatedDate,CreatedUserId,UpdatedDate,UpdatedUserId,TS
        public PFMDTO00009(string code, string desp, DateTime dATE_TIME, bool lASTMODIFY, string uSERNO, decimal rate,
            decimal duration, bool active, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId, byte[] tS)
        {
            this.Code = code;
            this.Description = desp;
            this.DATE_TIME = dATE_TIME;
            this.LASTMODIFY = lASTMODIFY;
            this.USERNO = uSERNO;
            this.Rate = rate;
            this.Duration = duration;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public PFMDTO00009(string code, string desp, DateTime dATE_TIME, bool lASTMODIFY, string uSERNO, decimal rate, decimal duration, bool active, byte[] tS, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId)
        {
            this.Code = code;
            this.Description = desp;
            this.DATE_TIME = dATE_TIME;
            this.LASTMODIFY = lASTMODIFY;
            this.USERNO = uSERNO;
            this.Rate = rate;
            this.Duration = duration;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public virtual string Code { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime DATE_TIME { get; set; }
        public virtual bool LASTMODIFY { get; set; }
        public virtual string USERNO { get; set; }

        public virtual decimal Rate { get; set; }
        public virtual decimal Duration { get; set; }
        public virtual bool IsCheck { get; set; }
    }
}