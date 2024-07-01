//----------------------------------------------------------------------
// <copyright file="MNMSVE00032.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KTRHMS</CreatedUser>
// <CreatedDate>11/04/2013</CreatedDate>
// <UpdatedUser>NLKK</UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
//using Ace.Cbs.Cx.Ser.Dao;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer;
using Ace.Windows.Core.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;

namespace Ace.Cbs.Mnm.Sve
{
    /// <summary>
    /// Current Account - Joint
    /// Saving Account - Joint
    /// Fixed Account - Joint
    /// Service
    /// </summary>
    public class MNMSVE00032 : BaseService, IMNMSVE00032
    {
        #region "Properties"
        public ICXSVE00002 CodeGenerator { get; set; }
        public ICXDAO00006 codeCheckerDAO { get; set; }
        public ICXSVE00006 CodeChecker { get; set; }
        public IPFMDAO00028 CledgerDAO { get; set; }
        public IPFMDAO00017 CaofDAO { get; set; }
        public IPFMDAO00001 CustomerIdDAO { get; set; }
        public IPFMDAO00016 SAOFDAO { get; set; }
        public IPFMDAO00021 FAOFDAO { get; set; }
        public IPFMDAO00023 FLedgerDAO { get; set; }
        public IMNMSVE00033 AcTypeCheckingService { get; set; }

        PFMDTO00050 CommonDTO = new PFMDTO00050();
        #endregion

        #region "Main Methods"
                 
        [Transaction(TransactionPropagation.Required)]
        public void SaveJoint(PFMDTO00050 jointDTO)
        {
            string accountCode = string.Empty;

            string accountType = jointDTO.AccountType;
            string subAccountType = jointDTO.SubAccountType;

            jointDTO.AccountType = CXCOM00010.Instance.GetSymbolByAccountType(accountType);
            jointDTO.SubAccountType = CXCOM00010.Instance.GetSymbolByAccountTypeAndSubAccountType(accountType, subAccountType);
            jointDTO.AccountSignature = CXCOM00010.Instance.GetAccountSignature(accountType, subAccountType);

            switch (jointDTO.TransactionStatus)
            {
                case "Current.Joint":
                case "BUSINESSLOAN.Joint": //Added by HWKO (27-Dec-2017)
                case "HIREPURCHASELOAN.Joint": //Added by HWKO (27-Dec-2017)
                case "PERSONALLOAN.Joint": //Added by HWKO (27-Dec-2017)
                case "DEALER.Joint": //Added by HWKO (27-Dec-2017)
                    // Prepare Data
                    PFMORM00028 cc_cledger = this.GetCLedger(jointDTO);
                    IList<PFMORM00017> cc_caofs = this.PutCAOFs(jointDTO);
                   
                    // Save with transaction
                    this.Save_CurrentAccount_Joint(cc_cledger, cc_caofs, jointDTO);

                    break;

                case "Saving.Joint":
                    // Prepare Data
                    PFMORM00028 so_cledger = this.GetCLedger(jointDTO);
                    IList<PFMORM00016> so_saof = this.PutSAOFs(jointDTO);
                    PFMORM00040 so_si = this.GetSavingInterest(jointDTO);
                  
                    // Save with transaction
                     this.Save_SavingAccount_Joint(so_cledger, so_si, so_saof, jointDTO);

                      break;

                case "Fixed.Joint":
                    // Prepare Data
                    PFMORM00023 fc_fledger = this.GetFLedger(jointDTO);
                    IList<PFMORM00021> fc_faof = this.PutFAOFs(jointDTO);
                   

                    // Save with transaction
                     this.Save_FixedAccount_Joint(fc_fledger, fc_faof, jointDTO.FReceipt, jointDTO);

                    break;
            }          
        }
       
