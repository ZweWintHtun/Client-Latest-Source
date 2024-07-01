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
    public interface ILOMCTL00006 : IPresenter
    {
        ILOMVEW00006 INSURANView { set; get; }
        IList<LOMDTO00004> GetAll();
        void Save(LOMDTO00004 entity);
        void Delete(IList<LOMDTO00004> itemList);
        LOMDTO00004 SelectByINSUCODE(string iNSUCODE);
    }

    public interface ILOMVEW00006
    {
        string INSUCODE { get; set; }
        string INSUDESP { get; set; }
        string Status { get; set; }


        LOMDTO00004 ViewData { get; set; }
        LOMDTO00004 PreviousInsuranceDto { get; set; }
        IList<LOMDTO00004> INSURANs { get; set; }

        ILOMCTL00006 Controller { set; get; }
        void ControlSetting(string name, bool isEnable);
        void Successful(string message);
        void Failure(string message);
    }
}