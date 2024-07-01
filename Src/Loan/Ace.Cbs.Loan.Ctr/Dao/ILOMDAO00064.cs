using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Dmd.DTO;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00064 : IDataRepository<LOMORM00026>
    {
        string AddDealerRegistration(string dealerNo, string dealerAC, string dName, string dPhone, string dAddress, string email, string nrc, string fax, string businessName, string city, string businessEmail, string address, decimal commission, string eventMode, string sourceBr, int createdUserId, DateTime createdDate, int updatedUserId, DateTime updatedDate);
        string DeleteDealerRegistration(string dealerNo, int createdUserId, string sourceBr);
        IList<LOMDTO00095> GetDealerAccountInfo(string acctNo, string sourceBr);
    }
    
}
