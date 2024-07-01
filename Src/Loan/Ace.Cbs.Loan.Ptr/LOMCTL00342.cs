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
    class LOMCTL00342 : AbstractPresenter, ILOMCTL00342
    {
        #region Properties
        private ILOMVEW00342 view;
        public ILOMVEW00342 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00342 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetViewData());
            }
        }

        IList<LOMDTO00334> CustNameList = new List<LOMDTO00334>();
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

            viewData.CustNameCustNRCConcatFromView = this.view.CustNameCustNRCConcat;
            viewData.CustNameCustNRCConcatWithEnterFromView = this.view.CustNameCustNRCConcatWithEnter;
            viewData.CustNameConcatFromView = this.view.CustNameConcat;
            viewData.CustNRCConcatFromView = this.view.CustNRCConcat;
            viewData.CustFatherNameConcatFromView = this.view.CustFatherNameConcat;
            viewData.CustAddressForOneConcatFromView = this.view.CustAddressForOneConcat;
            viewData.CustNameConcatWithEnterFromView = this.view.CustNameConcatWithEnter;
            
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
            string CustName = "", CustNRC = "", CustFatherName = "", CustAddress = "", CustNameCustNRC = "", CustNameCustNRCAll = "",
                CustNameConcatWithEnter = "", CustAddressForOneConcat = "", CustNameCustNRCConcatWithEnter = ""; 

            CustNameList = CXClientWrapper.Instance.Invoke<ILOMSVE00311, IList<LOMDTO00334>>(x => x.GetCustInfoByAcctNo(dataList[0].AcctNo, sourceBr));
            if (CustNameList.Count > 0)
            {
                int i = 0;
                do
                {
                    if (i > 0)
                    {
                        //CustNameConcat, CustNameConcatWithEnter, CustNameCustNRCConcat, CustFatherNameConcat, CustNRCConcat, CustAddressForOneConcat

                        //CustName = CustName + " @ ";
                        CustName = CustName + ", "; //CustNameConcat
                        CustNameConcatWithEnter = CustName + "\r\n";
                        //CustNRC = CustNRC + " @ ";
                        CustNRC = CustNRC + ", "; //CustNRCConcat
                        //CustFatherName = CustFatherName + " @ ";
                        CustFatherName = CustFatherName + ", "; //CustFatherNameConcat
                        //CustAddress = CustAddress + " @ ";
                        CustAddress = CustAddress + ", ";

                        //CustNameCustNRC = CustNameCustNRC.ToUpper() + ", "; //CustNameCustNRCConcat
                        CustNameCustNRC = CustNameCustNRC + ", ";
                        CustNameCustNRCConcatWithEnter = CustNameCustNRCConcatWithEnter + "\r\n";
                        CustNameCustNRCAll = CustNameCustNRC + ", ";
                    }

                    CustName = CustName + CustNameList[i].CustName;
                    CustNRC = CustNRC + CustNameList[i].CustNRC;
                    CustFatherName = CustFatherName + CustNameList[i].CustFatherName;
                    CustAddress = CustAddress + CustNameList[i].CustAddress;
                    if (i == 0)
                        CustAddressForOneConcat = CustAddress;
                    CustNameConcatWithEnter = CustNameConcatWithEnter + CustNameList[i].CustName;
                    //CustNameCustNRCAll = CustNameCustNRCAll + CustNameList[i].CustNameCustNRCAll;

                    //CustNameCustNRC = CustNameCustNRC + CustNameList[i].CustNameCustNRC;
                    //CustNameCustNRC = CustNameCustNRC + CustNameList[i].CustName.Remove(CustNameList[i].CustName.Trim().Length - 1) + " " + CustNameList[i].CustName.Remove(CustNameList[i].CustName.Trim().Length - 1);
                    CustNameCustNRC = CustNameCustNRC + (CustNameList[i].CustName.ToString() + " (" + CustNameList[i].CustNRC.ToString() + ")");
                    CustNameCustNRCConcatWithEnter = CustNameCustNRCConcatWithEnter + (CustNameList[i].CustName.ToString() + " (" + CustNameList[i].CustNRC.ToString() + ")");

                    i++;

                } while (i < CustNameList.Count);

            }
            if (dataList[0].AcctNo.Substring(5, 1) == "3")
            {
                foreach (LOMDTO00338 dto in dataList)
                {
                    dto.CustCompanyName = dto.CustName + " လုပ္ငန္း ";
                }
            }
            foreach (LOMDTO00338 dto in dataList)
            {
                if (dataList[0].AcctNo.Substring(5, 1) != "3")
                {
                    dto.CustCompanyName = CustName;
                }
                dto.CustName = CustName;
                dto.CustNRC = CustNRC;
                dto.CustAddress = CustAddress;
                dto.CustNameCustNRC = CustNameCustNRC;
                //dto.CustNameCustNRCForAll = CustNameCustNRCAll;
                dto.CustFatherName = CustFatherName;
                dto.CustNameConcatWithEnterFromView = CustNameConcatWithEnter;
                dto.CustAddressForOneConcatFromView = CustAddressForOneConcat;
                dto.CustNameCustNRCConcatWithEnterFromView = CustNameCustNRCConcatWithEnter;
            }
            return dataList;
        }

        public void Print()
        {
            if (this.Validate_Form())
            {
                LOMDTO00338 DTO = this.GetViewData();
                IList<LOMDTO00338> DTOList = new List<LOMDTO00338>();
                DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00311, IList<LOMDTO00338>>(x => x.GetBLLBInfoForContractPrinting(DTO));
                if (DTOList.Count > 0)
                {
                    DTOList = this.GetCustInfoByAcctNo(DTOList, DTO.SourceBr);
                    //CXUIScreenTransit.Transit("frmLOMVEW00343.ReportViewer", true, new object[] { DTOList,CustNameList, this.view.DateFromView,this.view.BudgetYear,
                    //this.view.InsuranceDesp,this.view.PartA,this.view.PartB});

                    string strCustName = DTOList[0].CustName;
                    string strCustNameConcatWithEnter = DTOList[0].CustNameConcatWithEnterFromView;
                    string strCustNRC = DTOList[0].CustNRC;
                    string strCustFatherName = DTOList[0].CustFatherName;
                    string strCustNameCustNRC = DTOList[0].CustNameCustNRC;
                    string strCustAddressForOne = DTOList[0].CustAddressForOneConcatFromView;
                    string strCustNameCustNRCWithEnter = DTOList[0].CustNameCustNRCConcatWithEnterFromView;

                    CXUIScreenTransit.Transit("frmLOMVEW00345.ReportViewer", true, new object[] { DTOList,CustNameList, this.view.DateFromView,this.view.BudgetYear,
                    this.view.InsuranceDesp,this.view.PartA,this.view.PartB,
                    strCustName, strCustNameConcatWithEnter, strCustNRC, strCustFatherName, strCustNameCustNRC, strCustAddressForOne,strCustNameCustNRCWithEnter});
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report. 
                }
            }
        }

        public void Print(IList<LOMDTO00338> DTOListSelectedCust)
        {
            IList<LOMDTO00338> DTOListSelectedCustNew = new List<LOMDTO00338>();
            if (this.Validate_Form())
            {
                LOMDTO00338 DTO = this.GetViewData();
                //IList<LOMDTO00334> DTOList = new List<LOMDTO00334>();
                string companyName = string.Empty;

                string custNameCustNRCConcat = DTO.CustNameCustNRCConcatFromView == null ? "" : DTO.CustNameCustNRCConcatFromView;
                string custNameConcat = DTO.CustNameConcatFromView == null ? "" : DTO.CustNameConcatFromView;
                string custNameConcatWithEnter = DTO.CustNameConcatWithEnterFromView == null ? "" : DTO.CustNameConcatWithEnterFromView;
                string custNRCConcat = DTO.CustNRCConcatFromView == null ? "" : DTO.CustNRCConcatFromView;
                string custFatherNameConcat = DTO.CustFatherNameConcatFromView;
                string custAddressForOneConcat = DTO.CustAddressForOneConcatFromView.Replace("\r\n", " ");
                string strCustNameCustNRCWithEnter = DTO.CustNameCustNRCConcatWithEnterFromView;

                DTOListSelectedCustNew = DTOListSelectedCust;

                DTOListSelectedCust = CXClientWrapper.Instance.Invoke<ILOMSVE00311, IList<LOMDTO00338>>(x => x.GetBLLBInfoForContractPrinting(DTO));
                if (DTOListSelectedCust.Count > 0)
                {
                    companyName = DTOListSelectedCust[0].CustName.ToString();
                    DTOListSelectedCust = this.GetCustInfoByAcctNo(DTOListSelectedCust, DTO.SourceBr);
                    
                    //CXUIScreenTransit.Transit("frmLOMVEW00343.ReportViewer", true, new object[] { DTOList,CustNameList, this.view.DateFromView,this.view.BudgetYear,
                    //this.view.InsuranceDesp,this.view.PartA,this.view.PartB});

                    //CXUIScreenTransit.Transit("frmLOMVEW00345.ReportViewer", true, new object[] { DTOListSelectedCust,DTOListSelectedCustNew, this.view.DateFromView,this.view.BudgetYear, this.view.InsuranceDesp,this.view.PartA,this.view.PartB,
                    //     custNameCustNRCConcat, custNameConcat, custNRCConcat, custFatherNameConcat, custAddressForOneConcat, companyName, custNameConcatWithEnter, strCustNameCustNRCWithEnter});
                    CXUIScreenTransit.Transit("frmLOMVEW00345.ReportViewer", true, new object[] { DTOListSelectedCust,DTOListSelectedCustNew, this.view.DateFromView,this.view.BudgetYear, this.view.InsuranceDesp,this.view.PartA,this.view.PartB,
                         custNameCustNRCConcat, custNameConcat, custNRCConcat, custFatherNameConcat, custAddressForOneConcat, companyName, custNameConcatWithEnter, strCustNameCustNRCWithEnter});
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report. 
                }
            }
        }

        public IList<LOMDTO00338> BindCustomerList(string sourceBr)
        {
            IList<LOMDTO00338> CustNameList = new List<LOMDTO00338>();

            LOMDTO00338 DTO = this.GetViewData();
            IList<LOMDTO00338> DTOList = new List<LOMDTO00338>();
            DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00311, IList<LOMDTO00338>>(x => x.GetBLLBInfoForContractPrinting(DTO));
            if (DTOList.Count > 0)
            {
                CustNameList = CXClientWrapper.Instance.Invoke<ILOMSVE00311, IList<LOMDTO00338>>(x => x.GetCustInfoByAcctNoForBL_LB(DTOList[0].AcctNo, sourceBr));
                if (CustNameList.Count > 0)
                {
                    return CustNameList;
                }
            }
            return CustNameList;
        }

        #endregion
    }
}
