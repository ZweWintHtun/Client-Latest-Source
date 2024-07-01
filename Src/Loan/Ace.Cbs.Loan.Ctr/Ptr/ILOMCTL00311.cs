using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Dmd.DTO;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00311 : IPresenter
    {
        ILOMVEW00311 View { get; set; }
        string Acsign { get; set; }
        string BranchCode { get; set; }
        bool CheckPersonalLoanAccountNo(string acctNo , string formname);
        void ClearAllCustomErrors();
        void Save(string BranchCode);
        void BindPersonalLoanInfo();
        IList<LOMDTO00243> Get_PLInfoRegisterEdit_ByAcctNo(string acctNo, string sourceBr);
        string Save_PLInfoRegisterEdit_ByAcctNo(string acctNo, string sourceBr, string companyName, string guaCompanyName
                                                       , string guaName, string guaNRC, string guaPhone, int createdUserId);

        DateTime GetSystemDate(string sourceBr);
        DateTime GetLastSettlementDate(string sourceBr);
    }
    public interface ILOMVEW00311
    {
        ILOMCTL00311 Controller { get; set; }

        string AccountNo { get; set; }
        int RepaymentPeriod { get; set; }
        string CurrencyCode { get; set; }
        string LoanNo { get; set; }
        string GuarantorCompanyName { get; set; }
        //int Duration { get; set; }

        bool isSaveValidate { get; set; }
        bool isActive { get; set; }
        string FormName { get; set; }
        LOMDTO00311 GetViewDataForCommon { get; set; }
        LOMDTO00313 GetViewDataForGuarantee { get; set; }
        //IList<LOMDTO00012> GetPenalFeeList();
        void GetFormControlSetting();

        void BindAccountInfo(IList<PFMDTO00072> accountInfoList);
        void BindPersonalLoanToView(LOMDTO00311 ploanDto);
        //void BindPeanlFee(IList<LOMDTO00012> penalList);
    }
}
