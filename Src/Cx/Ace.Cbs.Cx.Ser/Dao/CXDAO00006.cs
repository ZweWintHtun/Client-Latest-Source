using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
using Ace.Cbs.Cx.Com.Utt;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using System.Linq;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Tcm.Dmd;


namespace Ace.Cbs.Cx.Ser.Dao
{
    /// <summary>
    /// Code Validation Dao
    /// </summary>
    public class CXDAO00006 : DataRepository<PFMORM00001>, ICXDAO00006
    {
        public int CustomerSelectCount(string customerId)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.SelectCountByCustomerId");
            query.SetString("customerId", customerId);

            object count = query.UniqueResult();
            return Convert.ToInt32(count.ToString());
        }

        public PFMDTO00001 CustomerSelectByCustomerId(string customerId)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.SelectByCustomerId");
            query.SetString("customerId", customerId);

            return query.UniqueResult<PFMDTO00001>();
        }

        public int ChequeSelectCount(string chequeBookNo, string startNo, string endNo, string branchCode)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.Cheque.SelectCountByChequeBookNoAndStartNoAndEndNo");
            query.SetString("chequeBookNo", chequeBookNo);
            query.SetString("startNo", startNo);
            query.SetString("endNo", endNo);
            query.SetString("branchCode", branchCode);
            //query.SetString("currency", currency);

            object count = query.UniqueResult();
            return Convert.ToInt32(count.ToString());
        }

        public int PrintChequeSelectCount(string acctno,string startNo, string endNo, string branchCode,string chequeBookNo)
        {
            IQuery query = this.Session.GetNamedQuery("CXSVE00006.SelectCountByStartNoAndEndNo");
            query.SetString("acctno", acctno);
            query.SetString("startNo", startNo);
            query.SetString("endNo", endNo);
            query.SetString("branchCode", branchCode);
            query.SetString("chequeBookNo", chequeBookNo);
            object count = query.UniqueResult();
            return Convert.ToInt32(count.ToString());
        }

        public int ChequeSelectCount(string accountNo, string chequeBookNo, string startNo, string endNo, string branchCode, string currency)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.Cheque.SelectCountByAccountNoAndChequeBookNoAndStartNoAndEndNo");
            query.SetString("accountNo", accountNo);
            query.SetString("chequeBookNo", chequeBookNo);
            query.SetString("startNo", startNo);
            query.SetString("endNo", endNo);
            query.SetString("branchCode", branchCode);
            query.SetString("currency", currency);
            object count = query.UniqueResult();
            return Convert.ToInt32(count.ToString());
        }

        public int ChequeSelectCount(string accountNo, string chequeNo, string branchCode)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.Cheque.SelectCountByAccountNoAndChequeNo");
            query.SetString("accountNo", accountNo);
            query.SetString("chequeNo", chequeNo);
            query.SetString("branchCode", branchCode);

            object count = query.UniqueResult();
            return Convert.ToInt32(count.ToString());
        }

        public int SCheckSelectCount(string chequeBookNo, string startNo, string endNo, string branchCode,string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.SCheque.SelectCountByChequeBookNoAndStartNoAndEndNo");
            query.SetString("chequeBookNo", chequeBookNo);
            query.SetString("startNo", startNo);
            query.SetString("endNo", endNo);
            query.SetString("branchCode", branchCode);
           query.SetString("accountNo", accountNo);

            object count = query.UniqueResult();
            string sqlQuery = this.GetSQLString(query.QueryString);

            return Convert.ToInt32(count.ToString());
        }

        public int SCheckSelectCountForStopCheque(string chequeBookNo, string startNo, string endNo, string branchCode)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.SCheque.SelectCountByChequeBookNoAndStartNoAndEndNoForStopCheck");
            query.SetString("chequeBookNo", chequeBookNo);
            query.SetString("startNo", startNo);
            query.SetString("endNo", endNo);
            query.SetString("branchCode", branchCode);

            object count = query.UniqueResult();
            string sqlQuery = this.GetSQLString(query.QueryString);

            return Convert.ToInt32(count.ToString());
        }

        public int SCheckSelectCount(string chequeNo, string branchCode,string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.SCheque.SelectCountByChequeNo");
            query.SetString("chequeNo", chequeNo);
            query.SetString("branchCode", branchCode);
            query.SetString("accountNo", accountNo);
            object count = query.UniqueResult();

            return Convert.ToInt32(count.ToString());
        }

        public int UCheckSelectCount(string startNo, string endNo, string branchCode,string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.UCheque.SelectCountByChequeNo");
            query.SetString("startNo", startNo);
            query.SetString("endNo", endNo);
            query.SetString("branchCode", branchCode);
            query.SetString("accountNo", accountNo);
            object count = query.UniqueResult();
            return Convert.ToInt32(count.ToString());
        }

        public IList<PFMDTO00017> GetCAOFsByAccountNumber(string accountNumber)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.CAOFSelectByAccountNumber");
            query.SetString("accountNumber", accountNumber);

            return query.List<PFMDTO00017>();
        }

  
        public IList<PFMDTO00016> GetSAOFsByAccountNumber(string accountNumber)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.SAOFSelectByAccountNumber");
            query.SetString("accountNumber", accountNumber);

            return query.List<PFMDTO00016>();
        }

        public IList<PFMDTO00021> FAOFSelectByAccountNumberForRePrintingPassBook(string accountNumber)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00021.FAOFSelectByAccountNumberForRePrintingPassBook");
            query.SetString("acctno", accountNumber);

            return query.List<PFMDTO00021>();
        }

        public IList<PFMDTO00021> GetFAOFsByAccountNumber(string accountNumber)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.FAOFSelectByAccountNumber");
            query.SetString("accountNumber", accountNumber);

            return query.List<PFMDTO00021>();
        }

        public PFMDTO00017 GetCAOFByAccountNumber(string accountNumber, int serialOfCustomer)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.CAOFSelectByAccountNumberAndSerialofCustomer");
            query.SetString("accountNumber", accountNumber);   
            query.SetInt32("serialOfCustomer", serialOfCustomer);   

            return query.UniqueResult<PFMDTO00017>();
        }

        public PFMDTO00016 GetSAOFByAccountNumber(string accountNumber, int serialOfCustomer)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.SAOFSelectByAccountNumberAndSerialofCustomer");
            query.SetString("accountNumber", accountNumber);
            query.SetInt32("serialOfCustomer", serialOfCustomer);   

            return query.UniqueResult<PFMDTO00016>();
        }

        public PFMDTO00021 GetFAOFByAccountNumber(string accountNumber, int serialOfCustomer)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.FAOFSelectByAccountNumberAndSerialofCustomer");
            query.SetString("accountNumber", accountNumber);
            query.SetInt32("serialOfCustomer", serialOfCustomer);  

            return query.UniqueResult<PFMDTO00021>();
        }

        public IList<PFMDTO00072> GetCurrentAccountInfoByAccountNumber(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.GetCurrentAccountInfoByAccountNumber");
            query.SetString("accountNumber", accountNo);

            IList<PFMDTO00072> accountInfo = query.List<PFMDTO00072>();

            return accountInfo;
        }

        public IList<PFMDTO00072> GetCurrentAccountInfoByAccountNumber_ForClosedACAndUnClosed(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.GetCurrentAccountInfoByAccountNumber_ForClosedACAndUnClosed");
            query.SetString("accountNumber", accountNo);

            IList<PFMDTO00072> accountInfo = query.List<PFMDTO00072>();

            return accountInfo;
        }

        public IList<PFMDTO00072> GetSavingAccountInfoByAccountNumber(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.GetSavingAccountInfoByAccountNumber");
            query.SetString("accountNumber", accountNo);

            IList<PFMDTO00072> accountInfo = query.List<PFMDTO00072>();

            return accountInfo;
        }

        public int GetLinkAccountCountByCurrentAccountNo(string currentAccountNo)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.GetLinkAccountCountByCurrentAccountNo");
            query.SetString("currentAccountNo", currentAccountNo);

            object count = query.UniqueResult();

            if (count == null)
            {
                return 0;
            }

            return Convert.ToInt32(count.ToString());
        }

        public int GetLinkAccountCountBySavingAccountNo(string savingAccountNo)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.GetLinkAccountCountBySavingAccountNo");
            query.SetString("savingAccountNo", savingAccountNo);

            object count = query.UniqueResult();

            if (count == null)
            {
                return 0;
            }

            return Convert.ToInt32(count.ToString());
        }

        public int GetToAccountNoCountByAccountNo(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.GetToAccountNoCountByAccountNo");
            query.SetString("toAccountNo", accountNo);

            object count = query.UniqueResult();

            if (count == null)
            {
                return 0;
            }

            return Convert.ToInt32(count.ToString());
        }

        public int GetLoanAccountCountFromPer_GuanByAccountNo(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.GetLoanAccountCountFromPer_GuanByAccountNo");
            query.SetString("accountNo", accountNo);

            object count = query.UniqueResult();

            if (count == null)
            {
                return 0;
            }

            return Convert.ToInt32(count.ToString());
        }

        public int GetLoanAccountCountFromCLedgerByAccountNo(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.GetLoanAccountCountFromCLedgerByAccountNo");
            query.SetString("accountNo", accountNo);

            object count = query.UniqueResult();

            if (count == null)
            {
                return 0;
            }

            return Convert.ToInt32(count.ToString());
        }

        public int GetFreezeAccountCountByAccountNo(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.GetFreezeAccountCountByAccountNo");
            query.SetString("accountNo", accountNo);

            int count = query.List().Count;
            return count;
        }

        public object GetClosedAccountByAccountNo(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.IsClosedAccountForCLedger");
            query.SetString("accountNo", accountNo);
            string str = this.GetSQLString(query.QueryString);

            return query.UniqueResult();
        }

        public TLMDTO00016 SelectPOByPoNo(string poNo,string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.SelectByPONo");
            query.SetString("poNo", poNo);
            query.SetString("sourcebr", sourceBr);
            return query.UniqueResult<TLMDTO00016>();
        }

        public TLMDTO00001 SelectREByPoNo(string poNo, string budgetYear,string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.SelectREByPONo");
            query.SetString("poNo", poNo);
            query.SetString("budgetYear", budgetYear);
            query.SetString("sourcebr", sourceBr);
            return query.UniqueResult<TLMDTO00001>();
        }

        public PFMDTO00028 GetAccountInfoOfCledgerByAccountNo(string accountNo)
        {
            if (string.IsNullOrEmpty(accountNo))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            else
            {
                IQuery query = this.Session.GetNamedQuery("CXDAO00006.SelectAccountInfoFromCledgerByAccountNo");
                query.SetString("accountNo", accountNo);

                return query.UniqueResult<PFMDTO00028>();
            }
        }

        public PFMDTO00028 GetAccountInfoOfCledgerByAccountNoAndSourceBranch(string accountNo,string sourcebranch)
        {
            if (string.IsNullOrEmpty(accountNo))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            else
            {
                IQuery query = this.Session.GetNamedQuery("CXDAO00006.SelectAccountInfoFromCledgerByAccountNoAndSourceBranch");
                query.SetString("accountNo", accountNo);
                query.SetString("branchcode", sourcebranch);

                return query.UniqueResult<PFMDTO00028>();
            }
        }

        public PFMDTO00028 GetCurrentBalanceByAccountNo(string accountNo)
        {
            if (string.IsNullOrEmpty(accountNo))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            else
            {
                IQuery query = this.Session.GetNamedQuery("PFMDAO00028.SelectMinimumBalanceByAccountNo");
                query.SetString("accountNo", accountNo);

                return query.UniqueResult<PFMDTO00028>();
            }
        }

        public PFMDTO00029 GetLinkAccountCountByAccountNo(string accountNo, string accountType)
        {
            try
            {
                IQuery query;
                if (accountType.Substring(0, accountType.Length - 1) == "S")
                {
                    query = this.Session.GetNamedQuery("CXDAO00006.GetLinkAccountBySavingAccountNo");
                    query.SetString("accountNo", accountNo);
                }
                else
                {
                    query = this.Session.GetNamedQuery("CXDAO00006.GetLinkAccountByCurrentAccountNo");
                    query.SetString("accountNo", accountNo);
                }

                return query.UniqueResult<PFMDTO00029>();
            }
            catch
            {
                throw new Exception();
            }
            finally
            {
                if (this.Session.IsOpen)
                {
                    this.Session.Close();
                }
            }
        }

        public IList<PFMDTO00001> GetCustomerInformationBySAOForCAOF(string accountNo, string accountType)
        {
            try
            {
                IQuery query;
                if (accountType == "S")
                {
                    query = this.Session.GetNamedQuery("CXDAO00006.SelectCustomerInformationBySAOF");
                    query.SetString("accountNo", accountNo);
                }
                else if (accountType == "C")
                {
                    query = this.Session.GetNamedQuery("CXDAO00006.SelectCustomerInformationByCAOF");
                    query.SetString("accountNo", accountNo);
                }
                else if (accountType == "B")
                {
                    query = this.Session.GetNamedQuery("CXDAO00006.SelectCustomerInformationByCAOF");
                    query.SetString("accountNo", accountNo);
                }

                else if (accountType == "H")
                {
                    query = this.Session.GetNamedQuery("CXDAO00006.SelectCustomerInformationByCAOF");
                    query.SetString("accountNo", accountNo);
                }
                else if (accountType == "P")
                {
                    query = this.Session.GetNamedQuery("CXDAO00006.SelectCustomerInformationByCAOF");
                    query.SetString("accountNo", accountNo);
                }
                else if (accountType == "D")
                {
                    query = this.Session.GetNamedQuery("CXDAO00006.SelectCustomerInformationByCAOF");
                    query.SetString("accountNo", accountNo);
                }

                else throw new Exception(CXMessage.ME90018);//Invalid Input Parameter
                return query.List<PFMDTO00001>();
            }
            catch(Exception ex)
            {
                throw new Exception(CXMessage.ME00021);//Client Data Not Found
            }
            finally
            {
                if (this.Session.IsOpen)
                {
                    this.Session.Close();
                }
            }
        }

        public int GetLegalCaseFromLoansByAccountNo(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.SelectLegalCaseAccountByAccountNo");
            query.SetString("accountNo", accountNo);

            int count = query.List().Count;
            return count;
        }        
        

        public int GetNPLCaseFromLoansByAccountNo(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.SelectNPLCaseAccountByAccountNo");
            query.SetString("accountNo", accountNo);

            int count = query.List().Count;
            return count;
        }

        public int GetExpiredLoansFromLoansByAccountNo(string accountNo,DateTime todaydate)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.SelectExpiredLoansAccountByAccountNo");
            query.SetString("accountNo", accountNo);
            query.SetDateTime("todaydate", todaydate);

            int count = query.List().Count;
            return count;
        }

        public IList<PFMDTO00006> SelectStartNoandEndNobyCurrentAccountNo(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00006.SelectStartNoandEndNoByAcctno");
            query.SetString("accountNo", accountNo);
            return query.List<PFMDTO00006>();
        }

        public PFMDTO00041 SelectMinBal(string currencyCode, string soruceBranch)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.SelectMinBal");
            query.SetString("currencyCode", currencyCode);
            query.SetString("sourceBranch", soruceBranch);
            return query.UniqueResult<PFMDTO00041>();
        }

        public PFMDTO00057 SelectByVariable(string variable)
        {
            IQuery query = this.Session.GetNamedQuery("NewSetupDAO.SelectByVariable");
            query.SetString("variable", variable);
            return query.UniqueResult<PFMDTO00057>();
        }

        public TLMDTO00018 SelectSAmountByAccountNo(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.SelectSAmountByAccountNo");
            query.SetString("accountNo", accountNo);
            query.SetDateTime("todaydate", DateTime.Now);
            return query.UniqueResult<TLMDTO00018>();
        }

        public PFMDTO00029 LinkAcSelectLinkAmount(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00029.LinkAC_SelectLinkAmount");
            query.SetString("savingAccountNo", accountNo);
            query.SetString("currentAccountNo", accountNo);
            return query.UniqueResult<PFMDTO00029>();
        }

        /// <summary>
        /// To Check existance and closedate of AccountNo in CLedger
        /// </summary>
        /// <param name="accountNo">Customer AccountNo</param>
        /// <returns></returns>
        public bool CheckAccountNo(string acctNo)
        {
            if (string.IsNullOrEmpty(acctNo))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            else
            {
                IQuery query = this.Session.GetNamedQuery("CXDAO00006.CheckAccountNoinCLedger");
                query.SetString("accountNo", acctNo);
                PFMDTO00028 dto = query.UniqueResult<PFMDTO00028>();

                return (dto == null) ? false : true;
            }
        }


        //Select Top FAOF Information from FAOF Table By Account No.



        public PFMDTO00021 GetTopFAOFINfoByAccountNumber(string accountNumber)
        {
            PFMDTO00021 FAOFDTO = new PFMDTO00021();
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.FAOFSelectByAccountNumber");
            query.SetString("accountNumber", accountNumber);
            FAOFDTO = query.SetFirstResult(0).SetMaxResults(1).UniqueResult<PFMDTO00021>();
            return FAOFDTO;
        }

        //Select Top SAOF Information from SAOF Table By Account No.
        public PFMDTO00016 GetTopSAOFInfoByAccountNumber(string accountNumber)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.SAOFSelectByAccountNumber");
            query.SetString("accountNumber", accountNumber);
            PFMDTO00016 saofDTO = query.SetFirstResult(0).SetMaxResults(1).UniqueResult<PFMDTO00016>();
            return saofDTO;
        }

        //Select Top CAOF Information from CAOF Table By  Account No.
        public PFMDTO00017 GetTopCAOFInfoByAccountNumber(string accountNumber)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.CAOFSelectByAccountNumber");
            query.SetString("accountNumber", accountNumber);
            PFMDTO00017 caofdto = query.SetFirstResult(0).SetMaxResults(1).UniqueResult<PFMDTO00017>();
            return caofdto;
        }

        //Select CustomerInfo List from CustID Table by Account No.
        public IList<PFMDTO00001> SelectCustomerInformationByFAOF(string accountNumber)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.SelectCustomerInformationByFAOF");
            query.SetString("accountNo", accountNumber);
            IList<PFMDTO00001> CustInfoDTOList = query.List<PFMDTO00001>();
            return CustInfoDTOList;

        }     

        
        // CXDAO00006.SelectCustomerInformationByFAOF


        public PFMDTO00023 GetAccountInfoOfFledgerByAccountNo(string accountNo)
        {
            if (string.IsNullOrEmpty(accountNo))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            else
            {
                IQuery query = this.Session.GetNamedQuery("PFMDAO00023.SelectFLedgerByAccountNo");
                query.SetString("accountNo", accountNo);

                return query.UniqueResult<PFMDTO00023>();
            }
        }

        public IList<PFMDTO00054> SelectTLFByENOBranchCodeDate(string ENO, string ActiveBranch, DateTime Date,string Trancode)
        {
            if (string.IsNullOrEmpty(ENO))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            if (string.IsNullOrEmpty(ActiveBranch))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            if (string.IsNullOrEmpty(Date.Date.ToString()))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            IQuery query;
            if (string.IsNullOrEmpty(Trancode))
            {
                query = this.Session.GetNamedQuery("CXDAO00006.SelectTLFByENOBranchCodeDate");
            }
            else
            {
                query = this.Session.GetNamedQuery("CXDAO00006.SelectTLFByENOBranchCodeDateTrancode");
                query.SetString("trancode", Trancode);
            }
            query.SetString("ENO", ENO);
            query.SetString("ActiveBranch", ActiveBranch);
            query.SetString("Date", Date.Date.ToString("yyyy/MM/dd"));
            IList<PFMDTO00054> ListTLFDTO = query.List<PFMDTO00054>();
            return ListTLFDTO;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<TLMDTO00004> SelectMaxIBLTLFID()
        {
            IQuery query = this.Session.GetNamedQuery("IBLTLFDAO.SelectMaxId");
            IList<TLMDTO00004> ListIBLTLFDTO = query.List<TLMDTO00004>();

            return ListIBLTLFDTO;
        }

        public bool CheckUchequeByAccountNoChequeNo(string AccountNo, string ChequeNo, string ActiveBranch)
        {
            if (string.IsNullOrEmpty(AccountNo))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            //if (string.IsNullOrEmpty(ChequeNo))
            //{
            //    throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            //}
            if (string.IsNullOrEmpty(ActiveBranch))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.UCheque.CheckUchequeByAccountNoChequeNo");
            query.SetString("AccountNo", AccountNo);
            query.SetString("ChequeNo", ChequeNo);
            query.SetString("ActiveBranch", ActiveBranch);
            PFMDTO00020 UChequeDTO = query.UniqueResult<PFMDTO00020>();
            return (UChequeDTO == null) ? false : true;
        }       

        public IList<TLMDTO00004> SelectIBLTLFs(string ENO, string BranchCode)
        {
            if (string.IsNullOrEmpty(ENO))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            if (string.IsNullOrEmpty(BranchCode))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.SelectIBLTLFs");
            query.SetString("ENO", ENO);
            query.SetString("BranchCode", BranchCode);
            IList<TLMDTO00004> ListIBLTLFDTO = query.List<TLMDTO00004>();
            return ListIBLTLFDTO;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateFLedgerByAccountNo(string AccountNo)
        {
            if (string.IsNullOrEmpty(AccountNo))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            IQuery query = this.Session.GetNamedQuery("PFMDAO00023.UpdateFBalWihdrawal");
            query.SetString("accountNo", AccountNo);
            return query.ExecuteUpdate() == 0 ? false : true;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateCurrentBalance(string accountNo, decimal currentBalance, decimal tCount, int updatedUserId,string updatedUserNo)
        {
            if (string.IsNullOrEmpty(accountNo))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            if (string.IsNullOrEmpty(currentBalance.ToString()))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            if (string.IsNullOrEmpty(tCount.ToString()))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            if (string.IsNullOrEmpty(updatedUserId.ToString()))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            IQuery query = this.Session.GetNamedQuery("PFMDAO00028.UpdateCurrentBalance");
            query.SetString("accountNo", accountNo);
            query.SetDecimal("currentBalance", currentBalance);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetString("updatedUserNo", updatedUserNo);
            query.SetDecimal("transactionCount", tCount);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateFReceiptByAccountNoRNO(string accountNo, string receiptNo, decimal Amount, int updatedUserId)
        {
            if (string.IsNullOrEmpty(accountNo))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            if (string.IsNullOrEmpty(receiptNo))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            if (string.IsNullOrEmpty(Amount.ToString()))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            if (string.IsNullOrEmpty(updatedUserId.ToString()))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            IQuery query = this.Session.GetNamedQuery("PFMDAO00032.UpdateReversalFReceipt");
            query.SetString("accountNo", accountNo);
            query.SetDecimal("Amount",Amount);            
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);            
            return query.ExecuteUpdate() > 0;
        }

        public bool UpdateCashDenoByENO(string OriginalENO,string ReversalENO, string SourceBranchCode, int UpdatedUserId)
        {
            if (string.IsNullOrEmpty(OriginalENO))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            if (string.IsNullOrEmpty(ReversalENO))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            if (string.IsNullOrEmpty(SourceBranchCode))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            if (string.IsNullOrEmpty(UpdatedUserId.ToString()))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.UpdateCashDenoByENO");
            query.SetString("ENO", OriginalENO);
            query.SetString("ReversalENO", ReversalENO);
            query.SetInt32("UpdatedUserId", UpdatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetString("SourceBranchCode", SourceBranchCode);            
            return query.ExecuteUpdate() > 0;
        }

        public bool UpdateCashDenoByAcType(string AcType, string ReversalENO, string SourceBranchCode, int UpdatedUserId)
        {
            if (string.IsNullOrEmpty(AcType))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            if (string.IsNullOrEmpty(ReversalENO))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            if (string.IsNullOrEmpty(SourceBranchCode))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            if (string.IsNullOrEmpty(UpdatedUserId.ToString()))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.UpdateCashDenoByAcType");
            query.SetString("AcType", AcType);
            query.SetString("ReversalENO", ReversalENO);
            query.SetInt32("UpdatedUserId", UpdatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetString("SourceBranchCode", SourceBranchCode);
            return query.ExecuteUpdate() > 0; 
        }


        [Transaction(TransactionPropagation.Required)]
        public bool UpdateDepoDenoByTLF_EnoGropuNoSourceBr(string ENO, string GroupNo, string SourceBranchCode, int UpdatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.UpdateDepoDenoByTLF_EnoGropuNoSourceBr");
            query.SetString("ENO", ENO);
            query.SetString("GroupNo", GroupNo);
            query.SetString("SourceBranchCode", SourceBranchCode);
            query.SetInt32("UpdatedUserId", UpdatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }
        [Transaction(TransactionPropagation.Required)]
        public bool UpdateDepoDenoByGropuNoSourceBr(string GroupNo, string SourceBranchCode, int UpdatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.UpdateDepoDenoByGropuNoSourceBr");
           
            query.SetString("GroupNo", GroupNo);
            query.SetString("SourceBranchCode", SourceBranchCode);
            query.SetInt32("UpdatedUserId", UpdatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateReversalIBLTLFByENo(string ENO, string SourceBranchCode, int UpdatedUserId)
        {
            if (string.IsNullOrEmpty(ENO))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            if (string.IsNullOrEmpty(SourceBranchCode))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            if (string.IsNullOrEmpty(UpdatedUserId.ToString()))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.UpdateReversalIBLTLFByENo");
            query.SetString("Eno", ENO);
            query.SetString("SourceBranchCode", SourceBranchCode);
            query.SetInt32("UpdatedUserId", UpdatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }

        //[Transaction(TransactionPropagation.Required)]
        //bool UpdateCashDenoByENOStatus(string ReversalENO, string SourceBranchCode, int UpdatedUserId,string Status)
        //{
        //    IQuery query = this.Session.GetNamedQuery("CXDAO00006.UpdateCashDenoByENOStatus");
        //    query.SetString("DenoEntryNo", ReversalENO);
        //    query.SetInt32("UpdatedUserId", UpdatedUserId);
        //    query.SetDateTime("updatedDate", DateTime.Now);
        //    query.SetString("SourceBranchCode", SourceBranchCode);
        //    query.SetString("Status", Status);
        //    return query.ExecuteUpdate() > 0;
        //}

        [Transaction(TransactionPropagation.Required)]
        public bool DeletefromUCheckbyChequeNoAccountNo(string AccountNo, string ChequeNo, string SourceBranchCode, int UpdatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.DeletefromUCheckbyChequeNoAccountNo");
            query.SetString("AccountNo", AccountNo);
            query.SetString("ChequeNo", ChequeNo);
            query.SetInt32("UpdatedUserId", UpdatedUserId);
            query.SetDateTime("UpdatedDate", DateTime.Now);
            query.SetString("SourceBranchCode", SourceBranchCode);
            return query.ExecuteUpdate() > 0;
        }

      
        //
        public decimal SelectDepoDenoSumAmountByGroupNo(string ENO,string GroupNo, string SourceBranchCode)
        {
            if (string.IsNullOrEmpty(ENO))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            if (string.IsNullOrEmpty(GroupNo))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            if (string.IsNullOrEmpty(SourceBranchCode))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.SelectDepoDenoSumAmountByGroupNo");
            query.SetString("ENO", ENO);
            query.SetString("GroupNo", GroupNo);
            query.SetString("SourceBranchCode", SourceBranchCode);
            TLMDTO00009 depodenodto = query.UniqueResult<TLMDTO00009>();
            return (depodenodto.Amount == null) ? 0 : depodenodto.Amount;           
        }

        [Transaction(TransactionPropagation.Required)]
        public bool DeleteDepoDenoByTlf_EnoGroupNo(string ENO, string GroupNo, string SourceBranchCode, int UpdatedUserId)
        {
            if (string.IsNullOrEmpty(ENO))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            if (string.IsNullOrEmpty(GroupNo))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            if (string.IsNullOrEmpty(SourceBranchCode))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            if (string.IsNullOrEmpty(UpdatedUserId.ToString()))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.DeleteDepoDenoByTlf_EnoGroupNo");
            query.SetString("ENO", ENO);
            query.SetString("GroupNo", GroupNo);
            query.SetString("SourceBranchCode", SourceBranchCode);
            query.SetInt32("UpdatedUserId", UpdatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }

        public bool DeleteCashDenoByTLF_enoSourceBrReverse(string ENO, string SourceBranchCode, int UpdatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.DeleteCashDenoByTLF_enoSourceBrReverse");
            query.SetString("ENO", ENO);
            query.SetString("SourceBranchCode", SourceBranchCode);
            query.SetInt32("UpdatedUserId", UpdatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }

        public TLMDTO00005 SelectByTranCode(string tranCode)
        {
            if (string.IsNullOrEmpty(tranCode))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            IQuery query = this.Session.GetNamedQuery("TranTypeDAO.SelectByTranCode");
            query.SetString("tranCode", tranCode);
            return query.UniqueResult<TLMDTO00005>();
        }

        //Select Cash Deno By GroupNo
        public TLMDTO00015 SelectCashDenoByGroupNo(string GroupNo, string SourceBranchCode)
        {
            if (string.IsNullOrEmpty(GroupNo))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            if (string.IsNullOrEmpty(SourceBranchCode))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.SelectCashDenoByGroupNo");
            query.SetString("GroupNo", GroupNo);
            query.SetString("SourceBranchCode", SourceBranchCode);
            return query.UniqueResult<TLMDTO00015>();
        }

        //Select Cash Deno By GroupNoAndStatus
        public TLMDTO00015 SelectCashDenoByGroupNoAndStatus(string GroupNo, string SourceBranchCode,string status)   //Added by ASDA
        {
            if (string.IsNullOrEmpty(GroupNo))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            if (string.IsNullOrEmpty(SourceBranchCode))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.SelectCashDenoByGroupNoAndStatus");
            query.SetString("GroupNo", GroupNo);
            query.SetString("SourceBranchCode", SourceBranchCode);
            query.SetString("status", status);
            return query.UniqueResult<TLMDTO00015>();
        }

        /*Update TLF in Clearing Posting */
        [Transaction(TransactionPropagation.Required)]
        public bool UpdateTLFForClearingPosting(PFMDTO00054 TLFDTO)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00054.UpdateTLFForClearingPosting");
            query.SetDecimal("homeamt", TLFDTO.HomeAmt.Value);
            query.SetDecimal("homeOamt", TLFDTO.HomeOAmt.Value);
            query.SetDecimal("localamt", TLFDTO.LocalAmt.Value);
            query.SetDecimal("localOamt", TLFDTO.LocalOAmt.Value);
            query.SetString("clrpostStatus", TLFDTO.CLRPostStatus);
            query.SetBoolean("deliverReturn", TLFDTO.DeliverReturn);
            query.SetString("narration", TLFDTO.Narration);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", Convert.ToInt32(TLFDTO.UpdatedUserId));
            query.SetString("eno", TLFDTO.Eno);
            query.SetString("accountno", TLFDTO.AccountNo);
            query.SetString("status", TLFDTO.Status);
            query.SetString("sourceBr", TLFDTO.SourceBranchCode);
            return query.ExecuteUpdate() > 0;

        }
        public IList<TLMDTO00009> SelectDepoDenoChargesAmountByEntryNo(string GroupNo)
        {
            if (string.IsNullOrEmpty(GroupNo))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            IQuery query = this.Session.GetNamedQuery("TLMDAO00009.SelectChargesAmountByEntryNo");
            query.SetString("entryNo", GroupNo);
            return query.List<TLMDTO00009>();
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateTLFOrgnENOOrgnTranCodeByENO(string ReversalENO, string AccountNo, string ReversalTrancode, string ENO, string SourceBranchCode, int UpdatedUserId, DateTime updatedDate)                                                        
        {
            if (string.IsNullOrEmpty(ReversalENO))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            if (string.IsNullOrEmpty(ReversalTrancode))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            if (string.IsNullOrEmpty(ENO))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            if (string.IsNullOrEmpty(SourceBranchCode))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            if (string.IsNullOrEmpty(UpdatedUserId.ToString()))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            IQuery query = this.Session.GetNamedQuery("CXDAO00004.UpdateTLFOrgnENOOrgnTranCodeByENO");
            query.SetString("ReversalENO", ReversalENO);
            query.SetString("AccountNo", AccountNo);
            query.SetString("ReversalTranCode", ReversalTrancode);
            query.SetInt32("UpdatedUserId", UpdatedUserId);
            query.SetDateTime("updatedDate", updatedDate);
            query.SetString("SourceBranchCode", SourceBranchCode);
            query.SetString("ENO", ENO);
            return query.ExecuteUpdate() > 0;
        }

        /// <summary>
        /// Get CAOF , SAOF and LAOF Data by Customer Id (TCMSVE00045)
        /// </summary>
        /// <param name="custid"></param>
        /// <param name="status"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00028> GetCustomerAccountData(string custid, string status, ref int count)
        {
            IQuery query = null;
            switch (status)
            {
                case "S":
                    query = this.Session.GetNamedQuery("TCMSVE00045.SelectCustomerSAOFData");
                    break;
                
                case "C":
                    query = this.Session.GetNamedQuery("TCMSVE00045.SelectCustomerCAOFData");
                    break;

                case "L":
                    query = this.Session.GetNamedQuery("TCMSVE00045.SelectCustomerLAOFData");
                    break;

            }
            query.SetString("custid", custid);
            IList<PFMDTO00028> DataList = query.List<PFMDTO00028>();
            count =(DataList != null)? DataList.Count:0;
            return DataList;
        }

        /// <summary>
        /// Get Fixed Deposit Data and Receipt by Customer Id
        /// </summary>
        /// <param name="custid"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00021> GetFLedgerByCustomerId(string custid, ref int count)
        {
            IList<PFMDTO00021> dtolist = new List<PFMDTO00021>();
            IQuery query = this.Session.GetNamedQuery("TCMSVE00052.SelectFAOFData");
            query.SetString("custid", custid);
            var objectList = query.List();
            foreach (var item in objectList)
            {
                object[] a = (object[])item;
                dtolist.Add(new PFMDTO00021(a[0].ToString(), a[1].ToString(), a[2].ToString(), Convert.ToDateTime(a[3])));
            }
            return dtolist;
        }

        [Transaction(TransactionPropagation.Required)]
        public int GetLoanCountByCustomerId(string customerid)
        {
            IQuery query = this.Session.GetNamedQuery("TCMSVE00045.SelectLoanCount");
            query.SetString("custid", customerid);
            var count = query.List();
            return count.Count;
        }

        [Transaction(TransactionPropagation.Required)]
        public PFMDTO00001 GetCustomerAccountCount(string custid)
        {
            IQuery query = this.Session.GetNamedQuery("TCMSVE00045.SelectCustomerAccountCount");
            query.SetString("custid", custid);
            return query.UniqueResult<PFMDTO00001>();
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<TLMDTO00018> GetLoanGuarantee(string acctno)
        {
            IQuery query = this.Session.GetNamedQuery("TCMSVE00045.SelectLoanGuarantee");
            query.SetString("acctno", acctno);
            IList<TLMDTO00018> result = query.List<TLMDTO00018>();
            //var count = query.UniqueResult();
            //return (count == null) ? false : true;
            //return query.UniqueResult<TLMDTO00018>();

            //TLMDTO00018 result = query.List<TLMDTO00018>().FirstOrDefault();
            return result;
        }

        [Transaction(TransactionPropagation.Required)]
        public string SelectTopCurrencyCodeByAccountNo(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00033.SelectTopCurrencyCodeByAccountNo");
            query.SetString("accountNo", accountNo);
            return query.UniqueResult<PFMDTO00033>().CurrencyCode;
        }


        [Transaction(TransactionPropagation.Required)] ////for Sub_Ledger Customer 
        public PFMDTO00001 GetCustomerInfo(string custid,string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("CustomerIdDAO.SelectInfoByCustomerId");
            query.SetString("custid", custid);
            query.SetString("SourceBr", sourcebr);
            return query.UniqueResult<PFMDTO00001>();
        }

        [Transaction(TransactionPropagation.Required)] ////for Sub_Ledger Customer 
        public PFMDTO00001 GetCustomerInfomation(string custid)
        {
            IQuery query = this.Session.GetNamedQuery("SelectInfoByCustomerId");
            query.SetString("custid", custid);
            return query.UniqueResult<PFMDTO00001>();
        }

        public int ChequeSelectCountByBookNoAndSourceBr(string chequeBookNo, string branchCode, string currencyCode)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.Cheque.SelectCountByChequeBookNoAndSourceBr");
            query.SetString("chequeBookNo", chequeBookNo);
            query.SetString("branchCode", branchCode);
            query.SetString("currency", currencyCode);
            object count = query.UniqueResult();
            return Convert.ToInt32(count.ToString());
        }

        public bool CheckUserNameandPassword(string name, string password)
        {
            IQuery query = this.Session.GetNamedQuery("UserDAO.CheckUserNameandPassword");
            query.SetString("username", name);
            string encryptPassword = Encryption.EncryptString(password);
            query.SetString("password", encryptPassword);
            var count = query.UniqueResult();
            return (count == null) ? false : true;
        }

        //ForOnlineWithdrawReversal Case
        [Transaction(TransactionPropagation.Required)]
        public bool UpdateAmountForOnlineTransaction(string eno,string reversalENO,string branchCode,decimal amount)
        {
            if (string.IsNullOrEmpty(eno))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            if (string.IsNullOrEmpty(reversalENO))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            if (string.IsNullOrEmpty(branchCode))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            if (amount == 0)
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.UpdateAmountForOnlineTransaction");
            query.SetString("tlfEno", eno);
            query.SetString("reversalEno", reversalENO);
            query.SetString("sourceBr", branchCode);
            query.SetDecimal("amount", amount);            
            return query.ExecuteUpdate() > 0;
        }

        public PFMDTO00006 GetChequeInfoByChequeBookNo(string chequeBookNo, string branchCode)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00006.Select.ChequeInfoByChequeBookNo");
            query.SetString("chequebookno", chequeBookNo);
            query.SetString("branchCode", branchCode);
            PFMDTO00006 top1Result = query.List<PFMDTO00006>().FirstOrDefault();
            //return query.UniqueResult<PFMDTO00006>();
            return top1Result;
        }

        public TLMDTO00018 GetExpireAmount(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("TLMSVR00042.SelectExpireAmountByAccountNo");
            query.SetString("accountNo", accountNo);
            return query.UniqueResult<TLMDTO00018>();
        }
        #region Added By ZMS For Multiple Deposit And Withdraw Reversal (19/12/2017)
        public TLMDTO00009 SelectDepoDenoReverseStatusByEntryNoAndGroupNo(string groupno,string entryNo,string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00009.SelectDepoDenoReverseStatusByEntryNoAndGroupNo");
            query.SetString("groupNo", groupno);
            query.SetString("entryNo", entryNo);
            query.SetString("sourcebr", sourcebr);
            return query.UniqueResult<TLMDTO00009>();
        }

        public TLMDTO00015 SelectCashDenoGroupTransactionByGroupNo(string GroupNo, string SourceBranchCode)
        {
            if (string.IsNullOrEmpty(GroupNo))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            if (string.IsNullOrEmpty(SourceBranchCode))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.SelectCashDenoGroupTransactionByGroupNo");
            query.SetString("GroupNo", GroupNo);
            query.SetString("SourceBranchCode", SourceBranchCode);
            return query.UniqueResult<TLMDTO00015>();
        }

        public bool UpdateCashDenoReverseStatusOfGroupByENO(string OriginalENO, string ReversalENO, string SourceBranchCode, int UpdatedUserId)
        {
            if (string.IsNullOrEmpty(OriginalENO))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            if (string.IsNullOrEmpty(ReversalENO))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            if (string.IsNullOrEmpty(SourceBranchCode))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            if (string.IsNullOrEmpty(UpdatedUserId.ToString()))
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.UpdateCashDenoReverseStatusOfGroupByENO");
            query.SetString("ENO", OriginalENO);
            query.SetInt32("UpdatedUserId", UpdatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetString("SourceBranchCode", SourceBranchCode);
            return query.ExecuteUpdate() > 0;
        }
        #endregion

        //Added by HMW for "Seperating EOD" at 22.04.2019
        public TCMDTO00001 SelectStartBySourceBr(string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TCMDAO00001.SelectStartBySourceBr");
            query.SetString("sourceBr", sourceBr);
            return query.UniqueResult<TCMDTO00001>();
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00056> SelectAllAutoPayStatusList(string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("Sys001DAO.SelectAllAutoPayStatusList");
            query.SetString("sourceBr", sourceBr);
            IList<PFMDTO00056> list = query.List<PFMDTO00056>();
            return list;
        }
        
    }
        
}
