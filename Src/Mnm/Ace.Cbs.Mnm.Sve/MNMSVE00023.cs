using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Ctr;
using Spring.Transaction;
using Spring.Transaction.Interceptor;

using Ace.Windows.Admin.DataModel;
using System.Collections;
using Ace.Cbs.Cx.Com.Utt;
using System.Data.SqlTypes;

namespace Ace.Cbs.Mnm.Sve
{
    class MNMSVE00023:BaseService,IMNMSVE00023
    {
        IPFMDAO00054 TLFDAO { get; set; }  //added by ASDA
        ITLMDAO00017 RDDAO { get; set; }
        ITLMDAO00009 DepoDenoDAO { get; set; }
        ITLMDAO00015 CashDenoDAO { get; set; }
        IPFMDAO00028 CledgerDAO { get; set; }
        ICXDAO00006 CodeCheckerDAO { get; set; }
        IPFMDAO00023 FLedgerDAO { get; set; }
        IPFMDAO00024 CoaDAO { get; set; }
        IPFMDAO00056 Sys001DAO { get; set; }
        IPFMDAO00020 UChequeDAO { get; set; }
        IMNMSVE00022 RDUpdateService { get; set; }
        ITLMDAO00021 DrawingPrintingDAO { get; set; }
        ICXSVE00006 CommonService { get; set; }
        ICXSVE00002 CodeGenerator { get; set; }  //added by ASDA
        //ICXSVE00006 ReverSalDAO { get; set; }
        DateTime nextSettlementDate;
        decimal rate;
        int uchequeId;
        string cashDenoTlfEno;
        bool flag = true;
        //public IList<PFMDTO00054> TlfList = new List<PFMDTO00054>();
        public IList<PFMDTO00054> TlfList{ get; set; }
        #region Main Methods
        public TLMDTO00017 GetRDInfo(string registerNo, string sourceBr)
        {
            TLMDTO00017 RDInfo = this.RDDAO.SelectByRegisterNo(registerNo, sourceBr);
            if (RDInfo == null)
                return null;

            RDInfo.GroupNo = this.DepoDenoDAO.SelectGroupNoByAcType(registerNo, sourceBr);
            RDInfo.OrgCounterNo = this.CashDenoDAO.SelectCounterNoByAcType(registerNo, sourceBr);

            PFMDTO00028 cledgerAccount =this.CledgerDAO.SelectByAccountNoAndSourceBr(RDInfo.AccountNo, sourceBr);
            if (cledgerAccount != null)
            {
                if (cledgerAccount.CloseDate != default(DateTime) && cledgerAccount.CloseDate != null)
                {
                    RDInfo.IsCloseAC = true;
                }
            }

            decimal cashDenoAmount = 0;
            if (!string.IsNullOrEmpty(RDInfo.GroupNo))
                cashDenoAmount = this.CashDenoDAO.SelectAmountByTlfEno(RDInfo.GroupNo, sourceBr);
            else
                cashDenoAmount = this.CashDenoDAO.SelectAmountByACType(registerNo, sourceBr);

            
            RDInfo.CashAmount = cashDenoAmount;
            return RDInfo;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00054> Delete(TLMDTO00017 entity, CXDTO00001 denoInfo)
        {
        ////Delete UCheque
            //CodeCheckerDAO.DeletefromUCheckbyChequeNoAccountNo(entity.AccountNo, entity.CheckNo, entity.SourceBranchCode, entity.UpdatedUserId.Value);
              this.nextSettlementDate = this.Sys001DAO.SelectSysDate("NEXT_SETTLEMENT_DATE", entity.SourceBranchCode);
              TlfList = new List<PFMDTO00054>();
 
            //Group
            if (!string.IsNullOrEmpty(entity.GroupNo))
            {
                  //Update Cledger And Tlf 
                TlfList = this.TLFDAO.SelectByDRegisterNo(entity.RegisterNo, entity.SourceBranchCode, DateTime.Now);
                if (TlfList != null && TlfList.Count > 0)
                {
                    ReversalProcess(entity, denoInfo, true);
                }

                decimal otherAmount = 0;
                otherAmount = this.GetOtherGroupAmount(entity.GroupNo, entity.RegisterNo, entity.SourceBranchCode).Amount.Value;
                if (otherAmount > 0)
                {
                    //Update CashDeno By TlfEno
                    if (denoInfo != null)
                        this.CashDenoDAO.UpdateCashDenoByTlfEno(denoInfo, entity.UpdatedUserId.Value, entity.SourceBranchCode, entity.GroupNo, entity.CashAmount==null? 0 : entity.CashAmount.Value);
                }
                else
                {
                    //Delete CashDeno By TlfEno
                    this.CashDenoDAO.DeleteByTlfEno(entity.GroupNo, entity.SourceBranchCode, entity.UpdatedUserId.Value);
                }
             ////Update Cledger And Tlf 
                //TlfList = this.TLFDAO.SelectByDRegisterNo(entity.RegisterNo, entity.SourceBranchCode, DateTime.Now);
                //if (TlfList != null && TlfList.Count > 0)
                //{
                //    ReversalProcess(entity, denoInfo, true);
                //}
                //Delete DepoDeno
                this.DepoDenoDAO.DeleteByGroupNoAndACType(entity.RegisterNo, entity.SourceBranchCode, entity.UpdatedUserId.Value, entity.GroupNo);
                //Delete RD
                this.RDDAO.DeleteByRegisterNo(entity.RegisterNo, entity.SourceBranchCode, entity.UpdatedUserId.Value);
                  //ReversalProcess(entity, denoInfo, true);   \\Commit By ASDA
            }
            else
            {
                //Update Cledger And Tlf
                TlfList = this.TLFDAO.SelectByDRegisterNo(entity.RegisterNo, entity.SourceBranchCode, DateTime.Now);
                if (TlfList != null && TlfList.Count > 0)
                {
                    ReversalProcess(entity, denoInfo, true);
                }
                //Delete CashDeno By ACType
                this.CashDenoDAO.DeleteByACType(entity.RegisterNo, entity.SourceBranchCode, entity.UpdatedUserId.Value);
                //Delete RD
                this.RDDAO.DeleteByRegisterNo(entity.RegisterNo, entity.SourceBranchCode, entity.UpdatedUserId.Value);
            }

            ////Delete UCheque
            CodeCheckerDAO.DeletefromUCheckbyChequeNoAccountNo(entity.AccountNo, entity.CheckNo, entity.SourceBranchCode, entity.UpdatedUserId.Value);
            return TlfList;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00054> Save(TLMDTO00017 entity, CXDTO00001 denoInfo, int workstationId, bool voucher)
        {
            try
            {
                #region Get NextSettlementDate
                this.nextSettlementDate = this.Sys001DAO.SelectSysDate("NEXT_SETTLEMENT_DATE", entity.SourceBranchCode);
                if (this.nextSettlementDate == null || this.nextSettlementDate.ToString() == string.Empty)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MI30027";     //NextSettlementDate Not Found
                }
                #endregion

                this.rate = CXCOM00010.Instance.GetExchangeRate(entity.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType));

                string oldIncomeType = entity.OldIncomeType;
                string newIncomeType = entity.IncomeType;
                string oldDrawingType = entity.OldDrawingType;
                string newDrawingType = entity.DrawingType;

                #region Account to Account
                if (oldDrawingType == "Account" && newDrawingType == "Account")
                {
                    if ((oldIncomeType == "CS" && newIncomeType == "TR") || (oldIncomeType == "CS" && string.IsNullOrEmpty(newIncomeType)))
                    {
                        //group
                        if (!string.IsNullOrEmpty(entity.GroupNo))
                        {
                            //not last group
                            if (denoInfo != null)
                            {
                                //Delete DepoDeno
                                this.DepoDenoDAO.DeleteByGroupNoAndACType(entity.RegisterNo, entity.SourceBranchCode, entity.UpdatedUserId.Value, entity.GroupNo);
                                //Update CashDeno
                                this.CashDenoDAO.UpdateCashDenoByTlfEno(denoInfo, entity.UpdatedUserId.Value, entity.SourceBranchCode, entity.GroupNo, entity.CashAmount.Value);
                            }
                            //last group
                            else
                            {
                                //Delete DepoDeno
                                this.DepoDenoDAO.DeleteByGroupNoAndACType(entity.RegisterNo, entity.SourceBranchCode, entity.UpdatedUserId.Value, entity.GroupNo);
                                //Delete CashDeno
                                this.CashDenoDAO.DeleteByTlfEno(entity.GroupNo, entity.SourceBranchCode, entity.UpdatedUserId.Value);
                            }
                        }
                        //single
                        else
                        {
                            //Delete CashDeno
                            this.CashDenoDAO.DeleteByACType(entity.RegisterNo, entity.SourceBranchCode, entity.UpdatedUserId.Value);
                        }
                    }
                    else if (oldIncomeType == "TR" && newIncomeType == "CS")
                    {
                        //Insert CashDeno
                        this.CashDenoDAO.Save(this.ConvertToCashDenoORM(entity, denoInfo));
                    }
                    else if (oldIncomeType == "TR" && string.IsNullOrEmpty(newIncomeType))
                    {
                        //nothing
                    }
                    else if (string.IsNullOrEmpty(oldIncomeType) && newIncomeType == "CS")
                    {
                        //Insert CashDeno
                        this.CashDenoDAO.Save(this.ConvertToCashDenoORM(entity, denoInfo));
                    }
                    else if (string.IsNullOrEmpty(oldIncomeType) && newIncomeType == "TR")
                    {
                        //nothing
                    }
                    else if (oldIncomeType == "CS" && newIncomeType == "CS")
                    {
                        //group
                        if (!string.IsNullOrEmpty(entity.GroupNo))
                        {
                            //Update DepoDeno
                            this.DepoDenoDAO.UpdateByGroupNoAndACType(entity.RegisterNo, entity.SourceBranchCode, entity.UpdatedUserId.Value, entity.GroupNo, entity.Commission.Value + entity.TlxCharges.Value);
                            //Update CashDeno
                            if (denoInfo != null)
                                this.CashDenoDAO.UpdateCashDenoByTlfEno(denoInfo, entity.UpdatedUserId.Value, entity.SourceBranchCode, entity.GroupNo, entity.CashAmount.Value);                            
                        }
                        //single
                        else
                        {
                            //Update CashDeno
                            if (denoInfo != null)
                                this.CashDenoDAO.UpdateCashDenoByACType(denoInfo, entity.UpdatedUserId.Value, entity.SourceBranchCode, entity.RegisterNo, entity.CashAmount.Value);
                        }
                        flag = true;   //added by ASDA(to use reversal process)
                    }
                    else if (oldIncomeType == "TR" && newIncomeType == "TR")
                    {
                        //nothing
                    }
                    else if (string.IsNullOrEmpty(oldIncomeType) && string.IsNullOrEmpty(newIncomeType))
                    {
                        //nothing
                    }
                }  //-----------------------------------------------------------------------------------------------------------------
                #endregion

                #region Cash To Cash
                else if (oldDrawingType == "Cash" && newDrawingType == "Cash")
                {
                    if ((oldIncomeType == "CS" && string.IsNullOrEmpty(newIncomeType)) || (string.IsNullOrEmpty(oldIncomeType) && string.IsNullOrEmpty(newIncomeType)))
                    {
                        //group
                        if (!string.IsNullOrEmpty(entity.GroupNo))
                        {
                            //update DepoDeno
                            this.DepoDenoDAO.UpdateByGroupNoAndACType(entity.RegisterNo, entity.SourceBranchCode, entity.UpdatedUserId.Value, entity.GroupNo, entity.Amount.Value);
                            //Update CashDeno
                            if (denoInfo != null)
                                this.CashDenoDAO.UpdateCashDenoByTlfEno(denoInfo, entity.UpdatedUserId.Value, entity.SourceBranchCode, entity.GroupNo, entity.CashAmount.Value);
                        }
                        //single
                        else
                        {
                            //Update CashDeno
                            if (denoInfo != null)
                                this.CashDenoDAO.UpdateCashDenoByACType(denoInfo, entity.UpdatedUserId.Value, entity.SourceBranchCode, entity.RegisterNo, entity.CashAmount.Value);
                        }
                    }
                    else if ((oldIncomeType == "CS" && newIncomeType == "CS") || (string.IsNullOrEmpty(oldIncomeType) && newIncomeType == "CS"))
                    {
                        //group
                        if (!string.IsNullOrEmpty(entity.GroupNo))
                        {
                            if (!voucher)
                            {
                                //update DepoDeno
                                this.DepoDenoDAO.UpdateByGroupNoAndACType(entity.RegisterNo, entity.SourceBranchCode, entity.UpdatedUserId.Value, entity.GroupNo, entity.Amount.Value + entity.Commission.Value + entity.TlxCharges.Value);
                                //Update CashDeno
                                if (denoInfo != null)
                                    this.CashDenoDAO.UpdateCashDenoByTlfEno(denoInfo, entity.UpdatedUserId.Value, entity.SourceBranchCode, entity.GroupNo, entity.CashAmount.Value);
                            }
                            else
                            {
                                flag = false;
                                this.ReversalProcess(entity, denoInfo, false);
                            }
                        }
                        //single
                        else
                        {
                            //Update CashDeno
                            if (denoInfo != null)
                            {
                                if (!voucher)
                                {
                                    this.CashDenoDAO.UpdateCashDenoByACType(denoInfo, entity.UpdatedUserId.Value, entity.SourceBranchCode, entity.RegisterNo, entity.CashAmount.Value);
                                }
                                else
                                {
                                    flag = false;
                                    this.ReversalProcess(entity, denoInfo, false);   //edited by ASDA  
                                }
                            }
                        }
                    }
                }
                #endregion

                #region Cash To Account

                else if (oldDrawingType == "Cash" && newDrawingType == "Account")
                {
                    if ((oldIncomeType == "CS" && newIncomeType == "TR") || (oldIncomeType == "CS" && string.IsNullOrEmpty(newIncomeType)))
                    {
                        //group
                        if (!string.IsNullOrEmpty(entity.GroupNo))
                        {
                            //not last group
                            if (denoInfo != null)
                            {
                                //Delete DepoDeno
                                this.DepoDenoDAO.DeleteByGroupNoAndACType(entity.RegisterNo, entity.SourceBranchCode, entity.UpdatedUserId.Value, entity.GroupNo);
                                //Update CashDeno
                                this.CashDenoDAO.UpdateCashDenoByTlfEno(denoInfo, entity.UpdatedUserId.Value, entity.SourceBranchCode, entity.GroupNo, entity.CashAmount.Value);
                            }
                            //last group
                            else
                            {
                                //Delete DepoDeno
                                this.DepoDenoDAO.DeleteByGroupNoAndACType(entity.RegisterNo, entity.SourceBranchCode, entity.UpdatedUserId.Value, entity.GroupNo);
                                //Delete CashDeno
                                this.CashDenoDAO.DeleteByTlfEno(entity.GroupNo, entity.SourceBranchCode, entity.UpdatedUserId.Value);
                            }
                        }
                        //single
                        else
                        {
                            //Delete CashDeno
                            this.CashDenoDAO.DeleteByACType(entity.RegisterNo, entity.SourceBranchCode, entity.UpdatedUserId.Value);
                        }
                    }
                    if (string.IsNullOrEmpty(oldIncomeType) && newIncomeType == "CS")
                    {
                        //group
                        if (!string.IsNullOrEmpty(entity.GroupNo))
                        {
                            //Update DepoDeno
                            this.DepoDenoDAO.UpdateByGroupNoAndACType(entity.RegisterNo, entity.SourceBranchCode, entity.UpdatedUserId.Value, entity.GroupNo, entity.Commission.Value + entity.TlxCharges.Value);
                            //Update CashDeno
                            if (denoInfo != null)
                                this.CashDenoDAO.UpdateCashDenoByTlfEno(denoInfo, entity.UpdatedUserId.Value, entity.SourceBranchCode, entity.GroupNo, entity.CashAmount.Value);
                        }
                        //single
                        else
                        {
                            //Update CashDeno
                            if (denoInfo != null)
                                this.CashDenoDAO.UpdateCashDenoByTlfEno(denoInfo, entity.UpdatedUserId.Value, entity.SourceBranchCode, entity.GroupNo, entity.CashAmount.Value);
                        }
                    }

                    if (string.IsNullOrEmpty(oldIncomeType) && newIncomeType == "TR")
                    {
                        //group
                        if (!string.IsNullOrEmpty(entity.GroupNo))
                        {
                            //not last group
                            if (denoInfo != null)
                            {
                                //Delete DepoDeno
                                this.DepoDenoDAO.DeleteByGroupNoAndACType(entity.RegisterNo, entity.SourceBranchCode, entity.UpdatedUserId.Value, entity.GroupNo);
                                //Update CashDeno
                                this.CashDenoDAO.UpdateCashDenoByTlfEno(denoInfo, entity.UpdatedUserId.Value, entity.SourceBranchCode, entity.GroupNo, entity.CashAmount.Value);
                            }
                            //last group
                            else
                            {
                                //Delete DepoDeno
                                this.DepoDenoDAO.DeleteByGroupNoAndACType(entity.RegisterNo, entity.SourceBranchCode, entity.UpdatedUserId.Value, entity.GroupNo);
                                //Delete CashDeno
                                this.CashDenoDAO.DeleteByTlfEno(entity.GroupNo, entity.SourceBranchCode, entity.UpdatedUserId.Value);
                            }
                        }
                        //single
                        else
                        {
                            //Delete CashDeno
                            this.CashDenoDAO.DeleteByACType(entity.RegisterNo, entity.SourceBranchCode, entity.UpdatedUserId.Value);
                        }
                    }

                    if (oldIncomeType == "CS" && newIncomeType == "CS")
                    {
                        //group
                        if (!string.IsNullOrEmpty(entity.GroupNo))
                        {
                            //Update DepoDeno
                            this.DepoDenoDAO.UpdateByGroupNoAndACType(entity.RegisterNo, entity.SourceBranchCode, entity.UpdatedUserId.Value, entity.GroupNo, entity.Commission.Value + entity.TlxCharges.Value);
                            //Update CashDeno
                            if (denoInfo != null)
                                this.CashDenoDAO.UpdateCashDenoByTlfEno(denoInfo, entity.UpdatedUserId.Value, entity.SourceBranchCode, entity.GroupNo, entity.CashAmount.Value);
                        }
                        //single
                        else
                        {
                            //Update CashDeno
                            if (denoInfo != null)
                                this.CashDenoDAO.UpdateCashDenoByACType(denoInfo, entity.UpdatedUserId.Value, entity.SourceBranchCode, entity.RegisterNo, entity.CashAmount.Value);
                        }
                        flag = true;
                    }
                    if (string.IsNullOrEmpty(oldIncomeType) && string.IsNullOrEmpty(newIncomeType))
                    {
                        //group
                        if (!string.IsNullOrEmpty(entity.GroupNo))
                        {
                            //not last group
                            if (denoInfo != null)
                            {
                                //Delete DepoDeno
                                this.DepoDenoDAO.DeleteByGroupNoAndACType(entity.RegisterNo, entity.SourceBranchCode, entity.UpdatedUserId.Value, entity.GroupNo);
                                //Update CashDeno
                                this.CashDenoDAO.UpdateCashDenoByTlfEno(denoInfo, entity.UpdatedUserId.Value, entity.SourceBranchCode, entity.GroupNo, entity.CashAmount.Value);
                            }
                            //last group
                            else
                            {
                                //Delete DepoDeno
                                this.DepoDenoDAO.DeleteByGroupNoAndACType(entity.RegisterNo, entity.SourceBranchCode, entity.UpdatedUserId.Value, entity.GroupNo);
                                //Delete CashDeno
                                this.CashDenoDAO.DeleteByTlfEno(entity.GroupNo, entity.SourceBranchCode, entity.UpdatedUserId.Value);
                            }
                        }
                        //single
                        else
                        {
                            //Delete CashDeno
                            this.CashDenoDAO.DeleteByACType(entity.RegisterNo, entity.SourceBranchCode, entity.UpdatedUserId.Value);
                        }
                    }
                }

                #endregion

                #region Account To Cash
                else if (oldDrawingType == "Account" && newDrawingType == "Cash")
                {
                    if (oldIncomeType == "CS" && newIncomeType == "CS")
                    {
                        //group
                        if (!string.IsNullOrEmpty(entity.GroupNo))
                        {
                            //Update DepoDeno
                            this.DepoDenoDAO.UpdateByGroupNoAndACType(entity.RegisterNo, entity.SourceBranchCode, entity.UpdatedUserId.Value, entity.GroupNo, entity.Amount.Value + entity.Commission.Value + entity.TlxCharges.Value);
                            //Update CashDeno
                            if (denoInfo != null)
                                this.CashDenoDAO.UpdateCashDenoByTlfEno(denoInfo, entity.UpdatedUserId.Value, entity.SourceBranchCode, entity.GroupNo, entity.CashAmount.Value);
                        }
                        //single
                        else
                        {
                            //Update CashDeno
                            if (denoInfo != null)
                                this.CashDenoDAO.UpdateCashDenoByACType(denoInfo, entity.UpdatedUserId.Value, entity.SourceBranchCode, entity.RegisterNo, entity.CashAmount.Value);
                        }
                        flag = true;
                    }
                    else if (oldIncomeType == "CS" && string.IsNullOrEmpty(newIncomeType))
                    {
                        //group
                        if (!string.IsNullOrEmpty(entity.GroupNo))
                        {
                            //Update DepoDeno
                            this.DepoDenoDAO.UpdateByGroupNoAndACType(entity.RegisterNo, entity.SourceBranchCode, entity.UpdatedUserId.Value, entity.GroupNo, entity.Amount.Value);
                            //Update CashDeno
                            if (denoInfo != null)
                                this.CashDenoDAO.UpdateCashDenoByTlfEno(denoInfo, entity.UpdatedUserId.Value, entity.SourceBranchCode, entity.GroupNo, entity.CashAmount.Value);
                        }
                        //single
                        else
                        {
                            //Update CashDeno
                            if (denoInfo != null)
                                this.CashDenoDAO.UpdateCashDenoByACType(denoInfo, entity.UpdatedUserId.Value, entity.SourceBranchCode, entity.RegisterNo, entity.CashAmount.Value);
                        }
                    }
                    else if (string.IsNullOrEmpty(oldIncomeType) && string.IsNullOrEmpty(newIncomeType))
                    {
                        //Insert CashDeno
                        this.CashDenoDAO.Save(this.ConvertToCashDenoORM(entity, denoInfo));
                    }
                    else if (string.IsNullOrEmpty(oldIncomeType) && newIncomeType == "CS")
                    {
                        //Insert CashDeno
                        this.CashDenoDAO.Save(this.ConvertToCashDenoORM(entity, denoInfo));
                    }
                    else if (oldIncomeType == "TR" && newIncomeType == "CS")
                    {
                        //Insert CashDeno
                        this.CashDenoDAO.Save(this.ConvertToCashDenoORM(entity, denoInfo));
                    }
                    else if (oldIncomeType == "TR" && string.IsNullOrEmpty(newIncomeType))
                    {
                        //Insert CashDeno
                        this.CashDenoDAO.Save(this.ConvertToCashDenoORM(entity, denoInfo));
                    }
                }
                #endregion

                //Insert tlf   ---Added by ASDA (save to tlf with reversaleno if rd register no is already voucher)
                if (voucher)
                {
                    if(flag)
                    ReversalProcess(entity, denoInfo, false);
                }               
                //end--------------------------
                
               
                //Update RD
                this.RDDAO.UpdateRDImportantDataByRegisterNo(entity.TestKey.Value,entity.Amount.Value, entity.Commission.Value, entity.TlxCharges.Value, entity.IncomeType, entity.AccountNo, entity.Name, entity.NRC, entity.Address, entity.CheckNo, entity.PhoneNo, entity.Narration, entity.AccountSign, entity.RDType, entity.Deno_Status, entity.UpdatedUserId.Value, entity.RegisterNo, entity.SourceBranchCode);   //edited by ASDA

                IList<PFMDTO00020> UChequeList = this.UChequeDAO.SelectUchequeByAccountNoChequeNo(entity.AccountNo, entity.OldChequeNo, entity.SourceBranchCode);
                
                if (UChequeList.Count > 0)
                {
                    uchequeId = UChequeList.Where(x => x.ChequeNo == entity.OldChequeNo).ToList()[0].Id;
                }
               
                //Insert UCheck
                if (!string.IsNullOrEmpty(entity.CheckNo) && entity.AccountSign.StartsWith("C"))
                {    
                    this.UChequeDAO.Save(this.ConvertToUChequeORM(entity));
                }

                //Delete Old UCheque
                this.UChequeDAO.DeletefromUCheckbyId(uchequeId, entity.UpdatedUserId.Value);

                entity.AmountByLetter = this.RDUpdateService.AmountDesp(entity.Amount.Value, entity.Currency);
                //Delete DrawingPrinting
                this.DrawingPrintingDAO.DeleteByWorkStation(workstationId.ToString(), entity.SourceBranchCode);
                //Insert DrawingPrinting
                this.DrawingPrintingDAO.Save(this.ConvertToDrawingPrintingORM(entity, workstationId));
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";   //Error Occur!!! Please contact your administrator.
                throw new Exception(this.ServiceResult.MessageCode);
            }

            PFMDTO00054 tlfDto = new PFMDTO00054();
            tlfDto.ReferenceType = entity.AmountByLetter;
            TlfList = new List<PFMDTO00054>();
            TlfList.Add(tlfDto);
            return TlfList;
        }
        #endregion

