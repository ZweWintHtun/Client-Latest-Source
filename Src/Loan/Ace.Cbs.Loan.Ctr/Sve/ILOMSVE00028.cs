using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Sve 
{
    public interface ILOMSVE00028 : IBaseService
    {
        IList<LOMDTO00013> CheckLegalLoanNo(string loanNo, string sourceBr);
        void SaveLegalODRepayment(IList<LOMDTO00013> repaymentInfo,decimal currentBalance, string channel, string sourceBr, int workStationId, string currentUserName, int currentUserId);
    }
}
