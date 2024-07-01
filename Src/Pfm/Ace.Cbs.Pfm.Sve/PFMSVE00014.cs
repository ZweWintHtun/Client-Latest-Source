using System.Collections.Generic;
using System.Linq;
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
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Pfm.Sve
{
    /// <summary>
    /// Stop Cheque Service
    /// </summary>
    public class PFMSVE00014 : BaseService , IPFMSVE00014
    {
        private IPFMDAO00014 startendDAO;
        public IPFMDAO00014 StartEndDAO
        {
            get { return this.startendDAO; }
            set { this.startendDAO = value; }
        }

        private IPFMDAO00011 stopChequeDAO;
        public IPFMDAO00011 StopChequeDAO
        {
            get { return this.stopChequeDAO; }
            set { this.stopChequeDAO = value; }
        }

        private IPFMDAO00001 customerIdDAO;
        public IPFMDAO00001 CustomerIdDAO
        {
            get { return this.customerIdDAO; }
            set { this.customerIdDAO = value; }
        }

        private IPFMDAO00006 chequeDAO;
        public IPFMDAO00006 ChequeDAO
        {
            get { return this.chequeDAO; }
            set { this.chequeDAO = value; }
        }

        [Transaction(TransactionPropagation.Required)]
        public bool CheckStartChequeNo(string accountNo, string chequeNo, string startNo, string branch)
        {
            PFMDTO00006 DTOData = this.startendDAO.CheckStartChequeNo(accountNo, chequeNo, startNo, branch);
            if (DTOData == null)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00065; //Invalid Start Cheque No.
            }
            return DTOData == null;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool CheckEndChequeNo(string accountNo, string chequeNo, string endNo, string branch)
        {
            PFMDTO00006 DTOData = this.startendDAO.CheckStartChequeNo(accountNo, chequeNo, endNo, branch);
            if (DTOData == null)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00072; //Invalid End Cheque No.
            }
            return DTOData == null;
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual void Save(PFMDTO00011 entity)
        {
            PFMORM00011 result = Mapper.Map<PFMDTO00011, PFMORM00011>(entity);          
             PFMDTO00028 cledgerDTO=new PFMDTO00028();
             cledgerDTO = CXServiceWrapper.Instance.Invoke<ICXSVE00006, PFMDTO00028>(x => x.GetAccountInfoOfCledgerByAccountNo(entity.AccountNo));
            bool returnValue = CXServiceWrapper.Instance.Invoke<ICXSVE00006, bool>(x => x.IsValidChequeBookIssueNoForStopCheque(result.AccountNo, result.ChequeBookNo, result.StartNo, result.EndNo,result.SourceBranchCode,cledgerDTO.CurrencyCode));

            if (returnValue == false)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXServiceWrapper.Instance.ServiceResult.MessageCode;
                return;
            }

            this.stopChequeDAO.Save(result);
            this.ServiceResult.MessageCode = CXMessage.MI90001;// Saving Successful
        }

        IList<PFMDTO00001> customerLists = new List<PFMDTO00001>();
        public IList<PFMDTO00001> GetCustomerListByAccountNumber(string accountNumber)
        {   
            IList<PFMDTO00017> CAOFList = CXServiceWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00017>>(x => x.GetCAOFsByAccountNumber(accountNumber)); 

            if (CAOFList != null && CAOFList.Count > 0)            
            {
                 if (CAOFList[0].SourceBranchCode != CAOFList[0].SourceBranchCode) //add by hmw (For different branch account no checking)
                    //if (CAOFList[0].SourceBranchCode != CurrentUserEntity.BranchCode)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV00091;
                    return null;
                }
                else
                {
                    var customerId = from value in CAOFList
                                     where value.CustomerID != null
                                     select value.CustomerID;
                    if (customerId.ToList().Count > 0)
                    {
                        IList<string> customerIdList = customerId.ToList();
                        IList<PFMDTO00001> customerList = this.customerIdDAO.SelectListByCustId(customerIdList);
                        if (customerList != null)
                        {
                            for (int i = 0; i < customerList.Count; i++)
                            {
                                PFMDTO00001 customer = new PFMDTO00001();
                                customer.CustomerId = customerList[i].CustomerId;
                                customer.Name = customerList[i].Name;
                                customer.NRC = customerList[i].NRC;
                                customerLists.Add(customer);
                            }
                        }
                    }
                    return customerLists;
                }
                
            }

            else
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00058; //Invalid Current Account No.
                return null;
            }            
        }
    }
}