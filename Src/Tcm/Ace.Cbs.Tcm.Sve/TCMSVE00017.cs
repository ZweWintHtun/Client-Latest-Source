using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;

namespace Ace.Cbs.Tcm.Sve
{
    public class TCMSVE00017 : BaseService,ITCMSVE00017
    {
        #region Properties

        public ITLMDAO00015 CashDenoDAO { get; set; }
        public ITLMDAO00009 DepoDenoDAO { get; set; }
        public ITLMDAO00004 IblTlfDAO { get; set; }
        #endregion

        #region Variables
        private decimal _Rate { get; set; }

        #endregion

        #region Helper Methods

        public IList<TLMDTO00015> GetOnlineDenominationData(string sourceBr)
        {
            return CashDenoDAO.SelectOnlineCashDenoData(sourceBr);
        }

        public bool CheckEntryNo(string entryNo)
        {
            return this.CashDenoDAO.CheckEntryNo(entryNo);
        }

        /// <summary>
        /// Get Charges and AccountNo to bind GridView according to selected EntryNo
        /// </summary>
        /// <param name="entryNo"></param>
        /// <returns></returns>
        public IList<TLMDTO00015> GetChargesAmount(string entryNo, string sourceBr)
        {
            IList<TLMDTO00015> cashdenoList = new List<TLMDTO00015>();
            if (entryNo.Substring(0, 3).Equals("IBL"))
            {
                cashdenoList.Add(new TLMDTO00015());
                IList<TLMDTO00004> ibltlfdto = this.IblTlfDAO.SelectChargesByEntryNo(entryNo, sourceBr);
                for (int i = 0; i < ibltlfdto.Count; i++)
                {
                    if (ibltlfdto[i].Income != null && ibltlfdto[i].Income != 0)
                    {
                        cashdenoList[i].IncomeCharges = (ibltlfdto[i].Income.Value == null) ? 0 : ibltlfdto[i].Income.Value;
                    }
                    //else
                    //{
                    //    cashdenoList[i].IncomeCharges = 0;
                    //}
                    if (ibltlfdto[i].Communicationcharge != null && ibltlfdto[i].Communicationcharge != 0)
                    {
                        cashdenoList[i].CommunicationCharges = (ibltlfdto[i].Communicationcharge.Value == null) ? 0 : ibltlfdto[i].Communicationcharge.Value;
                    }
                    //else
                    //{
                    //    cashdenoList[i].CommunicationCharges = 0;
                    //}
                    if (ibltlfdto[i].Communicationcharge != null && ibltlfdto[i].Communicationcharge != 0)
                    {
                        cashdenoList[i].AccountType = ibltlfdto[i].AccountNo;
                    }
                }
                return cashdenoList;
            }
            else if (entryNo.Substring(0, 1).Equals("G"))
            {
                IList<TLMDTO00009> depodenolist = this.DepoDenoDAO.SelectChargesByGroupNo(entryNo);
                for (int i = 0; i < depodenolist.Count; i++)
                {
                    cashdenoList.Add(new TLMDTO00015());
                    cashdenoList[i].IncomeCharges = (depodenolist[i].Income.Value == null) ? 0 : depodenolist[i].Income.Value;
                    cashdenoList[i].CommunicationCharges = (depodenolist[i].Communicationcharge.Value == null) ? 0 : depodenolist[i].Communicationcharge.Value;
                    cashdenoList[i].AccountType = depodenolist[i].AccountType;
                }
                return cashdenoList;
            }
            else
                return null;
        }
        #endregion

        #region MainMethods 

        [Transaction(TransactionPropagation.Required)]
        public void Update(string entryno,string currency, CXDTO00001 denodto, int updatedUserId)
        {
            decimal rate = CXCOM00010.Instance.GetExchangeRate(currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType));
            if (this.CheckEntryNo(entryno))
            {
                try
                {
                    this.CashDenoDAO.UpdateCashDeno(entryno,denodto, denodto.CounterNo, updatedUserId, rate);
                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = "MI90001";
                }
                catch
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "ME90000";
                }
            }
            else
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV00213";
            }
        }
        #endregion
    }
}
