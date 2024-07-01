using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Loan.Dmd.DTO; // Added By AAM (15-Jan-2018)

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    //Added by HWKO (28-Jul-2017)
    public interface ILOMCTL00325 : IPresenter
    {
        ILOMVEW00325 View { get; set; }
        void BindPersonalLoanVoucherInfor(string plno);
        void Save(string plno, string sourcebr);
        void Call_PL_Limits_Voucher_Printing(string rptName, IList<LOMDTO00235> lst_PL_LimitVouPrint);
        string Get_CustomerName_PLVoucher(string plNo);
        DateTime GetSystemDate(string sourceBr);
        DateTime GetLastSettlementDate(string sourceBr);
    }

    //Added by HWKO (28-Jul-2017)
    public interface ILOMVEW00325
    {
        ILOMCTL00325 Controller { get; set; }

        string LoanNo { get; set; }
        string Currency { get; set; }
        string EntryNo { get; set; }
        decimal SanctionAmount { get; set; }

        void ClearControls();
        void Successful(string message, string voucherNo);
        void BindPLVoucherInfo(IList<PFMDTO00072> dtoList);

    }
}
