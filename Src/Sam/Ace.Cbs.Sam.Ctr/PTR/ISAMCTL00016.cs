//----------------------------------------------------------- Contract ------------------------------------//
//----------------------------------------------------------------------
// <copyright file="ISAMCTL00016.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>08/07/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Sam.Ctr.Ptr
{
    public interface ISAMCTL00016 : IPresenter
    {
        ISAMVEW00016 NewSetupView { set; get; }
        IList<PFMDTO00057> GetAll();
        void Save(PFMDTO00057 entity);
        void Delete(IList<PFMDTO00057> itemList);
        PFMDTO00057 SelectByVariable(string variable);
    }

    public interface ISAMVEW00016
    {
        string Variable { get; set; }
        string Value { get; set; }
        string Status { get; set; }

        PFMDTO00057 ViewData { get; set; }
        PFMDTO00057 PreviousNewSetupDto { get; set; }
        IList<PFMDTO00057> NewSetups { get; set; }
        ISAMCTL00016 Controller { set; get; }
        void ControlSetting(string name, bool isEnable);
        void Successful(string message);
        void Failure(string message);
    }
}