        public PFMDTO00067 GetJointAccountInformation(string accountNo,string acsign,string branchCode)
        {
                PFMDTO00067 rawdto = new PFMDTO00067();
                PFMDTO00028   cledgerdto = new PFMDTO00028();
                string message=string.Empty;
                try
                {
                    if (this.AcTypeCheckingService.AccountTypeChecking(accountNo, acsign,branchCode, out message))
                    {
                        string[] actype = acsign.Split(".".ToCharArray());
                        if (actype[0] == "Current" || actype[0] == "BUSINESSLOAN"
                            || actype[0] == "HIREPURCHASELOAN" || actype[0] == "PERSONALLOAN" || actype[0] == "DEALER")//Modified By HWKO (27-Dec-2017)
                        {
                            // Check current account no is already closed or not. and account exist in cledger
                            //if (this.CodeChecker.IsClosedAccountForCLedger(accountNo))
                            //{
                            //    this.ServiceResult.ErrorOccurred = true;
                            //    this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                            //    return null;
                            //}

                            cledgerdto = this.CledgerDAO.SelectACSignByAccountNo(accountNo);
                            
                            if (cledgerdto == null)
                            {
                                this.ServiceResult.ErrorOccurred = true;
                                this.ServiceResult.MessageCode = CXMessage.MV00175;//Account No Not Found
                                rawdto.message = "MV00175";
                                //return null;
                            }
                            if (cledgerdto.CloseDate != null && cledgerdto.CloseDate.ToString() != "" && cledgerdto.CloseDate != default(DateTime))
                            {
                                this.ServiceResult.ErrorOccurred = true;
                                this.ServiceResult.MessageCode = CXMessage.MV00044;     //Account has been Closed
                                rawdto.message = "MV00044";
                                //return null;
                            }
                            if (cledgerdto.CurrencyCode != actype[2])
                            {
                                this.ServiceResult.ErrorOccurred = true;
                                this.ServiceResult.MessageCode = CXMessage.MV00046;     //Invalid Account
                                rawdto.message = "MV00046";
                                //return null;
                            }

                            if (string.IsNullOrEmpty(rawdto.message))
                            {
                                //Modified By HWKO (27-Dec-2017)
                                if (actype[0] == "Current")
                                {
                                    rawdto.CustomerInfo = this.codeCheckerDAO.GetCustomerInformationBySAOForCAOF(accountNo, "C");
                                }
                                else if(actype[0] == "BUSINESSLOAN")
                                {
                                    rawdto.CustomerInfo = this.codeCheckerDAO.GetCustomerInformationBySAOForCAOF(accountNo, "B");
                                }
                                else if(actype[0] == "HIREPURCHASELOAN")
                                {
                                    rawdto.CustomerInfo = this.codeCheckerDAO.GetCustomerInformationBySAOForCAOF(accountNo, "H");
                                }
                                else if(actype[0] == "PERSONALLOAN")
                                {
                                    rawdto.CustomerInfo = this.codeCheckerDAO.GetCustomerInformationBySAOForCAOF(accountNo, "P");
                                }
                                else if(actype[0] == "DEALER")
                                {
                                    rawdto.CustomerInfo = this.codeCheckerDAO.GetCustomerInformationBySAOForCAOF(accountNo, "D");
                                }

                                //rawdto.CustomerInfo = this.codeCheckerDAO.GetCustomerInformationBySAOForCAOF(accountNo, "C");
                                //End Region

                                rawdto.NoOfPersonToSign = (rawdto.CustomerInfo.Count > 1) ? rawdto.CustomerInfo[0].NoOfPersonSign : 0;
                                rawdto.JointType = (rawdto.CustomerInfo.Count > 1) ? rawdto.CustomerInfo[0].JoinType : string.Empty;
                                rawdto.Photo = rawdto.CustomerInfo[0].Photo;
                                rawdto.Signature = rawdto.CustomerInfo[0].Signature;
                                //added by ASDA**
                                rawdto.OpenDate = rawdto.CustomerInfo[0].DATE_TIME;
                                rawdto.CreatedDate = rawdto.CustomerInfo[0].CreatedDate;
                                rawdto.CreatedUserId = rawdto.CustomerInfo[0].CreatedUserId;
                                //end***
                                cledgerdto = this.codeCheckerDAO.GetAccountInfoOfCledgerByAccountNo(accountNo);
                                rawdto.MiniumBalance = cledgerdto.MinimumBalance;
                                rawdto.OverDraftAmount = cledgerdto.OverdraftLimit;
                                rawdto.CBal = cledgerdto.CurrentBal;
                                rawdto.Currency = cledgerdto.CurrencyCode.ToString();
                                rawdto.SourceBr = cledgerdto.SourceBranchCode;
                                
                            }
                            return rawdto;
                        }
                        else if (actype[0] == "Saving")
                        {
                            // Check saving account no is already closed or not. and account exist in cledger
                            //if (this.CodeChecker.IsClosedAccountForCLedger(accountNo))
                            //{
                            //    this.ServiceResult.ErrorOccurred = true;
                            //    this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                            //    return null;
                            //}
                            //else
                            //{

                            cledgerdto = this.CledgerDAO.SelectACSignByAccountNo(accountNo);
                            
                            if (cledgerdto == null)
                            {
                                this.ServiceResult.ErrorOccurred = true;
                                this.ServiceResult.MessageCode = CXMessage.MV00175;    //Account No Not Found
                                rawdto.message = "MV00175";
                                //return null;
                            }
                            if (cledgerdto.CloseDate != null && cledgerdto.CloseDate.ToString() != "" && cledgerdto.CloseDate != default(DateTime))
                            {
                                this.ServiceResult.ErrorOccurred = true;
                                this.ServiceResult.MessageCode = CXMessage.MV00044;     //Account has been Closed
                                rawdto.message = "MV00044";
                                //return rawdto;
                            }
                            if (cledgerdto.CurrencyCode != actype[2])
                            {
                                this.ServiceResult.ErrorOccurred = true;
                                this.ServiceResult.MessageCode = CXMessage.MV00046;     //Invalid Account
                                rawdto.message = "MV00046";
                                //return null;
                            }

                            if (string.IsNullOrEmpty(rawdto.message))
                            {
                                rawdto.CustomerInfo = this.codeCheckerDAO.GetCustomerInformationBySAOForCAOF(accountNo, "S");
                                rawdto.MiniumBalance = cledgerdto.MinimumBalance;
                                rawdto.NoOfPersonToSign = (rawdto.CustomerInfo.Count > 1) ? rawdto.CustomerInfo[0].NoOfPersonSign : 0;
                                rawdto.JointType = (rawdto.CustomerInfo.Count > 1) ? rawdto.CustomerInfo[0].JoinType : string.Empty;
                                rawdto.Photo = rawdto.CustomerInfo[0].Photo;
                                rawdto.Signature = rawdto.CustomerInfo[0].Signature;
                                cledgerdto = this.codeCheckerDAO.GetAccountInfoOfCledgerByAccountNo(accountNo);
                                rawdto.MiniumBalance = cledgerdto.MinimumBalance;
                                rawdto.OverDraftAmount = cledgerdto.OverdraftLimit;
                                rawdto.CBal = cledgerdto.CurrentBal;
                                rawdto.Currency = cledgerdto.CurrencyCode.ToString();
                                rawdto.SourceBr = cledgerdto.SourceBranchCode;
                            }
                            return rawdto;
                        }
                        else if (actype[0] == "Fixed")
                        {
                            PFMDTO00023 fledgerDTO = this.FLedgerDAO.SelectACSignAndCurByAccountNo(accountNo);
                            
                            if (fledgerDTO == null)
                            {
                                this.ServiceResult.ErrorOccurred = true;
                                this.ServiceResult.MessageCode = CXMessage.MV00175;     //Account No Not Found
                                rawdto.message = "MV00175";
                                //return null;
                            }
                            if (fledgerDTO.CurrencyCode != actype[2])
                            {
                                this.ServiceResult.ErrorOccurred = true;
                                this.ServiceResult.MessageCode = CXMessage.MV00046;     //Invalid Account
                                rawdto.message = "MV00046";
                                //return null;
                            }

                            if (string.IsNullOrEmpty(rawdto.message))
                            {                                
                                IList<PFMDTO00021> faof = this.codeCheckerDAO.GetFAOFsByAccountNumber(accountNo);
                                
                                //rawdto.OpenDate = Convert.ToDateTime(faof[0].OpenDate);
                                rawdto.NoOfPersonToSign = faof[0].NoOfPersonSign;
                                rawdto.CustomerInfo = this.codeCheckerDAO.SelectCustomerInformationByFAOF(accountNo);
                                rawdto.CustomerInfo[0].DATE_TIME = Convert.ToDateTime(faof[0].OpenDate);
                                rawdto.CustomerInfo[0].CreatedDate = faof[0].CreatedDate;
                                rawdto.CustomerInfo[0].CreatedUserId = faof[0].CreatedUserId;
                                rawdto.JointType = (rawdto.CustomerInfo.Count > 1) ? faof[0].JoinType : string.Empty;
                                //rawdto.JointType = (rawdto.CustomerInfo.Count > 1) ? rawdto.CustomerInfo[0].JoinType : string.Empty;
                                rawdto.Photo = rawdto.CustomerInfo[0].Photo;
                                rawdto.Signature = rawdto.CustomerInfo[0].Signature;
                                fledgerDTO = this.codeCheckerDAO.GetAccountInfoOfFledgerByAccountNo(accountNo);
                                //rawdto.MiniumBalance = fledgerDTO.;
                                rawdto.Currency = fledgerDTO.CurrencyCode.ToString();                                
                                rawdto.SourceBr = fledgerDTO.SourceBranchCode;
                            }
                            return rawdto;

                        }
                        else
                        {
                            return rawdto = null;
                        }
                    }
                }
                catch (Exception e)
                {
                    if (e.Message == CXMessage.MV00211)
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = CXMessage.MV00211;
                        rawdto.message = message;
                    }
                    else
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = e.Message;
                    }
                }
        
