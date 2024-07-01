using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    /// <summary>
    /// DTO for VW_ExpireLeaseLandListing
    /// Created By HWKO (11-Jul-2017)
    /// </summary>
    ///
    [Serializable]
    public class LOMDTO00314: Supportfields<LOMDTO00314>
    {
        public LOMDTO00314() { }

        //Updated By ZMS (15-Nov-2017)
        public LOMDTO00314(int id, string lno, string acctNo, decimal sAmt, string landDesp,
            DateTime establishmentDate, decimal capital, DateTime landLeaseSDate, DateTime landLeaseEDate,
            string isDesp, DateTime isStartedDate, DateTime isExpiredDate, decimal isAmt,
            string cusName, string cusAddress, string cusPhone, string sourceBr, bool active,string blType)
        {
            this.Id = id;
            this.Lno = lno;
            this.AcctNo = acctNo;
            this.SAmt = sAmt;
            this.LandDesp = landDesp;
            this.EDate = establishmentDate;
            this.Capital = capital;
            this.LandLeaseSDate = landLeaseSDate;
            this.LandLeaseEDate = landLeaseEDate;
            this.IsDesp = isDesp;
            this.IsStartedDate = isStartedDate;
            this.IsExpiredDate = isExpiredDate;
            this.IsAmt = isAmt;
            this.CusName = cusName;
            this.CusAddress = cusAddress;
            this.CusPhone = cusPhone;
            this.SourceBr = sourceBr;
            this.Active = active;
            this.LoansBusinessTypeDesp = blType;
        }

        public LOMDTO00314(DateTime selectedDate, string sourceBr)
        {
            this.SelectedDate = selectedDate;
            this.SourceBr = sourceBr;
        }

        public virtual int Id { get; set; }
        public virtual string Lno { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual decimal SAmt { get; set; }
        public virtual string LandDesp { get; set; }
        public virtual DateTime EDate { get; set; }
        public virtual decimal Capital { get; set; }
        public virtual DateTime LandLeaseSDate { get; set; }
        public virtual DateTime LandLeaseEDate { get; set; }
        public virtual string IsDesp { get; set; }
        public virtual DateTime IsStartedDate { get; set; }
        public virtual DateTime IsExpiredDate { get; set; }
        public virtual decimal IsAmt { get; set; }
        public virtual string CusName { get; set; }
        public virtual string CusAddress { get; set; }
        public virtual string CusPhone { get; set; }
        public virtual string SourceBr { get; set; }

        public virtual DateTime SelectedDate { get; set; }
        public virtual string LoansBusinessTypeDesp { get; set; }
    }
}
