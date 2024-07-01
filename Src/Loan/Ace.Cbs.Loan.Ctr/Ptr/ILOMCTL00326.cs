using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00326 : IPresenter
    {
        ILOMVEW00326 View { get; set; }

        string CheckPLAccountandStartTerm(string hpNo, string sourceBr);
        string Get_PL_PrepaymentInfo_NewLogic(string hpNo, int startTerm, int endTerm, string sourceBr);
        string PL_Manual_Pre_Payment_Process_NewLogic(string hpNo, int startTerm, int endTerm, decimal totalPaidInstallmentAmt, decimal totalPaidPrincipleAmt, decimal totalPaidRentalChgAmt,
                                            decimal rentalDiscountRate, string eno, string sourceBr, int createdUserId, string userName);
    }

    public interface ILOMVEW00326
    {
        ILOMCTL00326 Controller { get; set; }
    }
}
