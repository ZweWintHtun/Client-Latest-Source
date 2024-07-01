using System;
using Ace.Windows.Core.DataModel;
using Ace.Windows.Admin.DataModel;
namespace Ace.Cbs.Pfm.Dmd
{
     [Serializable]
    public class PFMDTO00011 : Supportfields<PFMDTO00011>
    {
        //Stop Cheque DTO

        public PFMDTO00011()
        {
        }

        public PFMDTO00011(string accountNo, string chequeBookNo, string sourceBranchCode, string startNo, string endNo)
        {
            this.AccountNo = accountNo;
            this.ChequeBookNo = chequeBookNo;
            this.SourceBranchCode = sourceBranchCode;
            this.StartNo = startNo;
            this.EndNo = endNo;
        }

        public PFMDTO00011(string accountNo,string chequeBookNo,string sourceBranchCode,string startNo,string endNo, bool active )
        {
            this.AccountNo = accountNo;
            this.ChequeBookNo = chequeBookNo;
            this.SourceBranchCode = sourceBranchCode;
            this.StartNo = startNo;
            this.EndNo = endNo;
            this.Active = active;
        }

        public PFMDTO00011(string accountNo, string chequeBookNo, string startNo, string endNo, string remark, DateTime dateTime)
        {
            this.AccountNo = accountNo;
            this.ChequeBookNo = chequeBookNo;
            this.StartNo = startNo;
            this.EndNo = endNo;
            this.Remark = remark;
            this.DATE_TIME = dateTime;
        }
       
        public virtual int Id { get; set; }
        public virtual string AccountNo { get; set; }
        public virtual string ChequeBookNo { get; set; }
        public virtual string SourceBranchCode { get; set; }
        public virtual PFMORM00028 CLedger { get; set; } // For Account No 
        public virtual PFMORM00006 Cheque { get; set; } // For CheckBook
        public virtual Branch Branch { get; set; } // For SourceBranchCode
        public virtual string StartNo { get; set; }
        public virtual string EndNo { get; set; }
        public virtual string Remark { get; set; }
        public virtual System.Nullable<DateTime> DATE_TIME { get; set; }
        public virtual string USERNO { get; set; }
        public virtual string Name { get; set; }
        public virtual string SrNo { get; set; }
        public virtual string Date { get; set; }
        public virtual string NRC { get; set; }
        public virtual string CloseAccount { get; set; }
    }
}