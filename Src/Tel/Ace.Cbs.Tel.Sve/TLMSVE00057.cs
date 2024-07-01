using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;

namespace Ace.Cbs.Tel.Sve
{
    public class TLMSVE00057 : BaseService, ITLMSVE00057
    {
        public ITLMDAO00057 DrawingOutstandingDAO { get; set; }

        public IList<TLMDTO00017> SelectDrawingOutStanding(string sourceBr)
        {
            IList<TLMDTO00017> rdDTO = this.DrawingOutstandingDAO.SelectDrawingRegisterOutstanding(sourceBr);

            if (rdDTO.Count > 0)
            {
                return rdDTO;
            }
            else
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MI00039"; //No Data For Report
                return rdDTO;
            }
        }

        public IList<TLMDTO00017> SelectDrawingOutStandingByIncomeOutstand(string sourceBr)
        {
            IList<TLMDTO00017> rdDTO = this.DrawingOutstandingDAO.SelectDrawingRegisterOutstandingByIncomeOutstand(sourceBr);

            if (rdDTO.Count > 0)
            {
                return rdDTO;
            }
            else
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MI00039"; //No Data For Report
                return rdDTO;
            }
        }

        public IList<TLMDTO00017> SelectDrawingOutStandingByDrawingAmountOutstand(string sourceBr)
        {
            IList<TLMDTO00017> rdDTO = this.DrawingOutstandingDAO.SelectDrawingRegisterOutstandingByDrawingAmountOutstand(sourceBr);

            if (rdDTO.Count > 0)
            {
                return rdDTO;
            }
            else
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MI00039"; //No Data For Report
                return rdDTO;
            }
        }
    }
}
