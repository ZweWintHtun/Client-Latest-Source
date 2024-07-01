using System;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    // SAOF dto
    [Serializable]
    public class PFMDTO00016 : Supportfields<PFMDTO00016>
    {
        public PFMDTO00016() { }

        public PFMDTO00016(int id,string name,string name3,string accountSign,string address,string phoneNo,string fax,string nrc,string guardianshipNRC,DateTime dateOfBirth,string email,
                                        string business,string joinType, DateTime openDate,DateTime acceptedDate,DateTime closeDate,int noOfPersonSign,int serialofCustomer,string userNo,
                                        string sourceBranchCode,string cledgerAccountNo,string currencyCode,string customerID,string city_Code,string township_Code,string state_Code,byte[] ts,
                                        bool active,DateTime createdDate,int createdUserId,DateTime updatedDate,int updatedUserId)
        {
            this.Id = id;
            this.Name = name;
            this.Name3 = name3;
            this.AccountSign = accountSign;
            this.Address = address;
            this.PhoneNo = phoneNo;
            this.Fax = fax;
            this.NRC = nrc;
            this.GuardianshipNRC = guardianshipNRC;
            this.DateofBirth = dateOfBirth;
            this.Email = email;
            this.Business = business;
            this.JoinType = joinType;
            this.OPENDATE =openDate;
            this.AcceptedDate = acceptedDate;
            this.CloseDate = closeDate;
            this.NoOfPersonSign = noOfPersonSign;
            this.SerialofCustomer = serialofCustomer;
            this.USERNO = userNo;
            this.SourceBranchCode = sourceBranchCode;
            this.CledgerAccountNo = cledgerAccountNo;
            this.CurrencyCode = currencyCode;            
            this.Customer_Id = customerID;
            this.City_Code = city_Code;
            this.Township_Code = township_Code;
            this.State_Code = state_Code;
            this.TS = ts;
            this.Active = active;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public PFMDTO00016(string custid, string accountno, string lno, decimal? samount, DateTime? closedate)
        {
            this.Customer_Id = custid;
            this.AccountNo = accountno;
            this.LNo = lno;
            this.SAmount = samount;
            this.CloseDate = closedate;
        }

        // primary key
        public virtual int Id { get; set; }
        public virtual string AccountNo { get; set; }
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
        public virtual int NoOfPersonSign { get; set; }
        public virtual int SerialofCustomer { get; set; }
        public virtual string USERNO { get; set; }
        public virtual decimal AccruedInterest { get; set; }
        public virtual string SourceBranchCode { get; set; }
        public virtual string CurrencyCode { get; set; }
        public virtual string CledgerAccountNo { get; set; }
        public virtual string Customer_Id { get; set; }
        public virtual string City_Code { get; set; }
        public virtual string State_Code { get; set; }
        public virtual string Township_Code { get; set; }
        public virtual decimal CurrentBalance { get; set; }
        public virtual decimal LinkAmount { get; set; }
        public virtual string CounterNo { get; set; }
        public virtual string AllDenoRate { get; set; }
        public virtual string DenoString { get; set; }
        public virtual decimal AdjustAmount { get; set; }
        public virtual string RefundString { get; set; }
        public virtual string DenoRate { get; set; }
        public virtual string RefundRate { get; set; }
        public virtual string LNo {get;set;}
        public virtual System.Nullable<decimal> SAmount {get;set;}

        // Source Branch Relation
        public virtual BranchDTO Branch { get; set; }

        // CLedger Account No Relation
        public virtual PFMDTO00028 Cledger { get; set; }

        // Currency Relation
        public virtual CurrencyDTO Currency { get; set; }

        // CustomerId Relation
        public virtual PFMDTO00001 Customer { get; set; }

        // City Code Relation
        public virtual CityDTO CityCode { get; set; }

        // Town Ship Relation
        public virtual TownshipDTO TownshipCode { get; set; }

        // State Code Relation
        public virtual StateDTO StateCode { get; set; }


    }
}