        #region Helper Method
        public TLMDTO00017 GetOtherGroupAmount(string groupNo, string registerNo, string sourceBr)
        {
            TLMDTO00017 returnEntity = new TLMDTO00017();
            //Select Other Amount
            returnEntity.Amount = this.DepoDenoDAO.SelectOtherAmountByGroupNo(groupNo, registerNo, sourceBr);
            return returnEntity;
        }

        public PFMDTO00001 CheckAccount(string accountNo, string sourceBr, string oldAccountNo)
        {
            if (accountNo.Length == 6)
            {
                ChargeOfAccountDTO coaDTO = this.CoaDAO.SelectByCode(accountNo, sourceBr);
                if (coaDTO == null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MV00046";    //Invalid AccountNo
                    return null;
                }
                else
                {
                    PFMDTO00001 returnDTO = new PFMDTO00001();
                    returnDTO.AccountNo = accountNo;
                    returnDTO.Name = coaDTO.AccountName;
                    return returnDTO;
                }
            }
            else
            {
                PFMDTO00028 cledgerAccount = this.CledgerDAO.SelectACSignByAccountNo(accountNo);
                if (cledgerAccount == null)
                {
                    PFMDTO00023 fledgerAccount = this.FLedgerDAO.SelectACSignAndCurByAccountNo(accountNo);
                    if (fledgerAccount == null)
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = "MV00046";    //Invalid AccountNo
                        return null;
                    }
                    else
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = "MV00211\nCurrent, Saving, Chart Of Account";    //Current, Saving, Chart Of Account only
                        return null;
                    }
                }
                else
                {
                    if (cledgerAccount.CloseDate != null && cledgerAccount.CloseDate.ToString() != string.Empty && cledgerAccount.CloseDate != default(DateTime))
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = "MV00044"; //AccountNo has been closed.
                        return null;
                    }
                    else if (cledgerAccount.SourceBranchCode != sourceBr)
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = "MV00091\nInvalid\n" + sourceBr;    //Invalid Account No. Invalid for Branch [BranchNo]
                        return null;
                    }
                    else
                    {
                        if (accountNo == oldAccountNo)
                        {
                            PFMDTO00001 returnEntity = new PFMDTO00001();
                            returnEntity.AccountSign = cledgerAccount.AccountSign;
                            return returnEntity;
                        }

                        if (cledgerAccount.AccountSign[1] == 'J')
                        {
                            if (cledgerAccount.AccountSign[0] == 'C')
                            {
                                PFMDTO00017 Caof = new PFMDTO00017();
                                PFMDTO00001 CustInfo = new PFMDTO00001();
                                Caof = this.CodeCheckerDAO.GetCAOFByAccountNumber(accountNo, 1);
                                CustInfo = this.CodeCheckerDAO.GetCustomerInfo(Caof.CustomerID, sourceBr);
                                CustInfo.Message = cledgerAccount.AccountSign[0].ToString();
                                CustInfo.AccountSign = cledgerAccount.AccountSign;
                                return CustInfo;
                            }
                            else if (cledgerAccount.AccountSign[0] == 'S')
                            {
                                PFMDTO00016 Saof = new PFMDTO00016();
                                PFMDTO00001 CustInfo = new PFMDTO00001();
                                Saof = this.CodeCheckerDAO.GetSAOFByAccountNumber(accountNo, 1);
                                CustInfo = this.CodeCheckerDAO.GetCustomerInfo(Saof.Customer_Id, sourceBr);
                                CustInfo.Message = cledgerAccount.AccountSign;
                                CustInfo.Message = cledgerAccount.AccountSign[0].ToString();
                                CustInfo.AccountSign = cledgerAccount.AccountSign;
                                return CustInfo;
                            }
                        }
                        else if (cledgerAccount.AccountSign[1] == 'I')
                        {
                            if (cledgerAccount.AccountSign[0] == 'C')
                            {
                                PFMDTO00001 CustInfo = new PFMDTO00001();
                                IList<PFMDTO00001> CustInfoList = new List<PFMDTO00001>();
                                CustInfoList = this.CodeCheckerDAO.GetCustomerInformationBySAOForCAOF(accountNo, "C");
                                CustInfo = CustInfoList[0];
                                CustInfo.Message = cledgerAccount.AccountSign[0].ToString();
                                CustInfo.AccountSign = cledgerAccount.AccountSign;
                                return CustInfo;
                            }
                            else if (cledgerAccount.AccountSign[0] == 'S')
                            {
                                PFMDTO00001 CustInfo = new PFMDTO00001();
                                IList<PFMDTO00001> CustInfoList = new List<PFMDTO00001>();
                                CustInfoList = this.CodeCheckerDAO.GetCustomerInformationBySAOForCAOF(accountNo, "S");
                                CustInfo = CustInfoList[0];
                                CustInfo.Message = cledgerAccount.AccountSign[0].ToString();
                                CustInfo.AccountSign = cledgerAccount.AccountSign;
                                return CustInfo;
                            }
                        }
                        else if (cledgerAccount.AccountSign[1] == 'A' || cledgerAccount.AccountSign[1] == 'O' || cledgerAccount.AccountSign[1] == 'C' || cledgerAccount.AccountSign[1] == 'P')
                        {
                            if (cledgerAccount.AccountSign[0] == 'C')
                            {
                                IList<PFMDTO00017> CaofList = this.CodeCheckerDAO.GetCAOFsByAccountNumber(accountNo);
                                PFMDTO00017 caof = new PFMDTO00017();
                                caof = CaofList.Where(x => x.CustomerID == null).ToList()[0];
                                PFMDTO00001 CustInfo = new PFMDTO00001();
                                CustInfo.AccountNo = accountNo;
                                CustInfo.Name = caof.Name;
                                CustInfo.Address = caof.Address;
                                CustInfo.Message = cledgerAccount.AccountSign[0].ToString();
                                CustInfo.AccountSign = cledgerAccount.AccountSign;
                                return CustInfo;
                            }
                            else if (cledgerAccount.AccountSign[0] == 'S')
                            {
                                IList<PFMDTO00016> SaofList = this.CodeCheckerDAO.GetSAOFsByAccountNumber(accountNo);
                                PFMDTO00016 saof = new PFMDTO00016();
                                saof = SaofList.Where(x => x.Customer_Id == null).ToList()[0];
                                PFMDTO00001 CustInfo = new PFMDTO00001();
                                CustInfo.AccountNo = accountNo;
                                CustInfo.Name = saof.Name;
                                CustInfo.Address = saof.Address;
                                CustInfo.Message = cledgerAccount.AccountSign[0].ToString();
                                CustInfo.AccountSign = cledgerAccount.AccountSign;
                                return CustInfo;
                            }
                        }
                        else
                        {
                            this.ServiceResult.ErrorOccurred = true;
                            this.ServiceResult.MessageCode = "MV30006";     //Minor Account is not Allowed.
                        }
                    }
                }
            }
            return null;
        }

        public PFMDTO00028 GetAccount(string accountNo)
        {
            return this.CledgerDAO.SelectACSignByAccountNo(accountNo);
        }

        public string CheckAmount(string accountNo, decimal amount)
        {
            bool isLink = false;
            string messageCode = string.Empty;
            this.CommonService.CheckAmount(accountNo, amount, true, false, true, ref isLink, ref messageCode);
            return messageCode;
        }

        private TLMORM00015 ConvertToCashDenoORM(TLMDTO00017 entity, CXDTO00001 denoInfo)
        {
            TLMORM00015 CashDenoORM = new TLMORM00015();
            CashDenoORM.Id = this.CashDenoDAO.SelectMaxId() + 1;
            CashDenoORM.DenoEntryNo = null;  
            CashDenoORM.TlfEntryNo = entity.GroupNo;
            //CashDenoORM.AccountType = string.IsNullOrEmpty(entity.GroupNo) ? entity.RegisterNo : null;
            CashDenoORM.AccountType = string.IsNullOrEmpty(entity.GroupNo) ? entity.RegisterNo : entity.GroupNo.StartsWith("R") ? entity.RegisterNo : null;
            //if (CashDenoORM.AccountType == null)
            //{
            //    if (CashDenoORM.TlfEntryNo.StartsWith("G"))
            //        CashDenoORM.AccountType = entity.RegisterNo;
            //}
            CashDenoORM.FromType = null;
            CashDenoORM.BranchCode = null;
            CashDenoORM.ReceiptNo = null;
            CashDenoORM.Amount = entity.CashAmount;
            CashDenoORM.AdjustAmount = denoInfo.AdjustAmount;
            CashDenoORM.CashDate = DateTime.Now;
            CashDenoORM.DenoDetail = denoInfo.DenoString;
            CashDenoORM.DenoRefundDetail = denoInfo.RefundString;
            CashDenoORM.UserNo = entity.CreatedUserId.ToString();
            CashDenoORM.CounterNo = denoInfo.CounterNo;
            CashDenoORM.Status = "R";
            CashDenoORM.Reverse = false;
            CashDenoORM.UniqueId = null;
            CashDenoORM.SourceBranchCode = entity.SourceBranchCode;
            CashDenoORM.Currency = entity.Currency;
            CashDenoORM.DenoRate = denoInfo.DenoRateString;
            CashDenoORM.DenoRefundRate = denoInfo.RefundRateString;
            CashDenoORM.SettlementDate = this.nextSettlementDate;
            CashDenoORM.AllDenoRate = null;
            CashDenoORM.Rate = this.rate;
            CashDenoORM.Active = true;
            CashDenoORM.CreatedDate = DateTime.Now;
            CashDenoORM.CreatedUserId = entity.CreatedUserId;

            return CashDenoORM;
        }

        private PFMORM00020 ConvertToUChequeORM(TLMDTO00017 entity)
        {
            PFMORM00020 UChequeORM = new PFMORM00020();
            UChequeORM.ChequeNo = entity.CheckNo;
            UChequeORM.AccountNo = entity.AccountNo;
            UChequeORM.AccountSignature = entity.AccountSign;
            UChequeORM.Channel = "CBS";
            UChequeORM.DATE_TIME = DateTime.Now;
            UChequeORM.USERNO = entity.CreatedUserId.ToString();
            UChequeORM.SourceBranchCode = entity.SourceBranchCode;
            UChequeORM.Active = true;
            UChequeORM.CreatedDate = DateTime.Now;
            UChequeORM.CreatedUserId = entity.CreatedUserId;

            return UChequeORM;
        }

        private TLMORM00021 ConvertToDrawingPrintingORM(TLMDTO00017 entity, int workstationId)
        {
            TLMORM00021 drawingPrintORM = new TLMORM00021();
            drawingPrintORM.Id = this.DrawingPrintingDAO.SelectMaxId() + 1;
            drawingPrintORM.RegisterNo = entity.RegisterNo;
            drawingPrintORM.RAmount = entity.AmountByLetter;
            drawingPrintORM.WorkStation = workstationId.ToString();
            drawingPrintORM.SourceBranchCode = entity.SourceBranchCode;
            drawingPrintORM.UniqueId = null;
            drawingPrintORM.Active = true;
            drawingPrintORM.CreatedDate = DateTime.Now;
            drawingPrintORM.CreatedUserId = entity.UpdatedUserId.Value;

            return drawingPrintORM;
        }

        private void ReversalProcess(TLMDTO00017 entity, CXDTO00001 denoInfo, bool isDelete)  //added by ASDA
        {
            TlfList = new List<PFMDTO00054>();
            TLMDTO00015 cashDenoInfo = new TLMDTO00015();
            string GeneratedEno = GetGeneratedEnoLocal("Reversal Code", entity.UpdatedUserId.Value, entity.SourceBranchCode);
            string CurBudYear = CXCOM00010.Instance.GetBudgetYear1("");
            TLMDTO00017 oldData = GetRDInfo(entity.RegisterNo, entity.SourceBranchCode);
            //if (oldData.GroupNo == null)
            if(string.IsNullOrEmpty(entity.GroupNo))
            {
                cashDenoInfo = CashDenoDAO.SelectCashDenoInfoByACType(entity.RegisterNo, entity.SourceBranchCode);
            }
            TlfList = this.TLFDAO.SelectByDRegisterNo(entity.RegisterNo, entity.SourceBranchCode,DateTime.Now);
            if (TlfList != null && TlfList.Count > 0)
            {
                var isOrgnEnoNull = from x in TlfList
                                    where x.OrgnEno == null
                                    && x.DateTime.ToShortDateString() == DateTime.Now.ToShortDateString()
                                    select x;
                int i = isOrgnEnoNull.ToList<PFMDTO00054>() == null ? 0 : isOrgnEnoNull.ToList<PFMDTO00054>().Count;

                if (i == 0)
                {
                    throw new Exception("ME30003"); //Entry No Already Issued
                }
                else
                {
                    //Update CashDeno
                    
                    if (denoInfo != null)
                    {
                        //Update CashDeno
                        //this.CashDenoDAO.UpdateCashDenoByForAmountEdit(GeneratedEno, Convert.ToInt32(entity.UpdatedUserId), string.IsNullOrEmpty(oldData.GroupNo) ? cashDenoInfo.TlfEntryNo : oldData.GroupNo, entity.SourceBranchCode);                    
                        this.CashDenoDAO.UpdateCashDenoByForAmountEdit(GeneratedEno,Convert.ToInt32(entity.UpdatedUserId), string.IsNullOrEmpty(entity.GroupNo) ? cashDenoInfo.TlfEntryNo : entity.GroupNo, entity.SourceBranchCode);                    

                        //entity.GroupNo = string.IsNullOrEmpty(oldData.GroupNo) ? cashDenoInfo.TlfEntryNo : oldData.GroupNo;
                        entity.GroupNo = string.IsNullOrEmpty(entity.GroupNo) ? cashDenoInfo.TlfEntryNo : entity.GroupNo;
                        TLMORM00015 cashDenoData = this.ConvertToCashDenoORM(entity, denoInfo);
                        //Save CashDeno
                        this.CashDenoDAO.Save(cashDenoData);
                    }

                foreach (PFMDTO00054 tlfDto in TlfList)
                    {
                        CommonService.ReversalProcess(tlfDto.Eno, GeneratedEno, entity.GroupNo, entity.SourceBranchCode, DateTime.Now, entity.SourceBranchCode, entity.UpdatedUserId.Value, null, string.Empty, true);
                    }
                    if (!string.IsNullOrEmpty(entity.GroupNo))
                    {
                        //update DepoDeno
                        this.DepoDenoDAO.UpdateByGroupNoAndACType(entity.RegisterNo, entity.SourceBranchCode, entity.UpdatedUserId.Value, entity.GroupNo, entity.Amount.Value + entity.Commission.Value + entity.TlxCharges.Value);
                    }
                   
                    //for (int j = 0; j < TlfList.Count; j++)
                    //{
                    //    if (j == 0)
                    //        cashDenoSaveData.VirtualStatus = "OneTime";
                    //    else
                    //        cashDenoSaveData.VirtualStatus = null;

                    //    CommonService.ReversalProcess(TlfList[j].Eno, GeneratedEno, oldData.GroupNo, entity.SourceBranchCode, DateTime.Now, entity.SourceBranchCode, entity.UpdatedUserId.Value, cashDenoSaveData, string.Empty, true);                                               
                    //}
                    if (isDelete == true)
                    {
                        CashDenoDAO.UpdateCashDenoForReversalDelete(GeneratedEno, entity.UpdatedUserId.Value, entity.RegisterNo, entity.SourceBranchCode);
                    }
                }
                for (int a = 0; a < TlfList.Count; a++)
                {
                    TLMDTO00005 reversaltrancodedto = this.CodeCheckerDAO.SelectByTranCode(this.CodeCheckerDAO.SelectByTranCode(TlfList[a].TransactionCode).RVReference);
                    TlfList[a].Status = reversaltrancodedto.Status;
                    TlfList[a].ReferenceVoucherNo = GeneratedEno;
                }
            }
            else
            {
                throw new Exception("MV30010"); //This Register No is not Today Transaction
            }
        }

        private string GetGeneratedEnoLocal(string MaxItem, int UpdateUserID, string BranchCode)
        {
            DateTime sys001 = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), BranchCode ,true});

            string day = sys001.Day.ToString().PadLeft(2, '0');
            string month = sys001.Month.ToString().PadLeft(2, '0');
            string year = sys001.Year.ToString().Substring(2);

            string Eno = this.CodeGenerator.GetGenerateCode(MaxItem, string.Empty, UpdateUserID, BranchCode, new object[] { day, month, year });

            return Eno;
        }

        #endregion
    }
}
