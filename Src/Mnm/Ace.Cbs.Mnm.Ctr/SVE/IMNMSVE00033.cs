//----------------------------------------------------------------------
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>11/01/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Sve

{
    public interface IMNMSVE00033 : IBaseService
    {
        ICXSVE00002 CodeGenerator { get; set; }
        IPFMDAO00028 CledgerDAO { get; set; }
        IPFMDAO00017 CaofDAO { get; set; }      
        IPFMDAO00001 CustomerIdDAO { get; set; }
        IPFMDAO00016 SAOFDAO { get; set; }
        IPFMDAO00021 FAOFDAO { get; set; }
        IPFMDAO00023 FLedgerDAO { get; set; }

        void SaveCompany(PFMDTO00050 companyDTO);

       
        PFMDTO00050 CheckingAccount(string accountNo, string accountType, string branchCode);
        bool AccountTypeChecking(string accountNo, string accountType, string branchCode, out string message);

    }
}
