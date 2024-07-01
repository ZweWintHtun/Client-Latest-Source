using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Windows.Core.Utt;
using System.Windows.Forms;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Mnm.Ptr
{
    class MNMCTL00028 : AbstractPresenter, IMNMCTL00028
    {
        #region View
        private IMNMVEW00028 view;
        public IMNMVEW00028 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        private void WireTo(IMNMVEW00028 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetEntity());
            }
        }
        #endregion
        
        public void txtEncashRegisterNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (!e.HasXmlBaseError)
            {
                TLMDTO00001 reInfo = CXClientWrapper.Instance.Invoke<IMNMSVE00028, TLMDTO00001>(x => x.GetReInfo(View.RegisterNo, CurrentUserEntity.BranchCode));
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    this.SetCustomErrorMessage(this.GetControl("txtEncashRegisterNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
                else
                {
                    if (reInfo == null)
                    {
                        this.SetCustomErrorMessage(this.GetControl("txtEncashRegisterNo"), "MV00187"); //Invalid Encash RegisterNo.
                    }
                    else if (reInfo.IssueDate == null || reInfo.IssueDate == default(DateTime) || reInfo.IssueDate.ToString() == string.Empty)
                    {
                        this.SetCustomErrorMessage(this.GetControl("txtEncashRegisterNo"), "MV30009"); //Only Allow Encash Register No. that already voucher prepare.
                    }
                    else if (reInfo.IssueDate.Value.ToShortDateString() != DateTime.Now.ToShortDateString())
                    {
                        this.SetCustomErrorMessage(this.GetControl("txtEncashRegisterNo"), "ME30002");  //Not Allow Back Date Transaction.
                    }
                    else
                    {
                        this.SetCustomErrorMessage(this.GetControl("txtEncashRegisterNo"), string.Empty);
                        IList<TLMDTO00001> reList = new List<TLMDTO00001>();
                        reList.Add(reInfo);
                        this.View.BindInformation(reList);
                    }
                }
            }
        }

        public void Save()
        {
            TLMDTO00001 data = this.GetEntity();
            if (this.ValidateForm(data))
            {
                if (CXUIMessageUtilities.ShowMessageByCode("MC90001") == DialogResult.Yes)    //confirm to Delete or Reverse
                {
                    this.view.SaveStatus = true;
                    IList<PFMDTO00054> Tlf_List = CXClientWrapper.Instance.Invoke<IMNMSVE00028, IList<PFMDTO00054>>(x => x.Save(View.RegisterNo, CurrentUserEntity.CurrentUserID, CurrentUserEntity.BranchCode));
                    #region ErrorOccurred
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        if (Tlf_List.Count > 0)
                        {
                            string[] logItemForTlf = new string[35];
                            //ClientLog For Tlf
                            for (int i = 0; i < Tlf_List.Count; i++)
                            {
                                logItemForTlf[0] = string.Empty;//GroupNo
                                logItemForTlf[1] = Tlf_List[0].ReferenceVoucherNo;//EntryNo
                                logItemForTlf[2] = Tlf_List[i].AccountNo;//AcctNo
                                logItemForTlf[3] = Tlf_List[i].Acode;//ACode(from COASetUp)
                                logItemForTlf[4] = Tlf_List[i].LocalAmount.ToString();//LocalAmount
                                logItemForTlf[5] = Tlf_List[i].SourceCurrency;//SourceCur
                                logItemForTlf[6] = string.Empty;//Cheque
                                logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                                logItemForTlf[8] = Tlf_List[i].SettlementDate.ToString();//SettlementDate
                                logItemForTlf[9] = Tlf_List[i].Status;//Status
                                logItemForTlf[10] = Tlf_List[i].SourceBranchCode;//SourceBr
                                logItemForTlf[11] = Tlf_List[0].Eno;//Rno
                                logItemForTlf[12] = string.Empty;//Duration
                                logItemForTlf[13] = string.Empty;//LasintDate
                                logItemForTlf[14] = Tlf_List[0].Rate.ToString();//intRate
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
                                TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Encash Adjustment Commit Transaction", CurrentUserEntity.BranchCode,
                                logItemForTlf);
                            }
                        }
                        CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                    #endregion

                    #region Successful
                    else
                    {
                        if (Tlf_List.Count > 0)
                        {
                            string[] logItemForTlf = new string[35];
                            //ClientLog For Tlf
                            for (int i = 0; i < Tlf_List.Count; i++)
                            {
                                logItemForTlf[0] = string.Empty;//GroupNo
                                logItemForTlf[1] = Tlf_List[0].ReferenceVoucherNo;//EntryNo
                                logItemForTlf[2] = Tlf_List[i].AccountNo;//AcctNo
                                logItemForTlf[3] = Tlf_List[i].Acode;//ACode(from COASetUp)
                                logItemForTlf[4] = Tlf_List[i].LocalAmount.ToString();//LocalAmount
                                logItemForTlf[5] = Tlf_List[i].SourceCurrency;//SourceCur
                                logItemForTlf[6] = string.Empty;//Cheque
                                logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                                logItemForTlf[8] = Tlf_List[i].SettlementDate.ToString();//SettlementDate
                                logItemForTlf[9] = Tlf_List[i].Status;//Status
                                logItemForTlf[10] = Tlf_List[i].SourceBranchCode;//SourceBr
                                logItemForTlf[11] = Tlf_List[0].Eno;//Rno
                                logItemForTlf[12] = string.Empty;//Duration
                                logItemForTlf[13] = string.Empty;//LasintDate
                                logItemForTlf[14] = Tlf_List[0].Rate.ToString();//intRate
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
                                TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Encash Adjustment Commit Transaction", CurrentUserEntity.BranchCode,
                                logItemForTlf);
                            }
                        }
                        CXUIMessageUtilities.ShowMessageByCode("MI30040"); //Successfully Reversal Transaction.
                        View.ClearControl();
                    }
                    #endregion
                }
            }
        }

        private TLMDTO00001 GetEntity()
        {
            TLMDTO00001 entity = new TLMDTO00001();
            entity.RegisterNo = this.View.RegisterNo;
            return entity;
        }
    }
}
