using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using Spring.Transaction;
using Ace.Cbs.Cx.Com.Utt;
using Spring.Transaction.Interceptor;
using System;


namespace Ace.Cbs.Pfm.Sve
{
    public class PFMSVE00015 : BaseService, IPFMSVE00015
    {
        //Print Cheque Service

        #region"DAOProperties"
        private ICXDAO00003 printingDAO;
        public ICXDAO00003 PrintingDAO
        {
            set { this.printingDAO = value; }
            get { return this.printingDAO; }
        }

        private IPFMDAO00014 printChequeDAO;
        public IPFMDAO00014 PrintChequeDAO
        {
            get { return this.printChequeDAO; }
            set { this.printChequeDAO = value; }

        }

        private IPFMDAO00006 chequeDAO;
        public IPFMDAO00006 ChequeDAO
        {
            get { return this.chequeDAO; }
            set { this.chequeDAO = value; }

        }

        public IPFMDAO00020 UCheckDAO { get; set; }
        #endregion
        
        #region"Method"

        [Transaction(TransactionPropagation.Required)]
        public void Save(IList<PFMDTO00014> printedChequeList)
        {
            for (int i = 0; i < printedChequeList.Count; i++)
            {
                PFMDTO00014 printedCheque = printedChequeList[i];
                this.PrintCheque_Save(printedCheque);               
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public void PrintCheque_Save(PFMDTO00014 entity)
        {
            try
            {
                PFMORM00014 result = new PFMORM00014();
                result.AccountNo = entity.AccountNo;
                result.BranchCode = entity.BranchCode;
                result.DATE_TIME = entity.DATE_TIME;
                result.UserNo = entity.UserNo;
                result.ChequeBookNo = entity.ChequeBookNo;
                result.ChequeNo = entity.ChequeNo;
                result.SourceBranchCode = entity.SourceBranchCode;
                result.CreatedDate = result.DATE_TIME.Value;
                result.CreatedUserId = entity.CreatedUserId;

                this.printingDAO.Save(result);
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MI90001;// Saving Successful   
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME90036; // Error Occur!!! Please contact your administrator.
            }
        }

        public PFMDTO00006 SelectStartNoAndEndNoByChequeBookNo(string accountNo, string chequeBookNo)
        {
            return this.chequeDAO.SelectStartNoAndEndNoByChequeBookNo(accountNo, chequeBookNo);
        }

        public IList<PFMDTO00020> SelectUchequeByAccountNoChequeNo(string accountNo, string chequeBookNo, string sourceBr)
        {
            return this.UCheckDAO.SelectUchequeByAccountNoChequeNo(accountNo, chequeBookNo, sourceBr);
        }
        #endregion
    }
}
 