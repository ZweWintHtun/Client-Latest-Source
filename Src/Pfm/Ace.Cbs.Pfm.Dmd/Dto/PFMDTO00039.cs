using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    /// <summary>
    /// Per_Guan DTO Object
    /// </summary>
    [System.Serializable]
    public class PFMDTO00039 : EntityBase<PFMDTO00039>
    {

        public PFMDTO00039() { }

        public PFMDTO00039(string lno, string acctno, string name, string acctnoSign, string address, string phone, string nrc, string branchCode, string cur, System.Nullable<DateTime> closedate, string guarantorCompanyName) 
        {
            this.LNo = lno;
            this.AccountNo = acctno;
            this.Name = name;
            this.AccountSignature = acctnoSign;
            this.Address = address;
            this.Phone = phone;
            this.NRC = nrc;
            this.BranchCode = branchCode;
            this.CurrencyCode = cur;
            this.ClosedDate = closedate;
            this.GuarantorCompanyName = guarantorCompanyName;
        }

        public virtual string LNo { get; set; }
        public virtual string AccountNo { get; set; }
        public virtual string Name { get; set; }
        public virtual string AccountSignature { get; set; }
        public virtual string Address { get; set; }
        public virtual string Phone { get; set; }
        public virtual string NRC { get; set; }
        public virtual string BranchCode { get; set; }
        public virtual string CurrencyCode { get; set; }
        public virtual Nullable<DateTime> ClosedDate { get; set; }
        public virtual string GuarantorCompanyName { get; set; }
    }
}