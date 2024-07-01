using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXServer.Utt;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Windows.Core.Service;
using Ace.Cbs.Cx.Com.Utt;
using Spring.Transaction.Interceptor;
using Spring.Transaction;

namespace Ace.Cbs.Tel.Sve
{
    public class TLMSVE00072 : BaseService, ITLMSVE00072
    {
        public ICXSVE00006 CodeChecker { get; set; }
        public IPFMDAO00028 CledgerDAO { get; set; }
        public IPFMDAO00043 PrnFileDAO { get; set; }
        public IPFMDAO00023 FledgerDAO { get; set; }
        public bool IsCledgerStatus = true;
        public int LedgerPrintLineNo { get; set; }
        //public IList<PFMDTO00043> prnFileDTOLsit { get; set; }
        public ICXSVE00003 PrintingDAO { get; set; }

      

        public IList<PFMDTO00043> GetPrintTransactionByAccountNo(string accountNo)
        {

            #region  check Freeze Account
           
            if (this.CodeChecker.IsFreezeAccount(accountNo))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return null;
            }
            #endregion

            #region Cledger
            PFMDTO00028 cledgerDTO = this.CodeChecker.GetAccountInfoOfCledgerByAccountNo(accountNo);
                if (cledgerDTO != null)
                {
                    #region Check Close Date
                    if (cledgerDTO.CloseDate != null)
                    {

                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = CXMessage.MV00044;
                        return null;
                    }
                    #endregion
                    #region Select Prnfile
                    else
                    {
                        IList<PFMDTO00043> prnFileDTOLsit = this.PrintingDAO.PRNFile_SelecByAccountNo(accountNo);
                        if (prnFileDTOLsit.Count > 0)
                        {
                            prnFileDTOLsit[0].LedgerPrintLineNo = prnFileDTOLsit.Count;
                            prnFileDTOLsit[0].IsCledgerAccountStatus = true;
                            return prnFileDTOLsit;
                        }
                        else
                        {
                            this.ServiceResult.ErrorOccurred = true;
                            this.ServiceResult.MessageCode = CXMessage.MI00047;
                            return prnFileDTOLsit;
                        }

                    }
                    #endregion
                }
            #endregion


            else if (cledgerDTO == null)
            {
                #region Fledger
                PFMDTO00023 fledgerDTO = this.CodeChecker.GetAccountInfoOfFledgerByAccountNo(accountNo);
                if (fledgerDTO == null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV00046;
                    return null;
                }
                else
                {
                    IList<PFMDTO00058> fprnFileDTOLsit = this.PrintingDAO.FPRNFile_SelecByAccountNo(accountNo);
                    IList<PFMDTO00043> prnFileDTOLsit = new List<PFMDTO00043>();
                    foreach (PFMDTO00058 item in fprnFileDTOLsit)
                    {
                        PFMDTO00043 prnfile = new PFMDTO00043();
                        prnfile.IsCledgerAccountStatus = false;                    
                         prnfile.LedgerPrintLineNo = fprnFileDTOLsit.Count;
                        prnfile.DATE_TIME = item.CreatedDate;
                        prnfile.Debit = item.Debit;
                        prnfile.Credit = item.Credit;
                        prnfile.Reference = item.Reference;
                        prnfile.Balance = prnfile.Balance;
                        prnFileDTOLsit.Add(prnfile);
                    }
                       
                    return prnFileDTOLsit;
                }
                #endregion

            }

            else
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MI00047;
                return null;
            }              
        }

         [Transaction(TransactionPropagation.Required)]
        public bool UpdateAndDeleteByAccountNo(string accountNo,IList<PFMDTO00043> prnFileList,bool isCledgerStatus,int ledgerPrintLineNo,int updatedUserId)
        {
            if (isCledgerStatus == true)
            {
                this.CledgerDAO.UpdatePrnLineNoByAccountNo(accountNo, updatedUserId, ledgerPrintLineNo);
                this.PrintingDAO.DeletePrnFileByAccountNo(accountNo);
                return true;
            }

            else if (isCledgerStatus == false)
            {
                this.FledgerDAO.UpdatePrintLine(accountNo, ledgerPrintLineNo,updatedUserId);                
                this.PrintingDAO.DeleteFPrnFileByAccountNo(accountNo);
                return true;
               
            }
            else
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME00062;
                return false;
 
            }
        }

         public int GetPrintLineNumberByAccountNo(string accountNo)
         {
            return this.CledgerDAO.GetPrintLineNumberByAccountNo(accountNo);
         }


    }
}

