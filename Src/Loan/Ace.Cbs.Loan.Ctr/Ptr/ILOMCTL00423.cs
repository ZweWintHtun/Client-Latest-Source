using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00423
    {
        ILOMVEW00423 View { get; set; }
        void Print(string rptName,string bCode,string cur,string loanGroup);
        IList<LOMDTO00001> GetAllBLTypes();
    }
    public interface ILOMVEW00423
    {
        string bCode { get; set; }
        string cur { get; set; }
        string loanGroup { get; set; }
        string sourceBr { get; set; }
    }
}
