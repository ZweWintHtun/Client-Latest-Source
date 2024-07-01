using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Pfm.Dmd;
namespace Ace.Cbs.Tel.Ctr.Sve
{
   public interface ITLMSVE00027:IBaseService
    {
       bool IsInFAOFAccountNoOrInCledgerAcNo(string accountno);
       IList<PFMDTO00042> GetWithdrawalListingByAccountTypeList(DateTime startDate, DateTime endDate, int workStation, string acSign, string sourceBranch, int createdUserId);

       IList<PFMDTO00042> GetWithdrawalListingByCounterNoList(DateTime startDate, DateTime endDate, int workStation, string username, int createdUserId, string sourceBranch);
       IList<PFMDTO00042> GetWithdrawalListingByAccountNoList(DateTime startDate, DateTime endDate, string accountNo, int createdUserId, string sourceBranch, int workstation);
       IList<PFMDTO00042> GetWithdrawalListingList(DateTime startDate, DateTime endDate, string sourcebranchCode, int workStation, int createdUserId);
       bool IsValidUserNo(string userno,string sourcebr);
   }
}
