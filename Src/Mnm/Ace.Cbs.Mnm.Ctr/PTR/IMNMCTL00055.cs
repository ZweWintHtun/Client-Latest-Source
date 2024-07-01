using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Presenter;
using System.Data;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00055 : IPresenter
    {

        IMNMVEW00055 View { get; set; }
        void PrintExel();
        DataTable PrintExel_New();
        void ClearUIControl();
        void ClearCustomErrorMessage();
        IList<CounterInfoDTO> GetAllCounterListBySourceBranchCode();
        string SendReportTitle();
        string _counterType { get; set; }
    }

    public interface IMNMVEW00055
    {
        IMNMCTL00055 Controller { get; set; }
       
        bool IsReversal { get; set; }
        string Currency { get; set; }
        string CounterNo { get; set; }
        IList<CounterInfoDTO> TocounterInfolist { get; set; }
        DateTime EndDateTime { get; set; }
        
    }
}
