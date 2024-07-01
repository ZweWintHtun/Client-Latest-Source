using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient.Utilities;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Mnm.Ctr.Sve;

namespace Ace.Cbs.Mnm.Ptr
{
    public class MNMCTL00064 : AbstractPresenter , IMNMCTL00064
    {
        public IList<MNMDTO00007> PrintDataList { get; set; }

        public IMNMVEW00064 View { get; set; }

        int startYear;
        int endYear;
        string requiredYear;

        public void Print()
        {
            if (!Date_Check())
                return;

            requiredYear = startYear + "/" + endYear;
            PrintDataList = CXClientWrapper.Instance.Invoke<IMNMSVE00064,IList<MNMDTO00007>>(x => x.GetPrintDataList(requiredYear, CurrentUserEntity.BranchCode));
           
            if(PrintDataList.Count > 0)
            {
                string reportName = string.Empty;
                string month = string.Empty;
                if (this.View.FormName.Contains("January"))
                {
                    reportName = "Saving Interest Listing for January to March as at  " + DateTime.Now.ToString("dd/MM/yyyy");
                    month = "Jan-Mar";
                }
                else if (this.View.FormName.Contains("April"))
                {
                    reportName = "Saving Interest Listing for April to June as at  " + DateTime.Now.ToString("dd/MM/yyyy");
                    month = "Apr-Jun";
                }

                else if (this.View.FormName.Contains("July"))
                {
                    reportName = "Saving Interest Listing for July to September as at  " + DateTime.Now.ToString("dd/MM/yyyy");
                    month = "July-Sep";
                }

                else if (this.View.FormName.Contains("October"))
                {
                    reportName = "Saving Interest Listing for October to December as at  " + DateTime.Now.ToString("dd/MM/yyyy");
                    month = "Oct-Dec";
                }
                CXUIScreenTransit.Transit("frmMNMVEW00113", PrintDataList, reportName, month);
            }
            else
            {
                CXUIMessageUtilities.ShowMessageByCode("MI00039"); //No Data for Print
            }
        }

        public bool Date_Check()
        {
            if (this.View.RequiredYear == "")
                return false;

            startYear = Convert.ToInt16(this.View.RequiredYear.Substring(0,4));
            endYear = Convert.ToInt16(this.View.RequiredYear.Substring(4,4));

            if (startYear > endYear)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV30034,"greater than");  //Start Year can't be greater than End Year
                return false;
            }
            else if(startYear == endYear)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV30034,"equal to"); //Start Year can't be equal to End Year
                return false;
            }
            else if (DateTime.Now.Month > 3)
            {
                if (endYear > (DateTime.Now.Year + 1))
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV30035,endYear,(DateTime.Now.Year + 1));   //"Year : " & EndYear & " can't be greater than Current  Budget Year " & Year(Date) & "/" & Year(Date) + 1
                    return false;
                }             
            }
            else
            {
                if (endYear > DateTime.Now.Year)
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV30035,endYear,DateTime.Now.Year);  //"Year : " & EndYear & " can't be greater than Current Year " & Year(Date)
                    return false;
                }
            }
            return true;
        }
    }
}
