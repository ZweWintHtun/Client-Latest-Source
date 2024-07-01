using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;
using Ace.Windows.Admin.DataModel;
namespace Ace.Cbs.Sam.Dmd
{
    // NRCCode entity
    [Serializable]
    public class SAMORM00054 : EntityBase<SAMORM00054>
    {

        public SAMORM00054() { }


        //primary key
        public virtual string TownshipCode { get; set; }      
        public virtual string TownshipDesp { get; set; }
        public virtual string StateCode { get; set; } 

        //public virtual State State { get; set; }

    }
}
