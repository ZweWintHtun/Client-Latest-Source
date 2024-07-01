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
    public class LOMCTL00338 : AbstractPresenter, ILOMCTL00338
    {
        #region Properties
        private ILOMVEW00338 view;
        public ILOMVEW00338 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00338 view)
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

        public LOMDTO00338 GetViewData()
        {
            LOMDTO00338 viewData = new LOMDTO00338();
            if (!String.IsNullOrEmpty(this.view.AcctNo))
            {
                string lno = CXClientWrapper.Instance.Invoke<ILOMSVE00311, string>(x => x.GetBLNoByACNoAndSourceBr(this.view.AcctNo, this.view.SourceBranch));
                viewData.Lno = lno;
            }
            viewData.SourceBr = this.view.SourceBranch;
            viewData.DateFromView = this.view.DateFromView;
            return viewData;
        }

        public bool CheckBLAccountNo(string acctNo)
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

        #endregion

        #region Methods

        private IList<LOMDTO00338> GetCustInfoByAcctNo(IList<LOMDTO00338> dataList, string sourceBr)
        {
            string CustName = "", CustNRC = "", CustFatherName = "", CustAddress = "";
            IList<LOMDTO00334> CustNameList = new List<LOMDTO00334>();
            CustNameList = CXClientWrapper.Instance.Invoke<ILOMSVE00311, IList<LOMDTO00334>>(x => x.GetCustInfoByAcctNo(dataList[0].AcctNo, sourceBr));
            if (CustNameList.Count > 0)
            {
                int i = 0;
                do
                {
                    if (i > 0)
                    {
                        CustName = CustName + " @ ";
                        CustNRC = CustNRC + " @ ";
                        CustFatherName = CustFatherName + " @ ";
                        CustAddress = CustAddress + " @ ";
                    }

                    CustName = CustName + CustNameList[i].CustName;
                    CustNRC = CustNRC + CustNameList[i].CustNRC;
                    CustFatherName = CustFatherName + CustNameList[i].CustFatherName;
                    CustAddress = CustAddress + CustNameList[i].CustAddress;

                    i++;

                } while (i < CustNameList.Count);

            }
            foreach (LOMDTO00338 dto in dataList)
            {
                dto.CustName = CustName;
                dto.CustNRC = CustNRC;
                dto.CustAddress = CustAddress;
            }
            return dataList;
        }

        public void Print()
        {
            if (this.Validate_Form())
            {
                LOMDTO00338 DTO = this.GetViewData();
                IList<LOMDTO00338> DTOList = new List<LOMDTO00338>();
                DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00311, IList<LOMDTO00338>>(x => x.GetBLPGInfoForContractPrinting(DTO));
                if (DTOList.Count > 0)
                {
                    DTOList = this.GetCustInfoByAcctNo(DTOList, DTO.SourceBr);
                    CXUIScreenTransit.Transit("frmLOMVEW00339.ReportViewer", true, new object[] { DTOList, this.view.DateFromView });
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
