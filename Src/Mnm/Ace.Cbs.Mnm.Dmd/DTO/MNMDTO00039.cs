using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Mnm.Dmd
{
     [Serializable]
    public class MNMDTO00039 : Supportfields<MNMDTO00039>
    {
        public MNMDTO00039() { }

        public MNMDTO00039(DateTime startDate, DateTime endDate, string sourceBranch, string currency)
        {
            this.Date_Time = startDate;
            this.Date_Time = endDate;
            this.SourceBr = sourceBranch;
            this.Cur = currency;
        }

        public MNMDTO00039(DateTime startDate, DateTime endDate, string sourceBranch, string currency, string township)
        {
            this.Date_Time = startDate;
            this.Date_Time = endDate;
            this.SourceBr = sourceBranch;
            this.Cur = currency;
            this.TownShipDesp = township;
        }

        public MNMDTO00039(string custID, string name, string nrc, string fatherName, string address, string townshipDesp, string cityDesp, string stateDesp, string phone)
        {
            this.CustID = custID;
            this.Name = name;
            this.Nrc = nrc;
            this.FatherName = fatherName;
            this.Address = address;
            this.TownShipDesp = townshipDesp;
            this.CityDesp = cityDesp;
            this.StateDesp = stateDesp;
            this.Phone = phone;
        }

        public MNMDTO00039(int id,string accountNo,string custId,string address,string phone,string fax,DateTime openDate,string acSign,string nrc,string description,string accountType)
        {
            this.Id = id;
            this.AccountNo = accountNo;
            this.CustID = custId;
            this.Address = address;
            this.Phone = phone;
            this.Fax = fax;
            this.OpenDate = openDate;
            this.AccountSign = acSign;
            this.Nrc = nrc;
            this.Description = description;
            this.AccountType = accountType;
        }

        public MNMDTO00039(string name, string nrc, string customerId)
        {
            this.Name = name;
            this.Nrc = nrc;
            this.CustID = customerId;
        }

        public virtual int Id { get; set; }
        public virtual string CustID { get; set; }
        public virtual string Name { get; set; }
        public virtual string Nrc { get; set; }
        public virtual string FatherName { get; set; }
        public virtual string OccupationCode { get; set; }
        public virtual string Nationality { get; set; }
        public virtual string PassportNo { get; set; }
        public virtual string TownshipCode { get; set; }
        public virtual string StateCode { get; set; }
        public virtual int CloseAc { get; set; }
        public virtual int OpenAc { get; set; }
        public virtual DateTime Date_Time { get; set; }
        public virtual DateTime CloseDate { get; set; }
        public virtual string CityCode { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Fax { get; set; }
        public virtual string Email { get; set; }
        public virtual string Address { get; set; }
        public virtual string NameOnly { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }
        public virtual string StateDesp { get; set; }
        public virtual string CityDesp { get; set; }
        public virtual string TownShipDesp { get; set; }
        public virtual string OccupationDesp { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual string TransactionStatus { get; set; }

        public virtual string AccountNo { get; set; }
        public virtual string ReceiptNo { get; set; }
        public virtual DateTime OpenDate { get; set; }
        public virtual string AccountSign { get; set; }
        public virtual string Description { get; set; }
        public virtual string AccountType { get; set; }
        public virtual string WordAmount { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual string ReceiptDate { get; set; }
        public virtual string Duration { get; set; }
        public virtual int InterestRate { get; set; }
        public virtual DateTime MaturityDate { get; set; }
    }
}
