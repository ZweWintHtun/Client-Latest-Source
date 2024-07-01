using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.PTR;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.CXClient;

namespace Ace.Cbs.Pfm.Ptr
{
    public class PFMCTL00021 : AbstractPresenter, IPFMCTL00021
    {
        #region Property
        private bool isPrintValidate = false;

        private IPFMVEW00021 view;
        public IPFMVEW00021 SavingWithdrawalView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        private IList<PFMDTO00016> saof;
        public IList<PFMDTO00016> Saof
        {
            get { return this.saof; }
            set { this.saof = value; }
        }

        public PFMDTO00001 Customer { get; set; }

        private PFMDTO00016 saofEntity;
        public PFMDTO00016 SaofEntity
        {
            get { return this.saofEntity; }
            set { this.saofEntity = value; }
        }
        
        #endregion 

        #region Method

        private void WireTo(IPFMVEW00021 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view,new PFMDTO00059());               
            }
        }

        //Check ACode id valid or not
        public bool IsValidACode()
        {          
            string coa = CXCLE00002.Instance.GetScalarObject<string>("COA.Client.Select", new object[] { this.view.OLSACNo, this.view.SourceBranchCode, true });

            if (coa != null)
                return true;
            else
                return false;
        }

        //Chec AccountNo is valid or not
        public bool IsValidAccountCode()
        {
            this.Saof = CXClientWrapper.Instance.Invoke<IPFMSVE00021, IList<PFMDTO00016>>(x => x.GetSAOFByAccountNumber(this.SavingWithdrawalView.AccountNo));
            return this.Saof != null ? true : false;

        }

        //OLSAccountNo Textbox Validating
        public void mtxtOLSAccountNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError)
            {
                return;
            }
            if (SavingWithdrawalView.FormName == "Saving Withdrawal Form Online")
                if (!IsValidACode())
                {
                    // Invalid OLS Account No.
                    this.SetCustomErrorMessage(this.GetControl("mtxtOLSAccountNo"), CXMessage.MV00051);
                }
        }

        //AccountNo Textbox Validating
        public void mtxtAccountNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (this.view.AccountNo == string.Empty )
            {               
                if(e.HasXmlBaseError==false)
                {               
                    if (isPrintValidate == false)
                    {
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00051);
                        return;
                    }            
                }                
            }          

                if (CXCOM00006.Instance.Validate(this.view.AccountNo, CXCOM00009.AccountNoCodeFormat, CXCOM00009.AccountNoCheckDigitFormula))
                {
                    if (SavingWithdrawalView.FormName != "Saving Withdrawal Form Online")
                        // Get Customer Information by Saving Account Information
                        Customer = CXClientWrapper.Instance.Invoke<IPFMSVE00021, PFMDTO00001>(x => x.GetCustomerByAccountNumber(this.SavingWithdrawalView.AccountNo));

                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                        //Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode, this.view.AccountNo);
                        //SavingWithdrawalView.SetCursor("Account");   
                        return;
                    }

                    if (Customer != null)
                    {
                        this.SavingWithdrawalView.Name = Customer.Name;
                        this.SavingWithdrawalView.NRC = Customer.NRC;
                        SavingWithdrawalView.SetCursor("Amount");
                    }

                  
                }
            
            else
            {
                // Invalid Saving Account No.
                this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00051);
                //Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00051);
                //SavingWithdrawalView.SetCursor("Account");
            }
}

        //Amount Textbox Validating
        public void txtAmount_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError)
            {
                return;
            }
            if (Convert.ToDecimal(SavingWithdrawalView.Amount) < 1)
            {
                // Invalid Amount.
                this.SetCustomErrorMessage(this.GetControl("txtAmount"), CXMessage.MV00037);
                //Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00037);
                //SavingWithdrawalView.SetCursor("Amount");
            }
        }

        public void Print()
        {
            
            //PFMDTO00050 individual = this.GetIndividualEntity();
          
           
                if (SavingWithdrawalView.ViewDataList == null)
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00078);

                    if (SavingWithdrawalView.FormName == "Saving Withdrawal Form Offline")
                        SavingWithdrawalView.SetCursor("Account");
                    else
                        SavingWithdrawalView.SetCursor("OLSAccount");
                }
                else if (SavingWithdrawalView.ViewDataList.Count == 0)
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00078);

                    if (SavingWithdrawalView.FormName == "Saving Withdrawal Form Offline")
                        SavingWithdrawalView.SetCursor("Account");
                    else
                        SavingWithdrawalView.SetCursor("OLSAccount");
                }
                else
                {
                    string cashInZawGyi = null;
                    if (SavingWithdrawalView.FormName == "Saving Withdrawal Form Offline")
                    {
                        
                        foreach (PFMDTO00059 SavingReportEntity in SavingWithdrawalView.ViewDataList)
                        {
                            cashInZawGyi = this.CashInZawGyiFont(Convert.ToDecimal(SavingReportEntity.Amount.Remove(SavingReportEntity.Amount.Length - 3,3)));
                            SavingReportEntity.AmountWithZawGyi = cashInZawGyi;
                            CXUIScreenTransit.Transit("frmPFMVEW00022");
                            CXUIScreenTransit.Transit("frmPFMVEW00023", new object[] { SavingReportEntity  });
                        }
                    }
                    else if (SavingWithdrawalView.FormName == "Saving Withdrawal Form Online")
                    {
                        foreach (PFMDTO00059 SavingReportEntity in SavingWithdrawalView.ViewDataList)
                        {
                            cashInZawGyi = this.CashInZawGyiFont(Convert.ToDecimal(SavingReportEntity.Amount.Remove(SavingReportEntity.Amount.Length - 3, 3)));
                            SavingReportEntity.AmountWithZawGyi = cashInZawGyi;
                            CXUIScreenTransit.Transit("frmPFMVEW00022");
                            CXUIScreenTransit.Transit("frmPFMVEW00024", new object[] { SavingReportEntity });
                        }
                    }
                }
            

        }

        private string CashInZawGyiFont(decimal amount)
        {
            //int stringCount = (amount.ToString().Length);
            string keyword = string.Empty;
            //for (int i = 0; i < stringCount; i++)
            //{
            //    keyword += (amount.ToString()).;
            //}
            //return keyword;

            char[] keys = (amount.ToString()).ToCharArray();
            foreach (char item in keys)
            {
                keyword += GetZawGyiFont(item);
            }
            return keyword;
        }

        private string GetZawGyiFont(char key)
        {
            switch (key)
            {
                case '1':
                    return "၁";
                case '2':
                    return "၂";
                case '3':
                    return "၃";
                case '4':
                    return "၄";
                case '5':
                    return "၅";
                case '6':
                    return "၆";
                case '7':
                    return "၇";
                case '8':
                    return "၈";
                case '9':
                    return "၉";
                default:
                    return "၀";
            }
        }
        #endregion

    }

}