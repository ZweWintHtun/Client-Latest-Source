//----------------------------------------------------------- Contract ------------------------------------//
//----------------------------------------------------------------------
// <copyright file="ILOMCTL00006.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KSW</CreatedUser>
// <CreatedDate>08/18/2014</CreatedDate>
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
    public interface ILOMCTL00004 : IPresenter
    {
        ILOMVEW00004 GoodWillView { set; get; }
        IList<LOMDTO00001> SelectAll();
        void Save(LOMDTO00001 entity);
        void Delete(IList<LOMDTO00001> itemList);
        LOMDTO00001 SelectByGoodWillCode(string gCode);
    }

    public interface ILOMVEW00004
    {
        string GoodWillCode { get; set; }
        string Description { get; set; }
        string Status { get; set; }

        LOMDTO00001 ViewData { get; set; }
        LOMDTO00001 PreviousGoodWillDto { get; set; }
        IList<LOMDTO00001> GoodWillCodes { get; set; }
        ILOMCTL00004 Controller { set; get; }

        //void ControlSetting(string name, bool isEnable);
        void Successful(string message);
        void Failure(string message);
    }
}