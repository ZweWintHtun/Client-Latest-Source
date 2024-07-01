using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Mnm.Dmd.DTO;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Mnm.Ctr.Sve;

namespace Ace.Cbs.Mnm.Sve
{
    public class MNMSVE00071 : BaseService, IMNMSVE00071
    {
        private ICXDAO00009 viewDAO;
        public ICXDAO00009 ViewDAO
        {
            get { return this.viewDAO; }
            set { this.viewDAO = value; }
        }       

        public IList<MNMDTO00071> SelectSavingAccuredInterestAll()
        {
           return this.ViewDAO.SelectSavingAccuredInterestAll(); 
        }

        public IList<MNMDTO00071> SelectSavingAccuredInterestByStartDateandEndDate(DateTime startDate,DateTime endDate)
        {
            return this.ViewDAO.SelectSavingAccuredInterestBetweenStartDateandEndDate(startDate,endDate);
        }

        public IList<MNMDTO00071> SelectSavingAccuredByCash(DateTime startDate, DateTime endDate)
        {
            return this.ViewDAO.SelectSavingAccuredInterestByCash(startDate, endDate);
        }

        public IList<MNMDTO00071> SelectSavingAccuredByTransfer(DateTime startDate, DateTime endDate)
        {
            return this.ViewDAO.SelectSavingAccuredInterestByTransfer(startDate, endDate);
        }
    }
}
