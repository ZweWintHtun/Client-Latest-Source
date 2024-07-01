//----------------------------------------------------------------------
// <copyright file="Fixed year end interest calculation" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Khin Swe Win</CreatedUser>
// <CreatedDate>2014/07/15</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Windows.Core.Service;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Mnm.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Cx.Com.Utt;
//using Ace.Cbs.Cx.Ser.Dao;
using Ace.Cbs.Cx.Com.Ctr;

namespace Ace.Cbs.Mnm.Sve
{
    public class MNMSVE00142 : BaseService, IMNMSVE00142
    {

        #region Properties

        private IPFMDAO00056 sys001DAO;
        public IPFMDAO00056 Sys001DAO
        {
            get { return this.sys001DAO; }
            set { this.sys001DAO = value; }
        }
        private IPFMDAO00057 newSetupDAO;
        public IPFMDAO00057 NewSetupDAO
        {
            get { return this.newSetupDAO; }
            set { this.newSetupDAO = value; }
        }

        private ICXDAO00010 fixedEndDAO;
        public ICXDAO00010 ProcedureDAO
        {
            get { return this.fixedEndDAO; }
            set { this.fixedEndDAO = value; }
        }

        private IMNMDAO00041 tfixedDateDAO;
        public IMNMDAO00041 TfixedDateDAO
        {
            get { return this.tfixedDateDAO; }
            set { this.tfixedDateDAO = value; }
        }

        private IMNMDAO00042 tfixedDAO;
        public IMNMDAO00042 TfixedDAO
        {
            get { return this.tfixedDAO; }
            set { this.tfixedDAO = value; }
        }

        private IPFMDAO00032 freceiptDAO;
        public IPFMDAO00032 FreceiptDAO
        {
            get { return this.freceiptDAO; }
            set { this.freceiptDAO = value; }
        }
       
        private MNMORM00042 freceiptInfo;
        private MNMORM00041 freceiptDateInfo;
        #endregion
        public PFMDTO00057 newSetupDTO;
        #region variables
        string fixDuration;
        string sysname, dateStart, dateEnd;
        DateTime startDate, endDate;
        #endregion

        #region fixed year end interest post

