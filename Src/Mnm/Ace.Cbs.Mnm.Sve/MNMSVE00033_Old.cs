//----------------------------------------------------------------------
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>11/01/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Mnm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.Core.Service;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
//using Ace.Cbs.Mnm.Dmd.DTO;
using NHibernate;
using Spring.Data.NHibernate.Support;
using Ace.Windows.Admin.DataModel;
using System.Linq;


namespace Ace.Cbs.Mnm.Sve
{
    public class MNMSVE00033:BaseService,IMNMSVE00033
    {
        #region Properties

        public ICXSVE00002 CodeGenerator { get; set; }
        public IPFMDAO00028 CledgerDAO { get; set; }
        public IPFMDAO00017 CaofDAO { get; set; }
        public IPFMDAO00001 CustomerIdDAO { get; set; }
        public IPFMDAO00016 SAOFDAO { get; set; }
        public IPFMDAO00021 FAOFDAO { get; set; }
        public IPFMDAO00023 FLedgerDAO { get; set; }
        public ICXDAO00006 CommonDAO { get; set; }     //For Caof,Saof,Faof
        public ICXDAO00002 FormatDao { get; set; }
        public IPFMDAO00015 AccountTypeDAO { get; set; }
        public IPFMDAO00022 SubAccountTypeDAO { get; set; }

        #endregion

        #region private variables

        IList<PFMDTO00017> caofDatas;
        IList<PFMDTO00016> saofDatas;
        IList<PFMDTO00021> faofDatas;
        PFMDTO00028 cledgerAccount;
        PFMDTO00023 fledgerAccount;
        PFMDTO00050 CommonDTO;

        #endregion

        #region Main Method

