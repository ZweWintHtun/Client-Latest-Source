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
    public class PFMCTL00013 : AbstractPresenter, IPFMCTL00013
    {
        #region Initializer

        private IPFMVEW00013 chequeView;
        public IPFMVEW00013 ChequeView
        {
            set { this.WireTo(value); }
            get { return this.chequeView; }
        }

        private void WireTo(IPFMVEW00013 chequeView)
        {
            if (this.chequeView == null)
            {
                this.chequeView = chequeView;
                this.Initialize(this.chequeView, this.chequeView.ChequeEntity);
                this.ErrorProvider.Validating += new EventHandler<ValidationEventArgs>(this.mtxtAccountNo_CustomValidating);
                this.ErrorProvider.Validating += new EventHandler<ValidationEventArgs>(this.txtStartNo_CustomValidating);
                this.ErrorProvider.Validating += new EventHandler<ValidationEventArgs>(this.txtChequeBookNo_CustomValidating);//For Cheque Book No duplicate

            }
        }

        #endregion

        #region Private Variables

        private IList<PFMDTO00017> CAOFList = new List<PFMDTO00017>();        

        #endregion

        #region Validation Logic

        public override bool ValidateForm(object validationContext)
        {           
            return base.ValidateForm(validationContext);
        }        

        public void mtxtAccountNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError == false && chequeView.IsMainMenu==true)
            {
                if (CXCOM00006.Instance.Validate(this.ChequeView.AccountNo, CXCOM00009.AccountNoCodeFormat, CXCOM00009.AccountNoCheckDigitFormula))
                {
                    if (CXClientWrapper.Instance.Invoke<ICXSVE00006, bool>(x => x.IsClosedAccountForCLedger(this.ChequeView.AccountNo)))
                    {
                        // Account No has been closed.
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00044);
                        return;
                    }
                    else
                    {
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), string.Empty);
                    }

                    CAOFList = CXClientWrapper.Instance.Invoke<IPFMSVE00012, IList<PFMDTO00017>>(x => x.GetCAOFByAccountNumber(this.ChequeView.AccountNo,CurrentUserEntity.BranchCode));

                    if (CAOFList.Count < 1)
                    {
                        // Invalid Current Account No.
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00058);
                    }
                    else
                    {
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), string.Empty);
                    }
                }
                else
                {
                    // Invalid Current Account No.
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00046); //Invalid Account No.
                }
            }
        }

        public void txtStartNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError == false)            
            {
                if (!string.IsNullOrEmpty(this.ChequeView.StartNo))
                {
                    this.ChequeView.StartNo = CXCLE00007.GetFormatString(Convert.ToInt32(this.ChequeView.StartNo), CXCOM00009.ChequeNoDisplayFormat);

                    
                    string endNo = CXCLE00007.GetChequeEndNo(this.ChequeView.StartNo);

                    if (endNo.Equals("-1"))
                    {
                        // Invalid Start Cheque No.
                        this.SetCustomErrorMessage(this.GetControl("txtStartNo"), CXMessage.MV00065);
                        this.ChequeView.EndNo = string.Empty;
                    }
                    else if (endNo.Equals("-2"))
                    {
                        this.SetCustomErrorMessage(this.GetControl("txtStartNo"), CXMessage.MV00084);
                        this.ChequeView.EndNo = string.Empty;
                    }
                    else
                    {
                        this.ChequeView.EndNo = endNo;
                        this.SetCustomErrorMessage(this.GetControl("txtStartNo"), string.Empty);
                    }
                }
            }
        }

        //For Check Cheque Duplicate
        public void txtChequeBookNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.ChequeView.ChequeBookNo.Trim()))
                this.ChequeView.ChequeBookNo = CXCLE00007.GetFormatString(Convert.ToInt32(this.ChequeView.ChequeBookNo), CXCOM00009.ChequeBookNoDisplayFormat);

            if (!string.IsNullOrEmpty(this.ChequeView.ChequeBookNo))
            {
                if (CXClientWrapper.Instance.Invoke<ICXSVE00006, bool>(x => x.CheckChequeBookNo(this.ChequeView.ChequeBookNo, CurrentUserEntity.BranchCode)))
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    this.ChequeView.ChequeBookNo = string.Empty;
                    this.SetFocus("txtChequeBookNo");
                }
                else
                    this.SetFocus("txtStartNo");
            }
            else
            {
                this.SetCustomErrorMessage(this.GetControl("txtChequeBookNo"), CXMessage.MV00067);
                this.SetFocus("txtChequeBookNo");
            }
        }


        #endregion

        #region Public Methods

        public void Save(PFMDTO00006 entity)
        {
            if (this.ValidateForm(entity))            
            {
                entity.SourceBranchCode = CXCOM00007.Instance.BranchCode;
                entity.CreatedUserId = CurrentUserEntity.CurrentUserID;

                if (CAOFList.Count > 0)
                {
                    entity.AccountSign = CAOFList[0].AccountSign;

                    entity.CurrencyCode = CAOFList[0].CurrencyCode;
                }

                this.ChequeView.ChequeEntity.IssueDate = DateTime.Now;

                this.ChequeView.ChequeEntity.UserNo = CurrentUserEntity.CurrentUserID.ToString();

                CXClientWrapper.Instance.Invoke<IPFMSVE00013>(x => x.Save(entity));

                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                {
                    this.ChequeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
                else
                {
                    string message=CXClientWrapper.Instance.ServiceResult.MessageCode;
                    this.ChequeView.Failure(message);
                    if (message == "MV00025") //Duplicate Cheque Book No or Cheque No.\n Please enter New Cheque Book No and Cheque No.
                    {
                        this.SetCustomErrorMessage(this.GetControl("txtChequeBookNo"), message); //by hmw (To show error provider. But, it don't show error provider. It setfocus and select all data of the affected control.)
                    }
                    return;
                } 
            }
        }
        public void ClearControls()
        {
            this.chequeView.AccountNo = "";
            this.chequeView.ChequeBookNo = "";
            this.chequeView.EndNo = "";
            this.chequeView.StartNo = "";            
            this.ClearAllCustomErrorMessage();
        }
        #endregion
    }
}