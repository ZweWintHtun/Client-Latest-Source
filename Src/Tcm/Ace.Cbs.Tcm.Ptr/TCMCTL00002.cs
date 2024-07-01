//----------------------------------------------------------------------
// <copyright file="TCMCTL00002.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Windows.CXClient;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Tel.Ctr.Sve;
using System.Windows.Forms;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Cx.Com.Ctr;

namespace Ace.Cbs.Tcm.Ptr
{
    /// <summary>
    /// PO Refund By Transfer Controller
    /// </summary>

    public class TCMCTL00002 : AbstractPresenter, ITCMCTL00002
    {
        #region INITIALIZE VIEW
        private ITCMVEW00002 view;
        public ITCMVEW00002 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ITCMVEW00002 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetPOEntity());
            }
        }
        #endregion

        #region Helper Method      

        public TLMDTO00016 GetPOEntity()
        {
            TLMDTO00016 po = new TLMDTO00016();
            po.AccountNo = this.view.AccountNo;
            return po;

        }
        public TLMDTO00016 podto { get; set; }
        public TLMDTO00016 PO_Info;
        IList<PFMDTO00001> customers { get; set; }

        public string GetBudYear()
        {
            string Return = string.Empty;
            //DateTime tempDate = Convert.ToDateTime(this.View.RequireYear + "/" + this.View.RequireMonth + "/" + Convert.ToString(DateTime.Now.Day));

            string activeBudget = CXClientWrapper.Instance.Invoke<ITCMSVE00002, string>(x => x.GetBudYear(6, DateTime.Now, CurrentUserEntity.BranchCode));
            return activeBudget;
        }

        public IList<PFMDTO00043> PrintTransaction()
        {
            try
            {
                List<string[]> printingList = new List<string[]>();
                IList<PFMDTO00043> printtransaction = CXClientWrapper.Instance.Invoke<ITCMSVE00002, IList<PFMDTO00043>>(x => x.GetPrint(this.view.AccountNo));

                foreach (PFMDTO00043 item in printtransaction)
                {
                    string[] prnFileStrArr = { item.DATE_TIME.Value.ToString("dd/MM/yyyy"), item.Reference, item.Debit.ToString(), item.Credit.ToString(), item.Balance.ToString(), this.view.AccountNo };

                    printingList.Add(prnFileStrArr);

                }
                CXCLE00005.Instance.PrintingList("PassBookCode", "LineByLine", "PassBookPrinting", printingList, false, true);
                this.ClearControls();
                return printtransaction;
            }
            catch (Exception ex)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00010);
                return null;

            }

        }
        public void CheckSavingCustomer()
        {
            this.view.EnableControlsforPrint();
        }

        public void CommomtoSave()
        {
            try
            {
                TLMDTO00016 po = new TLMDTO00016();
                PO_Info = new TLMDTO00016();
                if (string.IsNullOrEmpty(this.podto.ACode))
                {
                    PO_Info.ACode = po.ACode = CXCLE00002.Instance.GetScalarObject<string>("COASetup.Client.Select", new object[] { CXCOM00007.Instance.GetValueByKeyName("PO"), this.view.Currency, CurrentUserEntity.BranchCode, true });
                }
                else
                {
                    this.PO_Info.ACode = po.ACode = this.podto.ACode;
                }

                if (this.customers != null)
                {
                    if (this.customers[0].AccountSign.StartsWith(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurrentAccountSign)))
                    {
                        PO_Info.CreditAcode = po.CreditAcode = CXCLE00002.Instance.GetScalarObject<string>("COASetup.Client.Select", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurControl), this.view.Currency, CurrentUserEntity.BranchCode, true });
                    }
                    else
                    {
                        PO_Info.CreditAcode = po.CreditAcode = CXCLE00002.Instance.GetScalarObject<string>("COASetup.Client.Select", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SavControl), this.view.Currency, CurrentUserEntity.BranchCode, true });
                    }
                }
                else
                {
                    PO_Info.CreditAcode = po.CreditAcode = this.view.AccountNo;
                }
                //po.ToAccountNo = podto.AccountNo;
                PO_Info.Amount = po.Amount = Convert.ToDecimal(this.view.Amount);//Modified by HMW at 3-Oct-2019 : Adding Thousand Seperators
                PO_Info.Currency = po.Currency = this.view.Currency;
                PO_Info.PONo = po.PONo = this.view.PONo;
                PO_Info.SourceBranchCode = po.SourceBranchCode = CurrentUserEntity.BranchCode;
                PO_Info.ToAccountNo = po.ToAccountNo = this.view.AccountNo;
                PO_Info.CustomerName = po.CustomerName = this.view.CustomerName;
                if (this.customers == null)
                {
                    PO_Info.AcSign = po.AcSign = string.Empty;
                }
                else
                {
                    PO_Info.AcSign = po.AcSign = this.customers[0].AccountSign;
                }
                po.IsCOAAccount = this.podto.IsCOAAccount;
                PO_Info.Budget = po.Budget = this.view.BudgetYear;
                po.UserNo = CurrentUserEntity.CurrentUserID.ToString();
                po.CreatedUserId = CurrentUserEntity.CurrentUserID;
                PO_Info.VoucherNo = CXClientWrapper.Instance.Invoke<ITCMSVE00002, string>(x => x.Save(po));

                #region Print Line
                if (this.customers != null && this.customers.Count > 0 && this.customers[0].AccountSign.StartsWith(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SavingAccountSign)))
                {
                    PFMDTO00028 account = CXClientWrapper.Instance.Invoke<ITCMSVE00002, PFMDTO00028>(x => x.GetAccountBalance(this.view.AccountNo));
                    PFMDTO00043 prnFileDTO = new PFMDTO00043();
                    prnFileDTO.AccountNo = this.customers[0].AccountNo;

                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00017, new object[] { this.view.AccountNo });
                    CXUIScreenTransit.Transit("frmPFMVEW00009", true, new object[] { this.View.MenuIdForPermission, prnFileDTO, customers[0].AccountSign, false });
                }
                #endregion

            }
            catch (Exception ex)
            { }
        }

        //Added by YMP at 30-07-2019 : [Seperating EOD Process] To show system date (not PC date) at report
        public DateTime GetSystemDate(string sourceBr)
        {
            TCMDTO00001 systemStartInfo = CXClientWrapper.Instance.Invoke<ICXSVE00006, TCMDTO00001>(x => x.SelectStartBySourceBr(sourceBr));
            DateTime systemDate = systemStartInfo.Date;
            return systemDate;
        }

        //Added by HMW at 26-08-2019 : [Seperating EOD Process] Check Settlement Date to show form
        public DateTime GetLastSettlementDate(string sourceBr)
        {
            DateTime lastSettlementDate = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.LastSettlementDate), sourceBr);
            return lastSettlementDate;
        }

        #endregion

        #region Validation Logic
        public void mtxtAccountNo_Validating(object sender, ValidationEventArgs e)
        {
            #region XML Error
            if (e.HasXmlBaseError)
            {
                return;
            }
            #endregion

            try
            {
                Nullable<CXDMD00011> accountType;

                if (CXCLE00012.Instance.IsValidAccountNo(this.view.AccountNo, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2) == true)
                {
                    if(accountType == CXDMD00011.DomesticAccountType)
                    {

                    }
                    IList<PFMDTO00001> customer = CXClientWrapper.Instance.Invoke<ITCMSVE00002, IList<PFMDTO00001>>(x => x.CheckCusomer(this.view.AccountNo, CurrentUserEntity.BranchCode));
                    this.customers = customer;

                    if (customer.Count > 0)
                    {
                        this.view.CustomerName = customer[0].Name;

                        #region Check UI Currency with Account Currency

                        if (this.view.Currency != customer[0].CurrencyCode)
                        {
                            this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00086, new object[] { this.view.Currency });
                            return;
                        }
                        #endregion
                    }

                    this.CheckSavingCustomer();
                }
                else if (CXCLE00012.Instance.IsValidAccountNo(this.view.AccountNo, out accountType) && (accountType == CXDMD00011.DomesticAccountType))
                {
                    if (this.view.AccountNo.Substring(3) == "000")
                    {
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00199);
                    }

                    ChargeOfAccountDTO coa = CXCOM00011.Instance.GetScalarObject<ChargeOfAccountDTO>("COA.Client.SelectAccountName", new object[] { this.view.AccountNo, CurrentUserEntity.BranchCode, true });
           
                    if (coa != null)
                    {
                        this.view.CustomerName = coa.AccountName;

                        this.podto.IsCOAAccount = true;
                    }
                    else
                    {
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }
            }
            catch (Exception ex)
            {
                if (CXClientWrapper.Instance.ServiceResult.MessageCode == "MV00091")
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode, new object[] { CurrentUserEntity.BranchCode });
                else
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode, new object[] { this.view.AccountNo });

                if (string.IsNullOrEmpty(CXClientWrapper.Instance.ServiceResult.MessageCode))
                {
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), ex.Message, new object[] { this.view.AccountNo });
                }

            }


        }

        #endregion

        #region UI Logic

        public void ClearControls()
        {
            this.view.PONo = string.Empty;
            this.view.BudgetYear = string.Empty;
            this.view.AccountNo = string.Empty;
            this.view.CustomerName = string.Empty;
            //this.view.Currency = string.Empty;
            this.view.Amount = 0;
            this.ClearErrors();
        }

        public void CheckPO()
        {

            TLMDTO00016 po = CXClientWrapper.Instance.Invoke<ITCMSVE00002, TLMDTO00016>(x => x.CheckPOAndBudget(this.view.PONo, this.view.BudgetYear,CurrentUserEntity.BranchCode));
            this.podto = po;
            if (po == null)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode, new object[] { this.view.PONo });
                this.view.POFocus();

            }
            else
            {
                this.view.Currency = po.Currency;
                this.view.Amount = Convert.ToDouble(po.Amount);
                this.view.Acode = po.ACode;
                this.view.AccountFocus();

            }
        }


        public void Save()
        {
            //try
            //{
            //    TLMDTO00016 po = new TLMDTO00016();

            //    if (string.IsNullOrEmpty(this.podto.ACode))
            //    {
            //        po.ACode = CXCLE00002.Instance.GetScalarObject<string>("COASetup.Client.Select", new object[] { CXCOM00007.Instance.GetValueByKeyName("PO"), this.view.Currency, CurrentUserEntity.BranchCode, true });
            //    }
            //    else
            //    {
            //        po.ACode = this.podto.ACode;
            //    }

            //    po.Amount = this.view.Amount;
            //    po.Currency = this.view.Currency;
            //    po.PONo = this.view.PONo;
            //    po.SourceBranchCode = CurrentUserEntity.BranchCode;
            //    po.AccountNo = this.view.AccountNo;
            //    po.CustomerName = this.view.CustomerName;
            //    if (this.customers  == null)
            //    {
            //        po.AcSign = string.Empty;
            //    }
            //    else
            //    {
            //        po.AcSign = this.customers[0].AccountSign;
            //    }
            //    po.IsCOAAccount = this.podto.IsCOAAccount;
            //    po.Budget = this.view.BudgetYear;
            //    po.CreatedUserId = CurrentUserEntity.CurrentUserID;
            //    CXClientWrapper.Instance.Invoke<ITCMSVE00002>(x => x.Save(po));
            //    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
            //    {
            //        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
            //        return;
            //    }
            //    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI30042);

            //    this.ClearControls();

            //    this.view.POFocus();
            //}
            //catch (Exception ex)
            //{ }
                this.CommomtoSave();
                #region ErrorOccurred
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    string[] logItemForTlf = new string[35];
                    //ClientLog For Tlf
                    logItemForTlf[0] = string.Empty;//GroupNo
                    logItemForTlf[1] = PO_Info.VoucherNo;//EntryNo
                    logItemForTlf[2] = PO_Info.ACode;//AcctNo
                    logItemForTlf[3] = PO_Info.ACode;//ACode(from COASetUp)
                    logItemForTlf[4] = PO_Info.Amount.ToString();//LocalAmount
                    logItemForTlf[5] = PO_Info.Currency;//SourceCur
                    logItemForTlf[6] = string.Empty;//Cheque
                    logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                    logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), PO_Info.SourceBranchCode).ToString();//SettlementDate
                    logItemForTlf[9] = string.Empty;//Status
                    logItemForTlf[10] = PO_Info.SourceBranchCode;//SourceBr
                    logItemForTlf[11] = string.Empty;//Rno
                    logItemForTlf[12] = string.Empty;//Duration
                    logItemForTlf[13] = string.Empty;//LasintDate
                    logItemForTlf[14] = string.Empty;//intRate
                    logItemForTlf[15] = string.Empty;//Accured
                    logItemForTlf[16] = string.Empty;//BudenAcc
                    logItemForTlf[17] = string.Empty;//Draccured
                    logItemForTlf[18] = string.Empty;//AccuredStatus
                    logItemForTlf[19] = PO_Info.ToAccountNo;//ToAccountNo
                    logItemForTlf[20] = string.Empty;//FirstRno
                    logItemForTlf[21] = PO_Info.PONo;//PoNo
                    logItemForTlf[22] = string.Empty;//ADate
                    logItemForTlf[23] = string.Empty;//IDate
                    logItemForTlf[24] = string.Empty;//ToAcctNo
                    logItemForTlf[25] = PO_Info.Charges.ToString();//Income
                    logItemForTlf[26] = PO_Info.Budget;//Budget
                    logItemForTlf[27] = string.Empty;//FromBranch
                    logItemForTlf[28] = string.Empty;//ToBranch
                    logItemForTlf[29] = string.Empty;//Inout
                    logItemForTlf[30] = string.Empty;//Success
                    logItemForTlf[31] = string.Empty;//COMMUCHARGE
                    logItemForTlf[32] = string.Empty;//IncomeType
                    logItemForTlf[33] = string.Empty;//OtherBank
                    logItemForTlf[34] = string.Empty;//OtherBankChq
                    TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "PO Refund(ByTransfer) Fail Transaction", CurrentUserEntity.BranchCode,
                    logItemForTlf);
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    return;
                }
                #endregion

                #region Successful
                else
                {
                    string[] logItemForTlf = new string[35];
                    //ClientLog For Tlf
                    logItemForTlf[0] = string.Empty;//GroupNo
                    logItemForTlf[1] = PO_Info.VoucherNo;//EntryNo
                    logItemForTlf[2] = PO_Info.ACode;//AcctNo
                    logItemForTlf[3] = PO_Info.ACode;//ACode(from COASetUp)
                    logItemForTlf[4] = PO_Info.Amount.ToString();//LocalAmount
                    logItemForTlf[5] = PO_Info.Currency;//SourceCur
                    logItemForTlf[6] = string.Empty;//Cheque
                    logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                    logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), PO_Info.SourceBranchCode).ToString();//SettlementDate
                    logItemForTlf[9] = string.Empty;//Status
                    logItemForTlf[10] = PO_Info.SourceBranchCode;//SourceBr
                    logItemForTlf[11] = string.Empty;//Rno
                    logItemForTlf[12] = string.Empty;//Duration
                    logItemForTlf[13] = string.Empty;//LasintDate
                    logItemForTlf[14] = string.Empty;//intRate
                    logItemForTlf[15] = string.Empty;//Accured
                    logItemForTlf[16] = string.Empty;//BudenAcc
                    logItemForTlf[17] = string.Empty;//Draccured
                    logItemForTlf[18] = string.Empty;//AccuredStatus
                    logItemForTlf[19] = PO_Info.ToAccountNo;//ToAccountNo
                    logItemForTlf[20] = string.Empty;//FirstRno
                    logItemForTlf[21] = PO_Info.PONo;//PoNo
                    logItemForTlf[22] = string.Empty;//ADate
                    logItemForTlf[23] = string.Empty;//IDate
                    logItemForTlf[24] = string.Empty;//ToAcctNo
                    logItemForTlf[25] = PO_Info.Charges.ToString();//Income
                    logItemForTlf[26] = PO_Info.Budget;//Budget
                    logItemForTlf[27] = string.Empty;//FromBranch
                    logItemForTlf[28] = string.Empty;//ToBranch
                    logItemForTlf[29] = string.Empty;//Inout
                    logItemForTlf[30] = string.Empty;//Success
                    logItemForTlf[31] = string.Empty;//COMMUCHARGE
                    logItemForTlf[32] = string.Empty;//IncomeType
                    logItemForTlf[33] = string.Empty;//OtherBank
                    logItemForTlf[34] = string.Empty;//OtherBankChq
                    TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "PO Refund(ByTransfer) Commit Transaction", CurrentUserEntity.BranchCode,
                    logItemForTlf);
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI30042);
                }
                #endregion
                this.ClearControls();

                this.view.POFocus();

        }

        public void Printing()
        {
            if (this.customers[0].AccountSign.StartsWith("S"))
            {
                this.CommomtoSave();
                IList<PFMDTO00043> printinglist = this.PrintTransaction();
                if (printinglist != null || printinglist.Count > 0)
                {
                    CXClientWrapper.Instance.Invoke<ITCMSVE00002, bool>(x => x.UpdateAndDeleteByAccountNo(this.view.AccountNo, printinglist, printinglist.Count, CurrentUserEntity.CurrentUserID));
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        return;
                    }

                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI30042);
                    this.ClearControls();

                    this.view.POFocus();
                }
                else
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME00012);

                }

            }

        }      

        #endregion
    }
}
