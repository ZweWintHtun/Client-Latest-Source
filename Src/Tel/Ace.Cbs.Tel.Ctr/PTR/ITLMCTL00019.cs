using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Com.Dmd;

namespace Ace.Cbs.Tel.Ctr.Ptr
{
    public interface ITLMCTL00019 : IPresenter
    {
        ITLMVEW00019 View { get; set; }
        string SourceBr { get; set; } 
        IList<TLMDTO00017> GetRegisterNo(string type);
        IList<TLMDTO00050> BindRegisterNoInformation(string Drawing_Type);
       
        void Save();
        TLMDTO00017 GetSaveData();  
    }

    public interface ITLMVEW00019
    {
        ITLMCTL00019 Controller { get; set; }

        string RegisterNo { get; set; }
        string CurrencyCode { get; set; }
        string type { get; set; }
        bool VIP { get; set; }
        string ParentFormId { get; }
        
        CXDMD00010 CurrentFormPermissionEntity { get; set; }
        void gvDrawingRemitt_DataBind();
        void Successful(string message, string VoucherNo);
        void Failure(string message,string accountNo);
       
    }
}
    

