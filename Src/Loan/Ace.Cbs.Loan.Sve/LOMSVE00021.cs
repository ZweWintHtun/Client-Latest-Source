//----------------------------------------------------------------------
// <copyright file="LOMSVE00021" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo</CreatedUser>
// <CreatedDate>2015-02-04</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Mnm.Ctr.Dao;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Dao;
using Spring.Transaction.Interceptor;
using Spring.Transaction;

namespace Ace.Cbs.Loan.Sve
{
    public class LOMSVE00021 : BaseService, ILOMSVE00021
    {
        #region "Properties"
        private ILOMDAO00013 LegalDAO { get; set; }
        private ITLMDAO00018 LoanDAO { get; set; }
        #endregion

        #region "Methods"
        public LOMDTO00013 SelectLegalInfoByLoanNo(string Lno,string sourceBr)
        {
            LOMDTO00013 LegalDTO = new LOMDTO00013();
            try
            {
                LegalDTO = LegalDAO.SelectLegalInfoByLoanNo(Lno, sourceBr).Count > 0 ? LegalDAO.SelectLegalInfoByLoanNo(Lno, sourceBr).First() : null;
                if (LegalDTO != null)
                 {
                     if (LegalDTO.CloseDate != null)
                     {
                         ServiceResult.ErrorOccurred = true;
                         ServiceResult.MessageCode = "MV90073";//This legal case loan is already closed.
                     }
                     else if (LegalDTO.ReleaseDate != null)
                     { 
                         ServiceResult.ErrorOccurred = true;
                         ServiceResult.MessageCode = "MV90075";//This loan No has not Legal Case.!
                     }
                 }
                 else
                 {
                       ServiceResult.ErrorOccurred = true;
                      ServiceResult.MessageCode = "MV90055";//Invalid Loan No.
                 }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException+ex.Message);
            }
            return LegalDTO;
        }

         [Transaction(TransactionPropagation.Required)]
        public bool Update(string loanNo, string sourceBr,decimal intRate,string legalawer, int updatedUserId)
        {
            try
            {
                bool isUpdate = false;
                try
                {
                    this.LoanDAO.UpdateLegaLawyer(legalawer, loanNo, sourceBr, updatedUserId);
                    this.LegalDAO.UpdateIntRate(intRate, loanNo, sourceBr, updatedUserId);
                    isUpdate = true;
                }
                catch
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "ME90000";
                    isUpdate = false;
                }
                return isUpdate;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.InnerException + ex.Message);
            }
        }
        #endregion
    }
}
