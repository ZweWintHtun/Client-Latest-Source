using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    /// <summary>
    /// Used Cheque DTO Entity
    /// </summary>
     [Serializable]
    public class PFMDTO00020 : EntityBase<PFMDTO00020>
    {
        public PFMDTO00020() { }

        public PFMDTO00020(string chequeNo)
        {
            this.ChequeNo = chequeNo;
        }

        public PFMDTO00020(string chequeNo, string accountNo, string accountSignature, DateTime dateTime, string userNo)
        {
            this.ChequeNo = chequeNo;
            this.AccountNo = accountNo;
            this.AccountSignature = accountSignature;
            this.DATE_TIME = dateTime;
            this.USERNO = userNo;
        }

        public PFMDTO00020(int id,string chequeNo, string accountNo, string accountSignature,string channel, DateTime dateTime, string userNo, string sourcebr, bool active,DateTime createdDate, int createdUsedId, DateTime updatedDate, int updatedUserId)
        {
            this.Id = id;
            this.ChequeNo = chequeNo;
            this.AccountNo = accountNo;
            this.AccountSignature = accountSignature;
            this.Channel = channel;
            this.DATE_TIME = dateTime;
            this.USERNO = userNo;
            this.SourceBranchCode = userNo;
            this.Active = active;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUsedId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }    

        public string ChequeNo { get; set; }
        public string AccountNo { get; set; }
        public string AccountSignature { get; set; }
        public string Channel { get; set; }
        public Nullable<DateTime> DATE_TIME { get; set; }
        public string USERNO { get; set; }
        public string SourceBranchCode { get; set; }
    }
}