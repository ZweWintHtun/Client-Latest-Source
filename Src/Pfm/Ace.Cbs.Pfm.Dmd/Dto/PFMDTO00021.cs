using System;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    //FAOF dto
    [Serializable]
    public class PFMDTO00021 : Supportfields<PFMDTO00021>
    {
        public PFMDTO00021() { }

        public PFMDTO00021(string acctno,int noOfPerson,string acsign, string cur,string business,string custid,
                     string name,string fathername,string nrc,string address)
        {
            this.FledgerAccountNo = acctno;
            this.NoOfPersonSign = noOfPerson;
            this.CurrencyCode = cur;
            this.Business = business;
            this.NRC = nrc;
            this.GuardianName = fathername;
            this.Address = address;
            this.CustomerId = custid;
            this.Name = name;
            this.AccountSignature = acsign;

 
        }

        public PFMDTO00021(int id, string accountNo, string lastReceiptNo, string name, string guardianName, string guardianNRC, string nrc, string accountSign, Nullable<DateTime> dateOfBirth, string joinType,
                                        string address, string phoneNo, string fax, string email, string business, Nullable<DateTime> acceptedDate, Nullable<DateTime> closeDate, int noOfPersonSign,
                                        int serialofCustomer,string sourceBranchCode,string currencyCode,string customerID,string city_Code,string township_Code,string state_Code,byte[] ts,
                                        bool active,DateTime createdDate,int createdUserId,DateTime updatedDate,int updatedUserId)
        {
            this.Id = id;
            this.FledgerAccountNo = accountNo;
            this.LastReceiptNo = lastReceiptNo;
            this.Name = name;
            this.GuardianName = guardianName;
            this.GuardianNRC = guardianNRC;
            this.NRC = nrc;
            this.AccountSignature = accountSign;
            this.DateOfBirth = dateOfBirth;
            this.JoinType = joinType;
            this.Address = address;
            this.Phone = phoneNo;
            this.Fax = fax;
            this.Email = email;
            this.Business = business;
            this.AcceptDate = acceptedDate;
            this.CloseDate = closeDate;
            this.NoOfPersonSign = noOfPersonSign;
            this.SerialOfCustomer = serialofCustomer;
            this.SourceBranchCode = sourceBranchCode;
            this.CurrencyCode = currencyCode;            
            this.CustomerId = customerID;
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
        public PFMDTO00021(string custid, string acctno, string receiptno, DateTime closedate)
        {
            this.CustomerId = custid;
            this.FledgerAccountNo = acctno;
            this.ReceiptNo = receiptno;
            if (closedate == System.DateTime.MinValue)
            {
                this.CloseDate = null;
            }
            else
            {
                this.CloseDate = closedate;
            }
        }

        public PFMDTO00021(string acctno, string name, string address, DateTime opendate, string phone, string fax, string township_Code, string city_Code, string state_Code)
        {
            this.FledgerAccountNo = acctno;
            this.Name = name;
            this.Address = address;
            this.OpenDate = opendate;
            this.Phone = phone;
            this.Fax = fax;
            this.City_Code = city_Code;
            this.Township_Code = township_Code;
            this.State_Code = state_Code;
        }

        //CXDAO00006.FAOFSelectByAccountNumber(PRMORM00021.hbm.xml)
        public PFMDTO00021(int id, string accountNo, string lastReceiptNo, string name, string guardianName, string guardianNRC, string nrc, string accountSign, Nullable<DateTime> dateOfBirth, string joinType,
                                        string address, string phoneNo, string fax, string email, string business, Nullable<DateTime> acceptedDate, Nullable<DateTime> closeDate, int noOfPersonSign,
                                        int serialofCustomer, string sourceBranchCode, string currencyCode, string customerID, string city_Code, string township_Code, string state_Code, DateTime openDate, byte[] ts,
                                        bool active, DateTime createdDate, int createdUserId, DateTime updatedDate, int updatedUserId)
        {
            this.Id = id;
            this.FledgerAccountNo = accountNo;
            this.LastReceiptNo = lastReceiptNo;
            this.Name = name;
            this.GuardianName = guardianName;
            this.GuardianNRC = guardianNRC;
            this.NRC = nrc;
            this.AccountSignature = accountSign;
            this.DateOfBirth = dateOfBirth;
            this.JoinType = joinType;
            this.Address = address;
            this.Phone = phoneNo;
            this.Fax = fax;
            this.Email = email;
            this.Business = business;
            this.AcceptDate = acceptedDate;
            this.CloseDate = closeDate;
            this.NoOfPersonSign = noOfPersonSign;
            this.SerialOfCustomer = serialofCustomer;
            this.SourceBranchCode = sourceBranchCode;
            this.CurrencyCode = currencyCode;
            this.CustomerId = customerID;
            this.City_Code = city_Code;
            this.Township_Code = township_Code;
            this.State_Code = state_Code;
            this.OpenDate = openDate;
            this.TS = ts;
            this.Active = active;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }       


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

        public virtual decimal AccuredInterest { get; set; }
       
        public virtual string FledgerAccountNo { get; set; }
        public virtual string CustomerId { get; set; }
        public virtual string SourceBranchCode { get; set; }
        public virtual string CurrencyCode { get; set; }
        public virtual string City_Code { get; set; }
        public virtual string Township_Code { get; set; }
        public virtual string State_Code { get; set; }
        public virtual string EStatus { get; set; }
        public virtual string ReceiptNo { get; set; }

        public virtual string AccuredStatus { get; set; }
        public virtual string Description { get; set; }

        // Fledger Account No Relation
        public virtual PFMDTO00023 Fledger { get; set; }

        // Source Branch Relation
        public virtual BranchDTO Branch { get; set; }

        // Currency Relation
        public virtual CurrencyDTO Currency { get; set; }

        // CustomerId Relation
        public virtual PFMDTO00001 Customer { get; set; }

        // Township Code Relation
        public virtual TownshipDTO TownshipCode { get; set; }

        // StateCode Relation
        public virtual StateDTO StateCode { get; set; }

        // CityCode Relation
        public virtual CityDTO CityCode { get; set; }
    }
}