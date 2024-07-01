using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Pfm.Ctr.Dao;
using Spring.Transaction;
using Spring.Transaction.Interceptor;

namespace Ace.Cbs.Mnm.Sve
{
    public class MNMSVE00007:BaseService,IMNMSVE00007
    {
        public IPFMDAO00053 AppSettingsDAO { get; set; }

        #region Main Method

        [Transaction(TransactionPropagation.Required)]
        public void Save_InterestNature_Configuration(bool isSavingAccrued,bool isFixedAccrued)
        {
            bool flag;
          
             
            if (isSavingAccrued) //If Saving Accrued 
                flag = this.AppSettingsDAO.UpdateKeyValue("SavingInterestAccrued", "Accrued"); 

            else                //Not Saving Accrued 
                flag = this.AppSettingsDAO.UpdateKeyValue("SavingInterestAccrued", "NotAccrued");

            if (isFixedAccrued) //If Fixed Accrued
                 flag = this.AppSettingsDAO.UpdateKeyValue("FixedDepositAccrued", "Accrued");

            else                //Not Fixed Accrued
                 flag = this.AppSettingsDAO.UpdateKeyValue("FixedDepositAccrued", "NotAccrued");

            if (flag == false)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90001"; //Error at updating 
                throw new Exception(this.ServiceResult.MessageCode);
            }

        }

        public IList<PFMDTO00053> SelectByKeyName(string keyName1,string keyname2)
        {
            IList<PFMDTO00053> ListAppSettDTO=this.AppSettingsDAO.SelectByKeyName(keyName1,keyname2);

            if (ListAppSettDTO.Count == 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90027"; //Error Occur
                return null;
            }

            else
                return ListAppSettDTO;
        }
        #endregion

    }
}
