//----------------------------------------------------------------------
// <copyright file="TLMSVE00065.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2014-02-12</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Windows.Core.Service;
using Spring.Transaction;
using Ace.Windows.CXServer.Utt;
using Spring.Transaction.Interceptor;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Cbs.Cx.Com.Dmd;
using System.Linq;
using Ace.Cbs.Tcm.Ctr.Dao;

namespace Ace.Cbs.Tcm.Sve
{
   public class TCMSVE00065:BaseService,ITCMSVE00065
   {
       #region "Properties"
       private ITCMDAO00052 DailyReportDAO { get; set; }
       private ICXDAO00010 DataGenerateDAO { get; set; }
       #endregion

       #region "Public Methods"
       public TCMDTO00052 SelectDailyReport(TCMDTO00052 dailyreportDTO,DateTime datetime,string currency,string budgetMonth,int createdUserId)
       {
           TCMDTO00052 drpDTO = new TCMDTO00052();
           //this.SaveorUpdateDailyReport(dailyreportDTO, datetime, currency,budgetMonth, true);
           drpDTO = this.DailyReportDAO.SelectAllDailyReport(datetime,currency);
           if (drpDTO == null)
           {
               this.SaveorUpdateDailyReport(dailyreportDTO, datetime, currency, budgetMonth, true,createdUserId);
               drpDTO = this.DailyReportDAO.SelectAllDailyReport(datetime, currency);
           }
           return drpDTO;
       }

       [Transaction(TransactionPropagation.Required)]
       public void SaveorUpdateDailyReport(TCMDTO00052 dailyreportDTO,DateTime datetime,string currency,string budgetMonth,bool isFormLoad,int createdUserId)
       {
           try
           {
               if (isFormLoad==false)
               {
                   int update = this.DailyReportDAO.UpdateDailyReport(dailyreportDTO);
                   this.ServiceResult.ErrorOccurred = false;
                   this.ServiceResult.MessageCode = "MI90002";
               }
               else
               {
                   TCMDTO00052 SPDTO = this.DataGenerateDAO.SelectDailyClosing(datetime.ToString("yyyy/MM/dd"), budgetMonth,currency);
                   this.DeleteDailyReport(SPDTO);
                   this.SaveOrDailyReportData(SPDTO, currency,createdUserId);                  
               }
           }
           catch (Exception ex)
           {
               this.ServiceResult.ErrorOccurred = true;
               this.ServiceResult.MessageCode = "ME90001";
               throw new Exception(this.ServiceResult.MessageCode);
           }
           //return dailyreport;
       }

       #endregion

       #region "Private Methods"
       [Transaction(TransactionPropagation.Required)]
       private void SaveOrDailyReportData(TCMDTO00052 DTO,string currency,int createdUserId)
       {
           TCMDTO00052 DRDTO = this.DailyReportDAO.SelectDailyReportData(currency);
           if (DRDTO == null)
           {
               DTO.DATE_TIME = DateTime.Now;
               DTO.CreatedUserId = createdUserId;
               //DTO.CreatedUserId = CurrentUserEntity.CurrentUserID;
               DTO.CreatedDate = DateTime.Now;
               this.Save(DTO);
           }
           else
           {
               DRDTO.DATE_TIME = DateTime.Now;
               DRDTO.UpdatedUserId = createdUserId;
               //DRDTO.UpdatedUserId = CurrentUserEntity.CurrentUserID;
               DRDTO.UpdatedDate = DateTime.Now;
               this.Update(DRDTO);
           }
       }
       [Transaction(TransactionPropagation.Required)]
       private void DeleteDailyReport(TCMDTO00052 dto)
       {
           try
           {
               this.DailyReportDAO.DeleteData(dto.CUR);
               this.ServiceResult.ErrorOccurred = false;
           }
           catch (Exception)
           {
               this.ServiceResult.ErrorOccurred = true;
               this.ServiceResult.MessageCode = CXMessage.MI50004;
               throw new Exception();
           }
       }

       [Transaction(TransactionPropagation.Required)]
       private void Save(TCMDTO00052 dto)
       {
           try
           {
               TCMORM00052 dailyReport = this.DailyReportDTOToDailyReportORM(dto);
               this.DailyReportDAO.Save(dailyReport);
           }
           catch (Exception)
           {
               this.ServiceResult.ErrorOccurred = true;
               this.ServiceResult.MessageCode = CXMessage.MI50004;
               throw new Exception();
           }
       }

       [Transaction(TransactionPropagation.Required)]
       private void Update(TCMDTO00052 dto)
       {
           try
           {
               this.DailyReportDAO.Update(this.DailyReportDTOToDailyReportORM(dto));
           }
           catch (Exception)
           {
               this.ServiceResult.ErrorOccurred = true;
               this.ServiceResult.MessageCode = CXMessage.MI50004;
               throw new Exception();
           }
       }

