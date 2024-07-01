//----------------------------------------------------------------------
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>HM</CreatedUser>
// <CreatedDate>31/12/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using System.Drawing;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    /// <summary>
    /// Sub Ledger (customer) Controller interface
    /// </summary>
    public interface IMNMCTL00052 : IPresenter
    {
        IMNMVEW00052 View { get; set; }       
        void PrintAll(string AcctNo,string acSign,string name , string nrc, string address);
        IList<PFMDTO00001> GetAccountInfo();
        bool Validate_Form();
        void ClearCustomErrorMessage();
        
    }

    /// <summary>
    /// Sub Ledger (customer) View interface
    /// </summary>
    public interface IMNMVEW00052
    {
        IMNMCTL00052 Controller { get; set; }
        string AccountNumber
        {
            get;
            set;
        }
        string FormName { get; set; }
        DateTime StartPeriod { get; set; }
        DateTime EndPeriod { get; set; }       
        void BindGridView(IList<PFMDTO00001> AccountInfo);
        bool CheckDate();
        DateTime GetEndDate();
        DateTime GetStartDate();
    }
}