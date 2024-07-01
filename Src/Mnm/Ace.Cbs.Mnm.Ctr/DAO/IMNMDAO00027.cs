using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Dao
{
    public interface IMNMDAO00027:IDataRepository<MNMORM00027>
    {
        int SelectMaxId();
        IList<MNMDTO00027> SelectByAccountNo(string accountNo);
        bool UpdateSChargeForInterestEdit(string accountNo, decimal lastCalculateInt, string month1, string month2, string month3, decimal interest1, decimal interest2, decimal interest3, int updatedUserId);
        MNMDTO00027 SelectSCharge(string InterestMonths, string budmth, string accountNo, string lno, string sourceBr);
        IList<MNMDTO00027> SelectByLoanNo(string accountNo, string loanNo);
       IList<MNMDTO00027> SelectByLoansNo(string loanNo, string accountNo,string sourceBr);
    }
}
