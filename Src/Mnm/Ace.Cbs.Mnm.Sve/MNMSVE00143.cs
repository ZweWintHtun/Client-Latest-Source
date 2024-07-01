using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Mnm.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Cx.Com.Utt;
//using Ace.Cbs.Cx.Ser.Dao;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Windows.Core.Service;
using Ace.Cbs.Mnm.Dmd;


namespace Ace.Cbs.Mnm.Sve
{
   public  class MNMSVE00143 : BaseService, IMNMSVE00143
    {

       private ICXDAO00009 fixedYEDAO;
       public ICXDAO00009 FixedYEDAO
       {
           get { return this.fixedYEDAO; }
           set { this.fixedYEDAO = value; }
       }

       public IList<MNMDTO00043> SelectFixedYearEnd(string sourcebr)
       {
           IList<MNMDTO00043> FiList = new List<MNMDTO00043>();
           FiList = FixedYEDAO.SelectFixedYEInterestList(sourcebr);

           if (FiList == null || FiList.Count <= 0)
           {
               this.ServiceResult.ErrorOccurred = true;
               this.ServiceResult.MessageCode = CXMessage.MI00039;    //No data to Report
               return null;
           }

           return FiList;
       }

       public IList<MNMDTO00043> SelectFixedYearEndPrev(string sourcebr)
       {
           IList<MNMDTO00044> Pre_FiList = new List<MNMDTO00044>();
           IList<MNMDTO00043> FiList = new List<MNMDTO00043>();

           Pre_FiList = FixedYEDAO.SelectFixedYEInterestPrevList(sourcebr);

           foreach (MNMDTO00044 preFI in Pre_FiList)
           {
               FiList.Add(ConvertDTO(preFI));
           }

           if (FiList == null || FiList.Count <= 0)
           {
               this.ServiceResult.ErrorOccurred = true;
               this.ServiceResult.MessageCode = CXMessage.MI00039;    //No data to Report
               return null;
           }



           return FiList;

       }

       public MNMDTO00043 ConvertDTO(MNMDTO00044 prefi)
       {
           return new MNMDTO00043
           (
            prefi.AcctNo,
            prefi.Name ,
            prefi.Fbal ,
            prefi.BudEndAcc ,
            prefi.Duration ,
            prefi.RDATE.Value,
            prefi.WDate.Value ,
            prefi.LasIntDate.Value,
            prefi.Amount ,
            prefi.RNo ,
            prefi.Accrued ,
            prefi.DrAccured ,
            prefi.SourceBr ,
            prefi.Cur 

           );
            
       }
    }
}
