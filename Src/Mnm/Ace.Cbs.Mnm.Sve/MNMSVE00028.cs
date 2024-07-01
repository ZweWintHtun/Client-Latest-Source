using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Pfm.Ctr.Dao;
using Spring.Transaction;
using Spring.Transaction.Interceptor;

namespace Ace.Cbs.Mnm.Sve
{
    class MNMSVE00028 : BaseService, IMNMSVE00028
    {
        ITLMDAO00001 REDAO { get; set; }
        ITLMDAO00016 PODAO { get; set; }
        ICXSVE00002 CodeGenerator { get; set; }
        ICXSVE00006 ReversalService { get; set; }
        IPFMDAO00054 TLFDAO { get; set; }
        ICXDAO00006 CodeCheckerDAO { get; set; }
        public IList<PFMDTO00054> TLF_LIST { get; set; }

        public TLMDTO00001 GetReInfo(string registerNo,string sourceBr)
        {
            TLMDTO00001 reInfo = this.REDAO.SelectByRegisterNo(registerNo, sourceBr);
            if (reInfo != null && (reInfo.ToAccountNo != null && reInfo.ToAccountNo.ToString() != string.Empty && reInfo.ToAccountNo.Substring(0, 2) == "IR"))
            {
                string CurBudYear = CXCOM00010.Instance.GetBudgetYear1("");
                TLMDTO00016 PODTO = this.PODAO.SelectPOByPONoAndSourceBrAndCurAndBudgetYear(reInfo.ToAccountNo, sourceBr, reInfo.Currency, CurBudYear);
                if (PODTO == null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MV00219"; //PO No. Not Found.
                    return null;
                }
            }
            return reInfo;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00054> Save(string registerNo, int updatedUserId, string sourceBr)
        {
            try
            {
                IList<PFMDTO00054> ListTLFDTO = new List<PFMDTO00054>();
                TLMDTO00001 reInfo = this.REDAO.SelectByRegisterNo(registerNo, sourceBr);
                if (reInfo != null && (reInfo.ToAccountNo != null && reInfo.ToAccountNo.ToString() != string.Empty && reInfo.ToAccountNo.Substring(0, 2) == "IR"))
                {
                    string CurBudYear = CXCOM00010.Instance.GetBudgetYear1("");
                    TLMDTO00016 PODTO = this.PODAO.SelectPOByPONoAndSourceBrAndCurAndBudgetYear(reInfo.ToAccountNo, sourceBr, reInfo.Currency, CurBudYear);

                    if (PODTO != null)
                    {
                        if (PODTO.IDate != null && PODTO.IDate != default(DateTime) && PODTO.IDate.ToString() != string.Empty)
                        {
                            this.ServiceResult.ErrorOccurred = true;
                            this.ServiceResult.MessageCode = "MV00149";    //This P.O No. {0} is already refund.
                            return null;
                        }

                        //Delete PO
                        PODAO.DeletePOByActive(reInfo.ToAccountNo, sourceBr, updatedUserId);
                    }
                }
                    
                    ListTLFDTO = TLFDAO.SelectByERegisterNo(registerNo, sourceBr, System.DateTime.Now);//ask
                    if (ListTLFDTO.Count > 0)
                    {

                        string ReversalVouno = string.Empty;
                        DateTime sys001 = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("NextSettlementDate"), sourceBr ,true });

                        string day = sys001.Day.ToString().PadLeft(2, '0');
                        string month = sys001.Month.ToString().PadLeft(2, '0');
                        string year = sys001.Year.ToString().Substring(2);

                        //to get vouno => " R + day + month + year + serial "
                        //ReversalVouno = this.CodeGenerator.GetGenerateCode("Reversal Voucher", string.Empty, updatedUserId, CurrentUserEntity.BranchCode, new object[] { day, month, year });                                 //To get Reversal Voucher No 
                        ReversalVouno = this.CodeGenerator.GetGenerateCode("Reversal Code", string.Empty, Convert.ToInt32(updatedUserId), sourceBr, new object[] { day, month, year });
                        //Reversal Process
                        this.ReversalService.ReversalProcess(ListTLFDTO[0].Eno, ReversalVouno, null, sourceBr, DateTime.Now, sourceBr, updatedUserId, null, null, true);

                        ListTLFDTO[0].ReferenceVoucherNo = ReversalVouno;
                        TLF_LIST = (from a in ListTLFDTO where a.Eno == ListTLFDTO[0].Eno select a).ToList();
                        for(int i = 0; i < TLF_LIST.Count; i++)
                        {
                            /////Insert Into TLF
                            TLMDTO00005 reversaltrancodedto = this.CodeCheckerDAO.SelectByTranCode(this.CodeCheckerDAO.SelectByTranCode(TLF_LIST[i].TransactionCode).RVReference);
                            TLF_LIST[i].Status = reversaltrancodedto.Status;
                        }
                        //Update Active=0 in RE Table
                        this.REDAO.DeleteREbyRegisterNo(registerNo, sourceBr,null,updatedUserId);
                    }
                    return TLF_LIST;
                
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MI30041";   //Reversal Transaction Fail. 
                throw new Exception(this.ServiceResult.MessageCode);
            }
        }
    }
}