            return rawdto;
         }
      
        #endregion

        #region Convert DTO to ORM

        private PFMORM00028 GetCLedger(PFMDTO00050 entity)
        {
            PFMORM00028 cledger = new PFMORM00028();

            cledger.Date_Time = DateTime.Now;
            cledger.AccountNo = entity.AccountNo;
            cledger.AccountSign = entity.AccountSignature;
            cledger.UserNo = entity.CreatedUserId.ToString();
            cledger.SavingInterestRate = entity.SavingInterestRate;
            cledger.SourceBranchCode = entity.BranchCode;
            cledger.CurrencyCode = entity.CurrencyCode;
            cledger.MinimumBalance = entity.MinBal;
            cledger.Active = true;
            cledger.UpdatedUserId = entity.UpdatedUserId;
            cledger.UpdatedDate = DateTime.Now;

            return cledger;
        }

        private PFMORM00040 GetSavingInterest(PFMDTO00050 entity)
        {
            PFMORM00040 savingInterest = new PFMORM00040();

            savingInterest.DATE_TIME = DateTime.Now;
            savingInterest.AccountSignature = entity.AccountSignature;
            savingInterest.Budget = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode);
            savingInterest.SourceBranchCode = entity.BranchCode;
            savingInterest.CurrencyCode = entity.CurrencyCode;
            savingInterest.Active = true;
            savingInterest.UpdatedUserId = entity.CreatedUserId;
            savingInterest.UpdatedDate = DateTime.Now;

            return savingInterest;
        }

        private PFMORM00023 GetFLedger(PFMDTO00050 entity)
        {
            PFMORM00023 fledger = new PFMORM00023();

            fledger.Date_Time = DateTime.Now;
            fledger.DebitAccountNo = entity.DebitLinkAccount;
            fledger.LinkLimit = entity.DebitLimit;
            fledger.AccountSignature = entity.AccountSignature;
            fledger.UserNo = entity.CreatedUserId.ToString();
            fledger.SourceBranchCode = entity.BranchCode;
            fledger.CurrencyCode = entity.CurrencyCode;
            fledger.Active = true;
            //fledger.UpdatedUserId = entity.CreatedUserId;
            //fledger.UpdatedDate = DateTime.Now;

            return fledger;
        }

        private IList<PFMORM00016> PutSAOFs(PFMDTO00050 entity)
        {
            IList<PFMORM00016> saofs = new List<PFMORM00016>();
            if (entity.CustomerIds != null)
            {
                for (int i = 1; i <= entity.CustomerIds.Count; i++)
                {
                    PFMORM00016 saof = new PFMORM00016();

                    saof.AccountSign = entity.AccountSignature;
                    saof.OPENDATE = entity.AcceptedDate;   //opendate
                    saof.USERNO = entity.CreatedUserId.ToString();
                    saof.Customer_Id = entity.CustomerIds[i - 1];
                    saof.SerialofCustomer = i;
                    saof.NoOfPersonSign = entity.NoOfPersonSign;
                    saof.SourceBranchCode = entity.BranchCode;
                    saof.CurrencyCode = entity.CurrencyCode;
                    saof.JoinType = entity.JoinType;
                    saof.Active = true;
                    saof.CreatedUserId = entity.CreatedUserId;
                    saof.CreatedDate = entity.CreatedDate;
                    saof.UpdatedDate = DateTime.Now;  //Added by ASDA
                    saof.UpdatedUserId = entity.UpdatedUserId;    //Added by ASDA

                    saofs.Add(saof);
                }
            }

            return saofs;
        }

        private IList<PFMORM00017> PutCAOFs(PFMDTO00050 entity)
        {
            IList<PFMORM00017> caofs = new List<PFMORM00017>();
            if (entity.CustomerIds!=null)
            {
                for (int i = 1; i <= entity.CustomerIds.Count; i++)
                {
                    PFMORM00017 caof = new PFMORM00017();

                    caof.NoOfPersonSign = entity.NoOfPersonSign;
                    caof.AccountSign = entity.AccountSignature;
                    caof.OPENDATE = Convert.ToDateTime(entity.AcceptedDate);  //edited by ASDA
                    caof.USERNO = entity.CreatedUserId.ToString();
                    caof.JoinType = entity.JoinType;
                    caof.CustomerID = entity.CustomerIds[i - 1];
                    caof.SerialofCustomer = i;
                    caof.SourceBranchCode = entity.BranchCode;
                    caof.CurrencyCode = entity.CurrencyCode;
                    caof.Active = true;
                    caof.CreatedUserId = entity.CreatedUserId;
                    caof.CreatedDate = entity.CreatedDate;
                    caof.UpdatedUserId = entity.UpdatedUserId;   
                    caof.UpdatedDate = DateTime.Now;

                    caofs.Add(caof);
                }
            }

            return caofs;
        }

        private IList<PFMORM00021> PutFAOFs(PFMDTO00050 entity)
        {
            IList<PFMORM00021> faofs = new List<PFMORM00021>();
            if (entity.CustomerIds != null)
            {
                for (int i = 1; i <= entity.CustomerIds.Count; i++)
                {
                    PFMORM00021 faof = new PFMORM00021();

                    faof.AccountSignature = entity.AccountSignature;
                    faof.OpenDate = entity.AcceptedDate;
                    faof.JoinType = entity.JoinType;
                    faof.NoOfPersonSign = entity.NoOfPersonSign;
                    faof.UserNo = entity.CreatedUserId.ToString();
                    faof.CustomerId = entity.CustomerIds[i - 1];
                    faof.SerialOfCustomer = i;
                    faof.SourceBranchCode = entity.BranchCode;
                    faof.CurrencyCode = entity.CurrencyCode;
                    faof.Active = true;
                    faof.CreatedUserId = entity.CreatedUserId;
                    faof.CreatedDate = entity.CreatedDate;
                    faof.UpdatedUserId = entity.UpdatedUserId;  //Added by ASDA
                    faof.UpdatedDate = DateTime.Now;    //Added by ASDA

                    faofs.Add(faof);
                }
            }

            return faofs;
        }

        #endregion

        #region Helper Methods

        [Transaction(TransactionPropagation.Required)]
        private void Save_CurrentAccount_Joint(PFMORM00028 cledger, IList<PFMORM00017> caofs,  PFMDTO00050 jointEntity)
        {
            cledger.AccountNo = jointEntity.AccountNo;
            this.CaofDAO.DeleteOldData(cledger.AccountNo);

            this.CledgerDAO.UpdateMinBal(cledger.AccountNo, cledger.MinimumBalance, Convert.ToInt32(jointEntity.UpdatedUserId));
            foreach (PFMORM00017 caof in caofs)
            {
                caof.CledgerAccountNo = jointEntity.AccountNo;
                this.CaofDAO.Save(caof);
                this.CaofDAO.UpdateByUpdatedUser(caof.CledgerAccountNo, caof.SourceBranchCode, caof.UpdatedUserId, DateTime.Now);  //Added by ASDA

                bool IsSameCustId = false;
                foreach (string oldCustomerId in jointEntity.OldCustomerIds)
                {
                    if (oldCustomerId == caof.CustomerID)
                    {
                        IsSameCustId = true;
                        break;
                    }
                }
                if(!IsSameCustId)
                    this.CustomerIdDAO.UpdateOpenAccount(caof.CustomerID, Convert.ToInt32(jointEntity.UpdatedUserId));//Update Customer's OpenAc +1
            }

            foreach (string oldCustomer in jointEntity.OldCustomerIds)
            {
                bool IsSameCustId = false;
                foreach (PFMORM00017 caof in caofs)
                {
                    if (oldCustomer == caof.CustomerID)
                    {
                        IsSameCustId = true;
                        break;
                    }
                }
                if(!IsSameCustId)
                    this.CustomerIdDAO.UpdateOpenAccount_Minus(oldCustomer, Convert.ToInt32(jointEntity.UpdatedUserId));//Update Customer's OpenAc -1
            }
        }

        [Transaction(TransactionPropagation.Required)]
        private void Save_SavingAccount_Joint(PFMORM00028 cledger, PFMORM00040 si, IList<PFMORM00016> saofs, PFMDTO00050 jointEntity)
        {
            cledger.AccountNo = jointEntity.AccountNo;           
            this.SAOFDAO.DeleteOldData(cledger.AccountNo);
            foreach (PFMORM00016 saof in saofs)
            {
                //saof.UpdatedUserId = jointEntity.UpdatedUserId;
                //saof.UpdatedDate = DateTime.Now;
                saof.CledgerAccountNo = jointEntity.AccountNo;
                this.SAOFDAO.Save(saof);
                this.SAOFDAO.UpdateByUpdatedUser(saof.CledgerAccountNo,jointEntity.BranchCode, jointEntity.UpdatedUserId,DateTime.Now);  //Added by ASDA

                bool IsSameCustId = false;
                foreach (string oldCustomerId in jointEntity.OldCustomerIds)
                {
                    if (oldCustomerId == saof.Customer_Id)
                    {
                        IsSameCustId = true;
                        break;
                    }
                }
                if (!IsSameCustId)
                    this.CustomerIdDAO.UpdateOpenAccount(saof.Customer_Id, Convert.ToInt32(jointEntity.UpdatedUserId));
            }

            foreach (string oldCustomer in jointEntity.OldCustomerIds)
            {
                bool IsSameCustId = false;
                foreach (PFMORM00016 saof in saofs)
                {
                    if (oldCustomer == saof.Customer_Id)
                    {
                        IsSameCustId = true;
                        break;
                    }
                }
                if (!IsSameCustId)
                    this.CustomerIdDAO.UpdateOpenAccount_Minus(oldCustomer, Convert.ToInt32(jointEntity.UpdatedUserId));
            }

            cledger.AccountNo = jointEntity.AccountNo;
            this.CledgerDAO.UpdateMinBal(cledger.AccountNo, cledger.MinimumBalance, Convert.ToInt32(jointEntity.UpdatedUserId));
           
       }

        [Transaction(TransactionPropagation.Required)]
        private void Save_FixedAccount_Joint(PFMORM00023 fledger, IList<PFMORM00021> faofs, PFMDTO00032 freceipt, PFMDTO00050 jointEntity)
        {
            this.FAOFDAO.DeleteOldData(jointEntity.AccountNo);    //Delete Old Data From Faof
            foreach (PFMORM00021 faof in faofs)
            {
                faof.FledgerAccountNo = jointEntity.AccountNo;
                //this.FAOFDAO.Update(faof);
                this.FAOFDAO.Save(faof);
                this.FAOFDAO.UpdateByUpdatedUser(faof.FledgerAccountNo, jointEntity.BranchCode, jointEntity.UpdatedUserId, DateTime.Now);  //Added by ASDA

                bool IsSameCustId = false;
                foreach (string oldCustomerId in jointEntity.OldCustomerIds)
                {
                    if (oldCustomerId == faof.CustomerId)
                    {
                        IsSameCustId = true;
                        break;
                    }
                }
                if (!IsSameCustId)
                    this.CustomerIdDAO.UpdateOpenAccount(faof.CustomerId, Convert.ToInt32(jointEntity.UpdatedUserId)); //Update Customer's OpenAc +1
            }

            foreach (string oldCustomer in jointEntity.OldCustomerIds)
            {
                bool IsSameCustId = false;
                foreach (PFMORM00021 faof in faofs)
                {
                    if (oldCustomer == faof.CustomerId)
                    {
                        IsSameCustId = true;
                        break;
                    }
                }
                if (!IsSameCustId)
                    this.CustomerIdDAO.UpdateOpenAccount_Minus(oldCustomer, Convert.ToInt32(jointEntity.UpdatedUserId)); //Update Customer's OpenAc -1
            }
           
        }
              
        #endregion
    }
}