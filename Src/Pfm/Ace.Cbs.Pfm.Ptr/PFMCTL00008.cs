using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.PTR;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;

namespace Ace.Cbs.Pfm.Ptr
{
    public class PFMCTL00008 : AbstractPresenter, IPFMCTL00008
    {
        #region For Initializer
        private IPFMVEW00008 printRecordView;
        public IPFMVEW00008 PrintRecordView
        {
            get
            {
                return this.printRecordView;
            }
            set
            {
                this.WireTo(value);
            }
        }

        private void WireTo(IPFMVEW00008 view)
        {
            if (this.printRecordView == null)
            {
                this.printRecordView = view;
                this.Initialize(this.printRecordView, this.printRecordView.PrintRecordEntity);
            }
        } 
        #endregion

        #region Private Variables
        private IList<PFMDTO00001> _CustomerList { get; set; }
        private PFMDTO00016 currentAccount = null;

        private int maxAmountValueLength =Convert.ToInt32(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.MaxAmountValueLength));
        private int maxAmountDecimalLength = Convert.ToInt32(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.MaxAmountDecimalPlace));

        #endregion

        #region Public Methods

        public bool Save(PFMDTO00045 printRecordEntity)
        {
            printRecordEntity.CreatedUserId = CurrentUserEntity.CurrentUserID;

            printRecordEntity.UserNo = CurrentUserEntity.CurrentUserID.ToString();

            if (this.ValidateForm(printRecordEntity))
            {
                if (printRecordEntity.CAmt == 0 && printRecordEntity.DAmt == 0)
                {
                    this.printRecordView.ShowErrorMessage(CXMessage.MV00049, true);

                    return false;
                }

                currentAccount = CXClientWrapper.Instance.Invoke<IPFMSVE00008, PFMDTO00016>(x => x.Save(printRecordEntity));

                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == true)
                {
                    this.printRecordView.ShowErrorMessage(CXClientWrapper.Instance.ServiceResult.MessageCode, false);

                    return false;
                }

                this.printRecordView.AccountSign = currentAccount.AccountSign;
                this.printRecordView.PrnFileDTO.CurrencyCode = currentAccount.CurrencyCode;
                return true;
            }
            else
            {
                return false;
            } 
        } 

        #endregion

        #region Validation Logic
     
        public void mtxtAccountNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if xml base error does not exist.
            if (e.HasXmlBaseError == false)
            {
                string accountNumber = this.printRecordView.PrintRecordEntity.AcctNo;

                // Validate account code by account code format(Regular Expression...)
                // And validate checkdigit of account code by account checkdigit formula
                if (CXCOM00006.Instance.Validate(accountNumber, CXCOM00009.AccountNoCodeFormat, CXCOM00009.AccountNoCheckDigitFormula))
                {
                    #region oldCode
                    //currentAccount = CXClientWrapper.Instance.Invoke<IPFMSVE00008, PFMDTO00016>(x => x.SelectByAccountNumber(accountNumber));

                    //if (currentAccount != null)
                    //{
                    //    // Set Empty to control.
                    //    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), string.Empty);
                    //}
                    //else
                    //{
                    //    // Set Error Message to Control.
                    //    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00046);
                    //}
                    #endregion
                    //check for account Type saving or current
                    _CustomerList = CXClientWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00001>>(x => x.GetCustomerInfomationByCaofOrSaof(accountNumber, "S"));
                    if (_CustomerList.Count == 0 || _CustomerList == null)
                    {
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00051); //Invalid Saving Account No.
                    }
                }
                else
                {
                    // Set Error Message to Control.
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00046);
                }
            }
        }
     
        public void mtxtBalance_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError == false)
            {
                //if (CXCLE00007.CheckAmountFormat(maxAmountValueLength, maxAmountDecimalLength, this.printRecordView.Balance))
                //{
                    if (this.printRecordView.CAmt != 0)
                    {
                        if (this.printRecordView.Balance == 0)
                        {
                            // Set Error Message to Control.
                            this.SetCustomErrorMessage(this.GetControl("mtxtBalance"), CXMessage.MV00050);
                        }
                        else if (this.printRecordView.CAmt > this.printRecordView.Balance)
                        {
                            // Set Error Message to Control.
                            this.SetCustomErrorMessage(this.GetControl("mtxtBalance"), CXMessage.MV00047);
                        }
                        else
                        {
                            // Set Error Message to Control.
                            this.SetCustomErrorMessage(this.GetControl("mtxtBalance"), string.Empty);
                        }
                    }
                    else
                    {
                        // Set Error Message to Control.
                        this.SetCustomErrorMessage(this.GetControl("mtxtBalance"), string.Empty);
                    }
                //}
                //else
                //{
                //    // Set Error Message to Control.
                //    this.SetCustomErrorMessage(this.GetControl("mtxtBalance"), CXMessage.MV00081, maxAmountValueLength, maxAmountDecimalLength);
                //}
            }
        }

        public override bool ValidateForm(object validationContext)
        {
            //return validateForm.
            return base.ValidateForm(validationContext);
        }

        //public void mtxtDeposit_CustomValidating(object sender, ValidationEventArgs e)
        //{
        //    if (e.HasXmlBaseError == false)
        //    {
        //        if (CXCLE00007.CheckAmountFormat(maxAmountValueLength, maxAmountDecimalLength, this.printRecordView.CAmt))
        //        {
        //            // Set Error Message to Control.
        //            this.SetCustomErrorMessage(this.GetControl("mtxtDeposit"), string.Empty);
        //        }
        //        else
        //        {
        //            // Set Error Message to Control.
        //            this.SetCustomErrorMessage(this.GetControl("mtxtDeposit"), CXMessage.MV00081,maxAmountValueLength,maxAmountDecimalLength);
        //        }
        //    }
        //}

        //public void mtxtWithdrawl_CustomValidating(object sender, ValidationEventArgs e)
        //{
        //    if (e.HasXmlBaseError == false)
        //    {
        //        if (CXCLE00007.CheckAmountFormat(maxAmountValueLength, maxAmountDecimalLength, this.printRecordView.DAmt))
        //        {
        //            // Set Error Message to Control.
        //            this.SetCustomErrorMessage(this.GetControl("mtxtWithdrawl"), string.Empty);
        //        }
        //        else
        //        {
        //            // Set Error Message to Control.
        //            this.SetCustomErrorMessage(this.GetControl("mtxtWithdrawl"), CXMessage.MV00081, maxAmountValueLength, maxAmountDecimalLength);
        //        }
        //    }
        //}

        #endregion
    }
}