using System;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.Core.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Mnm.Ctr.Sve;
using System.Collections.Generic;
using Ace.Cbs.Mnm.Ctr.Dao;
//using Ace.Cbs.Pfm.Dao;
using Ace.Windows.Core.Utt;


namespace Ace.Cbs.Mnm.Sve
{
    class MNMSVE00047 : BaseService, IMNMSVE00047
    {
        #region Properties

        public IPFMDAO00028 CledgerDAO { get; set; }
        public ICXDAO00009 ViewDAO { get; set; }
        private ICXDAO00006 CodeCheckerDAO { get; set; }
        public PFMDTO00001 CommonDto = new PFMDTO00001();       

        #endregion

        public PFMDTO00001 CheckingAccountNo(string accountNo, string accountType, string branchCode)
        {
            string[] acType = accountType.Split(".".ToCharArray());
            string message = string.Empty;

            try
            {              
                    if (acType[0].Contains("Saving") || acType[0].Contains("Current"))  //Current or Saving Account
                    {
                        PFMDTO00028 cledgerAccount = this.CledgerDAO.SelectACSignByAccountNo(accountNo);

                        if (cledgerAccount == null)
                        {
                            this.ServiceResult.ErrorOccurred = true;
                            this.ServiceResult.MessageCode = CXMessage.MV00175;    //Account No Not Found
                            return null;
                        }
                        if (cledgerAccount.CloseDate != null && cledgerAccount.CloseDate.ToString() != "" && cledgerAccount.CloseDate != default(DateTime))
                        {
                            this.ServiceResult.ErrorOccurred = true;
                            this.ServiceResult.MessageCode = CXMessage.MV00044;     //Account has been Closed
                            return null;
                        }
                     
                        if (acType[0] == "Current")     //Current Account
                        {
                            CommonDto = this.ViewDAO.SelectCaofInfoByAcctno (accountNo);//Select From Caof
                          
                        }
                        else        //Saving Account
                        {
                            CommonDto = this.ViewDAO.SelectSaofInfoByAcctno(accountNo); //Select From Saof    
                           
                        }
                        this.CommonDto.IsCheck = true;
                    
                }
            }

            catch (Exception e)
            {
                if (e.Message == CXMessage.MV00211)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV00211;
                    CommonDto = new PFMDTO00001();
                    CommonDto.Message = message;
                }
                else
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = e.Message;
                }
            }

            return this.CommonDto;

        }

        public IList<PFMDTO00001> SelectData(string accountType, string branchCode)
        {
            string type = accountType;

            if (type.Contains("Current"))
            {
                return this.ViewDAO.SelectCaofInfo(branchCode);
            }

            else if (type.Contains("Saving"))
            {
                return this.ViewDAO.SelectSaofInfo(branchCode);
            }

            return null;
 
        }

        public string SelectTopCurrencyCodeByAccountNo(string accountNo)
        {
            string currencycode = this.CodeCheckerDAO.SelectTopCurrencyCodeByAccountNo(accountNo);
            return currencycode;
        }
    }

}