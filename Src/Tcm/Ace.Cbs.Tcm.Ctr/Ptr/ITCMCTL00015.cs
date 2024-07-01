//----------------------------------------------------------------------
// <copyright file="ITCMCTL00015.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Tcm.Ctr.Ptr
{
    /// <summary>
    /// System Shut Down Controller Interface
    /// </summary>
    public interface ITCMCTL00015
    {
        ITCMVEW00015 View { get; set; }
        bool BindInitialData();
        void ShutDown();
        IList<PFMDTO00028> BindReconsile();
        void CommonShutDown();
        bool CheckAutoPayAndLateFeeCalculateProcess();//Added by HWKO (18-Jul-2017)

    }

    /// <summary>
    /// System Shut Down View Interface
    /// </summary>
    public interface ITCMVEW00015
    {
        ITCMCTL00015 Controller { get; set; }
        string BankHead { get; set; }
        string SystemDate { get; set; }
        string Status { get; set; }
        void Successful(string message);
        void Failure(string message);
        void BindReconsileGrid();
        bool ShutDown { get; set; }
        void CLoseForm();
        void NeedForShutDown();

    }
}
