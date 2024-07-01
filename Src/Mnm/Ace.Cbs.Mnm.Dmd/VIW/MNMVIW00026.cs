using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Mnm.Dmd
{
    /// <summary>
    /// VW_CURLIST_ALL
    /// </summary>
    /// 
     [Serializable]
    public class MNMVIW00026 : Supportfields<MNMVIW00026>
    {
         public MNMVIW00026() { }

        public virtual int Id { get; set; }
        public virtual string AccountNo { get; set; }
        public virtual string Name { get; set; }
        public virtual string CustomerID { get; set; }
        public virtual string Address { get; set; }
        public virtual string Township_Code { get; set; }
        public virtual string City_Code { get; set; }
        public virtual string State_Code { get; set; }
        public virtual string Fax { get; set; }
        public virtual string PhoneNo { get; set; }
        public virtual DateTime OpenDate { get; set; }
        public virtual string AccountSign { get; set; }
        public virtual string NRC { get; set; }
        public virtual string Description { get; set; }
        public virtual string Business { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Currency { get; set; }

    }
}