        [Transaction(TransactionPropagation.Required)]
        public void ProcessInterest(string sourceBr, DateTime date, int user)
        {
            #region old
            //if (date.Month.ToString() != "3")
            //{
            //    if (date.Month.ToString() != "9")
            //    {
            //        this.ServiceResult.ErrorOccurred = false;
            //        this.ServiceResult.MessageCode = "MI30051";  //No need to run for this month!

            //        return;
            //    }
            //}           
            //string sysname = "FIX_BUDEND_CAL";
            //string sys001Selectdate = this.Sys001DAO.Selectpostyear(sysname, sourceBr);
            //DateTime sys001Date = Convert.ToDateTime(sys001Selectdate);
            //string code=string.Empty;
            //string yearEdate9str = date.Year.ToString() + "/09/30";
            //string yearEdate3str = date.Year.ToString() + "/03/31";

            //DateTime yearEdate9 = Convert.ToDateTime(yearEdate9str);
            //DateTime yearEdate3 = Convert.ToDateTime(yearEdate3str);
            //if (sys001Selectdate != null)
            //{
            //    if (sys001Date.Month.ToString() == date.Month.ToString())
            //    {
            //         this.ServiceResult.ErrorOccurred = false;
            //         this.ServiceResult.MessageCode = "MI30052";  //Fixed Year End Interest Calculation Process is already Calculated !
            //         return;
            //    }
            //}
            //try
            //{
            //    if (date.Month.ToString() == "3")
            //    {
            //        code = this.ProcedureDAO.ProcessFixedYearendInterest(date, yearEdate3, "10/01", "03/31", user, sourceBr, 0);
            //    }

            //    else if (date.Month.ToString() == "9")
            //    {
            //        code = this.ProcedureDAO.ProcessFixedYearendInterest(date, yearEdate9, "04/01", "09/30", user, sourceBr, 0);
            //    }

            //    if (code == null || code == "0")
            //    {
            //        this.ServiceResult.ErrorOccurred = false;
            //        this.ServiceResult.MessageCode = "MI30053"; //No Fixed Deposit Account to Calculate Interest! 
            //        return;
            //    }

            //    else
            //    {
            //        if (date.Month.ToString() == "3")
            //        {
            //            bool status = Sys001DAO.UpdateStatusAndSysMonYear(null, "03/" + date.Year.ToString(), date, user, sysname, sourceBr);
            //        }

            //        else if (date.Month.ToString() == "9")
            //        {
            //            bool status = Sys001DAO.UpdateStatusAndSysMonYear(null, "09/" + date.Year.ToString(), date, user, sysname, sourceBr);
            //        }

            //        this.ServiceResult.ErrorOccurred = true;
            //        this.ServiceResult.MessageCode = "MI30054"; //Fixed Year End Interest Calculation Process is Successfully Completed!
            //        return;
            //    }
            //}
            #endregion
            fixDuration = string.Empty;
            string sysname = "FIX_BUDEND_CAL";
            string sys001Selectdate = this.Sys001DAO.Selectpostyear(sysname, sourceBr);
            DateTime sys001Date = Convert.ToDateTime(sys001Selectdate);

            if (sys001Selectdate != null)
            {
                if (sys001Date.Month.ToString() == date.Month.ToString() && sys001Date.Year.ToString() == date.Year.ToString())
                {
                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = "MI30052";  //Fixed Year End Interest Calculation Process is already Calculated !
                    return;
                }
            } 
            /// get fixed accured duration from newsetup////
            string name = "Fix_Post_Duration";

             newSetupDTO = this.NewSetupDAO.SelectByVariable(name);
            if (newSetupDTO != null)
            {
                fixDuration = newSetupDTO.Value;
            }
            else
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI90105";  //Fixed Year End Interest Calculation Process is already Calculated !
                return;
            }
            this.ServiceResult.ErrorOccurred = true;
            return;
        }
        [Transaction(TransactionPropagation.Required)]
        public void UpdateInterest(string sourceBr, DateTime date, int user)
        {
            fixDuration ="12";
            sysname = "FIX_BUDEND_CAL";
            try
            {
                if (fixDuration == "1")
                {
                    dateStart = date.Year.ToString() + "/" + date.Month.ToString() + "/01";
                    var lastDayOfMonth = DateTime.DaysInMonth(date.Year, date.Month);
                    dateEnd = date.Year.ToString() + "/" + date.Month.ToString() + "/" + lastDayOfMonth;

                    startDate = Convert.ToDateTime(dateStart);
                    endDate = Convert.ToDateTime(dateEnd);

                    string code = string.Empty;
                    code = this.ProcedureDAO.ProcessFixedYearendInterest(startDate, endDate, "04/02", "03/31", user, sourceBr, 0);
                    if (code == null || code == "0")
                    {
                        this.ServiceResult.ErrorOccurred = false;
                        this.ServiceResult.MessageCode = "MI30053"; //No Fixed Deposit Account to Calculate Interest! 
                        return;
                    }
                    else
                    {
                        bool status = Sys001DAO.UpdateStatusAndSysMonYear(null, date.Month.ToString() + "/" + date.Year.ToString(), date, user, sysname, sourceBr);
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = "MI30054"; //Fixed Year End Interest Calculation Process is Successfully Completed!
                        return;
                    }
                }
                else if (fixDuration == "3")
                {
                    if (date.Month.ToString() == "3" || date.Month.ToString() == "6" || date.Month.ToString() == "9" || date.Month.ToString() == "12")
                    {
                        int month = Convert.ToInt16(date.Month.ToString()) - 2;
                        dateStart = date.Year.ToString() + "/" + month.ToString() + "/01";
                        var lastDayOfMonth = DateTime.DaysInMonth(date.Year, date.Month);
                        dateEnd = date.Year.ToString() + "/" + date.Month.ToString() + "/" + lastDayOfMonth;

                        startDate = Convert.ToDateTime(dateStart);
                        endDate = Convert.ToDateTime(dateEnd);

                        string code = string.Empty;
                        code = this.ProcedureDAO.ProcessFixedYearendInterest(startDate, endDate, "04/02", "03/31", user, sourceBr, 0);
                        if (code == null || code == "0")
                        {
                            this.ServiceResult.ErrorOccurred = false;
                            this.ServiceResult.MessageCode = "MI30053"; //No Fixed Deposit Account to Calculate Interest! 
                            return;
                        }
                        else
                        {
                            bool status = Sys001DAO.UpdateStatusAndSysMonYear(null, date.Month.ToString() + "/" + date.Year.ToString(), date, user, sysname, sourceBr);
                            this.ServiceResult.ErrorOccurred = true;
                            this.ServiceResult.MessageCode = "MI30054"; //Fixed Year End Interest Calculation Process is Successfully Completed!
                            return;
                        }
                    }
                    else
                    {
                        this.ServiceResult.ErrorOccurred = false;
                        this.ServiceResult.MessageCode = "MI90106"; //Can not post fixed accured for this month.
                        return;
                    }
                }
                else if (fixDuration == "6")
                {
                    if (date.Month.ToString() == "9" || date.Month.ToString() == "12")
                    {
                        int month = Convert.ToInt16(date.Month.ToString()) - 5;
                        dateStart = date.Year.ToString() + "/" + month.ToString() + "/01";
                        var lastDayOfMonth = DateTime.DaysInMonth(date.Year, date.Month);
                        dateEnd = date.Year.ToString() + "/" + date.Month.ToString() + "/" + lastDayOfMonth;

                        startDate = Convert.ToDateTime(dateStart);
                        endDate = Convert.ToDateTime(dateEnd);

                        string code = string.Empty;
                        code = this.ProcedureDAO.ProcessFixedYearendInterest(startDate, endDate, "04/02", "03/31", user, sourceBr, 0);
                        if (code == null || code == "0")
                        {
                            this.ServiceResult.ErrorOccurred = false;
                            this.ServiceResult.MessageCode = "MI30053"; //No Fixed Deposit Account to Calculate Interest! 
                            return;
                        }
                        else
                        {
                            bool status = Sys001DAO.UpdateStatusAndSysMonYear(null, date.Month.ToString() + "/" + date.Year.ToString(), date, user, sysname, sourceBr);
                            this.ServiceResult.ErrorOccurred = true;
                            this.ServiceResult.MessageCode = "MI30054"; //Fixed Year End Interest Calculation Process is Successfully Completed!
                            return;
                        }
                    }
                    else
                    {
                        this.ServiceResult.ErrorOccurred = false;
                        this.ServiceResult.MessageCode = "MI90106"; //Can not post fixed accured for this month.
                        return;
                    }
                }
                else if (fixDuration == "12")
                {
                    if (date.Month.ToString() == "12")
                    {
                        int month = Convert.ToInt16(date.Month.ToString()) - 11;
                        dateStart = date.Year.ToString() + "/" + month.ToString() + "/01";
                        var lastDayOfMonth = DateTime.DaysInMonth(date.Year, date.Month);
                        dateEnd = date.Year.ToString() + "/" + date.Month.ToString() + "/" + lastDayOfMonth;

                        startDate = Convert.ToDateTime(dateStart);
                        endDate = Convert.ToDateTime(dateEnd);

                        string code = string.Empty;
                        code = this.ProcedureDAO.ProcessFixedYearendInterest(startDate, endDate, "04/02", "03/31", user, sourceBr, 0);
                        if (code == null || code == "0")
                        {
                            this.ServiceResult.ErrorOccurred = false;
                            this.ServiceResult.MessageCode = "MI30053"; //No Fixed Deposit Account to Calculate Interest! 
                            return;
                        }
                        else
                        {
                            bool status = Sys001DAO.UpdateStatusAndSysMonYear(null, date.Month.ToString() + "/" + date.Year.ToString(), date, user, sysname, sourceBr);
                            this.ServiceResult.ErrorOccurred = true;
                            this.ServiceResult.MessageCode = "MI30054"; //Fixed Year End Interest Calculation Process is Successfully Completed!
                            return;
                        }
                    }
                }
                else
                {
                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = "MI90106"; //Can not post fixed accured for this month.
                    return;
                }
               
            }
            catch (Exception e)
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "ME90043";
                //throw new Exception(CXMessage.ME90043);

            }
        }
        #endregion

        #region fixed year end prev
        public void checkDate(string sourceBr, DateTime date)
        {
            IList<MNMDTO00041> FixDatedto = this.TfixedDateDAO.SelectByStartDATE_Time(date, sourceBr);
            if (FixDatedto.Count > 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MC30010"; //Are you sure to Fixed Interest Prev_Posting again?
                return;
            }
            this.ServiceResult.ErrorOccurred = true;
        }

        public IList<PFMDTO00032> SelectfreceiptBydate(string sourceBr, DateTime date)
        {
            IList<PFMDTO00032> freciptDtolist = FreceiptDAO.SelectLastInterestDateByAll(sourceBr, date);
            return freciptDtolist;
        }

        [Transaction(TransactionPropagation.Required)]
        public void ProcessInterestPrev(string sourceBr, DateTime date, int user)
        {
            #region old
            //string sysname = "FIX_BUDEND_CAL";
            //string sys001Selectdate = this.Sys001DAO.Selectpostyear(sysname, sourceBr);
            ////StartofMonth = Format(Trim(Str((Month(Date)))) & "/01/" & Trim(Str(Year(Date))), "mm/dd/yyyy")
            ////EndofMonth = DateAdd("m", 1, StartofMonth) - 1
            //string sys001Selectdate = "01" + date.Month.ToString() + date.Year.ToString(); // start day of month
            //DateTime sys001Date = Convert.ToDateTime(sys001Selectdate);
            //string code = string.Empty;
            //string yearEdate9str = date.Year.ToString() + "/09/30";
            //string yearEdate3str = date.Year.ToString() + "/03/31";
            //DateTime yearEdate9 = Convert.ToDateTime(yearEdate9str);
            //DateTime yearEdate3 = Convert.ToDateTime(yearEdate3str);
            #endregion
            string sysname = "FIX_BUDEND_CAL";
            string sys001Selectdate = this.Sys001DAO.Selectpostyear(sysname, sourceBr);
            DateTime sys001Date = Convert.ToDateTime(sys001Selectdate);

            //string dateStart = date.Year.ToString() + "/" + date.Month.ToString() + "/01";
            //var lastDayOfMonth = DateTime.DaysInMonth(date.Year, date.Month);
            //string dateEnd = date.Year.ToString() + "/" + date.Month.ToString() + "/" + lastDayOfMonth;

            //DateTime startDate = Convert.ToDateTime(dateStart);
            //DateTime endDate = Convert.ToDateTime(dateEnd);

            if (sys001Selectdate != null)
            {
                if (sys001Date.Month.ToString() == date.Month.ToString() && sys001Date.Year.ToString() == date.Year.ToString())
                {
                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = "MI30052";  //Fixed Year End Interest Calculation Process is already Calculated !
                    return;
                }
            }
            bool deletetemp = TfixedDAO.DeleteTemptable(sourceBr);
            IList<PFMDTO00032> freciptDtolist = this.SelectfreceiptBydate(sourceBr, date);
            try
            {
                foreach (PFMDTO00032 item in freciptDtolist)
                {
                    this.TfixedDAO.Save(this.GetType(item));
                }
                this.ServiceResult.ErrorOccurred = true;
                //this.ServiceResult.MessageCode = "MI30054"; //Fixed Year End Interest Calculation Process is Successfully Completed!
                return;
                //}
            }
            catch (Exception e)
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "ME90043";
                // throw new Exception(CXMessage.ME90043);

            }
        }
        [Transaction(TransactionPropagation.Required)]
        public void UpdatePre(string sourceBr, DateTime date, int user)
        {
            string code = string.Empty;
            string dateStart = date.Year.ToString() + "/" + date.Month.ToString() + "/01";
            var lastDayOfMonth = DateTime.DaysInMonth(date.Year, date.Month);
            string dateEnd = date.Year.ToString() + "/" + date.Month.ToString() + "/" + lastDayOfMonth;

            DateTime startDate = Convert.ToDateTime(dateStart);
            DateTime endDate = Convert.ToDateTime(dateEnd);

            this.TfixedDateDAO.Save(this.GetTypeTempDate(startDate, sourceBr, endDate, user));
            code = this.ProcedureDAO.ProcessFixedYearendPrevInterest(startDate, endDate, "04/01", "03/31", user, sourceBr, 0);

            if (code == null || code == "0") //storeProcedure execute 2 table and return @RETURN Value(msg),if it's err - return null. if not , return 0;
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI30053"; //No Fixed Deposit Account to Calculate Interest! 
                return;
            }
            this.ServiceResult.ErrorOccurred = true;
            this.ServiceResult.MessageCode = "MI30054"; //Fixed Year End Interest Calculation Process is Successfully Completed!
            return;

        }

        private MNMORM00042 GetType(PFMDTO00032 item)
        {
            freceiptInfo = new MNMORM00042();
            freceiptInfo.Id = item.Id;
            freceiptInfo.AcctNo = item.AccountNo;
            freceiptInfo.RNo = item.ReceiptNo;
            freceiptInfo.Amount = item.Amount;
            freceiptInfo.Duration = item.Duration;
            if (item.WithdrawDate == default(DateTime))
            {
                freceiptInfo.WDate = null;
            }
            else
            {
                freceiptInfo.WDate = item.WithdrawDate;
            }

            if (item.LastInterestDate == default(DateTime))
            {
                freceiptInfo.LasIntDate = null;
            }
            else
            {
                freceiptInfo.LasIntDate = item.LastInterestDate;
            }

            freceiptInfo.PrnTime = item.PrintTime;
            freceiptInfo.LastPrnBal = item.LastPrintBalance;
            freceiptInfo.BudEndAcc = item.BudgetEndAccount;
            freceiptInfo.BudEndTax = item.BudgetEndTax;
            freceiptInfo.Accrued = item.Accrued;
            freceiptInfo.DrAccured = item.DebitAccrued;
            freceiptInfo.APerson = item.AuthorizedPerson;
            freceiptInfo.ACSign = item.AccountSign;
            freceiptInfo.IntRate = item.InterestRate;
            freceiptInfo.AccruedStatus = item.AccuredStatus;
            freceiptInfo.FirstRNo = item.FirstReceiptNo;
            freceiptInfo.ToAcctNo = item.ToAccountNo;
            if (item.RDate == default(DateTime))
            {
                freceiptInfo.RDATE = null;
            }
            else
            {
                freceiptInfo.RDATE = item.RDate;
            }

            freceiptInfo.USERNO = item.UserNo;
            freceiptInfo.SourceBr = item.SourceBranchCode;
            freceiptInfo.Cur = item.CurrencyCode;
            if (item.LastAccruedDate == default(DateTime))
            {
                freceiptInfo.LastAccruedDate = null;
            }
            else
            {
                freceiptInfo.LastAccruedDate = item.LastAccruedDate;
            }

            freceiptInfo.Active = item.Active;
            freceiptInfo.CreatedDate = item.CreatedDate;
            freceiptInfo.CreatedUserId = item.CreatedUserId;

            if (item.UpdatedDate == default(DateTime))
            {
                freceiptInfo.UpdatedDate = null;
            }
            else
            {
                freceiptInfo.UpdatedDate = item.UpdatedDate;
            }

            freceiptInfo.UpdatedUserId = item.UpdatedUserId;

            return freceiptInfo;

        }

        private MNMORM00041 GetTypeTempDate(DateTime date, string sourceBr, DateTime budEndDate, int userId)
        {
            freceiptDateInfo = new MNMORM00041();
            freceiptDateInfo.StartDATE_Time = date;
            freceiptDateInfo.EndDATE_Time = budEndDate;
            freceiptDateInfo.Counts = 1;
            freceiptDateInfo.SourceBr = sourceBr;
            freceiptDateInfo.Active = true;
            freceiptDateInfo.CreatedDate = DateTime.Now;
            freceiptDateInfo.CreatedUserId = userId;

            return freceiptDateInfo;
        }
        #endregion


    }
}
