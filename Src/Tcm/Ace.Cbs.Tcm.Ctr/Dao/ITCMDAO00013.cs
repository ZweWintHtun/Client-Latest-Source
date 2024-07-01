using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Tcm.Ctr.Dao
{
    public interface ITCMDAO00013 : IDataRepository<TCMVIW00013>
    {
        IList<PFMDTO00042> SelectAcctNoAbyWorkstation(int workstation, string currency);
        IList<PFMDTO00042> SelectAcctNoCbyWorkstation(int workstation, string currency);
        IList<PFMDTO00042> SelectAcctNoSbyWorkstation(int workstation, string currency);
        IList<PFMDTO00042> SelectAcctNoFbyWorkstation(int workstation, string currency);

        IList<PFMDTO00042> SelectAcctNoBbyWorkstation(int workstation, string currency);//Added by HWKO (17-Aug-2017)
        IList<PFMDTO00042> SelectAcctNoHbyWorkstation(int workstation, string currency);//Added by HWKO (17-Aug-2017)
        IList<PFMDTO00042> SelectAcctNoPbyWorkstation(int workstation, string currency);//Added by HWKO (17-Aug-2017)
        IList<PFMDTO00042> SelectAcctNoDbyWorkstation(int workstation, string currency);//Added by HWKO (17-Aug-2017)
    }
}
