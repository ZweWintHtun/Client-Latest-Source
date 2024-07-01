using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00427 : Supportfields<LOMDTO00406>
    {
        public LOMDTO00427() { }

        public LOMDTO00427(string acctNo, string name, string nRC, string fName, string cName, string absentTerm,DateTime dob,string address,string cAddress)
        {
            this.AccountNo = acctNo;
            this.Name = name;
            this.NRC = nRC;
            this.FatherName = fName;
            this.CompanyName = cName;
            this.AbsentTerm = absentTerm;
            this.DOB = dob;
            this.Address = address;
            this.CompanyAddress = cAddress;
        }
        public LOMDTO00427(string custid,string acctNo, string name, string nRC, string fName,
                           string contactPh,string address,string cName, string absentTerm,string userName, DateTime entryDate,string approveDate)
        {
            this.CustId = custid;
            this.AccountNo = acctNo;
            this.Name = name;
            this.NRC = nRC;
            this.FatherName = fName;
            this.ContactPhNo = contactPh;
            this.Address = address;

            if (cName == "" || cName == string.Empty)
                this.CompanyName = "-";
            else this.CompanyName = cName;

            if (absentTerm == "" || absentTerm == string.Empty)
                this.AbsentTerm = "-";
            else this.AbsentTerm = absentTerm;

            this.UserName = userName;
            this.CreatedDate = entryDate;
            this.ApprovedUserName = ApprovedUserName;
        }
        public LOMDTO00427(string name, string nRC, string fName, Nullable<DateTime> dob, string address,
                           string companyName, string userName, DateTime entryDate, string approveDate, string approvedUserName)
        {
            this.Name = name;
            this.NRC = nRC;
            this.FatherName = fName;
            this.DOB = dob;            
            this.Address = address;
            this.CompanyName = companyName;
            this.UserName = userName;
            this.CreatedDate = entryDate;
            this.ApprovedUserName = approvedUserName;
        }
        public LOMDTO00427(string name, string nRC, string fName, Nullable<DateTime> dob, string address,
                          string companyName, string userName, DateTime entryDate, string approveDate, string approvedUserName, string removedUserName)
        {
            this.Name = name;
            this.NRC = nRC;
            this.FatherName = fName;
            this.DOB = dob;
            this.Address = address;
            this.CompanyName = companyName;
            this.UserName = userName;
            this.CreatedDate = entryDate;
            this.ApprovedUserName = approvedUserName;
            this.RemovedUserName = removedUserName;
        }
        public virtual string AccountNo { get; set; }
        public virtual string Name { get; set; }
        public virtual string NRC { get; set; }
        public virtual string FatherName { get; set; }
        public virtual string CompanyName { get; set; }
        public virtual string AbsentTerm { get; set; }
        public virtual Nullable<DateTime> DOB { get; set; }
        public virtual string Address { get; set; }
        public virtual string CompanyAddress { get; set; }

        public virtual string saveResult { get; set; }
        public virtual string BranchCode { get; set; }

        public virtual string AccountType { get; set; }
        public virtual bool Select { get; set; }

        public virtual int ApprovedUserId { get; set; }
        public virtual Nullable<DateTime> ApprovedDate { get; set; }

        public virtual int RemovedUserId { get; set; }
        public virtual Nullable<DateTime> RemovedDate { get; set; }
        public virtual string RemovedUserName { get; set; }

        public virtual int Id { get; set; }
        public virtual Int64 No { get; set; }
        public virtual string ACSign { get; set; }
        public virtual string UserName { get; set; }
        public virtual string CustId { get; set; }
        public virtual string ApprovedUserName { get; set; }
        public virtual string ContactPhNo { get; set; }
        public virtual string UserType { get; set; }

        public virtual bool IsEntry { get; set; }
        public virtual bool IsApprove { get; set; }
        public virtual int UserId { get; set; }
    }
}
