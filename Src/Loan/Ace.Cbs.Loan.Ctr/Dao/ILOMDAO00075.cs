using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;


namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00075 :IDataRepository<LOMORM00075>
    {
        //bool CheckExist(string id, string productCode, string seasonCode, string uMCode, string startDate, string endDate, string deadLineDate, string username, DateTime date, bool isEdit);
        bool CheckExist(string seasonCode, bool isEdit);
        //IList<LOMDTO00075> SelectAllAGLoanProductTypeItem();
        //LOMDTO00075 SelectByAGLoanProductTypeItemSeasonCode(string seasonCode);
        //IList<LOMDTO00075> CheckExist2(string id, string productCode, string seasonCode,  string uMCode, string startDate, string endDate, string deadLineDate, string username, DateTime date);
        IList<LOMDTO00075> CheckExist2(string seasonCode);

        IList<LOMDTO00075> GetAllAGLoanProductTypeItem();
        LOMDTO00075 GetAllAGLoanProductTypeItemBySeasonCode(string seasonCode);
    }     
}
