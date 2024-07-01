using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;

namespace Ace.Cbs.Tcm.Ctr.Sve
{
    public interface ITCMSVE00066 : IBaseService
    {
       
        IList<TCMDTO00013> SelectLedgerBalanceByTransaction(PFMDTO00042 rawdata);
        IList<TCMDTO00013> SelectAcctNoByOverDrawn(PFMDTO00042 rawdata);

        #region oldcode 
        //IList<PFMDTO00042> SelectAcctNoAbyWorkstation(int workstation, string currency);
        //IList<PFMDTO00042> SelectAcctNoCbyWorkstation(int workstation, string currency);
        //IList<PFMDTO00042> SelectAcctNoSbyWorkstation(int workstation, string currency);
        //IList<PFMDTO00042> SelectAcctNoFbyWorkstation(int workstation, string currency);

        //IList<TCMDTO00013> SelectAcctNoByAll(int workstation, string currency, string sorting);
        //IList<TCMDTO00013> SelectAcctNoByCurrent(int workstation, string currency, string sorting);
        //IList<TCMDTO00013> SelectAcctNoBySaving(int workstation, string currency, string sorting);
        //IList<TCMDTO00013> SelectAcctNoByFixed(int workstation, string currency, string sorting);
        #endregion
    }
}
