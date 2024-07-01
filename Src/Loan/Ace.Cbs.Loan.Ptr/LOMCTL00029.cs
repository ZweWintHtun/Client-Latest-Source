using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.Admin.DataModel;
using System.Linq;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00029 : AbstractPresenter, ILOMCTL00029
    {

        #region Properties
        decimal d1, d2;
        private IList<PFMDTO00001> customerInformation;
        public IList<PFMDTO00001> CustomerInformation
        {
            get
            {
                if (this.customerInformation == null)
                    this.customerInformation = new List<PFMDTO00001>();
                return customerInformation;
            }
            set
            { this.customerInformation = value; }
        }
        private ILOMVEW00029 view;
        public ILOMVEW00029 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        private void WireTo(ILOMVEW00029 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.View.TransferEntity);
            }
        }
        int printedLine;

        #endregion

        #region UI Logic Method

        public void ClearControls(bool isGird)
        {
            if (isGird)
            {
                this.View.DisableControlsforView("Currency.Enable");
                this.View.VoucherNo = string.Empty;
                //this.view.Currency = string.Empty;
                this.View.DenoCollection.Clear();
                this.View.BranchCode = string.Empty;
                this.View.IsDebitTransaction = true;
                this.view.BindData();
                this.View.SetCursor("Currency");

            }
            this.view.AccountNo = string.Empty;
            this.view.Description = string.Empty;
            this.view.Narration = string.Empty;
            this.View.ChequeNo = string.Empty;
            this.view.Amount = 0;
            this.view.PrintTransactions = false;
            this.View.Status = "Add";
            this.ClearErrors();
        }

        public void cboCurrency_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError || string.IsNullOrEmpty(this.View.Currency))
                return;
            else
                this.View.DisableControlsforView("Currency.Disable");
        }

        public void txtChequeNo_Validating(object sender, ValidationEventArgs e)
        {
            try
            {
                if (e.HasXmlBaseError)
                    return;
                else
                {
                    if (view.ChequeNo != "")
                        this.view.ChequeNo = CXCLE00007.GetFormatString(Convert.ToInt32(this.view.ChequeNo), CXCOM00009.ChequeNoDisplayFormat);
                    else
                        return;
                }

                string branch = this.view.AccountNo.Substring(0, 3).Trim();
                bool result = CXClientWrapper.Instance.Invoke<ITLMSVE00014, bool>(x => x.CheckingChequeNo(this.view.AccountNo, this.view.ChequeNo, branch));
                {
                    if (result == false)
                    {
                        this.SetCustomErrorMessage(this.GetControl("txtChequeNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }
            }
            catch (Exception ex)
            {
                this.SetCustomErrorMessage(this.GetControl("txtChequeNo"), ex.Message);
            }
        }

        public void txtAmount_CustomValidating(object sender, ValidationEventArgs e)
        {
            try
            {
                if (e.HasXmlBaseError)
                    return;
                if (this.view.Amount.ToString().StartsWith(decimal.Zero.ToString()) || this.view.Amount <= 0)
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00037);
                }

            }
            catch (Exception ex)
            {
                this.SetCustomErrorMessage(this.GetControl("txtAmount"), ex.Message);
            }
        }

        public void mtxtAccountNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            try
            {
                //if (e.HasXmlBaseError || !this.View.TransferEntity.IsCheckCustomAccountValidation)
                if (e.HasXmlBaseError)
                    return;
                if (this.View.DenoCollection.Count > 0)
                {
                    foreach (TLMDTO00038 info in this.View.DenoCollection)
                        if (info.AccountNo == this.View.AccountNo && this.View.Status == "Add")
                        {
                            this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV90001); // Data Already Exits.
                            return;
                        }
                }
                CustomerInformation.Clear();
                Nullable<CXDMD00011> accountType;
                if (CXCLE00012.Instance.IsValidAccountNo(this.view.AccountNo, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2))
                {
                    CustomerInformation = CXClientWrapper.Instance.Invoke<ILOMSVE00029, IList<PFMDTO00001>>(x => x.SelectByAccountNumber(this.View.AccountNo));
                    this.View.AllowedPrinting = true;

                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                        return;
                    }
                    else
                    {
                        string branch = this.view.AccountNo.Substring(0, 3);
                        if (branch != CurrentUserEntity.BranchCode)
                        {
                            this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00091, new object[] { CurrentUserEntity.BranchCode });//Invalid Account No for Branch {0}.
                            return;
                        }
                    }
                }
                else if (accountType == CXDMD00011.DomesticAccountType)
                {
                    ChargeOfAccountDTO COAinfo = CXCLE00002.Instance.GetClientData<ChargeOfAccountDTO>("COA.Client.SelectAccountName", new object[] { this.View.AccountNo, this.View.LocalBranchCode, true });
                
                    if (COAinfo == null)
                    {
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00046);
                        return;
                    }
                    this.View.AllowedPrinting = false;
                    this.View.PrintTransactions = false;
                    this.View.IsDomesticAccount = true;
                    PFMDTO00001 CustomerInfo = new PFMDTO00001();
                    CustomerInfo.Name = COAinfo.AccountName;
                    CustomerInfo.AccountSign = string.Empty;
                    CustomerInfo.SourceBranch = this.View.LocalBranchCode;
                    CustomerInfo.CurrencyCode = this.View.Currency;
                    this.CustomerInformation.Add(CustomerInfo);
                    this.View.BranchCode = CustomerInfo.SourceBranch;
                }
                else
                {
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00046);
                    return;
                }
                if (CustomerInformation != null || customerInformation.Count > 0)
                {
                    this.View.Description = CustomerInformation[0].Name;
                    this.view.IsCurrentAccount = string.IsNullOrEmpty(CustomerInformation[0].AccountSign) ? false : (CustomerInformation[0].AccountSign.Substring(0, 1).Equals("C") ? true : false);
                    this.View.AccountSign = CustomerInformation[0].AccountSign;
                    this.View.BranchCode = CustomerInformation[0].SourceBranch;
                    this.View.CurrentBal = CustomerInformation[0].CurrentBal;
                    this.View.TransactionCount = CustomerInformation[0].TransactionCount;
                    this.View.PrintLineNo = Convert.ToInt32(CustomerInformation[0].PrintLineNo);
                    if (CustomerInformation[0].CurrencyCode != this.View.Currency)
                    {
                        // Invalid Currency
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00086, new object[] { this.View.Currency });
                        return;
                    }
                    if (accountType != CXDMD00011.DomesticAccountType)
                    {
                        if (CustomerInformation[0].AccountSign.Substring(0, 1) == CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurrentAccountSign))
                        {
                            this.view.IsCurrentAccount = true;
                            this.view.DisableEnableControl(true);
                            this.view.IsDomesticAccount = false;
                            //this.SetFocus("txtChequeNo");
                        }
                        else
                        {
                            this.view.IsCurrentAccount = false;
                            this.view.DisableEnableControl(false);
                            this.view.IsDomesticAccount = false;
                        }
                    }
                    else
                    { 
                            this.view.IsCurrentAccount = false;
                            this.view.DisableEnableControl(false);
                            //this.SetFocus("rdoDebit");   
                    }
                }
                else
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00046);
            }
            catch (Exception ex)
            {
                this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), ex.Message);
            }
        }

        public bool ValidateAdd()
        {
            return this.ValidateForm(this.View.TransferEntity);
        }

        public void gvTransferInformation_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (this.view.DenoCollection.Count < 1 && this.View.TransferEntity.IsCheckGridview)
            {
                // Do Data to transfer.
                this.SetCustomErrorMessage(this.GetControl("gvTransferInformation"), CXMessage.MV00046);
            }
        }

        public void Printing()
        {
            try
            {
                IList<PFMDTO00043> PintFileList = new List<PFMDTO00043>();
                List<string[]> printingList;

                var list = from x in this.view.DenoCollection where x.IsPrintTransaction == true select x.AccountNo;

                if (list.Count<string>() == 0)
                    return;

                PintFileList = CXCLE00006.Instance.SelectAllPrintingDataForCSAccounts(list.ToArray<string>());

                foreach (TLMDTO00038 info in this.View.DenoCollection)
                {
                    var query = from z in PintFileList where z.AccountNo == info.AccountNo orderby z.CreatedDate select z;
                    printingList = new List<string[]>();

                    for (int i = 0; i < query.Count<PFMDTO00043>(); i++)
                    {
                        PFMDTO00043 prnFile = query.ElementAt(i);
                        string dateTime = CXCOM00006.Instance.GetDateFormat(prnFile.DATE_TIME.Value).ToString();
                        string[] prnFileStrArr = { dateTime, prnFile.Reference, prnFile.Credit.ToString(), prnFile.Debit.ToString(), prnFile.Balance.ToString(), prnFile.Id.ToString() };

                        printingList.Add(prnFileStrArr);
                    }
                    if (query.Count<PFMDTO00043>() > 0)
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00017, new object[] { info.AccountNo });

                        CXCLE00005.Instance.StartLineNo = (int)query.ToList<PFMDTO00043>()[0].PrintLineNo == 0 ? 1 : (int)query.ToList<PFMDTO00043>()[0].PrintLineNo;
                        printedLine = CXCLE00005.Instance.StartLineNo;

                        CXCLE00005.Instance.PrintingList("PassBookCode", "LineByLine", "PassBookPrinting", printingList, false, true, out printedLine);


                        if (!CXCLE00006.Instance.UpdateAfterPrintingForCS(info.AccountNo, printedLine, CurrentUserEntity.CurrentUserID))
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME90043);
                    }

                }
            }
            catch (Exception ex)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME00061);
            }
        }
        #endregion

        #region Method

        public bool CheckAmount(IList<TLMDTO00038> transferCollection)
        {
            d1 = 0;
            d2 = 0;

            foreach (TLMDTO00038 transfer in transferCollection)
            {
                if (transfer.IsCredit)
                    d1 += transfer.Amount;
                else
                    d2 += transfer.Amount;
            }

            return d1 == d2 ? true : false;
        }

        public bool Save()
        {
            if (this.View.Status != "Add")
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00170);
                return false;
            }
            else if (this.View.DenoCollection.Count != 0 || this.ValidateForm(this.View.TransferEntity))
            {
                    string VoucherNo = string.Empty;

                    this.View.DenoCollection = this.GetDepositInfoToSave(this.View.DenoCollection);

                    if (this.View.TransferEntity.HomeExchangeRate == 0)
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00013);
                        this.View.TransferEntity.HomeExchangeRate = 1;
                        return false;
                    }

                    VoucherNo = CXClientWrapper.Instance.Invoke<ILOMSVE00029, string>(x => x.SaveSpecialTransfer(this.View.DenoCollection));

                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        return false;
                    }
                    else
                    {
                        this.View.VoucherNo = VoucherNo;
                        this.View.Successful(CXMessage.MI00051, "Voucher No", VoucherNo);
                        return true;
                    }
                }
            return false;
        }

        public bool checkAccount()
        {
            if(this.view.IsDebitTransaction)
            {
                if (this.view.IsCurrentAccount)
                {
                    if (CustomerInformation[0].OverdraftLimit != decimal.Zero || (customerInformation[0].LoansCount > 0 && CustomerInformation[0].OverdraftLimit == decimal.Zero))
                    {
                        return true;                       
                    }
                    else
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90020);//There is no Loans Account
                        return false;
                    }
                }
                else
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90021);//Not Allow to Debit from Saving A/C , Call Deposit A/C " & Chr(10) & "and Chart of Account
                    return false;
                }
            }
            return true;
        }

        private IList<TLMDTO00038> GetDepositInfoToSave(IList<TLMDTO00038> transferCollection)
        {
            foreach (TLMDTO00038 transferEntity in transferCollection)
            {
                transferEntity.CreatedDate = System.DateTime.Now;
                transferEntity.UpdatedDate = System.DateTime.Now;
                transferEntity.UpdatedUserId = transferEntity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                transferEntity.FromBranchCode = this.View.LocalBranchCode;
                transferEntity.Channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
            }
            return transferCollection;
        }

        #endregion
    }
}
