//----------------------------------------------------------------------
// <copyright file="MNMSVE00006.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Khin Swe Win</CreatedUser>
// <CreatedDate>05/11/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using Ace.Windows.Core.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Mnm.Ctr.Dao;
using Ace.Cbs.Mnm.Ctr.Sve;
using System.Globalization;
using Ace.Windows.Admin.Contracts.Dao;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Pfm.Dmd.DTO;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.DataModel;
using Ace.Windows.Ix.Core.DataModel;// Added by AAM (20_Sep_2018)

namespace Ace.Cbs.Mnm.Sve
{
    public class MNMSVE00006 : BaseService, IMNMSVE00006
    {
        #region Properties

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

        //private ICurrencyChargeOfAccountDAO ccoaDAO;
        //public ICurrencyChargeOfAccountDAO CcoaDAO
        //{
        //    get { return this.ccoaDAO; }
        //    set { this.ccoaDAO = value; }
        //}

        private ICXDAO00014 ccoaDAO;
        public ICXDAO00014 CcoaDAO
        {
            get { return this.ccoaDAO; }
            set { this.ccoaDAO = value; }
        }

        private IMNMDAO00010 prevccoaDAO;
        public IMNMDAO00010 PrevccoaDAO
        {
            get { return this.prevccoaDAO; }
            set { this.prevccoaDAO = value; }
        }

        private IPFMDAO00057 newSetupDAO;
        public IPFMDAO00057 NewSetupDAO
        {
            get { return this.newSetupDAO; }
            set { this.newSetupDAO = value; }
        }
        // Added by AAM (20_Sep_2018)
        private IPFMDAO00033 balDAO;
        public IPFMDAO00033 BalDAO
        {
            get { return this.balDAO; }
            set { this.balDAO = value; }
        }
        private MNMORM00010 ccoaInfo;

        string name = "MONTH_CLOSE";
        string namepost = "YEARLYPOST";
        string sysnmae = "YRPOSTDATE";
        string newSetupVariable = "budedate";

        #endregion

        #region Method
        public virtual IList<CurrencyChargeOfAccountDTO> SelectAllyearly(string sourcebr)
        {
            return this.CcoaDAO.SelectAllyearly(sourcebr);
        }

        [Transaction(TransactionPropagation.Required)]
        #region Old Code,Commented by AAM (20_Sep_2018)
        //public virtual bool Posting(string sourceBr)
        //{

        //    try
        //    {
        //        if (this.Sys001DAO.SelectbyMonthClose(name, sourceBr) == false)
        //        {
        //            return this.ServiceResult.ErrorOccurred = true;

        //        }

        //        string sys001Selectdate = this.Sys001DAO.Selectpostyear(name, sourceBr).ToString();
        //        string postSelectdate = this.SyspostDAO.SelectbyYearpost(namepost, sourceBr).ToString();
        //        string budeSelectDate = this.NewSetupDAO.SelectBudDate(newSetupVariable).ToString();
        //        string sys001YearStr = sys001Selectdate.Substring(3, 4);
        //        string syspostYearStr = postSelectdate.Substring(6, 4);
        //        string sys001MonthStr = sys001Selectdate.Substring(0, 2);
        //        //string syspostMonthStr = postSelectdate.Substring(0, 2); // Commented By AAM (31-Mar-2018)
        //        string syspostMonthStr = postSelectdate.Substring(0, 1); // Modified By AAM (31-Mar-2018)


        //        int sys001year = Convert.ToInt32(sys001YearStr);
        //        int syspostyear = Convert.ToInt32(syspostYearStr);
        //        int sys001Month = Convert.ToInt32(sys001MonthStr);
        //        int postMonth = Convert.ToInt32(syspostMonthStr);
        //        int budeYear = syspostyear + 1;

