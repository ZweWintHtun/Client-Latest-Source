using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00244
    {
        public LOMDTO00244() { }
        // Account Close Entry
        public LOMDTO00244(string name,string nrc,decimal balance)
        {
            NAME = name;
            NRC = nrc;
            Balance = balance;
        }
        // Account Close Entry
        public LOMDTO00244(string retCode, string retMsg)
        {
            RetCode = retCode;
            RetMsg = retMsg;
        }
        // Account Close Entry
        public LOMDTO00244(string retCode,string retMsg,string name, string nrc, decimal balance)
        {
            RetCode = retCode;
            RetMsg = retMsg;
            NAME = name;
            NRC = nrc;
            Balance = balance;
        }
        // Account Close Listing Report
        public LOMDTO00244(string acctNo, string name, string nrc, DateTime closeDate, decimal cbal, string loanAccountType)
        {
            AcctNo = acctNo;
            NAME = name;
            NRC = nrc;
            CloseDate = closeDate;
            CBal = cbal;
            loanACType = loanAccountType;
        }

        public string RetCode { get; set; }
        public string RetMsg { get; set; }
        public string NAME { get; set; }
        public string NRC { get; set; }
        public decimal Balance { get; set; }
        
        public string AcctNo { get; set; }
        public int CreatedUserId { get; set; }
        public string SourceBr { get; set; }
        public string NoofName { get; set; }
        public string NoofNRC { get; set; }

        public string ACTypeFilter { get; set; }
        public string SortBy { get; set; }
        public string Currency { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CloseDate { get; set; }
        public decimal CBal { get; set; }
        public string rptName { get; set; }
        public string loanACType { get; set; }

       
    }
}

