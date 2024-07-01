using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    /// <summary>
    /// Printing Current Account Company List (CustomerInfo) DTO
    /// </summary>
    [System.Serializable]
    public class PFMDTO00064:Supportfields<PFMDTO00064>
    {
        public PFMDTO00064() { }

        public virtual string CustomerId { get; set; }
        public virtual string Name { get; set; }
        public virtual string FatherName { get; set; }
        public virtual string NRC { get; set; }
        public virtual string Address { get; set; }
        public virtual string OccupationCode { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Fax { get; set; }
        public virtual string Nationality { get; set; }
    }
}
