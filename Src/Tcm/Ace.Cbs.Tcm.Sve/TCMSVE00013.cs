using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;

namespace Ace.Cbs.Tcm.Sve
{
    public class TCMSVE00013 : BaseService,ITCMSVE00013  
    {
        #region Dao Properties
        public ICXSVE00006 ReversalSVE { get; set; }

        private IPFMDAO00032 freceiptDAO;
        public IPFMDAO00032 FReceiptDAO
        {
            get
            {
                return this.freceiptDAO;
            }
            set
            {
                this.freceiptDAO = value;
            }
        }

        public IPFMDAO00054 TLFDao { get; set; }
        public ITLMDAO00015 CashDenoDAO { get; set; }
        public ICXSVE00002 CodeGenerator { get; set; }

        #endregion

        #region Main Methods

        public IList<PFMDTO00032> SelectFReceiptByAccountNo(string accountNo,string branchCode)
        {
            IList<PFMDTO00032> FReceiptList = FReceiptDAO.SelectFReceiptListByAccountNo(accountNo);

            if (FReceiptList == null)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00033;
                return null;
            }
            else if(FReceiptList.Count == 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00033;
                return null;
            }
            else if (FReceiptList[0].SourceBranchCode != branchCode)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00091; //Invalid Account No for Branch {0}.
                return null;
            }
            else
                return FReceiptList;
        }

        [Transaction(TransactionPropagation.Required)]
        public void Update(PFMDTO00032 fReceiptDTO)
        {
            try
            {
                PFMDTO00054 tlfDTO;
                TLMDTO00015 cashDenoDTO;
                string fixedCode,channel;
                DateTime settlementDate;
                settlementDate = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), fReceiptDTO.SourceBranchCode);

                if (fReceiptDTO.IsReversalTransaction)
                {
                    tlfDTO = this.TLFDao.SelectTlfForReversal(fReceiptDTO.AccountNo, fReceiptDTO.OldReceiptNo, fReceiptDTO.SourceBranchCode);

                    if (tlfDTO == null)
                        throw new Exception();
                    string ReversalVouno = string.Empty;
                    DateTime sys001 = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("NextSettlementDate"), fReceiptDTO.SourceBranchCode, true });

                    string day = sys001.Day.ToString().PadLeft(2, '0');
                    string month = sys001.Month.ToString().PadLeft(2, '0');
                    string year = sys001.Year.ToString().Substring(2);
                    int updatedUserId = fReceiptDTO.CreatedUserId;

                    //to get Reversal VoucherNo => " R + day + month + year + serial "                  
                    ReversalVouno = this.CodeGenerator.GetGenerateCode("Reversal Code", string.Empty, fReceiptDTO.CreatedUserId, fReceiptDTO.SourceBranchCode, new object[] { day, month, year });
                   
                    //call common module for reversal process
                    // this.ReversalSVE.ReversalProcess(tlfDTO.Eno, ReversalVouno, null, tlfDTO.SourceBranchCode, tlfDTO.DateTime, tlfDTO.SourceBranchCode, updatedUserId, new TLMDTO00015(), string.Empty, true);  // Call Commodule to save Tlf table 

                    //fixedCode = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.FixControl);
                    fixedCode = CXCOM00011.Instance.GetScalarObject<string>("COASetup.Server.Select", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.FixControl), fReceiptDTO.CurrencyCode, fReceiptDTO.SourceBranchCode, true });  //edited by HayMar
                    channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);

                    CXServiceWrapper.Instance.Invoke<ICXSVE00010, bool>(x => x.DepositAdjustment(ReversalVouno, tlfDTO.Eno, fReceiptDTO.AccountNo, fixedCode, tlfDTO.Description, tlfDTO.Amount, 0, fReceiptDTO.AccountSign, fReceiptDTO.CurrencyCode, tlfDTO.Rate.Value, fReceiptDTO.SourceBranchCode, settlementDate, fReceiptDTO.CreatedUserId, channel));

                    if (ServiceResult.ErrorOccurred == true)
                        throw new Exception();

                    cashDenoDTO = new TLMDTO00015();
                    cashDenoDTO.ReceiptNo = fReceiptDTO.OldReceiptNo;
                    cashDenoDTO.AccountType = fReceiptDTO.AccountNo;
                    cashDenoDTO.BranchCode = fReceiptDTO.SourceBranchCode;
                    cashDenoDTO.CreatedDate = fReceiptDTO.CreatedDate;
                    cashDenoDTO.CreatedUserId = fReceiptDTO.CreatedUserId;

                    if (!CashDenoDAO.UpdateReceiptReversal(cashDenoDTO))
                        throw new Exception();
                }
                FReceiptDAO.UpdateFixedReceipt(fReceiptDTO);
                this.ServiceResult.ErrorOccurred = false;
            }
            catch(Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME90036; // Updating Error.
                throw new Exception(this.ServiceResult.MessageCode);
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public void Delete(PFMDTO00032 fReceiptDTO)
        {
            try
            {
                if(FReceiptDAO.DeleteFixedReceipt(fReceiptDTO.AccountNo, fReceiptDTO.ReceiptNo, fReceiptDTO.CreatedUserId, fReceiptDTO.CreatedDate))
                    this.ServiceResult.ErrorOccurred = false;
                else
                    throw new Exception();
            }
            catch
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME90036; // Deleting Error.
                throw new Exception(this.ServiceResult.MessageCode);
            }
        }

        #endregion

    }
}
