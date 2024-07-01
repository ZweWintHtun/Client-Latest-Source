using System;
using Ace.Windows.Core.DataModel;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    //ChequeDTO
    [Serializable]
    public class PFMDTO00006 : Supportfields<PFMDTO00006>
    {
        public PFMDTO00006() { }
        public PFMDTO00006(string chequeBookNo) 
        {
            this.ChequeBookNo = chequeBookNo;
            
        }

        //SelectStartNoAndEndNoByChequeBookNo
        public PFMDTO00006(string accountNo, string chequeBookNo, string startNo, string endNo, string currencyCode) //Added by ASDA  
        {
            this.AccountNo = accountNo;
            this.ChequeBookNo = chequeBookNo;
            this.StartNo = startNo;
            this.EndNo = endNo;          
            this.CurrencyCode = currencyCode;            
        }
        
        public PFMDTO00006(string accountNo, string chequeBookNo, string startNo, string endNo)
        {
            this.AccountNo = accountNo;
            this.ChequeBookNo = chequeBookNo;
            this.StartNo = startNo;
            this.EndNo = endNo;                 
        }

        public PFMDTO00006(string ChequeBookNo, string StartNo, string EndNo)
        {
            this.ChequeBookNo = ChequeBookNo;
            this.StartNo = StartNo;
            this.EndNo = EndNo;
        }


        public PFMDTO00006(string startNo , string endNo)
        {
            this.StartNo = startNo;
            this.EndNo = endNo;
        }

        //SelectChequeInfoByChequeBookNo
        public PFMDTO00006(string accountNo, System.Nullable<DateTime> issueDate, string chequeBookNo, string startNo, string endNo,DateTime closedate, bool active)
        {            
            this.AccountNo = accountNo;
            this.IssueDate = issueDate;
            this.ChequeBookNo = chequeBookNo;
            this.StartNo = startNo;
            this.EndNo = endNo;
            this.CloseDate = closedate;
            this.Active = active;
        }

        //<!-- PFMDAO00006.SelectIssuedChequeByAccount-->
        public PFMDTO00006(string accountNo, System.Nullable<DateTime> issueDate, string chequeBookNo, string startNo, string endNo,bool active)
        {
            this.AccountNo = accountNo;
            this.IssueDate = issueDate;
            this.ChequeBookNo = chequeBookNo;
            this.StartNo = startNo;
            this.EndNo = endNo;
            this.Active = active;
        }





        // Primary Key
        public virtual string ChequeBookNo { get; set; }
        public virtual string AccountNo { get; set; }
        public virtual string SourceBranchCode { get; set; }
        public virtual string CurrencyCode { get; set; }
        public virtual string StartNo { get; set; }
        public virtual string EndNo { get; set; }
        public virtual System.Nullable<DateTime> CloseDate { get; set; }
        public virtual System.Nullable<DateTime> IssueDate { get; set; }
        public virtual string UserNo { get; set; }
        public virtual string AccountSign { get; set; }
        public bool IsMainMenu { get; set; }
        public virtual string Status { get; set; }
        public virtual string SourceBr { get; set; }
        //Source Branch Relation
        public virtual BranchDTO Branch { get; set; }

        //Cledger AccountNo Relation
        public virtual PFMDTO00028 Cledger { get; set; }

        //Currency Relation
        public virtual CurrencyDTO Currency { get; set; }
    }
}