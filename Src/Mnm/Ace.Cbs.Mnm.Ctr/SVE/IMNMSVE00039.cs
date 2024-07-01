﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00039 : IBaseService
    {
        IList<PFMDTO00029> GetAutoLinkListing(PFMDTO00042 DataDTO,int workStationId,int createdUserId);
    }
}