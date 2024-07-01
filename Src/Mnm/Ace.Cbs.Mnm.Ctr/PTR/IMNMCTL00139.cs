using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00139 : IPresenter
    {
        IMNMVEW00139 View { get; set; }
        void Update();
        void CleanUIControlData();
        DateTime GetSystemDate(string sourceBr);
    }

    public interface IMNMVEW00139
    {
        string TlfEntryNo { get; set; }
        string AccountType { get; set; }
        decimal MultiAmount { get; set; }
        string CustomerName { get; set; }
        string NRC { get; set; }
        string Narration { get; set; }
        decimal IndividualAmount { get; set; }
        IMNMCTL00139 Controller { get; set; }
        bool IsMulti { get; set; }
        void BindGridView(IList<PFMDTO00001> informationlist);
        void MessageShow(string messagecode);
        void MultiNonCustomerGridChange(bool enable);
        void FocusTlfEntryTextBox();
    }
}
