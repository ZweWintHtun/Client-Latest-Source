using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Gl.Dmd
{
    [Serializable]
    public class GLMDTO00001 : Supportfields<GLMDTO00001>
    {
        public GLMDTO00001 (){}

        public GLMDTO00001(int id, string formatType, string formatName)
        {
            this.Id = id;
            this.FormatType = formatType;
            this.FormatName = formatName;
            
        }

        //GLMVEW00007
        public GLMDTO00001(string formatType, string formatName, string formatStatus)
        {           
            this.FormatType = formatType;
            this.FormatName = formatName;
            this.FormatStatus = formatStatus;
        }
     
        public GLMDTO00001(int id, byte[] timestamp, string formatType, string formatName, int lno, string aCode , string dCode, string desp,
            string acRange1, string acRange2,string lRange1, string lRange2, string other, string status, string showHide, string amountTotal , string formatStatus, string normal, string uId,
            bool active, DateTime createdDate, int createdUserId, Nullable<DateTime> updatedDate, int updatedUserId)
        {
            this.Id = id;
            this.TS = timestamp;           
            this.FormatType = formatType;
            this.FormatName = formatName ;
            this.LineNo = lno;
            this.ACode = aCode;
            this.DCode = dCode ;            
            this.Description = desp;
            this.AccountRange1 = acRange1;
            this.AccountRange2 = acRange2;
            this.LineRange1 = lRange1;
            this.LineRange2 = lRange2;
            this.Other = other;
            this.Status = status;
            this.ShowHide = showHide;
            this.AmountTotal = amountTotal;
            this.FormatStatus = formatStatus;
            this.Normal = normal;
            this.UId = uId;      
            this.Active = active;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }
        
        public GLMDTO00001(int id, string formatType, string formatName, int lineNo, string acode, string dcode, string desp, string accountRange1, string accountRange2, string lineRange1, string lineRange2, string other, string status, string showHide, string amountTotal, string formatStatus, string normal)
        {
            this.Id = id;
            this.FormatType = formatType;
            this.FormatName = formatName;
            this.LineNo = lineNo;
            this.ACode = acode;
            this.DCode = dcode;           
            this.Description = desp;
            this.AccountRange1 = accountRange1;
            this.AccountRange2 = accountRange2;
            this.LineRange1 = lineRange1;
            this.LineRange2 = lineRange2;
            this.Other = other;
            this.Status = status;
            this.ShowHide = showHide;
            this.AmountTotal = amountTotal;
            this.FormatStatus = formatStatus;
            this.Normal = normal;
        }

        public GLMDTO00001(int lineNo, string aCode, string dCode, string desp, string showHide, string amountTotal, string status)
        {
            this.LineNo = lineNo; this.ACode = aCode; this.DCode = dCode; this.Description = desp; this.AmountTotal = amountTotal; this.Status = status;
        }

        public GLMDTO00001(string aCode, string dCode, decimal cBal, decimal bfAmount)
        {
            this.ACode = aCode; this.DCode = dCode; this.CBal = cBal; this.BFAmount = bfAmount;
        }

        public virtual int Id { get; set; }
        public virtual string FormatType { get; set; }
        public virtual string FormatName { get; set; }
        public virtual int LineNo { get; set; }
        public virtual string ACode { get; set; }
        public virtual string DCode { get; set; }        

        public virtual string Description { get; set; }
        public virtual string AccountRange1 { get; set; }
        public virtual string AccountRange2 { get; set; }
        public virtual string LineRange1 { get; set; }
        public virtual string LineRange2 { get; set; }
        public virtual string Other { get; set; }
        public virtual string Status { get; set; }
        public virtual string ShowHide { get; set; }
        public virtual string AmountTotal { get; set; }
        public virtual string FormatStatus { get; set; }
        public virtual string Normal { get; set; }
        public virtual string UId { get; set; }
        public bool IsCheck { get; set; }
        public virtual decimal CBal { get; set; }
        public virtual decimal BFAmount { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual decimal Total { get; set; }
    }
}
