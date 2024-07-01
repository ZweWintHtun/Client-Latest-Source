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
    public class LOMCTL00336 : AbstractPresenter, ILOMCTL00336
    {
        #region Properties
        private ILOMVEW00336 view;
        public ILOMVEW00336 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00336 view)
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

        public LOMDTO00336 GetViewData()
        {
            LOMDTO00336 viewData = new LOMDTO00336();
            if (!String.IsNullOrEmpty(this.view.AcctNo))
            {
                string plNo = CXClientWrapper.Instance.Invoke<ILOMSVE00311, string>(x => x.GetPLNoByACNoAndSourceBr(this.view.AcctNo, this.view.SourceBranch));
                viewData.PLNo = plNo;
            }
            viewData.SourceBr = this.view.SourceBranch;
            viewData.DateFromView = this.view.DateFromView;
            viewData.Reason = this.view.Reason;
            return viewData;
        }

        public bool CheckPLAccountNo(string acctNo)
        {
            try
            {
                if (this.view.AcctNo.Substring(0, 3) == CurrentUserEntity.BranchCode)
                {
                    Nullable<CXDMD00011> accountType;
                    if (CXCLE00012.Instance.IsValidAccountNo(this.view.AcctNo, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2))
                    {
                        IList<PFMDTO00028> AccountInfoList = new List<PFMDTO00028>();
                        AccountInfoList = CXClientWrapper.Instance.Invoke<ILOMSVE00311, IList<PFMDTO00028>>(x => x.IsValidForLoanAcctnoForPLContractPrinting(this.View.AcctNo, CurrentUserEntity.BranchCode));

                        //IList<PFMDTO00072> AccountInfoList = new List<PFMDTO00072>();
                        //AccountInfoList = CXClientWrapper.Instance.Invoke<ILOMSVE00311, IList<PFMDTO00072>>(x => x.IsValidForLoanAcctno(this.View.AcctNo));

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
        
        #endregion

        #region Methods

        private IList<LOMDTO00336> GetCustInfoByAcctNo(IList<LOMDTO00336> dataList, string sourceBr)
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
            foreach (LOMDTO00336 dto in dataList)
            {
                dto.CustName = CustName;
                dto.CustNRC = CustNRC;
                dto.CustFatherName = CustFatherName;
                dto.CustAddress = CustAddress;
            }
            return dataList;
        }

        string[] monthArr = { "ဇန္န၀ါရီ", "ေဖေဖာ္၀ါရီ", "မတ္", "ဧၿပီ", "ေမ", "ဇြန္", "ဇူလိုင္",
                                "ၾသဂုတ္", "စက္တင္ဘာ", "ေအာက္တိုဘာ", "ႏို၀င္ဘာ", "ဒီဇင္ဘာ" };
        string[] numArr = { "၀", "၁", "၂", "၃", "၄", "၅", "၆", "၇", "၈", "၉" };

        private string GetMyanmarString(string str)
        {
            string strMya = str;
            for (int i = 0; i < 10; i++)
            {
                strMya = strMya.Replace(i.ToString(), numArr[i]);
            }
            return strMya;
        }

        public string initY { get { return GetMyanmarString(this.view.DateFromView.Year.ToString()); } }
        public string initM { get { return GetMyanmarString(this.view.DateFromView.Month.ToString()); } }
        public string initD { get { return GetMyanmarString(this.view.DateFromView.Day.ToString()); } }

        public void Print()
        {
            if (this.Validate_Form())
            {
                string startYear = "";
                string startMonth = "";
                string startDay = "";
                string endYear = "";
                string endMonth = "";
                string endDay = "";

                LOMDTO00336 DTO = this.GetViewData();
                IList<LOMDTO00336> DTOList = new List<LOMDTO00336>();
                DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00311, IList<LOMDTO00336>>(x => x.GetPLInfoForContractPrinting(DTO));
                startYear = DTOList[0].startYear;
                startMonth = DTOList[0].startMonth;
                startDay = DTOList[0].startDay;

                endYear = DTOList[0].endYear;
                endMonth = DTOList[0].endMonth;
                endDay = DTOList[0].endDay;

                if (DTOList.Count > 0)
                {
                    DTOList = this.GetCustInfoByAcctNo(DTOList, DTO.SourceBr);
                    //CXUIScreenTransit.Transit("frmLOMVEW00337.ReportViewer", true, new object[] { DTOList, this.view.DateFromView, this.view.Reason
                    //                                                                            ,startYear,startMonth,startDay,endYear,endMonth,endDay
                    //                                                                            ,initialYear,initialMonth,initialDay});

                    CXUIScreenTransit.Transit("frmLOMVEW00251.ReportViewer", true, new object[] { DTOList, this.view.DateFromView, this.view.Reason
                                                                                                ,startYear,startMonth,startDay,endYear,endMonth,endDay
                                                                                                ,initY,initM,initD});
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
