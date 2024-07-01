using System;
using System.Collections.Generic;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    // CustomerId dto
    [Serializable]  
    public class PFMDTO00001 : Supportfields<PFMDTO00001>
    {

      
        public PFMDTO00001() 
        {
            this.CustPhoto = new PFMDTO00010();
        }

        public PFMDTO00001(string acctno, string name,decimal cbal,string address, string nrc)
        {
            this.AccountNo = acctno;
            this.Name = name;
            this.Amount = cbal;           
            this.Address = address;
            this.NRC = nrc;
        }
    
        //check Exist

        //Update
        public PFMDTO00001(string name, string nrc, string guardianName, string guardianNRCNo, string fatherName, string address, string phoneNo, string faxNo, string email, byte[] signature, bool isVIP, string gender, string remark, string passportNo, DateTime dateofbirth, string nameOnly, string nickName, string natinality, string stateCode, string cityCode, string townshipCode, string initial, string occupationCode, DateTime datetime,
            string sourcebranch,DateTime updatedDate, int updatedUserId)
        {
            this.Name = name;
            this.NRC = nrc;
            this.GuardianName = guardianName;
            this.GuardianNRCNo = guardianNRCNo;
            this.FatherName = fatherName;
            this.Address = address;
            this.PhoneNo = phoneNo;
            this.FaxNo = faxNo;
            this.Email = email;
            this.Signature = signature;
            this.IsVIP = isVIP;
            this.Gender = gender;
            this.Remark = remark;
            this.PassportNo = passportNo;
            this.DateOfBirth = dateofbirth;
            this.NameOnly = nameOnly;
            this.NickName = nickName;
            this.Nationality = natinality;
            this.StateCode = stateCode;
            this.CityCode = cityCode;
            this.TownshipCode = townshipCode;
            this.Initial = initial;
            this.OccupationCode = occupationCode;
            this.DATE_TIME = datetime;
            this.SourceBranch = sourcebranch;        
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;          		
        }

        public PFMDTO00001(string customerid, string name, string nrc, string guardianName, string guardianNRCNo, string fatherName, string address, decimal closeAC, decimal openAC, Nullable<DateTime> closeDate, string phoneNo, string faxNo, string email, byte[] signature, bool isVIP, string gender, string remark, string passportNo, DateTime dateofbirth, string nameOnly, string nickName, string nationality, string stateCode, string cityCode, string townshipCode, string initial, string occupationCode, bool active, byte[] ts, DateTime createdDate, int createdUserId, DateTime updatedDate, int updatedUserId)
        {
            this.CustomerId = customerid;
            this.Name = name;
            this.NRC = nrc;
            this.GuardianName = guardianName;
            this.GuardianNRCNo = guardianNRCNo;
            this.FatherName = fatherName;
            this.Address = address;
            this.CloseAC = closeAC;
            this.OpenAC = openAC;
            this.CloseDate = closeDate;
            this.PhoneNo = phoneNo;
            this.FaxNo = faxNo;
            this.Email = email;
            this.Signature = signature;
            this.IsVIP = isVIP;
            this.Gender = gender;
            this.Remark = remark;
            this.PassportNo = passportNo;
            this.DateOfBirth = dateofbirth;
            this.NameOnly = nameOnly;
            this.NickName = nickName;
            this.Nationality = nationality;
            this.StateCode = stateCode;
            this.CityCode = cityCode;
            this.TownshipCode = townshipCode;
            this.Initial = initial;
            this.OccupationCode = occupationCode;
            this.Active = active;
            this.TS = ts;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;

        }
     
        public PFMDTO00001(string customerid,string name,string nrc)
        {
            this.CustomerId = customerid;
            this.NRC = nrc;
            this.Name = name;
        }

    

    
        public PFMDTO00001( string nrc)
        {
            this.NRC = nrc;
        }
        //Select all
      

       //// Select By Id
        public PFMDTO00001(string customerid, string name, string nrc, string guardianName, string guardianNRCNo, string fatherName, string address, string phoneNo, string faxNo, string email, byte[] signature, bool isVIP, string gender, string remark, string passportNo, DateTime dateofbirth, string nameOnly, string nickName, string stateCode, string stateDescription, string cityCode, string cityDescription, string townshipCode, string townshipDescription, string initial, string occupationCode, string nationality, byte[] custphotos)
        {
          
            this.CustomerId = customerid;
            this.Name = name;
            this.NRC = nrc;
            this.GuardianName = guardianName;
            this.GuardianNRCNo = guardianNRCNo;
            this.FatherName = fatherName;
            this.Address = address;
            this.PhoneNo = phoneNo;
            this.FaxNo = faxNo;
            this.Email = email;
            this.Signature = signature;
            this.IsVIP = isVIP;
            this.Gender = gender;
            this.Remark = remark;
            this.PassportNo = passportNo;
            this.DateOfBirth = dateofbirth;
            this.NameOnly = nameOnly;
            this.NickName = nickName;          
            this.StateCode = stateCode;
            this.CityCode = cityCode;
            this.TownshipCode = townshipCode;
            this.Initial = initial;
            this.OccupationCode = occupationCode;
            this.StateCode = stateCode;
            this.CityCode = cityCode;
            this.TownshipCode = townshipCode;
            this.Initial = initial;
            this.OccupationCode = occupationCode;
            this.Nationality = nationality;
            this.CustPhoto = new PFMDTO00010();
            this.CustPhoto.CustPhotos = custphotos;
            this.CityDesp = cityDescription;
            this.StateDesp = stateDescription;
            this.TownshipDesp = townshipDescription;
        }

        public PFMDTO00001(string name, string address, string phoneNo, string faxNo, string nrc, string email,bool isVIP, byte[] photo, byte[] signature, string occupationDesp, string customerId, string jointType, int noOfPersionToSign,string curCode,DateTime dOB,string fatherName,string townShipCode,string cityCode,string stateCode,string townshipDesp,string cityDesp,string stateDesp)
        {
            this.Name = name;
            this.Address = address;
            this.PhoneNo = phoneNo;
            this.FaxNo = faxNo;
            this.NRC = nrc;
            this.Email = email;
            this.IsVIP = isVIP;
            this.Photo = photo;
            this.Signature = signature;
            this.OccupationDesp = occupationDesp;
            this.CustomerId = customerId;
            this.JoinType = jointType;
            this.NoOfPersonSign = noOfPersionToSign;
            this.CurrencyCode = curCode;
            this.DateOfBirth = dOB;
            this.FatherName = fatherName;
            this.TownshipCode =townShipCode;
            this.CityCode = cityCode;
            this.StateCode= stateCode;
            this.TownshipDesp = townshipDesp;
            this.CityDesp = cityDesp;
            this.StateDesp = stateDesp;
        }
        public PFMDTO00001(string name, string nrc, string address, string townshipcode, string townshipdesp, string phoneNo)
        {

            this.Name = name;
            this.NRC = nrc;
            this.Address = address;
            this.TownshipCode = townshipcode;
            this.TownshipDesp = townshipdesp;
            this.PhoneNo = phoneNo;
        }
        public PFMDTO00001(string name, string nrc, string address, string townshipcode, string phoneNo) //for Sub_Ledger Customer
        {
            this.Name = name;
            this.NRC = nrc;
            this.Address = address;
            this.TownshipCode = townshipcode;            
            this.PhoneNo = phoneNo;
        }

        public PFMDTO00001(string customerId, string name, string address,string accountSign, string phoneNo, string faxNo, string nrc, string email,string cityCode,string townshipCode,string townshipDescription,DateTime dob,string currencyCode,string occupation,string fatherName,byte[] signature,byte[] custPhoto,string statecode,string cityDescription,string stateDescription)
        {
            this.CustomerId = customerId;
            this.Name = name;
            this.Address = address;
            this.AccountSign = accountSign;
            this.PhoneNo = phoneNo;
            this.FaxNo = faxNo;
            this.NRC = nrc;
            this.Email = email;
            this.CityCode = cityCode;
            this.TownshipCode = townshipCode;
            this.TownshipDesp = townshipDescription;
            this.DateOfBirth = dob;
            this.CurrencyCode = currencyCode;
            this.OccupationDesp = occupation;
            this.FatherName = fatherName;
            this.Signature = signature;
            this.CustPhotos =custPhoto;
            this.StateCode = statecode;
            this.CityDesp = cityDescription;
            this.StateDesp = stateDescription;
        }
        public PFMDTO00001(string customerId, string name, string address, string accountSign, string phoneNo, string faxNo, string nrc, string email, string cityCode, string townshipCode, string townshipDescription)
        {
            this.CustomerId = customerId;
            this.Name = name;
            this.Address = address;
            this.AccountSign = accountSign;
            this.PhoneNo = phoneNo;
            this.FaxNo = faxNo;
            this.NRC = nrc;
            this.Email = email;
            this.CityCode = cityCode;
            this.TownshipCode = townshipCode;
            this.TownshipDesp = townshipDescription;
          
        }

        public PFMDTO00001(string custId, string name, DateTime DOB, string email, string address, string firmName, string phNo, string faxNo, string nrc, Boolean isVip, string townShip, string state, string city, byte[] custPhoto, byte[] signature, string desp, string joinType, int NoOfPersonSign)
        {
            this.CustomerId = custId;
            this.NameOnly = name;
            this.DateOfBirth = DOB;
            this.Email = email;
            this.Address = address;
            this.Name = firmName;
            this.PhoneNo = phNo;
            this.FaxNo = faxNo;
            this.NRC = nrc;
            this.IsVIP = isVip;
            this.TownshipDesp = townShip;
            this.StateDesp = state;
            this.CityDesp = city;
            this.CustPhoto = new PFMDTO00010();
            this.CustPhoto.CustPhotos = custPhoto;
            this.Signature = signature;
            this.OccupationDesp = desp;
            this.JoinType = joinType;
            this.NoOfPersonSign = NoOfPersonSign;
            
        }

        public PFMDTO00001(string name, string address, string phoneNo, string faxNo, string nrc, string email, bool isVIP, byte[] photo, byte[] signature, string occupationDesp, string customerId, string jointType, int noOfPersionToSign)
        {
            this.Name = name;
            this.Address = address;
            this.PhoneNo = phoneNo;
            this.FaxNo = faxNo;
            this.NRC = nrc;
            this.Email = email;
            this.IsVIP = isVIP;
            this.Photo = photo;
            this.Signature = signature;
            this.OccupationDesp = occupationDesp;
            this.CustomerId = customerId;
            this.JoinType = jointType;
            this.NoOfPersonSign = noOfPersionToSign;
         
        }

        //FAOF
        public PFMDTO00001(string customerId, string name, string address,  string phoneNo, string faxNo, string nrc, string email,Boolean isVip,byte[] custPhoto,byte[] signature,string occupationDesp,
            string currencyCode,DateTime dob,string fatherName,string cityCode, string townshipCode,
            string townshipDescription, string statecode, string cityDescription, string stateDescription, string accountSign, string guardianName, string guardianNRCNo)
        {
            this.CustomerId = customerId;
            this.Name = name;
            this.Address = address;
            this.AccountSign = accountSign;
            this.PhoneNo = phoneNo;
            this.FaxNo = faxNo;
            this.NRC = nrc;
            this.Email = email;
            this.CityCode = cityCode;
            this.TownshipCode = townshipCode;
            this.TownshipDesp = townshipDescription;
            this.DateOfBirth = dob;
            this.CurrencyCode = currencyCode;
            this.OccupationDesp = occupationDesp;
            this.FatherName = fatherName;
            this.Signature = signature;
            this.CustPhotos = custPhoto;
            this.StateCode = statecode;
            this.CityDesp = cityDescription;
            this.StateDesp = stateDescription;
            this.AccountSignature = accountSign;
            this.GuardianName = guardianName;
            this.GuardianNRCNo = guardianNRCNo;
        }

        //FAOF  ( CXDAO00006.SelectCustomerInformationByCAOF)  -- PFMORM00001.hbm.xml
        public PFMDTO00001(string customerId, string name, string address, string phoneNo, string faxNo, string nrc, string email, Boolean isVip, byte[] custPhoto, byte[] signature, string occupationDesp,
            string currencyCode, DateTime dob, string fatherName, string cityCode, string townshipCode,
            string townshipDescription, string statecode, string cityDescription, string stateDescription, string accountSign, string guardianName, string guardianNRCNo, DateTime openDate, DateTime createdDate, int createdUserId)
        {
            this.CustomerId = customerId;
            this.Name = name;
            this.Address = address;
            this.AccountSign = accountSign;
            this.PhoneNo = phoneNo;
            this.FaxNo = faxNo;
            this.NRC = nrc;
            this.Email = email;
            this.IsVIP = isVip;
            this.CityCode = cityCode;
            this.TownshipCode = townshipCode;
            this.TownshipDesp = townshipDescription;
            this.DateOfBirth = dob;
            this.CurrencyCode = currencyCode;
            this.OccupationDesp = occupationDesp;
            this.FatherName = fatherName;
            this.Signature = signature;
            this.CustPhotos = custPhoto;
            this.StateCode = statecode;
            this.CityDesp = cityDescription;
            this.StateDesp = stateDescription;
            this.AccountSignature = accountSign;
            this.GuardianName = guardianName;
            this.GuardianNRCNo = guardianNRCNo;
            this.DATE_TIME = openDate;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
        }
        // SAOF -->> "CXDAO00006.SelectCustomerInformationBySAOF" (PFMORM00001.hbm.xml)
        public PFMDTO00001(string custId, string name, string address,string fathername, string phoneNo, string faxNo, string nrc, string email, Boolean isVip, byte[] custPhoto, byte[] signature, string desp,
            string jointype, int noOfPersonSign, string curcode, string acctsign,string business, DateTime dob, string guardianName,string guardianNRCNo,
            string townshipcode, string cityCode, string stateCode, string townshipDesp, string cityDesp,
            string stateDesp, string nameofFirm, DateTime openDate, DateTime createdDate, int createdUserId)
        {
            this.CustomerId = custId;
            // Edited by HOW (To get Company name)
            if (nameofFirm != null)
            {
                this.Name = nameofFirm;
            }
            else
            {
                this.Name = name;
            }
            this.Address = address;
            this.FatherName = fathername;
            this.PhoneNo = phoneNo;
            this.FaxNo = faxNo;
            this.NRC = nrc;
            this.Email = email;
            this.IsVIP = isVip;
            this.CustPhotos = custPhoto;
            this.AccountSign = acctsign;
            this.Business = business;
            this.Signature = signature;
            this.OccupationDesp = desp;
            this.JoinType = jointype;
            this.NoOfPersonSign = noOfPersonSign;
            this.CurrencyCode = curcode;
            this.DateOfBirth = dob;
            this.GuardianName = guardianName;
            this.GuardianNRCNo = guardianNRCNo;
            this.TownshipCode = townshipcode;
            this.CityCode = cityCode;
            this.StateCode = stateCode;
            this.TownshipDesp = townshipDesp;
            this.StateDesp = stateDesp;
            this.CityDesp = cityDesp;
            this.NameofFirm = nameofFirm;
            this.DATE_TIME = openDate;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
        }

        //CXDAO00006.SelectCustomerInformationByCAOF (PFMORM00001.hbm.xml)   //added by ASDA
        public PFMDTO00001(string custId, string name, string address, string fathername, string phoneNo, string faxNo, string nrc, string email, Boolean isVip, byte[] custPhoto, byte[] signature, string desp,
            string jointype, int noOfPersonSign, string curcode, string acctsign, DateTime dob, string guardianName, string guardianNRCNo,
            string townshipcode, string cityCode, string stateCode, string townshipDesp, string cityDesp,
            string stateDesp, string nameofFirm, string business,DateTime openDate, DateTime createdDate, int createdUserId)
        {
            this.CustomerId = custId;
            if (nameofFirm != null)
            {
                this.Name = nameofFirm;
            }
            else
            {
                this.Name = name;
            }
            this.Address = address;
            this.FatherName = fathername;
            this.PhoneNo = phoneNo;
            this.FaxNo = faxNo;
            this.NRC = nrc;
            this.Email = email;
            this.IsVIP = isVip;
            this.CustPhotos = custPhoto;
            this.AccountSign = acctsign;
            this.Signature = signature;
            this.OccupationDesp = desp;
            this.JoinType = jointype;
            this.NoOfPersonSign = noOfPersonSign;
            this.CurrencyCode = curcode;
            this.DateOfBirth = dob;
            this.GuardianName = guardianName;
            this.GuardianNRCNo = guardianNRCNo;
            this.TownshipCode = townshipcode;
            this.CityCode = cityCode;
            this.StateCode = stateCode;
            this.TownshipDesp = townshipDesp;
            this.StateDesp = stateDesp;
            this.CityDesp = cityDesp;
            this.NameofFirm = nameofFirm;
            this.Business = business;            
            this.DATE_TIME = openDate;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
        }

        public PFMDTO00001(int year, int month, string sourceBr)
        {
            this.Year = year;
            this.Month = month;
            this.SourceBranch = sourceBr;
        }

        public PFMDTO00001(string customerId, string name, string nrc, decimal openac, decimal closeac, bool isvip)
        {
            this.CustomerId = customerId;
            this.Name = name;
            this.NRC = nrc;
            this.OpenAC = openac;
            this.CloseAC = closeac;
            this.IsVIP = isvip;
        }

        //Call for MNMSVE00052
        public PFMDTO00001(string acctno, string name, string address, string nrc, decimal cbal, DateTime dt, string sourcebr)
        {
            this.AccountNo = acctno;
            this.Name = name;
            this.Address = address;
            this.NRC = nrc;
            this.CurrentBal = cbal;
            this.DATE_TIME = dt;
            this.SourceBranch = sourcebr;
        }
        //call for MNMSVE00052
        public PFMDTO00001(DateTime dt, string acctno, string cheque, string desp, decimal withdrawAmt, decimal depositAmt, string s, string workstation, DateTime chktime, string sourceBr)
        {
            this.DATE_TIME = dt;
            this.AccountNo = acctno;
            this.ChequeNo = cheque ;
            this.Description = desp;
            this.WithdrawAmount = withdrawAmt ;
            this.DepositAmount = depositAmt ;
            this.S = s;
            this.Workstation= workstation;
            this.chktime = chktime ;
            this.SourceBranch = sourceBr;	
        }

        public PFMDTO00001(int createdUserId, string townshipCode, string townshipDescription)
        {
            this.CreatedUserId = createdUserId;
            this.TownshipCode = townshipCode;
            this.TownshipDesp = townshipDescription;
        }

        //public PFMDTO00001(int createdUserId)
        //{
        //    this.CreatedUserId = createdUserId;
            
        //}
        
        public virtual int Id { get; set; }
        public virtual string AccountNo { get; set; }
        public virtual decimal CurrentBal { get; set; }
        public virtual decimal OverdraftLimit { get; set; }
        public virtual decimal MinimumBalance { get; set; }
        public virtual Nullable<DateTime> OverdraftDate { get; set; }
        public virtual decimal DayOfBalance { get; set; }
        public virtual decimal LoansAccount { get; set; }
        public virtual decimal SavingInterestRate { get; set; }
        public virtual decimal TransactionCount { get; set; }
        public virtual decimal MonthOpeningBalance { get; set; }
        public virtual decimal PrintLineNo { get; set; }
        public virtual decimal TemporaryOverdraftLimit { get; set; }
        public virtual decimal LoansCount { get; set; }
        public virtual decimal LinkAmount { get; set; }
        public string TransactionStatus { get; set; }

        public virtual string CustomerId { get; set; }
        //public Nullable<string> CustomerId
        //{
        //    get { return this.CustomerId.Value; }

        //    set
        //    {
        //        if (value == null)
        //        {
        //            this.CustomerId = " ";
        //        }
        //        else this.CustomerId = value.Value;
        //    }
        //}
        public virtual string Name { get; set; }
        public virtual Boolean IsNRC { get; set; }
        public virtual string NRC { get; set; }
        public virtual string GuardianName { get; set; }
        public virtual Boolean IsGuardianNRC { get; set; }
        public virtual string GuardianNRCNo { get; set; }
        public virtual string FatherName { get; set; }
        public virtual string Address { get; set; }
        public virtual decimal CloseAC { get; set; }
        public virtual decimal OpenAC { get; set; }
        public virtual System.Nullable<DateTime> CloseDate { get; set; }
        public virtual string PhoneNo { get; set; }
        public virtual string FaxNo { get; set; }
        public virtual string Email { get; set; }
        public virtual byte[] Signature { get; set; }       
        public virtual Boolean IsVIP { get; set; }
        public virtual string Gender { get; set; }
        public virtual string Remark { get; set; }
        public virtual string PassportNo { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
        public virtual string NameOnly { get; set; }
        public virtual string NickName { get; set; }
        public virtual string SourceBranch { get; set; }
        public virtual DateTime DATE_TIME { get; set; }
        public virtual string USERNO { get; set; }
        public virtual int RowNum { get; set; }
        public virtual byte[] Photo { get; set; }
        public virtual string StateCode { get; set; }
        public virtual string CityCode { get; set; }
        public virtual string TownshipCode { get; set; }
        public virtual string Initial { get; set; }
        public virtual string OccupationCode { get; set; }
        public virtual string Nationality { get; set; }

        public virtual PFMDTO00010 CustPhoto { get; set; }
        public virtual byte[] CustPhotos { get; set; }
        public virtual string CustPhotoName { get; set; }

        public virtual bool isCheckName { get; set; }
        public virtual bool isCheckNRC { get; set; }
        public virtual bool isCheckFatherName { get; set; }
        public virtual bool NRCCheckStatus { get; set; }
        public virtual string AccountSign { get; set; }
        public virtual string StateDesp { get; set; }
        public virtual string CityDesp { get; set; }
        public virtual string TownshipDesp { get; set; }
        public virtual string OccupationDesp { get; set; }
        public virtual string InitialDesp { get; set; }
        public virtual string CurrencyCode { get; set; }
        public virtual int NoOfPersonSign { get; set; }
        public virtual string JoinType { get; set; }
        public virtual PFMDTO00016 SAFO { get; set; }
        public virtual PFMDTO00017 CAFO { get; set; }
        public virtual string chequeBookNo { get; set; }
        public virtual string StartNo { get; set; }
        public virtual string EndNo { get; set; }
        public virtual string ReceiptNo { get; set; }
        public string AccountType { get; set; }
        public string SubAccountType { get; set; }
        public string AccountSignature { get; set; }
        public string BranchCode { get; set; }
        public string NameofFirm { get; set; }
        public string Business { get; set; }
        public bool IsLastWithdrawal { get; set; }
        public string ChequeNo { get; set; }
        public decimal CashDenoAmount { get; set; }
        public virtual IList<PFMDTO00032> FreceiptInfo { get; set; }
        public IList<string> CustomerIds { get; set; }
        public string OldCustomerIds { get; set; }
        public decimal OVDLimit { get; set; }
        public System.Nullable<decimal> Amount{ get; set; }
        public bool IsCheck { get; set; }
        public string Message { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
       // public string Bussiness { get; set; }

        //for NRC
        public string StateCodeForNRC { get; set; }
        public string TownshipCodeForNRC { get; set; }
        public string NationalityCodeForNRC { get; set; }
        public string NRCNo { get; set; }

        //For FatherNRC
        public string FatherStateCodeForNRC { get; set; }
        public string FatherTownshipCodeForNRC { get; set; }
        public string FatherNationalityCodeForNRC { get; set; }
        public string FatherNRCNo { get; set; }

        public string Narration { get; set; }
        public bool ExpiredLoansStatus { get; set; } // Added by AAM(30_July_2018)

        #region Sub_Ledger     
       
        public virtual string Description { get; set; }
        public virtual decimal WithdrawAmount { get; set; }
        public virtual decimal DepositAmount { get; set; }
        public virtual string S { get; set; }
        public virtual string Workstation { get; set; }
        public virtual DateTime chktime { get; set; }
      
        #endregion

        // for Transfer voucher either Loans are expired or not ; can show the Loans Expired Message and can do Transfer process 
        public bool ExpiredStatus { get; set; } // Added by ZMS(13.11.18)

        public string BlackList { get; set; } // Added by ZMS(13.11.18)

    }
}