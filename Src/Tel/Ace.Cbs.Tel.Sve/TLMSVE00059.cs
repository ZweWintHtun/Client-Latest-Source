using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Cx.Com.Ctr;

namespace Ace.Cbs.Tel.Sve
{
   public class TLMSVE00059 :BaseService,ITLMSVE00059
    {
       public ITLMDAO00059 EncashOutstandingDAO { get; set; }
       //public ICXDAO00009 ViewDAO { get; set; }

       public IList<TLMDTO00001> SelectEncashOutStanding(string sourceBr)
       {
           IList<TLMDTO00001> reDTO = this.EncashOutstandingDAO.SelectEncashRegisterOutstanding(sourceBr);

           //if (reDTO.Count > 0)
           if (reDTO != null)
           {
               return reDTO;
           }
           else
           {
               this.ServiceResult.ErrorOccurred = true;
               this.ServiceResult.MessageCode = "MI00039"; //No Data For Report
               return reDTO;
           }
       }

       //public IList<TLMDTO00001> SelectEncashOutStanding(string sourceBr)
       //{
       //    IList<TLMDTO00001> reDTO = this.ViewDAO.SelectEncashRegisterOutstanding(sourceBr);

       //    //if (reDTO.Count > 0)
       //    if (reDTO != null)
       //    {
       //        return reDTO;
       //    }
       //    else
       //    {
       //        this.ServiceResult.ErrorOccurred = true;
       //        this.ServiceResult.MessageCode = "MI00039"; //No Data For Report
       //        return reDTO;
       //    }
       //}

    }
}
