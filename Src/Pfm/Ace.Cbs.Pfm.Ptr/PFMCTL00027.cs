using System;
using System.Windows.Forms;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.PTR;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Pfm.Ptr
{
    public class PFMCTL00027 : AbstractPresenter, IPFMCTL00027
    {
        #region Form Initializer
        
        private IPFMVEW00027 freceiptview;
        public IPFMVEW00027 FReceiptView
        {
            get
            {
                return this.freceiptview;
            }
            set
            {

                this.WireTo(value);
            }
        }
        
        private void WireTo(IPFMVEW00027 view)
        {
            if (this.freceiptview == null)
            {
                this.freceiptview = view;

                this.Initialize(this.freceiptview, this.FReceiptView.FReceiptEntity);
            }
        }

        #endregion

        #region Other Method

        public bool ValidateFormForAccountOpening(PFMDTO00032 freceiptentity)
        {
            return this.ValidateForm(freceiptentity);
        }

        public bool Save(PFMDTO00032 freceiptentity)
        {
            if (this.ValidateFormForAccountOpening(freceiptentity))
            {
                PFMDTO00032 returnValue = new PFMDTO00032();
                freceiptentity.SourceBranchCode = CurrentUserEntity.BranchCode;
                freceiptentity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                freceiptentity.RDate = DateTime.Now;
                freceiptentity.UserNo = CurrentUserEntity.CurrentUserID.ToString();

                if (freceiptentity.AccountNo != null && freceiptentity.AccountNo != string.Empty)
                {
                    returnValue=CXClientWrapper.Instance.Invoke<IPFMSVE00027,PFMDTO00032>(x => x.Save(freceiptentity, false));
                }
                else
                {
                    freceiptentity.ReceiptNo = this.GenerateReceiptNoByAccountNo(freceiptentity.Duration);
                    this.freceiptview.RebindReceiptNoTextBox(freceiptentity.ReceiptNo);
                    this.freceiptview.ShowInformationMessage(CXMessage.MI00004, new object[] { freceiptentity.ReceiptNo });
                    return true;
                }

                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                {
                    this.freceiptview.RebindReceiptNoTextBox(returnValue.ReceiptNo);
                    string r = returnValue.ReceiptNo;
                    this.FReceiptView.SuccessfulReceiptNo(CXMessage.MI00004, r);
                    //this.freceiptview.ShowInformationMessage(CXClientWrapper.Instance.ServiceResult.MessageCode,new object[] {freceiptentity.ReceiptNo});
                    return true;
                }
                else
                {
                    string message = CXClientWrapper.Instance.ServiceResult.MessageCode;
                    if (message == "MV00080") //Currency of Fixed Account and Interest Taken Account should be same.                    
                    {
                        this.freceiptview.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                    else 
                    {   
                        this.freceiptview.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                    return false;                    
                }
            }
            return false;
        }

        public void Update(int id, string rNo)
        {
            CXClientWrapper.Instance.Invoke<IPFMSVE00027>(x => x.Update(id, rNo));

            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                string s = CXClientWrapper.Instance.ServiceResult.MessageCode;
                this.freceiptview.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            else
            {
                this.freceiptview.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        private string GenerateReceiptNoByAccountNo(decimal duration)
        {
            string prefixCode = GetPrefixCode(duration);

            return prefixCode + (0 + 1).ToString().PadLeft(4, '0');
        }

        private string GetPrefixCode(decimal duration)
        {
            string prefixCode = string.Empty;

            if (duration < 1)
            {
                duration *= 4;
                prefixCode = Convert.ToInt32(duration).ToString() + 'W';
            }
            else if (duration >= 1 && duration < 12)
            {
                prefixCode = Convert.ToInt32(duration).ToString() + 'M';
            }
            else if (duration >= 12)
            {
                duration = duration / 12;
                prefixCode = Convert.ToInt32(duration).ToString() + 'Y';
            }

            return prefixCode;
        }

        public void ClearErrorMessage()
        {
            this.ClearAllCustomErrorMessage();
        }

        #endregion

        #region Validating Methods

        public void mtxtAccountNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (this.FReceiptView.IsMainMenu == false)
            {
                return;
            }

            // if xml base error does not exist.
            if (e.HasXmlBaseError == false)
            {
                //string accountNumber = this.FReceiptView.AccountNo.Replace("-", "").Trim();
              
                // Validate account code by account code format(Regular Expression...)
                // And validate checkdigit of account code by account checkdigit formula
                if (CXCOM00006.Instance.Validate(this.FReceiptView.AccountNo, CXCOM00009.AccountNoCodeFormat, CXCOM00009.AccountNoCheckDigitFormula))
                {
                    // Set Empty to control.
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), string.Empty);
                }
                else
                {
                    // Set Error Message to Control.
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00033);
                }
            }
        }

        public void mtxtInterestTakenAccount_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (this.FReceiptView.AutoRenewal == false)
            {
                return;
            }
            // if xml base error does not exist.
            if (e.HasXmlBaseError == false)
            {
                if (this.freceiptview.TakenAccount != string.Empty)
                {
                    //string accountNumber = this.FReceiptView.TakenAccount.Replace("-", "");
                    // Validate account code by account code format(Regular Expression...)
                    // And validate checkdigit of account code by account checkdigit formula
                    //Nullable<CXDMD00011> accountType;
                    //if (CXCLE00012.Instance.IsValidAccountNo(this.FReceiptView.TakenAccount, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2))       
                    #region Old data
                    //PFMDTO00028 CledgerDTO = CXClientWrapper.Instance.Invoke<ICXSVE00006, PFMDTO00028>(x => x.GetAccountInfoOfCledgerByAccountNo(this.freceiptview.TakenAccount));
                    //if (CledgerDTO != null)
                    //{
                    //    //// Set Empty to control.
                    //    //if (CledgerDTO.CloseDate != null) // To check closed account (by hmw)
                    //    //{
                    //    //    this.SetCustomErrorMessage(this.GetControl("mtxtInterestTakenAccount"), CXMessage.MV00201, new object[] { CledgerDTO.AccountNo }); //Account No {0} has been closed.
                    //    //}
                    //    //else
                    //    //{
                    //    //    this.SetCustomErrorMessage(this.GetControl("mtxtInterestTakenAccount"), string.Empty);
                    //    //}                        
                    //}
                    //else
                    //{
                    //    // Set Error Message to Control.
                    //    this.SetCustomErrorMessage(this.GetControl("mtxtInterestTakenAccount"), CXMessage.MV00036); //Invalid Interest Taken Account No
                    //}

                    #endregion
                    Nullable<CXDMD00011> accountType;
                    if (CXCLE00012.Instance.IsValidAccountNo(this.FReceiptView.TakenAccount, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2))
                    {
                        PFMDTO00028 CledgerDTO = CXClientWrapper.Instance.Invoke<ICXSVE00006, PFMDTO00028>(x => x.GetAccountInfoOfCledgerByAccountNo(this.freceiptview.TakenAccount));
                        if (CledgerDTO != null)
                        {
                            // Set Empty to control.
                            if (CledgerDTO.CloseDate != null) // To check closed account (by hmw)
                            {
                                this.SetCustomErrorMessage(this.GetControl("mtxtInterestTakenAccount"), CXMessage.MV00201, new object[] { CledgerDTO.AccountNo }); //Account No {0} has been closed.
                            }
                            else
                            {
                                this.SetCustomErrorMessage(this.GetControl("mtxtInterestTakenAccount"), string.Empty);
                            }

                        }
                        else if (freceiptview.TakenAccount.Substring(4, 1) == "3")
                        {
                            //MessageBox.Show("Interest Taken Account should not be fixed account.");
                            this.SetCustomErrorMessage(this.GetControl("mtxtInterestTakenAccount"), CXMessage.MV90104);
                            return;
                        }
                    }
                    
                    else if (accountType == CXDMD00011.DomesticAccountType)
                    {
                        ChargeOfAccountDTO COAinfo = CXCLE00002.Instance.GetClientData<ChargeOfAccountDTO>("COA.Client.SelectAccountName", new object[] { this.freceiptview.TakenAccount, this.freceiptview.LocalBranchCode, true });
                        if (COAinfo == null)
                        {
                            this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00046);
                            return;
                        }
                        //else if (!this.freceiptview.LocationTransactions)
                        //{
                        //    // Invalid Branch Code
                        //    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00165, new object[] { "Local or Other Branch " });
                        //    return;
                        //}

                    }
                    //else//for DomesticAccountType
                    //{
                    //    CheckForDomestic(accountType);
                    //}
                }
                else
                {
                    this.SetCustomErrorMessage(this.GetControl("mtxtInterestTakenAccount"), string.Empty);
                }
            }
        }
        //public bool CheckForDomestic(Nullable<> DomesticAccount)
        //{
        //    if ( DomesticAccount == CXDMD00011.DomesticAccountType)//for DomesticAccountType
        //        {
        //           string coaSetupName = CXCLE00002.Instance.GetScalarObject<string>("COASetup.Client.SelectByAccountNo", new object[] { this.freceiptview.TakenAccount, freceiptview., CXCOM00007.Instance.BranchCode, true });
        //        }

        //}
        public void ntxtAmount_CustomValidating(object sender, ValidationEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("/////////////////////////////////////////   " + this.FReceiptView.FReceiptEntity.Amount);

            if (e.HasXmlBaseError)
            {
                return;
            }

            decimal minimunAmount,FixedDividedAmount;

            string temp = CXCOM00007.Instance.GetValueByVariable("FATRANAMT");

            if (temp == string.Empty)
            {
                minimunAmount = 0;
            }
            else
            {
                minimunAmount = Convert.ToDecimal(temp);
            }

            temp = CXCOM00007.Instance.GetValueByVariable("FADIVIDER");

            if (temp == string.Empty)
            {
                FixedDividedAmount = 0;
            }
            else
            {
                FixedDividedAmount = Convert.ToDecimal(temp);
            }

            if (minimunAmount > FReceiptView.Amount)
            {
                this.SetCustomErrorMessage(this.GetControl("ntxtAmount"), CXMessage.MV00038);
            }

            else if (FReceiptView.Amount < FixedDividedAmount )
            {
                this.SetCustomErrorMessage(this.GetControl("ntxtAmount"), CXMessage.MV00038);
            }
            else
            {
                this.SetCustomErrorMessage(this.GetControl("ntxtAmount"), string.Empty);
            }
        }


        #endregion
    }
}