using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Pfm.Dmd;
namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00027 : IBaseService
    {
        IList<LOMDTO00013> CheckLegalLoanNo(string loanNo, string sourceBr);
        IList<PFMDTO00072> GetCustNames(string AccNo);
        void SaveLoanRepayment(IList<LOMDTO00013> GridDataSource,decimal currentBalance,string currency, string channel,string sourceBr, int workStationId, string currentUserName, int currentUserId);
    }
}
