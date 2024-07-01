//----------------------------------------------------------------------
// <copyright file="IMNMCTL00018.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>HM</CreatedUser>
// <CreatedDate>14/02/2014</CreatedDate>
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
    public interface IMNMCTL00019 : IPresenter
    {
        IMNMVEW00019 View { get; set; }
        void Save();
        void ClearCustomErrorMessage();
    }

    public interface IMNMVEW00019
    {
        IMNMCTL00019 Controller { get; set; }
        string RegisterNo { get; set; }
        decimal Amount { get; set; }
        string PoNo { get; set; }
        string Name_forPO { get; set; }
        string Currency { get; set; }
        void Successful(string message,string newpoNo);
        void Failure(string message);
        void InitializeControls();
    }
}
