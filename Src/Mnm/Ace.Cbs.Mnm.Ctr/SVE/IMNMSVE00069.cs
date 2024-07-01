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
    public interface IMNMSVE00069 : IBaseService
    {
        IList<PFMDTO00029> SelectLinkACInfo(string linkType,string branchNo);
    }
}
