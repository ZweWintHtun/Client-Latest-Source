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
using Ace.Cbs.Tel.Ctr.Sve;

namespace Ace.Cbs.Pfm.Ptr
{
    // Stop Cheque Presenter

    public class PFMCTL00014 : AbstractPresenter, IPFMCTL00014
    {
        #region Initializer
        private IPFMVEW00014 stopChequeView;
        public IPFMVEW00014 StopChequeView
        {
            set { this.WireTo(value); }
            get { return this.stopChequeView; }
        }

        private void WireTo(IPFMVEW00014 view)
        {
            if (this.stopChequeView == null)
            {
                this.stopChequeView = view;
                this.Initialize(this.stopChequeView, this.StopChequeView.StopChequeEntity);
                this.ErrorProvider.Validating += new EventHandler<ValidationEventArgs>(this.mtxtAccountNo_CustomValidating);                
            }
        }

        IList<PFMDTO00001> CustomerList { get; set; }
        #endregion

        #region Validation Method
        public override bool ValidateForm(object validationContext)
        {
            return base.ValidateForm(validationContext);
        }

        public void mtxtAccountNo_CustomValidating(object sender, ValidationEventArgs e)
        {           
            if (e.HasXmlBaseError==false)
            {
                if (CXCOM00006.Instance.Validate(this.stopChequeView.AccountNo,CXCOM00009.AccountNoCodeFormat,CXCOM00009.AccountNoCheckDigitFormula))                    
                {
                    if (this.stopChequeView.AccountNo.Substring(0, 3) != CurrentUserEntity.BranchCode)
                    {
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00091, new object[] { CurrentUserEntity.BranchCode });//Invalid Account No for Branch {0}.
                    }
                    else
                    {
                        if (CXClientWrapper.Instance.Invoke<ICXSVE00006, bool>(x => x.IsClosedAccountForCLedger(this.stopChequeView.AccountNo)))
                        {
                            // Account No has been closed.
                            this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00044);
                            return;
                        }
                        else
                        {
                            this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), string.Empty);
                        }

                        this.CustomerList = CXClientWrapper.Instance.Invoke<IPFMSVE00014, IList<PFMDTO00001>>(x => x.GetCustomerListByAccountNumber(this.stopChequeView.AccountNo));

