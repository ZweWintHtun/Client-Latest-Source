using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    /// <summary>
    /// CloseBal DTO
    /// </summary>
    [Serializable]
    public class PFMDTO00002 : EntityBase<PFMDTO00002>
    {
        public PFMDTO00002() { }

        public PFMDTO00002(decimal closebalance)
        {
            this.CloseBalance = closebalance;
        }

        public PFMDTO00002(decimal closebalance,string chequeNo)
        {
            this.CloseBalance = closebalance;
            this.CheckNo = chequeNo;
        }

        public virtual string AccountNo { get; set; }
        public virtual string Name { get; set; }
        public virtual decimal CloseBalance { get; set; }
        public virtual DateTime CloseDate { get; set; }
        public virtual string CheckNo { get; set; }
        public virtual string AccountSign { get; set; }
        public virtual string UserNo { get; set; }
        public virtual string Cur { get; set; }
        public virtual string SourceBranch { get; set; }
    }
}