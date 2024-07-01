using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Mnm.Ctr.Sve;
//using Ace.Cbs.Cx.Ser.Dao;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Mnm.Sve
{
    public class MNMSVE00057 :BaseService , IMNMSVE00057
    {
        #region Properties

        ICXDAO00009 ViewDAO { get; set; }
        IList<PFMDTO00017> PrintDataList { get; set; }

        #endregion

        #region MainMethod

        public IList<PFMDTO00017> GetCurrentAccountAll(DateTime startDate, DateTime endDate, string acSign, string sourceBr)     
        {
            if (acSign == "C")
            {
                PrintDataList = ViewDAO.SelectCurrentAccountAll(startDate, endDate, acSign, sourceBr);
            }
            else 
            {
                PrintDataList = ViewDAO.SelectCurrentAccountSpecific(startDate, endDate, acSign, sourceBr);
            }
            return PrintDataList;
        }

        public IList<PFMDTO00017> GetSavingAccountAll(DateTime startDate, DateTime endDate, string acSign, string sourceBr)
        {
            if (acSign == "S")
            {
                PrintDataList = ViewDAO.SelectSavingAccountAll(startDate, endDate, acSign, sourceBr);
            }
            else
            {
                PrintDataList = ViewDAO.SelectSavingAccountSpecific(startDate, endDate, acSign, sourceBr);
            }
            return PrintDataList;
        }

        // Added By HWKO (23-Jun-2017)
        public IList<PFMDTO00017> GetBusinessLoanAccountAll(DateTime startDate, DateTime endDate, string acSign, string sourceBr)
        {
            if (acSign == "B")
            {
                PrintDataList = ViewDAO.SelectBLHPPAccountAll(startDate, endDate, acSign, sourceBr);
            }
            else
            {
                PrintDataList = ViewDAO.SelectBLHPPAccountSpecific(startDate, endDate, acSign, sourceBr);
            }
            return PrintDataList;
        }

        // Added By HWKO (23-Jun-2017)
        public IList<PFMDTO00017> GetHirePurchaseLoanAccountAll(DateTime startDate, DateTime endDate, string acSign, string sourceBr)
        {
            if (acSign == "H")
            {
                PrintDataList = ViewDAO.SelectBLHPPAccountAll(startDate, endDate, acSign, sourceBr);
            }
            else
            {
                PrintDataList = ViewDAO.SelectBLHPPAccountSpecific(startDate, endDate, acSign, sourceBr);
            }
            return PrintDataList;
        }

        // Added By HWKO (23-Jun-2017)
        public IList<PFMDTO00017> GetPersonalLoanAccountAll(DateTime startDate, DateTime endDate, string acSign, string sourceBr)
        {
            if (acSign == "P")
            {
                PrintDataList = ViewDAO.SelectBLHPPAccountAll(startDate, endDate, acSign, sourceBr);
            }
            else
            {
                PrintDataList = ViewDAO.SelectBLHPPAccountSpecific(startDate, endDate, acSign, sourceBr);
            }
            return PrintDataList;
        }

        // Added By HWKO (04-Aug-2017)
        public IList<PFMDTO00017> GetDealerAccountAll(DateTime startDate, DateTime endDate, string acSign, string sourceBr)
        {
            if (acSign == "D")
            {
                PrintDataList = ViewDAO.SelectBLHPPAccountAll(startDate, endDate, acSign, sourceBr);
            }
            else
            {
                PrintDataList = ViewDAO.SelectBLHPPAccountSpecific(startDate, endDate, acSign, sourceBr);
            }
            return PrintDataList;
        }
        #endregion
    }
}
