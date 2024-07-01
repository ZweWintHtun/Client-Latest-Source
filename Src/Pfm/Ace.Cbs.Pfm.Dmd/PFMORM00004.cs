using System;
using Ace.Windows.Core.DataModel;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    // Occupation_Code entity
    [Serializable]
    public class PFMORM00004 : Supportfields<PFMORM00004>
    {
        public PFMORM00004() { }

        //primary key
        public virtual string Occupation_Code { get; set; }

        public virtual string Description { get; set; }
        public virtual string UserNo { get; set; }
        public virtual System.Nullable<DateTime> Date_Time { get; set; }
        public virtual System.Nullable<DateTime> EditDate_Time { get; set; }
        public virtual string EditUser { get; set; }
        public virtual System.Nullable<decimal> EditType { get; set; }
        public virtual System.Nullable<bool> Defaults { get; set; }
        public virtual User CreatedUser { get; set; }
      
    }
}