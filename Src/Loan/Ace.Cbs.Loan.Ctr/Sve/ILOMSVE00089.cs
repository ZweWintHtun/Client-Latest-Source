using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00089 : IBaseService
    {
        void CalculateInterest(DateTime withdrawDate, DateTime repaymentDate);
    }
}
