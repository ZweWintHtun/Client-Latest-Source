//----------------------------------------------------------------------
// <copyright file="ITLMDAO00029.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hnin Thazin Shwe</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Dao;

namespace Ace.Cbs.Tel.Ctr.Dao
{
    /// <summary>
    /// RemitBrIBL DAO Interface
    /// </summary>
    public interface ITLMDAO00029 : IDataRepository<TLMORM00029>
    {
        void UpdateIBLSerial(string currencycode,int serial, string drawerbank, int updateduserid);
        void IBLSerialUpdate(string currencycode, int serial, string drawerbank, string SourceBr, int updateduserid);
        bool UpdateIBL(string currencycode, int serial, string drawerbank, string SourceBr, int updateduserid);
        decimal SelectIblSerialByDrawerBankAndCurrencyCode(string drawerbank, string SourceBr, string currencycode);
        bool CheckExist(int id, string branchCode, string sourceBr, string cur);
        TLMDTO00029 SelectByCode(string currency, string branchCode, string sourceBranch);
        bool DeleteById(int id, int userId);
        TLMDTO00029 SelectById(int id, string SourceBr);
    }
}