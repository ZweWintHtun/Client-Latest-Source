//----------------------------------------------------------------------
// <copyright file="TLMSVE00035.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-08-01</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Tel.Sve
{
    /// <summary>
    /// Bank Cash Scroll Service
    /// </summary>
    public class TLMSVE00035 : BaseService, ITLMSVE00035
    {
        #region "DAO & Service"
        private IPFMDAO00036 cs99DAO;
        public IPFMDAO00036 CS99DAO
        {
            get;
            set;
        }
        public ICXSVE00010 DataGenerateService { get; set; }
       public ITLMDAO00052 BankCashCreditDAO { get; set; }
       public ICXDAO00009 ViewDAO { get; set; }
        public ICXSVE00006 CodeChecker { get; set; }
        public ICXDAO00010 DataGenerateDAO { get; set; }
        IList<PFMDTO00042> FinalBankDTOLists { get; set; }
        #endregion

        #region "Public Methods"
        public PFMDTO00036 GetSelectTopCS99(DateTime datetime, string currency,string sourcebr)
        {
            PFMDTO00036 CS99DTO = CS99DAO.GetTopCS99(datetime, currency,sourcebr);
            return CS99DTO;
        }

        public PFMDTO00036 GetSelectTopCS99WithoutCurrency(DateTime datetime,string sourcebr)
        {
            PFMDTO00036 Balance = CS99DAO.GetTopCS99WithoutCurrency(datetime,sourcebr);
            return Balance;
        }
        
        [Transaction(TransactionPropagation.Required)]
        private void GetReportDataForBankCashScroll(PFMDTO00042 BankCashScrollDTO)
        {
            PFMDTO00042 DataGenerateDTO = new PFMDTO00042();
            CXDTO00006 reportparameters = new CXDTO00006();
            //According To the Transaction Date and Settlement Date , Insert into Report TLF. by using ICXSVE00010 GetReportDataGenerateInSQL
            reportparameters = this.GetTranAndSettleDateDTO(BankCashScrollDTO);            
            //To Insert Datas to Report_TLF Table
            DataGenerateDTO = this.DataGenerateService.GetReportDataGenerateInSQL(reportparameters); 
            //return DataGenerateDTO;
        }

        public IList<PFMDTO00042> GetReturnBalanceAndRCTLData(PFMDTO00042 BankCashScrollDTO)
        {
           
            IList<PFMDTO00042> BalanceDTOList = new List<PFMDTO00042>();
            try
            {
                PFMDTO00042 BanlanceDTO = new PFMDTO00042();
                CXDTO00008 ReturnBalanceAndRCTLDTO = new CXDTO00008();
               

                switch (BankCashScrollDTO.DateType)
                {
                    case "Transaction Date": BankCashScrollDTO.DateType = "T";
                        break;

                    case "Settlement Date": BankCashScrollDTO.DateType = "S";
                        break;
                }

                switch (BankCashScrollDTO.IsWithReversal)
                {
                    case true: BankCashScrollDTO.WithdrawalCount = 1;
                        break;

                    case false: BankCashScrollDTO.WithdrawalCount = 0;
                        break;
                }

                this.GetReportDataForBankCashScroll(BankCashScrollDTO);

                if (BankCashScrollDTO.CurrencyType == "Home Currency")
                {
                    //exec SP_BANKING_BANKCASH_CALC_BYHOMECURALL.                      
                    BanlanceDTO = this.DataGenerateDAO.BankCashScroll(BankCashScrollDTO.WorkStation, BankCashScrollDTO.StartDate, BankCashScrollDTO.WithdrawalCount, BankCashScrollDTO.DateType, BankCashScrollDTO.SourceBranch, BankCashScrollDTO.CreatedUserId);
                    if (BanlanceDTO != null)
                    {
                        BalanceDTOList = this.GetBankDebitCreditDatas(BankCashScrollDTO);
                        /* Edited by HOW (To get cash closing balance for weekends)*/
                        if (BalanceDTOList.Count == 0) {
                            BalanceDTOList.Add(BanlanceDTO);
                        }
                    }    
                }
                else    //For source currency
                {
                    if (BankCashScrollDTO.IsHomeCurrency == true)
                    {
                        //exec sp_banking_bankcash_calc_byhomecur
                        BanlanceDTO = this.DataGenerateDAO.BankCashScrollByHomeCur(BankCashScrollDTO.WorkStation, BankCashScrollDTO.StartDate, BankCashScrollDTO.WithdrawalCount, BankCashScrollDTO.DateType, "KYT", BankCashScrollDTO.SourceBranch, BankCashScrollDTO.CreatedUserId);//BankCashScrollDTO.CurCode
                        if (BanlanceDTO != null)
                        {
                            BalanceDTOList = this.GetBankDebitCreditDatas(BankCashScrollDTO);
                        }                          
                    }
                    else
                    {
                        if (BankCashScrollDTO.IsAllBranches && BankCashScrollDTO.DateType == "T")
                        {                                //exec SP_BANKING_BANKCASH_CALC_BYSourceCUR
                                BanlanceDTO = this.DataGenerateDAO.BankCashScrollBySourceCur(BankCashScrollDTO.WorkStation, BankCashScrollDTO.StartDate, BankCashScrollDTO.WithdrawalCount, BankCashScrollDTO.DateType, BankCashScrollDTO.CurCode, BankCashScrollDTO.CreatedUserId);
                                if (BanlanceDTO != null)
                                {
                                    BalanceDTOList = this.GetBankDebitCreditDatas(BankCashScrollDTO);
                                    /* Edited by HOW (To get cash closing balance for weekends)*/
                                    if (BalanceDTOList.Count == 0)
                                        BalanceDTOList.Add(BanlanceDTO);
                                }                              
                           
                        }
                        else
                        {
                            //exec sp_banking_bankcash_calc
                            BanlanceDTO = this.DataGenerateDAO.BankCashScrollCALC(BankCashScrollDTO.WorkStation, BankCashScrollDTO.StartDate, BankCashScrollDTO.WithdrawalCount, BankCashScrollDTO.DateType, BankCashScrollDTO.CurCode, BankCashScrollDTO.OtherBank, BankCashScrollDTO.CreatedUserId);
                            if (BanlanceDTO != null)
                            {
                                BalanceDTOList = this.GetBankDebitCreditDatas(BankCashScrollDTO);
                                /* Edited by HOW (To get cash closing balance for weekends)*/
                                if (BalanceDTOList.Count == 0)
                                    BalanceDTOList.Add(BanlanceDTO);
                            }                           
                        }
                    }
                }
                BalanceDTOList[BalanceDTOList.Count - 1].ReturnObalance =(BalanceDTOList.Count!=0)? BanlanceDTO.ReturnObalance:0;
                BalanceDTOList[BalanceDTOList.Count - 1].TrCL = (BalanceDTOList.Count != 0) ? BanlanceDTO.TrCL : 0;
            }
            catch
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MI00039;
            }
                return BalanceDTOList;           
          }

        #endregion

        #region "Private Methods"

        private CXDTO00006 GetTranAndSettleDateDTO(PFMDTO00042 BankCashScrollDTO)
        {
            CXDTO00006 reportparameters = new CXDTO00006();
            switch (BankCashScrollDTO.DateType)
            {
                case "T": 
                    reportparameters.BDateType = "T";
                    reportparameters.StartDate = BankCashScrollDTO.StartDate;
                    reportparameters.EndDate = BankCashScrollDTO.StartDate;
                    reportparameters.ForCheck_Or_ForReturn = CXDMD00009.ForReturn;
                    reportparameters.UserNo = BankCashScrollDTO.WorkStation;
                    reportparameters.CreatedUserId = BankCashScrollDTO.CreatedUserId;

                    break;
                case "S": 
                    reportparameters.BDateType = "S";
                    reportparameters.StartDate = BankCashScrollDTO.StartDate;
                    reportparameters.EndDate = BankCashScrollDTO.StartDate;
                    reportparameters.ForCheck_Or_ForReturn = CXDMD00009.ForReturn;
                    reportparameters.UserNo = BankCashScrollDTO.WorkStation;
                    reportparameters.CreatedUserId = BankCashScrollDTO.CreatedUserId;

                    break;
            }

            if (!BankCashScrollDTO.IsAllBranches)
                reportparameters.SpecialCondition = "sourcebr = '" + BankCashScrollDTO.SourceBranch + "'";

            return reportparameters;

        }

        private IList<PFMDTO00042> GetBankDebitCreditDatas(PFMDTO00042 bankCashScrollDTO)
        {
            PFMDTO00042 rptDto = new PFMDTO00042();
            IList<PFMDTO00042> BankDTOLists = new List<PFMDTO00042>();
            IList<PFMDTO00042> DTOLists = new List<PFMDTO00042>();

            if (bankCashScrollDTO.IsWithReversal == true)
            {
                if (bankCashScrollDTO.DateType == "T")
                {
                    if (bankCashScrollDTO.CurrencyType == "Home Currency")
                    {
                        //For Debit Side (Dr:) ='CC' or 'CCA'  
                        BankDTOLists = this.BankCashCreditDAO.SelectTransactionDateWithReversalByHome(bankCashScrollDTO);
                        this.FinalBankDTOLists = this.SelectDataDTOList(BankDTOLists);
                       
                    }
                    else
                    {
                        if (bankCashScrollDTO.IsHomeCurrency == true)
                        {
                            BankDTOLists = this.BankCashCreditDAO.SelectTransactionDateWithReversalByCurrencyCode(bankCashScrollDTO);
                            this.FinalBankDTOLists = this.SelectDataDTOList(BankDTOLists);
                        }
                           /*  'For All Branch & Source Cur */
                        else
                        {
                            BankDTOLists = this.ViewDAO.SelectTranDateWithReversalByForAllBranchAndSourceCur(bankCashScrollDTO);
                            this.FinalBankDTOLists = this.SelectDataDTOList(BankDTOLists);
                        }
                    }
                }
                else if (bankCashScrollDTO.DateType == "S")
                {
                    if (bankCashScrollDTO.CurrencyType == "Home Currency")
                    {
                        BankDTOLists = this.BankCashCreditDAO.SelectWithReversalByHomeSettlementDate(bankCashScrollDTO);
                        this.FinalBankDTOLists = this.SelectDataDTOList(BankDTOLists);
                    }
                    else
                    {
                        if (bankCashScrollDTO.IsHomeCurrency == true)
                        {
                            BankDTOLists = this.BankCashCreditDAO.SelectWithReversalByCurrencyCodeSettlementDate(bankCashScrollDTO);
                            this.FinalBankDTOLists = this.SelectDataDTOList(BankDTOLists);
                        }
                        else
                        {
                            BankDTOLists = this.ViewDAO.SelectWithReversalByForAllBranchAndSourceCurBySettlementDate(bankCashScrollDTO);
                            this.FinalBankDTOLists = this.SelectDataDTOList(BankDTOLists);
                        }
                    }
                }
            }
            else /* Edited by HOW */
            {
                
                if (bankCashScrollDTO.DateType == "T")
                {
                    //if (bankCashScrollDTO.CurrencyType == "Home Currency")
                    //{
                    //    BankDTOLists = this.ViewDAO.SelectAllWithoutReversalByHomeTransactionDate(bankCashScrollDTO);
                    //    this.FinalBankDTOLists = this.SelectDataDTOList(BankDTOLists);
                    //}
                    //else
                    //{
                        if (bankCashScrollDTO.IsHomeCurrency == true)
                        {
                            bankCashScrollDTO.CurCode = "KYT";
                            BankDTOLists = this.ViewDAO.SelectByBankCashWithoutReversalByCurCodeTransactionDate(bankCashScrollDTO);
                            this.FinalBankDTOLists = this.SelectDataDTOList(BankDTOLists);
                        }
                        else
                        {
                            BankDTOLists = this.ViewDAO.SelecteWithoutReversalByForAllBranchAndSourceCurTransactionDate(bankCashScrollDTO);
                            this.FinalBankDTOLists = this.SelectDataDTOList(BankDTOLists);
                        }
                    }
                //}

                else if (bankCashScrollDTO.DateType == "S")
                {
                    //if (bankCashScrollDTO.CurrencyType == "Home Currency")
                    //{
                    //    BankDTOLists = this.ViewDAO.SelectAllWithoutReversalByHomeSettlementDate(bankCashScrollDTO);
                    //    this.FinalBankDTOLists = this.SelectDataDTOList(BankDTOLists);
                    //}
                    //else
                    //{
                        if (bankCashScrollDTO.IsHomeCurrency == true)
                        {
                            bankCashScrollDTO.CurCode = "KYT";
                            BankDTOLists = this.ViewDAO.SelectByBankCashWithoutReversalByCurCodeSettlementDate(bankCashScrollDTO);
                            this.FinalBankDTOLists = this.SelectDataDTOList(BankDTOLists);
                        }
                        else
                        {
                            BankDTOLists = this.ViewDAO.SelecteWithoutReversalByForAllBranchAndSourceCurSettlementDate(bankCashScrollDTO);
                            this.FinalBankDTOLists = this.SelectDataDTOList(BankDTOLists);
                        }
                    //}
                }

            }
            if (FinalBankDTOLists.Count != 0)
            {                
                for (int i = 0; i < FinalBankDTOLists.Count; i++)
                {
                    ChargeOfAccountDTO dto = CXCOM00011.Instance.GetScalarObject<ChargeOfAccountDTO>("COA.Server.SelectAccountName", new object[] { FinalBankDTOLists[i].ACode, FinalBankDTOLists[i].SourceBranch, true });
                    FinalBankDTOLists[i].Description = (dto.AccountName == null) ? "-" : dto.AccountName;
                }               
            }
            //else
            //{
            //    return null;
            //}
            return FinalBankDTOLists;
        }

        private IList<PFMDTO00042> SelectDataDTOList(IList<PFMDTO00042> BankDTOLists)
        {
            IList<PFMDTO00042> DTOLists = new List<PFMDTO00042>();
              #region "Looping"
            if (BankDTOLists.Count != 0)
            {

                for (int i = 0; i < BankDTOLists.Count; i++)
                {
                    PFMDTO00042 DTO = new PFMDTO00042();
                    if (i == 0)
                    {
                        DTO.ACode = BankDTOLists[i].ACode;
                        DTO.SourceBranch = BankDTOLists[i].SourceBranch;
                        if (BankDTOLists[i].Status == "CC" || BankDTOLists[i].Status == "CCA")
                        {
                            DTO.Amount = BankDTOLists[i].HomeAmt.Value + BankDTOLists[i].HomeOamt;
                        }
                        if (BankDTOLists[i].Status == "CD" || BankDTOLists[i].Status == "CDA")
                        {
                            DTO.LocalAmt = BankDTOLists[i].HomeAmt + BankDTOLists[i].HomeOamt;
                        }
                        DTOLists.Add(DTO);

                    }
                    else if (i > 0)
                    {
                        if (BankDTOLists[i].ACode != BankDTOLists[i - 1].ACode)
                        {
                            DTO.ACode = BankDTOLists[i].ACode;
                            DTO.SourceBranch = BankDTOLists[i].SourceBranch;
                            if (BankDTOLists[i - 1].Status == "CC" || BankDTOLists[i - 1].Status == "CCA")
                            {
                                DTOLists[DTOLists.Count - 1].LocalAmt = 0;
                            }
                            //else
                            //{
                            //    DTOLists[DTOLists.Count - 1].Amount = 0;
                            //}

                            if (BankDTOLists[i].Status == "CC" || BankDTOLists[i].Status == "CCA")
                            {
                                DTO.Amount = BankDTOLists[i].HomeAmt.Value + BankDTOLists[i].HomeOamt;
                            }
                            if (BankDTOLists[i].Status == "CD" || BankDTOLists[i].Status == "CDA")
                            {
                                DTO.LocalAmt = BankDTOLists[i].HomeAmt + BankDTOLists[i].HomeOamt;
                            }
                            DTOLists.Add(DTO);
                        }
                        else
                        {
                            if (BankDTOLists[i].Status == "CC" || BankDTOLists[i].Status == "CCA")
                            {
                                DTOLists[DTOLists.Count - 1].Amount += BankDTOLists[i].HomeAmt.Value + BankDTOLists[i].HomeOamt;
                            }
                            else if (BankDTOLists[i].Status == "CD" || BankDTOLists[i].Status == "CDA")
                            {
                                DTOLists[DTOLists.Count - 1].LocalAmt = (DTOLists[DTOLists.Count - 1].LocalAmt == null) ? 0 : DTOLists[DTOLists.Count - 1].LocalAmt;
                                DTOLists[DTOLists.Count - 1].LocalAmt += BankDTOLists[i].HomeAmt + BankDTOLists[i].HomeOamt;
                            }

                        }
                    }
                }
            }
            return DTOLists;
         #endregion
        }
        #endregion
    }
    }

