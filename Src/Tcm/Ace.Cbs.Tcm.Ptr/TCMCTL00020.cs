using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.CXClient;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tcm.Dmd;
using Ace.Windows.Core.Utt;


namespace Ace.Cbs.Tcm.Ptr
{
    public class TCMCTL00020:AbstractPresenter,ITCMCTL00020
    {
        #region Properties
        private ITCMVEW00020 view;
        public ITCMVEW00020 View
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        IList<PFMDTO00001> customerInfo { get; set; }
        public string Status { get; set; }
        public string Account { get; set; }
        public bool check = false;
        #endregion

        #region Methods
        private void WireTo(ITCMVEW00020 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetMinimumBalanceData());
            }
        }

        public void ClearControls()
        {
            this.view.AccountNo = string.Empty;
            this.view.OldMinimumLimit = 0;
            this.view.NewMinimumLimit = 0;
            this.view.Remark = string.Empty;
            this.view.Information = string.Empty;
            this.view.SetFocus();
        }

        public TCMDTO00007 GetMinimumBalanceData()
        {
            TCMDTO00007 minimumBalanceDTO = new TCMDTO00007();
            minimumBalanceDTO.AccountNo = this.view.AccountNo;
            minimumBalanceDTO.Old_Limit = this.view.OldMinimumLimit;
            minimumBalanceDTO.New_Limit = this.view.NewMinimumLimit;
            minimumBalanceDTO.Remark = this.view.Remark;
            return minimumBalanceDTO;
        }

        public bool Save()
        {
            this.Status = "Save";

            TCMDTO00007 balanceDTO = GetMinimumBalanceData();
            if (this.ValidateForm(balanceDTO))
            {

                if (this.view.NewMinimumLimit > 0)
                {
                    decimal totalBal = customerInfo[0].CurrentBal + customerInfo[0].OverdraftLimit;
                    if (this.view.NewMinimumLimit > totalBal)
                    {
                        //Total Minimum Balance can't be greater than Ledger Balance.
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00062", new object[]{ balanceDTO.AccountNo});
                    }
                    else
                    {
                        if (this.SaveData())
                        {
                            check = true;
                        }
                    }
                }
                else
                {
                    if (this.SaveData())
                    {
                        check = true;
                    }
                }
            }
            return check;
        }


        public bool SaveData()
        {
            TCMDTO00007 balanceDTO = GetMinimumBalanceData();
            balanceDTO.SourceBranch = customerInfo[0].SourceBranch;
            balanceDTO.Currency = customerInfo[0].CurrencyCode;
            balanceDTO.CreatedUserId = CurrentUserEntity.CurrentUserID;

            CXClientWrapper.Instance.Invoke<ITCMSVE00020>(x => x.SaveMinimumBalance(balanceDTO));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == true)
            {
                this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                check = false;
            }
            else
            {
                this.View.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                this.ClearControls();
                check = true;
            }

            return check;
                
        }
        #endregion

        #region Validation Logic
        public void mtxtAccountNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if xml base error does not exist.
            if (e.HasXmlBaseError != false)
                return;

            try
            {
                Nullable<CXDMD00011> accountType;
                IList<PFMDTO00001> customer = new List<PFMDTO00001>();
                if (CXCLE00012.Instance.IsValidAccountNo(this.view.AccountNo, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2))
                {
                    customerInfo = CXClientWrapper.Instance.Invoke<ITCMSVE00020, IList<PFMDTO00001>>(x => x.GetCustomerByAccountNumber(this.view.AccountNo));
                    if (customerInfo.Count > 0)
                    {
                        foreach (PFMDTO00001 info in customerInfo)
                        {
                            if (info.CustomerId != null)
                            {
                                customer.Add(info);
                            }
                        }
                        this.view.gvCustomer_DataBind(customer);
                        if(!string.IsNullOrEmpty(customerInfo[0].NameofFirm))
                        {
                            this.view.Information=customerInfo[0].NameofFirm;
                        }

                        if (this.Status != "Save")
                        {
                            this.Account = this.view.AccountNo;
                            this.view.OldMinimumLimit = customerInfo[0].MinimumBalance;
                            this.view.NewMinimumLimit = customerInfo[0].MinimumBalance;
                        }
                        else if(this.view.AccountNo==Account)
                        {
                            this.view.OldMinimumLimit = this.view.OldMinimumLimit;
                            this.view.NewMinimumLimit = this.view.NewMinimumLimit;
                            this.Status = string.Empty;
                        }
                        else 
                        {
                            this.view.OldMinimumLimit = customerInfo[0].MinimumBalance;
                            this.view.NewMinimumLimit = this.view.NewMinimumLimit;
                            this.Status = string.Empty;
                        }
                    }
                    else
                    {
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), "MV00046");//Account No Not Found.
                       
                    }
                }
            }
            catch (Exception ex)
            {
                this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), ex.Message);
            }
        }
        #endregion
    }
}
