using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using System;
using System.Collections.Generic;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00238 : IPresenter
    {
        ILOMVEW00240 View { get; set; }
        IList<LOMDTO00238> Get_COA_Lists(string sourceBr);
        string Importing_Deposit_Voucher(string acWithOtherBnk, List<LOMDTO00238> lstImportData,string eno, int createdUserId
                                                , string sourceBr,string narration);
        IList<LOMDTO00244> CheckAccountForAccountClosed(string acctNo, string sourceBr);
        IList<LOMDTO00244> GetAccountInfoForAccountClosed(string acctNo, string sourceBr);
        string Save_AccountClosed(LOMDTO00244 dto);
        IList<LOMDTO00244> AccountClosedListing(LOMDTO00244 dto);
        //void Print(LOMDTO00244 dto);
        void ExportToExcel(LOMDTO00244 dto);
        void PrintToExcel(IList<LOMDTO00244> dtoList, DateTime startDate, DateTime endDate, string branch, string name, string cur);
        bool CheckDate(DateTime startDate, DateTime endDate);
        //IList<LOMDTO00245> TransactionListing(LOMDTO00245 dto);
        void Print(LOMDTO00245 dto);
    }
    public interface ILOMVEW00240
    {
        ILOMCTL00238 Controller { get; set; }
    }
}
