using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Tcm.Dao;
using Ace.Cbs.Tcm.Ctr.Dao;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXServer.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.Core.Utt;
using AutoMapper;
using Spring.Data.NHibernate.Support;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Tcm.Sve
{
    public class TCMSVE00052 : BaseService, ITCMSVE00052
    {
        public ITCMDAO00052 DailyReportDAO { get; set; }
        public ICXDAO00010 ViewDAO { get; set; }

        public TCMORM00052 GetORM(TCMDTO00052 dto)
        {
            TCMORM00052 orm = new TCMORM00052();
            orm.Id = DailyReportDAO.SelectMaxId() + 1;
            orm.Cur = dto.CUR;
            orm.ReceiptCash = dto.RECEIPTCASH;
            orm.ReceiptCashVou = dto.RECEIPTCASHVOU;
            orm.ReceiptTransfer = dto.RECEIPTTRANSFER;
            orm.ReceiptTransferVou = dto.RECEIPTTRANSFERVOU;
            orm.ReceiptClearing = dto.RECEIPTCLEARING;
            orm.ReceiptClearingVou = dto.RECEIPTCLEARINGVOU;
            orm.PaymentCash = dto.PAYMENTCASH;
            orm.PaymentCashVou = dto.PAYMENTCASHVOU;
            orm.PaymentTransfer = dto.PAYMENTTRANSFER;
            orm.PaymentTransferVou = dto.PAYMENTTRANSFERVOU;
            orm.PaymentClearing = dto.PAYMENTCLEARING;
            orm.PaymentClearingVou = dto.PAYMENTCLEARINGVOU;
            orm.DrawingCash = dto.DRAWINGCASH;
            orm.DrawingCashVou = dto.DRAWINGCASHVOU;
            orm.DrawingTransfer = dto.DRAWINGTRANSFER;
            orm.DrawingTransferVou = dto.DRAWINGTRANSFERVOU;
            orm.EncashCash = dto.ENCASHCASH;
            orm.EncashCashVou = dto.ENCASHCASHVOU;
            orm.EncashTransfer = dto.ENCASHTRANSFER;
            orm.EncashTransferVou = dto.ENCASHTRANSFERVOU;
            orm.CashInHand = dto.CASHINHAND;
            orm.CashWithCBM = dto.CASHWITHCBM;
            orm.ACWithOthBank = dto.ACWITHOTHBANK;
            orm.CurOpened = dto.CUROPENED;
            orm.CurClosed = dto.CURCLOSED;
            orm.CurTotal = dto.CURTOTAL;
            orm.CurOBal = dto.CUROBAL;
            orm.CurDep = dto.CURDEP;
            orm.CurWith = dto.CURWITH;
            orm.SavOpened = dto.SAVOPENED;
            orm.SavClosed = dto.SAVCLOSED;
            orm.SavTotal = dto.SAVTOTAL;
            orm.SavOBal = dto.SAVOBAL;
            orm.SavDep = dto.SAVDEP;
            orm.SavWith = dto.SAVWITH;
            orm.CalOpened = dto.CALOPENED;
            orm.CalClosed = dto.CALCLOSED;
            orm.CalTotal = dto.CALTOTAL;
            orm.CalOBal = dto.CALOBAL;
            orm.CalDep = dto.CALDEP;
            orm.CalWith = dto.CALWITH;
            orm.FixOpened = dto.FIXOPENED;
            orm.FixClosed = dto.FIXCLOSED;
            orm.FixTotal = dto.FIXTOTAL;
            orm.FixOBal = dto.FIXOBAL;
            orm.FixDep = dto.FIXDEP;
            orm.FixWith = dto.FIXWITH;
            orm.Date_Time = dto.DATE_TIME;
            orm.Active = true;
            orm.CreatedUserId = dto.CreatedUserId;
            orm.CreatedDate = DateTime.Now;

            return orm;
        }

        public TCMDTO00052 AddAllData(TCMDTO00052 DTO, TCMDTO00052 DTOView)
        {
            DTO.D1_CNGLOAN = DTOView.D1_CNGLOAN;
            DTO.D1_OD = DTOView.D1_OD;
            DTO.D1_OTHERLOAN = DTOView.D1_OTHERLOAN;
            DTO.D1_STAFFLOAN = DTOView.D1_STAFFLOAN;
            DTO.R_0_CNGLOAN = DTOView.R_0_CNGLOAN;
            DTO.R_0_OD = DTOView.R_0_OD;
            DTO.R_0_OTHERLOAN = DTOView.R_0_OTHERLOAN;
            DTO.R_0_STAFFLOAN = DTOView.R_0_STAFFLOAN;
            DTO.R_1_CNGLOAN = DTOView.R_1_CNGLOAN;
            DTO.R_1_OD = DTOView.R_1_OD;
            DTO.R_1_OTHERLOAN = DTOView.R_1_OTHERLOAN;
            DTO.R_1_STAFFLOAN = DTOView.R_1_STAFFLOAN;
            DTO.R_2_CNGLOAN = DTOView.R_2_CNGLOAN;
            DTO.R_2_OD = DTOView.R_2_OD;
            DTO.R_2_OTHERLOAN = DTOView.R_2_OTHERLOAN;
            DTO.R_2_STAFFLOAN = DTOView.R_2_STAFFLOAN;
            DTO.A1_OUTSTANDING = DTOView.A1_OUTSTANDING;
            DTO.A2_CNGLOAN = DTOView.A2_CNGLOAN;
            DTO.A3_OD = DTOView.A3_OD;
            DTO.A4_OUTSTANDING = DTOView.A4_OUTSTANDING;

            return DTO;
        }

        #region Method

        public TCMDTO00052 SelectDailyClosingbySP(string rDATE, string bUDMONTH, string cUR,int createdUserId)
        {
            //TCMDTO00052 SPDTO = this.ViewDAO.SelectDailyClosing(rDATE, bUDMONTH, cUR);
            //this.DeleteDailyReport(SPDTO);
            //this.SelectDailyReportData(SPDTO, cUR);
            //TCMDTO00052 dailyDTO = this.SelectViewData(cUR, DateTime.Now);
            //return dailyDTO;
          this.SelectDailyClosing(rDATE, bUDMONTH, cUR,createdUserId);
          TCMDTO00052 dailyDTO = this.SelectViewData(cUR, DateTime.Now);
          return dailyDTO;
        }

          [Transaction]
        private void SelectDailyClosing(string rDATE, string bUDMONTH, string cUR,int createdUserId)
        {
            TCMDTO00052 SPDTO = this.ViewDAO.SelectDailyClosing(rDATE, bUDMONTH, cUR);
            this.DeleteDailyReport(SPDTO);
            this.SelectDailyReportData(SPDTO, cUR,createdUserId);            
            //TCMDTO00052 dailyDTO=this.SelectViewData(cUR,DateTime.Now);
            //return dailyDTO;                      
        }

      
        private void SelectDailyReportData(TCMDTO00052 DTO, string currency,int createdUserId)
        {
            TCMDTO00052 DRDTO = this.DailyReportDAO.SelectDailyReportData(currency);
            if (DRDTO == null)
            {
                DTO.DATE_TIME = DateTime.Now;
                //DTO.CreatedUserId = CurrentUserEntity.CurrentUserID;
                DTO.CreatedUserId = createdUserId;
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
                throw new Exception(this.ServiceResult.MessageCode);
            }
        }

        [Transaction]
        private void Save(TCMDTO00052 dto)
        {
            try
            {
                TCMORM00052 dailyReport = GetORM(dto);
                this.DailyReportDAO.Save(dailyReport);
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MI50004;
                throw new Exception(this.ServiceResult.MessageCode);
            }
        }

        [Transaction(TransactionPropagation.Required)]
        private void Update(TCMDTO00052 dto)
        {
            try
            {
                this.DailyReportDAO.Update(GetORM(dto));
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MI50004;
                throw new Exception(this.ServiceResult.MessageCode);
            }
        }

       
        private TCMDTO00052 SelectViewData(string currency, DateTime date)
        {
            TCMDTO00052 dto = this.DailyReportDAO.SelectViewDate(currency, date);
            return dto;
        } 
        #endregion
    }
}
