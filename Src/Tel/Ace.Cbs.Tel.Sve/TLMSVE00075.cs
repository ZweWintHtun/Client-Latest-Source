//----------------------------------------------------------------------
// <copyright file="TLMSVE00075.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2014-07-14</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Dto;
using Spring.Transaction;
using Spring.Transaction.Interceptor;

namespace Ace.Cbs.Tel.Sve
{
  public class TLMSVE00075:BaseService,ITLMSVE00075
  {
      #region "DAO Properties"
      private IPFMDAO00054 TlfDAO { get; set; }
      private ICXDAO00006 CledgerDAO { get; set; }
      private ITLMDAO00015 CashDenoDAO { get; set; }
      private ITLMDAO00009 DepoDenoDAO { get; set; }
      private ITLMDAO00004 IBLTLFDAO { get; set; }

      private DateTime SettlementDate { get; set; }
      private decimal Rate { get; set; }
      private string status = "P";
      private string multiporefund = "Multi PO Refund";
      private string onlinemultiwithdraw = "Online Multi Withdrawal";
      private string multiwithdraw = "Multi Withdrawal";
      private string ibl = "IBL";
      private string pstatus = "PORCS";
      #endregion

      #region "Public Methods"
      public PFMDTO00054 isValidEntryNo(string entryNo, string branchCode)
      {
          PFMDTO00054 tlfDTO = new PFMDTO00054();
          List<PFMDTO00054> tlfDTOList = new List<PFMDTO00054>();
          /* For Single PO */
          if (!entryNo.StartsWith("G"))
          {
              //tlfDTO = this.TlfDAO.SelectTlfDataByEntryNo(branchCode, entryNo);
              tlfDTOList = this.TlfDAO.SelectTlfListDataByEntryNo(branchCode, entryNo).ToList();
              //if (tlfDTOList.Count == 1)
              //{
              //    tlfDTO = tlfDTOList[0];
              //}
              //if (tlfDTOList.Count > 1)
              //{
              //    tlfDTO = tlfDTOList[0];
              //    tlfDTO.Amount = tlfDTO.Amount + tlfDTOList[1].Amount;


              //}
              if (tlfDTOList.Count > 0)
              {
                  if (tlfDTOList.Count > 1)
                  {
                      tlfDTO = tlfDTOList[0];
                      tlfDTO.Amount = tlfDTO.Amount + tlfDTOList[1].Amount;


                  }
                  else
                  {
                      tlfDTO = tlfDTOList[0];
                  }
              }
              else
              {
                  //tlfDTO = null;
                  return tlfDTO;
              }
              #region oldcode
              if (tlfDTO.OtherBankChq != null && tlfDTO.OtherBankChq !=string.Empty)
              {
                  if (tlfDTO.OtherBankChq.ToString().StartsWith("PO"))
                  {
                      tlfDTO.Status = "SinglePO";
                  }
              }
              else if (tlfDTO.AccountNo != null && tlfDTO.AccountNo != string.Empty)
              {
                  if (tlfDTO.AccountNo.Length == 6)
                  {
                      tlfDTO.Status = "DomesticDebit";
                  }
              }
              if (tlfDTO != null)
              {
                  object account = this.CledgerDAO.GetClosedAccountByAccountNo(tlfDTO.AccountNo);
                  if (account != null)
                  {
                      this.ServiceResult.ErrorOccurred = true;
                      this.ServiceResult.MessageCode = CXMessage.MI00065;//"This Entry No. is made by last payment!"
                  }
                  //if (this.CashDenoDAO.GetCashDenoInfo(entryNo, status, branchCode).Count > 0)
                  if (this.CashDenoDAO.GetCashDenoInfoByIsNotNullCashDate(entryNo, status, branchCode).Count > 0)  //edited by ASDA
                  {
                      this.ServiceResult.ErrorOccurred = true;
                      this.ServiceResult.MessageCode = CXMessage.MI00066; //"This Entry No. has already made Denomination Entry !"                     
                  }
                  IList<TLMDTO00009> Depodeno = new List<TLMDTO00009>();
                  Depodeno = this.DepoDenoDAO.SelectAccountTypesByTlf_Eno(entryNo, branchCode);
                  if (Depodeno.Count > 0)  //
                  {
                      if (Depodeno[0].GroupNo != null)
                      {
                          this.ServiceResult.ErrorOccurred = true;
                          this.ServiceResult.MessageCode = CXMessage.MI90013;  //Please Enter GroupNo for Multiple Transaction
                      }
                  }
              }
              else
              {
                  //Service Error =True
                  this.ServiceResult.ErrorOccurred = true;
                  tlfDTO = null;
                  this.ServiceResult.MessageCode = "MI30016";
              }

              if (!string.IsNullOrEmpty(entryNo) && entryNo.Substring(0, 3) == "IBL")
              {
                  string eno = this.IBLTLFDAO.SelectDistinctAccountNoByEno(entryNo, branchCode, "CD%");
                  tlfDTO.AccountNo = eno;
                  tlfDTO.Status = "";
              }

              #endregion

              #region editedby SAI
              //if (tlfDTOList != null)
              //{
              //    object account = this.CledgerDAO.GetClosedAccountByAccountNo(tlfDTOList[0].AccountNo);
              //    if (account != null)
              //    {
              //        this.ServiceResult.ErrorOccurred = true;
              //        this.ServiceResult.MessageCode = CXMessage.MI00065;//"This Entry No. is made by last payment!"
              //    }
              //    //if (this.CashDenoDAO.GetCashDenoInfo(entryNo, status, branchCode).Count > 0)
              //    if (this.CashDenoDAO.GetCashDenoInfoByIsNotNullCashDate(entryNo, status, branchCode).Count > 0)  //edited by ASDA
              //    {
              //        this.ServiceResult.ErrorOccurred = true;
              //        this.ServiceResult.MessageCode = CXMessage.MI00066; //"This Entry No. has already made Denomination Entry !"                     
              //    }
              //    IList<TLMDTO00009> Depodeno = new List<TLMDTO00009>();
              //    Depodeno = this.DepoDenoDAO.SelectAccountTypesByTlf_Eno(entryNo, branchCode);
              //    if (Depodeno.Count > 0)  //
              //    {
              //        if (Depodeno[0].GroupNo != null)
              //        {
              //            this.ServiceResult.ErrorOccurred = true;
              //            this.ServiceResult.MessageCode = CXMessage.MI90013;  //Please Enter GroupNo for Multiple Transaction
              //        }
              //    }
              //}
              //else
              //{
              //    //Service Error =True
              //    this.ServiceResult.ErrorOccurred = true;
              //    tlfDTOList = null;
              //    this.ServiceResult.MessageCode = "MI30016";
              //}

              //if (!string.IsNullOrEmpty(entryNo) && entryNo.Substring(0, 3) == "IBL")
              //{
              //    string eno = this.IBLTLFDAO.SelectDistinctAccountNoByEno(entryNo, branchCode, "CD%");
              //    tlfDTO.AccountNo = eno;
              //}
              #endregion

          } 
         
          else
          {
              if (this.CashDenoDAO.GetCashDenoInfoByIsNotNullCashDate(entryNo, status, branchCode).Count > 0)
              {
                  this.ServiceResult.ErrorOccurred = true;
                  this.ServiceResult.MessageCode = CXMessage.MI00066; //"This Entry No. has already made Denomination Entry !"                     
              }            
              else
              {
                  IList<TLMDTO00015> CashDenoDTOs = new List<TLMDTO00015>();
                  IList<TLMDTO00009> DepodenoDTOs = new List<TLMDTO00009>();
                  CashDenoDTOs = this.CashDenoDAO.GetCashDenoInfo(entryNo, status, branchCode);
                  DepodenoDTOs = this.DepoDenoDAO.SelectAccountTypesByGroupNo(entryNo, branchCode);
                  /* For Multiple PO*/
                  if (CashDenoDTOs.Count > 0 && DepodenoDTOs.Count > 0 && DepodenoDTOs[0].AccountType.StartsWith("PO"))
                  {
                      int i = 0;
                      while (i < DepodenoDTOs.Count)
                      {
                          tlfDTO.Amount = tlfDTO.Amount + DepodenoDTOs[i].Amount;
                          tlfDTO.OtherBank = DepodenoDTOs[i].Currency;
                          tlfDTO.ReceiptNo = multiporefund;
                          tlfDTO.Status = status;
                          i++;
                      }
                  }
                  /* For Multiple withdrawls*/
                  else if (CashDenoDTOs.Count > 0)
                  {
                      int i = 0;
                      while (i < CashDenoDTOs.Count)
                      {
                          tlfDTO.Amount = CashDenoDTOs[i].Amount;
                          tlfDTO.OtherBank = CashDenoDTOs[i].Currency;
                          tlfDTO.ReceiptNo = DepodenoDTOs[i].AccountType.Length == 16 ? multiporefund : DepodenoDTOs[i].Tlf_Eno.Substring(0, 3) == ibl ? onlinemultiwithdraw : multiwithdraw;
                          tlfDTO.Status = DepodenoDTOs[i].AccountType.Length == 16 ? pstatus : status;
                          i++;
                      }
                  }
              }
          }
          return tlfDTO;
      }