       private TCMORM00052 DailyReportDTOToDailyReportORM(TCMDTO00052 dailyReportDTO)
       {
           TCMORM00052 dailyReportORM = new TCMORM00052();
           dailyReportORM.Id = DailyReportDAO.SelectMaxId() + 1;
           dailyReportORM.Cur = dailyReportDTO.CUR;
           dailyReportORM.ReceiptCash = dailyReportDTO.RECEIPTCASH;
           dailyReportORM.ReceiptCashVou = dailyReportDTO.RECEIPTCASHVOU;
           dailyReportORM.ReceiptTransfer = dailyReportDTO.RECEIPTTRANSFER;
           dailyReportORM.ReceiptTransferVou = dailyReportDTO.RECEIPTTRANSFERVOU;
           dailyReportORM.ReceiptClearing = dailyReportDTO.RECEIPTCLEARING;
           dailyReportORM.ReceiptClearingVou = dailyReportDTO.RECEIPTCLEARINGVOU;
           dailyReportORM.PaymentCash = dailyReportDTO.PAYMENTCASH;
           dailyReportORM.PaymentCashVou = dailyReportDTO.PAYMENTCASHVOU;
           dailyReportORM.PaymentTransfer = dailyReportDTO.PAYMENTTRANSFER;
           dailyReportORM.PaymentTransferVou = dailyReportDTO.PAYMENTTRANSFERVOU;
           dailyReportORM.PaymentClearing = dailyReportDTO.PAYMENTCLEARING;
           dailyReportORM.PaymentClearingVou = dailyReportDTO.PAYMENTCLEARINGVOU;
           dailyReportORM.DrawingCash = dailyReportDTO.DRAWINGCASH;
           dailyReportORM.DrawingCashVou = dailyReportDTO.DRAWINGCASHVOU;
           dailyReportORM.DrawingTransfer = dailyReportDTO.DRAWINGTRANSFER;
           dailyReportORM.DrawingTransferVou = dailyReportDTO.DRAWINGTRANSFERVOU;
           dailyReportORM.EncashCash = dailyReportDTO.ENCASHCASH;
           dailyReportORM.EncashCashVou = dailyReportDTO.ENCASHCASHVOU;
           dailyReportORM.EncashTransfer = dailyReportDTO.ENCASHTRANSFER;
           dailyReportORM.EncashTransferVou = dailyReportDTO.ENCASHTRANSFERVOU;
           dailyReportORM.CashInHand = dailyReportDTO.CASHINHAND;
           dailyReportORM.CashWithCBM = dailyReportDTO.CASHWITHCBM;
           dailyReportORM.ACWithOthBank = dailyReportDTO.ACWITHOTHBANK;
           dailyReportORM.CurOpened = dailyReportDTO.CUROPENED;
           dailyReportORM.CurClosed = dailyReportDTO.CURCLOSED;
           dailyReportORM.CurOBal = dailyReportDTO.CUROBAL;
           dailyReportORM.CurTotal = dailyReportDTO.CURTOTAL;
           dailyReportORM.CurDep = dailyReportDTO.CURDEP;
           dailyReportORM.CurWith = dailyReportDTO.CURWITH;
           dailyReportORM.SavOpened = dailyReportDTO.SAVOPENED;
           dailyReportORM.SavClosed = dailyReportDTO.SAVCLOSED;
           dailyReportORM.SavOBal = dailyReportDTO.SAVOBAL;
           dailyReportORM.SavTotal = dailyReportDTO.SAVTOTAL;
           dailyReportORM.SavWith = dailyReportDTO.SAVWITH;
           dailyReportORM.SavDep = dailyReportDTO.SAVDEP;
           dailyReportORM.CalOpened = dailyReportDTO.CALOPENED;
           dailyReportORM.CalClosed = dailyReportDTO.CALCLOSED;
           dailyReportORM.CalDep = dailyReportDTO.CALDEP;
           dailyReportORM.CalOBal = dailyReportDTO.CALOBAL;
           dailyReportORM.CalTotal = dailyReportDTO.CALTOTAL;
           dailyReportORM.CalWith = dailyReportDTO.CALWITH;
           dailyReportORM.FixOpened = dailyReportDTO.FIXOPENED;
           dailyReportORM.FixClosed = dailyReportDTO.FIXCLOSED;
           dailyReportORM.FixDep = dailyReportDTO.FIXDEP;
           dailyReportORM.FixOBal = dailyReportDTO.FIXOBAL;
           dailyReportORM.FixTotal = dailyReportDTO.FIXTOTAL;
           dailyReportORM.FixWith = dailyReportDTO.FIXWITH;
           dailyReportORM.Date_Time = dailyReportDTO.DATE_TIME;
           return dailyReportORM;
       }
       #endregion
    }
}
