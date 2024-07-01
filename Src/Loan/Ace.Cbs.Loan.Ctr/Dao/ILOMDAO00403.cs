using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00403 : IDataRepository<LOMORM00403>
    {
        string BusinessLoansLateFeesCalculationProcess(string sourceBr, int createdUserId, string userName);

        string BusinessLoansMonthlyAutoPaymentProc(string sourceBr, int createdUserId, string userName); //Modify by HMW (06-Aug-2019) : To prevent "Voucher No Loss Issue" in every already run (or) no need to run case.
    }

}
