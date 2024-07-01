using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    // Customer Photo Entity
    [Serializable]
    public class PFMORM00010 : Supportfields<PFMORM00010>
    {
        public PFMORM00010() 
        {
          
        }
        
        // Primary Key
        public virtual int Id { get; set; }
        public virtual string CustomerId { get; set; }
        public virtual string CustPhotoName { get; set; }
        public virtual byte[] CustPhotos { get; set; }
        //public virtual byte[] TS { get; set; }
     

        // Source Branch Relation
        public virtual string SourceBranch { get; set; }

       // public virtual PFMORM00001 CustomerIds { get; set; }
    }
}