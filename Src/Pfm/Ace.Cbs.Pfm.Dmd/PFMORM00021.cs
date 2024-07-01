using System;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    // FAOF entity
    [Serializable]
    public class PFMORM00021 : Supportfields<PFMORM00021>
    {
        public PFMORM00021() { }

        public virtual int Id { get; set; }
        public virtual Nullable<DateTime> OpenDate { get; set; }
        public virtual string UserNo { get; set; }
        public virtual string LastReceiptNo { get; set; }
        public virtual string Name { get; set; }
        public virtual string GuardianName { get; set; }
        public virtual string GuardianNRC { get; set; }
        public virtual string NRC { get; set; }
        public virtual string AccountSignature { get; set; }
        public virtual Nullable<DateTime> DateOfBirth { get; set; }
        public virtual string JoinType { get; set; }
        public virtual string Address { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Fax { get; set; }
        public virtual string Email { get; set; }
        public virtual string Business { get; set; }
        public virtual Nullable<DateTime> AcceptDate { get; set; }
        public virtual Nullable<DateTime> CloseDate { get; set; }
        public virtual int NoOfPersonSign { get; set; }
        public virtual int SerialOfCustomer { get; set; }

        public virtual string FledgerAccountNo { get; set; }
        public virtual string CustomerId { get; set; }
        public virtual string SourceBranchCode { get; set; }
        public virtual string CurrencyCode { get; set; }
        public virtual string City_Code { get; set; }
        public virtual string Township_Code { get; set; }
        public virtual string State_Code { get; set; }
        public virtual string EStatus { get; set; }

        // Fledger Account No Relation
        public virtual PFMORM00023 Fledger{ get; set; }

        // Source Branch Relation
        public virtual Branch Branch { get; set; }

        // Currency Relation
        public virtual CurrencyDTO Currency { get; set; }

        // CustomerId Relation
        public virtual PFMORM00001 Customer { get; set; }

        // Township Code Relation
        public virtual Township TownshipCode { get; set; }

        // StateCode Relation
        public virtual State StateCode { get; set; }

        // CityCode Relation
        public virtual City CityCode { get; set; }
    }
}