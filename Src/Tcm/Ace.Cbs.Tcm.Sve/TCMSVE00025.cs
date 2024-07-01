using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tcm.Ctr.Sve;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXServer.Utt;
using Ace.Windows.Admin.DataModel;


namespace Ace.Cbs.Tcm.Sve
{
    public class TCMSVE00025:BaseService,ITCMSVE00025
    {
        #region DAO
        public ICXSVE00010 DataGenerateService { get; set; }
        public IPFMDAO00042 ReportTlfDAO { get; set; }
        //public ICXDAO00010 DataGenerateDAO { get; set; }
        #endregion

        #region Properties
        public int CreditCount = 0;
        public int DebitCount = 0;
        public decimal CreditAmount = 0;
        public decimal DebitAmount = 0;
        public int index;
        public IList<PFMDTO00042> PrintDataLists = new List<PFMDTO00042>();
        public PFMDTO00042 DTO = new PFMDTO00042();
        public PFMDTO00042 balanceDTO = new PFMDTO00042();
        #endregion

        #region Main Method

        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00042> GetReportData(PFMDTO00042 DataDTO)
        {
           
            balanceDTO = this.GetDataForReportTLF(DataDTO);
            if (balanceDTO.Row_Count > 0)
            {
                IList<PFMDTO00042>[] DataLists = new List<PFMDTO00042>[2];
                IList<PFMDTO00042> Lists = new List<PFMDTO00042>();
                int rStatus = 0;

                string cashCreditStatus = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashCreditStatus); //CC
                string cashDebitStatus = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashDebitStatus);  //CD
                string currentControlStatus = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurrentControlStatus);  //LDC
                string overDraftStatus = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.OverDraftStatus); //OD

                string date = DataDTO.StartDate.ToShortDateString();
                DateTime dateTime = Convert.ToDateTime(date);
               
                string workStationId = Convert.ToString(DataDTO.WorkStationId);
                string sourceCurrency = DataDTO.CurCode;
                string status = DataDTO.Status;
                string branchCode = DataDTO.SourceBranch;
                int createdUserId = DataDTO.CreatedUserId;

                if (DataDTO.IsWithReversal == true)
                {
                    rStatus = 1;
                    DataLists[0] = ReportTlfDAO.GetBankCashDataWithReversal1(workStationId, sourceCurrency,branchCode, dateTime, cashCreditStatus, cashDebitStatus);
                    DataLists[1] = ReportTlfDAO.GetBankCashDataWithReversal2(workStationId, sourceCurrency, dateTime, branchCode,cashCreditStatus, cashDebitStatus, currentControlStatus, overDraftStatus);
                    balanceDTO = DataGenerateService.BankCashScrollCALC(workStationId, dateTime, rStatus, status, sourceCurrency, branchCode, createdUserId);
                }
                else
                {
                    rStatus = 0;
                    DataLists[0] = ReportTlfDAO.GetBankCashDataWithoutReversal1(workStationId, sourceCurrency,branchCode, dateTime,cashCreditStatus, cashDebitStatus);
                    DataLists[1] = ReportTlfDAO.GetBankCashDataWithoutReversal2(workStationId, sourceCurrency, dateTime, branchCode,cashCreditStatus, cashDebitStatus, currentControlStatus, overDraftStatus);
                    balanceDTO = DataGenerateService.BankCashScrollCALC(workStationId, dateTime, rStatus, status, sourceCurrency, branchCode, createdUserId);
                }

                for (int i = 0; i < 2; i++)
                {
                    index = 0;
                    if (DataLists[i].Count > 0)
                    {
                        string compareAcode = string.Empty;
                        foreach (PFMDTO00042 data in DataLists[i])
                        {
                            index++;
                            if (i == 0)
                            { data.Status = data.Status.Substring(0, 2); }
                            else
                            { data.Status = data.Status.Substring(0, 2) + 'A'; }

                            //if (compareAcode == data.ACode)
                            if (compareAcode == data.ACode.Substring(0,3))
                            {
                                this.CollectData(data);

                                if (index == DataLists[i].Count)
                                {
                                    
                                    this.AddData(DTO);
                                  //PrintDataLists.Add(data1);
                                }
                            }

                            else

                            {
                                if (!string.IsNullOrEmpty(DTO.ACode))
                                {
                                    this.AddData(DTO);
                                    //PrintDataLists.Add(data2);
                                }

                                //compareAcode = data.ACode;
                                compareAcode = data.ACode.Substring(0, 3) ;

                                DTO.ACode = data.ACode.Substring(0, 3) + "000";

                                ChargeOfAccountDTO coa = CXCOM00011.Instance.GetScalarObject<ChargeOfAccountDTO>("COA.Client.SelectAccountName", new object[] { DTO.ACode, branchCode, true });
                                if (coa != null)
                                {
                                    DTO.ACName = coa.AccountName;
                                }
                                else
                                {
                                    DTO.ACName = string.Empty;
                                }
                                data.ACode = DTO.ACode;
                                data.ACName = DTO.ACName;
                                DTO = this.CollectData(data);


                                if (index == DataLists[i].Count)
                                {

                                    this.AddData(DTO);
                                }


                            }
                        }
                    }
                }
            }
            else
            {
                PrintDataLists = new List<PFMDTO00042>();
            }
        return PrintDataLists;
        }


        public PFMDTO00042 CollectData(PFMDTO00042 record)
        {
            if (record.Status == "CC" || record.Status == "CCA")
            {
                CreditCount++;
                CreditAmount += Convert.ToDecimal(record.LocalAmt);
               
                //PrintDataLists.Add(record);
            }
            else if (record.Status == "CD" || record.Status == "CDA")
            {
              
                DebitCount ++;
                DebitAmount += Convert.ToDecimal(record.LocalAmt);
                //PrintDataLists.Add(record);
            }
            return record;
        }

        public void AddData(PFMDTO00042 DTO)
        {
            PFMDTO00042 DataList = new PFMDTO00042();
            DataList.ACode = DTO.ACode;
            DataList.ACName = DTO.ACName;
            DataList.CreditCount = CreditCount;
            DataList.Credit = CreditAmount;
            DataList.DebitCount = DebitCount;
            DataList.Debit = DebitAmount;
            DataList.ReturnObalance = balanceDTO.ReturnObalance;
            DataList.TrCL = balanceDTO.TrCL;

            PrintDataLists.Add(DataList);
            DTO.ACode = string.Empty;
            this.DefaultData();
            //return DataList;
        }

        public void DefaultData()
        {
            CreditCount=0;
            CreditAmount=0;
            DebitCount=0;
            DebitAmount=0;
        }
        #endregion 

        #region Method
        public PFMDTO00042 GetDataForReportTLF(PFMDTO00042 DataDTO)
        {
            PFMDTO00042 DataGenerateDTO = new PFMDTO00042();

            CXDTO00006 reportparameters = new CXDTO00006();
            reportparameters.StartDate = DataDTO.StartDate;
            reportparameters.EndDate = DataDTO.StartDate;
            reportparameters.CreatedUserId = DataDTO.CreatedUserId;
            reportparameters.UserNo =Convert.ToString(DataDTO.WorkStationId);
            reportparameters.ForCheck_Or_ForReturn = CXDMD00009.ForReturn;
            reportparameters.BDateType = DataDTO.Status;
            reportparameters.SpecialCondition = "sourceBr = '" + DataDTO.SourceBranch + "'";
           
            DataGenerateDTO = this.DataGenerateService.GetReportDataGenerateInSQL(reportparameters);
            return DataGenerateDTO;
        }
        #endregion
    }
}
