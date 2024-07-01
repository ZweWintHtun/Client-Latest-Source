using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00429 
    {
        public LOMDTO00429() { }

        public LOMDTO00429(int no,int id,string acctno ,string name ,string nrc,string fatherName,string address,string companyNmae,string acsign,string absentTerm,DateTime createdDate,string userName)
        {
            //this.Id = id;
            this.No = no;
            this.AccountNo = acctno;
            this.Name = name;
            this.NRC = nrc;
            this.FatherName = fatherName;
            this.Address = address;
            this.CompanyName = companyNmae;
            this.ACSign = acsign;
            this.AbsentTerm = absentTerm;
            this.CreatedDate = createdDate;
            this.UserName = userName;
        }
        
        public virtual Int64 No { get; set; }
        public virtual int Id { get; set; }
        public virtual string AccountNo { get; set; }
        public virtual string Name { get; set; }
        public virtual string NRC { get; set; }
        public virtual string FatherName { get; set; }
        public virtual string CompanyName { get; set; }
        public virtual string Address { get; set; }
        public virtual string ACSign { get; set; }
        public virtual string AbsentTerm { get; set; }

        public virtual DateTime CreatedDate { get; set; }
        
        public virtual bool Select { get; set; }

        //public virtual int ApprovedUserId { get; set; }
        //public virtual Nullable<DateTime> ApprovedDate { get; set; }

        //public virtual int RejectedUserId { get; set; }
        //public virtual Nullable<DateTime> RejectedDate { get; set; }       
        
        public virtual string UserName { get; set; }
    }
}
