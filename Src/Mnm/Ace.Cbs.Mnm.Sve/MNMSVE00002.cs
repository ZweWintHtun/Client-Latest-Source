using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Windows.Admin.Contracts.Dao;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Mnm.Ctr;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Mnm.Ctr.Dao;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Windows.Core.DataModel;
using Ace.Windows.CXServer.Utt;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Pfm.Dmd.DTO;

namespace Ace.Cbs.Mnm.Sve
{
    public class MNMSVE00002:BaseService,IMNMSVE00002
    {    
        #region Properties
        string Edate, Sdate;
        string mth, qmth;
        IList<string> MessageList = new List<string>();

        private IPFMDAO00056 sys001DAO;
        public IPFMDAO00056 Sys001DAO
        {
            get { return this.sys001DAO; }
            set { this.sys001DAO = value; }
        }

        private IMNMDAO00001 syspostDAO;
        public IMNMDAO00001 SyspostDAO
        {
            get { return this.syspostDAO; }
            set { this.syspostDAO = value; }
        }

        //From SI To Prev_SI
        private IPFMDAO00040 siDAO;
        public IPFMDAO00040 SiDAO
        {
            get { return this.siDAO; }
            set { this.siDAO = value; }
        }

        private IMNMDAO00007 prevsiDAO;
        public IMNMDAO00007 PrevSiDAO
        {
            get { return this.prevsiDAO; }
            set { this.prevsiDAO = value; }
        }
        //For Tod_Schared and Prev_Tod_Schared
        private IMNMDAO00005 tod_ScharedDAO;
        public IMNMDAO00005 Tod_ScharedDAO
        {
            get { return this.tod_ScharedDAO; }
            set { this.tod_ScharedDAO = value; }
        }

        private IMNMDAO00006 prev_ScharedDAO;
        public IMNMDAO00006 Prev_ScharedDAO
        {
            get { return this.prev_ScharedDAO; }
            set { this.prev_ScharedDAO = value; }
        }

        //For Oi and Prev_Oi
        private IMNMDAO00008 oiDAO;
        public IMNMDAO00008 OiDAO
        {
            get { return this.oiDAO; }
            set { this.oiDAO = value; }
        }

        private IMNMDAO00009 prev_OiDAO;
        public IMNMDAO00009 Prev_OiDAO
        {
            get { return this.prev_OiDAO; }
            set { this.prev_OiDAO = value; }
        }

        //For Li and Prev_Li
        private ITLMDAO00018 loansDAO;
        public ITLMDAO00018 LoansDAO
        {
            get { return this.loansDAO; }
            set { this.loansDAO = value; }
        }

        private IMNMDAO00017 liDAO;
        public IMNMDAO00017 LiDAO
        {
            get { return this.liDAO; }
            set { this.liDAO = value; }
        }

        private IMNMDAO00018 prev_liDAO;
        public IMNMDAO00018 Prev_liDAO
        {
            get { return this.prev_liDAO; }
            set { this.prev_liDAO = value; }
        }

        private ILOMDAO00302 prev_farmliDAO;
        public ILOMDAO00302 Prev_farmliDAO
        {
            get { return this.prev_farmliDAO; }
            set { this.prev_farmliDAO = value; }
        }

        private ILOMDAO00085 farmliDAO;
        public ILOMDAO00085 FarmLiDAO
        {
            get { return this.farmliDAO; }
            set { this.farmliDAO = value; }
        }

        //For cashdeno and Prev_cashdeno
        private ITLMDAO00015 cashdenoDAO;
        public ITLMDAO00015 CashdenoDAO
        {
            get { return this.cashdenoDAO; }
            set { this.cashdenoDAO = value; }
        }

        private IMNMDAO00004 prev_cashdenoDAO;
        public IMNMDAO00004 Prev_cashdenoDAO
        {
            get { return this.prev_cashdenoDAO; }
            set { this.prev_cashdenoDAO = value; }
        }

        ////For depodeno and Prev_depodeno
        private ITLMDAO00009 depodenoDAO;
        public ITLMDAO00009 DepodenoDAO
        {
            get { return this.depodenoDAO; }
            set { this.depodenoDAO = value; }
        }

        private IMNMDAO00003 prev_depodenoDAO;
        public IMNMDAO00003 Prev_depodenoDAO
        {
            get { return this.prev_depodenoDAO; }
            set { this.prev_depodenoDAO = value; }
        }

        //For bal and Prev_bal

        private IPFMDAO00028 cledgerDAO;
        public IPFMDAO00028 CledgerDAO
        {
            get { return this.cledgerDAO; }
            set { this.cledgerDAO = value; }
        }

        private IPFMDAO00023 fledgerDAO;
        public IPFMDAO00023 FledgerDAO
        {
            get { return this.fledgerDAO; }
            set { this.fledgerDAO = value; }
        }
      
        private IPFMDAO00033 balDAO;
        public IPFMDAO00033 BalDAO
        {
            get { return this.balDAO; }
            set { this.balDAO = value; }
        }

        private IMNMDAO00016 prev_BalDAO;
        public IMNMDAO00016 Prev_BalDAO
        {
            get { return this.prev_BalDAO; }
            set { this.prev_BalDAO = value; }
        }

        //For IBLTLF and Prev_IBLTLF
        private ITLMDAO00004 iblTLFDAO;
        public ITLMDAO00004 IBLTLFDAO
        {
            get { return this.iblTLFDAO; }
            set { this.iblTLFDAO = value; }
        }

        private ITLMDAO00024 prev_IBLTLFDAO;
        public ITLMDAO00024 Prev_IBLTLFDAO
        {
            get { return this.prev_IBLTLFDAO; }
            set { this.prev_IBLTLFDAO = value; }
        }

        //For RE and Prev_RE
        private ITLMDAO00001 rEDAO;
        public ITLMDAO00001 REDAO
        {
            get { return this.rEDAO; }
            set { this.rEDAO = value; }
        }

        private IMNMDAO00019 prev_REDAO;
        public IMNMDAO00019 Prev_REDAO
        {
            get { return this.prev_REDAO; }
            set { this.prev_REDAO = value; }
        }

        //For RD and Prev_RD
        private ITLMDAO00017 rDDAO;
        public ITLMDAO00017 RDDAO
        {
            get { return this.rDDAO; }
            set { this.rDDAO = value; }
        }

        private IMNMDAO00020 prev_RDDAO;
        public IMNMDAO00020 Prev_RDDAO
        {
            get { return this.prev_RDDAO; }
            set { this.prev_RDDAO = value; }
        }

        //For PO and Prev_PO
        private ITLMDAO00016 pODAO;
        public ITLMDAO00016 PODAO
        {
            get { return this.pODAO; }
            set { this.pODAO = value; }
        }

        private IMNMDAO00002 prev_PODAO;
        public IMNMDAO00002 Prev_PODAO
        {
            get { return this.prev_PODAO; }
            set { this.prev_PODAO = value; }
        }

        //For Commit_Fees and Prev_Commit_Fees
        private IMNMDAO00011 commitDAO;
        public IMNMDAO00011 CommitDAO
        {
            get { return this.commitDAO; }
            set { this.commitDAO = value; }
        }

        private IMNMDAO00025 prev_CommitDAO;
        public IMNMDAO00025 Prev_CommitDAO
        {
            get { return this.prev_CommitDAO; }
            set { this.prev_CommitDAO = value; }
        }

        private IPFMDAO00057 newsetupDAO;
        public IPFMDAO00057 NewsetupDAO
        {
            get { return this.newsetupDAO; }
            set { this.newsetupDAO = value; }
        
        }

        private ITLMDAO00028 remitbrDAO;
        public ITLMDAO00028 RemitBrDAO
        {
            get { return this.remitbrDAO; }
            set { this.remitbrDAO = value; }
        }
        private ILOMDAO00401 outstandLoanBalanceDAO;
        public ILOMDAO00401 OutstandLoanBalanceDAO
        {
            get { return this.outstandLoanBalanceDAO; }
            set { this.outstandLoanBalanceDAO = value; }
        }
        #endregion

        #region Variables

        decimal month = 0, serial = 0;
        int quater_month,value, year, accruedint = 0;
        int UpdatedUserID;
        string name = "MONTH_CLOSE";
        string status = "A";
        string variable = "FISCALYEAR";
        string stringQuaterMonth, Mthyear, Mthstatus, sysmonth, budget,SourceBranchCode;
        
