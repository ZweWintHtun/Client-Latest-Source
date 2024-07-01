using System.Collections.Generic;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    /// <summary>
    /// CurrentAccount Printing Joint DTO
    /// </summary>
   [System.Serializable]
    public class PFMDTO00061:Supportfields<PFMDTO00061>
    {
       public PFMDTO00061() { }

       public string TransactionStatus { get; set; }
       public virtual string CurrencyCode { get; set; }
       public virtual string IntroducedBy { get; set; }
       public virtual int NoOfPersonSign { get; set; }
       public virtual string JoinType { get; set; }

       public string NameOfFirm { get; set; }
       public string Email { get; set; }
       public string Address { get; set; }
       public string Phone { get; set; }
       public string Fax { get; set; }

       public virtual byte[] Logo { get; set; }
       public virtual string BankName { get; set; }
       public virtual string BranchName { get; set; }
       public string CityCode { get; set; }
       public string TownshipCode { get; set; }
       public string StateCode { get; set; }

       public string TypeOfAccount { get; set; }
       public virtual IList<PFMDTO00001> Customers { get; set; }
    }
}
