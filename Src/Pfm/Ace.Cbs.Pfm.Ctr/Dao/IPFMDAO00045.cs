using System;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;

namespace Ace.Cbs.Pfm.Ctr.Dao 
{
   public interface IPFMDAO00045 : IDataRepository<PFMORM00045>
   {
        DateTime SelectCloseDateByAccountNo(string AccountNo);
   }
}