        #endregion

        #region Helper Methods

        public bool CheckClosing(MNMDTO00001 sysDTO,string sourceBranchCode)
        {
            DateTime currentDate = Convert.ToDateTime(sysDTO.Date_time);

            SourceBranchCode = sourceBranchCode;
            Mthyear = this.Sys001DAO.Selectpostyear(name, SourceBranchCode);
            Mthstatus = this.Sys001DAO.Selectmonthstatus(name, SourceBranchCode);
            stringQuaterMonth = currentDate.ToString("MM");
            year = Convert.ToInt32(currentDate.ToString("yyyy"));
            sysmonth = stringQuaterMonth + "/" + year;
            
            //if (Mthyear == sysmonth && Mthstatus == "A")
            //{
            //    this.ServiceResult.ErrorOccurred = true;
            //    ServiceResult.MessageCode="MI30030";//Please Run Before Day Close.
            //    return false;
            //}
            //else if (Mthyear != sysmonth || Mthstatus != "B")
            //{
            //    this.ServiceResult.ErrorOccurred = true;
            //    ServiceResult.MessageCode="ME30008";//After Day Close Can't Run. " Please Contact your System Administrator.
            //    return false;
            //}

            if (Mthyear == sysmonth && Mthstatus == "A")
            {
                this.ServiceResult.ErrorOccurred = true;
                ServiceResult.MessageCode = "MI30060";//Already run "After Day Close"!
                return false;
            }
            else if (Mthyear != sysmonth || Mthstatus != "B")
            {
                this.ServiceResult.ErrorOccurred = true;
                ServiceResult.MessageCode = "MI30061";//Please run "Before Day Close" first!
                return false;
            }
     
            return true;
        }
        #endregion

        #region Main Function