        //        //int getDateYear = Convert.ToInt32(DateTime.Now.ToShortDateString().Substring(6, 4)); // Commented By AAM (31-Mar-2018)
        //        //int getDateMonth = Convert.ToInt32(DateTime.Now.ToShortDateString().Substring(0, 2)); // Commented By AAM (31-Mar-2018)

        //        int getDateYear = Convert.ToInt32(DateTime.Now.ToShortDateString().Substring(5, 4)); // Modified By AAM (31-Mar-2018)
        //        int getDateMonth = Convert.ToInt32(DateTime.Now.ToShortDateString().Substring(0, 1)); // Modified By AAM (31-Mar-2018)

        //        int budeMonth = Convert.ToInt32(budeSelectDate.Substring(3, 2));

        //        if (sys001year < syspostyear)
        //        {
        //            return this.ServiceResult.ErrorOccurred = true;

        //        }
        //        else
        //        {
        //            if (sys001year == syspostyear)
        //            {
        //                return this.ServiceResult.ErrorOccurred = true;

        //            }
        //            else
        //            {
        //                if (sys001year < syspostyear)
        //                {
        //                    if (sys001Month < postMonth)
        //                    {
        //                        return this.ServiceResult.ErrorOccurred = true;

        //                    }
        //                }
        //            }
        //        }
        //        if (budeYear > getDateYear)
        //        {
        //            return this.ServiceResult.ErrorOccurred = true;

        //        }
        //        else
        //        {
        //            if (budeYear == getDateYear)
        //            {
        //                if (budeMonth > getDateMonth)
        //                {
        //                    return this.ServiceResult.ErrorOccurred = true;

        //                }
        //            }
        //        }

        //        return this.ServiceResult.ErrorOccurred = false;

        //    }
        //    catch (Exception)
        //    {
        //        return this.ServiceResult.ErrorOccurred = true;

        //    }
        //}
        #endregion
        //Added and modified by AAM (20_Sep_2018)
        public virtual bool Posting(string sourceBr)
        {
            //DateTime systemDate;
            try
            {
                IList<PFMDTO00079> lst = this.Get_BLFInfo_ByActiveBudget(sourceBr);
                DateTime actualYRPostDate = this.balDAO.CheckingYearlyPostingDate(lst[0].BEND_DATE);

                //Getting System Startup Date
                TCMDTO00001 startDTO = CXServiceWrapper.Instance.Invoke<ITCMSVE00014, TCMDTO00001>(x => x.SelectStartBySourceBr(sourceBr));
                if (startDTO == null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "ME90047";//System Start Up File has no record.
                    return true;
                }
                else if(startDTO.Status == "C")
                {
                    string monthClose = this.sys001DAO.Selectpostyear(name, sourceBr).ToString();
                    DateTime yearEndDate = DateTime.Parse(this.SyspostDAO.SelectbyYearpost(namepost, sourceBr).ToString());

                    if (actualYRPostDate.Date == startDTO.Date.Date)
                    {
                        if (Convert.ToInt32(monthClose.Substring(0, 2)) == startDTO.Date.Month)
                        {
                            if (Convert.ToInt32(monthClose.Substring(3, 4)) == startDTO.Date.Year)
                            {
                                if (yearEndDate.Date < startDTO.Date.Date)
                                {
                                    return false;//OK
                                }
                            }
                        }
                    }
                }

                //if (Convert.ToDateTime(actualYRPostDate).Day == DateTime.Now.Day)
                //if (actualYRPostDate == systemDate)
                //{
                //    return false;
                //}
                return true;
            }
            catch (Exception)
            {
                return this.ServiceResult.ErrorOccurred = true;
            }
        }

        [Transaction(TransactionPropagation.Required)]
        #region YearlyPosting Old Method
        //public virtual void YearlyPosting(IList<CurrencyChargeOfAccountDTO> itemList, DateTime datetime, string sourceBr,int currentUserId)
        //{

