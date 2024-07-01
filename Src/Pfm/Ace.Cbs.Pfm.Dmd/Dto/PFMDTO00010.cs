using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    // Customer Photo dto
    [Serializable]
    public class PFMDTO00010 : Supportfields<PFMDTO00010>
    {
        public PFMDTO00010()
        {
            
        }

        public PFMDTO00010(string customerId)
        {
            this.CustomerId = customerId;
        }

        public PFMDTO00010(string customerid, byte[] customerPhoto) 
        {
            this.CustomerId = customerid;
            this.CustPhotos = customerPhoto;
        }

       //public PFMDTO00010(int id, string customerid, byte[] customerPhoto, string custPhotoName,string sourceBr, byte[] tS, bool active, int createdUserId, System.Nullable<int> updatedUserId, System.Nullable<DateTime> updatedDate, DateTime createdDate)
       //{
       //    this.Id = id;
       //    this.CustomerId = customerid;
       //    this.CustPhotos = customerPhoto;
       //    this.CustPhotoName = custPhotoName;
       //    this.SourceBranch = sourceBr;
       //    this.TS = tS;
       //    this.Active = active;
       //    this.CreatedUserId = createdUserId;
       //    this.CreatedDate = createdDate;
       //    this.UpdatedUserId = updatedUserId;
       //    this.UpdatedDate = updatedDate;        

       //}

        //update
       public PFMDTO00010(  string custphotoname,byte[] custphotos, string sourcebranch, DateTime updateddate,Int32 updateduserId)
       {          
           this.CustPhotoName = custphotoname;
           this.CustPhotos = custphotos;
           this.SourceBranch = sourcebranch;          
           this.UpdatedDate = updateddate;
           this.UpdatedUserId = updateduserId;
       }
      

        // Primary Key
        public virtual int Id { get; set; }
        public virtual string CustPhotoName { get; set; }
        public virtual string CustomerId { get; set; }

        public virtual byte[] CustPhotos { get; set; }       

        // Source Branch Relation
        public virtual string SourceBranch { get; set; }

        // Customer Id Relation
       // public virtual PFMDTO00001 CustomerIds { get; set; }
    }
}