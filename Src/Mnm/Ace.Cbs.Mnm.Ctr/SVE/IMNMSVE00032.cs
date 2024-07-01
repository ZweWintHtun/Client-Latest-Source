//----------------------------------------------------------------------
// <copyright file="IMNMSVE00032.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KTRHMS</CreatedUser>
// <CreatedDate>11/04/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Ctr.PTR;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;

namespace Ace.Cbs.Mnm.Ctr.Sve
{
    /// <summary>
    /// Interface Class
    /// Current Account - Joint
    /// Saving Account - Joint
    /// Fixed Account - Joint
    /// </summary>
    public interface IMNMSVE00032
    {
        ICXSVE00002 CodeGenerator { get; set; }
        ICXDAO00006 codeCheckerDAO { get; set; }
        ICXSVE00006 CodeChecker { get; set; }
        IPFMDAO00028 CledgerDAO { get; set; }
        IPFMDAO00017 CaofDAO { get; set; }
        IPFMDAO00001 CustomerIdDAO { get; set; }
        IPFMDAO00016 SAOFDAO { get; set; }
        IPFMDAO00021 FAOFDAO { get; set; }
        IPFMDAO00023 FLedgerDAO { get; set; }

        void SaveJoint(PFMDTO00050 jointDTO);
        PFMDTO00067 GetJointAccountInformation(string accountNo, string acsign, string branchCode);
       
    }
}