        //    if (this.Posting(sourceBr)==false)
        //    {
        //        try
        //        {
        //            foreach (CurrencyChargeOfAccountDTO item in itemList)
        //            {

        //                this.PrevccoaDAO.Save(this.GetType(item));

        //            }

        //            if (CcoaDAO.UpdateBalance(currentUserId) == false)
        //            {
        //                throw new Exception(CXMessage.ME90001); //update error
        //            }

        //            string budget = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode);

        //            string[] budgetStringArr = budget.Split('/');
        //            int[] budgetIntArr = new int[2];
        //            budgetIntArr[0] = Convert.ToInt32(budgetStringArr[0]) + 1;
        //            budgetIntArr[1] = Convert.ToInt32(budgetStringArr[1]) + 1;

        //            budget = budgetIntArr[0].ToString() + "/" + budgetIntArr[1].ToString();

        //            if (CcoaDAO.UpdateZeroBalance(budget, currentUserId) == false)
        //            {
        //                throw new Exception(CXMessage.ME90001); //update error
        //            }

        //            if (SyspostDAO.UpdateStatus(datetime, namepost, sourceBr, currentUserId) == false)
        //            {
        //                throw new Exception(CXMessage.ME90001); //update error
        //            }

        //            if (Sys001DAO.UpdateDatePosting(sysnmae, sourceBr, currentUserId) == false)
        //            {
        //                throw new Exception(CXMessage.ME90001); //update error
        //            }

        //            this.ServiceResult.ErrorOccurred = false;
        //            this.ServiceResult.MessageCode = "MI30011"; //success
        //        }

