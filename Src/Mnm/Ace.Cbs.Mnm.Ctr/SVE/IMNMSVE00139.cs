using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00139
    {
        MNMDTO00055 GetInformationList(string eno, string sourcebranch, bool isMulti);
        string SaveCashDenoEdit(string tlfeno, TLMDTO00015 cashdenodto);
    }
}
