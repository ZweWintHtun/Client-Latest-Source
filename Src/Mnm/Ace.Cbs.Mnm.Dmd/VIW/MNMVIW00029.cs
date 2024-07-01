using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Mnm.Dmd
{
    /// <summary>
    /// VW_SAVLIST_ALL
    /// </summary>
    /// 
    [Serializable]
    public class MNMVIW00029 : Supportfields<MNMVIW00029>
    {
         public MNMVIW00029() { }

        public virtual int Id { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string AccountNo { get; set; }
        public virtual string Name { get; set; }
        public virtual string CustomerID { get; set; }
        public virtual Nullable<DateTime> DateOfBirth { get; set; }
        public virtual string FatherName { get; set; }
        public virtual string GuardianshipName { get; set; }
        public virtual string GuardianshipNRC { get; set; }
        public virtual string Address { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Fax { get; set; }
        public virtual DateTime OpenDate { get; set; }
        public virtual string AccountSign { get; set; }
        public virtual string NRC { get; set; }
        public virtual string Description { get; set; }
    }
}
