using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Loan.Ptr
{
    class LOMCTL00214 : AbstractPresenter, ILOMCTL00214
    {
        private ILOMVEW00214 view;
        public ILOMVEW00214 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00214 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }

        public string GetRepayAmountPerTerm(string hpno, string sourceBr)
        {
            string repayAmount = CXClientWrapper.Instance.Invoke<ILOMSVE00096, string>(x => x.GetRepayAmountPerTerm(hpno, sourceBr));
            return repayAmount;
        }

        //Updated by HWKO (21-Nov-2017)//void Print(string rptName,string hpNo,string currency, string sourceBr)
        public void Print(string rptName,string acctNo,string currency, string sourceBr)
        {
            IList<LOMDTO00213> DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00213>>(x => x.Get_HP_Repayment_Schedule_Listing(acctNo,currency,sourceBr));
            if (DTOList.Count > 0)
            {
                string header = "Hire Purchase Repayment Schedule Listing";
                string hpNo = DTOList[0].HPNO;
                acctNo = DTOList[0].AcctNo;
                string name = DTOList[0].NAME;
                string phoneNo = DTOList[0].PHONE;
                string address = DTOList[0].ADDRESS;
                CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, currency, header, sourceBr, hpNo,acctNo,name,phoneNo,address, rptName });
            }
            else
            {
                CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
            }

        }

        //Added by HWKO (21-Nov-2017)
        public bool CheckHPAccountNo(string acctNo)
        {
            try
            {
                if (this.view.AcctNo.Substring(0, 3) == CurrentUserEntity.BranchCode)
                {
                    Nullable<CXDMD00011> accountType;
                    if (CXCLE00012.Instance.IsValidAccountNo(this.view.AcctNo, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2))
                    {
                        IList<PFMDTO00072> AccountInfoList = new List<PFMDTO00072>();
                        // Commented by ZMS
                        //AccountInfoList = CXClientWrapper.Instance.Invoke<ILOMSVE00311, IList<PFMDTO00072>>(x => x.IsValidForLoanAcctno(this.View.AcctNo));
                        //Modified by ZMS
                        AccountInfoList = CXClientWrapper.Instance.Invoke<ILOMSVE00311, IList<PFMDTO00072>>(x => x.IsValidForLoanAcctnoForHPRepaymentListing(this.View.AcctNo));

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

                        if (AccountInfoList[0].AccountSignature.Substring(0, 1) != "H")
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


    }
}
