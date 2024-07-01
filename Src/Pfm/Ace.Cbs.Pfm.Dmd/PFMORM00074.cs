using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{    
    [Serializable]
    public class PFMORM00074 : EntityBase<PFMORM00074>
    {
        /// <summary>
        /// RateInfo ORM Entity
        /// </summary>
        public PFMORM00074() { }

       

        public virtual string CurrencyCode { get; set; }
        public virtual string RateType { get; set; }
        public virtual decimal Rate { get; set; }
        public virtual string DenoRate { get; set; }
        public virtual DateTime RegisterDate { get; set; }
        public virtual bool LastModify { get; set; }
        public virtual string ToCurrencyCode { get; set; }
    }
}