using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
//using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Gl.Dmd;


namespace Ace.Cbs.Gl.Ctr.Dao
{
    public interface IGLMDAO00014 : IDataRepository<GLMORM00001>
    {
        IList<GLMDTO00001> GetFormatFileDataListForReportFormatEntry(string formatStatus);
        bool CheckExist(int id, string formatType,string formatStatus);
        void Delete(GLMDTO00001 deleteitem);
        void Update(GLMDTO00001 updateitem);

        IList<GLMDTO00001> GetFormatFileDataListForFormulaEntry(string formatType, string formatStatus); //GLMVEW00018
        void DeleteAll(GLMDTO00001 deleteitem);  //GLMVEW00018
        IList<GLMDTO00001> SelectAllByFormatStatus(string formatStatus);
        IList<GLMDTO00001> SelectFormatFileByFormatTypeAndFormatStatus(string formatType, string formatStatus);
        IList<GLMDTO00001> SelectCCOASumAmountByAcodeAndDcode(IList<string> acodeList, IList<string> dcodeList, string requiredMonth, string bfRequiredMonth);
        IList<GLMDTO00001> SelectCCOAAmountByCurAndAcodeAndDcode(IList<string> acodeList, IList<string> dcodeList, string requiredMonth, string bfRequiredMonth, string cur);
        IList<GLMDTO00001> SelectFormatFileByFormatTypeAndFormatStatusAndStatus(string formatType, string formatStatus, string status);
    }
}
