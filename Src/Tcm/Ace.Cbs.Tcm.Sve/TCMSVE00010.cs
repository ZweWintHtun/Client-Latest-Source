using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Com.Ctr;

namespace Ace.Cbs.Tcm.Sve
{
    public class TCMSVE00010 : BaseService, ITCMSVE00010
    {
        public ITLMDAO00015 CashDenoDAO { get; set; }
        public ITLMDAO00009 MultipleTransactionDenoOutstandingDAO { get; set; }
        public ICXDAO00002 CodeGeneratorDAO { get; set; }

        IList<TLMDTO00015> CashDenoList { get; set; }

        public IList<TLMDTO00015> GetCashDenoList(string sourcebr, DateTime startDate, DateTime endDate, string status)
        {
            if ( status != "")
            {                
                CashDenoList = CashDenoDAO.SelectCashDenoBySourcebrAndDatetimeAndStatus(sourcebr, startDate, endDate, status);
            }
            else
            {
                CashDenoList = CashDenoDAO.SelectCashDenoBySourcebrAndDatetime(sourcebr, startDate, endDate); 
            }

            return CashDenoList;
        }

        public void DeleteDataFromDepoDeno(string sourcebr, DateTime startDate, DateTime endDate)
        {
            MultipleTransactionDenoOutstandingDAO.DeleteDataFromDepoDeno(sourcebr, startDate, endDate);            
        }

        public void DeleteDataFromCashDeno(string sourcebr, DateTime startDate, DateTime endDate, string status)
        {
            if (status != "")
            {
                CashDenoDAO.DeleteCashDenoByDatetimeAndStatus(sourcebr, startDate, endDate, status);
            }
            else
            {
                CashDenoDAO.DeleteCashDenoByDatetime(sourcebr, startDate, endDate);
            }
        }

        public void UpdateFormatDefinationMaxValue(string sourcebr, int updatedUserId, DateTime updatedDate)
        {
            CodeGeneratorDAO.UpdateMaxValueForDenominationDelete(updatedUserId, updatedDate, sourcebr);
        }
    }
}
