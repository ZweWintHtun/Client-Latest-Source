using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXServer.Utt;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Cbs.Tcm.Ctr.Dao;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tcm.Dmd;
using Spring.Transaction;
using Spring.Transaction.Interceptor;

namespace Ace.Cbs.Tcm.Sve
{
    public class TCMSVE00020 : BaseService, ITCMSVE00020
    {
        #region DAO
        public ITCMDAO00007 MinBalDAO { get; set; }
        public ICXSVE00006 CodeChecker { get; set; }
        public IPFMDAO00001 CustomerIdDAO { get; set; }
        public IPFMDAO00028 CledgerDAO { get; set; }
        #endregion

        #region Methods
        public IList<PFMDTO00001> GetCustomerByAccountNumber(string accountNo)
        {
            IList<PFMDTO00001> customerLists = new List<PFMDTO00001>();
            try
            {
                PFMDTO00001 customerInfo = new PFMDTO00001();
                //PFMDTO00001 cledger = new PFMDTO00001();
                PFMDTO00028 cledgerData = CXServiceWrapper.Instance.Invoke<ICXSVE00006, PFMDTO00028>(x => x.GetAccountInfoOfCledgerByAccountNo(accountNo));

                if ((cledgerData.AccountSign.Substring(0, 1)) == "S")
                {
                    IList<PFMDTO00016> saofDTOLists = CXServiceWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00016>>(x => x.GetSAOFsByAccountNumber(accountNo));

                    if (saofDTOLists.Count > 0)
                    {
                        var name = (from value in saofDTOLists
                                    where value.Name != null
                                    select value);
                        IList<PFMDTO00016> saofDTOLists2 = name.ToList<PFMDTO00016>();
                        if (saofDTOLists2.Count > 0)
                        {
                            customerLists.Add(customerInfo);
                            customerLists[0].NameofFirm = saofDTOLists2[0].Name;
                        }

                        var customerId = from value in saofDTOLists
                                         where value.Customer_Id != null
                                         select value.Customer_Id;

                        if (customerId.ToList().Count > 0)
                        {
                            IList<string> customerIdList = customerId.ToList();
                            IList<PFMDTO00001> list = this.CustomerIdDAO.SelectListByCustId(customerIdList);
                            foreach (PFMDTO00001 info in list)
                            {
                                customerLists.Add(info);
                            }
                        }
                    }
                }
                else if (((cledgerData.AccountSign.Substring(0, 1)) == "C"))
                {
                    IList<PFMDTO00017> caofDTOLists = CXServiceWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00017>>(x => x.GetCAOFsByAccountNumber(accountNo));

                    if (caofDTOLists.Count > 0)
                    {
                        var name = (from value in caofDTOLists
                                    where value.Name != null
                                    select value);
                        IList<PFMDTO00017> caofDTOLists2 = name.ToList<PFMDTO00017>();
                        if (caofDTOLists2.Count > 0)
                        {
                            customerLists.Add(customerInfo);
                            customerLists[0].NameofFirm = caofDTOLists2[0].Name;
                        }

                        var customerId = from value in caofDTOLists
                                         where value.CustomerID != null
                                         select value.CustomerID;

                        if (customerId.ToList().Count > 0)
                        {
                            IList<string> customerIdList = customerId.ToList();
                            IList<PFMDTO00001> list = this.CustomerIdDAO.SelectListByCustId(customerIdList);
                            foreach (PFMDTO00001 info in list)
                            {
                                customerLists.Add(info);
                            }
                        }
                    }
                }
                customerLists[0].MinimumBalance = cledgerData.MinimumBalance;
                customerLists[0].CurrentBal = cledgerData.CurrentBal;
                customerLists[0].OverdraftLimit = cledgerData.OverdraftLimit;
                customerLists[0].CurrencyCode = cledgerData.CurrencyCode;
                customerLists[0].SourceBranch = cledgerData.SourceBranchCode;
                return customerLists;
            }
            catch
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV00175";//Account No Not Found.   
                return customerLists;
            }
        }
               

        [Transaction(TransactionPropagation.Required)]
        public void SaveMinimumBalance(TCMDTO00007 balanceDTO)
        {
            try
            {
                //Update Cledger MinBal Amount
                CledgerDAO.UpdateMinBal(balanceDTO.AccountNo, balanceDTO.New_Limit, balanceDTO.CreatedUserId);

                //Save MinBal Table
                TCMORM00007 balance = this.GetMinnmumBalance(balanceDTO);
                this.MinBalDAO.Save(balance); 

                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI90001";//Saving Successful.
                
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = ex.Message;
                throw new Exception(this.ServiceResult.MessageCode);
            }
 
        }
        #endregion

        #region Convert DTO to ORM
        private TCMORM00007 GetMinnmumBalance(TCMDTO00007 entity)
        {
            TCMORM00007 minBal = new TCMORM00007();
            minBal.AccountNo=entity.AccountNo;
            minBal.Date_Time=DateTime.Now;
            minBal.UserNo=Convert.ToString(entity.CreatedUserId);
            minBal.Old_Limit=entity.Old_Limit;
            minBal.New_Limit=entity.New_Limit;
            minBal.Remark=entity.Remark;
            minBal.SourceBranch=entity.SourceBranch;
            minBal.Currency=entity.Currency;
            minBal.Active = true;
            minBal.CreatedUserId = entity.CreatedUserId;
            minBal.CreatedDate = DateTime.Now;
            return minBal;
        }
        #endregion


            
    }
}
