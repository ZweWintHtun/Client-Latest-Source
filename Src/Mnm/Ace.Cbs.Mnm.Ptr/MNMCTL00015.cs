using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Cle;

namespace Ace.Cbs.Mnm.Ptr
{
    public class MNMCTL00015:AbstractPresenter,IMNMCTL00015
    {

        #region View
        IMNMVEW00015 view;
        public IMNMVEW00015 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        private void WireTo(IMNMVEW00015 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetEntity());
            }
        }
        public IList<TLMDTO00016> PO { get; set; }
        public IList<PFMDTO00054> Tlflist { get; set; }
        #endregion

        #region Main Method
        public void Save()
        {
            TLMDTO00016 entity = this.GetEntity();
            if (this.ValidateForm(entity))
            {
               // string vouncherNo = CXClientWrapper.Instance.Invoke<IMNMSVE00015,string>(x => x.Save(this.View.PONo, CurrentUserEntity.CurrentUserID, CurrentUserEntity.BranchCode));
                IList<PFMDTO00054> Tlflist = CXClientWrapper.Instance.Invoke<IMNMSVE00015, IList<PFMDTO00054>>(x => x.Save(entity));
                #region Error Occoured
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {    
                    for (int i = 0; i < Tlflist.Count; i++)
                   {
                       string[] logItemForTlf = new string[35];
                       logItemForTlf[0] = string.Empty;//GroupNo
                       logItemForTlf[1] = this.view.PONo;//EntryNo
                       logItemForTlf[2] = this.PO[0].AccountNo;//AcctNo
                       logItemForTlf[3] = this.PO[0].ACode;
                       logItemForTlf[4] = this.PO[0].Amount.ToString();//LocalAmount
                       logItemForTlf[5] = this.PO[0].Currency;//SourceCur
                       logItemForTlf[6] = string.Empty;//Cheque
                       logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                       logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), entity.SourceBranchCode).ToString();//SettlementDate
                       logItemForTlf[9] = string.Empty;//Status
                       logItemForTlf[10] = entity.SourceBranchCode;//SourceBr
                       logItemForTlf[11] = Tlflist[0].RegisterNo;//Rno
                       logItemForTlf[12] = string.Empty;//Duration
                       logItemForTlf[13] = string.Empty;//LasintDate
                       logItemForTlf[14] = string.Empty;//intRate
                       logItemForTlf[15] = string.Empty;//Accured
                       logItemForTlf[16] = string.Empty;//BudenAcc
                       logItemForTlf[17] = string.Empty;//Draccured
                       logItemForTlf[18] = string.Empty;//AccuredStatus
                       logItemForTlf[19] = string.Empty;//ToAccountNo
                       logItemForTlf[20] = string.Empty;//FirstRno
                       logItemForTlf[21] = string.Empty;//PoNo
                       logItemForTlf[22] = string.Empty;//ADate
                       logItemForTlf[23] = string.Empty;//IDate
                       logItemForTlf[24] = string.Empty;//ToAcctNo
                       logItemForTlf[25] = string.Empty;//Income
                       logItemForTlf[26] = string.Empty;//Budget
                       logItemForTlf[27] = string.Empty;//FromBranch
                       logItemForTlf[28] = string.Empty;//ToBranch
                       logItemForTlf[29] = string.Empty;//Inout
                       logItemForTlf[30] = string.Empty;//Success
                       logItemForTlf[31] = string.Empty;//COMMUCHARGE
                       logItemForTlf[32] = string.Empty;//IncomeType
                       logItemForTlf[33] = string.Empty;//OtherBank
                       logItemForTlf[34] = string.Empty;//OtherBankChq
                       TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Cancel For Issued PO Register By Transfer Fail Transaction", CurrentUserEntity.BranchCode,
                       logItemForTlf);
                   }
                    CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
                #endregion

                #region Successful
                else
               {
                   for (int i = 0; i < Tlflist.Count; i++)
                   {
                       string[] logItemForTlf = new string[35];
                       logItemForTlf[0] = string.Empty;//GroupNo
                       logItemForTlf[1] = this.view.PONo;//EntryNo
                       logItemForTlf[2] = this.PO[0].AccountNo;//AcctNo
                       logItemForTlf[3] = this.PO[0].ACode;
                       logItemForTlf[4] = this.PO[0].Amount.ToString();//LocalAmount
                       logItemForTlf[5] = this.PO[0].Currency;//SourceCur
                       logItemForTlf[6] = string.Empty;//Cheque
                       logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                       logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), entity.SourceBranchCode).ToString();//SettlementDate
                       logItemForTlf[9] = string.Empty;//Status
                       logItemForTlf[10] = entity.SourceBranchCode;//SourceBr
                       logItemForTlf[11] = Tlflist[0].RegisterNo;//Rno
                       logItemForTlf[12] = string.Empty;//Duration
                       logItemForTlf[13] = string.Empty;//LasintDate
                       logItemForTlf[14] = string.Empty;//intRate
                       logItemForTlf[15] = string.Empty;//Accured
                       logItemForTlf[16] = string.Empty;//BudenAcc
                       logItemForTlf[17] = string.Empty;//Draccured
                       logItemForTlf[18] = string.Empty;//AccuredStatus
                       logItemForTlf[19] = string.Empty;//ToAccountNo
                       logItemForTlf[20] = string.Empty;//FirstRno
                       logItemForTlf[21] = string.Empty;//PoNo
                       logItemForTlf[22] = string.Empty;//ADate
                       logItemForTlf[23] = string.Empty;//IDate
                       logItemForTlf[24] = string.Empty;//ToAcctNo
                       logItemForTlf[25] = string.Empty;//Income
                       logItemForTlf[26] = string.Empty;//Budget
                       logItemForTlf[27] = string.Empty;//FromBranch
                       logItemForTlf[28] = string.Empty;//ToBranch
                       logItemForTlf[29] = string.Empty;//Inout
                       logItemForTlf[30] = string.Empty;//Success
                       logItemForTlf[31] = string.Empty;//COMMUCHARGE
                       logItemForTlf[32] = string.Empty;//IncomeType
                       logItemForTlf[33] = string.Empty;//OtherBank
                       logItemForTlf[34] = string.Empty;//OtherBankChq
                       TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Cancel For Issued PO Register By Transfer Commit Transaction", CurrentUserEntity.BranchCode,
                       logItemForTlf);
                   }
                    CXUIMessageUtilities.ShowMessageByCode("MI30040"); //Successfully Reversal Transaction.
                #endregion
                   
                if (CXUIMessageUtilities.ShowMessageByCode("MC00016") == System.Windows.Forms.DialogResult.Yes) //Do you want to print Transactions?
                    {
                        this.Printing();
                    }
                    this.View.ClearControls();
                }
            }
        }

        public void Printing()
        {
            try
            {
                IList<PFMDTO00043> PintFileList = new List<PFMDTO00043>();
                List<string[]> printingList = new List<string[]>();


                PintFileList = CXCLE00006.Instance.SelectAllPrintingDataForCSAccounts(new string[] { this.View.AccountNo });
                PintFileList = PintFileList.OrderBy(x => x.CreatedDate).ToList();


                for (int i = 0; i < PintFileList.Count; i++)
                    {
                        PFMDTO00043 prnFile = PintFileList[i];

                        string[] prnFileStrArr = { prnFile.DATE_TIME.Value.ToString("yyyy/mm/dd"), prnFile.Reference, prnFile.Credit.ToString(), prnFile.Debit.ToString(), prnFile.Balance.ToString(), prnFile.Id.ToString() };

                        printingList.Add(prnFileStrArr);
                    }
                if (PintFileList.Count > 0)
                    {
                        CXCLE00005.Instance.StartLineNo = (int)PintFileList.ToList<PFMDTO00043>()[0].PrintLineNo == 0 ? 1 : (int)PintFileList.ToList<PFMDTO00043>()[0].PrintLineNo;
                        int printedLine = CXCLE00005.Instance.StartLineNo;
                        CXCLE00005.Instance.PrintingList("PassBookCode", "LineByLine", "PassBookPrinting", printingList, false, true, out printedLine);

                        if (!CXCLE00006.Instance.UpdateAfterPrintingForCS(this.View.AccountNo, printedLine,CurrentUserEntity.CurrentUserID))
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME90043);
                    }
                
            }
            catch
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME00061);
            }
        }
        #endregion

        #region Validation Method
        public void txtPaymentOrderNo_CustomValidation(object sender, ValidationEventArgs e)
        {
            if(!e.HasXmlBaseError)
            {
                if (!this.View.PONo.Substring(0, 2).Equals("PO"))
                {
                    this.SetCustomErrorMessage(this.GetControl("txtPaymentOrderNo"), "MV00103");    //Invalid PONo
                }
                else
                {
                    PO = CXClientWrapper.Instance.Invoke<IMNMSVE00015, IList<TLMDTO00016>>(x => x.CheckPO(this.View.PONo, CurrentUserEntity.BranchCode));
                  
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        if (CXClientWrapper.Instance.ServiceResult.MessageCode == "MV00211")
                        {
                            this.SetCustomErrorMessage(this.GetControl("txtPaymentOrderNo"), CXClientWrapper.Instance.ServiceResult.MessageCode, "P.O (by Transfer)");
                        }
                        else
                        {
                            this.SetCustomErrorMessage(this.GetControl("txtPaymentOrderNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                        }
                    }
                    else
                    {
                        this.View.ShowData(PO);
                    }
                    
                }
            }
        }
        #endregion

        #region Helper Method
        TLMDTO00016 GetEntity()
        {
            TLMDTO00016 entity = new TLMDTO00016();
            entity.PONo = this.View.PONo;
            entity.SourceBranchCode = CurrentUserEntity.BranchCode;
            entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
            return entity;
        }

        public string GetBudgetYear()
        {
            string currentBudYear = string.Empty;
            string value = CXCOM00007.Instance.GetValueByVariable(CXCOM00009.BudgetYearCode);
            int month = Convert.ToInt32(value.ToString());
            if (DateTime.Today.Month < month)
            {
                currentBudYear = (DateTime.Today.Year - 1).ToString() + "/" + DateTime.Today.Year.ToString();
            }
            else
            {
                currentBudYear = DateTime.Today.Year.ToString() + "/" + (DateTime.Today.Year + 1).ToString();
            }
            return currentBudYear;
        }
        #endregion
    }
}
