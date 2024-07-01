using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Dmd;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00316 : AbstractPresenter, ILOMCTL00316
    {
        #region Properties
        private ILOMVEW00316 view;
        public ILOMVEW00316 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00316 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetViewData());
            }
        }
        #endregion

        #region Helper Method
        public bool Validate_Form()
        {
            return this.ValidateForm(this.GetViewData());
        }

        public void ClearCustomErrorMessage()
        {
            this.ClearAllCustomErrorMessage();
        }

        public LOMDTO00316 GetViewData()
        {
            LOMDTO00316 viewData = new LOMDTO00316();
            if (!String.IsNullOrEmpty(this.view.AcctNo))
            {
                string plNo = CXClientWrapper.Instance.Invoke<ILOMSVE00311, string>(x => x.GetPLNoByACNoAndSourceBr(this.view.AcctNo, this.view.SourceBranch));
                viewData.PLNO = plNo;
                viewData.ACNo = view.AcctNo; //Added by AAM(12_Sep_2018)
            } 
            viewData.SourceBr = this.view.SourceBranch;
            //viewData.Cur = this.view.Currency;
            return viewData;
        }

        public bool CheckPersonalLoanAccountNo(string acctNo)
        {
            try
            {
                if (this.view.AcctNo.Substring(0, 3) == CurrentUserEntity.BranchCode)
                {
                    Nullable<CXDMD00011> accountType;
                    if (CXCLE00012.Instance.IsValidAccountNo(this.view.AcctNo, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2))
                    {
                        IList<PFMDTO00072> AccountInfoList = new List<PFMDTO00072>();
                        //AccountInfoList = CXClientWrapper.Instance.Invoke<ILOMSVE00311, IList<PFMDTO00072>>(x => x.IsValidForLoanAcctno(this.View.AcctNo));
                        AccountInfoList = CXClientWrapper.Instance.Invoke<ILOMSVE00311, IList<PFMDTO00072>>(x => x.IsValidForLoanAcctnoForPLRepaymentListing(this.View.AcctNo));//Updated by ZMS(16.11.18)for Pristine requirements

                        if (AccountInfoList.Count < 1 || CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                        {
                            string msgCode = CXClientWrapper.Instance.ServiceResult.MessageCode;

                            if (msgCode == "MV00056" || msgCode == "MV90069")//new object[]{this.linkAccountView.CurrentAccountNo}
                            {
                                CXUIMessageUtilities.ShowMessageByCode(msgCode, new object[] { this.View.AcctNo }); //Invalid Account No.
                                this.SetFocus("mtxtAccountNo");
                                return false;
                            }

                            else
                            {
                                CXUIMessageUtilities.ShowMessageByCode(msgCode);
                                this.SetFocus("mtxtAccountNo");
                                return false;
                            }
                        }
                        if (AccountInfoList[0].AccountSignature.Substring(0, 1) != "P")
                        {
                            CXUIMessageUtilities.ShowMessageByCode("MV00046", new object[] { this.View.AcctNo }); //Invalid Account No.
                            this.SetFocus("mtxtAccountNo");
                            return false;
                        }
                    }
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00224, new object[] { this.view.AcctNo, CurrentUserEntity.BranchCode }); //Invalid Account No {0} for Branch {1}.
                    this.SetFocus("mtxtAccountNo");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), ex.Message);
                return false;
            }
        }

        public void mtxtAccountNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if xml base error does not exist.
            if (!e.HasXmlBaseError)
            {
                try
                {
                    if (this.view.AcctNo.Substring(0, 3) == CurrentUserEntity.BranchCode)
                    {
                        Nullable<CXDMD00011> accountType;
                        if (CXCLE00012.Instance.IsValidAccountNo(this.view.AcctNo, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2))
                        {
                            IList<PFMDTO00072> AccountInfoList = new List<PFMDTO00072>();
                            AccountInfoList = CXClientWrapper.Instance.Invoke<ILOMSVE00311, IList<PFMDTO00072>>(x => x.IsValidForLoanAcctno(this.View.AcctNo));

                            if (AccountInfoList.Count < 1 || CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                            {
                                string msgCode = CXClientWrapper.Instance.ServiceResult.MessageCode;

                                if (msgCode == "MV00056" || msgCode == "MV90069")//new object[]{this.linkAccountView.CurrentAccountNo}
                                {
                                    CXUIMessageUtilities.ShowMessageByCode(msgCode, new object[] { this.View.AcctNo }); //Invalid Account No.
                                    this.SetFocus("mtxtAccountNo");
                                }

                                else
                                {
                                    CXUIMessageUtilities.ShowMessageByCode(msgCode);
                                    this.SetFocus("mtxtAccountNo");
                                }
                            }
                        }
                    }
                    else
                    {
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00224, new object[] { this.view.AcctNo, CurrentUserEntity.BranchCode }); //Invalid Account No {0} for Branch {1}.
                        this.SetFocus("mtxtAccountNo");
                    }
                }
                catch (Exception ex)
                {
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), ex.Message);
                }
            }
        }

        #endregion

        #region Methods

        public void Print()
        {
            if (this.Validate_Form())
            {
                LOMDTO00316 DTO = this.GetViewData();
                IList<LOMDTO00316> DTOList = new List<LOMDTO00316>();
                DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00316, IList<LOMDTO00316>>(x => x.SelectByPLNO(DTO));
                if (DTOList.Count > 0)
                {
                    //string plno = this.view.PLLoanNo.ToString();
                    string sourcebranch = this.view.SourceBranch.ToString();
                    string header = "Personal Loans Repayment Schedule";
                    CXUIScreenTransit.Transit("frmLOMVEW00317.ReportViewer", true, new object[] { DTOList, sourcebranch, header });
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
                }
            }
        }
        #endregion
    }
}
