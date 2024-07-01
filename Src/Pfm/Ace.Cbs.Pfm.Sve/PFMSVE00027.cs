using System;
using System.Collections.Generic;
using System.Linq;
//using System.String;
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
    /// FReceipt Service 
    /// </summary>
    public class PFMSVE00027 : BaseService, IPFMSVE00027
    {
        #region Dao Properties

        private IPFMDAO00032 freceiptDAO;
        public IPFMDAO00032 FReceiptDAO
        {
            get
            {
                return this.freceiptDAO;
            }
            set
            {
                this.freceiptDAO = value;
            }
        }

        private IPFMDAO00023 fledgerDAO;
        public IPFMDAO00023 FledgerDAO
        {
            get
            {
                return this.fledgerDAO;
            }
            set
            {
                this.fledgerDAO = value;
            }
        }

        public ICXSVE00006 CodeChecker { get; set; }

        #endregion

        #region Private Variables

        private int SerialCount = 4;
        List<PFMDTO00021> faofEntities;

        #endregion

        #region Public Methods

        [Transaction(TransactionPropagation.Required)]
        public PFMDTO00032 Save(PFMDTO00032 freceiptentity, bool forAccountOpening)
        {           
            try
            {               
                PFMORM00032 result = Mapper.Map<PFMDTO00032, PFMORM00032>(freceiptentity);

                if(forAccountOpening == false)
                {
                    faofEntities = (List<PFMDTO00021>)CXServiceWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00021>>(x => x.GetFAOFsByAccountNumber(result.AccountNo));
                                        
                    if (faofEntities == null || faofEntities.Count == 0)
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = CXMessage.MV00033; //Invalid Fixed Account No.
                        return null;                                       
                    }
                    else if (faofEntities[0].SourceBranchCode != freceiptentity.SourceBranchCode)
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = CXMessage.MV00091; //Invalid Account No. for Branch {0}.
                        return null; 
                    }
                    else
                    {
                        result.AccountSign = faofEntities[0].AccountSignature;
                        result.CurrencyCode = faofEntities[0].CurrencyCode;
                    }
                }

                if (freceiptentity.AutoRenewal == true)
                {
                  int acc =result.ToAccountNo.ToString().Length;
                  if(acc == 6)
                    {
                        //this.ServiceResult.ErrorOccurred = true;
                        //this.ServiceResult.MessageCode = CXMessage.MI00004;                    
                        //return null;
                    }
                  else if (acc == 15)
                      if (!this.CheckExistAccountNoForCurrentAndSaving(result.ToAccountNo, result.CurrencyCode, freceiptentity.SourceBranchCode))             
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = this.ServiceResult.MessageCode;                    
                        return null;
                    }                     
                }

                string receiptNo = GenerateReceiptNoByAccountNo(result);
                if (string.IsNullOrEmpty(receiptNo)) 
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV00085; // Receipt No for this Account is already reached it's maximum limit.
                    return null;
                }
                else
                {
                    result.ReceiptNo = receiptNo;
                    result.FirstReceiptNo = receiptNo;
                    result.Active = true;
                    result.CreatedDate = DateTime.Now;
                    this.freceiptDAO.Save(result);
                    freceiptentity.ReceiptNo = receiptNo; 
                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = CXMessage.MI00004;// Saving Successful
                }
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME90043;
                throw new Exception(this.ServiceResult.MessageCode);
            }

            return freceiptentity;
        }

        private bool CheckExistAccountNoForCurrentAndSaving(string takenAccountNo,string fixedAccountCurrencyCode,string sourceBr)
        {
            if (String.IsNullOrEmpty(takenAccountNo))
            {
                return true;
            }
            // Check saving account no is already closed or not.
            if (this.CodeChecker.IsClosedAccountForCLedger(takenAccountNo))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;                
                return false;
            }

            List<PFMDTO00016> saofEntities =(List<PFMDTO00016>) CXServiceWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00016>>(x => x.GetSAOFsByAccountNumber(takenAccountNo));
                        
            if (saofEntities.Count > 0)
            {
                if (saofEntities[0].SourceBranchCode != sourceBr)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV00214; //Invalid Interest Taken Account No. for Branch {0}.
                    return false;
                }

                if (saofEntities[0].CurrencyCode == fixedAccountCurrencyCode)
                    return true;
                else
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV00080; //Currency of Fixed Account and Interest Taken Account should be same.
                    return false;
                }
            }
            else
            {
                List<PFMDTO00017> caofEntities = (List<PFMDTO00017>)CXServiceWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00017>>(x => x.GetCAOFsByAccountNumber(takenAccountNo));

                if (caofEntities.Count == 0)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV00036; //Invalid Interest Taken Account No
                    return false;
                }

                else if (caofEntities[0].SourceBranchCode != sourceBr)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV00214; //Invalid Interest Taken Account No. for Branch {0}.
                    return false;
                }

                if (caofEntities[0].CurrencyCode != fixedAccountCurrencyCode)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV00080; //Currency of Fixed Account and Interest Taken Account should be same.
                    return false;
                }
            }
            return true;
        }
        //private bool CheckExistAccountNoForDomestic(string takenAccountNo, string domesticAccountCurrencyCode, string sourceBr)
        //{
        //    if (String.IsNullOrEmpty(takenAccountNo))
        //    {
        //        return true;
        //    }
        //    else //for DomesticAccountType
        //    {

        //    }
        //    List<PFMDTO00017> caofEntities = (List<PFMDTO00017>)CXServiceWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00017>>(x => x.GetCAOFsByAccountNumber(takenAccountNo));
        //    this.ServiceResult.ErrorOccurred = true;
        //    this.ServiceResult.MessageCode = CXMessage.MV00080; //Currency of Fixed Account and Interest Taken Account should be same.
        //    return false;
        //}
        public void Update(int id, string rNo)
        {
            try
            {
                this.freceiptDAO.Update(id, rNo);
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MI90002;
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME90036;
            }
        }

        #endregion

        #region Private Methods

        private string GenerateReceiptNoByAccountNo(PFMORM00032 fReceiptEntity)
        {
            string receiptNo = string.Empty;

            //string prefixCode = GetPrefixCode(Convert.ToInt32(Convert.ToInt32(fReceiptEntity.Duration)));
            string prefixCode = GetPrefixCode(fReceiptEntity.Duration);

            if (String.IsNullOrEmpty(fReceiptEntity.AccountNo))
            {
                receiptNo = GetGenerateNumber(prefixCode, 0);
            }

            List<PFMDTO00032> fReceipts = (List<PFMDTO00032>)this.freceiptDAO.GetFixedReceiptByAccountNo(fReceiptEntity.AccountNo, fReceiptEntity.Duration);

            if (fReceipts.Count > 0)
            {
                string generateCode = fReceipts.OrderBy(a => a.ReceiptNo).LastOrDefault<PFMDTO00032>().ReceiptNo;

                int currentSerialNo = Convert.ToInt32(generateCode.Substring(generateCode.Length - SerialCount, SerialCount));

                receiptNo = GetGenerateNumber(prefixCode, currentSerialNo);
            }
            else
            {
                receiptNo = GetGenerateNumber(prefixCode, 0);
            }

            return receiptNo;
        }

        //private string GetPrefixCode(int duration)
        //{
        //    string prefixCode = string.Empty;

        //    if (duration < 1)
        //    {
        //        duration *= 4;
        //        prefixCode = duration.ToString() + 'W';
        //    }
        //    else if (duration >= 1 && duration < 12)
        //    {
        //        prefixCode = duration.ToString() + 'M';
        //    }
        //    else if (duration >= 12)
        //    {
        //        duration = duration / 12;
        //        prefixCode = duration.ToString() + 'Y';
        //    }

        //    return prefixCode;
        //}

        private string GetPrefixCode(decimal duration)
        {
            string prefixCode = string.Empty;

            if (duration < 1)
            {
                duration *= 4;
                prefixCode = Convert.ToInt32(duration).ToString() + 'W';
            }
            else if (duration >= 1 && duration < 12)
            {
                prefixCode = Convert.ToInt32(duration).ToString() + 'M';
            }
            else if (duration >= 12)
            {
                duration = duration / 12;
                prefixCode = Convert.ToInt32(duration).ToString() + 'Y';
            }

            return prefixCode;
        }

        private string GetGenerateNumber(string prefixCode, int currentSerialNo)
        {
            int serialNo = currentSerialNo + 1;

            string ReceiptNoMaximunValue = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiptNoMaximumValue);

            if (serialNo > Convert.ToInt32(ReceiptNoMaximunValue))
                return null;
            else
                return prefixCode + serialNo.ToString().PadLeft(SerialCount, '0');
        }

        private PFMDTO00023 GetAccountSignAndCurByAccountNo(string accountNo)
        {
            return fledgerDAO.SelectACSignAndCurByAccountNo(accountNo);
        }

        #endregion
    }
}