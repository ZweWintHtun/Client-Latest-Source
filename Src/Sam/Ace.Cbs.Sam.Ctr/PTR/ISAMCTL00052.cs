//----------------------------------------------------------------------
// <copyright file="ISAMCTL00052.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>08/08/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Com.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Sam.Ctr.Ptr
{
    public interface ISAMCTL00052 : IPresenter
    {
        ISAMVEW00052 TranTypeView { set; get; }
        IList<TLMDTO00005> GetAll();
        void Save(TLMDTO00005 entity);
        void Delete(IList<TLMDTO00005> itemList);
        TLMDTO00005 SelectByTranCode(string tranCode);
    }

    public interface ISAMVEW00052
    {
        string TranCode { get; set; }
        string Desp { get; set; }
        string Narration { get; set; }
        string TransactionStatus { get; set; }
        string PBReference { get; set; }
        string RVReference { get; set; }
        string Status { get; set; }

        TLMDTO00005 ViewData { get; set; }
        IList<TLMDTO00005> TranTypes { get; set; }
        TLMDTO00005 PreviousTranTypeDto { get; set; }
        ISAMCTL00052 Controller { set; get; }
        void ControlSetting(string name, bool isEnable);
        void Successful(string message);
        void Failure(string message);
    }
}