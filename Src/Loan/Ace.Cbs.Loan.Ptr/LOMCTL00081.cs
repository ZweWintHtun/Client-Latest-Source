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
using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00081 : AbstractPresenter, ILOMCTL00081
    {
        public static string HPNo = "";
        public string ResultStr;
        public string balance;
        public string checkStatus;
        public static string eno;
        public List<LOMDTO00084> lst;

        private ILOMVEW00081 view;
        public ILOMVEW00081 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00081 view)
        {
            if (this.view == null)
            {
                this.view = view;

            }
        }

        private IList<PFMDTO00001> customerInformation;
        public IList<PFMDTO00001> CustomerInformation
        {
            get
            {
                if (this.customerInformation == null)
                    this.customerInformation = new List<PFMDTO00001>();
                return customerInformation;
            }
            set
            { this.customerInformation = value; }
        }

        private PFMDTO00067 GetViewData()
        {
            PFMDTO00067 dto = new PFMDTO00067();
            dto.AccountNo = this.view.DealerAC;
            return dto;
        }

        public IList<LOMDTO00081> GetAllStockItem()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00080, IList<LOMDTO00081>>(x => x.GetAllStockItem());
        }

        public IList<LOMDTO00082> GetAllStockGroup()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00080, IList<LOMDTO00082>>(x => x.GetAllStockGroup());
        }

        public IList<LOMDTO00083> GetAllInstallmentTypes()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00080, IList<LOMDTO00083>>(x => x.GetAllInstallmentTypes());
        }

        public void Call_DealerSearch()
        {
            LOMDTO00080 dealerInfoLst = new LOMDTO00080();
            CXUIScreenTransit.Transit("frmLOMVEW00422", true, new object[] { "frmLOMVEW00081", dealerInfoLst });

            this.view.DealerNo = dealerInfoLst.DealerNo;
            this.view.Commission = dealerInfoLst.commission;
        }

        public void Call_AccountEnquiry()
        {
            CXUIScreenTransit.Transit("frmTLMVEW00042", true, new object[] { "frmLOMVEW00081", this.view.Caccount });
        }

        public void Call_GuanteeAccountEnquiry()
        {
            CXUIScreenTransit.Transit("frmTLMVEW00042", true, new object[] { "frmLOMVEW00081", this.view.guanacctno});
        }

        public void Call_HPVoucherDetails(IList<LOMDTO00092> lsts,string dealerAC)
        {
            CXUIScreenTransit.Transit("frmLOMVEW00088", true, new object[] { "frmLOMVEW00081", lsts, dealerAC });
        }

        public void mtxtAccountNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            try
            {
                if (e.HasXmlBaseError)
                    return;
                CustomerInformation.Clear();
                Nullable<CXDMD00011> accountType;
                if (CXCLE00012.Instance.IsValidAccountNo(this.view.Caccount, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2))
                {
                    CustomerInformation = CXClientWrapper.Instance.Invoke<ILOMSVE00064, IList<PFMDTO00001>>(x => x.SelectByAccountNumber(this.view.Caccount, DateTime.Now));

                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                        return;
                    }

                }
                else if (accountType == CXDMD00011.DomesticAccountType)
                {
                    ChargeOfAccountDTO COAinfo = CXCLE00002.Instance.GetClientData<ChargeOfAccountDTO>("COA.Client.SelectAccountName", new object[] { this.view.Caccount, this.view.SourceBr, true });
                    if (COAinfo == null)
                    {
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00046);
                        return;
                    }
                }
                else
                {
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00046);
                    return;
                }

                if (CustomerInformation != null || customerInformation.Count > 0)
                {
                    this.view.Caccount = CustomerInformation[0].AccountNo;
                }
            }
            catch (Exception ex)
            {
                this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), ex.Message);
            }
        }

        public void mtxtGraunteeAcctno_CustomValidating(object sender, ValidationEventArgs e)
        {
            try
            {
                if (e.HasXmlBaseError)
                    return;
                CustomerInformation.Clear();
                Nullable<CXDMD00011> accountType;
                if (CXCLE00012.Instance.IsValidAccountNo(this.view.guanacctno, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2))
                {
                    CustomerInformation = CXClientWrapper.Instance.Invoke<ILOMSVE00064, IList<PFMDTO00001>>(x => x.SelectByAccountNumber(this.view.guanacctno, DateTime.Now));

                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        this.SetCustomErrorMessage(this.GetControl("mtxtGraunteeAcctno"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                        return;
                    }

                }
                else if (accountType == CXDMD00011.DomesticAccountType)
                {
                    ChargeOfAccountDTO COAinfo = CXCLE00002.Instance.GetClientData<ChargeOfAccountDTO>("COA.Client.SelectAccountName", new object[] { this.view.guanacctno, this.view.SourceBr, true });
                    if (COAinfo == null)
                    {
                        this.SetCustomErrorMessage(this.GetControl("mtxtGraunteeAcctno"), CXMessage.MV00046);
                        return;
                    }

                }
                else
                {
                    this.SetCustomErrorMessage(this.GetControl("mtxtGraunteeAcctno"), CXMessage.MV00046);
                    return;
                }

                if (CustomerInformation != null || customerInformation.Count > 0)
                {
                    this.view.guanacctno = CustomerInformation[0].AccountNo;
                }
            }
            catch (Exception ex)
            {
                this.SetCustomErrorMessage(this.GetControl("mtxtGraunteeAcctno"), ex.Message);
            }

        }

        public PFMDTO00067 GetAccountInformation()
        {
            try
            {
                return CXClientWrapper.Instance.Invoke<ILOMSVE00080, PFMDTO00067>(service => service.GetAccountInformation(this.view.Caccount));
            }
            catch
            {
                throw new Exception();
            }
        }

        public LOMDTO00084 AddHirePurchaseRegistration(string hpno, string caccount, string dealerAC, string dealerStatus, string guanteeAcctNo, decimal downPayPercent, decimal rChgsPercent,// decimal sChgsPercent,
                                           decimal nextYrRChgsPercent, decimal disAmt, decimal docFees, int gapPeriod, decimal commPercent, string stockGCode, string stockISubCode, string relatedGLACode, decimal productValue, int payDuration, int payOptionId,
                                           DateTime repaySDate, DateTime repayExpDate, string sourceBr, string remarks, int createdUserId, string eno, string username)
        {
            LOMDTO00084 dto = CXClientWrapper.Instance.Invoke<ILOMSVE00080, LOMDTO00084>(x => x.AddHirePurchaseRegistration(hpno, caccount, dealerAC, dealerStatus, guanteeAcctNo, downPayPercent, rChgsPercent, //sChgsPercent,
                                                nextYrRChgsPercent, disAmt, docFees, gapPeriod, commPercent, stockGCode, stockISubCode, relatedGLACode, productValue, payDuration, payOptionId,
                                                repaySDate, repayExpDate, sourceBr, remarks, createdUserId, eno, CurrentUserEntity.CurrentUserName));
            return dto;
        }

        public string CheckBalance(string caccount, string sourceBr)
        {
            balance = CXClientWrapper.Instance.Invoke<ILOMSVE00080, string>(x => x.CheckBalance(caccount,sourceBr));
            return balance;
        }

        public string CheckAccountExistsOrValid(string caccount, string sourceBr)
        {
            checkStatus = CXClientWrapper.Instance.Invoke<ILOMSVE00080, string>(x => x.CheckAccountExistsOrValid(caccount,sourceBr));
            return checkStatus;
        }

        public IList<LOMDTO00092> GetHPVoucherDetails(LOMDTO00092 d)
        {
            LOMDTO00092 dto = new LOMDTO00092();
            dto.eno = d.eno;
            return CXClientWrapper.Instance.Invoke<ILOMSVE00080, IList<LOMDTO00092>>(x => x.GetHPVoucherDetails(d));
        }

        public string GetInstallmentAmt(decimal netAmt, int noOfTerms)
        {
           return CXClientWrapper.Instance.Invoke<ILOMSVE00080, string>(x =>x.GetInstallmentAmt(netAmt,noOfTerms));
        }

        //public IList<decimal> GetRateForHPReg()
        //{
        //    return CXClientWrapper.Instance.Invoke<ILOMSVE00080, IList<decimal>>(x => x.GetRateForHPReg());
        //}

        public IList<LOMDTO00080> GetAllDealerInformation(string sourceBr)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00080, IList<LOMDTO00080>>(x => x.GetAllDealerInformation(sourceBr));
        }

        public string GetDealerCommission_ByDealerNo(string dealerNo,string sourceBr)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00080,string>(x => x.GetDealerCommission_ByDealerNo(dealerNo,sourceBr));
        }

        public IList<LOMDTO00237> Get_HP_Information_For_Enquiry(string acctNo,string sourceBr)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00237>>(x => x.Get_HP_Information_For_Enquiry(acctNo, sourceBr));
        }

        public IList<LOMDTO00240> Get_TotalInterestAndFirstInstallment(LOMDTO00084 dto)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00240>>(x => x.Get_TotalInterestAndFirstInstallment(dto));
        }

        //Added by YMP at 30-07-2019 : [Seperating EOD Process] To show system date (not PC date) at report
        public DateTime GetSystemDate(string sourceBr)
        {
            TCMDTO00001 systemStartInfo = CXClientWrapper.Instance.Invoke<ICXSVE00006, TCMDTO00001>(x => x.SelectStartBySourceBr(sourceBr));
            DateTime systemDate = systemStartInfo.Date;
            return systemDate;
        }

        //Added by HMW at 28-08-2019 : [Seperating EOD Process] Check Settlement Date to show form
        public DateTime GetLastSettlementDate(string sourceBr)
        {
            DateTime lastSettlementDate = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.LastSettlementDate), sourceBr);
            return lastSettlementDate;
        }

        public TLMDTO00018 CountofLoan_byAccountNo(string AccountNo, string TranName)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00405, TLMDTO00018>(x => x.CountofLoan_byAccountNo(AccountNo, TranName));
        }
    }
}
