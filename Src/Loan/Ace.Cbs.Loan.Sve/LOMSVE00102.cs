using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Sve
{
    public class LOMSVE00102 : BaseService, ILOMSVE00102
    {
        #region Properties
        private ILOMDAO00102 _allloanRecordDAO;
        public ILOMDAO00102 AllLoanRecordDAO
        {
            get { return this._allloanRecordDAO; }
            set { this._allloanRecordDAO = value; }
        }
        #endregion

        #region Method
        public IList<LOMDTO00102> GetLoanRecordList(string townshipCode, DateTime startDate, DateTime endDate, string type) 
        {
            try
            {
                return this.AllLoanRecordDAO.GetLoanRecordList(townshipCode, startDate, endDate, type);
            }
            catch { return null; }
        }
        #endregion
    }
}
