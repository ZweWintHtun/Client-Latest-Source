using System;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    //SAOF entity
    [Serializable] 
    public class PFMORM00016 : Supportfields<PFMORM00016>
    {
        public PFMORM00016() { }

        // primary key
        public virtual int Id { get; set; }
        public virtual string CledgerAccountNo { get; set; }
        public virtual string Name { get; set; }
        public virtual string Name3 { get; set; }
        public virtual string AccountSign { get; set; }
        public virtual string Address { get; set; }
        public virtual string PhoneNo { get; set; }
        public virtual string Fax { get; set; }
        public virtual string NRC { get; set; }
        public virtual string GuardianshipNRC { get; set; }
        public virtual Nullable<DateTime> DateofBirth { get; set; }
        public virtual string Email { get; set; }
        public virtual string Business { get; set; }
        public virtual string JoinType { get; set; }
        public virtual Nullable<DateTime> OPENDATE { get; set; }
        public virtual Nullable<DateTime> AcceptedDate { get; set; }
        public virtual string EStatus { get; set; }
        public virtual Nullable<DateTime> CloseDate { get; set; }
        public virtual System.Nullable<int> NoOfPersonSign { get; set; }
        public virtual System.Nullable<int> SerialofCustomer { get; set; }
        public virtual string USERNO { get; set; }

        public virtual string SourceBranchCode { get; set; }
        public virtual string CurrencyCode { get; set; }
        public virtual string City_Code { get; set; }
        public virtual string Township_Code { get; set; }
        public virtual string State_Code { get; set; }
        public virtual string Customer_Id { get; set; }

        // Source Branch Relation
        public virtual Branch Branch { get; set; }

        //Cledger Account No relation
        public virtual PFMORM00028 Cledger { get; set; }

        // Currency Relation
        public virtual CurrencyDTO Currency { get; set; }

        // CustomerId Relation
        public virtual PFMORM00001 Customer { get; set; }

        // City Code Relation
        public virtual City CityCode { get; set; }

        // Town Ship Relation
        public virtual Township TownshipCode { get; set; }

        // State Code Relation
        public virtual State StateCode { get; set; }
    }
}