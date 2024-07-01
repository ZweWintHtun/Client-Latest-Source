//----------------------------------------------------------------------
// <copyright file="TLMSVE00042.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Ye Mann Aung</CreatedUser>
// <CreatedDate>2013-07-01</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;

using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Cx.Ser.Sve;

namespace Ace.Cbs.Tel.Sve
{
    public class TLMSVE00042 : BaseService, ITLMSVE00042
    {
        public ICXSVE00006 GetAccountInfomation { get; set; }
        
        private ITLMDAO00018 loansDAO;
        public ITLMDAO00018 LoansDAO
        {
            get { return this.loansDAO; }
            set { this.loansDAO = value; }
        }

        #region Method

        public PFMDTO00028 GetCustomerLedgerDataByAccountNo(string accountNo) // To get CLedger Data by AccountNo
        {
            return this.GetAccountInfomation.GetAccountInfoOfCledgerByAccountNo(accountNo);
        }

        public IList<PFMDTO00001> GetCustomerInfomationBySaoforCaof(string accountNo, string accountType)
        {
            return this.GetAccountInfomation.GetCustomerInfomationByCaofOrSaof(accountNo, accountType);
        }

        public IList<PFMDTO00006> GetChequeInfo(string accountNo)
        {
            return this.GetAccountInfomation.GetStartNoandEndNo(accountNo);
        }

        public TLMDTO00018 GetExpireAmount(string accountNo)
        {
            return this.LoansDAO.GetExpireAmount(accountNo);
        }

        //Added by HWKO (26-Jun-2017)
        public IList<TLMDTO00018> GetExpireAmountByAcctNo(string accountNo)
        {
            return this.LoansDAO.GetExpireAmountByAcctNo(accountNo);
        }

        //Added by HWKO (26-Jun-2017)
        public IList<TLMDTO00018> GetOverdraftExpireAmountByAcctNo(string accountNo)
        {
            return this.LoansDAO.GetOverdraftExpireAmountByAcctNo(accountNo);
        }

        //Added by HWKO (26-Jun-2017)
        public IList<TLMDTO00018> GetLoansExpireAmountByAcctNo(string accountNo)
        {
            return this.LoansDAO.GetLoansExpireAmountByAcctNo(accountNo);
        }

        public string GetLinkAccount(string accountNo, string accountType)
        {
            return this.GetAccountInfomation.GetLinkAccountNo(accountNo, accountType);
        }


        public PFMDTO00067 ConvertDTODataToRawDTO(string accountNo)
        {
            PFMDTO00067 rawdto = new PFMDTO00067();
            rawdto.AccountNo = accountNo;

            PFMDTO00028 cledgerDto = new PFMDTO00028();
            cledgerDto = this.GetCustomerLedgerDataByAccountNo(accountNo);
            if (cledgerDto != null)
            {
                rawdto.Amount = cledgerDto.CurrentBal;
                rawdto.AccountSign = cledgerDto.AccountSign;
                rawdto.ClosedDate = cledgerDto.CloseDate;
                rawdto.OverDraftAmount = cledgerDto.OverdraftLimit;
                rawdto.LinkAccountNo = this.GetLinkAccount(accountNo, rawdto.AccountSign);
                //rawdto.NoOfLoan = cledgerDto.LoansCount;
                rawdto.MiniumBalance = cledgerDto.MinimumBalance;

                //TLMDTO00018 loandto = new TLMDTO00018();
                //loandto = this.GetExpireAmount(accountNo);
                //rawdto.ExpireAmount = (loandto != null)?((loandto.ExpireDate < DateTime.Now) ? loandto.SAmount.Value : 0):0;
                IList<TLMDTO00018> loandtoLists = new List<TLMDTO00018>();
                loandtoLists = this.GetLoansExpireAmountByAcctNo(accountNo);
                rawdto.LoansAmount = 0;
                rawdto.NoOfLoan = loandtoLists.Count;
                if (loandtoLists.Count > 0)
                {
                    foreach (TLMDTO00018 loandto in loandtoLists)
                    {
                        rawdto.ExpireAmount += (loandto != null) ? ((loandto.ExpireDate < DateTime.Now) ? loandto.SAmount.Value : 0) : 0;
                        rawdto.LoansAmount += (loandto != null) ? loandto.SAmount.Value : 0;
                    }
                }
                
                
                string accountType = cledgerDto.AccountSign.Substring(0, cledgerDto.AccountSign.Length - 1);
                rawdto.CustomerInfo = this.GetCustomerInfomationBySaoforCaof(accountNo, accountType);
                rawdto.NoOfPersonToSign = (rawdto.CustomerInfo.Count >= 1) ? rawdto.CustomerInfo[0].NoOfPersonSign : 0;
                rawdto.JointType = (rawdto.CustomerInfo.Count > 1) ? rawdto.CustomerInfo[0].JoinType : string.Empty;

                
                if (rawdto.LinkAccountNo != string.Empty)
                {
                    cledgerDto = this.GetCustomerLedgerDataByAccountNo(rawdto.LinkAccountNo);
                    rawdto.LinkAmount = cledgerDto.CurrentBal;
                }
                rawdto.Photo =rawdto.CustomerInfo[0].CustPhotos;
                rawdto.Signature =rawdto.CustomerInfo[0].Signature;
                
                if(accountType.Equals("C"))
                    rawdto.ChequeInfo = this.GetChequeInfo(accountNo);
                
                return rawdto;
            }
            else
            {
                return rawdto = null;
            }
        }
        #endregion

        #region MainMethod

        public PFMDTO00067 GetAccountInformation(string accountNo)
        {
            try
            {
                return this.ConvertDTODataToRawDTO(accountNo);
            }
            catch
            {
                throw new Exception();
            }
        }

        #endregion
    }
}
