using System.Collections.Generic;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    /// <summary>
    /// Printing Current Account Company DTO
    /// </summary>
    [System.Serializable]
    public class PFMDTO00062 : Supportfields<PFMDTO00062>
    {
        public PFMDTO00062()
        {
            this.Customers = new List<PFMDTO00001>();
        }

        public string CurrencyCode { get; set; }
        public string NameOfFirm { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string IntroducedBy { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public int NoOfPersonToSignInput { get; set; }
        public byte[] Logo { get; set; }
        public string BankName { get; set; }
        public string BranchDesp { get; set; }
        public string Parameter { get; set; }
        public string CityCode { get; set; }
        public string TownshipCode { get; set; }
        public string StateCode { get; set; }
        public virtual IList<PFMDTO00001> Customers { get; set; }
    }
}
