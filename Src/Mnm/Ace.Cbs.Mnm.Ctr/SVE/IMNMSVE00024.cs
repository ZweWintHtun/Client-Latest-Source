using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00024 : IBaseService
    {
        TLMDTO00001 SelectReInfoByRegisterNo(string registerNo, string branchNo);
        void Save_ReEntity(TLMDTO00001 entity);
    }
}