                        if (this.CustomerList != null && this.CustomerList.Count > 0)
                        {
                            this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), string.Empty);
                            this.stopChequeView.gvCustomer_DataBind(this.CustomerList);
                        }
                        else
                        {
                            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == true) //Invalid Account No. for Branch {0}. (OR) Invalid Current Account No. (by hmw)
                            {
                                string message = CXClientWrapper.Instance.ServiceResult.MessageCode;
                                this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), message, new object[] { message == "MV00091" ? CurrentUserEntity.BranchCode : null });
                                return;
                            }
                            else
                            {
                                this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00058); //Invalid Current Account No.                            
                                return;
                            }

                        }
                    }
                }
                else
                {
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00058);
                    return;
                }
            }
        }

        public void ChequeStartNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError)
            {
                return;
            }
            StopChequeView.StartSerialNo= CXCLE00007.GetFormatString(Convert.ToInt32(StopChequeView.StartSerialNo), CXCOM00009.ChequeNoDisplayFormat);

            CXClientWrapper.Instance.Invoke<IPFMSVE00014, bool>(x => x.CheckStartChequeNo(StopChequeView.AccountNo, StopChequeView.ChequeBookNo, StopChequeView.StartSerialNo, CurrentUserEntity.BranchCode));

            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
            {
                this.SetCustomErrorMessage(this.GetControl("txtStartSerialNo"), CXMessage.MV00065);
                return;
            }
            else
            {
                this.SetCustomErrorMessage(this.GetControl("txtStartSerialNo"), string.Empty);
            }
        }
        
        public void ChequeEndNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError)
            {
                return;
            }

            if (Int32.Parse(StopChequeView.StartSerialNo) > Int32.Parse(StopChequeView.EndSerialNo)) //Start Cheque No is not greater than End Cheque No. (add by hmw)
            {
                this.SetCustomErrorMessage(this.GetControl("txtEndSerialNo"), CXMessage.MV00071);
                return;
            }

            StopChequeView.EndSerialNo = CXCLE00007.GetFormatString(Convert.ToInt32(StopChequeView.EndSerialNo), CXCOM00009.ChequeNoDisplayFormat);
            CXClientWrapper.Instance.Invoke<IPFMSVE00014, bool>(x => x.CheckEndChequeNo(StopChequeView.AccountNo, StopChequeView.ChequeBookNo, StopChequeView.EndSerialNo, CurrentUserEntity.BranchCode));

            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
            {
                this.SetCustomErrorMessage(this.GetControl("txtEndSerialNo"), CXMessage.MV00072);
                return;
            }
            else
            {
                this.SetCustomErrorMessage(this.GetControl("txtEndSerialNo"), string.Empty);                
            }

            
        // ---This following coding is no need for "Stopped Cheque Entry" Program because when "Cheque.EndNo" data samely enter into the "Start Serial No" and "End Serial No" textboxes, 
        // ---it occurs error. It is only for "Cheque Issue Entry" Program.
        // ---(Confirm by AK, Comment by hmw)

        //    if (CXCLE00007.IsValidChequeEndNo(this.stopChequeView.StartSerialNo, this.stopChequeView.EndSerialNo) == false)
        //    {
        //        //  Invalid End Cheque No.
        //        this.SetCustomErrorMessage(this.GetControl("txtEndSerialNo"), CXMessage.MV00072);
        //    }
        //    else
        //    {
        //        this.SetCustomErrorMessage(this.GetControl("txtEndSerialNo"), string.Empty);
        //    }
        }

        //For Check Cheque Duplicate
        public void txtChequeBookNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.StopChequeView.ChequeBookNo.Trim()))
            {
                this.StopChequeView.ChequeBookNo = CXCLE00007.GetFormatString(Convert.ToInt32(this.StopChequeView.ChequeBookNo), CXCOM00009.ChequeBookNoDisplayFormat);
                PFMDTO00006 result = CXClientWrapper.Instance.Invoke<IPFMSVE00015, PFMDTO00006>(x => x.SelectStartNoAndEndNoByChequeBookNo(StopChequeView.AccountNo, StopChequeView.ChequeBookNo));
                if (result == null)
                {
                    this.SetCustomErrorMessage(this.GetControl("txtChequeBookNo"), CXMessage.MV00067);//Invalid Cheque Book No.
                    this.StopChequeView.ChequeBookNo = string.Empty;
                }
            }            
            else
            {
                this.SetCustomErrorMessage(this.GetControl("txtChequeBookNo"), CXMessage.MV00067);  //Invalid Cheque Book No.
                this.SetFocus("txtChequeBookNo");
            }
        }
        #endregion

        #region Main Method
        public void ClearControls()
        {
            this.stopChequeView.AccountNo = "";
            this.stopChequeView.ChequeBookNo = "";
            this.stopChequeView.EndSerialNo = "";            
            this.stopChequeView.Remark = "";
            this.stopChequeView.StartSerialNo = "";
            this.ClearAllCustomErrorMessage();
        }

        public void Save(PFMDTO00011 entity)
        {
            if (this.ValidateForm(entity))
            {
                entity.SourceBranchCode = CXCOM00007.Instance.BranchCode;
                entity.USERNO = CurrentUserEntity.CurrentUserID.ToString();

                CXClientWrapper.Instance.Invoke<IPFMSVE00014>(x => x.Save(entity));

                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                {
                    this.StopChequeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
                else
                {
                    this.StopChequeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);                    
                }
            }
        }
        #endregion
    }
}