using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Cx.Cle;


namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00012 : AbstractPresenter, ILOMCTL00012
    {
        public TLMDTO00018 LoanDTO { get; set; }
        #region "Wire To"
        private ILOMVEW00012 view;
        public ILOMVEW00012 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        public string Currency { get; set; }
        public DateTime ExpiredDate { get; set; }

        private void WireTo(ILOMVEW00012 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetEntity());
            }
        }

        private TLMDTO00018 GetEntity()
        {
            TLMDTO00018 LoanEntity = new TLMDTO00018();
            LoanEntity.Lno = this.view.LoanNo;
            LoanEntity.OverdraftAmount = this.view.NewODLimit;
            return LoanEntity;
        }
        #endregion

        #region Method

        public void ClearCustomErrorMessage()
        {
            this.ClearAllCustomErrorMessage();
        }

        public void Save()
        {            
            if (!this.ValidateForm(GetEntity()))                         
                return;            
            else
            {
                this.view.Status = string.Empty;
                TLMDTO00018 LoanEntity = this.GetODLmitChangeData();
                if (this.view.NewODLimit.ToString() != "" && this.view.NewODLimit != 0 && this.view.NewODLimit != this.view.PresentODLimit)
                {
                    if (CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC90006, new object[] { LoanEntity.PresentODLimit, LoanEntity.NewODLimit }) == DialogResult.Yes)
                    {
                        CXClientWrapper.Instance.Invoke<ILOMSVE00012>(x => x.SaveODLimitChangeData(LoanEntity));
                        if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                        {
                            string message = CXClientWrapper.Instance.ServiceResult.MessageCode;
                            string[] msg = null;
                            if (!string.IsNullOrEmpty(message))
                            {
                                msg = message.Split('.');
                                CXUIMessageUtilities.ShowMessageByCode(msg[0].ToString(), new object[] { msg[1].ToString(), LoanEntity.AccountNo });
                            }
                            CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90017);   //Overdraft Limit has successfully changed. 
                            this.view.Name = string.Empty;
                           
                        }
                        else
                            CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }
            }
        } 

        public TLMDTO00018 GetODLmitChangeData()
        {
            TLMDTO00018 ODLmitChangeData = new TLMDTO00018();
            try
            {       
                ODLmitChangeData.Lno = this.view.LoanNo;
                ODLmitChangeData.AccountNo = this.view.AccountNo;
                ODLmitChangeData.OverdraftAmount = this.view.OverdraftAmount;
                ODLmitChangeData.PresentODLimit = this.view.PresentODLimit;
                ODLmitChangeData.NewODLimit = this.view.NewODLimit;
                ODLmitChangeData.TotalODLimit = this.view.TotalODLimit;
                ODLmitChangeData.NewTotalODLimit = this.view.NewTotalODLimit;
                ODLmitChangeData.Name = this.view.Name;
                ODLmitChangeData.Currency = Currency;
                ODLmitChangeData.ExpireDate = ExpiredDate;
                ODLmitChangeData.SourceBranchCode = CurrentUserEntity.BranchCode;
                ODLmitChangeData.UserNo = CurrentUserEntity.CurrentUserID.ToString();
                ODLmitChangeData.CreatedUserId = CurrentUserEntity.CurrentUserID;
                ODLmitChangeData.CreatedDate = DateTime.Now;
                ODLmitChangeData.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                ODLmitChangeData.UpdatedDate = DateTime.Now;
                ODLmitChangeData.serviceChargesRate = CXCLE00002.Instance.GetScalarObject<PFMDTO00009>("PFMORM00009.Client.SelectByCodeAndLastModify", new object[] { "ODSCHARGERATE", true, true }).Rate; //hm
                
            }
            catch
            {
                throw new Exception(CXMessage.ME00021);    //Client Data Not Found.
            }
            return ODLmitChangeData;
        }

        #endregion

        #region ValidationMethod
 
        public void txtLoanNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if xml base error does not exist.
            if (e.HasXmlBaseError == false) 
            {                
                try
                {
                    
                    LoanDTO = CXClientWrapper.Instance.Invoke<ILOMSVE00012, TLMDTO00018>(x => x.isValidLoanNo(this.View.LoanNo, CurrentUserEntity.BranchCode));

                    if (LoanDTO == null || CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        this.SetCustomErrorMessage(this.GetControl("txtLoanNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                        return;
                    }
                    this.view.AccountNo = LoanDTO.AccountNo;
                    this.view.PresentODLimit = LoanDTO.SAmount == null ? 0 : LoanDTO.SAmount.Value;
                    this.view.OverdraftAmount = LoanDTO.OverdraftAmount;
                    this.view.TotalODLimit = this.view.PresentODLimit;
                    this.View.Name = LoanDTO.Name;
                    this.Currency = LoanDTO.Currency;
                    this.ExpiredDate = Convert.ToDateTime(LoanDTO.ExpireDate);
                                                    
                   // this.SetFocus("txtNewODLimit");
                   // this.SetFocus("lblNewODLimit");                    
                }
                catch (Exception)
                {
                    this.SetCustomErrorMessage(this.GetControl("txtLoanNo"), "MV90055"); //Invalid Entry No.                    
                }
            }
            else
            { return; }
        }

        public void txtNewODLimit_CustomValidating(object sender, ValidationEventArgs e)
        {            
            // if xml base error does not exist.
            if (e.HasXmlBaseError == false)
            {
                
                this.view.NewTotalODLimit = this.view.NewODLimit;
            }
            else 
            {
                this.view.Status = "err";
                return;
            }
        }
        #endregion

    }
}
