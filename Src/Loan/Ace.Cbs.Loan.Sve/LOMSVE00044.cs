using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Dao;

namespace Ace.Cbs.Loan.Sve
{
    public class LOMSVE00044 : BaseService, ILOMSVE00044
    {
        private ILOMDAO00044 oDCalculationDAO;
        public ILOMDAO00044 ODCalculationDAO
        {
            get { return this.oDCalculationDAO; }
            set { this.oDCalculationDAO = value; }
        }

        public void CalculateODInterest(LOMDTO00044 dto)
        {
            oDCalculationDAO.CalculateODInterest(dto);
        }
    }
}
