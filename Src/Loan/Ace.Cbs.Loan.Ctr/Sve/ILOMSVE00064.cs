using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Dmd.DTO;

using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00064 : IBaseService
    {
        string Save(string dealerNo, string dealerAC, 
                    string dName, string dPhone, 
                    string dAddress, string email,
                    string nrc, string fax, 
                    string businessName, string city,
                    string businessEmail, string address,
                    decimal commission, string eventMode,
                    string sourceBr,int createdUserId,
                    DateTime createdDate,int updatedUserId,
                    DateTime updatedDate);
        void Delete(string dealerNo, int createdUserId, string sourceBr);
        IList<PFMDTO00001> SelectByAccountNumber(string accountNo, DateTime todaydate);
        PFMDTO00067 GetAccountInformation(string accountNo);
        PFMDTO00067 ConvertDTODataToRawDTO(string accountNo);
        string GetLinkAccount(string accountNo, string accountType);
        TLMDTO00018 GetExpireAmount(string accountNo);
        IList<PFMDTO00006> GetChequeInfo(string accountNo);
        IList<PFMDTO00001> GetCustomerInfomationBySaoforCaof(string accountNo, string accountType);
        PFMDTO00028 GetCustomerLedgerDataByAccountNo(string accountNo);

        IList<LOMDTO00095> GetDealerAccountInfo(string acctNo, string sourceBr);
        string CheckAccountExistsOrValid(string accountNo, string sourceBr);
    }
}
