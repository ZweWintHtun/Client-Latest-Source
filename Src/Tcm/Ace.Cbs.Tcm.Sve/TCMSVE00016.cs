using System;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tcm.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Windows.Admin.Contracts.Dao;
using System.Collections.Generic;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Mnm.Ctr.Dao;
using Ace.Windows.Core.Utt;
//using Ace.Windows.Ix.Core.Ctr;

namespace Ace.Cbs.Tcm.Sve
{
    public class TCMSVE00016 : BaseService, ITCMSVE00016
    {
        #region Properties

        public IPFMDAO00056 SysDAO { get; set; }
        public IFormatDefinitionDAO FormatDefintionDAO { get; set; }
        public IPFMDAO00028 CledgerDAO { get; set; }
        public IPFMDAO00036 Cs99DAO { get; set; }
        public ITLMDAO00013 CashSetupDAO { get; set; }
        public ITLMDAO00015 CashDenoDAO { get; set; }
        public ITCMDAO00009 CashClosingDAO { get; set; }

        //Added by HWKO (24-Oct-2017)
        private IPFMDAO00057 newsetupDAO;
        public IPFMDAO00057 NewsetupDAO
        {
            get { return this.newsetupDAO; }
            set { this.newsetupDAO = value; }
        }

        private ICXDAO00014 ccoaDAO;
        public ICXDAO00014 CcoaDAO
        {
            get { return this.ccoaDAO; }
            set { this.ccoaDAO = value; }
        }

        private IMNMDAO00005 tod_ScharedDAO;
        public IMNMDAO00005 Tod_ScharedDAO
        {
            get { return this.tod_ScharedDAO; }
            set { this.tod_ScharedDAO = value; }
        }
        //End Region

        public IList<TLMDTO00013> CashCurrencyList { get; set; }
        public IList<TLMDTO00013> CounterCurrencyList { get; set; }
        public IList<TLMDTO00013> CounterCashList { get; set; }
        public IList<TLMDTO00015> CashDenoList { get; set; }
        public IList<TLMDTO00012> DenoList { get; set; }
        public IList<TCMDTO00009> CashClosingList { get; set; }
        TCMORM00009 CashClosingEntity;
        PFMORM00036 Cs99Entity;

        public decimal paymentAmount { get; set; }
        public decimal receivedAmount { get; set; }
        public decimal homeAmount { get; set; }
        public decimal calculateAmount { get; set; }

        public DateTime NextSettlementDate { get; set; }
        public DateTime CurrentSettlementDate { get; set; }
        public int UserId { get; set; }
        public string BranchCode { get; set; }
        public DateTime PreviousSettlementDate { get; set; }
        public DateTime IDate { get; set; }
        public DateTime MaxDate { get; set; }

        #endregion

        #region Main Method

        [Transaction(TransactionPropagation.Required)]
        public TLMDTO00012 CutOffAndClosing(string branchCode, DateTime NextSettlementDate, DateTime currentSettlementDate, int userId)
        {
            TLMDTO00012 result = new TLMDTO00012();
            try
            {
                this.BranchCode = branchCode;
                this.NextSettlementDate = NextSettlementDate;
                this.CurrentSettlementDate = currentSettlementDate;
                this.UserId = userId;

                //this.CutOff();  
                result = this.CashClosing();

                this.ServiceResult.ErrorOccurred = false;
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME90043;
                throw new Exception(this.ServiceResult.MessageCode);
            }
            return result;
        }

        #endregion

        #region Helper Methods

