//----------------------------------------------------------------------
// <copyright file="ITLMSVE00017.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nay Lin Ko Ko, Khin Phyu Lin</CreatedUser>
// <CreatedDate>2013-06-19</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Service;

namespace Ace.Cbs.Tel.Ctr.Sve
{
    public interface ITLMSVE00017
    {
        IList<TLMDTO00017> SelectRegisterNoBySendDate(string order, string sourcebr, DateTime datetime);
        TLMDTO00017 SelectDrawingInfoByRegisterNo(string registerNo);
        IList<TLMDTO00001> SelectRemittanceEncashData(string sourceBranch); 
        //IList<TLMDTO00001> SelectRemittanceEncashData();
        void PassingRDDataList(IList<TLMDTO00017> rdlist, string sourcebranch);
        string PassingRDData(TLMDTO00017 rd);
        string PassingREData(TLMDTO00001 redto);
    }
}