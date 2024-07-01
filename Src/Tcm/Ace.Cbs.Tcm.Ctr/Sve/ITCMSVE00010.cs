using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Tcm.Ctr.Sve
{
    public interface ITCMSVE00010 : IBaseService
    {
        IList<TLMDTO00015> GetCashDenoList(string sourcebr, DateTime startDate, DateTime endDate, string status);
        void DeleteDataFromCashDeno(string sourcebr, DateTime startDate, DateTime endDate, string status);
        //string GetTlf_Eno(string sourcebr, DateTime startDate, DateTime endDate, string status);
        void DeleteDataFromDepoDeno(string sourcebr, DateTime startDate, DateTime endDate);
        void UpdateFormatDefinationMaxValue(string sourcebr, int updatedUserId, DateTime updatedDate);
    }
}
