using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    //Current Joint List DTO
    [System.Serializable]
    public class PFMDTO00063:Supportfields<PFMDTO00063>
    {
      public PFMDTO00063() { }
      
      public virtual string CusId { get; set; }
      public virtual string Name { get; set; }
      
      public virtual string NRC { get; set; }
      public virtual string Nationality { get; set; }
      public virtual string OccupationCode { get; set; }
      public virtual string Phone { get; set; }
      public virtual string Address { get; set; }
      public virtual string Fax { get; set; }
      public virtual string FatherName { get; set; }
    }
}
