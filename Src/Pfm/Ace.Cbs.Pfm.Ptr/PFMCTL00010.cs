using System;
using System.Collections.Generic;
using System.Linq;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.PTR;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;

namespace Ace.Cbs.Pfm.Ptr
{
    /// <summary>
    /// Saving Account Close Controller
    /// </summary>
    public class PFMCTL00010 : AbstractPresenter, IPFMCTL00010
    {
        #region Private Variables
        private IPFMVEW00010 view;
        private bool isSaveValidate = false;
        private string interestType = string.Empty;
        private decimal exchangeRate = 0;
        #endregion

        #region Properties
        public IPFMVEW00010 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        #endregion

        #region UI Logic
        private void WireTo(IPFMVEW00010 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, new PFMDTO00072());
            }
        }

        public void mtxtAccountNo_Validating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError || this.isSaveValidate)
            {
                return;
            }

            // AccountNo Checking (Code Format and CheckDigit)
            if (CXCOM00006.Instance.Validate(this.view.AccountNo, CXCOM00009.AccountNoCodeFormat, CXCOM00009.AccountNoCheckDigitFormula))
            {
                if (CXCOM00006.Instance.isSavingAccount(this.view.AccountNo, CXCOM00009.AccountTypePosition) == false)
                {
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00051);
                    return;
                }

                // Clear Saving Account No Error.
                this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), string.Empty);

                // Get Saving Account Information
                IList<PFMDTO00072> savingAccount = CXClientWrapper.Instance.Invoke<IPFMSVE00010, IList<PFMDTO00072>>(x => x.GetSavingAccountInfo(this.view.AccountNo,this.view.BranchCode));

                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    if (CXClientWrapper.Instance.ServiceResult.MessageCode == "MV00091")
                    {
                        //this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode, new object[] { CurrentUserEntity.BranchCode });
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode, new object[] { this.view.BranchCode });
                    }
                    else
                    {
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode, new object[] { this.view.AccountNo });
                    }               
                   
                    return;
                }

                if (savingAccount.Count == 0)
                {
                    // Invalid Saving Account No.
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00051);
                    //this.ClearControls();
                    return;
                }

                this.view.CurrencyCode = savingAccount[0].CurrencyCode;
                this.view.AccountSignature = savingAccount[0].AccountSignature;
                this.View.Customers = savingAccount.ToDictionary(x => x.CustomerId, y => y.CustomerName);
                this.view.Balance = savingAccount[0].CurrentBalance; 
                this.View.BindCustomer();

                // Get Saving Month
                int savingMonth = Convert.ToInt32(CXCOM00007.Instance.GetValueByVariable(CXCOM00009.SavingMonth));
                this.view.OpenDate = savingAccount[0].OpenDate;

                // Check Account OpenDate + SavingMonth(6) is greater than now
                if (savingAccount[0].OpenDate.AddMonths(savingMonth) > DateTime.Now)
                {
                    this.interestType = "debit";
                    this.view.DebitCreditStatus = "Debit Interest Amount";

                    // Calculate Debit Interest
                    //this.view.BeforeTax = this.GetBeforeTaxForDebit();
                    this.view.BeforeTax = 0;//assigned 0 because of logic of VB Core Banking
                }
                else
                {
                    this.interestType = "credit";
                    this.view.DebitCreditStatus = "Credit Interest Amount";

                    // Get Before Tax By Start Month and End Month?
                    this.view.BeforeTax = this.GetBeforeTaxForCredit();
                }

                //Get Charges
                if (this.interestType == "debit")
                {
                    this.view.Charges = CXCLE00002.Instance.GetScalarObject<decimal>("Setup.SavingAccountClose.Select", new object[] { this.view.CurrencyCode, this.view.BranchCode, true });
                }
                else
                    this.view.Charges = 0;

                // Get Tax Rate
                decimal taxRate = CXCLE00002.Instance.GetScalarObject<decimal>("RateFile.AccountClose.Select", new object[] { "TAXRATE", true });

                // Get Tax
                this.view.Tax = (this.view.BeforeTax * taxRate) / 100;

                // Get After Tax
                this.view.AfterTax = this.view.BeforeTax - this.view.Tax;

                decimal netInterest = 0;

                // Get Net Interest
                if (this.interestType == "credit")
                {
                    netInterest = this.view.AfterTax - this.view.Charges;
                    this.view.TotalInterest = netInterest;
                    this.view.NewBalance = this.view.Balance + netInterest;
                }
                else
                {
                    this.view.TotalInterest = 0;
                    this.view.NewBalance = this.view.Balance - this.view.Charges;
                }

                // Check Insufficient amount
                if (this.interestType == "debit" && this.view.Balance < this.view.Charges)
                {                                    
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00052);                    
                }
            }
            else
            {
                // Invalid Saving Account No.
                this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00051);
              //  this.ClearControls();      This is commented not to be clear in AccountNo textbox         
            }
        }
      

        public void SaveSavingAccountClose()
        {
            if (this.ValidateForm())
            {
                this.exchangeRate = CXCOM00010.Instance.GetExchangeRate(this.view.CurrencyCode, "TT");
                if (this.exchangeRate == 0)
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00013);
                    this.exchangeRate = 1;
                }

                if (Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC00001) == System.Windows.Forms.DialogResult.No)
                {
                    //this.ClearControls();
                    return;
                }

                PFMDTO00072 accountClose = this.GetAccountClose();

                //this.isSaveValidate = true;
                if (this.ValidateForm(accountClose))
                {
                    CXClientWrapper.Instance.Invoke<IPFMSVE00010>(x => x.SaveSavingAccountClose(accountClose));

                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        if (CXClientWrapper.Instance.ServiceResult.MessageCode == "MV00091")
                        {
                            //this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode, new object[] { CurrentUserEntity.BranchCode });
                            this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode, new object[] { this.view.BranchCode });
                        }
                        else
                        {
                            this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode, new object[] { this.view.AccountNo });
                        }
                    }
                    else
                    {
                        // Account  No ({0}) has been successfully closed.
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00006, new object[] { CXCLE00007.GetFormatStringBy999(accountClose.AccountNo, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat)) });
                        this.ClearControls();
                        this.SetFocus("mtxtAccountNo");
                    }
                }

                this.isSaveValidate = false;
            }
        }

        public void ClearControls()
        {
            this.view.AccountNo = string.Empty;
            this.view.AccountSignature = string.Empty;
            //this.view.CurrencyCode = string.Empty;
            this.view.OpenDate = DateTime.MinValue;
            this.view.CloseDate = DateTime.Now;
            this.view.Balance = 0;
            this.view.Charges = 0;
            this.view.Customers = new Dictionary<string, string>();
            this.view.BindCustomer();
            this.view.BeforeTax = 0;
            this.view.Tax = 0;
            this.view.AfterTax = 0;
            this.view.TotalInterest = 0;
            this.view.NewBalance = 0;
            this.ClearAllCustomErrorMessage();
        }

        public string GetBranchCode()
        {
            return CXCOM00007.Instance.BranchCode;
        }
        #endregion

        #region Helper Methods
        private decimal GetBeforeTaxForCredit()
        {
            // Get Debit Before Tax By Start Month and End Month
            string accountNo = this.view.AccountNo;
            object creditInterest = CXClientWrapper.Instance.Invoke<IPFMSVE00010, object>(x => x.GetBeforeTaxForCredit(accountNo));
            return Convert.ToDecimal(creditInterest);
        }

        private decimal GetBeforeTaxForDebit()
        {
            // Get Charges for Debit Calculation            
            this.view.Charges=CXCLE00002.Instance.GetScalarObject<decimal>("Setup.SavingAccountClose.Select", new object[] {this.view.CurrencyCode,this.view.BranchCode, true });

            // Get Debit Before Tax By Start Month and End Month
            object debitInterest = CXClientWrapper.Instance.Invoke<IPFMSVE00010, object>(x => x.GetBeforeTaxForDebit(this.view.AccountNo, this.view.OpenDate));
            return Convert.ToDecimal(debitInterest);
        }       
        
        private PFMDTO00072 GetAccountClose()
        {
            PFMDTO00072 accountClose = new PFMDTO00072();

            accountClose.InterestType = this.interestType;
            accountClose.AccountNo = this.view.AccountNo;
            accountClose.AccountSignature = this.view.AccountSignature;
            accountClose.CurrencyCode = this.view.CurrencyCode;
            accountClose.CloseDate = DateTime.Now;
            accountClose.CustomerName = (this.view.Customers.Count!=0?this.view.Customers.First().Value:null);
            accountClose.CustomerIds = this.view.Customers.Keys.ToArray<string>();
            accountClose.BranchCode = this.view.BranchCode;

            if(this.interestType == "debit")
            {
                accountClose.CurrentBalance = this.view.Balance - this.view.Charges;
                accountClose.CreditAmount1 = this.view.TotalInterest;
                accountClose.CreditAmount2 = 0;
                accountClose.DebitAccountNo1 = this.view.AccountNo;
                accountClose.DebitAmount1 = this.view.AfterTax;
                accountClose.DebitAccountNo2 = CXCOM00010.Instance.GetCOAAccountNo("SavingTax", accountClose.BranchCode, accountClose.CurrencyCode);
                accountClose.DebitAmount2 = this.view.Tax;
                
            }
            else
            {
                accountClose.CurrentBalance = this.view.Balance + this.view.TotalInterest;
                accountClose.CreditAccountNo1 = this.view.AccountNo;
                accountClose.CreditAmount1 = this.view.AfterTax;
                accountClose.CreditAccountNo2 = CXCOM00010.Instance.GetCOAAccountNo("SavingTax", accountClose.BranchCode, accountClose.CurrencyCode);
                accountClose.CreditDescription2 = CXCLE00001.Instance.GetCOAAccountNameByCoaSetupAccountNo(accountClose.CreditAccountNo2, accountClose.BranchCode);// add by hmw (to get description for tlf inserting)
                accountClose.CreditAmount2 = this.view.Tax;

                accountClose.DebitAccountNo1 = CXCOM00010.Instance.GetCOAAccountNo("SintDepo", accountClose.BranchCode, accountClose.CurrencyCode);
                accountClose.DebitDescription1 = CXCLE00001.Instance.GetCOAAccountNameByCoaSetupAccountNo(accountClose.DebitAccountNo1, accountClose.BranchCode);// add by hmw (to get description for tlf inserting)
                accountClose.DebitAmount1 = this.view.BeforeTax;
                accountClose.DebitAmount2 = 0;
            }

            accountClose.Charges = this.view.Charges;
            if (accountClose.Charges != 0)
            {
                accountClose.BankAccountNo = CXCOM00010.Instance.GetCOAAccountNo("INCOME", accountClose.BranchCode, accountClose.CurrencyCode);
                accountClose.BankAccountDescription = CXCLE00001.Instance.GetCOAAccountNameByCoaSetupAccountNo(accountClose.BankAccountNo, accountClose.BranchCode);// add by hmw (to get description for tlf inserting)
            }

            accountClose.TotalInterest = this.view.TotalInterest;
            accountClose.HomeExchangeRate = this.exchangeRate;

            accountClose.NextSettlementDate = CXCOM00010.Instance.GetNextSettlementDate("NEXT_SETTLEMENT_DATE", accountClose.BranchCode);

            accountClose.UpdatedUserId = CurrentUserEntity.CurrentUserID;
            accountClose.Active = true;

            return accountClose;
        }
        #endregion
    }
}