        [Transaction()]
        private void CutOff()
        {
            //DateTime[] date = { this.NextSettlementDate, this.CurrentSettlementDate };
            string status = string.Empty;
            this.CledgerDAO.UpdateDOBal(this.BranchCode, DateTime.Now, this.UserId);
            this.SysDAO.UpdateSysDateForCutOff(this.BranchCode, this.NextSettlementDate, this.CurrentSettlementDate, this.UserId);
            this.FormatDefintionDAO.FormatDefinitionMaxValueUpdatebyDay(this.BranchCode, this.UserId, DateTime.Now);

            #region appServerData Update
            //IList<PFMDTO00056> list = this.SysDAO.SelectDataForCutOffandCashClosing("NEXT_SETTLEMENT_DATE", "LAST_SETTLEMENT_DATE", this.BranchCode);
            //foreach (PFMDTO00056 data in list)
            //{
            //    PFMDTO00056 updateRecord = new PFMDTO00056();
            //    updateRecord.Id = data.Id;
            //    updateRecord.Name = data.Name;
            //    updateRecord.SysMonYear = data.SysMonYear;
            //    updateRecord.Status = data.Status;
            //    updateRecord.SysDate = (data.Name == "NEXT_SETTLEMENT_DATE") ? this.NextSettlementDate : this.CurrentSettlementDate;
            //    updateRecord.SysQty = data.SysQty;
            //    updateRecord.BranchCode = data.BranchCode;
            //    updateRecord.Active = data.Active;
            //    updateRecord.TS = data.TS;
            //    updateRecord.CreatedDate = data.CreatedDate;
            //    updateRecord.CreatedUserId = data.CreatedUserId;
            //    updateRecord.UpdatedDate = data.UpdatedDate;
            //    updateRecord.UpdatedUserId = data.UpdatedUserId;

            //    Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "Name", data.Name }, { "Active", true }, { "SourceBr", data.BranchCode} };
            //    CXServiceWrapper.Instance.Invoke<IServerClientDataUpdateService, bool>(x => x.Update("PFMORM00056", updateRecord, whereColumnsandValues));
            //}
            //for (int i = 0; i < date.Length; i++)
            //{
            //    status = (i == 0) ? "NEXT_SETTLEMENT_DATE" : "LAST_SETTLEMENT_DATE";
            //    PFMORM00056 sys001 = new PFMORM00056();
            //    sys001.SysDate = date[i].Date;
            //    Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "Name", status }, { "Active", true }, { "SourceBr", this.BranchCode } };
            //    CXServiceWrapper.Instance.Invoke<IServerClientDataUpdateService, bool>(x => x.Update("PFMORM00056", sys001, whereColumnsandValues));
            //}
            #endregion

        }

