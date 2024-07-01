using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00086 : IPresenter
    {
        ILOMVEW00086 LoanRecordView { set; get; }
        void Save(LOMDTO00086 entity);
        IList<LOMDTO00099> GetLoanRecordByLoanNo(string eno);
        void Delete(string eno);
        int CheckLoanAccNo(string acctNo);
    }
    public interface ILOMVEW00086
    {
        string LoanType { get; set; }
        string Eno { get; set; }
        string TownshipCode { get; set; }
        string VillageCode { get; set; }
        string FinancialYear { get; set; }
        string BusinessCode { get; set; }
        DateTime SuspendDate { get; set; }
        decimal SuspendAmu { get; set; }
        DateTime DeliverDate { get; set; }
        string TotalGroup { get; set; }
        string Population { get; set; }
        string Acre { get; set; }
        decimal SanctionAmu { get; set; }
        DateTime RefundDate { get; set; }
        decimal RefundAmu { get; set; }
        string RefundVrNo { get; set; }
        string Status { get; set; }
        string businessTypeUm { get; set; }

        ILOMCTL00086 LoanRecordController { get;set; }
        ILOMCTL00086 LiveStockLoanController { get; set; }
        LOMDTO00086 ViewData { get; set; }
        LOMDTO00086 PreviousLoanRecord { get; set; }
        FormState FormState { set; get; }
        void Successful(string message, string eno);
        void Failure(string message);
    }
}
