using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    /// <summary>
    /// Farm Loans ORM Entity
    /// </summary>
    [Serializable]
    public class LOMORM00078 : Supportfields<LOMORM00078>
    {
        public LOMORM00078() { }

        public virtual string Lno { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual string AType { get; set; }
        public virtual string LoanType { get; set; }
        public virtual string LoanProductType { get; set; }
        public virtual Nullable<DateTime> SDate { get; set; }
        public virtual Nullable<decimal> SAmt { get; set; }
        public virtual string Budget { get; set; }
        public virtual Nullable<DateTime> CloseDate { get; set; }
        public virtual Nullable<DateTime> ExpireDate { get; set; }
        public virtual Nullable<decimal> FirstSAmt { get; set; }
        public virtual Nullable<DateTime> LastIntDate { get; set; }
        public virtual Nullable<decimal> IntRate { get; set; }
        public virtual Nullable<decimal> Penalties { get; set; }
        public virtual bool Vourched { get; set; }
        public virtual Nullable<DateTime> VourchedDate { get; set; }
        public virtual string Name { get; set; }
        public virtual string FatherName { get; set; }
        public virtual string NRC { get; set; }
        public virtual string Village { get; set; }
        public virtual string Township { get; set; }
        public virtual string Address { get; set; }
        public virtual string FarmName { get; set; }
        public virtual string LandNo { get; set; }
        public virtual string LandType { get; set; }
        public virtual string SeasonType { get; set; }
        public virtual string CropType { get; set; }
        public virtual string BusinessType { get; set; }
        public virtual string GroupNo { get; set; }
        public virtual string StartPeriod { get; set; }
        public virtual string EndPeriod { get; set; }
        public virtual Nullable<DateTime> WithdrawDate { get; set; }
        public virtual Nullable<decimal> LoanAmtPerAcre { get; set; }
        public virtual Nullable<decimal> TotalAcre { get; set; }
        public virtual byte[] FarmSignature { get; set; }
        public virtual byte[] Signature { get; set; }
        public virtual string Remark { get; set; }
        public virtual string ACSign { get; set; }
        public virtual string UniqueId { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }
        public virtual LOMORM00085 FarmLi { get; set; }

        #region LoanRepayment
        public virtual string VrNo { get; set; }
        public virtual decimal RepaymentAmount { get; set; }
        #endregion
    }
}
