using System.Collections.Generic;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using System;

namespace Ace.Cbs.Pfm.Ctr.Dao
{
    public interface IPFMDAO00056 : IDataRepository<PFMORM00056>
    {
        PFMDTO00056 SelectSys001Info(string sourcebr, string name); //added by ASDA
        bool UpdateStatusByName(int updatedUserId, string name, string status, DateTime datetime);
        bool UpdateStatusByNameForLoanVoucher(int updatedUserId, string status, DateTime datetime, string sourcebr);
        bool CheckExist(int id, string name);
        //bool CheckExist(int id, string name, string branchCount);
        IList<PFMDTO00056> CheckExist2(int id, string name);
        IList<PFMDTO00056> SelectAll();
        PFMDTO00056 SelectById(int id);
        DateTime SelectSysDate(string name, string sourceBr);
        Boolean SelectbyMonthClose(string name, string sourceBr);
        string Selectpostyear(string name, string sourceBr);
        bool UpdateDatePosting(string name, string sourceBr, int updateUserID);
        string Selectmonthstatus(string name, string sourceBr);
        PFMDTO00056 SelectAllByName(string name, string sourceBr);
        bool UpdateDateDailyPosting(string name, DateTime date, string sourceBr, int updateUserID);
        bool UpdateSysDateForCutOff(string branchCode, DateTime nextSettlementDate, DateTime lastSettlementDate, int updatedUserId);
        //PFMDTO00056 SelectAllByName(string name);
        IList<PFMDTO00056> SelectSys001ForMonthBefore(string sourceBr);

        PFMDTO00056 SelectAllByNameAndSysDateAndStatus(string name, string status);
        bool UpdateStatusSys001(int updatedUserId, string name, string status, string sourceBr);
        bool UpdateSysMonYear(string sysMonYear, int updatedUserId, string name, string sourceBr);
        bool UpdateStatusAndSysMonYear(string status, string sysMonYear, DateTime sysDate, int updatedUserId, string name, string sourceBr);

        //IList<PFMDTO00056> SelectDataForCutOffandCashClosing(string nextName, string lastName, string branchCode); 
        IList<PFMDTO00056> SelectAllAutoPayStatusList(string sourceBr);//Added by  HMW (22-May-2019)
    }
}