        //        catch (Exception ex)
        //        {
        //            this.ServiceResult.ErrorOccurred = true;
        //            this.ServiceResult.MessageCode = ex.Message;
        //            throw new Exception(this.ServiceResult.MessageCode);
        //        }
        //    }
        //    else
        //    {
        //        this.ServiceResult.ErrorOccurred = true;
        //        this.ServiceResult.MessageCode = "MI30010";//No Need to run Yearly Posting.
        //    }
        //}
        #endregion
        #region YearlyPosting New Method,Added and modified by AAM (20_Sep_2018)
        public virtual void YearlyPosting(DateTime datetime, string sourceBr, int currentUserId, IList<DataVersionChangedValueDTO> dvcvList)
        {
            if (this.Posting(sourceBr) == false)//Checking Already Post or not
            {
                try
                {
                    // Added by AAM(20_Sep_2018)
                    string Return = string.Empty;
                    string budget2 = newSetupDAO.GetBudget_Month_Year_Quarter(2, datetime, sourceBr, Return);
                    if (budget2 == "2018/2018")
                        newSetupDAO.YearlyPostingProcess_Initial(currentUserId, sourceBr);
                    else
                    {
                        string[] budgetStringArr = budget2.Split('/');
                        int[] budgetIntArr = new int[2];
                        budgetIntArr[0] = Convert.ToInt32(budgetStringArr[0]) + 1;
                        budgetIntArr[1] = Convert.ToInt32(budgetStringArr[1]) + 1;
                    }
                    newSetupDAO.YearlyPostingProcess(budget2, currentUserId, sourceBr);

                    //Added by HMW at 30-Sept-2019
                    PFMDTO00056 LastSettlementDateDTO = sys001DAO.SelectSys001Info(sourceBr, "YRPOSTDATE");
                    SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, currentUserId, LastSettlementDateDTO.Id.ToString());
                    Dictionary<string, object> updateColumnsandValuesForYearlyPosting = new Dictionary<string, object> { { "SysMonYear", datetime.ToString("MM/yyyy") }, { "Status", "Y" }, { "SysDate", datetime } };
                    Dictionary<string, object> whereColumnsandValuesForYearlyPosting = new Dictionary<string, object> { { "BranchCode", sourceBr }, { "Name", "YRPOSTDATE" }, { "Active", true } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("PFMORM00056", updateColumnsandValuesForYearlyPosting, whereColumnsandValuesForYearlyPosting));

                  

                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = "MI30011"; //success
                }

                catch (Exception ex)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = ex.Message;
                    throw new Exception(this.ServiceResult.MessageCode);
                }
            }
            else
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MI30010";//No Need to run Yearly Posting.
            }
        }
        #endregion

        public IList<PFMDTO00079> Get_BLFInfo_ByActiveBudget(string sourceBr)
        {
            return this.balDAO.GetBLFInfoByActiveBudget(sourceBr);
        }

        #endregion

        #region Helper Method


        private MNMORM00010 GetType(CurrencyChargeOfAccountDTO ccoaDTO)
        {

            ccoaInfo = new MNMORM00010();
            ccoaInfo.ACODE = ccoaDTO.ACODE;
            ccoaInfo.DCODE = ccoaDTO.DCODE;
            ccoaInfo.CUR = ccoaDTO.CUR;
            ccoaInfo.BF = ccoaDTO.BF;
            ccoaInfo.OBAL = ccoaDTO.OBAL;
            ccoaInfo.HOBAL = ccoaDTO.HOBAL;
            ccoaInfo.CBAL = ccoaDTO.CBAL;
            ccoaInfo.M1 = ccoaDTO.M1;
            ccoaInfo.M2 = ccoaDTO.M2;
            ccoaInfo.M3 = ccoaDTO.M3;
            ccoaInfo.M4 = ccoaDTO.M4;
            ccoaInfo.M5 = ccoaDTO.M5;
            ccoaInfo.M6 = ccoaDTO.M6;
            ccoaInfo.M7 = ccoaDTO.M7;
            ccoaInfo.M8 = ccoaDTO.M8;
            ccoaInfo.M9 = ccoaDTO.M9;
            ccoaInfo.M10 = ccoaDTO.M10;
            ccoaInfo.M11 = ccoaDTO.M11;
            ccoaInfo.M12 = ccoaDTO.M12;
            ccoaInfo.M13 = ccoaDTO.M13;
            ccoaInfo.MSRC1 = ccoaDTO.MSRC1;
            ccoaInfo.MSRC2 = ccoaDTO.MSRC2;
            ccoaInfo.MSRC3 = ccoaDTO.MSRC3;
            ccoaInfo.MSRC4 = ccoaDTO.MSRC4;
            ccoaInfo.MSRC5 = ccoaDTO.MSRC5;
            ccoaInfo.MSRC6 = ccoaDTO.MSRC6;
            ccoaInfo.MSRC7 = ccoaDTO.MSRC7;
            ccoaInfo.MSRC8 = ccoaDTO.MSRC8;
            ccoaInfo.MSRC9 = ccoaDTO.MSRC9;
            ccoaInfo.MSRC10 = ccoaDTO.MSRC10;
            ccoaInfo.MSRC11 = ccoaDTO.MSRC11;
            ccoaInfo.MSRC12 = ccoaDTO.MSRC12;
            ccoaInfo.MSRC13 = ccoaDTO.MSRC13;
            ccoaInfo.BF1 = ccoaDTO.BF1;
            ccoaInfo.BF2 = ccoaDTO.BF2;
            ccoaInfo.BF3 = ccoaDTO.BF3;
            ccoaInfo.BF4 = ccoaDTO.BF4;
            ccoaInfo.BF5 = ccoaDTO.BF5;
            ccoaInfo.BF6 = ccoaDTO.BF6;
            ccoaInfo.BF7 = ccoaDTO.BF7;
            ccoaInfo.BF8 = ccoaDTO.BF8;
            ccoaInfo.BF9 = ccoaDTO.BF9;
            ccoaInfo.BF10 = ccoaDTO.BF10;
            ccoaInfo.BF11 = ccoaDTO.BF11;
            ccoaInfo.BF12 = ccoaDTO.BF11;
            ccoaInfo.BF13 = ccoaDTO.BF13;
            ccoaInfo.BFSRC1 = ccoaDTO.BFSRC1;
            ccoaInfo.BFSRC2 = ccoaDTO.BFSRC2;
            ccoaInfo.BFSRC3 = ccoaDTO.BFSRC3;
            ccoaInfo.BFSRC4 = ccoaDTO.BFSRC4;
            ccoaInfo.BFSRC5 = ccoaDTO.BFSRC5;
            ccoaInfo.BFSRC6 = ccoaDTO.BFSRC6;
            ccoaInfo.BFSRC7 = ccoaDTO.BFSRC7;
            ccoaInfo.BFSRC8 = ccoaDTO.BFSRC8;
            ccoaInfo.BFSRC9 = ccoaDTO.BFSRC9;
            ccoaInfo.BFSRC10 = ccoaDTO.BFSRC10;
            ccoaInfo.BFSRC11 = ccoaDTO.BFSRC11;
            ccoaInfo.BFSRC12 = ccoaDTO.BFSRC12;
            ccoaInfo.BFSRC13 = ccoaDTO.BFSRC13;
            ccoaInfo.MREV1 = ccoaDTO.MREV1;
            ccoaInfo.MREV2 = ccoaDTO.MREV2;
            ccoaInfo.MREV3 = ccoaDTO.MREV3;
            ccoaInfo.MREV4 = ccoaDTO.MREV4;
            ccoaInfo.MREV5 = ccoaDTO.MREV5;
            ccoaInfo.MREV6 = ccoaDTO.MREV6;
            ccoaInfo.MREV7 = ccoaDTO.MREV7;
            ccoaInfo.MREV8 = ccoaDTO.MREV8;
            ccoaInfo.MREV9 = ccoaDTO.MREV9;
            ccoaInfo.MREV10 = ccoaDTO.MREV10;
            ccoaInfo.MREV11 = ccoaDTO.MREV11;
            ccoaInfo.MREV12 = ccoaDTO.MREV12;
            ccoaInfo.MREV13 = ccoaDTO.MREV13;
            ccoaInfo.LYMSRC1 = ccoaDTO.LYMSRC1;
            ccoaInfo.LYMSRC2 = ccoaDTO.LYMSRC2;
            ccoaInfo.LYMSRC3 = ccoaDTO.LYMSRC3;
            ccoaInfo.LYMSRC4 = ccoaDTO.LYMSRC4;
            ccoaInfo.LYMSRC5 = ccoaDTO.LYMSRC5;
            ccoaInfo.LYMSRC6 = ccoaDTO.LYMSRC6;
            ccoaInfo.LYMSRC7 = ccoaDTO.LYMSRC7;
            ccoaInfo.LYMSRC10 = ccoaDTO.LYMSRC10;
            ccoaInfo.LYMSRC11 = ccoaDTO.LYMSRC11;
            ccoaInfo.LYMSRC12 = ccoaDTO.LYMSRC12;
            ccoaInfo.LYMSRC13 = ccoaDTO.LYMSRC13;
            ccoaInfo.SCCRBAL = ccoaDTO.SCCRBAL;
            ccoaInfo.ACCRUED = ccoaDTO.ACCRUED;
            ccoaInfo.BUDGET = ccoaDTO.BUDGET;
            ccoaInfo.UID = ccoaDTO.UID;
            ccoaInfo.Active = ccoaDTO.Active;
            ccoaInfo.TS = ccoaDTO.TS;
            ccoaInfo.CreatedUserId = ccoaDTO.CreatedUserId;
            ccoaInfo.CreatedDate = ccoaDTO.CreatedDate;
            ccoaInfo.UpdatedDate = ccoaDTO.UpdatedDate;
            ccoaInfo.UpdatedUserId = ccoaDTO.UpdatedUserId;


            return ccoaInfo;

        }

        #endregion

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
    }
}