        public PFMDTO00050 CheckingAccount(string accountNo, string accountType,string branchCode)
        {
            #region Old Coding

            //if (acSign[0] == 'C' || acSign[0] == 'S')       //Current or Saving Account
            //{
            //    cledgerAccount = this.CledgerDAO.SelectACSignByAccountNo(accountNo);
                

            //    if (cledgerAccount == null)         // Data Not Exist
            //    {
            //        fledgerAccount = this.FLedgerDAO.SelectACSignAndCurByAccountNo(accountNo);
            //        if (fledgerAccount == null)
            //        {
            //            this.ServiceResult.ErrorOccurred = true;
            //            this.ServiceResult.MessageCode = "MV00175";    //Account No Not Found
            //            return null;
            //        }
            //        else
            //        {
            //            this.ServiceResult.ErrorOccurred = true;
            //            this.ServiceResult.MessageCode = acSign[0] == 'C' ? "MV90020" : "MV90021";  //  Current Account Only || Saving Account Only
            //            return null;
            //        }

            //    }
            //    else     // Data Exist
            //    {
            //        if (cledgerAccount.CloseDate != null && cledgerAccount.CloseDate.ToString() != "" && cledgerAccount.CloseDate.ToString() != "01/01/0001 12:00:00 AM")
            //        {
            //            this.ServiceResult.ErrorOccurred = true;
            //            this.ServiceResult.MessageCode = "MV00044";     //Account has been Closed
            //            return null;
            //        }
            //        else
            //        {
            //            if (cledgerAccount.AccountSign[0] != acSign[0])
            //            {
            //                this.ServiceResult.ErrorOccurred = true;
            //                this.ServiceResult.MessageCode = acSign[0] == 'C' ? "MV90020" : "MV90021";  //  Current Account Only || Saving Account Only
            //                return null;
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
            //                            case 'C': this.ServiceResult.MessageCode = "MV90023"; break;    //Company Account Only
            //                            case 'P': this.ServiceResult.MessageCode = "MV90024"; break;    //Partnership Account Only
            //                            case 'A': this.ServiceResult.MessageCode = "MV90025"; break;    //Association Account Only
            //                        }
            //                        return null;
            //                    }
            //                    else
            //                    {
            //                        caofDatas = CommonDAO.GetCAOFsByAccountNumber(accountNo); //Select From Caof
            //                        this.CollectCaofInformation(caofDatas);     // Filter With CustomerId is null
            //                        this.CommonDTO.CustomerDTOs = CommonDAO.GetCustomerInformationBySAOForCAOF(accountNo, "C");   //Select From CustId
            //                        this.CommonDTO.MinBal = cledgerAccount.MinimumBalance;
            //                    }
            //                }
            //                else if (acSign[0] == 'S')
            //                {
            //                    if (cledgerAccount.AccountSign[1] != acSign[1])
            //                    {
            //                        this.ServiceResult.ErrorOccurred = true;
            //                        if (acSign[1] == 'O')
            //                            this.ServiceResult.MessageCode = "MV90026";     //Organization Account Only
            //                        return null;
            //                    }
            //                    else
            //                    {
            //                        saofDatas = CommonDAO.GetSAOFsByAccountNumber(accountNo); //Select From Saof
            //                        this.CollectSaofInformation(saofDatas);     // Filter With CustomerId is null
            //                        this.CommonDTO.CustomerDTOs = CommonDAO.GetCustomerInformationBySAOForCAOF(accountNo, "S"); //Select from CustId
            //                        this.CommonDTO.MinBal = cledgerAccount.MinimumBalance;
            //                    }

            //                } //Saving Organization Brace
            //            } //Sub Account Type Brace
            //        } //Not Closed Account Brace
            //    } //Data Exist Brace
            //} //Current or Saving Account Brace

            //else            //Fixed Account ('FC')
            //{

            //    fledgerAccount = this.FLedgerDAO.SelectACSignAndCurByAccountNo(accountNo);

            //    if (fledgerAccount == null)     //Data Not Exist
            //    {
            //        cledgerAccount = this.CledgerDAO.SelectACSignByAccountNo(accountNo);
            //        if (cledgerAccount == null)
            //        {
            //            this.ServiceResult.ErrorOccurred = true;
            //            this.ServiceResult.MessageCode = "MV00175";     //Account No Not Found
            //            return null;
            //        }
            //        else
            //        {
            //            this.ServiceResult.ErrorOccurred = true;
            //            this.ServiceResult.MessageCode = "MV90022";     //Fixed Deposit Account Only
            //            return null;
            //        }
            //    }
            //    else //Data Exist
            //    {
            //        if (fledgerAccount.AccountSignature[1] != 'C')
            //        {
            //            this.ServiceResult.ErrorOccurred = true;
            //            this.ServiceResult.MessageCode = "MV90023";     //Company Account Only
            //            return null;
            //        }
            //        else
            //        {
            //            faofDatas = CommonDAO.GetFAOFsByAccountNumber(accountNo);   //Select From Faof
            //            this.CollectFaofInformation(faofDatas); // Filter With CustomerId is null
            //            this.CommonDTO.CustomerDTOs = CommonDAO.SelectCustomerInformationByFAOF(accountNo);     //Select From CustId
            //        }
            //    }
            //}
            #endregion

            string[] acType = accountType.Split(".".ToCharArray());
            string message = string.Empty;
            try
            {
                if (this.AccountTypeChecking(accountNo, accountType, branchCode, out message))
                {
                    if (acType[0] != "Fixed")   //Current or Saving Account
                    {
                        cledgerAccount = cledgerAccount == null ? this.CledgerDAO.SelectACSignByAccountNo(accountNo) : cledgerAccount;
                        
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

                        if (acType[0] == "Current" || acType[0] == "BUSINESSLOAN" || acType[0] == "HIREPURCHASELOAN"
                            || acType[0] == "PERSONALLOAN" || acType[0] == "DEALER")   //Current Account //Added by HWKO (28-Dec-2017)
                        {
                            caofDatas = CommonDAO.GetCAOFsByAccountNumber(accountNo); //Select From Caof
                            this.CollectCaofInformation(caofDatas);     // Filter With CustomerId is null
                            this.CommonDTO.CustomerDTOs = CommonDAO.GetCustomerInformationBySAOForCAOF(accountNo, "C");   //Select From CustId
                            this.CommonDTO.MinBal = cledgerAccount.MinimumBalance;
                            this.CommonDTO.CurrentBal = cledgerAccount.CurrentBal;
                            this.CommonDTO.OvdLimit = cledgerAccount.OverdraftLimit;
                            this.CommonDTO.BranchCode = cledgerAccount.SourceBranchCode;
                            this.CommonDTO.Message = message;
                        }
                        else        //Saving Account
                        {
                            saofDatas = CommonDAO.GetSAOFsByAccountNumber(accountNo); //Select From Saof
                            this.CollectSaofInformation(saofDatas);     // Filter With CustomerId is null
                            this.CommonDTO.CustomerDTOs = CommonDAO.GetCustomerInformationBySAOForCAOF(accountNo, "S"); //Select from CustId
                            this.CommonDTO.MinBal = cledgerAccount.MinimumBalance;
                            this.CommonDTO.CurrentBal = cledgerAccount.CurrentBal;
                            this.CommonDTO.OvdLimit = cledgerAccount.OverdraftLimit;
                            this.CommonDTO.BranchCode = cledgerAccount.SourceBranchCode;
                            this.CommonDTO.Message = message;
                        }
                    }

                    else    //Fixed Deposit Account
                    {
                        fledgerAccount = fledgerAccount == null ? this.FLedgerDAO.SelectACSignAndCurByAccountNo(accountNo) : fledgerAccount;
                        
                        if (fledgerAccount == null)
                        {
                            this.ServiceResult.ErrorOccurred = true;
                            this.ServiceResult.MessageCode = CXMessage.MV00175;     //Account No Not Found
                            return null;
                        }
                        if (fledgerAccount.CurrencyCode != acType[2])
                        {
                            this.ServiceResult.ErrorOccurred = true;
                            this.ServiceResult.MessageCode = CXMessage.MV00046;     //Invalid Account
                            return null;
                        }

                        faofDatas = CommonDAO.GetFAOFsByAccountNumber(accountNo);   //Select From Faof
                        this.CollectFaofInformation(faofDatas); // Filter With CustomerId is null
                        this.CommonDTO.CustomerDTOs = CommonDAO.SelectCustomerInformationByFAOF(accountNo);     //Select From CustId                        
                        this.CommonDTO.BranchCode = fledgerAccount.SourceBranchCode;
                        this.CommonDTO.Message = message;
                    }
                }
            }
            catch(Exception e)
            {
                if (e.Message == CXMessage.MV00211)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV00211;
                    CommonDTO = new PFMDTO00050();
                    CommonDTO.Message = message;
                }
                else
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = e.Message;
                }
            }

