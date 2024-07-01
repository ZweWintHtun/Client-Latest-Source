//----------------------------------------------------------------------
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>11/15/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Mnm.Dmd;
using Ace.Windows.Core.Presenter;
using System.Windows.Forms;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00003 : IPresenter
    {
        IMNMVEW00003 View { get; set; }
        void CalculateInterest(int month, int year);
        void Show_Message(string msgCode);
    }

    public interface IMNMVEW00003
    {
        string MonthText { get; set; }
        int MonthValue { get; set; }
        int Year { get; set; }
        int Progress { get; set; }
        Timer TimerProgress { get; }
        bool IsSuccessful { get; set; }
        ProgressBarStyle ProgressBarStyle { set; }
        Ace.Windows.CXClient.Controls.CXC0007 ButCalculate { get; set; }
    }
}
