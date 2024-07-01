using System;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.Core.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Mnm.Ctr.Sve;
using System.Collections.Generic;
using Ace.Cbs.Mnm.Ctr.Dao;
//using Ace.Cbs.Pfm.Dao;


namespace Ace.Cbs.Mnm.Sve
{
    class MNMSVE00059 : BaseService, IMNMSVE00059
    {
        #region Properties

        /// <summary>
        /// Link Account Dao 
        /// </summary>
        /// 
        public ICXDAO00006 CommonDAO { get; set; }
        public IPFMDAO00023 FLedgerDAO { get; set; }
        public ICXDAO00009 ViewDAO { get; set; }

        public IList<MNMDTO00035> freceiptList { get; set; }

        public IList<PFMDTO00001> CommonDto { get; set; }

        #endregion

        #region Methods
        public IList<MNMDTO00035> SelectFReceiptInfo(string acctno,string cur,string branchno)
        {

            freceiptList = this.ViewDAO.SelectFReceiptInfo(acctno,branchno,cur);

            if (freceiptList == null || freceiptList.Count <= 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MI00039;    //No data to Report
                return null;
            }

            return freceiptList;

        }

        public IList<PFMDTO00001> CheckingAccount(string accountNo,string branchCode)
        {
            string message = string.Empty;

            try
            {

                PFMDTO00023 fledgerAccount = this.FLedgerDAO.SelectACSignAndCurByAccountNo(accountNo);

                if (fledgerAccount == null)     //Data Not Exist
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV00046;     //Invalid Account
                }
                else
                {
                    CommonDto = CommonDAO.SelectCustomerInformationByFAOF(accountNo);//Select From Faof
                    this.CommonDto[0].SourceBranch = fledgerAccount.SourceBranchCode;
                }
            }

            catch (Exception e)
            {
                if (e.Message == CXMessage.MV00211)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV00211;
                    CommonDto = new List<PFMDTO00001>();
                    CommonDto[0].Message = message;
                }
                else
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = e.Message;
                }
            }
            return this.CommonDto;

        }

        #endregion

    }
}
