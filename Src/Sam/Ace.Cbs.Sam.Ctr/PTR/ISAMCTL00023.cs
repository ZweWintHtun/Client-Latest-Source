//----------------------------------------------------------------------
// <copyright file="ISAMCTL00023.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>08/05/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using Ace.Cbs.Sam.Dmd;
using Ace.Cbs.Cx.Com.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Sam.Ctr.Ptr
{
    public interface ISAMCTL00023 : IPresenter
    {
        ISAMVEW00023 RateFileView { set; get; }
        IList<PFMDTO00009> GetAll();
        void Save(PFMDTO00009 entity);
        void Delete(IList<PFMDTO00009> itemList);
        PFMDTO00009 SelectByCode(string code);
  PFMDTO00009 SelectByRateCode(string code);
    }

    public interface ISAMVEW00023
    {
        string Code { get; set; }
        string Desp { get; set; }
        DateTime DATE_TIME { get; set; }
        decimal Rate { get; set; }
        string Status { get; set; }

        PFMDTO00009 ViewData { get; set; }
        PFMDTO00009 PreviousRateDto { get; set; }
        IList<PFMDTO00009> RateFiles { get; set; }
        ISAMCTL00023 Controller { set; get; }
        void ControlSetting(string name, bool isEnable);
        void Successful(string message);
        void Failure(string message);
    }
}