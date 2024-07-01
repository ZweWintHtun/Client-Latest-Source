//----------------------------------------------------------------------
// <copyright file="IMNMCTL00001.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>12/02/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using System.Windows.Forms;


namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00001:IPresenter
    {
        void CheckClosing();
        void Posting();
        void Show_Loans_Posting_Message();
        void Show_OverDraft_Posting_Message();
        void Show_CommitFee_Posting_Message();
        void Show_Saving_Posting_Message();
        void Show_Fixed_Posting_Message();
        void Successful_Message();
        DateTime GetSystemDate(string sourceBr);
        IMNMVEW00001 View { get; set; }
    }

    public interface IMNMVEW00001
    {
        IMNMCTL00001 Controller { get; set; }
        bool butProcess_Enable { get; set; }
        int ProgressBar { get; set; }
        Timer TimerProgress { get; }
        Timer TimerProgress2 { get; }
        ProgressBarStyle ProgressBarStyle { set; }
        bool ProgressBar2Visible { set; }
        ProgressBarStyle ProgressBar2Style { set; }
    }
}
