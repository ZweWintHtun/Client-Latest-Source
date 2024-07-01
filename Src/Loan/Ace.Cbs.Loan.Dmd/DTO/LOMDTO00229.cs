using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00229 : EntityBase<LOMDTO00229>
    {
        public LOMDTO00229() { }

        public LOMDTO00229(string loansGrpCode, string loansSubGrpCode, string loansBusCode, string typeOfLoans,
                            decimal totalLiveDisburse, decimal totalLiveIntInc, decimal totalLivePrinRepay,
                            decimal totalLiveIntRepay, decimal totalLivePrinOut, decimal totalLiveIntOut,
                            decimal GrTotalPrinLiveUnlive, decimal GrTotalIntLiveUnlive, decimal TotalUnlivePrin, decimal TotalUnliveInt)
        {
            LoansGroupCode = loansGrpCode;
            LoansSubGroupCode = loansSubGrpCode;
            LoansBusinessCode = loansBusCode;
            TypeOfLoans = typeOfLoans;

            TotalLiveDisbusement = totalLiveDisburse;
            TotalLiveInterestIncome = totalLiveIntInc;
            TotalLivePrincipalRepayment = totalLivePrinRepay;
            TotalLiveInterestRepayment = totalLiveIntRepay;
            TotalLivePricipalOutstanding = totalLivePrinOut;
            TotalLiveInterestOutstanding = totalLiveIntOut;

            this.GrTotalPrinLiveUnlive = GrTotalPrinLiveUnlive;
            this.GrTotalIntLiveUnlive = GrTotalIntLiveUnlive;
            this.TotalUnlivePrin = TotalUnlivePrin;
            this.TotalUnliveInt = TotalUnliveInt;
        }

        public string LoansGroupCode { get; set; }
        public string LoansSubGroupCode { get; set; }
        public string LoansBusinessCode { get; set; }
        public string TypeOfLoans { get; set; }

        public decimal TotalLiveDisbusement { get; set; }
        public decimal TotalLiveInterestIncome { get; set; }
        public decimal TotalLivePrincipalRepayment { get; set; }
        public decimal TotalLiveInterestRepayment { get; set; }
        public decimal TotalLivePricipalOutstanding { get; set; }
        public decimal TotalLiveInterestOutstanding { get; set; }

        public decimal GrTotalPrinLiveUnlive { get; set; }
        public decimal GrTotalIntLiveUnlive { get; set; }
        public decimal TotalUnlivePrin { get; set; }
        public decimal TotalUnliveInt { get; set; }


    }
}
