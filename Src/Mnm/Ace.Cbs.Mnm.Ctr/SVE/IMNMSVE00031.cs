using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Service;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Sve;
using System.Collections.Generic;

namespace Ace.Cbs.Mnm.Ctr.Sve
{
    /// <summary>
    /// Interface
    /// Current Account - Individual
    /// Current Account - PrivateFirm
    /// Saving Account - Individual
    /// Saving Account - Minor
    /// Fixed Account - Individual
    /// Fixed Account - Minor
    /// </summary>
    public interface IMNMSVE00031 : IBaseService
    {
        ICXSVE00002 CodeGenerator { get; set; }
        IPFMDAO00028 CledgerDAO { get; set; }
        IPFMDAO00017 CaofDAO { get; set; }       
        IPFMDAO00033 BalanceDAO { get; set; }
        IPFMDAO00001 CustomerIdDAO { get; set; }       
        IPFMDAO00016 SAOFDAO { get; set; }
        IPFMDAO00021 FAOFDAO { get; set; }        
        IPFMDAO00023 FLedgerDAO { get; set; }

        void SaveIndividual(PFMDTO00001 individualDTO);
        PFMDTO00001 CheckingAccount(string accountNo, string accountType, string branchCode);
        //void SaveCompany(PFMDTO00001 companyDTO);
    }
}
