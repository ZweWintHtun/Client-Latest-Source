using System;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    // CustomerId Entity
    [Serializable]
    public class PFMORM00001: Supportfields<PFMORM00001>
    {
        public PFMORM00001() 
        {
            this.CustPhoto = new PFMORM00010();         
        }

        public virtual string CustomerId { get; set; }
        public virtual string Name { get; set; }
        public virtual Boolean IsNRC { get; set; }
        public virtual string NRC { get; set; }
        public virtual string GuardianName { get; set; }
        public virtual Boolean IsGuardianNRC { get; set; }
        public virtual string GuardianNRCNo { get; set; }
        public virtual string FatherName { get; set; }
        public virtual string Address { get; set; }
        public virtual decimal CloseAC { get; set; }
        public virtual decimal OpenAC { get; set; }
        public virtual System.Nullable<DateTime> CloseDate { get; set; }
        public virtual string PhoneNo { get; set; }
        public virtual string FaxNo { get; set; }
        public virtual string Email { get; set; }
        public virtual byte[] Signature { get; set; }        
        public virtual byte[] CusPhotos { get; set; }
        public virtual Boolean IsVIP { get; set; }
        public virtual string Gender { get; set; }
        public virtual string Remark { get; set; }
        public virtual string PassportNo { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
        public virtual DateTime DATE_TIME { get; set; }
        public virtual string USERNO { get; set; }
        public virtual byte[] Photo { get; set; }
        public virtual string NameOnly { get; set; }        
        public virtual string NickName { get; set; }
        public virtual string SourceBranch { get; set; }       
        public virtual string CityCode { get; set; }
        public virtual string Initial{ get; set; }
        public virtual string OccupationCode { get; set; }
        public virtual string TownshipCode { get; set; }
        public virtual string StateCode { get; set; }
        public virtual string Nationality { get; set; }
        public virtual PFMORM00016 SAOF { get; set; }
        public virtual PFMORM00017 CAOF { get; set; }
        public virtual PFMORM00021 FAOF { get; set; }
        public virtual PFMORM00010 CustPhoto { get; set; }
        public virtual PFMORM00004 Occupation { get; set; }
        public virtual Township Township { get; set; }
        public virtual City City { get; set; }
        public virtual State State { get; set; }
        public virtual PFMORM00003 InitialEntity { get; set; }
      
    }
}