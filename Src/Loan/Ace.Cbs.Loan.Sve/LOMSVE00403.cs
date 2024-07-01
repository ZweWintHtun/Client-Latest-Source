using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Cx.Com.Utt;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXServer.Utt;
using Ace.Windows.Core.DataModel;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Cbs.Loan.Dmd.DTO;

namespace Ace.Cbs.Loan.Sve
{
    public class LOMSVE00403 : BaseService, ILOMSVE00403
    {

        #region Properties

        public ICXSVE00002 CodeGenerator { get; set; }

        private ILOMDAO00403 businessLoansDAO;
        public ILOMDAO00403 BusinessLoansDAO
        {
            get { return this.businessLoansDAO; }
            set { this.businessLoansDAO = value; }
        }

        private IPFMDAO00056 sys001DAO;
        public IPFMDAO00056 Sys001DAO
        {
            get { return this.sys001DAO; }
            set { this.sys001DAO = value; }
        }

        public ILOMDAO00406 BLDetailsDAO { get; set; }
        #endregion

        #region Methods
        public string BusinessLoansLateFeesCalculationProcess(string sourceBr, int createdUserId, string userName, IList<DataVersionChangedValueDTO> dvcvList,DateTime lateFeeRunDate)
        {
            try
            {
                DateTime sys001 = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("LastSettlementDate"), sourceBr, true });
                DateTime blLateFeesRunDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("NextSettlementDate"), sourceBr, true });

                string day = sys001.Day.ToString().PadLeft(2, '0');
                string month = sys001.Month.ToString().PadLeft(2, '0');
                string year = sys001.Year.ToString().Substring(2);
                int updatedUserId = createdUserId;

                string Eno = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, updatedUserId, sourceBr, new object[] { day, month, year });

                string retMsg = this.BusinessLoansDAO.BusinessLoansLateFeesCalculationProcess(sourceBr, createdUserId, userName);
                if (retMsg == "0")
                {
                    this.ServiceResult.ErrorOccurred = false;

                    //For BLLateFees_AutoRun
                    PFMDTO00056 InterestDateDTO = Sys001DAO.SelectSys001Info(sourceBr, "BLLateFees_AutoRun");
                    SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, createdUserId, InterestDateDTO.Id.ToString());
                    Dictionary<string, object> updateColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "SysDate", sys001.AddDays(-1) } };
                    Dictionary<string, object> whereColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "BranchCode", sourceBr }, { "Name", "BLLateFees_AutoRun" }, { "Active", true } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("PFMORM00056", updateColumnsandValuesForLoansInterestCalculation, whereColumnsandValuesForLoansInterestCalculation));

                    this.ServiceResult.MessageCode = CXMessage.MV90167;//Business Loan Late Fees Calculation Process is successfully finished!
                }
                else
                {

                    this.ServiceResult.ErrorOccurred = true;

                    //For BLLateFees_AutoRun
                    PFMDTO00056 InterestDateDTO = Sys001DAO.SelectSys001Info(sourceBr, "BLLateFees_AutoRun");
                    SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, createdUserId, InterestDateDTO.Id.ToString());
                    Dictionary<string, object> updateColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "SysDate", blLateFeesRunDate.AddDays(-1) } };
                    Dictionary<string, object> whereColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "BranchCode", sourceBr }, { "Name", "BLLateFees_AutoRun" }, { "Active", true } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("PFMORM00056", updateColumnsandValuesForLoansInterestCalculation, whereColumnsandValuesForLoansInterestCalculation));

                    this.sys001DAO.UpdateDateDailyPosting("BLLateFees_AutoRun", blLateFeesRunDate.AddDays(-1), sourceBr, createdUserId);

                }
                return retMsg;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string BusinessLoansMonthlyAutoPaymentProc(string sourceBr, int createdUserId, string userName, IList<DataVersionChangedValueDTO> dvcvList, DateTime AutoPayRunDate)
        {
            DateTime lastSettlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("LastSettlementDate"), sourceBr, true });
            DateTime transactionDate;
            if (lastSettlementDate.Date == DateTime.Now.Date)
            {
                transactionDate = DateTime.Now; //For Current Date Transaction
            }
            else
            {
                string lastSDate = lastSettlementDate.ToString("yyyy-MM-dd") + " " + "23:59:07.000"; // To update SQLite data
                transactionDate = DateTime.Parse(lastSDate);//For Back Date Transaction
            }

            try
            {
                DateTime sys001 = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("LastSettlementDate"), sourceBr, true });

                //Comment & Modified by HMW at (06-08-2019) : Generate ENO at Script side to prevent "Voucher No Loss Issue" in every already run (or) no need to run case.
                //string day = sys001.Day.ToString().PadLeft(2, '0');
                //string month = sys001.Month.ToString().PadLeft(2, '0');
                //string year = sys001.Year.ToString().Substring(2);
                //int updatedUserId = createdUserId; 
               
                //string Eno = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, updatedUserId, sourceBr, new object[] { day, month, year }); ;
                //string retMsg = this.BusinessLoansDAO.BusinessLoansMonthlyAutoPaymentProc(Eno, sourceBr, createdUserId, userName);
                          

                string retMsg = this.BusinessLoansDAO.BusinessLoansMonthlyAutoPaymentProc(sourceBr, createdUserId, userName);                
                if (retMsg == "0")
                {
                    //For BLMonthly_AutoPay
                    PFMDTO00056 InterestDateDTO = Sys001DAO.SelectSys001Info(sourceBr, "BLMonthly_AutoPay");
                    SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, createdUserId, InterestDateDTO.Id.ToString());
                    //Dictionary<string, object> updateColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "SysDate", DateTime.Now } };
                    Dictionary<string, object> updateColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "SysDate", transactionDate } };
                    Dictionary<string, object> whereColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "BranchCode", sourceBr }, { "Name", "BLMonthly_AutoPay" }, { "Active", true } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("PFMORM00056", updateColumnsandValuesForLoansInterestCalculation, whereColumnsandValuesForLoansInterestCalculation));

                    //this.sys001DAO.UpdateDateDailyPosting("BLMonthly_AutoPay", DateTime.Now, sourceBr, createdUserId);

                    //this.ServiceResult.MessageCode = CXMessage.MI90115;//Personal Loan Auto Payment Process is successfully finished.
                    
                    // Added By AAM (23-Nov-2017)
                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = CXMessage.MI90124; // Business Loan AutoPayment Process Successfully Finished.
                }
                else if (retMsg == "-1")
                {
                    #region
                    //this.ServiceResult.ErrorOccurred = true;
                    ////this.ServiceResult.MessageCode = CXMessage.MV90154;//No need to run auto pay process in this date!
                    //PFMDTO00056 InterestDateDTO = Sys001DAO.SelectSys001Info(sourceBr, "BLMonthly_AutoPay");
                    //SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, createdUserId, InterestDateDTO.Id.ToString());
                    //Dictionary<string, object> updateColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "SysDate", DateTime.Now } };
                    //Dictionary<string, object> whereColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "BranchCode", sourceBr }, { "Name", "BLMonthly_AutoPay" }, { "Active", true } };
                    //CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("PFMORM00056", updateColumnsandValuesForLoansInterestCalculation, whereColumnsandValuesForLoansInterestCalculation));

                    //this.sys001DAO.UpdateDateDailyPosting("BLMonthly_AutoPay", DateTime.Now, sourceBr, createdUserId);
                    #endregion
                    
                    // Added By AAM (23-Nov-2017)
                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = CXMessage.MV90154;//No need to run auto pay process in this date!

                }
                else if (retMsg == "-2")
                {
                    #region
                    // this.ServiceResult.ErrorOccurred = true;
                   //// this.ServiceResult.MessageCode = CXMessage.MV90161;//Already Run Personal Loan Auto Payment Process!
                   // PFMDTO00056 InterestDateDTO = Sys001DAO.SelectSys001Info(sourceBr, "BLMonthly_AutoPay");
                   // SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, createdUserId, InterestDateDTO.Id.ToString());
                   // Dictionary<string, object> updateColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "SysDate", DateTime.Now } };
                   // Dictionary<string, object> whereColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "BranchCode", sourceBr }, { "Name", "BLMonthly_AutoPay" }, { "Active", true } };
                   // CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("PFMORM00056", updateColumnsandValuesForLoansInterestCalculation, whereColumnsandValuesForLoansInterestCalculation));

                    // this.sys001DAO.UpdateDateDailyPosting("BLMonthly_AutoPay", DateTime.Now, sourceBr, createdUserId);
                    #endregion
                    // Added By AAM (23-Nov-2017)
                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = CXMessage.MV90171;//Already Run Business Loan Auto Payment Process!.

                }
                else //if (retMsg == "-3") Modified By AAM (23-Nov-2017)
                {
                    this.ServiceResult.ErrorOccurred = true;  //Added By AAM (23-Nov-2017)
                    this.ServiceResult.MessageCode = CXMessage.MV90173;//No Records to run BL Auto Payment Process!  //Added By AAM (23-Nov-2017)

                    PFMDTO00056 InterestDateDTO = Sys001DAO.SelectSys001Info(sourceBr, "BLMonthly_AutoPay");
                    SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, createdUserId, InterestDateDTO.Id.ToString());
                    //Dictionary<string, object> updateColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "SysDate", DateTime.Now } };
                    Dictionary<string, object> updateColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "SysDate", transactionDate } };
                    Dictionary<string, object> whereColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "BranchCode", sourceBr }, { "Name", "BLMonthly_AutoPay" }, { "Active", true } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("PFMORM00056", updateColumnsandValuesForLoansInterestCalculation, whereColumnsandValuesForLoansInterestCalculation));

                    //this.sys001DAO.UpdateDateDailyPosting("BLMonthly_AutoPay", DateTime.Now, sourceBr, createdUserId);

                }
                return retMsg;
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                // this.ServiceResult.MessageCode = CXMessage.MV90161;//Already Run Personal Loan Auto Payment Process!
                PFMDTO00056 InterestDateDTO = Sys001DAO.SelectSys001Info(sourceBr, "BLMonthly_AutoPay");
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, createdUserId, InterestDateDTO.Id.ToString());
                Dictionary<string, object> updateColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "SysDate", transactionDate } };
                Dictionary<string, object> whereColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "BranchCode", sourceBr }, { "Name", "BLMonthly_AutoPay" }, { "Active", true } };
                CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("PFMORM00056", updateColumnsandValuesForLoansInterestCalculation, whereColumnsandValuesForLoansInterestCalculation));

                this.sys001DAO.UpdateDateDailyPosting("BLMonthly_AutoPay", transactionDate, sourceBr, createdUserId);

                throw;
            }
        }

        public string BusinessLoansLateFeesAutoPayVoucherProcess(string eno, string sourceBr, int createdUserId, string userName, IList<DataVersionChangedValueDTO> dvcvList)
        {
            DateTime lastSettlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("LastSettlementDate"), sourceBr, true });
            DateTime transactionDate;
            if (lastSettlementDate.Date == DateTime.Now.Date)
            {
                transactionDate = DateTime.Now; //For Current Date Transaction
            }
            else
            {
                string lastSDate = lastSettlementDate.ToString("yyyy-MM-dd") + " " + "23:59:03.000"; // To update SQLite data
                transactionDate = DateTime.Parse(lastSDate);//For Back Date Transaction
            }
            //Comment & Modified by HMW at (26-07-2019) : Generate ENO at Script side to prevent "Voucher No Loss Issue" in every already run (or) no need to run case.
            //eno = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, 1, sourceBr, new object[] { lastSettlementDate.ToString("dd"), lastSettlementDate.ToString("MM"), lastSettlementDate.ToString("yy") });
            //string str = this.BLDetailsDAO.BusinessLoansLateFeesAutoPayVoucherProcess(eno, sourceBr, createdUserId, userName);
                       
            string str = this.BLDetailsDAO.BusinessLoansLateFeesAutoPayVoucherProcess(sourceBr, createdUserId, userName);
            if (str == "0")
            {
                this.ServiceResult.ErrorOccurred = false;
                PFMDTO00056 InterestDateDTO = sys001DAO.SelectSys001Info(sourceBr, "BL_LF_AutoVoucher");
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, createdUserId, InterestDateDTO.Id.ToString());
                //Dictionary<string, object> updateColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "Status", "Y" }, { "SysDate", DateTime.Now } };
                Dictionary<string, object> updateColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "Status", "Y" }, { "SysDate", transactionDate } };
                Dictionary<string, object> whereColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "BranchCode", sourceBr }, { "Name", "BL_LF_AutoVoucher" }, { "Active", true } };
                CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("PFMORM00056", updateColumnsandValuesForLoansInterestCalculation, whereColumnsandValuesForLoansInterestCalculation));

                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MV90195;//BL Late Fees Auto Voucher Process is successfully finshed!.
            }
            else if (str == "-2")
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MV90196;//Already Run BL Late Fees Auto Voucher Process!.
            }
            else if (str == "-3")
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.ME00070;//Please check the "System Date" and "Settlement Date" First!
            }
            else //(str == "-1")
            {
                this.ServiceResult.ErrorOccurred = false;
                PFMDTO00056 InterestDateDTO = sys001DAO.SelectSys001Info(sourceBr, "BL_LF_AutoVoucher");
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, createdUserId, InterestDateDTO.Id.ToString());
                //Dictionary<string, object> updateColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "Status", "Y" }, { "SysDate", DateTime.Now } };
                Dictionary<string, object> updateColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "Status", "Y" }, { "SysDate", transactionDate } };
                Dictionary<string, object> whereColumnsandValuesForLoansInterestCalculation = new Dictionary<string, object> { { "BranchCode", sourceBr }, { "Name", "BL_LF_AutoVoucher" }, { "Active", true } };
                CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("PFMORM00056", updateColumnsandValuesForLoansInterestCalculation, whereColumnsandValuesForLoansInterestCalculation));


                this.ServiceResult.ErrorOccurred = false;
                //this.ServiceResult.MessageCode = CXMessage.MV90197;//BL Late Fees Auto Voucher Process is failed!.
                this.ServiceResult.MessageCode = CXMessage.MV90186;//No Data For Late Fees Auto Pay Voucher Process! // Added By AAM(23-Nov-2017)
            }
            return str;
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