            return CommonDTO;
        }

        [Transaction(TransactionPropagation.Required)]
        public void SaveCompany(PFMDTO00050 companyDTO)
        {
            string accountCode = string.Empty;

            string accountType = companyDTO.AccountType;
            string subAccountType = companyDTO.SubAccountType;

            companyDTO.AccountType = CXCOM00010.Instance.GetSymbolByAccountType(accountType);
            companyDTO.SubAccountType = CXCOM00010.Instance.GetSymbolByAccountTypeAndSubAccountType(accountType, subAccountType);
            companyDTO.AccountSignature = CXCOM00010.Instance.GetAccountSignature(accountType, subAccountType);

            switch (companyDTO.TransactionStatus)
            {
                case "Current.Company":
                case "BUSINESSLOAN.Company": //Added by HWKO (28-Dec-2017)
                case "HIREPURCHASELOAN.Company": //Added by HWKO (28-Dec-2017)
                case "PERSONALLOAN.Company": //Added by HWKO (28-Dec-2017)
                case "DEALER.Company": //Added by HWKO (28-Dec-2017)
                    // Prepare Data
                    PFMORM00028 cc_cledger = this.GetCLedger(companyDTO);
                    IList<PFMORM00017> cc_caofs = this.GetCAOFs(companyDTO);

                    // Save with transaction
                    this.Save_CurrentAccount(cc_cledger, cc_caofs, companyDTO);

                    break;

                case "Current.Partnership":
                    // Prepare Data
                    PFMORM00028 cp_cledger = this.GetCLedger(companyDTO);
                    IList<PFMORM00017> cp_caofs = this.GetCAOFs(companyDTO);

                    // Save with transaction
                    this.Save_CurrentAccount(cp_cledger, cp_caofs, companyDTO);

                    break;

                case "Current.Association":
                    // Prepare Data
                    PFMORM00028 ca_cledger = this.GetCLedger(companyDTO);
                    IList<PFMORM00017> ca_caofs = this.GetCAOFs(companyDTO);

                    // Save with transaction
                    this.Save_CurrentAccount(ca_cledger, ca_caofs, companyDTO);

                    break;

                case "Saving.Company":
                    // Prepare Data
                    PFMORM00028 so_cledger = this.GetCLedger(companyDTO);
                    IList<PFMORM00016> so_saof = this.GetSAOFs(companyDTO);

                    // Save with transaction
                    this.Save_SavingAccount_Organization(so_cledger, so_saof, companyDTO);

                    break;

                case "Fixed.Company":
                    // Prepare Data
                    PFMORM00023 fc_fledger = this.GetFLedger(companyDTO);
                    IList<PFMORM00021> fc_faof = this.GetFAOFs(companyDTO);

                    // Save with transaction
                    this.Save_FixedAccount_Company(fc_fledger, fc_faof, companyDTO);

                    break;
            }

        }
        #endregion

        #region Helper Methods

        [Transaction(TransactionPropagation.Required)]
        private void Save_CurrentAccount(PFMORM00028 cledger, IList<PFMORM00017> caofs, PFMDTO00050 companyEntity)
        {
            IList<string> CustIdToIncrease = new List<string>();
            IList<string> CustIdToDecrease = new List<string>();
      
            this.CaofDAO.DeleteOldData(companyEntity.AccountNo);    //Delete Old Data From Caof

            foreach (PFMORM00017 caof in caofs)
            {
                caof.CledgerAccountNo = companyEntity.AccountNo;
                this.CaofDAO.Save(caof);        //Save New Data to Caof       
                this.CaofDAO.UpdateByUpdatedUser(caof.CledgerAccountNo, caof.SourceBranchCode, caof.UpdatedUserId, DateTime.Now);  //Added by ASDA

                bool IsSameCustId = false;
                foreach (string oldCustomerId in companyEntity.OldCustomerIds)
                {
                    if (oldCustomerId == caof.CustomerID)
                    {
                        IsSameCustId = true;
                        break;
                    }
                }
                if(!IsSameCustId && caof.CustomerID!=null)
                    this.CustomerIdDAO.UpdateOpenAccount(caof.CustomerID, Convert.ToInt32(companyEntity.UpdatedUserId)); //Update Customer's OpenAc +1
            }

            foreach (string oldCustomerId in companyEntity.OldCustomerIds)
            {
                bool IsSameCustId = false;
                foreach (PFMORM00017 caof in caofs)
                {
                    if (oldCustomerId == caof.CustomerID)
                    {
                        IsSameCustId = true;
                        break;
                    }
                }
                if(!IsSameCustId)
                    this.CustomerIdDAO.UpdateOpenAccount_Minus(oldCustomerId, Convert.ToInt32(companyEntity.UpdatedUserId));   //Update Customer's OpenAc -1
            }

            cledger.AccountNo = companyEntity.AccountNo;
            this.CledgerDAO.UpdateMinBal(cledger.AccountNo, cledger.MinimumBalance, Convert.ToInt32(companyEntity.UpdatedUserId)); //Update Cledger's MinBal



        }

        [Transaction(TransactionPropagation.Required)]
        private void Save_SavingAccount_Organization(PFMORM00028 cledger, IList<PFMORM00016> saofs, PFMDTO00050 companyEntity)
        {
            this.SAOFDAO.DeleteOldData(companyEntity.AccountNo);    //Delete Old Data From Saof

            foreach (PFMORM00016 saof in saofs)
            {
                saof.CledgerAccountNo = companyEntity.AccountNo;
                this.SAOFDAO.Save(saof);        //Save New Data to Saof   
                this.SAOFDAO.UpdateByUpdatedUser(saof.CledgerAccountNo, saof.SourceBranchCode, saof.UpdatedUserId, DateTime.Now);  //Added by ASDA

                bool IsSameCustId = false;
                foreach (string oldCustomerId in companyEntity.OldCustomerIds)
                {
                    if (oldCustomerId == saof.Customer_Id)
                    {
                        IsSameCustId = true;
                        break;
                    }
                }
                if(!IsSameCustId)
                    this.CustomerIdDAO.UpdateOpenAccount(saof.Customer_Id, Convert.ToInt32( companyEntity.UpdatedUserId)); //Update Customer's OpenAc +1             
            }

            foreach (string oldCustomerId in companyEntity.OldCustomerIds)
            {
                bool IsSameCustId = false;
                foreach (PFMORM00016 saof in saofs)
                {
                    if (oldCustomerId == saof.Customer_Id)
                    {
                        IsSameCustId = true;
                        break;
                    }
                }
                if (!IsSameCustId)
                    this.CustomerIdDAO.UpdateOpenAccount_Minus(oldCustomerId, Convert.ToInt32(companyEntity.UpdatedUserId));   //Update Customer's OpenAc -1
            }

            cledger.AccountNo = companyEntity.AccountNo;
            this.CledgerDAO.UpdateMinBal(cledger.AccountNo, cledger.MinimumBalance, Convert.ToInt32(companyEntity.UpdatedUserId));

        }

        [Transaction(TransactionPropagation.Required)]
        private void Save_FixedAccount_Company(PFMORM00023 fledger, IList<PFMORM00021> faofs, PFMDTO00050 companyEntity)
        {
            this.FAOFDAO.DeleteOldData(companyEntity.AccountNo);    //Delete Old Data From Faof
            foreach (PFMORM00021 faof in faofs)
            {
                faof.FledgerAccountNo = companyEntity.AccountNo;
                this.FAOFDAO.Save(faof);        //Save New Data to Saof 
                this.FAOFDAO.UpdateByUpdatedUser(faof.FledgerAccountNo, faof.SourceBranchCode, faof.UpdatedUserId, DateTime.Now);  //Added by ASDA

                bool IsSameCustId = false;
                foreach (string oldCustomerId in companyEntity.OldCustomerIds)
                {
                    if (oldCustomerId == faof.CustomerId)
                    {
                        IsSameCustId = true;
                        break;
                    }
                }
                if (!IsSameCustId)
                    this.CustomerIdDAO.UpdateOpenAccount(faof.CustomerId, Convert.ToInt32(companyEntity.UpdatedUserId)); //Update Customer's OpenAc +1
            }

            foreach (string oldCustomerId in companyEntity.OldCustomerIds)
            {
                bool IsSameCustId = false;
                foreach (PFMORM00021 faof in faofs)
                {
                    if (oldCustomerId == faof.CustomerId)
                    {
                        IsSameCustId = true;
                        break;
                    }
                }
                if (!IsSameCustId)
                    this.CustomerIdDAO.UpdateOpenAccount_Minus(oldCustomerId, Convert.ToInt32(companyEntity.UpdatedUserId)); //Update Customer's OpenAc -1
            }

        }
        #endregion

        #region Convert DTO to ORM

        private PFMORM00028 GetCLedger(PFMDTO00050 entity)
        {
            PFMORM00028 cledger = new PFMORM00028();

            cledger.AccountNo = entity.AccountNo;
            cledger.MinimumBalance = entity.MinBal;
            //cledger.CreatedUserId = entity.CreatedUserId;
            //cledger.UpdatedUserId = entity.CreatedUserId;
            //cledger.UpdatedDate = DateTime.Now;

            return cledger;
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
               
        private IList<PFMORM00016> GetSAOFs(PFMDTO00050 entity)
        {
            IList<PFMORM00016> saofs = new List<PFMORM00016>();

            PFMORM00016 companyInfo = new PFMORM00016();
            companyInfo.Name = entity.NameOfFirm;
            companyInfo.PhoneNo = entity.Phone;
            companyInfo.Fax = entity.Fax;
            companyInfo.Address = entity.Address;
            companyInfo.Email = entity.Email;
            companyInfo.NoOfPersonSign = entity.NoOfPersonSign;
            companyInfo.SerialofCustomer = 0;  //Added by ASDA
            companyInfo.AccountSign = entity.AccountSignature;
            companyInfo.OPENDATE = entity.AcceptedDate;
            companyInfo.USERNO = entity.CreatedUserId.ToString();
            companyInfo.Township_Code = entity.TownshipCode;
            companyInfo.State_Code = entity.StateCode;
            companyInfo.City_Code = entity.CityCode;
            companyInfo.SourceBranchCode = entity.BranchCode;
            companyInfo.CurrencyCode = entity.CurrencyCode;
            companyInfo.Active = true;
            companyInfo.CreatedDate = entity.CreatedDate;
            companyInfo.CreatedUserId = entity.CreatedUserId;
            companyInfo.UpdatedUserId = entity.UpdatedUserId;
            companyInfo.UpdatedDate = DateTime.Now;

            saofs.Add(companyInfo);

            for (int i = 1; i <= entity.CustomerIds.Count; i++)
            {
                PFMORM00016 saof = new PFMORM00016();

                saof.NoOfPersonSign = entity.NoOfPersonSign;
                saof.AccountSign = entity.AccountSignature;
                saof.OPENDATE = entity.AcceptedDate;
                saof.USERNO = entity.CreatedUserId.ToString();
                saof.Customer_Id = entity.CustomerIds[i - 1];
                saof.SerialofCustomer = i;
                saof.SourceBranchCode = entity.BranchCode;
                saof.CurrencyCode = entity.CurrencyCode;
                saof.Active = true;
                saof.CreatedDate = entity.CreatedDate;
                saof.CreatedUserId = entity.CreatedUserId;
                saof.UpdatedUserId = entity.UpdatedUserId;
                saof.UpdatedDate = DateTime.Now;

                saofs.Add(saof);
            }

            return saofs;
        }

        private IList<PFMORM00017> GetCAOFs(PFMDTO00050 entity)
        {
            IList<PFMORM00017> caofs = new List<PFMORM00017>();

            PFMORM00017 companyInfo = new PFMORM00017();
            companyInfo.CledgerAccountNo = entity.AccountNo;
            companyInfo.Name = entity.NameOfFirm;
            companyInfo.PhoneNo = entity.Phone;
            companyInfo.Fax = entity.Fax;
            companyInfo.Address = entity.Address;
            companyInfo.Email = entity.Email;
            companyInfo.NoOfPersonSign = entity.NoOfPersonSign;
            companyInfo.SerialofCustomer = 0;    //Added by ASDA
            companyInfo.AccountSign = entity.AccountSignature;
            companyInfo.OPENDATE = Convert.ToDateTime(entity.AcceptedDate);
            companyInfo.USERNO = entity.CreatedUserId.ToString();
            companyInfo.Township_Code = entity.TownshipCode;
            companyInfo.State_Code = entity.StateCode;
            companyInfo.City_Code = entity.CityCode;
            companyInfo.Business = entity.Business;
            companyInfo.SourceBranchCode = entity.BranchCode;
            companyInfo.CurrencyCode = entity.CurrencyCode;
            companyInfo.Active = true;
            companyInfo.CreatedDate = entity.CreatedDate;
            companyInfo.CreatedUserId = entity.CreatedUserId;
            companyInfo.UpdatedUserId = entity.UpdatedUserId;
            companyInfo.UpdatedDate = DateTime.Now;

            caofs.Add(companyInfo);

            for (int i = 1; i <= entity.CustomerIds.Count; i++)
            {
                PFMORM00017 caof = new PFMORM00017();
                caof.CledgerAccountNo = entity.AccountNo;
                caof.NoOfPersonSign = entity.NoOfPersonSign;
                caof.AccountSign = entity.AccountSignature;
                caof.OPENDATE = Convert.ToDateTime(entity.AcceptedDate);
                caof.USERNO = entity.CreatedUserId.ToString();
                caof.CustomerID = entity.CustomerIds[i - 1];
                caof.SerialofCustomer = i;
                caof.SourceBranchCode = entity.BranchCode;
                caof.CurrencyCode = entity.CurrencyCode;
                caof.Active = true;
                caof.CreatedDate = entity.CreatedDate;
                caof.CreatedUserId = entity.CreatedUserId;
                caof.UpdatedUserId = entity.UpdatedUserId;
                caof.UpdatedDate = DateTime.Now;

                caofs.Add(caof);
            }

            return caofs;
        }

        private IList<PFMORM00021> GetFAOFs(PFMDTO00050 entity)
        {
            IList<PFMORM00021> faofs = new List<PFMORM00021>();

            PFMORM00021 companyInfo = new PFMORM00021();
            companyInfo.FledgerAccountNo = entity.AccountNo;
            companyInfo.Name = entity.NameOfFirm;
            companyInfo.Phone = entity.Phone;
            companyInfo.Fax = entity.Fax;
            companyInfo.Address = entity.Address;
            companyInfo.Email = entity.Email;
            companyInfo.LastReceiptNo = entity.FReceipt.ReceiptNo;  // Receipt No. for Firm
            companyInfo.NoOfPersonSign = entity.NoOfPersonSign;
            companyInfo.SerialOfCustomer = 0;  //Added by ASDA
            companyInfo.AccountSignature = entity.AccountSignature;
            companyInfo.OpenDate = entity.AcceptedDate;
            companyInfo.UserNo = entity.CreatedUserId.ToString();
            companyInfo.Township_Code = entity.TownshipCode;
            companyInfo.State_Code = entity.StateCode;
            companyInfo.City_Code = entity.CityCode;
            companyInfo.SourceBranchCode = entity.BranchCode;
            companyInfo.CurrencyCode = entity.CurrencyCode;
            companyInfo.Active = true;
            companyInfo.CreatedDate = entity.CreatedDate;
            companyInfo.CreatedUserId = entity.CreatedUserId;
            companyInfo.UpdatedUserId = entity.UpdatedUserId;
            companyInfo.UpdatedDate = DateTime.Now;

            faofs.Add(companyInfo);

            for (int i = 1; i <= entity.CustomerIds.Count; i++)
            {
                PFMORM00021 faof = new PFMORM00021();
                faof.FledgerAccountNo = entity.AccountNo;
                faof.NoOfPersonSign = entity.NoOfPersonSign;
                faof.AccountSignature = companyInfo.AccountSignature;
                faof.OpenDate = entity.AcceptedDate;
                faof.UserNo = entity.CreatedUserId.ToString();
                faof.CustomerId = entity.CustomerIds[i - 1];
                faof.SerialOfCustomer = i;
                faof.SourceBranchCode = entity.BranchCode;
                faof.CurrencyCode = entity.CurrencyCode;
                faof.Active = true;
                faof.CreatedDate = entity.CreatedDate;
                faof.CreatedUserId = entity.CreatedUserId;
                faof.UpdatedUserId = entity.UpdatedUserId;
                faof.UpdatedDate = DateTime.Now;

                faof.LastReceiptNo = entity.FReceipt.ReceiptNo; //Receipt No. for Each Customer

                faofs.Add(faof);
            }

            return faofs;
        }
       

        ////Edited by ASDA*****
        //private IList<PFMORM00016> GetSAOFs(PFMDTO00050 entity)
        //{
        //    IList<PFMORM00016> saofs = new List<PFMORM00016>();

        //    for (int i = 1; i <= entity.CustomerIds.Count; i++)
        //    {
        //        PFMORM00016 saof = new PFMORM00016();
        //        saof.CledgerAccountNo = entity.AccountNo;
        //        saof.Name = entity.NameOfFirm;
        //        saof.PhoneNo = entity.Phone;
        //        saof.Fax = entity.Fax;
        //        saof.Address = entity.Address;
        //        saof.Email = entity.Email;
        //        saof.NoOfPersonSign = entity.NoOfPersonSign;
        //        saof.AccountSign = entity.AccountSignature;
        //        saof.OPENDATE = DateTime.Now;
        //        saof.USERNO = entity.CreatedUserId.ToString();
        //        saof.Township_Code = entity.TownshipCode;
        //        saof.State_Code = entity.StateCode;
        //        saof.City_Code = entity.CityCode;
        //        saof.NoOfPersonSign = entity.NoOfPersonSign;
        //        saof.AccountSign = entity.AccountSignature;
        //        saof.OPENDATE = DateTime.Now;               
        //        saof.Customer_Id = entity.CustomerIds[i - 1];
        //        saof.SerialofCustomer = i;
        //        saof.SourceBranchCode = entity.BranchCode;
        //        saof.CurrencyCode = entity.CurrencyCode;
        //        saof.Active = true;
        //        saof.CreatedUserId = entity.CreatedUserId;
        //        saof.UpdatedUserId = entity.CreatedUserId;
        //        saof.UpdatedDate = DateTime.Now;

        //        saofs.Add(saof);
        //    }
        //    return saofs;
        //}

        //private IList<PFMORM00017> GetCAOFs(PFMDTO00050 entity)
        //{
        //    IList<PFMORM00017> caofs = new List<PFMORM00017>();

        //    for (int i = 1; i <= entity.CustomerIds.Count; i++)
        //    {
        //        PFMORM00017 caof = new PFMORM00017();
        //        caof.CledgerAccountNo = entity.AccountNo;
        //        caof.Name = entity.NameOfFirm;
        //        caof.PhoneNo = entity.Phone;
        //        caof.Fax = entity.Fax;
        //        caof.Address = entity.Address;
        //        caof.Email = entity.Email; //Added by ASDA
        //        caof.Township_Code = entity.TownshipCode;
        //        caof.State_Code = entity.StateCode;
        //        caof.City_Code = entity.CityCode;
        //        caof.Business = entity.Business;                
        //        caof.NoOfPersonSign = entity.NoOfPersonSign;
        //        caof.AccountSign = entity.AccountSignature;
        //        caof.OPENDATE = DateTime.Now;
        //        caof.USERNO = entity.CreatedUserId.ToString();
        //        caof.CustomerID = entity.CustomerIds[i - 1];
        //        caof.SerialofCustomer = i;
        //        caof.SourceBranchCode = entity.BranchCode;
        //        caof.CurrencyCode = entity.CurrencyCode;
        //        caof.Active = true;
        //        caof.CreatedUserId = entity.CreatedUserId;
        //        caof.UpdatedUserId = entity.CreatedUserId;
        //        caof.UpdatedDate = DateTime.Now;

        //        caofs.Add(caof);
        //    }
        //    return caofs;
        //}

        //private IList<PFMORM00021> GetFAOFs(PFMDTO00050 entity)
        //{
        //    IList<PFMORM00021> faofs = new List<PFMORM00021>();

        //    for (int i = 1; i <= entity.CustomerIds.Count; i++)
        //    {
        //        PFMORM00021 faof = new PFMORM00021();
        //        faof.FledgerAccountNo = entity.AccountNo;
        //        faof.Name = entity.NameOfFirm;
        //        faof.Phone = entity.Phone;
        //        faof.Fax = entity.Fax;
        //        faof.Address = entity.Address;
        //        faof.Email = entity.Email;               
        //        faof.NoOfPersonSign = entity.NoOfPersonSign;
        //        faof.AccountSignature = entity.AccountSignature;                                
        //        faof.Township_Code = entity.TownshipCode;
        //        faof.State_Code = entity.StateCode;
        //        faof.City_Code = entity.CityCode;
        //        faof.FledgerAccountNo = entity.AccountNo;                             
        //        faof.OpenDate = DateTime.Now;
        //        faof.UserNo = entity.CreatedUserId.ToString();
        //        faof.CustomerId = entity.CustomerIds[i - 1];
        //        faof.SerialOfCustomer = i;
        //        faof.SourceBranchCode = entity.BranchCode;
        //        faof.CurrencyCode = entity.CurrencyCode;
        //        faof.Active = true;
        //        faof.CreatedUserId = entity.CreatedUserId;
        //        faof.UpdatedUserId = entity.CreatedUserId;
        //        faof.UpdatedDate = DateTime.Now;
        //        faof.LastReceiptNo = entity.FReceipt.ReceiptNo; //Receipt No. for Each Customer

        //        faofs.Add(faof);
        //    }
        //    return faofs;
        //}
        ////End*****
        private void CollectCaofInformation(IList<PFMDTO00017> caofDatas)
        {
            CommonDTO = new PFMDTO00050();
            foreach (PFMDTO00017 caof in caofDatas)
            {
                if (caof.CustomerID == null)
                {
                    CommonDTO.Name = caof.Name;
                    CommonDTO.Email = caof.Email;
                    CommonDTO.Address = caof.Address;
                    CommonDTO.CityCode = caof.City_Code;
                    CommonDTO.CurrencyCode = caof.CurrencyCode;
                    CommonDTO.Phone = caof.PhoneNo;
                    CommonDTO.Fax = caof.Fax;
                    CommonDTO.TownshipCode = caof.Township_Code;
                    CommonDTO.StateCode = caof.State_Code;
                    CommonDTO.Business = caof.Business;
                    CommonDTO.NoOfPersonSign = caof.NoOfPersonSign.Value;
                    CommonDTO.UpdatedUserId = caof.CreatedUserId;
                    CommonDTO.UpdatedDate = DateTime.Now;
                    break;
                }
            }
        }

        private void CollectSaofInformation(IList<PFMDTO00016> saofDatas)
        {
            CommonDTO = new PFMDTO00050();
            foreach (PFMDTO00016 saof in saofDatas)
            {
                if (saof.Customer_Id == null)
                {
                    CommonDTO.Name = saof.Name;
                    CommonDTO.Email = saof.Email;
                    CommonDTO.Address = saof.Address;
                    CommonDTO.CityCode = saof.City_Code;
                    CommonDTO.CurrencyCode = saof.CurrencyCode;
                    CommonDTO.Phone = saof.PhoneNo;
                    CommonDTO.Fax = saof.Fax;
                    CommonDTO.TownshipCode = saof.Township_Code;
                    CommonDTO.StateCode = saof.State_Code;
                    CommonDTO.Business = saof.Business;
                    CommonDTO.NoOfPersonSign = saof.NoOfPersonSign;
                    CommonDTO.UpdatedUserId = saof.CreatedUserId;
                    CommonDTO.UpdatedDate = DateTime.Now;
                    break;
                }
            }
        }

        private void CollectFaofInformation(IList<PFMDTO00021> faofDatas)
        {
            CommonDTO = new PFMDTO00050();
            foreach (PFMDTO00021 faof in faofDatas)
            {
                if (faof.CustomerId == null)
                {
                    CommonDTO.Name = faof.Name;
                    CommonDTO.Email = faof.Email;
                    CommonDTO.Address = faof.Address;
                    CommonDTO.CityCode = faof.City_Code;
                    CommonDTO.CurrencyCode = faof.CurrencyCode;
                    CommonDTO.Phone = faof.Phone;
                    CommonDTO.Fax = faof.Fax;
                    CommonDTO.TownshipCode = faof.Township_Code;
                    CommonDTO.StateCode = faof.State_Code;
                    CommonDTO.Business = faof.Business;
                    CommonDTO.NoOfPersonSign = faof.NoOfPersonSign;
                    CommonDTO.UpdatedUserId = faof.CreatedUserId;
                    CommonDTO.UpdatedDate = DateTime.Now;
                    break;
                }
            }
        }

        #endregion

        // eg. accountType => "Current.Individual.KYT"
        public bool AccountTypeChecking(string accountNo, string accountType, string branchCode,out string message)
        {
            if (string.IsNullOrEmpty(accountNo) || string.IsNullOrEmpty(accountType))
            {
                throw new Exception(CXMessage.ME90018); //Invalid Parameter
            }

            string[] AccountType = accountType.Split(".".ToCharArray());
            if (AccountType.Length != 3)
            {
                throw new Exception(CXMessage.ME90018); //Invalid Parameter
            }

            string acType = AccountType[0];
            string subAcType = AccountType[1];
            string cur = AccountType[2];
            int index = 0;
            string symbol=string.Empty;

            IList<FormatDefinition> formatDefinitionDTO = this.FormatDao.SelectFormatDefinitonByFormatCode(accountType, branchCode);

            IList<FormatDefinition> BarnchCodePortion = formatDefinitionDTO.Where<FormatDefinition>(x => x.PortionCode == "BranchCode").ToList();
            IList<FormatDefinition> CurrencyPortion = formatDefinitionDTO.Where<FormatDefinition>(x => x.PortionCode == "Currency").ToList();
            IList<FormatDefinition> AccountTypePortion = formatDefinitionDTO.Where<FormatDefinition>(x => x.PortionCode == "AccountType").ToList();
            IList<FormatDefinition> SubAccountTypePortion = formatDefinitionDTO.Where<FormatDefinition>(x => x.PortionCode == "SubAccountType").ToList();

            index = BarnchCodePortion[0].Length + CurrencyPortion[0].Length;

            PFMDTO00015 AccountTypeDTO = this.AccountTypeDAO.SelectByCode(acType);  //Get Symbol of AccountType
            symbol = accountNo.Substring(index, AccountTypePortion[0].Length);     //Get Symbol of Inputed AccountNo

            if (symbol != AccountTypeDTO.Symbol)  //Check AccountType is right?
            {
                message = AccountTypeDTO.Description;
                throw new Exception(CXMessage.MV00211);     //[AccountTypeDTO.Description]+ Only
            }

            index = index + AccountTypePortion[0].Length;

            PFMDTO00022 SubAccountTypeDTO = this.SubAccountTypeDAO.SelectByCodeAndAcTypeId(subAcType, AccountTypeDTO.Id);   //Get Symbol of SubAccountType
            symbol = accountNo.Substring(index, SubAccountTypePortion[0].Length);     //Get Symbol of Inputed AccountNo

            if (symbol != SubAccountTypeDTO.Symbol)   //Check SubAccountType is right?
            {
                message = SubAccountTypeDTO.Description;
                throw new Exception(CXMessage.MV00211);     //[SubAccountTypeDTO.Description]+ Only
            }

            message = string.Empty;

            #region Check Account and Currency

            //if (acType == "Current" || acType == "Saving")
            //{
            //    cledgerAccount = this.CledgerDAO.SelectACSignByAccountNo(accountNo);
            //    if (cledgerAccount == null)
            //    {
            //        throw new Exception(CXMessage.MV00175);     //Account No Not Found
            //    }
            //    if (cledgerAccount.CurrencyCode != cur)
            //    {
            //        throw new Exception(CXMessage.MV00046); //Invalid AccountNo
            //    }
            //}
            //else if (acType == "Fixed")
            //{
            //    fledgerAccount = this.FLedgerDAO.SelectACSignAndCurByAccountNo(accountNo);
            //    if (fledgerAccount == null)
            //    {
            //        throw new Exception(CXMessage.MV00175);     //Account No Not Found
            //    }

            //    if (fledgerAccount.CurrencyCode != cur)
            //    {
            //        throw new Exception(CXMessage.MV00046); //Invalid AccountNo
            //    }
            //}

            #endregion

            return true;
        }

    }
}
