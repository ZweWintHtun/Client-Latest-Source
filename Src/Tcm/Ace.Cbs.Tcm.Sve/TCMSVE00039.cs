using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tcm.Ctr.Sve;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Com.Utt;


namespace Ace.Cbs.Tcm.Sve
{
    public class TCMSVE00039:BaseService,ITCMSVE00039
    {
        #region DAO
        public IPFMDAO00006 ChequeDAO { get; set; }
        public IPFMDAO00011 StopChequeDAO { get; set; }
        public IPFMDAO00014 PrintChequeDAO { get; set; }
        public IPFMDAO00028 CledgerDAO { get; set; }
        private ICXDAO00006 codeCheckerDAO;
        #endregion

        #region Methods
        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00006> GetIssuedChequeData(PFMDTO00042 data)
        {
            IList<PFMDTO00006> IssuedCheques = new List<PFMDTO00006>();
            if (data.RequiredType == "By Date")
            {
                //string startDate = CXCOM00006.Instance.GetDateFormat(data.StartDate);
                //string endDate = CXCOM00006.Instance.GetDateFormat(data.EndDate);
                IssuedCheques = this.ChequeDAO.SelectIssuedChequeByDate(data.StartDate, data.EndDate,data.SourceBranch);
            }
            else
            {
                IssuedCheques = this.ChequeDAO.SelectIssuedChequeByAccount(data.AcctNo,data.SourceBranch);
            }
          
            return IssuedCheques;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00011> GetStoppedChequeData(PFMDTO00042 data)
        {
            IList<PFMDTO00011> StoppedCheques = new List<PFMDTO00011>();
            if (data.RequiredType == "By Date")
            {
                StoppedCheques = this.StopChequeDAO.SelectSChequeDataByDate(data.StartDate, data.EndDate,data.SourceBranch);
            }
            else
            {
                StoppedCheques = this.StopChequeDAO.SelectSChequeDataByAccount(data.AcctNo, data.SourceBranch);
            }

            return StoppedCheques;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00014> GetPrintedChequeData(PFMDTO00042 data)
        {
            IList<PFMDTO00014> PrintedCheques = new List<PFMDTO00014>();
            if (data.RequiredType == "By Date")
            {
                PrintedCheques = this.PrintChequeDAO.SelectPrintedChequeByDate(data.StartDate, data.EndDate,data.SourceBranch);
            }
            else
            {
                PrintedCheques = this.PrintChequeDAO.SelectPrintedChequeByAccount(data.AcctNo,data.SourceBranch);
            }

            return PrintedCheques;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool CheckIsSavingAccountNo(string accountNo, string sourcebr)
        {
            PFMDTO00028 account = this.CledgerDAO.SelectByAccountNoAndSourceBr(accountNo, sourcebr);
            if (account != null && account.AccountSign.Substring(0,1)=="S")
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00211;
            }

            return account != null;
        }

        public bool IsClosedAccountForCLedger(string accountNo)
        {
            object account = this.codeCheckerDAO.GetClosedAccountByAccountNo(accountNo);
            if (account != null)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00044;
            }

            return account != null;
        }

        [Transaction(TransactionPropagation.Required)]
        public void CheckingChequeBookNo(string accountNo, string sourcebr)
        {
            //bool flag = false ;

           this.CheckIsSavingAccountNo(accountNo, sourcebr);
           //this.IsClosedAccountForCLedger(accountNo);           
        }


        #endregion
    }
}
