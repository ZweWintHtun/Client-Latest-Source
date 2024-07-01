//----------------------------------------------------------------------
// <copyright file="ILOMCTL00027" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>ASDA</CreatedUser>
// <CreatedDate>07.02.2015</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Pfm.Dmd;
namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00027 : IPresenter
    {
        ILOMVEW00027 View { get; set; }        
        void Save(); 
    }
    public interface ILOMVEW00027
    {
        ILOMCTL00027 Controller { get; set; }
        string LoanNo { get; set; }
        string AccountNo { get; set; }
        decimal CurrentBalance { get; set; }
        decimal RepaymentAmount { get; set; }
        string Status { get; set; }
        void BindNameList(string[] CustomerList);
        void BindGridView(IList<LOMDTO00013> legalList);
        
    }
}
