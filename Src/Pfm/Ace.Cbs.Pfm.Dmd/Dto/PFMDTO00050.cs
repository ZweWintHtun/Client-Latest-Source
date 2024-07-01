using System;
using System.Collections.Generic;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    [Serializable]
    public class PFMDTO00050 : Supportfields<PFMDTO00050>
    {
        /// <summary>
        /// CurrentCompanyAccountDTO
        /// </summary>
        
        public PFMDTO00050() 
        {
            
        }

        public string IntroducedBy { get; set; }
        public string TransactionStatus { get; set; }
        public string AccountType { get; set; }
        public string SubAccountType { get; set; }
        public string AccountSignature { get; set; }
        public string BranchCode { get; set; }
        public string CurrencySymbol { get; set; }
        public string AccountNo { get; set; }
        public string Name { get; set; }
        public string NameOfFirm { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string GuardianshipName { get; set; }
        public string CityCode { get; set; }
        public string CurrencyCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string TownshipCode { get; set; }
        public string StateCode { get; set; }
        public string Business { get; set; }
        public int NoOfPersonSign { get; set; }
        public string ChequeBookNo { get; set; }
        public string ChequeStartNo { get; set; }
        public string ChequeEndNo { get; set; }
        public string DebitLinkAccount { get; set; }
        public decimal DebitLimit { get; set; }
        public decimal SavingInterestRate { get;set; }
        public Nullable<DateTime> DateOfBirth {get;set;}
        public string GuardianshipNRC {get;set;}
        public Nullable<DateTime> AcceptedDate {get;set;}
        public string JoinType { get; set; }

        public PFMDTO00032 FReceipt { get; set; }
        public string CustomerId { get; set; }
        public IList<string> CustomerIds { get; set; }
        public IList<PFMDTO00001> CustomerDTOs { get; set; }
        public decimal MinBal { get; set; }
        public IList<string> OldCustomerIds { get; set; }
        public string Message { get; set; }
        public decimal CurrentBal { get; set; }
        public decimal OvdLimit { get; set; }

        public string OldCustomerID { get; set; }

        //Added by HWKO (15-Aug-2017)
        public virtual string CpnyRegNo { get; set; }
        public virtual Nullable<DateTime> CpnyRegDate { get; set; }
        public virtual Nullable<DateTime> CpnyRegExpDate { get; set; }
        //End Region


    }
}
