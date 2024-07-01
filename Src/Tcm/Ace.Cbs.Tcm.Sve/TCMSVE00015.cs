//----------------------------------------------------------------------
// <copyright file="TCMSVE00015.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Cbs.Tcm.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Mnm.Ctr.Dao;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Windows.Core.Utt;
using Ace.Windows.Admin.Contracts.Dao;


namespace Ace.Cbs.Tcm.Sve
{
    /// <summary>
    /// System ShutDown Service
    /// </summary>
    public class TCMSVE00015 : BaseService, ITCMSVE00015
    {

        public string budgetmonth { get; set; }

        #region DAO
        public ITCMDAO00001 StartDAO { get; set; }
        public IPFMDAO00036 CS99DAO { get; set; }
        public IPFMDAO00041 SetUpDAO { get; set; }
        public IPFMDAO00056 Sys001DAO { get; set; }
        public IPFMDAO00028 CledgerDAO { get; set; }
        public IMNMDAO00022 AdjRemitOiDAO { get; set; }
        public IMNMDAO00023 AdjRemitSchargeDAO { get; set; }
        public IMNMDAO00024 AdjRemitTodSchargeDAO { get; set; }
        public ICXSVE00010 SPDAO { get; set; }
        public ICXDAO00009 ViewDAO { get; set; }
        public ITLMDAO00016 PODAO { get; set; }
        public ITLMDAO00018 LoanDAO { get; set; }
        public IPFMDAO00023 FledgerDAO { get; set; }        

        public IFormatDefinitionDAO FormatDefintionDAO { get; set; }

        #endregion

        #region Helper Method
        public TCMDTO00001 SelectStartBySourceBr(string sourceBr)
        {
            return this.StartDAO.SelectStartBySourceBr(sourceBr);
        }
        #endregion

        #region Main Method

        public bool ShutDown(bool shutdownstatus, string sourceBr, int updatedUserId)
        {
            if (shutdownstatus)
            {

                if (this.CheckAfterRun())
                {
                    this.Delete_ReportTLF_Table(sourceBr);//Added by HMW at 04-Sept-2019 : To fix "Server header data receving error occur".
                    this.Replace_Start(sourceBr, updatedUserId);
                    this.FormatDefintionDAO.FormatDefinitionMaxValueUpdatebyDay(sourceBr, updatedUserId, DateTime.Now);                    
                }
                return true;

            }
            else
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV20077;
                return false;
            }

        }

        public IList<TLMDTO00018> InsuranceExpiredLoansListing(string sourcebr, DateTime sysDate)
        {
            return this.LoanDAO.SelectInsuranceExpiredLoans(sourcebr, sysDate);
        }

