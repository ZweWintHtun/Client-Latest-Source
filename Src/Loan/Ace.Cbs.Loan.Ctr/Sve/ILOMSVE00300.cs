using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00300 : IBaseService
    {
        void CalculateFarmLoanPenalFee(string sourceBr);
    }
}
