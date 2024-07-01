using System;
using System.Collections.Generic;
using System.Linq;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using AutoMapper;
using Spring.Transaction;
using Spring.Transaction.Interceptor;

namespace Ace.Cbs.Pfm.Sve
{
    public class PFMSVE00009 : BaseService, IPFMSVE00009
    {     
        private IPFMDAO00043 prnDAO;
        public IPFMDAO00043 PrnDAO
        {
            set { this.prnDAO = value; }
            get { return this.prnDAO; }
        }

        private IPFMDAO00058 fprnDAO;
        public IPFMDAO00058 FPrnDAO
        {
            set { this.fprnDAO = value; }
            get { return this.fprnDAO; }
        }

        public IPFMDAO00028 CledgerDAO { get; set; }

        public IPFMDAO00023 FledgerDAO { get; set; }

        #region IPFMSVE00009 Members

        [Transaction(TransactionPropagation.Required)]
        public void SavePrnFile(PFMDTO00043 PrnFile)
        {
            try
            {
                PFMORM00043 result = Mapper.Map<PFMDTO00043, PFMORM00043>(PrnFile);
                this.prnDAO.Save(result);
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI90001";
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = ex.Message;
            }

        }

        [Transaction(TransactionPropagation.Required)]
        public void SaveFPrnFile(PFMDTO00058 FPrnFile)
        {
            try
            {
                PFMORM00058 result = Mapper.Map<PFMDTO00058, PFMORM00058>(FPrnFile);
                this.fprnDAO.Save(result);
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI90001";
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = ex.Message;
            }
        }

        public IList<PFMDTO00043> GetPrnFileByAccountNo(string accountNo)
        {
            return this.prnDAO.SelectPrnFileByAccountNo(accountNo);
        }

        public IList<PFMDTO00058> GetFPrnFileByAccountNo(string accountNo)
        {
            return this.fprnDAO.SelectFPrnFileByAccountNo(accountNo);
        }

        public void UpdatePrintLineNumber(string accountNo, int lineCount, bool isFixedAccount, int updatedUserId)
        {
            try
            {
                if (isFixedAccount)
                {
                    if (this.FledgerDAO.UpdatePrintLine(accountNo, lineCount,updatedUserId) == false)
                    {
                        // Update Error
                        throw new Exception(CXMessage.MI00009);
                    }
                }
                else
                {
                    if (this.CledgerDAO.UpdatePrintLine(accountNo, lineCount,updatedUserId) == false)
                    {
                        // Update Error
                        throw new Exception(CXMessage.MI00009);
                    }
                }

                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI90002";
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MI00009;
            }
        }

        public int SelectPrintLineNumberByAccountNo(string accountNo, bool isFixedAccount)
        {
            if (isFixedAccount)
            {
                return this.FledgerDAO.GetPrintLineNumberByAccountNo(accountNo); 
            }
            else
            {
                return this.CledgerDAO.GetPrintLineNumberByAccountNo(accountNo); 
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public void DeletePrnFile(IList<PFMDTO00043> PrnFiles, List<string[]> printedList)
        {
            try
            {
                foreach (string[] printedRow in printedList)
                {
                    int currentId =Convert.ToInt32(printedRow[5]);

                    if (currentId == 0)
                    {
                        continue;
                    }

                    PFMDTO00043 prnFile =PrnFiles.Where<PFMDTO00043>(x => x.Id == currentId).Single<PFMDTO00043>();

                    PFMORM00043 result = Mapper.Map<PFMDTO00043, PFMORM00043>(prnFile);

                    if (this.prnDAO.DeletePrnFileById(result.Id) == false) 
                    {
                        throw new Exception(CXMessage.MI00008);
                    }

                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = "MI90003";
                }
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MI00008;
                throw new Exception(this.ServiceResult.MessageCode);
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public void DeleteFPrnFile(IList<PFMDTO00058> FPrnFiles, List<string[]> printedList)
        {
            try
            {
                foreach (string[] printedRow in printedList)
                {
                    int currentId = Convert.ToInt32(printedRow[5]);

                    if (currentId == 0)
                    {
                        continue;
                    }

                    PFMDTO00058 fPrnFile =FPrnFiles.Where<PFMDTO00058>(x => x.Id == currentId).Single<PFMDTO00058>();

                    PFMORM00058 result = Mapper.Map<PFMDTO00058, PFMORM00058>(fPrnFile);

                    if (this.fprnDAO.DeleteFPrnFileById(result.Id) == false)
                    {
                        throw new Exception(CXMessage.MI00008);
                    }

                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = "MI90003"; 
                }
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MI00008;
                throw new Exception(this.ServiceResult.MessageCode);
            }
        }
        #endregion
    }
}