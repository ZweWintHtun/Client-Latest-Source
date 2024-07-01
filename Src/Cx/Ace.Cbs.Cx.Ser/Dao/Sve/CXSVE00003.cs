using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using Spring.Transaction;
using Spring.Transaction.Interceptor;

namespace Ace.Cbs.Cx.Ser.Sve
{
    /// <summary>
    /// Printing Dao Interface
    /// </summary>
    public class CXSVE00003 : BaseService, ICXSVE00003
    {
        private ICXDAO00003 printingDAO;
        public ICXDAO00003 PrintingDAO
        {
            set { this.printingDAO = value; }
            get { return this.printingDAO; }
        }

        public IList<PFMDTO00014> PrintCheque_SelectAll()
        {
            return this.printingDAO.PrintCheque_SelectAll();
        }

        [Transaction(TransactionPropagation.Required)]
        public void PrintCheque_Save(PFMDTO00014 entity)
        {
            try
            {
                PFMORM00014 result = new PFMORM00014();
                result.AccountNo = entity.AccountNo;
                result.BranchCode = entity.BranchCode;
                result.DATE_TIME = DateTime.Now;
                result.UserNo = entity.UserNo;
                result.ChequeBookNo = entity.ChequeBookNo;
                result.ChequeNo = entity.ChequeNo;
                result.BranchCode = entity.SourceBranchCode;
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

        [Transaction(TransactionPropagation.Required)]
        public void PrintCheque_Update(PFMDTO00014 entity)
        {
            try
            {
                PFMORM00014 result = new PFMORM00014();
                result.AccountNo = entity.AccountNo;
                result.DATE_TIME = DateTime.Now;
                result.UserNo = entity.UserNo;
                result.ChequeBookNo = entity.ChequeBookNo;
                result.ChequeNo = entity.ChequeNo;
                result.SourceBranchCode = entity.SourceBranchCode;
                result.UpdatedDate = result.DATE_TIME.Value;
                result.UpdatedUserId = entity.UpdatedUserId;

                this.printingDAO.Update(result);
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MI90002;//Update Success
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME90036; // Error Occur!!! Please contact your administrator.
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public void PrintCheque_Delete(IList<PFMDTO00014> itemList)
        {
            try
            {
                IList<PFMORM00014> result = new List<PFMORM00014>();
                foreach (PFMDTO00014 item in itemList)
                {
                    PFMORM00014 printCheque = new PFMORM00014();
                    printCheque.AccountNo = item.AccountNo;
                    printCheque.DATE_TIME = DateTime.Now;
                    printCheque.UserNo = item.UserNo;
                    printCheque.ChequeBookNo = item.ChequeBookNo;
                    printCheque.ChequeNo = item.ChequeNo;
                    printCheque.SourceBranchCode = item.SourceBranchCode;
                    printCheque.UpdatedDate = printCheque.DATE_TIME.Value;
                    printCheque.UpdatedUserId = item.UpdatedUserId;

                    result.Add(printCheque);
                }

                foreach (PFMORM00014 entity in result)
                {
                    entity.Active = false;
                    this.printingDAO.Delete(entity, false);// false = is not acutal delete
                }
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MI90003; // Delete Success
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME90036; // Error Occur!!! Please contact your administrator.
            }
        }

        public PFMDTO00014 PrintCheque_SelectByPrintChequeId(int id)
        {
            return this.printingDAO.PrintCheque_SelectByPrintChequeId(id);
        }

        [Transaction(TransactionPropagation.Required)]
        public void PRNFile_Save(PFMDTO00043 entity)
        {
            try
            {
                PFMORM00043 result = new PFMORM00043();

                result.Id = entity.Id;
                result.AccountNo = entity.AccountNo;
                result.DATE_TIME = DateTime.Now;
                result.UserNo = entity.UserNo;
                result.Credit = entity.Credit;
                result.Debit = entity.Debit;
                result.Balance = entity.Balance;
                result.Channel = entity.Channel;
                result.Reference = entity.Reference;
                result.PrintLineNo = entity.PrintLineNo;
                result.CurrencyCode = entity.CurrencyCode;
                result.SourceBranchCode = entity.SourceBranchCode;
                result.CreatedDate = result.DATE_TIME.Value;
                result.CreatedUserId = entity.CreatedUserId;

                this.printingDAO.PRNFile_Save(result);
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MI90001;// Saving Successful
            }

            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME90036; // Error Occur!!! Please contact your administrator.
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public void PRNFile_Update(PFMDTO00043 entity)
        {
            try
            {
                PFMORM00043 result = new PFMORM00043();

                result.Id = entity.Id;
                result.AccountNo = entity.AccountNo;
                result.DATE_TIME = DateTime.Now;
                result.UserNo = entity.UserNo;
                result.Credit = entity.Credit;
                result.Debit = entity.Debit;
                result.Balance = entity.Balance;
                result.Channel = entity.Channel;
                result.Reference = entity.Reference;
                result.PrintLineNo = entity.PrintLineNo;
                result.CurrencyCode = entity.CurrencyCode;
                result.SourceBranchCode = entity.SourceBranchCode;
                result.UpdatedDate = result.DATE_TIME.Value;
                result.UpdatedUserId = entity.CreatedUserId;

                this.printingDAO.PRNFile_Update(result);
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MI90002;//Update Success

            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME90036; // Error Occur!!! Please contact your administrator.
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public void PRNFile_Delete(IList<PFMDTO00043> itemList)
        {
            try
            {               
                IList<PFMORM00043> result = new List<PFMORM00043>();

                foreach (PFMDTO00043 pfnItem in itemList)
                {
                    PFMORM00043 pfnFile = new PFMORM00043();

                    pfnFile.Id = pfnItem.Id;
                    pfnFile.AccountNo = pfnItem.AccountNo;
                    pfnFile.DATE_TIME = DateTime.Now;
                    pfnFile.UserNo = pfnItem.UserNo;
                    pfnFile.Credit = pfnItem.Credit;
                    pfnFile.Debit = pfnItem.Debit;
                    pfnFile.Balance = pfnItem.Balance;
                    pfnFile.Channel = pfnItem.Channel;
                    pfnFile.Reference = pfnItem.Reference;
                    pfnFile.PrintLineNo = pfnItem.PrintLineNo;
                    pfnFile.CurrencyCode = pfnItem.CurrencyCode;
                    pfnFile.SourceBranchCode = pfnItem.SourceBranchCode;
                    pfnFile.UpdatedDate = pfnFile.DATE_TIME.Value;
                    pfnFile.UpdatedUserId = pfnItem.CreatedUserId;

                    result.Add(pfnFile);
                }

                foreach (PFMORM00043 item in result)
                {
                    item.UpdatedUserId = item.UpdatedUserId;
                    item.UpdatedDate = DateTime.Now;
                    item.Active = false;
                    this.printingDAO.PRNFile_Delete(item);                 
                }
                
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MI90003;//Delete Success
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME90036; // Error Occur!!! Please contact your administrator.
            }
        }

        public PFMDTO00043 PRNFile_SelectByPRNFileId(int id)
        {
            return this.printingDAO.PRNFile_SelectByPRNFileId(id);
        }

        public IList<PFMDTO00043> PRNFile_SelectAll()
        {
            return this.printingDAO.PRNFile_SelectAll();
        }

        public IList<PFMDTO00043> PRNFile_SelecByAccountNo(string accountNo)
        {
            return this.printingDAO.PRNFile_SelectByAccountNo(accountNo);
        }

        public IList<PFMDTO00058> FPRNFile_SelecByAccountNo(string accountNo)
        {
            return this.printingDAO.FPRNFile_SelectByAccountNo(accountNo);
        }

        [Transaction(TransactionPropagation.Required)]
        public void FPRNFile_Delete(IList<PFMDTO00058> itemList)
        {
            try
            {
                IList<PFMORM00058> result = new List<PFMORM00058>();

                foreach (PFMDTO00058 fprnItem in itemList)
                {
                    PFMORM00058 fpfnFile = new PFMORM00058();

                    fpfnFile.Id = fprnItem.Id;
                    fpfnFile.AccountNo = fprnItem.AccountNo;
                    fpfnFile.AccessDate = DateTime.Now;
                    fpfnFile.Credit = fprnItem.Credit;
                    fpfnFile.Debit = fprnItem.Debit;
                    fpfnFile.Balance = fprnItem.Balance;
                    fpfnFile.Channel = fprnItem.Channel;
                    fpfnFile.Reference = fprnItem.Reference;
                    fpfnFile.CurrencyId = fprnItem.CurrencyId;
                    fpfnFile.SourceBr = fprnItem.SourceBr;
                    fpfnFile.UpdatedDate = fpfnFile.AccessDate;
                    fpfnFile.UpdatedUserId = fprnItem.CreatedUserId;

                    result.Add(fpfnFile);
                }

                foreach (PFMORM00058 item in result)
                {
                    item.UpdatedUserId = item.UpdatedUserId.Value; // to modify
                    item.UpdatedDate = DateTime.Now;
                    item.Active = false;
                    this.printingDAO.FPRNFile_Delete(item);
                }
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MI90003;//Delete Success
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME90036; // Error Occur!!! Please contact your administrator.
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public bool DeletePrnFileByAccountNo(string accountNo)
        {
            return this.printingDAO.DeletePrnFileByAccountNo(accountNo);
        }

        [Transaction(TransactionPropagation.Required)]
        public bool DeleteFPrnFileByAccountNo(string accountNo)
        {
            return this.printingDAO.DeleteFPrnFileByAccountNo(accountNo);
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateDataAfterPrintingForCS(string accountNo, decimal printLineNo,int updatedUserId)
        {
            if (this.printingDAO.DeletePrnFileByAccountNo(accountNo))
                return this.printingDAO.UpdatePrintLineForCS(accountNo,printLineNo,updatedUserId);
            else 
                return false;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateDataAfterPrintingForFixed(string accountNo, decimal printLineNo,int updatedUserId)
        {
            if (this.printingDAO.DeleteFPrnFileByAccountNo(accountNo))
                return this.printingDAO.UpdatePrintLineForFixed(accountNo, printLineNo,updatedUserId);
            else
                return false;
        }

        public IList<PFMDTO00043> SelectPrnFileByAccountNos(string[] accountNos)
        {
            IList<PFMDTO00043> PrintingDataList = new List<PFMDTO00043>();

            foreach (string accountNo in accountNos)
            {
                IList<PFMDTO00043> printingList = new List<PFMDTO00043>();
                printingList = this.printingDAO.PRNFile_SelectByAccountNo(accountNo);
                decimal printLine=this.printingDAO.GetPrintLineforAccountNo(accountNo);

                foreach (PFMDTO00043 info in printingList)
                {
                    info.PrintLineNo = printLine;
                    PrintingDataList.Add(info);
                }
            }
            return PrintingDataList;
        }

        public IList<PFMDTO00058> SelectFPrnFileByAccountNos(string[] accountNos)
        {
            IList<PFMDTO00058> PrintingDataList = new List<PFMDTO00058>();

            foreach (string accountNo in accountNos)
            {
                IList<PFMDTO00058> printingList = new List<PFMDTO00058>();
                printingList = this.printingDAO.FPRNFile_SelectByAccountNo(accountNo);
                decimal printLine = this.printingDAO.GetPrintLineforFixedAccountNo(accountNo);

                foreach (PFMDTO00058 info in printingList)
                {
                    info.lineNo = (int)printLine;
                    PrintingDataList.Add(info);
                }
            }
            return PrintingDataList;
        }

    }
}
