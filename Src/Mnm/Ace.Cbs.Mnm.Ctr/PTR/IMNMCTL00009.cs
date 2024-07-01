//----------------------------------------------------------------------
// <copyright file="SAMVEW00004.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>11/04/2013</CreatedDate>
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

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00009 : IPresenter
    {
        IMNMVEW00009 View { get; set; }
        IList<PFMDTO00054> SelectForClrVoucherReversal(string eno);
        void ClearControls();
        void Reverse();

        DateTime GetSystemDate(string sourceBr);
        DateTime GetLastSettlementDate(string sourceBr);
    }

    public interface IMNMVEW00009
    {
        string Eno { get; set; }
        string Narration { get; set; }
        IMNMCTL00009 Controller { get; set; }
        void FillData(IList<PFMDTO00054> tlfEntity);
        void Successful(string message);
        void Failure(string Message);
        IList<PFMDTO00054> gridData { get; set; }
    }
}
