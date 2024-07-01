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
namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00088 : AbstractPresenter, ILOMCTL00088
    {
        private ILOMVEW00088 view;
        public ILOMVEW00088 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00088 view)
        {
            if (this.view == null)
            {
                this.view = view;

            }
        }
        //public IList<LOMDTO00085> GetHPVoucherDetails(LOMDTO00085 d)
        //{
        //    return CXClientWrapper.Instance.Invoke<ILOMSVE00080, IList<LOMDTO00085>>(x => x.GetHPVoucherDetails(d));
        //}

        // Added By AAM (10-Jan-2018)

        public void Call_Transfer_Voucher_Printing(string rptName,List<LOMDTO00234> lstsTransferVouPrint)
        {
            CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { "frmLOMVEW00088", lstsTransferVouPrint, rptName});
        }

        public string GetDealerBusinessName_For_HPLimitVoucher_Printing(string dealerNo)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00096, string>(x =>x.GetDealerBusinessName_For_HPLimitVoucher_Printing(dealerNo));
        }

        public IList<LOMDTO00234> Get_HPLimitVou_Lists(string eno)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00234>>(x => x.Get_HP_LimitVou_Lists(eno));
        }
    }
}
