using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Gl.Dmd;
using Ace.Cbs.Gl.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Gl.Ctr.Sve
{
    public interface IGLMSVE00023 :IBaseService
    {
        //string CheckDate(DateTime Dailydate, string sourcebr);
        void Posting(DateTime startDate, DateTime endDate, string workstation, int createdUserId, string branchCode);

        #region Monthly Report Setup

        void Save(GLMDTO00023 gLMDTO00023);
        void Update(GLMDTO00023 gLMDTO00023, List<GLMDTO00023> TitleOrderList, List<GLMDTO00023> SubTitleOrderList);
        void Delete(GLMDTO00023 gLMDTO00023);
        GLMDTO00023 SelectAllByAccountCode(string ACode);
        GLMDTO00023 SelectAllMonthlyCOAByAccountCode(string ACode);//Added by HMW (13-12-2022)        
        IList<GLMDTO00023> SelectAllAccountType();
        IList<GLMDTO00023> SelectAllBranchCode();
        IList<GLMDTO00023> SelectAllTITLE();
        IList<GLMDTO00023> SelectAllTITLE_By_Type(string Type);
        IList<GLMDTO00023> SelectAllSUBTITLE_by_TITLE(string TITLE);
        IList<GLMDTO00023> SelectAllOtherBankGroupTitle(string ACode);

        #endregion
    }
}
