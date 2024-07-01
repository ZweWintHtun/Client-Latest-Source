using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Mnm.Ctr;


namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00142 : IBaseService
    {
      
        void ProcessInterest(string sourceBr, DateTime date, int user);
        void checkDate(string sourceBr, DateTime date);
        void ProcessInterestPrev(string sourceBr, DateTime date, int user);
        void UpdateInterest(string sourceBr, DateTime date, int user);
        void UpdatePre(string sourceBr, DateTime date, int user);
        
    }
}
