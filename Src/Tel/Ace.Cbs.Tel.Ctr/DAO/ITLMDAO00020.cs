//----------------------------------------------------------------------
// <copyright file="ITLMCTL00020.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>7.6.2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Drawing;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Dao;

namespace Ace.Cbs.Tel.Ctr.Dao
{
    public interface ITLMDAO00020 : IDataRepository<TLMORM00020>
    {
        bool CheckExist(string dEPCODE, string dESP, string sourceBr, bool isEdit);
        IList<TLMDTO00020> SelectAll(string sourceBr);
        TLMDTO00020 SelectByDEPCODE(string dEPCODE);
        TLMDTO00020 SelectToTS(string dEPCODE, string sourceBr);
        TLMDTO00020 SelectToDeleteTS(string dEPCODE, string sourceBr);
        IList<TLMDTO00020> CheckExist2(string dEPCODE, string sourceBr);
        bool DeleteCode(TLMDTO00020 entity);
    }
}
