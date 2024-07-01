using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{   ////// InstallmentTypes /////
    [Serializable]
    public class LOMDTO00083 : EntityBase<LOMDTO00083>
    {
        public LOMDTO00083() { }
        public LOMDTO00083(string name, int noOfDay, int noOfMonth, bool active, DateTime createdDate, int createdUserId, DateTime updatedDate, int updatedUserId)
        {
            Name = name;
            NoOfDay = noOfDay;
            NoofMonth = NoofMonth;
            Active = active;
            CreatedDate = createdDate;
            CreatedUserId = createdUserId;
            UpdatedDate = updatedDate;
            UpdatedUserId = updatedUserId;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int NoOfDay { get; set; }
        public int NoofMonth { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UpdatedUserId { get; set; }
    }
}
