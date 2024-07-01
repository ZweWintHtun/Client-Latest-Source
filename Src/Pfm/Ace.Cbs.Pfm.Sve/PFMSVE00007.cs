using System;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using AutoMapper;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Windows.Core.Utt;

//PassBook->Transaction Binding->Printing User(enquiry) Service
namespace Ace.Cbs.Pfm.Sve
{

    public class PFMSVE00007 : BaseService, IPFMSVE00007
    {
        #region Properties

        private IPFMDAO00044 printUserDAO;
        public IPFMDAO00044 PrintUserDAO
        {
            set { this.printUserDAO = value; }
            get { return this.printUserDAO; }
        } 

        #endregion

        #region IPFMSVE00007 Members

        public PFMDTO00044 SelectPrintUserByBranchCode(string branchCode)
        {
            return printUserDAO.SelectPrintUserBySourceBr(branchCode);
        }

        public bool IsValidPassword(string sourceBranch,string password)
        {
            PFMDTO00044 printUserEntity = printUserDAO.IsValidPassword(sourceBranch);

            if (printUserEntity == null) return false;

            if (password.Equals(Encryption.DecryptString(printUserEntity.Password)))
            {
                return true;
            }
            else
            {
                return false;
            }  
        }

        [Transaction(TransactionPropagation.Required)]
        public void Save(PFMDTO00044 printUserEntity)
        {
            try
            {
                if (this.SelectPrintUserByBranchCode(printUserEntity.SourceBranchCode) == null)
                {
                    PFMORM00044 result = Mapper.Map<PFMDTO00044, PFMORM00044>(printUserEntity);
                    result.UsedDate = DateTime.Now;
                    result.CreatedDate = DateTime.Now;
                    result.Password = Encryption.EncryptString(result.Password);
                    printUserDAO.Save(result);

                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = "MI90001";
                }
                else
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MV00082";
                }
            }
            catch(Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = ex.Message;
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public void Update(PFMDTO00044 printUserEntity)
        {
            try
            {
                printUserEntity.UpdatedDate = DateTime.Now;
                printUserEntity.Password = Encryption.EncryptString(printUserEntity.Password);
                printUserDAO.UpdatePrintUser(printUserEntity);

                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI90001";
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = ex.Message;
            }
        }

        #endregion

    }
}