        [Transaction(TransactionPropagation.Required)]
        public IList<string> MonthAfterCalcuate(MNMDTO00001 sysDTO, string sourceBranchCode, int UpdatedUserId)
        {

            DateTime currentDate = Convert.ToDateTime(sysDTO.Date_time);
            // Added by AAM(18_Sep_2018)
            string Return = string.Empty;
            string budget1 = balDAO.GetBudget_Month_Year_Quarter(1, currentDate, sourceBranchCode, Return);
            string budget2 = balDAO.GetBudget_Month_Year_Quarter(2, currentDate, sourceBranchCode, Return);
            string budget3 = balDAO.GetBudget_Month_Year_Quarter(3, currentDate, sourceBranchCode, Return);
            string budget4 = balDAO.GetBudget_Month_Year_Quarter(4, currentDate, sourceBranchCode, Return);
            IList<PFMDTO00079> budgetEndMonth = balDAO.GetBLFInfoByActiveBudget(sourceBranchCode);

            try
            {
                UpdatedUserID = UpdatedUserId;
                SourceBranchCode = sourceBranchCode;
                quater_month = Convert.ToInt32(currentDate.ToString("MM"));
                stringQuaterMonth = currentDate.ToString("MM");
                year = Convert.ToInt32(currentDate.ToString("yyyy"));
                Mthyear = this.Sys001DAO.Selectpostyear(name, SourceBranchCode);
                Mthstatus = this.Sys001DAO.Selectmonthstatus(name, SourceBranchCode);
                sysmonth = stringQuaterMonth + "/" + year;

                #region Commented by AAM(18_Sep_2018)
                //budget = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode);
                //string[] budgetStringArr = budget.Split('/');
                //int[] budgetIntArr = new int[2];
                //budgetIntArr[0] = Convert.ToInt32(budgetStringArr[0]) + 1;
                //budgetIntArr[1] = Convert.ToInt32(budgetStringArr[1]) + 1;

                //budget = budgetIntArr[0].ToString() + "/" + budgetIntArr[1].ToString();

                //string Mth = "M"+ CXCOM00010.Instance.GetBudgetYear2(CXCOM00009.BudgetYearCode, currentDate.AddMonths(1));
                ////string Qmth="Q"+
                //string Tcount = "Tcount" + CXCOM00010.Instance.GetBudgetYear2(CXCOM00009.BudgetYearCode, currentDate.AddMonths(1));
                #endregion

                //Added by AAM (18_Sep_2018)
                budget = budget2;
                int bud = Convert.ToInt32(budget3) + 1;
                string Mth = "M" + bud;
                string Tcount = "Tcount" + bud;

                if (Mthyear == sysmonth && Mthstatus == "B")
                {
                    if (Mth != "M1")
                    {
                        //Updating Customer Ledger
                        //From Bal To Prev_Bal
                        IList<PFMDTO00033> balInfo = SelectAll_BAL(SourceBranchCode);

                        if (balInfo.Count > 0)
                        {
                            #region OldCode,Commented by AAM (19_Sep_2018)
                            //IList<PFMDTO00028> cledgerinfo = CledgerDAO.SelectCbalTCount(SourceBranchCode);
                            //foreach (PFMDTO00028 item in cledgerinfo)
                            //{
                            //    BalDAO.UpdateBalMonth(item.AccountNo, item.CurrentBal, item.TransactionCount, Mth, SourceBranchCode, UpdatedUserID);
                            //}

                            //CledgerDAO.UpdateTcount(SourceBranchCode, UpdatedUserID);
                            #endregion
                            #region Updated by ZMS For Pristine Version
                            //IList<PFMDTO00023> fledgerinfo = FledgerDAO.SelectFledgerFBal(SourceBranchCode);
                            //foreach (PFMDTO00023 item in fledgerinfo)
                            //{
                            //    BalDAO.UpdateBalMonth(item.AccountNo, item.FixedBalance, Mth,SourceBranchCode, UpdatedUserID);
                            //}
                            #endregion

                            //Added by AAM (19_Sep_2018)
                            balDAO.AfterDayClose_YearEndProcess_NotBudgetFirstMonth(Mth, UpdatedUserId, sourceBranchCode);

                        }
                        //From LI To PREV_LI 
                        IList<LOMDTO00021> liinfo = SelectAll_LI(SourceBranchCode);
                        if (liinfo.Count > 0)
                        {
                            #region Old Code,Commented by AAM (20_Sep_2018)
                            //For Loans acctno is equal to Li Acctno
                            //IList<TLMDTO00018> loansLno = SelectAll_LIOANS(SourceBranchCode);
                            //if (loansLno.Count > 0)
                            //{
                            //    foreach (TLMDTO00018 item in loansLno)
                            //    {
                            //        LiDAO.UpdateQBal(Convert.ToInt32(item.SAmount), item.Lno, stringQuaterMonth, SourceBranchCode, UpdatedUserID);
                            //    }
                            //}
                            #endregion
                            //Added by AAM (20_Sep_2018)
                            balDAO.AfterDayCloseAtYearEndProcess_UpdateLiQBal(budget4, UpdatedUserId, SourceBranchCode);

                        }
                        //From RD To Prev_Prev_RD                
                        if (stringQuaterMonth == "06")
                        {
                            Sdate = year.ToString() + "/04/01";
                            Edate = year.ToString() + "/06/30";
                        }
                        else if (stringQuaterMonth == "09")
                        {
                            Sdate = year.ToString() + "/07/01";
                            Edate = year.ToString() + "/09/30";
                        }
                        else if (stringQuaterMonth == "12")
                        {
                            Sdate = year.ToString() + "/10/01";
                            Edate = year.ToString() + "/12/30";
                        }

                        if (stringQuaterMonth == "06" || stringQuaterMonth == "09" || stringQuaterMonth == "12")
                        {
                            //From RD To Prev_Prev_RD
                            IList<TLMDTO00017> rdInfo = SelectAllQTR_RD(Sdate, Edate, SourceBranchCode);
                            if (rdInfo.Count > 0)
                            {
                                this.RD_PrevRDQTR(rdInfo, Sdate, Edate, SourceBranchCode);
                                //RDDAO.DeleteRDQTR(Sdate, Edate, SourceBranchCode);
                            }
                        }
                    }

                    this.ServiceResult.ErrorOccurred = false;
                    //this.ServiceResult.MessageCode = "MI30029";//After Day Close Finished
                    this.MessageList.Add("MI30029");//After Day Close Finished

                    //For Yearly Closing
                    //if (Mthyear.Substring(0,2) == "03") // Commented by AAM (18_Sep_2018)

                    //Added by AAM (18_Sep_2018)
                    int yearEndMonth = Convert.ToInt32(Mthyear.Substring(0, 2));
                    int budEndMonth = Convert.ToInt32(budgetEndMonth[0].BEND_DATE.Month);

                    if (yearEndMonth == budEndMonth)
                    {
                        #region Updated by ZMS For Pristine Version
                        //From SI To PREV_SI 
                        //IList<PFMDTO00040> siInfo = SelectAll_SI(SourceBranchCode);
                        //if(siInfo.Count > 0 )
                        //{
                        //    this.SI_PrevSI(siInfo, month, accruedint, budget, SourceBranchCode, UpdatedUserID);
                        //    //SiDAO.UpdateSi(month, accruedint, budget,SourceBranchCode,UpdatedUserID);
                        //}
                        #endregion
                        #region Updated by ZMS For Pristine Version
                        //From LI To PREV_LI 
                        //IList<LOMDTO00021> liinfo = SelectAll_LI(SourceBranchCode);
                        //if (liinfo.Count > 0)
                        //{
                        //    this.LI_PrevLI(liinfo, month, budget, SourceBranchCode, UpdatedUserID);
                        //    //LiDAO.UpdateLI(month, budget,SourceBranchCode, UpdatedUserID);
                        //}

                        ////From Farm_LI To PREV_Farm_LI //Updated by HWKO (16-Mar-2017)
                        //IList<LOMDTO00085> farmliinfo = SelectAll_FarmLI(SourceBranchCode);
                        //if (farmliinfo.Count > 0)
                        //{
                        //    this.FarmLI_PrevFarmLI(farmliinfo, month, budget, SourceBranchCode, UpdatedUserID);
                        //}

                        //From TOD_SCHARGED To PREV_TOD_SCHARGED 
                        //IList<MNMDTO00005> tod_ScharedInfo = SelectAll_TOD(SourceBranchCode);
                        //if (tod_ScharedInfo.Count > 0)
                        //{
                        //    this.Tod_PrevTod(tod_ScharedInfo, month, budget, SourceBranchCode, UpdatedUserID);
                        //    //Tod_ScharedDAO.UpdateTOD_SCHARGED(month, budget, SourceBranchCode, UpdatedUserID);
                        //}

                        ////From OI To PREV_OI 
                        //IList<MNMDTO00008> oiInfo = SelectAll_OI(SourceBranchCode);
                        //if (oiInfo.Count > 0)
                        //{
                        //    this.oi_PrevOI(oiInfo, month, budget, SourceBranchCode,UpdatedUserId);
                        //    //OiDAO.UpdateOI(month, budget, SourceBranchCode);
                        //}

                        #endregion
                        #region Commented by AAM (19_Sep_2018),to increase database performanaces.
                        //From BAL To PREV_BAL
                        //IList<PFMDTO00033> balInfo = SelectAll_BAL(SourceBranchCode);
                        //if (balInfo.Count > 0)
                        //{
                        //    this.BAL_PrevBAL(balInfo, budget, SourceBranchCode, UpdatedUserID);
                        //    //BalDAO.UpdateBal(budget,SourceBranchCode ,UpdatedUserID);
                        //}

                        #region Updated by ZMS For Pristine Version
                        ////From RD To Prev_Prev_RD
                        //IList<TLMDTO00017> rdInfo = SelectAll_RD(SourceBranchCode);
                        //if (rdInfo.Count > 0)
                        //{
                        //    this.RD_PrevRD(rdInfo,SourceBranchCode);
                        //    //RDDAO.DeleteRD(SourceBranchCode);                        
                        //}
                        #endregion

                        //From RE To Prev_Prev_RE
                        //IList<string> polist = GetREbyPO(SourceBranchCode);
                        #region
                        //IList<TLMDTO00001> reInfo = SelectAll_RE(polist,SourceBranchCode);
                        //if (reInfo.Count > 0)
                        //{
                        //    this.RE_PrevRE(reInfo,polist, SourceBranchCode);
                        //    //REDAO.DeleteRE(polist, SourceBranchCode);
                        //}
                        #endregion
                        //From PO To Prev_Prev_PO
                        //IList<TLMDTO00016> poInfo = SelectAll_PO(SourceBranchCode);
                        //if (poInfo.Count > 0)
                        //{
                        //    this.PO_PrevPO(poInfo, SourceBranchCode);
                        //    //PODAO.DeletePO(SourceBranchCode);
                        //}

                        #region Updated by ZMS For Pristine Version
                        ////From IblTlf To Prev_IblTlf 
                        //IList<TLMDTO00004> ibltlfInfo = SelectAll_IBLTLF(SourceBranchCode);
                        //if (ibltlfInfo.Count > 0)
                        //{
                        //    this.IBL_PrevIBLTLF(ibltlfInfo, SourceBranchCode);
                        //    //IBLTLFDAO.DeleteIBLTLF(SourceBranchCode);
                        //}

                        //Updated by ZMS For Pristine Version
                        //From Commit_Fees To Prev_Commit_Fees
                        //IList<MNMDTO00011> commitInfo = SelectAll_Commit(SourceBranchCode);
                        //if (commitInfo.Count > 0)
                        //{
                        //    this.Commit_PrevCommit(commitInfo, month, budget, SourceBranchCode, UpdatedUserID);
                        //    //CommitDAO.UpdateCommit(month,budget,SourceBranchCode,UpdatedUserID);
                        //}
                        #endregion
                        //From Cashdeno To Prev_Cashdeno 
                        //IList<TLMDTO00015> cashdenoInfo = SelectAll_CASHDENO(SourceBranchCode);
                        //if (cashdenoInfo.Count > 0)
                        //{
                        //    this.CashDeno_PreCashDeno(cashdenoInfo, SourceBranchCode);
                        //    //CashdenoDAO.DeleteCashDeno(SourceBranchCode);
                        //}

                        //From Depodeno To Prev_Depodeno 
                        //IList<TLMDTO00009> depoInfo = SelectAll_DEPODENO(SourceBranchCode);
                        //if (depoInfo.Count > 0)
                        //{
                        //    this.DepoDeno_PrevDepoDeno(depoInfo, SourceBranchCode);
                        //    //DepodenoDAO.DeleteDepodeno(SourceBranchCode);
                        //}
                        #endregion

                        //Added by AAM (19_Sep_2018)
                        balDAO.AfterDayClose_YearEndProcess(budget, UpdatedUserID, sourceBranchCode);

                        if (Mth == "M1")
                        {
                            #region OldCode Commented by AAM (19_Sep_2018)
                            //if (balInfo.Count > 0)
                            //{
                            //    IList<PFMDTO00028> cledgerinfo = CledgerDAO.SelectCbalTCount(SourceBranchCode);

                            //    //Updated by ZMS For Year End (Need to reopen comment or rewrite with store procedure)

                            //    foreach (PFMDTO00028 item in cledgerinfo)
                            //    {
                            //        BalDAO.UpdateCBal(item.CurrentBal, item.TransactionCount, item.AccountNo, SourceBranchCode, UpdatedUserID);
                            //    }

                            //    //Updated by ZMS For Year End (Need to reopen comment or rewrite with store procedure)

                            //    CledgerDAO.UpdateTcount(SourceBranchCode, UpdatedUserID);

                            //    #region Updated by ZMS For Pristine Version
                            //    //IList<PFMDTO00023> fledgerinfo = FledgerDAO.SelectFledgerFBal(SourceBranchCode);
                            //    //foreach (PFMDTO00023 item in fledgerinfo)
                            //    //{
                            //    //    BalDAO.UpdateFBal(item.FixedBalance, item.AccountNo, SourceBranchCode,UpdatedUserID);
                            //    //}
                            //    #endregion
                            //}
                            #endregion
                            //Added and modified by AAM (19_Sep_2018)
                            balDAO.AfterDayClose_YearEndProcess_BudgetFirstMonth(UpdatedUserId, sourceBranchCode);
                        }
                        //Update FISCALYEAR to be Ready For Coming Year
                        PFMDTO00057 newsetup = NewsetupDAO.SelectByVariable(variable);
                        value = Convert.ToInt32(newsetup.Value) + 1;
                        if (NewsetupDAO.UpdateByVariable(variable, value.ToString(), UpdatedUserID) == false)
                        {
                            throw new Exception(CXMessage.ME90001);
                        }

                        //Update SerialNo For Online Transcation For Coming Year
                        RemitBrDAO.UpdateSerialRemit(serial, SourceBranchCode, UpdatedUserID);

                        //Update Vouchermaxfile For All Voucher Type 
                        ///Prev_PODAO.FormatDefinitionMaxValueUpdate(SourceBranchCode, UpdatedUserID);//Commented By ZMS for Pristine need by HMW

                        /*
                        //Comment by HMW at 16-Oct-2019 (No Need)
                        this.ServiceResult.ErrorOccurred = false;                        
                        this.MessageList.Add("MI30031");//Yearly Closing is finished.
                         */

                    }

                    //Update MonthCLose status
                    if (Sys001DAO.UpdateStatusSys001(UpdatedUserID, name, status, SourceBranchCode) == false)
                    {
                        throw new Exception(CXMessage.ME90001);
                    }
                }
                //Updated By HWKO (14-Mar-2017)
                else if (Mthyear == sysmonth && Mthstatus == "A")
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.MessageList.Add("MI30030");//Please Run Before Day Close.                    
                }
                else if (Mthyear != sysmonth && Mthstatus == "B" || Mthyear != sysmonth && Mthstatus == "A")
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.MessageList.Add("ME30008");//After Day Close Can't Run. " Please Contact your System Administrator.
                }