        [Transaction(TransactionPropagation.Required)]
        public void Replace_Start(string sourceBr, int updatedUserId)
        {
            try
            {
                this.StartDAO.UpdateStatusBySourceBr(sourceBr, updatedUserId, "I");
                this.SetUpDAO.UpdateDenoStatusBySourceBr(sourceBr, updatedUserId);

                DateTime nextSettlementDate = Ace.Cbs.Cx.Com.Utt.CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate",
                         new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), sourceBr, true });

                DateTime lastSettlementDate = Ace.Cbs.Cx.Com.Utt.CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate",
                      new object[] { "LAST_SETTLEMENT_DATE", sourceBr, true });


                //nextSettlementDate = nextSettlementDate.AddDays(1);
                //lastSettlementDate = lastSettlementDate.AddDays(1);

                this.AdjRemitOiDAO.DeleteAdjRemitOi(sourceBr);
                this.AdjRemitSchargeDAO.DeleteAdjRemitScharge(sourceBr);
                this.AdjRemitTodSchargeDAO.DeleteAdjRemitTodScharge(sourceBr);
                this.SPDAO.Sp_ChangeTables(lastSettlementDate, nextSettlementDate, sourceBr);//Change TLF to MTLF,esc..
                string budget = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode);
                this.SPDAO.Sp_ChangeTables_AllCLedger(lastSettlementDate, nextSettlementDate, sourceBr, budget);

                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MI50006;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool CheckAfterRun()
        {
            PFMDTO00056 sysdto = this.Sys001DAO.SelectAllByNameAndSysDateAndStatus("MONTH_CLOSE", "B");
            if (sysdto != null)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV20080;
                return false;
            }
            else
            {
                return true;
            }
        }

        public IList<PFMDTO00028> DailyReconsile(string sourcebr)
        {
            try
            {
                string budgetmonth = "M" + CXCOM00010.Instance.GetBudgetYear2("M", DateTime.Now);
                IList<PFMDTO00028> cledgerlist = new List<PFMDTO00028>();

                #region Current
                IList<PFMDTO00028> cledgerforcurrent = this.CledgerDAO.SelectSumDoBal(sourcebr, "C");
                if (cledgerforcurrent.Count > 0)
                {
                    foreach (PFMDTO00028 item in cledgerforcurrent)
                    {
                        item.DayOfBalance = item.CurrentBal;
                        item.CurrencyCode = item.AccountNo;
                        decimal dobal = item.DayOfBalance;
                        string acode = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurControl), sourcebr);
                        MNMDTO00010 ccoas = this.CCOABalance(acode, budgetmonth, item.CurrencyCode, sourcebr);
                        PFMDTO00028 cledgerdto = new PFMDTO00028();
                        cledgerdto.AccountNo = "Current";
                        cledgerdto.CurrencyCode = item.CurrencyCode;
                        cledgerdto.GL = ccoas.CCOAAmount;
                        cledgerdto.Sub = dobal;
                        cledgerdto.Diff = cledgerdto.GL - cledgerdto.Sub;
                        if (cledgerdto.Diff != 0)
                        {
                            cledgerdto.Staus = "Not Agree";
                        }
                        else
                        {
                            cledgerdto.Staus = "Agree";

                        }

                        cledgerlist.Add(cledgerdto);
                    }


                }

                #endregion

                #region Saving
                IList<PFMDTO00028> cledgerforsavings = this.CledgerDAO.SelectSumDoBal(sourcebr, "S");
                if (cledgerforsavings.Count > 0)
                {
                    foreach (PFMDTO00028 item in cledgerforsavings)
                    {
                        item.DayOfBalance = item.CurrentBal;
                        item.CurrencyCode = item.AccountNo;
                        decimal dobal = item.DayOfBalance;
                        string acode = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SavControl), sourcebr);

                        PFMDTO00028 cledgerdto = new PFMDTO00028();
                        cledgerdto.AccountNo = "Saving";
                        cledgerdto.CurrencyCode = item.CurrencyCode;
                        MNMDTO00010 ccoas = this.CCOABalance(acode, budgetmonth, item.CurrencyCode, sourcebr);
                        cledgerdto.GL = ccoas.CCOAAmount;
                        cledgerdto.Sub = dobal;
                        cledgerdto.Diff = cledgerdto.GL - cledgerdto.Sub;
                        if (cledgerdto.Diff != 0)
                        {
                            cledgerdto.Staus = "Not Agree";
                        }
                        else
                        {
                            cledgerdto.Staus = "Agree";

                        }
                        cledgerlist.Add(cledgerdto);
                    }
                }

                #endregion

                #region Fixed Deposit
                IList<PFMDTO00023> fledgerforfixeds = this.FledgerDAO.SelectSumFixedBal(sourcebr);
                if (fledgerforfixeds.Count > 0)
                {
                    foreach (PFMDTO00023 item in fledgerforfixeds)
                    {
                        item.FixedBalance = item.FixedBalance;
                        item.CurrencyCode = item.AccountNo;
                        decimal dobal = item.FixedBalance;
                        string acode = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.FixControl), sourcebr);

                        PFMDTO00028 fledgerdto = new PFMDTO00028();
                        fledgerdto.AccountNo = "Fixed Deposit";
                        fledgerdto.CurrencyCode = item.CurrencyCode;
                        MNMDTO00010 ccoas = this.CCOABalance(acode, budgetmonth, item.CurrencyCode, sourcebr);
                        fledgerdto.GL = ccoas.CCOAAmount;
                        fledgerdto.Sub = dobal;
                        fledgerdto.Diff = fledgerdto.GL - fledgerdto.Sub;
                        if (fledgerdto.Diff != 0)
                        {
                            fledgerdto.Staus = "Not Agree";
                        }
                        else
                        {
                            fledgerdto.Staus = "Agree";

                        }
                        cledgerlist.Add(fledgerdto);
                    }
                }

                #endregion

                #region OverDraft
                IList<PFMDTO00028> cledgerforod = this.CledgerDAO.SelectSumDoBalForOD(sourcebr, "C");
                if (cledgerforod.Count > 0)
                {
                    foreach (PFMDTO00028 item in cledgerforod)
                    {
                        item.DayOfBalance = item.CurrentBal;
                        item.CurrencyCode = item.AccountNo;
                        decimal dobal = item.DayOfBalance;
                        string acode = CXCOM00010.Instance.GetCoaSetupAccountNo("OD", sourcebr);

                        PFMDTO00028 cledgerdto = new PFMDTO00028();
                        cledgerdto.AccountNo = "Overdraft";
                        cledgerdto.CurrencyCode = item.CurrencyCode;
                        MNMDTO00010 ccoas = this.CCOABalance(acode, budgetmonth, item.CurrencyCode, sourcebr);
                        cledgerdto.GL = ccoas.CCOAAmount;
                        cledgerdto.Sub = dobal;
                        cledgerdto.Diff = cledgerdto.GL - cledgerdto.Sub;
                        if (cledgerdto.Diff != 0)
                        {
                            cledgerdto.Staus = "Not Agree";
                        }
                        else
                        {
                            cledgerdto.Staus = "Agree";

                        }
                        cledgerlist.Add(cledgerdto);
                    }
                }

                #endregion

                #region Called Deposit
                IList<PFMDTO00028> cledgerforcalleddeposit = this.CledgerDAO.SelectSumDoBal(sourcebr, "L");
                if (cledgerforcalleddeposit.Count > 0)
                {
                    foreach (PFMDTO00028 item in cledgerforcalleddeposit)
                    {
                        item.DayOfBalance = item.CurrentBal;
                        item.CurrencyCode = item.AccountNo;
                        decimal dobal = item.DayOfBalance;
                        string acode = CXCOM00010.Instance.GetCoaSetupAccountNo("CALCONTROL", sourcebr);

                        PFMDTO00028 cledgerdto = new PFMDTO00028();
                        cledgerdto.AccountNo = "Call Deposit";
                        cledgerdto.CurrencyCode = item.CurrencyCode;
                        MNMDTO00010 ccoas = this.CCOABalance(acode, budgetmonth, item.CurrencyCode, sourcebr);
                        cledgerdto.GL = ccoas.CCOAAmount;
                        cledgerdto.Sub = dobal;
                        cledgerdto.Diff = cledgerdto.GL - cledgerdto.Sub;
                        if (cledgerdto.Diff != 0)
                        {
                            cledgerdto.Staus = "Not Agree";
                        }
                        else
                        {
                            cledgerdto.Staus = "Agree";

                        }
                        cledgerlist.Add(cledgerdto);
                    }
                }

                #endregion

                #region Payment Order
                IList<TLMDTO00016> pos = this.PODAO.SelectSumPOAmount(sourcebr);
                if (pos.Count > 0)
                {
                    foreach (TLMDTO00016 item in pos)
                    {


                        decimal dobal = item.Amount;
                        string poacode = CXCOM00010.Instance.GetCoaSetupAccountNo("PO", sourcebr);
                        MNMDTO00010 ccoasforPO = this.CCOABalance(poacode, budgetmonth, item.Currency, sourcebr);

                        string poracode = CXCOM00010.Instance.GetCoaSetupAccountNo("POR", sourcebr);
                        MNMDTO00010 ccoasforPOR = this.CCOABalance(poracode, budgetmonth, item.Currency, sourcebr);

                        string oldporacode = CXCOM00010.Instance.GetCoaSetupAccountNo("OLDPOR", sourcebr);
                        MNMDTO00010 ccoasforOLDPOR = this.CCOABalance(oldporacode, budgetmonth, item.Currency, sourcebr);

                        PFMDTO00028 cledgerdto = new PFMDTO00028();
                        cledgerdto.AccountNo = "Payment Order";
                        cledgerdto.CurrencyCode = item.Currency;

                        cledgerdto.GL = ccoasforPO.CCOAAmount + ccoasforPOR.CCOAAmount + ccoasforOLDPOR.CCOAAmount;
                        cledgerdto.Sub = dobal;
                        cledgerdto.Diff = cledgerdto.GL - cledgerdto.Sub;
                        if (cledgerdto.Diff != 0)
                        {
                            cledgerdto.Staus = "Not Agree";
                        }
                        else
                        {
                            cledgerdto.Staus = "Agree";

                        }
                        cledgerlist.Add(cledgerdto);
                    }
                }

                #endregion

                #region Business Loan
                IList<PFMDTO00028> cledgerforbusinessloan = this.CledgerDAO.SelectSumDoBal(sourcebr, "B");
                if (cledgerforbusinessloan.Count > 0)
                {
                    foreach (PFMDTO00028 item in cledgerforbusinessloan)
                    {
                        item.DayOfBalance = item.CurrentBal;
                        item.CurrencyCode = item.AccountNo;
                        decimal dobal = item.DayOfBalance;
                        string acode = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.BLControl), sourcebr);
                        MNMDTO00010 ccoas = this.CCOABalance(acode, budgetmonth, item.CurrencyCode, sourcebr);
                        PFMDTO00028 cledgerdto = new PFMDTO00028();
                        cledgerdto.AccountNo = "Business Loan";
                        cledgerdto.CurrencyCode = item.CurrencyCode;
                        cledgerdto.GL = ccoas.CCOAAmount;
                        cledgerdto.Sub = dobal;
                        cledgerdto.Diff = cledgerdto.GL - cledgerdto.Sub;
                        if (cledgerdto.Diff != 0)
                        {
                            cledgerdto.Staus = "Not Agree";
                        }
                        else
                        {
                            cledgerdto.Staus = "Agree";

                        }

                        cledgerlist.Add(cledgerdto);
                    }


                }

                #endregion

                #region Hire Purchase
                IList<PFMDTO00028> cledgerforhirepurchase = this.CledgerDAO.SelectSumDoBal(sourcebr, "H");
                if (cledgerforhirepurchase.Count > 0)
                {
                    foreach (PFMDTO00028 item in cledgerforhirepurchase)
                    {
                        item.DayOfBalance = item.CurrentBal;
                        item.CurrencyCode = item.AccountNo;
                        decimal dobal = item.DayOfBalance;
                        string acode = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.HPControl), sourcebr);
                        MNMDTO00010 ccoas = this.CCOABalance(acode, budgetmonth, item.CurrencyCode, sourcebr);
                        PFMDTO00028 cledgerdto = new PFMDTO00028();
                        cledgerdto.AccountNo = "Hire Puchase";
                        cledgerdto.CurrencyCode = item.CurrencyCode;
                        cledgerdto.GL = ccoas.CCOAAmount;
                        cledgerdto.Sub = dobal;
                        cledgerdto.Diff = cledgerdto.GL - cledgerdto.Sub;
                        if (cledgerdto.Diff != 0)
                        {
                            cledgerdto.Staus = "Not Agree";
                        }
                        else
                        {
                            cledgerdto.Staus = "Agree";

                        }

                        cledgerlist.Add(cledgerdto);
                    }


                }

                #endregion

                #region Personal Loan
                IList<PFMDTO00028> cledgerforpersonalloan = this.CledgerDAO.SelectSumDoBal(sourcebr, "P");
                if (cledgerforpersonalloan.Count > 0)
                {
                    foreach (PFMDTO00028 item in cledgerforpersonalloan)
                    {
                        item.DayOfBalance = item.CurrentBal;
                        item.CurrencyCode = item.AccountNo;
                        decimal dobal = item.DayOfBalance;
                        string acode = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.PLControl), sourcebr);
                        MNMDTO00010 ccoas = this.CCOABalance(acode, budgetmonth, item.CurrencyCode, sourcebr);
                        PFMDTO00028 cledgerdto = new PFMDTO00028();
                        cledgerdto.AccountNo = "Personal Loan";
                        cledgerdto.CurrencyCode = item.CurrencyCode;
                        cledgerdto.GL = ccoas.CCOAAmount;
                        cledgerdto.Sub = dobal;
                        cledgerdto.Diff = cledgerdto.GL - cledgerdto.Sub;
                        if (cledgerdto.Diff != 0)
                        {
                            cledgerdto.Staus = "Not Agree";
                        }
                        else
                        {
                            cledgerdto.Staus = "Agree";

                        }

                        cledgerlist.Add(cledgerdto);
                    }


                }

                #endregion

                #region Dealer
                IList<PFMDTO00028> cledgerfordealer = this.CledgerDAO.SelectSumDoBal(sourcebr, "D");
                if (cledgerfordealer.Count > 0)
                {
                    foreach (PFMDTO00028 item in cledgerfordealer)
                    {
                        item.DayOfBalance = item.CurrentBal;
                        item.CurrencyCode = item.AccountNo;
                        decimal dobal = item.DayOfBalance;
                        string acode = CXCOM00010.Instance.GetCoaSetupAccountNo("DLCONTROL", sourcebr);
                        MNMDTO00010 ccoas = this.CCOABalance(acode, budgetmonth, item.CurrencyCode, sourcebr);
                        PFMDTO00028 cledgerdto = new PFMDTO00028();
                        cledgerdto.AccountNo = "Dealer";
                        cledgerdto.CurrencyCode = item.CurrencyCode;
                        cledgerdto.GL = ccoas.CCOAAmount;
                        cledgerdto.Sub = dobal;
                        cledgerdto.Diff = cledgerdto.GL - cledgerdto.Sub;
                        if (cledgerdto.Diff != 0)
                        {
                            cledgerdto.Staus = "Not Agree";
                        }
                        else
                        {
                            cledgerdto.Staus = "Agree";

                        }

                        cledgerlist.Add(cledgerdto);
                    }


                }

                #endregion

                return cledgerlist;
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = ex.Message;
                return null;

            }
        }

        public bool CheckVaultBalance(string sourcebr)
        {
            /* Comment and Modify by HMW at 29-Jan-2020
            string date = DateTime.Now.ToShortDateString();
            PFMDTO00036 cs99dto = this.CS99DAO.GetTopCS99WithoutCurrency(Convert.ToDateTime(date), sourcebr);
             */

            TCMDTO00001 startDTO = this.SelectStartBySourceBr(sourcebr);
            DateTime date = startDTO.Date;

            PFMDTO00036 cs99dto = this.CS99DAO.GetTopCS99WithoutCurrency(date, sourcebr);
            if (cs99dto == null || cs99dto.Balance.Value == 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MC30004;
                return false;
            }

            else
            { return true; }
        }

        //Add by HWKO (18-Jul-2017)
        public bool CheckBLAutoPayment(string sourcebr)
        {
            PFMDTO00056 blAutoPayRun = this.Sys001DAO.SelectSys001Info(sourcebr, "BLMonthly_AutoPay");

            //Logic Changed by HMW (13-June-2019) : For Seperating EOD Process
            #region Normal_Logic

            //if (blAutoPayRun == null || blAutoPayRun.SysDate == null || blAutoPayRun.Status == null)
            //{ return false; }
            //else if (blAutoPayRun.SysDate.Value.ToShortDateString() != DateTime.Now.ToShortDateString() || blAutoPayRun.Status != "Y")
            //{ return false; }
            //else if (blAutoPayRun.SysDate.Value.ToShortDateString() == DateTime.Now.ToShortDateString() || blAutoPayRun.Status == "Y")
            //{ return true; }
            //else
            //{ return false; }

            #endregion

            #region Seperating_EOD_Logic

            TCMDTO00001 startdto = this.StartDAO.SelectStartBySourceBr(sourcebr);
            DateTime systemStartDate = startdto.Date;

            if (blAutoPayRun == null || blAutoPayRun.SysDate == null || blAutoPayRun.Status == null)
            { return false; }
            else if (blAutoPayRun.SysDate.Value.ToShortDateString() != systemStartDate.ToShortDateString() || blAutoPayRun.Status != "Y")
            { return false; }
            else if (blAutoPayRun.SysDate.Value.ToShortDateString() == systemStartDate.ToShortDateString() || blAutoPayRun.Status == "Y")
            { return true; }
            else
            { return false; }

            #endregion
        }

        //Add by HWKO (18-Jul-2017)
        public bool CheckHPAutoPayment(string sourcebr)
        {
            PFMDTO00056 hpAutoPayRun = this.Sys001DAO.SelectSys001Info(sourcebr, "HPMonthly_AutoPay");
            
            //Logic Changed by HMW (13-June-2019) : For Seperating EOD Process
            #region Normal_Logic

            //if (hpAutoPayRun == null || hpAutoPayRun.SysDate == null || hpAutoPayRun.Status == null)
            //{ return false; }
            //else if (hpAutoPayRun.SysDate.Value.ToShortDateString() != DateTime.Now.ToShortDateString() || hpAutoPayRun.Status != "Y")
            //{ return false; }
            //else if (hpAutoPayRun.SysDate.Value.ToShortDateString() == DateTime.Now.ToShortDateString() || hpAutoPayRun.Status == "Y")
            //{ return true; }
            //else
            //{ return false; }

            #endregion

            #region Seperating_EOD_Logic

            TCMDTO00001 startdto = this.StartDAO.SelectStartBySourceBr(sourcebr);
            DateTime systemStartDate = startdto.Date;

            if (hpAutoPayRun == null || hpAutoPayRun.SysDate == null || hpAutoPayRun.Status == null)
            { return false; }
            else if (hpAutoPayRun.SysDate.Value.ToShortDateString() != systemStartDate.ToShortDateString() || hpAutoPayRun.Status != "Y")
            { return false; }
            else if (hpAutoPayRun.SysDate.Value.ToShortDateString() == systemStartDate.ToShortDateString() || hpAutoPayRun.Status == "Y")
            { return true; }
            else
            { return false; }

            #endregion
        }

        //Add by HWKO (18-Jul-2017)
        public bool CheckPLAutoPayment(string sourcebr)
        {
            PFMDTO00056 plAutoPayRun = this.Sys001DAO.SelectSys001Info(sourcebr, "PLMonthly_AutoPay");

            //Logic Changed by HMW (13-June-2019) : For Seperating EOD Process
            #region Normal_Logic

            //if (plAutoPayRun == null || plAutoPayRun.SysDate == null || plAutoPayRun.Status == null)
            //{ return false; }
            //else if (plAutoPayRun.SysDate.Value.ToShortDateString() != DateTime.Now.ToShortDateString() || plAutoPayRun.Status != "Y")
            //{ return false; }
            //else if (plAutoPayRun.SysDate.Value.ToShortDateString() == DateTime.Now.ToShortDateString() || plAutoPayRun.Status == "Y")
            //{ return true; }
            //else
            //{ return false; }

            #endregion

            #region Seperating_EOD_Logic

            TCMDTO00001 startdto = this.StartDAO.SelectStartBySourceBr(sourcebr);
            DateTime systemStartDate = startdto.Date;

            if (plAutoPayRun == null || plAutoPayRun.SysDate == null || plAutoPayRun.Status == null)
            { return false; }
            else if (plAutoPayRun.SysDate.Value.ToShortDateString() != systemStartDate.ToShortDateString() || plAutoPayRun.Status != "Y")
            { return false; }
            else if (plAutoPayRun.SysDate.Value.ToShortDateString() == systemStartDate.ToShortDateString() || plAutoPayRun.Status == "Y")
            { return true; }
            else
            { return false; }

            #endregion
        }

        ////Add by HWKO (18-Jul-2017)
        //public bool CheckBLLateFeeCalculate(string sourcebr)
        //{
        //    DateTime nextSettlementDate;
        //    nextSettlementDate = (DateTime)this.Sys001DAO.SelectSys001Info(sourcebr, "NEXT_SETTLEMENT_DATE").SysDate;

        //    PFMDTO00056 blLateFee = this.Sys001DAO.SelectSys001Info(sourcebr, "BLLateFees_AutoRun");
        //    if (blLateFee == null || blLateFee.SysDate == null || blLateFee.Status == null)
        //    { return false; }
        //    else if (blLateFee.SysDate.Value.ToShortDateString() != nextSettlementDate.AddDays(-1).ToShortDateString() || blLateFee.Status != "Y")
        //    { return false; }
        //    else if (blLateFee.SysDate.Value.ToShortDateString() == nextSettlementDate.AddDays(-1).ToShortDateString() || blLateFee.Status == "Y")
        //    { return true; }
        //    else
        //    { return false; }
        //}

        ////Add by HWKO (18-Jul-2017)
        //public bool CheckHPLateFeeCalculate(string sourcebr)
        //{
        //    DateTime nextSettlementDate;
        //    nextSettlementDate = (DateTime)this.Sys001DAO.SelectSys001Info(sourcebr, "NEXT_SETTLEMENT_DATE").SysDate;

        //    PFMDTO00056 hpLateFee = this.Sys001DAO.SelectSys001Info(sourcebr, "HPLateFees_AutoRun");
        //    if (hpLateFee == null || hpLateFee.SysDate == null || hpLateFee.Status == null)
        //    { return false; }
        //    else if (hpLateFee.SysDate.Value.ToShortDateString() != nextSettlementDate.AddDays(-1).ToShortDateString() || hpLateFee.Status != "Y")
        //    { return false; }
        //    else if (hpLateFee.SysDate.Value.ToShortDateString() == nextSettlementDate.AddDays(-1).ToShortDateString() || hpLateFee.Status == "Y")
        //    { return true; }
        //    else
        //    { return false; }
        //}

        //Add by HWKO (18-Jul-2017)
        //public bool CheckPLLateFeeCalculate(string sourcebr)
        //{
        //    DateTime nextSettlementDate;
        //    nextSettlementDate = (DateTime)this.Sys001DAO.SelectSys001Info(sourcebr, "NEXT_SETTLEMENT_DATE").SysDate;

        //    PFMDTO00056 plLateFee = this.Sys001DAO.SelectSys001Info(sourcebr, "PLLateFees_AutoRun");
        //    if (plLateFee == null || plLateFee.SysDate == null || plLateFee.Status == null)
        //    { return false; }
        //    else if (plLateFee.SysDate.Value.ToShortDateString() != nextSettlementDate.AddDays(-1).ToShortDateString() || plLateFee.Status != "Y")
        //    { return false; }
        //    else if (plLateFee.SysDate.Value.ToShortDateString() == nextSettlementDate.AddDays(-1).ToShortDateString() || plLateFee.Status == "Y")
        //    { return true; }
        //    else
        //    { return false; }
        //}

        //Added by HWKO (16-Nov-2017)
        public bool CheckPLLateFeeAutoVoucherProcessRun(string sourcebr)
        {
            //DateTime nextSettlementDate;
            //nextSettlementDate = (DateTime)this.Sys001DAO.SelectSys001Info(sourcebr, "NEXT_SETTLEMENT_DATE").SysDate;

            PFMDTO00056 plLateFeeAutoPay = this.Sys001DAO.SelectSys001Info(sourcebr, "PLLateFees_AutoPay");

            //Logic Changed by HMW (13-June-2019) : For Seperating EOD Process
            #region Normal_Logic

            //if (plLateFeeAutoPay == null || plLateFeeAutoPay.SysDate == null || plLateFeeAutoPay.Status == null)
            //{ return false; }
            //else if (plLateFeeAutoPay.SysDate.Value.ToShortDateString() != DateTime.Now.ToShortDateString() || plLateFeeAutoPay.Status != "Y")
            //{ return false; }
            //else if (plLateFeeAutoPay.SysDate.Value.ToShortDateString() == DateTime.Now.ToShortDateString() || plLateFeeAutoPay.Status == "Y")
            //{ return true; }
            //else
            //{ return false; }

            #endregion

            #region Seperating_EOD_Logic

            TCMDTO00001 startdto = this.StartDAO.SelectStartBySourceBr(sourcebr);
            DateTime systemStartDate = startdto.Date;

            if (plLateFeeAutoPay == null || plLateFeeAutoPay.SysDate == null || plLateFeeAutoPay.Status == null)
            { return false; }
            else if (plLateFeeAutoPay.SysDate.Value.ToShortDateString() != systemStartDate.ToShortDateString() || plLateFeeAutoPay.Status != "Y")
            { return false; }
            else if (plLateFeeAutoPay.SysDate.Value.ToShortDateString() == systemStartDate.ToShortDateString() || plLateFeeAutoPay.Status == "Y")
            { return true; }
            else
            { return false; }

            #endregion
        }

        ///Added by HWKO (17-Nov-2017)
        public bool CheckBLLateFeeAutoVoucherProcessRun(string sourcebr)
        {
            //DateTime nextSettlementDate;
            //nextSettlementDate = (DateTime)this.Sys001DAO.SelectSys001Info(sourcebr, "NEXT_SETTLEMENT_DATE").SysDate;

            PFMDTO00056 blLateFee = this.Sys001DAO.SelectSys001Info(sourcebr, "BL_LF_AutoVoucher");

            //Logic Changed by HMW (13-June-2019) : For Seperating EOD Process
            #region Normal_Logic

            //if (blLateFee == null || blLateFee.SysDate == null || blLateFee.Status == null)
            //{ return false; }
            //else if (blLateFee.SysDate.Value.ToShortDateString() != DateTime.Now.ToShortDateString() || blLateFee.Status != "Y")
            //{ return false; }
            //else if (blLateFee.SysDate.Value.ToShortDateString() == DateTime.Now.ToShortDateString() || blLateFee.Status == "Y")
            //{ return true; }
            //else
            //{ return false; }

            #endregion

            #region Seperating_EOD_Logic

            TCMDTO00001 startdto = this.StartDAO.SelectStartBySourceBr(sourcebr);
            DateTime systemStartDate = startdto.Date;

            if (blLateFee == null || blLateFee.SysDate == null || blLateFee.Status == null)
            { return false; }
            else if (blLateFee.SysDate.Value.ToShortDateString() != systemStartDate.ToShortDateString() || blLateFee.Status != "Y")
            { return false; }
            else if (blLateFee.SysDate.Value.ToShortDateString() == systemStartDate.ToShortDateString() || blLateFee.Status == "Y")
            { return true; }
            else
            { return false; }

            #endregion
        }

        //Added by HWKO (17-Nov-2017)
        public bool CheckHPLateFeeAutoVoucherProcessRun(string sourcebr)
        {
            //DateTime nextSettlementDate;
            //nextSettlementDate = (DateTime)this.Sys001DAO.SelectSys001Info(sourcebr, "NEXT_SETTLEMENT_DATE").SysDate;

            PFMDTO00056 hpLateFee = this.Sys001DAO.SelectSys001Info(sourcebr, "HPLateFees_AutoPay");

            //Logic Changed by HMW (13-June-2019) : For Seperating EOD Process
            #region Normal_Logic

            //if (hpLateFee == null || hpLateFee.SysDate == null || hpLateFee.Status == null)
            //{ return false; }
            //else if (hpLateFee.SysDate.Value.ToShortDateString() != DateTime.Now.ToShortDateString() || hpLateFee.Status != "Y")
            //{ return false; }
            //else if (hpLateFee.SysDate.Value.ToShortDateString() == DateTime.Now.ToShortDateString() || hpLateFee.Status == "Y")
            //{ return true; }
            //else
            //{ return false; }

            #endregion

            #region Seperating_EOD_Logic

            TCMDTO00001 startdto = this.StartDAO.SelectStartBySourceBr(sourcebr);
            DateTime systemStartDate = startdto.Date;

            if (hpLateFee == null || hpLateFee.SysDate == null || hpLateFee.Status == null)
            { return false; }
            else if (hpLateFee.SysDate.Value.ToShortDateString() != systemStartDate.ToShortDateString() || hpLateFee.Status != "Y")
            { return false; }
            else if (hpLateFee.SysDate.Value.ToShortDateString() == systemStartDate.ToShortDateString() || hpLateFee.Status == "Y")
            { return true; }
            else
            { return false; }

            #endregion
        }

        public MNMDTO00010 CCOABalance(string acode, string budgetmonth, string cur, string dcode)
        {
            MNMDTO00010 ccoadto = new MNMDTO00010();
            string budgetYear = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode);
            IList<MNMDTO00010> ccoa = this.ViewDAO.SelectSumCCOAAmount(cur, acode, budgetYear, dcode);
            if (ccoa.Count > 0)
            {

                switch (budgetmonth)
                {
                    case "M1": decimal m1 = (from value in ccoa
                                             select value.M1.Value).SingleOrDefault();
                        ccoadto.CCOAAmount = m1;
                        break;

                    case "M2": decimal m2 = (from value in ccoa
                                             select value.M2.Value).SingleOrDefault();
                        ccoadto.CCOAAmount = m2;
                        break;
                    case "M3": decimal m3 = (from value in ccoa
                                             select value.M3.Value).SingleOrDefault();
                        ccoadto.CCOAAmount = m3;
                        break;
                    case "M4": decimal m4 = (from value in ccoa
                                             select value.M4.Value).SingleOrDefault();
                        ccoadto.CCOAAmount = m4;
                        break;
                    case "M5": decimal m5 = (from value in ccoa
                                             select value.M5.Value).SingleOrDefault();
                        ccoadto.CCOAAmount = m5;
                        break;
                    case "M6": decimal m6 = (from value in ccoa
                                             select value.M6.Value).SingleOrDefault();
                        ccoadto.CCOAAmount = m6;
                        break;
                    case "M7": decimal m7 = (from value in ccoa
                                             select value.M7.Value).SingleOrDefault();
                        ccoadto.CCOAAmount = m7;
                        break;
                    case "M8": decimal m8 = (from value in ccoa
                                             select value.M8.Value).SingleOrDefault();
                        ccoadto.CCOAAmount = m8;
                        break;
                    case "M9": decimal m9 = (from value in ccoa
                                             select value.M9.Value).SingleOrDefault();
                        ccoadto.CCOAAmount = m9;
                        break;
                    case "M10": decimal m10 = (from value in ccoa
                                               select value.M10.Value).SingleOrDefault();
                        ccoadto.CCOAAmount = m10;
                        break;
                    case "M11": decimal m11 = (from value in ccoa
                                               select value.M11.Value).SingleOrDefault();
                        ccoadto.CCOAAmount = m11;
                        break;

                    case "M12": decimal m12 = (from value in ccoa
                                               select value.M12.Value).SingleOrDefault();
                        ccoadto.CCOAAmount = m12;
                        break;

                }

                ccoadto.ACODE = (from value in ccoa
                                 where value.ACODE == acode
                                 select value.ACODE).SingleOrDefault();
            }
            return ccoadto;
        }

        //Added by HMW (04-09-2019) : To fix "Data Header Receving Error Occur" issue when so many data exists in "ReportTlf" table
        public void Delete_ReportTLF_Table(string sourceBr)
        {
            this.ViewDAO.DeleteAll_from_ReportTlf_bySourceBr(sourceBr);            
        }

        #endregion

    }
}
