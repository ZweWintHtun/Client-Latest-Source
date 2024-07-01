using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Admin.Contracts.Dao;

namespace Ace.Cbs.Pfm.Sve
{
    public class PFMSVE00021 : BaseService, IPFMSVE00021
    {

        string firstCustomerId=string.Empty;
        public IList<PFMDTO00016> SAOF { get; set; }
        private IChargeOfAccountDAO coaDAO;
        public IChargeOfAccountDAO COADAO
        {
            get
            {
                return this.coaDAO;
            }
            set
            {
                this.coaDAO = value;
            }
        }
        public ICXSVE00006 CodeChecker { get; set; }
        private IPFMDAO00028 cledgerDAO;
        public IPFMDAO00028 CledgerDAO
        {
            get
            {
                return this.cledgerDAO;
            }
            set
            {
                this.cledgerDAO = value;
            }
        }

        // Call Dao SelectACode Method
        public ChargeOfAccountDTO SelectACode(string aCode, string sourceBranchCode)
        {
            return this.coaDAO.SelectACode(aCode, sourceBranchCode);
        }

        //Select Saving Account No for CLedger
        public PFMDTO00028 SelectAccountNoByCustomerId(string accountNo)
        {
            return this.cledgerDAO.SelectAccountNoByCustomerId(accountNo);        
            
        }

        //Select SAOF's  Account Numbers
        public IList<PFMDTO00016> GetSAOFByAccountNumber(string accountNumber)
        {

            return CXServiceWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00016>>(x => x.GetSAOFsByAccountNumber(accountNumber));
        }

        //Select SAOF's  Account Numbers
        public PFMDTO00001 GetCustomerByAccountNumber(string accountNumber)
        {
            // Get SAOF by accountNo (For CustomerId)
            SAOF = this.GetSAOFByAccountNumber(accountNumber);

            // Check Account No
            if (SAOF == null)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00051; // Invalid Saving Account No.
                return null;
            }
            else if (SAOF.Count == 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00051; // Invalid Saving Account No.
                return null;
            }

            foreach (PFMDTO00016 CustId in SAOF)
                if (CustId.Customer_Id != null && CustId.Customer_Id != string.Empty)
                {
                    firstCustomerId = CustId.Customer_Id;
                    break;
                }

            return CXServiceWrapper.Instance.Invoke<ICXSVE00006, PFMDTO00001>(x => x.GetCustomerByCustomerId(firstCustomerId));
        }


    }
}