                #region
                //if (Mthyear == sysmonth && Mthstatus == "A")
                //{

                //}
                //else
                //{
                //    this.ServiceResult.ErrorOccurred = true;
                //    this.MessageList.Add("ME30008");//After Day Close Can't Run. " Please Contact your System Administrator.
                //}
                //this.ServiceResult.MessageCode = "MI30002"; //success        
                #endregion
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                //this.ServiceResult.MessageCode = "MV00000";
                this.MessageList.Add("MI30009");
                throw new Exception("ME90001");
            }

            return this.MessageList;
        }
                
        public string DatabaseBackupAfterMonthClose()
        {
            try
            {
                //Backup Database Here BY HWKO (14-Mar-2017)
                return this.BalDAO.BackupDatabaseAfterMonthClose();
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.MessageList.Add("MI30009");
                throw new Exception("ME90001");
            }
        }
        #endregion

        #region helper method

        public IList<string> GetREbyPO(string SourceBranchCode)
        {
            IList<TLMDTO00016> polists = PODAO.SelectByPoNOforRE(SourceBranchCode);
            //IList<ChargeOfAccountSetupDTO> toaccountnoList = this.GetCoAsetupList();

            var PoNo = from value in polists
                        where value.PONo != null
                       select value.PONo;

            IList<string> PoList = PoNo.ToList();

            return PoList;
        }
        private IList<PFMDTO00040> SelectAll_SI(string SourceBranchCode)
        {
            return this.SiDAO.SelectAll(SourceBranchCode);
        }
        private IList<MNMDTO00005> SelectAll_TOD(string SourceBranchCode)
        {
            return this.Tod_ScharedDAO.SelectAll(SourceBranchCode);
        }
        private IList<MNMDTO00008> SelectAll_OI(string SourceBranchCode)
        {
            return this.OiDAO.SelectAllOI(SourceBranchCode);
        }
        private IList<MNMDTO00011> SelectAll_Commit(string SourceBranchCode)
        {
            return this.CommitDAO.SelectAll(SourceBranchCode);
        }
        private IList<LOMDTO00021> SelectAll_LI(string SourceBranchCode)
        {
            return this.LiDAO.SelectAll(SourceBranchCode);

        }
        //Updated by HWKO (16-Mar-2017)
        private IList<LOMDTO00085> SelectAll_FarmLI(string SourceBranchCode)
        {
            return this.FarmLiDAO.SelectAll(SourceBranchCode);

        }        
        private IList<TLMDTO00018> SelectAll_LIOANS(string SourceBranchCode)
        {
            return this.LoansDAO.SelectAll(SourceBranchCode);
        }
        private IList<TLMDTO00015> SelectAll_CASHDENO(string SourceBranchCode)
        {
            return this.CashdenoDAO.SelectAll(SourceBranchCode);
        }
        private IList<TLMDTO00009> SelectAll_DEPODENO(string SourceBranchCode)
        {
            return this.DepodenoDAO.SelectAllDepoDeno(SourceBranchCode);
        }
        private IList<PFMDTO00033> SelectAll_BAL(string SourceBranchCode)
        {
            return this.BalDAO.SelectAll(SourceBranchCode);
        }
        private IList<TLMDTO00004> SelectAll_IBLTLF(string SourceBranchCode)
        {
            return this.IBLTLFDAO.SelectAll(SourceBranchCode);
        }
        private IList<TLMDTO00017> SelectAllQTR_RD(string Sdate, string Edate, string SourceBranchCode)
        {
            return this.RDDAO.SelectAllRDQTR(Sdate, Edate, SourceBranchCode);
        }
        private IList<TLMDTO00017> SelectAll_RD(string SourceBranchCode)
        {
            return this.RDDAO.SelectAllRD(SourceBranchCode);
        }
        private IList<TLMDTO00001> SelectAll_RE(IList<string> poList,string SourceBranchCode)
        {
            return this.REDAO.SelectRE(poList, SourceBranchCode);
        }
        private IList<TLMDTO00016> SelectAll_PO(string SourceBranchCode)
        {
            return this.PODAO.SelectPO(SourceBranchCode);
        }

        [Transaction(TransactionPropagation.Required)]
        private void SI_PrevSI(IList<PFMDTO00040> siInfo,decimal month,int accruedint,string budget,string SourceBranchCode,int UpdatedUserID)
        {
            foreach (PFMDTO00040 item in siInfo)
            {
                this.PrevSiDAO.Save(this.GetTypeSI(item));
            }
            SiDAO.UpdateSi(month, accruedint, budget, SourceBranchCode, UpdatedUserID);
        }

        [Transaction(TransactionPropagation.Required)]
        private void Tod_PrevTod(IList<MNMDTO00005> tod_ScharedInfo,decimal month,string budget,string SourceBranchCode,int UpdatedUserID)
        {
            foreach (MNMDTO00005 item in tod_ScharedInfo)
            {
                this.Prev_ScharedDAO.Save(this.GetTypeTOD(item));
            }
            Tod_ScharedDAO.UpdateTOD_SCHARGED(month, budget, SourceBranchCode, UpdatedUserID);
        }

        [Transaction(TransactionPropagation.Required)]
        private void oi_PrevOI(IList<MNMDTO00008> oiInfo,decimal month,string budget,string SourceBranchCode,int updatedUserId)
        {
            foreach (MNMDTO00008 item in oiInfo)
            {
                this.Prev_OiDAO.Save(this.GetTypeOI(item));
            }
            OiDAO.UpdateOI(month, budget, SourceBranchCode,updatedUserId);
        }

        [Transaction(TransactionPropagation.Required)]
        private void Commit_PrevCommit(IList<MNMDTO00011> commitInfo,decimal month,string budget,string SourceBranchCode,int UpdatedUserID)
        {
            foreach (MNMDTO00011 item in commitInfo)
            {
                this.Prev_CommitDAO.Save(this.GetTypeCommit(item));
            }
            CommitDAO.UpdateCommit(month,budget,SourceBranchCode,UpdatedUserID);
        }

        [Transaction(TransactionPropagation.Required)]
        private void LI_PrevLI(IList<LOMDTO00021> liInfo,decimal month,string budget,string SourceBranchCode,int UpdatedUserID)
        {
            foreach (LOMDTO00021 item in liInfo)
            {
                this.Prev_liDAO.Save(this.GetTypeLI(item));
            }
            LiDAO.UpdateLI(month, budget,SourceBranchCode, UpdatedUserID);
        }

        //Updated by HWKO (16-Mar-2017)
        [Transaction(TransactionPropagation.Required)]
        private void FarmLI_PrevFarmLI(IList<LOMDTO00085> farmliInfo, decimal month, string budget, string SourceBranchCode, int UpdatedUserID)
        {
            foreach (LOMDTO00085 item in farmliInfo)
            {
                this.Prev_farmliDAO.Save(this.GetTypeFarmLI(item));
            }
            this.FarmLiDAO.UpdateFarmLI(month, budget, SourceBranchCode, UpdatedUserID);
        }

        [Transaction(TransactionPropagation.Required)]
        private void CashDeno_PreCashDeno(IList<TLMDTO00015> cashInfo, string SourceBranchCode)
        {
            foreach (TLMDTO00015 item in cashInfo)
            {
                this.Prev_cashdenoDAO.Save(this.GetTypeCashdeno(item));
            }
            //CashdenoDAO.DeleteCashDeno(SourceBranchCode);
        }

        [Transaction(TransactionPropagation.Required)]
        private void DepoDeno_PrevDepoDeno(IList<TLMDTO00009> depoInfo, string SourceBranchCode)
        {
            foreach (TLMDTO00009 item in depoInfo)
            {
                this.Prev_depodenoDAO.Save(this.GetTypeDepodeno(item));
            }
            DepodenoDAO.DeleteDepodeno(SourceBranchCode);
        }

        [Transaction(TransactionPropagation.Required)]
        private void BAL_PrevBAL(IList<PFMDTO00033> balInfo,string budget,string SourceBranchCode,int UpdatedUserID)
        {
            foreach (PFMDTO00033 item in balInfo)
            {
                this.Prev_BalDAO.Save(this.GetTypeBal(item));
            }
            BalDAO.UpdateBal(budget,SourceBranchCode ,UpdatedUserID);
        }

        [Transaction(TransactionPropagation.Required)]
        private void IBL_PrevIBLTLF(IList<TLMDTO00004> ibltlfInfo, string SourceBranchCode)
        {
            foreach (TLMDTO00004 item in ibltlfInfo)
            {
                this.prev_IBLTLFDAO.Save(this.GetTypeIBLTLF(item));
            }
            IBLTLFDAO.DeleteIBLTLF(SourceBranchCode);
        }

        [Transaction(TransactionPropagation.Required)]
        private void RE_PrevRE(IList<TLMDTO00001> reInfo,IList<string> polist,string SourceBranchCode)
        {
            foreach (TLMDTO00001 item in reInfo)
            {
                MNMORM00019 orm = this.GetTypeRE(item);
                this.Prev_REDAO.Save(this.GetTypeRE(item));
            }
            REDAO.DeleteRE(polist, SourceBranchCode);
        }

        [Transaction(TransactionPropagation.Required)]
        private void RD_PrevRDQTR(IList<TLMDTO00017> rdInfo,string Sdate,string Edate,string SourceBranchCode)
        {
            foreach (TLMDTO00017 item in rdInfo)
            {
                this.Prev_RDDAO.Save(this.GetTypeRD(item));               
            }
            RDDAO.DeleteRDQTR(Sdate, Edate, SourceBranchCode);
        }

        [Transaction(TransactionPropagation.Required)]
         private void RD_PrevRD(IList<TLMDTO00017> rdInfo,string SourceBranchCode)
        {
            foreach (TLMDTO00017 item in rdInfo)
            {
                this.Prev_RDDAO.Save(this.GetTypeRD(item)); 
            }
            RDDAO.DeleteRD(SourceBranchCode);
        }

        [Transaction(TransactionPropagation.Required)]
        private void PO_PrevPO(IList<TLMDTO00016> poInfo, string SourceBranchCode)
        {
            foreach (TLMDTO00016 item in poInfo)
            {
                this.Prev_PODAO.Save(this.GetTypePO(item));
            }
            PODAO.DeletePO(SourceBranchCode);
        }

        //public IList<LOMDTO00021> CheckIntCalculateDate(string year, DateTime Smonth, DateTime Emonth)
        //{
        //    IList<LOMDTO00021> liList = this.LiDAO.CheckIntCalculateDate(year,Smonth,Emonth);
        //    return liList;
        //}

        //public bool UpdateLoanInterest(IList<LOMDTO00021> liList)
        //{
        //    for (int i = 0; i < liList.Count; i++)
        //    {
        //        liDAO.UpdateLoanInterest(liList[i]);
        //    }
        //    return true;
        //}
        public string CalculateLoansInterestForQuarter(DateTime sDate, DateTime eDate, int period, string branchCode)
        {
            return liDAO.CalculateLoansInterestForQuarter(sDate, eDate, period, branchCode);
        }
        #region Business Loans
        //Monthly BL Interest Calculation
        public string CalculateLoansInterestForMonthly(DateTime sDate, DateTime eDate, int period, string branchCode, IList<DataVersionChangedValueDTO> dvcvList, int userId)
        {
            string result= liDAO.CalculateLoansInterestForMonthly(sDate, eDate, period, branchCode);
            //For Loans Interest Calculation
            PFMDTO00056 InterestDateDTO = Sys001DAO.SelectSys001Info(branchCode, "LOAN_INT_CAL");
            SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, userId, InterestDateDTO.Id.ToString()); 
            Dictionary<string, object> updateColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "SysDate", DateTime.Now } };
            Dictionary<string, object> whereColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "BranchCode", branchCode }, { "Name", "LOAN_INT_CAL" }, { "Active", true } };
            CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("PFMORM00056", updateColumnsandValuesForLoansInterestCalculation, whereColumnsandValuesForLoansInterestCalculation));
            return result;
        }
        //Daily BL Interest Calculation
        public string CalculateBusinessLoansInterestForDaily(DateTime sDate, DateTime eDate,string branchCode, IList<DataVersionChangedValueDTO> dvcvList, int userId)
        {
            IList<LOMDTO00401> BLDdueLoanList = OutstandLoanBalanceDAO.SelectBusinessLoansDueForInterest(sDate, eDate, branchCode);
            string result;
            if (BLDdueLoanList.Count != 0 || BLDdueLoanList.Count >= 1)
            {
                result = liDAO.CalculateBusinessLoansInterestForDaily(sDate, eDate, branchCode, userId);
                PFMDTO00056 InterestDateDTO = Sys001DAO.SelectSys001Info(branchCode, "LOAN_INT_CAL_DAILY");
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, userId, InterestDateDTO.Id.ToString());
                Dictionary<string, object> updateColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "SysDate", eDate } };
                Dictionary<string, object> whereColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "BranchCode", branchCode }, { "Name", "LOAN_INT_CAL_DAILY" }, { "Active", true } };
                CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("PFMORM00056", updateColumnsandValuesForLoansInterestCalculation, whereColumnsandValuesForLoansInterestCalculation));
                return result;
            }
            else
            {
                PFMDTO00056 InterestDateDTO = Sys001DAO.SelectSys001Info(branchCode, "LOAN_INT_CAL_DAILY");
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, userId, InterestDateDTO.Id.ToString());
                Dictionary<string, object> updateColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "SysDate", eDate } };
                Dictionary<string, object> whereColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "BranchCode", branchCode }, { "Name", "LOAN_INT_CAL_DAILY" }, { "Active", true } };
                CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("PFMORM00056", updateColumnsandValuesForLoansInterestCalculation, whereColumnsandValuesForLoansInterestCalculation));
                this.sys001DAO.UpdateDateDailyPosting("LOAN_INT_CAL_DAILY", eDate, branchCode, userId);
                result = "fault";
                return result;
            }
        }

        #region Data Version Update Service
        public void SaveOrUpdateClientDataVersion(DataAction dataAction, IList<DataVersionChangedValueDTO> dvcvList, int createdUserId, string dataValueId)
        {
            ClientDataVersionDTO clientDataVersionDTO = new ClientDataVersionDTO();
            PFMORM00056 Sys001ORM = new PFMORM00056();

            //Require Data
            clientDataVersionDTO.ORMObjectName = Sys001ORM;
            clientDataVersionDTO.DataIdValue = dataValueId;
            clientDataVersionDTO.CreatedUserId = createdUserId;

            //ChangedDataContents
            IList<ChangeDataContent> cdclist = new List<ChangeDataContent>();
            foreach (DataVersionChangedValueDTO dvcvdto in dvcvList)
            {
                ChangeDataContent cdcdto = new ChangeDataContent();
                cdcdto.Property = dvcvdto.OrmPropertyName;
                cdcdto.OldValue = dvcvdto.OrmPreviousValue;
                cdcdto.NewValue = dvcvdto.OrmNewValue;
                cdclist.Add(cdcdto);
            }
            clientDataVersionDTO.ChangeDataContentList = cdclist;
            // CXServiceWrapper.Instance.Invoke<IDataVersionUpdateService, bool>(x => x.SaveOrUpdateClientDataVersion(clientDataVersionDTO, dataAction));
        }
        #endregion

        #endregion
        public IList<LOMDTO00021> SelectLoansInterestByQuater(LOMDTO00021 dto)
        {
            IList<LOMDTO00021> DataList = new List<LOMDTO00021>();
            DataList = liDAO.SelectLoansInterestByQuater(dto.QuaterNo,dto.Budget,dto.SourceBr,dto.Cur);
            return DataList;

        }

        public IList<LOMDTO00054> SelectODInterestByQuater(LOMDTO00054 dto)
        {
            IList<LOMDTO00054> DataList = new List<LOMDTO00054>();
            DataList = liDAO.SelectODInterestByQuater(dto.MonthNo, dto.Budget, dto.SourceBr, dto.Cur);
            return DataList;

        }

        #endregion

        #region Convert DTO to ORM

        private MNMORM00007 GetTypeSI(PFMDTO00040 siDTO)
        {
            MNMORM00007 prevsiInfo = new MNMORM00007();
            prevsiInfo.Id = siDTO.Id;
            prevsiInfo.AccountNo = siDTO.AccountNo;
            prevsiInfo.AccountSignature = siDTO.AccountSignature;
            prevsiInfo.CloseDate = siDTO.CloseDate;
            prevsiInfo.Status = siDTO.Status;
            prevsiInfo.Budget = siDTO.Budget;
            prevsiInfo.LastInt = siDTO.LastInt;
            prevsiInfo.AccruedInt = siDTO.AccruedInt;
            prevsiInfo.Month1 = siDTO.Month1;
            prevsiInfo.Month2 = siDTO.Month2;
            prevsiInfo.Month3 = siDTO.Month3;
            prevsiInfo.Month4 = siDTO.Month4;
            prevsiInfo.Month5 = siDTO.Month5;
            prevsiInfo.Month6 = siDTO.Month6;
            prevsiInfo.Month7 = siDTO.Month7;
            prevsiInfo.Month8 = siDTO.Month8;
            prevsiInfo.Month9 = siDTO.Month9;
            prevsiInfo.Month10 = siDTO.Month10;
            prevsiInfo.Month11 = siDTO.Month11;
            prevsiInfo.Month12 = siDTO.Month12;
            prevsiInfo.SourceBranchCode = siDTO.SourceBranchCode;
            prevsiInfo.DATE_TIME = siDTO.DATE_TIME;
            prevsiInfo.CurrencyCode = siDTO.CurrencyCode;
            prevsiInfo.Active = siDTO.Active;
            prevsiInfo.TS = siDTO.TS;
            prevsiInfo.CreatedUserId = siDTO.CreatedUserId;
            prevsiInfo.CreatedDate = siDTO.CreatedDate;
            prevsiInfo.UpdatedDate = siDTO.UpdatedDate;
            prevsiInfo.UpdatedUserId = siDTO.UpdatedUserId;

            return prevsiInfo;

        }

        private MNMORM00006 GetTypeTOD(MNMDTO00005 todDTO)
        {
            MNMORM00006 prevTod = new MNMORM00006();
            prevTod.ID = todDTO.ID;
            prevTod.Acctno = todDTO.Acctno;
            prevTod.LNo = todDTO.LNo;
            prevTod.S1 = todDTO.S1;
            prevTod.S2 = todDTO.S2;
            prevTod.S3 = todDTO.S3;
            prevTod.S4 = todDTO.S4;
            prevTod.S5 = todDTO.S5;
            prevTod.S6 = todDTO.S6;
            prevTod.S7 = todDTO.S7;
            prevTod.S8 = todDTO.S8;
            prevTod.S9 = todDTO.S9;
            prevTod.S10 = todDTO.S10;
            prevTod.S11 = todDTO.S11;
            prevTod.S12 = todDTO.S12;
            prevTod.LastInt = todDTO.LastInt;
            prevTod.LastDate = todDTO.LastDate;
            prevTod.Budget = todDTO.Budget;
            prevTod.UId = todDTO.UserNo;
            prevTod.CloseDate = todDTO.CloseDate;
            prevTod.ACSign = todDTO.ACSign;
            prevTod.TODCloseDate = todDTO.CloseDate;
            prevTod.TOD_SDate = todDTO.TOD_SDate;
            prevTod.UId = todDTO.UId;
            prevTod.SourceBr = todDTO.SourceBr;
            prevTod.Cur = todDTO.Cur;
            prevTod.Active = todDTO.Active;
            prevTod.TS = todDTO.TS;
            prevTod.CreatedUserId = todDTO.CreatedUserId;
            prevTod.CreatedDate = todDTO.CreatedDate;
            prevTod.UpdatedDate = todDTO.UpdatedDate;
            prevTod.UpdatedUserId = todDTO.UpdatedUserId;

            return prevTod;

        }
        private MNMORM00009 GetTypeOI(MNMDTO00008 oiDTO)
        {
            MNMORM00009 prevOi = new MNMORM00009();
            prevOi.ID = oiDTO.Id;
            prevOi.Acctno = oiDTO.AcctNo;
            prevOi.LNo = oiDTO.LNo;
            prevOi.M1 = oiDTO.M1;
            prevOi.M2 = oiDTO.M2;
            prevOi.M3 = oiDTO.M3;
            prevOi.M4 = oiDTO.M4;
            prevOi.M5 = oiDTO.M5;
            prevOi.M6 = oiDTO.M6;
            prevOi.M7 = oiDTO.M7;
            prevOi.M8 = oiDTO.M8;
            prevOi.M9 = oiDTO.M9;
            prevOi.M10 = oiDTO.M10;
            prevOi.M11 = oiDTO.M11;
            prevOi.M12 = oiDTO.M12;
            prevOi.P1Status = oiDTO.P1Status;
            prevOi.P2Status = oiDTO.P2Status;
            prevOi.P3Status = oiDTO.P3Status;
            prevOi.P4Status = oiDTO.P4Status;
            prevOi.LastDate = oiDTO.LastDate;
            prevOi.LastInt= oiDTO.LastInt;
            prevOi.UId = oiDTO.UId;
            prevOi.ACSign = oiDTO.ACSign;
            prevOi.CloseDate = oiDTO.CloseDate;
            prevOi.Budget = oiDTO.Budget;
            prevOi.TODCloseDate= oiDTO.TODCloseDate;
            prevOi.SourceBr = oiDTO.SourceBr;
            prevOi.Cur= oiDTO.Cur;
            prevOi.Active = oiDTO.Active;
            prevOi.TS = oiDTO.TS;
            prevOi.CreatedDate = oiDTO.CreatedDate;
            prevOi.CreatedUserId = oiDTO.CreatedUserId;
            prevOi.UpdatedUserId = oiDTO.UpdatedUserId;
            prevOi.UpdatedDate = oiDTO.UpdatedDate;

            return prevOi;

        }
        private MNMORM00025 GetTypeCommit(MNMDTO00011 commitDTO)
        {
            MNMORM00025 prevCommit = new MNMORM00025();
            prevCommit.Id = commitDTO.Id;
            prevCommit.Acctno = commitDTO.Acctno;
            prevCommit.LNo = commitDTO.LNo;
            prevCommit.M1 = commitDTO.M1;
            prevCommit.M2 = commitDTO.M2;
            prevCommit.M3 = commitDTO.M3;
            prevCommit.M4 = commitDTO.M4;
            prevCommit.M5 = commitDTO.M5;
            prevCommit.M6 = commitDTO.M6;
            prevCommit.M7 = commitDTO.M7;
            prevCommit.M8 = commitDTO.M8;
            prevCommit.M9 = commitDTO.M9;
            prevCommit.M10 = commitDTO.M10;
            prevCommit.M11 = commitDTO.M11;
            prevCommit.M12 = commitDTO.M12;
            prevCommit.P1Status = commitDTO.P1Status;
            prevCommit.P2Status = commitDTO.P2Status;
            prevCommit.P3Status = commitDTO.P3Status;
            prevCommit.P4Status = commitDTO.P4Status;
            prevCommit.LastDate = commitDTO.LastDate;
            prevCommit.LastInt = commitDTO.LastInt;
            prevCommit.UserNo = commitDTO.UserNo;
            prevCommit.ACSign = commitDTO.ACSign;
            prevCommit.CloseDate = commitDTO.CloseDate;
            prevCommit.Budget = commitDTO.Budget;
            prevCommit.TODCloseDate = commitDTO.TODCloseDate;
            prevCommit.UId = commitDTO.UId;
            prevCommit.SourceBr = commitDTO.SourceBr;
            prevCommit.Cur = commitDTO.Cur;
            prevCommit.Active = commitDTO.Active;
            prevCommit.TS = commitDTO.TS;
            prevCommit.CreatedDate = commitDTO.CreatedDate;
            prevCommit.CreatedUserId = commitDTO.CreatedUserId;
            prevCommit.UpdatedDate = commitDTO.UpdatedDate;
            prevCommit.UpdatedUserId = commitDTO.UpdatedUserId;

            return prevCommit;

        }
        private MNMORM00018 GetTypeLI(LOMDTO00021 liDTO)
        {
            MNMORM00018 prevLi = new MNMORM00018();
            prevLi.ID = liDTO.Id;
            prevLi.LNo = liDTO.LNo;
            prevLi.Acctno = liDTO.Acctno;
            prevLi.Q1 = liDTO.Q1;
            prevLi.Q2 = liDTO.Q2;
            prevLi.Q3 = liDTO.Q3;
            prevLi.Q4 = liDTO.Q4;
            prevLi.QBal1 = liDTO.QBal1;
            prevLi.QBal2 = liDTO.QBal2;
            prevLi.QBal3 = liDTO.QBal3;
            prevLi.QBal4 = liDTO.QBal4;
            prevLi.UserNo = liDTO.UserNo;
            prevLi.ACSign = liDTO.ACSign;
            prevLi.CloseDate = liDTO.CloseDate;
            prevLi.Budget = liDTO.Budget;
            prevLi.UId = liDTO.UId;
            prevLi.SourceBr = liDTO.SourceBr;
            prevLi.Cur = liDTO.Cur;
            prevLi.Active = liDTO.Active;
            prevLi.TS = liDTO.TS;
            prevLi.CreatedUserId = liDTO.CreatedUserId;
            prevLi.CreatedDate = liDTO.CreatedDate;
            prevLi.UpdatedUserId = liDTO.UpdatedUserId;
            prevLi.UpdatedDate = liDTO.UpdatedDate;
            return prevLi;

        }
        private LOMORM00302 GetTypeFarmLI(LOMDTO00085 farmliDTO)
        {
            LOMORM00302 prevFarmLi = new LOMORM00302();
            prevFarmLi.Id = farmliDTO.Id;
            prevFarmLi.LNo = farmliDTO.LNo;
            prevFarmLi.AcctNo = farmliDTO.AcctNo;
            prevFarmLi.ACSign = farmliDTO.ACSign;
            prevFarmLi.LoanProductCode = farmliDTO.LoanProductCode;
            prevFarmLi.PrincipalAmount = farmliDTO.PrincipalAmount;
            prevFarmLi.TotalInt = farmliDTO.TotalInt;
            prevFarmLi.LastInt = farmliDTO.LastInt;
            prevFarmLi.AccuredInt = farmliDTO.AccuredInt;
            prevFarmLi.M1 = farmliDTO.M1;
            prevFarmLi.M2 = farmliDTO.M2;
            prevFarmLi.M3 = farmliDTO.M3;
            prevFarmLi.M4 = farmliDTO.M4;
            prevFarmLi.M5 = farmliDTO.M5;
            prevFarmLi.M6 = farmliDTO.M6;
            prevFarmLi.M7 = farmliDTO.M7;
            prevFarmLi.M8 = farmliDTO.M8;
            prevFarmLi.M9 = farmliDTO.M9;
            prevFarmLi.M10 = farmliDTO.M10;
            prevFarmLi.M11 = farmliDTO.M11;
            prevFarmLi.M12 = farmliDTO.M12;
            prevFarmLi.Budget = farmliDTO.Budget;
            prevFarmLi.DATE_TIME = farmliDTO.DATE_TIME;
            prevFarmLi.SourceBr = farmliDTO.SourceBr;
            prevFarmLi.Cur = farmliDTO.Cur;
            prevFarmLi.CreatedDate = farmliDTO.CreatedDate;
            prevFarmLi.CreatedUserId = farmliDTO.CreatedUserId;
            prevFarmLi.UpdatedUserId = farmliDTO.UpdatedUserId;
            prevFarmLi.UpdatedDate = farmliDTO.UpdatedDate;

            return prevFarmLi;
        }
        private MNMORM00004 GetTypeCashdeno(TLMDTO00015 cashDTO)
        {
            MNMORM00004 prev_cash = new MNMORM00004();
            prev_cash.Id =cashDTO.Id;
            prev_cash.Amount= cashDTO.Amount;
            prev_cash.DenoEntryNo=cashDTO.DenoEntryNo;
            prev_cash.TLFEntryNo= cashDTO.TlfEntryNo;      
            prev_cash.AccountType= cashDTO.AccountType;
            prev_cash.FromType =cashDTO.FromType;
            prev_cash.BranchCode= cashDTO.BranchCode;
            prev_cash.ReceiptNo=cashDTO. ReceiptNo    ;    
            prev_cash.AdjustmentAmount=cashDTO. AdjustAmount.Value;
            prev_cash.CashDate=cashDTO.CashDate.Value;
            prev_cash.DenoDetail=cashDTO.DenoDetail;
            prev_cash.DenoRefundDetail=cashDTO.DenoRefundDetail ;
            prev_cash.UserNo= cashDTO.UserNo ;
            prev_cash.CounterNo=cashDTO.CounterNo;
            prev_cash.Status=cashDTO. Status;
            prev_cash.Reverse=cashDTO.Reverse.Value;
            prev_cash.UId=cashDTO. UniqueId ;
            prev_cash.SourceBranchCode= cashDTO.SourceBranchCode;
            prev_cash.Currency= cashDTO.Currency ;
            prev_cash.DenoRate= cashDTO.DenoRate;
            prev_cash.DenoRefundRate= cashDTO.DenoRefundRate ;
            prev_cash.SettlementDate=cashDTO.SettlementDate.Value;
            prev_cash.AllDenoRate=cashDTO. AllDenoRate ;
            prev_cash.Rate= cashDTO.Rate.Value;

            return prev_cash;

        }
        private MNMORM00003 GetTypeDepodeno(TLMDTO00009 depoDTO)
        {
            MNMORM00003 prev_depo = new MNMORM00003();

            prev_depo.GroupNo = depoDTO.GroupNo;
            prev_depo.Tlf_Eno = depoDTO.Tlf_Eno;
            prev_depo.AcType = depoDTO.AccountType;
            prev_depo.Amount = depoDTO.Amount;
            prev_depo.Reverse_Status = depoDTO.Reverse_Status;
            prev_depo.Income = depoDTO.Income;
            prev_depo.CommuCharge = depoDTO.Communicationcharge;
            prev_depo.UId = depoDTO.UniqueId;
            prev_depo.SourceBr = depoDTO.SourceBranchCode;
            prev_depo.Cur = depoDTO.Currency;

           return prev_depo;

        }
        private MNMORM00016 GetTypeBal(PFMDTO00033 balDTO)
        {
            MNMORM00016 prev_bal = new MNMORM00016();
            prev_bal.Id = balDTO.Id;
            prev_bal.AcctNo = balDTO.AccountNo;
            prev_bal.Cur = balDTO.CurrencyCode;
            prev_bal.DATE_TIME = balDTO.DATE_TIME;
            prev_bal.USERNO = balDTO.USERNO;
            prev_bal.CloseDate = balDTO.CloseDate;
            prev_bal.Budget = balDTO.Budget;
            prev_bal.ACSign = balDTO.AccountSign;
            prev_bal.M1 = balDTO.Month1;
            prev_bal.TCount1 = balDTO.TransactionCountOfMonth1;
            prev_bal.M2 = balDTO.Month2;
            prev_bal.TCount2 = balDTO.TransactionCountOfMonth2;
            prev_bal.M3 = balDTO.Month3;
            prev_bal.TCount3 = balDTO.TransactionCountOfMonth3;
            prev_bal.M4 = balDTO.Month4;
            prev_bal.TCount4 = balDTO.TransactionCountOfMonth4;
            prev_bal.M5 = balDTO.Month5;
            prev_bal.TCount5 = balDTO.TransactionCountOfMonth5;
            prev_bal.M6 = balDTO.Month6;
            prev_bal.TCount6 = balDTO.TransactionCountOfMonth6;
            prev_bal.M7 = balDTO.Month7;
            prev_bal.TCount7 = balDTO.TransactionCountOfMonth7;
            prev_bal.M8 = balDTO.Month8;
            prev_bal.TCount8 = balDTO.TransactionCountOfMonth8;
            prev_bal.M9 = balDTO.Month9;
            prev_bal.TCount9 = balDTO.TransactionCountOfMonth9;
            prev_bal.M10 = balDTO.Month10;
            prev_bal.TCount10 = balDTO.TransactionCountOfMonth10;
            prev_bal.M11= balDTO.Month11;
            prev_bal.TCount11 = balDTO.TransactionCountOfMonth11;
            prev_bal.M12 = balDTO.Month12;
            prev_bal.TCount12 = balDTO.TransactionCountOfMonth12;
            prev_bal.SourceBr = balDTO.SourceBranchCode;

            return prev_bal;

        }
        private TLMORM00024 GetTypeIBLTLF(TLMDTO00004 ibltlfDTO)
        {
            TLMORM00024 prev_ibltlf = new TLMORM00024();

            prev_ibltlf.Id = ibltlfDTO.Id;
            prev_ibltlf.FromBranch = ibltlfDTO.FromBranch;
            prev_ibltlf.ToBranch = ibltlfDTO.ToBranch;
            prev_ibltlf.AcctNo = ibltlfDTO.AccountNo;
            prev_ibltlf.Amount = ibltlfDTO.Amount;
            prev_ibltlf.TranType = ibltlfDTO.TranType;
            prev_ibltlf.DATE_TIME = ibltlfDTO.Date_Time;
            prev_ibltlf.InOut = ibltlfDTO.InOut;
            prev_ibltlf.Success = ibltlfDTO.Success;
            prev_ibltlf.ENo = ibltlfDTO.Eno;
            prev_ibltlf.USERNO = ibltlfDTO.UserNo;
            prev_ibltlf.Cheque = ibltlfDTO.Cheque;
            prev_ibltlf.Income =ibltlfDTO.Income;
            prev_ibltlf. CommuCharge =ibltlfDTO.Communicationcharge;
            prev_ibltlf.Reversal=ibltlfDTO.Reversal;
            prev_ibltlf.IncomeType =ibltlfDTO.IncomeType;
            prev_ibltlf.RelatedAC =ibltlfDTO.RelatedAccount;
            prev_ibltlf.RelatedBr=ibltlfDTO.RelatedBranch;
            prev_ibltlf.UID =ibltlfDTO.UniqueId;
            prev_ibltlf.SourceBr=ibltlfDTO.SourceBranchCode;
            prev_ibltlf.Cur = ibltlfDTO.Currency;

            return prev_ibltlf;
        }
        private MNMORM00002 GetTypePO(TLMDTO00016 poDTO)
        {
            MNMORM00002 prev_po = new MNMORM00002();
            prev_po.PONo    = poDTO.PONo;
            prev_po.ACCTNO = poDTO.AccountNo;
            prev_po.AMOUNT  = poDTO.Amount;
            prev_po.ADATE   = poDTO.ADate;
            prev_po.IDATE   = poDTO.IDate;
            prev_po.STATUS  = poDTO.Status;
            prev_po.TOACCTNO = poDTO.ToAccountNo;
            prev_po.CHECKNO = poDTO.CheckNo;
            prev_po.INCOME  = poDTO.Income;
            prev_po.USERNO  = poDTO.UserNo;
            prev_po.ACSIGN  = poDTO.AcSign;
            prev_po.CHARGES = poDTO.Charges;
            prev_po.ACODE   = poDTO.ACode;
            prev_po.BUDGET  = poDTO.Budget;
            prev_po.UID     = poDTO.UniqueId;
            prev_po.SOURCEBR = poDTO.SourceBranchCode;
            prev_po.CUR     = poDTO.Currency;
            prev_po.RATE    = poDTO.Rate;
            prev_po.SETTLEMENTDATE = poDTO.SettlementDate;
            prev_po.REFUNDSDATE = poDTO.RefundDate;
                
            return prev_po;
                 
        }
        private MNMORM00020 GetTypeRD(TLMDTO00017 rdDTO)
        {
            MNMORM00020 prev_rd = new MNMORM00020();
            prev_rd.REGISTERNO =rdDTO.RegisterNo;
            prev_rd.DRAWINGNO = rdDTO.DrawingNo;
            prev_rd.DRAFTNO = rdDTO.DraftNo;
            prev_rd.DBANK = rdDTO.Dbank;
            prev_rd.BR_ALIAS = rdDTO.Br_Alias;
            prev_rd.TYPE = rdDTO.Type;
            prev_rd.ACCTNO = rdDTO.AccountNo;
            prev_rd.NAME = rdDTO.Name;
            prev_rd.ADDRESS = rdDTO.Address;
            prev_rd.NRC = rdDTO.NRC;
            prev_rd.CHECKNO = rdDTO.CheckNo;
            prev_rd.TOACCTNO = rdDTO.ToAccountNo;
            prev_rd.TONAME  = rdDTO.ToName;
            prev_rd.TONRC=rdDTO.ToNRC;
            prev_rd.TOADDRESS = rdDTO.ToAddress;
            prev_rd.TESTKEY=rdDTO.TestKey;
            prev_rd.AMOUNT=rdDTO.Amount;
            prev_rd.COMMISSION=rdDTO.Commission;
            prev_rd.TLXCHARGES=rdDTO.TlxCharges;
            prev_rd.DATE_TIME=rdDTO.DateTime;
            prev_rd.RECEIPTDATE=rdDTO.ReceiptDate;
            prev_rd.INCOMEDATE=rdDTO.IncomeDate;
            prev_rd.RDTYPE =rdDTO.RDType;
            prev_rd.INCOMETYPE=rdDTO.IncomeType;
            prev_rd.ACSIGN =rdDTO.AccountSign;
            prev_rd.USERNO =rdDTO.UserNo;
            prev_rd.BUDGET = rdDTO.Budget;
            prev_rd.SENDDATE =rdDTO .SendDate;
            prev_rd.LOANSERIAL =rdDTO.LoanSerial;
            prev_rd.DENO_STATUS =rdDTO.Deno_Status;
            prev_rd.PHONENO =rdDTO.PhoneNo;
            prev_rd.TOPHONENO =rdDTO.ToPhoneNo;
            prev_rd.NARRATION =rdDTO.Narration;
            prev_rd.UID = rdDTO.UniqueId;
            prev_rd.SOURCEBR =rdDTO.SourceBranchCode;
            prev_rd.CUR =rdDTO.Currency;
            prev_rd.CHANNEL =rdDTO.Channel;
            prev_rd.SETTLEMENTDATE = rdDTO.SettlementDate;
            
            return prev_rd;
        }
        private MNMORM00019 GetTypeRE(TLMDTO00001 reDTO)
        {
            MNMORM00019 prev_re = new MNMORM00019();

              prev_re.RegisterNo=reDTO.RegisterNo;
              prev_re.EncashNo =reDTO .EncashNo;
              prev_re.Ebank=reDTO.Ebank;
              prev_re.Br_Alias =reDTO.Br_Alias;
              prev_re.Type =reDTO.Type;
              prev_re.Name=reDTO.Name;
              prev_re.NRC=reDTO.NRC;
              prev_re.ToAccountNo =reDTO.ToAccountNo;
              prev_re.ToName =reDTO.ToName;
              prev_re.ToNRC =reDTO.ToNRC;
              prev_re.ToAddress =reDTO.ToAddress;
              prev_re.TestKey =reDTO.TestKey;
              prev_re.Amount =reDTO.Amount;
              prev_re.Date_Time=reDTO.Date_Time;
              prev_re.IssueDate =reDTO.IssueDate;
              prev_re.AccountSign =reDTO.AccountSign;
              prev_re.UserNo=reDTO.UserNo;
              prev_re.Budget =reDTO.Budget;
              prev_re.PrintStatus =reDTO.PrintStatus;
              prev_re.PhoneNo=reDTO.PhoneNo;
              prev_re.ToPhoneNo =reDTO.ToPhoneNo;
              prev_re.UniqueId =reDTO.UniqueId;
              prev_re.SourceBranchCode =reDTO.SourceBranchCode;
              prev_re.Currency =reDTO.Currency;
              prev_re.SettlementDate = reDTO.SettlementDate;

              return prev_re;
        }
        #endregion


       
    }
}
