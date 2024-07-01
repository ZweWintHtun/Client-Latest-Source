using System;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.DataModel;
namespace Ace.Cbs.Mnm.Dmd
{
    /// <summary>
    /// VW_FAOF_Name
    /// </summary>
    /// 
    [Serializable]
    public class MNMVIW00032 : EntityBase<MNMVIW00032>
    {
        public virtual string AccountNo { get; set; }
        public virtual string Name { get; set; }
        public virtual string CustomerId { get; set; }
        public virtual string Address { get; set; }
        public virtual string PhoneNo { get; set; }
        public virtual string FaxNo { get; set; }
        public virtual DateTime OpenDate { get; set; }
        public virtual string AccountSign { get; set; }
        public virtual string NRC { get; set; }
        public virtual string Description { get; set; }
        public virtual string AccountType { get; set; }
    }
}
