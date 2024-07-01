using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Spring.Transaction;
using Spring.Transaction.Interceptor;

namespace Ace.Cbs.Mnm.Sve
{
    public class MNMSVE00025 : BaseService, IMNMSVE00025
    {
        ITLMDAO00001 REDAO { get; set; }

        public TLMDTO00001 GetReInfo(string registerNo, string sourceBr)
        {
            return this.REDAO.SelectByRegisterNo(registerNo, sourceBr);
        }

        [Transaction(TransactionPropagation.Required)]
        public void UpdateReInfo(TLMDTO00001 entity)
        {
            try
            {
                this.REDAO.UpdateByRegisterNo(entity);
            }
            catch (Exception e)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MC90003"; //Update Fail. Try Again?
            }
        }
    }
}
