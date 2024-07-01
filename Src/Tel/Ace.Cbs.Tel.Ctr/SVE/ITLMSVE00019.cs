using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Tel.Ctr.Sve
{
   public interface ITLMSVE00019:IBaseService
    {
        IList<TLMDTO00017> GetRegisterNoBySourceBranchCode(string sourceBranchCode, string type);
        bool[] GetAccountNo(string accountNo,decimal amount,bool isChecked);
        string SaveData(TLMDTO00017 drawingRemit);
        string SaveDataForFX(TLMDTO00017 drawingRemit);
        TLMDTO00015 GetCashDenoData(string registerNo, string sourceBr);
   }
}
