//----------------------------------------------------------------------
// <copyright file="SAMVEW00004.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>11/04/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;

namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00009 : IBaseService
    {
        IList<PFMDTO00054> SelectForClrVoucherReversal(string eno, string sourceBr);

        string Reverse(PFMDTO00054 tlfdto);
    }
}
