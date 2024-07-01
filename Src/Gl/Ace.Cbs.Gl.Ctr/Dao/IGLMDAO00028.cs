using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Gl.Dmd;
using Ace.Cbs.Gl.Dmd.Dto;// Added By AAM(06-Mar-2018)

namespace Ace.Cbs.Gl.Ctr.Dao
{
    public interface IGLMDAO00028 : IDataRepository<CurrencyChargeOfAccount>
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

        IList<GLMDTO00028> Get_SFP_ReportData(string requireMonth, string sourceBr);

        string GetLastDayofMonth(string requireYear, string requireMonth);//added by ZMS to get last day of month (04.12.2018)
    }
}
