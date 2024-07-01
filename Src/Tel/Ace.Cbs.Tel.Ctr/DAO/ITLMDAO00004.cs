//----------------------------------------------------------------------
// <copyright file="ITLMDAO00005.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>AK</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser>Nyo Me San</UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;

namespace Ace.Cbs.Tel.Ctr.Dao
{
    public interface ITLMDAO00004 : IDataRepository<TLMORM00004>
    {
        int SelectMaxId();

        IList<TLMDTO00004> SelectIBLTLfInfoByEno(string eno, string sourceBr);
        bool CheckExistRelatedBrAndAc(string eno, string sourceBr);
        bool CheckExist(string accountno);
        IList<TLMDTO00004> SelectDataForTransactionReconsile(string fromBr, string toBr,bool inout,string branch,DateTime date);

        IList<TLMDTO00004> SelectAll(string SourceBranchCode);
        void DeleteIBLTLF(string SourceBranchCode);

        IList<TLMDTO00004> SelectChargesByEntryNo(string entryno, string sourceBr);
        string SelectDistinctAccountNoByEno(string entryno, string sourcebr, string trantype);

    }
}
