using System;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    /// <summary>
    /// CAOF Entity
    /// </summary>
    [Serializable]
    public class PFMORM00017 : Supportfields<PFMORM00017>
    {
        public PFMORM00017() { }

        public virtual int Id { get; set; }
        public virtual string CledgerAccountNo { get; set; }
        public virtual string Name { get; set; }
        public virtual string AccountSign { get; set; }
        public virtual string Address { get; set; }
        public virtual string PhoneNo { get; set; }
        public virtual string Fax { get; set; }
        public virtual string Email { get; set; }
        public virtual string Business { get; set; }
        public virtual string NRC { get; set; }
        public virtual string NAMESP { get; set; }
        public virtual string ESTATUS { get; set; }
        public virtual string CODE { get; set; }
        public virtual DateTime OPENDATE { get; set; }
        public virtual string USERNO { get; set; }
        public virtual string SourceBranchCode { get; set; }
        public virtual string CurrencyCode { get; set; }
        public virtual string JoinType { get; set; }
        public virtual System.Nullable<DateTime> AcceptedDate { get; set; }
        public virtual string CustomerID { get; set; }
        public virtual string City_Code { get; set; }
        public virtual string Township_Code { get; set; }
        public virtual string State_Code { get; set; }
    //    public virtual Int32 NoPSign { get; set; }
        public virtual System.Nullable<DateTime> CloseDate { get; set; }
        public virtual System.Nullable<int> NoOfPersonSign { get; set; }
        public virtual System.Nullable<int> SerialofCustomer { get; set; }

        //Added by HWKO (15-Aug-2017)
        public virtual string CpnyRegNo { get; set; }
        public virtual Nullable<DateTime> CpnyRegDate { get; set; }
        public virtual Nullable<DateTime> CpnyRegExpDate { get; set; }
        //End Region
        
        //Source Branch Relation
        public virtual Branch Branch { get; set; }
        
        //Cledger Account No relation
        public virtual PFMORM00028 Cledger { get; set; }

        //Currency Account No relation
        public virtual CurrencyDTO Currency { get; set; }

        //CustomerId Relation
        public virtual PFMORM00001 Customer { get; set; }

        //CityCode Relation
        public virtual City CityCode { get; set; }

        //Township Relation
        public virtual Township TownshipCode { get; set; }

        //StateCode Relation
        public virtual State StateCode { get; set; }
    }
}