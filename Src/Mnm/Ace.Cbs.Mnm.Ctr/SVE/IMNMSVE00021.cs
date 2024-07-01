using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tel.Dmd;


namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00021:IBaseService
    {

        TLMDTO00017 GetDrawingData(string RegisterNo,string branchNo);

        //TLMDTO00017 Save_CrossChange(string registerNo1, string registerNo2, string regCur1, string regCur2, string rAmount1, string rAmount2, string workStation, string sourcebr, int currentUserId);     //comment by ASDA
        TLMDTO00017 Save_CrossChange(string registerNo1, string registerNo2, string regCur1, string regCur2, string rAmount1, string rAmount2,DateTime date1 , DateTime date2, string workStation, string sourcebr, int currentUserId);       
    }
}
