using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    /// <summary>
    /// Sub Account Type ORM Object
    /// </summary>
    public class PFMORM00022 : EntityBase<PFMORM00022>
    {
        public virtual string Code { get; set; }
        public virtual string Description { get; set; }
        public virtual string Symbol { get; set; }
        public virtual string AccountSignature { get; set; }
        public virtual int AccountTypeId { get; set; }
        public virtual PFMORM00015 AccountType { get; set; }
    }
}