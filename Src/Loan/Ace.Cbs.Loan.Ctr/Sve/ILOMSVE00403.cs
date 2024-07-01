using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Windows.Ix.Core.DataModel;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00403 : IBaseService
    {
        string BusinessLoansLateFeesCalculationProcess(string sourceBr, int createdUserId, string userName, IList<DataVersionChangedValueDTO> dvcvList,DateTime lateFeeRunDate);
        string BusinessLoansMonthlyAutoPaymentProc(string sourceBr, int createdUserId, string userName, IList<DataVersionChangedValueDTO> dvcvList,DateTime AutoPayRunDate);

        string BusinessLoansLateFeesAutoPayVoucherProcess(string eno, string sourceBr, int createdUserId, string userName, IList<DataVersionChangedValueDTO> dvcvList);

    }
}