      [Transaction(TransactionPropagation.Required)]
      public void SaveorUpdate(PFMDTO00054 cashDeNoDTO, CXDTO00001 denoString)
      {
          TLMORM00015 cashDenoEntity = this.GetCashDeno(cashDeNoDTO, denoString);
        
          try
          {
              //if (!string.IsNullOrEmpty(cashDeNoDTO.VoucherStatus) && cashDeNoDTO.VoucherStatus.Contains("PORCS"))
              //{
              //    this.CashDenoDAO.Save(cashDenoEntity);
              //}
              //if (!string.IsNullOrEmpty(cashDeNoDTO.VoucherStatus) && cashDeNoDTO.VoucherStatus.Contains("SinglePO"))
              //{
              //    this.CashDenoDAO.Save(cashDenoEntity);
              //}
              if (!string.IsNullOrEmpty(cashDeNoDTO.VoucherStatus) && cashDeNoDTO.VoucherStatus.Contains("DomesticDebit"))//For Domestic Credit Voucher
              {
                  cashDenoEntity.AccountType = cashDeNoDTO.AccountNo;//Edited by HOW
                  this.CashDenoDAO.Save(cashDenoEntity);
              }

              else
              {               
                  TLMDTO00015 updatecashDenoDTO=new TLMDTO00015();
                  updatecashDenoDTO.TlfEntryNo=cashDeNoDTO.Eno;
                  updatecashDenoDTO.Status=this.status;
                  updatecashDenoDTO.DenoDetail=denoString.DenoString;
                  updatecashDenoDTO.DenoRate=denoString.DenoRateString;
                  updatecashDenoDTO.Rate=this.Rate;
                  updatecashDenoDTO.AdjustAmount=0;
                  updatecashDenoDTO.UserNo=cashDeNoDTO.UserNo;
                  updatecashDenoDTO.CounterNo = cashDenoEntity.CounterNo;
                  updatecashDenoDTO.AllDenoRate=string.Empty;
                  updatecashDenoDTO.UpdatedUserId=cashDeNoDTO.CreatedUserId;
                  updatecashDenoDTO.SourceBranchCode = cashDeNoDTO.SourceBranchCode;
                  updatecashDenoDTO.VirtualStatus = "CashDeno";
                  updatecashDenoDTO.SettlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), cashDeNoDTO.SourceBranchCode ,true });
                  this.CashDenoDAO.UpdateCashDenoByGroupNo(updatecashDenoDTO);
              }
              this.ServiceResult.ErrorOccurred = false;              
          }
          catch
          {
              this.ServiceResult.ErrorOccurred = true;
              this.ServiceResult.MessageCode = "ME90000";
          }        
      }
      #endregion

      #region "Helper Method"
      private TLMORM00015 GetCashDeno(PFMDTO00054 cashDeNoDTO, CXDTO00001 denoString)
      {
          this.SettlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), cashDeNoDTO.SourceBranchCode ,true });
          if(this.SettlementDate==null)
          {
              this.ServiceResult.ErrorOccurred = true;
              this.ServiceResult.MessageCode = CXMessage.ME00021; // Client Data Not Found.
              return null;
          }
          this.Rate = CXCOM00010.Instance.GetExchangeRate(cashDeNoDTO.CurrencyCode, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType));
          if (this.Rate == 0)
          {
              this.ServiceResult.ErrorOccurred = true;
              this.ServiceResult.MessageCode = CXMessage.ME00021; // Client Data Not Found.
              return null;
          }
          TLMORM00015 cashDeno = new TLMORM00015();
          cashDeno.TlfEntryNo = cashDeNoDTO.Eno;
         // cashDeno.AccountType = cashDeNoDTO.AccountNo;
        cashDeno.AccountType = cashDeNoDTO.PaymentOrderNo;
          cashDeno.Amount = cashDeNoDTO.Amount;
          cashDeno.UserNo = cashDeNoDTO.UserNo;
          cashDeno.Status = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.PaymentCashStatus);
          cashDeno.CounterNo = denoString.CounterNo;
          cashDeno.SourceBranchCode = cashDeNoDTO.SourceBranchCode;
          cashDeno.CashDate = DateTime.Now;
          cashDeno.SettlementDate = this.SettlementDate;
          cashDeno.DenoDetail = denoString.DenoString;
          cashDeno.DenoRate = denoString.DenoRateString;
          cashDeno.DenoRefundDetail = denoString.RefundString;
          cashDeno.DenoRefundRate = denoString.RefundRateString;
          cashDeno.Currency = cashDeNoDTO.CurrencyCode;
          cashDeno.AdjustAmount = 0;
          cashDeno.Rate = this.Rate;
          cashDeno.Active = true;
          cashDeno.CreatedUserId = cashDeNoDTO.CreatedUserId;
          cashDeno.CreatedDate = DateTime.Now;
          cashDeno.Reverse = false;
          return cashDeno;
      }
      #endregion
  }
}
