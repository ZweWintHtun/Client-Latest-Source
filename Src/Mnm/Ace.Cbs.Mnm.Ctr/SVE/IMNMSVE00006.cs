using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Mnm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Pfm.Dmd.DTO;
using Ace.Windows.Ix.Core.DataModel;// Added by AAM (20_Sep_2018)

namespace Ace.Cbs.Mnm.Ctr.Sve
{
   public interface IMNMSVE00006:IBaseService
    {
       IList<CurrencyChargeOfAccountDTO> SelectAllyearly(string sourcebr);
       bool Posting(string sourceBr);
       //void YearlyPosting(IList<CurrencyChargeOfAccountDTO> itemList, DateTime datetime, string sourceBr, int currentUserId);
       void YearlyPosting(DateTime datetime, string sourceBr, int currentUserId, IList<DataVersionChangedValueDTO> dvcvList);//Modified by HMW at 30-Sept-2019
       IList<PFMDTO00079> Get_BLFInfo_ByActiveBudget(string sourceBr);
    }
}
