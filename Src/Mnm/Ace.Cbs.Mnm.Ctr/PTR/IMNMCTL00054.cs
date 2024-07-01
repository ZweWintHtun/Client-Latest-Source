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
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    /// <summary>
    /// Sub Ledger (Domestic) Controller interface
    /// </summary>
    public interface IMNMCTL00054 : IPresenter
    {
        IMNMVEW00054 View { get; set; }
       // bool Validate_Form();
        void ClearCustomErrorMessages();
        void Print();
    }

    /// <summary>
    /// Sub Ledger (Domestic) View interface
    /// </summary>
    public interface IMNMVEW00054
    {
        IMNMCTL00054 Controller { get; set; }
        DateTime StartDate { get; set; }

        DateTime EndDate { get; set; }
        bool IsHomeCurrency { get; set; }
        bool IsSourceCurrency { get; set; }
        bool IsTransactionDate { get; set; }
        bool IsSettlementDate { get; set; }  

        string Currency { get; set; }        
        string AccountCode { get; set; }
        string AccountDescription { get; set; }
        //string AccountType { get; set; }
          
        IList<ChargeOfAccountDTO> AccountTypeList { get; set; }
        IList<CurrencyDTO> CurrencyList { get; set; }
    }
}