using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00025 : IBaseService
    {
        TLMDTO00001 GetReInfo(string registerNo, string sourceBr);
        void UpdateReInfo(TLMDTO00001 entity);
    }
}