        [Transaction()]
        private TLMDTO00012 CashClosing()
        {
            this.PreviousSettlementDate = this.CurrentSettlementDate.AddDays(-1);
            this.IDate = this.PreviousSettlementDate.AddDays(1);
            //this.IDate = this.CurrentSettlementDate.AddDays(1);

            //Cs99DAO.DeleteForCashClosing(this.BranchCode, this.CurrentSettlementDate, this.CurrentSettlementDate, DateTime.Now, this.UserId);
            //Replaced by HMW at 20-4-2-24
            //Cs99DAO.DeleteForCashClosing(this.BranchCode, this.CurrentSettlementDate, this.CurrentSettlementDate.CompareTo(this.PreviousSettlementDate) == 1 ? this.NextSettlementDate : this.NextSettlementDate, DateTime.Now, this.UserId);
            //CashClosingDAO.DeleteForCashClosing(this.BranchCode, this.CurrentSettlementDate, this.CurrentSettlementDate.CompareTo(this.PreviousSettlementDate) == 1 ? this.NextSettlementDate : this.NextSettlementDate, DateTime.Now, this.UserId);

            CashCurrencyList = this.CashSetupDAO.SelectCashSetupForCashClosing();
            CounterCurrencyList = this.CashSetupDAO.SelectCounterInfoForCashClosing(this.BranchCode);

            //CashCurrencyList.Union<TLMDTO00013>(CounterCurrencyList);
            foreach (TLMDTO00013 info in CounterCurrencyList)
            {
                CashCurrencyList.Add(info);
            }

            

            foreach (TLMDTO00013 cashCounterEntity in CashCurrencyList)
            {
                homeAmount = 0;
                this.MaxDate = this.CashClosingDAO.SelectMaximunDate(cashCounterEntity.CurrencyCode, cashCounterEntity.CounterNo, this.BranchCode);
                this.MaxDate = this.MaxDate == default(DateTime) ? PreviousSettlementDate : this.MaxDate;
                DenoList = CXCOM00011.Instance.GetListObject<TLMDTO00012>("Deno.SelectByCurrencyCode", new object[] { cashCounterEntity.CurrencyCode, true });
                this.paymentAmount = 0;
                this.receivedAmount = 0;

                CashClosingList = this.CashClosingDAO.SelectDenoDeatilForCashClosing(cashCounterEntity.CurrencyCode, cashCounterEntity.CounterNo, this.BranchCode, this.MaxDate);

                foreach (TCMDTO00009 cashClosingInfo in CashClosingList)
                {
                    this.receivedAmount += cashClosingInfo.CAmount;
                    this.homeAmount += cashClosingInfo.HomeAmount;
                    DenoList = CXServiceWrapper.Instance.Invoke<ICXSVE00004, IList<TLMDTO00012>>(x => x.GetDenoCalculateAmount(DenoList, cashClosingInfo.DenoDetail, string.Empty, "R"));
                }

                CashDenoList = this.CashDenoDAO.SelectHomeAmountByBranch(this.BranchCode, cashCounterEntity.CurrencyCode, this.CurrentSettlementDate, cashCounterEntity.IsCounter == 1 ? string.Empty : cashCounterEntity.CounterNo, cashCounterEntity.IsCounter == 0 ? string.Empty : cashCounterEntity.CounterNo);

                foreach (TLMDTO00015 cashDenoEntity in CashDenoList)
                {
                    if (cashDenoEntity.Status == "R")
                    {
                        this.receivedAmount += cashDenoEntity.Amount;
                        this.homeAmount += cashDenoEntity.Amount * cashDenoEntity.Rate.Value;
                    }
                    else
                    {
                        this.paymentAmount += cashDenoEntity.Amount;
                        this.homeAmount -= cashDenoEntity.Amount * cashDenoEntity.Rate.Value;
                    }

                    calculateAmount = 0;
                    DenoList = CXServiceWrapper.Instance.Invoke<ICXSVE00004, IList<TLMDTO00012>>(x => x.GetDenoCalculateAmount(DenoList, cashDenoEntity.DenoDetail, cashDenoEntity.DenoRefundDetail, cashDenoEntity.Status));

                }

                calculateAmount = receivedAmount - paymentAmount;

                var denoList = from value in DenoList
                               where value.DenoCount > 0 || value.RefundCount > 0
                               select value;

                if (denoList.Count<TLMDTO00012>() > 0)
                {
                    CXDTO00001 DenoDetail = CXServiceWrapper.Instance.Invoke<ICXSVE00004, CXDTO00001>(x => x.GetDenoString(DenoList, true, this.BranchCode));
                    //if user counter is hasvault(1), V P R (3 lines in CashClosing)
                    //Comment by HMW (20-4-2024)
                    //if (calculateAmount != 0 && cashCounterEntity.HasValut)
                    if (cashCounterEntity.HasValut)
                    {
                        // Added by HWKO (26-Oct-2017)
                        PFMDTO00057 isVaultDto = this.NewsetupDAO.SelectByVariable("ISVAULT");
                        if (isVaultDto.Value == "0")
                        {
                            // Modified by ZMS (2018/09/17) for Budget Month Flexible
                            //string budMonth = CurrentSettlementDate.Month < 4 ? "M" + (CurrentSettlementDate.Month + 9).ToString() : "M" + (CurrentSettlementDate.Month - 3).ToString();
                            string Return = string.Empty;
                            string budMonth = "M" + CcoaDAO.GetBudget_Month_Year_Quarter(3, CurrentSettlementDate, this.BranchCode, Return); // For 2018/09/17 => 6
                            string currency = CounterCurrencyList.FirstOrDefault().CurrencyCode.ToString();
                            string CashAcode = this.Tod_ScharedDAO.GetCoaSetupAccountNo("CASH", this.BranchCode, currency);
                            decimal ccoaAmt = this.CcoaDAO.SelectCurMAmtByAcodeAndDcode(budMonth, CashAcode, this.BranchCode);
                            IDate = CurrentSettlementDate;
                            int day = NextSettlementDate.Subtract(IDate).Days;
                            
                            CashClosingDAO.DeleteForCashClosing(this.BranchCode, IDate, IDate, DateTime.Now, this.UserId);//Added by HMW (20-4-2024)                                
                            do
                            {
                                Int32 maxId = CashClosingDAO.SelectMaxId();
                                maxId += 1;                                
                                this.CashClosingDAO.Save(this.GetCashClosingEntity(maxId, cashCounterEntity.CounterNo, IDate, cashCounterEntity.CurrencyCode, ccoaAmt, DenoDetail.DenoString, ccoaAmt));
                                IDate = IDate.AddDays(1);
                                day--;
                            } while (day != 0);
                        }
                            //End Region
                        else
                        {                            
                            IDate = CurrentSettlementDate;
                            int day = NextSettlementDate.Subtract(IDate).Days;
                            do
                            {
                                Int32 maxId = CashClosingDAO.SelectMaxId();
                                maxId += 1;

                                this.CashClosingDAO.Save(this.GetCashClosingEntity(maxId, cashCounterEntity.CounterNo, IDate, cashCounterEntity.CurrencyCode, calculateAmount, DenoDetail.DenoString, homeAmount));
                                IDate = IDate.AddDays(1);
                                day--;
                            } while (day != 0);
                        }

                    }

                    //if user counter is hasvault(0), V = V+P-R (1 line in Cashclosing)// not yet finish
                    else if (calculateAmount != 0 && !cashCounterEntity.HasValut)
                    {
                        //       MsgBox "Counter No. [" & .Fields("CounterNo").Value & "] 
                        //        has cash balance amount [" & calculateAmount & "]." & vbLf & "
                        //        This Counter is not supposed to have cash balance because there is no vault. 
                        //        Please check it again.", vbInformation, Globalizer.Message_Title
                        //        Exit Function
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = string.Empty;//Counter No.{0} has cash balance amount{1} This Counter is not supposed to have cash balance because there is no vault.Please check it again.
                        TLMDTO00012 result = new TLMDTO00012();
                        result.CounterNo = cashCounterEntity.CounterNo;
                        result.Amount = calculateAmount;
                        // return result;   
                    }
                }

            }

            //Comment by HMW (20-4-2024 : Issue Fix for Initial Setup Case for FVS)
            //Cs99DAO.DeleteForCashClosing(this.BranchCode, this.CurrentSettlementDate, this.CurrentSettlementDate, DateTime.Now, this.UserId);

            //while (CurrentSettlementDate.Day < NextSettlementDate.Day)
            int days = NextSettlementDate.Subtract(CurrentSettlementDate).Days;
            do
            {
                //Comment by HMW (20-4-2024 : Issue Fix for Initial Setup Case for FVS)
                //Cs99DAO.DeleteForCashClosing(this.BranchCode, this.CurrentSettlementDate, this.CurrentSettlementDate, DateTime.Now, this.UserId);
                
                CashClosingList = CashClosingDAO.SelectTotalAmountsForCashClosing(this.BranchCode, this.CurrentSettlementDate);

                //Added by HMW (20-4-2024)
                Cs99DAO.DeleteForCashClosing(this.BranchCode, this.CurrentSettlementDate, this.CurrentSettlementDate, DateTime.Now, this.UserId);  
                foreach (TCMDTO00009 entity in CashClosingList)
                {
                    int maxId = Cs99DAO.SelectMaxId();
                    maxId += 1;                                      
                    Cs99DAO.Save(this.GetCs99Entity(maxId, entity.Cur, entity.TotalCashBalance, entity.TotalHomeAmount));                    
                }
                //Add new by HMW (20-4-2024)
                //TCMDTO00009 cashclosing;
                //int maxId = Cs99DAO.SelectMaxId();
                //maxId += 1;

                //Cs99DAO.Save(this.GetCs99Entity(maxId, cashclosing.Cur, cashclosing.TotalCashBalance, cashclosing.TotalHomeAmount));
                CurrentSettlementDate = CurrentSettlementDate.AddDays(1);
                days--;
            } while (days != 0);

            return new TLMDTO00012();
        }

