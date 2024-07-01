using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Cle;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00412 : AbstractPresenter, ILOMCTL00412
    {
        #region Properties
        private ILOMVEW00412 view;
        public ILOMVEW00412 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00412 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetViewData());
            }
        }
        #endregion

        #region Helper Method
        public void ClearCustomErrorMessage()
        {
            this.ClearAllCustomErrorMessage();
        }

        public LOMDTO00406 GetViewData()
        {
            LOMDTO00406 viewData = new LOMDTO00406();
            viewData.SourceBr = this.view.SourceBranch;
            viewData.Cur = this.view.Currency;
            //viewData.Lno = this.view.BLNo;//Commented by HWKo (22-Nov-2017)
            viewData.Acctno = this.view.AcctNo;//Added by HWKO (22-Nov-2017)
            return viewData;
        }

        //Added by HWKO (22-Nov-2017)
        public bool Validate_Form()
        {
            return this.ValidateForm(this.GetViewData());
        }
        #endregion

        #region Methods

        //Added by HWKO (22-Nov-2017)
        public bool CheckBusinessLoansAccountNo(string acctNo)
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
                                return false;
                            }

                            else
                            {
                                CXUIMessageUtilities.ShowMessageByCode(msgCode);
                                this.SetFocus("mtxtAccountNo");
                                return false;
                            }
                        }
                        if (AccountInfoList[0].AccountSignature.Substring(0, 1) != "B")
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

        public IList<TLMDTO00018> GetBusinessLNo(string sourceBr)
        {
            try
            {
                IList<TLMDTO00018> DTOList = new List<TLMDTO00018>();
                DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00405, IList<TLMDTO00018>>(x => x.SelectBusinessLoansNoBySourceBr(sourceBr));
                if (DTOList.Count == 0)
                {
                   //CXUIMessageUtilities.ShowMessageByCode("MI90020");//There is no Loans Account
                }
                return DTOList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Print()
        {
            try
            {
                LOMDTO00406 DTO = this.GetViewData();
                IList<LOMDTO00406> DTOList = new List<LOMDTO00406>();
                DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00405, IList<LOMDTO00406>>(x => x.SelectBLInfolistingByBLNo(DTO));
                if (DTOList.Count >0)
                {
                    //string blNo = this.view.BLNo.ToString();//Commented by HWKO (22-Nov-2017)
                    string acctNo = this.view.AcctNo;
                    string currency = this.view.Currency.ToString();
                    string sourcebranch = this.view.SourceBranch.ToString();
                    string header = "Business Loans Schedule Listing By Account No";
                    CXUIScreenTransit.Transit("frmLOMVEW00413.ReportViewer", true, new object[] { DTOList,currency, sourcebranch, header });
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
