using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Gl.Dmd;
using Ace.Cbs.Gl.Dmd.Dto;

namespace Ace.Cbs.Gl.Ctr.Sve
{
    public interface IGLMSVE00028 : IBaseService
    {
        object GetPropertyPlanAndEquipment(string requireMonth, string currency, string sourceBr);
        object GetSoftwareAndNetworkEquipment(string requireMonth, string currency, string sourceBr);
        //object GetLoansAndHPAmount(string requireMonth, string currency, string sourceBr);//Commented by HWKO (22-Dec-2017)
        object GetLoansAmount(string requireMonth, string currency, string sourceBr);//Added by HWKO (22-Dec-2017)
        object GetHPAmount(string requireMonth, string currency, string sourceBr);//Added by HWKO (22-Dec-2017)
        object GetOtherAssets(string requireMonth, string currency, string sourceBr);
        object GetCashAndCashEquivalent(string requireMonth, string currency, string sourceBr);
        object GetInterCompanyReceivable(string requireMonth, string currency, string sourceBr);
        object GetPaidUpCapital(string requireMonth, string currency, string sourceBr);
        object GetOtherReserves(string requireMonth, string currency, string sourceBr);
        object GetRetainedEarnings(string requireMonth, string currency, string sourceBr);
        object GetSundryDepositAndOtherPayables(string requireMonth, string currency, string sourceBr);
        object GetProfit(string requireMonth, string currency, string sourceBr);
        object GetLoss(string requireMonth, string currency, string sourceBr);
        object GetOverdraft(string requireMonth, string currency, string sourceBr);//Added by HWKO (01-Dec-2017)
        IList<GLMDTO00028> Get_SFP_Report_Data(string requireMonth, string sourceBr);

        string GetBudYear(int service, DateTime reqDate, string sourceBr);//added by ZMS to get active Budget from BLF (2018/09/18)

        string GetLastDayofMonth(string requireYear,string requireMonth);//added by ZMS to get last day of month (04.12.2018)

    }
}
