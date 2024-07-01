using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Tcm.Dmd;

namespace Ace.Cbs.Tcm.Ctr.Dao
{
    public interface ITCMDAO00003 : IDataRepository<TCMORM00003>
    {
       // IList<TCMDTO00003> GetNPLIntList(string loanNo, string aType, string sourceBr); //NPL Release Case(LOMSVE00015) 
        IList<TCMDTO00003> GetNPLIntList(string loanNo, IList<string> aType, string sourceBr); //NPL Release Case(LOMSVE00015) 
        bool UpdateNPLIntForNPLRelease(string loanNo,string sourceBr,int updatedUserID);
    }
}
