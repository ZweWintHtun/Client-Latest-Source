using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Gl.Dmd;
using System.Data;

namespace Ace.Cbs.Gl.Ctr.Sve
{
    public interface IGLMSVE00027 : IBaseService
    {
        //IList<PFMDTO00042> GetReportDataListForMonthlyReports(DateTime requiredDate, bool IsTransactionDate, string sourceBranchCode);
        //IList<PFMDTO00042> GetReportDataListForMonthlyReports(DateTime requiredDate, string sourceBranchCode);       
        //DataSet SelectMonthlyCOAForIncomeExpenditureAndGeneralReturnsReport(DateTime requiredDate, string sourceBranchCode, string isIncome, string workStation);
        IList<GLMDTO00023> SelectMonthlyCOAForIncomeExpenditureAndGeneralReturnsReport1(DateTime requiredDate, string sourceBranchCode, string isIncome, string workStation);
        IList<GLMDTO00023> SelectMonthlyCOAForIncomeExpenditureAndGeneralReturnsReport2(DateTime requiredDate, string sourceBranchCode, string isIncome, string workStation);
    }
}
