using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Dmd.DTO;

using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00088 : IPresenter
    {
        ILOMVEW00088 View { get; set; }
        //IList<LOMDTO00085> GetHPVoucherDetails(LOMDTO00085 d);
        void Call_Transfer_Voucher_Printing(string rptName, List<LOMDTO00234> lstsTransferVouPrint);
        string GetDealerBusinessName_For_HPLimitVoucher_Printing(string dealerNo);
        IList<LOMDTO00234> Get_HPLimitVou_Lists(string eno);
        
    }
    public interface ILOMVEW00088
    {
        ILOMCTL00088 Controller { get; set; }
    }
}
