using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Mnm.Ctr;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Ix.Core.DataModel;


namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00002:IBaseService
    { 
        //virtual IList<PFMDTO00040> SelectAll();
        bool CheckClosing(MNMDTO00001 sysDTO, string sourceBranchCode);
        IList<string> MonthAfterCalcuate(MNMDTO00001 sysDTO, string SourceBranchCode, int Updateduserid);
        //IList<LOMDTO00021> CheckIntCalculateDate(string year, DateTime Smonth, DateTime Emonth);
        //bool UpdateLoanInterest(IList<LOMDTO00021> liList);
        IList<LOMDTO00021> SelectLoansInterestByQuater(LOMDTO00021 dto);
        IList<LOMDTO00054> SelectODInterestByQuater(LOMDTO00054 dto);

        string CalculateLoansInterestForQuarter(DateTime sDate, DateTime eDate, int period, string branchCode);
        string CalculateLoansInterestForMonthly(DateTime sDate, DateTime eDate, int period, string branchCode, IList<DataVersionChangedValueDTO> dvcvList,int userId);
        string CalculateBusinessLoansInterestForDaily(DateTime sDate, DateTime eDate, string branchCode, IList<DataVersionChangedValueDTO> dvcvList, int userId);

        string DatabaseBackupAfterMonthClose();//Updated by HWKO (14-Mar-2017)
    }
}
