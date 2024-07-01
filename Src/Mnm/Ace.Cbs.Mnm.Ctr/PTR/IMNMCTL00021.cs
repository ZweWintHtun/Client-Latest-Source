
//----------------------------------------------------------------------
// <copyright file="IMNMCTL00021.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>HM</CreatedUser>
// <CreatedDate>06/02/2014</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00021:IPresenter
    {
        IMNMVEW00021 View { get; set; }
        bool isFinish { get; set; }
        void Save();
        void ClearCustomErrorMessage();    

    }

    public interface IMNMVEW00021
    {
        IMNMCTL00021 Controller { get; set; }

        void Failure(string message);
        void Successful(string message);
        void ClearControls();
        string RegisterNo1 { get; set; }
        string RegisterNo2 { get; set; }
        string Amount1 { get; set; }
        string Amount2 { get; set; }
        string PayerName1 { get; set; }
        string PayerName2 { get; set; }
        string PayeeName1 { get; set; }
        string PayeeName2 { get; set; }
        string DraweBankCode1 { get; set; }
        string DraweBankCode2 { get; set; }
        string DraweBankName1 { get; set; }
        string DraweBankName2 { get; set; }
        string Currency1 { get; set; }
        string Currency2 { get; set; }
    }
}
