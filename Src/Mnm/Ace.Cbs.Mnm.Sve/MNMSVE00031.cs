using System;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.Core.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Mnm.Ctr.Sve;
using System.Collections.Generic;
using Ace.Cbs.Mnm.Ctr.Dao;
//using Ace.Cbs.Pfm.Dao;
using Ace.Cbs.Mnm.Ctr.Sve;

namespace Ace.Cbs.Mnm.Sve
{
    /// <summary>
    /// Service
    /// Current Account - Individual
    /// Current Account - PrivateFirm
    /// Saving Account - Individual
    /// Saving Account - Minor
    /// Fixed Account - Individual
    /// Fixed Account - Minor
    /// </summary>
    public class MNMSVE00031 : BaseService, IMNMSVE00031
    {
        #region Properties
        public ICXSVE00002 CodeGenerator { get; set; }
        public IPFMDAO00028 CledgerDAO { get; set; }
        public IPFMDAO00017 CaofDAO { get; set; }       
        public IPFMDAO00033 BalanceDAO { get; set; }
        public IPFMDAO00001 CustomerIdDAO { get; set; }        
        public IPFMDAO00016 SAOFDAO { get; set; }
        public IPFMDAO00021 FAOFDAO { get; set; }       
        public IPFMDAO00023 FLedgerDAO { get; set; }
        public IMNMDAO00031 CommonDAO { get; set; }       
        public ICXDAO00006 CheckAccountDAO { get; set; }    //for validate check digit
        public PFMDTO00001 CommonDto=new PFMDTO00001();
        public IMNMSVE00033 AcTypeCheckingService { get; set; }
        

        #endregion

        #region Main Method
        [Transaction(TransactionPropagation.Required)]
        public void SaveIndividual(PFMDTO00001 individualDTO)
        {
            switch (individualDTO.TransactionStatus)
            {
                case "Current.Individual":
                case "BUSINESSLOAN.Individual": //Added by HWKO (26-Dec-2017)
                case "PERSONALLOAN.Individual": //Added by HWKO (26-Dec-2017)
                case "HIREPURCHASELOAN.Individual": //Added by HWKO (26-Dec-2017)
                case "DEALER.Individual": //Added by HWKO (26-Dec-2017)
                case "Current.PrivateFirm":
                    // Prepare Data
                    PFMORM00028 cc_cledger = this.GetCLedger(individualDTO);
                    PFMORM00017 cc_caofs = this.GetCAOF(individualDTO);
                    
                    // Save with transaction
                    this.Save_CurrentAccount(cc_cledger,cc_caofs,individualDTO);

                    break;

                case "Saving.Individual":
                case "Saving.Minor":
                    // Prepare Data
                    PFMORM00028 si_cledger = this.GetCLedger(individualDTO);                   
                    PFMORM00016 si_saof = this.GetSAOF(individualDTO);
                   

                    // Save with transaction
                   this.Save_SavingAccount(si_cledger, si_saof, individualDTO);

                    break;

                case "Fixed.Individual":
                case "Fixed.Minor":
                    // Prepare Data
                    PFMORM00023 fi_fledger = this.GetFLedger(individualDTO);
                    PFMORM00021 fi_faof = this.GetFAOF(individualDTO);
                   
                    // Save with transaction
                    this.Save_FixedAccount(fi_fledger, fi_faof, individualDTO);

                    break;

                                
            }            
          
        }
        #endregion

        #region Helper Methods


