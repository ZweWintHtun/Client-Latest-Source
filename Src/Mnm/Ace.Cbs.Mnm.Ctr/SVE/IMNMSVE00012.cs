using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Ctr.PTR;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using System.Drawing;
using System.Windows.Forms;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Service;

namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00012 : IBaseService
    {
        IPFMDAO00054 TlfDAO { get; set; }
        ICXDAO00006 codeCheckerDAO { get; set; }
        
        void Update(TLMDTO00016 Entity);

        string Save(PFMDTO00054 Entity);

        IList<PFMDTO00054> SelectTlfInfoByEntryNoandDateTime(string eno, string dtranCode, string ctranCode,string sourcebr);

        TLMDTO00016 SelectPOInfoByPONO(string PoNo, string sourcebr);
    }
}
