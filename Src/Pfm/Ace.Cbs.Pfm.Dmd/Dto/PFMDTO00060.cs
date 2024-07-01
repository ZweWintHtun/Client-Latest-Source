using System;
//Printing -> Opening Form Printing ->Current Account Individual 
namespace Ace.Cbs.Pfm.Dmd
{
    [System.Serializable]
   public class PFMDTO00060
    {
       public PFMDTO00060() { }

       public string CustomerId { get; set; }
       public string Name { get; set; }
       public string FatherName { get; set; }
       public string Address { get; set; }
       public string Occupation { get; set; }
       public string Nationality { get; set; }
       public string NRC { get; set; }
       public string IntroducedBy { get; set; }
       public string Phone { get; set; }
       public byte[] Logo { get; set; }
       public string BankName { get; set; }
       public string BranchName { get; set; }
       public string Currency { get; set; }
       public string TypeOfAccount { get; set; }
       public string EMail { get; set; }
       public string GuardianName { get; set; }
       public string Fax { get; set; }
       public string GuardianNRC { get; set; }
       public string CityCode { get; set; }
       public string StateCode { get; set; }
       public string TownshipCode { get; set; }
       public DateTime DateOfBirth { get; set; }
       public byte[] Photo { get; set; }
       public byte[] Signature { get; set; }
       public DateTime MatureDate { get; set; }
    }
}
