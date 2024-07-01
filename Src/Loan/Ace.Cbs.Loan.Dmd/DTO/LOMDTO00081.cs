using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{   ////// Stock /////
    [Serializable]
    public class LOMDTO00081 : EntityBase<LOMDTO00081>
    {
        public LOMDTO00081() { }
        public LOMDTO00081(string groupCode, string subCode, bool active, DateTime createdDate, int createdUserId, DateTime updatedDate, int updatedUserId)
        {
            GroupCode = groupCode;
            SubCode = subCode;
            Active = active;
            CreatedDate = createdDate;
            CreatedUserId = createdUserId;
            UpdatedDate = updatedDate;
            UpdatedUserId = updatedUserId;
        }
        public string GroupCode { get; set; }
        public string SubCode { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UpdatedUserId { get; set; }
    
    }
}
