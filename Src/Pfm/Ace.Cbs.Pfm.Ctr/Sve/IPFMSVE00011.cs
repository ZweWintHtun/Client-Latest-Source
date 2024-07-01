using System.Collections.Generic;
using Ace.Cbs.Pfm.Dmd;
namespace Ace.Cbs.Pfm.Ctr.Sve
{
    /// <summary>
    /// Current Account Closing Service InterfAce.
    /// </summary>
    public interface IPFMSVE00011
    {
        IList<PFMDTO00072> GetCurrentAccountInfo(string accountNo,string sourceBranchCode);
        void SaveCurrentAccountClose(PFMDTO00072 accountClose);
    }
}