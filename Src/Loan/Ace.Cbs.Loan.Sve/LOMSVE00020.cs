//----------------------------------------------------------------------
// <copyright file="LOMSVE00020" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo</CreatedUser>
// <CreatedDate>2015-02-03</CreatedDate>
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
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Sve
{
    public class LOMSVE00020 : BaseService, ILOMSVE00020
    {
        #region "Properties"
        private IMNMDAO00017 LIDAO { get; set; }
        private ITLMDAO00018 LoansDAO { get; set; }
        #endregion

        #region "Methods"
        public TLMDTO00018 isValidLoanNo(string loanNo, string sourceBr)
        {
            TLMDTO00018 loanDTO = new TLMDTO00018();
            try
            {
                bool isValidLno;
               // LOMDTO00021 LiDTO = LIDAO.GetLiInfo(loanNo, sourceBr).First();
                LOMDTO00021 LiDTO = new LOMDTO00021();

                IList<LOMDTO00021> LIList = LIDAO.GetLiInfo(loanNo, sourceBr);
                if (LIList.Count > 0)
                {
                    LiDTO = LIList.First();
                }
                else
                {
                    LiDTO = null;
                }
               
             
             
                
                isValidLno = LiDTO != null ? true : false;
                if (isValidLno)
                {
                    loanDTO = LoansDAO.GetLoansAccountInformation(loanNo, sourceBr);
                    if (loanDTO != null)
                    {
                        if (loanDTO.AType != "LOANS")
                        {
                            this.ServiceResult.ErrorOccurred = true;
                            ServiceResult.MessageCode = "MV90085";//Loan Account Type Only.                          
                        }
                        else if (loanDTO.CloseDate != null)
                        {
                            this.ServiceResult.ErrorOccurred = true;
                            ServiceResult.MessageCode = "MV90086";//Loan Account has been Closed. 
                        }
                        else
                        {
                            loanDTO.FirstSAmount = LiDTO.InterestAmount;
                        }
                    }
                    else
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        ServiceResult.MessageCode = "MV90055";//Loan No is Valid                     
                    }                   
                }
                else
                {
                    this.ServiceResult.ErrorOccurred = true;
                     
                     ServiceResult.MessageCode = "MI90067";//Loans No. not found in Interest File.                   
                   // ServiceResult.MessageCode = "MV90100";  //Invalid Account No {0} for Branch {1}.                      
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException+ex.Message);
            }           
            return loanDTO;
        }

         [Transaction(TransactionPropagation.Required)]
        public bool Update(string loanNo, string sourceBr, decimal quarterint, int updatedUserId)
        {
            try
            {
                bool isUpdate = false;
                try
                {
                    this.LIDAO.UpdateLoansInterest(loanNo, sourceBr, quarterint, updatedUserId);
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