        public PFMDTO00001 CheckingAccount(string accountNo,string accountType,string branchCode)
        {
            #region Old Coding

            //if (acSign[0] == 'C' || acSign[0] == 'S')       //Current or Saving Account
            //{
            //    PFMDTO00028 cledgerAccount = this.CledgerDAO.SelectACSignByAccountNo(accountNo);
                               

            //    if (cledgerAccount == null)         // Data Not Exist
            //    {
            //        this.ServiceResult.ErrorOccurred = true;
            //        this.ServiceResult.MessageCode = "MV00175"; //Invalid Account
            //    }
            //    else     // Data Exist
            //    {
                    
            //        if (cledgerAccount.CloseDate != null && cledgerAccount.CloseDate.ToString() != "" && cledgerAccount.CloseDate.ToString() != "01/01/0001 12:00:00 AM")
            //        {
            //            this.ServiceResult.ErrorOccurred = true;
            //            this.ServiceResult.MessageCode = "MV00044";     //Account has been Closed
            //        }
            //        else
            //        {                 
                                             
            //            if (cledgerAccount.AccountSign[0] != acSign[0])
            //            {
            //                this.ServiceResult.ErrorOccurred = true;
            //                this.ServiceResult.MessageCode = acSign[0] == 'C' ? "MV00000" : "MV00000";  //  Current Account Only || Saving Account Only
            //            }
            //            else
            //            {
            //                if (acSign[0] == 'C')
            //                {
            //                    if (cledgerAccount.AccountSign[1] != acSign[1])
            //                    {
            //                        this.ServiceResult.ErrorOccurred = true;
            //                        switch (acSign[1])
            //                        {
            //                            case 'I': this.ServiceResult.MessageCode = "MV00000"; break;    //Individual  Account Only
            //                            case 'S': this.ServiceResult.MessageCode = "MV00000"; break;    //Private Firm Account Only
                                        
            //                        }
            //                    }
            //                    else
            //                    {
            //                        CommonDto = CommonDAO.GetCAOFsInfoByAccountNumber(accountNo);//Select From Caof
            //                        this.CommonDto.MinimumBalance = cledgerAccount.MinimumBalance;
            //                        this.CommonDto.CurrentBal = cledgerAccount.CurrentBal;
            //                        this.CommonDto.OVDLimit = cledgerAccount.OverdraftLimit;                  
                                                                      
            //                    }
            //                }
            //                else if (acSign[0] == 'S')
            //                {
            //                    if (cledgerAccount.AccountSign[1] != acSign[1])
            //                    {
            //                        this.ServiceResult.ErrorOccurred = true;
            //                        switch (acSign[1])
            //                        {
            //                            case 'I': this.ServiceResult.MessageCode = "MV00000"; break;    //Individual  Account Only
            //                            case 'M': this.ServiceResult.MessageCode = "MV00000"; break;    //Minor Account Only

            //                        }
            //                    }
            //                    else
            //                    {
            //                        CommonDto = CommonDAO.GetSAOFInfoByAccountNumber(accountNo); //Select From Saof    
            //                        this.CommonDto.MinimumBalance = cledgerAccount.MinimumBalance;
            //                        this.CommonDto.CurrentBal = cledgerAccount.CurrentBal;
            //                        this.CommonDto.OVDLimit = cledgerAccount.OverdraftLimit;
                    
                                                                      
                                    
            //                    }

            //                } //Saving Organization Brace
            //            } //Sub Account Type Brace
            //        } //Not Closed Account Brace
            //    } //Data Exist Brace
            //} //Current or Saving Account Brace

            //else            //Fixed Account ('FC')
            //{
            //    PFMDTO00023 fledgerAccount = this.FLedgerDAO.SelectACSignAndCurByAccountNo(accountNo);
            //    if (fledgerAccount == null)     //Data Not Exist
            //    {
            //        this.ServiceResult.ErrorOccurred = true;
            //        this.ServiceResult.MessageCode = "MV00175";     //Invalid Account
            //    }
            //    else //Data Exist
            //    {
            //        if (fledgerAccount.AccountSignature[1] != acSign[1])
            //        {
            //            this.ServiceResult.ErrorOccurred = true;
            //            switch (acSign[1])
            //            {
            //                case 'I': this.ServiceResult.MessageCode = "MV00000"; break;    //Individual  Account Only
            //                case 'M': this.ServiceResult.MessageCode = "MV00000"; break;    //Minor Account Only

            //            }    
            //        }
            //        else
            //        {
            //            CommonDto = CommonDAO.GetFAOFInfoByAccountNumber(accountNo);//Select From Faof                        
                       
            //        }
            //    }
            //}

            #endregion

            string[] acType = accountType.Split(".".ToCharArray());
            string message = string.Empty;

            try
            {
                if(this.AcTypeCheckingService.AccountTypeChecking(accountNo,accountType, branchCode, out message))
                {
                    if(acType[0]!="Fixed")  //Current or Saving Account
                    {
                        PFMDTO00028 cledgerAccount = this.CledgerDAO.SelectACSignByAccountNo(accountNo);
                        
                        if (cledgerAccount == null)
                        {
                            this.ServiceResult.ErrorOccurred = true;
                            this.ServiceResult.MessageCode = CXMessage.MV00175;    //Account No Not Found
                            return null;
                        }
                        if (cledgerAccount.CloseDate != null && cledgerAccount.CloseDate.ToString() != "" && cledgerAccount.CloseDate != default(DateTime))
                        {
                            this.ServiceResult.ErrorOccurred = true;
                            this.ServiceResult.MessageCode = CXMessage.MV00044;     //Account has been Closed
                            return null;
                        }
                        if (cledgerAccount.CurrencyCode != acType[2])
                        {
                            this.ServiceResult.ErrorOccurred = true;
                            this.ServiceResult.MessageCode = CXMessage.MV00046;     //Invalid Account
                            return null;
                        }
                        if (acType[0] == "Current" || acType[0] == "BUSINESSLOAN" || acType[0] == "PERSONALLOAN" || acType[0] == "HIREPURCHASELOAN" || acType[0] == "DEALER")//Modified by HWKO (26-Dec-2017)     //Current Account
                        {
                            CommonDto = CommonDAO.GetCAOFsInfoByAccountNumber(accountNo);//Select From Caof
                            this.CommonDto.MinimumBalance = cledgerAccount.MinimumBalance;
                            this.CommonDto.CurrentBal = cledgerAccount.CurrentBal;
                            this.CommonDto.OVDLimit = cledgerAccount.OverdraftLimit;
                        }
                        else        //Saving Account
                        {
                            CommonDto = CommonDAO.GetSAOFInfoByAccountNumber(accountNo); //Select From Saof    
                            this.CommonDto.MinimumBalance = cledgerAccount.MinimumBalance;
                            this.CommonDto.CurrentBal = cledgerAccount.CurrentBal;
                            this.CommonDto.OVDLimit = cledgerAccount.OverdraftLimit;
                        }
                        this.CommonDto.SourceBranch = cledgerAccount.SourceBranchCode;
                    }
                    else    //Fixed Account
                    {
                        PFMDTO00023 fledgerAccount = this.FLedgerDAO.SelectACSignAndCurByAccountNo(accountNo);
                        if (fledgerAccount == null)     //Data Not Exist
                        {
                            this.ServiceResult.ErrorOccurred = true;
                            this.ServiceResult.MessageCode = CXMessage.MV00175;     //Invalid Account
                        }
                        if (fledgerAccount.CurrencyCode != acType[2])
                        {
                            this.ServiceResult.ErrorOccurred = true;
                            this.ServiceResult.MessageCode = CXMessage.MV00046;     //Invalid Account
                            return null;
                        }

                        CommonDto = CommonDAO.GetFAOFInfoByAccountNumber(accountNo);//Select From Faof
                        this.CommonDto.SourceBranch = fledgerAccount.SourceBranchCode;
                    }
                }
            }
            catch (Exception e)
            {
                if (e.Message == CXMessage.MV00211)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV00211;
                    CommonDto = new PFMDTO00001();
                    CommonDto.Message = message;
                }
                else
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = e.Message;
                }
            }
            return this.CommonDto;
        }

       
        [Transaction(TransactionPropagation.Required)]
        private void Save_CurrentAccount(PFMORM00028 cledger, PFMORM00017 caof, PFMDTO00001 companyEntity)
        {
           
                this.CustomerIdDAO.UpdateOpenAccount_Minus(companyEntity.OldCustomerIds, companyEntity.CreatedUserId);   //Update Customer's OpenAc -1                    
                
                this.CustomerIdDAO.UpdateOpenAccount(companyEntity.CustomerId, companyEntity.CreatedUserId); //Update Customer's OpenAc +1            

                this.CaofDAO.UpdateCustomerIDByAccountNo(companyEntity.AccountNo, companyEntity.CustomerId,companyEntity.NameofFirm,companyEntity.Business, Convert.ToInt32(companyEntity.CreatedUserId), Convert.ToDateTime(companyEntity.UpdatedDate));  //Update Customer'ID BY Account No
                                  
                this.CledgerDAO.UpdateMinBal(companyEntity.AccountNo,Convert.ToDecimal(companyEntity.MinimumBalance),Convert.ToInt32(companyEntity.UpdatedUserId));
        
                     
        }


        [Transaction(TransactionPropagation.Required)]
        private void Save_SavingAccount(PFMORM00028 cledger,PFMORM00016 saof,PFMDTO00001 companyEntity)
        {
            
            this.CustomerIdDAO.UpdateOpenAccount_Minus(companyEntity.OldCustomerIds, companyEntity.CreatedUserId);   //Update Customer's OpenAc -1

            this.CustomerIdDAO.UpdateOpenAccount(companyEntity.CustomerId, companyEntity.CreatedUserId); //Update Customer's OpenAc +1

            this.SAOFDAO.UpdateCustomerIDByAccountNo(companyEntity.AccountNo, companyEntity.CustomerId, Convert.ToInt32(companyEntity.UpdatedUserId), Convert.ToDateTime(companyEntity.UpdatedDate));  //Update Customer'ID BY Account No

            this.CledgerDAO.UpdateMinBal(companyEntity.AccountNo, Convert.ToDecimal(companyEntity.MinimumBalance), Convert.ToInt32(companyEntity.UpdatedUserId));
        
        }


        [Transaction(TransactionPropagation.Required)]
        private void Save_FixedAccount(PFMORM00023 fledger, PFMORM00021 saof, PFMDTO00001 companyEntity)
        {
            this.CustomerIdDAO.UpdateOpenAccount_Minus(companyEntity.OldCustomerIds, companyEntity.CreatedUserId);   //Update Customer's OpenAc -1

            this.CustomerIdDAO.UpdateOpenAccount(companyEntity.CustomerId, companyEntity.CreatedUserId); //Update Customer's OpenAc +1

            this.FAOFDAO.UpdateCustomerIDByAccountNo(companyEntity.AccountNo, companyEntity.CustomerId, Convert.ToInt32(companyEntity.UpdatedUserId),DateTime.Now);  //Update Customer'ID BY Account No
           
        
        }


        #endregion

        #region Convert DTO to ORM

        private PFMORM00028 GetCLedger(PFMDTO00001 entity)
        {
            PFMORM00028 cledger = new PFMORM00028();

            cledger.AccountNo = entity.AccountNo;
            cledger.MinimumBalance = entity.MinimumBalance;
            //cledger.UpdatedUserId = entity.CreatedUserId;
            //cledger.UpdatedDate = DateTime.Now;

            return cledger;
        }


        private PFMORM00023 GetFLedger(PFMDTO00001 entity)
        {
            PFMORM00023 fledger = new PFMORM00023();

            fledger.Date_Time = DateTime.Now;
            fledger.AccountSignature = entity.AccountSignature;
            fledger.UserNo = entity.CreatedUserId.ToString();
            fledger.SourceBranchCode = entity.BranchCode;
            fledger.CurrencyCode = entity.CurrencyCode;
            fledger.Active = true;
            //fledger.UpdatedUserId = entity.CreatedUserId;
            //fledger.UpdatedDate = DateTime.Now;
            

            return fledger;
        }

        private PFMORM00016 GetSAOF(PFMDTO00001 entity)
        {
            PFMORM00016 individualDTO = new PFMORM00016();
            
            individualDTO.DateofBirth = entity.DateOfBirth;          
            individualDTO.OPENDATE = DateTime.Now;
            individualDTO.Customer_Id = entity.CustomerId;
            individualDTO.AccountSign = entity.AccountSignature;
            individualDTO.NoOfPersonSign = 0;
            individualDTO.SerialofCustomer = 0;
            individualDTO.SourceBranchCode = entity.BranchCode;
            individualDTO.CurrencyCode = entity.CurrencyCode;
            individualDTO.Active = true;
            individualDTO.UpdatedUserId = entity.CreatedUserId;
            individualDTO.UpdatedDate = DateTime.Now;

            return individualDTO;
        }

     
        private PFMORM00017 GetCAOF(PFMDTO00001 entity)
        {
            PFMORM00017 individualDTO = new PFMORM00017();
            individualDTO.Name = entity.NameofFirm;
            individualDTO.Business = entity.Business;
            individualDTO.AccountSign = entity.AccountSignature;
            individualDTO.OPENDATE = DateTime.Now;
            individualDTO.CustomerID = entity.CustomerId;
            individualDTO.SerialofCustomer = 0;
            individualDTO.NoOfPersonSign = 0;
            individualDTO.JoinType = "0";
            individualDTO.SourceBranchCode = entity.BranchCode;
            individualDTO.CurrencyCode = entity.CurrencyCode;
            individualDTO.Active = true;
            individualDTO.UpdatedUserId = entity.CreatedUserId;
            individualDTO.UpdatedDate = DateTime.Now;

            return individualDTO;
        }

        private PFMORM00021 GetFAOF(PFMDTO00001 entity)
        {
            PFMORM00021 individualDTO = new PFMORM00021();

            individualDTO.AccountSignature = entity.AccountSignature;
            individualDTO.OpenDate = DateTime.Now;
            individualDTO.CustomerId = entity.CustomerId;
            individualDTO.SourceBranchCode = entity.BranchCode;
            individualDTO.CurrencyCode = entity.CurrencyCode;
            individualDTO.Active = true;
            individualDTO.UpdatedUserId = entity.CreatedUserId;
            individualDTO.UpdatedDate = DateTime.Now;

            return individualDTO;
        }


      

        #endregion
    }
}
