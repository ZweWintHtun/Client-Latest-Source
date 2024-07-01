using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    /// <summary>
    /// AGLoanProductTypeItem ORM Entity
    /// </summary>
    [Serializable]
    public class LOMORM00075 : EntityBase<LOMORM00075>
    {
        public LOMORM00075() { }

        public virtual string AGLoanProductTypeItemId { get; set; }
        public virtual string ProductCode { get; set; }
        public virtual string SeasonCode { get; set; }
        public virtual string UMCode { get; set; }
        public virtual string SDay { get; set; }
        public virtual string SMonth { get; set; }
        public virtual string EDay { get; set; }
        public virtual string EMonth { get; set; }
        public virtual string DeadLineDay { get; set; }
        public virtual string DeadLineMonth { get; set; }
        public virtual string USERNO { get; set; }
        public virtual DateTime DATE_TIME { get; set; }
    }
}
