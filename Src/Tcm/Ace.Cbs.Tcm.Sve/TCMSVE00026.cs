using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Cx.Com.Ctr;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Windows.CXServer.Utt;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Tcm.Sve
{
    public class TCMSVE00026:BaseService,ITCMSVE00026
    {
        #region DAO
        public ICXSVE00010 DataGenerateService { get; set; }
        public IPFMDAO00042 ReportTlfDAO { get; set; }
        public ICXDAO00009 ViewDAO { get; set; }
        #endregion


        #region Properties
        public IList<PFMDTO00042> PrintDataLists = new List<PFMDTO00042>();
        public PFMDTO00042 DTO = new PFMDTO00042();
        public PFMDTO00042 balanceDTO = new PFMDTO00042();
        public PFMDTO00042 closingDTO = new PFMDTO00042();
        public decimal CreditAmount = 0;
        public decimal DebitAmount = 0;
        public int index = 0;
        public string branchCode = string.Empty;
        #endregion

        #region Main Methods
        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00042> GetReportData(PFMDTO00042 DataDTO)
        {
           
            balanceDTO = this.GetDataForReportTLF(DataDTO);
            if (balanceDTO.Row_Count > 0)
            {
                IList<PFMDTO00042> DataLists = new List<PFMDTO00042>();

                #region controller data
                string workStation = Convert.ToString(DataDTO.WorkStationId);
                string date = DataDTO.StartDate.ToShortDateString();
                DateTime dateTime = Convert.ToDateTime(date);
                int createdUserId=DataDTO.CreatedUserId;
                string dStatus = DataDTO.Status;
                int rStatus = (DataDTO.IsWithReversal == true) ? 1 : 0;
                string status = "C";
                string currency = (string.IsNullOrEmpty(DataDTO.CurCode))?"KYT":DataDTO.CurCode;
                //branchCode = (string.IsNullOrEmpty(DataDTO.BranchName))?DataDTO.SourceBranch:DataDTO.BranchName;
                branchCode = DataDTO.SourceBranch;
                #endregion

                if (DataDTO.CurrencyType == "Home Currency")
                {
                    closingDTO = this.DataGenerateService.ClosingBalanceByHomeCurrencyAll(workStation, dateTime, status, rStatus, branchCode, createdUserId);
                    balanceDTO = this.DataGenerateService.BankCashScroll(workStation, dateTime, rStatus, dStatus, branchCode, createdUserId);

                    if (DataDTO.IsWithReversal == true)
                    {
                        DataLists = ViewDAO.GetCleanCashByHomeCurrencyData(workStation, dateTime, currency);//only KYT
                        if (DataDTO.IsAllBranches == true)
                        {
                            PrintDataLists = this.SelectData(DataLists);//All Branches,Home Currency,With Reversal
                        }
                        else
                        {
                            IList<PFMDTO00042> Lists = this.SelectBranchData(DataLists);
                            PrintDataLists = this.SelectData(Lists);//One Branch,Home Currency,With Reversal
                        }
                        
                    }
                    else
                    {
                        DataLists = ViewDAO.GetCleanCashWithoutReversalByHomeCurrencyData(workStation, dateTime, currency);//only KYT
                        if (DataDTO.IsAllBranches == true)
                        {
                            PrintDataLists = this.SelectData(DataLists);//All Branches,Home Currency,Without Reversal
                        }
                        else
                        {
                            IList<PFMDTO00042> Lists = this.SelectBranchData(DataLists);
                            PrintDataLists = this.SelectData(Lists);//One Branch,Home Currency,Without Reversal
                        }
                    }
                    
                }
                else
                {
                    if (DataDTO.IsWithReversal == true)
                    {
                        if (DataDTO.IsHomeCurrency == true)
                        {
                           
                            closingDTO = this.DataGenerateService.ClosingBalanceByHomeCurrency(workStation, dateTime, status, rStatus, currency, branchCode, createdUserId);
                            balanceDTO = this.DataGenerateService.BankCashScrollByHomeCur(workStation, dateTime, rStatus, dStatus, currency, branchCode, createdUserId);
                            DataLists = ViewDAO.GetCleanCashByHomeCurrencyData(workStation, dateTime, currency);//source cur(home amount)
                            
                            if (DataDTO.IsAllBranches == true)
                            {
                                PrintDataLists = this.SelectData(DataLists);//All Branches,Source Currency,With Reversal,By Home Currency
                            }
                            else
                            {
                                IList<PFMDTO00042> Lists = this.SelectBranchData(DataLists);
                                PrintDataLists = this.SelectData(Lists);//One Branch,Source Currency,With Reversal,By Home Currency
                            }
                        }
                        else
                        {

                            DataLists = ViewDAO.GetCleanCashData(workStation, dateTime, currency);//source cur(local amount)
                            
                            if (DataDTO.IsAllBranches == true)
                            {
                                closingDTO = this.DataGenerateService.ClosingBalanceBySourceCurrency(workStation, dateTime, status, rStatus, currency, createdUserId);
                                balanceDTO = this.DataGenerateService.BankCashScrollBySourceCur(workStation, dateTime, rStatus, dStatus, currency, createdUserId);
                                PrintDataLists = this.SelectData(DataLists);//All Branches,Source Currency,With Reversal,Not By Home Currency
                            }
                            else
                            {
                                closingDTO = this.DataGenerateService.ClosingBalance(workStation, dateTime, status, rStatus, currency, branchCode, createdUserId);
                                balanceDTO = this.DataGenerateService.BankCashScrollCALC(workStation, dateTime, rStatus, dStatus, currency, branchCode, createdUserId);
                                IList<PFMDTO00042> Lists = this.SelectBranchData(DataLists);
                                PrintDataLists = this.SelectData(Lists);//One Branch,Source Currency,With Reversal,Not By Home Currency
                            }
                        }
                    }
                    else
                    {
                        if (DataDTO.IsHomeCurrency == true)
                        {
                           
                            closingDTO = this.DataGenerateService.ClosingBalanceByHomeCurrency(workStation, dateTime, status, rStatus, currency, branchCode, createdUserId);
                            balanceDTO = this.DataGenerateService.BankCashScrollByHomeCur(workStation, dateTime, rStatus, dStatus, currency, branchCode, createdUserId);
                            DataLists = ViewDAO.GetCleanCashWithoutReversalByHomeCurrencyData(workStation, dateTime, currency);//source cur(home amount)
                           
                            if (DataDTO.IsAllBranches == true)
                            {
                                PrintDataLists = this.SelectData(DataLists);//All Branches,Source Currency,Without Reversal,By Home Currency
                            }
                            else
                            {
                                IList<PFMDTO00042> Lists = this.SelectBranchData(DataLists);
                                PrintDataLists = this.SelectData(Lists);//One Branch,Source Currency,Without Reversal,By Home Currency
                            }
                        }
                        else
                        {
                            DataLists = ViewDAO.GetCleanCashWithoutReversalData(workStation, dateTime, currency);
                           
                            if (DataDTO.IsAllBranches == true)
                            {
                                closingDTO = this.DataGenerateService.ClosingBalanceBySourceCurrency(workStation, dateTime, status, rStatus, currency, createdUserId);
                                balanceDTO = this.DataGenerateService.BankCashScrollBySourceCur(workStation, dateTime, rStatus, dStatus, currency, createdUserId);
                                PrintDataLists = this.SelectData(DataLists);//All Branches,Source Currency,Without Reversal,Not By Home Currency
                            }
                            else
                            {
                                closingDTO = this.DataGenerateService.ClosingBalance(workStation, dateTime, status, rStatus, currency, branchCode, createdUserId);
                                balanceDTO = this.DataGenerateService.BankCashScrollCALC(workStation, dateTime, rStatus, dStatus, currency, branchCode, createdUserId);
                                IList<PFMDTO00042> Lists = this.SelectBranchData(DataLists);
                                PrintDataLists = this.SelectData(Lists);//One Branch,Source Currency,Without Reversal,Not By Home Currency
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
        #endregion

        #region Methods
        public PFMDTO00042 GetDataForReportTLF(PFMDTO00042 DataDTO)
        {
            PFMDTO00042 DataGenerateDTO = new PFMDTO00042();

            CXDTO00006 reportparameters = new CXDTO00006();
            reportparameters.StartDate = DataDTO.StartDate;
            reportparameters.EndDate = DataDTO.StartDate;
            reportparameters.CreatedUserId = DataDTO.CreatedUserId;
            reportparameters.UserNo = Convert.ToString(DataDTO.WorkStationId);
            reportparameters.SpecialCondition = "SourceBr = " + "'" + DataDTO.SourceBranch + "'";
            reportparameters.ForCheck_Or_ForReturn = CXDMD00009.ForReturn;
            reportparameters.BDateType = DataDTO.Status == "Settlement Date"?"S":"T";/*Added By Prize.*/
           
           DataGenerateDTO = this.DataGenerateService.GetReportDataGenerateInSQL(reportparameters);
            return DataGenerateDTO;
        }

        public IList<PFMDTO00042> SelectData(IList<PFMDTO00042> DataLists)
        {
            IList<PFMDTO00042> dtoList = new List<PFMDTO00042>();
            if (DataLists.Count > 0)
            {
                string compareAcode = string.Empty;
                PFMDTO00042 dto = new PFMDTO00042();
              
                foreach (PFMDTO00042 data in DataLists)
                {
                    index++;
                   
                    if (data.ACode == compareAcode)
                    {
                        this.CollectData(data);
                        if (index == DataLists.Count)
                        {  
                            dto = this.AddData(DTO);
                            dtoList.Add(dto);
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(DTO.ACName))
                        {
                            dto = this.AddData(DTO);
                            dtoList.Add(dto);
                        }
                        compareAcode = data.ACode;

                        ChargeOfAccountDTO coa = CXCOM00011.Instance.GetScalarObject<ChargeOfAccountDTO>("COA.Client.SelectAccountName", new object[] { data.ACode, data.SourceBranch, true });
                        if (coa != null)
                        {
                            DTO.ACode = data.ACode;
                            DTO.ACName = coa.AccountName;
                        }
                        else
                        {
                            DTO.ACName = string.Empty;
                        }
                        this.CollectData(data);

                        if (index == DataLists.Count)
                        {
                            dto = this.AddData(DTO);
                            dtoList.Add(dto);
                        }
                    }
                }
                
            }
            return dtoList;
            
        }

        public PFMDTO00042 CollectData(PFMDTO00042 record)
        {
            if (record.Status == "CC" || record.Status == "CCA" || record.Status=="TC" || record.Status=="LC")
            {
               CreditAmount +=(record.LocalAmt==null)?Convert.ToDecimal(record.HomeAmt): Convert.ToDecimal(record.LocalAmt);
            }
            else if (record.Status == "CD" || record.Status == "CDA" || record.Status=="TD" || record.Status=="LD")
            {
                DebitAmount += (record.LocalAmt == null) ? Convert.ToDecimal(record.HomeAmt) : Convert.ToDecimal(record.LocalAmt);
            }
            return record;
        }


        public PFMDTO00042 AddData(PFMDTO00042 DTO)
        {
            PFMDTO00042 DataList = new PFMDTO00042();
            DataList.ACode = DTO.ACode;
            DataList.ACName = DTO.ACName;
            DataList.Credit = CreditAmount;
            DataList.Debit = DebitAmount;
            DataList.ReturnObalance = balanceDTO.ReturnObalance;
            DataList.TrCL = balanceDTO.TrCL;
            DataList.ClosingBalance = closingDTO.ClosingBalance;

            DTO.ACName = string.Empty;
            this.DefaultData();
            return DataList;
        }

        public void DefaultData()
        {
            CreditAmount = 0;
            DebitAmount = 0;
        }

        public IList<PFMDTO00042> SelectBranchData(IList<PFMDTO00042> DataLists)
        {
            IList<PFMDTO00042> tempList = new List<PFMDTO00042>();
            foreach (PFMDTO00042 branchDTO in DataLists)
            {
                
                if (branchDTO.SourceBranch ==branchCode)
                {
                    tempList.Add(branchDTO);
                }
                
            }
            return tempList;
        }
        #endregion
    }
      
}
