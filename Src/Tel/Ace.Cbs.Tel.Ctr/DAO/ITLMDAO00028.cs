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
    /// RemitBr DAO Interface
    /// </summary>
    public interface ITLMDAO00028 : IDataRepository<TLMORM00028>
    {
        int SelectMaxId();
        void TTSerialUpdate(string currencycode, int serial, string drawerbank, string SourceBr, int updateduserid);
        decimal SelectTTSerialByDrawerBankAndSourceBrachCode(string drawerbank, string SourceBr, string currencycode);
        void UpdateTTSerial(string currencycode, int serial, string drawerbank, int updateduserid);//old
        void UpdateSerialRemit();//old
        decimal SelectTTSerialByDrawerBankAndCurrencyCode(string drawerbank, string currencycode);//old
        bool CheckExist(int id, string branchCode, string sourceBr, string cur);
        TLMDTO00028 SelectByCode(string currency, string branchCode, string sourceBranch);
        bool DeleteById(int id, int userId);
        void UpdateSerialRemit(decimal serial, string sourcebr, int updateduserid);
        TLMDTO00028 SelectById(int id, string sourceBranch);
    }
}