        private TCMORM00009 GetCashClosingEntity(int maxId, string counterNo, DateTime idate, string currency, decimal amount, string denoDetail, decimal homeAmount)
        {
            CashClosingEntity = new TCMORM00009();
            CashClosingEntity.Id = maxId;
            CashClosingEntity.CounterNo = counterNo;
            CashClosingEntity.Date = idate;
            CashClosingEntity.Currency = currency;
            CashClosingEntity.CAmount = amount;
            CashClosingEntity.DenoDetail = denoDetail;
            CashClosingEntity.HomeAmount = homeAmount;
            CashClosingEntity.SourceBranchCode = this.BranchCode;
            CashClosingEntity.Active = true;
            CashClosingEntity.CreatedDate = DateTime.Now;
            CashClosingEntity.CreatedUserId = this.UserId;

            return CashClosingEntity;
        }

        private PFMORM00036 GetCs99Entity(int maxid, string currency, decimal cashBalance, decimal homeAmount)
        {
            Cs99Entity = new PFMORM00036();
            Cs99Entity.Id = maxid;
            Cs99Entity.Balance = cashBalance;
            Cs99Entity.Date_Time = this.CurrentSettlementDate;
            Cs99Entity.CurrencyCode = currency;
            Cs99Entity.HomeAmount = homeAmount;

            Cs99Entity.SourceBranchCode = this.BranchCode;
            Cs99Entity.Active = true;
            Cs99Entity.CreatedDate = DateTime.Now;
            Cs99Entity.CreatedUserId = this.UserId;

            return Cs99Entity;
        }

        #endregion
    }
}
