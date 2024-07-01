using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Mnm.Ctr.Dao;
using Ace.Windows.Admin.Contracts.Dao;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tcm.Ctr.Dao;
using Ace.Cbs.Tcm.Dmd;

namespace Ace.Cbs.Mnm.Sve
{
    public class MNMSVE00139 :BaseService, IMNMSVE00139
    {
        #region DAO Properties
        ITLMDAO00015 CashDenoDao { get; set; }
        IPFMDAO00054 TlfDao { get; set; }
        ICXSVE00006 CustomerCommonService { get; set; }
        ITLMDAO00009 DepoDenoDao { get; set; }
        ICXSVE00002 CodeGenerator { get; set; }
        #endregion

        #region variable
        IList<TLMDTO00009> DenoDepoList { get; set; }
        PFMDTO00001 informationdto { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// To get Data information to show UI
        /// </summary>
        /// <param name="eno"></param>
        /// <param name="sourcebranch"></param>
        /// <param name="isMulti"></param>
        /// <returns></returns>
        
        public MNMDTO00055 GetInformationList(string eno, string sourcebranch, bool isMulti)
        {
            try
            {                
                MNMDTO00055 denoeditdto = new MNMDTO00055();                
                denoeditdto.CashDenoDto = this.GetCashDenoDatayByEno(eno, sourcebranch);
                IList<PFMDTO00001> InformationList = new List<PFMDTO00001>();
                if (denoeditdto.CashDenoDto == null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MI30016";
                    return null;
                }
                else
                {
                    if (!denoeditdto.CashDenoDto.CashDate.Value.ToString("yyyy/MM/dd").Equals(DateTime.Now.ToString("yyyy/MM/dd")))
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = "ME30002";
                        return null;
                    }
                }

               

                if (isMulti)
                {
                    DenoDepoList = this.DepoDenoDao.SelectAccountNoByGroupNo(eno, denoeditdto.CashDenoDto.Status,denoeditdto.CashDenoDto.SourceBranchCode);
                    //int index = 0;
                    foreach (TLMDTO00009 deponodto in DenoDepoList)
                    {
                        informationdto = new PFMDTO00001();
                        if (deponodto.AccountType.Length.Equals(Convert.ToInt32(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CustomerAccountTypeLength))))
                        {
                            informationdto = this.CustomerCommonService.GetCustomerInfomationByAccountNo(deponodto.AccountType, false)[0];
                        }
                        IList<PFMDTO00054> NarrationList = this.TlfDao.GetNarrationByEno(deponodto.Tlf_Eno);
                        //informationdto.CashDenoAmount = denoeditdto.CashDenoDto.Amount;
                        informationdto.Narration = NarrationList[0].Narration;
                        informationdto.Amount = deponodto.Amount;
                        informationdto.AccountNo = deponodto.AccountType;
                        InformationList.Add(informationdto);
                        //index++;
                    }
                }
                else
                {
                    IList<PFMDTO00054> NarrationList = this.TlfDao.GetNarrationByEno(eno);
                    informationdto = new PFMDTO00001();
                    if (denoeditdto.CashDenoDto.AccountType.Length.Equals(Convert.ToInt32(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CustomerAccountTypeLength))))
                    {
                        informationdto = this.CustomerCommonService.GetCustomerInfomationByAccountNo(denoeditdto.CashDenoDto.AccountType, false)[0];
                    }
                    informationdto.Narration = NarrationList[0].Narration;
                    informationdto.Amount = denoeditdto.CashDenoDto.Amount;
                    informationdto.AccountNo = denoeditdto.CashDenoDto.AccountType;
                    InformationList.Add(informationdto);
                }
                denoeditdto.InformationList = InformationList;
                
                return denoeditdto;
            }
            catch
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90027"; ////Invalid Entry No
                return null; 
            }
        }
        /// <summary>
        /// Save new record and edit old one for Cash Deno Edit
        /// </summary>
        /// <param name="tlfeno"></param>
        /// <param name="cashdenodto"></param>
        [Transaction(TransactionPropagation.Required)]
        public string SaveCashDenoEdit(string tlfeno , TLMDTO00015 cashdenodto)
        {
            try
            {
                cashdenodto.TlfEntryNo = this.CodeGenerator.GetGenerateCode("DenoEdit", string.Empty, cashdenodto.CreatedUserId, cashdenodto.SourceBranchCode);
                cashdenodto.CashDate = DateTime.Now;
                cashdenodto.SettlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", 
                    new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), cashdenodto.SourceBranchCode,true });
                cashdenodto.Rate = CXCOM00010.Instance.GetExchangeRate(cashdenodto.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType));
                this.CashDenoDao.Save(this.TransferDtoToOrm(cashdenodto));
                this.CashDenoDao.UpdateCashDenoEdit(tlfeno, cashdenodto);

                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI90002";
                return cashdenodto.TlfEntryNo;
            }
            catch
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90039";
                throw new Exception(this.ServiceResult.MessageCode);
            }
        }

        #endregion

        #region HelperMethods
        private TLMDTO00015 GetCashDenoDatayByEno(string eno, string sourcebranch)
        {
            return this.CashDenoDao.SelectCashDenoByTlfEnoForDenoEdit(eno,sourcebranch);
        }

        private TLMORM00015 TransferDtoToOrm(TLMDTO00015 cashdenodto)
        {
            TLMORM00015 cashdenoOrm = new TLMORM00015();
            cashdenoOrm.DenoEntryNo = null;
            cashdenoOrm.TlfEntryNo = cashdenodto.TlfEntryNo;
            cashdenoOrm.AccountType = cashdenodto.AccountType;
            cashdenoOrm.BranchCode = cashdenodto.BranchCode;
            cashdenoOrm.ReceiptNo = cashdenodto.ReceiptNo;
            cashdenoOrm.Amount = cashdenodto.Amount;
            cashdenoOrm.AdjustAmount = cashdenodto.AdjustAmount;
            cashdenoOrm.CashDate = cashdenodto.CashDate;
            cashdenoOrm.DenoDetail = cashdenodto.DenoDetail;
            cashdenoOrm.DenoRefundDetail = cashdenodto.DenoRefundDetail;
            cashdenoOrm.UserNo = cashdenodto.UserNo;
            cashdenoOrm.CounterNo = cashdenodto.CounterNo;
            cashdenoOrm.Status = cashdenodto.Status;
            cashdenoOrm.Reverse = cashdenodto.Reverse;
            cashdenoOrm.SourceBranchCode = cashdenodto.SourceBranchCode;
            cashdenoOrm.Currency = cashdenodto.Currency;
            cashdenoOrm.DenoRate = cashdenodto.DenoRate;
            cashdenoOrm.DenoRefundRate = cashdenodto.DenoRefundRate;
            cashdenoOrm.SettlementDate = cashdenodto.SettlementDate;
            cashdenoOrm.AllDenoRate = cashdenodto.AllDenoRate;
            cashdenoOrm.Rate = cashdenodto.Rate;
            cashdenoOrm.CreatedUserId = cashdenodto.CreatedUserId;
            return cashdenoOrm;
        }
        #endregion
    }
}
