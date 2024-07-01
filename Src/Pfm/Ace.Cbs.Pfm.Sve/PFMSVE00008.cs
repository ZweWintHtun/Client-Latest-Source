using System;
using System.Collections.Generic;
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

namespace Ace.Cbs.Pfm.Sve
{
    public class PFMSVE00008 : BaseService, IPFMSVE00008
    {
        private IPFMDAO00045 printRecordDAO;
        public IPFMDAO00045 PrintRecordDAO
        {
            set { this.printRecordDAO = value; }
            get { return this.printRecordDAO; }
        }
        public ICXSVE00006 CodeChecker { get; set; }

        [Transaction(TransactionPropagation.Required)]
        public PFMDTO00016 Save(PFMDTO00045 entity)
        {
            PFMDTO00016 returnVal = null;
            try
            {
                PFMORM00045 result = Mapper.Map<PFMDTO00045, PFMORM00045>(entity);

                if (this.CodeChecker.IsClosedAccountForCLedger(result.AcctNo))
                {
                    throw new Exception(this.CodeChecker.ServiceResult.MessageCode);
                }
                returnVal = SelectByAccountNumber(result.AcctNo);

                if (returnVal == null)
                {
                    throw new Exception(CXMessage.MV00046);
                }
                //printRecordDAO.Save(result);
                this.ServiceResult.ErrorOccurred = false;
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = ex.Message;
            }
            return returnVal;
        }

        private PFMDTO00016 SelectByAccountNumber(string accountNo)
        {
            PFMDTO00016 result = null;

            IList<PFMDTO00016> saofs = (List<PFMDTO00016>)CXServiceWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00016>>(x => x.GetSAOFsByAccountNumber(accountNo));

            if (saofs.Count > 0)
            {
                result = new PFMDTO00016();
                result.AccountSign = saofs[0].AccountSign;
                result.CurrencyCode = saofs[0].CurrencyCode;
                //result.EStatus = "Saving Account";
                return result;
            }

            IList<PFMDTO00017> caofs = (List<PFMDTO00017>)CXServiceWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00017>>(x => x.GetCAOFsByAccountNumber(accountNo));

            if (caofs.Count > 0)
            {
                result = new PFMDTO00016();
                result.AccountSign = caofs[0].AccountSign;
                result.CurrencyCode = caofs[0].CurrencyCode;
                //result.EStatus = "Current Account";
                return result;
            }

            IList<PFMDTO00021> faofs = (List<PFMDTO00021>)CXServiceWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00021>>(x => x.GetFAOFsByAccountNumber(accountNo));

            if (faofs.Count > 0)
            {
                result = new PFMDTO00016();
                result.AccountSign = faofs[0].AccountSignature;
                result.CurrencyCode = faofs[0].CurrencyCode;
                //result.EStatus = "Fixed Account";
                return result;
            }

            return result;
        }

    }
}