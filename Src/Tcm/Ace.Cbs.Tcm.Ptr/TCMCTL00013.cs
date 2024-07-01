using System;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Tcm.Ctr.Sve;

namespace Ace.Cbs.Tcm.Ptr
{
    public class TCMCTL00013 : AbstractPresenter,ITCMCTL00013
    {
        private bool isValidatedFreceipt = false;
        #region Form Initializer

        private ITCMVEW00013 freceiptview;
        public ITCMVEW00013 FReceiptView
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

        private void WireTo(ITCMVEW00013 view)
        {
            if (this.freceiptview == null)
            {
                this.freceiptview = view;

                this.Initialize(this.freceiptview, this.FReceiptView.FReceiptEntity);
            }
        }

        public PFMDTO00032 tempDTO { get; set; }

        #endregion

        #region Validating Methods

        public void mtxtAccountNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if xml base error does not exist.
            if (e.HasXmlBaseError == true)
                return;
            //else if (!string.IsNullOrEmpty(this.FReceiptView.Status))//when save,validation not check
            //    return;
            try
            {
                Nullable<CXDMD00011> accountType;
                if (CXCLE00012.Instance.IsValidAccountNo(this.FReceiptView.AccountNo, out accountType) && (accountType != CXDMD00011.DomesticAccountType))
                {
                    this.FReceiptView.FReceiptList = CXClientWrapper.Instance.Invoke<ITCMSVE00013, PFMDTO00032>(x => x.SelectFReceiptByAccountNo(this.freceiptview.AccountNo, this.FReceiptView.SourceBranchCode));
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        if (CXClientWrapper.Instance.ServiceResult.MessageCode == "MV00091")
                            this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), "MV00091", new object[] { CurrentUserEntity.BranchCode });
                        else
                            this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                        
                }
            }
            catch(Exception ex)
            {
                // Set Error Message to Control.
                this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), ex.Message);
            }
        }

        public void mtxtReceiptNo_CustomeValidating(object sender, ValidationEventArgs e)
        { 
            // if xml base error does not exist.
            if (e.HasXmlBaseError == true)
                return;

            if (this.isValidatedFreceipt)
                return;
            if (String.IsNullOrEmpty(this.FReceiptView.ReceiptNo))
            {
                //Invalid Receipt No
                this.SetCustomErrorMessage(this.GetControl("mtxtReceiptNo"), CXMessage.MV00022);
                return;
            }  

            var temp = from x in this.FReceiptView.FReceiptList where x.ReceiptNo == this.FReceiptView.ReceiptNo select x;
            
            if (temp.Count<PFMDTO00032>() == 0)
            {
                //"Receipt No is not issued or it is already  withdrawal "
                this.SetCustomErrorMessage(this.GetControl("mtxtReceiptNo"), CXMessage.MV90052);
                return;
            }           
            else if (temp.ToList<PFMDTO00032>()[0].WithdrawDate.Value != default(DateTime))
            {
                //Receipt No is already withdrawal
                this.SetCustomErrorMessage(this.GetControl("mtxtReceiptNo"), CXMessage.MV00147, new object[] { this.FReceiptView.ReceiptNo });
                return;
            }
            else if (!string.IsNullOrEmpty(this.FReceiptView.Status))//when save,validation not check
            {
                return;
            }

             tempDTO = temp.ToList<PFMDTO00032>()[0];
             if (!(Convert.ToDateTime(temp.ToList<PFMDTO00032>()[0].LastInterestDate).ToShortDateString() == "01/01/0001"))
            {
                if (Convert.ToDateTime(temp.ToList<PFMDTO00032>()[0].LastInterestDate).ToShortDateString() != DateTime.Now.ToShortDateString() )
                {
                    //Not Allowed Back Date Transaction!
                    this.SetCustomErrorMessage(this.GetControl("mtxtReceiptNo"), CXMessage.ME30002, new object[] { this.FReceiptView.ReceiptNo });
                    return;
                }
                else
                {
                    //this receipt no is already deposit, so must be reverse
                   this.FReceiptView.IsReverse = true; 
                }
            }
           
            this.FReceiptView.EnableControlsForReceiptEditing("ReceiptNo.Enable");

            this.FReceiptView.Amount = tempDTO.Amount;
            this.FReceiptView.Rate = tempDTO.InterestRate;
            this.FReceiptView.TakenAccount = tempDTO.ToAccountNo;
            this.FReceiptView.IsFReceiptValidate = true;
            this.FReceiptView.Duration = tempDTO.Duration;
            this.FReceiptView.IsFReceiptValidate = false;
            this.FReceiptView.CurrencyCode = tempDTO.CurrencyCode;
            this.FReceiptView.AccountSign = tempDTO.AccountSign;
            this.FReceiptView.OldReceiptNo = tempDTO.ReceiptNo;

            if (tempDTO.AccuredStatus == "00")
            {
                this.FReceiptView.AutoRenewal = false; // autoRenewal checked Value
                this.FReceiptView.VisibleControlsForReceiptEditing(false, false);
            }
            else
            {
                this.FReceiptView.AutoRenewal = true;
                this.FReceiptView.VisibleControlsForReceiptEditing(true, tempDTO.AccuredStatus == "12" ? true : false);
                this.FReceiptView.OnlyPrinciple = tempDTO.AccuredStatus == "12" ? true : false;
            }
            this.FReceiptView.ReceiptNoDisable();
        }        

        public void ntxtAmount_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError)
                return;
            else if (tempDTO.LastInterestDate.Value != default(DateTime) && tempDTO.Amount != this.FReceiptView.Amount)
            {
                if (tempDTO.LastInterestDate.Value.ToString("yyyy/MM/dd") != System.DateTime.Now.ToString("yyyy/MM/dd"))
                {
                    //Back Date Transaction
                    this.SetCustomErrorMessage(this.GetControl("mtxtReceiptNo"), CXMessage.MV20023);
                    return;
                }
                else
                    this.FReceiptView.FReceiptEntity.IsReversalTransaction = true;
            }

            decimal minimunAmount, FixedDividedAmount;
            string temp = CXCOM00007.Instance.GetValueByVariable("FATRANAMT");

            if (temp == string.Empty)
                minimunAmount = 0;
            else
                minimunAmount = Convert.ToDecimal(temp);

            temp = CXCOM00007.Instance.GetValueByVariable("FADIVIDER");

            if (temp == string.Empty)
                FixedDividedAmount = 0;
            else
                FixedDividedAmount = Convert.ToDecimal(temp);

            if (minimunAmount > FReceiptView.Amount)
                this.SetCustomErrorMessage(this.GetControl("ntxtAmount"), CXMessage.MV00038);
            else if (FReceiptView.Amount < FixedDividedAmount)
                this.SetCustomErrorMessage(this.GetControl("ntxtAmount"), CXMessage.MV00038);
            else
                this.SetCustomErrorMessage(this.GetControl("ntxtAmount"), string.Empty);
        }

        public void mtxtInterestTakenAccount_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (this.FReceiptView.AutoRenewal == false)
                return;
            // if xml base error does not exist.
            else if (e.HasXmlBaseError == true)
                return;
            else if(string.IsNullOrEmpty(this.FReceiptView.TakenAccount))
                return;
            //else if (!string.IsNullOrEmpty(this.FReceiptView.Status))//when save,validation not check
            //    return;

            try
            {
                // And validate checkdigit of account code by account checkdigit formula
                Nullable<CXDMD00011> accountType;
                IList<PFMDTO00072> CurrentAcctLList = new List<PFMDTO00072>();
                if (CXCLE00012.Instance.IsValidAccountNo(this.FReceiptView.TakenAccount, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2))
                {
                    //Interest taken account must be Current Account (bug from ma ssa)
                    CurrentAcctLList = CXClientWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00072>>(x => x.GetCurrentAccountInfoByAccountNumber(this.freceiptview.TakenAccount));
                    if (CurrentAcctLList == null || CurrentAcctLList.Count==0)
                    {
                        // Set Empty to control.
                        this.SetCustomErrorMessage(this.GetControl("mtxtInterestTakenAccount"), CXMessage.MV00036);
                    }
                    //else if (CurrentAcctLList[0].BranchCode != this.FReceiptView.SourceBranchCode)
                    //{
                    //    // Set Error Message to Control.
                    //    this.SetCustomErrorMessage(this.GetControl("mtxtInterestTakenAccount"), CXMessage.MV00091, new object[] { this.FReceiptView.SourceBranchCode });
                    //}
                    else if (CurrentAcctLList[0].CurrencyCode != this.tempDTO.CurrencyCode)
                    {
                        // Set Currency Error Message to Control.
                        this.SetCustomErrorMessage(this.GetControl("mtxtInterestTakenAccount"), CXMessage.MV00086, new object[] { this.tempDTO.CurrencyCode });
                    }
                }
            }
            catch (Exception ex)
            {
                this.SetCustomErrorMessage(this.GetControl("mtxtInterestTakenAccount"), ex.Message);
            }
        }

        #endregion

        #region Main Methods

        public bool Save(PFMDTO00032 fReceiptEntity)
        {
            if (!this.ValidateForm(fReceiptEntity))
                return false;
            //try
            //{
                CXClientWrapper.Instance.Invoke<ITCMSVE00013>(x => x.Update(fReceiptEntity));

                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    return false;
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90002); //Update Successfull
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00143); //Please Deposit for Fixed Account again.

                    return true;
                }
            //}
            //catch (Exception ex)
            //{
            //    CXUIMessageUtilities.ShowMessageByCode(ex.Message);
            //    return false;
            //}
        }

        public bool Delete(PFMDTO00032 fReceiptEntity)
        {
            if (!this.ValidateForm(fReceiptEntity))
                return false;
            else if (this.tempDTO.LastInterestDate != default(DateTime))
            {
                // Set Empty to control.
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME00022);
                return false;
            }
            else if (CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC90001) == DialogResult.Yes)
            {
                CXClientWrapper.Instance.Invoke<ITCMSVE00013>(x => x.Delete(fReceiptEntity));

                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    return false;
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90003);
                    return true;
                }
            }
            else
                return false;
        }

        #endregion

    }
}
