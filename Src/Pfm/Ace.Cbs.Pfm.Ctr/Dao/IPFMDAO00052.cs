//----------------------------------------------------------------------
// <copyright file="IPFMDAO00052.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>07/30/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Pfm.Ctr.Dao
{
    /// <summary>
    /// PFMDAO00052 Interface
    /// </summary>
    public interface IPFMDAO00052 : IDataRepository<PFMORM00052>
    {
        bool CheckExist(int id, int formatId, string portionCode, int position, int length, bool isValue, bool isCheckDigit, bool isIncrement, bool isZeroLeading);
        IList<PFMDTO00052> SelectAll();
        int SelectMaxId();
    }
  }