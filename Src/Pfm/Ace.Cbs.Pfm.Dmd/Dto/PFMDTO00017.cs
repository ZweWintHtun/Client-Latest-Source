using System;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    //CAOF
    [Serializable]
    public class PFMDTO00017 : Supportfields<PFMDTO00017>
    {
        public PFMDTO00017() { }

        public PFMDTO00017(string custID)
        {
            this.CustomerID = custID;
        }

public PFMDTO00017( int id,
                    string name,
                    string accountSign,
                    string address,
                    string phoneNo,
                    string fax,
                    string email,
                    string business,
                    string nrc,
                    string code,
                    DateTime openDate,
                    string userNo,
                    string joinType,
                    DateTime acceptedDate,
                    DateTime closeDate,
                    int noOfPersonSign,
                    int serialofCustomer,
                    string sourceBranchCode,
                    string currencyCode,
                    string cledgerAccountNo,
                    string customerID,
                    string city_Code,
                    string township_Code,
                    string state_Code,
                    byte[] ts,
                    bool active,
                    DateTime createdDate,
                    int createdUserId,
                    DateTime updatedDate,
                    int updatedUserId)
        {
            this.Id = id;
            this.Name = name;
            this.AccountSign = accountSign;
            this.Address = address;
            this.PhoneNo = phoneNo;
            this.Fax = fax;
            this.Email = email;
            this.Business = business;
            this.NRC = nrc;
            this.CODE = code;
            this.OPENDATE = openDate;
            this.USERNO = userNo;
            this.JoinType = joinType;
            this.AcceptedDate = acceptedDate;
            this.CloseDate = closeDate;
            this.NoOfPersonSign = noOfPersonSign;
            this.SerialofCustomer = serialofCustomer;
            this.SourceBranchCode = sourceBranchCode;
            this.CurrencyCode = currencyCode;
            this.CledgerAccountNo = cledgerAccountNo;
            this.CustomerID = customerID;
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

        public PFMDTO00017(string accountNo, string name, string custId, string address, string phone, string fax, DateTime openDate,
                      string accountSign, string nrc, string description, string business, string sourceBr, string currency)
        {
            this.CledgerAccountNo = accountNo;
            this.Name = name;
            this.CustomerID = custId;
            this.Address = address;
            this.PhoneNo = phone;
            this.Fax = fax;
            this.OPENDATE = openDate;
            this.AccountSign = accountSign;
            this.NRC = nrc;

            this.CODE = description;
            this.Business = business;
            this.SourceBranchCode = sourceBr;
            this.CurrencyCode = currency;

        }

        //call from MNMSVE00057
        public PFMDTO00017(string accountNo, string name, string custId, string address, string township_code, string city_code, string state_code, string phone, string fax, DateTime opendate, string acsign, string nrc, string business, string sourceBr, string cur)
        {
            this.CledgerAccountNo = accountNo;
            this.Name = name;
            this.CustomerID = custId;
            this.Address = address;
            this.Township_Code = township_code;
            this.City_Code = city_code;
            this.State_Code = state_code;
            this.PhoneNo = phone;
            this.Fax = fax;
            this.OPENDATE = opendate;
            this.AccountSign = acsign;
            this.NRC = nrc;
            this.Business = business;
            this.SourceBranchCode = sourceBr;
            this.Currency = Currency;
        }

        //call from MNMSVE00057
        public PFMDTO00017(string accountNo, string name, DateTime dateOfBirth, string parentName, string guardianshipName, string nrc, string address, DateTime opendate, string phone, string fax)
        {
            this.CledgerAccountNo = accountNo;
            this.Name = name;
            this.DateofBirth = dateOfBirth;
            this.ParentName = parentName;
            this.GuardianshipName = guardianshipName;
            this.NRC = nrc;
            this.Address = address;
            this.OPENDATE = opendate;
            this.PhoneNo = phone;
            this.Fax = fax;
        }

        public PFMDTO00017(int id,
                                        string name,
                                        string accountSign,
                                        string address,
                                        string phoneNo,
                                        string fax,
                                        string email,
                                        string business,
                                        string nrc,
                                        string code,
                                        DateTime openDate,
                                        string userNo,
                                        string joinType,
                                        DateTime acceptedDate,
                                        DateTime closeDate,
                                        int noOfPersonSign,
                                        int serialofCustomer,
                                        string sourceBranchCode,
                                        string currencyCode,
                                        string cledgerAccountNo,
                                        string customerID,
                                        string city_Code,
                                        string township_Code,
                                        string state_Code,
                                        byte[] ts,
                                        bool active,
                                        DateTime createdDate,
                                        int createdUserId,
                                        DateTime updatedDate,
                                        int updatedUserId,
                                        decimal currentBal, decimal minimumBalance, decimal overdraftLimit)
        {
            this.Id = id;
            this.Name = name;
            this.AccountSign = accountSign;
            this.Address = address;
            this.PhoneNo = phoneNo;
            this.Fax = fax;
            this.Email = email;
            this.Business = business;
            this.NRC = nrc;
            this.CODE = code;
            this.OPENDATE = openDate;
            this.USERNO = userNo;
            this.JoinType = joinType;
            this.AcceptedDate = acceptedDate;
            this.CloseDate = closeDate;
            this.NoOfPersonSign = noOfPersonSign;
            this.SerialofCustomer = serialofCustomer;
            this.SourceBranchCode = sourceBranchCode;
            this.CurrencyCode = currencyCode;
            this.CledgerAccountNo = cledgerAccountNo;
            this.CustomerID = customerID;
            this.City_Code = city_Code;
            this.Township_Code = township_Code;
            this.State_Code = state_Code;
            this.TS = ts;
            this.Active = active;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
            this.CurrentBal = currentBal;
            this.MinimumBalance = minimumBalance;
            this.OverdraftLimit = overdraftLimit;
        }

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
        public virtual System.Nullable<DateTime> CloseDate { get; set; }
        public virtual System.Nullable<int> NoOfPersonSign { get; set; }
        public virtual System.Nullable<int> SerialofCustomer { get; set; }

        //Added by HWKO (15-Aug-2017)
        public virtual string CpnyRegNo { get; set; }
        public virtual Nullable<DateTime> CpnyRegDate { get; set; }
        public virtual Nullable<DateTime> CpnyRegExpDate { get; set; }
        //End Region

        //Source Branch Relation
        public BranchDTO Branch { get; set; }

        //Cledger Account No relation
        public virtual PFMDTO00028 Cledger { get; set; }

        //Currency Account No relation
        public virtual CurrencyDTO Currency { get; set; }

        //CustomerId Relation
        public virtual PFMDTO00001 Customer { get; set; }

        //CityCode Relation
        public virtual CityDTO CityCode { get; set; }

        //Township Relation
        public virtual TownshipDTO TownshipCode { get; set; }

        //StateCode Relation
        public virtual StateDTO StateCode { get; set; }

        #region CurrentAccountAll
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual string ParentName { get; set; }
        public virtual string GuardianshipName { get; set; }
        public virtual Nullable<DateTime> DateofBirth { get; set; }


        public decimal CurrentBal { get; set; }
        public decimal MinimumBalance { get; set; }
        public decimal OverdraftLimit { get; set; }

        // public virtual decimal Balance { get; set; }
        #endregion
    }
}