using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Mnm.Dmd
{
    [Serializable]
    public class MNMDTO00046 : Supportfields<MNMDTO00046>
    {
        public MNMDTO00046() { }

        public MNMDTO00046(string customerID)
        {
            this.CustomerId = customerID;
        }

        public MNMDTO00046(string name, string nrc, string address, string townshipcode, string citycode, string phoneno)
        {
            this.Name = name;
            this.NRC = nrc;
            this.Address = address;
            this.TownshipCode = townshipcode;
            this.CityCode = citycode;
            this.PhoneNo = phoneno;
        }

        public MNMDTO00046(string townshipcode, string townshipdesp)
        {
            this.TownshipCode = townshipcode;
            this.TownshipDesp = townshipdesp;
        }

        public MNMDTO00046(string customerID, string name, string nrc, string address, string townshipcode, string citycode, string phoneno, string townshipdesp, decimal amount, string accountno, string datetime, string description, decimal withdrawlamount, decimal depositamount)
        {
            this.CustomerId = customerID;
            this.Name = name;
            this.NRC = nrc;
            this.Address = address;
            this.TownshipCode = townshipcode;
            this.TownshipDesp = townshipdesp;
            this.CityCode = citycode;
            this.PhoneNo = phoneno;
            this.Amount = amount;
            this.AccountNo = accountno;
            this.DATE_TIME = datetime;
            this.Description = description;
            this.WithdrawAmount = withdrawlamount;
            this.DepositAmount = depositamount;
        }



        public virtual int Id { get; set; }
        public virtual string AccountNo { get; set; }

        public virtual string CustomerId { get; set; }
        public virtual string Name { get; set; }
        public virtual string NRC { get; set; }
        public virtual string GuardianName { get; set; }
        public virtual string GuardianNRCNo { get; set; }
        public virtual string FatherName { get; set; }
        public virtual string Address { get; set; }
        public virtual decimal CloseAC { get; set; }
        public virtual decimal OpenAC { get; set; }
        public virtual string PhoneNo { get; set; }
        public virtual string FaxNo { get; set; }
        public virtual string Email { get; set; }
        public virtual string Gender { get; set; }
        public virtual string Remark { get; set; }
        public virtual string PassportNo { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
        public virtual string NameOnly { get; set; }
        public virtual string NickName { get; set; }
        public virtual string SourceBranch { get; set; }
        public virtual string DATE_TIME { get; set; }
        public virtual string USERNO { get; set; }
        public virtual int RowNum { get; set; }
        public virtual string StateCode { get; set; }
        public virtual string CityCode { get; set; }
        public virtual string TownshipCode { get; set; }
        public virtual string Initial { get; set; }
        public virtual string OccupationCode { get; set; }
        public virtual string Nationality { get; set; }
        public virtual string AccountSign { get; set; }
        public virtual string StateDesp { get; set; }
        public virtual string CityDesp { get; set; }
        public virtual string TownshipDesp { get; set; }
        public virtual string OccupationDesp { get; set; }
        public virtual string InitialDesp { get; set; }
        public virtual string CurrencyCode { get; set; }
        public string AccountType { get; set; }
        public System.Nullable<decimal> Amount{ get; set; }

        public virtual string Description { get; set; }
        public virtual decimal WithdrawAmount { get; set; }
        public virtual decimal DepositAmount { get; set; }
        public virtual string S { get; set; }
        public virtual string Workstation { get; set; }
        public virtual DateTime chktime { get; set; }
        public virtual System.Nullable<decimal> Balance { get; set; }
      
    }
}
