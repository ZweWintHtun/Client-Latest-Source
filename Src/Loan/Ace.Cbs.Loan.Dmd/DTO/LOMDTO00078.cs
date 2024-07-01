using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMDTO00078 : Supportfields<LOMDTO00078>
    {
        public LOMDTO00078() { }

        public LOMDTO00078(string lno, string acctNo, string loanProductType)
        {
            this.Lno = lno;
            this.AcctNo = acctNo;
            this.LoanProductType = loanProductType;
        }

        public LOMDTO00078(string lno, string acctNo, Nullable<decimal> samt, DateTime withdrawDate)
        {
            this.Lno = lno;
            this.AcctNo = acctNo;
            this.SAmt = samt;
            this.WithdrawDate = withdrawDate;
        }

        public LOMDTO00078(string lno, string acctno, string atype, string loanType, string loanProductType,
            Nullable<DateTime> sDate, Nullable<decimal> sAmt, Nullable<DateTime> expireDate, Nullable<decimal> firstSAmt, Nullable<DateTime> lastIntDate,
            Nullable<decimal> intRate, Nullable<decimal> penalties, bool vourched, Nullable<DateTime> vourchedDate, string name, string fatherName,
            string nrc, string village, string townShip, string address, string farmName, string landNo,
            string landType, string seasonType, string businessType, string groupNo,
            string startPeriod, string endPeriod, Nullable<DateTime> withdrawDate, Nullable<decimal> loanAmtPerAcre,
            Nullable<decimal> totalAcre, string remark, string acSign,
            string sourceBr, string cur, byte[] firmSign, byte[] cusSign)
        {
            this.Lno = lno;
            this.AcctNo = acctno;
            this.AType = atype;
            this.LoanType = loanType;
            this.LoanProductType = loanProductType;
            this.SDate = sDate;
            this.SAmt = sAmt;
            this.ExpireDate = expireDate;
            this.FirstSAmt = firstSAmt;
            this.LastIntDate = lastIntDate;
            this.IntRate = intRate;
            this.Penalties = penalties;
            bool Vourched = vourched;
            this.VourchedDate = vourchedDate;
            this.Name = name;
            this.FatherName = fatherName;
            this.NRC = nrc;
            this.Village = village;
            this.Township = townShip;
            this.Address = address;
            this.FarmName = farmName;
            this.LandNo = landNo;
            this.LandType = landType;
            this.SeasonType = seasonType;
            this.BusinessType = businessType;
            this.GroupNo = groupNo;
            this.StartPeriod = startPeriod;
            this.EndPeriod = endPeriod;
            this.WithdrawDate = withdrawDate;
            this.LoanAmtPerAcre = loanAmtPerAcre;
            this.TotalAcre = totalAcre;
            this.Remark = remark;
            this.ACSign = acSign;
            this.SourceBr = sourceBr;
            this.Cur = cur;
            this.FarmSignature = firmSign;
            this.Signature = cusSign;
        }

        public LOMDTO00078(string lno, string acctno, Nullable<DateTime> sDate,
            Nullable<decimal> samt, string startPeriod, string endPeriod,
            Nullable<DateTime> withdrawDate, string sourceBr, string cur)
        {
            this.Lno = lno;
            this.AcctNo = acctno;
            this.SDate = sDate;
            this.SAmt = samt;
            this.StartPeriod = startPeriod;
            this.EndPeriod = endPeriod;
            this.WithdrawDate = withdrawDate;
            this.SourceBr = sourceBr;
            this.Cur = cur;
        }

        #region LoanRepayment
        public LOMDTO00078(string lno)
        {
            this.Lno = lno;
        }

        public LOMDTO00078(string acctNo, string loanType, string displayName, bool active)
        {
            this.AcctNo = acctNo;
            this.LoanType = loanType;
            this.DisplayName = displayName;
            this.Active = active;
        }

        public LOMDTO00078(string lno, string accountno, System.Nullable<decimal> samt, string loanType, string cur)
        {
            this.AcctNo = accountno;
            this.Lno = lno;
            this.SAmt = samt;
            this.LoanType = loanType;
            this.Cur = cur;
        }

        public LOMDTO00078(string resultCode, string creditAccountDesp, string interestAccountDesp, decimal interest, string creditAccountCode, string interestAccountCode, string lastRepaymentNo)
        {
            this.ResultCode = resultCode;
            this.CreditAccountDesp = creditAccountDesp;
            this.InterestAccountDesp = interestAccountDesp;
            this.Interest = interest;
            this.CreditAccountCode = creditAccountCode;
            this.InterestAccountCode = InterestAccountCode;
            this.LastRepaymentNo = LastRepaymentNo;
        }

        public LOMDTO00078(string resultCode, string lno, string acctNo, decimal sAmount, string loans_type, string currency, string name, string accountName, string creditAccountDesp, string debitAccountCode, string sDate)
        {
            this.ResultCode = resultCode;
            this.Lno = lno;
            this.AcctNo = acctNo;
            this.SAmt = sAmount;
            this.LoanType = loans_type;
            this.Cur = currency;
            this.Name = name;
            this.AccountName = accountName;
            this.CreditAccountDesp = creditAccountDesp;
            this.DebitAccountCode = debitAccountCode;
            this.StartDate = sDate;
            //this.Interest = interest;
        }

        /* For Interest */
        public LOMDTO00078(decimal InterestAmount)
        {
            this.InterestAmount = InterestAmount;
        }
        #endregion

        public LOMDTO00078(string lno, string acctno, string atype, string loanType, string loanProductType,
            Nullable<DateTime> sDate, Nullable<decimal> sAmt, Nullable<DateTime> expireDate, Nullable<decimal> firstSAmt, Nullable<DateTime> lastIntDate,
            Nullable<decimal> intRate, Nullable<decimal> penalties, bool vourched, Nullable<DateTime> vourchedDate, string name, string fatherName,
            string nrc, string village, string townShip, string address, string farmName, string landNo,
            string landType, string seasonType, string businessType, string groupNo,
            string startPeriod, string endPeriod, Nullable<DateTime> withdrawDate, Nullable<decimal> loanAmtPerAcre,
            Nullable<decimal> totalAcre, string remark, string acSign, string uId,
            string sourceBr, string cur, bool active, byte[] tS, DateTime createdDate, int createdUserId,
            Nullable<DateTime> updatedDate, Nullable<int> updatedUserId)
        {
            this.Lno = lno;
            this.AcctNo = acctno;
            this.AType = atype;
            this.LoanType = loanType;
            this.LoanProductType = loanProductType;
            this.SDate = sDate;
            this.SAmt = sAmt;
            this.ExpireDate = expireDate;
            this.FirstSAmt = firstSAmt;
            this.LastIntDate = lastIntDate;
            this.IntRate = intRate;
            this.Penalties = penalties;
            bool Vourched = vourched;
            this.VourchedDate = vourchedDate;
            this.Name = name;
            this.FatherName = fatherName;
            this.NRC = nrc;
            this.Village = village;
            this.Township = townShip;
            this.Address = address;
            this.FarmName = farmName;
            this.LandNo = landNo;
            this.LandType = landType;
            this.SeasonType = seasonType;
            this.BusinessType = businessType;
            this.GroupNo = groupNo;
            this.StartPeriod = startPeriod;
            this.EndPeriod = endPeriod;
            this.WithdrawDate = withdrawDate;
            this.LoanAmtPerAcre = loanAmtPerAcre;
            this.TotalAcre = totalAcre;
            //this.FarmSignature = farmSig;
            //this.Signature = signature;
            this.Remark = remark;
            this.ACSign = acSign;
            this.UniqueId = uId;
            this.SourceBr = sourceBr;
            this.Cur = cur;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public virtual string Lno { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual string AType { get; set; }
        public virtual string LoanType { get; set; }
        public virtual string LoanProductType { get; set; }
        public virtual Nullable<DateTime> SDate { get; set; }
        public virtual Nullable<decimal> SAmt { get; set; }
        public virtual string Budget { get; set; }
        public virtual Nullable<DateTime> CloseDate { get; set; }
        public virtual Nullable<DateTime> ExpireDate { get; set; }
        public virtual Nullable<decimal> FirstSAmt { get; set; }
        public virtual Nullable<DateTime> LastIntDate { get; set; }
        public virtual Nullable<decimal> IntRate { get; set; }
        public virtual Nullable<decimal> Penalties { get; set; }
        public virtual bool Vourched { get; set; }
        public virtual Nullable<DateTime> VourchedDate { get; set; }
        public virtual string Name { get; set; }
        public virtual string FatherName { get; set; }
        public virtual string NRC { get; set; }
        public virtual string Village { get; set; }
        public virtual string Township { get; set; }
        public virtual string Address { get; set; }
        public virtual string FarmName { get; set; }
        public virtual string LandNo { get; set; }
        public virtual string LandType { get; set; }
        public virtual string SeasonType { get; set; }
        public virtual string BusinessType { get; set; }
        public virtual string GroupNo { get; set; }
        public virtual string StartPeriod { get; set; }
        public virtual string EndPeriod { get; set; }
        public virtual Nullable<DateTime> WithdrawDate { get; set; }
        public virtual Nullable<decimal> LoanAmtPerAcre { get; set; }
        public virtual Nullable<decimal> TotalAcre { get; set; }
        public virtual byte[] FarmSignature { get; set; }
        public virtual byte[] Signature { get; set; }
        public virtual string Remark { get; set; }
        public virtual string ACSign { get; set; }
        public virtual string UniqueId { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }

        public virtual string GuaranteeAccountNo1 { get; set; }
        public virtual string GuaranteeAccountNo2 { get; set; }

        //Not included in table fields
        public virtual string status { get; set; }

        #region LoanRepayment
        public virtual string CreditAccountDesp { get; set; }
        public virtual string InterestAccountDesp { get; set; }
        public virtual decimal WithdrawableBalance { get; set; }
        public virtual string CreditAccountCode { get; set; }
        public virtual string InterestAccountCode { get; set; }
        public virtual decimal Interest { get; set; }
        public virtual string AccountName { get; set; }
        public virtual string DebitAccountCode { get; set; }
        public virtual string LastRepaymentNo { get; set; }

        public virtual string ResultCode { get; set; }
        public virtual decimal RepaymentAmount { get; set; }
        public virtual decimal TotalOutstanding { get; set; }
        public virtual decimal TotalInterest { get; set; }
        public virtual string RepaymentNo { get; set; }
        public virtual string VrNo { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual string StartDate { get; set; }
        public virtual decimal InterestAmount { get; set; }
        #endregion

        public virtual LOMDTO00015 Land_buildingDto { get; set; }
        public virtual LOMDTO00079 Per_guaranteeDto { get; set; }
        public virtual IList<PFMDTO00072> LoanAcctnoInfoList { get; set; }
        public virtual IList<LOMDTO00085> FarmLiList { get; set; }

    }
}
