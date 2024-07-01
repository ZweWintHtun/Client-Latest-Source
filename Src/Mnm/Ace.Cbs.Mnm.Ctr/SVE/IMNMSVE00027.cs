using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00027
    {
        TLMDTO00017 DrawingRegisterNoValidate(string RegisterNo,string SourceBranchCode);
        IList<PFMDTO00054> Save(TLMDTO00017 drawingRegisterDTO, CXDTO00001 DenoInfo, bool isVoucher);
        bool SelectForDenoForm(TLMDTO00017 drawingRegisterDTO, out IList<TLMDTO00015> ListCashDeno, out decimal? RemainingAmount);
        TLMDTO00017 GetOtherGroupAmount(string groupNo, string registerNo, string sourceBr);
   bool CheckDenoStatus(string registerNo, string sourceBr);
        TLMDTO00017 GetGroupAmount(string groupNo, string registerNo, string sourceBr);
        TLMDTO00015 GetAmountByAcType(string acType, string sourceBranchCode);
    }
}
