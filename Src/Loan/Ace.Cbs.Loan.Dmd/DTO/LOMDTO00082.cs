using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{   ////// StockGroup/////
    [Serializable]
    public class LOMDTO00082 : EntityBase<LOMDTO00082>
    {
        public LOMDTO00082() { }
        public LOMDTO00082(string groupCode, string description,bool active, DateTime createdDate, int createdUserId, DateTime updatedDate, int updatedUserId,string relatedGLAcode,string acname)
        {
            GroupCode = groupCode;
            Description = description;
            Active = active;
            CreatedDate = createdDate;
            CreatedUserId = createdUserId;
            UpdatedDate = updatedDate;
            UpdatedUserId = updatedUserId;
            RelatedGLACode = relatedGLAcode;
            ACName = acname;
        }
        public string GroupCode { get; set; }
        public string Description { get; set; }
        public string PreFix { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UpdatedUserId { get; set; }
        public string RelatedGLACode { get; set; }
        public string ACName { get; set; }

    }
}
