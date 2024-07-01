//----------------------------------------------------------- Contract ------------------------------------//
//----------------------------------------------------------------------
// <copyright file="ILOMCTL00009.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KSW</CreatedUser>
// <CreatedDate>08/25/2014</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using Ace.Cbs.Loan.Ctr.Ptr;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00009 : IPresenter
    {
        ILOMVEW00009 GJTCodeView { set; get; }
        IList<LOMDTO00007> SelectAll();
        void Save(LOMDTO00007 entity);
        void Delete(IList<LOMDTO00007> itemList);
        LOMDTO00007 SelectByGjtype(string gjtype);
    }

    public interface ILOMVEW00009
    {
        string Code { get; set; }
        string Description { get; set; }
        string Status { get; set; }

        LOMDTO00007 ViewData { get; set; }
        IList<LOMDTO00007> GJTCodes { get; set; }
        LOMDTO00007 PreviousGJTDto { get; set; }
        ILOMCTL00009 Controller { set; get; }

        void ControlSetting(string name, bool isEnable);
        void Successful(string message);
        void Failure(string message);
    }
}