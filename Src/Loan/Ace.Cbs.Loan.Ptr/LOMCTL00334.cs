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
    public class LOMCTL00334 : AbstractPresenter, ILOMCTL00334
    {
        #region Properties
        private ILOMVEW00334 view;
        public ILOMVEW00334 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00334 view)
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

        public LOMDTO00334 GetViewData()
        {
            LOMDTO00334 viewData = new LOMDTO00334();
            if (!String.IsNullOrEmpty(this.view.AcctNo))
            {
                string hpNo = CXClientWrapper.Instance.Invoke<ILOMSVE00311, string>(x => x.GetHPNoByACNoAndSourceBr(this.view.AcctNo, this.view.SourceBranch));
                viewData.HPNo = hpNo;
            }
            viewData.SourceBr = this.view.SourceBranch;
            viewData.DateFromView = this.view.DateFromView;
            viewData.ProductNameFromView = this.view.ProductName;
            viewData.CarNoFromView = this.view.CarNo;
            viewData.CarBoardNoFromView = this.view.CarBoardNo;
            viewData.NoOfProductFromView = this.view.NoOfProduct;
            viewData.CustNameConcatFromView = this.view.CustNameConcat;
            viewData.CustNameCustNRCConcatFromView = this.view.CustNameCustNRCConcat;
            viewData.CustNameCustNRCConcatWithEnterFromView = this.view.CustNameCustNRCConcatWithEnter;
            viewData.CustNRCConcatFromView = this.view.CustNRCConcat;
            viewData.CustFatherNameConcatFromView = this.view.CustFatherNameConcat;
            viewData.CustAddressForOneConcatFromView = this.view.CustAddressForOneConcat;
            
            //viewData.Cur = this.view.Currency;
            return viewData;
        }

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
        #endregion

        #region Methods

        private IList<LOMDTO00334> GetCustInfoByAcctNo(IList<LOMDTO00334> dataList,string sourceBr)
        {
            string CustName = "", CustNRC = "", CustFatherName = "", CustAddress = "", CustAddressForOne = "", CustNameCustNRC = "";
            IList<LOMDTO00334> CustNameList = new List<LOMDTO00334>();
            CustNameList = CXClientWrapper.Instance.Invoke<ILOMSVE00311, IList<LOMDTO00334>>(x => x.GetCustInfoByAcctNo(dataList[0].AcctNo,sourceBr));
            if (CustNameList.Count > 0)
            {
                int i = 0;
                do
                {
                    if (i > 0)
                    {
                        //CustName = CustName + " @ ";
                        CustName = CustName + ", ";
                        //CustNRC = CustNRC + " @ ";
                        CustNRC = CustNRC + ", ";
                        //CustFatherName = CustFatherName + " @ ";
                        CustFatherName = CustFatherName + ", ";
                        //CustAddress = CustAddress + " @ ";
                        CustAddress = CustAddress + ", ";
                        CustNameCustNRC = CustNameCustNRC.ToUpper() + "\r\n";
                    }

                    CustName = CustName + CustNameList[i].CustName;
                    CustNRC = CustNRC + CustNameList[i].CustNRC;
                    CustFatherName = CustFatherName + CustNameList[i].CustFatherName;
                    CustAddress = CustAddress + CustNameList[i].CustAddress;

                    if(i == 0)
                        CustAddressForOne = CustAddress;

                    CustNameCustNRC = CustNameCustNRC.ToUpper() + CustNameList[i].CustNameCustNRC.ToUpper();

                    i++;

                } while (i < CustNameList.Count);

            }

            //CustAddressForOne = CustAddress;
            //Remove last character
            //if (CustNameList.Count > 1)
            //CustAddressForOne = CustAddressForOne.Remove(CustAddressForOne.Trim().Length - 1);

            foreach (LOMDTO00334 dto in dataList)
            {
                dto.CustName = CustName;
                dto.CustNRC = CustNRC;
                dto.CustFatherName = CustFatherName;
                dto.CustAddress = CustAddress;
                dto.CustNameCustNRC = CustNameCustNRC;
                dto.CustAddressForOne = CustAddressForOne;
            }
            return dataList; 
        }
        
        public void Print()
        {
            if (this.Validate_Form())
            {
                LOMDTO00334 DTO = this.GetViewData();
                IList<LOMDTO00334> DTOList = new List<LOMDTO00334>();
                string companyName = string.Empty;
                DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00311, IList<LOMDTO00334>>(x => x.GetHPInfoForContractPrinting(DTO));
                if (DTOList.Count > 0)
                {
                    companyName = DTOList[0].CustName.ToString();
                    DTOList = this.GetCustInfoByAcctNo(DTOList,DTO.SourceBr);
                    //CXUIScreenTransit.Transit("frmLOMVEW00335.ReportViewer", true, new object[] { DTOList, this.view.DateFromView, this.view.ProductName });
                    CXUIScreenTransit.Transit("frmLOMVEW00344.ReportViewer", true, new object[] { DTOList, this.view.DateFromView, this.view.ProductName, this.view.CarNo, this.view.CarBoardNo, this.view.NoOfProduct});
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report. 
                }
            }
        }

        public void Print(IList<LOMDTO00334> DTOListSelectedCust)
        {
            if (this.Validate_Form())
            {
                LOMDTO00334 DTO = this.GetViewData();
                //IList<LOMDTO00334> DTOList = new List<LOMDTO00334>();
                string companyName = string.Empty;

                string custNameCustNRCConcatWithEnter = DTO.CustNameCustNRCConcatWithEnterFromView == null ? "" : DTO.CustNameCustNRCConcatWithEnterFromView;
                string custNameConcat = DTO.CustNameConcatFromView == null ? "" : DTO.CustNameConcatFromView;
                string custNRCConcat = DTO.CustNRCConcatFromView == null ? "" : DTO.CustNRCConcatFromView;
                string custFatherNameConcat = DTO.CustFatherNameConcatFromView;
                string custAddressForOneConcat = DTO.CustAddressForOneConcatFromView;

                DTOListSelectedCust = CXClientWrapper.Instance.Invoke<ILOMSVE00311, IList<LOMDTO00334>>(x => x.GetHPInfoForContractPrinting(DTO));
                if (DTOListSelectedCust.Count > 0)
                {
                    companyName = DTOListSelectedCust[0].CustName.ToString();
                    DTOListSelectedCust = this.GetCustInfoByAcctNo(DTOListSelectedCust, DTO.SourceBr);
                    //CXUIScreenTransit.Transit("frmLOMVEW00335.ReportViewer", true, new object[] { DTOList, this.view.DateFromView, this.view.ProductName });
                    CXUIScreenTransit.Transit("frmLOMVEW00344.ReportViewer", true, new object[] { DTOListSelectedCust, this.view.DateFromView, this.view.ProductName, this.view.CarNo, this.view.CarBoardNo, this.view.NoOfProduct, custNameConcat, this.view.CustNameCustNRCConcat, custNameCustNRCConcatWithEnter, custNRCConcat, custFatherNameConcat, custAddressForOneConcat, companyName });
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report. 
                }
            }
        }

        public IList<LOMDTO00334> BindCustomerList(string sourceBr)
        {
            IList<LOMDTO00334> CustNameList = new List<LOMDTO00334>();

            LOMDTO00334 DTO = this.GetViewData();
            IList<LOMDTO00334> DTOList = new List<LOMDTO00334>();
            DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00311, IList<LOMDTO00334>>(x => x.GetHPInfoForContractPrinting(DTO));
            if (DTOList.Count > 0)
            {
                CustNameList = CXClientWrapper.Instance.Invoke<ILOMSVE00311, IList<LOMDTO00334>>(x => x.GetCustInfoByAcctNo(DTOList[0].AcctNo, sourceBr));
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
