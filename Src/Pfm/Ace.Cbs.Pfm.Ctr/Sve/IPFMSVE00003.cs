using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Pfm.Dmd.DTO;

namespace Ace.Cbs.Pfm.Ctr.Sve
{
    /// <summary>
    /// Interface Class
    /// Current Account - Joint
    /// Saving Account - Joint
    /// Fixed Account - Joint
    /// </summary>
    public interface IPFMSVE00003
    {
        ICXSVE00002 CodeGenerator { get; set; }
        IPFMDAO00028 CledgerDAO { get; set; }
        IPFMDAO00017 CaofDAO { get; set; }
        IPFMSVE00013 ChequeService { get; set; }
        IPFMDAO00033 BalanceDAO { get; set; }
        IPFMDAO00001 CustomerIdDAO { get; set; }
        IPFMDAO00040 SavingInterestDAO { get; set; }
        IPFMDAO00016 SAOFDAO { get; set; }
        IPFMDAO00021 FAOFDAO { get; set; }
        IPFMSVE00027 FReceiptService { get; set; }
        IPFMDAO00023 FLedgerDAO { get; set; }

        string SaveJoint(PFMDTO00050 jointDTO);

        PFMDTO00080 CheckBlackListCustomerByCustId(string custId, string branchCode);
    }
}