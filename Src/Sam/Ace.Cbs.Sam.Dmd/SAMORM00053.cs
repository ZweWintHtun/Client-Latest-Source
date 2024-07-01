using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Sam.Dmd
{
    // Nationality_Code entity
    [Serializable]
    public class SAMORM00053 : EntityBase<SAMORM00053>
    {

        public SAMORM00053() { }

        //primary key
        public virtual string Nationality_Code { get; set; }

        public virtual string Description { get; set; }
        public virtual string UserNo { get; set; }
        public virtual System.Nullable<DateTime> Date_Time { get; set; }
        public virtual System.Nullable<DateTime> EditDate_Time { get; set; }
        public virtual string EditUser { get; set; }
        public virtual System.Nullable<decimal> EditType { get; set; }
        public virtual System.Nullable<bool> Defaults { get; set; }

    }
}
