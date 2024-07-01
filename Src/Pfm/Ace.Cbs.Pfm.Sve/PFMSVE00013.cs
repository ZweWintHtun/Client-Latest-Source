using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using AutoMapper;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using System;
using System.Collections.Generic;

namespace Ace.Cbs.Pfm.Sve
{
    //Cheque -> Cheque Issue (Book)
    public class PFMSVE00013 : BaseService, IPFMSVE00013
    {
        #region Dao Properties

        private IPFMDAO00006 chequeDAO;
        public IPFMDAO00006 ChequeDAO
        {
            get { return this.chequeDAO; }
            set { this.chequeDAO = value; }
        }

        # endregion

        #region Private Variables

        List<PFMDTO00017> caofEntities;
        
        #endregion
        
        #region Public Methods

        public virtual PFMDTO00006 CheckStartChequeNo(string accountNo, string startNo, string branch)
        {
            PFMDTO00006 chequeInfo = new PFMDTO00006();
            chequeInfo = this.ChequeDAO.CheckStartChequeNo(accountNo,startNo,branch);
            return chequeInfo;
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual void Save(PFMDTO00006 chequeentity)
        {
            //string currency = null;
            //if(chequeentity.AccountNo.Substring(0,3)=="1")
            //{

            //}
            try
            {
                chequeentity.CreatedDate = DateTime.Now;
                PFMORM00006 cheque = Mapper.Map<PFMDTO00006, PFMORM00006>(chequeentity);

                caofEntities = (List<PFMDTO00017>)CXServiceWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00017>>(x => x.GetCAOFsByAccountNumber(cheque.AccountNo));

                if (caofEntities[0].SourceBranchCode != chequeentity.SourceBranchCode)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV00091; //Invalid Account No. for Branch {0}.
                    return;
                }

                else if (this.CheckStartChequeNo(chequeentity.AccountNo, chequeentity.StartNo, chequeentity.SourceBranchCode) != null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV00065 ;  //Invalid Start Cheque No.
                    return;
                }
                else if (CXServiceWrapper.Instance.Invoke<ICXSVE00006, bool>(x => x.HasDuplicatedChequeBookIssueNo(chequeentity.ChequeBookNo, chequeentity.StartNo, chequeentity.EndNo, chequeentity.SourceBranchCode, caofEntities[0].CurrencyCode, chequeentity.AccountNo)))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXServiceWrapper.Instance.ServiceResult.MessageCode;
                    return;
                }

                else
                {
                    this.chequeDAO.Save(cheque);
                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = CXMessage.MI90001; // Saving Successful
                }
            }
            catch(Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME90043;
                throw new Exception(this.ServiceResult.MessageCode);
            }
        }

        #endregion

    }
}