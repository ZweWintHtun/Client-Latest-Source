using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Com.Ctr;

using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;

using Ace.Cbs.Cx.Com.Dto;
using Ace.Windows.Core.Service;


namespace Ace.Cbs.Tcm.Ctr.Sve
{
    public interface ITCMSVE00007 : IBaseService
    {
        void Save(TLMDTO00015 cashDenoEntity, PFMDTO00054 PaymentData);     
        PFMDTO00054 Check_EntryNo(string entryNo, string sourceBr,string tranCode);
        IList<TLMDTO00015> Check_DenoEno(string tlfeno, string status, string sourceBr);      
    }
}
